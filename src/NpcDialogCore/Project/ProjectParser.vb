Imports System.IO
Imports System.Text.Json
Imports NpcDialogCore.NpcDialogGeneratorMain
Imports NpcDialogCore.ProjectClass

Public Class ProjectParser
    Public Property langs As List(Of FileInfo)
    Public Property dialogue As DirectoryInfo

    Public Property actors As List(Of Character)

    Public proj As ProjectClass

    Public Sub New(path As String)
        Try
            Dim f As New FileInfo(path)
            If f.Exists Then
                Dim projStr As String
                Using sr As StreamReader = f.OpenText
                    projStr = sr.ReadToEnd
                End Using

                Dim proj As ProjectClass = JsonSerializer.Deserialize(projStr, GetType(ProjectClass), JsonReadOption)
                Me.proj = proj
                Me.actors = proj.actors
                dialogue = New DirectoryInfo(proj.dialogue)
                langs = New List(Of FileInfo)
                For Each i As String In proj.langs
                    langs.Add(New FileInfo(i))
                Next
            End If
        Catch
            Throw New Exception($"出现错误了！{vbCrLf}检查一下是否是正确的工程项目？")
        End Try
    End Sub
    Public Sub New()
        Me.proj = New ProjectClass
    End Sub
    Public Sub setActors(l As List(Of Character))
        Me.actors = l
        proj.actors = l
    End Sub
    Public Sub addLang(p As FileInfo)
        langs.Add(p)
        proj.langs.Add(p.FullName)
    End Sub
End Class
