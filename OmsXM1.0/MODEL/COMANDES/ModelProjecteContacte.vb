Option Explicit On
Module ModelProjecteContacte
    Private objects As List(Of ProjecteContacte)
    Private dateUpdate As DateTime
    Public Function getObjects(idProjecte As Integer) As List(Of ProjecteContacte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idProjecte = idProjecte)
    End Function
    Public Function getDataList(contactes As List(Of ProjecteContacte)) As DataList
        Dim pc As ProjecteContacte, c As Contacte
        getDataList = New DataList

        If contactes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA("cognom", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("cognom", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("poblacio", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("provincia", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("telefon", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("email", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each pc In contactes
                c = ModelContacte.getObject(pc.idContacte)
                If c.provincia Is Nothing Then c.provincia = New Provincia
                If c.estat Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.cognom1, c.cognom2, c.poblacio, c.provincia.nom, c.telefon, c.email, IDIOMA.getString("actiu")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.cognom1, c.cognom2, c.poblacio, c.provincia.nom, c.telefon, c.email, IDIOMA.getString("noActiu")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getObject(idProjecte As Integer, idContacte As Integer) As ProjecteContacte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idProjecte = idProjecte And x.idContacte = idContacte)
    End Function
    Public Function exist(idProjecte As Integer, idContacte As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = idProjecte And x.idContacte = idContacte)
    End Function
    Public Function save(obj As ProjecteContacte) As Integer
        Dim id As Integer
        id = dbProjecteContacte.insert(obj)
        If id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return id
    End Function

    Public Function remove(obj As ProjecteContacte) As Boolean
        Dim result As Boolean
        result = dbProjecteContacte.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Function removePare(id As Integer) As Boolean
        Return dbProjecteContacte.removePare(id)
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of ProjecteContacte)
        dateUpdate = Now()
        Return dbProjecteContacte.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaprojecteContacte)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
