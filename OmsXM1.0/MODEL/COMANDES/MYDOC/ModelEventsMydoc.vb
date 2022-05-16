Option Explicit On
Module ModelEventsMyDOc
    Private objects As List(Of EventsMD)
    Public Function getObjects(idRecurs As Integer) As List(Of EventsMD)
        Dim objectesActuals As List(Of EventsMD), e As EventsMD
        If Not isUpdated() Then objects = getRemoteObjects()
        objectesActuals = objects.FindAll(Function(x) x.idRecurs = idRecurs)
        If objectesActuals.Count = 0 Then
            objectesActuals = dbEventsMD.getObjects(idRecurs)
            If Not IsNothing(objectesActuals) Then
                For Each e In objectesActuals
                    objects.Add(e)
                Next
            End If
        End If
        Return objectesActuals
    End Function

    Public Function getObject(id As Integer, idTaula As Integer) As EventsMD
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function

    Public Function save(obj As EventsMD) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        If obj.id = -1 Then
            obj.id = dbEventsMD.insert(obj)
        Else
            obj.id = dbEventsMD.update(obj.id, obj.finalitzat, obj.idUsuari)
        End If
        If obj.id > -1 Then
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub resetIndex(idTaula As Integer)
        objects(idTaula) = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of EventsMD)
        Return dbEventsMD.getObjects()
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
