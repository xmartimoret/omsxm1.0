Option Explicit On
Module ModelarticlePreu
    Private objects As List(Of ArticlePreu)
    Private dateUpdate As DateTime
    Public Function getObjects(idArticle As Integer) As List(Of ArticlePreu)
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = objects.FindAll(Function(x) x.idArticle = idArticle)
    End Function
    Public Function getObjects(idArticle As Integer, idProveidor As Integer) As List(Of ArticlePreu)
        Dim ap As ArticlePreu
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of ArticlePreu)
        For Each ap In objects
            If ap.idProveidor = idProveidor Then
                If ap.idArticle = idArticle Then
                    getObjects.Add(ap)
                End If
            End If
        Next
        ap = Nothing
    End Function
    Public Function getLastObject(idArticle As Integer, idProveidor As Integer) As ArticlePreu
        Dim tempObjects As List(Of ArticlePreu), ap As ArticlePreu, exist As Boolean, temp As ArticlePreu
        If Not isUpdated() Then objects = getRemoteObjects()
        tempObjects = getObjects(idArticle, idProveidor)
        temp = New ArticlePreu
        For Each ap In tempObjects
            If ap.data >= temp.data Then
                temp = ap
                exist = True
            End If
        Next
        tempObjects = Nothing
        ap = Nothing
        If exist Then
            Return temp
        Else
            Return Nothing
        End If
    End Function
    Public Function getDataList(articlepreus As List(Of ArticlePreu)) As DataList
        Dim a As ArticlePreu
        getDataList = New DataList
        articlepreus.Sort()
        If articlepreus.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("proveidor", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("article", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("unitat", 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("data", 80, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("import", 80, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("descompte", 80, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))

            For Each a In articlepreus
                getDataList.rows.Add(New ListViewItem(New String() {a.id, ModelProveidor.getNom(a.idProveidor), ModelArticle.getNom(a.idArticle), ModelArticle.getCodiUnitat(a.idArticle), a.data, a.base, a.descompte, a.base - a.descompte}))
            Next
        End If
        a = Nothing
    End Function
    Public Function getObject(id As Integer) As ArticlePreu
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function exist(obj As ArticlePreu) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.nom = obj.nom)
    End Function
    Public Function exist(idArticle As Integer, idProveidor As Integer, preu As Double, descompte As Double)
        Dim ap As ArticlePreu
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each ap In objects
            If ap.idArticle = idArticle Then
                If ap.idProveidor = idProveidor Then
                    If preu = ap.base And descompte = ap.descompte Then
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function
    Public Function save(obj As ArticlePreu) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        If obj.id = -1 Then
            obj.id = dbArticlePreu.insert(obj)
        Else
            obj.id = dbArticlePreu.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As ArticlePreu) As Boolean
        Dim result As Boolean
        result = dbArticlePreu.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of ArticlePreu)
        dateUpdate = Now()
        Return dbArticlePreu.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaArticlePreu)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module


