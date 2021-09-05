Imports System.IO
Imports System.Text
Imports System.Text.Json

Public Class NpcDialogGeneratorMain
    ''' <summary>
    ''' lang的字典
    ''' </summary>
    Private langDic As New Dictionary(Of String, String)
    ''' <summary>
    ''' 一行内容
    ''' </summary>
    Private line As New List(Of String)

    Private dialogs As New List(Of JsonFormatMain)
    ''' <summary>
    ''' New Object 
    ''' </summary>
    ''' <param name="languageFile">languageFile</param>
    Public Sub New(languageFile As FileInfo)
        Try

            Using sr As StreamReader = languageFile.OpenText
                Dim aLine As String
                While sr.Peek
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

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub addDialogFile(f As FileInfo)
        Try
            Dim str As String = f.OpenText.ReadToEnd
            Dim t As JsonFormatMain = JsonSerializer.Deserialize(str, GetType(JsonFormatMain))
            dialogs.Add(t)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub addDialogFolder(d As DirectoryInfo)
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
End Class
