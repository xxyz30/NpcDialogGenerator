Imports System.Windows.Forms
Imports NpcDialogCore

Public Class RawTextEdit
    Private lang As Dictionary(Of String, String)
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(raw As Object, lang As Dictionary(Of String, String))
        MyClass.New
        If raw IsNot Nothing Then
            If TypeOf raw Is String Then
                ShowText.Checked = True
                TextBox2.Text = raw
                UseRawText_CheckedChanged(Nothing, Nothing)
            ElseIf TypeOf raw Is RawText Then
                Dim t As RawText = raw
                TextBox1.Text = t.rawtext(0).translate
            Else
                Throw New Exception("不支持的类型：" + raw.GetType.ToString)
            End If
        End If
        Me.lang = lang
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If UseRawText.Checked AndAlso String.IsNullOrEmpty(TextBox1.Text) Then
            Return
        ElseIf ShowText.Checked AndAlso String.IsNullOrEmpty(TextBox2.Text) Then
            Return
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UseRawText_CheckedChanged(sender As Object, e As EventArgs) Handles UseRawText.CheckedChanged
        If UseRawText.Checked Then
            rawBox.Enabled = True
            showBox.Enabled = False
        ElseIf ShowText.Checked Then
            rawBox.Enabled = False
            showBox.Enabled = True
        End If
    End Sub
    Public Function getRawtext() As Object
        If UseRawText.Checked Then
            Dim a As New RawText With {
                .rawtext = New List(Of RawText.rawTextItem)
            }
            a.rawtext.Add(New RawText.rawTextItem With {.translate = TextBox1.Text})
            Return a
        Else
            Return TextBox2.Text
        End If
    End Function

End Class
