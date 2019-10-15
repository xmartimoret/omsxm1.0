Public Class panelDataDiari
    Friend dgvCentres As dataDiarioCentres
    Friend dgvSubcomptes As dataDiarioProjectes
    Friend dgvAssentaments As dataDiarioAssentaments
    Private dadesInforme As dataReport
    Public Sub New(p As dataReport)
        InitializeComponent()

        dadesInforme = p
        Call setCentres()
    End Sub
    Private Sub setCentres()
        dgvCentres = New dataDiarioCentres(dadesInforme)
        Me.split1.Panel1.Controls.Clear()
        dgvCentres.Dock = DockStyle.Fill
        Me.split1.Panel1.Controls.Add(dgvCentres)
        AddHandler dgvCentres.selectData, AddressOf setProjectes
        dgvCentres.Show()
    End Sub
    Private Sub setProjectes(c As Centre, sg As Subgrup)

        If c Is Nothing Or sg Is Nothing Then
            Me.split2.Panel1.Controls.Clear()
            Me.split2.Panel2.Controls.Clear()
        Else

            dgvSubcomptes = New dataDiarioProjectes(c, sg, dadesInforme)
            Me.split2.Panel1.Controls.Clear()
            dgvSubcomptes.Dock = DockStyle.Fill
            Me.split2.Panel1.Controls.Add(dgvSubcomptes)
            AddHandler dgvSubcomptes.selectData, AddressOf setAssentaments
            dgvSubcomptes.Show()

            Me.split2.Panel2.Controls.Clear()
        End If

    End Sub
    Private Sub setAssentaments(assentaments As List(Of Assentament))
        If assentaments Is Nothing Then
            Me.split2.Panel2.Controls.Clear()
        Else
            dgvAssentaments = New dataDiarioAssentaments(assentaments)
            Me.split2.Panel2.Controls.Clear()
            dgvAssentaments.Dock = DockStyle.Fill
            Me.split2.Panel2.Controls.Add(dgvAssentaments)
            dgvAssentaments.Show()
        End If

    End Sub

End Class
