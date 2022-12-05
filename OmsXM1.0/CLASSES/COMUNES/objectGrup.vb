Public Class objectGrup(Of T)
    Public Property id As Integer
    Public Property objects As List(Of T)
    Public Sub New()
        objects = New List(Of T)
    End Sub
    Public Sub New(pId As Integer, pObjects As List(Of T))
        _objects = pObjects
        _id = pId
    End Sub
    Public Overrides Function GetHashCode() As Integer
        Return _id
    End Function
    Public Function insertar(s As T) As Boolean
        If objects Is Nothing Then objects = New List(Of T)
        objects.Add(s)
        Return True
    End Function
    Public Function actualitzar(s As T) As Boolean
        Call eliminar(s)
        Call insertar(s)
        Return True
    End Function
    Public Function eliminar(s As T) As Boolean
        objects.Remove(s)
        Return True
    End Function
    Protected Overrides Sub Finalize()
        objects = Nothing
        MyBase.Finalize()
    End Sub
End Class
