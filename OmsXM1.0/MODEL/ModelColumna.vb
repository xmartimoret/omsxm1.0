Option Explicit On

Module ModelColumna
    Private objects As List(Of Columna)

    Private dateUpdate As DateTime
    Public Function getObjects(filtre As String) As List(Of Columna)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getDataList(columnes As List(Of Columna)) As DataList
        Dim c As Columna

        getDataList = New DataList
        If columnes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.TOTALITZA)
            For Each c In columnes
                If c.totalitzador Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, IDIOMA.getString("columnes")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, IDIOMA.getString("projectes")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getObject(id As Integer) As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) StrComp(x.id, id, CompareMethod.Text) = 0)
    End Function
    Public Function getObject(code As String) As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) StrComp(x.codi, code, CompareMethod.Text) = 0)
    End Function
    Public Function save(obj As Columna) As Integer
        If obj.id = -1 Then
            obj.codi = getNewCode()
            obj.ordre = getMaxOrder() + 1
            obj.id = dbColumna.insert(obj)

        Else
            obj.id = dbColumna.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            objects.Add(obj)
            Return obj.id
        End If
        Return -1
    End Function
    Public Function remove(obj As Columna) As Boolean
        Dim result As Boolean
        result = dbColumna.remove(obj)
        If result Then
            objects.Remove(obj)
            Call Reindexar()
        End If
        Return result
    End Function

    Public Function exist(obj As Object) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.nom, obj.codi, CompareMethod.Text) = 0)
    End Function
    Public Function existName(obj As Columna) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.nom, obj.nom, CompareMethod.Text) = 0)
    End Function
    Public Function getNewCode() As String
        Dim i As Integer
        getNewCode = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        i = objects.Count + 1
        If i < 10 Then
            getNewCode = "C0" & i
        Else
            getNewCode = "C" & i
        End If
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
    Private Function getRemoteObjects() As List(Of Columna)
        getRemoteObjects = dbColumna.getObjects
        dateUpdate = Now()
    End Function
    Private Function getMaxOrder() As Integer
        Dim obj As Columna, i As Integer
        i = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If IsNumeric(obj.ordre) Then
                If CInt(obj.ordre) > i Then i = obj.ordre
            Else
                If obj.ordre > i Then i = obj.ordre
            End If
        Next obj
        obj = Nothing
        Return i
    End Function
    Private Sub Reindexar()
        Dim cCodi As String, c As Columna, i As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        i = 1
        For Each c In objects
            If i > 9 Then
                cCodi = "C" & i
            Else
                cCodi = "C0" & i
            End If
            c.codi = dbColumna.update(c.id, cCodi)
            i = i + 1
        Next
        dateUpdate = Now
    End Sub
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaColumnes
    End Function
End Module
