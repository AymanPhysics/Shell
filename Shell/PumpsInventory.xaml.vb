Imports System.Data
Imports System.Windows
Imports System.Windows.Media
Imports System.Management

Public Class PumpsInventory

    Public TableName As String = "PumpsInventoryMaster"
    Public TableDetailsName As String = "PumpsInventoryDetails"

    Public MainId As String = "Daydate"
    Public SubId As String = "Shift"

    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Dim StaticsDt As New DataTable
    WithEvents G As New MyGrid
    WithEvents G2 As New MyGrid

    Public MyDayDate As DateTime = Nothing
    Public MyShift As Integer = 0

    Private Sub Sales_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

        bm.FillCombo("Shifts", Shift, "", , True)
        Shift.SelectedValue = Md.CurrentShiftId

        bm.Fields = New String() {MainId, SubId, "Notes", "Total", "SaveId"}
        bm.control = New Control() {DayDate, Shift, Notes, Total, SaveId}
        bm.KeyFields = New String() {MainId, SubId}

        bm.Table_Name = TableName

        LoadWFH()
        LoadWFH2()

        DayDate.SelectedDate = Nothing
        DayDate.SelectedDate = Md.CurrentDate
        Shift.SelectedValue = Md.CurrentShiftId

        btnNew_Click(Nothing, Nothing)

        If MyShift > 0 Then
            DayDate.SelectedDate = MyDayDate
            Shift.SelectedValue = MyShift
            txtID_Leave(Nothing, Nothing)
        End If

        If Not Md.MyProject = Client.AutoMarket Then
            btnPrint.Visibility = Visibility.Hidden
        End If
    End Sub


    Structure GC
        Shared Id As String = "Id"
        Shared Name As String = "Name"
        Shared TankName As String = "TankName"
        Shared ItemsPetroleumName As String = "ItemsPetroleumName"
        Shared Bal0 As String = "Bal0"
        Shared CurrentBal As String = "CurrentBal"
        Shared SalesBal As String = "SalesBal"
        Shared Caliber As String = "Caliber"
        Shared Qty As String = "Qty"
        Shared Price As String = "Price"
        Shared Value As String = "Value"
    End Structure


    Private Sub LoadWFH()
        WFH.Child = G
        WFH.TabIndex = 9
        G.TabIndex = 9
        G.TabStop = True

        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue

        G.Columns.Add(GC.Id, "كود العداد")
        G.Columns.Add(GC.Name, "اسم العداد")
        G.Columns.Add(GC.TankName, "التانك")
        G.Columns.Add(GC.ItemsPetroleumName, "الصنف")
        G.Columns.Add(GC.CurrentBal, "عداد نهاية الوردية")
        G.Columns.Add(GC.Bal0, "عداد بداية الوردية")
        G.Columns.Add(GC.SalesBal, "إجمالي الصادر")
        G.Columns.Add(GC.Caliber, "العيارات")
        G.Columns.Add(GC.Qty, "صافي المباع لتر")
        G.Columns.Add(GC.Price, "السعر")
        G.Columns.Add(GC.Value, "صافي المباع قيمة")

        G.Columns(GC.Name).FillWeight = 300
        G.Columns(GC.TankName).FillWeight = 300
        G.Columns(GC.ItemsPetroleumName).FillWeight = 300
        G.Columns(GC.Bal0).FillWeight = 150
        G.Columns(GC.CurrentBal).FillWeight = 150
        G.Columns(GC.SalesBal).FillWeight = 150
        G.Columns(GC.Caliber).FillWeight = 150

        G.Columns(GC.Id).ReadOnly = True
        G.Columns(GC.Name).ReadOnly = True
        G.Columns(GC.TankName).ReadOnly = True
        G.Columns(GC.ItemsPetroleumName).ReadOnly = True
        G.Columns(GC.Bal0).ReadOnly = True
        G.Columns(GC.SalesBal).ReadOnly = True
        G.Columns(GC.Qty).ReadOnly = True
        G.Columns(GC.Price).ReadOnly = True
        G.Columns(GC.Value).ReadOnly = True

        G.AllowUserToDeleteRows = False
        G.AllowUserToAddRows = False

        AddHandler G.CellEndEdit, AddressOf GridCalcRow
    End Sub


    Structure GC2
        Shared TankName As String = "TankName"
        Shared Qty As String = "Qty"
        Shared Value As String = "Value"
    End Structure


    Private Sub LoadWFH2()
        WFH2.Child = G2
        WFH2.TabIndex = 10
        G2.TabIndex = 10
        G2.TabStop = False

        G2.Columns.Clear()
        G2.ForeColor = System.Drawing.Color.DarkBlue

        G2.Columns.Add(GC2.TankName, "التانك")
        G2.Columns.Add(GC2.Qty, "صافي المباع لتر")
        G2.Columns.Add(GC2.Value, "صافي المباع قيمة")

        G2.Columns(GC2.TankName).FillWeight = 300

        G2.Columns(GC2.TankName).ReadOnly = True
        G2.Columns(GC2.Qty).ReadOnly = True
        G2.Columns(GC2.Value).ReadOnly = True

        G2.AllowUserToDeleteRows = False
        G2.AllowUserToAddRows = False

    End Sub

    Private Sub GridCalcRow(sender As Object, e As Forms.DataGridViewCellEventArgs)
        Try
            CalcRow(e.RowIndex)
        Catch ex As Exception
        End Try
        Dim x As Decimal = 0
        For i As Integer = 0 To G.Rows.Count - 1
            x += Val(G.Rows(i).Cells(GC.Value).Value)
        Next
        Total.Text = Math.Round(x, 2, MidpointRounding.AwayFromZero)

        G2.Rows.Clear()
        For i As Integer = 0 To G.Rows.Count - 1
            Dim exists As Boolean = False
            For i2 As Integer = 0 To G2.Rows.Count - 1
                If G.Rows(i).Cells(GC.TankName).Value = G2.Rows(i2).Cells(GC2.TankName).Value Then
                    G2.Rows(i2).Cells(GC2.Qty).Value += Val(G.Rows(i).Cells(GC.Qty).Value)
                    G2.Rows(i2).Cells(GC2.Value).Value += Val(G.Rows(i).Cells(GC.Value).Value)
                    exists = True
                End If
            Next
            If Not exists Then G2.Rows.Add({G.Rows(i).Cells(GC.TankName).Value, G.Rows(i).Cells(GC.Qty).Value, G.Rows(i).Cells(GC.Value).Value})
        Next
    End Sub

    Dim lop As Boolean = False
    Sub CalcRow(ByVal i As Integer)
        Try
            If Val(G.Rows(i).Cells(GC.CurrentBal).Value) = 0 Then
                G.Rows(i).Cells(GC.Qty).Value = ""
            End If

            G.Rows(i).Cells(GC.SalesBal).Value = Val(G.Rows(i).Cells(GC.CurrentBal).Value) - Val(G.Rows(i).Cells(GC.Bal0).Value)
            G.Rows(i).Cells(GC.Qty).Value = Val(G.Rows(i).Cells(GC.CurrentBal).Value) - Val(G.Rows(i).Cells(GC.Bal0).Value) - Val(G.Rows(i).Cells(GC.Caliber).Value)
        Catch ex As Exception
            G.Rows(i).Cells(GC.Qty).Value = ""
        End Try
        Try
            G.Rows(i).Cells(GC.Value).Value = Val(G.Rows(i).Cells(GC.Qty).Value) * Val(G.Rows(i).Cells(GC.Price).Value)
        Catch ex As Exception
            G.Rows(i).Cells(GC.Value).Value = ""
        End Try
    End Sub

    Sub FillControls()
        If lop Then Return
        lop = True
        bm.FillControls()
        SaveId_LostFocus(SaveId, Nothing)

        Dim dt As DataTable = bm.ExecuteAdapter("select * from " & TableDetailsName & " where " & MainId & "='" & bm.ToStrDate(DayDate.SelectedDate) & "' and " & SubId & "=" & Shift.SelectedValue)

        G.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Id).Value = dt.Rows(i)("Id").ToString
            G.Rows(i).Cells(GC.Name).Value = dt.Rows(i)("Name").ToString
            G.Rows(i).Cells(GC.TankName).Value = dt.Rows(i)("TankName").ToString
            G.Rows(i).Cells(GC.ItemsPetroleumName).Value = dt.Rows(i)("ItemsPetroleumName").ToString
            G.Rows(i).Cells(GC.Bal0).Value = dt.Rows(i)("Bal0").ToString
            G.Rows(i).Cells(GC.CurrentBal).Value = dt.Rows(i)("CurrentBal").ToString
            G.Rows(i).Cells(GC.SalesBal).Value = dt.Rows(i)("SalesBal").ToString
            G.Rows(i).Cells(GC.Caliber).Value = dt.Rows(i)("Caliber").ToString
            G.Rows(i).Cells(GC.Qty).Value = dt.Rows(i)("Qty").ToString
            G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)("Price").ToString
            G.Rows(i).Cells(GC.Value).Value = dt.Rows(i)("Value").ToString
        Next
        lop = False
        Notes.Focus()
        G.RefreshEdit()
        GridCalcRow(Nothing, Nothing)
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

        G.EndEdit()
        Try
            CalcRow(G.CurrentRow.Index)
        Catch ex As Exception
        End Try

        bm.DefineValues()
        If Not bm.Save(New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}) Then Return

        If Not bm.SaveGrid(G, TableDetailsName, New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}, New String() {"Id", "Name", "TankName", "ItemsPetroleumName", "Bal0", "CurrentBal", "Qty", "SalesBal", "Caliber", "Price", "Value"}, New String() {GC.Id, GC.Name, GC.TankName, GC.ItemsPetroleumName, GC.Bal0, GC.CurrentBal, GC.Qty, GC.SalesBal, GC.Caliber, GC.Price, GC.Value}, New VariantType() {VariantType.Integer, VariantType.String, VariantType.String, VariantType.String, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal}, New String() {GC.Id}) Then Return

        If sender Is btnPrint OrElse sender Is btnPrint Then
            PrintPone(sender)
            'txtID_Leave(Nothing, Nothing)
            'AllowClose = True
            Return
        End If

        If Not sender Is btnSave2 Then btnNew_Click(sender, e)
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
            G.Rows.Clear()
            bm.ClearControls(False)
            SaveId_LostFocus(SaveId, Nothing)
            DayDate.SelectedDate = d
            'Shift.SelectedIndex = 0

            G.Rows.Clear()
            dt = bm.ExecuteAdapter("GetPumpsData", New String() {"DayDate", "Shift"}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue})
            For i As Integer = 0 To dt.Rows.Count - 1
                G.Rows.Add()
                G.Rows(i).Cells(GC.Id).Value = dt.Rows(i)("Id").ToString
                G.Rows(i).Cells(GC.Name).Value = dt.Rows(i)("Name").ToString
                G.Rows(i).Cells(GC.TankName).Value = dt.Rows(i)("TankName").ToString
                G.Rows(i).Cells(GC.ItemsPetroleumName).Value = dt.Rows(i)("ItemsPetroleumName").ToString
                G.Rows(i).Cells(GC.Bal0).Value = dt.Rows(i)("Bal0").ToString
                G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)("Price").ToString
            Next
            GridCalcRow(Nothing, Nothing)
        Catch
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")

            bm.ExecuteNonQuery("delete from " & TableDetailsName & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")

            btnNew_Click(sender, e)
        End If
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

    Sub SetStyle(ByVal x As Button)
        x.Style = Application.Current.FindResource("GlossyCloseButton")
        x.VerticalContentAlignment = VerticalAlignment.Center
        x.Width = 85
        x.Height = 35
        x.Margin = New Thickness(5, 5, 0, 0)
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

    Private Sub btnSave2_Click(sender As Object, e As RoutedEventArgs) Handles btnSave2.Click
        btnSave_Click(sender, Nothing)
        Dim frm As New Window With {.Title = "أرصدة التانكات"}
        bm.AddKeyDownToForm(frm)
        frm.Content = New TanksInventory With {.MyDayDate = DayDate.SelectedDate, .MyShift = Shift.SelectedValue}
        frm.Show()
        frm.WindowState = WindowState.Maximized
    End Sub


    Private Sub SaveId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SaveId.KeyUp
        If bm.ShowHelp("Saves", SaveId, SaveName, e, "select cast(Id as varchar(100)) Id,Name from Saves") Then
            SaveId_LostFocus(SaveId, Nothing)
        End If
    End Sub

    Private Sub SaveId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SaveId.LostFocus
        bm.LostFocus(SaveId, SaveName, "select Name from Saves where Id=" & SaveId.Text.Trim(), True)
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SaveId.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub


    Private Sub btnPrint_Click(sender As Object, e As RoutedEventArgs) Handles btnPrint.Click
        btnSave_Click(sender, e)
    End Sub


    Private Sub PrintPone(ByVal sender As System.Object)
        Dim rpt As New ReportViewer
        rpt.paraname = New String() {"@Daydate", "@Shift", "ShiftName", "Header"}
        rpt.paravalue = New String() {DayDate.SelectedDate, Shift.SelectedValue.ToString, Shift.Text, CType(Parent, Page).Title}
        rpt.Rpt = "PumpsInventory.rpt"
        rpt.Show()

    End Sub
     
End Class
