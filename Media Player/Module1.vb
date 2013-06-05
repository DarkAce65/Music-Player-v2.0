Module Module1

    Function Initialize()
        Form1.Label1.Text = "Media Player     " + Date.Today.ToShortDateString
        Form1.Auto_Play.Checked = True
        Form1.OpenFileDialog1.Multiselect = True
    End Function

    Function SetPlayerColor()
        Try
            Dim ColorChange As Color = Color.FromArgb(Replace(Split(My.Computer.FileSystem.ReadAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt")), vbNewLine, 2)(1), "Color: ", ""))
            Form1.ListBox1.BackColor = ColorChange
            Form1.ListBox2.BackColor = ColorChange
            Form1.BackColor = ColorChange
            If ColorChange.GetBrightness > (1 / 3) Then
                Form1.Label1.ForeColor = Drawing.Color.Black
                Form1.Label2.ForeColor = Drawing.Color.Black
                Form1.Label3.ForeColor = Drawing.Color.Black
                Form1.ListBox1.ForeColor = Drawing.Color.Black
                Form1.ListBox2.ForeColor = Drawing.Color.Black
                Form1.Auto_Play.ForeColor = Drawing.Color.Black
            Else
                Form1.Label1.ForeColor = Drawing.Color.White
                Form1.Label2.ForeColor = Drawing.Color.White
                Form1.Label3.ForeColor = Drawing.Color.White
                Form1.ListBox1.ForeColor = Drawing.Color.White
                Form1.ListBox2.ForeColor = Drawing.Color.White
                Form1.Auto_Play.ForeColor = Drawing.Color.White
            End If
        Catch ex As Exception
            MsgBox("Error" + vbNewLine + "Invalid color.", MsgBoxStyle.Critical)
            Form1.ListBox1.BackColor = Color.Silver
            Form1.ListBox2.BackColor = Color.Silver
            Form1.BackColor = Color.Silver
            Dim TemporaryText As String = My.Computer.FileSystem.ReadAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"))
            TemporaryText = Replace(TemporaryText, Split(TemporaryText, vbNewLine, 2)(1), "Color: " + Form1.BackColor.ToArgb.ToString, 1, 1)
            My.Computer.FileSystem.WriteAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt"), TemporaryText, False)
        End Try
    End Function

    Function Form_Fade(ByRef Form As Form)
        Form.Enabled = False
        For A As Single = 100 To 0 Step -1
            Form.Opacity = A / 100
            Form.Refresh()
        Next
    End Function
End Module
