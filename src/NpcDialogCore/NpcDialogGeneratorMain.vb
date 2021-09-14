Imports System.IO
Imports System.Text
Imports System.Text.Json

Public Class NpcDialogGeneratorMain
    Public Shared JsonReadOption As New JsonSerializerOptions With {.ReadCommentHandling = JsonCommentHandling.Skip}

    ''' <summary>
    ''' lang的字典
    ''' </summary>
    Private langDic As New Dictionary(Of String, String)
    ''' <summary>
    ''' 一行内容
    ''' </summary>
    Private line As New List(Of String)
    ''' <summary>
    ''' lang文件
    ''' </summary>
    Private langFile As New List(Of FileInfo)
    ''' <summary>
    ''' 所有的dialogue文件定义
    ''' </summary>
    Private dialogueFile As New List(Of FileInfo)
    ''' <summary>
    ''' dialogue定义
    ''' </summary>
    Private dialogs As New List(Of JsonFormatMain)
    ''' <summary>
    ''' 增加一个lang文件
    ''' </summary>
    ''' <param name="languageFile">languageFile</param>
    Public Sub addLanguage(languageFile As FileInfo)
        Try
            Using sr As StreamReader = languageFile.OpenText
                Dim aLine As String
                While sr.Peek <> -1
                    aLine = sr.ReadLine
                    line.Add(aLine)
                    '读取等号
                    If Not aLine.StartsWith("##") Then
                        Dim t As String() = aLine.Split("=")
                        If t.Length >= 2 Then
                            '合法映射
                            Dim tt As String = ""
                            For i As Integer = 1 To t.Length - 1
                                tt += t(i)
                            Next
                            langDic.Add(t(0), tt)
                        End If
                    End If
                End While
                sr.Close()
            End Using
            langFile.Add(languageFile)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function addDialogFile(f As FileInfo) As JsonFormatMain
        Try
            Dim str As String = f.OpenText.ReadToEnd
            Dim t As JsonFormatMain = JsonSerializer.Deserialize(str, GetType(JsonFormatMain), JsonReadOption)
            dialogs.Add(t)
            dialogueFile.Add(f)
            Return t
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub addDialogFolder(d As DirectoryInfo)
        dialogs.Clear()
        Try
            For Each i As FileInfo In d.GetFiles("*.json")
                Try
                    addDialogFile(i)
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getAllDialogs() As List(Of JsonFormatMain)
        Return dialogs
    End Function

    Public Function getLangDic() As Dictionary(Of String, String)
        Return langDic
    End Function
End Class
