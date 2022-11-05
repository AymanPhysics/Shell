﻿Imports System.Data

Public Class RPT20

    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        If Level.SelectedIndex < 1 Then
            bm.ShowMSG("برجاء تحديد المستوى")
            Level.Focus()
            Return
        End If

        Dim rpt As New ReportViewer

        rpt.paraname = New String() {"@Level", "@FromDate", "@ToDate", "Header"}
        rpt.paravalue = New String() {Level.SelectedIndex, FromDate.SelectedDate, ToDate.SelectedDate, CType(Parent, Page).Title}
        Select Case Flag
            Case 1
                rpt.Rpt = "AccountBalance.rpt"
        End Select
        rpt.Show()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()
        FillLevel()

        Dim MyNow As DateTime = bm.MyGetDate()
        FromDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)
    End Sub



    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")
        lblFromDate.SetResourceReference(Label.ContentProperty, "From Date")
        lblToDate.SetResourceReference(Label.ContentProperty, "To Date")
    End Sub

    Private Sub FillLevel()
        Try
            Level.Items.Clear()
            Dim x As Integer = Val(bm.ExecuteScalar("select min(Level) from chart where SubType=1"))
            Level.Items.Add("-")
            For i As Integer = 1 To x
                Level.Items.Add(i)
            Next
            Level.SelectedIndex = 0
        Catch
        End Try
    End Sub

End Class