Option Explicit On
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class dImportUtes
    Private empresaActual As Empresa
    Private actualitzar As Boolean
    Private isZamora As Boolean
    Private Const ANY_INICIAL As Integer = 2015
    Private rutaFitxer As String
    Public Function getDadesZamora() As CentresGB
        If Not setEmpresa(CONFIG.getCodiZamora) Then
            Call ERRORS.ERR_NO_EXIST_ZAMORA()
            getDadesZamora = Nothing
        Else
            isZamora = True
            Me.Text = IDIOMA.getString("importDataZamora")
            Me.lblRutaDiari.Text = IDIOMA.getString("guardarDadesA") & " " & CONFIG.getPathDiarioServidor(empresaActual.codi, 0)
            Call setAnys()
            Call setRutaFitxer()
            Call validateControls()
            Me.ShowDialog()
            If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
                getDadesZamora = getData()
            Else
                getDadesZamora = Nothing
            End If
        End If
        Me.Close()
    End Function
    Public Function getDadesAndorra() As CentresGB
        If Not setEmpresa(CONFIG.getCodiAndorra) Then
            Call ERRORS.ERR_NO_EXIST_ANDORRA()
            getDadesAndorra = Nothing
        Else
            isZamora = False
            Me.Text = IDIOMA.getString("importDataAndorra")
            Me.lblRutaDiari.Text = IDIOMA.getString("guardarDadesA") & CONFIG.getPathDiarioServidor(empresaActual.codi, 0)
            Call setAnys()
            Call setRutaFitxer() ' FITXER XLS
            Call validateControls()
            Me.ShowDialog()

            If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
                getDadesAndorra = getData()
            Else
                getDadesAndorra = Nothing
            End If
        End If
        Me.Close()
    End Function
    Private Sub setLanguage()
        Me.lblAny.Text = IDIOMA.getString("anyo")
        Me.lblMes.Text = IDIOMA.getString("mes")
        Me.lblErrAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrMes.Text = IDIOMA.getString("campObligatori")
        Me.lblErrRutaXls.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdImportar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.xecAny.Text = IDIOMA.getString("totAny")
        Me.xecLog.Text = IDIOMA.getString("mostrarLog")
    End Sub
    Private Function setEmpresa(codi As String) As Boolean
        empresaActual = ModelEmpresa.getObject(codi)
        setEmpresa = True
        If empresaActual Is Nothing Then setEmpresa = False
    End Function
    Private Sub setAnys()
        Dim i As Integer
        actualitzar = False
        cbAny.Items.Clear()
        For i = ANY_INICIAL To Year(Now)
            cbAny.Items.Add(i)
        Next i
        actualitzar = True
        cbAny.SelectedIndex = getIndexAny()
        Call validateControls()
    End Sub
    Private Function getIndexAny()
        Dim i As Integer
        getIndexAny = -1
        For i = 0 To cbAny.Items.Count - 1
            If cbAny.Items(i).ToString = CONFIG_FILE.getTag(CONFIG_FILE.TAG.ANY_ACTUAL_UTE) Then
                getIndexAny = i
                Exit For
            End If
        Next i
    End Function
    Private Sub setMesos()
        Dim i As Integer
        actualitzar = False
        cbMes.Items.Clear()
        For i = 1 To 12
            cbMes.Items.Add(CONFIG.mesNom(i))
        Next i
        actualitzar = True
        cbMes.SelectedIndex = getIndexMes()
    End Sub
    Private Function getIndexMes()
        Dim i As Integer
        getIndexMes = -1
        For i = 0 To cbMes.Items.Count - 1
            If i + 1 = Val(CONFIG_FILE.getTag(CONFIG_FILE.TAG.MES_ACTUAL_UTE)) Then
                getIndexMes = i
                Exit For
            End If
        Next i
    End Function

    Private Sub setRutaFitxer()
        Dim fBrowser As Directori
        If isZamora Then
            rutaFitxer = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_FITXER_ZAMORA)
            fBrowser = New Directori(rutaFitxer, IDIOMA.getString("escollirFitxerZamora"), IDIOMA.getString("dadesZamora") & "(*.xls*)|*.xls*")
        Else
            rutaFitxer = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_FITXER_ANDORRA)
            fBrowser = New Directori(rutaFitxer, IDIOMA.getString("escollirFitxerAndorra"), IDIOMA.getString("dadesAndorra") & "(*.xls*)|*.xls*")
        End If
        fBrowser.Dock = DockStyle.Fill
        PanelRuta.Controls.Clear()
        PanelRuta.Controls.Add(fBrowser)
        AddHandler fBrowser.selectObject, AddressOf getRutaFitxer
        fBrowser.Show()
    End Sub
    Private Sub getRutaFitxer(t As String)
        rutaFitxer = t
        Call validateControls()
    End Sub
    Private Sub validateControls()
        cbAny.Enabled = True
        cbMes.Enabled = True
        Me.lblErrAny.Visible = False
        Me.lblErrMes.Visible = False
        Me.lblErrRutaXls.Visible = False
        Me.cmdGuardar.Enabled = True
        If cbAny.SelectedIndex = -1 Then
            cbMes.Enabled = False
            Me.lblErrAny.Visible = True
            Me.cmdGuardar.Enabled = False
        End If

        If Not CONFIG.fileExist(rutaFitxer) Then
            Me.lblErrRutaXls.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If xecAny.Checked Then
            Me.cbMes.Enabled = False
            Me.lblErrMes.Visible = False
            actualitzar = False
            Me.cbMes.SelectedIndex = -1
            actualitzar = True
        Else
            If cbMes.SelectedIndex = -1 Then
                Me.lblErrMes.Visible = True
                Me.cmdGuardar.Enabled = False
            End If
        End If
    End Sub
    Private Function getData() As CentresGB
        getData = New CentresGB
        getData.anyActual = cbAny.SelectedItem
        getData.rutaGB = rutaFitxer
        If xecAny.Checked Then
            getData.mesActual = -1
        Else
            getData.mesActual = cbMes.SelectedIndex + 1
        End If
        getData.isLog = xecLog.Checked
    End Function

    Private Sub cbAny_Change()
        If actualitzar Then
            If cbAny.SelectedIndex > -1 Then
                Call setMesos()
            Else
                actualitzar = False
                cbMes.Items.Clear()
                actualitzar = True
            End If
            Call validateControls()
        End If
    End Sub
    Private Sub cbMes_Change()
        If actualitzar Then
            Call validateControls()
        End If
    End Sub
    Private Sub xecTotAny_Click()
        If actualitzar Then Call validateControls()
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbAny_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAny.SelectedIndexChanged
        If actualitzar Then
            If cbAny.SelectedIndex > -1 Then
                Call setMesos()
            Else
                actualitzar = False
                cbMes.Items.Clear()
                actualitzar = True
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub dImportUtes_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If cbAny.SelectedIndex > -1 Then Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.ANY_ACTUAL_UTE, cbAny.SelectedItem)
        If cbMes.SelectedIndex > -1 Then Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.MES_ACTUAL_UTE, cbMes.SelectedIndex + 1)
        If isZamora Then
            If fileExist(rutaFitxer) Then Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_FITXER_ZAMORA, rutaFitxer)
        Else
            If fileExist(rutaFitxer) Then Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_FITXER_ANDORRA, rutaFitxer)
        End If
    End Sub

    Private Sub dImportUtes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub
End Class
