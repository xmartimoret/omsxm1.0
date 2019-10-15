Public Class tabControl
    Public Property panel As UserControl
    Public Property id As Integer
    Public Property nom As String
    Friend Event close(id As Integer)
    Friend Event isActivate(id As Integer)

    Public Sub New()
        InitializeComponent()
        panel.Dock = DockStyle.Fill
        Me.lblTitol.BackColor = Color.Transparent
    End Sub
    Public Sub New(pId As Integer, pTitol As String, pPanel As UserControl)
        InitializeComponent()
        lblTitol.Text = pTitol
        panel = pPanel
        id = pId
        nom = pTitol
        panel.Dock = DockStyle.Fill
        Me.lblTitol.BackColor = Color.Transparent
    End Sub
    Public Sub activate()
        Me.BackColor = Color.Black
        lblTitol.ForeColor = Color.White

    End Sub
    Public Sub deActivate()
        Me.BackColor = Color.Transparent
        lblTitol.ForeColor = Color.Black

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        RaiseEvent close(id)
    End Sub

    Private Sub lblTitol_Click(sender As Object, e As EventArgs) Handles lblTitol.Click
        Call activate()
        RaiseEvent isActivate(id)
    End Sub
End Class
