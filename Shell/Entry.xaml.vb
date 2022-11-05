﻿Imports System.Data
Imports System.Windows
Imports System.Windows.Media
Imports System.Management

Public Class Entry

    Public TableName As String = "Entry"
    Public TableDetailsName As String = "EntryDt"
    Public SubId As String = "InvoiceNo"

    Dim dv As New DataView
    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Dim StaticsDt As New DataTable
    WithEvents G As New MyGrid
    WithEvents MyTimer As New Threading.DispatcherTimer
    Public Flag As Integer
    

    Sub NewId()
        InvoiceNo.Clear()
        InvoiceNo.IsEnabled = False
    End Sub

    Sub UndoNewId()
        InvoiceNo.IsEnabled = True
    End Sub

    Private Sub Sales_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

        bm.Fields = New String() {SubId, "DayDate", "Notes"}
        bm.control = New Control() {InvoiceNo, DayDate, Notes}
        bm.KeyFields = New String() {SubId}

        bm.Table_Name = TableName

        LoadWFH()
        btnNew_Click(Nothing, Nothing)
    End Sub


    Structure GC
        Shared Debit As String = "Debit"
        Shared Credit As String = "Credit"
        Shared MainAccNo As String = "MainAccNo"
        Shared SubAccNo As String = "SubAccNo"
        Shared CostCenterId As String = "CostCenterId"
        Shared Notes As String = "Notes"
        Shared DocNo As String = "DocNo"
    End Structure


    Private Sub LoadWFH()
        WFH.Child = G

        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue
        G.Columns.Add(GC.Debit, "مدين")
        G.Columns.Add(GC.Credit, "دائن")
        G.Columns.Add(GC.MainAccNo, "الحساب")
        G.Columns.Add(GC.SubAccNo, "الفرعى")
        G.Columns.Add(GC.CostCenterId, "م. التكلفة")
        G.Columns.Add(GC.Notes, "البيان")
        G.Columns.Add(GC.DocNo, "رقم المستند")

        G.Columns(GC.Debit).FillWeight = 100
        G.Columns(GC.Credit).FillWeight = 100
        G.Columns(GC.MainAccNo).FillWeight = 80
        G.Columns(GC.SubAccNo).FillWeight = 80
        G.Columns(GC.CostCenterId).FillWeight = 80
        G.Columns(GC.Notes).FillWeight = 200
        G.Columns(GC.DocNo).FillWeight = 100

        'G.Columns(GC.Name).ReadOnly = True

        'G.Columns(GC.UnitQty).Visible = False

        If Md.ShowCostCenter Then
            G.Columns(GC.CostCenterId).Visible = True
            CostCenterName.Visibility = Visibility.Visible
        Else
            G.Columns(GC.CostCenterId).Visible = False
            CostCenterName.Visibility = Visibility.Hidden
        End If

        AddHandler G.CellEndEdit, AddressOf GridCalcRow
        AddHandler G.KeyDown, AddressOf GridKeyDown
        AddHandler G.CellBeginEdit, AddressOf G_CellBeginEdit
        AddHandler G.SelectionChanged, AddressOf G_SelectionChanged
    End Sub

    Dim lop As Boolean = False
 
    Sub ClearRow(ByVal i As Integer)
        G.Rows(i).Cells(GC.Debit).Value = Nothing
        G.Rows(i).Cells(GC.Credit).Value = Nothing
        G.Rows(i).Cells(GC.MainAccNo).Value = Nothing
        G.Rows(i).Cells(GC.SubAccNo).Value = Nothing
        G.Rows(i).Cells(GC.CostCenterId).Value = Nothing
        G.Rows(i).Cells(GC.Notes).Value = Nothing
        G.Rows(i).Cells(GC.DocNo).Value = Nothing
    End Sub

    Private Sub GridCalcRow(ByVal sender As Object, ByVal e As Forms.DataGridViewCellEventArgs)
        Try
            If G.Columns(e.ColumnIndex).Name = GC.Debit Then
                G.Rows(e.RowIndex).Cells(GC.Debit).Value = Val(G.Rows(e.RowIndex).Cells(GC.Debit).Value)
                If Val(G.Rows(e.RowIndex).Cells(GC.Debit).Value) <> 0 Then
                    G.Rows(e.RowIndex).Cells(GC.Credit).Value = 0
                    G.Rows(e.RowIndex).Cells(GC.Credit).ReadOnly = True
                    G.CurrentCell = G.Rows(e.RowIndex).Cells(GC.MainAccNo)
                Else
                    G.Rows(e.RowIndex).Cells(GC.Credit).ReadOnly = False
                    G.CurrentCell = G.Rows(e.RowIndex).Cells(GC.Credit)
                End If
            ElseIf G.Columns(e.ColumnIndex).Name = GC.Credit Then
                G.Rows(e.RowIndex).Cells(GC.Credit).Value = Val(G.Rows(e.RowIndex).Cells(GC.Credit).Value)
                If Val(G.Rows(e.RowIndex).Cells(GC.Credit).Value) <> 0 Then
                    G.Rows(e.RowIndex).Cells(GC.Debit).Value = 0
                    G.Rows(e.RowIndex).Cells(GC.Debit).ReadOnly = True
                Else
                    G.Rows(e.RowIndex).Cells(GC.Debit).ReadOnly = False
                End If
            ElseIf G.Columns(e.ColumnIndex).Name = GC.MainAccNo Then
                bm.AccNoLostFocusGrid(G.Rows(e.RowIndex).Cells(GC.MainAccNo), MainAccName)
                dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & Val(G.Rows(e.RowIndex).Cells(GC.MainAccNo).Value) & ")")
                If dt.Rows.Count = 0 Then
                    G.Rows(e.RowIndex).Cells(GC.SubAccNo).ReadOnly = True
                Else
                    G.Rows(e.RowIndex).Cells(GC.SubAccNo).ReadOnly = False
                End If
                GridCalcRow(sender, New Forms.DataGridViewCellEventArgs(G.Columns(GC.SubAccNo).Index, e.RowIndex))
                'G.CurrentCell = G.Rows(G.CurrentCell.RowIndex).Cells(GC.SubAccNo)
            ElseIf G.Columns(e.ColumnIndex).Name = GC.SubAccNo Then
                dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & Val(G.Rows(e.RowIndex).Cells(GC.MainAccNo).Value) & ")")
                If dt.Rows.Count > 0 Then
                    bm.LostFocusGrid(G.Rows(e.RowIndex).Cells(GC.SubAccNo), SubAccName, "select Name from " & dt.Rows(0)("TableName") & " where Id=" & Val(G.Rows(e.RowIndex).Cells(GC.SubAccNo).Value) & " and AccNo=" & Val(G.Rows(e.RowIndex).Cells(GC.MainAccNo).Value))
                    'G.CurrentCell = G.Rows(G.CurrentCell.RowIndex).Cells(GC.CostCenterId)
                Else
                    G.Rows(e.RowIndex).Cells(GC.SubAccNo).Value = ""
                    SubAccName.Content = ""
                End If
            ElseIf G.Columns(e.ColumnIndex).Name = GC.CostCenterId Then
                bm.CostCenterIdLostFocusGrid(G.Rows(e.RowIndex).Cells(GC.CostCenterId), CostCenterName)
            End If
            CalcTotal()
            G.EditMode = Forms.DataGridViewEditMode.EditOnEnter
        Catch ex As Exception
        End Try
    End Sub



    Sub FillControls()
        If lop Then Return
        lop = True
        UndoNewId()
        bm.FillControls()

        Dim dt As DataTable = bm.ExecuteAdapter("select * from " & TableDetailsName & " where InvoiceNo=" & InvoiceNo.Text)

        G.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Debit).Value = dt.Rows(i)("Debit").ToString
            G.Rows(i).Cells(GC.Credit).Value = dt.Rows(i)("Credit").ToString
            G.Rows(i).Cells(GC.MainAccNo).Value = dt.Rows(i)("MainAccNo").ToString
            GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.MainAccNo).Index, i))
            G.Rows(i).Cells(GC.SubAccNo).Value = dt.Rows(i)("SubAccNo").ToString
            GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.SubAccNo).Index, i))
            G.Rows(i).Cells(GC.CostCenterId).Value = dt.Rows(i)("CostCenterId").ToString
            GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.CostCenterId).Index, i))
            G.Rows(i).Cells(GC.Notes).Value = dt.Rows(i)("Notes").ToString
            G.Rows(i).Cells(GC.DocNo).Value = dt.Rows(i)("DocNo").ToString
        Next
        DayDate.Focus()
        G.RefreshEdit()
        lop = False
        CalcTotal()
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        bm.FirstLast(New String() {SubId}, "Max", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        bm.NextPrevious(New String() {SubId}, New String() {InvoiceNo.Text}, "Next", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnPrint.Click
        btnSave_Click(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not CType(sender, Button).IsEnabled Then Return

        For i As Integer = 0 To G.Rows.Count - 1
            If Val(G.Rows(i).Cells(GC.Debit).Value) = 0 AndAlso Val(G.Rows(i).Cells(GC.Credit).Value) = 0 Then
                Continue For
            End If
            If Val(G.Rows(i).Cells(GC.MainAccNo).Value) = 0 Then
                bm.ShowMSG("برجاء تحديد الحساب بالسطر " & (i + 1).ToString)
                G.Focus()
                G.CurrentCell = G.Rows(i).Cells(GC.MainAccNo)
                Return
            ElseIf Not G.Rows(i).Cells(GC.SubAccNo).ReadOnly AndAlso Val(G.Rows(i).Cells(GC.SubAccNo).Value) = 0 Then
                bm.ShowMSG("برجاء تحديد الفرعى بالسطر " & (i + 1).ToString)
                G.Focus()
                G.CurrentCell = G.Rows(i).Cells(GC.SubAccNo)
                Return
            End If
        Next

        If Not IsDate(DayDate.SelectedDate) Then
            bm.ShowMSG("برجاء تحديد التاريخ")
            DayDate.Focus()
            Return
        ElseIf Val(Diff.Text) <> 0 Then
            bm.ShowMSG("المدين لا يساوى الدائن")
            Return
        End If

        G.EndEdit()

        Dim State As BasicMethods.SaveState = BasicMethods.SaveState.Update
        If InvoiceNo.Text.Trim = "" Then
            InvoiceNo.Text = bm.ExecuteScalar("select max(" & SubId & ")+1 from " & TableName)
            If InvoiceNo.Text = "" Then InvoiceNo.Text = "1"
            lblLastEntry.Text = InvoiceNo.Text
            State = BasicMethods.SaveState.Insert
        End If

        bm.DefineValues()
        If Not bm.Save(New String() {SubId}, New String() {InvoiceNo.Text.Trim}, State) Then
            If State = BasicMethods.SaveState.Insert Then
                InvoiceNo.Text = ""
                lblLastEntry.Text = ""
            End If
            Return
        End If

        If Not bm.SaveGrid(G, TableDetailsName, New String() {"InvoiceNo"}, New String() {InvoiceNo.Text}, New String() {"Debit", "Credit", "MainAccNo", "SubAccNo", "CostCenterId", "Notes", "DocNo"}, New String() {GC.Debit, GC.Credit, GC.MainAccNo, GC.SubAccNo, GC.CostCenterId, GC.Notes, GC.DocNo}, New VariantType() {VariantType.Decimal, VariantType.Decimal, VariantType.Integer, VariantType.Integer, VariantType.Integer, VariantType.String, VariantType.String}, New String() {GC.MainAccNo}) Then Return

        If sender Is btnPrint Then
            PrintPone(sender)
        End If

        If Not DontClear Then btnNew_Click(sender, e)
        AllowClose = True
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        bm.FirstLast(New String() {SubId}, "Min", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearControls()
        DayDate.Focus()
    End Sub

    Sub ClearControls()
        Try
            NewId()
            Dim d As DateTime = Nothing
            Try
                If d.Year = 1 Then d = bm.MyGetDate
                d = DayDate.SelectedDate
            Catch ex As Exception
            End Try

            bm.ClearControls(False)
            
            MainAccName.Content = ""
            SubAccName.Content = ""
            CostCenterName.Content = ""

            DayDate.SelectedDate = bm.MyGetDate()
            G.Rows.Clear()
            CalcTotal()
        Catch
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & InvoiceNo.Text.Trim & "'")

            bm.ExecuteNonQuery("delete from " & TableDetailsName & " where " & SubId & "='" & InvoiceNo.Text.Trim & "'")
            btnNew_Click(sender, e)
        End If
    End Sub

    Private Sub btnPrevios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevios.Click
        bm.NextPrevious(New String() {SubId}, New String() {InvoiceNo.Text}, "Back", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub
    Dim lv As Boolean = False
    Private Sub txtID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoiceNo.LostFocus
        If lv Then
            Return
        End If
        lv = True

        bm.DefineValues()
        Dim dt As New DataTable
        bm.RetrieveAll(New String() {SubId}, New String() {InvoiceNo.Text.Trim}, dt)
        If dt.Rows.Count = 0 Then
            ClearControls()
            lv = False
            Return
        End If
        FillControls()
        lv = False
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles InvoiceNo.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub txtID_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs)
        bm.MyKeyPress(sender, e, True)
    End Sub

    Dim AllowClose As Boolean = False
    
    Private Sub btnDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDeleteRow.Click
        Try
            If Not G.CurrentRow.ReadOnly AndAlso bm.ShowDeleteMSG("MsgDeleteRow") Then
                G.Rows.Remove(G.CurrentRow)
                CalcTotal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrintPone(ByVal sender As System.Object)
        Dim rpt As New ReportViewer
        rpt.paraname = New String() {"@InvoiceNo", "Header"}
        rpt.paravalue = New String() {InvoiceNo.Text, CType(Parent, Page).Title}
        rpt.Rpt = "EntryOne.rpt"
        rpt.ShowDialog()
    End Sub


    Dim LopCalc As Boolean = False
    Private Sub CalcTotal()
        If LopCalc Or lop Then Return
        Try
            LopCalc = True
            Debit.Text = Math.Round(0, 2)
            Credit.Text = Math.Round(0, 2)
            Diff.Text = Math.Round(0, 2)
            For i As Integer = 0 To G.Rows.Count - 1
                Debit.Text += Val(G.Rows(i).Cells(GC.Debit).Value)
                Credit.Text += Val(G.Rows(i).Cells(GC.Credit).Value)
            Next
            Diff.Text = Val(Debit.Text) - Val(Credit.Text)

            LopCalc = False
        Catch ex As Exception
        End Try
    End Sub

    Dim DontClear As Boolean = False
    
    Private Sub GridKeyDown(ByVal sender As Object, ByVal e As Forms.KeyEventArgs)
        Try
            If G.CurrentCell.RowIndex = G.Rows.Count - 1 Then
                Dim c = G.CurrentCell.RowIndex
                G.Rows.Add()
                G.CurrentCell = G.Rows(c).Cells(G.CurrentCell.ColumnIndex)
            End If
            If G.CurrentCell.ColumnIndex = G.Columns(GC.MainAccNo).Index Then
                If bm.AccNoShowHelpGrid(G.CurrentRow.Cells(GC.MainAccNo), MainAccName, e, 1) Then
                    G.CurrentCell = G.Rows(G.CurrentCell.RowIndex).Cells(GC.SubAccNo)
                End If
            ElseIf G.CurrentCell.ColumnIndex = G.Columns(GC.SubAccNo).Index Then
                dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & Val(G.Rows(G.CurrentCell.RowIndex).Cells(GC.MainAccNo).Value) & ")")
                If dt.Rows.Count > 0 AndAlso bm.ShowHelpGrid(dt.Rows(0)("TableName"), G.Rows(G.CurrentCell.RowIndex).Cells(GC.SubAccNo), SubAccName, e, "select cast(Id as varchar(100)) Id,Name from " & dt.Rows(0)("TableName") & " where AccNo=" & Val(G.Rows(G.CurrentCell.RowIndex).Cells(GC.MainAccNo).Value)) Then
                    'GridCalcRow(sender, New Forms.DataGridViewCellEventArgs(G.Columns(GC.SubAccNo).Index, G.CurrentCell.RowIndex))
                    G.CurrentCell = G.Rows(G.CurrentCell.RowIndex).Cells(GC.CostCenterId)
                End If
            ElseIf G.CurrentCell.ColumnIndex = G.Columns(GC.CostCenterId).Index Then
                If bm.ShowHelpGrid("CostCenters", G.Rows(G.CurrentCell.RowIndex).Cells(GC.CostCenterId), CostCenterName, e, "select cast(Id as varchar(100)) Id,Name from CostCenters where SubType=1") Then
                    G.CurrentCell = G.Rows(G.CurrentCell.RowIndex).Cells(GC.Notes)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub SetStyle(ByVal x As Button)
        x.Style = Application.Current.FindResource("GlossyCloseButton")
        x.VerticalContentAlignment = VerticalAlignment.Center
        x.Width = 100
        x.Height = 50
        x.Margin = New Thickness(10, 10, 0, 0)
    End Sub


    Private Sub LoadResource()
        btnSave.SetResourceReference(Button.ContentProperty, "Save")
        btnDelete.SetResourceReference(Button.ContentProperty, "Delete")
        btnNew.SetResourceReference(Button.ContentProperty, "New")

        btnFirst.SetResourceReference(Button.ContentProperty, "First")
        btnNext.SetResourceReference(Button.ContentProperty, "Next")
        btnPrevios.SetResourceReference(Button.ContentProperty, "Previous")
        btnLast.SetResourceReference(Button.ContentProperty, "Last")
    End Sub

    Private Sub G_CellBeginEdit(sender As Object, e As Forms.DataGridViewCellCancelEventArgs)
        If e.ColumnIndex = G.Columns(GC.MainAccNo).Index Then
            G.Rows(e.RowIndex).Cells(GC.SubAccNo).ReadOnly = False
        End If
    End Sub

    Private Sub G_SelectionChanged(sender As Object, e As EventArgs)
        GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.MainAccNo).Index, G.CurrentRow.Index))
        GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.SubAccNo).Index, G.CurrentRow.Index))
        GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.CostCenterId).Index, G.CurrentRow.Index))
        If Val(G.Rows(G.CurrentRow.Index).Cells(GC.Debit).Value) + Val(G.Rows(G.CurrentRow.Index).Cells(GC.Credit).Value) <> 0 AndAlso G.CurrentRow.Index > 0 Then
            If Not G.Rows(G.CurrentRow.Index).Cells(GC.Notes).Value = Nothing AndAlso Not G.Rows(G.CurrentRow.Index).Cells(GC.Notes).Value = "" Then
                G.Rows(G.CurrentRow.Index).Cells(GC.Notes).Value = G.Rows(G.CurrentRow.Index - 1).Cells(GC.Notes).Value
            End If
        End If
    End Sub



End Class
