' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System.Text
Imports System.Windows.Media.Animation
Imports System.IO
Imports System.Windows.Threading
Imports System.Data

Partial Public Class MainPage
    Inherits Page
    Public NLevel As Boolean = False
    Dim m As MainWindow = Application.Current.MainWindow
    Dim bm As New BasicMethods
    WithEvents t As New DispatcherTimer With {.IsEnabled = True, .Interval = New TimeSpan(0, 0, 1)}


    Private sampleGridOpacityAnimation As DoubleAnimation
    Private sampleGridTranslateTransformAnimation As DoubleAnimation
    Private borderTranslateDoubleAnimation As DoubleAnimation

    Public Sub New()
        InitializeComponent()

        Dim widthBinding As New Binding("ActualWidth")
        widthBinding.Source = Me

        sampleGridOpacityAnimation = New DoubleAnimation()
        sampleGridOpacityAnimation.To = 0
        sampleGridOpacityAnimation.Duration = New Duration(TimeSpan.FromSeconds(0.15))

        sampleGridTranslateTransformAnimation = New DoubleAnimation()
        sampleGridTranslateTransformAnimation.BeginTime = TimeSpan.FromSeconds(0.15)
        sampleGridTranslateTransformAnimation.Duration = New Duration(TimeSpan.FromSeconds(0.15))

        borderTranslateDoubleAnimation = New DoubleAnimation()
        borderTranslateDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(0.3))
        borderTranslateDoubleAnimation.BeginTime = TimeSpan.FromSeconds(0)


    End Sub
    Private Shared _packUri As New Uri("pack://application:,,,/")

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        borderTranslateDoubleAnimation.From = 0
        borderTranslateDoubleAnimation.To = -ActualWidth
        SampleDisplayBorderTranslateTransform.BeginAnimation(TranslateTransform.XProperty, borderTranslateDoubleAnimation)
        GridSampleViewer_Loaded(Nothing, Nothing)
        Md.Currentpage = ""
    End Sub

    Private Sub selectedSampleChanged(ByVal sender As Object, ByVal args As RoutedEventArgs)

        If TypeOf args.Source Is RadioButton Then
            Dim theButton As RadioButton = CType(args.Source, RadioButton)
            Dim theFrame As Page = CType(theButton.Tag, Page)

            theButton.IsTabStop = False

            SampleDisplayFrame.Content = theButton.Tag
            SampleDisplayBorder.Visibility = Visibility.Visible

            CType(args.Source, RadioButton).IsChecked = False

            Try

                theFrame.Title = Resources.Item(CType(CType(args.Source, RadioButton).Content, TranslateTextAnimationExample).RealText.Tag)
                theFrame.Tag = CType(CType(args.Source, RadioButton).Content, TranslateTextAnimationExample).RealText.Tag


            Catch ex As Exception
            End Try
            sampleDisplayFrameLoaded(theFrame, args)

        End If

    End Sub

    Private Sub sampleDisplayFrameLoaded(ByVal sender As Object, ByVal args As EventArgs)
        Try
            If Not Resources.Item(CType(CType(sender, Frame).Content, Page).Tag) Is Nothing Then
                CType(CType(sender, Frame).Content, Page).Title = Resources.Item(CType(CType(sender, Frame).Content, Page).Tag)
                Md.Currentpage = CType(CType(sender, Frame).Content, Page).Title
            End If
        Catch ex As Exception
        End Try
        Try
            If Resources.Item(CType(sender, Page).Tag) Is Nothing Then
                CType(sender, Page).Title = CType(sender, Page).Tag
            Else
                CType(sender, Page).Title = Resources.Item(CType(sender, Page).Tag)
            End If
            Md.Currentpage = CType(sender, Page).Title
        Catch ex As Exception
        End Try

        sampleGridTranslateTransformAnimation.To = -ActualWidth
        borderTranslateDoubleAnimation.From = -ActualWidth
        borderTranslateDoubleAnimation.To = 0

        SampleDisplayBorder.Visibility = Visibility.Visible
        SampleGrid.BeginAnimation(Grid.OpacityProperty, sampleGridOpacityAnimation)
        SampleGridTranslateTransform.BeginAnimation(TranslateTransform.XProperty, sampleGridTranslateTransformAnimation)
        SampleDisplayBorderTranslateTransform.BeginAnimation(TranslateTransform.XProperty, borderTranslateDoubleAnimation)
    End Sub

    Private Sub galleryLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
        If bm.TestIsLoaded(Me, True) Then Return
        TAB.Margin = New Thickness(0)
        TAB.HorizontalAlignment = HorizontalAlignment.Stretch
        TAB.VerticalAlignment = VerticalAlignment.Stretch

        Load()

        SampleDisplayBorderTranslateTransform.X = -ActualWidth
        SampleDisplayBorder.Visibility = Visibility.Hidden
    End Sub

    Private Sub pageSizeChanged(ByVal sender As Object, ByVal args As SizeChangedEventArgs)
        SampleDisplayBorderTranslateTransform.X = Me.ActualWidth
    End Sub

    Dim DesignDt As New DataTable
    Sub LoadRadio(ByVal G As WrapPanel, ByVal frm As UserControl, ByVal Ttl As String)
        CurrentMenuitem += 1


        If Not Md.DictionaryEn.Item(Ttl) Is Nothing Then
            While Md.DictionaryEn.Item(Ttl).Length < 16
                Md.DictionaryEn.Item(Ttl) = " " & Md.DictionaryEn.Item(Ttl) & " "
            End While
        End If
        If Not Md.DictionaryAr.Item(Ttl) Is Nothing Then
            While Md.DictionaryAr.Item(Ttl).Length < 16
                Md.DictionaryAr.Item(Ttl) = " " & Md.DictionaryAr.Item(Ttl) & " "
            End While
        End If


        Dim RName As String = "menuitem" & CurrentMenuitem
        Dim r As New RadioButton With {.Name = RName, .Style = Application.Current.FindResource("GlassRadioButtonStyle")}
        Dim AnimatingAlongAPathExampleFrame As New Page
        AnimatingAlongAPathExampleFrame.Content = frm
        r.Tag = AnimatingAlongAPathExampleFrame

        Dim t As New UserControl

        t = New TranslateTextAnimationExample
        CType(t, TranslateTextAnimationExample).RealText.SetResourceReference(TextBlock.TextProperty, Ttl)
        CType(t, TranslateTextAnimationExample).RealText.Tag = Ttl
        r.SetResourceReference(RadioButton.BackgroundProperty, "SC")
        t.SetResourceReference(RadioButton.BackgroundProperty, "SC")


        G.Children.Add(r)

        r.Width = 150
        r.Height = 100
        r.SetResourceReference(RadioButton.ToolTipProperty, Ttl)
        r.Content = t

        If Md.DictionaryAr.Item(Ttl) Is Nothing Then
            CType(t, TranslateTextAnimationExample).RealText.Text = Ttl
            r.ToolTip = Ttl
        End If
    End Sub

    Private Sub LoadRadio(ByVal frm As TabItem, ByVal Ttl As String)
        Dim r As New RadioButton With {.Style = Application.Current.FindResource("GlassRadioButtonStyle")}
        Dim AnimatingAlongAPathExampleFrame As New Frame
        AnimatingAlongAPathExampleFrame.Source = New Uri(frm.GetType().ToString.Split(".").Last & ".Xaml", UriKind.RelativeOrAbsolute)
        AnimatingAlongAPathExampleFrame.Background = System.Windows.Media.Brushes.White
        AnimatingAlongAPathExampleFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden
        r.Content = AnimatingAlongAPathExampleFrame
        'SampleGrid.Children.Add(r)
        r.Width = 100
        r.Height = 60
        r.ToolTip = Ttl
    End Sub


    Private Sub GridSampleViewer_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        bm.TestIsLoaded(Me, False)
    End Sub

    Private Sub ResizeHeader(G As WrapPanel)
        If Lvl Then Return
        Dim Ttl As String = CType(CType(G.Parent, ScrollViewer).Parent, TabItem).Header
        While Md.DictionaryEn.Item(Ttl).Length < 16
            Md.DictionaryEn.Item(Ttl) = " " & Md.DictionaryEn.Item(Ttl) & " "
        End While
        While Md.DictionaryAr.Item(Ttl).Length < 16
            Md.DictionaryAr.Item(Ttl) = " " & Md.DictionaryAr.Item(Ttl) & " "
        End While

    End Sub


    Public Lvl As Boolean = False
    Dim CurrentTab As Integer = 0
    Dim CurrentMenuitem As Integer = 0
    Public Sub Load()

        DesignDt = bm.ExecuteAdapter("select * from PLevels where id='" & Md.UserName & "'")

        If Md.MyProject = Client.PCs Then
            LoadGPCs()
            Return
        End If

        LoadTabs()

        If Not Lvl Then
            Dim dt As DataTable = bm.ExecuteAdapter("select * from nlevels where id=" & Md.LevelId)
            If dt.Rows.Count = 0 Then Return

            For i As Integer = 0 To TAB.Items.Count - 1
                Dim item As TabItem = CType(TAB.Items(i), TabItem)

                If dt.Rows(0)(CType(TAB.Items(i), TabItem).Name).ToString = "" Then
                    item.Visibility = Visibility.Collapsed
                Else
                    item.Visibility = IIf(dt.Rows(0)(item.Name), Visibility.Visible, Visibility.Collapsed)
                End If
                item.Content.Visibility = item.Visibility

                For x As Integer = 0 To CType(CType(item.Content, ScrollViewer).Content, WrapPanel).Children.Count - 1
                    If CType(CType(item.Content, ScrollViewer).Content, WrapPanel).Children(x).GetType = GetType(RadioButton) Then
                        Dim t As RadioButton = CType(CType(CType(item.Content, ScrollViewer).Content, WrapPanel).Children(x), RadioButton)
                        If dt.Rows(0)(t.Name).ToString = "" Then
                            t.Visibility = Visibility.Collapsed
                        Else
                            t.Visibility = IIf(dt.Rows(0)(t.Name), Visibility.Visible, Visibility.Collapsed)
                        End If
                    End If
                Next
            Next

            For i As Integer = 0 To TAB.Items.Count - 1
                If CType(TAB.Items(i), TabItem).Visibility = Visibility.Visible Then
                    CType(TAB.Items(i), TabItem).IsSelected = True
                    Exit For
                End If
            Next

        End If

    End Sub

    Function MakePanel(MyHeader As String, ImagePath As String) As WrapPanel
        CurrentTab += 1
        Dim SV As New MyScrollViewer
        bm.SetImage(SV.Img, ImagePath)
        Dim t As New TabItem With {.Content = SV, .Name = "tab" & CurrentTab, .Header = MyHeader}
        TAB.Items.Add(t)
        Dim G As WrapPanel = SV.MyWrapPanel
        G.AddHandler(System.Windows.Controls.Primitives.ToggleButton.CheckedEvent, New System.Windows.RoutedEventHandler(AddressOf Me.selectedSampleChanged))
        ResizeHeader(G)
        t.SetResourceReference(TabItem.HeaderProperty, t.Header)
        Return G
    End Function

    Private Sub LoadGPCs()
        Dim G As WrapPanel = MakePanel("File", "Omega.jpg")

        Dim frm As New BasicForm With {.TableName = "PCs"}
        bm.SetImage(CType(frm, BasicForm).Img, "password.jpg")
        frm.txtName.MaxLength = 1000
        m.TabControl1.Items.Clear()
        LoadRadio(G, frm, "PCs")

    End Sub

    Private Sub LoadGFile()
        Dim s As String = "buttonscreen.jpg"
        s = "buttonscreen3.jpg"

        Dim G As WrapPanel = MakePanel("File", s)
        Dim frm As UserControl

        LoadRadio(G, New Employees, "Employees")


        frm = New BasicForm With {.TableName = "Countries"}
        bm.SetImage(CType(frm, BasicForm).Img, "CustomerInvoicesItems.Jpg")
        LoadRadio(G, frm, "Countries")

        frm = New BasicForm2 With {.MainTableName = "Countries", .MainSubId = "Id", .MainSubName = "Name", .lblMain_Content = "Country", .TableName = "Cities", .MainId = "CountryId", .SubId = "Id", .SubName = "Name"}
        bm.SetImage(CType(frm, BasicForm2).Img, "CustomerInvoicesItems.Jpg")
        LoadRadio(G, frm, "Cities")


        frm = New BasicForm3 With {.MainTableName = "Countries", .MainSubId = "Id", .MainSubName = "Name", .lblMain_Content = "Country", .Main2TableName = "Cities", .Main2MainId = "CountryId", .Main2SubId = "Id", .Main2SubName = "Name", .lblMain2_Content = "City", .TableName = "Areas", .MainId = "CountryId", .MainId2 = "CityId", .SubId = "Id", .SubName = "Name"}
        LoadRadio(G, frm, "Areas")


        frm = New BasicForm With {.TableName = "MainJobs"}
        LoadRadio(G, frm, "MainJobs")

        frm = New BasicForm2 With {.MainTableName = "MainJobs", .MainSubId = "Id", .MainSubName = "Name", .lblMain_Content = "MainJob", .TableName = "SubJobs", .MainId = "MainJobId", .SubId = "Id", .SubName = "Name"}
        LoadRadio(G, frm, "SubJobs")

        frm = New BasicForm With {.TableName = "Departments"}
        bm.SetImage(CType(frm, BasicForm).Img, "CustomerInvoicesItems.Jpg")
        LoadRadio(G, frm, "Departments")

        frm = New BasicForm With {.TableName = "AttachmentTypes"}
        bm.SetImage(CType(frm, BasicForm).Img, "CustomerInvoicesItems.Jpg")
        LoadRadio(G, frm, "Attachment Types")


        frm = New BasicForm With {.TableName = "Shifts"}
        bm.SetImage(CType(frm, BasicForm).Img, "CustomerInvoicesItems.Jpg")
        LoadRadio(G, frm, "Shifts")

    End Sub


    Private Sub LoadGSalaries()
        Dim G As WrapPanel = MakePanel("Salaries", "IMG46.jpg")
        Dim frm As UserControl

        frm = New OfficialHolidays
        LoadRadio(G, frm, "OfficialHolidays")

        frm = New CalcSalary With {.Flag = 4}
        LoadRadio(G, frm, "Import Attendance")

        frm = New EditAttendance2
        LoadRadio(G, frm, "Add Attendance")

        frm = New EditAttendance
        LoadRadio(G, frm, "Edit Attendance")

        frm = New Loans With {.TableName = "Loans"}
        LoadRadio(G, frm, "Loans")

        frm = New DirectBonusCut With {.TableName = "DirectBonus"}
        LoadRadio(G, frm, "DirectBonus")

        frm = New DirectBonusCut With {.TableName = "DirectCut"}
        LoadRadio(G, frm, "DirectCut")

        frm = New LeaveRequests With {.TableName = "LeaveRequests"}
        LoadRadio(G, frm, "LeaveRequests")

        frm = New LeaveRequests2 With {.TableName = "LeaveRequests2"}
        LoadRadio(G, frm, "LeaveRequests2")

        frm = New CalcSalary With {.Flag = 1}
        LoadRadio(G, frm, "Calc Salary")

    End Sub


    Private Sub LoadGAccountants()
        Dim s As String = "buttonscreen4.jpg"


        Dim G As WrapPanel = MakePanel("Accounts", s)
        Dim frm As UserControl

        frm = New Chart
        LoadRadio(G, frm, "Chart")

        If Md.ShowCostCenter Then
            frm = New CostCenters
            LoadRadio(G, frm, "CostCenters")
        End If

        frm = New Customers 'Suppliers With {.TableName = "Customers"}
        LoadRadio(G, frm, "Customers")


        frm = New Suppliers
        LoadRadio(G, frm, "Suppliers")


        frm = New CreditsDebits With {.TableName = "Debits", .LinkFile = 3}
        LoadRadio(G, frm, "Debits")

        frm = New CreditsDebits With {.TableName = "Credits", .LinkFile = 4}
        LoadRadio(G, frm, "Credits")

        frm = New CreditsDebits With {.TableName = "Saves", .LinkFile = 5}
        LoadRadio(G, frm, "Saves")

        frm = New CreditsDebits With {.TableName = "Banks", .LinkFile = 6}
        LoadRadio(G, frm, "Banks")


        frm = New Entry
        LoadRadio(G, frm, "Entry")

        frm = New BankCash With {.Flag = 1, .LinkFile = 5}
        LoadRadio(G, frm, "Safe Income")

        frm = New BankCash With {.Flag = 2, .LinkFile = 5}
        LoadRadio(G, frm, "Safe Outcome")

        frm = New BankCash With {.Flag = 3, .LinkFile = 6}
        LoadRadio(G, frm, "Bank Income")

        frm = New BankCash With {.Flag = 4, .LinkFile = 6}
        LoadRadio(G, frm, "Bank Outcome")

        frm = New DeficitAndIncrease
        LoadRadio(G, frm, "DeficitAndIncrease")

    End Sub

    Private Sub LoadGStores()
        Dim s As String = "Store.jpg"

        Dim G As WrapPanel = MakePanel("Stores", s)
        Dim frm As UserControl

        'frm = New BasicForm With {.TableName = "Groups"}
        frm = New Groups With {.WithImage = True}
        LoadRadio(G, frm, "Groups")

        frm = New BasicForm2 With {.MainTableName = "Groups", .MainSubId = "Id", .MainSubName = "Name", .lblMain_Content = "Group", .TableName = "Types", .MainId = "GroupId", .SubId = "Id", .SubName = "Name", .WithImage = True}
        LoadRadio(G, frm, "Types")


        frm = New Items
        LoadRadio(G, frm, "Items")

        frm = New ItemsUpdate
        LoadRadio(G, frm, "ItemsUpdate")

        If Md.MyProject = Client.El7ariry Then
            frm = New Prices With {.Flag = 1}
            LoadRadio(G, frm, "CustomerPrices")
        End If

        frm = New RPT18 With {.Flag = 1}
        LoadRadio(G, frm, "Print Barcode")

        frm = New RPT18 With {.Flag = 2}
        LoadRadio(G, frm, "Print Items")

        frm = New Stores
        'frm = New BasicForm With {.TableName = "Stores", .Flag = 2}
        LoadRadio(G, frm, "Stores")

        frm = New BasicForm With {.TableName = "PersonalAccounts"}
        LoadRadio(G, frm, "Personal Accounts")

        LoadRadio(G)

        frm = New Sales With {.Flag = Sales.FlagState.أرصدة_افتتاحية}
        LoadRadio(G, frm, "Starting balances")

        frm = New Sales With {.Flag = Sales.FlagState.إضافة}
        LoadRadio(G, frm, "Adding")

        frm = New Sales With {.Flag = Sales.FlagState.تسوية_إضافة}
        LoadRadio(G, frm, "AddingAdjustment")

        frm = New Sales With {.Flag = Sales.FlagState.صرف}
        LoadRadio(G, frm, "Exchange")

        frm = New Sales With {.Flag = Sales.FlagState.تسوية_صرف}
        LoadRadio(G, frm, "ExchangeAdjustment")

        frm = New Sales With {.Flag = Sales.FlagState.هدايا}
        LoadRadio(G, frm, "Gifts")

        frm = New Sales With {.Flag = Sales.FlagState.هالك}
        LoadRadio(G, frm, "Loses")

        frm = New Sales With {.Flag = Sales.FlagState.تحويل_إلى_مخزن}
        LoadRadio(G, frm, "Transfer to a Store")

        LoadRadio(G)

        frm = New Sales With {.Flag = Sales.FlagState.مشتريات}
        LoadRadio(G, frm, "Purchases")

        frm = New Sales With {.Flag = Sales.FlagState.مردودات_مشتريات}
        LoadRadio(G, frm, "Purchase Returns")

        frm = New Sales With {.Flag = Sales.FlagState.مبيعات_لموردين}
        LoadRadio(G, frm, "Suppliers Sales")

        frm = New SalesLoan With {.Flag = SalesLoan.FlagState.سلفة}
        LoadRadio(G, frm, "Loan")

        frm = New SalesLoan With {.Flag = SalesLoan.FlagState.رد_سلفة}
        LoadRadio(G, frm, "Loan Return")

        LoadRadio(G)

        frm = New Sales With {.Flag = Sales.FlagState.المبيعات}
        LoadRadio(G, frm, "Sales")

        frm = New Sales With {.Flag = Sales.FlagState.مردودات_المبيعات}
        LoadRadio(G, frm, "Sales Returns")

        If Md.MyProject = Client.El7ariry Then

            frm = New Sales With {.Flag = Sales.FlagState.مبيعات_ضريبية}
            LoadRadio(G, frm, "Sales Tax")

            frm = New Sales With {.Flag = Sales.FlagState.مردودات_مبيعات_ضريبية}
            LoadRadio(G, frm, "Sales Tax Returns")

        End If


        frm = New Sales With {.Flag = Sales.FlagState.مشتريات_من_عملاء}
        LoadRadio(G, frm, "Customers Purchases")

        If Md.MyProject <> Client.El7ariry Then
            frm = New Sales With {.Flag = Sales.FlagState.مبيعات_الوردية}
            LoadRadio(G, frm, "Fuels Sales")
        End If

        'LoadRadio(G)

        frm = New Inventory
        LoadRadio(G, frm, "Inventory")

        If Md.MyProject = Client.AutoMarket Then
            frm = New Inventory2
            LoadRadio(G, frm, "Inventory2")
        End If

        LoadRadio(G)

        If Md.MyProject = Client.MisrPetrol Then
            frm = New ShiftNotes
            LoadRadio(G, frm, "ShiftNotes")
        End If

    End Sub

    Private Sub LoadGStoresPetroleum()
        Dim s As String = "IMG40.Jpg"

        Dim G As WrapPanel = MakePanel("Stores Petroleum", s)
        Dim frm As UserControl

        frm = New ItemsPetroleum
        LoadRadio(G, frm, "ItemsPetroleum")

        If Md.MyProject = Client.AutoMarket Then
            frm = New TankTypes
            LoadRadio(G, frm, "TankTypes")
        End If

        frm = New Tanks
        LoadRadio(G, frm, "Tanks")

        frm = New Pumps
        LoadRadio(G, frm, "Pumps")

        frm = New PumpsInventory
        LoadRadio(G, frm, "PumpsInventory")

        If Md.MyProject = Client.AutoMarket Then
            frm = New TanksInventory2
        Else
            frm = New TanksInventory
        End If
        LoadRadio(G, frm, "TanksInventory")

        frm = New Liquidation
        LoadRadio(G, frm, "Liquidation")

    End Sub

    Private Sub LoadGSecurity()
        Dim s As String = "IMG40.Jpg"

        Dim G As WrapPanel = MakePanel("Options", s)
        Dim frm As UserControl

        frm = New ChangePassword
        LoadRadio(G, frm, "Change Password")

        frm = New Levels
        LoadRadio(G, frm, "Levels")

        frm = New Attachments
        LoadRadio(G, frm, "Attachement")

        'frm = New PhoneIndex
        'LoadRadio(G, frm, "Contacts")

        frm = New CalcSalary With {.Flag = 6}
        LoadRadio(G, frm, "Close Shift")

        frm = New CalcSalary With {.Flag = 7}
        LoadRadio(G, frm, "Open New Year")

        frm = New CalcSalary With {.Flag = 9}
        LoadRadio(G, frm, "Start New Year")

        'frm = New CalcSalary With {.Flag = 8}
        'LoadRadio(G, frm, "Calc Avg Cost")

        frm = New Statics
        LoadRadio(G, frm, "Statics")


    End Sub

    Private Sub LoadGAccountsReports()
        Dim s As String = "buttonscreen4.jpg"

        Dim G As WrapPanel = MakePanel("Accounts Reports", s)
        Dim frm As UserControl


        frm = New RPT2 With {.Flag = 1}
        LoadRadio(G, frm, "Account Motion")

        frm = New RPT2 With {.Flag = 1, .MyLinkFile = 1}
        LoadRadio(G, frm, "Customer Account Motion")


        frm = New RPT2 With {.Flag = 1, .MyLinkFile = 2}
        LoadRadio(G, frm, "Supplier Account Motion")

        frm = New RPT2 With {.Flag = 1, .MyLinkFile = 3}
        LoadRadio(G, frm, "Debit Account Motion")

        frm = New RPT2 With {.Flag = 1, .MyLinkFile = 4}
        LoadRadio(G, frm, "Credit Account Motion")

        frm = New RPT2 With {.Flag = 1, .MyLinkFile = 5}
        LoadRadio(G, frm, "Save Account Motion")

        frm = New RPT2 With {.Flag = 1, .MyLinkFile = 6}
        LoadRadio(G, frm, "Bank Account Motion")

        LoadRadio(G)

        frm = New RPT4 With {.Flag = 1, .LinkFile = 5}
        LoadRadio(G, frm, "Safe Income View")

        frm = New RPT4 With {.Flag = 2, .LinkFile = 5}
        LoadRadio(G, frm, "Safe Outcome View")

        frm = New RPT4 With {.Flag = 3, .LinkFile = 6}
        LoadRadio(G, frm, "Bank Income View")

        frm = New RPT4 With {.Flag = 4, .LinkFile = 6}
        LoadRadio(G, frm, "Bank Outcome View")

        frm = New RPT2 With {.Flag = 2, .MyLinkFile = 5}
        LoadRadio(G, frm, "Save Daily Motion")

        LoadRadio(G)

        frm = New RPT11 With {.Flag = 1, .MyLinkFile = 1}
        LoadRadio(G, frm, "Customers Balances")

        frm = New RPT11 With {.Flag = 1, .MyLinkFile = 2}
        LoadRadio(G, frm, "Suppliers Balances")

        frm = New RPT11 With {.Flag = 1, .MyLinkFile = 3}
        LoadRadio(G, frm, "Debits Balances")

        frm = New RPT11 With {.Flag = 1, .MyLinkFile = 4}
        LoadRadio(G, frm, "Credits Balances")

        frm = New RPT11 With {.Flag = 1, .MyLinkFile = 5}
        LoadRadio(G, frm, "Saves Balances")

        frm = New RPT11 With {.Flag = 1, .MyLinkFile = 6}
        LoadRadio(G, frm, "Banks Balances")

        LoadRadio(G)

        frm = New RPT2 With {.Flag = 3, .MyLinkFile = 1}
        LoadRadio(G, frm, "Customers Assistant")
        
        frm = New RPT2 With {.Flag = 3, .MyLinkFile = 2}
        LoadRadio(G, frm, "Suppliers Assistant")

        frm = New RPT2 With {.Flag = 3, .MyLinkFile = 3}
        LoadRadio(G, frm, "Debits Assistant")

        frm = New RPT2 With {.Flag = 3, .MyLinkFile = 4}
        LoadRadio(G, frm, "Credits Assistant")

        frm = New RPT2 With {.Flag = 3, .MyLinkFile = 5}
        LoadRadio(G, frm, "Saves Assistant")

        frm = New RPT2 With {.Flag = 3, .MyLinkFile = 6}
        LoadRadio(G, frm, "Banks Assistant")

        LoadRadio(G)


        frm = New RPT25 With {.Flag = 8}
        LoadRadio(G, frm, "Calc Store Cost")

        frm = New RPT20 With {.Flag = 1}
        LoadRadio(G, frm, "Account Balance")

        frm = New RPT27 With {.Flag = 1, .MyEndType = 0}
        LoadRadio(G, frm, "Operating")

        frm = New RPT27 With {.Flag = 1, .MyEndType = 1}
        LoadRadio(G, frm, "Trading")

        frm = New RPT27 With {.Flag = 1, .MyEndType = 2}
        LoadRadio(G, frm, "Gains and losses")

        frm = New RPT27 With {.Flag = 1, .MyEndType = 3}
        LoadRadio(G, frm, "Balance Sheet")

        frm = New RPT27 With {.Flag = 2, .MyEndType = 2, .IsIncomeStatement = 1}
        LoadRadio(G, frm, "Income Statement")

        frm = New RPT27 With {.Flag = 3, .MyEndType = 3}
        LoadRadio(G, frm, "Financial Position")


        frm = New RPT7 With {.Flag = 2}
        LoadRadio(G, frm, "DeficitAndIncrease")

        frm = New RPT7 With {.Flag = 3}
        LoadRadio(G, frm, "DeficitAndIncreaseComparison")


    End Sub


    Private Sub LoadGSalaryReports()
        Dim G As WrapPanel = MakePanel("Salary Reports", "IMG46.Jpg")
        Dim frm As UserControl

        frm = New RPT9 With {.Flag = 1}
        LoadRadio(G, frm, "Salary Detailed")

        frm = New RPT9 With {.Flag = 2}
        LoadRadio(G, frm, "Salary Total")

        frm = New RPT9 With {.Flag = 3}
        LoadRadio(G, frm, "Attendance")

        frm = New RPT25 With {.Flag = 1}
        LoadRadio(G, frm, "Loans")

        frm = New RPT25 With {.Flag = 6}
        LoadRadio(G, frm, "Loans Status")

    End Sub

    Private Sub LoadGOperationsReports()
        Dim G As WrapPanel = MakePanel("Operations Reports", "Build1.jpg")
        Dim frm As UserControl

        frm = New RPT14 With {.Flag = 1}
        LoadRadio(G, frm, "CostCenterOutCome")

        frm = New RPT14 With {.Flag = 2}
        LoadRadio(G, frm, "CostCenterOutComeToTal")

        frm = New RPT15 With {.Flag = 1}
        LoadRadio(G, frm, "BuildingIncome")

    End Sub

    Private Sub LoadGStoresReports()
        Dim s As String = "Store.jpg"

        Dim G As WrapPanel = MakePanel("Stores Reports", s)
        Dim G1 As WrapPanel = G
        Dim G2 As WrapPanel = G
        If Md.MyProject = Client.Shady Then
            G1 = MakePanel("Purchase Reports", s)
            G2 = MakePanel("Sales Reports", s)
        End If
        Dim frm As UserControl

        frm = New RPT13 With {.Flag = 1}
        LoadRadio(G, frm, "Items Printing")

        frm = New RPT13 With {.Flag = 2}
        LoadRadio(G, frm, "Items Printing With Images")

        frm = New RPT13 With {.Flag = 3}
        LoadRadio(G, frm, "Items Price")

        LoadRadio(G)

        frm = New RPT6 With {.Flag = 1, .Detail = 1}
        LoadRadio(G, frm, "Stores Motions Detailed")

        frm = New RPT6 With {.Flag = 1, .Detail = 0}
        LoadRadio(G, frm, "Stores Motions Total")

        frm = New RPT6 With {.Flag = 2, .Detail = 1}
        LoadRadio(G1, frm, "Purchase Invoices Detailed")

        frm = New RPT6 With {.Flag = 2, .Detail = 0}
        LoadRadio(G1, frm, "Purchase Invoices Total")

        frm = New RPT6 With {.Flag = 2, .Detail = 5}
        LoadRadio(G1, frm, "Purchase Notes")

        frm = New RPT6 With {.Flag = 3, .Detail = 1}
        LoadRadio(G2, frm, "Sales Invoices Detailed")

        frm = New RPT6 With {.Flag = 3, .Detail = 0}
        LoadRadio(G2, frm, "Sales Invoices Total")

        frm = New RPT6 With {.Flag = 5, .Detail = 1}
        LoadRadio(G1, frm, "Loans Detailed")

        frm = New RPT31 With {.Flag = 1}
        LoadRadio(G1, frm, "Loans Status")


        'frm = New RPT6 With {.Flag = 5, .Detail = 0}
        'LoadRadio(G, frm, "Loans Total")

        LoadRadio(G)

        frm = New RPT6 With {.Flag = 3, .Detail = 9}
        LoadRadio(G2, frm, "Sales Mobile")

        frm = New RPT31 With {.Flag = 2}
        LoadRadio(G2, frm, "تليفونات العملاء مختصر")

        frm = New RPT6 With {.Flag = 3, .Detail = 5}
        LoadRadio(G2, frm, "Sales Notes")

        frm = New RPT6 With {.Flag = 4, .Detail = 3}
        LoadRadio(G2, frm, "Car Withdrawals")

        frm = New RPT12 With {.Flag = 1}
        LoadRadio(G, frm, "ItemCard")

        frm = New RPT121 With {.Flag = 1}
        LoadRadio(G, frm, "ItemMovement")

        frm = New RPT12 With {.Flag = 2}
        LoadRadio(G, frm, "Items Balance In Store")

        frm = New RPT12 With {.Flag = 3}
        LoadRadio(G, frm, "Items Balance In All Stores")

        frm = New RPT12 With {.Flag = 4}
        LoadRadio(G, frm, "Items exceeded limit demand")


        frm = New RPT6 With {.Flag = 3, .Detail = 8}
        LoadRadio(G2, frm, "Sales Profit")

        If Md.MyProject = Client.Shady Then
            frm = New RPT6 With {.Flag = 3, .Detail = 11}
            LoadRadio(G2, frm, "Daily Sales Profit")
        End If

        frm = New RPT121 With {.Flag = 2}
        LoadRadio(G, frm, "Inventory")

        LoadRadio(G)

        frm = New RPT12 With {.Flag = 5}
        LoadRadio(G, frm, "Store Balance with Cost")

        frm = New RPT12 With {.Flag = 6}
        LoadRadio(G, frm, "All Stores Balance with Cost")

        frm = New RPT12 With {.Flag = 8}
        LoadRadio(G, frm, "Store Balance with Price")

        frm = New RPT12 With {.Flag = 9}
        LoadRadio(G, frm, "All Stores Balance with Price")

        frm = New RPT3 With {.Flag = 1}
        LoadRadio(G, frm, "Target Comparison")

        frm = New RPT6 With {.Flag = 2, .Detail = 10}
        LoadRadio(G1, frm, "Daily Purchase")

        frm = New RPT6 With {.Flag = 3, .Detail = 10}
        LoadRadio(G2, frm, "Daily Sales")

        frm = New RPT6 With {.Flag = 0, .Detail = 6}
        LoadRadio(G, frm, "Items Motion")

        frm = New RPT6 With {.Flag = 3, .Detail = 6}
        LoadRadio(G2, frm, "Items Sales")

        frm = New RPT6 With {.Flag = 4, .Detail = 7}
        LoadRadio(G2, frm, "Sales Bonus")

        frm = New RPT180 With {.Flag = 1}
        LoadRadio(G2, frm, "Print Text")

    End Sub

    Private Sub LoadGStoresPetroleumReports()
        Dim s As String = "Store.jpg"

        Dim G As WrapPanel = MakePanel("Stores Petroleum Reports", s)
        Dim frm As UserControl

        If Md.MyProject = Client.Shady Then
            frm = New RPT28 With {.Flag = 1}
            LoadRadio(G, frm, "Stores Petroleum Total")

            frm = New RPT28 With {.Flag = 2}
            LoadRadio(G, frm, "Stores Petroleum Daily")

            frm = New RPT28 With {.Flag = 3}
            LoadRadio(G, frm, "Stores Petroleum Shifts")
        End If

        If Md.MyProject = Client.AutoMarket Then
            frm = New RPT28 With {.Flag = 4}
            LoadRadio(G, frm, "ItemCard")

            frm = New RPT28 With {.Flag = 5}
            LoadRadio(G, frm, "Purchases")

            frm = New RPT28 With {.Flag = 6}
            LoadRadio(G, frm, "Sales")

            frm = New RPT28 With {.Flag = 7}
            LoadRadio(G, frm, "PumpOutput")
        End If
    End Sub

    Sub LoadRadio(ByVal G As WrapPanel)
        Dim r As New Label
        G.Children.Add(r)
        'r.Background = System.Windows.Media.Brushes.Silver
        r.Width = ActualWidth
        r.Height = 4
    End Sub
    Private Sub LoadTabs()

        LoadGFile()
        LoadGStores()

        If Md.MyProject = Client.Shady OrElse Md.MyProject = Client.AutoMarket Then
            LoadGStoresPetroleum()
        End If
        LoadGSalaries()
        LoadGAccountants()

        LoadGSecurity()

        LoadGStoresReports()

        If Md.MyProject = Client.Shady OrElse Md.MyProject = Client.AutoMarket Then
            LoadGStoresPetroleumReports()
        End If
        LoadGSalaryReports()
        LoadGAccountsReports()

    End Sub

    Private Sub PrintTbl(ByVal Header As String, ByVal tbl As String, Optional ByVal maintbl As String = "", Optional ByVal mainfield As String = "")
        Dim frm As New ReportViewer
        frm.Rpt = IIf(maintbl = "", "PrintTbl.rpt", "PrintTbl2.rpt")
        frm.paraname = {"Header", "@tbl", "@maintbl", "@mainfield"}
        frm.paravalue = {Header, tbl, maintbl, mainfield}
        frm.Show()
    End Sub


End Class

