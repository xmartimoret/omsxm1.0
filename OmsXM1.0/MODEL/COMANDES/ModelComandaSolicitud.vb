Option Explicit On
Module ModelComandaSolicitud
    Private Enum estat
        EN_EDICIO = 0
        ES_COMANDA
        ES_VALIDADA
        ES_ENVIADA
    End Enum

    Private objects As List(Of SolicitudComanda)
    Private objectsBySerie As Collection
    Private dateUpdate As DateTime
        Private anyActual As Integer
    Public Function getObjects(serie As String, Optional filtre As String = "") As List(Of SolicitudComanda)
        Dim a As SolicitudComanda, altres As String = ""
        If Not isUpdated() Then objects = getRemoteObjects(serie)
        getObjects = New List(Of SolicitudComanda)
        For Each a In objects
            If a.proveidor IsNot Nothing Then altres = a.proveidor
            If a.codiProjecte IsNot Nothing Then altres = altres & a.codiProjecte
            If a.empresa IsNot Nothing Then altres = altres & a.empresa
            If altres <> "" Then
                If a.isFilter(filtre, altres) Then
                    getObjects.Add(a)
                End If
            Else
                If a.isFilter(filtre) Then
                    getObjects.Add(a)
                End If
            End If
        Next
    End Function
    Public Function getDataList(comandes As List(Of SolicitudComanda)) As DataList
        Dim a As SolicitudComanda
        getDataList = New DataList
        comandes.Sort()
        If comandes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("codi", 200, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("data", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("proveidor", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Center))

            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))
            For Each a In comandes
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.dataComanda, a.empresa, a.codiProjecte, a.proveidor, a.base, a.total}))
            Next
        End If
        a = Nothing
    End Function
    Public Function getObject(id As Integer) As SolicitudComanda
        Return objects.Find(Function(x) x.id = id)
    End Function

    Public Function getCodi(id As Integer) As String
        Dim c As SolicitudComanda
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        c = objects.Find(Function(x) x.id = id)
            If c IsNot Nothing Then Return c.codi
            Return Nothing
        End Function
    Private Function getLastCodi() As Integer
        Dim c As SolicitudComanda, id As Integer
        If Not isUpdated() Then objects = getRemoteObjects(0)
        id = 1
        For Each c In objects
            If id < Val(c.codi) Then
                id = Val(c.codi)
            End If
        Next
        Return id
    End Function
    Public Function getNom(id As Integer) As String
        Dim a As SolicitudComanda
        getNom = ""
            'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
            a = objects.Find(Function(x) x.id = id)
            If a IsNot Nothing Then getNom = a.nom
            a = Nothing
        End Function


    Public Function exist(obj As SolicitudComanda) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects(0)
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existCodi(obj As SolicitudComanda) As Integer
        If Not isUpdated() Then objects = getRemoteObjects(0)
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function save(obj As SolicitudComanda) As Integer
        If obj.id = -1 Then
            obj.codi = getLastCodi() + 1
            If obj.serie = "" Then obj.serie = Year(obj.dataComanda)
            obj.id = dbSolicitudComanda.insert(obj)

        Else
            obj.id = dbSolicitudComanda.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            If Not ModelArticleSolicitut.save(obj.articles, obj.id) Then Return -1
        End If
        Return obj.id
    End Function
    Public Function remove(obj As SolicitudComanda) As Boolean
        Dim result As Boolean
        result = dbSolicitudComanda.remove(obj)
        If result Then
            result = ModelArticleSolicitut.remove(obj)
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
            objects = Nothing
        End Sub

    Private Function getRemoteObjects(estat As estat) As List(Of SolicitudComanda)
        dateUpdate = Now()
        Return dbSolicitudComanda.getObjects(estat)
    End Function
    Private Function getRemoteObjects(serie As String) As List(Of SolicitudComanda)
        dateUpdate = Now()
        Return dbSolicitudComanda.getObjects(serie)
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.GetTaulaSolicitudComanda)
        Else
            isUpdated = False
        End If
        If isUpdated Then dateUpdate = Now
    End Function

End Module
