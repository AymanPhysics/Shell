Imports System.Drawing
Imports System.Data
Imports System.IO
Imports System.Windows.Controls.Primitives

Class MainWindow
    Dim bm As New BasicMethods
    Public Nlvl As Boolean = False
    Dim bol As Boolean = False
    Dim Copy As Boolean = False
    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If Nlvl Or bol Then Return
        If Copy = True Then
            bol = True
            Application.Current.Shutdown()
            Exit Sub
        End If
        bm.ClearTemp()
        If bm.ShowDeleteMSG("MsgExit") Then
            bol = True
            Md.FourceExit = True
            Application.Current.Shutdown()
        Else
            e.Cancel = True
            Me.BringIntoView()
        End If
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        Md.ShowCostCenter = False

        Select Case Md.MyProject
            Case Client.El7ariry
                Md.ShowCostCenter = True
        End Select

        Select Case Md.MyProject
            Case Client.El7ariry
            Case Else
                WindowStyle = WindowStyle.ThreeDBorderWindow
        End Select
        Select Case Md.MyProject
            Case Client.El7ariry, Client.AutoMarket, Client.MisrPetrol
                Md.ShowShiftForEveryStore = True
        End Select


        If Not LoadConnection() Then Return
        LoadBarcodePrinter()
        LoadPonePrinter()

        If Not Md.MyProject = Client.PCs Then bm.TestProtection()
        Dim v As Integer = Val(bm.ExecuteScalar("select LastVersion from LastVersion"))
        If v > Md.LastVersion Or v = 0 Then
            bm.ShowMSG("MsgLastVersion")
            Application.Current.Shutdown()
        End If

        If Md.LastVersion > v Then
            bm.ExecuteNonQuery("delete from LastVersion insert into LastVersion (LastVersion) select " & Md.LastVersion)
        End If

        bm.ClearTemp()
        Md.CompanyName = bm.ExecuteScalar("select CompanyName from Statics")
        Md.CompanyTel = bm.ExecuteScalar("select CompanyTel from Statics")
        Dim L As New Login

        bm.SetImage(L.Img, "buttonscreen2.jpg")
        btnChangeLanguage.Visibility = Visibility.Hidden

        LoadTabs(L)
        LoadResource()
        btnChangeLanguage_Click(Nothing, Nothing)

    End Sub

    Sub LoadBarcodePrinter()
        Try
            Dim st As New StreamReader("BarcodePrinter.dll")
            Md.BarcodePrinter = st.ReadLine
            st.Close()
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadPonePrinter()
        Try
            Dim st As New StreamReader("PonePrinter.dll")
            Md.PonePrinter = st.ReadLine
            st.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LoadTabs(G As Object)
        Try
            MainGrid.Children.Clear()
            MainGrid.Children.Add(New Frame With {.Content = G})
        Catch ex As Exception
        End Try
    End Sub

    Public Sub AddTabOLD(ByVal M As MenuItem, ByVal L As UserControl)
        Dim Tab As New TabItem
        Tab.Header = M.Header
        Tab.Name = "Tab" & M.Name
        Tab.Content = L
        For Each it As TabItem In TabControl1.Items
            If it.Name = Tab.Name Then
                Tab = it
                TabControl1.SelectedItem = Tab
                Return
            End If
        Next
        TabControl1.Items.Add(Tab)
        TabControl1.SelectedItem = Tab
    End Sub

    'Add new tab --> mahmoud
    Public Sub AddTAB(ByVal M As MenuItem, ByVal UserCtrl As UserControl, Optional ByVal HaveClose As Boolean = True)
        Dim TabName As String = M.Name
        Dim TabHeader As String = M.Header
        Dim MW As MainWindow = Application.Current.MainWindow
        Dim TI As TabItem
        For I As Integer = 0 To MW.TabControl1.Items.Count - 1
            TI = MW.TabControl1.Items(I)
            If TI.Name = TabName Then
                TI.Focus()
                Exit Sub
            End If
        Next
        TI = New TabItem
        If HaveClose Then
            TI.Header = New TabsHeader With {.MyTabHeader = TabHeader, .MyTabName = TabName, .WithClose = Visibility.Visible}
        Else
            TI.Header = New TabsHeader With {.MyTabHeader = TabHeader, .MyTabName = TabName, .WithClose = Visibility.Hidden}
        End If
        Try
            CType(TI.Header, TabsHeader).Grid1.Children.Add(M.Icon)
        Catch ex As Exception
        End Try
        TI.Name = TabName
        TI.Content = UserCtrl
        MW.TabControl1.Items.Add(TI)
        TI.Focus()
    End Sub

    Function LoadConnection() As Boolean
        If con.State = ConnectionState.Open Then Return True
        Dim st As New StreamReader(Md.UdlName & ".udl")
        Dim s As String = ""
        st.ReadLine()
        st.ReadLine()
        s += st.ReadLine
        con.ConnectionString = s.Substring(20)
        Dim cb As New SqlClient.SqlConnectionStringBuilder(con.ConnectionString)
        Dim f As New Form1

        'cb.ConnectionString &= ";Max Pool Size=1000"

        Select Case Md.MyProject
            Case Client.MisrPetrol
                con.ConnectionString = "Data Source=" & cb.DataSource & ";Initial Catalog=" & cb.InitialCatalog & ";Persist Security Info=True;User ID=sa;Password=Shell123!@#"
            Case Else
                con.ConnectionString = cb.ConnectionString
        End Select
        

        Try
            con.Open()
        Catch ex As Exception
            bm.ShowMSG("Connection failed")
            bol = True
            Md.FourceExit = True
            Application.Current.Shutdown()
            Return False
        End Try
        cmd.Connection = con
        Return True
    End Function

    Public LogedIn As Boolean = False
    Public Flag As Integer = 1


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnLogout.Click
        Try
            If Not bm.ShowDeleteMSG("MsgExit") Then Return
            Forms.Application.Restart()
            Application.Current.Shutdown()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnChangeLanguage_Click(sender As Object, e As RoutedEventArgs) Handles btnChangeLanguage.Click

        If sender Is Nothing Then
            Try
                If GetSetting("OMEGA", "Lang", "En", True) = False Then
                    SaveSetting("OMEGA", "Lang", "En", True)
                Else
                    SaveSetting("OMEGA", "Lang", "En", False)
                End If
            Catch ex As Exception
                SaveSetting("OMEGA", "Lang", "En", False)
            End Try
        End If

        FlowDirection = FlowDirection.RightToLeft
        Md.DictionaryCurrent = Md.DictionaryAr
        SaveSetting("OMEGA", "Lang", "En", False)


        Resources = Md.DictionaryCurrent
        Banner1.Resources = Md.DictionaryCurrent
        Banner2.Resources = Md.DictionaryCurrent
        If MainGrid.Children(0).GetType.ToString = "System.Windows.Controls.Frame" Then CType(MainGrid.Children(0), Frame).Refresh()

    End Sub

    Private Sub LoadResource()
        Md.DictionaryAr.Source = New Uri("Dic_Ar.xaml", UriKind.Relative)
        Md.DictionaryEn.Source = New Uri("Dic_En.xaml", UriKind.Relative)

        btnChangeLanguage.SetResourceReference(Button.ContentProperty, "Ar-En")
        btnLogout.SetResourceReference(Button.ContentProperty, "Logout")
        btnExit.SetResourceReference(Button.ContentProperty, "ExitApp")
    End Sub


    Public Sub MainWindow_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
        Try
            If e.Key = System.Windows.Input.Key.Enter Then
                'e.Handled = True
                If FocusManager.GetFocusedElement(sender).GetType = GetType(Button) Then Return
                If FocusManager.GetFocusedElement(sender).GetType = GetType(Forms.Integration.WindowsFormsHost) Then Return
                If FocusManager.GetFocusedElement(sender).GetType = GetType(TextBox) Then
                    If CType(FocusManager.GetFocusedElement(sender), TextBox).VerticalScrollBarVisibility = ScrollBarVisibility.Visible Then Return
                End If
                InputManager.Current.ProcessInput(New KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Tab) With {.RoutedEvent = Keyboard.KeyDownEvent})
                If FocusManager.GetFocusedElement(sender).GetType = GetType(TextBox) AndAlso Not CType(FocusManager.GetFocusedElement(sender), TextBox).VerticalScrollBarVisibility = ScrollBarVisibility.Visible Then CType(FocusManager.GetFocusedElement(sender), TextBox).SelectAll()
            End If
        Catch
        End Try
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As RoutedEventArgs) Handles btnMinimize.Click
        WindowState = WindowState.Minimized
    End Sub
End Class
