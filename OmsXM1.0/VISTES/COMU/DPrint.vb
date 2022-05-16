Imports System.Windows.Forms

Public Class DPrint
    Private pDir As Directori
    Public Function getTipusImpresio() As TipusImpressio
        Call setLanguage()
        Call setRuta()
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.Yes Then
            getTipusImpresio = New TipusImpressio
            getTipusImpresio.isExcel = Me.optExcel.Checked
            getTipusImpresio.isRegistreActual = Me.optRegistreActual.Checked
            getTipusImpresio.rutaInforme = pDir.lblDirectori.Text
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_IMPRESSIO_INFORMES, pDir.lblDirectori.Text)
        Else
            getTipusImpresio = Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblTipus.Text = IDIOMA.getString("mitjaImpressio")
        Me.LblTipusInforme.Text = IDIOMA.getString("tipusImpressio")
        Me.optRegistreActual.Text = IDIOMA.getString("registreSeleccionat")
        Me.optRegistres.Text = IDIOMA.getString("registresActuals")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdImprimir")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")

    End Sub
    Private Sub setRuta()
        Dim ruta As String
        ruta = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_IMPRESSIO_INFORMES)
        If Not CONFIG.folderExist(ruta) Then ruta = CONFIG.getDirectoriAplicacio
        pDir = New Directori(ruta, IDIOMA.getString(""))
        panelDirectori.Controls.Clear()
        pDir.Dock = DockStyle.Fill
        panelDirectori.Controls.Add(pDir)
        pDir.Show()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.Yes
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.No
        Me.Hide()
    End Sub

End Class
