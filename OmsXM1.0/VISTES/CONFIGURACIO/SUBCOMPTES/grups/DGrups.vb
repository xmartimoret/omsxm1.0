Imports System.Windows.Forms

Public Class DGrups
    Private pGrup As SelectGrup
    Public Sub New()
        InitializeComponent()
        Me.Text = IDIOMA.getString("grupsComptables")
        pGrup = New SelectGrup(1, False, True, "")
        pGrup.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(pGrup)
        pGrup.Show()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
