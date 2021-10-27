Imports System.Windows.Forms
Imports NpcDialogCore
Imports NpcDialogCore.Scenes.ScencesItem

Public Class AddDialogue
    Private langDic As Dictionary(Of String, String)
    Private selectedLang As List(Of String)
    Public JsonStr As JsonFormatMain
    Public ReadOnly Property dialogueName As String
        Get
            Return TextBox3.Text
        End Get
    End Property
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(langDic As Dictionary(Of String, String))
        MyClass.New
        Me.langDic = langDic
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '整合成类
        If isOk() Then
            Dim t As JsonFormatMain = JsonFormatMain.getNew
            For i As Integer = 0 To selectedLang.Count - 1
                Dim key As String = selectedLang(i)
                Dim b As New List(Of buttonsClass)
                Dim bCommand As New List(Of String)
                Dim scene_tag As String
                If CheckBox1.Checked Then
                    scene_tag = key
                Else
                    scene_tag = TextBox1.Text & (Val(TextBox2.Text) + i)
                End If
                If Not i = selectedLang.Count - 1 Then
                    bCommand.Add($"dialogue open @s @a {selectedLang(i + 1)}")
                    bCommand.Add($"dialogue change @s {selectedLang(i + 1)} @a")
                End If
                Dim rawtext As New RawText With {.rawtext = New List(Of RawText.rawTextItem)}
                rawtext.rawtext.Add(New RawText.rawTextItem With {.translate = key})
                b.Add(New buttonsClass With {.name = " ", .commands = bCommand})
                t.dialog.scenes.Add(New Scenes.ScencesItem With {.scene_tag = scene_tag,
                                .buttons = b, .text = rawtext})
            Next

            JsonStr = t
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function isOk() As Boolean
        If Not CheckBox1.Checked Then
            If String.IsNullOrEmpty(TextBox1.Text) Then
                ErrMsg("请填写命名规则")
                Return False
            End If
            If String.IsNullOrEmpty(TextBox1.Text) Then
                TextBox1.Text = 1
            End If
        End If

        If selectedLang.Count = 0 Then
            ErrMsg("请选择至少一条剧情！")
            Return False
        End If
        If String.IsNullOrEmpty(TextBox3.Text) Then
            ErrMsg("请填写剧情组名称(文件名称)")
            Return False
        End If
        Return True
    End Function

    Private Sub ErrMsg(s As String)
        MsgBox(s, vbOKOnly + vbAbort, "错误")
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New SelectLang(langDic)
        If t.ShowDialog = DialogResult.OK Then
            selectedLang = t.selectedLang
            LangCount.Text = $"共计{selectedLang.Count}条"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Panel1.Enabled = Not CheckBox1.Checked
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar < "0" And e.KeyChar > "9" Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class
