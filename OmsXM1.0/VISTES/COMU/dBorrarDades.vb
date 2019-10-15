Option Explicit On
Imports System.Windows.Forms
Public Class dBorrarDades
    Private empresaActual As Empresa
    Private actualitzar As Boolean
    Private borrar As Integer
    Private tipusDades As String
    Public Function getCentres() As CentresGB
        Call setEmpreses()
        tipusDades = IDIOMA.getString("dadesDeDetall")
        Call validateControls()
        borrar = 1
        Me.Text = IDIOMA.getString("esborrarDadesDetall")
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getCentres = getData()
            Me.Close()
        Else
            getCentres = Nothing
            Me.Close()
        End If
        empresaActual = Nothing
    End Function
    Public Function getProjectes() As CentresGB
        Call setEmpreses()
        Call validateControls()
        tipusDades = IDIOMA.getString("transitories")
        borrar = 2
        Me.Text = IDIOMA.getString("esborrarDadesTransitories")
        Me.ShowDialog()

        If Me.DialogResult = DialogResult.OK Then
            getProjectes = getDataProjecte()
            Me.Close()
        Else
            getProjectes = Nothing
            Me.Close()
        End If
    End Function
    Public Function getCentresBudget() As CentresGB
        Call setEmpreses()
        Call validateControls()
        borrar = 0
        tipusDades = IDIOMA.getString("dadesBudget")
        Me.Text = IDIOMA.getString("esborrarDadesBudget")
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getCentresBudget = getData()
        Else
            getCentresBudget = Nothing
        End If
        Me.Close()
    End Function

    Public Function getProjectesBudget() As CentresGB
        Call setEmpreses()
        Call validateControls()
        borrar = 0
        tipusDades = IDIOMA.getString("dadesBudget")
        Me.Text = IDIOMA.getString("esborrarDadesBudget")
        Me.Show()

        If Me.DialogResult = DialogResult.OK Then
            getProjectesBudget = getDataProjecte()
            Me.Close()
        Else
            getProjectesBudget = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setLanguage()
        Me.lblAny.Text = IDIOMA.getString("any")
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblMes.Text = IDIOMA.getString("mes")
        Me.xecAny.Text = IDIOMA.getString("totAny")
        Me.xecLog.Text = IDIOMA.getString("mostrarLog")
        Me.lblErrorAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorMes.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdEsborrar")
        Me.cmdCancel.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub setEmpreses()
        Dim empreses As List(Of Empresa)
        actualitzar = False
        empreses = ModelEmpresa.getObjects
        cbEmpresa.Items.Clear()
        If empreses.Count > 0 Then cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects(empreses))
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub setAnys()
        Dim dades As List(Of Integer), a As Integer
        actualitzar = False
        dades = ModulActualitzacioGB.getAnyos
        cbAny.Items.Clear()
        cbMes.Items.Clear()
        For Each a In dades
            cbAny.Items.Add(a)
        Next
        If cbAny.Items.Count > 0 Then
            cbAny.SelectedIndex = cbAny.Items.Count - 1
            Call setMesos()
        End If
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub setAnysTransitories()
        Dim dades() As Integer, i As Integer
        actualitzar = False
        dades = ModelTransitoria.getAnyos(empresaActual.id)
        cbAny.Items.Clear()
        cbMes.Items.Clear()
        If UBound(dades) > 0 Then
            For i = LBound(dades) To UBound(dades)
                cbAny.Items.Add(dades(i))
            Next
            cbAny.SelectedIndex = cbAny.Items.Count - 1
            Call setMesosTransitoria()
        End If
        Call validateControls()
        actualitzar = True
    End Sub
    'setAnysBudget
    Private Sub setAnysBudget()
        Dim dades As List(Of Integer)
        actualitzar = False
        dades = ModelBudget.getAnyos(empresaActual.id)
        cbAny.Items.Clear()
        cbMes.Items.Clear()
        If dades.Count > 0 Then
            cbAny.Items.AddRange(CONFIG.getListObjects(dades))
            cbAny.SelectedIndex = cbAny.Items.Count - 1
            Call setMesosBudget()
        End If
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub setMesos()
        Dim mesos As List(Of Mes)
        actualitzar = False
        mesos = ModulActualitzacioGB.getMesos(cbAny.SelectedItem)
        cbMes.Items.Clear()
        If mesos.Count > 0 Then
            cbMes.Items.AddRange(CONFIG.getListObjects(mesos))
            cbMes.SelectedIndex = cbMes.Items.Count - 1
        End If
        Call validateControls()
        actualitzar = True
        mesos = Nothing
    End Sub
    Private Sub setMesosTransitoria()
        Dim mesos As List(Of Mes)
        actualitzar = False
        mesos = ModelTransitoria.getMesos(empresaActual.id, cbAny.SelectedItem)
        cbMes.Items.Clear()
        If mesos.Count > 0 Then
            cbMes.Items.AddRange(CONFIG.getListObjects(mesos))
            cbMes.SelectedIndex = cbMes.Items.Count - 1
        End If
        Call validateControls()
        actualitzar = True
        mesos = Nothing
    End Sub
    Private Sub setMesosBudget()
        Dim m As Integer
        actualitzar = False
        cbMes.Items.Clear()
        For m = 1 To 12
            cbMes.Items.Add(New Mes(m, mesNom(m)))
        Next m
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub validateControls()
        cbAny.Enabled = True
        cbMes.Enabled = True
        Me.lblErrorAny.Visible = False
        Me.lblErrorEmpresa.Visible = False
        Me.lblErrorMes.Visible = False
        Me.cmdGuardar.Enabled = True
        If cbEmpresa.SelectedIndex = -1 Then
            cbAny.Enabled = False
            cbMes.Enabled = False
            Me.cmdGuardar.Enabled = False
            Me.lblErrorEmpresa.Visible = True
        End If
        If cbAny.SelectedIndex = -1 Then
            cbMes.Enabled = False
            Me.lblErrorAny.Visible = True
            Me.cmdGuardar.Enabled = False
        End If

        If xecAny.Checked Then
            Me.cbMes.Enabled = False
            Me.lblErrorMes.Visible = False
            actualitzar = False
            Me.cbMes.SelectedIndex = -1
            actualitzar = True
        Else
            If cbMes.SelectedIndex = -1 Then
                Me.lblErrorMes.Visible = True
                Me.cmdGuardar.Enabled = False
            End If
        End If
    End Sub
    Private Function getData() As CentresGB
        getData = New CentresGB
        getData.anyActual = cbAny.SelectedItem
        If Me.xecAny.Checked Then
            getData.mesActual = -1
        Else
            getData.mesActual = cbMes.SelectedItem.num
        End If
        getData.centres = DSelectCentres.getCentres(empresaActual.id, IDIOMA.getString("selectCentres"))
        getData.isLog = Me.xecLog.Checked
        If getData.centres Is Nothing Then getData = Nothing
    End Function
    Private Function getDataProjecte() As CentresGB
        getDataProjecte = New CentresGB
        getDataProjecte.anyActual = cbAny.SelectedItem
        If xecAny.Checked Then
            getDataProjecte.mesActual = -1
        Else
            getDataProjecte.mesActual = cbMes.SelectedItem.num
        End If
        getDataProjecte.projectes = DProjectes.selectProjectes(4, empresaActual.id)
        getDataProjecte.isLog = xecLog.Checked
        If getDataProjecte.projectes Is Nothing Then getDataProjecte = Nothing
    End Function


    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = ModelEmpresa.getObject(cbEmpresa.SelectedItem.id)
                If borrar = 1 Then
                    Call setAnys()
                ElseIf borrar = 2 Then
                    Call setAnysTransitories()
                Else
                    Call setAnysBudget()
                End If
            Else
                actualitzar = False
                cbAny.Items.Clear()
                cbMes.Items.Clear()
                actualitzar = True
            End If
            Call validateControls()
        End If
    End Sub
    Private Sub cbAny_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAny.SelectedIndexChanged
        If actualitzar Then
            If cbAny.SelectedIndex > -1 Then
                If borrar = 1 Then
                    Call setMesos()
                ElseIf borrar = 2 Then
                    Call setMesosTransitoria()
                Else
                    Call setMesosBudget()
                End If
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
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Dim mesTancat As Boolean, m As Integer
        If borrar > 0 Then
            If cbMes.SelectedIndex = -1 Then
                For m = 1 To 12
                    If borrar = 2 Then
                        mesTancat = ModelEstatMes.getEstatTransitoria(empresaActual.id, cbAny.SelectedItem, m)
                    ElseIf borrar = 1 Then
                        mesTancat = ModelEstatMes.getEstat(empresaActual.id, cbAny.SelectedItem, m)
                    End If
                    If mesTancat Then Exit For
                Next m
            Else
                If borrar = 2 Then
                    mesTancat = ModelEstatMes.getEstatTransitoria(empresaActual.id, cbAny.SelectedItem, cbMes.SelectedItem.num)
                ElseIf borrar = 1 Then
                    mesTancat = ModelEstatMes.getEstat(empresaActual.id, cbAny.SelectedItem, cbMes.SelectedItem.num)
                End If
            End If
        End If
        If Not mesTancat Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()
        Else
            If borrar = 2 Then
                Call ERRORS.ERR_BORRAR_MES_TRANSITORIA_TANCADA()
            Else
                Call ERRORS.ERR_BORRAR_MES_TANCAT()
            End If
        End If
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub xecAny_CheckedChanged(sender As Object, e As EventArgs) Handles xecAny.CheckedChanged
        If actualitzar Then Call validateControls()
    End Sub



    Private Sub dBorrarDades_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setLanguage()
    End Sub
End Class
