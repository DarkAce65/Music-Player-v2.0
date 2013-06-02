<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.Shuffle = New System.Windows.Forms.Button()
        Me.Auto_Play = New System.Windows.Forms.CheckBox()
        Me.Mini_Player = New System.Windows.Forms.Button()
        Me.Clear_Playlist = New System.Windows.Forms.Button()
        Me.Play_Song = New System.Windows.Forms.Button()
        Me.Import_Folder = New System.Windows.Forms.Button()
        Me.Clear_Library = New System.Windows.Forms.Button()
        Me.Import = New System.Windows.Forms.Button()
        Me.Color = New System.Windows.Forms.Button()
        Me.Close_Player = New System.Windows.Forms.Button()
        Me.Move_Down = New System.Windows.Forms.Button()
        Me.Move_Up = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveFromPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Media Player"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Selected Song Info"
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(15, 28)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(376, 228)
        Me.AxWindowsMediaPlayer1.TabIndex = 0
        '
        'Shuffle
        '
        Me.Shuffle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shuffle.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Shuffle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Shuffle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Shuffle.Location = New System.Drawing.Point(431, 304)
        Me.Shuffle.Name = "Shuffle"
        Me.Shuffle.Size = New System.Drawing.Size(100, 24)
        Me.Shuffle.TabIndex = 29
        Me.Shuffle.Text = "Shuffle"
        Me.Shuffle.UseVisualStyleBackColor = True
        '
        'Auto_Play
        '
        Me.Auto_Play.AutoSize = True
        Me.Auto_Play.BackColor = System.Drawing.Color.Transparent
        Me.Auto_Play.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Auto_Play.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Auto_Play.Location = New System.Drawing.Point(431, 278)
        Me.Auto_Play.Name = "Auto_Play"
        Me.Auto_Play.Size = New System.Drawing.Size(85, 20)
        Me.Auto_Play.TabIndex = 28
        Me.Auto_Play.Text = "Auto-Play"
        Me.Auto_Play.UseVisualStyleBackColor = False
        '
        'Mini_Player
        '
        Me.Mini_Player.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Mini_Player.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Mini_Player.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Mini_Player.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Mini_Player.Location = New System.Drawing.Point(325, 334)
        Me.Mini_Player.Name = "Mini_Player"
        Me.Mini_Player.Size = New System.Drawing.Size(100, 50)
        Me.Mini_Player.TabIndex = 30
        Me.Mini_Player.Text = "Switch to Mini-Player"
        Me.Mini_Player.UseVisualStyleBackColor = True
        '
        'Clear_Playlist
        '
        Me.Clear_Playlist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Clear_Playlist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Clear_Playlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Clear_Playlist.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Clear_Playlist.Location = New System.Drawing.Point(431, 334)
        Me.Clear_Playlist.Name = "Clear_Playlist"
        Me.Clear_Playlist.Size = New System.Drawing.Size(100, 50)
        Me.Clear_Playlist.TabIndex = 27
        Me.Clear_Playlist.Text = "Clear Playlist"
        Me.Clear_Playlist.UseVisualStyleBackColor = True
        '
        'Play_Song
        '
        Me.Play_Song.BackColor = System.Drawing.SystemColors.Control
        Me.Play_Song.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Play_Song.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Play_Song.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Play_Song.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Play_Song.Location = New System.Drawing.Point(325, 278)
        Me.Play_Song.Name = "Play_Song"
        Me.Play_Song.Size = New System.Drawing.Size(100, 50)
        Me.Play_Song.TabIndex = 21
        Me.Play_Song.Text = "Play"
        Me.Play_Song.UseVisualStyleBackColor = False
        '
        'Import_Folder
        '
        Me.Import_Folder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Import_Folder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Import_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Import_Folder.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Import_Folder.Location = New System.Drawing.Point(325, 446)
        Me.Import_Folder.Name = "Import_Folder"
        Me.Import_Folder.Size = New System.Drawing.Size(100, 50)
        Me.Import_Folder.TabIndex = 23
        Me.Import_Folder.Text = "Import from Folder..."
        Me.Import_Folder.UseVisualStyleBackColor = True
        '
        'Clear_Library
        '
        Me.Clear_Library.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Clear_Library.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Clear_Library.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Clear_Library.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Clear_Library.Location = New System.Drawing.Point(325, 502)
        Me.Clear_Library.Name = "Clear_Library"
        Me.Clear_Library.Size = New System.Drawing.Size(100, 50)
        Me.Clear_Library.TabIndex = 24
        Me.Clear_Library.Text = "Clear Library"
        Me.Clear_Library.UseVisualStyleBackColor = True
        '
        'Import
        '
        Me.Import.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Import.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Import.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Import.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Import.Location = New System.Drawing.Point(325, 390)
        Me.Import.Name = "Import"
        Me.Import.Size = New System.Drawing.Size(100, 50)
        Me.Import.TabIndex = 22
        Me.Import.Text = "Import..."
        Me.Import.UseVisualStyleBackColor = True
        '
        'Color
        '
        Me.Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Color.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Color.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color.Location = New System.Drawing.Point(431, 390)
        Me.Color.Name = "Color"
        Me.Color.Size = New System.Drawing.Size(100, 50)
        Me.Color.TabIndex = 26
        Me.Color.Text = "Change Player Color"
        Me.Color.UseVisualStyleBackColor = True
        '
        'Close_Player
        '
        Me.Close_Player.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_Player.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Close_Player.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Close_Player.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Close_Player.Location = New System.Drawing.Point(431, 446)
        Me.Close_Player.Name = "Close_Player"
        Me.Close_Player.Size = New System.Drawing.Size(100, 50)
        Me.Close_Player.TabIndex = 25
        Me.Close_Player.Text = "Close"
        Me.Close_Player.UseVisualStyleBackColor = True
        '
        'Move_Down
        '
        Me.Move_Down.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Move_Down.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Move_Down.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Move_Down.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Move_Down.Location = New System.Drawing.Point(602, 80)
        Me.Move_Down.Name = "Move_Down"
        Me.Move_Down.Size = New System.Drawing.Size(20, 30)
        Me.Move_Down.TabIndex = 34
        Me.Move_Down.Text = "˅"
        Me.Move_Down.UseVisualStyleBackColor = True
        '
        'Move_Up
        '
        Me.Move_Up.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Move_Up.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Move_Up.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Move_Up.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Move_Up.Location = New System.Drawing.Point(602, 44)
        Me.Move_Up.Name = "Move_Up"
        Me.Move_Up.Size = New System.Drawing.Size(20, 30)
        Me.Move_Up.TabIndex = 33
        Me.Move_Up.Text = "˄"
        Me.Move_Up.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(394, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Current Playlist"
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Location = New System.Drawing.Point(397, 44)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(199, 212)
        Me.ListBox2.TabIndex = 31
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(15, 278)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(304, 274)
        Me.ListBox1.TabIndex = 35
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Audio/Video Files (*.mp3;*.wav;*.wmv)|*.mp3;*.wav;*.wmv"
        Me.OpenFileDialog1.Title = "Open Audio Files..."
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select Folder..."
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.UserProfile
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.AddToPlaylistToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.ToolStripMenuItem1.Text = "Play Next"
        '
        'AddToPlaylistToolStripMenuItem
        '
        Me.AddToPlaylistToolStripMenuItem.Name = "AddToPlaylistToolStripMenuItem"
        Me.AddToPlaylistToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AddToPlaylistToolStripMenuItem.Text = "Add to Playlist"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveFromPlaylistToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(187, 26)
        '
        'RemoveFromPlaylistToolStripMenuItem
        '
        Me.RemoveFromPlaylistToolStripMenuItem.Name = "RemoveFromPlaylistToolStripMenuItem"
        Me.RemoveFromPlaylistToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.RemoveFromPlaylistToolStripMenuItem.Text = "Remove from Playlist"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(728, 603)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Move_Down)
        Me.Controls.Add(Me.Move_Up)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Shuffle)
        Me.Controls.Add(Me.Auto_Play)
        Me.Controls.Add(Me.Mini_Player)
        Me.Controls.Add(Me.Clear_Playlist)
        Me.Controls.Add(Me.Play_Song)
        Me.Controls.Add(Me.Import_Folder)
        Me.Controls.Add(Me.Clear_Library)
        Me.Controls.Add(Me.Import)
        Me.Controls.Add(Me.Color)
        Me.Controls.Add(Me.Close_Player)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Shuffle As System.Windows.Forms.Button
    Friend WithEvents Auto_Play As System.Windows.Forms.CheckBox
    Friend WithEvents Mini_Player As System.Windows.Forms.Button
    Friend WithEvents Clear_Playlist As System.Windows.Forms.Button
    Friend WithEvents Play_Song As System.Windows.Forms.Button
    Friend WithEvents Import_Folder As System.Windows.Forms.Button
    Friend WithEvents Clear_Library As System.Windows.Forms.Button
    Friend WithEvents Import As System.Windows.Forms.Button
    Friend WithEvents Color As System.Windows.Forms.Button
    Friend WithEvents Close_Player As System.Windows.Forms.Button
    Friend WithEvents Move_Down As System.Windows.Forms.Button
    Friend WithEvents Move_Up As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToPlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveFromPlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
