Public Class panelDesplagable
    Private llargadaPanel As Integer
    Private textToolTip As String

    Friend Event accioMostrar()
    Public Sub New()
        InitializeComponent()
        Call setAccio()
    End Sub
    Public Sub New(pHeight As Integer, pTitol As String, pTeclaAcceleradora As String)
        llargadaPanel = pHeight
        InitializeComponent()
        lblTitol.Text = pTitol
        textToolTip = pTitol
        Button1.Text = "&" & pTeclaAcceleradora
    End Sub
    Public Sub New(pHeight As Integer, pTitol As String, pTeclaAcceleradora As String, p As Object)
        InitializeComponent()
        panelData.Controls.Clear()
        p.Dock = DockStyle.Fill
        panelData.Controls.Add(p)
        lblTitol.Text = pTitol
        textToolTip = pTitol
        llargadaPanel = pHeight
        Button1.Text = "&" & pTeclaAcceleradora
    End Sub
    Friend Sub setAccio()
        If lblAccio.Text = "-" Then
            lblAccio.Text = "+"
            Me.panelData.Visible = True
            Me.Height = 15
            Me.Parent.Height = 15
            Me.ToolTip1.SetToolTip(lblAccio, IDIOMA.getString("mostrarDades") & " " & textToolTip)
        Else
            lblAccio.Text = "-"

            Me.Height = llargadaPanel
            Me.Parent.Height = llargadaPanel

            Me.ToolTip1.SetToolTip(lblAccio, IDIOMA.getString("amagarDades") & " " & textToolTip)
            Me.panelData.Visible = True
        End If
        RaiseEvent accioMostrar()
    End Sub
    Private Sub lblAccio_Click(sender As Object, e As EventArgs) Handles lblAccio.Click
        Call setAccio()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call setAccio()
    End Sub


End Class