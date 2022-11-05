Imports System.Data

Public Class Prices
    Dim bm As New BasicMethods

    Dim dt As New DataTable
    Dim dv As New DataView
    Public Header As String = ""
    Public Flag As Integer = 1
    Dim Tablename As String = "CustomerItems"
    Dim tbl As String = "Customers"
    Dim Key As String = "CustomerId"
    Dim ItemsTable As String = "Items"

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If Flag = 2 Then
            lblToId.Content = "المورد"
            Tablename = "SupplierItems"
            tbl = "Suppliers"
            Key = "SupplierId"
        End If
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

    End Sub

    Private Sub ToId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ToId.KeyUp
        If bm.ShowHelp(lblToId.Content, ToId, ToName, e, "select Id,Name from " & tbl) Then
            ToId_LostFocus(Nothing, Nothing)
        End If
    End Sub

    Private Sub ToId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ToId.LostFocus
        bm.LostFocus(ToId, ToName, "select Name from " & tbl & " where Id=" & ToId.Text.Trim())
    End Sub


    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles Me.PreviewKeyDown
        Try
            If e.Key = Input.Key.Up Then
                DataGridView1.SelectedIndex = DataGridView1.SelectedIndex - 1
            ElseIf e.Key = Input.Key.Down Then
                DataGridView1.SelectedIndex = DataGridView1.SelectedIndex + 1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSave.Click
        bm.ExecuteNonQuery("delete " & Tablename & " where " & Key & "=" & ToId.Text & " and (dbo.GetItemGroupId(ItemId)='" & Val(GroupId.Text) & "' or '" & Val(GroupId.Text) & "'=0) and (dbo.GetItemTypeId(ItemId)='" & Val(TypeId.Text) & "' or '" & Val(TypeId.Text) & "'=0)")
        For i As Integer = 0 To dt.Rows.Count - 1
            bm.ExecuteNonQuery("insert " & Tablename & " (" & Key & ",ItemId,Price,PriceSub) select '" & ToId.Text & "','" & dt.Rows(i)(0) & "','" & dt.Rows(i)(2) & "','" & dt.Rows(i)(3) & "'")
        Next
        btnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub LoadResource()
        'lblName.SetResourceReference(Label.ContentProperty, "Name")
    End Sub

    Private Sub GetData()

        Try
            If ToId.Text = "" Then Return
            dt = New DataTable
            dt = bm.ExecuteAdapter("select It.Id 'كود الصنف',It.Name 'اسم الصنف',isnull(t.Price,it.SalesPrice) 'سعر رئيسى',isnull(t.PriceSub,it.SalesPriceSub) 'سعر فرعى'	from (select * from " & Tablename & " where (CustomerId='" & ToId.Text & "' or CustomerId is null)) t right join " & ItemsTable & " it on(t.ItemId=it.Id) where (it.GroupId='" & Val(GroupId.Text) & "' or '" & Val(GroupId.Text) & "'=0) and (it.TypeId='" & Val(TypeId.Text) & "' or '" & Val(TypeId.Text) & "'=0) order by It.Id")

            If dt.Rows.Count = 0 Then Return
            ToId.IsEnabled = False
            GroupId.IsEnabled = False
            TypeId.IsEnabled = False

            dt.TableName = "tbl"

            dv.Table = dt
            DataGridView1.ItemsSource = dv

            DataGridView1.Columns(0).IsReadOnly = True
            DataGridView1.Columns(1).IsReadOnly = True
            DataGridView1.Columns(1).Width = 400
            DataGridView1.SelectedIndex = 0
        Catch
        End Try

    End Sub


    Private Sub btnNew_Click(sender As Object, e As RoutedEventArgs) Handles btnNew.Click
        GroupId.IsEnabled = True
        TypeId.IsEnabled = True
        ToId.IsEnabled = True

        GroupId.Clear()
        TypeId.Clear()
        ToId.Clear()

        GroupName.Clear()
        TypeName.Clear()
        ToName.Clear()

        DataGridView1.ItemsSource = Nothing
    End Sub


    Private Sub TypeId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles TypeId.KeyUp
        bm.ShowHelp("Types", TypeId, TypeName, e, "select cast(Id as varchar(100)) Id,Name from Types where GroupId=" & GroupId.Text.Trim)
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles GroupId.KeyDown, TypeId.KeyDown, ToId.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub GroupId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles GroupId.LostFocus
        bm.LostFocus(GroupId, GroupName, "select Name from Groups where Id=" & GroupId.Text.Trim())
        'TypeId_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub TypeId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TypeId.LostFocus
        bm.LostFocus(TypeId, TypeName, "select Name from Types where GroupId=" & GroupId.Text.Trim & " and Id=" & TypeId.Text.Trim())
        GetData()
    End Sub

    Private Sub GroupId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles GroupId.KeyUp
        If bm.ShowHelp("Groups", GroupId, GroupName, e, "select cast(Id as varchar(100)) Id,Name from Groups") Then
            GroupId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub DataGridView1_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.PreviewKeyDown
        If e.Key = Input.Key.Enter Then
            e.Handled = True
        End If
    End Sub
End Class