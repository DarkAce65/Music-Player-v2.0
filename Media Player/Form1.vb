Public Class Form1
    Dim Current_User As String
    Dim A As Integer
    Dim TemporaryText As String
    Dim TextFilePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "DataFile.txt")

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        FormFade(Me)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
        Current_User = SystemInformation.UserName
        A = Nothing
        If System.IO.File.Exists(TextFilePath) = False Then
            My.Computer.FileSystem.WriteAllText(TextFilePath, "Media Player Data" + vbNewLine + "Color: Silver" + vbNewLine, False)
        End If
        SetPlayerColor()
    End Sub

    Private Sub Close_Player_Click(sender As System.Object, e As System.EventArgs) Handles Close_Player.Click
        Cursor.Current = Cursors.Default
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Close()
    End Sub

    Private Sub Clear_Library_Click(sender As Object, e As EventArgs) Handles Clear_Library.Click
        Label1.Text = "Media Player     " + Date.Today.ToShortDateString
        Label2.Text = "Selected Song Info"
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        My.Computer.FileSystem.WriteAllText(TextFilePath, "Media Player Data" + vbNewLine + Split(My.Computer.FileSystem.ReadAllText(TextFilePath), vbNewLine)(1), False)
    End Sub

    Private Sub Clear_Playlist_Click(sender As Object, e As EventArgs) Handles Clear_Playlist.Click
        Label1.Text = "Media Player     " + Date.Today.ToShortDateString
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        ListBox2.Items.Clear()
    End Sub

    Private Sub Import_Click(sender As Object, e As EventArgs) Handles Import.Click
        Import.Enabled = False
        Import_Folder.Enabled = False
        Clear_Library.Enabled = False
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each File In OpenFileDialog1.FileNames
                AddMedia(File)
            Next
        End If
        SortMedia()
        Import.Enabled = True
        Import_Folder.Enabled = True
        Clear_Library.Enabled = True
    End Sub

    Private Sub Import_Folder_Click(sender As Object, e As EventArgs) Handles Import_Folder.Click
        Import.Enabled = False
        Import_Folder.Enabled = False
        Clear_Library.Enabled = False
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.CurrentDirectory = FolderBrowserDialog1.SelectedPath
            For Each File In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory, FileIO.SearchOption.SearchAllSubDirectories, "*.mp3", "*.wav", "*.wmv")
                AddMedia(File)
            Next
        End If
        SortMedia()
        Import.Enabled = True
        Import_Folder.Enabled = True
        Clear_Library.Enabled = True
    End Sub

    Private Sub Color_Click(sender As Object, e As EventArgs) Handles Color.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TemporaryText = My.Computer.FileSystem.ReadAllText(TextFilePath)
            TemporaryText = Replace(TemporaryText, Me.BackColor.ToArgb, ColorDialog1.Color.ToArgb, 1, 1)
            My.Computer.FileSystem.WriteAllText(TextFilePath, TemporaryText, False)
            SetPlayerColor()
        End If
    End Sub

    Private Sub Mini_Player_Click(sender As Object, e As System.EventArgs) Handles Mini_Player.Click
        MiniPlayer()
    End Sub

    Private Sub Play_Song_Click(sender As Object, e As EventArgs) Handles Play_Song.Click
        PlayMedia()
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        PlayMedia()
    End Sub

    Private Sub ListBox2_DoubleClick(sender As Object, e As EventArgs) Handles ListBox2.DoubleClick
        PlayMedia()
    End Sub

    Private Sub ListBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ListBox1.SelectedIndex = ListBox1.IndexFromPoint(e.Location)
            If ListBox1.SelectedItem <> "" Then
                ContextMenuStrip1.Show(ListBox1, e.Location)
            End If
        End If
    End Sub

    Private Sub ListBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ListBox2.SelectedIndex = ListBox2.IndexFromPoint(e.Location)
            If ListBox2.SelectedItem <> "" Then
                ContextMenuStrip2.Show(ListBox2, e.Location)
            End If
        End If
    End Sub

    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub

    Private Sub ListBox1_MouseLeave(sender As Object, e As EventArgs) Handles ListBox1.MouseLeave
        Label1.Focus()
    End Sub

    Private Sub ListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedValueChanged
        If ListBox1.SelectedItem <> "" Then
            ListBox2.SelectedItem = Nothing
            SongInfo(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub ListBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedValueChanged
        If ListBox2.SelectedItem <> "" Then
            ListBox1.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        If e.ClickedItem.ToString = "Add to Playlist" Then
            If ListBox1.SelectedItem <> "" And ListBox2.Items.Contains(ListBox1.SelectedItem) = False Then
                ListBox2.Items.Add(ListBox1.SelectedItem)
            End If
        End If
        If e.ClickedItem.ToString = "Play Next" Then
            Try
                If AxWindowsMediaPlayer1.currentMedia.sourceURL <> "" And ListBox2.Items.Count > 0 Then
                    Dim IndexNumber As Integer = ListBox2.Items.IndexOf(IO.Path.GetFileName(AxWindowsMediaPlayer1.currentMedia.sourceURL)) + 1
                    If ListBox1.SelectedItem <> "" And ListBox2.Items.Contains(ListBox1.SelectedItem) = False Then
                        ListBox2.Items.Insert(IndexNumber, ListBox1.SelectedItem)
                    End If
                End If
            Catch ex As Exception
                If ListBox1.SelectedItem <> "" And ListBox2.Items.Contains(ListBox1.SelectedItem) = False Then
                    ListBox2.Items.Add(ListBox1.SelectedItem)
                End If
            End Try
        End If
    End Sub

    Private Sub Shuffle_Click(sender As Object, e As EventArgs) Handles Shuffle.Click
        ShufflePlaylist()
    End Sub

    Private Sub Move_Up_Click(sender As Object, e As System.EventArgs) Handles Move_Up.Click
        If ListBox2.SelectedIndex > 0 Then
            Dim NewIndex = ListBox2.SelectedIndex - 1
            ListBox2.Items.Insert(NewIndex, ListBox2.SelectedItem)
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
            ListBox2.SelectedIndex = NewIndex
        End If
    End Sub

    Private Sub Move_Down_Click(sender As Object, e As System.EventArgs) Handles Move_Down.Click
        If ListBox2.SelectedIndex < ListBox2.Items.Count - 1 Then
            Dim NewIndex = ListBox2.SelectedIndex + 2
            ListBox2.Items.Insert(NewIndex, ListBox2.SelectedItem)
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
            ListBox2.SelectedIndex = NewIndex - 1
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_MediaChange(sender As Object, e As AxWMPLib._WMPOCXEvents_MediaChangeEvent) Handles AxWindowsMediaPlayer1.MediaChange
        Label1.Text = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Title") + " by " + AxWindowsMediaPlayer1.currentMedia.getItemInfo("Artist") + " (" + AxWindowsMediaPlayer1.currentMedia.durationString + ")"
    End Sub
End Class
