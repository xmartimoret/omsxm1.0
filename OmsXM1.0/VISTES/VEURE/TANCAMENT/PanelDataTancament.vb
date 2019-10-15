Public Class PanelDataTancament
    Friend dgvCentres As DataTancamentCentres
    Friend dgvCentresMes As DataTancamentCentresMes
    Private dadesInforme As dataReport
    Public Sub New(p As dataReport)
        InitializeComponent()

        dadesInforme = p
        Call setCentres()
    End Sub
    Private Sub setCentres()
        dgvCentres = New DataTancamentCentres(dadesInforme)
        Me.split1.Panel1.Controls.Clear()
        dgvCentres.Dock = DockStyle.Fill
        Me.split1.Panel1.Controls.Add(dgvCentres)
        AddHandler dgvCentres.selectData, AddressOf setDataMesos
        dgvCentres.Show()
    End Sub
    Private Sub setDataMesos(c As Centre, sg As Subgrup)
        dgvCentresMes = New DataTancamentCentresMes(c, sg, dadesInforme)
        Me.Split1.Panel2.Controls.Clear()
        dgvCentresMes.Dock = DockStyle.Fill
        Me.Split1.Panel2.Controls.Add(dgvCentresMes)

        dgvCentresMes.Show()
    End Sub

End Class
