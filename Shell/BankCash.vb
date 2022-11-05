Imports System.Data

Public Class BankCash
    Public TableName As String = "BankCash"
    Public TableDetailsName As String = "BankCashMoney"
    Public MainId As String = "BankId"
    Public SubId As String = "Flag"
    Public SubId2 As String = "InvoiceNo"


    Dim dt As New DataTable
    Dim bm As New BasicMethods

    WithEvents G As New MyGrid

    Public Flag As Integer = 0
    Public LinkFile As Integer = 0
    Public Save2Flag As Integer = 0

    Private Sub BasicForm_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

        If Md.ShowCostCenter Then
            lblCostCenterId.Visibility = Visibility.Visible
            CostCenterId.Visibility = Visibility.Visible
            CostCenterName.Visibility = Visibility.Visible
        Else
            lblCostCenterId.Visibility = Visibility.Hidden
            CostCenterId.Visibility = Visibility.Hidden
            CostCenterName.Visibility = Visibility.Hidden
        End If

        If Save2Flag = 0 Then
            btnSave2.Visibility = Visibility.Hidden
        End If

        bm.Fields = New String() {MainId, SubId, SubId2, "DayDate", "Value", "MainAccNo", "SubAccNo", "Notes", "Canceled", "Cash", "SheekNo", "SheekPerson", "SheekDate", "CostCenterId", "IsMoney"}
        bm.control = New Control() {BankId, txtFlag, txtID, DayDate, Value, MainAccNo, SubAccNo, Notes, Canceled, Cash, SheekNo, SheekPerson, SheekDate, CostCenterId, IsMoney}
        bm.KeyFields = New String() {MainId, SubId, SubId2}
        bm.Table_Name = TableName


        LoadWFH()

        IsMoney_Checked(Nothing, Nothing)
        RdoCash_Checked(Nothing, Nothing)

        If Not Md.Manager Then
            btnDelete.Visibility = Visibility.Hidden
            btnFirst.Visibility = Visibility.Hidden
            btnPrevios.Visibility = Visibility.Hidden
            btnNext.Visibility = Visibility.Hidden
            btnLast.Visibility = Visibility.Hidden

            txtID.IsEnabled = Md.Manager
            BankId.IsEnabled = False
            BankName.IsEnabled = False

        End If

        DayDate.IsEnabled = Md.Manager

        If LinkFile = 5 Then
            BankId.Text = Md.DefaultSave
        Else
            BankId.Text = Md.DefaultBank
        End If
        BankId_LostFocus(Nothing, Nothing)

    End Sub

    Structure GC
        Shared Price As String = "Price"
        Shared Qty As String = "Qty"
        Shared Value As String = "Value"
    End Structure


    Private Sub LoadWFH()
        WFH.Child = G
        WFH.TabIndex = 9
        G.TabIndex = 9
        G.TabStop = True

        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue
        G.Columns.Add(GC.Price, "الفئة")
        G.Columns.Add(GC.Qty, "الكمية")
        G.Columns.Add(GC.Value, "القيمة")
        G.Columns(GC.Price).ReadOnly = True
        G.Columns(GC.Value).ReadOnly = True

        G.AllowUserToAddRows = False
        G.AllowUserToDeleteRows = False
        AddHandler G.CellEndEdit, AddressOf GridCalcRow

    End Sub

    Sub NewId()
        txtID.Clear()
        txtID.IsEnabled = False
    End Sub

    Sub UndoNewId()
        txtID.IsEnabled = True
    End Sub


    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        bm.FirstLast(New String() {MainId, SubId, SubId2}, "Max", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Sub FillControls()
        bm.FillControls()
        MainAccNo_LostFocus(Nothing, Nothing)
        SubAccNo_LostFocus(Nothing, Nothing)
        CostCenterId_LostFocus(Nothing, Nothing)
        DayDate.Focus()


        Dim dt As DataTable = bm.ExecuteAdapter("select * from BankCashMoney where Flag=" & Flag & " and InvoiceNo=" & txtID.Text)
        G.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Qty).Value = dt.Rows(i)("Qty").ToString
            G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)("Price").ToString
            G.Rows(i).Cells(GC.Value).Value = dt.Rows(i)("Value").ToString
        Next
        GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.Qty).Index, 0))

        UndoNewId()

    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        bm.NextPrevious(New String() {MainId, SubId, SubId2}, New String() {BankId.Text, txtFlag.Text, txtID.Text}, "Next", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        AllowSave = False
        If Val(BankId.Text) = 0 Then
            bm.ShowMSG("برجاء تحديد " & lblBank.Content)
            BankId.Focus()
            Return
        End If
        If Val(MainAccNo.Text) = 0 Then
            bm.ShowMSG("برجاء تحديد الحساب العام")
            MainAccNo.Focus()
            Return
        End If
        If Val(SubAccNo.Text) = 0 And SubAccNo.IsEnabled Then
            bm.ShowMSG("برجاء تحديد الحساب الفرعى")
            SubAccNo.Focus()
            Return
        End If

        G.EndEdit()
        Dim ee As New Forms.DataGridViewCellEventArgs(G.Columns(GC.Qty).Index, -1)
        Try
            ee = New Forms.DataGridViewCellEventArgs(G.Columns(GC.Qty).Index, G.CurrentCell.RowIndex)
        Catch ex As Exception
        End Try
        GridCalcRow(G, ee)
        Value.Text = Val(Value.Text)


        Dim State As BasicMethods.SaveState = BasicMethods.SaveState.Update
        If txtID.Text.Trim = "" Then
            txtID.Text = bm.ExecuteScalar("select max(" & SubId2 & ")+1 from " & TableName & " where " & MainId & "='" & BankId.Text & "' and " & SubId & "=" & txtFlag.Text)
            If txtID.Text = "" Then txtID.Text = "1"
            LastEntry.Text = txtID.Text
            State = BasicMethods.SaveState.Insert
        End If

        bm.DefineValues()
        If Not bm.Save(New String() {MainId, SubId, SubId2}, New String() {BankId.Text, txtFlag.Text.Trim, txtID.Text}, State) Then
            If State = BasicMethods.SaveState.Insert Then
                txtID.Text = ""
                LastEntry.Text = ""
            End If
            Return
        End If

        If Not bm.SaveGrid(G, TableDetailsName, New String() {MainId, "Flag", "InvoiceNo"}, New String() {BankId.Text, txtFlag.Text, txtID.Text}, New String() {"Qty", "Price", "Value"}, New String() {GC.Qty, GC.Price, GC.Value}, New VariantType() {VariantType.Decimal, VariantType.Decimal, VariantType.Decimal}, New String() {GC.Price}) Then Return

        AllowSave = True
        If Not DontClear Then btnNew_Click(sender, e)

    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        bm.FirstLast(New String() {MainId, SubId, SubId2}, "Min", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearControls()
    End Sub

    Sub ClearControls()

        G.Rows.Clear()

        bm.ClearControls()
        MainAccName.Clear()
        SubAccName.Clear()
        CostCenterName.Clear()
        RdoCash.IsChecked = True
        DayDate.SelectedDate = Md.CurrentDate



        txtFlag.Text = Flag
        NewId()
        DayDate.Focus()

        ClearGrid()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & MainId & "='" & BankId.Text & "' and " & SubId & "='" & txtFlag.Text.Trim & "' and " & SubId2 & "=" & txtID.Text & "      delete from " & TableDetailsName & " where " & MainId & "='" & BankId.Text & "' and " & SubId & "='" & txtFlag.Text.Trim & "' and " & SubId2 & "=" & txtID.Text)
            btnNew_Click(sender, e)
        End If
    End Sub

    Private Sub btnPrevios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevios.Click
        bm.NextPrevious(New String() {MainId, SubId, SubId2}, New String() {BankId.Text, txtFlag.Text, txtID.Text}, "Back", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub
    Dim lv As Boolean = False

    Private Sub txtID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.LostFocus
        If lv Then
            Return
        End If
        lv = True

        bm.DefineValues()
        Dim dt As New DataTable
        bm.RetrieveAll(New String() {MainId, SubId, SubId2}, New String() {BankId.Text, txtFlag.Text.Trim, txtID.Text}, dt)
        If dt.Rows.Count = 0 Then
            ClearControls()
            lv = False
            Return
        End If
        FillControls()
        lv = False
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txtID.KeyDown, MainAccNo.KeyDown, SubAccNo.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub txtID_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles Value.KeyDown
        bm.MyKeyPress(sender, e, True)
    End Sub


    Dim AllowClose As Boolean = False
    'Private Sub MyBase_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    If Not btnSave.Enabled Then Exit Sub
    '    Select Case bm.RequestDelete
    '        Case BasicMethods.CloseState.Yes
    '            AllowClose = False
    '            btnSave_Click(Nothing, Nothing)
    '            If Not AllowClose Then e.Cancel = True
    '        Case BasicMethods.CloseState.No

    '        Case BasicMethods.CloseState.Cancel
    '            e.Cancel = True
    '    End Select
    'End Sub

    Private Sub BankId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BankId.LostFocus
        If Val(BankId.Text.Trim) = 0 Then
            BankId.Clear()
            BankName.Clear()
            btnNew_Click(sender, e)
            Return
        End If

        dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & LinkFile)
        bm.LostFocus(BankId, BankName, "select Name from " & dt.Rows(0)("TableName") & " where Id=" & BankId.Text.Trim())

        btnNew_Click(sender, e)

    End Sub

    Private Sub BankId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles BankId.KeyUp
        dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & LinkFile)
        If dt.Rows.Count > 0 AndAlso bm.ShowHelp(dt.Rows(0)("TableName"), BankId, BankName, e, "select cast(Id as varchar(100)) Id,Name from " & dt.Rows(0)("TableName")) Then
            BankId_LostFocus(Nothing, Nothing)
        End If
    End Sub

    Private Sub SubAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SubAccNo.LostFocus
        If Val(MainAccNo.Text) = 0 Or Not SubAccNo.IsEnabled Then
            SubAccNo.Clear()
            SubAccName.Clear()
            Return
        End If

        dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")")
        bm.LostFocus(SubAccNo, SubAccName, "select Name from " & dt.Rows(0)("TableName") & " where Id=" & SubAccNo.Text.Trim() & " and AccNo=" & Val(MainAccNo.Text))
    End Sub
    Private Sub SubAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SubAccNo.KeyUp
        dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")")
        If dt.Rows.Count > 0 AndAlso bm.ShowHelp(dt.Rows(0)("TableName"), SubAccNo, SubAccName, e, "select cast(Id as varchar(100)) Id,Name from " & dt.Rows(0)("TableName") & " where AccNo=" & Val(MainAccNo.Text)) Then
            SubAccNo_LostFocus(Nothing, Nothing)
        End If
    End Sub


    Private Sub MainAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MainAccNo.LostFocus

        Dim Done As Boolean = False
        If Not Md.Manager AndAlso Md.MyProject = Client.El7ariry And LinkFile = 5 Then
            If Flag = 2 Then
                bm.AccNoLostFocus(MainAccNo, MainAccName, , , , 2)
                Done = True
            End If
        End If
        If Not Done Then bm.AccNoLostFocus(MainAccNo, MainAccName, , )

        SubAccNo.IsEnabled = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")").Rows.Count > 0
        SubAccNo_LostFocus(Nothing, Nothing)

        If SubAccNo.IsEnabled Then
            SubAccNo.Focus()
        Else
            CostCenterId.Focus()
        End If
    End Sub

    Private Sub MainAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MainAccNo.KeyUp

        If Not Md.Manager AndAlso Md.MyProject = Client.El7ariry And LinkFile = 5 Then
            If Flag = 2 Then
                bm.AccNoShowHelp(MainAccNo, MainAccName, e, , , , 2)
                Return
            End If
        End If
        bm.AccNoShowHelp(MainAccNo, MainAccName, e, , , )

    End Sub

    Private Sub RdoCash_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles RdoCash.Checked, RdoCheck.Checked
        Try
            If Cash Is Nothing Then Return

            Cash.Text = 0
            If RdoCash.IsChecked Then
                Cash.Text = 1
            ElseIf RdoCheck.IsChecked Then
                Cash.Text = 2
            End If
        Catch ex As Exception
        End Try

        Try
            If RdoCheck.IsChecked Then
                SheekNo.Visibility = Visibility.Visible
                lblSheekNo.Visibility = Visibility.Visible

                SheekPerson.Visibility = Visibility.Visible
                lblSheekPerson.Visibility = Visibility.Visible

                SheekDate.Visibility = Visibility.Visible
                lblSheekDate.Visibility = Visibility.Visible
            Else
                SheekNo.Visibility = Visibility.Hidden
                lblSheekNo.Visibility = Visibility.Hidden

                SheekPerson.Visibility = Visibility.Hidden
                lblSheekPerson.Visibility = Visibility.Hidden

                SheekDate.Visibility = Visibility.Hidden
                lblSheekDate.Visibility = Visibility.Hidden
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Cash_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles Cash.TextChanged
        Try
            If Cash.Text = 1 Then
                RdoCash.IsChecked = True
            ElseIf Cash.Text = 2 Then
                RdoCheck.IsChecked = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Canceled_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Canceled.Checked
        Value.Text = ""
        Value.IsEnabled = False
    End Sub

    Private Sub Canceled_Unchecked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Canceled.Unchecked
        Value.IsEnabled = True
    End Sub

    Private Sub LoadResource()
        btnSave.SetResourceReference(Button.ContentProperty, "Save")
        btnDelete.SetResourceReference(Button.ContentProperty, "Delete")
        btnNew.SetResourceReference(Button.ContentProperty, "New")

        btnFirst.SetResourceReference(Button.ContentProperty, "First")
        btnNext.SetResourceReference(Button.ContentProperty, "Next")
        btnPrevios.SetResourceReference(Button.ContentProperty, "Previous")
        btnLast.SetResourceReference(Button.ContentProperty, "Last")

        lblID.SetResourceReference(Label.ContentProperty, "Id")

        lblBank.SetResourceReference(Label.ContentProperty, "Bank")
        If LinkFile = 5 Then lblBank.SetResourceReference(Label.ContentProperty, "Safe")

        lblDayDate.SetResourceReference(Label.ContentProperty, "DayDate")
        lblValue.SetResourceReference(Label.ContentProperty, "Value")
        lblNotes.SetResourceReference(Label.ContentProperty, "Notes")
        lblMainAccNo.SetResourceReference(Label.ContentProperty, "MainAccNo")
        lblSubAccNo.SetResourceReference(Label.ContentProperty, "SubAccNo")
        lblSheekDate.SetResourceReference(Label.ContentProperty, "SheekDate")
        lblSheekNo.SetResourceReference(Label.ContentProperty, "SheekNo")
        lblSheekPerson.SetResourceReference(Label.ContentProperty, "SheekPerson")
    End Sub

    Private Sub CostCenterId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CostCenterId.LostFocus
        bm.CostCenterIdLostFocus(CostCenterId, CostCenterName, )
    End Sub

    Private Sub CostCenterId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles CostCenterId.KeyUp
        bm.CostCenterIdShowHelp(CostCenterId, CostCenterName, e, )
    End Sub

    Private Sub GridCalcRow(sender As Object, e As Forms.DataGridViewCellEventArgs)
        If Not IsMoney.IsChecked Then Return
        Try
            G.Rows(e.RowIndex).Cells(GC.Qty).Value = Val(G.Rows(e.RowIndex).Cells(GC.Qty).Value)
            G.Rows(e.RowIndex).Cells(GC.Value).Value = Val(G.Rows(e.RowIndex).Cells(GC.Qty).Value) * Val(G.Rows(e.RowIndex).Cells(GC.Price).Value)
        Catch ex As Exception
        End Try
        Dim x As Decimal = 0
        For i As Integer = 0 To G.Rows.Count - 1
            x += Val(G.Rows(i).Cells(GC.Value).Value)
        Next
        Value.Text = Math.Round(x, 2, MidpointRounding.AwayFromZero)
    End Sub

    Private Sub IsMoney_Checked(sender As Object, e As RoutedEventArgs) Handles IsMoney.Checked, IsMoney.Unchecked
        If IsMoney.IsChecked Then
            WFH.Visibility = Visibility.Visible
            Value.Clear()
            Value.IsEnabled = False
        Else
            WFH.Visibility = Visibility.Hidden
            ClearGrid()
            Value.IsEnabled = True
        End If
    End Sub

    Private Sub ClearGrid()
        G.Rows.Clear()
        dt = bm.ExecuteAdapter("select Price from MoneyTypes order by Price desc")
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)(0)
        Next
    End Sub

    Private Sub btnSave2_Click(sender As Object, e As RoutedEventArgs) Handles btnSave2.Click
        btnSave_Click(sender, e)
        Select Case Save2Flag
            Case 1
                Dim frm As New Window With {.Title = "إيرادات خزنة"}
                bm.AddKeyDownToForm(frm)
                frm.Content = New BankCash With {.Flag = 1, .LinkFile = 5}
                frm.Show()
                frm.WindowState = WindowState.Maximized
        End Select
    End Sub


    Dim AllowSave As Boolean = False
    Dim DontClear As Boolean = False
    Private Sub btnPrint_Click(sender As Object, e As RoutedEventArgs) Handles btnPrint.Click, btnPrint2.Click, btnPrint3.Click
        DontClear = True
        If btnSave.IsEnabled AndAlso btnSave.Visibility = Visibility.Visible Then
            btnSave_Click(sender, e)
        Else
            AllowSave = True
        End If
        DontClear = False
        If Not AllowSave Then Return

        Dim rpt As New ReportViewer
        rpt.Header = CType(Parent, Page).Title
        rpt.paraname = New String() {"@BankId", "@Flag", "@InvoiceNo", "Header"}
        rpt.paravalue = New String() {Val(BankId.Text), Flag, txtID.Text, CType(Parent, Page).Title}
        If sender Is btnPrint Then
            rpt.Rpt = "BankCash_G1.rpt"
            rpt.Show()
        ElseIf sender Is btnPrint2 Then
            rpt.Rpt = "BankCash_G12.rpt"
            rpt.Print(".", Md.PonePrinter, 1)
        ElseIf sender Is btnPrint3 Then
            rpt.Rpt = "BankCash_G13.rpt"
            If Flag = 2 Then rpt.Rpt = "BankCash_G14.rpt"
            rpt.Show()
        End If
    End Sub

End Class
