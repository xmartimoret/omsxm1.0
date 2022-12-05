Option Explicit On
Module ModelArticleSolicitut
    Private objects As List(Of objectGrup(Of ArticleSolicitut))
    Private objActual As objectGrup(Of ArticleSolicitut)
    Private dateUpdate As DateTime
    Public Function getObjects(idSolicitut As Integer) As List(Of ArticleSolicitut)
        Dim o As objectGrup(Of ArticleSolicitut)
        If Not isUpdated(idSolicitut) Then objActual = actualitzarGrup(idSolicitut, getRemoteObjects(idSolicitut))
        o = objects.Find(Function(x) x.id = getIdGrup(idSolicitut))
        If Not objActual Is Nothing Then getObjects = objActual.objects.FindAll(Function(x) x.idGrup = idSolicitut)
    End Function
    Public Function getDataList(ArticlesComanda As List(Of ArticleSolicitut)) As DataList
        Dim a As ArticleSolicitut
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
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))
            For Each a In ArticlesComanda
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.quantitat, a.unitat, a.nom, a.preu, a.tpcDescompte, a.total}))
            Next
        End If
        a = Nothing
    End Function

    'Public Function getObject(id As Integer) As ArticleSolicitut
    '    If Not isUpdated() Then objects = getRemoteObjects()
    '    Return objects.Find(Function(x) x.id = id)
    'End Function
    'Public Function exist(obj As ArticleSolicitut) As Boolean
    '    If Not isUpdated() Then objects = getRemoteObjects()
    '    Return objects.Exists(Function(x) x.id <> obj.id And x.idSolicutComanda = obj.idSolicutComanda And x.codi = obj.codi)
    'End Function
    Public Function save(obj As ArticleSolicitut) As Integer
        If Not isUpdated(obj.idSolicutComanda) Then objActual = actualitzarGrup(obj.idSolicutComanda, getRemoteObjects(obj.idSolicutComanda))
        If obj.id = -1 Then
            obj.id = dbArticleSolicitut.insert(obj)
        Else
            obj.id = dbArticleSolicitut.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objActual.actualitzar(obj)
        End If
        Return obj.id
    End Function
    Public Function save(ac As List(Of ArticleSolicitut), idSolicitut As Integer) As Boolean
        Dim a As ArticleSolicitut, aD As ArticleSolicitut, pos As Integer, d As String
        If Not isUpdated(idSolicitut) Then objActual = actualitzarGrup(idSolicitut, getRemoteObjects(idSolicitut))
        For Each a In ac
            a.idSolicutComanda = idSolicitut
            pos = a.pos + 1
            Call save(a)
            For Each d In a.descripcio
                aD = New ArticleSolicitut
                aD.idSolicutComanda = idSolicitut
                aD.pos = pos
                aD.nom = d
                pos = pos + 1
                Call save(aD)
            Next

        Next
        Return True
    End Function
    Public Function remove(obj As ArticleSolicitut) As Boolean
        Dim result As Boolean
        If Not isUpdated(obj.idSolicutComanda) Then objActual = actualitzarGrup(obj.idSolicutComanda, getRemoteObjects(obj.idSolicutComanda))
        result = dbArticleSolicitut.remove(obj)
        If result Then
            dateUpdate = Now()
            objActual.eliminar(obj)
        End If
        Return result
    End Function
    Public Function remove(obj As SolicitudComanda) As Boolean
        Dim result As Boolean
        If Not isUpdated(obj.id) Then objActual = actualitzarGrup(obj.id, getRemoteObjects(obj.id))
        result = dbArticleSolicitut.remove(obj)
        If result Then
            dateUpdate = Now()
            For Each a As ArticleSolicitut In obj.articles
                result = result * objActual.eliminar(a)
            Next
        End If
        Return result
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function getRemoteObjects(id As Integer) As List(Of ArticleSolicitut)
        dateUpdate = Now()
        Return dbArticleSolicitut.getObjects(getIdGrup(id) * 100, getIdGrup(id) * 100 + 99)
    End Function
    Private Function actualitzarGrup(id As Integer, articles As List(Of ArticleSolicitut)) As objectGrup(Of ArticleSolicitut)
        Dim o As objectGrup(Of ArticleSolicitut)
        If objects Is Nothing Then
            objects = New List(Of objectGrup(Of ArticleSolicitut))
            o = New objectGrup(Of ArticleSolicitut)(getIdGrup(id), articles)
            objects.Add(o)
        Else
            o = objects.Find(Function(x) x.id = getIdGrup(getIdGrup(id)))
            If o Is Nothing Then
                objects.Add(o)
            Else
                o.objects = articles
            End If
        End If
        Return o
    End Function

    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated(id As Integer) As Boolean
        Dim obj As objectGrup(Of ArticleSolicitut), idGrup As Integer
        idGrup = getIdGrup(id)
        If DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaArticleSolicitud) Then
            For Each obj In objects
                If obj.id = idGrup Then
                    Return True
                    Exit For
                End If
            Next
        End If
        Return False
    End Function
    Private Function getIdGrup(id As Integer) As Integer
        Return id \ 100
    End Function
