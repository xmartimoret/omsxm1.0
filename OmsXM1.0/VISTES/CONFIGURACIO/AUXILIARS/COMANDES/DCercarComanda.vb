Imports System.Windows.Forms

Public Class DCercarComanda
    Public Function getCodi() As String
        Call setLanguage()
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            Return txtCodi.Text
        End If
        Return ""
    End Function
    Private Sub setLanguage()
        Me.lblCodiCaption.Text = IDIOMA.getString("codiComanda")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
    End Sub
    Private Sub validateControls()
        If txtCodi.Text.Length < 3 Then
            Me.cmdGuardar.Enabled = False
        Else
            Me.cmdGuardar.Enabled = True
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub
End Class
