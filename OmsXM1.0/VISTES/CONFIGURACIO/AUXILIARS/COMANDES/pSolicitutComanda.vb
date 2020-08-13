﻿Public Class pSolicitutComanda
    Private solicitudActual As SolicitudComanda
    Private listProveidors As lstProveidor
    Private listContactesproveidor As lstContactesProveidor
    Private listLlocsEntrega As lstLlocsEntrega
    Private listContactesEntrega As lstContactes
    Private panelDataComanda As SelectDia
    Private panelDataEntregaEquips As SelectDia
    Private PanelDataMuntatgeEquips As SelectDia
    Private contacteProveidorActual As ProveidorCont
    Private proveidorActual As Proveidor
    Private empresaActual As Empresa
    Private projecteActual As Projecte
    Private llocEntregaActual As LlocEntrega
    Private contacteActual As Contacte
    Private actualitzar As Boolean
    Friend Event removeItem(c As SolicitudComanda)
    Public Sub New(pSolicitut As SolicitudComanda)
        InitializeComponent()
        solicitudActual = pSolicitut
        Call inicialitzarObjects()
        Call setLanguage()
        Call setEmpreses()
        Call setProveidors()
        Call setContactesProveidor()
        Call setComanda()

    End Sub
    Private Sub inicialitzarObjects()
        empresaActual = ModelEmpresa.getObject(solicitudActual.empresa)
        projecteActual = ModelProjecte.getObject(solicitudActual.codiProjecte)
        proveidorActual = ModelProveidor.getObjectByStrings(solicitudActual.idProveidor, solicitudActual.proveidor)
        contacteProveidorActual = proveidorActual.getContacte(solicitudActual.contacteProveidor)
        llocEntregaActual = ModelLlocEntrega.getObjectByName(solicitudActual.llocEntrega)
        contacteActual = ModelContacte.getObject(solicitudActual.telefonEntrega)
    End Sub
    Private Sub setLanguage()
        Me.lblAlcancePedido.Text = IDIOMA.getString("disposicioSolicitutComanda")
        Me.lblAltres.Text = IDIOMA.getString("altres")
        Me.lblComparatiu.Text = IDIOMA.getString("comparatiu")
        Me.lblContacte.Text = IDIOMA.getString("Contacte")
        Me.lblContacteProveidorTitol.Text = IDIOMA.getString("contacte")
        Me.lblDataComanda.Text = IDIOMA.getString("dataSolicitut")
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblEntrega.Text = IDIOMA.getString("llocEntrega")
        Me.lblEntregaEquips.Text = IDIOMA.getString("dataEntregaEquips")
        Me.lblEntregaMuntatge.Text = IDIOMA.getString("dataMuntatge")
        Me.lblMagatzem.Text = IDIOMA.getString("magatzem")
        Me.lblOferta1.Text = IDIOMA.getString("oferta") & " 1"
        Me.lblOferta2.Text = IDIOMA.getString("oferta") & " 2"
        Me.lblOferta3.Text = IDIOMA.getString("oferta") & " 3"
        Me.lblProjecte.Text = IDIOMA.getString("projecte")
        Me.lblProveidor.Text = IDIOMA.getString("proveidor")
        Me.lblTitolSolicitud.Text = IDIOMA.getString("solicitutComanda")
        Me.lblTotalCaption.Text = IDIOMA.getString("total")
        Me.xecAltres.Text = IDIOMA.getString("altres")
        Me.xecEmbalatge.Text = IDIOMA.getString("embalatge")
        Me.xecMuntatgeObra.Text = IDIOMA.getString("muntatgeObra")
        Me.xecPostaMarxa.Text = IDIOMA.getString("postaServei")
        Me.xecPostaPunt.Text = IDIOMA.getString("postaPunt")

        Me.xecProvesObra.Text = IDIOMA.getString("provesObra")
        Me.xecProvesTaller.Text = IDIOMA.getString("provesTaller")
        Me.xecSuministre.Text = IDIOMA.getString("suministre")
        Me.xecSupervisioMuntatge.Text = IDIOMA.getString("supervisioMuntatge")
        Me.xecTransport.Text = IDIOMA.getString("transportSeguros")
        Me.optExplotacions.Text = IDIOMA.getString("explotacions")
        Me.optGeneric.Text = IDIOMA.getString("generic")
        Me.optObres.Text = IDIOMA.getString("obres")


    End Sub
    Private Sub setEmpreses()
        actualitzar = False
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)

        actualitzar = True
        If empresaActual IsNot Nothing Then Me.cbEmpresa.SelectedItem = empresaActual
    End Sub
    Private Sub setProjectes()
        cbProjecte.Items.Clear()
        cbProjecte.Items.AddRange(ModelProjecte.getListObjects(empresaActual.id))
        If Not projecteActual Is Nothing Then cbProjecte.SelectedItem = projecteActual
    End Sub
    Private Sub setProveidors()
        If Not IsNothing(proveidorActual) Then
            listProveidors = New lstProveidor(proveidorActual)
        Else
            listProveidors = New lstProveidor(New Proveidor)
        End If
        AddHandler listProveidors.selectObject, AddressOf setProveidor
        pProveidor.Controls.Clear()
        listProveidors.Dock = DockStyle.Fill
        pProveidor.Controls.Add(listProveidors)
        listProveidors.cb.Select()
    End Sub
    Private Sub setContactesProveidor()
        If Not IsNothing(contacteProveidorActual) Then
            listContactesproveidor = New lstContactesProveidor(contacteProveidorActual, proveidorActual.id)
        Else
            listContactesproveidor = New lstContactesProveidor(New ProveidorCont, proveidorActual.id)
        End If
        AddHandler listContactesproveidor.selectObject, AddressOf setContacteProveidor
    End Sub
    Private Sub setComanda()
        Me.xecAltres.Checked = solicitudActual.altresAlcans
        Me.xecEmbalatge.Checked = solicitudActual.embalatge
        Me.xecMuntatgeObra.Checked = solicitudActual.muntatge
        Me.xecPostaMarxa.Checked = solicitudActual.postaServei
        Me.xecPostaPunt.Checked = solicitudActual.postaApunt
        Me.xecProvesObra.Checked = solicitudActual.provesObra
        Me.xecProvesTaller.Checked = solicitudActual.provesTaller
        Me.xecSuministre.Checked = solicitudActual.suministreMaterial
        Me.xecSupervisioMuntatge.Checked = solicitudActual.supervisio
        Me.xecTransport.Checked = solicitudActual.transport
        panelDataComanda = New SelectDia(solicitudActual.dataComanda, IDIOMA.getString("escollirData"))
        panelDataEntregaEquips = New SelectDia(solicitudActual.dataEntrega, IDIOMA.getString("escollirData"))
        PanelDataMuntatgeEquips = New SelectDia(solicitudActual.dataFinalitzacio, IDIOMA.getString("escollirData"))
        Call CONFIG.setPanel(Me.panelData, panelDataComanda)
        Call CONFIG.setPanel(Me.panelDataEquips, panelDataEntregaEquips)
        Call CONFIG.setPanel(Me.panelDataMuntatge, PanelDataMuntatgeEquips)
        Me.txtOferta1.Text = solicitudActual.oferta1
        Me.txtOferta2.Text = solicitudActual.oferta2
        Me.txtOferta3.Text = solicitudActual.oferta3
        Me.txtComparatiu.Text = solicitudActual.comparatiu
        Me.txtAltres.Text = solicitudActual.altresDocumentacio
    End Sub
    Private Sub validateControlsEmpresa()
        Dim pAvis As avis
        If empresaActual.codi = solicitudActual.empresa Then
            pAvis = New avis(True, IDIOMA.getString("okImport") & ". (" & solicitudActual.empresa & ")")
        Else
            pAvis = New avis(False, IDIOMA.getString("errImport") & ". (" & solicitudActual.empresa & ")")
        End If
        Call CONFIG.setPanel(pAvisEmpresa, pAvis)
        If projecteActual.codi = solicitudActual.codi Then
            pAvis = New avis(True, IDIOMA.getString("okImport") & ". (" & solicitudActual.codiProjecte & ")")
        Else
            pAvis = New avis(False, IDIOMA.getString("errImport") & ". (" & solicitudActual.codiProjecte & ")")
        End If
        Call CONFIG.setPanel(pAvisProjecte, pAvis)
        If InStr(1, solicitudActual.llocEntrega, llocEntregaActual.nom, CompareMethod.Text) > 0 Then
            pAvis = New avis(True, IDIOMA.getString("okImport") & ". (" & solicitudActual.llocEntrega & ")")
        Else
            pAvis = New avis(True, IDIOMA.getString("errImport") & ". (" & solicitudActual.llocEntrega & ")")
        End If
        Call CONFIG.setPanel(pAvisLlocEntrega, pAvis)
        If InStr(1, solicitudActual.contacteEntrega, contacteActual.nom, CompareMethod.Text) > 0 Or
        InStr(1, solicitudActual.telefonEntrega, contacteActual.telefon, CompareMethod.Text) > 0 Then
            pAvis = New avis(True, IDIOMA.getString("okImport") & ". (" & solicitudActual.contacteEntrega & ")")
        Else
            pAvis = New avis(True, IDIOMA.getString("errImport") & ". (" & solicitudActual.contacteEntrega & ")")
        End If
        Call CONFIG.setPanel(pAvisContacteEntrega, pAvis)
    End Sub
    Private Sub validateControlsProveidor()
        Dim pAvis As avis, c As ProveidorCont
        If proveidorActual.id = solicitudActual.idProveidor Then
            pAvis = New avis(True, IDIOMA.getString("okImport") & ". (" & solicitudActual.proveidor & ")")
        Else
            pAvis = New avis(False, IDIOMA.getString("errImport") & ". (" & solicitudActual.proveidor & ")")
        End If
        Call CONFIG.setPanel(pAvisProveidor, pAvis)
        c = proveidorActual.getContacte(solicitudActual.contacteProveidor)
        If Not IsNothing(c) Then
            pAvis = New avis(True, IDIOMA.getString("okImport") & ". (" & solicitudActual.contacteProveidor & ")")
        Else
            pAvis = New avis(False, IDIOMA.getString("errImport") & ". (" & solicitudActual.contacteProveidor & ")")
        End If
        Call CONFIG.setPanel(pAvisProjecte, pAvis)
    End Sub


    Private Sub setProveidor()
        actualitzar = False
        proveidorActual = listProveidors.obj
        If Not IsNothing(proveidorActual) Then
            If proveidorActual.isAnotacioActiva Then
                Call MISSATGES.ANOTACIONS_PROVEIDOR(proveidorActual.nom, proveidorActual.getAnotacionsActives)
            End If
            Me.lblDireccioProveidor.Text = proveidorActual.toTarget
            If contacteProveidorActual Is Nothing And proveidorActual.contactes.Count > 0 Then
                contacteProveidorActual = proveidorActual.contactes.Item(0)
            End If
            If contacteProveidorActual Is Nothing Then contacteProveidorActual = New ProveidorCont
            listContactesproveidor = New lstContactesProveidor(contacteActual, proveidorActual.id)
            AddHandler listContactesproveidor.selectObject, AddressOf setContacteProveidor
            Call CONFIG.setPanel(panelContacteProveidor, listContactesproveidor)
            actualitzar = True
            Call setContacteProveidor()
        Else
            contacteProveidorActual = Nothing
            listContactesproveidor = Nothing
            Me.PanelContacte.Controls.Clear()
            actualitzar = True
        End If

    End Sub


    Private Sub setContacteProveidor()
        contacteProveidorActual = listContactesproveidor.obj
        If Not IsNothing(contacteProveidorActual) Then
            lblContacteProveidor.Text = contacteProveidorActual.toTarget
        Else
            lblContacteProveidor.Text = ""
        End If
    End Sub

    ''' set data
    ''' 
    ''' </summary>
    Private Sub setEmpresa()
        actualitzar = False
        If Not IsNothing(empresaActual) Then
            cbProjecte.Items.Clear()
            cbProjecte.Items.AddRange(ModelProjecte.getListObjects(empresaActual.id))
            cbProjecte.SelectedItem = projecteActual
        Else
            cbProjecte.Items.Clear()
            cbProjecte.SelectedIndex = -1
        End If
        actualitzar = True
    End Sub
    Private Sub setProjecte()
        projecteActual.magatzems = ModelProjecteEntrega.getObjects(projecteActual.id)
        projecteActual.contactes = ModelProjecteContacte.getObjects(projecteActual.id)

        If llocEntregaActual IsNot Nothing Then If llocEntregaActual.id = -1 And projecteActual.magatzems.Count > 0 Then llocEntregaActual = ModelLlocEntrega.getObject(projecteActual.magatzems.Item(0).idEntrega)
        If llocEntregaActual Is Nothing Then llocEntregaActual = New LlocEntrega
        listLlocsEntrega = New lstLlocsEntrega(llocEntregaActual)
        If contacteActual IsNot Nothing Then If contacteActual.id = -1 And projecteActual.contactes.Count > 0 Then contacteActual = ModelContacte.getObject(projecteActual.contactes.Item(0).idContacte)
        listContactesEntrega = New lstContactes(contacteActual)
        AddHandler listContactesEntrega.selectObject, AddressOf setContacte
        AddHandler listLlocsEntrega.selectObject, AddressOf setLlocEntrega
        Call CONFIG.setPanel(panelMagatzem, listLlocsEntrega)
        Call CONFIG.setPanel(PanelContacte, listContactesEntrega)
        Call setLLocEntrega()
        Call setContacte()
    End Sub
    Private Sub setContacte()
        contacteActual = listContactesEntrega.obj
        If Not IsNothing(listContactesEntrega.obj) Then
            lblTelEmail.Text = contacteActual.toTarget
        Else
            lblTelEmail.Text = ""
        End If

    End Sub
    Private Sub setLLocEntrega()
        llocEntregaActual = listLlocsEntrega.obj
        If Not IsNothing(listLlocsEntrega.obj) Then
            lblDireccio.Text = llocEntregaActual.toTarget
        Else
            lblDireccio.Text = ""
        End If
    End Sub


    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If cbEmpresa.SelectedIndex > -1 Then
            empresaActual = cbEmpresa.SelectedItem
            Call setEmpresa()
        Else
            empresaActual = Nothing
            Call setEmpresa()
        End If
    End Sub


    Private Sub cbEmpresa_TextChanged(sender As Object, e As EventArgs) Handles cbEmpresa.TextChanged
        If actualitzar Then
            If cbEmpresa.Text = "" Then
                empresaActual = Nothing
                Call setEmpresa()
            End If
        End If
    End Sub

    Private Sub pSolicitutComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
