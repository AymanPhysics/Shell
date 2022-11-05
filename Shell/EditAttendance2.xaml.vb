Imports System.Data

Public Class EditAttendance2
    Dim dt As New DataTable
    Dim bm As New BasicMethods
    WithEvents G As New MyGrid

    Public Sub BasicForm_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        If bm.TestIsLoaded(Me) Then Return
        
        LoadResource()
        LoadWFH()
        DayDate.SelectedDate = bm.MyGetDate()

        StoreId.Text = Md.DefaultStore
        StoreId.IsEnabled = Md.Manager
        StoreId_LostFocus(Nothing, Nothing)

        btnDelete.Visibility = Visibility.Hidden
        DayDate.IsEnabled = Md.Manager
    End Sub

    Structure GC
        Shared EmpId As String = "EmpId"
        Shared EmpName As String = "EmpName"
        Shared CheckIn As String = "CheckIn"
        Shared CheckOut As String = "CheckOut"
    End Structure


    Private Sub LoadWFH()
        WFH.Child = G

        G.Columns.Clear()
        G.ForeColor = System.Drawing.Color.DarkBlue
        G.Columns.Add(GC.EmpId, "كود الموظف")
        G.Columns.Add(GC.EmpName, "اسم الموظف")
        G.Columns.Add(GC.CheckIn, "حضور")
        G.Columns.Add(GC.CheckOut, "انصراف")

        G.Columns(GC.EmpId).ReadOnly = True
        G.Columns(GC.EmpName).ReadOnly = True
        G.Columns(GC.CheckIn).ReadOnly = True
        G.Columns(GC.CheckOut).ReadOnly = True

        G.Columns(GC.EmpName).FillWeight = 300

        G.AutoSizeColumnsMode = Forms.DataGridViewAutoSizeColumnsMode.Fill
        G.AllowUserToDeleteRows = False
        G.AllowUserToAddRows = False

        G.EditMode = Forms.DataGridViewEditMode.EditOnEnter
        G.TabStop = False
        AddHandler G.CellDoubleClick, AddressOf G_CellDoubleClick
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If DayDate.SelectedDate Is Nothing Then
            DayDate.Focus()
            Return
        End If
        G.EndEdit()

        bm.ExecuteNonQuery("delete AttendanceLog where dbo.GetEmpDefaultStore(EmpId)=" & Val(StoreId.Text) & " and cast(DayDate as date)='" & bm.ToStrDate(DayDate.SelectedDate) & "'")

        Dim str As String = "Insert AttendanceLog(EmpId,DayDate,State) values "
        For i As Integer = 0 To G.Rows.Count - 1
            Try
                If G.Rows(i).Cells(GC.EmpId).Value.ToString.Trim = "" OrElse G.Rows(i).Cells(GC.CheckIn).Value.ToString.Trim <> "" Then
                    str &= "('" & G.Rows(i).Cells(GC.EmpId).Value.ToString & "','" & bm.ToStrDate(DayDate.SelectedDate) & " " & G.Rows(i).Cells(GC.CheckIn).Value.ToString & "','0'),"
                End If
                If G.Rows(i).Cells(GC.EmpId).Value.ToString.Trim = "" OrElse G.Rows(i).Cells(GC.CheckOut).Value.ToString.Trim <> "" Then
                    str &= "('" & G.Rows(i).Cells(GC.EmpId).Value.ToString & "','" & bm.ToStrDate(DayDate.SelectedDate) & " " & G.Rows(i).Cells(GC.CheckOut).Value.ToString & "','1'),"
                End If
            Catch ex As Exception
            End Try
        Next
        str = str.Substring(0, str.Length - 1)

        If Not bm.ExecuteNonQuery(str) Then Return

        btnNew_Click(sender, e)

    End Sub


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, DayDate.SelectedDateChanged
        G.Rows.Clear()
        dt = bm.ExecuteAdapter("GetNewAttendanceLog", {"StoreId", "DayDate"}, {Val(StoreId.Text), bm.ToStrDate(DayDate.SelectedDate)})
        For i As Integer = 0 To dt.Rows.Count - 1
            G.Rows.Add({dt.Rows(i)(0), dt.Rows(i)(1), dt.Rows(i)(2), dt.Rows(i)(3)})
        Next
        G.RefreshEdit()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If bm.ShowDeleteMSG() Then
            bm.ExecuteNonQuery("delete AttendanceLog where dbo.GetEmpDefaultStore(EmpId)=" & Val(StoreId.Text) & " and cast(DayDate as date)='" & bm.ToStrDate(DayDate.SelectedDate) & "'")
            btnNew_Click(sender, e)
        End If
    End Sub




    Private Sub LoadResource()
        btnSave.SetResourceReference(Button.ContentProperty, "Save")
        btnDelete.SetResourceReference(Button.ContentProperty, "Delete")
        btnNew.SetResourceReference(Button.ContentProperty, "New")
        lblStoreId.SetResourceReference(Button.ContentProperty, "Store")

    End Sub

    Private Sub G_CellDoubleClick(sender As Object, e As Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = G.Columns(GC.CheckIn).Index Then
            G.Rows(e.RowIndex).Cells(GC.CheckIn).Value = bm.ExecuteScalar("select cast(cast(GetDate() as time)as nvarchar(8))")
        ElseIf e.ColumnIndex = G.Columns(GC.CheckOut).Index Then
            G.Rows(e.RowIndex).Cells(GC.CheckOut).Value = bm.ExecuteScalar("select cast(cast(GetDate() as time)as nvarchar(8))")
        End If
    End Sub


    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub StoreId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyUp
        bm.ShowHelp("Stores", StoreId, StoreName, e, "select cast(Id as varchar(100)) Id,Name from Stores", "Stores")
    End Sub

    Private Sub StoreId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StoreId.LostFocus
        bm.LostFocus(StoreId, StoreName, "select Name from Fn_EmpStores(" & Md.UserName & ") where Id=" & StoreId.Text.Trim())
        btnNew_Click(Nothing, Nothing)
    End Sub


End Class
