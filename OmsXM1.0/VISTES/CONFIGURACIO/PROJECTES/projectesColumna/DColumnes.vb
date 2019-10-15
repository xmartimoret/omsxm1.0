Imports System.Windows.Forms

Public Class DColumnes
    Private panelColumnes As SelectSubColumnes
    Public Function getColumnes(idColumna As String, pTitol As String) As List(Of Columna)
        panelColumnes = New SelectSubColumnes(0, True, True, "", 1)
        Me.Text = pTitol
        panelColumnes.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(panelColumnes)
        Me.ShowDialog()
        If Not panelColumnes.columnes Is Nothing Then
            Return panelColumnes.columnes
        End If
        Return Nothing
    End Function

End Class
