<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RawTextEdit
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.rawBox = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.showBox = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ShowText = New System.Windows.Forms.RadioButton()
        Me.UseRawText = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.rawBox.SuspendLayout()
        Me.showBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(323, 173)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 38)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(77, 30)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "确定"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.Location = New System.Drawing.Point(89, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(77, 30)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "取消"
        '
        'rawBox
        '
        Me.rawBox.Controls.Add(Me.Button1)
        Me.rawBox.Controls.Add(Me.TextBox1)
        Me.rawBox.Controls.Add(Me.Label1)
        Me.rawBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.rawBox.Location = New System.Drawing.Point(0, 0)
        Me.rawBox.Name = "rawBox"
        Me.rawBox.Size = New System.Drawing.Size(507, 64)
        Me.rawBox.TabIndex = 1
        Me.rawBox.TabStop = False
        Me.rawBox.Text = "使用原始文本"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(426, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "选择"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(74, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(346, 23)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "翻译文本"
        '
        'showBox
        '
        Me.showBox.Controls.Add(Me.TextBox2)
        Me.showBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.showBox.Enabled = False
        Me.showBox.Location = New System.Drawing.Point(0, 64)
        Me.showBox.Name = "showBox"
        Me.showBox.Size = New System.Drawing.Size(507, 100)
        Me.showBox.TabIndex = 2
        Me.showBox.TabStop = False
        Me.showBox.Text = "直接显示文本"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 22)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(489, 72)
        Me.TextBox2.TabIndex = 2
        '
        'ShowText
        '
        Me.ShowText.AutoSize = True
        Me.ShowText.Location = New System.Drawing.Point(114, 9)
        Me.ShowText.Name = "ShowText"
        Me.ShowText.Size = New System.Drawing.Size(98, 21)
        Me.ShowText.TabIndex = 3
        Me.ShowText.Text = "直接显示文本"
        Me.ShowText.UseVisualStyleBackColor = True
        '
        'UseRawText
        '
        Me.UseRawText.AutoSize = True
        Me.UseRawText.Checked = True
        Me.UseRawText.Location = New System.Drawing.Point(10, 9)
        Me.UseRawText.Name = "UseRawText"
        Me.UseRawText.Size = New System.Drawing.Size(98, 21)
        Me.UseRawText.TabIndex = 4
        Me.UseRawText.TabStop = True
        Me.UseRawText.Text = "使用原始文本"
        Me.UseRawText.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.UseRawText)
        Me.Panel1.Controls.Add(Me.ShowText)
        Me.Panel1.Location = New System.Drawing.Point(12, 173)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(214, 41)
        Me.Panel1.TabIndex = 5
        '
        'RawTextEdit
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(507, 227)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.showBox)
        Me.Controls.Add(Me.rawBox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RawTextEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "编辑文本"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.rawBox.ResumeLayout(False)
        Me.rawBox.PerformLayout()
        Me.showBox.ResumeLayout(False)
        Me.showBox.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents rawBox As GroupBox
    Friend WithEvents showBox As GroupBox
    Friend WithEvents ShowText As RadioButton
    Friend WithEvents UseRawText As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
End Class
