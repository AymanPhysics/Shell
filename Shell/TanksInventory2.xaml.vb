Imports System.Data
Imports System.Windows
Imports System.Windows.Media
Imports System.Management

Public Class TanksInventory2

    Public TableName As String = "TanksInventoryMaster2"
    Public TableDetailsName As String = "TanksInventoryDetails2"

    Public SubId As String = "InvoiceNo"

    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Dim StaticsDt As New DataTable
    WithEvents G As New MyGrid

    Public MyDayDate As DateTime = Nothing
    Public MyShift As Integer = 0

    Private Sub Sales_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

        bm.FillCombo("Shifts", Shift, "", , True)
        Shift.SelectedValue = Md.CurrentShiftId

        bm.Fields = New String() {SubId, "Daydate", "Shift", "Notes", "ToId", "Total", "Car", "Diff"}
        bm.control = New Control() {InvoiceNo, DayDate, Shift, Notes, ToId, Total, Car, Diff}
        bm.KeyFields = New String() {SubId}

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
        Shared NetQty As String = "NetQty"
    End Structure

    Private Sub LoadWFH()
        WFH.Child = G
        WFH.TabIndex = 9
        G.TabIndex = 9
        G.TabStop = True
        'G.AllowLeaveGrid = True
        G.StandardTab = True

        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue

        G.Columns.Add(GC.Id, "كود التانك")
        G.Columns.Add(GC.Name, "اسم التانك")
        G.Columns.Add(GC.NetQty, "الكمية المفرغة لتر")


        G.Columns(GC.Name).FillWeight = 300
        G.Columns(GC.NetQty).FillWeight = 150

        G.Columns(GC.Id).ReadOnly = True
        G.Columns(GC.Name).ReadOnly = True


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
            x += Val(G.Rows(i).Cells(GC.NetQty).Value)
        Next
        Total.Text = Math.Round(x, 2, MidpointRounding.AwayFromZero)
    End Sub

    Dim lop As Boolean = False
    Sub CalcRow(ByVal i As Integer)
        'G.EndEdit()
        

    End Sub



    Sub FillControls()
        If lop Then Return
        lop = True
        bm.FillControls()
        ToId_LostFocus(Nothing, Nothing)

        Dim dt As DataTable = bm.ExecuteAdapter("select * from " & TableDetailsName & " where " & SubId & "=" & Val(InvoiceNo.Text))

        G.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Id).Value = dt.Rows(i)("Id").ToString
            G.Rows(i).Cells(GC.Name).Value = dt.Rows(i)("Name").ToString
            G.Rows(i).Cells(GC.NetQty).Value = dt.Rows(i)("NetQty").ToString

        Next
        Notes.Focus()
        If G.Rows.Count > 0 Then G.CurrentCell = G.Rows(0).Cells(0)
        G.RefreshEdit()
        G_SelectionChanged(G, New EventArgs())

        CalcDiff()
        lop = False
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        bm.FirstLast(New String() {SubId}, "Max", dt)
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
        bm.NextPrevious(New String() {SubId}, New String() {Val(InvoiceNo.Text)}, "Next", dt)
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


        Dim inv As String = InvoiceNo.Text
        If Val(InvoiceNo.Text) = 0 Then
            InvoiceNo.Text = bm.ExecuteScalar("select isnull(max(" & SubId & "),0)+1 from " & TableName)
        End If

        bm.DefineValues()
        If Not bm.Save(New String() {SubId}, New String() {Val(InvoiceNo.Text)}) Then
            InvoiceNo.Text = inv
            Return
        End If

        If Not bm.SaveGrid(G, TableDetailsName, New String() {SubId}, New String() {Val(InvoiceNo.Text)}, New String() {"Id", "Name", "NetQty"}, New String() {GC.Id, GC.Name, GC.NetQty}, New VariantType() {VariantType.Integer, VariantType.String, VariantType.Decimal}, New String() {GC.Id}) Then
            InvoiceNo.Text = inv
            Return
        End If

        btnNew_Click(sender, e)
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        bm.FirstLast(New String() {SubId}, "Min", dt)
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
            InvoiceNo.Clear()
            bm.ClearControls(False)
            DayDate.SelectedDate = d

            ToId.Text = bm.ExecuteScalar("select top 1 OilSupplierAccNo from statics")
            ToId_LostFocus(Nothing, Nothing)

            DontCalc = True
            dt = bm.ExecuteAdapter("GetTanksData2", {}, {})
            For i As Integer = 0 To dt.Rows.Count - 1
                G.Rows.Add()
                G.Rows(i).Cells(GC.Id).Value = dt.Rows(i)("Id").ToString
                G.Rows(i).Cells(GC.Name).Value = dt.Rows(i)("Name").ToString
            Next


            CalcDiff()

            DontCalc = False

        Catch
            DontCalc = False
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & Val(InvoiceNo.Text) & "'")

            bm.ExecuteNonQuery("delete from " & TableDetailsName & " where " & SubId & "='" & Val(InvoiceNo.Text) & "'")

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
        bm.NextPrevious(New String() {SubId}, New String() {Val(InvoiceNo.Text)}, "Back", dt)
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
        bm.RetrieveAll(New String() {SubId}, New String() {Val(InvoiceNo.Text)}, dt)
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


     

    Dim DontCalc As Boolean = False
    Dim SaveSub As Boolean = False
    Private Sub G_SelectionChanged(sender As Object, e As EventArgs)
        If DontCalc Then Return
      
    End Sub

    Private Sub G_KeyDown(sender As Object, e As Forms.KeyEventArgs)
        'Throw New NotImplementedException
    End Sub

    Private Sub Car_LostFocus(sender As Object, e As RoutedEventArgs) Handles Car.LostFocus
        Try
            G.EndEdit()
            GridCalcRow(Nothing, New Forms.DataGridViewCellEventArgs(G.CurrentCell.ColumnIndex, G.CurrentCell.RowIndex))
            Car.Text = Val(Car.Text)
            CalcDiff()
        Catch
        End Try
    End Sub

    Sub CalcDiff() Handles Total.TextChanged, Car.TextChanged
        Try
            G.EndEdit()
            GridCalcRow(Nothing, New Forms.DataGridViewCellEventArgs(G.CurrentCell.ColumnIndex, G.CurrentCell.RowIndex))
            Diff.Text = Val(Total.Text) - Val(Car.Text)
        Catch ex As Exception
        End Try
    End Sub
End Class
