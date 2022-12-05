Option Explicit On
Imports OmsXM.dbProjecte
Module ModelProjecte
    Private objects As List(Of Projecte)
    Private dateUpdate As DateTime
    Private Const N_COLUMNS As Integer = 7
    Public Function getObject(id As Integer) As Projecte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(codi As String, Optional idEmpresa As Integer = -1) As Projecte
        If Not isUpdated() Then objects = getRemoteObjects()
        If idEmpresa > -1 Then
            Return objects.Find(Function(x) x.codi = codi And x.idEmpresa = idEmpresa)
        Else
            Return objects.Find(Function(x) x.codi = codi)
        End If
    End Function
    Public Function getObjects(Optional filter As String = "") As List(Of Projecte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filter, x.toStringEmpresa))
    End Function
    Public Function getObjects() As List(Of Object)
        Dim p As Projecte
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of Object)
        For Each p In objects
            getObjects.Add(p)
        Next
    End Function
    Public Function getObjects(idEmpresa As Integer) As List(Of Projecte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idEmpresa = idEmpresa)
    End Function
    Public Function getObjects(idEmpresa As Integer, filtre As String) As List(Of Projecte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idEmpresa = idEmpresa And x.isFilter(filtre))
    End Function
    Public Function getListObjects(idEmpresa As Integer) As Object()
        Dim obj As Projecte, i As Integer = 0, objectes() As Object, temp As List(Of Projecte)
        temp = getObjects(idEmpresa)
        ReDim objectes(temp.Count - 1)
        For Each obj In temp
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getListObjects(p As List(Of Projecte)) As Object()
        Dim obj As Projecte, i As Integer = 0, objectes() As Object, temp As List(Of Projecte)
        temp = p
        ReDim objectes(temp.Count - 1)
        For Each obj In temp
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getStringProjectes() As String(,)
        Dim obj As Projecte, dades(,) As String, i As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        ReDim dades(objects.Count, 2)
        For Each obj In objects
            dades(i, 0) = obj.id
            dades(i, 1) = ModelEmpresa.getCodiEmpresa(obj.idEmpresa)
            dades(i, 2) = obj.codi
            i = i + 1
        Next
        obj = Nothing
        Return dades
    End Function
    Public Function getNoSelectedExpramObjects(idEmpresa As Integer, filtre As String) As List(Of Projecte)
        Dim obj As Projecte
        getNoSelectedExpramObjects = New List(Of Projecte)
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If Not ModelProjecteColumna.existProject(obj.id) Then
                If obj.isFilter(filtre) Then getNoSelectedExpramObjects.Add(obj)
            End If
        Next obj
        obj = Nothing
    End Function

    Public Function getNoSelectedClientObjects(filtre As String) As List(Of Projecte)
        getNoSelectedClientObjects = New List(Of Projecte)
        Return objects.FindAll(Function(x) Not ModelProjecteClient.existProjecte(x.id) And x.isFilter(filtre))
    End Function
    Public Function getObjectsNoAdded(idEmpresa As Integer, Optional filtre As String = "") As List(Of Projecte)
        Dim p As Projecte
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjectsNoAdded = New List(Of Projecte)
        For Each p In objects
            If p.isFilter(filtre) Then
                If p.idEmpresa = idEmpresa Then
                    If Not ModelProjecteCentre.existProjecte(p.id) Then
                        getObjectsNoAdded.Add(p)
                    End If
                End If
            End If
        Next p
        p = Nothing
    End Function
    Public Function getCodi(id As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id).codi
    End Function
    Public Function getBy4DigitsCode(codi As String) As Projecte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) Right(x.codi, Len(codi)) = codi)
    End Function
    Public Function getTotalProjectes() As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        getTotalProjectes = objects.Count
    End Function
    Public Function exist(obj As Projecte) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.idEmpresa = obj.idEmpresa And x.codi.Equals(obj.codi))
    End Function
    Public Function getDataList(projectes As List(Of Projecte)) As DataList
        Dim p As Projecte
        getDataList = New DataList
        If projectes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add((COLUMN.GENERICA("idEmpresa", 0, HorizontalAlignment.Center)))
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.NOTES)
            getDataList.columns.Add(COLUMN.GENERICA("responsable", 300, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("director", 300, HorizontalAlignment.Center))
            For Each p In projectes
                getDataList.rows.Add(New ListViewItem(New String() {p.id, p.idEmpresa, ModelEmpresa.getNom(p.idEmpresa), p.codi, p.nom, p.notes, p.responsable, p.director}))
            Next
        End If
        p = Nothing
    End Function
    Public Function getListViewItem(p As Projecte) As ListViewItem
        Return New ListViewItem(New String() {p.id, p.idEmpresa, ModelEmpresa.getNom(p.idEmpresa), p.codi, p.nom, p.notes, p.responsable, p.director})
    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim a As Projecte
        a = getObject(id)
        If a IsNot Nothing Then
            Return getListViewItem(a)
        End If
        Return Nothing
    End Function
    Public Function save(obj As Projecte) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            i = dbProjecte.insert(obj)
        Else
            i = dbProjecte.update(obj)
        End If
        If i > -1 Then
            obj.id = i
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            If Not GOOGLE_SHEETS.save(obj) Then Call ERRORS.ERR_UPDATE_GOOGLE_SHEETS()
            Return obj.id
        End If
        Return -1
    End Function
    Public Function remove(obj As Object) As Boolean
        If dbProjecte.remove(obj) Then
            dateUpdate = Now()
            objects.Remove(obj)
            If Not GOOGLE_SHEETS.remove(obj) Then Call ERRORS.ERR_UPDATE_GOOGLE_SHEETS()
            Return True
        End If
        Return False
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub

    ' private module
    Private Function getRemoteObjects() As List(Of Projecte)
        dateUpdate = Now()
        Return dbProjecte.getObjects
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
        Return DBCONNECT.getTaulaProjecte
    End Function

End Module

