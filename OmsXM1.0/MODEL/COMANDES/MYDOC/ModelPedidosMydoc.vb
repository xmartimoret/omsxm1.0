Module ModelPedidosMydoc
    Private objects As List(Of PedidoMD)
    Public Function getRemoteObject(id As Integer) As PedidoMD
        Dim p As PedidoMD
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.Find(Function(x) x.id = id)
        If IsNothing(p) Then
            p = dbPedidosMD.getObject(id)
            If Not IsNothing(p) Then objects.Add(p)
        End If
        Return p
    End Function
    Public Function getObject(id As Integer) As PedidoMD
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function


    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub setdata()
        If Not isUpdated() Then objects = getRemoteObjects()
    End Sub
    Public Function save(obj As PedidoMD) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        If dbPedidosMD.update(obj.id, obj.estat) Then
            objects.Remove(obj)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function
    Public Function updateEnviado(obj As PedidoMD) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        If dbPedidosMD.updateEnviado(obj.id, obj.estat) Then
            objects.Remove(obj)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function
    Private Function getRemoteObjects() As List(Of PedidoMD)
        Return dbPedidosMD.getObjects
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
