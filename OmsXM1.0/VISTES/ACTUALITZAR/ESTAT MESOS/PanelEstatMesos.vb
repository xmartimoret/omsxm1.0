Option Explicit On
Imports vb = Microsoft.VisualBasic
Public Class PanelEstatMesos
    Private actualitzar As Boolean
    Private empresaActual As Empresa
    Private mesActual As EstatMes
    Private anyActual As Integer
    Private Const ANY_INICIAL As Integer = 2016
    Private Sub setLanguage()
        Dim i As Integer
        Me.lblAny.Text = IDIOMA.getString("anyo")
        Me.lblErrAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.lblEmpreses.Text = IDIOMA.getString("empresa")
        Me.lblMes1.Text = IDIOMA.getString("mes")
        Me.lblMes2.Text = IDIOMA.getString("mes")
        Me.lblTransitoria1.Text = IDIOMA.getString("transitoria")
        Me.lblTransitoria2.Text = IDIOMA.getString("transitoria")
        Me.cmdTancar.Text = IDIOMA.getString("cmdTancar")

    End Sub
    Private Sub setEmpreses()
        actualitzar = False
        Me.lstEmpreses.Items.Clear()
        Me.lstEmpreses.Items.AddRange(ModelEmpresa.getListObjects)
        Call validateControls()
        actualitzar = True
    End Sub
    Private Sub validateControls()
        actualitzar = False
        Me.lblErrAny.Visible = False
        Me.lblErrEmpresa.Visible = False
        Me.Panel1.Visible = True
        cbAny.Enabled = True
        If lstEmpreses.SelectedIndex = -1 Then
            Me.Panel1.Visible = False
            Me.lblErrEmpresa.Visible = True
        End If
        If Me.cbAny.SelectedIndex = -1 Then
            Me.Panel1.Visible = False
            Me.lblErrAny.Visible = True
        End If
        actualitzar = True
    End Sub
    Private Sub setAnys()
        Dim i As Integer
        actualitzar = False
        cbAny.Items.Clear()
        For i = ANY_INICIAL To Year(Now)
            cbAny.Items.Add(i)
        Next i
        actualitzar = True
        cbAny.SelectedIndex = getIndexAny()
    End Sub
    Private Function getIndexAny()
        Dim i As Integer
        getIndexAny = -1
        For i = 0 To cbAny.Items.Count - 1
            If cbAny.Items(i) = anyActual Then
                getIndexAny = i
                Exit For
            End If
        Next i
    End Function

    Private Sub setMesos()
        Dim mesos As List(Of EstatMes), m As EstatMes
        Call ModelEstatMes.actualitzar(empresaActual.id, anyActual)
        mesos = ModelEstatMes.getObjects(empresaActual.id, anyActual)
        actualitzar = False
        For Each m In mesos
            If m.estat Then
                Me.Panel1.Controls(CStr("xecM" & m.mes)).Text = IDIOMA.getString("estatTancat")
            Else
                Me.Panel1.Controls(CStr("xecM" & m.mes)).Text = IDIOMA.getString("estatObert")
            End If
            If m.estatTransitoria Then
                Me.Panel1.Controls(CStr("xecT" & m.mes)).Text = IDIOMA.getString("estatTancada")
            Else
                Me.Panel1.Controls(CStr("xecT" & m.mes)).Text = IDIOMA.getString("estatOberta")
            End If
            Select Case (m.mes)
                Case 1
                    Me.xecM1.Checked = m.estat
                    Me.xecT1.Checked = m.estatTransitoria
                Case 2
                    Me.xecM2.Checked = m.estat
                    Me.xecT2.Checked = m.estatTransitoria
                Case 3
                    Me.xecM3.Checked = m.estat
                    Me.xecT3.Checked = m.estatTransitoria
                Case 4
                    Me.xecM4.Checked = m.estat
                    Me.xecT4.Checked = m.estatTransitoria
                Case 5
                    Me.xecM5.Checked = m.estat
                    Me.xecT5.Checked = m.estatTransitoria
                Case 6
                    Me.xecM6.Checked = m.estat
                    Me.xecT6.Checked = m.estatTransitoria
                Case 7
                    Me.xecM7.Checked = m.estat
                    Me.xecT7.Checked = m.estatTransitoria
                Case 8
                    Me.xecM8.Checked = m.estat
                    Me.xecT8.Checked = m.estatTransitoria
                Case 9
                    Me.xecM9.Checked = m.estat
                    Me.xecT9.Checked = m.estatTransitoria
                Case 10
                    Me.xecM10.Checked = m.estat
                    Me.xecT10.Checked = m.estatTransitoria
                Case 11
                    Me.xecM11.Checked = m.estat
                    Me.xecT11.Checked = m.estatTransitoria
                Case 12
                    Me.xecM12.Checked = m.estat
                    Me.xecT12.Checked = m.estatTransitoria
            End Select

        Next m
        actualitzar = True
        mesos = Nothing
    End Sub
    Private Sub setMes(m As Integer)
        Dim tempAny As Integer, mesAnterior As Integer, mesSeguent As Integer, tempAnySeguent As Integer
        If m = 1 Then
            tempAny = anyActual - 1
            mesAnterior = 12
        Else
            tempAny = anyActual
            mesAnterior = m - 1
        End If
        If m = 12 Then
            tempAnySeguent = anyActual + 1
            mesSeguent = 1
        Else
            tempAnySeguent = anyActual
            mesSeguent = m + 1
        End If
        mesActual = ModelEstatMes.getObject(empresaActual.id, anyActual, m)
        If Not mesActual.estat Then
            ' ens cal comprovar si es pot obrir.
            ' perque es pugui obrir  ha de passar que no hihagi un mes posterior  que estigui tancat tancar
            If ModelEstatMes.getEstat(empresaActual.id, tempAny, mesAnterior) Or (anyActual = ANY_INICIAL And m = 1) Then
                If ModulActualitzacioGB.existEmpresaMes(anyActual, empresaActual.id, m) Then
                    If mesActual.estatTransitoria Then
                        If MISSATGES.CONFIRM_CLOSE_MONTH(m, anyActual, empresaActual) Then
                            mesActual.estat = True
                            Call ModelEstatMes.save(mesActual)
                        End If
                    Else
                        Call ERRORS.ERR_MES_NO_TRANSI()
                    End If
                Else
                    Call ERRORS.ERR_MES_NO_DETALLS()
                End If
            Else
                Call ERRORS.ERR_MES_ANTERIOR_OBERT()
            End If
        Else
            ' ens cal comprovar si es pot tancat.
            'perquè es pugui tancar ha de passar que hi ha detalls, i que no hi hagi un mes anterior obert
            If Not ModelEstatMes.getEstat(empresaActual.id, tempAnySeguent, mesSeguent) Then
                If MISSATGES.CONFIRM_REOPEN_MONTH(m, anyActual, empresaActual) Then
                    mesActual.estat = False
                    Call ModelEstatMes.save(mesActual)

                End If
            Else
                Call ERRORS.ERR_MES_SEGUENT_TANCAT()
            End If
        End If
        Call setMesos()
    End Sub
    Private Sub setTransitories(m As Integer)
        Dim tempAny As Integer, mesAnterior As Integer, mesSeguent As Integer, tempAnySeguent As Integer
        If m = 1 Then
            tempAny = anyActual - 1
            mesAnterior = 12
        Else
            tempAny = anyActual
            mesAnterior = m - 1
        End If
        If m = 12 Then
            tempAnySeguent = anyActual + 1
            mesSeguent = 1
        Else
            tempAnySeguent = anyActual
            mesSeguent = m + 1
        End If
        mesActual = ModelEstatMes.getObject(empresaActual.id, anyActual, m)
        If Not mesActual.estatTransitoria Then
            If ModelEstatMes.getEstat(empresaActual.id, tempAny, mesAnterior) Or (anyActual = ANY_INICIAL And m = 1) Then
                If MISSATGES.CONFIRM_CLOSE_TRANSITORIA(m, anyActual, empresaActual) Then
                    mesActual.estatTransitoria = True
                    Call ModelEstatMes.save(mesActual)
                End If
            Else
                Call ERRORS.ERR_MES_ANTERIOR_OBERT()
            End If
        Else
            If Not mesActual.estat Then
                If MISSATGES.CONFIRM_REOPEN_TRANSITORIA(m, anyActual, empresaActual) Then
                    mesActual.estatTransitoria = False
                    Call ModelEstatMes.save(mesActual)

                End If
            Else
                Call ERRORS.ERR_MES_ACTUAL_TANCAT()
            End If
        End If
        Call setMesos()
    End Sub

    Private Sub cbAny_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAny.SelectedIndexChanged
        If actualitzar Then
            If cbAny.SelectedIndex > -1 Then
                anyActual = cbAny.SelectedItem
                For i As Integer = 1 To 12
                    Me.Panel1.Controls(CStr("lbl" & i)).Text = CONFIG.mesNom(i) & Chr(10) & anyActual
                Next
                Call setMesos()
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub lstEmpreses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEmpreses.SelectedIndexChanged
        If actualitzar Then
            If lstEmpreses.SelectedIndex > -1 Then
                empresaActual = ModelEmpresa.getObject(lstEmpreses.SelectedItem.id)
                anyActual = ModelEstatMes.getAnyEnCurs(empresaActual.id)
                Call setAnys()
            Else
                empresaActual = New Empresa
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub cmdTancar_Click(sender As Object, e As EventArgs) Handles cmdTancar.Click
        Call FrmApliOms.resetPanel()
    End Sub

    Private Sub PanelEstatMesos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empresaActual = New Empresa
        Call setLanguage()
        Call ModelEstatMes.reset()
        Call setEmpreses()
        Call setAnys()
    End Sub

    Private Sub xecT_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles xecT1.MouseDown, xecT2.MouseDown, xecT3.MouseDown,
                xecT4.MouseDown, xecT5.MouseDown, xecT6.MouseDown,
                xecT7.MouseDown, xecT8.MouseDown, xecT9.MouseDown,
                xecT10.MouseDown, xecT11.MouseDown, xecT12.MouseDown
        If actualitzar Then
            If IsNumeric(vb.Right(sender.name, 2)) Then
                Call setTransitories(vb.Right(sender.name, 2))
            Else
                Call setTransitories(vb.Right(sender.name, 1))
            End If
        End If
    End Sub
    Private Sub xec_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles xecM1.MouseDown, xecM2.MouseDown, xecM3.MouseDown,
                xecM4.MouseDown, xecM5.MouseDown, xecM6.MouseDown,
                xecM7.MouseDown, xecM8.MouseDown, xecM9.MouseDown,
                xecM10.MouseDown, xecM11.MouseDown, xecM12.MouseDown
        If actualitzar Then
            If IsNumeric(vb.Right(sender.name, 2)) Then
                Call setMes(vb.Right(sender.name, 2))
            Else
                Call setMes(vb.Right(sender.name, 1))
            End If
        End If
    End Sub

End Class
