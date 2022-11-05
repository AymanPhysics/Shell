﻿Imports System.Data

Public Class HelpCustomers
    Dim bm As New BasicMethods
    Public FirstColumn As String = "ID", SecondColumn As String = "Name", ThirdColumn As String = "Tel", FourthColumn As String = "Mobile", FifthColumn As String = "Address", SixthColumn As String = "Type", SeventhColumn As String = "AccNo"

    Dim dt As New DataTable
    Dim dv As New DataView
    Public Header As String = ""
    Private Sub Help_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        bm.FillCombo("Chart", CboAccNo, " where LinkFile=1")
        Type.SelectedIndex = 0
        LoadResource()
        Banner1.StopTimer = True
        Banner1.Header = Header
        LoadData()
        CboAccNo.SelectedValue = Val(Md.CustAccNo)

        'If Md.MyProject = Client.ClothesRed Then
        '    Banner1.R.Fill = System.Windows.Media.Brushes.Red
        '    Banner1.lblMain.Foreground = System.Windows.Media.Brushes.White
        '    Banner1.Background = System.Windows.Media.Brushes.White
        '    Banner1.Foreground = System.Windows.Media.Brushes.Red
        'End If
        txtArName.Focus()
    End Sub

    Private Sub txtId_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.GotFocus
        Try
            dv.Sort = FirstColumn
        Catch
        End Try
    End Sub

    Private Sub txtArName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArName.GotFocus
        Try
            dv.Sort = SecondColumn
        Catch
        End Try
    End Sub

    Private Sub txtTel_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTel.GotFocus
        Try
            dv.Sort = ThirdColumn
        Catch
        End Try
    End Sub

    Private Sub txtMob_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMob.GotFocus
        Try
            dv.Sort = FourthColumn
        Catch
        End Try
    End Sub

    Private Sub txtAddress_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.GotFocus
        Try
            dv.Sort = FifthColumn
        Catch
        End Try
    End Sub

    Private Sub Type_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type.GotFocus
        Try
            dv.Sort = SixthColumn
        Catch
        End Try
    End Sub

    Private Sub CboAccNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAccNo.GotFocus
        Try
            dv.Sort = SeventhColumn
        Catch
        End Try
    End Sub


    Private Sub txtId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged, txtArName.TextChanged, txtTel.TextChanged, txtMob.TextChanged, txtAddress.TextChanged, Type.SelectionChanged, CboAccNo.SelectionChanged
        Try
            dv.RowFilter = " [" & FirstColumn & "] like '%" & txtID.Text & "%' and [" & SecondColumn & "] like '%" & txtArName.Text & "%' and [" & ThirdColumn & "] like '%" & txtTel.Text & "%' and [" & FourthColumn & "] like '%" & txtMob.Text & "%' and [" & FifthColumn & "] like '%" & txtAddress.Text & "%' and [" & SixthColumn & "] like '%" & Type.Items(Type.SelectedIndex).Content & "%' and ([" & SeventhColumn & "] = '" & CboAccNo.SelectedValue.ToString & "' or " & CboAccNo.SelectedIndex & "=0)"
        Catch ex As Exception
        End Try
    End Sub

    Public SelectedId As Integer = 0
    Public SelectedName As String = ""

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles Me.PreviewKeyDown
        Try
            If e.Key = System.Windows.Input.Key.Enter Then
                SelectedId = DataGridView1.Items(DataGridView1.SelectedIndex)(0)
                SelectedName = DataGridView1.Items(DataGridView1.SelectedIndex)(1)
                Close()
            ElseIf e.Key = Input.Key.Escape Then
                Close()
            ElseIf e.Key = Input.Key.Up Then
                DataGridView1.SelectedIndex = DataGridView1.SelectedIndex - 1
                If DataGridView1.SelectedIndex > -1 Then DataGridView1.ScrollIntoView(DataGridView1.SelectedItem)
            ElseIf e.Key = Input.Key.Down Then
                DataGridView1.SelectedIndex = DataGridView1.SelectedIndex + 1
                If DataGridView1.SelectedIndex > -1 Then DataGridView1.ScrollIntoView(DataGridView1.SelectedItem)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub DataGridView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles DataGridView1.MouseDoubleClick
        Try
            SelectedId = DataGridView1.Items(DataGridView1.SelectedIndex)(0)
            SelectedName = DataGridView1.Items(DataGridView1.SelectedIndex)(1)
            Close()
        Catch ex As Exception
        End Try
    End Sub



    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        If txtArName.Text.Trim = "" Then Return
        If Type.SelectedIndex < 1 Then
            bm.ShowMSG("برجاء تحديد النوع")
            Type.Focus()
            Return
        End If
        If CboAccNo.SelectedIndex < 1 Then
            bm.ShowMSG("برجاء تحديد الحساب")
            CboAccNo.Focus()
            Return
        End If
        txtID.Clear()

        For i As Integer = 0 To dv.Table.Rows.Count - 1
            If txtArName.Text.Trim = dv.Table.Rows(i).Item(1).ToString Then Return
        Next

        txtArName.Text = txtArName.Text.Trim
        txtTel.Text = txtTel.Text.Trim
        txtMob.Text = txtMob.Text.Trim
        txtAddress.Text = txtAddress.Text.Trim

        If Not bm.AddItemToTable("Customers", {"Name", "Tel", "Mobile", "Address", "Type", "AccNo"}, {txtArName.Text, txtTel.Text, txtMob.Text, txtAddress.Text, Type.SelectedIndex - 1, CboAccNo.SelectedValue.ToString}) Then Return
        LoadData()
        DataGridView1.SelectedIndex = dv.Table.Rows.Count - 1

        txtId_TextChanged(Nothing, Nothing)
    End Sub

    Dim IsLoaded As Boolean = False
    Private Sub LoadResource()
        If IsLoaded Then Return
        IsLoaded = True
        'lblName.SetResourceReference(Label.ContentProperty, "Name")

        FirstColumn = Application.Current.MainWindow.Resources.Item(FirstColumn)
        SecondColumn = Application.Current.MainWindow.Resources.Item(SecondColumn)
        ThirdColumn = Application.Current.MainWindow.Resources.Item(ThirdColumn)
        FourthColumn = Application.Current.MainWindow.Resources.Item(FourthColumn)
        FifthColumn = Application.Current.MainWindow.Resources.Item(FifthColumn)
        SixthColumn = Application.Current.MainWindow.Resources.Item(SixthColumn)
        'Application.Current.MainWindow.Resources.Item(SeventhColumn)

    End Sub

    Private Sub LoadData()
        Try
            dt = bm.ExecuteAdapter("CustomersSearch")
            dt.TableName = "tbl"
            dt.Columns(0).ColumnName = FirstColumn
            dt.Columns(1).ColumnName = SecondColumn
            dt.Columns(2).ColumnName = ThirdColumn
            dt.Columns(3).ColumnName = FourthColumn
            dt.Columns(4).ColumnName = FifthColumn
            dt.Columns(5).ColumnName = SixthColumn
            dt.Columns(6).ColumnName = SeventhColumn
            dv.Table = dt
            DataGridView1.ItemsSource = dv
            DataGridView1.Columns(0).Width = 85
            DataGridView1.Columns(1).Width = 165
            DataGridView1.Columns(2).Width = 90
            DataGridView1.Columns(3).Width = 90
            DataGridView1.Columns(4).Width = 120
            DataGridView1.Columns(5).Width = 120
            DataGridView1.Columns(6).Visibility = Visibility.Hidden
            DataGridView1.Columns(7).Width = 200

            DataGridView1.SelectedIndex = 0
        Catch
        End Try

    End Sub

End Class