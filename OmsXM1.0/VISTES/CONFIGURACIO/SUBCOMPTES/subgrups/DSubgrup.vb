Imports System.Windows.Forms

Public Class DSubgrup
    Private subgrupActual As Subgrup
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getsubgrup(psubgrup As Subgrup) As Subgrup
        subgrupActual = psubgrup
        If subgrupActual.id = -1 Then
            Me.Text = IDIOMA.getString("dsubgrupAfegirsubgrup")
        Else
            Me.Text = IDIOMA.getString("dsubgrupModificarsubgrup")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getsubgrup = getData()
            Me.Close()
        Else
            getsubgrup = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = subgrupActual.id
        txtCodi.Text = subgrupActual.codi
        txtNom.Text = subgrupActual.nom
        xecCompres.Checked = subgrupActual.esDespesaCompra
        xecVariables.Checked = subgrupActual.esDespesaVariable
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.xecCompres.Text = IDIOMA.getString("SubCompres")
        Me.xecVariables.Text = IDIOMA.getString("SubVariables")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
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
            Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        End If
        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub

    Private Function getData() As Subgrup
        getData = subgrupActual.copy
        getData.codi = txtCodi.Text
        getData.nom = txtNom.Text
        getData.esDespesaCompra = xecCompres.Checked
        getData.esDespesaVariable = xecVariables.Checked
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub Dsubgrup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub
    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, txtCodi.Text.Length, 4)
        e.Handled = False
    End Sub

End Class
