Option Explicit On
Module ModelTipusPagament
    Private auxiliar As ModelAuxiliar

    Public Function getAuxiliar() As ModelAuxiliar
        If auxiliar Is Nothing Then auxiliar = New ModelAuxiliar(DBCONNECT.getTaulaTipusPagament)
        Return auxiliar
    End Function
    Public Sub resetIndex()
        auxiliar = Nothing
    End Sub
    '    Private objects As List(Of TipusPagament)
    '    Private dateUpdate As DateTime
    '    Public Function getObjects(Optional filtre As String = "") As List(Of TipusPagament)
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        Return objects.FindAll(Function(x) x.isFilter(filtre))
    '    End Function
    '    Public Function getDataList(TipusPagamentos As List(Of TipusPagament)) As DataList
    '        Dim c As TipusPagament
    '        getDataList = New DataList
    '        TipusPagamentos.Sort()
    '        If TipusPagamentos.Count > 0 Then
    '            getDataList.columns.Add(COLUMN.ID)
    '            getDataList.columns.Add(COLUMN.CODI)
    '            getDataList.columns.Add(COLUMN.NOM)
    '            getDataList.columns.Add(COLUMN.GENERICA("diesAPagar", 50, HorizontalAlignment.Center))
    '            getDataList.columns.Add(COLUMN.GENERICA("diaPagament", 50, HorizontalAlignment.Center))
    '            getDataList.columns.Add(COLUMN.GENERICA("actiu", 50, HorizontalAlignment.Center))
    '            For Each c In TipusPagamentos
    '                If c.actiu Then
    '                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, c.dies, c.diaPagament, IDIOMA.getString("si")}))
    '                Else
    '                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, c.dies, c.diaPagament, IDIOMA.getString("no")}))
    '                End If
    '            Next
    '        End If
    '        c = Nothing
    '    End Function
    '    Public Function getListObjects() As Object()
    '        Dim obj As Object, i As Integer = 0, objectes() As Object
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        ReDim objectes(objects.Count - 1)
    '        For Each obj In objects
    '            objectes(i) = obj
    '            i = i + 1
    '        Next
    '        getListObjects = objectes
    '        objectes = Nothing
    '        obj = Nothing
    '    End Function
    '    Public Function getObject(id As Integer) As TipusPagament
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        Return objects.Find(Function(x) x.id = id)
    '    End Function
    '    Public Function exist(obj As TipusPagament) As Boolean
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        Return objects.Exists(Function(x) x.id <> obj.id And x.nom = obj.nom)
    '    End Function
    '    Public Function existCodi(obj As TipusPagament) As Boolean
    '        If Not isUpdated() Then objects = getRemoteObjects()
    '        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    '    End Function
    '    Public Function save(obj As TipusPagament) As Integer
    '        If obj.id = -1 Then
    '            obj.id = dbTipusPagament.insert(obj)
    '        Else
    '            obj.id = dbTipusPagament.update(obj)
    '        End If
    '        If obj.id > -1 Then
    '            dateUpdate = Now()
    '            objects.Remove(obj)
    '            objects.Add(obj)
    '        End If
    '        Return obj.id
    '    End Function
    '    Public Function remove(obj As TipusPagament) As Boolean
    '        Dim result As Boolean
    '        result = dbTipusPagament.remove(obj)
    '        If result Then
    '            dateUpdate = Now()
    '            objects.Remove(obj)
    '        End If
    '        Return result
    '    End Function

    '    Public Sub resetIndex()
    '        objects = Nothing
    '    End Sub

    '    Private Function getRemoteObjects() As List(Of TipusPagament)
    '        dateUpdate = Now()
    '        Return dbTipusPagament.getObjects
    '    End Function
    '    ''' <summary>
    '    ''' Comprova si s'ha actualitzat la BBDD
    '    ''' </summary>
    '    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    '    Private Function isUpdated() As Boolean
    '        If Not objects Is Nothing Then
    '            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaTipusPagament)
    '        Else
    '            Return False
    '        End If
    '        If isUpdated Then dateUpdate = Now
    '    End Function
End Module
