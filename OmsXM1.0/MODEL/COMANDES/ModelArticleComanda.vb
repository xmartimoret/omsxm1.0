'estic aqui
Option Explicit On
Module ModelarticleComanda
    Private objects As List(Of articleComanda)
    Private dateUpdate As DateTime
    Public Function getObjects(idComanda As Integer) As List(Of articleComanda)
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = objects.FindAll(Function(x) x.idComanda = idComanda)
    End Function
    Public Function getDataList(ArticlesComanda As List(Of articleComanda)) As DataList
        Dim a As articleComanda
        getDataList = New DataList
        ArticlesComanda.Sort()
        If ArticlesComanda.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("referencia", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("quantitat", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("unitat", 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("descripcio", 80, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("import", 80, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("descompte", 80, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))
            For Each a In ArticlesComanda
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.quantitat, a.unitat.codi, a.nom, a.preu.base, a.preu.descompte, a.tIva.codi, a.total}))
            Next
        End If
        a = Nothing
    End Function
    Public Function getObject(id As Integer) As articleComanda
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function exist(obj As articleComanda) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.idComanda = obj.idComanda And x.codi = obj.codi)
    End Function

    Public Function save(obj As articleComanda) As Integer
        If obj.id = -1 Then
            obj.id = dbArticleComanda.insert(obj)
        Else
            obj.id = dbArticleComanda.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Sub saveComanda(ac As List(Of articleComanda))
        Dim a As articleComanda
        For Each a In ac
            Call save(a)
        Next
        a = Nothing
    End Sub
    Public Function remove(obj As articleComanda) As Boolean
        Dim result As Boolean
        result = dbArticleComanda.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub
    ' todo cal anualitzar, per masses dades a igual que les comandes
    Private Function getRemoteObjects() As List(Of articleComanda)
        dateUpdate = Now()
        Return dbArticleComanda.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaArticleComanda)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module


