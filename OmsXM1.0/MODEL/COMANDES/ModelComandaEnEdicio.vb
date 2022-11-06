Module ModelComandaEnEdicio
    Private objects As List(Of Comanda)
    Private dateUpdate As DateTime
    Private anyActual As Integer
    Private Enum estat
        pendentEliminar = -1
        enEdicio = 0
        enValidacio = 1
        aEnviar = 2
    End Enum
    Public Function getObjects(pEstat As Integer, Optional filtre As String = "") As List(Of Comanda)
        Dim a As Comanda, altres As String = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        Call importNumsMydoc()
        getObjects = New List(Of Comanda)
        For Each a In objects
            If a.estat = pEstat Then
                '' a.articles = ModelArticleComandaEnEdicio.getObjects(a.id)
                'If a.idSolicitut > 0 Then a.solicitutF56 = ModelComandaSolicitud.getObject(a.idSolicitut, a.estat)
                If a.proveidor IsNot Nothing Then altres = a.proveidor.nom
                If a.projecte IsNot Nothing Then altres = altres & a.projecte.nom
                If a.empresa IsNot Nothing Then altres = altres & a.empresa.nom
                altres = altres & a.getStringTascaMydoc
                If altres <> "" Then
                    If a.isFilter(filtre, altres) Then
                        getObjects.Add(a)
                    End If
                Else
                    If a.isFilter(filtre) Then
                        getObjects.Add(a)
                    End If
                End If
            End If
        Next
    End Function
    Public Function getObjects(dIni As Date, dFi As Date, idempresa As Integer, proveidors As List(Of Proveidor), projectes As List(Of Projecte), pEstat As Integer) As List(Of Comanda)
        Dim a As Comanda, i As Integer, okProveidor As Boolean, okProjecte As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Call importNumsMydoc()
        getObjects = New List(Of Comanda)
        For Each a In objects
            If a.estat = pEstat Then
                If pEstat = 0 Then
                    a.notes = IDIOMA.getString("enEdicio")
                ElseIf pEstat = 1 Then
                    a.notes = IDIOMA.getString("enValidacio")
                End If
                If a.data >= dIni And a.data <= dFi Then
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
            End If
        Next
        a = Nothing
    End Function
    Public Function getObjectsByCodiComanda(pCodi As String) As List(Of Comanda)
        Dim a As Comanda
        If Not isUpdated() Then objects = getRemoteObjects()
        Call importNumsMydoc()
        getObjectsByCodiComanda = New List(Of Comanda)
        For Each a In objects
            If InStr(a.codi, pCodi, CompareMethod.Text) > 0 Then
                If a.estat = 0 Then
                    a.notes = IDIOMA.getString("enEdicio")
                ElseIf a.estat = 1 Then
                    a.notes = IDIOMA.getString("enValidacio")
                End If
                getObjectsByCodiComanda.Add(a)
            End If
        Next
        a = Nothing
    End Function
    Public Function getDataList(comandes As List(Of Comanda)) As DataList
        Dim a As Comanda, esEnviada As String, comentString As String, cm As ComentariMD, esUrgent As String, i As Integer
        getDataList = New DataList
        comandes.Sort()
        If comandes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("urgent", 65, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("codi", 90, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("data", 90, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("empresa", 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("proveidor", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Right))
            getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Right))
            getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Right))
            getDataList.columns.Add(COLUMN.GENERICA("myDoc", 100, HorizontalAlignment.Right))
            getDataList.columns.Add(COLUMN.GENERICA("estatMydoc", 200, HorizontalAlignment.Left))
            getDataList.columns.Add(COLUMN.GENERICA("dataEntradaMydoc", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("enviadaAProveidor", 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("comentaris", 300, HorizontalAlignment.Left))
            i = 0
            For Each a In comandes
                If a.empresa Is Nothing Then a.empresa = New Empresa
                If a.projecte Is Nothing Then a.projecte = New Projecte
                If a.proveidor Is Nothing Then a.proveidor = New Proveidor
                If a.idMydoc > 0 And a.docMyDoc Is Nothing Then
                    esEnviada = IDIOMA.getString("si")
                Else
                    esEnviada = IDIOMA.getString("no")
                End If
                If a.urgent Then
                    esUrgent = IDIOMA.getString("si")
                Else
                    esUrgent = IDIOMA.getString("no")
                End If
                comentString = ""
                For Each cm In a.comentaris
                    If comentString = "" Then
                        comentString = Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
                    Else
                        comentString = comentString & " --> " & Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
                    End If

                Next
                If a.empresa.id = 1 Then
                    getDataList.rows.Add(New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString}))
                End If
                If a.urgent Then
                    getDataList.rows(i).BackColor = Color.Cyan
                Else
                    getDataList.rows(i).BackColor = Color.White
                End If
                i = i + 1
            Next
        End If
        a = Nothing
    End Function
    Public Function getListViewItem(a As Comanda) As ListViewItem
        Dim esUrgent As String, esEnviada As String, comentString As String
        If a.idMydoc > 0 And a.docMyDoc Is Nothing Then
            esEnviada = IDIOMA.getString("si")
        Else
            esEnviada = IDIOMA.getString("no")
        End If
        If a.urgent Then
            esUrgent = IDIOMA.getString("si")
        Else
            esUrgent = IDIOMA.getString("no")
        End If
        comentString = ""
        For Each cm In a.comentaris
            If comentString = "" Then
                comentString = Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
            Else
                comentString = comentString & " --> " & Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
            End If

        Next
        If a.empresa.id = 1 Then
            '{a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString}
            Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
        Else
            Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
        End If

    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim a As Comanda, esUrgent As String, esEnviada As String, comentString As String
        a = getObject(id)
        If a.idMydoc > 0 And a.docMyDoc Is Nothing Then
            esEnviada = IDIOMA.getString("si")
        Else
            esEnviada = IDIOMA.getString("no")
        End If
        If a.urgent Then
            esUrgent = IDIOMA.getString("si")
        Else
            esUrgent = IDIOMA.getString("no")
        End If
        comentString = ""
        For Each cm In a.comentaris
            If comentString = "" Then
                comentString = Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
            Else
                comentString = comentString & " --> " & Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
            End If

        Next
        If a IsNot Nothing Then
            If a.empresa.id = 1 Then
                Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
            Else
                Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
            End If

        End If
        Return Nothing
    End Function
    Public Function getObject(id As Integer) As Comanda
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObjectBYCodi(p As String) As Comanda
        'If Not isUpdated(ANYO) Then objects = getRemoteobjects(ANYO)
        Return objects.Find(Function(x) InStr(1, p, x.getCodi, CompareMethod.Text) > 0)
    End Function
    Public Function getCodi(id As Integer) As String
        Dim c As Comanda
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        c = objects.Find(Function(x) x.id = id)
        If c IsNot Nothing Then Return c.codi
        Return Nothing
    End Function
    'Friend Function getLastCodiEmpresa(idEmpresa As Integer, anyo As Integer) As Integer
    '    Dim c As Comanda, id As Integer
    '    If Not isUpdated() Then objects = getRemoteObjects()
    '    id = 1
    '    For Each c In objects
    '        If idEmpresa = c.empresa.id Then
    '            If id < Val(c.codi) Then
    '                id = Val(c.codi)
    '            End If
    '        End If
    '    Next
    '    Return id
    'End Function
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
    Public Function existObject(id As Integer, p As Object) As Boolean
        Return dbComanda.exist(id, p, 0)
    End Function
    Public Function save(obj As Comanda) As Integer
        Dim a As articleComanda
        If Not isUpdated() Then objects = getRemoteObjects()
        If obj.id = -1 Then
            'obj.codi = getLastCodiEmpresa(obj.empresa.id, obj.getAnyo) + 1
            'obj.codi = "NOVA"            
            obj.id = dbComanda.insert(obj, obj.estat)
            For Each a In obj.articles
                a.idComanda = obj.id
            Next
        Else
            obj.id = dbComanda.update(obj, obj.estat)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            If Not ModelArticleComandaEnEdicio.saveComanda(obj) Then Return -1
        End If
        Return obj.id
    End Function
    Public Function aBassura(obj As Comanda) As Boolean
        obj.estat = -1
        obj.id = dbComanda.updateEstat(obj.id, -1)
        If obj.id > 0 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function
    Public Function remove(obj As Comanda) As Boolean
        Dim result As Boolean
        result = dbComanda.remove(obj, obj.estat)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Function remove(idComanda As Integer) As Boolean
        Dim result As Boolean, obj As Comanda
        obj = New Comanda(idComanda, "")
        result = dbComanda.remove(New Comanda(idComanda, ""), 0)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Function getNewComandaToF56(obj As SolicitudComanda) As Comanda
        Dim c As Comanda, e As Empresa, p As Projecte, ct As Contacte, pr As Proveidor, a As articleComanda, aF As ArticleSolicitut, descrip As String, posDescrip As Integer = 0
        Dim nomCognom() As String
        e = ModelEmpresa.getObject(obj.empresa)
        p = ModelProjecte.getObject(obj.codiProjecte, e.id)
        pr = ModelProveidor.getObject(obj.idProveidor)
        c = New Comanda(-1, -1, pr, e, p)
        c.magatzem = ModelLlocEntrega.getObject(obj.idLlocEntrega)
        If IsNothing(c.magatzem) Then If obj.llocEntrega <> "" Then c.magatzem = ModelLlocEntrega.getObjectByName(obj.llocEntrega)
        c.contacte = ModelContacte.getObject(obj.idContacteEntrega)
        If IsNothing(c.contacte) Then If obj.contacteEntrega <> "" Then c.contacte = ModelContacte.getObjectByName(obj.contacteEntrega)
        c.contacteProveidor = ModelProveidorContacte.getObject(obj.idContacteProveidor)
        If IsNothing(c.contacteProveidor) Then If Not IsNothing(pr) Then c.contacteProveidor = pr.contacteActual()
        If Not IsNothing(pr) Then c.dadesBancaries = pr.iban1
        If Not IsNothing(pr) Then c.tipusPagament = pr.tipusPagament
        c.data = Now
        c.dataEntrega = obj.dataEntrega
        c.dataMuntatge = obj.dataFinalitzacio
        c.nOferta = obj.oferta1
        c.notes = obj.notes
        c.ports = "PAGADOS"
        c.documentacio = obj.documentacio
        c.estat = 0
        c.solicitutF56 = obj
        c.idSolicitut = obj.id
        c.departament = obj.departament
        nomCognom = Split(obj.responsableCompra)
        If UBound(nomCognom) = 1 Then
            c.responsableCompra = ModelResponsableCompra.getObject(nomCognom(0), nomCognom(1))
            If c.responsableCompra Is Nothing Then c.responsableCompra = ModelResponsableCompra.getObject(Left(nomCognom(0), 1) & nomCognom(1))
        End If
        For Each aF In obj.articles
            a = New articleComanda
            a.codi = aF.codi
            a.nom = aF.nom
            a.quantitat = aF.quantitat
            a.unitat = ModelUnitat.getObject(aF.unitat)
            If a.unitat Is Nothing Then a.unitat = ModelUnitat.getAuxiliar.getObject(0)
            a.idComanda = -1 ' cal tenir en compte a l'hora de guardar els articles
            a.pos = aF.pos
            a.preu = aF.preu
            a.tIva = ModelArticle.getTipusIva(a.codi)
            a.tpcDescompte = aF.tpcDescompte
            c.articles.Add(a)
            posDescrip = aF.pos + 1
            For Each descrip In aF.descripcio
                a = New articleComanda
                a.nom = descrip
                a.idComanda = -1 ' cal tenir en compte a l'hora de guardar els articles
                a.pos = posDescrip
                posDescrip = posDescrip + 1
                c.articles.Add(a)
            Next
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
        Return dbComanda.getObjects(-1, 0)
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

    '**** ACTIONS SYSTEM MYDOC 
    ''' <summary>
    '''   Llegeix els fitxers que hi  ha en el mydoc . 
    ''' </summary>
    Public Sub importNumsMydoc()
        Dim ruta As String, numero As Long, f As String, c As Comanda, isok As Boolean
        ruta = CONFIG.setFolder(CONFIG_FILE.getRutafitxersMydoc)
        If CONFIG.folderExist(ruta) Then
            f = Dir(ruta, FileAttribute.Archive)
            Do While f <> ""
                isok = False
                Using fitxer As New IO.StreamReader(ruta & f, System.Text.Encoding.GetEncoding(1252)) ' obre el fitxer                 
                    If Not fitxer.EndOfStream Then
                        c = getObjectBYCodi(f)
                        If Not IsNothing(c) Then
                            numero = fitxer.ReadLine()
                            c.docMyDoc = New PedidoMD
                            c.docMyDoc.id = numero
                            c.idMydoc = numero
                            isok = True
                        End If
                    End If
                End Using
                If isok Then
                    If upDateSysMyDoc(c) > 0 Then
                        Call Kill(ruta & f)
                    End If
                End If
                f = Dir()
            Loop
        End If
    End Sub
    ''' <summary>
    ''' Anota el numero del Mydoc a la comanda actuaul
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Public Function upDateSysMyDoc(obj As Comanda) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        obj.id = dbComanda.update(obj.id, obj.estat, obj.docMyDoc.id)
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function updateUrgent(id As Integer) As Integer
        Dim obj As Comanda
        If Not isUpdated() Then objects = getRemoteObjects()
        obj = getObject(id)
        obj.urgent = obj.urgent = False
        id = dbComanda.updateUrgent(obj.id, obj.estat, obj.urgent)
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function enviarComanda(comandaActual As Comanda, pdfActual As String) As Integer
        Dim pdfOrigen As String, P As frmAvis, d As doc, eventActual As EventsMD, eventSeguent As EventsMD
        P = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("actualitzantEmail"), comandaActual.getCorreuProveidor)
        Call ModulEnviarCorreo.enviarCorreu(pdfActual, IDIOMA.getString("comanda") & "-" & comandaActual.ToString, comandaActual, comandaActual.getCorreuProveidor, "")
        P.tancar()
        If MISSATGES.CONFIRM_SEND_COMANDA Then
            P = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("guardarComanda"), pdfActual)
            comandaActual.baseComanda = comandaActual.base - comandaActual.descompte
            comandaActual.ivaComanda = comandaActual.iva
            If IsNothing(comandaActual.docMyDoc) Then comandaActual.docMyDoc = New PedidoMD
            If comandaActual.docMyDoc.id = -1 Then
                comandaActual.docMyDoc = ModelPedidosMydoc.getObject(comandaActual.idMydoc)
            End If
            If comandaActual.docMyDoc.id > 0 Then comandaActual.docMyDoc.events = ModelEventsMyDOc.getObjects(comandaActual.idMydoc)
            If ModelTasca.esFinalWorkflow(comandaActual.getTascaActual) Then
                eventActual = comandaActual.getEventActual
                If ModelComandaEnEdicio.remove(comandaActual) Then
                    Call ModelArticleComandaEnEdicio.remove(comandaActual)
                    frmIniComanda.updatecomanda()
                End If
                comandaActual.estat = 2
                If ModelComanda.insert(comandaActual.copy) > 0 Then
                    For Each d In comandaActual.documentacio
                        d.idComanda = comandaActual.id
                        d.anyo = comandaActual.getAnyo
                        Call ModelDocumentacio.save(d)
                    Next
                    pdfOrigen = CONFIG.getfitxerComandaEnValidacio(comandaActual.getCodi())
                    If CONFIG.fileExist(pdfOrigen) Then
                        FileCopy(pdfOrigen, setSeparator(CONFIG.getDirectoriPDFComandesEnviades(comandaActual.empresa.id)) & CONFIG.getFitxer(pdfOrigen))
                        eventActual.dataFi = Now
                        eventActual.finalitzat = 1
                        eventActual.idUsuari = 91
                        If ModelEventsMyDOc.save(eventActual) > 0 Then
                            comandaActual.docMyDoc.events.Remove(eventActual)
                            comandaActual.docMyDoc.events.Add(eventActual)
                            eventSeguent = New EventsMD
                            eventSeguent.automatic = 1
                            eventSeguent.dataIni = Now
                            eventSeguent.dataFi = Now
                            eventSeguent.finalitzat = 1
                            eventSeguent.idRecurs = eventActual.idRecurs
                            eventSeguent.idTaula = eventActual.idTaula
                            eventSeguent.idTasca = ModelTasca.getIdTascaFinal
                            If ModelEventsMyDOc.save(eventSeguent) Then
                                comandaActual.docMyDoc.estat = 1
                                Call ModelPedidosMydoc.save(comandaActual.docMyDoc)
                            End If
                        End If

                    End If
                    P.tancar()
                    Return 1
                End If
            Else
                Call ModelPedidosMydoc.updateEnviado(comandaActual.docMyDoc)
                P.tancar()
                Return 0
            End If
        End If
        P.tancar()
        Return -1
    End Function

    Public Function passarAEnviada(comandaActual As Comanda, pdfActual As String) As Integer
        Dim pdfOrigen As String, d As doc, idComanda As Integer
        If ModelComandaEnEdicio.remove(comandaActual) Then
            Call ModelArticleComandaEnEdicio.remove(comandaActual)
            frmIniComanda.updatecomanda()
        End If
        comandaActual.baseComanda = comandaActual.base - comandaActual.descompte
        comandaActual.ivaComanda = comandaActual.iva
        comandaActual.estat = 2
        idcomanda = ModelComanda.insert(comandaActual.copy)
        If idcomanda > 0 Then
            For Each d In comandaActual.documentacio
                d.idComanda = idcomanda
                d.anyo = comandaActual.getAnyo
                Call ModelDocumentacio.save(d)
            Next
            pdfOrigen = CONFIG.getfitxerComandaEnValidacio(comandaActual.getCodi())
            If CONFIG.fileExist(pdfOrigen) Then
                FileCopy(pdfOrigen, setSeparator(CONFIG.getDirectoriPDFComandesEnviades(comandaActual.empresa.id)) & CONFIG.getFitxer(pdfOrigen))
                Try
                    Kill(pdfOrigen)
                Catch ex As Exception
                    Call ERRORS.ERR_REMOVE_PDF_COMANDA(pdfOrigen)
                End Try
                frmIniComanda.updateComandesEnviades()
                Return 1
            End If
            Return 0
        End If
        Return -1
    End Function
End Module
