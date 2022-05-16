Option Explicit On
Module ModelYSheet
    Private objects As List(Of YSheet)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of YSheet)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getObject(id As Integer) As YSheet
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getobject(codi As String) As YSheet
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) UCase(x.codi) = UCase(codi))
    End Function
    Public Function getDataList(ySheets As List(Of YSheet)) As DataList
        Dim obj As YSheet
        getDataList = New DataList
        If ySheets IsNot Nothing Then
            If ySheets.Count > 0 Then
                ySheets.Sort()
                getDataList.columns.Add(COLUMN.ID)
                getDataList.columns.Add(COLUMN.CODI)
                getDataList.columns.Add(COLUMN.NOM)
                For Each obj In ySheets
                    getDataList.rows.Add(New ListViewItem(New String() {obj.id, obj.codi, obj.nom}))
                Next
            End If
        End If
        obj = Nothing
    End Function
    Public Function getListViewItem(obj As YSheet) As ListViewItem
        Return New ListViewItem(New String() {obj.id, obj.codi, obj.nom})
    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim a As YSheet
        a = getObject(id)
        If a IsNot Nothing Then
            Return getListViewItem(a)
        End If
        Return Nothing
    End Function
    Public Function exist(Y As YSheet) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) (UCase(Trim(x.codi)) = UCase(Trim(Y.codi)) Or UCase(Trim(x.nom)) = UCase(Trim(Y.nom))) And x.id <> Y.id)
    End Function
    Public Function exist(code As String) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) UCase(Trim(x.codi)) = UCase(Trim(code)))
    End Function
    Public Function save(obj As YSheet) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrder() + 1
            i = dbYSheet.insert(obj)
        Else
            i = dbYSheet.update(obj)
        End If
        If i > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Return obj.id
        End If
        Return -1
    End Function
    Public Function remove(obj As YSheet) As Boolean
        If dbYSheet.remove(obj) Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        End If
        Return False
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub changeOrder(y1 As YSheet, y2 As YSheet)
        Dim temp As Integer
        temp = y1.ordre
        y1.ordre = y2.ordre
        y2.ordre = temp
        Call save(y1)
        Call save(y2)
    End Sub
    Private Function getMaxOrder() As Long
        Dim y As YSheet
        getMaxOrder = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each y In objects
            If getMaxOrder < y.ordre Then getMaxOrder = y.ordre
        Next y
        y = Nothing
    End Function
    Private Function getRemoteObjects() As List(Of YSheet)
        dateUpdate = Now()
        Return dbYSheet.getObjects
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
        getTable = DBCONNECT.getTaulaYelowSheet
    End Function
End Module
