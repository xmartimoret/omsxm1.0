Imports System.Windows.Forms

Public Class DCentresMan
    Private sCentres As SelectCentreMan
    Private centreActual As Centre
    Public Function getCentres(pCentres As List(Of Centre), pFitxer As String) As List(Of Centre)
        sCentres = New SelectCentreMan(pCentres)
        AddHandler sCentres.selectObject, AddressOf getCentre
        Me.lblFitxerMan.Text = pFitxer
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getCentres = sCentres.centres
        Else
            getCentres = Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblFitxerCaption.Text = IDIOMA.getString("fitxerMan") & ": "
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub setData()
        sCentres.Dock = DockStyle.Fill

        panelData.Controls.Clear()
        panelData.Controls.Add(sCentres)
        sCentres.Show()
    End Sub
    Private Sub panelCentresMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub
    Private Sub getCentre(c As Centre)

    End Sub
End Class