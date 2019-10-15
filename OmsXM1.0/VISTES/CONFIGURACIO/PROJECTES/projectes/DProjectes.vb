Imports System.Windows.Forms

Public Class DProjectes
    Private panelProjectes As SelectProjectes
    Private tipusProjectes As Integer
    Public Function getProjectes(pTipusProjectes As Integer, idEmpresa As String) As List(Of Projecte)
        tipusProjectes = pTipusProjectes
        panelProjectes = New SelectProjectes(pTipusProjectes, Val(idEmpresa), 0, True, True, "", 1)
        panelProjectes.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(panelProjectes)
        Me.ShowDialog()
        If Not panelProjectes.projectes Is Nothing Then
            Return panelProjectes.projectes
        End If
        Return Nothing
    End Function
    Public Function selectProjectes(pTipusProjectes As Integer, pIdEmpresa As Integer) As List(Of Projecte)
        tipusProjectes = pTipusProjectes
        panelProjectes = New SelectProjectes(pTipusProjectes, pIdEmpresa, 0, True, True, "", 1)
        panelProjectes.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(panelProjectes)
        Me.ShowDialog()
        If Not panelProjectes.projectes Is Nothing Then
            Return panelProjectes.projectes
        End If
        Return Nothing

    End Function

End Class
