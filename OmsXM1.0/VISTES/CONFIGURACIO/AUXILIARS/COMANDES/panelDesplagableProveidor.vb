Public Class panelDesplagableProveidor
    Private llargadaPanel As Integer
    Private textToolTip As String
    Private listProveidors As lstProveidor
    Private listContactes As lstContactesProveidor
    Private proveidorActual As Proveidor
    Private contacteActual As ProveidorCont

    Friend Event accioMostrar()
    Friend Event selectObject(p As Proveidor)
    Private actualitzar As Boolean
    Public Sub New()
        InitializeComponent()
        proveidorActual = New Proveidor
        contacteActual = New ProveidorCont
        Call setAccio()
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String)
        InitializeComponent()
        proveidorActual = New Proveidor
        contacteActual = New ProveidorCont
        llargadaPanel = pHeight
        Button1.Text = "&" & pTecla
        listProveidors = New lstProveidor(proveidorActual)
        AddHandler listProveidors.selectObject, AddressOf setProveidor
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pProveidor As Proveidor)
        InitializeComponent()
        llargadaPanel = pHeight
        proveidorActual = pProveidor
        contacteActual = New ProveidorCont
        lblTitol.Text = IDIOMA.getString("proveidor")
        Button1.Text = "&" & pTecla
        listProveidors = New lstProveidor(proveidorActual)
        AddHandler listProveidors.selectObject, AddressOf setProveidor
        If proveidorActual IsNot Nothing  Then Call setProveidor 
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pProveidor As Proveidor, pContacte As ProveidorCont)

        InitializeComponent()

        llargadaPanel = pHeight
        proveidorActual = pProveidor
        lblTitol.Text = IDIOMA.getString("proveidor")
        Button1.Text = "&" & pTecla
        contacteActual = pContacte
        listProveidors = New lstProveidor(proveidorActual)
        AddHandler listProveidors.selectObject, AddressOf setProveidor
        If proveidorActual IsNot Nothing Then Call setProveidor()
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
    Friend Sub setObjects(estat As Boolean)
        If Not IsNothing(listProveidors) Then listProveidors.setObjects(estat)
        If Not IsNothing(listContactes) Then listContactes.setObjects(estat)
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
        Call setLanguage()
        Call setAccio()
        listProveidors.cb.Select()
    End Sub
    Private Sub setLanguage()
        Me.lblContacte.Text = IDIOMA.getString("departament") & ": "
        Me.lblTitol.Text = IDIOMA.getString("proveidor") & ":"
    End Sub
    Private Sub setProveidor()
        actualitzar = False
        proveidorActual = listProveidors.obj

        If Not IsNothing(proveidorActual) Then
            If proveidorActual.isAnotacioActiva Then
                Call MISSATGES.ANOTACIONS_PROVEIDOR(proveidorActual.nom, proveidorActual.getAnotacionsActives)
            End If
            Me.lblDireccio.Text = proveidorActual.toTarget
            If contacteActual Is Nothing And proveidorActual.contactes.Count > 0 Then
                contacteActual = proveidorActual.contactes.Item(0)
            End If
            If contacteActual Is Nothing Then contacteActual = New ProveidorCont
            listContactes = New lstContactesProveidor(contacteActual, proveidorActual.id)
            AddHandler listContactes.selectObject, AddressOf setContacte
            Me.PanelContacte.Controls.Clear()
            listContactes.Dock = DockStyle.Fill
            Me.PanelContacte.Controls.Add(listContactes)
            listContactes.Show()
            actualitzar = True
            Call setContacte()
            Call setTipTool()
            If lblAccio.Text = " + " Then
                Call setAccio()
            End If
        Else
            contacteActual = Nothing
            listContactes = Nothing
            Me.PanelContacte.Controls.Clear()
            actualitzar = True
            Call setTipTool()
            If lblAccio.Text = " - " Then
                Call setAccio()
            End If
        End If
        RaiseEvent selectObject(proveidorActual)
    End Sub

    Private ReadOnly Property etiqueta As String
        Get
            Return IDIOMA.getString("proveidor") & ": " & proveidorActual.nom & " | " & proveidorActual.poblacio & " | " & contacteActual.toString
        End Get
    End Property
    Friend ReadOnly Property proveidor As Proveidor
        Get
            Return proveidorActual
        End Get
    End Property
    Friend ReadOnly Property contacte As ProveidorCont
        Get
            Return contacteActual
        End Get
    End Property
    Private Sub setContacte()
        contacteActual = listContactes.obj
        If Not IsNothing(contacteActual) Then
            lblTelEmail.Text = contacteActual.toTarget
        Else
            lblTelEmail.Text = ""
        End If
    End Sub
    Private Function getDadesProveidor() As Proveidor
        getDadesProveidor = proveidorActual.copy
    End Function
    Private Function getDadesContacte() As ProveidorCont
        getDadesContacte = contacteActual.copy
    End Function
    Private Sub setTipTool()
        Dim t As String = ""
        If proveidorActual IsNot Nothing Then
            t = proveidorActual.toTarget
            If contacteActual IsNot Nothing Then t = t & vbCrLf & contacteActual.toString & " | " & contacteActual.toTarget
        End If
        Me.lblTitpTool.Text = t
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        proveidorActual = Nothing
        listProveidors = Nothing
        listContactes = Nothing
    End Sub

End Class
