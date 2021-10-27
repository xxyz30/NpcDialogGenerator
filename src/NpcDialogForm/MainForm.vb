Imports NpcDialogCore
Imports System.IO
Imports System.Text
Imports System.Text.Encodings.Web
Imports System.Text.Json
Imports System.Text.Unicode

Public Class MainForm
    Private npcDialogDatas As New NpcDialogGeneratorMain
    Private isLoadedProj As Boolean = False
    Private projPath As FileInfo
    Public Shared ReadOnly JsonWriteOptions As New JsonSerializerOptions With {.IgnoreNullValues = True, .WriteIndented = True, .Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin)}
    Public Sub New()
        InitializeComponent()
        langNode = ProjTree.Nodes(0)
        dialogueNode = ProjTree.Nodes(1)
        AddFolder.Enabled = False
        AddNewDialogGroup.Enabled = False
    End Sub
    Public Sub New(p As FileInfo)
        MyClass.New()
        loadProj(p)
        'If loadProj(p) Then

        'End If
    End Sub
    ''' <summary>
    ''' 加载项目
    ''' </summary>
    ''' <param name="f"></param>
    ''' <returns></returns>
    Private Function loadProj(f As FileInfo) As Boolean
        Try
            '打开新项目
            '扫描项目
            Dim proj As New ProjectParser(f.FullName)
            Me.npcDialogDatas.project = proj

            setLangNode(proj.langs)

            dialogueNode.Nodes.Clear()
            setDialogueNode(proj.dialogue, dialogueNode)

            ContentPanel.Controls.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        isLoadedProj = True
        AddFolder.Enabled = True
        AddNewDialogGroup.Enabled = True
        projPath = f
        Return True
    End Function


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
                        npcDialogDatas.project.addLang(p)
                    Catch ex As Exception

                    End Try
                ElseIf i.ToLower.EndsWith(".npc_dia.json") Then
                    '是一个项目文件
                    Dim f As New FileInfo(i)
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
                        Try
                            loadProj(f)
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                End If

            ElseIf Directory.Exists(i) Then
                Dim f As New DirectoryInfo(i)
                If isLoadedProj Then
                    Dim aa As DialogResult = MsgBox("打开新窗口？", vbYesNoCancel + vbQuestion, "询问")
                    If aa = DialogResult.Yes Then
                        '新实例化窗体
                        'Dim newForm As New MainForm(f)
                        'newForm.Show()
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
    Private Sub setLangNode(l As List(Of FileInfo))
        langNode.Nodes.Clear()
        If l Is Nothing Then Return
        For Each i As FileInfo In l
            npcDialogDatas.addLanguage(i)
            langNode.Nodes.Add(i.Name).ToolTipText = i.FullName
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

    Private Sub AddNewDialogGroup_Click(sender As Object, e As EventArgs) Handles AddNewDialogGroup.Click
        Dim node As TreeNode = ProjTree.SelectedNode
        Dim dir As TreeNodeWithList = node.Tag
        Dim t As New AddDialogue(npcDialogDatas.getLangDic)
        If t.ShowDialog = DialogResult.OK Then
            Dim jsonStr As String = JsonSerializer.Serialize(t.JsonStr, JsonWriteOptions)
            '尝试创建文件和写入内容
            Dim p As New FileInfo(Path.Combine(dir.Directory.FullName, t.dialogueName + ".json"))
            Try
                Using sr As FileStream = p.Create
                    sr.Write(New UTF8Encoding(True).GetBytes(jsonStr), 0, jsonStr.Length)
                    sr.Close()
                End Using
                dir.storyList.Add(New DialogDetailsControl(t.JsonStr, npcDialogDatas.getLangDic))
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    Private Sub addActor_Click(sender As Object, e As EventArgs) Handles addActor.Click
        Dim d As New ActorEditor(npcDialogDatas)
        d.ShowDialog()
    End Sub

    Private Sub SaveProj_Click(sender As Object, e As EventArgs) Handles SaveProj.Click
        If projPath IsNot Nothing Then
            Using sw As New StreamWriter(projPath.FullName, False)
                sw.Write(JsonSerializer.Serialize(npcDialogDatas.project.proj))
            End Using
        Else
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                projPath = New FileInfo(SaveFileDialog1.FileName)
                SaveProj_Click(sender, e)
            End If
        End If
    End Sub
End Class
