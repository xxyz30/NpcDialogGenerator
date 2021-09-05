Imports System.Text.Json.Serialization
Imports System.Text.Json
Public Class RawText
    Public Property rawtext As List(Of rawTextItem)

    Public Class rawTextItem
        Public Property text As String
        Public Property translate As String
        <JsonPropertyName("with")>
        Public Property withList As List(Of Object) '这玩意能塞下一个新的rawtext类
            Get
                Return withListItem
            End Get
            Set(v As List(Of Object))
                Dim t As New List(Of Object)
                For i As Integer = 0 To v.Count - 1
                    If TypeOf v(i) Is String Then
                        t.Add(v(i))
                    ElseIf TypeOf v(i) Is JsonElement Then
                        Try
                            Dim tt As RawText = JsonSerializer.Deserialize(v(i).ToString, GetType(RawText))
                            t.Add(tt)
                        Catch ex As Exception

                        End Try
                    End If
                Next
                withListItem = t
            End Set
        End Property
        Private withListItem As List(Of Object)

        Public Property selector As String

        Public Property score As ScoreItem

        Public Class ScoreItem
            Public Property name As String
            Public Property objective As String
            Public Property value As Integer
        End Class

    End Class
End Class
