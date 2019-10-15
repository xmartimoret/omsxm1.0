Imports System.Windows.Forms

Public Class DSubcompteSubgrup
    Private subcompteActual As SubcompteGrup
    Public Function getSubcompte(s As SubcompteGrup) As SubcompteGrup
        subcompteActual = s
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getSubcompte = getData()
        Else
            getSubcompte = Nothing
        End If
        Me.Close()
    End Function
    Private Sub setData()
        Me.lblSubcompte.Text = subcompteActual.ToString
        Me.xecCompres.Checked = subcompteActual.esDespesaCompra
        Me.xecVariables.Checked = subcompteActual.esDespesaVariable
    End Sub
    Private Function getData() As SubcompteGrup
        getData = subcompteActual.copy
        getData.esDespesaCompra = xecCompres.Checked
        getData.esDespesaVariable = xecVariables.Checked
    End Function
    Private Sub setLanguage()
        Me.Text = IDIOMA.getString("dSubcomptesSubgrup")
        Me.xecCompres.Text = IDIOMA.getString("SubCompres")
        Me.xecVariables.Text = IDIOMA.getString("SubVariables")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
    End Sub
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub
End Class
