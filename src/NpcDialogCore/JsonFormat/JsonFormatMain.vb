Imports System.Text.Json.Serialization
Public Class JsonFormatMain
    Public Property format_version As String

    <JsonPropertyName("minecraft:npc_dialogue")>
    Public Property dialog As Scenes
    Public Shared Function getNew() As JsonFormatMain
        Dim t As New JsonFormatMain
        t.dialog = New Scenes
        t.format_version = "1.17"
        t.dialog.scenes = New List(Of Scenes.ScencesItem)
        Return t
    End Function
End Class
