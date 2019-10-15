Option Explicit On
Module ModelProvincia
    Private auxiliar As ModelAuxiliar
    Public Function getAuxiliar() As ModelAuxiliar
        If auxiliar Is Nothing Then auxiliar = New ModelAuxiliar(DBCONNECT.getTaulaProvincia)
        Return auxiliar
    End Function
    Public Sub resetIndex()
        auxiliar = Nothing
    End Sub
    '    Private objects As List(Of Provincia)
    '    Private dateUpdate As DateTime
    '    Public Function getObjects(Optional filtre As String = "") As List(Of Provincia)
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        Return objects.FindAll(Function(x) x.isFilter(filtre))
    '    End Function
    '    Public Function getDataList(provincies As List(Of Provincia)) As DataList
    '        Dim c As Provincia
    '        getDataList = New DataList
    '        provincies.Sort()
    '        If provincies.Count > 0 Then
    '            getDataList.columns.Add(COLUMN.ID)
    '            getDataList.columns.Add(COLUMN.CODI)
    '            getDataList.columns.Add(COLUMN.NOM)
    '            For Each c In provincies
    '                getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom}))
    '            Next
    '        End If
    '        c = Nothing
    '    End Function
    '    Public Function getListObjects() As Object()
    '        Dim obj As Object, i As Integer = 0, objectes() As Object
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        ReDim objectes(objects.Count - 1)
    '        For Each obj In objects
    '            objectes(i) = obj
    '            i = i + 1
    '        Next
    '        getListObjects = objectes
    '        objectes = Nothing
    '        obj = Nothing
    '    End Function
    '    Public Function getObject(id As Integer) As Provincia
    '        Dim p As Provincia
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        p = objects.Find(Function(x) x.id = id)
    '        If p Is Nothing Then p = New Provincia
    '        Return p
    '    End Function
    '    Public Function exist(obj As Provincia) As Boolean
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        Return objects.Exists(Function(x) x.id <> obj.id And x.nom = obj.nom)
    '    End Function
    '    Public Function existCodi(obj As Provincia) As Integer
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    '    End Function
    '    Public Function save(obj As Provincia) As Integer
    '        If obj.id = -1 Then
    '            obj.id = dbProvincia.insert(obj)
    '        Else
    '            obj.id = dbProvincia.update(obj)
    '        End If
    '        If obj.id > -1 Then
    '            dateUpdate = Now()
    '            objects.Remove(obj)
    '            objects.Add(obj)
    '        End If
    '        Return obj.id
    '    End Function
    '    Public Function remove(obj As Provincia) As Boolean
    '        Dim result As Boolean
    '        result = dbProvincia.remove(obj)
    '        If result Then
    '            dateUpdate = Now()
    '            objects.Remove(obj)
    '        End If
    '        Return result
    '    End Function

    '    Public Sub resetIndex()
    '        objects = Nothing
    '    End Sub

    '    Private Function getRemoteObjects() As List(Of Provincia)
    '        dateUpdate = Now()
    '        Return dbProvincia.getObjects
    '    End Function
    '    ''' <summary>
    '    ''' Comprova si s'ha actualitzat la BBDD
    '    ''' </summary>
    '    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    '    Private Function isUpdated() As Boolean
    '        If Not objects Is Nothing Then
    '            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaProvincia)
    '        Else
    '            Return False
    '        End If
    '        If isUpdated Then dateUpdate = Now
    '    End Function
End Module
