Imports System.Text.Json.Serialization
Public Class JsonFormatMain
    Public Property format_version As String

    <JsonPropertyName("minecraft:npc_dialogue")>
    Public Property dialog As Scenes
End Class
