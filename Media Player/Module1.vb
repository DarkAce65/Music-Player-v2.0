Module Module1
    Function SetPlayerColor()
        Dim ColorChange As Color = Color.FromName(Replace(Split(My.Computer.FileSystem.ReadAllText(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt")), vbNewLine, 2)(1), "Color: ", ""))
        Try
            Form1.ListBox1.BackColor = ColorChange
            Form1.ListBox2.BackColor = ColorChange
            Form1.BackColor = ColorChange
        Catch ex As Exception
            MsgBox("Error" + vbNewLine + "Invalid color selected.", MsgBoxStyle.Critical)
            Form1.ListBox1.BackColor = Color.Silver
            Form1.ListBox2.BackColor = Color.Silver
            Form1.BackColor = Color.Silver
        End Try
    End Function
End Module
