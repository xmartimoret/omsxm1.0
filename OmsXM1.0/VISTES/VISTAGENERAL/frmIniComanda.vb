
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmIniComanda
    Private tabs As List(Of tabControl)
    Private refrescarSolicitudsComanda As Boolean
    Private refrescarComandaEnEdicio As Boolean
    Private refrescarComandes As Boolean
    Private refrescarComandesEliminacio As Boolean
    Private refrescarFitxersF56 As Boolean
    Private idActual As Integer
    Private isPComanda As Boolean
    Private panelComanda As pComanda
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        tabs = New List(Of tabControl)
        Call setLanguage()
        If Not DBCONNECT.setConnectServer Then
            Dim f As New dRutaServidorDades, ruta As String
            ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES), IDIOMA.getString("configRutaServidorDades"))
            f.Dispose()
            If CONFIG.folderExist(ruta) Then
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES, ruta)
            End If
            f = Nothing
        Else
            Call ModelEmpresa.setdata()
            Call ModelProveidor.setdata()
            Call ModelArticle.setdata()
        End If
    End Sub
    Private Sub setLanguage()
        Me.mnuComptabilitat.Text = IDIOMA.getString("comptabilitat")
        Me.mnuInformeSubctesCompra.Text = IDIOMA.getString("informeResumSubcomptesCompra")
        Me.mnuInformeArticles.Text = IDIOMA.getString("articles")
        Me.mnuinformeArticlesComandes.Text = IDIOMA.getString("veureArticlesComandes")
        Me.mnuRutaInformes.Text = IDIOMA.getString("mnuRutaInformes")
        Me.mnuF56.Text = IDIOMA.getString("f56SolicitutComanda")
        Me.mnuEnviarF56.Text = IDIOMA.getString("f56Enviar")
        Me.mnuAplicacioVaris.Text = IDIOMA.getString("varis")
        Me.mnuAplicacioFirmaCorreu.Text = IDIOMA.getString("firmaCorreu")
        Me.mnuAplicacio.Text = IDIOMA.getString("mnuAplicacio")
        Me.mnuServidorMydoc.Text = IDIOMA.getString("mnuConfigServerMydoc_Caption")
        Me.mnuApliRutaDirectori.Text = IDIOMA.getString("mnuConfigServerDirectori_Caption")
        Me.mnuReset.Text = IDIOMA.getString("mnuResetDades")
        Me.mnuArticles.Text = IDIOMA.getString("articles")
        Me.mnuAxiliars.Text = IDIOMA.getString("mnuAxiliars")
        Me.mnuCentres.Text = IDIOMA.getString("centres")
        Me.mnuLlocsEntrega.Text = IDIOMA.getString("mnuLlocsEntrega")
        Me.mnuContactesCentre.Text = IDIOMA.getString("mnuContactesCentre")

        Me.mnuConfig.Text = IDIOMA.getString("mnuConfig_Caption")
        Me.mnuFabricants.Text = IDIOMA.getString("fabricants")
        Me.mnuFamilies.Text = IDIOMA.getString("families")
        Me.mnuResponsableCompra.Text = IDIOMA.getString("responsableCompra")
        Me.mnuInformes.Text = IDIOMA.getString("mnuInformes")
        Me.mnuNovaComanda.Text = IDIOMA.getString("mnuNovaComanda")
        Me.mnuPaisos.Text = IDIOMA.getString("paisos")
        Me.mnuProveidors.Text = IDIOMA.getString("proveidors")
        Me.mnuProvincies.Text = IDIOMA.getString("provincies")
        Me.mnuTipusIva.Text = IDIOMA.getString("tipusIva")
        Me.mnuTipusPagament.Text = IDIOMA.getString("tipusPagament")
        Me.mnuUnitats.Text = IDIOMA.getString("unitats")
        Me.mnucercadorComandes.Text = IDIOMA.getString("cercadorComandes")
        Me.mnuComandes.Text = UCase(IDIOMA.getString("comandes"))
        Me.mnuComandesEnviar.Text = IDIOMA.getString("comandesAEnviar")
        Me.mnuImportF56.Text = IDIOMA.getString("importarF56")

        Me.mnuInfoComandes.Text = IDIOMA.getString("comandes")

        Me.mnuVeureComandaEdicio.Text = IDIOMA.getString("veureComandaEdicio")
        Me.mnuComandesEnviar.Text = IDIOMA.getString("veureComandaEnviar")
        Me.mnuCodiComanda.Text = IDIOMA.getString("actualitzarCodiComanda")
        Me.mnuCodisComanda2.Text = IDIOMA.getString("actualitzarCodiComanda")
        Me.mnuRutaSolicituts.Text = IDIOMA.getString("mnuDirectoriFitxersSolicituts")
        Me.mnuRutaComandes.Text = IDIOMA.getString("mnuDirectoriFitxersComandes")
        Me.mnuActualitzarF56.Text = IDIOMA.getString("actualitzarF56")
        Me.mnuActualitzarEmpresa.Text = IDIOMA.getString("actualitzarTaulaEmpresa")
        Me.mnuActualitzarMagatzem.Text = IDIOMA.getString("actualitzarTaulaLlocEntrega")
        Me.mnuActualitzarProjecte.Text = IDIOMA.getString("actualitzarTaulaProjecte")
        Me.mnuActualitzarProveidor.Text = IDIOMA.getString("actualitzarTaulaProveidor")
        Me.mnuActualitzarResponsable.Text = IDIOMA.getString("actualitzarTaulaResponsable")
        Me.mnuActualitzarTot.Text = IDIOMA.getString("actualitzarTotTaula")

        Me.mnuComandaEliminar.Text = IDIOMA.getString("comandesAEliminar")

    End Sub

    Private Sub setTabs()
        Dim t As tabControl, posLeft As Integer, posTop As Integer
        posLeft = 4
        posTop = 4
        panelTabs.Controls.Clear()
        For Each t In tabs
            panelTabs.Controls.Add(t)
            t.Left = posLeft
            t.Top = posTop
            AddHandler t.close, AddressOf closetab
            AddHandler t.isActivate, AddressOf activateTab
            posLeft = t.Left + t.Width + 4
        Next
    End Sub
    Private Sub closetab(id As Integer)
        Dim t As tabControl
        Me.pData.Controls.Clear()
        For Each t In tabs
            If t.id = id Then
                If isPComanda Then
                    If TypeName(panelComanda) = "pComanda" Then
                        Call panelComanda.saveComanda()
                        isPComanda = False
                    End If
                End If
                tabs.Remove(t)
                Exit For
            End If
        Next
        Call setTabs()
        If id > 1 Then Call activateTab(id - 1)
    End Sub
    Private Sub activateTab(id As Integer)
        Dim t As tabControl
        For Each t In tabs
            If t.id <> id Then
                t.deActivate()
                t.panel.Hide()
            Else
                'If isPComanda Then
                '    If TypeName(panelComanda) = "pComanda" Then
                '        Call panelComanda.saveComanda()
                '        isPComanda = False
                '    End If
                'End If
                t.activate()
                If t.nom = IDIOMA.getString("solicitudsComanda") Then
                    If refrescarSolicitudsComanda Then
                        t.panel = New SelectSolicitudComandes(1, True, False)
                        t.panel.Dock = DockStyle.Fill
                        refrescarSolicitudsComanda = False
                    End If
                ElseIf t.nom = IDIOMA.getString("comandesEdicio") Then
                    If refrescarComandaEnEdicio Then
                        t.panel = New SelectComandesEdicio(1, True, False)
                        t.panel.Dock = DockStyle.Fill
                        refrescarComandaEnEdicio = False
                    End If
                ElseIf t.nom = IDIOMA.getString("fitxersF56") Then
                    If refrescarFitxersF56 Then
                        Dim p As SelectFitxersSolicitut
                        p = New SelectFitxersSolicitut(0, True, False)
                        t.panel = p
                        AddHandler p.selectObject, AddressOf importFitxersf56
                        t.panel.Dock = DockStyle.Fill
                    End If
                ElseIf t.nom = IDIOMA.getString("comandesEnviar") Then
                    If refrescarComandes Then
                        Dim p As SelectComandesEnValidacio
                        p = New SelectComandesEnValidacio(1, True, False, IDIOMA.getString("comandesPendentEnviar"), 3)
                        AddHandler p.updateData, AddressOf updatecomanda
                        t.panel = p
                        t.panel.Dock = DockStyle.Fill
                        refrescarComandes = False
                    End If
                ElseIf t.nom = IDIOMA.getString("comandesEliminacio") Then
                    If refrescarComandesEliminacio Then
                        Dim p As SelectComandesEnEliminacio
                        p = New SelectComandesEnEliminacio(1, True, False, IDIOMA.getString("comandesPendentsEliminar"), 1)
                        AddHandler p.updateComanda, AddressOf updateComandaEliminacio
                        t.panel = p
                        t.panel.Dock = DockStyle.Fill

                        refrescarComandesEliminacio = False
                    End If
                ElseIf TypeName(t.panel) = "pComanda" Then
                    isPComanda = True
                End If
                Me.pData.Controls.Clear()
                Me.pData.Controls.Add(t.panel)
                t.panel.Show()
                idActual = id
            End If
        Next
    End Sub

    Private Sub mnuNovaComanda_Click(sender As Object, e As EventArgs) Handles mnuNovaComanda.Click
        Dim i As Integer, c As Comanda, panelComanda As pComanda, codic As CodiComanda
        c = DNovaComanda.getComanda
        If c IsNot Nothing Then
            c.serie = Year(Now)
            codic = ModelCodiComanda.getObject(c.serie, c.empresa.id)
            If Not IsNothing(codic) Then
                c.codi = codic.codi
                codic.codi = codic.codi + 1
            Else
                codic = New CodiComanda(-1, c.serie, 1, c.empresa.id, "")
                c.codi = 1
                codic.codi = 2
            End If
            Call ModelCodiComanda.save(codic)
            Call ModelComandaEnEdicio.save(c)
            i = getIdTab(IDIOMA.getString("mnuComandes"))
            If i > -1 Then
                Call activateTab(i)
            Else
                panelComanda = New pComanda(c, True)
                Call setTab(c.getCodi, panelComanda)
            End If
        End If
        c = Nothing
    End Sub
    Friend Sub updatecomanda()
        refrescarComandaEnEdicio = True
    End Sub
    'Private Sub RemoveSelectSolicitud(c As SolicitudComanda)
    '    If ModelComandaSolicitud.remove(c) Then refrescarSolicitudsComanda = True
    'End Sub

    Private Sub setTab(titol As String, c As UserControl)
        Dim t As tabControl, i As Integer, posLeft As Integer
        i = getIdTab(titol)

        If i = -1 Then
            i = 1
            posLeft = 4
            For Each t In tabs
                i = i + 1
                posLeft = t.Left + t.Width + 4
            Next
            t = New tabControl(i, titol, c)
            tabs.Add(t)
            panelTabs.Controls.Add(t)
            t.Left = posLeft
            t.Top = 4
            AddHandler t.close, AddressOf closetab
            AddHandler t.isActivate, AddressOf activateTab
        End If
        Call activateTab(i)
    End Sub

    Private Sub mnuProveidors_Click(sender As Object, e As EventArgs) Handles mnuProveidors.Click
        Call setTab(IDIOMA.getString("proveidors"), New pProveidors)
    End Sub

    Private Sub mnuCentres_Click(sender As Object, e As EventArgs) Handles mnuCentres.Click
        Call setTab(IDIOMA.getString("centres"), New pProjectesContactes)
    End Sub
    Private Function getIdTab(p As String) As Integer
        Dim t As tabControl
        For Each t In tabs
            If p = t.nom Then
                Return t.id
            End If
        Next
        Return -1
    End Function

    Friend Sub tornarAEditar(c As Comanda)
        Call closetab(idActual)
        Call modificarComanda(c)
    End Sub
    Friend Sub modificarComanda(c As Comanda)
        panelComanda = New pComanda(c, True)
        Call setTab(c.getCodi, panelComanda)
        AddHandler panelComanda.UpdateComanda, AddressOf updatecomanda
        AddHandler panelComanda.UpdateEliminada, AddressOf updateComandaEliminacio
    End Sub
    Friend Sub mostrarComandaValidacio(c As Comanda)
        Dim panelPDF As panelPDF, rutaFitxer As String
        rutaFitxer = CONFIG.getDirectoriPDFComandesEnValidacio & c.getCodi & ".pdf"
        If CONFIG.fileExist(rutaFitxer) Then
            panelPDF = New panelPDF(rutaFitxer, c)
            Call setTab(c.getCodi, panelPDF)
        Else
            Call ModulExportarComanda.execute(c, True, rutaFitxer, False)
            If CONFIG.fileExist(rutaFitxer) Then
                panelPDF = New panelPDF(rutaFitxer, c)
                Call setTab(c.getCodi, panelPDF)
            Else
                Call ERRORS.NO_SHOW_COMANDA_VALIDACIO()
            End If
        End If
    End Sub
    Friend Sub mostrarComanda(c As Comanda, ruta As String)
        Dim panelPDF As panelPDF, rutaFitxer As String
        rutaFitxer = ruta
        If CONFIG.fileExist(rutaFitxer) Then
            panelPDF = New panelPDF(rutaFitxer, c)
            Call setTab(c.getCodi, panelPDF)
        End If
    End Sub
    Friend Sub modificarSolicitut(c As SolicitudComanda, tipusComanda As Integer)
        Dim panelComanda As pSolicitutComanda
        panelComanda = New pSolicitutComanda(c)
        Call setTab(c.toStringCodi, panelComanda)
        'AddHandler panelComanda.removeItem, AddressOf RemoveSelectSolicitud
    End Sub
    Private Sub mnuArticles_Click(sender As Object, e As EventArgs) Handles mnuArticles.Click
        Dim p As pArticlesPreus
        p = New pArticlesPreus()
        Call setTab(IDIOMA.getString("articles"), p)

    End Sub

    Private Sub mnuTipusPagament_Click(sender As Object, e As EventArgs) Handles mnuTipusPagament.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setTipusPagament()
        p = Nothing
    End Sub
    Private Sub mnuPaisos_Click(sender As Object, e As EventArgs) Handles mnuPaisos.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setPaisos()
        p = Nothing
    End Sub

    Private Sub mnuProvincies_Click(sender As Object, e As EventArgs) Handles mnuProvincies.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setProvincies()
        p = Nothing
    End Sub
    Private Sub mnuTipusIva_Click(sender As Object, e As EventArgs) Handles mnuTipusIva.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setTipusIva()
        p = Nothing
    End Sub

    Private Sub mnuUnitats_Click(sender As Object, e As EventArgs) Handles mnuUnitats.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setUnitats()
        p = Nothing
    End Sub


    Private Sub mnuFamilies_Click(sender As Object, e As EventArgs) Handles mnuFamilies.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setFamilies()
        p = Nothing
    End Sub

    Private Sub mnuFabricants_Click(sender As Object, e As EventArgs) Handles mnuFabricants.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setFabricants()
        p = Nothing
    End Sub



    Private Sub mnuVeureSolicituts_Click(sender As Object, e As EventArgs)
        Dim p As SelectSolicitudComandes
        p = New SelectSolicitudComandes(1, True, False)
        Call setTab(IDIOMA.getString("solicitudsComanda"), p)
    End Sub
    Friend Sub setLog(l As Log)
        Dim p As panelLog
        p = New panelLog(l)
        Call setTab(l.titol, p)
    End Sub

    'Private Sub setFitxers(fitxers As List(Of CodiDescripcio))
    '    Call ModulImportSolicituds.importFitxers(fitxers)

    '    refrescarSolicitudsComanda = True
    'End Sub
    Private Sub mnuApliServidor_Click(sender As Object, e As EventArgs) Handles mnuServidorMydoc.Click
        Dim fr As New frmServer
        fr.ShowDialog()
        fr.Dispose()
        fr = Nothing
    End Sub

    Private Sub mnuApliRutaDirectori_Click(sender As Object, e As EventArgs) Handles mnuApliRutaDirectori.Click
        Dim f As New dRutaServidorDades, ruta As String
        ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES), IDIOMA.getString("configRutaServidorDades"))
        f.Dispose()
        If CONFIG.folderExist(ruta) Then
            Call DBCONNECT.close()
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES, ruta)
        End If

        f = Nothing
    End Sub

    'Private Sub mnuimportSolicitut_Click(sender As Object, e As EventArgs)


    '    Dim p As SelectFitxersSolicitut
    '    p = New SelectFitxersSolicitut(0, True, False)
    '    refrescarFitxersF56 = False
    '    Call setTab(IDIOMA.getString("fitxersF56"), p)
    '    AddHandler p.selectObject, AddressOf importFitxersf56

    'End Sub
    Private Sub importFitxersf56(fitxers As List(Of CodiDescripcio))
        Dim objects As List(Of SolicitudComanda), c As Comanda, s As SolicitudComanda, p As SelectComandesEdicio, i As Integer, a As frmAvis
        Dim codiC As CodiComanda
        objects = ModulImportSolicituds.importFitxers(fitxers)
        i = 0
        If objects.Count > 0 Then
            a = New frmAvis(IDIOMA.getString("esperaUnMoment"), "CREANT COMANDES", "", objects.Count)
            For Each s In objects
                'aqui cal comprovar si existeix 
                s = DImportF56Avisos.getData(s)
                If Not IsNothing(s) Then
                    If ModulImportSolicituds.save(s) Then
                        c = ModelComandaEnEdicio.getNewComandaToF56(s)
                        a.setData(IDIOMA.getString("importarF56"), c.ToString, i)
                        If Not IsNothing(c) Then
                            c.serie = Year(Now)
                            codiC = ModelCodiComanda.getObject(c.serie, c.empresa.id)

                            If Not IsNothing(codiC) Then
                                c.codi = codiC.codi
                                codiC.codi = codiC.codi + 1
                            Else
                                codiC = New CodiComanda(-1, c.serie, 1, c.empresa.id, "")
                                c.codi = 1
                                codiC.codi = 2
                            End If

                            Call ModelCodiComanda.save(codiC)
                            c.id = ModelComandaEnEdicio.save(c)
                            If c.id > 0 Then
                                For Each d In c.documentacio
                                    d.idComandaEnEdicio = c.id
                                    d.anyo = c.getAnyo
                                    Call ModelDocumentacio.save(d)
                                    'If CONFIG.fileExist(CONFIG.setSeparator(CONFIG_FILE.getTag(Tag.RUTA_FITXERS_SOLICITUT)) & d.nom) Then
                                    '    Call FileCopy(CONFIG.setSeparator(CONFIG_FILE.getTag(Tag.RUTA_FITXERS_SOLICITUT)) & d.nom, CONFIG.setSeparator(CONFIG.getDirectoriServidorOfertes) & d.nom)
                                    '    Kill(CONFIG.setSeparator(CONFIG_FILE.getTag(Tag.RUTA_FITXERS_SOLICITUT)) & d.nom)
                                    'End If                    
                                Next
                            End If
                            i = i + 1
                        End If
                    End If
                End If
            Next
            a.tancar()

            If i > 0 Then
                refrescarComandaEnEdicio = True
                p = New SelectComandesEdicio(1, True, False)
                Me.Visible = False
                Call setTab(IDIOMA.getString("comandesEdicio"), p)
                Me.Visible = True
            End If
            refrescarFitxersF56 = True

        End If
        objects = Nothing
        s = Nothing
        c = Nothing
    End Sub

    Private Sub mnuVeureComandaEdicio_Click(sender As Object, e As EventArgs) Handles mnuVeureComandaEdicio.Click
        Dim p As SelectComandesEdicio
        p = New SelectComandesEdicio(1, True, False)
        Call setTab(IDIOMA.getString("comandesEdicio"), p)
    End Sub
    Friend Sub activatePrevious()
        Call closetab(idActual)
        Call activateTab(idActual - 1)
    End Sub
    Friend Sub activateComandaValidada(c As Comanda)
        Call closetab(idActual)
        Call mostrarComandaValidacio(c)
    End Sub
    Private Sub ImportarSolicitutdDeComandaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuImportF56.Click
        Dim panelFitxersSolicitut As SelectFitxersSolicitut
        panelFitxersSolicitut = New SelectFitxersSolicitut(0, True, False)
        refrescarFitxersF56 = False
        Call setTab(IDIOMA.getString("fitxersF56"), panelFitxersSolicitut)
        AddHandler panelFitxersSolicitut.selectObject, AddressOf importFitxersf56
    End Sub

    Private Sub mnuLlocsEntrega_Click(sender As Object, e As EventArgs) Handles mnuLlocsEntrega.Click
        Dim p As SelectLlocEntrega
        p = New SelectLlocEntrega(1, True, False, IDIOMA.getString("magatzemsLlocsEntrega"), 1)
        Call setTab(IDIOMA.getString("magatzems"), New pLlocEntrega)
    End Sub

    Private Sub mnuContactesCentre_Click(sender As Object, e As EventArgs) Handles mnuContactesCentre.Click
        Call setTab(IDIOMA.getString("contactesProjecte"), New pContactes)
    End Sub


    Private Sub mnuCodiComanda_Click(sender As Object, e As EventArgs) Handles mnuCodiComanda.Click
        Call DAuxiliars.setCodisComanda()
    End Sub

    Private Sub mnuRutaSolicituts_Click(sender As Object, e As EventArgs) Handles mnuRutaSolicituts.Click
        Dim f As New dRutaServidorDades, ruta As String
        ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_FITXERS_SOLICITUT), IDIOMA.getString("configRutaFitxersSolicituts"))
        f.Dispose()
        If CONFIG.folderExist(ruta) Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_FITXERS_SOLICITUT, ruta)
        End If

        f = Nothing
    End Sub

    Private Sub mnuResponsableCompra_Click(sender As Object, e As EventArgs) Handles mnuResponsableCompra.Click
        Dim p As DAuxiliars
        p = New DAuxiliars()
        p.setResponsableCompra()
        p = Nothing
    End Sub

    Private Sub mnuComandesEnviar_Click(sender As Object, e As EventArgs) Handles mnuComandesEnviar.Click
        Dim p As SelectComandesEnValidacio
        p = New SelectComandesEnValidacio(1, True, False, IDIOMA.getString("comandesPendentEnviar"), 3)
        Call setTab(IDIOMA.getString("comandesEnviar"), p)
        AddHandler p.selectObject, AddressOf actualitzarPanelValidacio
    End Sub
    Private Sub actualitzarPanelValidacio(c As Comanda)
        refrescarComandes = True
        'Call activateTab(getIdTab(IDIOMA.getString("comandesEnviar")))
    End Sub
    Friend Sub updateComandesEnviades()
        refrescarComandes = True
    End Sub

    Friend Sub refreshTabActual()
        Call activateTab(idActual)
    End Sub
    Private Sub mnuReset_Click(sender As Object, e As EventArgs) Handles mnuReset.Click
        Call CONFIG.resetDades()
    End Sub

    Private Sub mnuCodisComanda2_Click(sender As Object, e As EventArgs) Handles mnuCodisComanda2.Click
        Call DAuxiliars.setCodisComanda()
    End Sub

    Private Sub RutaComandesEnviadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuRutaComandes.Click
        Dim f As New dRutaServidorDades, ruta As String
        ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_FITXERS_COMANDA), IDIOMA.getString("configRutaComandes"))
        f.Dispose()
        If CONFIG.folderExist(ruta) Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_FITXERS_COMANDA, ruta)
        End If

        f = Nothing
    End Sub

    Private Sub mnuActualitzarTot_Click(sender As Object, e As EventArgs) Handles mnuActualitzarTot.Click
        Call GOOGLE_SHEETS.connectService()
        If GOOGLE_SHEETS.saveAll(ModelProveidor.getObjects(True), New Proveidor) And
          GOOGLE_SHEETS.saveAll(ModelProveidorContacte.getObjects(True), New ProveidorCont) And
          GOOGLE_SHEETS.saveAll(ModelLlocEntrega.getObjects(True), New LlocEntrega) And
          GOOGLE_SHEETS.saveAll(ModelContacte.getObjects(True), New Contacte) And
          GOOGLE_SHEETS.saveAll(ModelProjecte.getObjects, New Projecte) And
          GOOGLE_SHEETS.saveAll(ModelResponsableCompra.getAuxiliar.getObjects, New ResponsableCompra) And
          GOOGLE_SHEETS.saveAll(ModelEmpresa.getObjects, New Empresa) Then Call MISSATGES.DATA_UPDATED()
        Call GOOGLE_SHEETS.closeService()
    End Sub
    Private Sub mnuActualitzarProveidor_Click(sender As Object, e As EventArgs) Handles mnuActualitzarProveidor.Click
        If GOOGLE_SHEETS.saveAll(ModelProveidor.getObjects(True), New Proveidor) And GOOGLE_SHEETS.saveAll(ModelProveidorContacte.getObjects(True), New ProveidorCont) Then Call MISSATGES.DATA_UPDATED()
        Call GOOGLE_SHEETS.closeService()
    End Sub
    Private Sub mnuActualitzarMagatzem_Click(sender As Object, e As EventArgs) Handles mnuActualitzarMagatzem.Click
        If GOOGLE_SHEETS.saveAll(ModelLlocEntrega.getObjects(True), New LlocEntrega) And GOOGLE_SHEETS.saveAll(ModelContacte.getObjects(True), New Contacte) Then Call MISSATGES.DATA_UPDATED()
        Call GOOGLE_SHEETS.closeService()
    End Sub
    Private Sub mnuActualitzarProjecte_Click(sender As Object, e As EventArgs) Handles mnuActualitzarProjecte.Click
        If GOOGLE_SHEETS.saveAll(ModelProjecte.getObjects, New Projecte) Then Call MISSATGES.DATA_UPDATED()
        Call GOOGLE_SHEETS.closeService()
    End Sub
    Private Sub mnuActualitzarResponsable_Click(sender As Object, e As EventArgs) Handles mnuActualitzarResponsable.Click
        If GOOGLE_SHEETS.saveAll(ModelResponsableCompra.getAuxiliar.getObjects, New ResponsableCompra) Then Call MISSATGES.DATA_UPDATED()
        Call GOOGLE_SHEETS.closeService()
    End Sub
    Private Sub mnuActualitzarEmpresa_Click(sender As Object, e As EventArgs) Handles mnuActualitzarEmpresa.Click
        If GOOGLE_SHEETS.saveAll(ModelEmpresa.getObjects, New Empresa) Then Call MISSATGES.DATA_UPDATED()
        Call GOOGLE_SHEETS.closeService()
    End Sub

    Private Sub mnuAplicacioFirmaCorreu_Click(sender As Object, e As EventArgs) Handles mnuAplicacioFirmaCorreu.Click
        Dim panel As pConfigCorreu
        panel = New pConfigCorreu
        Call setTab(IDIOMA.getString("etqSignEmail"), panel)

    End Sub



    Private Sub mnucercadorComandes_Click_1(sender As Object, e As EventArgs) Handles mnucercadorComandes.Click
        Dim p As pCercarComandes
        p = New pCercarComandes
        Call setTab(IDIOMA.getString("cercarComandes"), p)
    End Sub

    Private Sub mnuEnviarF56_Click(sender As Object, e As EventArgs) Handles mnuEnviarF56.Click
        Dim r As ResponsableCompra, responsables As List(Of Object), ruta As String
        responsables = DAuxiliars.getResponsablesCompra()
        If responsables.Count = 1 Then
            r = responsables.Item(0)
            ruta = modulF56.execute()
            If CONFIG.fileExist(ruta) Then
                Call ModulEnviarCorreo.enviarF56(ruta, CONFIG.getFitxer(ruta), r.notes)
            End If
        End If
        r = Nothing
        responsables = Nothing
    End Sub

    Private Sub mnuinformeArticlesComandes_Click(sender As Object, e As EventArgs) Handles mnuinformeArticlesComandes.Click
        Dim panel As pArticlesComandes
        panel = New pArticlesComandes()
        Call setTab(IDIOMA.getString("articlesComandes"), panel)
    End Sub

    Private Sub mnuRutesInformes_Click(sender As Object, e As EventArgs) Handles mnuRutaInformes.Click
        Dim f As New dRutaServidorDades, ruta As String
        ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_IMPRESSIO_INFORMES), IDIOMA.getString("configRutaImpresioInformes"))
        f.Dispose()
        If CONFIG.folderExist(ruta) Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_IMPRESSIO_INFORMES, ruta)
        End If

        f = Nothing
    End Sub

    Private Sub mnuInformeSubctesCompra_Click(sender As Object, e As EventArgs) Handles mnuInformeSubctesCompra.Click
        Call ModulInformeSubcomptesCompra.execute()
    End Sub

    Private Sub mnuComandaEliminar_Click(sender As Object, e As EventArgs) Handles mnuComandaEliminar.Click
        Dim p As SelectComandesEnEliminacio
        p = New SelectComandesEnEliminacio(1, True, False, IDIOMA.getString("comandesPendentsEliminar"), 1)
        Call setTab(IDIOMA.getString("comandesEliminacio"), p)
        AddHandler p.updateComanda, AddressOf updateComandaEliminacio
    End Sub
    Friend Sub updateComandaEliminacio()
        refrescarComandesEliminacio = True
    End Sub

    Private Sub mnuInformes_Click(sender As Object, e As EventArgs) Handles mnuInformes.Click

    End Sub
End Class
