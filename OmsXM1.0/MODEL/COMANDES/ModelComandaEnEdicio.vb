Module ModelComandaEnEdicio
    Private objects As List(Of Comanda)
    Private dateUpdate As DateTime
    Private anyActual As Integer
    Public Function getObjects(Optional filtre As String = "") As List(Of Comanda)
        Dim a As Comanda, altres As String = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of Comanda)
        For Each a In objects
            a.articles = ModelArticleComandaEnEdicio.getObjects(a.id)
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
    Public Function getDataList(comandes As List(Of Comanda)) As DataList
        Dim a As Comanda
        getDataList = New DataList
        comandes.Sort()
        If comandes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("codi", 200, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("data", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("proveidor", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Center))
            For Each a In comandes
                If a.empresa Is Nothing Then a.empresa = New Empresa
                If a.projecte Is Nothing Then a.projecte = New Projecte
                If a.proveidor Is Nothing Then a.proveidor = New Proveidor
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, a.base, a.iva, a.total}))
            Next
        End If
        a = Nothing
    End Function
    Public Function getObject(id As Integer) As Comanda
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        Return objects.Find(Function(x) x.id = id)
    End Function

    Public Function getCodi(id As Integer) As String
        Dim c As Comanda
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        c = objects.Find(Function(x) x.id = id)
        If c IsNot Nothing Then Return c.codi
        Return Nothing
    End Function
    Friend Function getLastCodiEmpresa(idEmpresa As Integer, anyo As Integer) As Integer
        Dim c As Comanda, id As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        id = 1
        For Each c In objects
            If idEmpresa = c.empresa.id Then
                If id < Val(c.codi) Then
                    id = Val(c.codi)
                End If
            End If
        Next
        Return id
    End Function
    Public Function getNom(id As Integer) As String
        Dim a As Comanda
        getNom = ""
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        a = objects.Find(Function(x) x.id = id)
        If a IsNot Nothing Then getNom = a.nom
        a = Nothing
    End Function


    Public Function exist(obj As Comanda) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existCodi(obj As Comanda) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function save(obj As Comanda) As Integer
        Dim a As articleComanda
        If Not isUpdated() Then objects = getRemoteObjects()
        If obj.id = -1 Then
            obj.codi = getLastCodiEmpresa(obj.empresa.id, obj.getAnyo) + 1
            obj.id = dbComandaEnEdicio.insert(obj)
            For Each a In obj.articles
                a.idComanda = obj.id
            Next
        Else
            obj.id = dbComandaEnEdicio.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            If Not ModelArticleComandaEnEdicio.saveComanda(obj) Then Return -1
        End If
        Return obj.id
    End Function
    Public Function remove(obj As Comanda) As Boolean
        Dim result As Boolean
        result = dbComandaEnEdicio.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Function getNewComandaToF56(obj As SolicitudComanda) As Comanda
        Dim c As Comanda, e As Empresa, p As Projecte, ct As Contacte, pr As Proveidor, a As articleComanda, aF As ArticleSolicitut
        e = ModelEmpresa.getObject(obj.empresa)
        p = ModelProjecte.getObject(obj.codiProjecte)
        pr = ModelProveidor.getObject(obj.idProveidor)
        c = New Comanda(-1, -1, pr, e, p)
        c.responsable = p.responsable
        c.director = p.director
        c.magatzem = ModelLlocEntrega.getObjectByName(obj.llocEntrega)
        c.contacte = ModelContacte.getObject(obj.contacteEntrega)
        If IsNothing(c.contacte) Then c.contacte = ModelContacte.getObjectByName(obj.contacteEntrega)
        c.contacteProveidor = ModelProveidorContacte.getObject(obj.idContacteProveidor)
        If IsNothing(c.contacteProveidor) Then c.contacteProveidor = pr.contacteActual()
        c.dadesBancaries = pr.iban1
        c.tipusPagament = pr.tipusPagament
        c.data = Now
        c.dataEntrega = obj.dataEntrega
        c.dataMuntatge = obj.dataFinalitzacio
        c.nOferta = obj.oferta1
        c.notes = obj.notes
        c.ports = "PAGADOS"
        c.estat = 0
        c.solicitutF56 = obj
        c.idSolicitut = obj.id
        For Each aF In obj.articles
            a = New articleComanda
            a.codi = aF.codi
            a.nom = aF.nom
            a.idComanda = -1 ' cal tenir en compte a l'hora de guardar els articles
            a.pos = aF.pos
            a.preu = aF.preu
            a.tIva = ModelArticle.getTipusIva(a.codi)
            a.tpcDescompte = aF.tpcDescompte
            c.articles.Add(a)
        Next
        getNewComandaToF56 = c
        c = Nothing
        e = Nothing
        p = Nothing
        ct = Nothing
        pr = Nothing
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of Comanda)
        dateUpdate = Now()
        Return dbComandaEnEdicio.getObjects()
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaComandaEdicio)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
