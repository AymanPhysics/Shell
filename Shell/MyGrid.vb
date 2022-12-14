Imports System.Windows.Forms

Public Class MyGrid

    Private Sub Grid_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Me.DataError, MyBase.DataError, MyClass.DataError

    End Sub

    Public Sub New()
        InitializeComponent()
        AllowUserToDeleteRows = False
        'Dim DataGridViewCellStyle1 As New DataGridViewCellStyle
        'Dim DataGridViewCellStyle2 As New DataGridViewCellStyle
        'DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        'DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        BackgroundColor = System.Drawing.Color.GhostWhite
        'DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        'DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold
        'DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        'DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        'DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        'DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        'ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Dock = System.Windows.Forms.DockStyle.Fill
        EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Location = New System.Drawing.Point(0, 0)
        MultiSelect = False
        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Name = "Grid"
        'RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        'Size = New System.Drawing.Size(150, 150)
        'TabIndex = 0
        StandardTab = False
        'If Md.MyProject = Client.ClothesRed Then
        '    ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font(ColumnHeadersDefaultCellStyle.Font.FontFamily, 14)
        '    ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White
        '    ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Red
        '    RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        '    RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Red
        'End If
    End Sub

    Public Property BaarcodeIndex As Integer = -1
    Public Property AllowLeaveGrid As Boolean = False


    Dim lop2 As Boolean = False
    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        If lop2 Then
            lop2 = False
            Return False
        End If
        Try
            If AllowLeaveGrid AndAlso keyData = Keys.Enter Then
                EditMode = DataGridViewEditMode.EditOnF2
                EndEdit()
                'SendKeys.SendWait("{Tab}")
                'StandardTab = True
                'Me.OnKeyDown(New KeyEventArgs(Keys.Tab))
                'RaiseKeyEvent(Me, New KeyEventArgs(Keys.Tab))
                SelectNextControl(Me.Parent, True, True, True, True)

                EditMode = DataGridViewEditMode.EditOnEnter
                'SendKeys.SendWait("{Tab}")
                'SelectNextControl(Me, True, True, True, True)
                'Me.GetNextControl(Me.Parent, True).Focus()
                'Dim rowindex As Integer = CurrentCell.RowIndex
                'Dim columnindex As Integer = CurrentCell.ColumnIndex
                'CurrentCell = Rows(rowindex).Cells(columnindex)
                'Return True
            ElseIf Not BaarcodeIndex = CurrentCell.ColumnIndex AndAlso keyData = Keys.Enter Then
                Dim rowindex As Integer = CurrentCell.RowIndex
                Dim columnindex As Integer = CurrentCell.ColumnIndex
                firstcolumnenabled(columnindex, rowindex)
                CurrentCell = Rows(rowindex).Cells(columnindex)
                Return True
            ElseIf keyData = Keys.Enter Then
                OnKeyDown(New KeyEventArgs(Keys.Enter))
            ElseIf keyData = Keys.F11 Then
                Rows.Remove(CurrentRow)
            ElseIf keyData = Keys.F1 Then
                OnKeyDown(New KeyEventArgs(Keys.F1))
            ElseIf keyData = Keys.F12 Then
                OnKeyDown(New KeyEventArgs(Keys.F12))
            Else
                lop2 = True
                Return ProcessDialogKey(keyData)
            End If
        Catch ex As Exception
            lop2 = True
            Return ProcessDialogKey(keyData)
        End Try
    End Function

    Sub firstcolumnenabled(ByRef currcolumn As Integer, ByRef currindex As Integer)
        Try
            Dim newindex As Integer = currindex
            For i As Integer = currcolumn + 1 To Columns.Count - 1
                If Not BaarcodeIndex = i AndAlso Not Columns(i).ReadOnly AndAlso Columns(i).Visible And Not Rows(currindex).Cells(i).ReadOnly AndAlso Rows(currindex).Cells(i).Visible Then
                    currcolumn = i
                    currindex = newindex
                    Return
                End If
            Next
            currcolumn = -1
            currindex += 1
            firstcolumnenabled(currcolumn, currindex)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MyGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If Not BaarcodeIndex = CurrentCell.ColumnIndex AndAlso e.KeyCode = Keys.Enter Then
                Dim rowindex As Integer = CurrentCell.RowIndex
                Dim columnindex As Integer = CurrentCell.ColumnIndex
                firstcolumnenabled(columnindex, rowindex)
                CurrentCell = Rows(rowindex).Cells(columnindex)
                e.Handled = True
            ElseIf e.KeyCode = Keys.F11 Then
                Rows.Remove(CurrentRow)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
