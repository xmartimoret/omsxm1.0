Public Class panelPDF
    Private comandaActual As Comanda
    Private pdfActual As String
    Private actualitzar As Boolean
    Private rutaOfertes As String
    Public Sub New()
        InitializeComponent()
        SplitC.Panel2Collapsed = True
        rutaOfertes = CONFIG.setFolder(CONFIG.getDirectoriServidorOfertes)
    End Sub
    Public Sub New(f As String, c As Comanda)
        ' Esta llamada es exigida por el diseñador.
        comandaActual = c
        pdfActual = f
        InitializeComponent()
        Call setLanguage()
        SplitC.Panel2Collapsed = True

        pdfReaderComanda.LoadFile(f)
        pdfReaderComanda.Enabled = True
        'pdfReaderComanda.Dock = DockStyle.
        pdfReaderComanda.setShowScrollbars(False)
        pdfReaderComanda.setShowToolbar(False)
        If c.solicitutF56 IsNot Nothing Then
            If CONFIG.fileExist(CONFIG.getDirectoriServidorF56 & c.solicitutF56.pdfSolicitut) Then
                pdfReader.LoadFile(CONFIG.getDirectoriServidorF56 & c.solicitutF56.pdfSolicitut)
                pdfReader.setShowScrollbars(False)
                pdfReader.setShowToolbar(False)
                pdfReader.setPageMode("NONE")
            End If
        End If
        rutaOfertes = CONFIG.setFolder(CONFIG.getDirectoriServidorOfertes)
        If c.estat = 1 Then
            Me.cmdValidar.Enabled = True
            Me.cmdEnviar.Enabled = True
        Else
            Me.cmdValidar.Enabled = False
            Me.cmdEnviar.Enabled = False
        End If
    End Sub
    Private Sub setLanguage()
        Me.cmdValidar.Text = IDIOMA.getString("enviarEdicio")
        Me.cmdEnviar.Text = IDIOMA.getString("enviarAProveidor")
        If comandaActual.estat = 1 Then
            Me.lblTitol.Text = IDIOMA.getString("comandaEnValidacio") & " " & pdfActual
        Else
            Me.lblTitol.Text = IDIOMA.getString("comandaEnviada") & " " & pdfActual
        End If

        cmdAdjunts.Text = IDIOMA.getString("fitxersAdjunts")
        lblAdjunts.Text = IDIOMA.getString("fitxersAdjunts")
        tTip1.SetToolTip(cmdAdjunts, IDIOMA.getString("veureFitxersAdjunts"))
        tTip1.SetToolTip(cmdEliminar, IDIOMA.getString("preEliminar"))
        tTip1.SetToolTip(cmdExcel, IDIOMA.getString("cmdImprimir"))
        tTip1.SetToolTip(cmdPdf, IDIOMA.getString("cmdImprimir"))
        tTip1.SetToolTip(cmdBaixar, IDIOMA.getString("cmdBaixar"))
    End Sub

    Private Sub cmdF56_Click(sender As Object, e As EventArgs) Handles cmdAdjunts.Click
        Dim amplada As String
        If cmdAdjunts.Text = IDIOMA.getString("fitxersAdjunts") Then
            SplitC.Panel2Collapsed = False
            amplada = CONFIG_FILE.getTag(CONFIG_FILE.TAG.WIDHT_SPLIT_COMANDES)
            If IsNumeric(amplada) Then
                If amplada > 50 Then
                    SplitC.SplitterDistance = amplada
                Else
                    SplitC.SplitterDistance = 800
                End If
            Else
                SplitC.SplitterDistance = 800
            End If
            cmdAdjunts.Text = IDIOMA.getString("amagarFitxersAdjunts")
        Else
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.WIDHT_SPLIT_COMANDES, SplitC.SplitterDistance)
            SplitC.Panel2Collapsed = True
            cmdAdjunts.Text = IDIOMA.getString("fitxersAdjunts")
        End If
    End Sub
    Private Sub cmdEnviar_Click(sender As Object, e As EventArgs) Handles cmdEnviar.Click
        Dim result As Integer
        result = ModelComandaEnEdicio.enviarComanda(comandaActual, pdfActual)
        If result = 1 Then
            frmIniComanda.updateComandesEnviades()
            frmIniComanda.activatePrevious()
        ElseIf result = 0 Then
            frmIniComanda.updateComandesEnviades()
        End If


        'Dim pdfOrigen As String, P As frmAvis, d As doc, eventActual As EventsMD, eventSeguent As EventsMD
        'P = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("actualitzantEmail"), comandaActual.getCorreuProveidor)
        'Call ModulEnviarCorreo.enviarCorreu(pdfActual, IDIOMA.getString("comanda") & "-" & comandaActual.ToString, comandaActual, comandaActual.getCorreuProveidor, "")
        'P.tancar()
        'If MISSATGES.CONFIRM_SEND_COMANDA Then
        '    P = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("guardarComanda"), pdfActual)
        '    comandaActual.baseComanda = comandaActual.base - comandaActual.descompte
        '    comandaActual.ivaComanda = comandaActual.iva
        '    comandaActual.estat = 2
        '    If ModelTasca.esFinalWorkflow(comandaActual.getTascaActual) Then
        '        eventActual = comandaActual.getEventActual
        '        If ModelComanda.insert(comandaActual.copy) > 0 Then
        '            If ModelComandaEnEdicio.remove(comandaActual) Then
        '                Call ModelArticleComandaEnEdicio.remove(comandaActual)
        '                frmIniComanda.updatecomanda()
        '            End If
        '            For Each d In comandaActual.documentacio
        '                d.idComanda = comandaActual.id
        '                d.anyo = comandaActual.getAnyo
        '                Call ModelDocumentacio.save(d)
        '            Next

        '            pdfOrigen = CONFIG.getfitxerComandaEnValidacio(comandaActual.getCodi())
        '            If CONFIG.fileExist(pdfOrigen) Then
        '                FileCopy(pdfOrigen, setSeparator(CONFIG.getDirectoriPDFComandesEnviades(comandaActual.empresa.id)) & CONFIG.getFitxer(pdfOrigen))

        '                'TODOxmarti 12/10/21 cal revisar
        '                eventActual.dataFi = Now
        '                eventActual.finalitzat = 1
        '                eventActual.idUsuari = 91
        '                If ModelEventsMyDOc.save(eventActual) > 0 Then
        '                    comandaActual.docMyDoc.events.Remove(eventActual)
        '                    comandaActual.docMyDoc.events.Add(eventActual)
        '                    eventSeguent = New EventsMD
        '                    eventSeguent.automatic = 1
        '                    eventSeguent.dataIni = Now
        '                    eventSeguent.dataFi = Now
        '                    eventSeguent.finalitzat = 1
        '                    eventSeguent.idRecurs = eventActual.idRecurs
        '                    eventSeguent.idTaula = eventActual.idTaula
        '                    eventSeguent.idTasca = ModelTasca.getIdTascaFinal
        '                    If ModelEventsMyDOc.save(eventSeguent) Then
        '                        comandaActual.docMyDoc.estat = 1
        '                        Call ModelPedidosMydoc.save(comandaActual.docMyDoc)
        '                    End If
        '                End If




        '            End If

        '        End If
        '    Else
        '        ' aqui cal canviar l'estat del metadato estat 
        '        ' i al posar enviado

        '    End If
        '    P.tancar()
        'End If
    End Sub

    Private Sub cmdCopiar_Click(sender As Object, e As EventArgs) Handles cmdCopiar.Click
        Dim c As Comanda, codiC As CodiComanda
        c = comandaActual.copy
        c.id = -1
        c.estat = 0
        c.serie = Year(Now)
        c.data = Now
        codiC = ModelCodiComanda.getObject(c.serie, c.empresa.id)
        If Not IsNothing(codiC) Then
            c.codi = codiC.codi
            codiC.codi = codiC.codi + 1
        Else
            codiC = New CodiComanda(-1, c.serie, 1, c.empresa.id, "")
            c.codi = 1
            codiC.codi = 2
        End If
        If MISSATGES.CONFIRM_COPY_COMANDA() Then
            Dim p As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("copiantComanda"), c.ToString)
            c.id = ModelComandaEnEdicio.save(c)
            If c.id > 0 Then
                Call ModelCodiComanda.save(codiC)
                Call frmIniComanda.modificarComanda(c)
                frmIniComanda.updatecomanda()
            End If
            p.tancar()
        End If
    End Sub

    Private Sub cmdValidar_Click(sender As Object, e As EventArgs) Handles cmdValidar.Click
        If MISSATGES.CONFIRM_SEND_EDICIO Then
            comandaActual.estat = 0

            If ModelComandaEnEdicio.save(comandaActual) > 0 Then
                Call frmIniComanda.tornarAEditar(comandaActual)
                Call frmIniComanda.modificarComanda(comandaActual)
                frmIniComanda.updatecomanda()
                frmIniComanda.updateComandesEnviades()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdExcel.Click
        Dim f As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintComanda"), comandaActual.ToString)
        Call ModulExportarComanda.execute(comandaActual, False, "")
        f.tancar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdPdf.Click
        Dim f As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintComanda"), comandaActual.ToString)
        Call ModulExportarComanda.execute(comandaActual, True, "")
        f.tancar()
    End Sub

    Private Sub cbAdjunts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAdjunts.SelectedIndexChanged
        If actualitzar Then
            If cbAdjunts.SelectedIndex > -1 Then
                If CONFIG.fileExist(rutaOfertes & cbAdjunts.SelectedItem.nom) Then
                    pdfReader.LoadFile(rutaOfertes & cbAdjunts.SelectedItem.nom)
                    pdfReader.setShowScrollbars(False)
                    pdfReader.setShowToolbar(False)
                    pdfReader.setPageMode("NONE")
                End If
            End If
        End If
    End Sub

    Private Sub panelPDF_Load(sender As Object, e As EventArgs) Handles Me.Load
        actualitzar = False
        cmdAdjunts.Visible = False
        If Not IsNothing(comandaActual.documentacio) Then
            If comandaActual.documentacio.Count > 0 Then
                Call setAdjunts(comandaActual.documentacio)
                cmdAdjunts.Visible = True
            End If
        End If
        actualitzar = True
        If cbAdjunts.Items.Count > 0 Then cbAdjunts.SelectedIndex = 0
    End Sub
    Private Sub setAdjunts(docs As List(Of doc))
        cbAdjunts.Items.Clear()
        cbAdjunts.Items.AddRange(CONFIG.getListObjects(docs))
    End Sub

    Private Sub cmdBaixar_Click(sender As Object, e As EventArgs) Handles cmdBaixar.Click
        Dim rutaFitxer As String, rutaExport As String
        If Not IsNothing(comandaActual) Then
            rutaFitxer = CONFIG.getDirectoriPDFComandesEnValidacio & comandaActual.getCodi & ".pdf"
            If CONFIG.fileExist(rutaFitxer) Then
                rutaExport = CONFIG.getRutaEmpresaComandesPDF(comandaActual.empresa.nom, comandaActual.getAnyo)
                If CONFIG.folderExist(rutaExport) Then
                    rutaExport = CONFIG.setFolder(rutaExport) & comandaActual.toStingNomComanda & ".pdf"
                    FileCopy(rutaFitxer, rutaExport)
                    MISSATGES.COMANDA_GUARDADA(rutaExport)
                End If
            End If
        End If
    End Sub
End Class
