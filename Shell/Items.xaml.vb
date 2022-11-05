Imports System.Data

Public Class Items
    Public TableName As String = "Items"
    Public SubId As String = "Id"
    Public SubName As String = "Name"



    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Public Flag As Integer = 0
    WithEvents G As New MyGrid
    WithEvents G1 As New MyGrid
    WithEvents G2 As New MyGrid

    Private Sub BasicForm_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadWFH()
        LoadWFH1()
        LoadWFH2()
        LoadResource()
        lblStoreId.Visibility = Visibility.Hidden
        StoreId.Visibility = Visibility.Hidden
        StoreName.Visibility = Visibility.Hidden
        lblPrintingGroupId.Visibility = Visibility.Hidden
        PrintingGroupId.Visibility = Visibility.Hidden
        PrintingGroupName.Visibility = Visibility.Hidden
        
        If Not Md.SaleQtySub Then
            lblUnitSub.Visibility = Visibility.Hidden
            lblPurchasePriceSub.Visibility = Visibility.Hidden
            lblSalesPriceSub.Visibility = Visibility.Hidden
            lblUnitCount.Visibility = Visibility.Hidden
            
            UnitSub.Visibility = Visibility.Hidden
            PurchasePriceSub.Visibility = Visibility.Hidden
            SalesPriceSub.Visibility = Visibility.Hidden
            UnitCount.Visibility = Visibility.Hidden

            UnitSub2.Visibility = Visibility.Hidden
            PurchasePriceSub2.Visibility = Visibility.Hidden
            SalesPriceSub2.Visibility = Visibility.Hidden
            UnitCount2.Visibility = Visibility.Hidden
        End If

        bm.Fields = New String() {SubId, SubName, "GroupId", "TypeId", "PrintingGroupId", "StoreId", "PurchasePrice", "PurchasePriceSub", "PurchasePriceSub2", "SalesPrice", "SalesPriceSub", "SalesPriceSub2", "ItemType", "Unit", "UnitSub", "UnitSub2", "UnitCount", "UnitCount2", "Adding", "IsTables", "IsTakeAway", "IsDelivary", "Limit", "LimitSub", "Target", "NonStored", "Service", "Service2", "MainUnitOnly", "Bonus", "Stopped", "Weight", "WeightSub", "Maximum", "MaximumSub", "SalesPriceSubTax", "SalesPriceTax", "OnlinePrice"}
        bm.control = New Control() {txtID, txtName, GroupId, TypeId, PrintingGroupId, StoreId, PurchasePrice, PurchasePriceSub, PurchasePriceSub2, SalesPrice, SalesPriceSub, SalesPriceSub2, ItemType, Unit, UnitSub, UnitSub2, UnitCount, UnitCount2, Adding, IsTables, IsTakeAway, IsDelivary, Limit, LimitSub, Target, NonStored, Service, Service2, MainUnitOnly, Bonus, Stopped, Weight, WeightSub, Maximum, MaximumSub, SalesPriceSubTax, SalesPriceTax, OnlinePrice}
        bm.KeyFields = New String() {SubId}
        bm.Table_Name = TableName
        btnNew_Click(sender, e)
        ItemType.SelectedIndex = 0

        If Md.MyProject = Client.El7ariry Then
            LimitSub.Visibility = Visibility.Hidden
            lblLimitSub.Visibility = Visibility.Hidden
            SalesPriceSub.Visibility = Visibility.Hidden
            lblSalesPriceSub.Visibility = Visibility.Hidden
        Else
            TabItem1.Visibility = Visibility.Hidden
            TabItem2.Visibility = Visibility.Hidden
            lblOnlinePrice.Visibility = Visibility.Hidden
            OnlinePrice.Visibility = Visibility.Hidden
        End If
    End Sub

    Structure GC
        Shared Barcode As String = "Barcode"
    End Structure

    Structure GC1
        Shared StoreId As String = "StoreId"
        Shared StoreName As String = "StoreName"
        Shared Price As String = "Price"
        Shared PriceSub As String = "PriceSub"
        'Shared PriceSub2 As String = "PriceSub2"
        Shared Limit As String = "Limit"
        Shared Maximum As String = "Maximum"
    End Structure

    Structure GC2
        Shared CustomerId As String = "CustomerId"
        Shared CustomerName As String = "CustomerName"
        Shared Price As String = "Price"
        Shared PriceSub As String = "PriceSub"
    End Structure

    Private Sub LoadWFH()
        WFH0.Child = G
        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue
        G.Columns.Add(GC.Barcode, "Barcode")

        G.AutoSizeColumnsMode = Forms.DataGridViewAutoSizeColumnsMode.Fill
        G.AllowUserToDeleteRows = True
        G.EditMode = Forms.DataGridViewEditMode.EditOnEnter
        G.TabStop = False

    End Sub

    Private Sub LoadWFH1()
        WFH1.Child = G1
        G1.Columns.Clear()
        G1.ForeColor = System.Drawing.Color.DarkBlue
        G1.Columns.Add(GC1.StoreId, "كود المخزن")
        G1.Columns.Add(GC1.StoreName, "اسم المخزن")
        G1.Columns.Add(GC1.Price, "السعر")
        G1.Columns.Add(GC1.PriceSub, "السعر فرعي")
        G1.Columns.Add(GC1.Limit, "حد الطلب")
        G1.Columns.Add(GC1.Maximum, "الحد الأقصى")

        G1.AutoSizeColumnsMode = Forms.DataGridViewAutoSizeColumnsMode.Fill
        G1.AllowUserToDeleteRows = False
        G1.AllowUserToAddRows = False
        G1.EditMode = Forms.DataGridViewEditMode.EditOnEnter
        G1.TabStop = False

        G1.Columns(GC1.StoreId).ReadOnly = True
        G1.Columns(GC1.StoreName).ReadOnly = True
        G1.Columns(GC1.StoreName).FillWeight = 300

    End Sub

    Private Sub LoadWFH2()
        WFH2.Child = G2
        G2.Columns.Clear()
        G2.ForeColor = System.Drawing.Color.DarkBlue
        G2.Columns.Add(GC2.CustomerId, "كود العميل")
        G2.Columns.Add(GC2.CustomerName, "اسم العميل")
        G2.Columns.Add(GC2.Price, "السعر")
        G2.Columns.Add(GC2.PriceSub, "السعر فرعي")

        G2.AutoSizeColumnsMode = Forms.DataGridViewAutoSizeColumnsMode.Fill
        G2.EditMode = Forms.DataGridViewEditMode.EditOnEnter
        G2.TabStop = False

        G2.Columns(GC2.CustomerName).ReadOnly = True
        G2.Columns(GC2.CustomerName).FillWeight = 300

        AddHandler G2.KeyDown, AddressOf G2_KeyDown
        AddHandler G2.CellEndEdit, AddressOf G2_CellEndEdit
    End Sub

    Private Sub G2_KeyDown(sender As Object, e As Forms.KeyEventArgs)
        Try
            If G2.CurrentCell.RowIndex = G2.Rows.Count - 1 Then
                Dim c = G2.CurrentCell.RowIndex
                G2.Rows.Add()
                G2.CurrentCell = G2.Rows(c).Cells(G2.CurrentCell.ColumnIndex)
            End If
            If G2.CurrentCell.ColumnIndex = G2.Columns(GC2.CustomerId).Index OrElse G2.CurrentCell.ColumnIndex = G2.Columns(GC2.CustomerName).Index Then
                G2.CancelEdit()
                If bm.ShowHelpGrid("Customers", G2.CurrentRow.Cells(GC2.CustomerId), G2.CurrentRow.Cells(GC2.CustomerName), e, "select cast(Id as varchar(100)) Id,Name from Customers") Then
                    G2_CellEndEdit(sender, New Forms.DataGridViewCellEventArgs(G2.Columns(GC2.CustomerId).Index, G2.CurrentCell.RowIndex))
                    G2.CurrentCell = G2.Rows(G2.CurrentCell.RowIndex).Cells(GC2.Price)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub G2_CellEndEdit(sender As Object, e As Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = G2.Columns(GC2.CustomerId).Index Then
            Dim dt As DataTable = bm.ExecuteAdapter("Select Id,Name From Customers where Id=" & Val(G2.Rows(e.RowIndex).Cells(GC2.CustomerId).Value))
            If dt.Rows.Count > 0 Then
                G2.Rows(e.RowIndex).Cells(GC2.CustomerId).Value = dt.Rows(0)(0)
                G2.Rows(e.RowIndex).Cells(GC2.CustomerName).Value = dt.Rows(0)(1)
            Else
                G2.Rows(e.RowIndex).Cells(GC2.CustomerId).Value = ""
                G2.Rows(e.RowIndex).Cells(GC2.CustomerName).Value = ""
            End If
        End If
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        bm.FirstLast(New String() {SubId}, "Max", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Sub FillControls()
        bm.FillControls()
        bm.GetImage(TableName, New String() {SubId}, New String() {txtID.Text.Trim}, "Image", Image1)

        GroupId_LostFocus(Nothing, Nothing)
        TypeId_LostFocus(Nothing, Nothing)
        PrintingGroupId_LostFocus(Nothing, Nothing)
        StoreId_LostFocus(Nothing, Nothing)

        G.Rows.Clear()
        G1.Rows.Clear()
        G2.Rows.Clear()

        dt = bm.ExecuteAdapter("select Barcode from ItemsBarcode where ItemId='" & Val(txtID.Text) & "'")
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add({dt.Rows(i)(0)})
        Next

        If TabItem1.Visibility = Visibility.Visible Then
            dt = bm.ExecuteAdapter("select s.Id,s.Name,P.Price,P.PriceSub,Limit,Maximum from Stores s left join ItemsPrices P on(P.StoreId=s.Id and p.ItemId='" & Val(txtID.Text) & "')")
            For i As Integer = 0 To dt.Rows.Count - 1
                G1.Rows.Add({dt.Rows(i)(0), dt.Rows(i)(1), dt.Rows(i)(2), dt.Rows(i)(3), dt.Rows(i)(4), dt.Rows(i)(5)})
            Next
        End If

        If TabItem2.Visibility = Visibility.Visible Then
            dt = bm.ExecuteAdapter("select s.Id,s.Name,P.Price,P.PriceSub from CustomerItems P left join Customers s on(P.CustomerId=s.Id) where p.ItemId='" & Val(txtID.Text) & "'")
            For i As Integer = 0 To dt.Rows.Count - 1
                G2.Rows.Add({dt.Rows(i)(0), dt.Rows(i)(1), dt.Rows(i)(2), dt.Rows(i)(3)})
            Next
        End If
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        bm.NextPrevious(New String() {SubId}, New String() {txtID.Text}, "Next", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtName.Text.Trim = "" Then
            txtName.Focus()
            Return
        End If

        Dim s As String = bm.ExecuteScalar("select Id from Items where Id<>'" & Val(txtID.Text) & "' and Name='" & txtName.Text.Trim & "'")
        If s <> "" Then
            bm.ShowMSG("تم تكرار اسم الصنف في الصنف رقم " & s)
            txtName.Focus()
            Return
        End If

        Target.Text = Val(Target.Text)
        UnitCount.Text = Val(UnitCount.Text)
        PurchasePrice.Text = Val(PurchasePrice.Text)
        PurchasePriceSub.Text = Val(PurchasePriceSub.Text)
        SalesPrice.Text = Val(SalesPrice.Text)
        SalesPriceSub.Text = Val(SalesPriceSub.Text)

        Maximum.Text = Val(Maximum.Text)
        MaximumSub.Text = Val(MaximumSub.Text)

        UnitCount2.Text = Val(UnitCount2.Text)
        PurchasePriceSub2.Text = Val(PurchasePriceSub2.Text)
        SalesPriceSub2.Text = Val(SalesPriceSub2.Text)
        Limit.Text = Val(Limit.Text)
        LimitSub.Text = Val(LimitSub.Text)
        Service.Text = Val(Service.Text)
        Service2.Text = Val(Service2.Text)

        G.EndEdit()
        G1.EndEdit()
        G2.EndEdit()

        bm.DefineValues()
        If Not bm.Save(New String() {SubId}, New String() {txtID.Text.Trim}) Then Return

        bm.ExecuteNonQuery("delete ItemsBarcode where ItemId='" & Val(txtID.Text) & "'")
        Dim Str As String = "insert ItemsBarcode(ItemId,Barcode,UserName,MyGetDate) values "
        For i As Integer = 0 To G.Rows.Count - 1
            Try
                If G.Rows(i).Cells(GC.Barcode).Value.ToString.Trim = "" Then Continue For
                Str &= "('" & Val(txtID.Text) & "','" & G.Rows(i).Cells(GC.Barcode).Value.ToString & "','" & Md.UserName & "',GetDate()),"
            Catch ex As Exception
            End Try
        Next
        Str = Str.Substring(0, Str.Length - 1)
        bm.ExecuteNonQuery(Str)



        Str = "delete ItemsPrices where ItemId='" & Val(txtID.Text) & "' insert ItemsPrices(ItemId,StoreId,Price,PriceSub,Limit,Maximum,UserName,MyGetDate) values "
        For i As Integer = 0 To G1.Rows.Count - 1
            Try
                If G1.Rows(i).Cells(GC1.StoreId).Value.ToString.Trim = "" Then Continue For
                Str &= "('" & Val(txtID.Text) & "','" & G1.Rows(i).Cells(GC1.StoreId).Value.ToString & "','" & G1.Rows(i).Cells(GC1.Price).Value.ToString & "','" & G1.Rows(i).Cells(GC1.PriceSub).Value.ToString & "','" & G1.Rows(i).Cells(GC1.Limit).Value.ToString & "','" & G1.Rows(i).Cells(GC1.Maximum).Value.ToString & "','" & Md.UserName & "',GetDate()),"
            Catch ex As Exception
            End Try
        Next
        Str = Str.Substring(0, Str.Length - 1)
        bm.ExecuteNonQuery(Str)


        Str = "delete CustomerItems where ItemId='" & Val(txtID.Text) & "' insert CustomerItems(ItemId,CustomerId,Price,PriceSub,UserName,MyGetDate) values "
        For i As Integer = 0 To G2.Rows.Count - 1
            Try
                If G2.Rows(i).Cells(GC2.CustomerId).Value.ToString.Trim = "" Then Continue For
                Str &= "('" & Val(txtID.Text) & "','" & G2.Rows(i).Cells(GC2.CustomerId).Value.ToString & "','" & G2.Rows(i).Cells(GC2.Price).Value.ToString & "','" & G2.Rows(i).Cells(GC2.PriceSub).Value.ToString & "','" & Md.UserName & "',GetDate()),"
            Catch ex As Exception
            End Try
        Next
        Str = Str.Substring(0, Str.Length - 1)
        bm.ExecuteNonQuery(Str)


        bm.SaveImage(TableName, New String() {SubId}, New String() {txtID.Text.Trim}, "Image", Image1)

        Dim gp As String = GroupId.Text
        Dim tp As String = TypeId.Text
        btnNew_Click(sender, e)
        GroupId.Text = gp
        TypeId.Text = tp
        GroupId_LostFocus(Nothing, Nothing)
        TypeId_LostFocus(Nothing, Nothing)
        txtID.Text = bm.ExecuteScalar("select max(" & SubId & ")+1 from " & TableName & " where GroupId=" & gp & " and TypeId=" & tp)
        G.Rows.Clear()
        G.Rows.Add({txtID.Text})
        G.Rows.Add({bm.ean13(txtID.Text)})
        If txtID.Text = "" Then txtID.Text = "1"

    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        bm.FirstLast(New String() {SubId}, "Min", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearControls()
    End Sub

    Sub ClearControls()
        bm.ClearControls()
        bm.SetNoImage(Image1)
        G.Rows.Clear()
        G1.Rows.Clear()
        G2.Rows.Clear()

        If TabItem1.Visibility = Visibility.Visible Then
            dt = bm.ExecuteAdapter("select Id,Name,0,0 from Stores")
            For i As Integer = 0 To dt.Rows.Count - 1
                G1.Rows.Add({dt.Rows(i)(0), dt.Rows(i)(1), dt.Rows(i)(2), dt.Rows(i)(3)})
            Next
        End If


        GroupName.Clear()
        TypeName.Clear()
        PrintingGroupName.Clear()
        StoreName.Clear()

        txtName.Clear()
        txtID.Text = bm.ExecuteScalar("select max(" & SubId & ")+1 from " & TableName)
        If txtID.Text = "" Then txtID.Text = "1"
        G.Rows.Add({txtID.Text})
        G.Rows.Add({bm.ean13(txtID.Text)})
        txtName.Focus()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & txtID.Text.Trim & "'")
            bm.ExecuteNonQuery("delete from ItemsBarcode where ItemId='" & txtID.Text.Trim & "'")
            bm.ExecuteNonQuery("delete from ItemsPrices where ItemId='" & txtID.Text.Trim & "'")
            bm.ExecuteNonQuery("delete from CustomerItems where ItemId='" & txtID.Text.Trim & "'")
            btnNew_Click(sender, e)
        End If
    End Sub

    Private Sub btnPrevios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevios.Click
        bm.NextPrevious(New String() {SubId}, New String() {txtID.Text}, "Back", dt)
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
        bm.RetrieveAll(New String() {SubId}, New String() {txtID.Text.Trim}, dt)
        If dt.Rows.Count = 0 Then
            Dim s As String = txtID.Text
            ClearControls()
            txtID.Text = s
            txtName.Focus()
            lv = False
            Return
        End If
        FillControls()
        lv = False
        txtName.SelectAll()
        txtName.Focus()
        txtName.SelectAll()
        txtName.Focus()
        'txtName.Text = dt(0)("Name")
    End Sub

    Private Sub StoreId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyUp
        bm.ShowHelp("Stores", StoreId, StoreName, e, "select cast(Id as varchar(100)) Id,Name from Stores")
    End Sub

    Private Sub TypeId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles TypeId.KeyUp
        bm.ShowHelp("Types", TypeId, TypeName, e, "select cast(Id as varchar(100)) Id,Name from Types where GroupId=" & GroupId.Text.Trim)
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txtID.KeyDown, GroupId.KeyDown, TypeId.KeyDown, PrintingGroupId.KeyDown, StoreId.KeyDown, ItemType.KeyDown, Limit.KeyDown, LimitSub.KeyDown, Target.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub txtID_KeyUp(sender As Object, e As KeyEventArgs) Handles txtID.KeyUp
        Try
            If bm.ShowHelp("Items", txtID, txtName, e, "select cast(Id as varchar(100)) Id,Name from Items where Stopped=0") Then txtName.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrintingGroupId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles PrintingGroupId.KeyUp
        bm.ShowHelp("PrintingGroups", PrintingGroupId, PrintingGroupName, e, "select cast(Id as varchar(100)) Id,Name from PrintingGroups")
    End Sub


    Private Sub txtID_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles PurchasePrice.KeyDown, PurchasePriceSub.KeyDown, SalesPrice.KeyDown, SalesPriceSub.KeyDown, PurchasePriceSub2.KeyDown, SalesPriceSub2.KeyDown, UnitCount.KeyDown, UnitCount2.KeyDown, Service.KeyDown, Service2.KeyDown
        bm.MyKeyPress(sender, e, True)
    End Sub

    Private Sub GroupId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles GroupId.LostFocus
        bm.LostFocus(GroupId, GroupName, "select Name from Groups where Id=" & GroupId.Text.Trim())
        TypeId_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub PrintingGroupId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles PrintingGroupId.LostFocus
        bm.LostFocus(PrintingGroupId, PrintingGroupName, "select Name from PrintingGroups where Id=" & PrintingGroupId.Text.Trim())
    End Sub

    Private Sub TypeId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TypeId.LostFocus
        bm.LostFocus(TypeId, TypeName, "select Name from Types where GroupId=" & GroupId.Text.Trim & " and Id=" & TypeId.Text.Trim())
    End Sub

    Private Sub StoreId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StoreId.LostFocus
        bm.LostFocus(StoreId, StoreName, "select Name from Fn_EmpStores(" & Md.UserName & ") where Id=" & StoreId.Text.Trim())
    End Sub

    Private Sub GroupId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles GroupId.KeyUp
        If bm.ShowHelp("Groups", GroupId, GroupName, e, "select cast(Id as varchar(100)) Id,Name from Groups") Then
            GroupId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub btnSetImage_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSetImage.Click
        bm.SetImage(Image1)
    End Sub

    Private Sub btnSetNoImage_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSetNoImage.Click
        bm.SetNoImage(Image1, False, True)
    End Sub

    Private Sub SalesUnitCount_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles UnitCount.LostFocus
        Try
            If Val(UnitCount.Text) = 0 Then
                SalesPriceSub.Text = 0
            Else
                SalesPriceSub.Text = Val(SalesPrice.Text) / Val(UnitCount.Text)
            End If
        Catch ex As Exception
            SalesPriceSub.Text = 0
        End Try
        Try
            If Val(UnitCount.Text) = 0 Then
                WeightSub.Text = 0
            Else
                WeightSub.Text = Val(Weight.Text) / Val(UnitCount.Text)
            End If
        Catch ex As Exception
            WeightSub.Text = 0
        End Try
    End Sub

    Private Sub SalesUnitCount2_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles UnitCount2.LostFocus
        Try
            If Val(UnitCount2.Text) = 0 Then
                SalesPriceSub2.Text = 0
            Else
                SalesPriceSub2.Text = Val(SalesPrice.Text) / Val(UnitCount2.Text)
            End If
        Catch ex As Exception
            SalesPriceSub2.Text = 0
        End Try
    End Sub

    Private Sub PurchaseUnitCount_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles UnitCount.LostFocus
        Try
            If Val(UnitCount.Text) = 0 Then
                PurchasePriceSub.Text = 0
            Else
                PurchasePriceSub.Text = Val(PurchasePrice.Text) / Val(UnitCount.Text)
            End If
        Catch ex As Exception
            PurchasePriceSub.Text = 0
        End Try
    End Sub

    Private Sub PurchaseUnitCount2_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles UnitCount2.LostFocus
        Try
            If Val(UnitCount2.Text) = 0 Then
                PurchasePriceSub2.Text = 0
            Else
                PurchasePriceSub2.Text = Val(PurchasePrice.Text) / Val(UnitCount2.Text)
            End If
        Catch ex As Exception
            PurchasePriceSub2.Text = 0
        End Try
    End Sub

    Private Sub ItemType_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ItemType.SelectionChanged
        Select Case ItemType.SelectedIndex
            Case 0, 1
                IsDelivary.IsChecked = False
                IsTables.IsChecked = False
                IsTakeAway.IsChecked = False
            Case 2, 3
                IsDelivary.IsChecked = True
                IsTables.IsChecked = True
                IsTakeAway.IsChecked = True
        End Select
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

    Private Sub btnSave_Copy_Click(sender As Object, e As RoutedEventArgs) Handles btnSave_Copy.Click
        For i As Integer = 0 To G2.Rows.Count - 2
            G2.Rows(i).Cells(GC2.Price).Value += Val(PriceDiff.Text)
        Next
    End Sub

    Private Sub btnSave_Copy1_Click(sender As Object, e As RoutedEventArgs) Handles btnSave_Copy1.Click
        For i As Integer = 0 To G2.Rows.Count - 2
            G2.Rows(i).Cells(GC2.Price).Value -= Val(PriceDiff.Text)
        Next
    End Sub

    Private Sub btnSave_Copy2_Click(sender As Object, e As RoutedEventArgs) Handles btnSave_Copy2.Click
        For i As Integer = 0 To G2.Rows.Count - 2
            G2.Rows(i).Cells(GC2.PriceSub).Value += Val(PriceDiff.Text)
        Next
    End Sub

    Private Sub btnSave_Copy3_Click(sender As Object, e As RoutedEventArgs) Handles btnSave_Copy3.Click
        For i As Integer = 0 To G2.Rows.Count - 2
            G2.Rows(i).Cells(GC2.PriceSub).Value -= Val(PriceDiff.Text)
        Next
    End Sub
End Class
