Imports System.Windows.Forms

Public Class dCrearLlibreMajor
    Private empresaActual As Empresa
    Private contaplusActual As Contaplus
    Private directoriExportacio As String
    Private actualitzar As Boolean
    Private projectesActuals As List(Of Projecte)
    Private departamentsActual As List(Of Departament)
    Private dataIni As SelectDia, dataFi As SelectDia, dr As Directori
    Private logActual As Log
    Private Sub setEmpreses()
        actualitzar = False
        Me.cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        actualitzar = True

        cbEmpresa.SelectedIndex = getIndexEmpresa()

        If cbEmpresa.SelectedIndex > -1 Then empresaActual = CType(cbEmpresa.SelectedItem, Empresa)

    End Sub
    Private Function getIndexEmpresa() As Integer
        Dim idEmpresa As Integer, i As Integer
        If IsNumeric(CONFIG_FILE.getTag(CONFIG_FILE.TAG.ID_EMPRESA_ACTUAL)) Then
            idEmpresa = CInt(CONFIG_FILE.getTag(CONFIG_FILE.TAG.ID_EMPRESA_ACTUAL))
            For i = 0 To cbEmpresa.Items.Count - 1
                If cbEmpresa.Items(i).id = idEmpresa Then
                    Return i
                End If
            Next
        End If

        Return -1
    End Function
    Private Sub setAnysComptables()
        actualitzar = False
        Me.cbAny.Items.Clear()
        If empresaActual.empresesContaplus.Count > 0 Then
            cbAny.Items.AddRange(ModelEmpresaContaplus.getListObjects(empresaActual))
            cbAny.SelectedIndex = cbAny.Items.Count - 1
        End If
        actualitzar = True
        Call cbAny_SelectedIndexChanged(cbAny, Nothing)
    End Sub
    Private Sub setData()
        dataIni = New SelectDia()
        dataFi = New SelectDia()
        If CONFIG.folderExist(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_DEPARTAMENTS)) Then
            dr = New Directori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_DEPARTAMENTS), IDIOMA.getString(""))
            Call getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_DEPARTAMENTS))
        Else
            dr = New Directori(CONFIG.getDirectoriPredeterminatExportDepartaments, IDIOMA.getString(""))
            Call getDirectori(CONFIG.getDirectoriPredeterminatExportDepartaments)
        End If
        pDataIni.Controls.Clear()
        pDataFinal.Controls.Clear()

        pDirectori.Controls.Clear()
        dataIni.Dock = DockStyle.Fill
        dataFi.Dock = DockStyle.Fill
        dr.Dock = DockStyle.Fill
        pDataIni.Controls.Add(dataIni)
        pDataFinal.Controls.Add(dataFi)
        pDirectori.Controls.Add(dr)
        AddHandler dataIni.selectObject, AddressOf getDateInici
        AddHandler dataFi.selectObject, AddressOf getDateFinal
        AddHandler dr.selectObject, AddressOf getDirectori
        dataIni.Show()
        dataFi.Show()
        dr.Show()

    End Sub
    Private Sub setDataLimits()
        Dim d As String
        dataIni.dataActual = Format(DateSerial(contaplusActual.anyo, 1, 1), "dd-MM-yy")
        dataIni.dataInferior = DateSerial(contaplusActual.anyo, 1, 1)
        dataIni.dataSuperior = DateSerial(contaplusActual.anyo, 12, 31)
        d = CONFIG_FILE.getTag(CONFIG_FILE.TAG.DATA_FI_EXPORT_DEPARTAMENTS)
        If IsDate(d) Then
            If Year(d) = contaplusActual.anyo Then
                dataFi.dataActual = CDate(d)
            End If
        End If
        dataFi.dataInferior = DateSerial(contaplusActual.anyo, 1, 1)
        dataFi.dataSuperior = DateSerial(contaplusActual.anyo, 12, 31)
    End Sub
    Private Sub validateControls()
        Me.cmdCrear.Enabled = True
        If empresaActual.id = -1 Then
            Me.lblErrorEmpresa.Visible = True
            cmdCrear.Enabled = False
        Else
            Me.lblErrorEmpresa.Visible = False
        End If
        If contaplusActual.id = -1 Then
            Me.lblErrorAny.Visible = True
            cmdCrear.Enabled = False
            Call enabledControlsData(False)
        Else
            Me.lblErrorAny.Visible = False
            Call enabledControlsData(True)
        End If
        If IsDate(dataIni.dataActual) And IsDate(dataFi.dataActual) Then
            If CDate(dataIni.dataActual) > CDate(dataFi.dataActual) Then
                cmdCrear.Enabled = False
            End If
        Else
            cmdCrear.Enabled = False
        End If
        If departamentsActual Is Nothing And projectesActuals Is Nothing Then
            cmdCrear.Enabled = False
            lblErrProjectes.Visible = True
        Else
            If departamentsActual.Count = 0 And projectesActuals.Count = 0 Then
                lblErrProjectes.Visible = True
            Else
                lblErrProjectes.Visible = False
            End If
        End If

        If Not IsDate(dataIni.dataActual) Then
            lblErrorDataDeparta.Visible = True
            cmdCrear.Enabled = False
        Else
            lblErrorDataDeparta.Visible = True
        End If
        If Not IsDate(dataFi.dataActual) Then
            lblErrorDataDeparta.Visible = True
            cmdCrear.Enabled = False
        Else
            lblErrorDataDeparta.Visible = False
        End If
        If Not CONFIG.folderExist(directoriExportacio) Then
            lblErrorDataDeparta.Visible = True
            cmdCrear.Enabled = False
        Else
            lblErrorDataDeparta.Visible = False
        End If
    End Sub
    Private Sub enabledControlsData(estat As Boolean)
        Me.pDataIni.Visible = estat
        Me.pDataFinal.Visible = estat
        Me.lblDataIni.Visible = estat
        Me.lblDataFi.Visible = estat
        Me.lblErrorSelectAny.Visible = Not estat
    End Sub
    Private Sub setlanguage()
        Me.lblAny.Text = IDIOMA.getString("anyComptable")
        Me.lblDataIni.Text = IDIOMA.getString("dataIni")
        Me.lblDataFi.Text = IDIOMA.getString("dataFi")
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblErrorAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdCrear.Text = IDIOMA.getString("crearLlibreMajor")
        Me.cmdProjectes.Text = IDIOMA.getString("projectes")
        Me.cmdDepartaments.Text = IDIOMA.getString("departaments")
        Me.Text = IDIOMA.getString("analiticLlibreMajor")
        Me.lblErrorDataDeparta.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorSelectAny.Text = IDIOMA.getString("selectAnyComptable")
        Me.lblDepartamentProjecte.Text = IDIOMA.getString("selectDepartamentProjecte")
        Me.lblBorrarDeparta.Text = IDIOMA.getString("borrarSeleccio")
        Me.lblBorrarProjecte.Text = IDIOMA.getString("borrarSeleccio")
    End Sub
    Private Sub getDateInici(d As Date)
        Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.DATA_INI_EXPORT_DEPARTAMENTS, d)
        Call validateControls()
    End Sub
    Private Sub getDateFinal(d As Date)
        Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.DATA_FI_EXPORT_DEPARTAMENTS, d)
        Call validateControls()
    End Sub

    Private Sub getDirectori(p As String)
        directoriExportacio = p
        Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_DEPARTAMENTS, p)
        Call validateControls()
    End Sub
    Private Sub dCrearLlibreMajor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empresaActual = New Empresa
        contaplusActual = New Contaplus
        departamentsActual = New List(Of Departament)
        projectesActuals = New List(Of Projecte)

        Call setlanguage()

        Call setData()

        Call setEmpreses()

        Call setDataLimits()


    End Sub
    Private Sub cbAny_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAny.SelectedIndexChanged
        If actualitzar Then
            If cbAny.SelectedIndex > -1 Then

                contaplusActual = ModelEmpresaContaplus.getObject(cbAny.SelectedItem.id)
                If CONFIG_FILE.getTag(CONFIG_FILE.TAG.ES_LOCAL) Then
                    Me.lblInfoImport.Text = IDIOMA.getString("dadesDe") & ": " & CONFIG.getPathDiarioLocal(empresaActual.codi, contaplusActual.anyo)
                Else
                    Me.lblInfoImport.Text = IDIOMA.getString("dadesDe") & ": " & CONFIG.getPathDiarioServidor(empresaActual.codi, contaplusActual.anyo)
                End If
                Call setDataLimits()
            Else
                    contaplusActual = New Contaplus
                Me.lblInfoImport.Text = ""
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = cbEmpresa.SelectedItem
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.ID_EMPRESA_ACTUAL, empresaActual.id)
                Call setAnysComptables()
            Else
                empresaActual = New Empresa
            End If
            Call validateControls()
        End If
    End Sub
    Private Sub cmdProjectes_Click(sender As Object, e As EventArgs) Handles cmdProjectes.Click
        Dim pActuals As List(Of Projecte)
        pActuals = DProjectes.getProjectes(4, empresaActual.id)

        If pActuals IsNot Nothing Then
            lstProjectes.Items.Clear()
            projectesActuals.AddRange(pActuals)
            lstProjectes.Items.AddRange(CONFIG.getListObjects(projectesActuals))
        End If
        Call validateControls()
        pActuals = Nothing
    End Sub

    Private Sub dCrearLlibreMajor_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        empresaActual = Nothing
        contaplusActual = Nothing
        departamentsActual = Nothing
        directoriExportacio = Nothing
        projectesActuals = Nothing
        logActual = Nothing
        dataIni = Nothing
        dataFi = Nothing

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub cmdDepartaments_Click(sender As Object, e As EventArgs) Handles cmdDepartaments.Click
        Dim departaments As List(Of Departament), d As Departament
        departaments = dDepartaments.getDepartaments
        If departaments IsNot Nothing Then
            For Each d In departaments
                d.idEmpresa = empresaActual.id
            Next
            Me.lstDepartaments.Items.Clear()
            Me.lstDepartaments.Items.AddRange(CONFIG.getListObjects(departaments))
            departamentsActual = departaments
        End If
        Call validateControls()
        departaments = Nothing
    End Sub

    Private Sub lblBorrarDeparta_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblBorrarDeparta.LinkClicked
        departamentsActual = New List(Of Departament)
        lstDepartaments.Items.Clear()
        Call validateControls()
    End Sub

    Private Sub lblBorrarProjecte_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblBorrarProjecte.LinkClicked
        projectesActuals = New List(Of Projecte)
        lstProjectes.Items.Clear()
        Call validateControls()
    End Sub

    Private Sub cmdCrear_Click(sender As Object, e As EventArgs) Handles cmdCrear.Click
        Dim noSeguir As Boolean = False, p As Projecte, d As Departament
        logActual = New Log
        logActual.entrades = ModelDiario.getNoVinculats(empresaActual, contaplusActual, Month(dataFi.dataActual))
        For Each p In projectesActuals
            If Not departamentsActual.Exists(Function(x) UCase(x.codi) = UCase(Strings.Left(p.codi, 3))) Then
                d = New Departament
                d.codi = Strings.Left(p.codi, 3)
                d.idEmpresa = empresaActual.id
                departamentsActual.Add(d)
            End If
        Next

        If logActual.entrades.Count > 0 Then
            If ModelLog.hihaErrors(logActual.entrades) Then
                Call dLogs.setLog(logActual)
                If Not MISSATGES.CONFIRM_SEGUIR_LLIBRE_MAJOR Then noSeguir = True
            End If
        End If
        If noSeguir Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Call setAssentamentsDepartaments()
            Call ModulExportarDepartaments.getData(departamentsActual, empresaActual, dataIni.dataActual, dataFi.dataActual, projectesActuals, directoriExportacio)
            Me.DialogResult = DialogResult.OK
        End If
        logActual = Nothing
        p = Nothing
        d = Nothing
        Me.Dispose()
    End Sub
    Private Sub setAssentamentsDepartaments()
        Dim d As Departament
        Call ModelDiario.resetIndex()
        For Each d In departamentsActual
            d.assentaments = ModelDiario.getAssentamentsDepartament(empresaActual, contaplusActual, d.codi, CDate(dataIni.dataActual), CDate(dataFi.dataActual))
        Next
        d = Nothing
    End Sub

End Class
