Imports System.Windows.Forms

Public Class dRutaTresoreria
    Private fBrowser As Directori
    Private rutaActual As String
    Private filtreFitxer As String
    Public Function getFitxerImport(ruta As String) As String
        rutaActual = ruta
        filtreFitxer = "{" & IDIOMA.getString("fitxerTresoreria") & "}*.xls*|*.xls*"
        Me.Text = IDIOMA.getString("escollirFitxerTresoreriaCaption")
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getFitxerImport = fBrowser.lblDirectori.Text
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.TRESORERIA_OBRES, fBrowser.lblDirectori.Text)
            Me.Close()
        Else
            getFitxerImport = ""
            Me.Close()
        End If
    End Function
    Public Function getFitxerExport(ruta As String) As String
        rutaActual = ruta
        filtreFitxer = "{" & IDIOMA.getString("fitxerTresoreria") & "}*.xls*|*.xls*"
        Me.Text = IDIOMA.getString("escollirFitxerCashCaption")
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getFitxerExport = fBrowser.lblDirectori.Text
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.CASH_TRESORERIA, fBrowser.lblDirectori.Text)
            Me.Close()
        Else
            getFitxerExport = ""
            Me.Close()
        End If
    End Function
    Private Sub setLanguage()
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub setData()
        fBrowser = New Directori(rutaActual, Me.Text, filtreFitxer)
        fBrowser.Dock = DockStyle.Fill
        PanelRuta.Controls.Clear()
        PanelRuta.Controls.Add(fBrowser)
        fBrowser.Show()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Boto2_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Hide()
    End Sub
End Class
