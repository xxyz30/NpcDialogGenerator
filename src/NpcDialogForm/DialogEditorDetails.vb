Imports System.Text
Imports System.Windows.Forms
Imports NpcDialogCore

Public Class DialogEditorDetails
    Private scenes As Scenes.ScencesItem
    Private lang As Dictionary(Of String, String)
    Private newText As Boolean = True
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(items As Scenes.ScencesItem, lang As Dictionary(Of String, String))
        MyClass.New
        scenes = items
        Me.lang = lang
        newText = False


        tagBox.Text = scenes.scene_tag
        speakerBox.Text = scenes.npc_name.ToString

        openRunBox.Text = listToStr(scenes.on_open_commands)
        CloseRunbox.Text = listToStr(scenes.on_close_commands)
    End Sub
    Private Function listToStr(l As List(Of String)) As String
        If l Is Nothing Then Return Nothing
        Dim t As New StringBuilder
        For Each i As String In l
            t.AppendLine(i)
        Next
        Return t.ToString
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Label3.LinkClicked
        If newText Then
            Dim t As New RawTextEdit()
            t.ShowDialog()
        Else
            Dim t As New RawTextEdit(scenes.text, lang)
            t.ShowDialog()
        End If
    End Sub

End Class
