Option Explicit On
Module ModelDepartament
    Private objects As List(Of Departament)
    Private dateUpdate As DateTime
    Private Const ID As String = "ID"
    Private Const ID_EMPRESA As String = "IDEMPRESA"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const ORDRE As String = "ORDRE"

    Public Function getObjects(Optional filtre As String = "") As List(Of Departament)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getDataList(departaments As List(Of Departament)) As DataList
        Dim d As Departament
        getDataList = New DataList
        If departaments.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            For Each d In departaments
                getDataList.rows.Add(New ListViewItem(New String() {d.id, d.codi, d.nom}))
            Next
        End If
        d = Nothing
    End Function
    Public Function getListViewItem(d As Departament) As ListViewItem
        Return New ListViewItem(New String() {d.id, d.codi, d.nom})
    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim a As Departament
        a = getObject(id)
        If a IsNot Nothing Then
            Return getListViewItem(a)
        End If
        Return Nothing
    End Function
    Public Function getObject(id As Integer) As Departament
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function exist(obj As Departament) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function exist(id As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id = id)
    End Function

    Public Function save(obj As Departament) As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrdre() + 1
            obj.id = dbDepartament.insert(obj)
        Else
            obj.id = dbDepartament.update(obj)
        End If
        If obj.id <> -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Return obj.id
            'TODO CAL MODIFICAR  EL OBJ.ID
        End If
        Return -1
    End Function
    Public Function remove(obj As Departament) As Boolean
        Dim result As Boolean
        result = dbDepartament.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        End If
        Return False
    End Function

    Public Sub changeOrder(obj1 As Departament, obj2 As Departament)
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
        Dim i As Integer, c As Departament
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
    Private Function getMaxOrdre() As Integer
        Dim obj As Departament
        getMaxOrdre = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If Val(obj.ordre) > getMaxOrdre Then getMaxOrdre = Val(obj.ordre)
        Next obj
        obj = Nothing
    End Function
    Private Function getRemoteObjects() As List(Of Departament)
        dateUpdate = Now()
        Return dbDepartament.getObjects()
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
        Return DBCONNECT.getTaulaDepartament
    End Function


End Module
