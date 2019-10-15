Public Class panelDataPretancament
    Friend dgvCentres As dataPretancamentCentres
    Friend dgvDesglosse As dataPretancamentCentresDesglossat
    Friend dgvSubcomptes As dataTransitoriesProjectes
    Friend dgvAssentaments As dataDiarioAssentaments
    Private dadesInforme As dataReport

    Public Sub New(p As dataReport)
        InitializeComponent()

        dadesInforme = p
        Call setCentres()
    End Sub
    Private Sub setCentres()
        dgvCentres = New dataPretancamentCentres(dadesInforme)
        Me.Split1.Panel1.Controls.Clear()
        dgvCentres.Dock = DockStyle.Fill
        Me.Split1.Panel1.Controls.Add(dgvCentres)
        AddHandler dgvCentres.selectData, AddressOf setDesglosse
        dgvCentres.Show()
    End Sub
    Private Sub setDesglosse(c As Centre, sg As Subgrup)

        If c Is Nothing Or sg Is Nothing Then
            Me.Split2.Panel1.Controls.Clear()
            Me.Split2.Panel2.Controls.Clear()
        Else
            dgvDesglosse = New dataPretancamentCentresDesglossat(c, sg, dadesInforme)
            Me.Split2.Panel1.Controls.Clear()
            dgvDesglosse.Dock = DockStyle.Fill
            Me.Split2.Panel1.Controls.Add(dgvDesglosse)
            AddHandler dgvDesglosse.selectData, AddressOf setAssentaments
            AddHandler dgvDesglosse.selectDataTransitoria, AddressOf setTransitoria
            dgvDesglosse.Show()
            Me.Split2.Panel2.Controls.Clear()
        End If

    End Sub
    Private Sub setAssentaments(assentaments As List(Of Assentament))
        If assentaments Is Nothing Then
            Me.Split2.Panel2.Controls.Clear()
        Else
            dgvAssentaments = New dataDiarioAssentaments(assentaments)
            Me.Split2.Panel2.Controls.Clear()
            dgvAssentaments.Dock = DockStyle.Fill
            Me.Split2.Panel2.Controls.Add(dgvAssentaments)
            dgvAssentaments.Show()
        End If

    End Sub
    Private Sub setTransitoria(c As Centre, sg As Subgrup)
        Dim dr As dataReport
        If c Is Nothing Or sg Is Nothing Then
            Me.Split2.Panel2.Controls.Clear()
        Else
            dr = dadesInforme
            dr.isValorAcumulat = False
            dgvSubcomptes = New dataTransitoriesProjectes(c, sg, dr)
            Me.Split2.Panel2.Controls.Clear()
            dgvSubcomptes.Dock = DockStyle.Fill
            Me.Split2.Panel2.Controls.Add(dgvSubcomptes)
            dgvSubcomptes.Show()
            dr = Nothing
        End If
    End Sub

End Class
