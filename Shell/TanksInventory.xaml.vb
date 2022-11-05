Imports System.Data
Imports System.Windows
Imports System.Windows.Media
Imports System.Management

Public Class TanksInventory

    Public TableName As String = "TanksInventoryMaster"
    Public TableDetailsName As String = "TanksInventoryDetails"
    Public TableDetailsNameSub As String = "TanksInventoryDetailsSub"

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

        bm.Fields = New String() {MainId, SubId, "Notes", "ToId"}
        bm.control = New Control() {DayDate, Shift, Notes, ToId}
        bm.KeyFields = New String() {MainId, SubId}

        bm.Table_Name = TableName

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


    Structure GC
        Shared Id As String = "Id"
        Shared Name As String = "Name"
        Shared Bal0Size As String = "Bal0Size"
        Shared Bal0Qty As String = "Bal0Qty"
        Shared AfterSize As String = "AfterSize"
        Shared AfterQty As String = "AfterQty"
        Shared BeforeSize As String = "BeforeSize"
        Shared BeforeQty As String = "BeforeQty"
        Shared NetSize As String = "NetSize"
        Shared NetQty As String = "NetQty"
        Shared CarQty As String = "CarQty"
        Shared PurshaseDiffQty As String = "PurshaseDiffQty"
        Shared CurrentBalSize As String = "CurrentBalSize"
        Shared CurrentBalQty As String = "CurrentBalQty"
        Shared SalesQty As String = "SalesQty"
        Shared PumpsSalesQty As String = "PumpsSalesQty"
        Shared SalesDiffQty As String = "SalesDiffQty"
        Shared Price As String = "Price"
        Shared PurchasePrice As String = "PurchasePrice"
        Shared Ratio As String = "Ratio"
        Shared Value As String = "Value"
        Shared Taxes As String = "Taxes"
    End Structure

    Private Sub LoadWFH()
        WFH.Child = G
        WFH.TabIndex = 9
        G.TabIndex = 9
        G.TabStop = True
        G.AllowLeaveGrid = True
        G.StandardTab = True

        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue

        G.Columns.Add(GC.Id, "كود التانك")
        G.Columns.Add(GC.Name, "اسم التانك")
        G.Columns.Add(GC.CurrentBalSize, "مقاس نهاية الوردية")
        G.Columns.Add(GC.CurrentBalQty, "كمية نهاية الوردية")
        G.Columns.Add(GC.Bal0Size, "مقاس بداية الوردية")
        G.Columns.Add(GC.Bal0Qty, "كمية بداية الوردية")
        G.Columns.Add(GC.BeforeSize, "مقاس قبل التفريغ")
        G.Columns.Add(GC.BeforeQty, "كمية  قبل التفريغ")
        G.Columns.Add(GC.AfterSize, "مقاس بعد التفريغ")
        G.Columns.Add(GC.AfterQty, "كمية  بعد التفريغ")
        G.Columns.Add(GC.NetSize, "المقاس المفرغة لتر")
        G.Columns.Add(GC.NetQty, "الكمية المفرغة لتر")
        G.Columns.Add(GC.CarQty, "السيارة")
        G.Columns.Add(GC.PurshaseDiffQty, "عجز / زيادة سيارة")
        G.Columns.Add(GC.SalesQty, "المباع")
        G.Columns.Add(GC.PumpsSalesQty, "المباع من العدادات")
        G.Columns.Add(GC.SalesDiffQty, "فرق المباع")

        G.Columns.Add(GC.Price, "سعر البيع")
        G.Columns.Add(GC.PurchasePrice, "سعر الشراء")
        G.Columns.Add(GC.Ratio, "نسبة البخر")
        G.Columns.Add(GC.Value, "القيمة")
        G.Columns.Add(GC.Taxes, "الضريبة")


        G.Columns(GC.Name).FillWeight = 300
        G.Columns(GC.Bal0Qty).FillWeight = 150
        G.Columns(GC.BeforeQty).FillWeight = 150
        G.Columns(GC.AfterQty).FillWeight = 150
        G.Columns(GC.NetQty).FillWeight = 150
        G.Columns(GC.CarQty).FillWeight = 150
        G.Columns(GC.PurshaseDiffQty).FillWeight = 150
        G.Columns(GC.CurrentBalQty).FillWeight = 150
        G.Columns(GC.SalesQty).FillWeight = 150
        G.Columns(GC.PumpsSalesQty).FillWeight = 150
        G.Columns(GC.SalesDiffQty).FillWeight = 150

        G.Columns(GC.Id).ReadOnly = True
        G.Columns(GC.Name).ReadOnly = True
        G.Columns(GC.Bal0Size).ReadOnly = True
        G.Columns(GC.Bal0Qty).ReadOnly = True
        G.Columns(GC.BeforeQty).ReadOnly = True
        G.Columns(GC.AfterQty).ReadOnly = True
        G.Columns(GC.NetSize).ReadOnly = True
        G.Columns(GC.NetQty).ReadOnly = True
        G.Columns(GC.CarQty).ReadOnly = True
        G.Columns(GC.PurshaseDiffQty).ReadOnly = True
        G.Columns(GC.CurrentBalQty).ReadOnly = True
        G.Columns(GC.SalesQty).ReadOnly = True
        G.Columns(GC.SalesDiffQty).ReadOnly = True
        G.Columns(GC.PumpsSalesQty).ReadOnly = True

        G.Columns(GC.AfterSize).Visible = False
        G.Columns(GC.AfterQty).Visible = False
        G.Columns(GC.BeforeSize).Visible = False
        G.Columns(GC.BeforeQty).Visible = False

        G.Columns(GC.NetSize).Visible = False

        G.Columns(GC.Price).Visible = False
        G.Columns(GC.PurchasePrice).Visible = False
        G.Columns(GC.Ratio).Visible = False
        G.Columns(GC.Value).Visible = False
        G.Columns(GC.Taxes).Visible = False

        G.AllowUserToDeleteRows = False
        G.AllowUserToAddRows = False


        AddHandler G.KeyDown, AddressOf G_KeyDown
        AddHandler G.SelectionChanged, AddressOf G_SelectionChanged
        AddHandler G.CellEndEdit, AddressOf GridCalcRow
    End Sub

    Private Sub GridCalcRow(sender As Object, e As Forms.DataGridViewCellEventArgs)
        CalcRow(e.RowIndex)
        Dim x As Decimal = 0
        For i As Integer = 0 To G.Rows.Count - 1
            '    x += Val(G.Rows(i).Cells(GC.Value).Value)
        Next
        'Total.Text = Math.Round(x, 2, MidpointRounding.AwayFromZero)
    End Sub

    Dim lop As Boolean = False
    Sub CalcRow(ByVal i As Integer)
        G.EndEdit()
        Dim x As String = G.Columns(G.CurrentCell.ColumnIndex).Name
        Select Case x
            Case GC.Bal0Size
                G.Rows(i).Cells(GC.Bal0Qty).Value = bm.ExecuteScalar("GetTankQty", New String() {"TankId", "Dept"}, New String() {Val(G.Rows(i).Cells(GC.Id).Value), Val(G.Rows(i).Cells(GC.Bal0Size).Value)})
            Case GC.BeforeSize
                G.Rows(i).Cells(GC.BeforeQty).Value = bm.ExecuteScalar("GetTankQty", New String() {"TankId", "Dept"}, New String() {Val(G.Rows(i).Cells(GC.Id).Value), Val(G.Rows(i).Cells(GC.BeforeSize).Value)})
            Case GC.AfterSize
                G.Rows(i).Cells(GC.AfterQty).Value = bm.ExecuteScalar("GetTankQty", New String() {"TankId", "Dept"}, New String() {Val(G.Rows(i).Cells(GC.Id).Value), Val(G.Rows(i).Cells(GC.AfterSize).Value)})
            Case GC.NetSize
                G.Rows(i).Cells(GC.NetQty).Value = bm.ExecuteScalar("GetTankQty", New String() {"TankId", "Dept"}, New String() {Val(G.Rows(i).Cells(GC.Id).Value), Val(G.Rows(i).Cells(GC.NetSize).Value)})
            Case GC.CurrentBalSize
                G.Rows(i).Cells(GC.CurrentBalQty).Value = bm.ExecuteScalar("GetTankQty", New String() {"TankId", "Dept"}, New String() {Val(G.Rows(i).Cells(GC.Id).Value), Val(G.Rows(i).Cells(GC.CurrentBalSize).Value)})
                G_SelectionChanged(Nothing, Nothing)
        End Select


        G.Rows(i).Cells(GC.Value).Value = Math.Round(Val(G.Rows(i).Cells(GC.CarQty).Value) * (1 - Val(G.Rows(i).Cells(GC.Ratio).Value)) * Val(G.Rows(i).Cells(GC.PurchasePrice).Value), 2, MidpointRounding.AwayFromZero)
        G.Rows(i).Cells(GC.Taxes).Value = Math.Round(Val(G.Rows(i).Cells(GC.CarQty).Value) * (Val(G.Rows(i).Cells(GC.Price).Value) - Val(G.Rows(i).Cells(GC.PurchasePrice).Value)) * 0.02, 2, MidpointRounding.AwayFromZero)

        G.Rows(i).Cells(GC.NetSize).Value = Val(G.Rows(i).Cells(GC.AfterSize).Value) - Val(G.Rows(i).Cells(GC.BeforeSize).Value)
        G.Rows(i).Cells(GC.NetQty).Value = Val(G.Rows(i).Cells(GC.AfterQty).Value) - Val(G.Rows(i).Cells(GC.BeforeQty).Value)
        G.Rows(i).Cells(GC.PurshaseDiffQty).Value = Val(G.Rows(i).Cells(GC.NetQty).Value) - Val(G.Rows(i).Cells(GC.CarQty).Value)
        G.Rows(i).Cells(GC.SalesQty).Value = Val(G.Rows(i).Cells(GC.Bal0Qty).Value) + Val(G.Rows(i).Cells(GC.CarQty).Value) - Val(G.Rows(i).Cells(GC.CurrentBalQty).Value)
        G.Rows(i).Cells(GC.SalesDiffQty).Value = Val(G.Rows(i).Cells(GC.PumpsSalesQty).Value) - Val(G.Rows(i).Cells(GC.SalesQty).Value)

        'Try
        '    If Val(G.Rows(i).Cells(GC.CurrentBal).Value) = 0 Then G.Rows(i).Cells(GC.Bal0).Value = ""
        '    G.Rows(i).Cells(GC.Qty).Value = Val(G.Rows(i).Cells(GC.CurrentBal).Value) - Val(G.Rows(i).Cells(GC.Bal0).Value)
        'Catch ex As Exception
        '    G.Rows(i).Cells(GC.Qty).Value = ""
        'End Try
        'Try
        '    G.Rows(i).Cells(GC.Value).Value = Val(G.Rows(i).Cells(GC.Qty).Value) * Val(G.Rows(i).Cells(GC.Price).Value)
        'Catch ex As Exception
        '    G.Rows(i).Cells(GC.Qty).Value = ""
        'End Try
    End Sub


    Structure GC2
        Shared Id As String = "Id"
        Shared AfterSize As String = "AfterSize"
        Shared AfterQty As String = "AfterQty"
        Shared BeforeSize As String = "BeforeSize"
        Shared BeforeQty As String = "BeforeQty"
        Shared NetQty As String = "NetQty"
        Shared CarQty As String = "CarQty"
        Shared PurshaseDiffQty As String = "PurshaseDiffQty"
        Shared SalesQty As String = "SalesQty"
    End Structure

    Private Sub LoadWFH2()
        WFH2.Child = G2
        WFH2.TabIndex = 10
        G2.TabIndex = 10
        G2.TabStop = True

        G2.Columns.Clear()
        G2.ForeColor = System.Drawing.Color.DarkBlue

        G2.Columns.Add(GC2.Id, "كود التانك")
        G2.Columns.Add(GC2.BeforeSize, "مقاس قبل التفريغ")
        G2.Columns.Add(GC2.BeforeQty, "كمية  قبل التفريغ")
        G2.Columns.Add(GC2.AfterSize, "مقاس بعد التفريغ")
        G2.Columns.Add(GC2.AfterQty, "كمية  بعد التفريغ")
        G2.Columns.Add(GC2.NetQty, "الكمية المفرغة لتر")
        G2.Columns.Add(GC2.CarQty, "السيارة")
        G2.Columns.Add(GC2.PurshaseDiffQty, "عجز / زيادة سيارة")
        G2.Columns.Add(GC2.SalesQty, "المباع")
        
        G2.Columns(GC2.BeforeQty).FillWeight = 150
        G2.Columns(GC2.AfterQty).FillWeight = 150
        G2.Columns(GC2.NetQty).FillWeight = 150
        G2.Columns(GC2.CarQty).FillWeight = 150
        G2.Columns(GC2.PurshaseDiffQty).FillWeight = 150
        G2.Columns(GC2.SalesQty).FillWeight = 150
        
        G2.Columns(GC2.Id).ReadOnly = True
        G2.Columns(GC2.BeforeQty).ReadOnly = True
        G2.Columns(GC2.AfterQty).ReadOnly = True
        G2.Columns(GC2.NetQty).ReadOnly = True
        G2.Columns(GC2.PurshaseDiffQty).ReadOnly = True
        G2.Columns(GC2.SalesQty).ReadOnly = True
        
        G2.Columns(GC2.Id).Visible = False


        AddHandler G2.RowsAdded, AddressOf GridRowsAdded2
        AddHandler G2.GotFocus, AddressOf GridGotFocus2
        AddHandler G2.CellEndEdit, AddressOf GridCalcRow2

        Dim dt As DataTable = bm.ExecuteAdapter("select * from " & TableDetailsNameSub & " where " & MainId & "='" & bm.ToStrDate(DayDate.SelectedDate) & "' and " & SubId & "=" & Shift.SelectedValue & " and Id=" & G.CurrentRow.Cells(GC.Id).Value)
        G2.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G2.Rows.Add()
            G2.Rows(i).Cells(GC2.Id).Value = dt.Rows(i)("Id").ToString
            G2.Rows(i).Cells(GC2.BeforeSize).Value = dt.Rows(i)("BeforeSize").ToString
            G2.Rows(i).Cells(GC2.BeforeQty).Value = dt.Rows(i)("BeforeQty").ToString
            G2.Rows(i).Cells(GC2.AfterSize).Value = dt.Rows(i)("AfterSize").ToString
            G2.Rows(i).Cells(GC2.AfterQty).Value = dt.Rows(i)("AfterQty").ToString
            G2.Rows(i).Cells(GC2.NetQty).Value = dt.Rows(i)("NetQty").ToString
            G2.Rows(i).Cells(GC2.CarQty).Value = dt.Rows(i)("CarQty").ToString
            G2.Rows(i).Cells(GC2.PurshaseDiffQty).Value = dt.Rows(i)("PurshaseDiffQty").ToString
            G2.Rows(i).Cells(GC2.SalesQty).Value = dt.Rows(i)("SalesQty").ToString
        Next
        If Not DontCalc Then
            G2.RefreshEdit()
            If Not SaveSub Then G2.Focus()
        End If
    End Sub

    Private Sub GridRowsAdded2(sender As Object, e As Forms.DataGridViewRowsAddedEventArgs)
        If G.CurrentRow Is Nothing Then Return
        G2.Rows(e.RowIndex).Cells(GC2.Id).Value = G.CurrentRow.Cells(GC.Id).Value
    End Sub

    Private Sub GridCalcRow2(sender As Object, e As Forms.DataGridViewCellEventArgs)
        If lop Then Return
        If G.CurrentCell Is Nothing OrElse G2.CurrentCell Is Nothing Then Return
        G2.Rows(e.RowIndex).Cells(GC2.Id).Value = G.CurrentRow.Cells(GC.Id).Value
        Dim i As Integer = e.RowIndex
        Dim x As String = G2.Columns(G2.CurrentCell.ColumnIndex).Name
        Select Case x
            Case GC2.BeforeSize
                If Not G2.Rows(i).Cells(GC2.BeforeSize).Value Is Nothing Then
                    G2.Rows(i).Cells(GC2.BeforeQty).Value = bm.ExecuteScalar("GetTankQty", New String() {"TankId", "Dept"}, New String() {Val(G2.Rows(i).Cells(GC2.Id).Value), Val(G2.Rows(i).Cells(GC2.BeforeSize).Value)})
                End If
            Case GC2.AfterSize
                If Not G2.Rows(i).Cells(GC2.AfterSize).Value Is Nothing Then
                    G2.Rows(i).Cells(GC2.AfterQty).Value = bm.ExecuteScalar("GetTankQty", New String() {"TankId", "Dept"}, New String() {Val(G2.Rows(i).Cells(GC2.Id).Value), Val(G2.Rows(i).Cells(GC2.AfterSize).Value)})
                End If
        End Select


        G2.Rows(i).Cells(GC2.NetQty).Value = Val(G2.Rows(i).Cells(GC2.AfterQty).Value) - Val(G2.Rows(i).Cells(GC2.BeforeQty).Value)


        G2.Rows(i).Cells(GC2.PurshaseDiffQty).Value = Val(G2.Rows(i).Cells(GC2.NetQty).Value) - Val(G2.Rows(i).Cells(GC2.CarQty).Value)
        If i = 0 Then
            G2.Rows(i).Cells(GC2.SalesQty).Value = Val(G.CurrentRow.Cells(GC.Bal0Qty).Value) - Val(G2.Rows(i).Cells(GC2.BeforeQty).Value)
        Else
            G2.Rows(i).Cells(GC2.SalesQty).Value = Val(G2.Rows(i - 1).Cells(GC2.AfterQty).Value) - Val(G2.Rows(i).Cells(GC2.BeforeQty).Value)
        End If

        Dim NetQty As Decimal = 0
        Dim CarQty As Decimal = 0
        Dim PurshaseDiffQty As Decimal = 0
        For ii As Integer = 0 To G2.Rows.Count - 1
            NetQty += Val(G2.Rows(ii).Cells(GC2.NetQty).Value)
            CarQty += Val(G2.Rows(ii).Cells(GC2.CarQty).Value)
            PurshaseDiffQty += Val(G2.Rows(ii).Cells(GC2.PurshaseDiffQty).Value)
        Next
        G.CurrentRow.Cells(GC.NetQty).Value = Math.Round(NetQty, 2, MidpointRounding.AwayFromZero)
        G.CurrentRow.Cells(GC.CarQty).Value = Math.Round(CarQty, 2, MidpointRounding.AwayFromZero)
        G.CurrentRow.Cells(GC.PurshaseDiffQty).Value = Math.Round(PurshaseDiffQty, 2, MidpointRounding.AwayFromZero)
    End Sub


    Sub FillControls()
        If lop Then Return
        lop = True
        bm.FillControls()
        ToId_LostFocus(Nothing, Nothing)

        Dim dt As DataTable = bm.ExecuteAdapter("select * from " & TableDetailsName & " where " & MainId & "='" & bm.ToStrDate(DayDate.SelectedDate) & "' and " & SubId & "=" & Shift.SelectedValue)

        G.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Id).Value = dt.Rows(i)("Id").ToString
            G.Rows(i).Cells(GC.Name).Value = dt.Rows(i)("Name").ToString
            G.Rows(i).Cells(GC.Bal0Size).Value = dt.Rows(i)("Bal0Size").ToString
            G.Rows(i).Cells(GC.Bal0Qty).Value = dt.Rows(i)("Bal0Qty").ToString
            G.Rows(i).Cells(GC.BeforeSize).Value = dt.Rows(i)("BeforeSize").ToString
            G.Rows(i).Cells(GC.BeforeQty).Value = dt.Rows(i)("BeforeQty").ToString
            G.Rows(i).Cells(GC.AfterSize).Value = dt.Rows(i)("AfterSize").ToString
            G.Rows(i).Cells(GC.AfterQty).Value = dt.Rows(i)("AfterQty").ToString
            G.Rows(i).Cells(GC.NetSize).Value = dt.Rows(i)("NetSize").ToString
            G.Rows(i).Cells(GC.NetQty).Value = dt.Rows(i)("NetQty").ToString
            G.Rows(i).Cells(GC.CarQty).Value = dt.Rows(i)("CarQty").ToString
            G.Rows(i).Cells(GC.PurshaseDiffQty).Value = dt.Rows(i)("PurshaseDiffQty").ToString
            G.Rows(i).Cells(GC.CurrentBalSize).Value = dt.Rows(i)("CurrentBalSize").ToString
            G.Rows(i).Cells(GC.CurrentBalQty).Value = dt.Rows(i)("CurrentBalQty").ToString
            G.Rows(i).Cells(GC.SalesQty).Value = dt.Rows(i)("SalesQty").ToString
            G.Rows(i).Cells(GC.PumpsSalesQty).Value = dt.Rows(i)("PumpsSalesQty").ToString
            G.Rows(i).Cells(GC.SalesDiffQty).Value = dt.Rows(i)("SalesDiffQty").ToString
            
            G.Rows(i).Cells(GC.PurshaseDiffQty).Value = dt.Rows(i)("PurshaseDiffQty").ToString
            G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)("Price").ToString
            G.Rows(i).Cells(GC.PurchasePrice).Value = dt.Rows(i)("PurchasePrice").ToString
            G.Rows(i).Cells(GC.Ratio).Value = dt.Rows(i)("Ratio").ToString
            G.Rows(i).Cells(GC.Value).Value = dt.Rows(i)("Value").ToString
            G.Rows(i).Cells(GC.Taxes).Value = dt.Rows(i)("Taxes").ToString


        Next
        Notes.Focus()
        If G.Rows.Count > 0 Then G.CurrentCell = G.Rows(0).Cells(0)
        G.RefreshEdit()
        G_SelectionChanged(G, New EventArgs())
        If G2.Rows.Count > 0 Then GridCalcRow2(G2, New Forms.DataGridViewCellEventArgs(0, 0))
        lop = False
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

        G.EndEdit()
        Try
            'CalcRow(G.CurrentRow.Index)
        Catch ex As Exception
        End Try

        bm.DefineValues()
        If Not bm.Save(New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}) Then Return

        If Not bm.SaveGrid(G, TableDetailsName, New String() {MainId, SubId}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue}, New String() {"Id", "Name", "Bal0Size", "Bal0Qty", "BeforeSize", "BeforeQty", "AfterSize", "AfterQty", "NetSize", "NetQty", "CarQty", "PurshaseDiffQty", "CurrentBalSize", "CurrentBalQty", "SalesQty", "PumpsSalesQty", "SalesDiffQty", "Price", "PurchasePrice", "Ratio", "Value", "Taxes"}, New String() {GC.Id, GC.Name, GC.Bal0Size, GC.Bal0Qty, GC.BeforeSize, GC.BeforeQty, GC.AfterSize, GC.AfterQty, GC.NetSize, GC.NetQty, GC.CarQty, GC.PurshaseDiffQty, GC.CurrentBalSize, GC.CurrentBalQty, GC.SalesQty, GC.PumpsSalesQty, GC.SalesDiffQty, GC.Price, GC.PurchasePrice, GC.Ratio, GC.Value, GC.Taxes}, New VariantType() {VariantType.Integer, VariantType.String, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal}, New String() {GC.Id}) Then Return

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
            DayDate.SelectedDate = d

            ToId.Text = bm.ExecuteScalar("select top 1 OilSupplierAccNo from statics")
            ToId_LostFocus(Nothing, Nothing)

            DontCalc = True
            dt = bm.ExecuteAdapter("GetTanksData", New String() {"DayDate", "Shift"}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue})
            For i As Integer = 0 To dt.Rows.Count - 1
                G.Rows.Add()
                G.Rows(i).Cells(GC.Id).Value = dt.Rows(i)("Id").ToString
                G.Rows(i).Cells(GC.Name).Value = dt.Rows(i)("Name").ToString
                G.Rows(i).Cells(GC.Bal0Size).Value = dt.Rows(i)("Bal0Size").ToString
                G.Rows(i).Cells(GC.Bal0Qty).Value = dt.Rows(i)("Bal0Qty").ToString
                G.Rows(i).Cells(GC.PumpsSalesQty).Value = dt.Rows(i)("PumpsSalesQty").ToString
                G.Rows(i).Cells(GC.Price).Value = dt.Rows(i)("Price").ToString
                G.Rows(i).Cells(GC.PurchasePrice).Value = dt.Rows(i)("PurchasePrice").ToString
                G.Rows(i).Cells(GC.Ratio).Value = dt.Rows(i)("Ratio").ToString
            Next

            DontCalc = False

        Catch
            DontCalc = False
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")

            bm.ExecuteNonQuery("delete from " & TableDetailsName & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")

            bm.ExecuteNonQuery("delete from " & TableDetailsNameSub & " where " & SubId & "='" & Shift.SelectedValue & "' and " & MainId & " ='" & bm.ToStrDate(DayDate.SelectedDate) & "'")

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
        Dim frm As New Window With {.Title = "المبيعات"}
        bm.AddKeyDownToForm(frm)
        frm.Content = New Sales With {.Flag = Sales.FlagState.المبيعات, .Save2Flag = 1}
        frm.Show()
        frm.WindowState = WindowState.Maximized
    End Sub


    Private Sub ToId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ToId.KeyUp
        Dim Title, tbl As String
        tbl = "Suppliers"
        Title = "الموردين"
        Dim str As String = Val(bm.ExecuteScalar("select top 1 Id from chart where LinkFile=2"))
        bm.ShowHelp(Title, ToId, ToName, e, "select cast(Id as varchar(100)) Id,Name from " & tbl, "Suppliers", {"AccNo"}, {str})
        
    End Sub


    Private Sub ToId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ToId.LostFocus
        Dim tbl As String
        tbl = "Suppliers"
        bm.LostFocus(ToId, ToName, "select Name from " & tbl & " where Id=" & ToId.Text.Trim())
    End Sub

    Private Sub GridGotFocus2(sender As Object, e As EventArgs)
        'CalcRow(G.CurrentRow.Index)
    End Sub


    Private Sub btnSaveSub_Click(sender As Object, e As RoutedEventArgs) Handles btnSaveSub.Click

        G2.EndEdit()
        If Not bm.SaveGrid(G2, TableDetailsNameSub, New String() {MainId, SubId, "Id"}, New String() {bm.ToStrDate(DayDate.SelectedDate), Shift.SelectedValue, G.CurrentRow.Cells(GC2.Id).Value}, New String() {"BeforeSize", "BeforeQty", "AfterSize", "AfterQty", "NetQty", "CarQty", "PurshaseDiffQty", "SalesQty"}, New String() {GC2.BeforeSize, GC2.BeforeQty, GC2.AfterSize, GC2.AfterQty, GC2.NetQty, GC2.CarQty, GC2.PurshaseDiffQty, GC2.SalesQty}, New VariantType() {VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal}, New String() {GC2.Id}) Then Return
        G2.Rows.Clear()
        'bm.ShowMSG("تم الحفظ بنجاح")
        DontCalc = True
        Try
            G.Focus()

            G.CurrentCell = G.Rows(G.CurrentRow.Index + 1).Cells(GC.CurrentBalSize)
            G.EditMode = Forms.DataGridViewEditMode.EditOnEnter
            G.BeginEdit(True)
            DontCalc = False

            SaveSub = True
            G_SelectionChanged(Nothing, Nothing)
            SaveSub = False

        Catch ex As Exception
        End Try
        DontCalc = False
        SaveSub = False
    End Sub

    Dim DontCalc As Boolean = False
    Dim SaveSub As Boolean = False
    Private Sub G_SelectionChanged(sender As Object, e As EventArgs)
        If DontCalc Then Return
        Try
            lblName.Content = G.CurrentRow.Cells(GC.Name).Value
        Catch ex As Exception
            lblName.Content = ""
        End Try
        LoadWFH2()
        GridCalcRow2(G2, New Forms.DataGridViewCellEventArgs(0, 0))
    End Sub

    Private Sub G_KeyDown(sender As Object, e As Forms.KeyEventArgs)
        'Throw New NotImplementedException
    End Sub

End Class
