Imports System.Windows.Forms
Imports NpcDialogCore.Scenes.ScencesItem
Public Class ButtonsDialogue
    Private button As buttonsClass
    Private lang As Dictionary(Of String, String)
    Public Function getButton() As buttonsClass
        Return button
    End Function
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(button As buttonsClass, lang As Dictionary(Of String, String))
        MyClass.New
        Me.button = button
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim t As RawTextEdit
        If button IsNot Nothing Then
            '创建新对象
            t = New RawTextEdit(Nothing, lang)
        Else
            t = New RawTextEdit(button.name, lang)
        End If
        If t.ShowDialog = DialogResult.OK Then
            button.name = t.getRawtext
        End If
    End Sub
End Class
