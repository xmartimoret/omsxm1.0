Option Explicit On
Module ModelComanda
    Private objects As List(Of Comanda)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of Comanda)
        Dim a As Comanda, altres As String = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of Comanda)
        For Each a In objects
            If a.proveidor IsNot Nothing Then altres = a.proveidor.nom
            If a.projecte IsNot Nothing Then altres = altres & a.projecte.nom
            If a.empresa IsNot Nothing Then altres = altres & a.empresa.nom
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
    Public Function getDataList(comandes As List(Of Comanda)) As DataList
        Dim a As Comanda
        getDataList = New DataList
        comandes.Sort()
        If comandes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("codi", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("data", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("proveidor", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("descompte", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))
            For Each a In comandes
                If a.empresa Is Nothing Then a.empresa = New Empresa
                If a.projecte Is Nothing Then a.projecte = New Projecte
                If a.proveidor Is Nothing Then a.proveidor = New Proveidor
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, a.base, a.descompte, a.iva, a.total}))
            Next
        End If
        a = Nothing
    End Function
    Public Function getObject(id As Integer) As Comanda
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function

    Public Function getCodi(id As Integer) As String
        Dim c As Comanda
        If Not isUpdated() Then objects = getRemoteObjects()
        c = objects.Find(Function(x) x.id = id)
        If c IsNot Nothing Then Return c.codi
        Return Nothing
    End Function
    Public Function getNom(id As Integer) As String
        Dim a As Comanda
        getNom = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        a = objects.Find(Function(x) x.id = id)
        If a IsNot Nothing Then getNom = a.nom
        a = Nothing
    End Function


    Public Function exist(obj As Comanda) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existCodi(obj As Comanda) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function save(obj As Comanda) As Integer
        If obj.id = -1 Then
            obj.id = dbComanda.insert(obj)
        Else
            obj.id = dbComanda.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As Comanda) As Boolean
        Dim result As Boolean
        result = dbComanda.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of Comanda)
        dateUpdate = Now()
        Return dbComanda.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaComanda)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function


End Module
