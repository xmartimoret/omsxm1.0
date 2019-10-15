Imports System.Windows.Forms

Public Class DSelectCentres
    Private panelCentres As SelectCentres
    Public Function getCentres(idEmpresa As String, titol As String) As List(Of Centre)
        panelCentres = New SelectCentres(idEmpresa, True, True, titol, 1)
        panelCentres.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(panelCentres)
        Me.Text = titol
        Me.ShowDialog()
        If Not panelCentres.centres Is Nothing Then
            Return panelCentres.centres
        End If
        Return Nothing
    End Function
    Public Function getCentresNoAdded(pCentres As List(Of Centre), titol As String) As List(Of Centre)
        panelCentres = New SelectCentres(pCentres, True, True, titol, 1)
        panelCentres.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(panelCentres)
        Me.Text = titol
        Me.ShowDialog()
        If Not panelCentres.centres Is Nothing Then
            Return panelCentres.centres
        End If
        Return Nothing
    End Function

End Class
