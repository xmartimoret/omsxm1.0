Public Class panelDataTransitories
    Friend dgvCentres As dataTransitoriesCentres
    Friend dgvSubcomptes As dataTransitoriesProjectes
    Private dadesInforme As dataReport
    Public Sub New(p As dataReport)
        InitializeComponent()
        dadesInforme = p
        Call setCentres()
    End Sub
    Private Sub setCentres()
        Dim f As frmAvis
        f = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("carregantDades"), dadesInforme.seccioActual.ToString)
        dgvCentres = New dataTransitoriesCentres(dadesInforme)
        Me.split1.Panel1.Controls.Clear()
        dgvCentres.Dock = DockStyle.Fill
        Me.split1.Panel1.Controls.Add(dgvCentres)
        AddHandler dgvCentres.selectData, AddressOf setProjectes
        dgvCentres.Show()
        f.tancar()
        f = Nothing
    End Sub
    Private Sub setProjectes(c As Centre, sg As Subgrup)

        If c Is Nothing Or sg Is Nothing Then
            Me.split1.Panel2.Controls.Clear()
        Else
            dgvSubcomptes = New dataTransitoriesProjectes(c, sg, dadesInforme)
            Me.split1.Panel2.Controls.Clear()
            dgvSubcomptes.Dock = DockStyle.Fill
            Me.split1.Panel2.Controls.Add(dgvSubcomptes)
            dgvSubcomptes.Show()
        End If

    End Sub

End Class
