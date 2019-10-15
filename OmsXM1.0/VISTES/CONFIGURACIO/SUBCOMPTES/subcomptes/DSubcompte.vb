Imports System.Windows.Forms

Public Class DSubcompte
    Private subcompteActual As Subcompte
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getSubcompte(pSubcompte As Subcompte) As Subcompte
        subcompteActual = pSubcompte
        If subcompteActual.id = -1 Then
            Me.Text = IDIOMA.getString("dSubcompteAfegirSubcompte")
        Else
            Me.Text = IDIOMA.getString("dSubcompteModificarSubcompte")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getSubcompte = getData()
            Me.Close()
        Else
            getSubcompte = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = subcompteActual.id
        txtCodi.Text = subcompteActual.codi
        txtNom.Text = subcompteActual.nom
        txtNotes.Text = subcompteActual.notes
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")

        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblNotes.Text = IDIOMA.getString("notes")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.lblErrNom.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
            Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        ElseIf txtCodi.Text.Length <> 7 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
            Me.lblErrCodi.Text = IDIOMA.getString("codiIncorrecte")
        End If

        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub

    Private Function getData() As Subcompte
        getData = subcompteActual.copy
        getData.codi = txtCodi.Text
        getData.nom = txtNom.Text
        getData.notes = txtNotes.Text
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DSubcompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub
    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = (VALIDAR.EnterMax(e.KeyChar, txtCodi.Text.Length, 7, txtCodi.Text, 9999999))
        e.Handled = False
    End Sub
End Class
