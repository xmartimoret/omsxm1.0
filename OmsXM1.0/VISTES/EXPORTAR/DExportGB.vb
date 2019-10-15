Option Explicit On
Imports System.Windows.Forms
Public Class DExportGB
    Private empresaActual As Empresa
    Private contaplusActual As Contaplus
    Private isUnload As Boolean
    Private actualitzar As Boolean
    Private esPretancament As Boolean
    Private rutaFitxer As String
    Dim esGb As Boolean
    Public Function getCentres(Optional esPret As Boolean = False, Optional esMan As Boolean = False) As CentresGB
        Dim man As String
        esGb = Not esMan
        If esMan Then
            man = IDIOMA.getString("fitxerMan")
        Else
            man = " GB"
        End If
        esPretancament = esPret
        Call setEmpreses()
        Call setRutaGb()
        Call validateControls()
        If esPretancament Then
            Me.Text = IDIOMA.getString("exportPretancament") & "  " & man
        Else
            Me.Text = IDIOMA.getString("exportTancament") & "  " & man
        End If
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getCentres = getData()
            If getCentres IsNot Nothing Then
                getCentres.empresa = empresaActual
                getCentres.contaplus = contaplusActual
            End If
        Else
            getCentres = Nothing
        End If
        Me.Close()
    End Function
    Private Sub setEmpreses()
        actualitzar = False
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects())
        actualitzar = True
        cbEmpresa.SelectedIndex = getIndexEmpresa()
        Call validateControls()
    End Sub
    Private Function getIndexEmpresa() As Integer
        Dim idEmpresa As String, e As Empresa, i As Integer
        idEmpresa = CONFIG_FILE.getTag(CONFIG_FILE.TAG.ID_EMPRESA_ACTUAL)
        i = 0
        getIndexEmpresa = -1
        For Each e In cbEmpresa.Items
            If e.id = Val(idEmpresa) Then
                getIndexEmpresa = i
                Exit For
            End If
            i = i + 1
        Next
        e = Nothing
    End Function
    Private Sub setAnys()
        Dim dades As List(Of Integer), a As Integer
        actualitzar = False
        If UCase(empresaActual.codi) = UCase(CONFIG.getCodiAndorra) Then
            dades = ModulImportAndorra.getAnyos(empresaActual.codi)
        ElseIf UCase(empresaActual.codi) = UCase(CONFIG.getCodiZamora) Then
            dades = ModulImportZamora.getAnyos(empresaActual.codi)
        Else
            If esPretancament Then
                dades = ModelTransitoria.getListAnys(empresaActual.id)
            Else
                dades = ModulActualitzacioGB.getAnyos
            End If
        End If
        cbAny.Items.Clear()
        cbMes.Items.Clear()
        If dades.Count > 0 Then
            For Each a In dades
                cbAny.Items.Add(a)
            Next
            cbAny.SelectedIndex = cbAny.Items.Count - 1
            Call setMesos()
        End If
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub setMesos()
        Dim dades As List(Of Mes)
        actualitzar = False
        If UCase(empresaActual.codi) = UCase(CONFIG.getCodiAndorra) Then
            dades = ModulImportAndorra.getMesos(empresaActual.codi, cbAny.SelectedItem)
        ElseIf UCase(empresaActual.codi) = UCase(CONFIG.getCodiZamora) Then
            dades = ModulImportZamora.getMesos(empresaActual.codi, cbAny.SelectedItem)
        Else
            If esPretancament Then
                dades = ModelTransitoria.getMesos(empresaActual.id, cbAny.SelectedItem)
            Else
                dades = ModulActualitzacioGB.getMesos(cbAny.SelectedItem)
            End If
        End If
        cbMes.Items.Clear()
        If dades.Count > 0 Then
            cbMes.Items.AddRange(getObjects(dades))
            cbMes.SelectedIndex = cbMes.Items.Count - 1
        End If
        Call validateControls()
        actualitzar = True
    End Sub
    Private Function getObjects(dList As List(Of Mes)) As Object()
        Dim i As Integer, temp() As Object, o As Object
        ReDim temp(0 To dList.Count - 1)
        i = 0
        For Each o In dList
            temp(i) = o
            i = i + 1
        Next
        o = Nothing
        Return temp
    End Function

    Private Sub setRutaGb()
        Dim fBrowser As Directori
        If esPretancament Then
            rutaFitxer = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_GB_PRETANCAMENT)
            fBrowser = New Directori(rutaFitxer, IDIOMA.getString("escollirFitxerPretancament"), IDIOMA.getString("dadesPretancament") & "(*.xls*)|*.xls*")
        Else
            If esGb Then
                rutaFitxer = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_GB_TANCAMENT)
                fBrowser = New Directori(rutaFitxer, IDIOMA.getString("escollirFitxerTancament"), IDIOMA.getString("dadesTancament") & "(*.xls*)|*.xls*")
            Else
                rutaFitxer = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_EXPORT_MAN)
                fBrowser = New Directori(rutaFitxer, IDIOMA.getString("escollirFitxerMan"), IDIOMA.getString("dadesTancament") & "(*.xls*)|*.xls*")
            End If

        End If

        fBrowser.Dock = DockStyle.Fill
        PanelDir.Controls.Clear()
        PanelDir.Controls.Add(fBrowser)
        AddHandler fBrowser.selectObject, AddressOf getRutaFitxer
        fBrowser.Show()

    End Sub
    Private Sub getRutaFitxer(t As String)
        rutaFitxer = t
        If esPretancament Then
            CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_GB_PRETANCAMENT, rutaFitxer)
        Else
            If esGb Then
                CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_GB_TANCAMENT, rutaFitxer)
            Else
                CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_EXPORT_MAN, rutaFitxer)
            End If
        End If
        Call validateControls()
    End Sub
    Private Sub setLanguage()
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblErrAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrFitxer.Text = IDIOMA.getString("campObligatori")
        Me.lblErrMes.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.lblErrParticipacio.Text = IDIOMA.getString("campObligatori")
        Me.lblMes.Text = IDIOMA.getString("mes")
        Me.lblAny.Text = IDIOMA.getString("anyo")
        Me.lblParticipacio.Text = IDIOMA.getString("participacio")
        Me.xecAny.Text = IDIOMA.getString("totAny")
        Me.xecTancar.Text = IDIOMA.getString("noTancarForm")
        Me.xecLog.Text = IDIOMA.getString("mostrarLog")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdExportar")
    End Sub
    Private Sub validateControls()
        cbAny.Enabled = True
        cbMes.Enabled = True
        Me.lblErrAny.Visible = False
        Me.lblErrorEmpresa.Visible = False
        Me.lblErrMes.Visible = False
        Me.lblErrFitxer.Visible = False
        Me.lblErrParticipacio.Visible = False
        Me.cmdGuardar.Enabled = True
        If cbEmpresa.SelectedIndex = -1 Then
            cbAny.Enabled = False
            cbMes.Enabled = False
            Me.cmdGuardar.Enabled = False
            Me.lblErrorEmpresa.Visible = True
        End If
        If cbAny.SelectedIndex = -1 Then
            cbMes.Enabled = False
            Me.lblErrAny.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Val(Me.txtParticipacio.Text) <= 0 Then
            Me.lblErrParticipacio.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Not CONFIG.fileExist(rutaFitxer) Then
            Me.lblErrFitxer.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If cbMes.SelectedIndex = -1 Then
            Me.lblErrMes.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Function getData() As CentresGB
        getData = New CentresGB
        getData.anyActual = cbAny.SelectedItem
        getData.participacio = Me.txtParticipacio.Text  ' 01/05/2016, anoto la participacio, ja que pot ser diferent que l'actual de l'empresa.
        getData.rutaGB = rutaFitxer
        getData.isClose = Not xecTancar.Checked
        getData.mesActual = cbMes.SelectedItem.num
        contaplusActual = ModelEmpresaContaplus.getObjectByEmpresaAny(empresaActual.id, cbAny.SelectedItem)
        getData.centres = DSelectCentres.getCentres(empresaActual.id, IDIOMA.getString("selectCentresDe") & " " & empresaActual.ToString)
        getData.isLog = xecLog.Checked
        getData.totAny = Me.xecAny.Checked
        If getData.centres Is Nothing Then
            getData = Nothing
        End If
    End Function

    Private Sub cmdGuardar_Click()
        isUnload = False
        Me.Hide()
    End Sub

    Private Sub txtParticipacio_Change()
        If actualitzar Then Call validateControls()
    End Sub



    Private Sub cbAny_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAny.SelectedIndexChanged
        If actualitzar Then
            If cbAny.SelectedIndex > -1 Then
                Call setMesos()
                contaplusActual = ModelEmpresaContaplus.getObjectByEmpresaAny(empresaActual.id, cbAny.SelectedItem)
            Else
                actualitzar = False
                cbMes.Items.Clear()
                actualitzar = True
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub cbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMes.SelectedIndexChanged
        If actualitzar Then
            Call validateControls()
        End If
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = cbEmpresa.SelectedItem
                Me.txtParticipacio.Text = empresaActual.participacio
                Call setAnys()
            Else
                actualitzar = False
                cbAny.Items.Clear()
                cbMes.Items.Clear()
                Me.txtParticipacio.Text = 0
                actualitzar = True
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub txtParticipacio_TextChanged(sender As Object, e As EventArgs) Handles txtParticipacio.TextChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.ID_EMPRESA_ACTUAL, empresaActual.id)
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txtParticipacio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParticipacio.KeyPress
        e.KeyChar = VALIDAR.EnterMax(e.KeyChar, txtParticipacio.Text.Length, 3, txtParticipacio.Text, 100)
    End Sub

    Private Sub DExportGB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
    End Sub
End Class
