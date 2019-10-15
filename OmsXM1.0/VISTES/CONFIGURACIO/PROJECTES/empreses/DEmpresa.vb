Imports System.Windows.Forms

Public Class DEmpresa
    Private empresaActual As Empresa
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getEmpresa(pEmpresa As Empresa) As Empresa
        empresaActual = pEmpresa
        If empresaActual.id = -1 Then
            Me.Text = IDIOMA.getString("dEmpresaAfegirEmpresa")
        Else
            Me.Text = IDIOMA.getString("dEmpresaModificarEmpresa")
        End If

        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getEmpresa = getData()
            Me.Close()
        Else
            getEmpresa = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        Dim p As SelectEmpresesContaplus
        p = New SelectEmpresesContaplus(empresaActual.id, empresaActual.nom, "EMPRESES CONTAPLUS", 1)
        p.Dock = DockStyle.Fill
        Me.PanelContaplus.Controls.Add(p)
        p.Show()
        lblId.Text = empresaActual.id
        txtCodi.Text = empresaActual.codi
        txtNom.Text = empresaActual.nom
        txtNotes.Text = empresaActual.notes
        txtParticipacio.Text = empresaActual.participacio
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")

        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblParticipacio.Text = IDIOMA.getString("participacio")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblNotes.Text = IDIOMA.getString("notes")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.lblErrNom.Visible = False
        Me.lblErrParticipacio.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtParticipacio.Text.Length = 0 Then
            Me.lblErrParticipacio.Visible = True
            Me.cmdGuardar.Enabled = False
        ElseIf val(txtParticipacio.Text) = 0 Then
            Me.lblErrParticipacio.Visible = True
            Me.cmdGuardar.Enabled = False
        End If

    End Sub
    Private Function getData() As Empresa
        getData = empresaActual.copy
        getData.id = lblId.Text
        getData.codi = txtCodi.Text
        getData.nom = txtNom.Text
        getData.notes = txtNotes.Text
        getData.participacio = txtParticipacio.Text
    End Function


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub


    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        Call validateControls()
    End Sub

    Private Sub txtParticipacio_TextChanged(sender As Object, e As EventArgs) Handles txtParticipacio.TextChanged
        Call validateControls()
    End Sub

    Private Sub txtParticipacio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParticipacio.KeyPress
        e.KeyChar = VALIDAR.EnterMax(e.KeyChar, txtParticipacio.Text.Length, 4, txtParticipacio.Text, 100)
        e.Handled = False
    End Sub
End Class
