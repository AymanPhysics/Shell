Imports System.Data

Public Class BasicForm
    Public TableName As String = ""
    Public SubId As String = "Id"
    Public SubName As String = "Name"



    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Dim m As MainWindow = Application.Current.MainWindow
    Public Flag As Integer = 0
    Public WithImage As Boolean = False

    Public Sub BasicForm_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If Not Md.MyProject = Client.PCs Then
            txtName2.Visibility = Visibility.Hidden
        End If
        If bm.TestIsLoaded(Me) Then Return
        LoadResource()
        If WithImage Then
            btnSetImage.Visibility = Visibility.Visible
            btnSetNoImage.Visibility = Visibility.Visible
            Image1.Visibility = Visibility.Visible
        End If
        bm.Fields = New String() {SubId, SubName}
        bm.control = New Control() {txtID, txtName}
        bm.KeyFields = New String() {SubId}
        If Flag = 2 Then
            bm.Fields = New String() {SubId, SubName, "Flag", "CustAccNo"}
            bm.control = New Control() {txtID, txtName, CheckBox1, AccNo}
            CheckBox1.Visibility = Visibility.Visible
        Else
            CheckBox1.Visibility = Visibility.Hidden
            lblAccNo.Visibility = Visibility.Hidden
            AccNo.Visibility = Visibility.Hidden
            AccName.Visibility = Visibility.Hidden
        End If
        If TableName = "Groups" Then
            bm.Fields = New String() {SubId, SubName, "CashCustPrevent", "IsShop"}
            bm.control = New Control() {txtID, txtName, CashCustPrevent, CheckBox1}
            CashCustPrevent.Visibility = Visibility.Visible
            If Md.MyProject = Client.Shady Then
                CheckBox1.Visibility = Visibility.Visible
                CheckBox1.Content = "كافيتيريا"
            End If
        Else
            CashCustPrevent.Visibility = Visibility.Hidden
        End If
        bm.Table_Name = TableName
        btnNew_Click(sender, e)
        
    End Sub


    Private Sub AccNo_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles AccNo.LostFocus
        bm.AccNoLostFocus(AccNo, AccName, , 1)
    End Sub

    Private Sub AccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles AccNo.KeyUp
        bm.AccNoShowHelp(AccNo, AccName, e, , 1)
    End Sub


    Sub FillControls()
        bm.FillControls()
        AccNo_LostFocus(Nothing, Nothing)
        If WithImage Then bm.GetImage(TableName, New String() {SubId}, New String() {txtID.Text.Trim}, "Image", Image1)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CType(Application.Current.MainWindow, MainWindow).TabControl1.Items.Remove(Me.Parent)
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        bm.FirstLast(New String() {SubId}, "Max", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        bm.NextPrevious(New String() {SubId}, New String() {txtID.Text}, "Next", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtName.Text.Trim = "" Then
            txtName.Focus()
            Return
        End If
        bm.DefineValues()
        If Not bm.Save(New String() {SubId}, New String() {txtID.Text.Trim}) Then Return
        If WithImage Then bm.SaveImage(TableName, New String() {SubId}, New String() {txtID.Text.Trim}, "Image", Image1)
        btnNew_Click(sender, e)
        AllowClose = True
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click

        bm.FirstLast(New String() {SubId}, "Min", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearControls()
    End Sub

    Sub ClearControls()
        bm.ClearControls()
        bm.SetNoImage(Image1)
        AccNo_LostFocus(Nothing, Nothing)
        txtName.Clear()
        txtID.Text = bm.ExecuteScalar("select max(" & SubId & ")+1 from " & TableName)
        If txtID.Text = "" Then txtID.Text = "1"
        CashCustPrevent.IsChecked = False
        txtName.Focus()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete from " & TableName & " where " & SubId & "='" & txtID.Text.Trim & "'")
            btnNew_Click(sender, e)
        End If
    End Sub

    Private Sub btnPrevios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevios.Click
        bm.NextPrevious(New String() {SubId}, New String() {txtID.Text}, "Back", dt)
        If dt.Rows.Count = 0 Then Return
        FillControls()
    End Sub
    Dim lv As Boolean = False

    Private Sub txtID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txtID.KeyUp
        If bm.ShowHelp(CType(Parent, Page).Title, txtID, txtName, e, "select cast(Id as varchar(100)) Id,Name from " & TableName, TableName) Then
            txtName.Focus()
        End If
    End Sub

    Private Sub txtID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.LostFocus
        If lv Then
            Return
        End If
        lv = True

        bm.DefineValues()
        Dim dt As New DataTable
        bm.RetrieveAll(New String() {SubId}, New String() {txtID.Text.Trim}, dt)
        If dt.Rows.Count = 0 Then
            Dim s As String = txtID.Text
            ClearControls()
            txtID.Text = s
            txtName.Focus()
            lv = False
            Return
        End If
        FillControls()
        lv = False
        txtName.SelectAll()
        txtName.Focus()
        txtName.SelectAll()
        txtName.Focus()
        'txtName.Text = dt(0)("Name")
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txtID.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub


    Dim AllowClose As Boolean = False
    'Private Sub MyBase_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    If Not btnSave.Enabled Then Exit Sub
    '    Select Case bm.RequestDelete
    '        Case BasicMethods.CloseState.Yes
    '            AllowClose = False
    '            btnSave_Click(Nothing, Nothing)
    '            If Not AllowClose Then e.Cancel = True
    '        Case BasicMethods.CloseState.No

    '        Case BasicMethods.CloseState.Cancel
    '            e.Cancel = True
    '    End Select
    'End Sub


    Private Sub btnSetImage_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSetImage.Click
        bm.SetImage(Image1)
    End Sub

    Private Sub btnSetNoImage_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSetNoImage.Click
        bm.SetNoImage(Image1, False, True)
    End Sub


    Private Sub LoadResource()
        btnSave.SetResourceReference(Button.ContentProperty, "Save")
        btnDelete.SetResourceReference(Button.ContentProperty, "Delete")
        btnNew.SetResourceReference(Button.ContentProperty, "New")

        btnFirst.SetResourceReference(Button.ContentProperty, "First")
        btnNext.SetResourceReference(Button.ContentProperty, "Next")
        btnPrevios.SetResourceReference(Button.ContentProperty, "Previous")
        btnLast.SetResourceReference(Button.ContentProperty, "Last")

        lblId.SetResourceReference(Label.ContentProperty, "Id")
        lblName.SetResourceReference(Label.ContentProperty, "Name")
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtName.TextChanged
        txtName2.Text = bm.Encrypt(txtName.Text)
    End Sub
End Class
