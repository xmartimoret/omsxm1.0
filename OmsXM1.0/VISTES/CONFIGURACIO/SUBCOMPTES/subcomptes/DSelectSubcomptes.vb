Imports System.Windows.Forms

Public Class DSelectSubcomptes
    Private panelSubcomptes As SelectSubcomptes
    Private idGrupComptable As Integer
    Public Function getSubcomptes(pIdGrupComptable As Integer) As List(Of Subcompte)
        idGrupComptable = pIdGrupComptable
        xec67.Checked = True

        Me.ShowDialog()
        If Not panelSubcomptes.subcomptes Is Nothing Then
            Return panelSubcomptes.subcomptes
        End If
        Return Nothing
    End Function
    Private Sub setLanguage()
        Me.xec67.Text = IDIOMA.getString("dSelectSubcomptesNomes67")
    End Sub
    Private Sub DSelectSubcomptes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
    End Sub

    Private Sub xec67_CheckedChanged(sender As Object, e As EventArgs) Handles xec67.CheckedChanged
        panelSubcomptes = New SelectSubcomptes(0, True, True, idGrupComptable, xec67.Checked, "", 1)
        panelSubcomptes.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(panelSubcomptes)
        panelSubcomptes.Show()
    End Sub
End Class
