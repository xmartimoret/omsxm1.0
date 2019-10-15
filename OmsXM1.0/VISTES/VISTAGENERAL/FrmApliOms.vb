Public Class FrmApliOms
    Private Const USUARI_EXPLOTACIONS As Integer = 0
    Private Const USUARI_ADMINISTRADOR As Integer = 1
    Private Const USUARI_SUPER_ADMINISTRADOR As Integer = 2
    Private Sub setLanguage()
        Me.MnuConfigSubgrupsGB.Text = IDIOMA.getString("mnuConfigSubgrupsGB")
        Me.mnuConfigMan.Text = IDIOMA.getString("mnuConfigMan")
        Me.mnuConfigGB.Text = IDIOMA.getString("mnuConfigGB")
        Me.mnuConfigCentresMan.Text = IDIOMA.getString("mnuConfigCentresMan")
        Me.mnuConfigMesMan.Text = IDIOMA.getString("mnuConfigMesMan")
        Me.mnuConfigMesGb.Text = IDIOMA.getString("mnuConfigMesGb")
        Me.mnuActualitzarPlantillaMan.Text = IDIOMA.getString("mnuConfigPlantillaMan")
        Me.mnuActualitzarPlantillaGB.Text = IDIOMA.getString("mnuActualitzarPlantillaGB")
        Me.MnuTresoreria.Text = IDIOMA.getString("mnuTresoreria")
        Me.mnuConfigTresoreria.Text = IDIOMA.getString("mnuConfig_Caption")
        Me.mnuImportTresoreria.Text = IDIOMA.getString("mnuImportar")
        Me.mnuExportTresoreria.Text = IDIOMA.getString("mnuExportar")
        Me.mnuEditarTresoreria.Text = IDIOMA.getString("mnuEditar")
        Me.mnuUsuaris.Text = IDIOMA.getString("usuaris")
        Me.mnuUsuariExplotacions.Text = IDIOMA.getString("usuariExplotacions")
        Me.mnuUsuariAdministrador.Text = IDIOMA.getString("usuariAdministrador")
        Me.mnuUsuariSuper.Text = IDIOMA.getString("usuariSuperAdministrador")
        Me.MnuConfigDepartaments.Text = IDIOMA.getString("menuCaptionDepartaments")
        Me.MnuConfigProjectesClient.Text = IDIOMA.getString("mnuConfigClients")
        Me.MnuConfigProjectesExpram.Text = IDIOMA.getString("projectesExpram")
        Me.MnuConfigCentres.Text = IDIOMA.getString("centres")
        Me.MnuConfigProjecte.Text = IDIOMA.getString("projectes")
        Me.MnuConfig.Text = IDIOMA.getString("mnuConfig_Caption")
        Me.MnuConfigEmpreses.Text = IDIOMA.getString("mnuConfigEmpreses_Caption")
        Me.MnuConfigProjectes.Text = IDIOMA.getString("mnuConfigProjectes_Caption")
        Me.MnuConfigServer.Text = IDIOMA.getString("mnuConfigServer_Caption")
        Me.MnuConfigServerConnect.Text = IDIOMA.getString("mnuConfigServerConnect_Caption")
        Me.MnuConfigServerContaplus.Text = IDIOMA.getString("mnuConfigServerContaplus_Caption")
        Me.MnuConfigServerDirectori.Text = IDIOMA.getString("mnuConfigServerDirectori_Caption")
        Me.MnuConfigSubctes.Text = IDIOMA.getString("mnuConfigSubctes_Caption")
        Me.mnuActualitzarDiarios.Text = IDIOMA.getString("mnuActualitzarDiarioCaption")
        Me.MnuActualitzar.Text = IDIOMA.getString("actualitzar")
        Me.mnuActualitzarDB.Text = IDIOMA.getString("mnuCopyDB")
        Me.mnuEstatMesos.Text = IDIOMA.getString("mnuEstatMesos")
        Me.mnuResetDades.Text = IDIOMA.getString("mnuResetDades")
        Me.mnuEsborrar.Text = IDIOMA.getString("mnuEsborrar")
        Me.mnuExportar.Text = IDIOMA.getString("mnuExportar")
        Me.mnuVeureDades.Text = IDIOMA.getString("mnuVeure")
        Me.mnuEsborrarBudget.Text = IDIOMA.getString("budgets")
        Me.mnuEsborrarBudgetCentres.Text = IDIOMA.getString("perCentres")
        Me.mnuEsborrarBudgetProjectes.Text = IDIOMA.getString("perProjectes")
        Me.mnuEsborrarDetall.Text = IDIOMA.getString("detalls")
        Me.mnuEsborrarTransitoria.Text = IDIOMA.getString("transitories")
        Me.mnuExportarAGb.Text = IDIOMA.getString("aGb")
        Me.mnuExportAMan.Text = IDIOMA.getString("aMan")
        Me.mnuExportarCanviarDataGB.Text = IDIOMA.getString("dataGb")
        Me.mnuExportarCanviarDataMan.Text = IDIOMA.getString("dataMan")
        Me.mnuExportarGBPretancament.Text = IDIOMA.getString("exportPreTancamentGb")
        Me.mnuExportarGBTancament.Text = IDIOMA.getString("exportTancamentGb")
        Me.mnuExportarManTancament.Text = IDIOMA.getString("exportTancamentMan")
        Me.mnuTransitories.Text = IDIOMA.getString("mnuTransitories")
        Me.mnuPlantillaFitxers.Text = IDIOMA.getString("mnuPlantillaFitxersTransitoria")
        Me.mnuConfigTransitories.Text = IDIOMA.getString("mnuConfig_Caption")
        Me.mnuImportarTransitories.Text = IDIOMA.getString("mnuImportTransitories")
        Me.mnuExportarTransitories.Text = IDIOMA.getString("mnuExportTransitories")
        Me.mnuAssentamentTransitories.Text = IDIOMA.getString("mnuAssentamentTransitoria")
        Me.mnuClientsTransitories.Text = IDIOMA.getString("mnuConfigClients")
        Me.MnuConfigProjectesClient.Text = IDIOMA.getString("mnuConfigClients")
        Me.mnuPlantillaTransitories.Text = IDIOMA.getString("mnuPlantillaTransitoria")
        Me.mnuYellowTransitories.Text = IDIOMA.getString("mnuYellowSheets")
        Me.mnuLlibreMajor.Text = IDIOMA.getString("mnuAnaliticLlibreMajor")
        Me.mnuCrearLlibreMajor.Text = IDIOMA.getString("mnuCrearLlibreMajor")
        Me.mnuConfiguracioLlibreMajor.Text = IDIOMA.getString("mnuConfig_Caption")
        Me.mnuConfigDepartamentsLLibreMajor.Text = IDIOMA.getString("menuCaptionDepartaments")
        Me.mnuConfigPrefixesLlibreMajor.Text = IDIOMA.getString("menuCaptionPrefixSubcomptes")
        Me.MnuConfigSubcompte.Text = IDIOMA.getString("subcomptes")
        Me.MnuGrupsSubgrups.Text = IDIOMA.getString("grupsComptables")
        Me.MnuConfigPrefixSubcompte.Text = IDIOMA.getString("menuCaptionPrefixSubcomptes")
        Me.mnuUtes.Text = IDIOMA.getString("mnuUte")
        Me.mnuImportAndorra.Text = IDIOMA.getString("mnuImportAndorra")
        Me.mnuImportZamora.Text = IDIOMA.getString("mnuImportZamora")
        Me.mnuBudget.Text = IDIOMA.getString("budget")
        Me.mnuBudgetConfiguracio.Text = IDIOMA.getString("mnuConfiguracio")
        Me.mnuBudgetConfigVossCentres.Text = IDIOMA.getString("mnuBudgetConfigVossCentres")
        Me.mnuBudgetConfigCentresFullesGb.Text = IDIOMA.getString("mnuBudgetConfigCentresFullesGb")
        Me.mnuBudgetConfigParametres.Text = IDIOMA.getString("mnuParametres")
        Me.mnuBudgetConfigFitxerVoss.Text = IDIOMA.getString("mnuBudgetConfigFitxerVoss")
        Me.mnuBudgetImportar.Text = IDIOMA.getString("mnuImportar")
        Me.mnuBudgetImportarExplotacions.Text = IDIOMA.getString("mnuExplotacions")
        Me.mnuBudgetImportarCesmed.Text = IDIOMA.getString("mnuBudgetImportarCesmed")
        Me.mnuBudgetImportarGB.Text = IDIOMA.getString("mnuBudgetImportarGB")
        Me.mnuBudgetImportarHead.Text = IDIOMA.getString("mnuBudgetImportarHead")
        Me.mnuBudgetImportarObres.Text = IDIOMA.getString("mnuBudgetImportarObres")
        Me.mnuBudgetExportar.Text = IDIOMA.getString("mnuExportar")
        Me.mnuBudgetExportarGB.Text = IDIOMA.getString("mnuBudgetExportarGB")
        Me.mnuBudgetExportarMan.Text = IDIOMA.getString("mnuBudgetExportarMan")
        Me.mnuBudgetExportarVoss.Text = IDIOMA.getString("mnuBudgetExportarVoss")
        Me.mnuAxiliars.Text = IDIOMA.getString("mnuAxiliars")
        Me.mnuPaisos.Text = IDIOMA.getString("paisos")
        Me.mnuProvincies.Text = IDIOMA.getString("provincies")
        Me.mnuTipusPagament.Text = IDIOMA.getString("tipusPagament")
        Me.mnuTipusIva.Text = IDIOMA.getString("tipusIva")
        Me.mnuProveidors.Text = IDIOMA.getString("proveidors")
        Me.mnuContactesProjecte.Text = IDIOMA.getString("projectes")
        Me.mnuFabricants.Text = IDIOMA.getString("fabricants")
        Me.mnufamilies.Text = IDIOMA.getString("families")
        Me.mnuUnitats.Text = IDIOMA.getString("unitats")
        Me.mnuArticles.Text = IDIOMA.getString("articles")
    End Sub
    Friend Sub setData()
        '1 cal saber l'estat del servidor.
        '//caldrà veure que es fa amb sqlserver.
        If CONFIG.folderExist(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES)) Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.ES_LOCAL, False)
            Me.lblEstat.Text = IDIOMA.getString("modeServidor")
            Me.lblEstat.ForeColor = Color.Blue
            Me.lblEstat.BackColor = Color.White
        Else
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.ES_LOCAL, True)
            Me.lblEstat.Text = IDIOMA.getString("modeLocal")
            Me.lblEstat.ForeColor = Color.Red

            Me.lblEstat.BackColor = Color.Black
        End If
    End Sub

    Private Sub FrmApliOms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateUser()

        Call setLanguage()
        Call setData()
    End Sub

    Private Sub MnuConfigServerConnect_Click(sender As Object, e As EventArgs) Handles MnuConfigServerConnect.Click
        Dim fr As New frmServer
        fr.ShowDialog()
        fr.Dispose()
        fr = Nothing
    End Sub

    Private Sub MnuConfigProjecte_Click(sender As Object, e As EventArgs) Handles MnuConfigProjecte.Click
        Dim p As SelectProjectes
        panelData.Controls.Clear()
        p = New SelectProjectes(1, False, False, IDIOMA.getString("projectes"))
        Call setPanel(p)

    End Sub

    Private Sub MnuConfigSubcompte_Click(sender As Object, e As EventArgs) Handles MnuConfigSubcompte.Click
        Dim p As SelectSubcomptes
        panelData.Controls.Clear()
        p = New SelectSubcomptes(1, False, False, IDIOMA.getString("subcomptes"), 1)
        Call setPanel(p)
    End Sub
    Public Sub resetPanel()
        panelData.Controls.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(Me.Size.Width, 140)
    End Sub
    Private Sub setPanel(p As Object)
        p.Dock = DockStyle.Fill
        panelData.Controls.Add(p)
        p.Show()
        Me.WindowState = FormWindowState.Maximized
        Me.Activate()
    End Sub

    Private Sub MnuConfigEmpreses_Click(sender As Object, e As EventArgs) Handles MnuConfigEmpreses.Click
        Dim p As SelectEmpreses
        panelData.Controls.Clear()
        Call DBCONNECT.getConnection()
        p = New SelectEmpreses(1, False, False, IDIOMA.getString("empreses"))
        Call setPanel(p)

    End Sub

    Private Sub MnuConfigPrefixSubcompte_Click(sender As Object, e As EventArgs) Handles MnuConfigPrefixSubcompte.Click
        Call setPrefixosSubcomptes()
    End Sub
    Private Sub setPrefixosSubcomptes()
        Dim p As SelectPrefixSubcompte
        panelData.Controls.Clear()
        p = New SelectPrefixSubcompte(1, False, False, IDIOMA.getString("menuCaptionPrefixSubcomptes"))
        Call setPanel(p)
    End Sub
    Private Sub MnuGrupsSubgrups_Click(sender As Object, e As EventArgs) Handles MnuGrupsSubgrups.Click
        Dim p As grupsSubgrupsSubcomptes
        panelData.Controls.Clear()
        p = New grupsSubgrupsSubcomptes()
        Call setPanel(p)
    End Sub

    Private Sub MnuConfigCentres_Click(sender As Object, e As EventArgs) Handles MnuConfigCentres.Click
        Dim p As empresesSeccionsCentres
        panelData.Controls.Clear()
        p = New empresesSeccionsCentres()
        Call setPanel(p)
    End Sub

    Private Sub MnuConfigProjectesExpram_Click(sender As Object, e As EventArgs) Handles MnuConfigProjectesExpram.Click
        Dim p As projectesColumnes
        panelData.Controls.Clear()
        p = New projectesColumnes()
        Call setPanel(p)
    End Sub

    Private Sub MnuConfigProjectesClient_Click(sender As Object, e As EventArgs) Handles MnuConfigProjectesClient.Click
        Dim p As PanelProjecteClients
        panelData.Controls.Clear()
        p = New PanelProjecteClients()
        Call setPanel(p)
    End Sub

    Private Sub MnuConfigDepartaments_Click(sender As Object, e As EventArgs) Handles MnuConfigDepartaments.Click
        Call setDepartaments()
    End Sub
    Private Sub setDepartaments()
        Dim p As SelectDepartament
        panelData.Controls.Clear()
        p = New SelectDepartament(1, False, False, IDIOMA.getString("menuCaptionDepartaments"))
        Call setPanel(p)
    End Sub
    Private Sub MnuConfigServerDirectori_Click(sender As Object, e As EventArgs) Handles MnuConfigServerDirectori.Click
        Dim f As New dRutaServidorDades, ruta As String
        ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES), IDIOMA.getString("configRutaServidorDades"))
        f.Dispose()
        If CONFIG.folderExist(ruta) Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES, ruta)
        End If
        Call setData()
        f = Nothing
    End Sub

    Private Sub MnuConfigServerContaplus_Click(sender As Object, e As EventArgs) Handles MnuConfigServerContaplus.Click
        Dim f As New dRutaServidorDades, ruta As String
        ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_CONTAPLUS), IDIOMA.getString("configRutaContaplus"))
        f.Dispose()
        If CONFIG.folderExist(ruta) Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_CONTAPLUS, ruta)
        End If
        f = Nothing
    End Sub

    Private Sub mnuActualitzarDiarios_Click(sender As Object, e As EventArgs) Handles mnuActualitzarDiarios.Click
        Dim d As DDiarioContaplus
        d = New DDiarioContaplus()
        d.ShowDialog()
        d.Dispose()
        d = Nothing
    End Sub

    Private Sub mnuActualitzarDB_Click(sender As Object, e As EventArgs) Handles mnuActualitzarDB.Click
        Call CopyDB.copy()
    End Sub

    Private Sub mnuEstatMesos_Click(sender As Object, e As EventArgs) Handles mnuEstatMesos.Click
        Dim p As PanelEstatMesos
        panelData.Controls.Clear()
        p = New PanelEstatMesos()
        Call setPanel(p)
    End Sub

    Private Sub mnuResetDades_Click(sender As Object, e As EventArgs) Handles mnuResetDades.Click
        Call CONFIG.resetDades()
    End Sub

    Private Sub mnuVeureDades_Click(sender As Object, e As EventArgs) Handles mnuVeureDades.Click
        Dim t As ToolStripMenuItem, emp As Empresa, c As Contaplus, t1 As ToolStripMenuItem
        mnuVeureDades.DropDownItems.Clear()
        Try
            For Each emp In ModelEmpresa.getObjects
                t = New ToolStripMenuItem(emp.nom)
                mnuVeureDades.DropDownItems.Add(t)
                For Each c In emp.empresesContaplus
                    t1 = New ToolStripMenuItem(c.anyo)
                    t1.Name = c.idEmpresa
                    AddHandler t1.Click, AddressOf testMessage
                    t.DropDownItems.Add(t1)
                Next
            Next
            'Call DBCONNECT.close()
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
        End Try
        t = Nothing
        t1 = Nothing
        emp = Nothing
        c = Nothing
    End Sub
    Private Sub testMessage(sender As Object, e As EventArgs)
        Dim emp As Empresa, c As Contaplus, p As panelData
        emp = ModelEmpresa.getObject(CInt(sender.name))
        c = ModelEmpresaContaplus.getObjectByEmpresaAny(sender.name, CInt(sender.text))
        panelData.Controls.Clear()
        p = New panelData(emp, c)
        Call setPanel(p)
    End Sub
    Public Sub setDataContaplus(e As Empresa, c As Contaplus)
        Dim p As panelData
        panelData.Controls.Clear()
        p = New panelData(e, c)
        Call setPanel(p)
    End Sub
    Public Sub setDataContaplus(e As Empresa, c As Contaplus, m As Integer)
        Dim p As panelData
        panelData.Controls.Clear()
        p = New panelData(e, c, m)
        Call setPanel(p)
    End Sub
    Public Sub setDataInforme(e As Empresa, c As Contaplus, m As Integer, tipusInforme As String)
        Dim p As panelData
        panelData.Controls.Clear()
        p = New panelData(e, c, m, tipusInforme)
        Call setPanel(p)
    End Sub
    Private Sub mnuEsborrarTransitoria_Click(sender As Object, e As EventArgs) Handles mnuEsborrarTransitoria.Click
        Call ModelTransitoria.ClearDataTransitoria()
    End Sub

    Private Sub mnuEsborrarDetall_Click(sender As Object, e As EventArgs) Handles mnuEsborrarDetall.Click
        Call ModulActualitzacioGB.ClearDataDetalls()
    End Sub

    Private Sub mnuExportarGBPretancament_Click(sender As Object, e As EventArgs) Handles mnuExportarGBPretancament.Click
        ModulActualitzacioGB.exportData(True)
    End Sub

    Private Sub mnuExportarGBTancament_Click(sender As Object, e As EventArgs) Handles mnuExportarGBTancament.Click
        ModulActualitzacioGB.exportData(False)
    End Sub

    Private Sub mnuClientsTransitories_Click(sender As Object, e As EventArgs) Handles mnuClientsTransitories.Click
        Dim p As PanelProjecteClients
        panelData.Controls.Clear()
        p = New PanelProjecteClients()
        Call setPanel(p)
    End Sub

    Private Sub mnuImportarTransitories_Click(sender As Object, e As EventArgs) Handles mnuImportarTransitories.Click
        Call ModulImportTransitoria.execute()
    End Sub
    Private Sub mnuPlantillaTransitories_Click(sender As Object, e As EventArgs) Handles mnuPlantillaTransitories.Click
        Dim p As pPlantillaTransitoria
        p = New pPlantillaTransitoria
        panelData.Controls.Clear()
        Call setPanel(p)
    End Sub

    Private Sub mnuEsborrar_Click(sender As Object, e As EventArgs) Handles mnuEsborrar.Click

    End Sub

    Private Sub mnuExportarTransitories_Click(sender As Object, e As EventArgs) Handles mnuExportarTransitories.Click
        Call ModulExportTransitoria.execute()
    End Sub

    Private Sub mnuYellowTransitories_Click(sender As Object, e As EventArgs) Handles mnuYellowTransitories.Click
        Dim p As SelectYSheets
        panelData.Controls.Clear()
        p = New SelectYSheets(1, False, False, IDIOMA.getString("ySheets"), 1)
        Call setPanel(p)
    End Sub

    Private Sub mnuAssentamentTransitories_Click(sender As Object, e As EventArgs) Handles mnuAssentamentTransitories.Click
        If ModelAssentamentTransitoria.execute Then
            Call mnuEstatMesos_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub mnuConfigDepartamentsLLibreMajor_Click(sender As Object, e As EventArgs) Handles mnuConfigDepartamentsLLibreMajor.Click
        Call setDepartaments()
    End Sub

    Private Sub mnuConfigPrefixesLlibreMajor_Click(sender As Object, e As EventArgs) Handles mnuConfigPrefixesLlibreMajor.Click
        Call setPrefixosSubcomptes()
    End Sub

    Private Sub mnuInformes_Click(sender As Object, e As EventArgs)
        MsgBox(Calendari.getDate(, "EN"))
    End Sub

    Private Sub mnuCrearLlibreMajor_Click(sender As Object, e As EventArgs) Handles mnuCrearLlibreMajor.Click
        Call ModulExportarDepartaments.execute()
    End Sub
    Private Sub FrmApliOms_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call DBCONNECT.close()
    End Sub
    Private Sub validateUser()
        Dim usuariActual As Integer, estat As Boolean
        usuariActual = Val(CONFIG_FILE.getTag(CONFIG_FILE.TAG.TIPUS_USUARI))
        If usuariActual = USUARI_EXPLOTACIONS Then
            Me.lblUsuari.Text = IDIOMA.getString("usuariExplotacions")
            Me.mnuExportarGBPretancament.Enabled = True
            estat = False
        ElseIf usuariActual = USUARI_ADMINISTRADOR Then
            Me.lblUsuari.Text = IDIOMA.getString("usuariAdministrador")
            Me.mnuExportarGBPretancament.Enabled = False
            estat = True
        Else
            Me.lblUsuari.Text = IDIOMA.getString("usuariSuperAdministrador")
            Me.mnuExportarGBPretancament.Enabled = True
        End If
        Me.MnuConfigProjectesExpram.Enabled = estat
        Me.MnuConfigCentres.Enabled = estat
        Me.MnuConfigProjecte.Enabled = estat
        Me.MnuConfigEmpreses.Enabled = estat
        Me.MnuConfigProjectes.Enabled = estat
        Me.MnuConfigServerContaplus.Enabled = estat
        Me.MnuConfigSubctes.Enabled = estat
        Me.mnuActualitzarDiarios.Enabled = estat
        Me.mnuEstatMesos.Enabled = estat
        Me.mnuEsborrarBudget.Enabled = estat
        Me.mnuEsborrarDetall.Enabled = estat
        Me.mnuExportAMan.Enabled = estat
        Me.mnuExportarCanviarDataMan.Enabled = estat
        Me.mnuExportarGBTancament.Enabled = estat
        Me.MnuConfigSubcompte.Enabled = estat
        Me.MnuGrupsSubgrups.Enabled = estat
        Me.MnuConfigPrefixSubcompte.Enabled = estat
        Me.mnuConfigTresoreria.Enabled = estat
        Me.mnuExportAMan.Enabled = estat

        Call resetPanel()
    End Sub

    Private Sub mnuUsuariExplotacions_Click(sender As Object, e As EventArgs) Handles mnuUsuariExplotacions.Click
        Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.TIPUS_USUARI, USUARI_EXPLOTACIONS)
        Call validateUser()
        Call MISSATGES.NEW_USER(USUARI_EXPLOTACIONS)
    End Sub

    Private Sub mnuUsuariAdministrador_Click(sender As Object, e As EventArgs) Handles mnuUsuariAdministrador.Click
        Dim p As dPassword
        p = New dPassword
        p.ShowDialog()
        If p.DialogResult = DialogResult.OK Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.TIPUS_USUARI, USUARI_ADMINISTRADOR)
            Call validateUser()
            Call MISSATGES.NEW_USER(USUARI_ADMINISTRADOR)
        ElseIf p.DialogResult = DialogResult.Abort Then
            Call ERRORS.ERR_PASSWORD()
        End If
        p.Dispose()
        p = Nothing
    End Sub

    Private Sub mnuUsuariSuper_Click(sender As Object, e As EventArgs) Handles mnuUsuariSuper.Click
        Dim p As dPassword
        p = New dPassword
        p.ShowDialog()
        If p.DialogResult = DialogResult.OK Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.TIPUS_USUARI, USUARI_SUPER_ADMINISTRADOR)
            Call validateUser()
            Call MISSATGES.NEW_USER(USUARI_SUPER_ADMINISTRADOR)
        ElseIf p.DialogResult = DialogResult.Abort Then
            Call ERRORS.ERR_PASSWORD()
        End If
        p.Dispose()
        p = Nothing
    End Sub

    Private Sub mnuPlantillaFitxers_Click(sender As Object, e As EventArgs) Handles mnuPlantillaFitxers.Click
        Dim p As pPlantillaTransitoriaProjecte
        p = New pPlantillaTransitoriaProjecte
        panelData.Controls.Clear()
        Call setPanel(p)
    End Sub
    Public Sub setLog(l As Log)
        Dim p As panelLog
        p = New panelLog(l)
        Call resetPanel()
        Call setPanel(p)
    End Sub

    Private Sub mnuActualitzarPlantillaGB_Click(sender As Object, e As EventArgs) Handles mnuActualitzarPlantillaGB.Click
        Call ModulActualitzacioGB.crearPlantilla()
    End Sub

    Private Sub mnuConfigMesGb_Click(sender As Object, e As EventArgs) Handles mnuConfigMesGb.Click
        Call ModulActualitzacioGB.actualitzarMes()
    End Sub

    Private Sub mnuConfigCentresMan_Click(sender As Object, e As EventArgs) Handles mnuConfigCentresMan.Click
        Call ModulActualitzacioMan.execute()
    End Sub

    Private Sub mnuActualitzarPlantillaMan_Click(sender As Object, e As EventArgs) Handles mnuActualitzarPlantillaMan.Click

    End Sub

    Private Sub mnuConfigMesMan_Click(sender As Object, e As EventArgs) Handles mnuConfigMesMan.Click
        Call ModulActualitzacioMan.actualitzarMes()
    End Sub

    Private Sub mnuImportAndorra_Click(sender As Object, e As EventArgs) Handles mnuImportAndorra.Click
        Call ModulImportAndorra.execute()
    End Sub

    Private Sub mnuImportZamora_Click(sender As Object, e As EventArgs) Handles mnuImportZamora.Click
        Call ModulImportZamora.execute()
    End Sub

    Private Sub ProvaGBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProvaGBToolStripMenuItem.Click
        Dim p As DSubGrupGB, sggb As SubGrupGB
        p = New DSubGrupGB
        sggb = p.getsubgrup(New SubGrupGB(1, "p", "prova", ""))


    End Sub

    Private Sub MnuConfigSubgrupsGB_Click(sender As Object, e As EventArgs) Handles MnuConfigSubgrupsGB.Click
        Dim p As PanelSubgrupsGB
        panelData.Controls.Clear()
        p = New PanelSubgrupsGB()
        Call setPanel(p)
    End Sub

    Private Sub mnuExportarManTancament_Click(sender As Object, e As EventArgs) Handles mnuExportarManTancament.Click
        ModulActualitzacioGB.exportData(False, True)
    End Sub

    Private Sub MnuObresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuBudgetImportarObres.Click

    End Sub

    Private Sub mnuBudgetConfigParametres_Click(sender As Object, e As EventArgs) Handles mnuBudgetConfigParametres.Click
        Dim p As DParametresBudget
        p = New DParametresBudget
        p.ShowDialog()
        p = Nothing
    End Sub

    Private Sub mnuBudgetImportarExplotacions_Click(sender As Object, e As EventArgs) Handles mnuBudgetImportarExplotacions.Click
        Call ModulImportBudget.execute()
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

    Private Sub mnuTipusPagament_Click(sender As Object, e As EventArgs) Handles mnuTipusPagament.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setTipusPagament()
        p = Nothing
    End Sub

    Private Sub mnuTipusIva_Click(sender As Object, e As EventArgs) Handles mnuTipusIva.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setTipusIva()
        p = Nothing
    End Sub

    Private Sub mnuProveidors_Click(sender As Object, e As EventArgs) Handles mnuProveidors.Click
        Dim p As pProveidors
        panelData.Controls.Clear()
        p = New pProveidors()
        Call setPanel(p)
    End Sub

    Private Sub mnuContactesProjecte_Click(sender As Object, e As EventArgs) Handles mnuContactesProjecte.Click
        Dim p As pProjectesContactes
        panelData.Controls.Clear()
        p = New pProjectesContactes()
        Call setPanel(p)
    End Sub

    Private Sub mnuFabricants_Click(sender As Object, e As EventArgs) Handles mnuFabricants.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setFabricants()
        p = Nothing
    End Sub

    Private Sub mnuUnitats_Click(sender As Object, e As EventArgs) Handles mnuUnitats.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setUnitats()
        p = Nothing
    End Sub
    Private Sub mnuFamilies_Click(sender As Object, e As EventArgs) Handles mnufamilies.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setFamilies()
        p = Nothing
    End Sub
    Private Sub mnuArticles_Click(sender As Object, e As EventArgs) Handles mnuArticles.Click
        Dim p As pArticles
        panelData.Controls.Clear()
        p = New pArticles()
        Call setPanel(p)
    End Sub

    Private Sub ComandesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComandesToolStripMenuItem.Click
        Dim p As pComanda
        panelData.Controls.Clear()
        p = New pComanda()
        Call setPanel(p)
    End Sub

    Private Sub ContactesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContactesToolStripMenuItem.Click
        Dim p As pContactes
        panelData.Controls.Clear()
        p = New pContactes()
        Call setPanel(p)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim p As pLlocEntrega
        panelData.Controls.Clear()
        p = New pLlocEntrega()
        Call setPanel(p)
    End Sub

    Private Sub FrmApliOms_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub FrmApliOms_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
End Class