Imports System.Data

Public Class ShiftNotes


    Dim dt As New DataTable
    Dim bm As New BasicMethods

    Public Flag As Integer = 0

    Private Sub ShiftNotes_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        bm.TestIsLoaded(Me)

        If Flag = 0 Then
            Notes.Text = bm.ExecuteScalar("select Notes from ShiftNotes where Daydate='" & Md.CurrentDate & "' and Shift=" & Md.CurrentShiftId & " and EmpId=" & Md.UserName)
        Else
            Notes.IsReadOnly = True
            btnSave.Visibility = Visibility.Hidden
            dt = bm.ExecuteAdapter("GetShiftNotes", {"DayDate", "Shift"}, {Md.CurrentDate, Md.CurrentShiftId})
            For i As Integer = 0 To dt.Rows.Count - 1
                For i2 As Integer = 0 To dt.Columns.Count - 1
                    Notes.AppendText(dt.Rows(i)(i2).ToString & vbCrLf)
                Next
                Notes.AppendText(vbCrLf & "***********************************************************" & vbCrLf & vbCrLf)
            Next
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If bm.ExecuteNonQuery("if exists(select EmpId from ShiftNotes where Daydate='" & bm.ToStrDate(Md.CurrentDate) & "' and Shift=" & Md.CurrentShiftId & " and EmpId=" & Md.UserName & ") update ShiftNotes set Notes='" & Notes.Text.Trim.Replace("'", "''") & "',MyGetDate=GetDate(),UserName=" & Md.UserName & " where Daydate='" & bm.ToStrDate(Md.CurrentDate) & "' and Shift=" & Md.CurrentShiftId & " and EmpId=" & Md.UserName & " else insert ShiftNotes(DayDate,Shift,EmpId,Notes,MyGetDate,UserName)select '" & bm.ToStrDate(Md.CurrentDate) & "'," & Md.CurrentShiftId & "," & Md.UserName & ",'" & Notes.Text.Trim.Replace("'", "''") & "',GetDate()," & Md.UserName & "") Then
            bm.ShowMSG("Saved Successfuly")
        End If
    End Sub

    
End Class
