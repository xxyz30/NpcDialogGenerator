''' <summary>
''' 本类用于存储项目
''' </summary>
Public Class ProjectClass
    ''' <summary>
    ''' lang文件数组
    ''' </summary>
    ''' <returns></returns>
    Public Property langs As List(Of String)
    ''' <summary>
    ''' dialogue文件夹路径
    ''' </summary>
    ''' <returns></returns>
    Public Property dialogue As String
    ''' <summary>
    ''' 创建的角色
    ''' </summary>
    ''' <returns></returns>
    Public Property actors As List(Of Character)


    Public Class Character
        Public Property name As String

    End Class
End Class
