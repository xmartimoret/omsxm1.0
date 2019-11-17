Option Explicit On
Module ModelProjecteEntrega
    Private objects As List(Of projecteEntrega)
    Private dateUpdate As DateTime
    Public Function getObjects(idProjecte As Integer) As List(Of projecteEntrega)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idProjecte = idProjecte)
    End Function
    Public Function getDataList(entregues As List(Of projecteEntrega)) As DataList
        Dim pc As projecteEntrega, c As LlocEntrega
        getDataList = New DataList

        If entregues.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA("poblacio", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("provincia", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each pc In entregues
                c = ModelLlocEntrega.getObject(pc.idEntrega)
                If Not IsNothing(c) Then
                    If c.provincia Is Nothing Then c.provincia = New Provincia
                    If c.estat Then
                        getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("actiu")}))
                    Else
                        getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("noActiu")}))
                    End If
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getObject(idProjecte As Integer, idEntrega As Integer) As projecteEntrega
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idProjecte = idProjecte And x.idEntrega = idEntrega)
    End Function
    Public Function exist(idProjecte As Integer, idEntrega As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = idProjecte And x.idEntrega = idEntrega)
    End Function
    Public Function save(obj As projecteEntrega) As Integer
        Dim id As Integer
        id = dbProjecteEntrega.insert(obj)
        If id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return id
    End Function

    Public Function remove(obj As projecteEntrega) As Boolean
        Dim result As Boolean
        result = dbProjecteEntrega.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Function removePare(id As Integer) As Boolean
        Return dbProjecteEntrega.removePare(id)
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of projecteEntrega)
        dateUpdate = Now()
        Return dbProjecteEntrega.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaProjecteEntrega)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
