<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.UpStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.另存为ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开lang文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开对话文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开对话文件夹ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ProjTree = New System.Windows.Forms.TreeView()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.UpStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UpStrip
        '
        Me.UpStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.UpStrip.Location = New System.Drawing.Point(0, 25)
        Me.UpStrip.Name = "UpStrip"
        Me.UpStrip.Size = New System.Drawing.Size(903, 25)
        Me.UpStrip.TabIndex = 0
        Me.UpStrip.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "打开lang文件"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(903, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.保存ToolStripMenuItem, Me.另存为ToolStripMenuItem, Me.打开lang文件ToolStripMenuItem, Me.打开对话文件ToolStripMenuItem, Me.打开对话文件夹ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        '另存为ToolStripMenuItem
        '
        Me.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem"
        Me.另存为ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.另存为ToolStripMenuItem.Text = "另存为"
        '
        '打开lang文件ToolStripMenuItem
        '
        Me.打开lang文件ToolStripMenuItem.Name = "打开lang文件ToolStripMenuItem"
        Me.打开lang文件ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.打开lang文件ToolStripMenuItem.Text = "打开lang文件"
        '
        '打开对话文件ToolStripMenuItem
        '
        Me.打开对话文件ToolStripMenuItem.Name = "打开对话文件ToolStripMenuItem"
        Me.打开对话文件ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.打开对话文件ToolStripMenuItem.Text = "打开对话文件"
        '
        '打开对话文件夹ToolStripMenuItem
        '
        Me.打开对话文件夹ToolStripMenuItem.Name = "打开对话文件夹ToolStripMenuItem"
        Me.打开对话文件夹ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.打开对话文件夹ToolStripMenuItem.Text = "打开对话文件夹"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 50)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProjTree)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ContentPanel)
        Me.SplitContainer1.Size = New System.Drawing.Size(903, 459)
        Me.SplitContainer1.SplitterDistance = 265
        Me.SplitContainer1.TabIndex = 2
        '
        'ProjTree
        '
        Me.ProjTree.AllowDrop = True
        Me.ProjTree.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ProjTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjTree.Location = New System.Drawing.Point(0, 0)
        Me.ProjTree.Name = "ProjTree"
        Me.ProjTree.Size = New System.Drawing.Size(265, 459)
        Me.ProjTree.TabIndex = 0
        '
        'ContentPanel
        '
        Me.ContentPanel.AllowDrop = True
        Me.ContentPanel.AutoScroll = True
        Me.ContentPanel.BackColor = System.Drawing.SystemColors.Control
        Me.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContentPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentPanel.Location = New System.Drawing.Point(0, 0)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Size = New System.Drawing.Size(634, 459)
        Me.ContentPanel.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 509)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(903, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "DownStrip"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 531)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.UpStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "主窗体"
        Me.UpStrip.ResumeLayout(False)
        Me.UpStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UpStrip As ToolStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 另存为ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ProjTree As TreeView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents 打开lang文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开对话文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开对话文件夹ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ContentPanel As Panel
End Class
