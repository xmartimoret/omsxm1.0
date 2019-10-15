Option Explicit On
Module ModelProjecteClient
    Private objects As List(Of ProjecteClient)

    Private dateUpdate As DateTime
    Private Const N_COLUMNS As Integer = 5
    Public Function getObjects(idClient As Integer, Optional idEmpresa As Integer = 0) As List(Of ProjecteClient)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idClient = idClient And (x.idEmpresa = idEmpresa Or idEmpresa = 0))
    End Function

    ''' <summary>
    ''' Obté una llista(Datalist) per poder presentar a l'usuari mitjançant un formulari
    ''' </summary>
    ''' <param name="projectesClients">Conjunt d'objectes a llistar</param>
    ''' <returns>DataList  amb les dades dels objectes que s'han passat com a paràmetre</returns>
    Public Function getDataList(projectesClients As List(Of ProjecteClient)) As DataList
        Dim obj As ProjecteClient, p As Projecte
        getDataList = New DataList

        If projectesClients.Count > 0 Then
            projectesClients.Sort()
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            For Each obj In projectesClients
                p = ModelProjecte.getObject(obj.idProjecte)
                If p IsNot Nothing Then
                    getDataList.rows.Add(New ListViewItem(New String() {obj.idProjecte, obj.idClient, ModelEmpresa.getObject(p.idEmpresa).nom, p.codi, p.nom}))
                End If
            Next
        End If
        obj = Nothing
        p = Nothing
    End Function


    Public Function getObject(idClient As Integer, idProjecte As Integer) As ProjecteClient
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idProjecte = idProjecte And x.idClient = idClient)
    End Function
    Public Function getObject(idProjecte As Integer) As ProjecteClient
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idProjecte = idProjecte)
    End Function
    Public Function save(obj As ProjecteClient) As Boolean
        Dim result As Boolean
        If Not exist(obj) Then
            result = dbProjecteClient.insert(obj)
        Else
            result = dbProjecteClient.Update(obj)
        End If
        If result Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function

    Public Function remove(idProjecte As Integer, idClient As Integer) As Boolean
        If dbProjecteClient.remove(idProjecte, idClient) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idProjecte = idProjecte And x.idClient = idClient)
            Return True
        End If
        Return False
    End Function
    Public Function removeClient(idClient As Integer) As Boolean
        If dbProjecteClient.removeClient(idClient) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idClient = idClient)
            Return True
        End If
        Return False
    End Function
    Public Function exist(idClient As Integer, idProjecte As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = idProjecte And x.idClient = idClient)
    End Function
    Public Function exist(obj As ProjecteClient) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = obj.idProjecte And x.idClient = obj.idClient)
    End Function
    Public Function existProjecte(idProjecte As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = idProjecte)
    End Function
    Private Function getIdMaxOrder(idClient As Integer) As Integer
        Dim obj As ProjecteClient
        If Not isUpdated() Then objects = getRemoteObjects()
        getIdMaxOrder = 0
        For Each obj In objects
            If obj.idClient = idClient Then
                If obj.ordre > getIdMaxOrder Then
                    getIdMaxOrder = obj.ordre
                End If
            End If
        Next obj
        obj = Nothing
    End Function

    Public Sub changeOrder(pc1 As ProjecteClient, pc2 As ProjecteClient)
        Dim temp As String
        temp = pc1.ordre
        pc1.ordre = pc2.ordre
        pc2.ordre = temp
        Call save(pc1)
        Call save(pc2)
    End Sub


    Public Function getTotalProjectes() As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Count
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    ''notes xmarti cal provar
    'Public Sub reOrdenar()
    '    Dim i As Integer, pc As ProjecteClient
    '    If Not isUpdated() Then objects = getRemoteObjects()
    '    i = 1
    '    For Each pc In objects
    '        pc.ordre = i
    '        Call save(pc)
    '        i = +1
    '    Next
    '    pc = Nothing
    'End Sub
    Private Function getRemoteObjects() As List(Of ProjecteClient)
        dateUpdate = Now()
        Return dbProjecteClient.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaProjectesClient
    End Function

End Module
