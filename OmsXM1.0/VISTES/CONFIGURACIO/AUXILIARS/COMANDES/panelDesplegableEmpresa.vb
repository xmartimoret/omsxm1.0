Public Class panelDesplegableEmpresa
    Private llargadaPanel As Integer
    Private textToolTip As String
    Private listLLocsEntrega As lstLlocsEntrega
    Private listContactes As lstContactes
    Private listProvincies As lstAuxiliars1
    Friend empresaActual As Empresa
    Friend projecteActual As Projecte
    Friend llocActual As LlocEntrega
    Friend contacteActual As Contacte
    Private llocActualTemp As LlocEntrega
    Private contacteActualTemp As Contacte
    Friend Event tempProveidor(p As Proveidor, c As ProveidorCont)
    Friend Event accioMostrar()
    Private actualitzar As Boolean
    Private elements As List(Of Control)
    Public Sub New()
        InitializeComponent()
        elements = getControls()
        Call setAccio()
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String)
        InitializeComponent()
        empresaActual = New Empresa
        elements = getControls()
        llargadaPanel = pHeight
        Button1.Text = "&" & pTecla
        listProvincies = New lstAuxiliars1(Nothing, DBCONNECT.getTaulaProvincia)
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pEmpresa As Empresa)
        InitializeComponent()
        elements = getControls()
        llargadaPanel = pHeight
        empresaActual = pEmpresa
        Button1.Text = "&" & pTecla
        listProvincies = New lstAuxiliars1(Nothing, DBCONNECT.getTaulaProvincia)

    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pEmpresa As Empresa, pProjecte As Projecte)
        InitializeComponent()
        llargadaPanel = pHeight
        empresaActual = pEmpresa
        projecteActual = pProjecte
        Button1.Text = "&" & pTecla
        listProvincies = New lstAuxiliars1(Nothing, DBCONNECT.getTaulaProvincia)

    End Sub

    Private Sub setLanguage()
        Me.lblContacte.Text = IDIOMA.getString("contacte") & ":"
        Me.lblDireccio.Text = IDIOMA.getString("direccio") & ":"
        Me.lblPoblacio.Text = IDIOMA.getString("poblacio") & ":"
        Me.lblEmpresa.Text = IDIOMA.getString("empresa") & ":"
        Me.lblProjecte.Text = IDIOMA.getString("projecte") & ":"
        Me.lblTelEmail.Text = IDIOMA.getString("telEmail") & ":"
        Me.lblContacte.Text = IDIOMA.getString("contacte") & ":"
        Me.lblMagatzem.Text = IDIOMA.getString("magatzem") & ":"
        Me.lblProvincia.Text = IDIOMA.getString("provincia") & ":"
        Me.lblResponsables.Text = IDIOMA.getString("responsables") & ":"
    End Sub
    Private Sub validateControls()

        If cbEmpresa.SelectedIndex = -1 Then
            cbProjecte.Enabled = False
            txtDireccio.Enabled = False
            txtPoblacio.Enabled = False
            txtCodiPostal.Enabled = False
            listProvincies.cb.Enabled = False
            txtEmail.Enabled = False
            txtDirector.Enabled = False
            txtResponsable.Enabled = False

        Else
            cbProjecte.Enabled = True
            txtDireccio.Enabled = True
            txtPoblacio.Enabled = True
            txtCodiPostal.Enabled = True
            listProvincies.cb.Enabled = True
            txtEmail.Enabled = True
            txtDirector.Enabled = True
            txtResponsable.Enabled = True
        End If
    End Sub
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
        Call validateControls()
    End Sub
    Private Sub setProjecte()
        projecteActual.magatzems = ModelProjecteEntrega.getObjects(projecteActual.id)
        projecteActual.contactes = ModelProjecteContacte.getObjects(projecteActual.id)
        If projecteActual.magatzems.Count > 0 Then
            listLLocsEntrega = New lstLlocsEntrega(ModelLlocEntrega.getObject(projecteActual.magatzems.Item(0).idEntrega))
        Else
            listLLocsEntrega = New lstLlocsEntrega(ModelLlocEntrega.getObject(Nothing))
        End If
        If projecteActual.contactes.Count > 0 Then
            listContactes = New lstContactes(ModelContacte.getObject(projecteActual.contactes.Item(0).idContacte))
        Else
            listContactes = New lstContactes(ModelContacte.getObject(Nothing))
        End If
        AddHandler listContactes.selectObject, AddressOf setContacte

        Me.panelMagatzem.Controls.Clear()
        listLLocsEntrega.Dock = DockStyle.Fill
        Me.panelMagatzem.Controls.Add(listLLocsEntrega)
        AddHandler listLLocsEntrega.selectObject, AddressOf setLlocEntrega
        Call setLlocEntrega()
        Me.PanelContacte.Controls.Clear()
        listContactes.Dock = DockStyle.Fill
        Me.PanelContacte.Controls.Add(listContactes)
        Call setContacte()
        Me.panelProvincia.Controls.Clear()
        listProvincies.Dock = DockStyle.Fill
        Me.panelProvincia.Controls.Add(listProvincies)
        txtResponsable.Text = projecteActual.responsable
        txtDirector.Text = projecteActual.director

        Call validateControls()
    End Sub
    Private Sub setLlocEntrega()
        llocActual = listLLocsEntrega.obj
        If Not IsNothing(listLLocsEntrega.obj) Then
            llocActualTemp = llocActual.copy
        Else
            llocActualTemp = Nothing
        End If
        If Not IsNothing(listLLocsEntrega.obj) Then Me.txtCodiPostal.Text = llocActualTemp.codiPostal
        If Not IsNothing(listLLocsEntrega.obj) Then Me.txtDireccio.Text = llocActualTemp.direccio
        If Not IsNothing(listLLocsEntrega.obj) Then Me.txtPoblacio.Text = llocActualTemp.poblacio
        If Not IsNothing(listLLocsEntrega.obj) Then listProvincies.cb.SelectedItem = llocActualTemp.provincia

    End Sub
    Private Sub setContacte()
        contacteActual = listContactes.obj
        If Not IsNothing(listContactes.obj) Then
            contacteActualTemp = contacteActual.copy
        Else
            contacteActualTemp = Nothing
        End If
        If Not IsNothing(listContactes.obj) Then Me.txtTelefon.Text = contacteActualTemp.telefon
        If Not IsNothing(listContactes.obj) Then Me.txtEmail.Text = contacteActualTemp.email
    End Sub
    Private Sub setProvincia()
        If Not IsNothing(llocActualTemp) Then llocActualTemp.provincia = listProvincies.obj
    End Sub
    Private ReadOnly Property etiqueta As String
        Get
            Return IDIOMA.getString("projecte") & ": " & projecteActual.nom & " | " & llocActual.nom & " | " & contacteActual.tostring
        End Get
    End Property

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodiPostal.KeyPress, txtEmail.KeyPress, txtPoblacio.KeyPress, txtTelefon.KeyPress
        If sender.Equals(txtCodiPostal) Then
            e.KeyChar = VALIDAR.Enter(e.KeyChar, txtCodiPostal.Text.Length, 5)
        ElseIf sender.Equals(txtPoblacio) Or sender.Equals(txtEmail) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 49)
        ElseIf sender.Equals(txtTelefon) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 15)
        ElseIf sender.Equals(txtDirector) Or sender.Equals(txtResponsable) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 100)
        Else
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 254)
        End If

    End Sub
    Private Function getDadesLLocEntrega() As LlocEntrega
        getDadesLLocEntrega = llocActual.copy
        getDadesLLocEntrega.direccio = txtDireccio.Text
        getDadesLLocEntrega.codiPostal = txtCodiPostal.Text
        getDadesLLocEntrega.poblacio = txtPoblacio.Text
        getDadesLLocEntrega.provincia = listProvincies.obj
    End Function
    Private Function getDadesContacte() As Contacte
        getDadesContacte = contacteActual.copy
        getDadesContacte.telefon = txtTelefon.Text
        getDadesContacte.email = txtEmail.Text
    End Function
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtCodiPostal.TextChanged, txtEmail.TextChanged, txtPoblacio.TextChanged, txtTelefon.TextChanged, txtDireccio.TextChanged
        If actualitzar Then
            If sender.Equals(txtDireccio) Then
                If llocActualTemp IsNot Nothing Then llocActualTemp.direccio = txtDireccio.Text
            ElseIf sender.Equals(txtPoblacio) Then
                If llocActualTemp IsNot Nothing Then llocActualTemp.poblacio = txtPoblacio.Text
            ElseIf sender.Equals(txtCodiPostal) Then
                If llocActualTemp IsNot Nothing Then llocActualTemp.codiPostal = txtCodiPostal.Text
            ElseIf sender.Equals(txtEmail) Then
                If contacteActualTemp IsNot Nothing Then contacteActualTemp.email = txtEmail.Text
            ElseIf sender.Equals(txtTelefon) Then
                If contacteActualTemp IsNot Nothing Then contacteActualTemp.telefon = txtTelefon.Text
            End If
        End If
    End Sub
    Friend Sub gravarDades()
        If Not IsNothing(llocActual) Then
            If Not llocActual.equalsComanda(llocActualTemp) Then
                MsgBox("gravantllocactual")
            End If
        End If
        If Not IsNothing(contacteActual) Then
            If Not contacteActual.equalsComanda(contacteActualTemp) Then
                MsgBox("gravantContacte")
            End If
        End If
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        listLLocsEntrega = Nothing
        listContactes = Nothing
        listProvincies = Nothing
        empresaActual = Nothing
        projecteActual = Nothing
        llocActual = Nothing
        contacteActual = Nothing
        llocActualTemp = Nothing
        contacteActualTemp = Nothing
    End Sub
    Friend Sub setAccio()
        If lblAccio.Text = " - " Then
            lblAccio.Text = " + "
            Me.panelData.Visible = False
            Me.PanelTipTool.Visible = True
            Me.Height = 60
            Me.Parent.Height = 60
            Me.ToolTip1.SetToolTip(lblAccio, IDIOMA.getString("mostrarDades") & " " & textToolTip)
            Call setTipTool()
        Else
            lblAccio.Text = " - "
            Me.Height = llargadaPanel
            Me.Parent.Height = llargadaPanel
            Me.panelData.Visible = True
            Me.PanelTipTool.Visible = False
        End If
        If Not IsNothing(cbEmpresa) Then cbEmpresa.Select()
        RaiseEvent accioMostrar()
    End Sub
    Private Sub lblAccio_Click(sender As Object, e As EventArgs) Handles lblAccio.Click
        Call setAccio()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call setAccio()
    End Sub
    Private Sub setTipTool()
        Dim t As String = ""
        If projecteActual IsNot Nothing Then
            t = projecteActual.ToString & vbCrLf
            If llocActualTemp IsNot Nothing Then
                t = t & llocActualTemp.direccio & " | " & llocActualTemp.codiPostal & " " & llocActualTemp.poblacio
                If llocActualTemp.provincia IsNot Nothing Then t = t & "(" & llocActualTemp.provincia.ToString & ")"
            End If
            If contacteActualTemp IsNot Nothing Then t = t & vbCrLf & contacteActualTemp.tostring & " | " & contacteActualTemp.telefon & " | " & contacteActualTemp.email
        End If
        Me.lblTipTool.Text = t
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If cbEmpresa.SelectedIndex > -1 Then
            empresaActual = cbEmpresa.SelectedItem
            Call setEmpresa()
            If lblAccio.Text = " + " Then
                Call setAccio()
            End If
        Else
            empresaActual = Nothing
            Call setEmpresa()
            If lblAccio.Text = " - " Then
                Call setAccio()
            End If
        End If
        Call validateControls()
    End Sub
    Private Sub cbEmpresa_TextChanged(sender As Object, e As EventArgs) Handles cbEmpresa.TextChanged
        If actualitzar Then
            If cbEmpresa.Text = "" Then
                empresaActual = Nothing
                Call setEmpresa()
                If lblAccio.Text = " - " Then
                    Call setAccio()
                End If
            End If
        End If
    End Sub
    Private Sub cbProjecte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProjecte.SelectedIndexChanged
        If cbProjecte.SelectedIndex > -1 Then
            projecteActual = cbProjecte.SelectedItem
            Call setProjecte()
        Else
            projecteActual = Nothing
            listLLocsEntrega = Nothing
            Me.PanelContacte.Controls.Clear()
            Me.panelMagatzem.Controls.Clear()
            Me.panelProvincia.Controls.Clear()
            Me.txtCodiPostal.Text = ""
            Me.txtDireccio.Text = ""
            Me.txtPoblacio.Text = ""
            Me.txtTelefon.Text = ""
            Me.txtEmail.Text = ""
            Me.txtResponsable.Text = ""
            Me.txtDirector.Text = ""
        End If
        Call validateControls()
    End Sub
    Private Sub cbProjecte_TextChanged(sender As Object, e As EventArgs) Handles cbProjecte.TextChanged
        If actualitzar Then
            If cbProjecte.Text = "" Then
                projecteActual = Nothing
                listLLocsEntrega = Nothing
                Me.PanelContacte.Controls.Clear()
                Me.panelMagatzem.Controls.Clear()
                Me.panelProvincia.Controls.Clear()
                Me.txtCodiPostal.Text = ""
                Me.txtDireccio.Text = ""
                Me.txtPoblacio.Text = ""
                Me.txtTelefon.Text = ""
                Me.txtEmail.Text = ""
                Me.txtResponsable.Text = ""
                Me.txtDirector.Text = ""
            End If
        End If
    End Sub
    Private Sub panelDesplegableEmpresa_Load(sender As Object, e As EventArgs) Handles Me.Load
        actualitzar = False
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        actualitzar = True
        If empresaActual IsNot Nothing Then Me.cbEmpresa.SelectedItem = empresaActual
        Call setLanguage()
        Call setAccio()
        Call validateControls()
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccio.KeyDown,
                                                                         txtPoblacio.KeyDown,
                                                                         txtCodiPostal.KeyDown,
                                                                         panelMagatzem.KeyDown,
                                                                         panelProvincia.KeyDown,
                                                                         PanelContacte.KeyDown,
                                                                         txtTelefon.KeyDown,
                                                                         txtEmail.KeyDown,
                                                                         txtDirector.KeyDown,
                                                                         txtResponsable.KeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Down Then
            e.Handled = False
            Call SendKeys.Send("{tab}")
        ElseIf e.KeyValue = Keys.Up Then
            e.Handled = False
            Call getTab(sender, -1)
        End If
    End Sub
    Private Function getControls() As List(Of Control)
        getControls = New List(Of Control)
        getControls.Add(panelMagatzem)
        getControls.Add(txtDireccio)
        getControls.Add(txtPoblacio)
        getControls.Add(txtCodiPostal)
        getControls.Add(panelProvincia)
        getControls.Add(PanelContacte)
        getControls.Add(txtTelefon)
        getControls.Add(txtEmail)
        getControls.Add(txtResponsable)
        getControls.Add(txtDirector)
    End Function
    Private Sub getTab(sender As Object, p As Integer)
        Dim i As Integer
        For i = 0 To elements.Count - 1
            If sender.Equals(elements(i)) Then
                Exit For
            End If
        Next
        If i + p = elements.Count Then
            elements(0).Select()
        ElseIf i + p < 0 Then
            elements(elements.Count - 1).Select()
        Else
            elements(i + p).Select()
        End If
    End Sub

End Class
