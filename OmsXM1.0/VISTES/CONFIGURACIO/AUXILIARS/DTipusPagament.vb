Imports System.Windows.Forms

Public Class DTipusPagament
    Private tipusPagamentActual As TipusPagament
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function gettipusPagament(pTipusPagament As TipusPagament) As TipusPagament
        tipusPagamentActual = pTipusPagament
        If tipusPagamentActual.id = -1 Then
            Me.Text = IDIOMA.getString("dtipusPagamentAfegirtipusPagament")
        Else
            Me.Text = IDIOMA.getString("dtipusPagamentModificartipusPagament")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            gettipusPagament = getData()
            Me.Close()
        Else
            gettipusPagament = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = tipusPagamentActual.id
        txtCodi.Text = tipusPagamentActual.codi
        txtDies.Text = tipusPagamentActual.dies
        txtDia.Text = tipusPagamentActual.diaPagament
        txtNom.Text = tipusPagamentActual.nom
        xecActiu.Checked = tipusPagamentActual.actiu
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblDies.Text = IDIOMA.getString("dies")
        Me.lblDia.Text = IDIOMA.getString("dia")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        Me.etqDiaMes.Text = IDIOMA.getString("diaPagament")
        Me.etqDies.Text = IDIOMA.getString("diesA")
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
    Private Function getData() As TipusPagament
        getData = tipusPagamentActual.copy
        getData.codi = txtCodi.Text
        getData.dies = txtDies.Text
        getData.diaPagament = txtDia.Text
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

    Private Sub DtipusPagament_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub

    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged, txtDia.TextChanged, txtNom.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, sender.Text.Length, 3)
    End Sub
    Private Sub txtDies_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDies.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, sender.Text.Length, 3)
    End Sub
    Private Sub txtDia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDia.KeyPress
        e.KeyChar = VALIDAR.EnterMax(e.KeyChar, sender.Text.Length, 3, sender.text, 31)
    End Sub



    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNom.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.Length, 49)
    End Sub
End Class
