Imports System.Windows.Forms

Public Class dSelectYSheets
    Private panelSubcomptes As SelectYSheets

    Public Function getSubcomptes() As List(Of YSheet)
        Me.ShowDialog()
        If Not panelSubcomptes.ysheets Is Nothing Then
            Return panelSubcomptes.ysheets
        End If
        Return Nothing
    End Function
    Private Sub setLanguage()
        Me.Text = IDIOMA.getString("seleccionarSubcomptes")
    End Sub
    Private Sub DSelectSubcomptes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setSubcomptes()
    End Sub
    Private Sub setSubcomptes()
        panelSubcomptes = New SelectYSheets(0, True, True, IDIOMA.getString("ySheets"), 1)
        panelSubcomptes.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(panelSubcomptes)
        panelSubcomptes.Show()
    End Sub
End Class
