Imports System.Windows.Forms

Public Class DTipusIva
    Private tipusIvaActual As TipusIva
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function gettipusIva(ptipusIva As TipusIva) As TipusIva
        tipusIvaActual = ptipusIva
        If tipusIvaActual.id = -1 Then
            Me.Text = IDIOMA.getString("dtipusIvaAfegirtipusIva")
        Else
            Me.Text = IDIOMA.getString("dtipusIvaModificartipusIva")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            gettipusIva = getData()
            Me.Close()
        Else
            gettipusIva = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = tipusIvaActual.id
        txtCodi.Text = tipusIvaActual.codi
        txtImpost.Text = tipusIvaActual.impost
        Me.txtREquivalencia.Text = tipusIvaActual.rEquivalencia
        txtNom.Text = tipusIvaActual.nom
        xecActiu.Checked = tipusIvaActual.actiu
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblImpost.Text = IDIOMA.getString("impost")
        Me.lblREquivalencia.Text = IDIOMA.getString("r.equiv.")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.lblErrImpost.Text = IDIOMA.getString("campObligatori")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.lblErrNom.Visible = False
        Me.lblErrImpost.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtImpost.Text.Length = 0 Then
            Me.lblErrImpost.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Function getData() As TipusIva
        getData = tipusIvaActual.copy
        getData.codi = txtCodi.Text
        getData.impost = txtImpost.Text
        getData.rEquivalencia = txtREquivalencia.Text
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

    Private Sub DtipusIva_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtCodi.TextChanged, txtImpost.TextChanged, txtNom.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, sender.Text.Length, 3)
    End Sub
    Private Sub txtInt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImpost.KeyPress
        e.KeyChar = VALIDAR.EnterMax(e.KeyChar, sender.Text.Length, 3, sender.text, 100)
    End Sub
    Private Sub txtDouble_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtREquivalencia.KeyPress
        e.KeyChar = VALIDAR.Decimal_(e.KeyChar, sender.text, sender.SelectionStart, sender.text.length, 5, 2)
    End Sub
End Class
