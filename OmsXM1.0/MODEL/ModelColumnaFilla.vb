Option Explicit On
Module ModelColumnaFilla
    Private objects As List(Of ColumnaFilla)
    Private dateUpdate As DateTime

    Public Function getObjects(idColumna As Integer) As List(Of ColumnaFilla)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idColumna = idColumna)
    End Function
    Public Function getFilles(idParent As Integer, Optional filtre As String = "") As List(Of Columna)
        Dim cf As ColumnaFilla, c As Columna
        If Not isUpdated() Then objects = getRemoteObjects()
        getFilles = New List(Of Columna)
        For Each cf In objects.FindAll(Function(x) x.idColumna = idParent)
            c = ModelColumna.getObject(cf.idFilla)
            If c.isFilter(filtre) Then getFilles.Add(c)
        Next
        c = Nothing
        cf = Nothing
    End Function
    Public Function getObject(id As String) As ColumnaFilla
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idFilla = id)
    End Function
    Public Function save(obj As ColumnaFilla) As Boolean
        Dim result As Boolean
        If Not exist(obj) Then
            result = dbColumnaFilla.insert(obj)
            If result Then
                dateUpdate = Now()
                objects.Remove(obj)
                objects.Add(obj)
                Return True
            End If
        End If
        Return False
    End Function
    Public Function remove(obj As ColumnaFilla) As Boolean
        Dim result As Boolean
        result = dbColumnaFilla.remove(obj)
        If result Then
            dateUpdate = Now
            objects.RemoveAll(Function(x) x.id = obj.id)
            Return True
        End If
        Return False
    End Function
    Public Function removeColumna(c As Columna) As Boolean
        Dim result As Boolean
        result = dbColumnaFilla.removeColumna(c)
        If result Then
            objects.RemoveAll(Function(x) x.idColumna = c.id)
            Return True
        End If
        Return False
    End Function

    Public Function exist(obj As ColumnaFilla) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idFilla = obj.idFilla And x.idColumna = obj.idColumna)
    End Function
    Public Function existFilla(idFilla As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idFilla = idFilla)
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
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
    Private Function getRemoteObjects() As List(Of ColumnaFilla)
        dateUpdate = Now()
        Return dbColumnaFilla.getObjects
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaColumnesFilles
    End Function
End Module
