Option Explicit On
Module ModelSubGrupGB
    Private objects As List(Of SubGrupGB)
    Private dateUpdate As DateTime
    Public Function getObjects(filtre As String) As List(Of SubGrupGB)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getDataList(subgrups As List(Of SubGrupGB)) As DataList
        Dim c As SubGrupGB
        subgrups.Sort()
        getDataList = New DataList
        If subgrups.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("formula"), 150, HorizontalAlignment.Left))
            For Each c In subgrups
                getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, c.toStringFormula}))
            Next
        End If
        c = Nothing
    End Function
    Public Function getListObjects() As Object()
        Dim obj As SubGrupGB, i As Integer = 0, objectes() As Object, temp As List(Of SubGrupGB)
        temp = ModelSubGrupGB.getObjects("")
        ReDim objectes(temp.Count - 1)
        For Each obj In temp
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
        temp = Nothing
    End Function
    Public Function getObject(id As Integer) As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) StrComp(x.id, id, CompareMethod.Text) = 0)
    End Function
    Public Function getObject(code As String) As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) StrComp(x.codi, code, CompareMethod.Text) = 0)
    End Function
    Public Function save(obj As SubGrupGB) As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrdre() + 1
            obj.id = dbSubgrupGb.insert(obj)
        Else
            obj.id = dbSubgrupGb.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            objects.Add(obj)
            Return obj.id
        End If
        Return -1
    End Function
    Public Function remove(obj As SubGrupGB) As Boolean
        Dim result As Boolean
        result = dbSubgrupGb.remove(obj.id)
        If result Then
            dateUpdate = Now
            objects.RemoveAll(Function(x) x.id = obj.id)
        End If
        Return result
    End Function

    Public Function exist(obj As Object) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.nom, obj.codi, CompareMethod.Text) = 0)
    End Function
    Public Function existName(obj As SubGrupGB) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.nom, obj.nom, CompareMethod.Text) = 0)
    End Function
    Private Function getMaxOrdre() As Integer
        Dim obj As SubGrupGB
        getMaxOrdre = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If Val(obj.ordre) > getMaxOrdre Then getMaxOrdre = Val(obj.ordre)
        Next obj
        obj = Nothing
    End Function
    'Public Function getNewCode() As String
    '    Dim i As Integer
    '    getNewCode = ""
    '    If Not isUpdated() Then objects = getRemoteObjects()
    '    i = objects.Count + 1
    '    If i < 10 Then
    '        getNewCode = "C0" & i
    '    Else
    '        getNewCode = "C" & i
    '    End If
    'End Function
    Public Function changeOrder(id1 As Integer, id2 As Integer)
        Dim temp As String, obj1 As SubGrupGB, obj2 As SubGrupGB
        If id1 <= 0 Or id2 <= 0 Then Return False
        obj1 = getObject(id1)
        obj2 = getObject(id2)
        If obj1 Is Nothing Or obj2 Is Nothing Then Return False
        temp = obj1.ordre
        obj1.ordre = obj2.ordre
        obj2.ordre = temp
        Call save(obj1)
        Call save(obj2)
        Return True
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
    Private Function getRemoteObjects() As List(Of SubGrupGB)
        getRemoteObjects = dbSubgrupGb.getObjects
        dateUpdate = Now()
    End Function

    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaSubgrupGB
    End Function
End Module
