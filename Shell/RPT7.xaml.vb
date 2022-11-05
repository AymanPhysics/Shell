Imports System.Data

Public Class RPT7
    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public LinkFile As Integer = 5

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click

        Dim rpt As New ReportViewer

        rpt.paraname = New String() {"@StoreId", "StoreName", "@FromDate", "@ToDate", "Header", "@BankId"}
        rpt.paravalue = New String() {Val(StoreId.Text), StoreName.Text, FromDate.SelectedDate, ToDate.SelectedDate, CType(Parent, Page).Title, Val(BankId.Text)}
        Select Case Flag
            Case 1
                rpt.Rpt = "DailyMotion.rpt"
            Case 2
                rpt.Rpt = "DeficitAndIncrease.rpt"
            Case 3
                rpt.Rpt = "DeficitAndIncreaseComparison.rpt"
        End Select
        rpt.Show()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()
        If Flag <> 3 Then
            StoreId.Visibility = Visibility.Hidden
            StoreName.Visibility = Visibility.Hidden
            lblStoreId.Visibility = Visibility.Hidden
        End If
        If Flag <> 2 Then
            BankId.Visibility = Visibility.Hidden
            BankName.Visibility = Visibility.Hidden
            lblBank.Visibility = Visibility.Hidden
        End If
        Dim MyNow As DateTime = bm.MyGetDate()
        FromDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
    End Sub
    



    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")
        lblFromDate.SetResourceReference(Label.ContentProperty, "From Date")
        lblToDate.SetResourceReference(Label.ContentProperty, "To Date")


    End Sub

    Private Sub StoreId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyUp
        If bm.ShowHelp("Stores", StoreId, StoreName, e, "select cast(Id as varchar(100)) Id,Name from Fn_EmpStores(" & Md.UserName & ")") Then
            StoreId_LostFocus(StoreId, Nothing)
        End If
    End Sub

    Private Sub StoreId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StoreId.LostFocus
        bm.LostFocus(StoreId, StoreName, "select Name from Fn_EmpStores(" & Md.UserName & ") where Id=" & StoreId.Text.Trim())
    End Sub


    Private Sub BankId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BankId.LostFocus
        If Val(BankId.Text.Trim) = 0 Then
            BankId.Clear()
            BankName.Clear()
            Return
        End If

        dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & LinkFile)
        bm.LostFocus(BankId, BankName, "select Name from " & dt.Rows(0)("TableName") & " where Id=" & BankId.Text.Trim())
    End Sub

    Private Sub BankId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles BankId.KeyUp
        dt = bm.ExecuteAdapter("select * from LinkFile where Id=" & LinkFile)
        If dt.Rows.Count > 0 AndAlso bm.ShowHelp(dt.Rows(0)("TableName"), BankId, BankName, e, "select cast(Id as varchar(100)) Id,Name from " & dt.Rows(0)("TableName")) Then
            BankId_LostFocus(Nothing, Nothing)
        End If
    End Sub

End Class