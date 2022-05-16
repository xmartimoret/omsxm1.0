Public Class pLlocEntrega
    Private panelLlocEntrega As SelectLlocEntrega
    Private LlocEntregaActual As LlocEntrega
    Private Sub setLlocEntrega()
        panelLlocEntrega = New SelectLlocEntrega(1, True, True, IDIOMA.getString("magatzems"), 1)
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

End Class
