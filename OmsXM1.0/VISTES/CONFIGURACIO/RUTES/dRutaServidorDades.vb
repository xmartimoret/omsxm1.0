Imports System.Windows.Forms

Public Class dRutaServidorDades
    Private fBrowser As Directori
    Private rutaActual As String
    Public Function getDirectori(ruta As String, caption As String) As String
        rutaActual = ruta
        Me.Text = caption
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getDirectori = fBrowser.lblDirectori.Text
            Me.Close()
        Else
            getDirectori = ""
            Me.Close()
        End If
    End Function
    Private Sub setLanguage()

        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub setData()
        fBrowser = New Directori(rutaActual, Me.Text)
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

    Private Sub dRutaServidorDades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
