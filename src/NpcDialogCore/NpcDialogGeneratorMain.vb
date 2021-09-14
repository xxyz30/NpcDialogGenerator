Imports System.IO
Imports System.Text
Imports System.Text.Json

Public Class NpcDialogGeneratorMain
    Public Shared JsonReadOption As New JsonSerializerOptions With {.ReadCommentHandling = JsonCommentHandling.Skip}

    ''' <summary>
    ''' lang���ֵ�
    ''' </summary>
    Private langDic As New Dictionary(Of String, String)
    ''' <summary>
    ''' һ������
    ''' </summary>
    Private line As New List(Of String)
    ''' <summary>
    ''' lang�ļ�
    ''' </summary>
    Private langFile As New List(Of FileInfo)
    ''' <summary>
    ''' ���е�dialogue�ļ�����
    ''' </summary>
    Private dialogueFile As New List(Of FileInfo)
    ''' <summary>
    ''' dialogue����
    ''' </summary>
    Private dialogs As New List(Of JsonFormatMain)
    ''' <summary>
    ''' ����һ��lang�ļ�
    ''' </summary>
    ''' <param name="languageFile">languageFile</param>
    Public Sub addLanguage(languageFile As FileInfo)
        Try
            Using sr As StreamReader = languageFile.OpenText
                Dim aLine As String
                While sr.Peek <> -1
                    aLine = sr.ReadLine
                    line.Add(aLine)
                    '��ȡ�Ⱥ�
                    If Not aLine.StartsWith("##") Then
                        Dim t As String() = aLine.Split("=")
                        If t.Length >= 2 Then
                            '�Ϸ�ӳ��
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
