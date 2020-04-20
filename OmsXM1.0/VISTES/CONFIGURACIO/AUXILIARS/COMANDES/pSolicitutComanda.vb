Public Class pSolicitutComanda
    Private solicitudActual As SolicitudComanda
    Private listProveidors As lstProveidor
    Private listContactesproveidor As lstContactesProveidor
    Private listLlocsEntrega As lstLlocsEntrega
    Private listContactesEntrega As lstContactes
    Private contacteProveidorActual As ProveidorCont
    Private proveidorActual As Proveidor
    Private empresaActual As Empresa
    Private projecteActual As Projecte
    Private llocEntregaActual As LlocEntrega
    Private contacteActual As Contacte
    Private actualitzar As Boolean
    Public Sub New(pSolicitut As SolicitudComanda)
        InitializeComponent()
        solicitudActual = pSolicitut



        Call setEmpreses()
        Call setProveidors()
        Call setContactesProveidor()

    End Sub
    Private Sub inicialitzarObjects()
        empresaActual = ModelEmpresa.getObject(solicitudActual.empresa)
        projecteActual = ModelProjecte.getObject(solicitudActual.codiProjecte)
        proveidorActual = ModelProveidor.getObjectByStrings(solicitudActual.idProveidor, solicitudActual.proveidor)
        contacteProveidorActual = proveidorActual.getContacte(solicitudActual.contacteProveidor)
        llocEntregaActual = ModelLlocEntrega.getObjectByName(solicitudActual.llocEntrega)
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
    Private Sub setComanda()

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

    Private Sub setProveidors()
        If Not IsNothing(proveidorActual) Then
            listProveidors = New lstProveidor(proveidorActual)
        Else
            listProveidors = New lstProveidor(New Proveidor)
        End If
        AddHandler listProveidors.selectObject, AddressOf setProveidor
    End Sub
    Private Sub setContactesProveidor()
        If Not IsNothing(contacteProveidorActual) Then
            listContactesproveidor = New lstContactesProveidor(contacteProveidorActual, proveidorActual.id)
        Else
            listContactesproveidor = New lstContactesProveidor(New ProveidorCont, proveidorActual.id)
        End If
        AddHandler listContactesproveidor.selectObject, AddressOf setContacteProveidor
    End Sub
    Private Sub setLlocEntregues()

    End Sub
    Private Sub setContactesEntrega()

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
    Private Sub pSolicitutComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
End Class
