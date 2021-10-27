Imports System.Windows.Forms
Imports NpcDialogCore
Imports NpcDialogCore.ProjectClass

Public Class ActorEditor
    Private proj As NpcDialogGeneratorMain
    Private actor As List(Of Character)
    Public Sub New()
        InitializeComponent()

    End Sub
    Public Sub New(proj As NpcDialogGeneratorMain)
        Me.New
        Me.proj = proj
        actor = proj.project.actors
        If actor IsNot Nothing Then
            For Each i As Character In actor
                'name为键名，需要转换
                ListView1.Items.Add(i.name).SubItems.Add(proj.getLocalLang(i.name))
            Next
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim actors As New List(Of Character)
        For Each i As ListViewItem In ListView1.Items
            actors.Add(New Character With {.name = i.SubItems(0).Text})
        Next
        proj.project.setActors(actors)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Add__Click(sender As Object, e As EventArgs) Handles Add.Click
        '添加一个角色
        Dim dia As New SelectLang(proj.getLangDic)
        dia.allowMutil(False)
        dia.Text = "选择一个语言当做NPC的名称"
        If dia.ShowDialog = DialogResult.OK Then
            ListView1.Items.Add(dia.selectedLang(0)).SubItems.Add(proj.getLocalLang(dia.selectedLang(0)))
        End If
    End Sub

    Private Sub Del_Click(sender As Object, e As EventArgs) Handles Del.Click
        For Each i As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(i)
        Next
    End Sub
End Class
