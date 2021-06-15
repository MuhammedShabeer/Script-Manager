Imports System.IO
Imports System.Xml
Public Class frmScriptSearch
    Dim dtPathData As New DataTable
    Dim dtSerachedTextData As New DataTable
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\BackgroundDefault.jpg") Then
                btnBrowseImage.Tag = AppDomain.CurrentDomain.BaseDirectory & "\BackgroundDefault.jpg"
            End If

            If File.Exists("Settings.xml") Then
                ReadSettingsXml()
            Else
                CreateSettingsXml()
            End If
            SettingsPanel.Location = New System.Drawing.Point(btnSettings.Location.X, btnSettings.Location.Y + 33)
            changeSettings()
            btnSaveSettings_Click(btnSaveSettings, New EventArgs)
            dtPathData.Columns.AddRange(New DataColumn(1) {New DataColumn("Path"), New DataColumn("CreatedDate", GetType(Date))})
            dtSerachedTextData.Columns.AddRange(New DataColumn(2) {New DataColumn("Path"), New DataColumn("Line"), New DataColumn("CreatedDate", GetType(Date))})
            If chkLoadDirectory.Checked Then btnfindDirectory_Click(sender, e)
            DataGridView1.AutoGenerateColumns = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnfindDirectory_Click(sender As Object, e As EventArgs) Handles btnfindDirectory.Click
        Try
            directoryTree.Nodes.Clear()
            dtPathData.Rows.Clear()
            If Directory.Exists(txtDirectory.Text) Then
                directoryTree.Nodes.Add(txtDirectory.Text)
                populateTreeView(txtDirectory.Text, directoryTree.Nodes(0))
            End If
            DataGridView1.DataSource = dtPathData
            ToolStripStatusLabel1.Text = FileCount & " Files found"
        Catch ex As Exception
        Finally
            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Maximum = 0
            FileCount = 0
        End Try
    End Sub
    Dim FileCount As Integer = 0
    Private Sub populateTreeView(directoryPath As String, parentNode As TreeNode)
        Try
            If Directory.Exists(txtDirectory.Text) Then
                Dim strDirecoryArray As String() = Directory.GetDirectories(directoryPath)
                If strDirecoryArray.Length <= 0 Then
                    strDirecoryArray = Directory.GetFiles(directoryPath, IIf(txtExtention.Text.Trim = "", "*", txtExtention.Text.Trim), SearchOption.AllDirectories)
                    FileCount = FileCount + strDirecoryArray.Length
                End If
                If strDirecoryArray.Length > 0 Then
                    ToolStripProgressBar1.Maximum = ToolStripProgressBar1.Maximum + strDirecoryArray.Length
                    For Each directory As String In strDirecoryArray
                        Dim NodeName As String = Path.GetFileNameWithoutExtension(directory)
                        Dim childNode As TreeNode = New TreeNode(NodeName)
                        childNode.Tag = directory
                        parentNode.Nodes.Add(childNode)
                        If File.Exists(directory) Then dtPathData.Rows.Add(directory, New FileInfo(directory).CreationTime)
                        populateTreeView(directory, childNode)
                        ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub OpenFile()
        Try
            Dim strPath As String = ""
            If TabControl1.SelectedIndex = 0 Then
                If directoryTree.SelectedNode.Tag Is Nothing Then Exit Sub
                strPath = directoryTree.SelectedNode.Tag
            ElseIf TabControl1.SelectedIndex = 1 Then
                If DataGridView1.CurrentCell.Value Is Nothing Then Exit Sub
                strPath = DataGridView1.CurrentCell.Value
            End If
            If File.Exists(strPath) Then
                RichTextBox1.Tag = Nothing
                Me.Cursor = Cursors.WaitCursor
                RichTextBox1.Text = ""
                Using read As IO.StreamReader = IO.File.OpenText(strPath)
                    RichTextBox1.Text = read.ReadToEnd()
                    read.Close()
                End Using
                Dim word As String = txtSearchText.Text
                If word <> "" Then
                    Dim startindex As Integer = 0
                    While startindex < RichTextBox1.TextLength
                        Dim wordstartIndex As Integer = RichTextBox1.Find(word, startindex, RichTextBoxFinds.None)
                        If wordstartIndex <> -1 Then
                            RichTextBox1.SelectionStart = wordstartIndex
                            RichTextBox1.SelectionLength = word.Length
                            RichTextBox1.SelectionBackColor = btnRichTextBoxHighlightFontColour.BackColor
                        Else
                            Exit While
                        End If
                        startindex += wordstartIndex + word.Length
                    End While
                End If
                _startindex = 0
                RichTextBox1.Tag = strPath
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private CurrentNodeMatches As List(Of TreeNode) = New List(Of TreeNode)()
    Private LastNodeIndex As Integer = 0
    Private LastSearchFile As String
    Private Sub FindNode(sender As Object, e As EventArgs) Handles btnFindFile.Click
        Try
            If TabControl1.SelectedIndex = 0 Then
                Dim searchText As String = txtFileName.Text
                If String.IsNullOrEmpty(searchText) Then
                    btnfindDirectory_Click(sender, e)
                    Exit Sub
                End If
                If LastSearchFile <> searchText Then
                    CurrentNodeMatches.Clear()
                    LastSearchFile = searchText
                    LastNodeIndex = 0
                    SearchNodes(searchText, directoryTree.Nodes(0))
                End If
                If LastNodeIndex >= 0 AndAlso CurrentNodeMatches.Count > 0 AndAlso LastNodeIndex < CurrentNodeMatches.Count Then
                    Dim selectedNode As TreeNode = CurrentNodeMatches(LastNodeIndex)
                    LastNodeIndex += 1
                    directoryTree.SelectedNode = selectedNode
                    directoryTree.SelectedNode.Expand()
                    directoryTree.[Select]()
                Else
                    If LastNodeIndex = CurrentNodeMatches.Count Then
                        If LastNodeIndex = 0 Then
                            MsgBox("Nothing to show", MsgBoxStyle.Information)
                            Exit Sub
                        End If
                        MsgBox("Find reached the starting point of search", MsgBoxStyle.Information)
                        LastNodeIndex = 0
                    End If
                End If
                ToolStripStatusLabel1.Text = CurrentNodeMatches.Count & " Files found"
            ElseIf TabControl1.SelectedIndex = 1 Then
                Dim dtFilter As DataTable = New DataView(dtPathData, "Path like '%" & txtFileName.Text.Trim & "%'", "CreatedDate", DataViewRowState.CurrentRows).ToTable()
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = dtFilter
                DataGridView1.Refresh()
                ToolStripStatusLabel1.Text = dtFilter.Rows.Count & " Files found"
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub SearchNodes(ByVal SearchText As String, ByVal StartNode As TreeNode, Optional ByVal FindPath As Boolean = False)
        Try
            Dim node As TreeNode = Nothing
            While StartNode IsNot Nothing
                If Not FindPath Then
                    If String.Compare(StartNode.Text, SearchText, True) Then
                        ' StartNode.Text.ToLower().Contains(SearchText.ToLower()) 
                        CurrentNodeMatches.Add(StartNode)
                    End If
                Else
                    If StartNode.Tag = SearchText Then
                        SearchTextCurrentNodeMatches.Add(StartNode)
                    End If
                End If
                If StartNode.Nodes.Count <> 0 Then
                    SearchNodes(SearchText, StartNode.Nodes(0), FindPath)
                End If
                StartNode = StartNode.NextNode
            End While
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            OpenFile()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If DataGridView1.CurrentCell.OwningColumn.Name = "ColPath" Then OpenFile()
            If DataGridView1.CurrentCell.OwningColumn.Name = "ColOpen" Then ToolStripMenuItem2_Click(sender, New EventArgs)
            ToolStripStatusLabel1.Text = "File name :" & Path.GetFileNameWithoutExtension(DataGridView1.Rows(e.RowIndex).Cells("ColPath").Value)
            If Not IsNothing(CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView).Item("Line")) Then
                btnSearchInFile_Click(sender, New EventArgs, CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView).Item("Line"))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            Dim strPath As String = ""
            If TabControl1.SelectedIndex = 0 Then
                If directoryTree.SelectedNode.Tag Is Nothing Then Exit Sub
                strPath = directoryTree.SelectedNode.Tag
            ElseIf TabControl1.SelectedIndex = 1 Then
                If DataGridView1.CurrentRow.Cells("ColPath").Value Is Nothing Then Exit Sub
                strPath = DataGridView1.CurrentRow.Cells("ColPath").Value
            End If
            If File.Exists(strPath) Then
                Process.Start(strPath)
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Try
            SettingsPanel.Visible = Not SettingsPanel.Visible
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FindControlRecursive(ByVal parent As Control)
        Try
            If parent Is Nothing Then Exit Sub
            If txtFont.Text = "" Then Exit Sub
            Dim strFont() As String = txtFont.Text.Split(",")
            Try
                parent.Font = New System.Drawing.Font(strFont(0), CInt(strFont(1)))
                parent.ForeColor = btnAppFontColour.BackColor
            Catch ex As Exception
            End Try
            If File.Exists(btnBrowseImage.Tag) Then
                If ((parent.GetType() Is GetType(Panel)) Or parent.GetType() Is GetType(GroupBox) Or parent.GetType() Is GetType(SplitContainer) _
                   Or (parent.GetType() Is GetType(Button)) Or (parent.GetType() Is GetType(StatusStrip))) And Not parent.Name = "btnSettings" _
                   And Not parent.Name = "btnAppFontColour" And Not parent.Name = "btnTextWindowFontColour" And Not parent.Name = "btnRichTextBoxFontColour" _
                   And Not parent.Name = "btnRichTextBoxHighlightFontColour" And Not parent.Name = "btnTextWindowHighLightColour" Then
                    parent.BackgroundImage = New Bitmap(Image.FromFile(btnBrowseImage.Tag))
                End If
            End If
            For Each child As Control In parent.Controls
                FindControlRecursive(child)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub changeSettings()
        Try
            txtDirectory.Text = txtDefultDirectory.Text
            txtRichBoxFont.Text = txtTextWindowFontSettings.Text
            btnRichTextBoxFontColour.BackColor = btnTextWindowFontColour.BackColor
            RichTextBox1.ForeColor = btnRichTextBoxFontColour.BackColor
            btnRichTextBoxHighlightFontColour.BackColor = btnTextWindowHighLightColour.BackColor
            FindControlRecursive(Me)
            txtRichBoxFont_TextChanged(Nothing, New EventArgs)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Try
            If File.Exists("Settings.xml") Then
                UpdateSettingsXml()
            Else
                CreateSettingsXml()
            End If
            changeSettings()
            SettingsPanel.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSetttingClear_Click(sender As Object, e As EventArgs) Handles btnSetttingClear.Click
        Try
            txtDefultDirectory.Text = ""
            txtFont.Text = ""
            txtExtention.Text = ""
            btnBrowseImage.Tag = ""
            btnBrowseImage.Text = "&Browse"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            If DataGridView1.CurrentCell.OwningColumn.Name = "ColPath" Then
                OpenFile()
                ToolStripStatusLabel1.Text = "File name :" & Path.GetFileNameWithoutExtension(DataGridView1.CurrentCell.Value)
            End If
            If Not IsNothing(CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView).Item("Line")) Then
                btnSearchInFile_Click(sender, New EventArgs, CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView).Item("Line"))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnRestoreSettings_Click(sender As Object, e As EventArgs) Handles btnRestoreSettings.Click
        Try
            txtDefultDirectory.Text = "D:\DESKTOP\Sql - Scripts\From Year 2021"
            txtExtention.Text = " *.sql"
            txtFont.Text = "Microsoft Sans Serif, 10"
            chkLoadDirectory.CheckState = CheckState.Checked
            changeSettings()
        Catch ex As Exception
        End Try
    End Sub
    Private SearchTextCurrentNodeMatches As List(Of TreeNode) = New List(Of TreeNode)()
    Private SearchTextLastNodeIndex As Integer = 0
    Private SearchTextLastSearchtext As String
    Private Sub btnSearchText_Click(sender As Object, e As EventArgs) Handles btnSearchText.Click
        Try
            Dim searchText As String = txtSearchText.Text
            If String.IsNullOrEmpty(searchText) Then
                btnfindDirectory_Click(sender, e)
                Exit Sub
            End If
            If SearchTextLastSearchtext <> searchText Then
                SearchTextCurrentNodeMatches.Clear()
                SearchTextLastSearchtext = searchText
                SearchTextLastNodeIndex = 0
                dtSerachedTextData.Rows.Clear()
                For Each row As DataRow In dtPathData.Rows
                    Using read As IO.StreamReader = IO.File.OpenText(row("Path"))
                        While Not read.EndOfStream
                            Dim line As String = read.ReadLine()
                            Dim LineCompare As String = line
                            If LineCompare.ToUpper().Contains(txtSearchText.Text.ToUpper) Then
                                dtSerachedTextData.Rows.Add(row("Path"), line, New FileInfo(row("Path")).CreationTime)
                                SearchNodes(row("Path"), directoryTree.Nodes(0), True)
                            End If
                        End While
                    End Using
                Next
            End If
            If TabControl1.SelectedIndex = 0 Then
                If SearchTextLastNodeIndex >= 0 AndAlso SearchTextCurrentNodeMatches.Count > 0 AndAlso SearchTextLastNodeIndex < SearchTextCurrentNodeMatches.Count Then
                    Dim selectedNode As TreeNode = SearchTextCurrentNodeMatches(SearchTextLastNodeIndex)
                    SearchTextLastNodeIndex += 1
                    Try
                        If RichTextBox1.Tag = directoryTree.SelectedNode.Tag And directoryTree.SelectedNode.Text = selectedNode.Text Then
                            btnSearchInFile_Click(sender, e)
                            ToolStripStatusLabel1.Text = "Searching in " & directoryTree.SelectedNode.Text
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try
                    directoryTree.SelectedNode = selectedNode
                    directoryTree.SelectedNode.Expand()
                    directoryTree.[Select]()
                Else
                    If SearchTextLastNodeIndex = SearchTextCurrentNodeMatches.Count Then
                        If SearchTextLastNodeIndex = 0 Then
                            MsgBox("Nothing to show", MsgBoxStyle.Information)
                            Exit Sub
                        End If
                        MsgBox("Find reached the starting point of search", MsgBoxStyle.Information)
                        SearchTextLastNodeIndex = 0
                    End If
                End If
            End If
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = dtSerachedTextData
            DataGridView1.Refresh()
            ToolStripStatusLabel1.Text = SearchTextCurrentNodeMatches.Count & " Text found"
            btnSearchInFile_Click(sender, e)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub directoryTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles directoryTree.AfterSelect
        Try
            OpenFile()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtDirectory_TextChanged(sender As Object, e As EventArgs) Handles txtDirectory.TextChanged
        Try
            txtFileName.Text = ""
            CurrentNodeMatches.Clear()
            LastSearchFile = ""
            LastNodeIndex = 0
            txtSearchText.Text = ""
            SearchTextCurrentNodeMatches.Clear()
            SearchTextLastSearchtext = ""
            SearchTextLastNodeIndex = 0
            dtSerachedTextData.Rows.Clear()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtFileName_TextChanged(sender As Object, e As EventArgs) Handles txtFileName.TextChanged
        Try
            txtSearchText.Text = ""
            SearchTextCurrentNodeMatches.Clear()
            SearchTextLastSearchtext = ""
            SearchTextLastNodeIndex = 0
            dtSerachedTextData.Rows.Clear()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtSearchText_TextChanged(sender As Object, e As EventArgs) Handles txtSearchText.TextChanged
        Try
            If txtSearchText.Text = "" Then
                FindNode(sender, e)
            Else
                txtRichTextBoxSearch.Text = ""
                OpenFile()
            End If
            RichTextBox1.Clear()
            _startindex = 0
        Catch ex As Exception
        End Try
    End Sub
    Dim _startindex As Integer = 0
    Private Sub btnSearchInFile_Click(sender As Object, e As EventArgs, Optional ByVal SearchText As String = "")
        Try
            Dim word As String = IIf(SearchText = "", txtSearchText.Text, SearchText)
            If word <> "" Then
                If SearchText <> "" Then
                    Dim wordstartIndex As Integer = RichTextBox1.Find(word, 0, RichTextBoxFinds.None)
                    If wordstartIndex <> -1 Then
                        RichTextBox1.SelectionStart = wordstartIndex
                        RichTextBox1.ScrollToCaret()
                        RichTextBox1.SelectionStart = RichTextBox1.Find(txtSearchText.Text, wordstartIndex, RichTextBoxFinds.None)
                        RichTextBox1.SelectionBackColor = btnRichTextBoxHighlightFontColour.BackColor
                    End If
                Else
                    If _startindex < RichTextBox1.TextLength Then
                        Dim wordstartIndex As Integer = RichTextBox1.Find(word, _startindex, RichTextBoxFinds.None)
                        If wordstartIndex <> -1 Then
                            RichTextBox1.SelectionStart = wordstartIndex
                            RichTextBox1.SelectionBackColor = btnRichTextBoxHighlightFontColour.BackColor
                            RichTextBox1.ScrollToCaret()
                        Else
                            _startindex = 0
                            '  btnSearchInFile_Click(sender, e)
                            Exit Sub
                        End If
                        _startindex += wordstartIndex + word.Length
                    End If
                    If _startindex > RichTextBox1.TextLength Then _startindex = 0
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As EventArgs) Handles DataGridView1.DataSourceChanged
        Try
            'For i As Integer = 0 To DataGridView1.Rows.Count - 1
            '    DataGridView1.Rows(i).HeaderCell.Value = Path.GetFileNameWithoutExtension(DataGridView1.Rows(i).Cells("ColPath").Value)
            'Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CreateSettingsXml()
        Try
            Using writer As New XmlTextWriter("Settings.xml", System.Text.Encoding.UTF8)
                With writer
                    .WriteStartDocument(True)
                    .Formatting = Formatting.Indented
                    .Indentation = 2
                    .WriteStartElement("Settings")
                    .WriteStartElement("DefultDirectory")
                    .WriteString(txtDefultDirectory.Text)
                    .WriteEndElement()
                    .WriteStartElement("Extention")
                    .WriteString(txtExtention.Text)
                    .WriteEndElement()
                    .WriteStartElement("Font")
                    .WriteString(txtFont.Text)
                    .WriteEndElement()
                    .WriteStartElement("LoadDirectory")
                    .WriteString(chkLoadDirectory.CheckState)
                    .WriteEndElement()
                    .WriteStartElement("BackGroundImage")
                    .WriteString(IIf(btnBrowseImage.Tag Is Nothing, "", btnBrowseImage.Tag))
                    .WriteEndElement()
                    .WriteStartElement("FontColor")
                    .WriteString(btnAppFontColour.BackColor.ToArgb)
                    .WriteEndElement()
                    .WriteStartElement("TextWindowFont")
                    .WriteString(txtTextWindowFontSettings.Text.Trim)
                    .WriteEndElement()
                    .WriteStartElement("TextWindowFontcolor")
                    .WriteString(btnTextWindowFontColour.BackColor.ToArgb)
                    .WriteEndElement()
                    .WriteStartElement("TextWindowFontHighLightcolor")
                    .WriteString(btnTextWindowHighLightColour.BackColor.ToArgb)
                    .WriteEndElement()
                    .WriteEndElement()
                    .WriteEndDocument()
                    .Flush()
                    .Close()
                End With
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ReadSettingsXml()
        Try
            Dim xmldoc As New XmlDocument()
            With xmldoc
                .Load("Settings.xml")
                txtDefultDirectory.Text = .SelectSingleNode("Settings").ChildNodes.Item(0).InnerText.Trim()
                txtExtention.Text = .SelectSingleNode("Settings").ChildNodes.Item(1).InnerText.Trim()
                txtFont.Text = .SelectSingleNode("Settings").ChildNodes.Item(2).InnerText.Trim()
                chkLoadDirectory.CheckState = .SelectSingleNode("Settings").ChildNodes.Item(3).InnerText.Trim()
                If not File.Exists(btnBrowseImage.Tag) Then btnBrowseImage.Tag = .SelectSingleNode("Settings").ChildNodes.Item(4).InnerText.Trim()
                btnAppFontColour.BackColor = Color.FromArgb(CInt(.SelectSingleNode("Settings").ChildNodes.Item(5).InnerText.Trim()))
                txtTextWindowFontSettings.Text = .SelectSingleNode("Settings").ChildNodes.Item(6).InnerText.Trim()
                btnTextWindowFontColour.BackColor = Color.FromArgb(CInt(.SelectSingleNode("Settings").ChildNodes.Item(7).InnerText.Trim()))
                btnTextWindowHighLightColour.BackColor = Color.FromArgb(CInt(.SelectSingleNode("Settings").ChildNodes.Item(8).InnerText.Trim()))
                If File.Exists(btnBrowseImage.Tag) Then
                    btnBrowseImage.Text = Path.GetFileNameWithoutExtension(btnBrowseImage.Tag)
                Else
                    btnBrowseImage.Text = "&Browse"
                End If
                If txtExtention.Text = "" Then
                    Dim extention As String = InputBox("Select default extention", "Select Default Extention", "*.txt")
                    txtExtention.Text = extention
                End If
                If txtDefultDirectory.Text = "" Then
                    Dim FolderBrowserDialog1 As New FolderBrowserDialog
                    FolderBrowserDialog1.Description = "Select default directory"
                    If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                        txtDefultDirectory.Text = FolderBrowserDialog1.SelectedPath
                    End If
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateSettingsXml()
        Try
            Dim xmldoc As New XmlDocument()
            With xmldoc
                .Load("Settings.xml")
                .SelectSingleNode("Settings").ChildNodes.Item(0).InnerText = txtDefultDirectory.Text.Trim
                .SelectSingleNode("Settings").ChildNodes.Item(1).InnerText = txtExtention.Text.Trim
                .SelectSingleNode("Settings").ChildNodes.Item(2).InnerText = txtFont.Text.Trim
                .SelectSingleNode("Settings").ChildNodes.Item(3).InnerText = chkLoadDirectory.CheckState
                .SelectSingleNode("Settings").ChildNodes.Item(4).InnerText = IIf(btnBrowseImage.Tag Is Nothing, "", btnBrowseImage.Tag)
                .SelectSingleNode("Settings").ChildNodes.Item(5).InnerText = btnAppFontColour.BackColor.ToArgb
                .SelectSingleNode("Settings").ChildNodes.Item(6).InnerText = txtTextWindowFontSettings.Text
                .SelectSingleNode("Settings").ChildNodes.Item(7).InnerText = btnTextWindowFontColour.BackColor.ToArgb
                .SelectSingleNode("Settings").ChildNodes.Item(8).InnerText = btnTextWindowHighLightColour.BackColor.ToArgb

                .Save("Settings.xml")
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBrowseImage_Click(sender As Object, e As EventArgs) Handles btnBrowseImage.Click
        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog
            ofd.Filter = "All files |*|Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png"
            ofd.FilterIndex = 1
            If ofd.ShowDialog() = DialogResult.OK Then
                btnBrowseImage.Tag = ofd.FileName
                btnBrowseImage.Text = Path.GetFileNameWithoutExtension(ofd.FileName)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnClearSettings_Click(sender As Object, e As EventArgs) Handles btnClearSettings.Click
        Try
            ReadSettingsXml()
            SettingsPanel.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FontColour(sender As Object, e As EventArgs) Handles btnAppFontColour.Click, btnTextWindowFontColour.Click, btnRichTextBoxFontColour.Click, btnTextWindowHighLightColour.Click, btnRichTextBoxHighlightFontColour.Click
        Try
            Dim colorDlg As New ColorDialog()
            If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                sender.BackColor = colorDlg.Color
                If sender.name = "btnRichTextBoxFontColour" Then
                    RichTextBox1.ForeColor = colorDlg.Color
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtRichBoxFont_TextChanged(sender As Object, e As EventArgs) Handles txtRichBoxFont.TextChanged
        Try
            Dim strFont() As String = txtRichBoxFont.Text.Split(",")
            RichTextBox1.Font = New System.Drawing.Font(strFont(0), CInt(strFont(1)))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SettingsPanel_Leave(sender As Object, e As EventArgs) Handles SettingsPanel.Leave
        Try
            SettingsPanel.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SettingsPanel_VisibleChanged(sender As Object, e As EventArgs) Handles SettingsPanel.VisibleChanged
        Try
            If SettingsPanel.Visible = True Then SettingsPanel.Select()
        Catch ex As Exception
        End Try
    End Sub
    Dim WordSearchIntex As List(Of Integer)
    Private Sub txtRichTextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtRichTextBoxSearch.TextChanged
        Try
            txtSearchText.Text = ""
            Dim strBackText As String = RichTextBox1.Text
            RichTextBox1.Clear()
            RichTextBox1.Text = strBackText
            _startindex = 0
            WordSearchIntex = New List(Of Integer)
            Dim word As String = txtRichTextBoxSearch.Text
            If txtRichTextBoxSearch.Text = "" Then Exit Sub
            While _startindex < strBackText.Length
                If _startindex < strBackText.Length Then
                    Dim wordstartIndex As Integer = strBackText.IndexOf(word, _startindex, comparisonType:=StringComparison.InvariantCultureIgnoreCase)
                    If wordstartIndex <> -1 Then
                        WordSearchIntex.Add(wordstartIndex)
                        RichTextBox1.Select(wordstartIndex, word.Length)
                        RichTextBox1.SelectionBackColor = Color.Aqua
                        RichTextBox1.ScrollToCaret()
                    End If
                    _startindex += If(wordstartIndex = -1, 0, wordstartIndex) + word.Length
                End If
            End While
            _startindex = 0
            NextPrev_Click(sender, e)

            'Dim word As String = txtRichTextBoxSearch.Text
            'While _startindex < RichTextBox1.TextLength
            '    ' If _startindex < RichTextBox1.TextLength Then
            '    Dim wordstartIndex As Integer = RichTextBox1.Text.IndexOf(word, _startindex, comparisonType:=StringComparison.CurrentCultureIgnoreCase)
            '    If wordstartIndex <> -1 Then
            '        WordSearchIntex.Add(wordstartIndex)
            '        RichTextBox1.SelectionStart = wordstartIndex
            '        RichTextBox1.SelectionBackColor = Color.Aqua
            '        RichTextBox1.ScrollToCaret()
            '    End If
            '    _startindex += wordstartIndex + word.Length
            '    '   End If
            'End While




            '        Public Static void Find(RichTextBox rtb, String word, Color color)
            '{
            '    If (word == "") Then
            '                    {
            '        Return;
            '    }
            '    Int s_start = rtb.SelectionStart, startIndex = 0, Index;
            '    While ((Index = rtb.Text.IndexOf(word, startIndex))!= -1)
            '    {
            '        rtb.Select(Index, word.Length);
            '        rtb.SelectionColor = Color;
            '        startIndex = Index + word.Length;
            '    }
            '    rtb.SelectionStart = 0;
            '    rtb.SelectionLength = rtb.TextLength;
            '    rtb.SelectionColor = Color.Black;
            '}


        Catch ex As Exception
        End Try
    End Sub
    Private Sub NextPrev_Click(sender As Object, e As EventArgs) Handles btnFindRichPrev.Click, btnFindRichNext.Click
        Try
            Dim word As String = txtRichTextBoxSearch.Text
            If sender.name = "btnFindRichPrev" Then
                If _startindex < 0 Then
                    _startindex = 0
                Else
                    _startindex = _startindex - 1
                End If
            ElseIf sender.name = "btnFindRichNext" Then
                _startindex = _startindex + 1
            End If

            RichTextBox1.SelectionStart = WordSearchIntex(_startindex)
            RichTextBox1.SelectionBackColor = btnRichTextBoxHighlightFontColour.BackColor
            RichTextBox1.ScrollToCaret()

            'If _startindex < RichTextBox1.TextLength Then
            '    Dim wordstartIndex As Integer = RichTextBox1.Find(word, _startindex, RichTextBoxFinds.None)
            '    If wordstartIndex <> -1 Then
            '        RichTextBox1.SelectionStart = wordstartIndex
            '        RichTextBox1.SelectionBackColor = btnRichTextBoxHighlightFontColour.BackColor
            '        RichTextBox1.ScrollToCaret()
            '    Else
            '        _startindex = 0
            '        Exit Sub
            '    End If
            '    _startindex += wordstartIndex + word.Length
            'End If
            If _startindex > RichTextBox1.TextLength Then _startindex = 0

        Catch ex As Exception
        End Try
    End Sub
End Class

