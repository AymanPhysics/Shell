Imports System.Data

Public Class RPT31

    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim rpt As New ReportViewer
        rpt.paraname = New String() {"Header", "@CountryId", "@CityId", "@AreaId"}
        rpt.paravalue = New String() {CType(Parent, Page).Title, 0, 0, 0}
        Select Case Flag
            Case 1
                rpt.Rpt = "ItemsLoans.rpt"
            Case 2
                rpt.Rpt = "Customers.rpt"
        End Select
        rpt.Show()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()

    End Sub

    Dim lop As Boolean = False



    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")

    End Sub


End Class