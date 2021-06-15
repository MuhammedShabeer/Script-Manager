<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScriptSearch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScriptSearch))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tspShorcutdescripton = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.directoryTree = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpen = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnSearchText = New System.Windows.Forms.Button()
        Me.btnFindFile = New System.Windows.Forms.Button()
        Me.btnfindDirectory = New System.Windows.Forms.Button()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRichTextBoxHighlightFontColour = New System.Windows.Forms.Button()
        Me.btnRichTextBoxFontColour = New System.Windows.Forms.Button()
        Me.btnFindRichNext = New System.Windows.Forms.Button()
        Me.btnFindRichPrev = New System.Windows.Forms.Button()
        Me.txtRichBoxFont = New System.Windows.Forms.TextBox()
        Me.txtRichTextBoxSearch = New System.Windows.Forms.TextBox()
        Me.SettingsPanel = New System.Windows.Forms.GroupBox()
        Me.btnTextWindowHighLightColour = New System.Windows.Forms.Button()
        Me.btnTextWindowFontColour = New System.Windows.Forms.Button()
        Me.btnAppFontColour = New System.Windows.Forms.Button()
        Me.btnBrowseImage = New System.Windows.Forms.Button()
        Me.chkLoadDirectory = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClearSettings = New System.Windows.Forms.Button()
        Me.btnSetttingClear = New System.Windows.Forms.Button()
        Me.txtDefultDirectory = New System.Windows.Forms.TextBox()
        Me.txtTextWindowFontSettings = New System.Windows.Forms.TextBox()
        Me.txtExtention = New System.Windows.Forms.TextBox()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.btnRestoreSettings = New System.Windows.Forms.Button()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SettingsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripSeparator1, Me.tspShorcutdescripton, Me.ToolStripSeparator2, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 414)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(805, 23)
        Me.StatusStrip1.TabIndex = 9
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.AutoSize = False
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(370, 17)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'tspShorcutdescripton
        '
        Me.tspShorcutdescripton.Name = "tspShorcutdescripton"
        Me.tspShorcutdescripton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tspShorcutdescripton.Size = New System.Drawing.Size(0, 18)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabel1.AutoToolTip = True
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 18)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(805, 414)
        Me.SplitContainer1.SplitterDistance = 268
        Me.SplitContainer1.TabIndex = 10
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 107)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(268, 307)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.directoryTree)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(260, 281)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tree view"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'directoryTree
        '
        Me.directoryTree.BackColor = System.Drawing.SystemColors.Window
        Me.directoryTree.ContextMenuStrip = Me.ContextMenuStrip1
        Me.directoryTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.directoryTree.Location = New System.Drawing.Point(0, 0)
        Me.directoryTree.Name = "directoryTree"
        Me.directoryTree.Size = New System.Drawing.Size(260, 281)
        Me.directoryTree.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem1.Text = "Show"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem2.Text = "Open File"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(260, 281)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "List view"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPath, Me.ColCreatedDate, Me.ColOpen})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(260, 281)
        Me.DataGridView1.TabIndex = 0
        '
        'ColPath
        '
        Me.ColPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColPath.DataPropertyName = "Path"
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColPath.DefaultCellStyle = DataGridViewCellStyle10
        Me.ColPath.HeaderText = "Path"
        Me.ColPath.Name = "ColPath"
        Me.ColPath.ReadOnly = True
        '
        'ColCreatedDate
        '
        Me.ColCreatedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColCreatedDate.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle11.Format = "d"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.ColCreatedDate.DefaultCellStyle = DataGridViewCellStyle11
        Me.ColCreatedDate.HeaderText = "Created Date"
        Me.ColCreatedDate.Name = "ColCreatedDate"
        Me.ColCreatedDate.ReadOnly = True
        Me.ColCreatedDate.Width = 95
        '
        'ColOpen
        '
        Me.ColOpen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColOpen.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColOpen.HeaderText = "Open"
        Me.ColOpen.Name = "ColOpen"
        Me.ColOpen.ReadOnly = True
        Me.ColOpen.Width = 39
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSettings)
        Me.Panel1.Controls.Add(Me.btnSearchText)
        Me.Panel1.Controls.Add(Me.btnFindFile)
        Me.Panel1.Controls.Add(Me.btnfindDirectory)
        Me.Panel1.Controls.Add(Me.txtSearchText)
        Me.Panel1.Controls.Add(Me.txtFileName)
        Me.Panel1.Controls.Add(Me.txtDirectory)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(268, 107)
        Me.Panel1.TabIndex = 1
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btnSettings.BackgroundImage = CType(resources.GetObject("btnSettings.BackgroundImage"), System.Drawing.Image)
        Me.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSettings.Location = New System.Drawing.Point(7, 5)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(33, 29)
        Me.btnSettings.TabIndex = 14
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnSearchText
        '
        Me.btnSearchText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchText.Location = New System.Drawing.Point(144, 75)
        Me.btnSearchText.Name = "btnSearchText"
        Me.btnSearchText.Size = New System.Drawing.Size(118, 24)
        Me.btnSearchText.TabIndex = 13
        Me.btnSearchText.Text = "&Search Text"
        Me.btnSearchText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSearchText.UseVisualStyleBackColor = True
        '
        'btnFindFile
        '
        Me.btnFindFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindFile.Location = New System.Drawing.Point(144, 43)
        Me.btnFindFile.Name = "btnFindFile"
        Me.btnFindFile.Size = New System.Drawing.Size(118, 24)
        Me.btnFindFile.TabIndex = 13
        Me.btnFindFile.Text = "&Find file"
        Me.btnFindFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFindFile.UseVisualStyleBackColor = True
        '
        'btnfindDirectory
        '
        Me.btnfindDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnfindDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindDirectory.Location = New System.Drawing.Point(184, 8)
        Me.btnfindDirectory.Name = "btnfindDirectory"
        Me.btnfindDirectory.Size = New System.Drawing.Size(78, 24)
        Me.btnfindDirectory.TabIndex = 13
        Me.btnfindDirectory.Text = "&Find"
        Me.btnfindDirectory.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.txtSearchText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchText.Location = New System.Drawing.Point(10, 76)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(128, 23)
        Me.txtSearchText.TabIndex = 12
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.txtFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(10, 44)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(128, 23)
        Me.txtFileName.TabIndex = 12
        '
        'txtDirectory
        '
        Me.txtDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirectory.Location = New System.Drawing.Point(45, 9)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.Size = New System.Drawing.Size(133, 23)
        Me.txtDirectory.TabIndex = 10
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 45)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(533, 369)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnRichTextBoxHighlightFontColour)
        Me.Panel2.Controls.Add(Me.btnRichTextBoxFontColour)
        Me.Panel2.Controls.Add(Me.btnFindRichNext)
        Me.Panel2.Controls.Add(Me.btnFindRichPrev)
        Me.Panel2.Controls.Add(Me.txtRichBoxFont)
        Me.Panel2.Controls.Add(Me.txtRichTextBoxSearch)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(533, 45)
        Me.Panel2.TabIndex = 2
        '
        'btnRichTextBoxHighlightFontColour
        '
        Me.btnRichTextBoxHighlightFontColour.BackColor = System.Drawing.Color.Yellow
        Me.btnRichTextBoxHighlightFontColour.Location = New System.Drawing.Point(166, 10)
        Me.btnRichTextBoxHighlightFontColour.Name = "btnRichTextBoxHighlightFontColour"
        Me.btnRichTextBoxHighlightFontColour.Size = New System.Drawing.Size(16, 25)
        Me.btnRichTextBoxHighlightFontColour.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.btnRichTextBoxHighlightFontColour, "Text window highlight color")
        Me.btnRichTextBoxHighlightFontColour.UseVisualStyleBackColor = False
        '
        'btnRichTextBoxFontColour
        '
        Me.btnRichTextBoxFontColour.BackColor = System.Drawing.Color.Black
        Me.btnRichTextBoxFontColour.Location = New System.Drawing.Point(150, 10)
        Me.btnRichTextBoxFontColour.Name = "btnRichTextBoxFontColour"
        Me.btnRichTextBoxFontColour.Size = New System.Drawing.Size(16, 25)
        Me.btnRichTextBoxFontColour.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.btnRichTextBoxFontColour, "Text window font color")
        Me.btnRichTextBoxFontColour.UseVisualStyleBackColor = False
        '
        'btnFindRichNext
        '
        Me.btnFindRichNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindRichNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindRichNext.Location = New System.Drawing.Point(477, 11)
        Me.btnFindRichNext.Name = "btnFindRichNext"
        Me.btnFindRichNext.Size = New System.Drawing.Size(45, 24)
        Me.btnFindRichNext.TabIndex = 13
        Me.btnFindRichNext.Text = ">"
        Me.btnFindRichNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFindRichNext.UseVisualStyleBackColor = True
        '
        'btnFindRichPrev
        '
        Me.btnFindRichPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindRichPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindRichPrev.Location = New System.Drawing.Point(426, 11)
        Me.btnFindRichPrev.Name = "btnFindRichPrev"
        Me.btnFindRichPrev.Size = New System.Drawing.Size(45, 24)
        Me.btnFindRichPrev.TabIndex = 13
        Me.btnFindRichPrev.Text = "<"
        Me.btnFindRichPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFindRichPrev.UseVisualStyleBackColor = True
        '
        'txtRichBoxFont
        '
        Me.txtRichBoxFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtRichBoxFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.txtRichBoxFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRichBoxFont.Location = New System.Drawing.Point(8, 11)
        Me.txtRichBoxFont.Name = "txtRichBoxFont"
        Me.txtRichBoxFont.Size = New System.Drawing.Size(142, 23)
        Me.txtRichBoxFont.TabIndex = 12
        Me.txtRichBoxFont.Text = "Microsoft Sans Serif, 10"
        '
        'txtRichTextBoxSearch
        '
        Me.txtRichTextBoxSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRichTextBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtRichTextBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.txtRichTextBoxSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRichTextBoxSearch.Location = New System.Drawing.Point(186, 11)
        Me.txtRichTextBoxSearch.Name = "txtRichTextBoxSearch"
        Me.txtRichTextBoxSearch.Size = New System.Drawing.Size(235, 23)
        Me.txtRichTextBoxSearch.TabIndex = 12
        '
        'SettingsPanel
        '
        Me.SettingsPanel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.SettingsPanel.Controls.Add(Me.btnTextWindowHighLightColour)
        Me.SettingsPanel.Controls.Add(Me.btnTextWindowFontColour)
        Me.SettingsPanel.Controls.Add(Me.btnAppFontColour)
        Me.SettingsPanel.Controls.Add(Me.btnBrowseImage)
        Me.SettingsPanel.Controls.Add(Me.chkLoadDirectory)
        Me.SettingsPanel.Controls.Add(Me.Label4)
        Me.SettingsPanel.Controls.Add(Me.Label3)
        Me.SettingsPanel.Controls.Add(Me.Label2)
        Me.SettingsPanel.Controls.Add(Me.Label5)
        Me.SettingsPanel.Controls.Add(Me.Label1)
        Me.SettingsPanel.Controls.Add(Me.btnClearSettings)
        Me.SettingsPanel.Controls.Add(Me.btnSetttingClear)
        Me.SettingsPanel.Controls.Add(Me.txtDefultDirectory)
        Me.SettingsPanel.Controls.Add(Me.txtTextWindowFontSettings)
        Me.SettingsPanel.Controls.Add(Me.txtExtention)
        Me.SettingsPanel.Controls.Add(Me.txtFont)
        Me.SettingsPanel.Controls.Add(Me.btnRestoreSettings)
        Me.SettingsPanel.Controls.Add(Me.btnSaveSettings)
        Me.SettingsPanel.Location = New System.Drawing.Point(326, 144)
        Me.SettingsPanel.Name = "SettingsPanel"
        Me.SettingsPanel.Size = New System.Drawing.Size(339, 240)
        Me.SettingsPanel.TabIndex = 1
        Me.SettingsPanel.TabStop = False
        Me.SettingsPanel.Text = "Settings"
        Me.SettingsPanel.Visible = False
        '
        'btnTextWindowHighLightColour
        '
        Me.btnTextWindowHighLightColour.BackColor = System.Drawing.Color.Yellow
        Me.btnTextWindowHighLightColour.Location = New System.Drawing.Point(319, 49)
        Me.btnTextWindowHighLightColour.Name = "btnTextWindowHighLightColour"
        Me.btnTextWindowHighLightColour.Size = New System.Drawing.Size(16, 25)
        Me.btnTextWindowHighLightColour.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.btnTextWindowHighLightColour, "Text window highlight color")
        Me.btnTextWindowHighLightColour.UseVisualStyleBackColor = False
        '
        'btnTextWindowFontColour
        '
        Me.btnTextWindowFontColour.BackColor = System.Drawing.Color.Black
        Me.btnTextWindowFontColour.Location = New System.Drawing.Point(303, 49)
        Me.btnTextWindowFontColour.Name = "btnTextWindowFontColour"
        Me.btnTextWindowFontColour.Size = New System.Drawing.Size(16, 25)
        Me.btnTextWindowFontColour.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.btnTextWindowFontColour, "Text window font color")
        Me.btnTextWindowFontColour.UseVisualStyleBackColor = False
        '
        'btnAppFontColour
        '
        Me.btnAppFontColour.BackColor = System.Drawing.Color.Black
        Me.btnAppFontColour.Location = New System.Drawing.Point(319, 19)
        Me.btnAppFontColour.Name = "btnAppFontColour"
        Me.btnAppFontColour.Size = New System.Drawing.Size(16, 25)
        Me.btnAppFontColour.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.btnAppFontColour, "App font color")
        Me.btnAppFontColour.UseVisualStyleBackColor = False
        '
        'btnBrowseImage
        '
        Me.btnBrowseImage.Location = New System.Drawing.Point(111, 140)
        Me.btnBrowseImage.Name = "btnBrowseImage"
        Me.btnBrowseImage.Size = New System.Drawing.Size(222, 23)
        Me.btnBrowseImage.TabIndex = 15
        Me.btnBrowseImage.Text = "&Browse image"
        Me.btnBrowseImage.UseVisualStyleBackColor = True
        '
        'chkLoadDirectory
        '
        Me.chkLoadDirectory.AutoSize = True
        Me.chkLoadDirectory.BackColor = System.Drawing.Color.Transparent
        Me.chkLoadDirectory.Checked = True
        Me.chkLoadDirectory.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLoadDirectory.Location = New System.Drawing.Point(12, 175)
        Me.chkLoadDirectory.Name = "chkLoadDirectory"
        Me.chkLoadDirectory.Size = New System.Drawing.Size(139, 17)
        Me.chkLoadDirectory.TabIndex = 14
        Me.chkLoadDirectory.Text = "Load directory in startup"
        Me.chkLoadDirectory.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Background image"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Default directory"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Search extension"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(12, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Text window font"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Font"
        '
        'btnClearSettings
        '
        Me.btnClearSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSettings.Location = New System.Drawing.Point(271, 198)
        Me.btnClearSettings.Name = "btnClearSettings"
        Me.btnClearSettings.Size = New System.Drawing.Size(61, 24)
        Me.btnClearSettings.TabIndex = 13
        Me.btnClearSettings.Text = "&Cancel"
        Me.btnClearSettings.UseVisualStyleBackColor = True
        '
        'btnSetttingClear
        '
        Me.btnSetttingClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetttingClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetttingClear.Location = New System.Drawing.Point(204, 198)
        Me.btnSetttingClear.Name = "btnSetttingClear"
        Me.btnSetttingClear.Size = New System.Drawing.Size(61, 24)
        Me.btnSetttingClear.TabIndex = 13
        Me.btnSetttingClear.Text = "&Clear"
        Me.btnSetttingClear.UseVisualStyleBackColor = True
        '
        'txtDefultDirectory
        '
        Me.txtDefultDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDefultDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDefultDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtDefultDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDefultDirectory.Location = New System.Drawing.Point(111, 109)
        Me.txtDefultDirectory.Name = "txtDefultDirectory"
        Me.txtDefultDirectory.Size = New System.Drawing.Size(223, 23)
        Me.txtDefultDirectory.TabIndex = 12
        '
        'txtTextWindowFontSettings
        '
        Me.txtTextWindowFontSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTextWindowFontSettings.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTextWindowFontSettings.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.txtTextWindowFontSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTextWindowFontSettings.Location = New System.Drawing.Point(111, 50)
        Me.txtTextWindowFontSettings.Name = "txtTextWindowFontSettings"
        Me.txtTextWindowFontSettings.Size = New System.Drawing.Size(190, 23)
        Me.txtTextWindowFontSettings.TabIndex = 12
        Me.txtTextWindowFontSettings.Text = "Microsoft Sans Serif, 10"
        '
        'txtExtention
        '
        Me.txtExtention.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExtention.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtExtention.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.txtExtention.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtention.Location = New System.Drawing.Point(111, 80)
        Me.txtExtention.Name = "txtExtention"
        Me.txtExtention.Size = New System.Drawing.Size(223, 23)
        Me.txtExtention.TabIndex = 12
        Me.txtExtention.Text = " *.sql"
        '
        'txtFont
        '
        Me.txtFont.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.txtFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFont.Location = New System.Drawing.Point(111, 20)
        Me.txtFont.Name = "txtFont"
        Me.txtFont.Size = New System.Drawing.Size(208, 23)
        Me.txtFont.TabIndex = 12
        Me.txtFont.Text = "Microsoft Sans Serif, 10"
        '
        'btnRestoreSettings
        '
        Me.btnRestoreSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestoreSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestoreSettings.Location = New System.Drawing.Point(7, 198)
        Me.btnRestoreSettings.Name = "btnRestoreSettings"
        Me.btnRestoreSettings.Size = New System.Drawing.Size(117, 24)
        Me.btnRestoreSettings.TabIndex = 13
        Me.btnRestoreSettings.Text = "&Restore default"
        Me.btnRestoreSettings.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSettings.Location = New System.Drawing.Point(137, 198)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(61, 24)
        Me.btnSaveSettings.TabIndex = 13
        Me.btnSaveSettings.Text = "&Save"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'frmScriptSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 437)
        Me.Controls.Add(Me.SettingsPanel)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScriptSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.SettingsPanel.ResumeLayout(False)
        Me.SettingsPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tspShorcutdescripton As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnfindDirectory As System.Windows.Forms.Button
    Friend WithEvents directoryTree As System.Windows.Forms.TreeView
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnFindFile As System.Windows.Forms.Button
    Friend WithEvents btnSearchText As System.Windows.Forms.Button
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents SettingsPanel As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSetttingClear As System.Windows.Forms.Button
    Friend WithEvents txtDefultDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtExtention As System.Windows.Forms.TextBox
    Friend WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
    Friend WithEvents chkLoadDirectory As System.Windows.Forms.CheckBox
    Friend WithEvents ColPath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpen As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnRestoreSettings As System.Windows.Forms.Button
    Friend WithEvents btnBrowseImage As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnClearSettings As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFindRichPrev As Button
    Friend WithEvents txtRichTextBoxSearch As TextBox
    Friend WithEvents btnFindRichNext As Button
    Friend WithEvents txtRichBoxFont As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTextWindowFontSettings As TextBox
    Friend WithEvents btnTextWindowFontColour As Button
    Friend WithEvents btnAppFontColour As Button
    Friend WithEvents btnRichTextBoxFontColour As Button
    Friend WithEvents btnRichTextBoxHighlightFontColour As Button
    Friend WithEvents btnTextWindowHighLightColour As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class


