Option Explicit On
Public Class ModelAuxiliar
    Private objects As List(Of Object)
    Private dateUpdate As DateTime
    Public Property taulaActual As String
    Public Sub New(pTaula As String)
        _taulaActual = pTaula
    End Sub
    Public Function getObjects(Optional filtre As String = "") As List(Of Object)
        If Not isUpdated() Then objects = getRemoteObjects() ' : Call ordenar()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getObjectsActius(Optional filtre As String = "") As List(Of Object)
        If Not isUpdated() Then objects = getRemoteObjects() ' : Call ordenar()
        Return objects.FindAll(Function(x) x.isFilter(filtre) And x.actiu = True)
    End Function
    Public Function getDataList(objects As List(Of Object)) As DataList
        Dim c As Object
        getDataList = New DataList

        If objects.Count > 0 Then
            Select Case taulaActual
                Case DBCONNECT.getTaulaPais
                    getDataList.columns.Add(COLUMN.ID)
                    getDataList.columns.Add(COLUMN.CODI)
                    getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("abrev."), 50, HorizontalAlignment.Center))
                    getDataList.columns.Add(COLUMN.NOM)
                    For Each c In objects
                        getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.abreviatura, c.nom}))
                    Next
                Case DBCONNECT.getTaulaTipusIva
                    getDataList.columns.Add(COLUMN.ID)
                    getDataList.columns.Add(COLUMN.CODI)
                    getDataList.columns.Add(COLUMN.NOM)
                    getDataList.columns.Add(COLUMN.GENERICA("impost", 50, HorizontalAlignment.Center))
                    getDataList.columns.Add(COLUMN.GENERICA("r.equiv.", 50, HorizontalAlignment.Center))
                    getDataList.columns.Add(COLUMN.GENERICA("actiu", 50, HorizontalAlignment.Center))
                    For Each c In objects
                        If c.actiu Then
                            getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, c.impost, c.rEquivalencia, IDIOMA.getString("si")}))
                        Else
                            getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, c.impost, c.rEquivalencia, IDIOMA.getString("no")}))
                        End If
                    Next
                Case DBCONNECT.getTaulaTipusPagament
                    getDataList.columns.Add(COLUMN.ID)
                    getDataList.columns.Add(COLUMN.CODI)
                    getDataList.columns.Add(COLUMN.NOM)
                    getDataList.columns.Add(COLUMN.GENERICA("diesAPagar", 50, HorizontalAlignment.Center))
                    getDataList.columns.Add(COLUMN.GENERICA("diaPagament", 50, HorizontalAlignment.Center))
                    getDataList.columns.Add(COLUMN.GENERICA("actiu", 50, HorizontalAlignment.Center))
                    For Each c In objects
                        If c.actiu Then
                            getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, c.dies, c.diaPagament, IDIOMA.getString("si")}))
                        Else
                            getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, c.dies, c.diaPagament, IDIOMA.getString("no")}))
                        End If
                    Next
                Case Else
                    getDataList.columns.Add(COLUMN.ID)
                    getDataList.columns.Add(COLUMN.CODI)
                    getDataList.columns.Add(COLUMN.NOM)
                    For Each c In objects
                        getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom}))
                    Next
            End Select


        End If
        c = Nothing
    End Function



    Public Function getListObjects() As Object()
        Dim obj As Object, i As Integer = 0, objectes() As Object
        If Not isUpdated() Then objects = getRemoteObjects() : Call ordenar()
        ReDim objectes(objects.Count - 1)
        For Each obj In objects
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getObject(id As Integer) As Object
        Dim p As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.Find(Function(x) x.id = id)
        'If p Is Nothing Then p = New Object
        Return p
    End Function

    Public Function getCodi(id As Integer) As String
        Dim p As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.Find(Function(x) x.id = id)
        If p Is Nothing Then Return p.codi
        Return ""
    End Function
    Public Function getName(id As Integer) As String
        Dim p As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.Find(Function(x) x.id = id)
        If p Is Nothing Then Return p.nom
        Return ""
    End Function
    Public Function exist(obj As Object) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.nom = obj.nom)
    End Function
    Public Function existCodi(obj As Object) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function save(obj As Object) As Integer
        If obj.id = -1 Then
            obj.id = dbAuxiliars.insert(obj)
        Else
            obj.id = dbAuxiliars.update(obj)
            objects.Remove(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Add(obj)
            Call ordenar()
        End If
        Return obj.id
    End Function
    Public Function remove(obj As Object) As Boolean
        Dim result As Boolean
        result = dbAuxiliars.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of Object)
        dateUpdate = Now()
        Return dbAuxiliars.getObjects(taulaActual)
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        isUpdated = False
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, taulaActual)
        End If
        If isUpdated Then dateUpdate = Now
    End Function

    Private Sub ordenar()
        Dim i As Integer, j As Integer, k As Integer, t As Object
        For i = 0 To objects.Count - 1
            k = i
            For j = i To objects.Count - 1
                If StrComp(objects(k).nom, objects(j).nom, CompareMethod.Text) > 0 Then
                    k = j
                End If
            Next
            If k <> i Then
                t = objects(i)
                objects(i) = objects(k)
                objects(k) = t
            End If
        Next
    End Sub

End Class

