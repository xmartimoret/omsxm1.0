Imports System.Windows.Forms

Public Class DGrup
    Private grupActual As Grup
    Private actualitzar As Boolean
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getGrup(pGrup As Grup) As Grup
        grupActual = pGrup
        If grupActual.id = -1 Then
            Me.Text = IDIOMA.getString("dGrupAfegirGrup")
        Else
            Me.Text = IDIOMA.getString("dGrupModificarGrup")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getGrup = getData()
            Me.Close()
        Else
            getGrup = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        actualitzar = False
        lblId.Text = grupActual.id
        txtCodi.Text = grupActual.codi
        txtNom.Text = grupActual.nom
        txtNotes.Text = grupActual.notes
        xecResum.Checked = grupActual.resum
        actualitzar = True
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.xecResum.Text = IDIOMA.getString("dGrupEsResum")
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

    Private Function getData() As Grup
        getData = grupActual.copy
        getData.codi = txtCodi.Text
        getData.nom = txtNom.Text
        getData.notes = txtNotes.Text
        getData.resum = xecResum.Checked
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DGrup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, txtCodi.Text.Length, 1)
    End Sub
End Class
