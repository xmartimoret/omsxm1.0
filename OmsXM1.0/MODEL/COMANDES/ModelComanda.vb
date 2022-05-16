Option Explicit On
Module ModelComanda
    Private objects(2100) As List(Of Comanda)
    Private dateUpdate As DateTime
    Private anyActual As Integer
    Public Function getObjects(anyo As Integer, Optional filtre As String = "") As List(Of Comanda)
        Dim a As Comanda, altres As String = ""
        If Not isUpdated(anyo) Then objects(anyo) = getRemoteObjects(anyo)
        getObjects = New List(Of Comanda)
        For Each a In objects(anyo)
            If a.proveidor IsNot Nothing Then altres = a.proveidor.nom
            If a.projecte IsNot Nothing Then altres = altres & a.projecte.nom
            If a.empresa IsNot Nothing Then altres = altres & a.empresa.nom
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
    Public Function getObjects(dIni As Date, dFi As Date, idempresa As Integer, proveidors As List(Of Proveidor), projectes As List(Of Projecte)) As List(Of Comanda)
        Dim a As Comanda, i As Integer, okProveidor As Boolean, okProjecte As Boolean
        For i = Year(dIni) To Year(dFi)
            If Not isUpdated(i) Then objects(i) = getRemoteObjects(i)
        Next
        getObjects = New List(Of Comanda)
        For i = Year(dIni) To Year(dFi)
            For Each a In objects(i)
                If a.data >= dIni And a.data <= dFi Then
                    a.notes = IDIOMA.getString("enviada")
                    a.estat = 2
                    If idempresa = a.empresa.id Or idempresa = -1 Then
                        okProveidor = False : okProjecte = False
                        If proveidors.Count = 0 Then
                            okProveidor = True
                        ElseIf a.proveidor IsNot Nothing Then
                            If proveidors.Exists(Function(x) x.id = a.proveidor.id) Then
                                okProveidor = True
                            End If
                        End If
                        If projectes.Count = 0 Then
                            okProjecte = True
                        ElseIf a.projecte IsNot Nothing Then
                            If projectes.Exists(Function(x) x.id = a.projecte.id) Then
                                okProjecte = True
                            End If
                        End If
                        If okProveidor And okProjecte Then getObjects.Add(a)
                    End If
                End If
            Next
        Next
        a = Nothing
    End Function
    Public Function getDataList(comandes As List(Of Comanda)) As DataList
        Dim a As Comanda
        getDataList = New DataList
        comandes.Sort()
        If comandes.Count > 0 Then
            getDataList.columns.Add(COLUMN.GENERICA("ID", 0, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("idEstat", 0, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("estat", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("codi", 140, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("data", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("proveidor", 300, HorizontalAlignment.Left))
            getDataList.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Right))
            getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Right))
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Right))
            For Each a In comandes
                If a.empresa Is Nothing Then a.empresa = New Empresa
                If a.projecte Is Nothing Then a.projecte = New Projecte
                If a.proveidor Is Nothing Then a.proveidor = New Proveidor
                If a.empresa.id = 1 Then
                    getDataList.rows.Add(New ListViewItem(New String() {a.id, a.estat, a.notes, a.getCodi, Format(a.data, "dd-MM-yy"), "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {a.id, a.estat, a.notes, a.getCodi, Format(a.data, "dd-MM-yy"), a.empresa.codi, a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €")}))
                End If

            Next
        End If
        a = Nothing
    End Function
    Public Function getDataListArticles(comandes As List(Of Comanda)) As DataList
        Dim c As Comanda, a As articleComanda
        getDataListArticles = New DataList
        If comandes.Count > 0 Then

            getDataListArticles.columns.Add(COLUMN.GENERICA("estat", 80, HorizontalAlignment.Center))
            getDataListArticles.columns.Add(COLUMN.GENERICA("codi", 140, HorizontalAlignment.Center))
            getDataListArticles.columns.Add(COLUMN.GENERICA("data", 70, HorizontalAlignment.Center))
            getDataListArticles.columns.Add(COLUMN.GENERICA("projecte", 100, HorizontalAlignment.Center))
            getDataListArticles.columns.Add(COLUMN.GENERICA("proveidor", 180, HorizontalAlignment.Left))
            getDataListArticles.columns.Add(COLUMN.GENERICA("referencia", 120, HorizontalAlignment.Center))
            getDataListArticles.columns.Add(COLUMN.GENERICA("quantitat", 50, HorizontalAlignment.Center))
            getDataListArticles.columns.Add(COLUMN.GENERICA("descripcio", 210, HorizontalAlignment.Left))
            getDataListArticles.columns.Add(COLUMN.GENERICA("preu", 100, HorizontalAlignment.Right))
            getDataListArticles.columns.Add(COLUMN.GENERICA("descompte", 60, HorizontalAlignment.Center))
            getDataListArticles.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Right))
            getDataListArticles.columns.Add(COLUMN.GENERICA("total", 120, HorizontalAlignment.Right))


            For Each c In comandes
                For Each a In c.articles
                    If a.preu <> 0 Then
                        If c.empresa Is Nothing Then c.empresa = New Empresa
                        If c.projecte Is Nothing Then c.projecte = New Projecte
                        If c.proveidor Is Nothing Then c.proveidor = New Proveidor
                        getDataListArticles.rows.Add(New ListViewItem(New String() {c.notes, c.getCodi, Format(c.data, "dd-MM-yy"), c.projecte.codi, c.proveidor.nom, a.codi, a.quantitat, a.nom, Format(a.preu, "#,##0.00 €"), Format(a.tpcDescompte, "#,##0%"), Format(a.base, "#,##0.00 €"), Format(a.total, "#,##0.00 €")}))
                    End If
                Next
            Next
        End If
        a = Nothing
    End Function
    Public Function getObject(id As Integer) As Comanda
        Dim c As Comanda, i As Integer
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)

        For i = 2010 To 2100
            If Not IsNothing(objects(i)) Then
                For Each c In objects(i)
                    c = objects(i).Find(Function(x) x.id = id)
                    If c IsNot Nothing Then
                        Return c
                    End If
                Next
            End If
        Next

        Return Nothing
    End Function

    Public Function getCodi(id As Integer) As String
        Dim c As Comanda, i As Integer
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)

        For i = 2010 To 2100
            If Not IsNothing(objects(i)) Then
                For Each c In objects(i)
                    c = objects(i).Find(Function(x) x.id = id)
                    If c IsNot Nothing Then
                        Return c.codi
                    End If
                Next
            End If
        Next

        Return Nothing
    End Function
    Friend Function getLastCodiEmpresa(idEmpresa As Integer, anyo As Integer) As Integer
        Dim c As Comanda, id As Integer
        If Not isUpdated(anyo) Then objects(anyo) = getRemoteObjects(anyo)
        id = 1
        For Each c In objects(anyo)
            If idEmpresa = c.empresa.id Then
                If id < Val(c.codi) Then
                    id = Val(c.codi)
                End If
            End If
        Next
        Return id
    End Function
    Public Function getNom(id As Integer) As String
        Dim c As Comanda, i As Integer
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)

        For i = 2010 To 2100
            If Not IsNothing(objects(i)) Then
                For Each c In objects(i)
                    c = objects(i).Find(Function(x) x.id = id)
                    If c IsNot Nothing Then
                        Return c.nom
                    End If
                Next
            End If
        Next

        Return Nothing
    End Function
    Public Function exist(obj As Comanda) As Boolean
        If Not isUpdated(obj.getAnyo) Then objects(obj.getAnyo) = getRemoteObjects(obj.getAnyo)
        Return objects(obj.getAnyo).Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existCodi(obj As Comanda) As Integer
        If Not isUpdated(Year(obj.data)) Then objects(obj.getAnyo) = getRemoteObjects(Year(obj.data))
        Return objects(obj.getAnyo).Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existObject(id As Integer, p As Object) As Boolean
        Return dbComanda.exist(id, p, 2)
    End Function
    Public Function insert(obj As Comanda) As Integer
        If Not isUpdated(obj.getAnyo) Then objects(obj.getAnyo) = getRemoteObjects(obj.getAnyo)
        obj.id = dbComanda.insert(obj, 2)
        If obj.id > -1 Then
            dateUpdate = Now()
            objects(obj.getAnyo).Remove(obj)
            objects(obj.getAnyo).Add(obj)
            If Not ModelarticleComanda.insertComanda(obj.articles, obj.id) Then Return -1
        End If
        Return obj.id
    End Function
    Public Function remove(obj As Comanda) As Boolean
        Dim result As Boolean
        result = dbComanda.remove(obj, 2)
        If result Then
            dateUpdate = Now()
            objects(obj.getAnyo).Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
        Dim i As Integer
        For i = 2000 To UBound(objects)
            objects(i) = Nothing
        Next
    End Sub

    Private Function getRemoteObjects(anyo As Integer) As List(Of Comanda)
        dateUpdate = Now()
        Return dbComanda.getObjects(anyo, 2)
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated(anyo As Integer) As Boolean
        If Not objects(anyo) Is Nothing Then
            If anyActual <> anyo Then
                anyActual = anyo
                Return False
            Else
                isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaComanda)
            End If
        Else
            anyActual = anyo
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function


End Module
