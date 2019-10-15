Option Explicit On
Module ModelSubcompte
    Private objects As List(Of Subcompte)
    Private dateUpdate As DateTime
    Private Const nColumns As Integer = 3
    Public Function getObject(id As Integer) As Subcompte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getobject(codi As String) As Subcompte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = codi)
    End Function
    Public Function getStringSubcomptes() As String(,)
        Dim obj As Subcompte, dades(,) As String, i As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        ReDim dades(objects.Count, 1)
        For Each obj In objects
            dades(i, 0) = obj.id
            dades(i, 1) = obj.codi
            i = i + 1
        Next
        obj = Nothing
        Return dades
    End Function
    Public Function getDataList(subcomptes As List(Of Subcompte)) As DataList
        Dim s As Subcompte
        getDataList = New DataList
        getDataList.columns.Add(COLUMN.ID)
        getDataList.columns.Add(COLUMN.CODI)
        getDataList.columns.Add(COLUMN.NOM)
        If subcomptes IsNot Nothing Then
            If subcomptes.Count > 0 Then
                For Each s In subcomptes
                    getDataList.rows.Add(New ListViewItem(New String() {s.id, s.codi, s.nom}))
                Next
            End If
        Else
            getDataList.rows.Add(New ListViewItem(New String() {"", "", ""}))
        End If
        s = Nothing
    End Function
    Public Function exist(obj As Subcompte) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function exist(id As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id = id)
    End Function
    Public Function existCodi(codi As String) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.codi = codi)
    End Function
    Public Function getObjects(Optional filter As String = "") As List(Of Subcompte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filter))
    End Function
    Public Function getObjects(nomesGrup67 As Boolean, Optional filter As String = "") As List(Of Subcompte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filter) And Left(x.codi, 1) >= "6")
    End Function
    Public Function getObjects67() As List(Of Subcompte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) Left(x.codi, 1) = "6" Or Left(x.codi, 1) = "7")
    End Function
    Public Function getObjectsNoSelect(nomesGrup67 As Boolean, idGrup As Integer, txt As String) As List(Of Subcompte)
        Dim s As Subcompte
        getObjectsNoSelect = New List(Of Subcompte)
        For Each s In getObjects(txt)
            If nomesGrup67 Then
                If Left(s.codi, 1) >= 6 Then
                    If Not ModelSubcomptesGrup.existSubcompteInGrup(s.id, idGrup) Then getObjectsNoSelect.Add(s)
                End If
            Else
                If Not ModelSubcomptesGrup.existSubcompteInGrup(s.id, idGrup) Then getObjectsNoSelect.Add(s)
            End If
        Next s
        s = Nothing
    End Function
    Public Function getDescripcio(Optional id As Integer = -1, Optional codi As String = "") As String
        Dim s As Subcompte
        If Not isUpdated() Then objects = getRemoteObjects()
        s = objects.Find(Function(x) x.id = id Or x.codi = codi)

        If s IsNot Nothing Then
            getDescripcio = s.nom
        Else
            getDescripcio = ""
        End If
        s = Nothing
    End Function
    Public Function getCodi(id As Integer) As String
        Dim s As Subcompte
        If Not isUpdated() Then objects = getRemoteObjects()
        s = objects.Find(Function(x) x.id = id)
        If s IsNot Nothing Then
            getCodi = s.codi
        Else
            getCodi = ""
        End If
        s = Nothing
    End Function
    Public Function getId(codi As String) As Integer
        Dim s As Subcompte
        If Not isUpdated() Then objects = getRemoteObjects()
        s = objects.Find(Function(x) x.codi = codi)
        If s IsNot Nothing Then
            getId = s.id
        Else
            getId = ""
        End If
        s = Nothing
    End Function
    Public Function getToString(id As Integer) As String
        Dim s As Subcompte
        If Not isUpdated() Then objects = getRemoteObjects()
        s = objects.Find(Function(x) x.id = id)
        If s IsNot Nothing Then
            getToString = s.ToString
        Else
            getToString = ""
        End If
        s = Nothing
    End Function
    Public Function save(obj As Object) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            i = dbSubcompte.insert(obj)
        Else
            i = dbSubcompte.update(obj)
        End If

        If i > -1 Then
            obj.id = i
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Return obj.id
        End If
        Return -1
    End Function
    Public Function remove(obj As Object) As Boolean
        If dbSubcompte.remove(obj) Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        End If
        Return False
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub

    ' private module

    Private Function getRemoteObjects() As List(Of Subcompte)
        dateUpdate = Now()
        Return dbSubcompte.getObjects
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
        Return DBCONNECT.getTaulaSubcomptes
    End Function

End Module


