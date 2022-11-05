Imports System.Data

Public Class RPT28
    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click

        Dim rpt As New ReportViewer

        Dim InOut As Integer = 2
        If Flag = 5 Then
            InOut = 0
        ElseIf Flag = 6 OrElse Flag = 7 Then
            InOut = 1
        End If
        rpt.paraname = New String() {"@ItemsPetroleumId", "ItemsPetroleumNameName", "@FromDate", "@ToDate", "Header", "@InOut"}
        rpt.paravalue = New String() {Val(ItemsPetroleumId.Text), ItemsPetroleumName.Text, FromDate.SelectedDate, ToDate.SelectedDate, CType(Parent, Page).Title, InOut}
        Select Case Flag
            Case 1
                rpt.Rpt = "InventoryDetails.rpt"
            Case 2
                rpt.Rpt = "InventoryDetails2.rpt"
            Case 3
                rpt.Rpt = "InventoryDetails3.rpt"
            Case 4
                rpt.Rpt = "ItemsPetroleumMotion.rpt"
            Case 5
                rpt.Rpt = "ItemsPetroleumMotion2.rpt"
            Case 6
                rpt.Rpt = "ItemsPetroleumMotion3.rpt"
            Case 7
                rpt.Rpt = "ItemsPetroleumMotion4.rpt"
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


    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")
        lblFromDate.SetResourceReference(Label.ContentProperty, "From Date")
        lblToDate.SetResourceReference(Label.ContentProperty, "To Date")


    End Sub

    Private Sub ItemsPetroleumId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ItemsPetroleumId.KeyUp
        If bm.ShowHelp("ItemsPetroleum", ItemsPetroleumId, ItemsPetroleumName, e, "select cast(Id as varchar(100)) Id,Name from ItemsPetroleum") Then
            ItemsPetroleumId_LostFocus(ItemsPetroleumId, Nothing)
        End If
    End Sub

    Private Sub ItemsPetroleumId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ItemsPetroleumId.LostFocus
        bm.LostFocus(ItemsPetroleumId, ItemsPetroleumName, "select Name from ItemsPetroleum where Id=" & ItemsPetroleumId.Text.Trim())
    End Sub

End Class