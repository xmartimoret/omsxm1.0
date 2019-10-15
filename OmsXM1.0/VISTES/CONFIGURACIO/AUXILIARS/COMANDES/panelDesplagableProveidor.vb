Public Class panelDesplagableProveidor
    Private llargadaPanel As Integer
    Private textToolTip As String
    Private listProveidors As lstProveidor
    Private listContactes As lstContactesProveidor
    Private listProvincies As lstAuxiliars1
    Friend proveidorActual As Proveidor
    Private proveidorTemp As Proveidor
    Friend contacteActual As ProveidorCont
    Private contacteTemp As ProveidorCont
    Friend Event accioMostrar()
    Friend Event selectObject(p As Proveidor)
    Private actualitzar As Boolean
    Public Sub New()
        InitializeComponent()
        Call setAccio()
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String)
        InitializeComponent()
        proveidorActual = New Proveidor
        llargadaPanel = pHeight
        Button1.Text = "&" & pTecla
        listProveidors = New lstProveidor(proveidorActual)
        AddHandler listProveidors.selectObject, AddressOf setProveidor
        listProvincies = New lstAuxiliars1(proveidorActual.provincia, DBCONNECT.getTaulaProvincia)
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pProveidor As Proveidor)
        InitializeComponent()
        llargadaPanel = pHeight
        proveidorActual = pProveidor

        lblTitol.Text = IDIOMA.getString("proveidor")
        Button1.Text = "&" & pTecla
        listProveidors = New lstProveidor(proveidorActual)
        AddHandler listProveidors.selectObject, AddressOf setProveidor
        listProvincies = New lstAuxiliars1(proveidorActual.provincia, DBCONNECT.getTaulaProvincia)
        If proveidorActual IsNot Nothing  Then Call setProveidor 
    End Sub

    Friend Sub setAccio()
        If lblAccio.Text = " - " Then
            lblAccio.Text = " + "
            Me.panelData.Visible = False
            Me.panelTipTool.Visible = True
            Me.Height = 60
            Me.Parent.Height = 60
            Me.ToolTip1.SetToolTip(lblAccio, IDIOMA.getString("mostrarDades") & " " & textToolTip)
            Call setTipTool()
        Else
            lblAccio.Text = " - "
            Me.Height = llargadaPanel
            Me.Parent.Height = llargadaPanel
            Me.panelData.Visible = True
            Me.panelTipTool.Visible = False
        End If
        listProveidors.cb.Select()
        RaiseEvent accioMostrar()
    End Sub
    Private Sub lblAccio_Click(sender As Object, e As EventArgs) Handles lblAccio.Click
        Call setAccio()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call setAccio()
    End Sub
    Private Sub panel_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.panelList.Controls.Clear()
        listProveidors.Dock = DockStyle.Fill
        Me.panelList.Controls.Add(listProveidors)
        Me.panelProvincia.Controls.Clear()
        listProvincies.Dock = DockStyle.Fill
        Me.panelProvincia.Controls.Add(listProvincies)
        Call setLanguage()
        Call setAccio()
        listProveidors.cb.Select()
        Call validateControls()

    End Sub
    Private Sub setLanguage()
        Me.lblContacte.Text = IDIOMA.getString("departament") & ": "
        Me.lblDireccio.Text = IDIOMA.getString("direccio") & ":"
        Me.lblPoblacio.Text = IDIOMA.getString("poblacio") & ":"
        Me.lblTitol.Text = IDIOMA.getString("proveidor") & ":"
        Me.lblProvincia.Text = IDIOMA.getString("provincia") & ":"
        Me.lblTelEmail.Text = IDIOMA.getString("telEmail") & ":"
    End Sub
    Private Sub validateControls()
        If listProveidors.cb.SelectedIndex = -1 Then
            txtDireccio.Enabled = False
            txtPoblacio.Enabled = False
            txtCodiPostal.Enabled = False
            listProvincies.cb.Enabled = False
            txtEmail.Enabled = False
        Else
            txtDireccio.Enabled = True
            txtPoblacio.Enabled = True
            txtCodiPostal.Enabled = True
            listProvincies.cb.Enabled = True
            txtEmail.Enabled = True
        End If
    End Sub
    Private Sub setProveidor()
        actualitzar = False
        proveidorActual = listProveidors.obj
        If Not IsNothing(proveidorActual) Then
            proveidorTemp = proveidorActual.copy
            Me.txtDireccio.Text = proveidorActual.direccio
            Me.txtCodiPostal.Text = proveidorActual.codiPostal
            Me.txtPoblacio.Text = proveidorActual.poblacio
            Me.txtEmail.Text = proveidorActual.email
            listProvincies.cb.SelectedItem = proveidorActual.provincia
            AddHandler listProvincies.selectObject, AddressOf setProvincia
            If proveidorActual.contactes.Count > 0 Then
                contacteActual = proveidorActual.contactes.Item(0)
            Else
                contacteActual = Nothing
            End If
            listContactes = New lstContactesProveidor(contacteActual, proveidorActual.id)
            AddHandler listContactes.selectObject, AddressOf setContacte
            Me.PanelContacte.Controls.Clear()
            listContactes.Dock = DockStyle.Fill
            Me.PanelContacte.Controls.Add(listContactes)
            listContactes.Show()
            Call validateControls()
            actualitzar = True
            Call setContacte()
            Call setTipTool()
            If lblAccio.Text = " + " Then
                Call setAccio()
            End If
        Else
            Me.txtDireccio.Text = ""
            Me.txtCodiPostal.Text = ""
            Me.txtPoblacio.Text = ""
            Me.txtEmail.Text = ""
            listProvincies.cb.SelectedIndex = -1
            contacteActual = Nothing
            listContactes = Nothing
            Me.PanelContacte.Controls.Clear()
            Call validateControls()
            actualitzar = True
            Call setTipTool()
            If lblAccio.Text = " - " Then
                Call setAccio()
            End If
            proveidorTemp = Nothing
        End If
        RaiseEvent selectObject(proveidorActual)
    End Sub
    Private Sub setProvincia()
        If Not IsNothing(proveidorTemp) Then proveidorTemp.provincia = listProvincies.obj
    End Sub
    Private ReadOnly Property etiqueta As String
        Get
            Return IDIOMA.getString("proveidor") & ": " & proveidorTemp.nom & " | " & proveidorTemp.poblacio & " | " & contacteTemp.toString
        End Get
    End Property
    Private Sub setContacte()
        contacteActual = listContactes.obj
        contacteTemp = listContactes.obj
        If contacteTemp IsNot Nothing Then proveidorTemp.idContacteActual = contacteTemp.id
        If contacteTemp IsNot Nothing Then Me.txtTelefon.Text = contacteTemp.telefon1

    End Sub
    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodiPostal.KeyPress, txtEmail.KeyPress, txtPoblacio.KeyPress, txtTelefon.KeyPress
        If sender.Equals(txtCodiPostal) Then
            e.KeyChar = VALIDAR.Enter(e.KeyChar, txtCodiPostal.Text.Length, 5)
        ElseIf sender.Equals(txtPoblacio) Or sender.Equals(txtEmail) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 49)
        ElseIf sender.Equals(txtTelefon) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 15)
        Else
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 254)
        End If

    End Sub
    Private Function getDadesProveidor() As Proveidor
        getDadesProveidor = proveidorActual.copy
        getDadesProveidor.direccio = txtDireccio.Text
        getDadesProveidor.codiPostal = txtCodiPostal.Text
        getDadesProveidor.poblacio = txtPoblacio.Text
        getDadesProveidor.provincia = listProvincies.obj
    End Function
    Private Function getDadesContacte() As ProveidorCont
        getDadesContacte = contacteActual.copy
        getDadesContacte.telefon1 = txtTelefon.Text
        If StrComp(txtEmail.Text, proveidorActual.email, CompareMethod.Text) <> 0 Then
            getDadesContacte.email = txtEmail.Text
        End If
    End Function
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtCodiPostal.TextChanged, txtEmail.TextChanged, txtPoblacio.TextChanged, txtTelefon.TextChanged, txtDireccio.TextChanged
        If actualitzar Then
            If sender.Equals(txtDireccio) Then
                If proveidorTemp IsNot Nothing Then proveidorTemp.direccio = txtDireccio.Text
            ElseIf sender.Equals(txtPoblacio) Then
                If proveidorTemp IsNot Nothing Then proveidorTemp.poblacio = txtPoblacio.Text
            ElseIf sender.Equals(txtCodiPostal) Then
                If proveidorTemp IsNot Nothing Then proveidorTemp.codiPostal = txtCodiPostal.Text
            ElseIf sender.Equals(txtEmail) Then
                If proveidorTemp IsNot Nothing Then proveidorTemp.email = txtEmail.Text
            ElseIf sender.Equals(txtTelefon) Then
                If contacteTemp IsNot Nothing Then contacteTemp.telefon1 = txtTelefon.Text
            End If

        End If
    End Sub
    Friend Sub gravarDades()
        If Not IsNothing(proveidorActual) Then
            If Not proveidorActual.equalsComanda(proveidorTemp) Then
                MsgBox("gravantProveidor")
            End If
        End If
        If Not IsNothing(contacteActual) Then
            If Not contacteActual.equalsComanda(contacteTemp) Then
                MsgBox("gravantContacte")
            End If
        End If
    End Sub
    Private Sub setTipTool()
        Dim t As String = ""
        If proveidorTemp IsNot Nothing Then
            t = proveidorTemp.direccio & " | " & proveidorTemp.codiPostal & " " & proveidorTemp.poblacio
            If proveidorTemp.provincia IsNot Nothing Then t = t & "(" & proveidorTemp.provincia.ToString & ")"
            If contacteTemp IsNot Nothing Then t = t & vbCrLf & contacteTemp.toString & " | " & contacteTemp.telefon1 & " | " & proveidorTemp.email
        End If

        Me.lblTitpTool.Text = t
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        proveidorActual = Nothing
        listProveidors = Nothing
        listContactes = Nothing
        listProvincies = Nothing
    End Sub
End Class
