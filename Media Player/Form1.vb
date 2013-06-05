﻿Public Class Form1
    Dim Current_User As String
    Dim A As Integer
    Dim TemporaryText As String

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Form_Fade(Me)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
        Current_User = SystemInformation.UserName
        A = Nothing
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
        Import.Enabled = True
        Import_Folder.Enabled = True
        Clear_Library.Enabled = True
    End Sub

    Private Sub Clear_Library_Click(sender As Object, e As EventArgs) Handles Clear_Library.Click
        My.Computer.FileSystem.WriteAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"), "Media Player Data", False)
    End Sub

    Private Sub Color_Click(sender As Object, e As EventArgs) Handles Color.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TemporaryText = My.Computer.FileSystem.ReadAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"))
            TemporaryText = Replace(TemporaryText, Me.BackColor.ToArgb, ColorDialog1.Color.ToArgb, 1, 1)
            My.Computer.FileSystem.WriteAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"), TemporaryText, False)
            SetPlayerColor()
        End If
    End Sub
End Class
