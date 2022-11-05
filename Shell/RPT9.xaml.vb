Imports System.Data

Public Class RPT9
    Dim bm As New BasicMethods
    Dim dt As New DataTable

    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        If Val(txtMonth.Text) = 0 OrElse Val(txtYear.Text) = 0 Then Return

        Dim rpt As New ReportViewer
        Select Case Flag
            Case 1
                rpt.Rpt = "SalaryHistory.rpt"
            Case 2
                rpt.Rpt = "SalaryHistory2.rpt"
            Case 3
                rpt.Rpt = "Attendance.rpt"
        End Select

        rpt.paraname = New String() {"@EmpId", "@Month", "@Year", "Header", "@FromDay", "@ToDay", "@MainJobId", "@SubJobId"}
        rpt.paravalue = New String() {Val(EmpId.Text), txtMonth.Text, txtYear.Text, CType(Parent, Page).Title, Val(FromDay.Text), Val(ToDay.Text), Val(MainJobId.Text), Val(SubJobId.Text)}
        rpt.Show()

    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()
        Dim MyNow As DateTime = bm.MyGetDate()
        txtMonth.Text = MyNow.Month
        txtYear.Text = MyNow.Year
    End Sub
    Private Sub LoadResource()

        Select Case Flag
            Case 1, 2, 3
                Button2.SetResourceReference(System.Windows.Controls.Button.ContentProperty, "View Report")
        End Select

        lblEmpId.SetResourceReference(Label.ContentProperty, "Employee")
        lblFromDate.SetResourceReference(System.Windows.Controls.Label.ContentProperty, "Month")
        lblFromDate_Copy.SetResourceReference(System.Windows.Controls.Label.ContentProperty, "Year")
        lblMainJob.SetResourceReference(Label.ContentProperty, "MainJob")
        lblSubJobId.SetResourceReference(Label.ContentProperty, "SubJob")
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txtMonth.KeyDown, txtYear.KeyDown, EmpId.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub EmpId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles EmpId.KeyUp
        If bm.ShowHelp("Employees", EmpId, EmpName, e, "Select cast(Id as varchar(10))Id," & Resources.Item("CboName") & " Name from Employees") Then
            EmpId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub EmpId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles EmpId.LostFocus
        If Val(EmpId.Text.Trim) = 0 Then
            EmpId.Clear()
            EmpName.Clear()
            Return
        End If
        bm.LostFocus(EmpId, EmpName, "select " & Resources.Item("CboName") & " Name from Employees where Id=" & EmpId.Text.Trim())
    End Sub


    Private Sub MainJobId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MainJobId.KeyUp
        bm.ShowHelp("MainJobs", MainJobId, MainJobName, e, "select cast(Id as varchar(100)) Id,Name from MainJobs", "MainJobs")
    End Sub

    Private Sub SubJobId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles SubJobId.KeyUp
        bm.ShowHelp("SubJobs", SubJobId, SubJobName, e, "select cast(Id as varchar(100)) Id,Name from SubJobs where MainJobId=" & MainJobId.Text.Trim, "SubJobs", {"MainJobId"}, {Val(MainJobId.Text)})
    End Sub

    Private Sub MainJobId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MainJobId.LostFocus
        bm.LostFocus(MainJobId, MainJobName, "select Name from MainJobs where Id=" & MainJobId.Text.Trim())
        SubJobId_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub SubJobId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles SubJobId.LostFocus
        bm.LostFocus(SubJobId, SubJobName, "select Name from SubJobs where MainJobId=" & MainJobId.Text.Trim & " and Id=" & SubJobId.Text.Trim())
    End Sub


End Class