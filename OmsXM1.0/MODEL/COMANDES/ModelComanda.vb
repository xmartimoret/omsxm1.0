Option Explicit On
Module ModelComanda
    Private objects As List(Of Comanda)
    Private dateUpdate As DateTime
    Private anyActual As Integer
    Public Function getObjects(anyo As Integer, Optional filtre As String = "") As List(Of Comanda)
        Dim a As Comanda, altres As String = ""
        If Not isUpdated(anyo) Then objects = getRemoteObjects(anyo)
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
            getDataList.columns.Add(COLUMN.GENERICA("codi", 200, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("data", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("proveidor", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))
            For Each a In comandes
                If a.empresa Is Nothing Then a.empresa = New Empresa
                If a.projecte Is Nothing Then a.projecte = New Projecte
                If a.proveidor Is Nothing Then a.proveidor = New Proveidor
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, a.base, a.iva, a.total}))
            Next
        End If
        a = Nothing
    End Function
    Public Function getObject(id As Integer) As Comanda
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        Return objects.Find(Function(x) x.id = id)
    End Function

    Public Function getCodi(id As Integer) As String
        Dim c As Comanda
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        c = objects.Find(Function(x) x.id = id)
        If c IsNot Nothing Then Return c.codi
        Return Nothing
    End Function
    Private Function getLastCodiEmpresa(idEmpresa As Integer, anyo As Integer) As Integer
        Dim c As Comanda, id As Integer
        If Not isUpdated(anyo) Then objects = getRemoteObjects(anyo)
        id = 1
        For Each c In objects
            If idEmpresa = c.empresa.id Then
                If id < Val(c.codi) Then
                    id = Val(c.codi)
                End If
            End If
        Next
        Return id
    End Function
    Public Function getNom(id As Integer) As String
        Dim a As Comanda
        getNom = ""
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        a = objects.Find(Function(x) x.id = id)
        If a IsNot Nothing Then getNom = a.nom
        a = Nothing
    End Function


    Public Function exist(obj As Comanda) As Boolean
        If Not isUpdated(obj.getAnyo) Then objects = getRemoteObjects(obj.getAnyo)
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existCodi(obj As Comanda) As Integer
        If Not isUpdated(Year(obj.data)) Then objects = getRemoteObjects(Year(obj.data))
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function save(obj As Comanda) As Integer
        If Not isUpdated(obj.getAnyo) Then objects = getRemoteObjects(obj.getAnyo)
        If obj.id = -1 Then
            obj.codi = getLastCodiEmpresa(obj.empresa.id, obj.getAnyo) + 1
            obj.id = dbComanda.insert(obj)
        Else
            obj.id = dbComanda.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            If Not ModelarticleComanda.saveComanda(obj.articles) Then Return -1
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

    Private Function getRemoteObjects(anyo As Integer) As List(Of Comanda)
        dateUpdate = Now()
        Return dbComanda.getObjects(anyo)
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated(anyo As Integer) As Boolean
        If Not objects Is Nothing Then
            If anyActual <> anyo Then
                anyActual = anyo
                Return False
            Else
                isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaComanda)
            End If
        Else
            anyActual = anyo
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function


End Module