End Module
'copia seguretat 
'Module ModelArticleSolicitut
'    Private objects As List(Of objectGrup(Of articleComanda))
'    Private dateUpdate As DateTime
'    Public Function getObjects(idComanda As Integer) As List(Of ArticleSolicitut)
'        If Not isUpdated() Then objects = getRemoteObjects()
'        getObjects = objects.FindAll(Function(x) x.idSolicutComanda = idComanda)
'    End Function
'    Public Function getDataList(ArticlesComanda As List(Of ArticleSolicitut)) As DataList
'        Dim a As ArticleSolicitut
'        getDataList = New DataList
'        ArticlesComanda.Sort()
'        If ArticlesComanda.Count > 0 Then
'            getDataList.columns.Add(COLUMN.ID)
'            getDataList.columns.Add(COLUMN.GENERICA("referencia", 150, HorizontalAlignment.Center))
'            getDataList.columns.Add(COLUMN.GENERICA("quantitat", 150, HorizontalAlignment.Center))
'            getDataList.columns.Add(COLUMN.GENERICA("unitat", 50, HorizontalAlignment.Center))
'            getDataList.columns.Add(COLUMN.GENERICA("descripcio", 80, HorizontalAlignment.Center))
'            getDataList.columns.Add(COLUMN.GENERICA("import", 80, HorizontalAlignment.Center))
'            getDataList.columns.Add(COLUMN.GENERICA("descompte", 80, HorizontalAlignment.Center))
'            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))
'            For Each a In ArticlesComanda
'                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.quantitat, a.unitat, a.nom, a.preu, a.tpcDescompte, a.total}))
'            Next
'        End If
'        a = Nothing
'    End Function
'    Public Function getObject(id As Integer) As ArticleSolicitut
'        If Not isUpdated() Then objects = getRemoteObjects()
'        Return objects.Find(Function(x) x.id = id)
'    End Function
'    Public Function exist(obj As ArticleSolicitut) As Boolean
'        If Not isUpdated() Then objects = getRemoteObjects()
'        Return objects.Exists(Function(x) x.id <> obj.id And x.idSolicutComanda = obj.idSolicutComanda And x.codi = obj.codi)
'    End Function
'    Public Function save(obj As ArticleSolicitut) As Integer
'        If Not isUpdated() Then objects = getRemoteObjects()
'        If obj.id = -1 Then
'            obj.id = dbArticleSolicitut.insert(obj)
'        Else
'            obj.id = dbArticleSolicitut.update(obj)
'        End If
'        If obj.id > -1 Then
'            dateUpdate = Now()
'            objects.Remove(obj)
'            objects.Add(obj)

'        End If
'        Return obj.id
'    End Function
'    Public Function save(ac As List(Of ArticleSolicitut), idSolicitut As Integer) As Boolean
'        Dim a As ArticleSolicitut, aD As ArticleSolicitut, pos As Integer, d As String
'        If Not isUpdated() Then objects = getRemoteObjects()
'        For Each a In ac
'            a.idSolicutComanda = idSolicitut
'            pos = a.pos + 1
'            Call save(a)
'            For Each d In a.descripcio
'                aD = New ArticleSolicitut
'                aD.idSolicutComanda = idSolicitut
'                aD.pos = pos
'                aD.nom = d
'                pos = pos + 1
'                Call save(aD)
'            Next

'        Next
'        Return True
'    End Function
'    Public Function remove(obj As ArticleSolicitut) As Boolean
'        Dim result As Boolean
'        If Not isUpdated() Then objects = getRemoteObjects()
'        result = dbArticleSolicitut.remove(obj)
'        If result Then
'            dateUpdate = Now()
'            objects.Remove(obj)
'        End If
'        Return result
'    End Function
'    Public Function remove(obj As SolicitudComanda) As Boolean
'        Dim result As Boolean
'        If Not isUpdated() Then objects = getRemoteObjects()
'        result = dbArticleSolicitut.remove(obj)
'        If result Then
'            dateUpdate = Now()
'            For Each a As ArticleSolicitut In objects
'                result = result * objects.Remove(a)
'            Next
'        End If
'        Return result
'    End Function
'    Public Sub resetIndex()
'        objects = Nothing
'    End Sub
'    ' todo cal anualitzar, per masses dades a igual que les comandes
'    Private Function getRemoteObjects() As List(Of ArticleSolicitut)
'        dateUpdate = Now()
'        Return dbArticleSolicitut.getObjects
'    End Function
'    ''' <summary>
'    ''' Comprova si s'ha actualitzat la BBDD
'    ''' </summary>
'    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
'    Private Function getRemoteObjects(id As Integer) As List(Of articleComanda)
'        dateUpdate = Now()
'        Return dbArticleComanda.getObjects(id * 100, id * 100 + 99)
'    End Function
'    Private Sub actualitzarGrup(id As Integer, articles As List(Of articleComanda))
'        Dim o As objectGrup(Of articleComanda)
'        If objects Is Nothing Then
'            objects = New List(Of objectGrup(Of articleComanda))
'            o = New objectGrup(Of articleComanda)(id, articles)
'            objects.Add(o)
'        Else

'        End If
'    End Sub

'    ''' <summary>
'    ''' Comprova si s'ha actualitzat la BBDD
'    ''' </summary>
'    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
'    Private Function isUpdated(id As Integer) As Boolean
'        Dim obj As objectGrup(Of articleComanda), idGrup As Integer
'        idGrup = getIdGrup(id)
'        If DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaArticleComanda) Then
'            For Each obj In objects
'                If obj.id = idGrup Then
'                    Return True
'                    Exit For
'                End If
'            Next
'        End If
'        Return False
'    End Function
'    Private Function getIdGrup(id As Integer) As Integer
'        Return id \ 100
'    End Function
'End Module





