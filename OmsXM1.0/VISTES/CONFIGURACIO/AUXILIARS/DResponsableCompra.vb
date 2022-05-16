Imports System.Windows.Forms

Public Class DResponsableCompra
    Private responsableActual As ResponsableCompra
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getObject(presponsableCompra As ResponsableCompra) As ResponsableCompra
        responsableActual = presponsableCompra
        If responsableActual.id = -1 Then
            Me.Text = IDIOMA.getString("afegirNouResponsableCompra")
        Else
            Me.Text = IDIOMA.getString("modificarResponsableCompra")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getObject = getData()
            Me.Close()
        Else
            getObject = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = responsableActual.id
        txtCodi.Text = responsableActual.codi
        txtEmail.Text = responsableActual.notes
        txtNom.Text = responsableActual.nom
        xecActiu.Checked = responsableActual.actiu
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblEmail.Text = IDIOMA.getString("email")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.lblErrNom.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Function getData() As ResponsableCompra
        getData = responsableActual.copy
        getData.codi = txtCodi.Text
        getData.notes = txtEmail.Text
        getData.actiu = xecActiu.Checked
        getData.nom = txtNom.Text
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DresponsableCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtCodi.TextChanged, txtEmail.TextChanged, txtNom.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, sender.Text.Length, 3)
    End Sub

End Class



