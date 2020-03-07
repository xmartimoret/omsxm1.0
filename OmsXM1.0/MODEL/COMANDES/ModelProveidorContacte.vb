Option Explicit On
Module ModelProveidorContacte
    Private objects As List(Of ProveidorCont)
    Private dateUpdate As DateTime
    Public Function getObjects(idProveidor As Integer, Optional filtre As String = "") As List(Of ProveidorCont)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idProveidor = idProveidor And x.isFilter(filtre, x.poblacio))
    End Function
    Public Function getDataList(provincies As List(Of ProveidorCont)) As DataList
        Dim c As ProveidorCont
        getDataList = New DataList
        provincies.Sort()
        If provincies.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("departament", 70, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA("poblacio", 70, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("provincia", 70, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("telefon", 70, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("telefon", 70, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("email", 70, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each c In provincies
                If c.provincia Is Nothing Then
                    c.provincia = New Provincia
                End If
                getDataList.rows.Add(New ListViewItem(New String() {c.id, c.departament, c.nom, c.poblacio, c.provincia.nom, c.telefon1, c.telefon2, c.email, c.actiu}))
            Next
        End If
        c = Nothing
    End Function
    Public Function getObject(id As Integer) As ProveidorCont
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function exist(obj As ProveidorCont) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.departament = obj.departament And x.nom = obj.nom)
    End Function

    Public Function save(obj As ProveidorCont) As Integer
        If obj.id = -1 Then
            obj.id = dbProveidorCont.insert(obj)
        Else
            obj.id = dbProveidorCont.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As ProveidorCont) As Boolean
        Dim result As Boolean
        result = dbProveidorCont.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Function removePare(id As Integer) As Boolean
        Return dbProveidorCont.removePare(id)
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of ProveidorCont)
        dateUpdate = Now()
        Return dbProveidorCont.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaProveidorContacte)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
