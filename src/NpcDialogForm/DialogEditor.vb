Imports NpcDialogCore

Public Class DialogEditor
    Private scenes As Scenes
    Private lang As Dictionary(Of String, String)
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(items As Scenes, lang As Dictionary(Of String, String))
        scenes = items.Clone
        InitializeComponent()
        For i As Integer = 0 To scenes.scenes.Count - 1
            Dim s As Scenes.ScencesItem = scenes.scenes(i)

            Dim npc_name As String = RawText.getRawText(s.npc_name, lang)
            If String.IsNullOrEmpty(npc_name) Then npc_name = "默认"
            Dim text As String = RawText.getRawText(s.text, lang)

            ListView1.Items.Add(npc_name)
            ListView1.Items(i).SubItems.Add(text)
            ListView1.Items(i).SubItems.Add(s.scene_tag)
        Next
        Me.lang = lang
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Dim a As ListView = sender
        Dim t As New DialogEditorDetails(scenes.scenes(a.Items.IndexOf(a.SelectedItems(0))), lang)
        t.ShowDialog()
    End Sub

    Public Function getChangeObject() As Scenes
        Return scenes
    End Function
End Class
