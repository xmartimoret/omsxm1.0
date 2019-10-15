Public Class PanelSubgrupsGB
    Private subgrups As SelectSubGrupsGb
    Private subgrupActual As SubGrupGB
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub setObjects()
        subgrups = New SelectSubGrupsGb(1, False, False, -1, IDIOMA.getString("subGrupsGB"), 1)
        AddHandler subgrups.selectObject, AddressOf setSubgrup
        subgrups.Dock = DockStyle.Fill
        panelData.Controls.Clear()
        subgrups.Show()
        panelData.Controls.Add(subgrups)

    End Sub
    Private Sub setSubgrup(sg As SubGrupGB)
        subgrupActual = sg
    End Sub

    Private Sub PanelSubgrupsGB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setObjects()
    End Sub


End Class
