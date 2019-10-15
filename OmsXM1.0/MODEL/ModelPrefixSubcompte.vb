Option Explicit On
Module ModelPrefixSubcompte
    Private objects As List(Of PrefixSubcte)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of PrefixSubcte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isfilter(filtre))
    End Function
    Public Function getDataList(subcomptes As List(Of PrefixSubcte)) As DataList
        Dim s As PrefixSubcte
        getDataList = New DataList
        If subcomptes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.PREFIX)
            getDataList.columns.Add(COLUMN.SUBCOMPTE)
            For Each s In subcomptes
                getDataList.rows.Add(New ListViewItem(New String() {s.id, s.prefix, s.codiSubcompte & " - " & s.descripcioSubcompte}))
            Next
        End If
        s = Nothing
    End Function
    Public Function getObject(id As Integer) As PrefixSubcte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(prefix As String) As PrefixSubcte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) StrComp(prefix, x.prefix, CompareMethod.Text) = 0)
    End Function
    Public Function save(obj As PrefixSubcte) As Boolean
        Dim i As Integer
        If obj.id = -1 Then
            i = dbPrefixSubcompte.insert(obj)
        Else
            i = dbPrefixSubcompte.update(obj)
        End If

        If i > 0 Then
            obj.id = i
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            objects.Add(obj)
            Return True
        End If
        Return False

    End Function
    Public Function remove(obj As PrefixSubcte) As Boolean
        If dbPrefixSubcompte.remove(obj) Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        End If
        Return False
    End Function
    Public Function exist(obj As PrefixSubcte) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.prefix = obj.prefix)
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of PrefixSubcte)
        dateUpdate = Now()
        Return dbPrefixSubcompte.getObjects
    End Function
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaPrefixSubctePretancament
    End Function




End Module
