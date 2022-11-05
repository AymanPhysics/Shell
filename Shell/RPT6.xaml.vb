Imports System.Data

Public Class RPT6
    Dim bm As New BasicMethods
    Public Flag As Integer = 0
    Public Detail As Integer = 0
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim rpt As New ReportViewer
        If ComboBox1.SelectedIndex < 0 Then ComboBox1.SelectedIndex = 0
        If Shift.SelectedIndex < 0 Then Shift.SelectedIndex = 0
        rpt.paraname = New String() {"@FromDate", "@ToDate", "@Shift", "@Flag", "@StoreId", "@FromInvoiceNo", "@ToInvoiceNo", "@NewItemsOnly", "@RPTFlag1", "@RPTFlag2", "@PrintingGroupId", "@CashierId", "@IsClosedOnly", "Header", "@ToId", "@GroupId", "GroupName", "@TypeId", "TypeName", "@ItemId", "@Barcode", "@AccNo", "@PaymentType", "@Mobile", "@CarNo", "@EmpId"}
        rpt.paravalue = New String() {FromDate.SelectedDate, ToDate.SelectedDate, Shift.SelectedValue.ToString, 0, Val(StoreId.Text), Val(FromInvoice.Text), Val(ToInvoice.Text), 0, Flag, ComboBox1.SelectedValue.ToString, 0, Val(CashierId.Text), IIf(IsClosedOnly.IsChecked, 1, 0), CType(Parent, Page).Title, Val(ToId.Text), Val(GroupId.Text), GroupName.Text, Val(TypeId.Text), TypeName.Text, Val(ItemId.Text), Barcode.Text, MainAccNo.Text.Trim, PaymentType.SelectedIndex, Mobile.Text, CarNo.Text.Trim, Val(EmpId.Text)}


        Select Case Detail
            Case 0
                rpt.Rpt = "Sales2.rpt"
            Case 1
                rpt.Rpt = "SalesBarcode.rpt"
            Case 2
                rpt.Rpt = "DeletedSales.rpt"
            Case 3
                rpt.Rpt = "CarSales.rpt"
            Case 4
                rpt.Rpt = "Sales3.rpt"
            Case 5
                rpt.Rpt = "SalesNotes.rpt"
            Case 6
                rpt.Rpt = "ItemSales.rpt"
            Case 7
                rpt.paravalue = New String() {FromDate.SelectedDate, ToDate.SelectedDate, Shift.SelectedValue.ToString, ComboBox1.SelectedValue.ToString, Val(StoreId.Text), Val(FromInvoice.Text), Val(ToInvoice.Text), 0, Flag, ComboBox1.SelectedValue.ToString, 0, Val(CashierId.Text), IIf(IsClosedOnly.IsChecked, 1, 0), CType(Parent, Page).Title, Val(ToId.Text), Val(GroupId.Text), GroupName.Text, Val(TypeId.Text), TypeName.Text, Val(ItemId.Text), Barcode.Text, MainAccNo.Text.Trim, PaymentType.SelectedIndex, Mobile.Text, CarNo.Text.Trim, Val(EmpId.Text)}

                rpt.Rpt = "ItemsSales3.rpt"
            Case 8
                rpt.paravalue = New String() {FromDate.SelectedDate, ToDate.SelectedDate, Shift.SelectedValue.ToString, ComboBox1.SelectedValue.ToString, Val(StoreId.Text), Val(FromInvoice.Text), Val(ToInvoice.Text), 0, Flag, ComboBox1.SelectedValue.ToString, 0, Val(CashierId.Text), IIf(IsClosedOnly.IsChecked, 1, 0), CType(Parent, Page).Title, Val(ToId.Text), Val(GroupId.Text), GroupName.Text, Val(TypeId.Text), TypeName.Text, Val(ItemId.Text), Barcode.Text, MainAccNo.Text.Trim, PaymentType.SelectedIndex, Mobile.Text, CarNo.Text.Trim, Val(EmpId.Text)}

                rpt.Rpt = "ItemsSales4.rpt"
            Case 9
                rpt.Rpt = "SalesMobile.rpt"
            Case 10
                rpt.Rpt = "Sales4.rpt"
            Case 11
                rpt.paravalue = New String() {FromDate.SelectedDate, ToDate.SelectedDate, Shift.SelectedValue.ToString, ComboBox1.SelectedValue.ToString, Val(StoreId.Text), Val(FromInvoice.Text), Val(ToInvoice.Text), 0, Flag, ComboBox1.SelectedValue.ToString, 0, Val(CashierId.Text), IIf(IsClosedOnly.IsChecked, 1, 0), CType(Parent, Page).Title, Val(ToId.Text), Val(GroupId.Text), GroupName.Text, Val(TypeId.Text), TypeName.Text, Val(ItemId.Text), Barcode.Text, MainAccNo.Text.Trim, PaymentType.SelectedIndex, Mobile.Text, CarNo.Text.Trim, Val(EmpId.Text)}

                rpt.Rpt = "ItemsSales41.rpt"
        End Select

        rpt.Show()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        bm.FillCombo("Shifts", Shift, "", , True)

        LoadCbo()
        Dim MyNow As DateTime = bm.MyGetDate()
        Shift.SelectedValue = 0
        FromDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        StoreId.Text = ""
        StoreId_LostFocus(Nothing, Nothing)


        lblBarcode.Visibility = Visibility.Hidden
        Barcode.Visibility = Visibility.Hidden
        If Flag = 0 OrElse Flag = 1 OrElse Flag = 2 OrElse Flag = 3 Then
            If Detail = 1 OrElse Detail = 6 Then
                lblBarcode.Visibility = Visibility.Visible
                Barcode.Visibility = Visibility.Visible
            End If
        End If

        lblMainAccNo.Visibility = Visibility.Hidden
        MainAccNo.Visibility = Visibility.Hidden
        MainAccName.Visibility = Visibility.Hidden
        If Flag = 0 Or Flag = 1 Or Flag = 2 Or Flag = 3 Or Flag = 4 Then
            If Detail = 1 OrElse Detail = 6 Then
                lblMainAccNo.Visibility = Visibility.Visible
                MainAccNo.Visibility = Visibility.Visible
                MainAccName.Visibility = Visibility.Visible
            End If
        End If

        If Flag <> 3 Then
            lblEmpId.Visibility = Visibility.Hidden
            EmpId.Visibility = Visibility.Hidden
            EmpName.Visibility = Visibility.Hidden
        End If


        If Detail = 6 Then
            ComboBox1.Visibility = Visibility.Hidden
            Label2.Visibility = Visibility.Hidden
        End If
    End Sub

    Private Sub StoreId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyUp
        If bm.ShowHelp("Stores", StoreId, StoreName, e, "select cast(Id as varchar(100)) Id,Name from Fn_EmpStores(" & Md.UserName & ")") Then
            StoreId_LostFocus(StoreId, Nothing)
        End If
    End Sub


    Private Sub StoreId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StoreId.LostFocus
        bm.LostFocus(StoreId, StoreName, "select Name from Fn_EmpStores(" & Md.UserName & ") where Id=" & StoreId.Text.Trim())
    End Sub

    Private Sub LoadCbo()
        Dim dt As New DataTable("tbl")
        dt.Columns.Add("Id")
        dt.Columns.Add("Name")
        dt.Rows.Add(New String() {0, "الكل"})
        Select Case Flag
            Case 1
                dt.Rows.Add(New String() {1, "أرصدة افتتاحية"})
                dt.Rows.Add(New String() {2, "إضافة"})
                dt.Rows.Add(New String() {3, "تسوية إضافة"})
                dt.Rows.Add(New String() {4, "صرف"})
                dt.Rows.Add(New String() {5, "تسوية صرف"})
                dt.Rows.Add(New String() {6, "هدايا"})
                dt.Rows.Add(New String() {7, "هالك"})
                dt.Rows.Add(New String() {8, "تحويل إلى مخزن"})

                lblCashier.Content = "المستلم"

                lblToId.Visibility = Visibility.Hidden
                ToId.Visibility = Visibility.Hidden
                ToName.Visibility = Visibility.Hidden
                lblToId.Content = "المخزن المحول إليه"

            Case 2
                dt.Rows.Add(New String() {9, "مشتريات"})
                dt.Rows.Add(New String() {10, "مردودات مشتريات"})
                dt.Rows.Add(New String() {17, "مشتريات من عميل"})

                lblCashier.Content = "البائع"

                lblToId.Visibility = Visibility.Visible
                ToId.Visibility = Visibility.Visible
                ToName.Visibility = Visibility.Visible
                lblToId.Content = "المورد"

            Case 3
                dt.Rows.Add(New String() {11, "مبيعات ضريبية"})
                dt.Rows.Add(New String() {12, "مردودات مبيعات ضريبية"})
                'dt.Rows.Add(New String() {13, "مبيعات التيك أواى"})
                'dt.Rows.Add(New String() {14, "مردودات مبيعات التيك أواى"})
                'dt.Rows.Add(New String() {15, "مبيعات التوصيل"})
                'dt.Rows.Add(New String() {16, "مردودات مبيعات التوصيل"})
                'IsClosedOnly.Visibility = Visibility.Visible
                dt.Rows.Add(New String() {13, "المبيعات"})
                dt.Rows.Add(New String() {14, "مردودات المبيعات"})
                dt.Rows.Add(New String() {18, "مبيعات لموردين"})

                lblCashier.Content = "البائع"

                lblToId.Visibility = Visibility.Visible
                ToId.Visibility = Visibility.Visible
                ToName.Visibility = Visibility.Visible
                lblToId.Content = "العميل"

            Case 4
                dt.Rows.Add(New String() {11, "مبيعات ضريبية"})
                'dt.Rows.Add(New String() {12, "مردودات مبيعات ضريبية"})
                dt.Rows.Add(New String() {13, "المبيعات"})
                'dt.Rows.Add(New String() {14, "مردودات المبيعات"})

                lblCashier.Content = "المستلم"

                lblToId.Visibility = Visibility.Visible
                ToId.Visibility = Visibility.Visible
                ToName.Visibility = Visibility.Visible
                lblToId.Content = "العميل"

            Case 5
                dt.Rows.Add(New String() {19, "سلفة"})
                dt.Rows.Add(New String() {20, "رد سلفة"})

                lblCashier.Content = "البائع"

                lblToId.Visibility = Visibility.Visible
                ToId.Visibility = Visibility.Visible
                ToName.Visibility = Visibility.Visible
                lblToId.Content = "الحساب الشخصى"

        End Select

        Dim dv As New DataView
        dv.Table = dt
        ComboBox1.ItemsSource = dv
        ComboBox1.SelectedValuePath = "Id"
        ComboBox1.DisplayMemberPath = "Name"
        ComboBox1.SelectedIndex = 0

        '----------------------PaymentType

        PaymentType.Items.Add("-")
        PaymentType.Items.Add("نقدى")
        PaymentType.Items.Add("فيزا")
        PaymentType.Items.Add("نقدى - فيزا")
        PaymentType.Items.Add("آجل")
        PaymentType.Items.Add("نقدى - آجل")
        PaymentType.SelectedIndex = 0
        PaymentType.Visibility = Visibility.Hidden
        lblPaymentType.Visibility = Visibility.Hidden
        If Flag = 2 Or Flag = 3 Then
            If Detail = 0 Or Detail = 1 Then
                PaymentType.Visibility = Visibility.Visible
                lblPaymentType.Visibility = Visibility.Visible
            End If
        End If

    End Sub

    Private Sub ComboBox1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ComboBox1.SelectionChanged
        If Flag = 1 Then
            If ComboBox1.SelectedValue = 8 Then
                lblToId.Visibility = Visibility.Visible
                ToId.Visibility = Visibility.Visible
                ToName.Visibility = Visibility.Visible
            Else
                lblToId.Visibility = Visibility.Hidden
                ToId.Visibility = Visibility.Hidden
                ToName.Visibility = Visibility.Hidden

                ToId.Clear()
                ToName.Clear()
            End If

        End If
    End Sub


    Private Sub ToId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ToId.KeyUp
        Dim Title, tbl As String
        If Flag = 1 Then
            tbl = "Stores"
            Title = "المخازن"
            bm.ShowHelp(Title, ToId, ToName, e, "select cast(Id as varchar(100)) Id,Name from " & tbl)
        ElseIf Flag = 2 Then
            tbl = "Suppliers"
            Title = "الموردين"
            bm.ShowHelp(Title, ToId, ToName, e, "select cast(Id as varchar(100)) Id,Name from " & tbl)
        ElseIf Flag = 3 OrElse Flag = 4 Then
            tbl = "Customers"
            Title = "العملاء"
            bm.ShowHelp(Title, ToId, ToName, e, "select cast(Id as varchar(100)) Id,Name from " & tbl)
        ElseIf Flag = 5 Then
            tbl = "PersonalAccounts"
            Title = "الحساب الشخصى"
            bm.ShowHelp(Title, ToId, ToName, e, "select cast(Id as varchar(100)) Id,Name from " & tbl)
        End If
    End Sub

    Private Sub ToId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ToId.LostFocus
        Dim tbl As String
        If Flag = 1 Then
            tbl = "Stores"
        ElseIf Flag = 2 Then
            tbl = "Suppliers"
        ElseIf Flag = 3 OrElse Flag = 4 Then
            tbl = "Customers"
        ElseIf Flag = 5 Then
            tbl = "PersonalAccounts"
        Else
            Return
        End If
        bm.LostFocus(ToId, ToName, "select Name from " & tbl & " where Id=" & ToId.Text.Trim())
    End Sub


    Private Sub CashierId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles CashierId.KeyUp
        bm.ShowHelp("Employees", CashierId, CashierName, e, "select cast(Id as varchar(100)) Id," & Resources.Item("CboName") & " Name from Employees where Doctor=0 and Stopped=0")
    End Sub

    Private Sub CashierId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CashierId.LostFocus
        bm.LostFocus(CashierId, CashierName, "select " & Resources.Item("CboName") & " Name from Employees where Doctor=0 and Id=" & CashierId.Text.Trim() & " and Stopped=0")
    End Sub

    Private Sub GroupId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles GroupId.LostFocus
        bm.LostFocus(GroupId, GroupName, "select Name from Groups where Id=" & GroupId.Text.Trim())
        TypeId_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub TypeId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TypeId.LostFocus
        bm.LostFocus(TypeId, TypeName, "select Name from Types where GroupId=" & GroupId.Text.Trim & " and Id=" & TypeId.Text.Trim())
    End Sub

    Private Sub GroupId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles GroupId.KeyUp
        If bm.ShowHelp("Groups", GroupId, GroupName, e, "select cast(Id as varchar(100)) Id,Name from Groups") Then
            GroupId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub TypeId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles TypeId.KeyUp
        bm.ShowHelp("Types", TypeId, TypeName, e, "select cast(Id as varchar(100)) Id,Name from Types where GroupId=" & GroupId.Text.Trim)
    End Sub


    Private Sub ItemId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ItemId.KeyUp
        If bm.ShowHelp("Items", ItemId, ItemName, e, "select cast(Id as varchar(100)) Id,Name from Items where (GroupId=" & Val(GroupId.Text) & " or " & Val(GroupId.Text) & "=0) and (TypeId=" & Val(TypeId.Text) & " or " & Val(TypeId.Text) & "=0)") Then
            ItemId_LostFocus(ItemId, Nothing)
        End If
    End Sub

    Private Sub ItemId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ItemId.LostFocus
        bm.LostFocus(ItemId, ItemName, "select Name from Items where Id=" & ItemId.Text.Trim() & " and (GroupId=" & Val(GroupId.Text) & " or " & Val(GroupId.Text) & "=0) and (TypeId=" & Val(TypeId.Text) & " or " & Val(TypeId.Text) & "=0)")
    End Sub

    Private Sub MainAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MainAccNo.LostFocus
        bm.AccNoLostFocus(MainAccNo, MainAccName, , )
        ToId_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub MainAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MainAccNo.KeyUp
        bm.AccNoShowHelp(MainAccNo, MainAccName, e, , )
    End Sub

    Private Sub EmpId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles EmpId.KeyUp
        bm.ShowHelp("Employees", EmpId, EmpName, e, "select cast(Id as varchar(100)) Id," & Resources.Item("CboName") & " Name from Employees where SystemUser=0 and Stopped=0")
    End Sub

    Private Sub EmpId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles EmpId.LostFocus
        bm.LostFocus(EmpId, EmpName, "select " & Resources.Item("CboName") & " Name from Employees where SystemUser=0 and Id=" & EmpId.Text.Trim() & " and Stopped=0")
    End Sub

End Class
