Imports System.IO
Imports System.Windows.Forms

Public Class AddFolder
    Public pathStr As String
    Private isOkPath As Boolean = False
    Private rootString As String
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(root As String)
        MyClass.New
        rootString = root
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim ok As Boolean = True
        For Each i As Char In Path.GetInvalidFileNameChars()
            If TextBox1.Text.Contains(i) Then
                ok = False
                Exit For
            End If
        Next
        If ok Then
            Dim p As String = Path.Combine(rootString, TextBox1.Text)
            If File.Exists(p) Then ok = False
            If Directory.Exists(p) Then ok = False
        End If
        If ok Then
            pathStr = Path.Combine(rootString, TextBox1.Text)
            Label2.Text = "允许的名称"
        Else
            Label2.Text = "文件夹名重复或者名称错误"
            pathStr = ""
        End If
    End Sub
End Class
