Imports System.Data
Imports System.Windows
Imports System.Windows.Media
Imports System.Management

Public Class Inventory2

    Public MainTableName As String = "Stores"
    Public MainSubId As String = "Id"
    Public MainSubName As String = "Name"

    Public TableName As String = "InventoryMaster2"
    Public TableDetailsName As String = "InventoryDetails2"

    Public MainId As String = "StoreId"
    Public SubId As String = "InvoiceNo"

    Dim dv As New DataView
    Dim HelpDt As New DataTable
    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Dim StaticsDt As New DataTable
    WithEvents G As New MyGrid
    WithEvents MyTimer As New Threading.DispatcherTimer
    Public FirstColumn As String = "الكـــــود", SecondColumn As String = "الاســــــــــــم", ThirdColumn As String = "السعــــر", Statement As String = ""
    Dim Gp As String = "الأقسام الرئيسية", Tp As String = "الأقسام الفرعية", It As String = "الأصناف"



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

        RdoGrouping_Checked(Nothing, Nothing)
        bm.FillCombo("Shifts", Shift, "", , True)
        Shift.SelectedValue = Md.CurrentShiftId

        TabItem1.Header = "" ' TryCast(TryCast(Me.Parent, TabItem).Header, TabsHeader).MyTabHeader

        bm.Fields = New String() {MainId, SubId, "DayDate", "Shift", "Notes", "DocNo"}
        bm.control = New Control() {StoreId, InvoiceNo, DayDate, Shift, Notes, DocNo}
        bm.KeyFields = New String() {MainId, SubId}

        bm.Table_Name = TableName

        LoadGroups()
        LoadAllItems()
        LoadWFH()
        DayDate.SelectedDate = Nothing
        DayDate.SelectedDate = Md.CurrentDate
        Shift.SelectedValue = Md.CurrentShiftId
        StoreId.Text = Md.DefaultStore
        StoreId_LostFocus(Nothing, Nothing)


        If Not Md.Manager Then
            btnDelete.Visibility = Visibility.Hidden
            btnFirst.Visibility = Visibility.Hidden
            btnPrevios.Visibility = Visibility.Hidden
            btnNext.Visibility = Visibility.Hidden
            btnLast.Visibility = Visibility.Hidden

            DayDate.IsEnabled = False
            Shift.IsEnabled = False
            If Md.DefaultStore > 0 Then
                StoreId.IsEnabled = False
            End If

            'btnPrint.Visibility = Visibility.Hidden
            'btnSave.Visibility = Visibility.Hidden

        End If

        All.IsChecked = True
        btnPrint2.Visibility = Visibility.Hidden

    End Sub


    Structure GC
        Shared Barcode As String = "Barcode"
        Shared Id As String = "Id"
        Shared Name As String = "Name"
        Shared UnitId As String = "UnitId"
        Shared Qty As String = "Qty"
        Shared QtyAdd As String = "QtyAdd"
        Shared QtyBal As String = "QtyBal"
        Shared Deference As String = "Deference"
    End Structure


    Private Sub LoadWFH()
        'WFH.Background = New SolidColorBrush(Colors.LightSalmon)
        'WFH.Foreground = New SolidColorBrush(Colors.Red)
        WFH.Child = G
        WFH.TabIndex = 9
        G.TabIndex = 9
        G.TabStop = True

        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue

        G.Columns.Add(GC.Barcode, "الباركود")
        G.Columns.Add(GC.Id, "كود الصنف")
        G.Columns.Add(GC.Name, "اسم الصنف")

        Dim GCUnitId As New Forms.DataGridViewComboBoxColumn
        GCUnitId.HeaderText = "الوحدة"
        GCUnitId.Name = GC.UnitId
        bm.FillCombo("select 0 Id,'' Name", GCUnitId)
        G.Columns.Add(GCUnitId)

        G.Columns.Add(GC.Qty, "الكمية المسلمة")
        G.Columns.Add(GC.QtyAdd, "إضافة")
        G.Columns.Add(GC.QtyBal, "رصيد آخر الوردية")
        G.Columns.Add(GC.Deference, "المباع")

        G.Columns(GC.Barcode).FillWeight = 150
        G.Columns(GC.Id).FillWeight = 110
        G.Columns(GC.Name).FillWeight = 300
        G.Columns(GC.UnitId).FillWeight = 200
        G.Columns(GC.Qty).FillWeight = 200
        G.Columns(GC.QtyAdd).FillWeight = 200
        G.Columns(GC.QtyBal).FillWeight = 200
        G.Columns(GC.Deference).FillWeight = 200

        G.Columns(GC.Name).ReadOnly = True
        G.Columns(GC.Deference).ReadOnly = True

        G.BaarcodeIndex = G.Columns(GC.Barcode).Index

        AddHandler G.CellEndEdit, AddressOf GridCalcRow
        AddHandler G.KeyDown, AddressOf GridKeyDown
    End Sub

    Function ReadOnlyState() As Boolean
        If Not Md.AllowCashierToEditPrice Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub LoadGroups()
        Try
            WGroups.Children.Clear()
            WTypes.Children.Clear()
            WItems.Children.Clear()
            TabGroups.Header = Gp
            TabTypes.Header = Tp
            TabItems.Header = It

            Dim dt As DataTable = bm.ExecuteAdapter("LoadGroups2", New String() {"IsShop", "Form"}, New String() {Md.ShopItemsOnly, "0"})
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim x As New Button
                SetStyle(x)
                'bm.SetImage(x, CType(dt.Rows(i)("Image"), Byte()))
                x.Name = "TabItem_" & dt.Rows(i)("Id").ToString
                x.Tag = dt.Rows(i)("Id").ToString
                x.Content = dt.Rows(i)("Name").ToString
                x.ToolTip = dt.Rows(i)("Name").ToString
                WGroups.Children.Add(x)
                AddHandler x.Click, AddressOf LoadTypes
            Next
        Catch
        End Try
    End Sub

    Private Sub LoadTypes(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            Dim xx As Button = sender
            WTypes.Tag = xx.Tag
            WTypes.Children.Clear()
            WItems.Children.Clear()

            If All.IsChecked Then
                Dim dtdt As DataTable = bm.ExecuteAdapter("select Id from Items where GroupId=" & xx.Tag & " and NonStored=0 and dbo.GetStoreItemBal(" & StoreId.Text & ",Id,0,0,'" & bm.ToStrDate(DayDate.SelectedDate) & "')>0 and Stopped=0")
                For i As Integer = 0 To dtdt.Rows.Count - 1
                    AddItem(dtdt.Rows(i)(0))
                Next
            End If

            TabTypes.Header = Tp & " - " & xx.Content.ToString
            TabItems.Header = It

            Dim dt As DataTable = bm.ExecuteAdapter("LoadTypes2", New String() {"GroupId", "Form"}, New String() {xx.Tag.ToString, 0})
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim x As New Button
                SetStyle(x)
                'bm.SetImage(x, CType(dt.Rows(i)("Image"), Byte()))
                x.Name = "TabItem_" & xx.Tag.ToString & "_" & dt.Rows(i)("Id").ToString
                x.Tag = dt.Rows(i)("Id").ToString
                x.Content = dt.Rows(i)("Name").ToString
                x.ToolTip = dt.Rows(i)("Name").ToString
                WTypes.Children.Add(x)
                AddHandler x.Click, AddressOf LoadItems
            Next
        Catch
        End Try
    End Sub


    Sub LoadAllItems()
        Try

            Dim x As Integer = Val(bm.ExecuteScalar("select Flag from stores where ID='" & Val(StoreId.Text) & "'"))
            HelpDt = bm.ExecuteAdapter("Select Id,Name From Items where " & ItemWhere())
            HelpDt.TableName = "tbl"
            HelpDt.Columns(0).ColumnName = FirstColumn
            HelpDt.Columns(1).ColumnName = SecondColumn
            'HelpDt.Columns(2).ColumnName = ThirdColumn

            dv.Table = HelpDt
            HelpGD.ItemsSource = dv
            HelpGD.Columns(0).Width = 75
            HelpGD.Columns(1).Width = 220
            'HelpGD.Columns(2).Width = 75

            HelpGD.SelectedIndex = 0
        Catch
        End Try

    End Sub

    Private Sub txtId_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.GotFocus
        Try
            dv.Sort = FirstColumn
        Catch
        End Try
    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.GotFocus
        Try
            dv.Sort = SecondColumn
        Catch
        End Try
    End Sub

    Private Sub txtPrice_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice.GotFocus
        Try
            dv.Sort = ThirdColumn
        Catch
        End Try
    End Sub

    Private Sub txtId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged, txtName.TextChanged, txtPrice.TextChanged
        Try
            dv.RowFilter = " [" & FirstColumn & "] >" & IIf(txtID.Text.Trim = "", 0, txtID.Text) & " and [" & SecondColumn & "] like '%" & txtName.Text & "%' and [" & ThirdColumn & "] >=" & IIf(txtPrice.Text.Trim = "", 0, txtPrice.Text) & ""
        Catch
        End Try
    End Sub


    Private Sub HelpGD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txtID.PreviewKeyDown, txtName.PreviewKeyDown, txtPrice.PreviewKeyDown
        Try
            If e.Key = Input.Key.Up Then
                HelpGD.SelectedIndex = HelpGD.SelectedIndex - 1
            ElseIf e.Key = Input.Key.Down Then
                HelpGD.SelectedIndex = HelpGD.SelectedIndex + 1
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub HelpGD_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles HelpGD.MouseDoubleClick
        Try
            AddItem(HelpGD.Items(HelpGD.SelectedIndex)(0))
        Catch ex As Exception
        End Try
    End Sub



    Function ItemWhere() As String
        Dim st As String = ""
        st = " ItemType in(0,1,2,3) and Stopped=0 "
        Return st
    End Function
    Private Sub LoadItems(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            Dim xx As Button = sender
            WItems.Tag = xx.Tag
            WItems.Children.Clear()


            If All.IsChecked Then
                Dim dtdt As DataTable = bm.ExecuteAdapter("select Id from Items where GroupId=" & WTypes.Tag.ToString & " and TypeId=" & xx.Tag & " and NonStored=0 and dbo.GetStoreItemBal(" & StoreId.Text & ",Id,0,0,'" & bm.ToStrDate(DayDate.SelectedDate) & "')<>0 and Stopped=0 ")
                For i As Integer = 0 To dtdt.Rows.Count - 1
                    AddItem(dtdt.Rows(i)(0))
                Next
            End If


            TabItems.Header = It & " - " & xx.Content.ToString

            Dim dt As DataTable = bm.ExecuteAdapter("Select * From Items where " & ItemWhere() & " and GroupId=" & WTypes.Tag.ToString & " and TypeId=" & xx.Tag.ToString)
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim x As New Button
                SetStyle(x)
                'bm.SetImage(x, CType(dt.Rows(i)("Image"), Byte()))
                x.Tag = dt.Rows(i)("Id").ToString
                x.Content = dt.Rows(i)("Name").ToString
                x.ToolTip = dt.Rows(i)("Name").ToString
                WItems.Children.Add(x)
                AddHandler x.Click, AddressOf TabItem
            Next
        Catch
        End Try
    End Sub

    Private Sub TabItem(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim x As Button = sender
        AddItem(x.Tag)
    End Sub

    Sub AddItem(ByVal Id As String, Optional ByVal i As Integer = -1, Optional ByVal Add As Decimal = 1)
        Try
            Dim Exists As Boolean = False
            Dim Move As Boolean = False
            If i = -1 Then Move = True

            G.AutoSizeColumnsMode = Forms.DataGridViewAutoSizeColumnsMode.Fill
            If i = -1 Then
                'For x As Integer = 0 To G.Rows.Count - 1
                '    If Not G.Rows(x).Cells(GC.Id).Value Is Nothing AndAlso G.Rows(x).Cells(GC.Id).Value.ToString = Id.ToString AndAlso Not G.Rows(x).ReadOnly AndAlso Not G.Rows(x).Cells(GC.IsPrinted).Value = 1 Then
                '        i = x
                '        Exists = True
                '        GoTo Br
                '    End If
                'Next
                i = G.Rows.Add()
Br:
            End If

            Dim dt As DataTable = bm.ExecuteAdapter("Select * From Items where Id='" & Id & "' and " & ItemWhere())
            Dim dr() As DataRow = dt.Select("Id='" & Id & "'")
            If dr.Length = 0 Then
                If Not G.Rows(i).Cells(GC.Id).Value Is Nothing OrElse G.Rows(i).Cells(GC.Id).Value <> "" Then bm.ShowMSG("هذا الصنف غير موجود")
                ClearRow(i)
                Return
            End If
            G.Rows(i).Cells(GC.Id).Value = dr(0)(GC.Id)
            G.Rows(i).Cells(GC.Name).Value = dr(0)(GC.Name)
            LoadItemUint(i)
            GridCalcRow(Nothing, New Forms.DataGridViewCellEventArgs(G.Columns(GC.UnitId).Index, i))
            CalcRow(i)
            If Move Then
                G.Focus()
                G.Rows(i).Selected = True
                G.FirstDisplayedScrollingRowIndex = i
                G.CurrentCell = G.Rows(i).Cells(GC.QtyAdd)
                G.EditMode = Forms.DataGridViewEditMode.EditOnEnter
                G.BeginEdit(True)
            End If
            If Exists Then
                G.Rows(i).Selected = True
                G.FirstDisplayedScrollingRowIndex = i
                G.CurrentCell = G.Rows(i).Cells(GC.QtyAdd)
                'G.CurrentCell = G.Rows(i).Cells(GC.Qty)
                G.EditMode = Forms.DataGridViewEditMode.EditOnEnter
                G.BeginEdit(True)
            End If
        Catch
            If i <> -1 Then
                ClearRow(i)
            End If
        End Try
    End Sub

    Dim lop As Boolean = False
    Sub CalcRow(ByVal i As Integer)
        Try
            If G.Rows(i).Cells(GC.Id).Value Is Nothing OrElse G.Rows(i).Cells(GC.Id).Value.ToString = "" Then
                ClearRow(i)
                Return
            End If
            G.Rows(i).Cells(GC.Deference).Value = Val(G.Rows(i).Cells(GC.Qty).Value) + Val(G.Rows(i).Cells(GC.QtyAdd).Value) - Val(G.Rows(i).Cells(GC.QtyBal).Value)
        Catch ex As Exception
            ClearRow(i)
        End Try
    End Sub

    Sub ClearRow(ByVal i As Integer)
        G.Rows(i).Cells(GC.Barcode).Value = Nothing
        G.Rows(i).Cells(GC.Id).Value = Nothing
        G.Rows(i).Cells(GC.Name).Value = Nothing
        G.Rows(i).Cells(GC.UnitId).Value = Nothing
        G.Rows(i).Cells(GC.Qty).Value = Nothing
        G.Rows(i).Cells(GC.QtyAdd).Value = Nothing
        G.Rows(i).Cells(GC.QtyBal).Value = Nothing
        G.Rows(i).Cells(GC.Deference).Value = Nothing
    End Sub

    Private Sub GridCalcRow(ByVal sender As Object, ByVal e As Forms.DataGridViewCellEventArgs)
        If G.Columns(e.ColumnIndex).Name = GC.Barcode AndAlso Not G.Rows(e.RowIndex).Cells(GC.Barcode).Value Is Nothing Then
            If G.Rows(e.RowIndex).Cells(GC.Barcode).Value.ToString.Length > 0 Then
                G.Rows(e.RowIndex).Cells(GC.Id).Value = bm.ExecuteScalar("select top 1 ItemId from ItemsBarcode where Barcode='" & G.Rows(e.RowIndex).Cells(GC.Barcode).Value.ToString & "'")
                GridCalcRow(sender, New Forms.DataGridViewCellEventArgs(G.Columns(GC.Id).Index, e.RowIndex))
                Exit Sub
            End If
        ElseIf G.Columns(e.ColumnIndex).Name = GC.Id Then
            AddItem(G.Rows(e.RowIndex).Cells(GC.Id).Value, e.RowIndex, 0)
        ElseIf G.Columns(e.ColumnIndex).Name = GC.UnitId Then
            'G.Rows(e.RowIndex).Cells(GC.Qty).Value = bm.ExecuteScalar("select dbo.FnStoreIetmBal(" & Val(StoreId.Text) & "," & G.Rows(e.RowIndex).Cells(GC.Id).Value & "," & G.Rows(e.RowIndex).Cells(GC.UnitId).Value & ",'" & bm.ToStrDate(DayDate.SelectedDate) & "')")
        End If
        G.EditMode = Forms.DataGridViewEditMode.EditOnEnter
        CalcRow(e.RowIndex)
    End Sub


    Private Sub StoreId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyUp
        If bm.ShowHelp("Stores", StoreId, StoreName, e, "select cast(Id as varchar(100)) Id,Name from Fn_EmpStores(" & Md.UserName & ")") Then
            StoreId_LostFocus(StoreId, Nothing)
        End If
    End Sub

    Private Sub StoreId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StoreId.LostFocus
        bm.LostFocus(StoreId, StoreName, "select Name from Fn_EmpStores(" & Md.UserName & ") where Id=" & StoreId.Text.Trim())
        LoadAllItems()
        ClearControls()
    End Sub

    Sub FillControls()
        If lop Then Return
        lop = True
        UndoNewId()
        bm.FillControls()

        Dim dt As DataTable = bm.ExecuteAdapter("select SD.* /*,It.Unit,It.UnitSub*/ from InventoryDetails2 SD left join Items It on(SD.ItemId=It.Id) where SD.StoreId=" & StoreId.Text & " and SD.InvoiceNo=" & InvoiceNo.Text & bm.AppendWhere)

        G.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add()
            G.Rows(i).Cells(GC.Barcode).Value = dt.Rows(i)("Barcode").ToString
            G.Rows(i).Cells(GC.Id).Value = dt.Rows(i)("ItemId").ToString
            G.Rows(i).Cells(GC.Name).Value = dt.Rows(i)("ItemName").ToString
            LoadItemUint(i)
            G.Rows(i).Cells(GC.UnitId).Value = dt.Rows(i)("UnitId")
            G.Rows(i).Cells(GC.Qty).Value = dt.Rows(i)("Qty").ToString
            G.Rows(i).Cells(GC.QtyAdd).Value = dt.Rows(i)("QtyAdd").ToString
            G.Rows(i).Cells(GC.QtyBal).Value = dt.Rows(i)("QtyBal").ToString
            G.Rows(i).Cells(GC.Deference).Value = dt.Rows(i)("Deference").ToString
            CalcRow(i)
            If Md.Cashier Then
                G.Rows(i).ReadOnly = True
                G.Rows(i).DefaultCellStyle.BackColor = System.Drawing.Color.PeachPuff
                btnDelete.IsEnabled = False
            End If
        Next
        Notes.Focus()
        G.RefreshEdit()
        lop = False
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        bm.FirstLast(New String() {MainId, SubId}, "Max", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        bm.NextPrevious(New String() {MainId, SubId}, New String() {StoreId.Text, InvoiceNo.Text}, "Next", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnPrint.Click, btnPrint2.Click
        btnSave_Click(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If StoreId.Text.Trim = "" Then Return
        If Not CType(sender, Button).IsEnabled Then Return

        For i As Integer = 0 To G.Rows.Count - 1
            If Val(G.Rows(i).Cells(GC.Id).Value) > 0 Then
                Exit For
            End If
            If i = G.Rows.Count - 1 Then Return
        Next

        For i As Integer = 0 To G.Rows.Count - 1
            If Val(G.Rows(i).Cells(GC.Id).Value) > 0 AndAlso G.Rows(i).Cells(GC.QtyAdd).Value Is Nothing AndAlso Md.MyProject <> Client.AutoMarket Then
                bm.ShowMSG("برجاء تحديد الكمية بالسطر رقم " & (i + 1).ToString)
                G.CurrentCell = G.Rows(i).Cells(GC.QtyAdd)
                G.Focus()
                G.BeginEdit(True)
                Return
            End If
        Next


        G.EndEdit()
        Try
            CalcRow(G.CurrentRow.Index)
        Catch ex As Exception
        End Try

        If Not Md.Manager Then
            DayDate.SelectedDate = Md.CurrentDate
            Shift.SelectedValue = Md.CurrentShiftId
        End If


        Dim State As BasicMethods.SaveState = BasicMethods.SaveState.Update
        If InvoiceNo.Text.Trim = "" Then
            InvoiceNo.Text = bm.ExecuteScalar("select max(" & SubId & ")+1 from " & TableName & " where " & MainId & "='" & StoreId.Text & "'" & bm.AppendWhere)
            If InvoiceNo.Text = "" Then InvoiceNo.Text = "1"
            lblLastEntry.Text = InvoiceNo.Text
            'lblLastEntry.Foreground = System.Windows.Media.Brushes.Red
            'System.Threading.Thread.Sleep(500)
            'lblLastEntry.Foreground = System.Windows.Media.Brushes.Blue
            State = BasicMethods.SaveState.Insert
        End If

        bm.DefineValues()
        If Not bm.Save(New String() {MainId, SubId}, New String() {StoreId.Text, InvoiceNo.Text.Trim}, State) Then
            If State = BasicMethods.SaveState.Insert Then
                InvoiceNo.Text = ""
                lblLastEntry.Text = ""
            End If
            Return
        End If

        If Not bm.SaveGrid(G, "InventoryDetails2", New String() {"StoreId", "InvoiceNo"}, New String() {StoreId.Text, InvoiceNo.Text}, New String() {"Barcode", "ItemId", "ItemName", "UnitId", "Qty", "QtyAdd", "QtyBal", "Deference"}, New String() {GC.Barcode, GC.Id, GC.Name, GC.UnitId, GC.Qty, GC.QtyAdd, GC.QtyBal, GC.Deference}, New VariantType() {VariantType.String, VariantType.Integer, VariantType.String, VariantType.Integer, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal, VariantType.Decimal}, New String() {GC.Id}) Then Return

        'If /*State = BasicMethods.SaveState.Insert AndAlso*/ Flag = FlagState.مشتريات Then
        Select Case CType(sender, Button).Name
            Case btnPrint.Name, btnPrint2.Name
                State = BasicMethods.SaveState.Print
        End Select

        If sender Is btnPrint OrElse sender Is btnPrint2 Then
            PrintPone(sender)
            'txtID_Leave(Nothing, Nothing)
            'AllowClose = True
            Return
        End If

        If Not DontClear Then btnNew_Click(sender, e)
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        bm.FirstLast(New String() {MainId, SubId}, "Min", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearControls()
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

            Dim s As String = Shift.SelectedValue.ToString
            Dim st As String = StoreId.Text

            bm.ClearControls(False)
            If Md.Cashier = 1 Then
                DayDate.SelectedDate = Md.CurrentDate
                Shift.SelectedValue = Md.CurrentShiftId
            Else
                DayDate.SelectedDate = d
                Shift.SelectedValue = s
            End If

            DayDate.SelectedDate = Md.CurrentDate
            Shift.SelectedValue = Md.CurrentShiftId

            StoreId.Text = st


            G.Rows.Clear()
            'InvoiceNo.Text = bm.ExecuteScalar("select max(" & SubId & ")+1 from " & TableName & " where " & MainId & "='" & StoreId.Text & "'" & bm.AppendWhere)
            'If InvoiceNo.Text = "" Then InvoiceNo.Text = "1"
        Catch
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & InvoiceNo.Text.Trim & "' and " & MainId & " ='" & StoreId.Text & "'")

            bm.ExecuteNonQuery("delete from " & TableDetailsName & " where " & SubId & "='" & InvoiceNo.Text.Trim & "' and " & MainId & " ='" & StoreId.Text & "'")

            btnNew_Click(sender, e)
        End If
    End Sub

    Private Sub btnPrevios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevios.Click
        bm.NextPrevious(New String() {MainId, SubId}, New String() {StoreId.Text, InvoiceNo.Text}, "Back", dt)
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
        bm.RetrieveAll(New String() {MainId, SubId}, New String() {StoreId.Text, InvoiceNo.Text.Trim}, dt)
        If dt.Rows.Count = 0 Then
            ClearControls()
            lv = False
            Return
        End If
        FillControls()
        lv = False
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyDown, InvoiceNo.KeyDown, txtID.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub txtID_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txtPrice.KeyDown
        bm.MyKeyPress(sender, e, True)
    End Sub

    Private Sub btnDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDeleteRow.Click
        Try
            If Not G.CurrentRow.ReadOnly AndAlso bm.ShowDeleteMSG("MsgDeleteRow") Then
                G.Rows.Remove(G.CurrentRow)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrintPone(ByVal sender As System.Object)
        Dim rpt As New ReportViewer
        rpt.paraname = New String() {"@FromDate", "@ToDate", "@Shift", "@StoreId", "@FromInvoiceNo", "@ToInvoiceNo", "Header"}

        rpt.paravalue = New String() {DayDate.SelectedDate, DayDate.SelectedDate, Shift.SelectedValue.ToString, StoreId.Text, InvoiceNo.Text, InvoiceNo.Text, CType(Parent, Page).Title}
        rpt.Rpt = "Inventory2Pone.rpt"
        If sender Is btnPrint2 Then rpt.Rpt = "Inventory2PoneBlank.rpt"
        'rpt.Print(, , 1 )
        rpt.Show()

    End Sub


    Private Sub RdoGrouping_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles RdoGrouping.Checked, RdoSearch.Checked
        Try
            If RdoGrouping.IsChecked Then
                txtID.Visibility = Visibility.Hidden
                txtName.Visibility = Visibility.Hidden
                txtPrice.Visibility = Visibility.Hidden
                HelpGD.Visibility = Visibility.Hidden
                PanelGroups.Visibility = Visibility.Visible
                PanelTypes.Visibility = Visibility.Visible
                PanelItems.Visibility = Visibility.Visible
            ElseIf RdoSearch.IsChecked Then
                txtID.Visibility = Visibility.Visible
                txtName.Visibility = Visibility.Visible
                txtPrice.Visibility = Visibility.Visible
                HelpGD.Visibility = Visibility.Visible
                PanelGroups.Visibility = Visibility.Hidden
                PanelTypes.Visibility = Visibility.Hidden
                PanelItems.Visibility = Visibility.Hidden
            End If
        Catch
        End Try
    End Sub


    Dim LopCalc As Boolean = False
    Dim DontClear As Boolean = False

    Private Sub GridKeyDown(ByVal sender As Object, ByVal e As Forms.KeyEventArgs)
        Try
            If G.CurrentCell.RowIndex = G.Rows.Count - 1 Then
                Dim c = G.CurrentCell.RowIndex
                G.Rows.Add()
                G.CurrentCell = G.Rows(c).Cells(G.CurrentCell.ColumnIndex)
            End If
            If G.CurrentCell.ColumnIndex = G.Columns(GC.Id).Index OrElse G.CurrentCell.ColumnIndex = G.Columns(GC.Name).Index Then
                If bm.ShowHelpGrid("Items", G.CurrentRow.Cells(GC.Id), G.CurrentRow.Cells(GC.Name), e, "select cast(Id as varchar(100)) Id,Name from Items where Stopped=0") Then
                    GridCalcRow(sender, New Forms.DataGridViewCellEventArgs(G.Columns(GC.Id).Index, G.CurrentCell.RowIndex))
                    G.CurrentCell = G.Rows(G.CurrentCell.RowIndex).Cells(GC.QtyAdd)
                End If
            End If
        Catch ex As Exception
        End Try
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


    Private Sub LoadItemUint(i As Integer)
        Try
            Dim Id As Integer = Val(G.Rows(i).Cells(GC.Id).Value)
            Dim dt As DataTable = bm.ExecuteAdapter("Select * From Items where Id='" & Id & "' and " & ItemWhere() & "")

            bm.FillCombo("select 0 Id,Unit Name From Items where Id='" & Id & "' and " & ItemWhere() & " union select 1 Id,UnitSub Name From Items where Id='" & Id & "' and " & ItemWhere() & " /*union select 2 Id,UnitSub2 Name From Items where Id='" & Id & "' and " & ItemWhere() & "*/", G.Rows(i).Cells(GC.UnitId))

            If Val(dt.Rows(0)("MainUnitOnly")) <> 1 AndAlso Val(bm.ExecuteScalar("select Flag from stores where ID='" & Val(StoreId.Text) & "'")) = 1 Then
                G.Rows(i).Cells(GC.UnitId).Value = 1
            End If
            If G.Rows(i).Cells(GC.UnitId).Value Is Nothing Then G.Rows(i).Cells(GC.UnitId).Value = 0
        Catch
        End Try
    End Sub


End Class
