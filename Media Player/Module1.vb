Module Module1
    Dim TextFilePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt")

    Function Initialize()
        Form1.Label1.Text = "Media Player     " + Date.Today.ToShortDateString
        Form1.Label2.Text = "Selected Song Info"
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

    Function MiniPlayer()
        If Form1.Close_Player.Visible = True Then
            For Each Ctrl As Control In Form1.Controls
                Ctrl.Visible = False
            Next
            Form1.Label1.Visible = True
            Form1.AxWindowsMediaPlayer1.Visible = True
            Form1.Mini_Player.Visible = True
            Form1.AxWindowsMediaPlayer1.Height = 45
            Form1.Mini_Player.Location = New Point(15, 79)
            Form1.Mini_Player.Size = New Size(200, 25)
            Form1.Mini_Player.Text = "Switch to Full-Player"
            Form1.Refresh()
        Else
            For Each Ctrl As Control In Form1.Controls
                Ctrl.Visible = True
            Next
            Form1.AxWindowsMediaPlayer1.Height = 228
            Form1.Mini_Player.Location = New Point(325, 334)
            Form1.Mini_Player.Size = New Size(100, 50)
            Form1.Mini_Player.Text = "Switch to Mini-Player"
            Form1.Refresh()
        End If
    End Function

    Function PlayMedia()
        If Form1.ListBox1.SelectedItem <> "" Then
            Form1.ListBox2.Items.Clear()
            Form1.ListBox2.Items.Add(Form1.ListBox1.SelectedItem)
            Form1.AxWindowsMediaPlayer1.URL = Split(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(Form1.ListBox1.SelectedIndex + 2), " === ")(1)
        ElseIf Form1.ListBox2.SelectedItem <> "" Then
            Form1.AxWindowsMediaPlayer1.URL = Split(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(Form1.ListBox1.Items.IndexOf(Form1.ListBox2.SelectedItem) + 2), " === ")(1)
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

    Function RemoveFromPlaylist()
        If Form1.ListBox2.SelectedItem <> "" Then
            Dim Next_Delete As Integer = Form1.ListBox2.SelectedIndex
            If Form1.ListBox2.Items.Count = 1 Then
                Form1.ListBox2.Items.Clear()
                Form1.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                Form1.Label1.Text = "Media Player"
            Else
                If Form1.AxWindowsMediaPlayer1.currentMedia.sourceURL <> "" Then
                    If Form1.ListBox2.SelectedItem = IO.Path.GetFileName(Form1.AxWindowsMediaPlayer1.currentMedia.sourceURL) Then
                        Form1.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                        Try
                            Form1.ListBox2.SelectedIndex = Next_Delete + 1
                        Catch ex As Exception
                            Form1.ListBox2.SelectedIndex = 0
                        End Try
                        Form1.AxWindowsMediaPlayer1.URL = Split(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(Form1.ListBox1.Items.IndexOf(Form1.ListBox2.SelectedItem) + 2), " === ")(1)
                    End If
                End If
                Form1.ListBox2.SelectedIndex = Next_Delete
                Form1.ListBox2.Items.Remove(Form1.ListBox2.SelectedItem)
                End If
        End If
    End Function

    Function NextItem()
        If Form1.ListBox2.Items.IndexOf(IO.Path.GetFileName(Form1.AxWindowsMediaPlayer1.currentMedia.sourceURL)) + 2 > Form1.ListBox2.Items.Count Then
            Form1.ListBox2.SelectedIndex = 0
        Else
            Form1.ListBox2.SelectedIndex = Form1.ListBox2.Items.IndexOf(IO.Path.GetFileName(Form1.AxWindowsMediaPlayer1.currentMedia.sourceURL)) + 1
        End If
        Form1.AxWindowsMediaPlayer1.URL = Split(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(Form1.ListBox1.Items.IndexOf(Form1.ListBox2.SelectedItem) + 2), " === ")(1)
        Form1.PlayNext.RunWorkerAsync()
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

    Function Duration(Minutes)
        Dim FinalDuration As String = Nothing
        If Minutes > 60 And Math.Round(((Minutes - Math.Floor(Minutes)) * 60)) > 10 Then
            FinalDuration = Math.Floor(Minutes / 60).ToString + ":"
        ElseIf Minutes > 60 And Math.Round(((Minutes - Math.Floor(Minutes)) * 60)) < 10 Then
            FinalDuration = Math.Floor(Minutes / 60).ToString + ":0"
        End If
        If Math.Round(((Minutes - Math.Floor(Minutes)) * 60)) > 10 Then
            FinalDuration = FinalDuration + Math.Floor(Minutes).ToString + ":" + Math.Round(((Minutes - Math.Floor(Minutes)) * 60)).ToString
        Else
            FinalDuration = FinalDuration + Math.Floor(Minutes).ToString + ":0" + Math.Round(((Minutes - Math.Floor(Minutes)) * 60)).ToString
        End If
        Return FinalDuration
    End Function

    Function SongInfo(Index)
        Dim Info As TagLib.File = TagLib.File.Create(Split(Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(Form1.ListBox1.SelectedIndex + 2), " === ")(1))
        If Info.Tag.Performers.Length > 0 Then
            If Info.Tag.Title = Nothing Then
                Form1.Label2.Text = Info.Name + " by " + Info.Tag.Performers(0) + " (" + Duration(Info.Properties.Duration.TotalMinutes) + ")"
            Else
                Form1.Label2.Text = Info.Tag.Title + " by " + Info.Tag.Performers(0) + " (" + Duration(Info.Properties.Duration.TotalMinutes) + ")"
            End If
        Else
            If Info.Tag.Title = Nothing Then
                Form1.Label2.Text = Info.Name + " (" + Duration(Info.Properties.Duration.TotalMinutes) + ")"
            Else
                Form1.Label2.Text = Info.Tag.Title + " (" + Duration(Info.Properties.Duration.TotalMinutes) + ")"
            End If
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