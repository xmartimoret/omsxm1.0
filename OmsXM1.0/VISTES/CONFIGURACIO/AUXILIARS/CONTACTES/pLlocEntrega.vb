﻿Public Class pLlocEntrega
    Private panelLlocEntrega As SelectLlocEntrega
    Private LlocEntregaActual As LlocEntrega
    Private Sub setLlocEntrega()
        panelLlocEntrega = New SelectLlocEntrega(1, False, True, IDIOMA.getString("magatzems"), 1)
        AddHandler panelLlocEntrega.selectObject, AddressOf getLlocEntrega
        Me.panelData.Controls.Clear()
        panelLlocEntrega.Dock = DockStyle.Fill
        panelData.Controls.Add(panelLlocEntrega)
        panelLlocEntrega.Show()
    End Sub
    Private Sub getLlocEntrega(a As LlocEntrega)
        LlocEntregaActual = a
    End Sub
    Private Sub pArticles_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setLlocEntrega()
    End Sub

    Private Sub panelData_Paint(sender As Object, e As PaintEventArgs) Handles panelData.Paint

    End Sub
End Class
