Imports System.Data
Imports Microsoft.Office.Interop
Imports System.IO

Public Class RPT25
    Dim bm As New BasicMethods
    Dim dt As New DataTable

    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click

        Dim rpt As New ReportViewer
        Select Case Flag
            Case 1
                rpt.Rpt = "Loans.rpt"
            Case 2
                rpt.Rpt = "DirectBonus.rpt"
            Case 3
                rpt.Rpt = "DirectCut.rpt"
            Case 4
                rpt.Rpt = "LeaveRequests.rpt"
            Case 5
                rpt.Rpt = "LeaveRequests2.rpt"
            Case 6
                rpt.Rpt = "LoansStatus.rpt"
            Case 7
                rpt.Rpt = "EmpShifts.rpt"
            Case 8, 10
                MyFromDate = FromDate.SelectedDate
                MyToDate = ToDate.SelectedDate
                Button2.IsEnabled = False
                BackgroundWorker1.RunWorkerAsync()
                Return
            Case 9
                rpt.Rpt = "NurseShiftSummary.rpt"
        End Select

        rpt.paraname = New String() {"@EmpId", "@FromDate", "@ToDate", "Header"}
        rpt.paravalue = New String() {Val(EmpId.Text), FromDate.SelectedDate, ToDate.SelectedDate, CType(Parent, Page).Title}
        rpt.Show()

    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me, True) Then Return
        LoadResource()
        'bm.Addcontrol_MouseDoubleClick({EmpId})
        Dim MyNow As DateTime = bm.MyGetDate()
        FromDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        Select Flag
            Case 6
                FromDate.Visibility = Visibility.Hidden
                lblFromDate.Visibility = Visibility.Hidden
                ToDate.Visibility = Visibility.Hidden
                lblToDate.Visibility = Visibility.Hidden
            Case 8
                FromDate.SelectedDate = New DateTime(MyNow.Year - 1, 12, 31, 0, 0, 0)
                lblEmpId.Visibility = Visibility.Hidden
                EmpId.Visibility = Visibility.Hidden
                EmpName.Visibility = Visibility.Hidden
                lblFromDate.Content = "أول المدة في"
                lblToDate.Content = "آخر المدة في"
            Case 10
                lblEmpId.Visibility = Visibility.Hidden
                EmpId.Visibility = Visibility.Hidden
                EmpName.Visibility = Visibility.Hidden
                lblFromDate.Visibility = Visibility.Hidden
                FromDate.Visibility = Visibility.Hidden
                lblToDate.Visibility = Visibility.Hidden
                ToDate.Visibility = Visibility.Hidden
        End Select
    End Sub
    Private Sub LoadResource()

        Button2.SetResourceReference(System.Windows.Controls.Button.ContentProperty, "View Report")
        
        lblEmpId.SetResourceReference(Label.ContentProperty, "Employee")
        lblFromDate.SetResourceReference(Label.ContentProperty, "From Date")
        lblToDate.SetResourceReference(Label.ContentProperty, "To Date")
        Button2.SetResourceReference(Button.ContentProperty, "Calculate")
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles EmpId.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub EmpId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles EmpId.KeyUp
        If bm.ShowHelp("Employees", EmpId, EmpName, e, "Select cast(Id as varchar(10))Id," & Resources.Item("CboName") & " Name from Employees" & IIf(Flag = 7, " where SalaryOrShifts=1", "")) Then
            EmpId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub EmpId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles EmpId.LostFocus
        If Val(EmpId.Text.Trim) = 0 Then
            EmpId.Clear()
            EmpName.Clear()
            Return
        End If
        bm.LostFocus(EmpId, EmpName, "select " & Resources.Item("CboName") & " Name from Employees where Id=" & EmpId.Text.Trim() & IIf(Flag = 7, " and SalaryOrShifts=1", ""))
    End Sub

    Dim MyFromDate As Date, MyToDate As Date
    Dim WithEvents BackgroundWorker1 As New ComponentModel.BackgroundWorker
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Select Case Flag
            Case 8
                'bm.ExcuteNonQuery("CalcAvgCost", New String() {"FromDate", "ToDate"}, New String() {bm.ToStrDate(MyFromDate), bm.ToStrDate(MyToDate)})
                'bm.ExecuteNonQuery("CalcAvgCost", {}, {})
                bm.ExecuteNonQuery("CalcMovingAvgCost", New String() {"FromDate", "ToDate"}, New String() {bm.ToStrDate(MyFromDate), bm.ToStrDate(MyToDate)})
                'bm.ExecuteNonQuery("CalcItemsBalCostGroup", New String() {"FromDate", "ToDate"}, New String() {bm.ToStrDate(MyFromDate), bm.ToStrDate(MyToDate)})
            Case 10
                bm.ExecuteNonQuery("CalcImportMessagesOpennedOnly", {}, {})
        End Select
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        bm.ShowMSG("Done Successfuly")
        Button2.IsEnabled = True
    End Sub


End Class