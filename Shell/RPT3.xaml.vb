Imports System.Data

Public Class RPT3

    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        If StoreId.Visibility = Visibility.Visible AndAlso StoreId.Text.Trim = "" Then
            bm.ShowMSG("برجاء تحديد المخزن")
            StoreId.Focus()
            Return
        End If


        Dim MyNow As DateTime = bm.MyGetDate()
        If Val(txtYear.Text) = 0 Then txtYear.Text = MyNow.Year
        If Val(txtMonth.Text) = 0 Then txtMonth.Text = MyNow.Month

        Dim rpt As New ReportViewer
        rpt.paraname = New String() {"@Year", "@Month", "@GroupId", "GroupName", "@TypeId", "TypeName", "@StoreId", "Header"}
        rpt.paravalue = New String() {Val(txtYear.Text), Val(txtMonth.Text), Val(GroupId.Text), GroupName.Text, Val(TypeId.Text), TypeName.Text, Val(StoreId.Text), CType(Parent, Page).Title}
        Select Case Flag
            Case 1
                rpt.Rpt = "StoreItemSales.rpt"
        End Select
        rpt.Show()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()
        
        Dim MyNow As DateTime = bm.MyGetDate()
        txtYear.Text = MyNow.Year
        txtMonth.Text = MyNow.Month
    End Sub

    Dim lop As Boolean = False



    Private Sub LoadResource()
        Button2.SetResourceReference(Button.ContentProperty, "View Report")
        
    End Sub

    Private Sub StoreId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyUp
        If bm.ShowHelp("Stores", StoreId, StoreName, e, "select cast(Id as varchar(100)) Id,Name from Fn_EmpStores(" & Md.UserName & ")") Then
            StoreId_LostFocus(StoreId, Nothing)
        End If
    End Sub

    Private Sub StoreId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StoreId.LostFocus
        bm.LostFocus(StoreId, StoreName, "select Name from Fn_EmpStores(" & Md.UserName & ") where Id=" & StoreId.Text.Trim())
    End Sub



    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyDown, ColorId.KeyDown, SizeId.KeyDown, GroupId.KeyDown, TypeId.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub GroupId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles GroupId.LostFocus
        bm.LostFocus(GroupId, GroupName, "select Name from Groups where Id=" & GroupId.Text.Trim())
        TypeId_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub TypeId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TypeId.LostFocus
        bm.LostFocus(TypeId, TypeName, "select Name from Types where GroupId=" & GroupId.Text.Trim & " and Id=" & TypeId.Text.Trim())
    End Sub

    Private Sub GroupId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles GroupId.KeyUp
        If bm.ShowHelp("Groups", GroupId, GroupName, e, "select cast(Id as varchar(100)) Id,Name from Groups") Then
            GroupId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub TypeId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles TypeId.KeyUp
        bm.ShowHelp("Types", TypeId, TypeName, e, "select cast(Id as varchar(100)) Id,Name from Types where GroupId=" & GroupId.Text.Trim)
    End Sub


End Class