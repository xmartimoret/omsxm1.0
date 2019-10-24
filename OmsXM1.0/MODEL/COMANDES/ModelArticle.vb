Option Explicit On
Module ModelArticle
    Private objects As List(Of article)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of article)
        Dim a As article, altres As String = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of article)
        For Each a In objects
            If a.familia IsNot Nothing Then altres = a.familia.nom
            If a.fabricant IsNot Nothing Then altres = altres & a.fabricant.nom

            If altres <> "" Then
                If a.isFilter(filtre, altres) Then
                    getObjects.Add(a)
                End If
            Else
                If a.isFilter(filtre) Then
                    getObjects.Add(a)
                End If
            End If
        Next

    End Function
    Public Function getDataList(articles As List(Of article)) As DataList
        Dim a As article
        getDataList = New DataList
        articles.Sort()
        If articles.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("codi", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA("familia", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("fabricant", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("unitat", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Center))
            For Each a In articles
                If a.familia Is Nothing Then a.familia = New Familia
                If a.fabricant Is Nothing Then a.fabricant = New Fabricant
                If a.unitat Is Nothing Then a.unitat = New Unitat
                If a.iva Is Nothing Then a.iva = New TipusIva
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.nom, a.familia.nom, a.fabricant.nom, a.unitat.codi, a.iva.impost}))
            Next
        End If
        a = Nothing
    End Function
    Public Function getListStringCodi() As String()
        Dim ll As List(Of article), o() As String, i As Integer
        ll = getObjects()
        If ll.Count > 0 Then
            ReDim o(ll.Count - 1)
            For Each t As article In ll
                o(i) = t.codi
                i = i + 1
            Next
            Return o
        End If
        Return Nothing
    End Function
    Public Function getObject(id As Integer) As article
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(r As String) As article
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = r)
    End Function
    Public Function getCodiUnitat(id As Integer) As String
        Dim u As Unitat
        getCodiUnitat = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        u = objects.Find(Function(x) x.id = id).unitat
        If u IsNot Nothing Then getCodiUnitat = u.codi
        u = Nothing
    End Function
    Public Function getNom(id As Integer) As String
        Dim a As article
        getNom = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        a = objects.Find(Function(x) x.id = id)
        If a IsNot Nothing Then getNom = a.nom
        a = Nothing
    End Function
    Public Function getCodi(id As Integer) As String
        Dim a As article
        getCodi = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        a = objects.Find(Function(x) x.id = id)
        If a IsNot Nothing Then getCodi = a.codi
        a = Nothing
    End Function
    Public Function getNomFabricant(id As Integer) As String
        Dim f As Fabricant
        getNomFabricant = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        f = objects.Find(Function(x) x.id = id).fabricant
        If f IsNot Nothing Then getNomFabricant = f.nom
        f = Nothing
    End Function
    Public Function exist(obj As article) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.nom = obj.nom)
    End Function
    Public Function existCodi(obj As article) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function save(obj As article) As Integer
        If obj.id = -1 Then
            obj.id = dbArticle.insert(obj)
        Else
            obj.id = dbArticle.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As article) As Boolean
        Dim result As Boolean
        result = dbArticle.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of article)
        dateUpdate = Now()
        Return dbArticle.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaArticle)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
