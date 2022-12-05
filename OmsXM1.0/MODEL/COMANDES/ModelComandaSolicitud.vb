Option Explicit On
Module ModelComandaSolicitud
    Private Enum estat
        pendentEliminar = -1
        enEdicio = 0
        validada = 1
    End Enum
    Private objects As List(Of SolicitudComanda)
    Private dateUpdate As DateTime
    Private estatActual As estat
    Public Function getObjects(e As Integer, Optional filtre As String = "") As List(Of SolicitudComanda)
        Dim a As SolicitudComanda, altres As String = ""
        If Not isUpdated(e) Then objects = getRemoteObjects(e)
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
    Public Function getListViewItem(a As SolicitudComanda) As ListViewItem
        Return New ListViewItem(New String() {a.id, a.codi, a.dataComanda, a.empresa, a.codiProjecte, a.proveidor, a.base, a.total})
    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim a As SolicitudComanda
        a = getObject(id)
        If a IsNot Nothing Then
            Return New ListViewItem(New String() {a.id, a.codi, a.dataComanda, a.empresa, a.codiProjecte, a.proveidor, a.base, a.total})
        End If
        Return Nothing
    End Function
    Public Function getObject(id As Integer, e As Integer) As SolicitudComanda
        If Not isUpdated(e) Then objects = getRemoteObjects(e)
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(id As Integer) As SolicitudComanda
        If Not isUpdated(estatActual) Then objects = getRemoteObjects(estatActual)
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getCodi(id As Integer, e As Integer) As String
        Dim c As SolicitudComanda
        If Not isUpdated(e) Then objects = getRemoteObjects(e)
        c = objects.Find(Function(x) x.id = id)
        If c IsNot Nothing Then Return c.codi
        Return Nothing
    End Function
    'Private Function getLastCodi() As Integer
    '    Dim c As SolicitudComanda, id As Integer
    '    If Not isUpdated(e) Then objects = getRemoteObjects(0)
    '    id = 1
    '    For Each c In objects
    '        If id < Val(c.codi) Then
    '            id = Val(c.codi)
    '        End If
    '    Next
    '    Return id
    'End Function
    Public Function getNom(id As Integer, e As Integer) As String
        Dim a As SolicitudComanda
        getNom = ""
        If Not isUpdated(e) Then objects = getRemoteObjects(e)
        a = objects.Find(Function(x) x.id = id)
        If a IsNot Nothing Then getNom = a.nom
        a = Nothing
    End Function


    Public Function exist(obj As SolicitudComanda, e As Integer) As Boolean
        If Not isUpdated(e) Then objects = getRemoteObjects(e)
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existCodi(obj As SolicitudComanda, e As Integer) As Integer
        If Not isUpdated(e) Then objects = getRemoteObjects(e)
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function save(obj As SolicitudComanda) As Integer
        If Not isUpdated(obj.estat) Then objects = getRemoteObjects(obj.estat)
        If obj.id = -1 Then
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
        If Not isUpdated(obj.estat) Then objects = getRemoteObjects(obj.estat)

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

    Private Function getRemoteObjects(estat As Integer) As List(Of SolicitudComanda)
        Dim s As SolicitudComanda
        'getRemoteObjects = New List(Of SolicitudComanda)
        dateUpdate = Now()
        estatActual = estat
        Return dbSolicitudComanda.getObjects(estat)
        ' todo es fa prova i no ees carreguen els articles 
        'For Each s In dbSolicitudComanda.getObjects(estat)
        '    s.articles = ModelArticleSolicitut.getObjects(s.id)
        '    getRemoteObjects.Add(s)
        'Next
    End Function

    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated(e As Integer) As Boolean
        If e <> estatActual Then Return False
        If Not objects Is Nothing Then
            Return DBCONNECT.isUpdated(dateUpdate, DBCONNECT.GetTaulaSolicitudComanda)
        Else
            Return False
        End If
    End Function

End Module
