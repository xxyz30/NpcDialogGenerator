Imports System.Text.Json
Public Class Scenes
    Implements ICloneable

    Public Property scenes As List(Of ScencesItem)

    Public Class ScencesItem
        Public Property scene_tag As String

        Public Property npc_name As Object
            Get
                Return npcName
            End Get
            Set(value As Object)
                npcName = parseRawText(value)
            End Set
        End Property
        Private npcName As Object
        Public Property text As Object
            Get
                Return contentText
            End Get
            Set(value As Object)
                contentText = parseRawText(value)
            End Set
        End Property
        Private contentText As Object

        Public Property on_open_commands As List(Of String)
        Public Property on_close_commands As List(Of String)

        Public Property buttons As List(Of buttonsClass)

        Public Class buttonsClass

            Private buttonName As Object
            Public Property name As Object
                Get
                    Return buttonName
                End Get
                Set(value As Object)
                    buttonName = parseRawText(value)
                End Set
            End Property

            Public Property commands As List(Of String)
        End Class
    End Class

    Private Shared Function parseRawText(v As JsonElement) As Object
        If v.ValueKind = JsonValueKind.String Then
            Return v.GetString
        ElseIf v.ValueKind = JsonValueKind.Object Then
            Try
                Dim t As RawText = JsonSerializer.Deserialize(v.ToString, GetType(RawText))
                Return t
            Catch ex As Exception
            End Try
        End If
        Return Nothing
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return JsonSerializer.Deserialize(JsonSerializer.Serialize(Me, New JsonSerializerOptions() With {.IgnoreNullValues = True}), Me.GetType)
    End Function
End Class
