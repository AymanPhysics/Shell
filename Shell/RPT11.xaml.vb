Imports System.Data

Public Class RPT11
    Public MyLinkFile As Integer = 0
    Public MyEndType As Integer = 0
    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim rpt As New ReportViewer

        rpt.paraname = New String() {"@MainAccNo", "MainAccName", "@DayDate", "@ToDate", "@LinkFile", "@EndType", "@FromBal", "@ToBal", "Header"}
        rpt.paravalue = New String() {MainAccNo.Text, MainAccName.Text, ToDate.SelectedDate, ToDate.SelectedDate, MyLinkFile, MyEndType, Val(FromBal.Text), Val(ToBal.Text), CType(Parent, Page).Title}
        Select Case Flag
            Case 1
                rpt.Rpt = "AllBal.rpt"
            Case 2
                rpt.Rpt = "EndAccounts.rpt"
        End Select
        rpt.Show()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

        Dim MyNow As DateTime = bm.MyGetDate()
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        If Flag = 2 Then
            lblMainAcc.Visibility = Visibility.Hidden
            MainAccNo.Visibility = Visibility.Hidden
            MainAccName.Visibility = Visibility.Hidden

            lblFromBal.Visibility = Visibility.Hidden
            FromBal.Visibility = Visibility.Hidden
            lblToBal.Visibility = Visibility.Hidden
            ToBal.Visibility = Visibility.Hidden
        End If
    End Sub

    Dim lop As Boolean = False



    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")
        lblToDate.SetResourceReference(Label.ContentProperty, "To Date")

    End Sub

    Private Sub MainAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MainAccNo.LostFocus
        bm.AccNoLostFocus(MainAccNo, MainAccName, , MyLinkFile)
    End Sub

    Private Sub MainAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MainAccNo.KeyUp
        bm.AccNoShowHelp(MainAccNo, MainAccName, e, , MyLinkFile)
    End Sub

End Class