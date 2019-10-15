Option Explicit On
Imports System.Windows.Forms
Public Class DCentre
    Private centreActual As Centre
    Private actualitzar As Boolean
    Public Function getCentre(c As Centre) As Centre
        centreActual = c
        Call setLanguage()

        Call setData()
        Me.txtCodi.Select()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getCentre = getData()
        Else
            getCentre = Nothing
        End If
        Me.Close()
    End Function
    Private Sub validateControls()
        lblErrCodi.Visible = False
        lblErrNom.Visible = False
        cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            lblErrCodi.Visible = True
            cmdGuardar.Enabled = False
        End If
        If txtNom.Text.Length = 0 Then
            lblErrNom.Visible = True
            cmdGuardar.Enabled = False
        End If
    End Sub
    Private Sub setData()
        actualitzar = False
        Me.lblSeccio.Text = centreActual.codiSeccio
        Me.lblId.Text = centreActual.id
        Me.txtCodi.Text = centreActual.codi
        Me.txtNom.Text = centreActual.nom
        Me.txtNotes.Text = centreActual.notes
        Me.xecActiu.Checked = centreActual.actiu
        actualitzar = True
    End Sub
    Private Sub setLanguage()
        If centreActual.id = -1 Then
            Me.Text = IDIOMA.getString("dCentreNouCaption")
        Else
            Me.Text = IDIOMA.getString("dCentreModificarCaption")
        End If
        Me.lblCaptionId.Text = IDIOMA.getString("id")
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblNotes.Text = IDIOMA.getString("fitxerVoss")
        Me.xecActiu.Text = IDIOMA.getString("activa")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblSeccioCaption.Text = IDIOMA.getString("seccio")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
    End Sub
    Private Function getData() As Centre
        Dim i As Integer
        getData = centreActual.copy
        getData.codi = Me.txtCodi.Text
        getData.nom = Me.txtNom.Text
        getData.notes = Me.txtNotes.Text
        getData.actiu = Me.xecActiu.Checked
    End Function
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub
    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        If actualitzar Then Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.signeAlfaNumeric(e.KeyChar, txtCodi.Text.Length, 10)
    End Sub
    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        If actualitzar Then Call validateControls()
    End Sub
    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNom.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, txtNom.Text.Length, 100)
    End Sub
    Private Sub txtNotes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNotes.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, txtNotes.Text.Length, 250)
    End Sub

    Private Sub DCentre_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call validateControls()
    End Sub
End Class
