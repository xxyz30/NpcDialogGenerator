Imports NpcDialogCore
Imports NpcDialogCore.Scenes

Public Class DialogDetailsControl
    Private dialogs As JsonFormatMain
    Private langDic As Dictionary(Of String, String)
    Private detailsStr As String = ""
    Private names As String = ""

    Private Shared ReadOnly nameFont As New Font("黑体", 16)
    Private Shared ReadOnly contentFont As New Font("黑体", 14)
    Private Shared ReadOnly textStartX As Integer = 20
    Private Shared ReadOnly textStartY As Integer = 10
    Private fillR As Rectangle
    Private fillRColor As Brush = Brushes.White
    Public Sub New(dialogs As JsonFormatMain, langDic As Dictionary(Of String, String))
        If dialogs Is Nothing AndAlso langDic Is Nothing Then
            Throw New Exception("此文件无效！")
        End If
        InitializeComponent()
        Me.Dock = DockStyle.Top
        Me.dialogs = dialogs
        Me.Height = 80
        Me.langDic = langDic
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        fillR = New Rectangle(textStartX - 3, textStartY - 3, Me.Width - 2 * textStartX, Me.Height - 2 * textStartY)
        getDetails()
        Dim g As Graphics = e.Graphics

        g.FillRectangle(fillRColor, fillR)
        g.DrawRectangle(Pens.Black, fillR)
        drawStr(g)
    End Sub
    Private Sub drawStr(g As Graphics)
        g.DrawString(names, nameFont, Brushes.Black, textStartX, textStartY)
        Dim t As SizeF = g.MeasureString(names, nameFont)
        g.DrawString(detailsStr, contentFont, Brushes.Black, textStartX, t.Height + 3 + textStartY)
    End Sub
    Private Sub getDetails()


        If dialogs.dialog.scenes.Count > 0 Then
            detailsStr = RawText.getRawText(dialogs.dialog.scenes(0).text, langDic)
            names = RawText.getRawText(dialogs.dialog.scenes(0).npc_name, langDic)
        End If
    End Sub

    Private Sub DialogDetailsControl_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        fillRColor = Brushes.LightGray
        Me.Refresh()
    End Sub

    Private Sub DialogDetailsControl_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        fillRColor = Brushes.White
        Me.Refresh()
    End Sub
End Class
