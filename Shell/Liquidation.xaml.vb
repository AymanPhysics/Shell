Imports System.Data
Imports System.Windows
Imports System.Windows.Media
Imports System.Management

Public Class Liquidation

    Public TableName As String = "LiquidationMaster"
    Public TableDetailsName0 As String = "LiquidationDetails"
    Public TableDetailsName As String = "LiquidationMoney"

    Public MainId As String = "Daydate"
    Public SubId As String = "Shift"

    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Dim StaticsDt As New DataTable
    WithEvents G0 As New MyGrid
    WithEvents G As New MyGrid

    Public MyDayDate As DateTime = Nothing
    Public MyShift As Integer = 0

    Private Sub Sales_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

        bm.FillCombo("Shifts", Shift, "", , True)
        Shift.SelectedValue = Md.CurrentShiftId

        bm.Fields = New String() {MainId, SubId, "SaveId", "SaveId2", "SaveId3", "Bal", "Net", "Tips", "FellowshipFund", "SmallChange", "Custody", "Notes", "Total"}
        bm.control = New Control() {DayDate, Shift, SaveId, SaveId2, SaveId3, Bal, Net, Tips, FellowshipFund, SmallChange, Custody, Notes, Total}
        bm.KeyFields = New String() {MainId, SubId}

        bm.Table_Name = TableName

        LoadWFH0()
        LoadWFH()

        DayDate.SelectedDate = Nothing
        DayDate.SelectedDate = Md.CurrentDate
        Shift.SelectedValue = Md.CurrentShiftId

        btnNew_Click(Nothing, Nothing)

        If MyShift > 0 Then
            DayDate.SelectedDate = MyDayDate
            Shift.SelectedValue = MyShift
            txtID_Leave(Nothing, Nothing)
        End If

    End Sub


    Structure GC0
        Shared EmpId As String = "EmpId"
        Shared EmpName As String = "EmpName"
        Shared Perc1 As String = "Perc1"
        Shared Perc2 As String = "Perc2"
        Shared Value As String = "Value"
    End Structure


    Private Sub LoadWFH0()
        WFH0.Child = G0
        WFH0.TabIndex = 9
        G0.TabIndex = 9
        G0.TabStop = True

        G0.Columns.Clear()
        G0.ForeColor = System.Drawing.Color.DarkBlue

        G0.Columns.Add(GC0.EmpId, "كود الموظف")
        G0.Columns.Add(GC0.EmpName, "اسم الموظف")
        G0.Columns.Add(GC0.Perc1, "نسبة أولية")
        G0.Columns.Add(GC0.Perc2, "النسبة")
        G0.Columns.Add(GC0.Value, "القيمة")

        G0.Columns(GC0.EmpName).FillWeight = 300

        G0.Columns(GC0.EmpName).ReadOnly = True
        G0.Columns(GC0.Perc2).ReadOnly = True
        G0.Columns(GC0.Value).ReadOnly = True

        G0.AllowUserToDeleteRows = True
        G0.AllowUserToAddRows = True

        AddHandler G0.CellEndEdit, AddressOf GridCalcRow0
        AddHandler G0.KeyDown, AddressOf GridKeyDown0
    End Sub


    Private Sub ClearGrid()
        G.Rows.Clear()
        dt = bm.ExecuteAdapter("select Price from MoneyTypes order by Price desc")
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)(0)
        Next
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

    Private Sub GridCalcRow(sender As Object, e As Forms.DataGridViewCellEventArgs)
        Try
            G.Rows(e.RowIndex).Cells(GC.Qty).Value = Val(G.Rows(e.RowIndex).Cells(GC.Qty).Value)
            G.Rows(e.RowIndex).Cells(GC.Value).Value = Val(G.Rows(e.RowIndex).Cells(GC.Qty).Value) * Val(G.Rows(e.RowIndex).Cells(GC.Price).Value)
        Catch ex As Exception
        End Try
        Dim x As Decimal = 0
        For i As Integer = 0 To G.Rows.Count - 1
            x += Math.Round(Val(G.Rows(i).Cells(GC.Value).Value), 2, MidpointRounding.AwayFromZero)
        Next
        Net.Text = Math.Round(x, 2, MidpointRounding.AwayFromZero)
    End Sub


    Private Sub GridCalcRow0(sender As Object, e As Forms.DataGridViewCellEventArgs)
        Try
            If e Is Nothing Then e = New Forms.DataGridViewCellEventArgs(G0.CurrentCell.ColumnIndex, G0.CurrentRow.Index)
        Catch
            e = New Forms.DataGridViewCellEventArgs(0, 0)
        End Try
        Try
            If Val(G0.Rows(e.RowIndex).Cells(GC0.EmpId).Value) = 0 Then
                G0.Rows(e.RowIndex).Cells(GC0.EmpId).Value = ""
                G0.Rows(e.RowIndex).Cells(GC0.EmpName).Value = ""
                G0.Rows(e.RowIndex).Cells(GC0.Perc1).Value = ""
                G0.Rows(e.RowIndex).Cells(GC0.Perc2).Value = ""
                G0.Rows(e.RowIndex).Cells(GC0.Value).Value = ""
                'Return
            End If

            If e.ColumnIndex = G0.Columns(GC0.EmpId).Index Then
                G0.Rows(e.RowIndex).Cells(GC0.EmpName).Value = bm.ExecuteScalar("select ArName from Employees where Id=" & Val(G0.Rows(e.RowIndex).Cells(GC0.EmpId).Value))
            End If

            Dim x As Decimal = 0
            Dim count As Integer = 0
            For i As Integer = 0 To G0.Rows.Count - 1
                If Val(G0.Rows(i).Cells(GC0.EmpId).Value) = 0 Then Continue For
                x += Math.Round(Val(G0.Rows(i).Cells(GC0.Perc1).Value), 2, MidpointRounding.AwayFromZero)
                count += 1
            Next

            For i As Integer = 0 To G0.Rows.Count - 1
                If Val(G0.Rows(i).Cells(GC0.EmpId).Value) = 0 Then Continue For
                G0.Rows(i).Cells(GC0.Perc2).Value = (100 - x) / count
                G0.Rows(i).Cells(GC0.Value).Value = Math.Round((Val(G0.Rows(i).Cells(GC0.Perc1).Value) + Val(G0.Rows(i).Cells(GC0.Perc2).Value)) * (Val(Tips.Text) - Val(FellowshipFund.Text) - Val(SmallChange.Text)) / 100, 2, MidpointRounding.AwayFromZero)
            Next

        Catch ex As Exception
        End Try
    End Sub

    Dim lop As Boolean = False
    Sub FillControls()
        If lop Then Return
        lop = True
        bm.FillControls()
        SaveId_LostFocus(SaveId, Nothing)
        SaveId2_LostFocus(SaveId2, Nothing)
        SaveId3_LostFocus(SaveId3, Nothing)

        Dim dt As DataTable = bm.ExecuteAdapter("select * from " & TableDetailsName0 & " where " & MainId & "='" & bm.ToStrDate(DayDate.SelectedDate) & "' and " & SubId & "=" & Shift.SelectedValue)

        G0.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G0.Rows.Add()
            G0.Rows(i).Cells(GC0.EmpId).Value = dt.Rows(i)("EmpId").ToString
            G0.Rows(i).Cells(GC0.EmpName).Value = dt.Rows(i)("EmpName").ToString
            G0.Rows(i).Cells(GC0.Perc1).Value = dt.Rows(i)("Perc1").ToString
            G0.Rows(i).Cells(GC0.Perc2).Value = dt.Rows(i)("Perc2").ToString
            G0.Rows(i).Cells(GC0.Value).Value = dt.Rows(i)("Value").ToString
        Next


        dt = bm.ExecuteAdapter("select * from " & TableDetailsName & " where " & MainId & "='" & bm.ToStrDate(DayDate.SelectedDate) & "' and " & SubId & "=" & Shift.SelectedValue)

        G.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Qty).Value = dt.Rows(i)("Qty").ToString
            G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)("Price").ToString
            G.Rows(i).Cells(GC.Value).Value = dt.Rows(i)("Value").ToString
        Next
        GridCalcRow(G, New Forms.DataGridViewCellEventArgs(G.Columns(GC.Qty).Index, 0))

        lop = False
        Notes.Focus()
        G0.RefreshEdit()
        GridCalcRow0(Nothing, Nothing)
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        bm.FirstLast(New String() {MainId, SubId}, "Max", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Shift.SelectedIndex = Shift.Items.Count - 1 Then
            DayDate.SelectedDate = DayDate.SelectedDate.Value.AddDays(1)
            Shift.SelectedIndex = 1
            txtID_Leave(Nothing, Nothing)
            Return
        End If
        bm.NextPrevious(New String() {MainId, SubId}, New String() {"'" & bm.ToStrDate(DayDate.SelectedDate) & "'", Shift.SelectedValue}, "Next", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If DayDate.SelectedDate Is Nothing Then Return
        If Not CType(sender, Button).IsEnabled Then Return

        If Val(SaveId.Text) = 0 Then
            bm.ShowMSG("برجاء تحديد الخزنة")
            Return
        End If

        SaveId.Text = Val(SaveId.Text)
        SaveId2.Text = Val(SaveId2.Text)
        SaveId3.Text = Val(SaveId3.Text)

        G0.EndEdit()
        Try
            GridCalcRow0(Nothing, Nothing)
        Catch ex As Exception
        End Try


        G.EndEdit()
        Dim ee As New Forms.DataGridViewCellEventArgs(G.Columns(GC.Qty).Index, -1)
        Try
            ee = New Forms.DataGridViewCellEventArgs(G.Columns(GC.Qty).Index, G.CurrentCell.RowIndex)
        Catch ex As Exception
        End Try
        GridCalcRow(G, ee)


        bm.DefineValues()
        If Not bm.Save(New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}) Then Return

        If Not bm.SaveGrid(G0, TableDetailsName0, New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}, New String() {"EmpId", "EmpName", "Perc1", "Perc2", "Value"}, New String() {GC0.EmpId, GC0.EmpName, GC0.Perc1, GC0.Perc2, GC0.Value}, New VariantType() {VariantType.Integer, VariantType.String, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal}, New String() {GC0.EmpId}) Then Return

        If Not bm.SaveGrid(G, TableDetailsName, New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}, New String() {"Qty", "Price", "Value"}, New String() {GC.Qty, GC.Price, GC.Value}, New VariantType() {VariantType.Decimal, VariantType.Decimal, VariantType.Decimal}, New String() {GC.Price}) Then Return

        If Not sender Is btnCalc Then
            btnNew_Click(sender, e)
        End If
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        bm.FirstLast(New String() {MainId, SubId}, "Min", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearControls()
        Shift.SelectedIndex = 0
    End Sub

    Sub ClearControls()
        Try
            Dim d As DateTime = Nothing
            Try
                If d.Year = 1 Then d = bm.MyGetDate
                d = DayDate.SelectedDate
            Catch ex As Exception
            End Try
            Dim s As String = Shift.SelectedValue
            G0.Rows.Clear()
            G.Rows.Clear()
            bm.ClearControls(False)
            SaveId_LostFocus(SaveId, Nothing)
            SaveId2_LostFocus(SaveId2, Nothing)
            SaveId3_LostFocus(SaveId3, Nothing)
            DayDate.SelectedDate = d
            'Shift.SelectedIndex = 0

            G0.Rows.Clear()
            GridCalcRow0(Nothing, Nothing)
            ClearGrid()
        Catch
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            Delete()
            btnNew_Click(sender, e)
        End If
    End Sub

    Sub Delete()
        bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")
        bm.ExecuteNonQuery("delete from " & TableDetailsName0 & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")
        bm.ExecuteNonQuery("delete from " & TableDetailsName & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")
    End Sub

    Private Sub btnPrevios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevios.Click
        If Shift.SelectedIndex = 1 Then
            DayDate.SelectedDate = DayDate.SelectedDate.Value.AddDays(-1)
            Shift.SelectedIndex = Shift.Items.Count - 1
            txtID_Leave(Nothing, Nothing)
            Return
        End If
        bm.NextPrevious(New String() {MainId, SubId}, New String() {"'" & bm.ToStrDate(DayDate.SelectedDate) & "'", Shift.SelectedValue}, "Back", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub
    Dim lv As Boolean = False
    Private Sub txtID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayDate.LostFocus, Shift.LostFocus
        If lv OrElse Shift.IsDropDownOpen Then
            Return
        End If
        lv = True

        bm.DefineValues()
        Dim dt As New DataTable
        bm.RetrieveAll(New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}, dt)
        If dt.Rows.Count = 0 Then
            ClearControls()
            lv = False
            Return
        End If
        FillControls()
        lv = False
    End Sub


    Private Sub LoadResource()
        lblSaveId.SetResourceReference(Label.ContentProperty, "Safe")

        btnSave.SetResourceReference(Button.ContentProperty, "Save")
        btnDelete.SetResourceReference(Button.ContentProperty, "Delete")
        btnNew.SetResourceReference(Button.ContentProperty, "New")

        btnFirst.SetResourceReference(Button.ContentProperty, "First")
        btnNext.SetResourceReference(Button.ContentProperty, "Next")
        btnPrevios.SetResourceReference(Button.ContentProperty, "Previous")
        btnLast.SetResourceReference(Button.ContentProperty, "Last")
    End Sub

    Private Sub SaveId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SaveId.KeyUp
        If bm.ShowHelp("Saves", SaveId, SaveName, e, "select cast(Id as varchar(100)) Id,Name from Saves") Then
            SaveId_LostFocus(SaveId, Nothing)
        End If
    End Sub

    Private Sub SaveId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SaveId.LostFocus
        bm.LostFocus(SaveId, SaveName, "select Name from Saves where Id=" & SaveId.Text.Trim(), True)

        If lop Then Return
        bm.LostFocus(SaveId, Bal, "select dbo.Bal0(dbo.GetSafeAccNo(" & SaveId.Text.Trim() & ")," & SaveId.Text.Trim() & ",'" & bm.ToStrDate(DayDate.SelectedDate) & "',0,0)", True)
        Bal.Text = Math.Round(Val(Bal.Text), 2, MidpointRounding.AwayFromZero)
    End Sub

    Private Sub SaveId2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SaveId2.KeyUp
        If bm.ShowHelp("Saves", SaveId2, SaveName2, e, "select cast(Id as varchar(100)) Id,Name from Saves") Then
            SaveId2_LostFocus(SaveId2, Nothing)
        End If
    End Sub

    Private Sub SaveId2_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SaveId2.LostFocus
        bm.LostFocus(SaveId2, SaveName2, "select Name from Saves where Id=" & SaveId2.Text.Trim(), True)
    End Sub

    Private Sub SaveId3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SaveId3.KeyUp
        If bm.ShowHelp("Saves", SaveId3, SaveName3, e, "select cast(Id as varchar(100)) Id,Name from Saves") Then
            SaveId3_LostFocus(SaveId3, Nothing)
        End If
    End Sub

    Private Sub SaveId3_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SaveId3.LostFocus
        bm.LostFocus(SaveId3, SaveName3, "select Name from Saves where Id=" & SaveId3.Text.Trim(), True)
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SaveId.KeyDown, SaveId2.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub GridKeyDown0(sender As Object, e As Forms.KeyEventArgs)
        If G0.CurrentCell.ColumnIndex = G0.Columns(GC0.EmpId).Index Then
            If bm.ShowHelpGrid("Employees", G0.CurrentRow.Cells(GC0.EmpId), G0.CurrentRow.Cells(GC0.EmpName), e, "select cast(Id as varchar(100)) Id,ArName Name from Employees") Then
                GridCalcRow0(sender, New Forms.DataGridViewCellEventArgs(G0.Columns(GC0.EmpId).Index, G0.CurrentCell.RowIndex))
                G0.CurrentCell = G0.Rows(G0.CurrentCell.RowIndex).Cells(GC0.Perc1)
            End If
        End If
    End Sub


    Private Sub Net_TextChanged(sender As Object, e As TextChangedEventArgs) Handles Net.TextChanged, FellowshipFund.TextChanged, SmallChange.TextChanged, Custody.TextChanged
        Tips.Text = Math.Round(Val(Net.Text) - Val(Bal.Text), 2, MidpointRounding.AwayFromZero)
        Total.Text = Math.Round(Val(Tips.Text) - Val(FellowshipFund.Text) - Val(SmallChange.Text) - Val(Custody.Text), 2, MidpointRounding.AwayFromZero)
        GridCalcRow0(Nothing, Nothing)
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As RoutedEventArgs) Handles btnCalc.Click
        Delete()
        SaveId_LostFocus(Nothing, Nothing)
        Net_TextChanged(Nothing, Nothing)
        btnSave_Click(btnCalc, Nothing)
    End Sub
End Class
