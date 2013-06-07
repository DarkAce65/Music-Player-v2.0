Module Module1
    Dim TextFilePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt")

    Function Initialize()
        Form1.Label1.Text = "Media Player     " + Date.Today.ToShortDateString
        Form1.Auto_Play.Checked = True
        Form1.OpenFileDialog1.Multiselect = True
        Form1.AxWindowsMediaPlayer1.settings.volume = 100
        If Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine).Length > 2 Then
            Dim Files As Array = Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine).Skip(2).ToArray
            For Each Media_Item In Files
                Form1.ListBox1.Items.Add(Split(Media_Item, " === ")(0))
            Next
        End If
    End Function

    Function PlayMedia()
        If Form1.ListBox1.SelectedItem <> "" Then
            Form1.ListBox2.Items.Clear()
            Form1.ListBox2.Items.Add(Form1.ListBox1.SelectedItem)
            Form1.AxWindowsMediaPlayer1.URL = Split(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(Form1.ListBox1.SelectedIndex + 2), " === ")(1)
        End If
    End Function

    Function AddMedia(File)
        If Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine).Contains(IO.Path.GetFileName(File) + " === " + File) = False Then
            My.Computer.FileSystem.WriteAllText(TextFilePath, vbNewLine + IO.Path.GetFileName(File) + " === " + File, True)
            Form1.ListBox1.Items.Add(IO.Path.GetFileName(File))
        End If
    End Function

    Function SortMedia()
        Dim TemporaryArray As Array = Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine).Skip(2).ToArray
        Dim TemporaryText As String = Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(0) + vbNewLine + Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(1)
        My.Computer.FileSystem.WriteAllText(TextFilePath, TemporaryText, False)
        Array.Sort(TemporaryArray)
        For Each Item In TemporaryArray
            My.Computer.FileSystem.WriteAllText(TextFilePath, vbNewLine + Item, True)
        Next
        Form1.ListBox1.Sorted = True
    End Function

    Function ShufflePlaylist()
        Dim Selected_Media As String
        Dim Shuffled_Index As Integer
        Dim Shuffle_Playlist As New Collection
        If Form1.ListBox2.SelectedItem <> "" Then
            Selected_Media = Form1.ListBox2.SelectedItem
        Else
            Selected_Media = Nothing
        End If
        Form1.ListBox2.BeginUpdate()
        For Initial_Index As Integer = 0 To (Form1.ListBox2.Items.Count - 1)
            Shuffle_Playlist.Add(Form1.ListBox2.Items.Item(Initial_Index))
        Next
        Form1.ListBox2.Items.Clear()
        Do While Shuffle_Playlist.Count
            Randomize()
            Shuffled_Index = Int((Shuffle_Playlist.Count * Rnd()) + 1)
            Form1.ListBox2.Items.Add(Shuffle_Playlist(Shuffled_Index))
            Shuffle_Playlist.Remove(Shuffled_Index)
        Loop
        Form1.ListBox2.EndUpdate()
        If Not Selected_Media = Nothing Then
            Form1.ListBox2.SelectedItem = Selected_Media
        End If
    End Function

    Function SetPlayerColor()
        Try
            Dim ColorChange As Color = Color.FromArgb(Replace(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(1), "Color: ", ""))
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
            Dim TemporaryText As String = My.Computer.FileSystem.ReadAllText(TextFilePath)
            TemporaryText = Replace(TemporaryText, Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(1), "Color: " + Color.Silver.ToArgb.ToString)
            My.Computer.FileSystem.WriteAllText(TextFilePath, TemporaryText, False)
        End Try
    End Function

    Function SongInfo(Index)
        Dim Info As TagLib.File = TagLib.File.Create(Split(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(Form1.ListBox1.SelectedIndex + 2), " === ")(1))
        If Info.Tag.Performers.Length > 0 Then
            Form1.Label2.Text = Info.Tag.Title + " by " + Info.Tag.Performers(0) + " (" + Info.Properties.Duration.ToString + ")"
        Else
            Form1.Label2.Text = Info.Tag.Title + " (" + Info.Properties.Duration.ToString + ")"
        End If
    End Function

    Function FormFade(Form)
        Form.Enabled = False
        For A As Single = 100 To 0 Step -1
            Form.Opacity = A / 100
            Form.Refresh()
        Next
    End Function
End Module