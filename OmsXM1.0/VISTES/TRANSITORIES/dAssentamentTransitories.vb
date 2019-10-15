Imports System.Windows.Forms

Public Class dAssentamentTransitories
    Private actualitzar As Boolean
    Private isUnload As Boolean
    Private empresaActual As Empresa
    Private mesActual As Mes
    Private anyActual As Integer
    Private assentamentActual As AssentamentTransitoria
    Private rutaFitxer As String
    Public Function getAssentament() As AssentamentTransitoria
        Call ModelTransitoria.resetIndex()
        Me.ShowDialog()
        If Not isUnload Then
            getAssentament = assentamentActual
            Me.Dispose()
        Else
            getAssentament = Nothing
        End If
    End Function
    Private Sub setDirectori()
        Dim fBrowser As Directori
        rutaFitxer = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_EXPORTACIO_DBF)
        If Not CONFIG.folderExist(rutaFitxer) Then rutaFitxer = CONFIG.getDirectoriPredeterminatExportDBF
        fBrowser = New Directori(rutaFitxer, IDIOMA.getString("escollirDirectoriAssentamentTransitoria"))
        fBrowser.Dock = DockStyle.Fill
        panelDir.Controls.Clear()
        panelDir.Controls.Add(fBrowser)
        AddHandler fBrowser.selectObject, AddressOf getRutaFitxer
        fBrowser.Show()
    End Sub
    Private Sub getRutaFitxer(p As String)
        rutaFitxer = p
        CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_EXPORTACIO_DBF, rutaFitxer)
        Application.DoEvents()
        Call validateControls()
    End Sub
    Private Sub setEmpreses()
        actualitzar = False
        Me.cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub setAnys()
        Dim dades As List(Of Integer), i As Integer
        actualitzar = False
        dades = ModelTransitoria.getListAnys(empresaActual.id)
        cbAny.Items.Clear()
        cbMes.Items.Clear()
        If dades.Count > 0 Then
            For Each i In dades
                cbAny.Items.Add(i)
            Next
            cbAny.SelectedIndex = cbAny.Items.Count - 1
            anyActual = cbAny.SelectedItem
            Call setMesos()
        End If
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub setMesos()
        Dim dades As List(Of Mes), m As Mes
        actualitzar = False
        dades = ModelTransitoria.getMesos(empresaActual.id, cbAny.SelectedItem)
        cbMes.Items.Clear()
        If dades.Count > 0 Then
            For Each m In dades
                cbMes.Items.Add(m)
            Next
            cbMes.SelectedIndex = cbMes.Items.Count - 1
            mesActual = cbMes.SelectedItem
            Call setData()
        End If
        Call validateControls()
        actualitzar = True
    End Sub

    Private Sub setData()
        actualitzar = False
        If mesActual.num = 12 Then

            Me.txtData.Text = Format(DateAdd(DateInterval.Day, -1, DateSerial(anyActual + 1, 1, 1)), "dd-MM-yy")
            Me.txtDataExtorn.Text = Format(DateSerial(anyActual + 1, 1, 1), "dd-mm-yy")
        Else
            Me.txtData.Text = Format(DateAdd(DateInterval.Day, -1, DateSerial(anyActual, mesActual.num + 1, 1)), "dd-MM-yy")
            Me.txtDataExtorn.Text = Format(DateSerial(anyActual, mesActual.num + 1, 1), "dd-MM-yy")
        End If
        Me.txtConcepte.Text = "TRANSITORIA " & CONFIG.getDosDigits(mesActual.num) & "/" & Strings.Right(anyActual, 2)
        Me.txtConcepteExtorn.Text = "TRANSITORIA_EXT " & CONFIG.getDosDigits(mesActual.num) & "/" & Strings.Right(anyActual, 2)
        Me.txtDocument.Text = CONFIG.getDosDigits(mesActual.num) & "/" & Strings.Right(anyActual, 2)
        If Me.xecFitxer.Checked Then
            Me.txtNomFitxer.Text = Strings.Right(anyActual, 2) & CONFIG.getDosDigits(mesActual.num) & "DiaExt" & empresaActual.codi
        Else
            Me.txtNomFitxer.Text = Strings.Right(anyActual, 2) & CONFIG.getDosDigits(mesActual.num) & "Dia" & empresaActual.codi
        End If
        Me.txtNomFitxerExtorn.Text = Strings.Right(anyActual, 2) & CONFIG.getDosDigits(mesActual.num) & "Ext" & empresaActual.codi
        actualitzar = True
        Call validateControls()
    End Sub
    Private Sub getData()
        assentamentActual = New AssentamentTransitoria
        assentamentActual.concepte = Me.txtConcepte.Text
        assentamentActual.concepteExtorn = Me.txtConcepteExtorn.Text
        assentamentActual.document = Me.txtDocument.Text
        assentamentActual.fecha = Me.txtData.Text
        assentamentActual.fechaExtorn = Me.txtDataExtorn.Text
        assentamentActual.nomFitxer = Me.txtNomFitxer.Text
        assentamentActual.nomFitxerExtorn = Me.txtNomFitxerExtorn.Text
        assentamentActual.ruta = rutaFitxer
        assentamentActual.isUnFitxer = Me.xecFitxer.Checked
        assentamentActual.subcteSaldoDeure = Me.txtSubcompteCompres.Text
        assentamentActual.subcteSaldoHaver = Me.txtSubcompteVendes.Text
        assentamentActual.assentaments = ModelAssentamentTransitoria.getAssentaments(assentamentActual, ModelTransitoria.getObjects(empresaActual, anyActual, mesActual.num), False)
        assentamentActual.assentamentsExtorn = ModelAssentamentTransitoria.getAssentaments(assentamentActual, ModelTransitoria.getObjects(empresaActual, anyActual, mesActual.num), True)
    End Sub
    Private Sub setDataSubcomptes()
        actualitzar = False
        Me.txtSubcompteCompres.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SUBCOMPTE_TRANSITORIA_COMPRES)
        Me.txtSubcompteVendes.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SUBCOMPTE_TRANSITORIA_VENDES)
        actualitzar = True
        Call Me.txtSubcompte_textChanged(Nothing, Nothing)
        Call Me.txtSubcompteVendes_textChanged(Nothing, Nothing)

    End Sub
    Private Sub setLanguage()
        Me.Text = IDIOMA.getString("crearAssentamentTransitoria")
        Me.lblAny.Text = IDIOMA.getString("anyo")
        Me.lblConcepte.Text = IDIOMA.getString("concepte")
        Me.LblConcepteExtorn.Text = IDIOMA.getString("concepteExt")
        Me.lblDadesAssentament.Text = IDIOMA.getString("dadesAssentament")
        Me.lblDadesFitxer.Text = IDIOMA.getString("dadesFitxer")
        Me.lblData.Text = IDIOMA.getString("data")
        Me.lblDataExtorn.Text = IDIOMA.getString("dataExt")
        Me.lblDocument.Text = IDIOMA.getString("document")
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblErrorAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorConcepte.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorData.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorDataExtorn.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorDirectori.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorDocument.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorExtorn.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorMes.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorNomFitxer.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorNomFitxerExtorn.Text = IDIOMA.getString("campObligatori")

        Me.lblMes.Text = IDIOMA.getString("mes")
        Me.lblNomFitxer.Text = IDIOMA.getString("nomFitxer")
        Me.lblNomFitxerExtorn.Text = IDIOMA.getString("nomFitxerExt")

        Me.xecFitxer.Text = IDIOMA.getString("nomesUnFitxerExport")
    End Sub
    Private Sub validateControls()
        Me.lblErrorAny.Visible = False
        Me.lblErrorConcepte.Visible = False
        Me.lblErrorData.Visible = False
        Me.lblErrorDataExtorn.Visible = False
        Me.lblErrorDirectori.Visible = False
        Me.lblErrorDocument.Visible = False
        Me.lblErrorEmpresa.Visible = False
        Me.lblErrorMes.Visible = False
        Me.lblErrorNomFitxer.Visible = False
        Me.lblErrorNomFitxerExtorn.Visible = False
        Me.lblErrorConcepte.Visible = False
        Me.lblErrorExtorn.Visible = False
        Me.cmdGuardar.Enabled = True
        Me.cbAny.Enabled = True
        Me.cbMes.Enabled = True
        If cbEmpresa.SelectedIndex = -1 Then
            Me.lblErrorEmpresa.Visible = True
            Me.cbAny.Enabled = False
            Me.cbMes.Enabled = False
            Me.cmdGuardar.Enabled = False
        End If
        If cbAny.SelectedIndex = -1 Then
            Me.lblErrorAny.Visible = True
            Me.cmdGuardar.Enabled = False
            Me.cbMes.Enabled = False
        End If
        If cbMes.SelectedIndex = -1 Then
            Me.lblErrorMes.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Not IsDate(Me.txtData.Text) Then
            Me.lblErrorData.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Not IsDate(Me.txtDataExtorn.Text) Then
            Me.lblErrorDataExtorn.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtConcepte.Text = "" Then
            Me.lblErrorConcepte.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtConcepteExtorn.Text = "" Then
            Me.lblErrorExtorn.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtDocument.Text = "" Then
            Me.lblErrorDocument.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtNomFitxer.Text = "" Then
            Me.lblErrorNomFitxer.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtNomFitxerExtorn.Text = "" And Not Me.xecFitxer.Checked Then
            Me.lblErrorNomFitxerExtorn.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Not CONFIG.folderExist(rutaFitxer) Then
            Me.lblErrorDirectori.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Not ModelSubcompte.existCodi(Me.txtSubcompteCompres.Text) Then
            Me.cmdGuardar.Enabled = False
        End If
        If Not ModelSubcompte.existCodi(Me.txtSubcompteVendes.Text) Then
            Me.cmdGuardar.Enabled = False
        End If
        If Not Me.xecFitxer.Checked Then
            Me.txtNomFitxerExtorn.Visible = True
            Me.lblNomFitxerExtorn.Visible = True
            Me.lblDbfExtorn.Visible = True
        Else
            Me.txtNomFitxerExtorn.Visible = False
            Me.lblNomFitxerExtorn.Visible = False
            Me.lblDbfExtorn.Visible = False
        End If
    End Sub



    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = cbEmpresa.SelectedItem
                Call setAnys()
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub cbAny_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAny.SelectedIndexChanged
        If actualitzar Then
            If cbAny.SelectedIndex > -1 Then
                anyActual = cbAny.SelectedItem
                Call setMesos()
                Call validateControls()
            End If
        End If
    End Sub

    Private Sub cbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMes.SelectedIndexChanged
        If actualitzar Then
            If cbMes.SelectedIndex > -1 Then
                mesActual = cbMes.SelectedItem
                Call setData()
                Call validateControls()
            End If
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub txtChanged(sender As Object, e As EventArgs) Handles txtConcepte.TextChanged,
                                                                     txtConcepteExtorn.TextChanged,
                                                                     txtDocument.TextChanged,
                                                                     txtNomFitxer.TextChanged,
                                                                     txtNomFitxerExtorn.TextChanged,
                                                                     txtData.TextChanged,
                                                                     txtDataExtorn.TextChanged
        If actualitzar Then Call validateControls()
    End Sub
    Private Sub txtSubcompte_textChanged(sender As Object, e As EventArgs) Handles txtSubcompteCompres.TextChanged
        Dim descripcio As String
        If txtSubcompteCompres.Text.Length = 7 Then
            descripcio = ModelSubcompte.getDescripcio(, txtSubcompteCompres.Text)
            If descripcio = "" Then
                Me.lblErrorSubcompteCompres.Text = "ERROR: Subcompte no Existeix"
                Me.lblErrorSubcompteCompres.ForeColor = Color.Red
                Me.cmdGuardar.Enabled = False
            Else
                Me.lblErrorSubcompteCompres.Text = descripcio
                If actualitzar Then
                    Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SUBCOMPTE_TRANSITORIA_COMPRES, Me.txtSubcompteCompres.Text)
                End If
                Me.lblErrorSubcompteCompres.ForeColor = Color.Blue
                Call validateControls()
            End If
        Else
            Call validateControls()
        End If
    End Sub
    Private Sub txtSubcompteVendes_textChanged(sender As Object, e As EventArgs) Handles txtSubcompteVendes.TextChanged
        Dim descripcio As String
        If txtSubcompteVendes.Text.Length = 7 Then
            descripcio = ModelSubcompte.getDescripcio(, txtSubcompteVendes.Text)
            If descripcio = "" Then
                Me.lblErrorSubcompteVendes.Text = "ERROR: Subcompte no Existeix"
                Me.lblErrorSubcompteVendes.ForeColor = Color.Red
                Me.cmdGuardar.Enabled = False
            Else
                Me.lblErrorSubcompteVendes.Text = descripcio
                If actualitzar Then
                    Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SUBCOMPTE_TRANSITORIA_VENDES, Me.txtSubcompteVendes.Text)
                End If
                Me.lblErrorSubcompteVendes.ForeColor = Color.Blue
                Call validateControls()
            End If
        Else
            Call validateControls()
        End If
    End Sub

    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomFitxerExtorn.KeyPress,
                                                                                              txtNomFitxer.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, sender.Text.Length, 15)
    End Sub
    Private Sub txtData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtData.KeyPress,
                                                                                   txtDataExtorn.KeyPress
        e.KeyChar = VALIDAR.Data(e.KeyChar, sender.text, sender.Text.Length, sender.SelectionStart)
    End Sub
    Private Sub txtInt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubcompteCompres.KeyPress,
                                                                                  txtSubcompteVendes.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, sender.Text.Length, 7)
    End Sub

    Private Sub xecFitxer_CheckedChanged(sender As Object, e As EventArgs) Handles xecFitxer.CheckedChanged
        If actualitzar Then
            If Me.txtNomFitxer.Text <> "" Then Call setData()
            Call validateControls()
        End If
    End Sub

    Private Sub frmExportTransitoriesDBF_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        isUnload = True
        empresaActual = Nothing
        assentamentActual = Nothing
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim errNom As Boolean
        If StrComp(Me.txtNomFitxer.Text, "diario", vbTextCompare) = 0 Then
            Call ERRORS.ERR_NOM_FITXER_DBF()
            errNom = True
        End If
        If StrComp(Me.txtNomFitxerExtorn.Text, "diario", vbTextCompare) = 0 Then
            Call ERRORS.ERR_NOM_FITXER_EXTORN_DBF()
            errNom = True
        End If
        If Not errNom Then
            Call getData()
            isUnload = False
            Me.Hide()
        End If
    End Sub


    Private Sub dAssentamentTransitories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empresaActual = New Empresa
        Call setEmpreses()
        Call setDirectori()
        Call setDataSubcomptes()
        Call setLanguage()
    End Sub
End Class
