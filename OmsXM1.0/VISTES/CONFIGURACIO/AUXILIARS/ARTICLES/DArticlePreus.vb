Imports System.Windows.Forms

Public Class dArticlePreus
    Private preus As SelectPreus
    Private preuActual As ArticlePreu
    Public Function getPreuArticle(pÌdArticle As Integer) As ArticlePreu
        preus = New SelectPreus(pÌdArticle, IDIOMA.getString("seleccionarPreu"))

        setPanel()
        Me.ShowDialog()
        getPreuArticle = preuActual
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub setPanel()
        Me.panelData.Controls.Clear()
        preus.Dock = DockStyle.Fill
        AddHandler preus.selectObject, AddressOf getPreu
        Me.panelData.Controls.Add(preus)
    End Sub
    Private Sub getPreu(a As ArticlePreu)
        Me.DialogResult = DialogResult.OK
        preuActual = a
        Me.Hide()
    End Sub


    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub
End Class
