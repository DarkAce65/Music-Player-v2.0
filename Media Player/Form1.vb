Public Class Form1
    Dim Current_User As String
    Dim A As Integer

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Enabled = False
        For A As Single = 100 To 0 Step -1
            Me.Opacity = A / 100
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Current_User = SystemInformation.UserName
        Auto_Play.Checked = True
        A = Nothing
        OpenFileDialog1.Multiselect = True
        If System.IO.File.Exists(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt")) = False Then
            My.Computer.FileSystem.WriteAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"), "Media Player Data" + vbNewLine + "Color: Silver" + vbNewLine, False)
        End If
        SetPlayerColor()
    End Sub

    Private Sub Close_Player_Click(sender As System.Object, e As System.EventArgs) Handles Close_Player.Click
        Cursor.Current = Cursors.Default
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Close()
    End Sub

    Private Sub Import_Click(sender As Object, e As EventArgs) Handles Import.Click
        Import.Enabled = False
        Import_Folder.Enabled = False
        Clear_Library.Enabled = False
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each File In OpenFileDialog1.FileNames
                My.Computer.FileSystem.WriteAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"), vbNewLine + "File Name" + " === " + File, True)
            Next
        End If
        MsgBox(My.Computer.FileSystem.ReadAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt")))
        Import.Enabled = True
        Import_Folder.Enabled = True
        Clear_Library.Enabled = True
    End Sub

    Private Sub Clear_Library_Click(sender As Object, e As EventArgs) Handles Clear_Library.Click
        My.Computer.FileSystem.WriteAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"), "Media Player Data", False)
    End Sub

    Private Sub Color_Click(sender As Object, e As EventArgs) Handles Color.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            SetPlayerColor()
        End If
    End Sub
End Class
