Option Explicit On
Module ModelClient
    Private objects As List(Of Client)

    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of Client)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getDataList(clients As List(Of Client)) As DataList
        Dim c As Client
        getDataList = New DataList
        clients.Sort()
        If clients.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.NOTES)
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each c In clients
                If c.actiu Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.notes, IDIOMA.getString("actiu")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.notes, IDIOMA.getString("noActiu")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getObject(id As Integer) As Client
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function exist(obj As Client) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.nom = obj.nom)
    End Function

    Public Function save(obj As Client) As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrder() + 1
            obj.id = dbClient.insert(obj)
        Else
            obj.id = dbClient.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As Client) As Boolean
        Dim result As Boolean
        result = dbClient.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Private Function getMaxOrder() As Integer
        Dim obj As Client
        getMaxOrder = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If Val(obj.ordre) > getMaxOrder Then getMaxOrder = Val(obj.ordre)
        Next obj
        obj = Nothing
    End Function
    Public Sub changeOrder(obj1 As Client, obj2 As Client)
        Dim temp As String
        temp = obj1.ordre
        obj1.ordre = obj2.ordre
        obj2.ordre = temp
        Call save(obj1)
        Call save(obj2)
    End Sub
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub reOrdenar()
        Dim i As Integer, c As Client
        If Not isUpdated() Then objects = getRemoteObjects()
        objects.Sort()
        i = 1
        For Each c In objects
            c.ordre = i
            Call save(c)
            i = i + 1
        Next
        c = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of Client)
        dateUpdate = Now()
        Return dbClient.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaClient)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
