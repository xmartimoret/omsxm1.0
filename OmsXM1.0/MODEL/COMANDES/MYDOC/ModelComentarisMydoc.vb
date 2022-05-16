Module ModelComentarisMydoc
    Private objects As List(Of ComentariMD)
    Public Function getObjects(idRecurs As Integer) As List(Of ComentariMD)
        Dim objectesActuals As List(Of ComentariMD)
        If Not isUpdated() Then objects = getRemoteObjects()
        objectesActuals = objects.FindAll(Function(x) x.idRecurs = idRecurs)
        Return objectesActuals
    End Function
    Public Function getObject(id As Integer) As ComentariMD
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub resetIndex(idTaula As Integer)
        objects(idTaula) = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of ComentariMD)
        Return dbComentarisMD.getObjects()
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If objects Is Nothing Then
            Return False
        End If
        Return True
    End Function

End Module
