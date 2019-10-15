Option Explicit On
Module ModelProveidorAnotacio
    Private objects As List(Of proveidorAnotacio)
    Private dateUpdate As DateTime
    Public Function getObjects(idProveidor As Integer, Optional filtre As String = "") As List(Of proveidorAnotacio)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idProveidor = idProveidor And x.isFilter(filtre, x.notes))
    End Function
    Public Function getDataList(notes As List(Of proveidorAnotacio)) As DataList
        Dim c As proveidorAnotacio
        getDataList = New DataList
        notes.Sort()
        If notes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOTES)
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each c In notes
                If c.estat Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.notes, IDIOMA.getString("actiu")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.notes, IDIOMA.getString("noActiu")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getObject(id As Integer) As proveidorAnotacio
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function exist(obj As proveidorAnotacio) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.notes = obj.notes)
    End Function

    Public Function save(obj As proveidorAnotacio) As Integer
        If obj.id = -1 Then
            obj.id = dbProveidorAnotacio.insert(obj)
        Else
            obj.id = dbProveidorAnotacio.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As proveidorAnotacio) As Boolean
        Dim result As Boolean
        result = dbProveidorAnotacio.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Function removePare(id As Integer) As Boolean
        Return dbProveidorAnotacio.removePare(id)
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of proveidorAnotacio)
        dateUpdate = Now()
        Return dbProveidorAnotacio.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaProveidorAnotacio)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
