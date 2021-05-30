Imports System.IO
Imports System.Xml
Public Class frmScriptSearch
    Dim dtPathData As New DataTable
    Dim dtSerachedTextData As New DataTable
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If File.Exists("Settings.xml") Then
                ReadSettingsXml()
            Else
                CreateSettingsXml()
            End If
            SettingsPanel.Location = New System.Drawing.Point(btnSettings.Location.X, btnSettings.Location.Y + 33)
            changeSettings()
            dtPathData.Columns.AddRange(New DataColumn(1) {New DataColumn("Path"), New DataColumn("CreatedDate", GetType(Date))})
            dtSerachedTextData.Columns.AddRange(New DataColumn(2) {New DataColumn("Path"), New DataColumn("Line"), New DataColumn("CreatedDate", GetType(Date))})
            If chkLoadDirectory.Checked Then Button1_Click(sender, e)
            DataGridView1.AutoGenerateColumns = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
                            RichTextBox1.SelectionBackColor = Color.Yellow
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
    Private Sub FindNode(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If TabControl1.SelectedIndex = 0 Then
                Dim searchText As String = txtFileName.Text
                If String.IsNullOrEmpty(searchText) Then
                    Button1_Click(sender, e)
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
                    If StartNode.Text.ToLower().Contains(SearchText.ToLower()) Then
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
                Button7_Click(sender, New EventArgs, CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView).Item("Line"))
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
            Catch ex As Exception
            End Try
            If File.Exists(btnBrowseImage.Tag) Then
                If ((parent.GetType() Is GetType(Panel)) Or parent.GetType() Is GetType(GroupBox) Or parent.GetType() Is GetType(SplitContainer) _
                   Or (parent.GetType() Is GetType(Button)) Or (parent.GetType() Is GetType(StatusStrip))) And Not parent.Name = "btnSettings" Then
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
            FindControlRecursive(Me)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
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
                Button7_Click(sender, New EventArgs, CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView).Item("Line"))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim searchText As String = txtSearchText.Text
            If String.IsNullOrEmpty(searchText) Then
                Button1_Click(sender, e)
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
                            LineCompare.ToUpper()
                            If LineCompare.Contains(txtSearchText.Text.ToUpper) Then
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
                            Button7_Click(sender, e)
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
            Button7_Click(sender, e)
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
                OpenFile()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim _startindex As Integer = 0
    Private Sub Button7_Click(sender As Object, e As EventArgs, Optional ByVal SearchText As String = "")
        Try
            Dim word As String = IIf(SearchText = "", txtSearchText.Text, SearchText)
            If word <> "" Then
                If SearchText <> "" Then
                    Dim wordstartIndex As Integer = RichTextBox1.Find(word, 0, RichTextBoxFinds.None)
                    If wordstartIndex <> -1 Then
                        RichTextBox1.SelectionStart = wordstartIndex
                        RichTextBox1.ScrollToCaret()
                        RichTextBox1.SelectionStart = RichTextBox1.Find(txtSearchText.Text, wordstartIndex, RichTextBoxFinds.None)
                        RichTextBox1.SelectionBackColor = Color.Yellow

                    End If
                Else
                    If _startindex < RichTextBox1.TextLength Then
                        Dim wordstartIndex As Integer = RichTextBox1.Find(word, _startindex, RichTextBoxFinds.None)
                        If wordstartIndex <> -1 Then
                            RichTextBox1.SelectionStart = wordstartIndex
                            RichTextBox1.SelectionBackColor = Color.Yellow
                            RichTextBox1.ScrollToCaret()
                        Else
                            _startindex = 0
                            '  Button7_Click(sender, e)
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
                btnBrowseImage.Tag = .SelectSingleNode("Settings").ChildNodes.Item(4).InnerText.Trim()
                If File.Exists(btnBrowseImage.Tag) Then
                    btnBrowseImage.Text = Path.GetFileNameWithoutExtension(btnBrowseImage.Tag)
                Else
                    btnBrowseImage.Text = "&Browse"
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
                .SelectSingleNode("Settings").ChildNodes.Item(0).InnerText = txtDefultDirectory.Text
                .SelectSingleNode("Settings").ChildNodes.Item(1).InnerText = txtExtention.Text
                .SelectSingleNode("Settings").ChildNodes.Item(2).InnerText = txtFont.Text
                .SelectSingleNode("Settings").ChildNodes.Item(3).InnerText = chkLoadDirectory.CheckState
                .SelectSingleNode("Settings").ChildNodes.Item(4).InnerText = IIf(btnBrowseImage.Tag Is Nothing, "", btnBrowseImage.Tag)
                .Save("Settings.xml")
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnBrowseImage.Click
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

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            ReadSettingsXml()
            SettingsPanel.Visible = False
        Catch ex As Exception
        End Try
    End Sub
End Class

