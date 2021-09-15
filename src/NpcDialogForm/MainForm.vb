Imports NpcDialogCore
Imports System.IO
Public Class MainForm
    Private npcDialogDatas As New NpcDialogGeneratorMain
    Private isLoadedProj As Boolean = False
    Public Sub New()
        InitializeComponent()
        langNode = ProjTree.Nodes(0)
        dialogueNode = ProjTree.Nodes(1)
        AddFolder.Enabled = False
        AddNewDialogGroup.Enabled = False
    End Sub
    Public Sub New(p As DirectoryInfo)
        MyClass.New()
        Try
            '拖入文件夹，则会当作工程
            '扫描项目
            dialogueNode.Nodes.Clear()
            setDialogueNode(p, dialogueNode)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        isLoadedProj = True
        AddFolder.Enabled = True
        AddNewDialogGroup.Enabled = True
    End Sub


    Private Sub ProjTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles ProjTree.AfterSelect
        Dim a As TreeNode = getRootNode(e.Node)
        If a Is langNode Or Not isLoadedProj Then
            AddNewDialogGroup.Enabled = False
            AddFolder.Enabled = False
        ElseIf a Is dialogueNode Then
            ContentPanel.Controls.Clear()
            getDialogues(e.Node)
            AddNewDialogGroup.Enabled = True
            AddFolder.Enabled = True
        Else
        End If
    End Sub
    Private Sub getDialogues(n As TreeNode)
        Dim t As TreeNodeWithList = n.Tag
        If t IsNot Nothing Then
            ContentPanel.Controls.AddRange(t.storyList.ToArray)
        End If
    End Sub


    Private Function getRootNode(n As TreeNode) As TreeNode
        If n.Parent Is Nothing Then
            Return n
        Else
            Return getRootNode(n.Parent)
        End If
    End Function


    Private Sub ProjTree_DragEnter(sender As Object, e As DragEventArgs) Handles ContentPanel.DragEnter, ProjTree.DragEnter, Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ProjTree_DragDrop(sender As Object, e As DragEventArgs) Handles ProjTree.DragDrop, ContentPanel.DragDrop, Me.DragDrop
        Dim a As String() = e.Data.GetData(DataFormats.FileDrop)
        For Each i As String In a
            If File.Exists(i) Then
                If i.ToLower.EndsWith(".lang") Then
                    Try
                        Dim p As New FileInfo(i)
                        npcDialogDatas.addLanguage(p)
                        langNode.Nodes.Add(p.Name).ToolTipText = p.FullName
                    Catch ex As Exception

                    End Try
                    'ElseIf i.ToLower.EndsWith(".json") Then
                    '    Try
                    '        Dim p As New FileInfo(i)
                    '        'npcDialogDatas.addDialogFile(p)
                    '        '直接打开一个对话框，会直接跳转到编辑，不添加进去
                    '    Catch ex As Exception

                    '    End Try
                    'Else
                    '    Continue For
                End If
            ElseIf Directory.Exists(i) Then
                Dim f As New DirectoryInfo(i)
                If isLoadedProj Then
                    Dim aa As DialogResult = MsgBox("打开新窗口？", vbYesNoCancel + vbQuestion, "询问")
                    If aa = DialogResult.Yes Then
                        '新实例化窗体
                        Dim newForm As New MainForm(f)
                        newForm.Show()
                        Return
                    ElseIf aa = DialogResult.Cancel Then
                        Return
                    End If
                Else
                    isLoadedProj = True
                End If
                Try
                    '拖入文件夹，则会当作工程
                    '扫描项目
                    dialogueNode.Nodes.Clear()
                    setDialogueNode(f, dialogueNode)
                    ContentPanel.Controls.Clear()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                Exit For
            End If
        Next

    End Sub

    Private Sub setDialogueNode(d As DirectoryInfo, ByRef lastNode As TreeNode)
        Dim formatList As New List(Of DialogDetailsControl)
        For Each j As FileInfo In d.GetFiles
            If j.Extension = ".json" Then
                Try
                    Dim tt As JsonFormatMain = npcDialogDatas.addDialogFile(j)
                    formatList.Add(New DialogDetailsControl(tt, npcDialogDatas.getLangDic))
                Catch ex As Exception

                End Try
            End If
        Next
        lastNode.Tag = New TreeNodeWithList With {.Directory = d, .storyList = formatList}
        For Each i As DirectoryInfo In d.GetDirectories
            Dim t As TreeNode = lastNode.Nodes.Add(i.Name)
            t.ToolTipText = i.FullName

            setDialogueNode(i, t)
        Next
    End Sub

    Private Sub ContentPanelReset()
        ContentPanel.Controls.Clear()
        For Each i As JsonFormatMain In npcDialogDatas.getAllDialogs
            Dim c As New DialogDetailsControl(i, npcDialogDatas.getLangDic)
            ContentPanel.Controls.Add(c)
        Next

    End Sub

    Private Class TreeNodeWithList
        Public storyList As List(Of DialogDetailsControl)
        Public Directory As DirectoryInfo
    End Class

    Private Sub OpenLang_Click(sender As Object, e As EventArgs) Handles OpenLang.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ProjTree_DragDrop(Nothing, New DragEventArgs(New DataObject(DataFormats.FileDrop, OpenFileDialog1.FileNames), -1, 0, 0, DragDropEffects.All, DragDropEffects.All))
        End If
    End Sub

    Private Sub OpenDialog_Click(sender As Object, e As EventArgs) Handles OpenDialog.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim t As String() = {FolderBrowserDialog1.SelectedPath}
            ProjTree_DragDrop(Nothing, New DragEventArgs(New DataObject(DataFormats.FileDrop, t), -1, 0, 0, DragDropEffects.All, DragDropEffects.All))
        End If
    End Sub

    Private Sub AddFolder_Click(sender As Object, e As EventArgs) Handles AddFolder.Click
        Dim p As String = CType(ProjTree.SelectedNode.Tag, TreeNodeWithList).Directory.FullName
        Dim t As New AddFolder(p)
        If t.ShowDialog() = DialogResult.OK Then
            Try
                Dim dir As DirectoryInfo = Directory.CreateDirectory(t.pathStr)
                Dim node As TreeNode = ProjTree.SelectedNode.Nodes.Add(dir.Name)
                node.ToolTipText = dir.FullName
                node.Tag = New TreeNodeWithList With {.Directory = dir, .storyList = New List(Of DialogDetailsControl)}
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

End Class
