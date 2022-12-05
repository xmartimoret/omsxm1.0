Public Class panelData
    Public dadesInforme As dataReport
    Private actualitzar As Boolean
    Private panelDiari As panelDataDiari
    Private panelTransitoria As panelDataTransitories
    Private panelPretancament As panelDataPretancament
    Private panelTancament As PanelDataTancament
    Private mesActual As Integer
    Public Sub New(pEmpresa As Empresa, pC As Contaplus)
        InitializeComponent()
        Call ModelCentre.actualitzar(False)
        dadesInforme = New dataReport(cbDades.SelectedItem, pEmpresa, pC)
        dadesInforme.tipusInforme = CONFIG_FILE.getTag(CONFIG_FILE.TAG.TIPUS_INFORME)
        Call setTipusDades()
        Call setSeccions()
        Call setLanguage()
        dadesInforme.isValorAcumulat = optAcumulat.Checked
        mesActual = 0
        Call setMesos()

        Call setSeccio()
        dadesInforme.grupComptable = ModelGrup.getObject("R")
        Call showData()
    End Sub

    Public Sub New(pEmpresa As Empresa, pC As Contaplus, pMesActual As Integer)
        InitializeComponent()


        dadesInforme = New dataReport(cbDades.SelectedItem, pEmpresa, pC)
        dadesInforme.tipusInforme = CONFIG_FILE.getTag(CONFIG_FILE.TAG.TIPUS_INFORME)
        Call setTipusDades()
        Call setSeccions()
        Call setLanguage()
        dadesInforme.isValorAcumulat = optAcumulat.Checked

        mesActual = pMesActual
        Call setMesos()
        Call setSeccio()
        dadesInforme.grupComptable = ModelGrup.getObject("R")
        Call showData()
    End Sub
    Public Sub New(pEmpresa As Empresa, pC As Contaplus, pMesActual As Integer, tipusInforme As String)
        InitializeComponent()
        dadesInforme = New dataReport(cbDades.SelectedItem, pEmpresa, pC)
        dadesInforme.tipusInforme = tipusInforme
        Call setTipusDades()
        Call setSeccions()
        Call setLanguage()
        dadesInforme.isValorAcumulat = optAcumulat.Checked
        mesActual = pMesActual
        Call setMesos()
        Call setSeccio()
        dadesInforme.grupComptable = ModelGrup.getObject("R")
        Call showData()
    End Sub
    Private Sub setTipusDades()
        actualitzar = False
        cbDades.Items.Clear()
        cbDades.Items.Add(IDIOMA.getString("dadesComptabilitat"))
        cbDades.Items.Add(IDIOMA.getString("dadesTransitories"))
        cbDades.Items.Add(IDIOMA.getString("dadesPretancament"))
        cbDades.Items.Add(IDIOMA.getString("dadesTancament"))
        cbDades.Items.Add(IDIOMA.getString("dadesBudget"))
        cbDades.SelectedIndex = getSelectedTipusDades(dadesInforme.tipusInforme)
        actualitzar = True
    End Sub
    Private Function getSelectedTipusDades(tipus As String) As Integer
        Dim i As Integer
        getSelectedTipusDades = 0
        For i = 0 To cbDades.Items.Count - 1
            If cbDades.Items(i) = tipus Then
                getSelectedTipusDades = i
                Exit For
            End If
        Next
    End Function
    Private Sub setSeccions()
        actualitzar = False
        cbSeccio.Items.Clear()
        cbSeccio.Items.AddRange(CONFIG.getListObjects(dadesInforme.empresaActual.seccions))
        If cbSeccio.Items.Count > 0 Then
            cbSeccio.SelectedIndex = getSelectedSeccio(Val(CONFIG_FILE.getTag(CONFIG_FILE.TAG.SECCIO_INFORME)))
            dadesInforme.seccioActual = cbSeccio.SelectedItem
        End If
        actualitzar = True
    End Sub
    Private Function getSelectedSeccio(id As Integer) As Integer
        Dim i As Integer
        getSelectedSeccio = 0
        For i = 0 To cbSeccio.Items.Count - 1
            If id = cbSeccio.Items(i).id Then
                getSelectedSeccio = i
                Exit For
            End If
        Next
    End Function
    Private Sub setMesos()
        Dim m As Integer
        actualitzar = False
        cbMes.Items.Clear()
        For m = 1 To 12
            cbMes.Items.Add(New Mes(m, CONFIG.mesNom(m), dadesInforme.contaplusActual.anyo))
        Next
        If mesActual <= 0 Then
            If IsNumeric(CONFIG_FILE.getTag(CONFIG_FILE.TAG.MES_ACTUAL_INFORMES)) Then
                cbMes.SelectedIndex = getSelectedMes(CONFIG_FILE.getTag(CONFIG_FILE.TAG.MES_ACTUAL_INFORMES))
            Else
                cbMes.SelectedIndex = getSelectedMes(1)
            End If
        Else
            If cbMes.Items.Count >= mesActual Then
                cbMes.SelectedIndex = getSelectedMes(mesActual)
            End If
        End If
        dadesInforme.mesActual = cbMes.SelectedItem
        actualitzar = True
    End Sub
    Private Function getSelectedMes(m As Integer) As Integer
        Dim i As Integer
        getSelectedMes = cbMes.Items.Count - 1
        For i = 0 To cbMes.Items.Count - 1
            If m = cbMes.Items(i).num Then
                getSelectedMes = i
                Exit For
            End If
        Next
    End Function
    Private Sub setSeccio()
        Dim i As Integer, mesActiu(12) As Boolean, c As Centre, f As frmAvis
        If actualitzar Then
            f = New frmAvis(IDIOMA.getString("actualitzar"), IDIOMA.getString("carregantDades"), dadesInforme.seccioActual.nom)
            For i = 1 To 12
                mesActiu(i) = True
            Next
            For Each c In dadesInforme.seccioActual.centres
                If Not c.actualitzat Then
                    f.setData(IDIOMA.getString("carregantDades"), c.nom)
                    If c.projectes.Count > 0 Then
                        c.assentaments = ModelDiario.getAssentamentsCentreByMes(dadesInforme.empresaActual, dadesInforme.contaplusActual, c)
                        c.transitories = ModelTransitoria.getObjectsByCentreAny(dadesInforme.empresaActual, c, dadesInforme.mesActual.anyo)
                        c.importsSubgrups = ModulActualitzacioGB.getValues(c.id, dadesInforme.mesActual.anyo, mesActiu)
                        c.importsBudget = ModelBudget.getObjectsByCentreAny(dadesInforme.empresaActual, c, dadesInforme.mesActual.anyo)
                        c.setValorsSubgrupsBudget()
                        c.setValorsSubgrupsDetall()
                        c.setValorsSubgrupsDetallGB()
                        c.actualitzat = True
                    End If
                End If
            Next c
            f.tancar()
            c = Nothing
        End If
        f = Nothing
    End Sub
    Private Sub setLanguage()
        Me.lblMes.Text = IDIOMA.getString("mes") & ":"
        Me.lblSeccio.Text = IDIOMA.getString("seccio") & ":"
        Me.Text = dadesInforme.empresaActual.ToString & ". " & dadesInforme.tipusInforme
        Me.optAcumulat.Text = IDIOMA.getString("acumulat")
        Me.optIncremental.Text = IDIOMA.getString("incremental")
        Me.lblDades.Text = IDIOMA.getString("dadesDe") & ":"
    End Sub

    Private Sub cbSeccio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSeccio.SelectedIndexChanged
        If actualitzar Then
            dadesInforme.seccioActual = cbSeccio.SelectedItem
            CONFIG_FILE.setTag(CONFIG_FILE.TAG.SECCIO_INFORME, dadesInforme.seccioActual.id)
            Call setSeccio()
            Call showData()
        End If
    End Sub
    Private Sub showData()
        Dim p As Pretancament
        p = Nothing
        Select Case cbDades.SelectedItem
            Case IDIOMA.getString("dadesComptabilitat")
                panelDiari = New panelDataDiari(dadesInforme)
                Me.Panel2.Controls.Clear()
                panelDiari.Dock = DockStyle.Fill
                Me.Panel2.Controls.Add(panelDiari)
                panelDiari.Show()
            Case IDIOMA.getString("dadesTransitories")
                panelTransitoria = New panelDataTransitories(dadesInforme)
                Me.Panel2.Controls.Clear()
                panelTransitoria.Dock = DockStyle.Fill
                Me.Panel2.Controls.Add(panelTransitoria)
                panelTransitoria.Show()
            Case IDIOMA.getString("dadesPretancament")
                panelPretancament = New panelDataPretancament(dadesInforme)
                Me.Panel2.Controls.Clear()
                panelPretancament.Dock = DockStyle.Fill
                Me.Panel2.Controls.Add(panelPretancament)
                panelPretancament.Show()
            Case IDIOMA.getString("dadesTancament")
                panelTancament = New PanelDataTancament(dadesInforme)
                Me.Panel2.Controls.Clear()
                panelTancament.Dock = DockStyle.Fill
                Me.Panel2.Controls.Add(panelTancament)
                panelTancament.Show()
            Case IDIOMA.getString("dadesBudget")
        End Select
        Call setTitol()

    End Sub

    Private Sub cbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMes.SelectedIndexChanged
        If actualitzar Then
            dadesInforme.mesActual = cbMes.SelectedItem
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.MES_ACTUAL_INFORMES, dadesInforme.mesActual.num)
            Call setData()
        End If
    End Sub

    Private Sub optIncremental_CheckedChanged(sender As Object, e As EventArgs) Handles optIncremental.CheckedChanged
        If actualitzar Then
            dadesInforme.isValorAcumulat = optAcumulat.Checked
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.ES_INCREMENTAL_INFORME, optIncremental.Checked)
            Call setData()
        End If
    End Sub

    Private Sub optAcumulat_CheckedChanged(sender As Object, e As EventArgs) Handles optAcumulat.CheckedChanged
        If actualitzar Then
            dadesInforme.isValorAcumulat = optAcumulat.Checked
            Call setData()
        End If
    End Sub


    Private Sub cbDades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDades.SelectedIndexChanged
        If actualitzar Then
            dadesInforme.tipusInforme = cbDades.SelectedItem
            CONFIG_FILE.setTag(CONFIG_FILE.TAG.TIPUS_INFORME, dadesInforme.tipusInforme)
            Call setSeccio()
            Call showData()
        End If
    End Sub
    Private Sub setData()
        If actualitzar Then
            Select Case cbDades.SelectedItem
                Case IDIOMA.getString("dadesComptabilitat")
                    If panelDiari.dgvCentres IsNot Nothing Then panelDiari.dgvCentres.setData()
                    If panelDiari.dgvSubcomptes IsNot Nothing Then
                        panelDiari.dgvSubcomptes.setData()
                        panelDiari.dgvSubcomptes.actualitzarAssentaments()
                    End If
                    If panelDiari.dgvAssentaments IsNot Nothing Then panelDiari.dgvAssentaments.setData()
                Case IDIOMA.getString("dadesTransitories")
                    If panelTransitoria.dgvCentres IsNot Nothing Then panelTransitoria.dgvCentres.setData()
                    If panelTransitoria.dgvSubcomptes IsNot Nothing Then
                        panelTransitoria.dgvSubcomptes.setData()
                    End If
                Case IDIOMA.getString("dadesPretancament")
                    If panelPretancament.dgvCentres IsNot Nothing Then
                        panelPretancament.dgvCentres.setData()
                        If panelPretancament.dgvDesglosse IsNot Nothing Then panelPretancament.dgvDesglosse.setData()
                    End If

                Case IDIOMA.getString("dadesTancament")
                    If panelTancament.dgvCentres IsNot Nothing Then
                        panelTancament.dgvCentres.setData()
                    End If
                Case IDIOMA.getString("dadesBudget")
            End Select
            Call setTitol()
        End If
    End Sub
    Private Sub setTitol()
        Dim dIni As String, dFinal As String
        If optAcumulat.Checked Then
            dIni = Format(DateSerial(dadesInforme.contaplusActual.anyo, 1, 1), "dd-MM-yy")
        Else
            dIni = Format(DateSerial(dadesInforme.contaplusActual.anyo, dadesInforme.mesActual.num, 1), "dd-MM-yy")
        End If
        If dadesInforme.mesActual.num = 12 Then
            dFinal = Format(DateAdd(DateInterval.Day, -1, DateSerial(dadesInforme.contaplusActual.anyo + 1, 1, 1)), "dd-MM-yy")
        Else
            dFinal = Format(DateAdd(DateInterval.Day, -1, DateSerial(dadesInforme.contaplusActual.anyo, dadesInforme.mesActual.num + 1, 1)), "dd-MM-yy")
        End If
        Me.lblTitol.Text = dadesInforme.empresaActual.codi & "." & dadesInforme.seccioActual.codi & " (" & dIni & " a " & dFinal & ")"
    End Sub

End Class
