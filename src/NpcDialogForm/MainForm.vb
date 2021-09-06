Imports NpcDialogCore
Imports System.IO
Public Class MainForm
    Private npcDialogDatas As New NpcDialogGeneratorMain
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim a As New NpcDialogGeneratorMain
        a.addDialogFile(New FileInfo("C:\Users\ts187\Desktop\新建文本文档.json"))
    End Sub

    Private Sub ProjTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles ProjTree.AfterSelect

    End Sub


    Private Sub ProjTree_DragEnter(sender As Object, e As DragEventArgs) Handles ContentPanel.DragEnter, ProjTree.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ProjTree_DragDrop(sender As Object, e As DragEventArgs) Handles ProjTree.DragDrop
        Dim a As String() = e.Data.GetData(DataFormats.FileDrop)
        For Each i As String In a
            If Not i.EndsWith(".lang") Then Continue For
            Try
                Dim p As New FileInfo(i)
                npcDialogDatas.addLanguage(p)
            Catch ex As Exception

            End Try
        Next

    End Sub

    Private Sub ContentPanel_DragDrop(sender As Object, e As DragEventArgs) Handles ContentPanel.DragDrop
        Dim a As String() = e.Data.GetData(DataFormats.FileDrop)
        For Each i As String In a
            If File.Exists(i) Then
                '是个文件
                Try
                    Dim p As New FileInfo(i)
                    npcDialogDatas.addDialogFile(p)
                Catch ex As Exception

                End Try
            ElseIf Directory.Exists(i) Then
                '是个文件夹
                Try
                    Dim f As New DirectoryInfo(i)
                    npcDialogDatas.addDialogFolder(f)
                Catch ex As Exception
                End Try
            End If
        Next
        ContentPanel.Controls.Clear()
        For Each i As JsonFormatMain In npcDialogDatas.getAllDialogs
            Dim c As New DialogDetailsControl(i, npcDialogDatas.getLangDic)
            ContentPanel.Controls.Add(c)
        Next

    End Sub

End Class
