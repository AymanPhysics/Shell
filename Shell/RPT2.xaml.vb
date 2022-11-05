Imports System.Data

Public Class RPT2
    Public MyLinkFile As Integer = 0
    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        If MyLinkFile = 0 AndAlso Val(MainAccNo.Text) = 0 Then
            bm.ShowMSG("برجاء تحديد الحساب العام")
            MainAccNo.Focus()
            Return
        End If
        If MyLinkFile = 0 AndAlso Val(SubAccNo.Text) = 0 AndAlso SubAccNo.IsEnabled Then
            bm.ShowMSG("برجاء تحديد الحساب الفرعى")
            SubAccNo.Focus()
            Return
        End If
        If MyLinkFile > 0 AndAlso Val(SubAccNo.Text) = 0 AndAlso SubAccNo.Visibility = Visibility.Visible Then
            bm.ShowMSG("برجاء تحديد الكود")
            SubAccNo.Focus()
            Return
        End If

        Dim rpt As New ReportViewer

        rpt.paraname = New String() {"@MainAccNo", "MainAccName", "@SubAccNo", "SubAccName", "@FromDate", "@ToDate", "Header", "@Detailed", "@LinkFile", "@ToId", "@RPTFlag1", "@RPTFlag2", "@ActiveOnly", "@HasBalOnly"}
        rpt.paravalue = New String() {Val(MainAccNo.Text), MainAccName.Text, Val(SubAccNo.Text), SubAccName.Text, FromDate.SelectedDate, ToDate.SelectedDate, CType(Parent, Page).Title, IIf(Detailed.IsChecked, 1, 0), MyLinkFile, Val(SubAccNo.Text), IIf(MyLinkFile = 1, 3, 2), 0, ActiveOnly.SelectedIndex, HasBalOnly.SelectedIndex}
        Select Case Flag
            Case 1
                rpt.Rpt = "AccountMotion.rpt"
                If Detailed.IsChecked AndAlso (MyLinkFile = 5 OrElse MyLinkFile = 6) Then rpt.Rpt = "AccountMotionBanks.rpt"
                If DetailedInvoice.IsChecked Then rpt.Rpt = "AccountMotion2.rpt"
            Case 2
                rpt.Rpt = "AccountMotionBanks2.rpt"
            Case 3
                rpt.Rpt = "Assistant.rpt"
        End Select
        SubAccNo.SelectAll()
        SubAccNo.Focus()
        rpt.Show()
        
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

        ActiveOnly.SelectedIndex = 2
        HasBalOnly.SelectedIndex = 2

        lblActiveOnly.Visibility = Visibility.Hidden
        ActiveOnly.Visibility = Visibility.Hidden
        lblHasBalOnly.Visibility = Visibility.Hidden
        HasBalOnly.Visibility = Visibility.Hidden

        If Flag = 2 Then
            Detailed.Visibility = Visibility.Hidden
        ElseIf Flag = 3 Then
            Detailed.Visibility = Visibility.Hidden
            DetailedInvoice.Visibility = Visibility.Hidden

            lblActiveOnly.Visibility = Visibility.Visible
            ActiveOnly.Visibility = Visibility.Visible
            lblHasBalOnly.Visibility = Visibility.Visible
            HasBalOnly.Visibility = Visibility.Visible

            lblSubAcc.Visibility = Visibility.Collapsed
            SubAccNo.Visibility = Visibility.Collapsed
            SubAccName.Visibility = Visibility.Collapsed
        End If

        If MyLinkFile = 0 Then
            btnPrev.Visibility = Visibility.Hidden
            btnNext.Visibility = Visibility.Hidden
        Else
            lblMainAcc.Visibility = Visibility.Collapsed
            MainAccNo.Visibility = Visibility.Collapsed
            MainAccName.Visibility = Visibility.Collapsed
            Select Case MyLinkFile
                Case 1
                    lblSubAcc.SetResourceReference(Label.ContentProperty, "Customer")
                Case 2
                    lblSubAcc.SetResourceReference(Label.ContentProperty, "Supplier")
                Case 3
                    lblSubAcc.SetResourceReference(Label.ContentProperty, "Debit")
                Case 4
                    lblSubAcc.SetResourceReference(Label.ContentProperty, "Credit")
                Case 5
                    lblSubAcc.SetResourceReference(Label.ContentProperty, "Safe")
                Case 6
                    lblSubAcc.SetResourceReference(Label.ContentProperty, "Bank")
                Case 7
                    lblSubAcc.SetResourceReference(Label.ContentProperty, "Seller")
            End Select
        End If
        If Flag = 3 Then
            lblMainAcc.Visibility = Visibility.Visible
            MainAccNo.Visibility = Visibility.Visible
            MainAccName.Visibility = Visibility.Visible
        End If

        If Not (MyLinkFile = 1 Or MyLinkFile = 2) Then
            If Flag <> 1 Then DetailedInvoice.Visibility = Visibility.Hidden
        End If

        Dim MyNow As DateTime = bm.MyGetDate()
        FromDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
    End Sub

    Dim lop As Boolean = False
    Private Sub SubAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SubAccNo.LostFocus
        If lop Then Return
        If MyLinkFile = 0 Then
            If Val(MainAccNo.Text) = 0 Or Not SubAccNo.IsEnabled Then
                SubAccNo.Clear()
                SubAccName.Clear()
                Return
            End If
            dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")")
            bm.LostFocus(SubAccNo, SubAccName, "select Name from " & dt.Rows(0)("TableName") & " where Id=" & SubAccNo.Text.Trim() & " and AccNo=" & Val(MainAccNo.Text))
        Else
            If Val(SubAccNo.Text) = 0 Then
                SubAccNo.Clear()
                SubAccName.Clear()
                Return
            End If
            dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & MyLinkFile)
            bm.LostFocus(SubAccNo, SubAccName, "select Name from " & dt.Rows(0)("TableName") & " where Id=" & SubAccNo.Text.Trim())
            If MyLinkFile > 0 Then
                bm.LostFocus(SubAccNo, MainAccNo, "select AccNo from " & dt.Rows(0)("TableName") & " where Id=" & SubAccNo.Text.Trim())
                lop = True
                MainAccNo_LostFocus(Nothing, Nothing)
                lop = False
            End If

        End If
    End Sub
    Private Sub SubAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SubAccNo.KeyUp
        If MyLinkFile = 0 Then
            dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")")
            If dt.Rows.Count > 0 AndAlso bm.ShowHelp(dt.Rows(0)("TableName"), SubAccNo, SubAccName, e, "select cast(Id as varchar(100)) Id,Name from " & dt.Rows(0)("TableName") & " where AccNo=" & Val(MainAccNo.Text)) Then
                SubAccNo_LostFocus(Nothing, Nothing)
            End If
        Else
            dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & MyLinkFile)
            If dt.Rows.Count > 0 AndAlso bm.ShowHelp(dt.Rows(0)("TableName"), SubAccNo, SubAccName, e, "select cast(Id as varchar(100)) Id,Name from " & dt.Rows(0)("TableName")) Then
                SubAccNo_LostFocus(Nothing, Nothing)
            End If
        End If
    End Sub


    Private Sub MainAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MainAccNo.LostFocus
        bm.AccNoLostFocus(MainAccNo, MainAccName, , MyLinkFile)

        SubAccNo.IsEnabled = MyLinkFile > 0 OrElse bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")").Rows.Count > 0
        SubAccNo_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub MainAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MainAccNo.KeyUp
        bm.AccNoShowHelp(MainAccNo, MainAccName, e, , MyLinkFile)
    End Sub


    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")
        lblFromDate.SetResourceReference(Label.ContentProperty, "From Date")
        lblToDate.SetResourceReference(Label.ContentProperty, "To Date")
        lblMainAcc.SetResourceReference(Label.ContentProperty, "Main AccNo")
        lblSubAcc.SetResourceReference(Label.ContentProperty, "Sub AccNo")
        Detailed.SetResourceReference(CheckBox.ContentProperty, "Detailed")
        DetailedInvoice.SetResourceReference(CheckBox.ContentProperty, "Detailed With Invoice")
    End Sub

    Private Sub Detailed_Checked(sender As Object, e As RoutedEventArgs) Handles DetailedInvoice.Checked, Detailed.Checked
        If Flag = 3 Then Return
        If sender Is DetailedInvoice And Detailed.IsChecked = True Then Detailed.IsChecked = False
        If sender Is Detailed And DetailedInvoice.IsChecked = True Then DetailedInvoice.IsChecked = False
    End Sub

    Private Sub btnNext_Click(sender As Object, e As RoutedEventArgs) Handles btnNext.Click
        dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & MyLinkFile)
        SubAccNo.Text = bm.ExecuteScalar("select min(Id) from " & dt.Rows(0)("TableName") & " where Id>'" & SubAccNo.Text.Trim() & "'")
        SubAccNo_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As RoutedEventArgs) Handles btnPrev.Click
        dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & MyLinkFile)
        SubAccNo.Text = bm.ExecuteScalar("select min(Id) from " & dt.Rows(0)("TableName") & " where Id<'" & SubAccNo.Text.Trim() & "'")
        SubAccNo_LostFocus(Nothing, Nothing)
    End Sub

End Class