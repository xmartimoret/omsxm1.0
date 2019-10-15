Public Class dPassword
    Private Const clauAdmin As String = "oms"
    Private Sub setLanguage()
        Me.Text = IDIOMA.getString("validarAccio")
        Me.lblClau.Text = IDIOMA.getString("clauPas") & ":"
        Me.cmdAcceptar.Text = IDIOMA.getString("cmdAcceptar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub dPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
    End Sub

    Private Sub cmdAcceptar_Click(sender As Object, e As EventArgs) Handles cmdAcceptar.Click
        If Me.txtClau.Text = clauAdmin Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Abort
        End If
        Me.Close()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
