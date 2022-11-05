Imports System.Data

Public Class RPT19
    Dim bm As New BasicMethods
    Public Flag As Integer = 0
    Public Detail As Integer = 0
    Dim dt As New DataTable

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim rpt As New ReportViewer
        rpt.paraname = New String() {"@FromDate", "@ToDate", "@MainAccNo", "@SubAccNo", "@FromInvoiceNo", "@ToInvoiceNo", "Header", "Flag"}
        rpt.paravalue = New String() {FromDate.SelectedDate, ToDate.SelectedDate, Val(MainAccNo.Text), Val(SubAccNo.Text), Val(FromInvoice.Text), Val(ToInvoice.Text), CType(Parent, Page).Title, IIf(Flag = 2 Or Flag = 4, 2, 1)}
        'rpt.Header = Md.MyProject.ToString
        Select Case Flag
            Case 1, 2
                rpt.Rpt = "Income.rpt"
            Case 3, 4
                rpt.Rpt = "Outcome.rpt"
        End Select
        rpt.Show()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()
        Dim MyNow As DateTime = bm.MyGetDate()
        FromDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
    End Sub
    Private Sub SubAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SubAccNo.LostFocus
        If Val(MainAccNo.Text) = 0 Or Not SubAccNo.IsEnabled Then
            SubAccNo.Clear()
            SubAccName.Clear()
            Return
        End If

        dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")")
        bm.LostFocus(SubAccNo, SubAccName, "select Name from " & dt.Rows(0)("TableName") & " where Id=" & SubAccNo.Text.Trim() & " and AccNo=" & Val(MainAccNo.Text))
    End Sub
    Private Sub SubAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SubAccNo.KeyUp
        dt = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")")
        If dt.Rows.Count > 0 AndAlso bm.ShowHelp(dt.Rows(0)("TableName"), SubAccNo, SubAccName, e, "select cast(Id as varchar(100)) Id,Name from " & dt.Rows(0)("TableName") & " where AccNo=" & Val(MainAccNo.Text)) Then
            SubAccNo_LostFocus(Nothing, Nothing)
        End If
    End Sub


    Private Sub MainAccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MainAccNo.LostFocus
        bm.AccNoLostFocus(MainAccNo, MainAccName, , )

        SubAccNo.IsEnabled = bm.ExecuteAdapter("select * from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=" & MainAccNo.Text & ")").Rows.Count > 0
        SubAccNo_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub MainAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MainAccNo.KeyUp
        bm.AccNoShowHelp(MainAccNo, MainAccName, e, , )
    End Sub


    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")
        lblFromId.SetResourceReference(Label.ContentProperty, "From Id")
        lblToId.SetResourceReference(Label.ContentProperty, "To Id")
        lblFromDate.SetResourceReference(Label.ContentProperty, "From Date")
        lblToDate.SetResourceReference(Label.ContentProperty, "To Date")
        lblMainAccNo.SetResourceReference(Label.ContentProperty, "Main AccNo")
        lblSubAccNo.SetResourceReference(Label.ContentProperty, "Sub AccNo")
    End Sub

End Class
