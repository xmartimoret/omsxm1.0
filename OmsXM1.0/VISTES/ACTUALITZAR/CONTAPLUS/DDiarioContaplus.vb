Imports System.Windows.Forms

Public Class DDiarioContaplus
    Private empresaActual As Empresa
    Private contaplusActual As Contaplus
    Private actualitzar As Boolean
    Private Sub setEmpreses()
        Dim empreses As List(Of Empresa)
        actualitzar = False
        empreses = ModelEmpresa.getObjectsContaplus
        If empreses.Count > 0 Then
            cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects(empreses))
        End If
        actualitzar = True
        empreses = Nothing
    End Sub
    Private Sub setAnys()
        Dim pDiarios As SelectDiario
        pDiarios = New SelectDiario(empresaActual.id, IDIOMA.getString("empresesContaplus"), 1)
        pDiarios.Dock = DockStyle.Fill
        PanelDiario.Controls.Clear()
        PanelDiario.Controls.Add(pDiarios)
        AddHandler pDiarios.selectObject, AddressOf setContaplus
        PanelDiario.Show()
    End Sub
    Private Sub setContaplus(c As Contaplus)
        contaplusActual = c
        Call validateControls()
    End Sub
    Private Sub validateControls()
        cmdGuardar.Enabled = True
        If cbEmpresa.SelectedIndex = -1 Then
            cmdGuardar.Enabled = False
            lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioErrEmpresa")
            Me.lblAvis.ForeColor = Color.Red
        Else
            If contaplusActual.id > -1 Then
                If CONFIG.fileExist(CONFIG.getPathDiarioContaplus(contaplusActual.nom)) Then
                    If CONFIG.fileExist(CONFIG.getPathDiarioServidor(empresaActual.codi, contaplusActual.anyo)) Then
                        If CONFIG.getDateFileModified(CONFIG.getPathDiarioServidor(empresaActual.codi, contaplusActual.anyo)) <>
                           CONFIG.getDateFileModified(CONFIG.getPathDiarioContaplus(contaplusActual.nom)) Then
                            lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioActualitzar")
                            Me.lblAvis.ForeColor = Color.Red
                        Else
                            lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioActualitzat")
                            cmdGuardar.Enabled = False
                            Me.lblAvis.ForeColor = Color.Green
                        End If
                    Else
                        lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioActualitzar")
                        Me.lblAvis.ForeColor = Color.Red
                    End If
                Else
                    lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioErrFitxerContaplus")
                    Me.lblAvis.ForeColor = Color.Red

                    cmdGuardar.Enabled = False
                End If
            Else
                lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioErrContaplus")
                Me.lblAvis.ForeColor = Color.Red

                cmdGuardar.Enabled = False
            End If
        End If
        Application.DoEvents()
    End Sub

    Private Sub CopiarFitxer()
        On Error GoTo err1
        If MISSATGES.CONFIRM_COPYFILE(CONFIG.getPathDiarioContaplus(contaplusActual.nom), CONFIG.getPathDiarioServidor(empresaActual.codi, contaplusActual.anyo)) Then
            Me.lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioCopiantFitxer")
            Me.lblAvis.Visible = True
            Application.DoEvents()
            Call habilitar(False)
            Me.lblAvis.ForeColor = Color.Red
            Call FileCopy(CONFIG.getPathDiarioContaplus(contaplusActual.nom), CONFIG.getPathDiarioServidor(empresaActual.codi, contaplusActual.anyo))
            Call FileCopy(CONFIG.getPathSubctaContaplus(contaplusActual.nom), CONFIG.getPathSubctaServidor(empresaActual.codi, contaplusActual.anyo))
            Call FileCopy(CONFIG.getPathProyeContaplus(contaplusActual.nom), CONFIG.getPathProyeServidor(empresaActual.codi, contaplusActual.anyo))
            Call MISSATGES.FILE_UPDATED()
            Me.lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioFitxerActualitzat")
            Me.lblAvis.ForeColor = Color.Green
            Call habilitar(True)
        End If
        Exit Sub
err1:
        If Err.Number = 70 Then
            Call ERRORS.ERR_FITXER_DIARIO_OBERT()
            Me.lblAvis.ForeColor = Color.Red
            Me.lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioErrCopiat")
        Else
            Call MsgBox(Err.Description, vbCritical, "ERROR Nº " & Err.Number)
            Me.lblAvis.Text = IDIOMA.getString("actualitzarFitxerDiarioErrCopiat")
        End If
        Call habilitar(True)
        Err.Clear()
        Err.Number = 0
    End Sub
    Private Sub setLanguage()
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdSortir")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdCopiar")
        Me.Text = IDIOMA.getString("dDiarioContaplusCaption")
    End Sub
    Private Sub habilitar(estat As Boolean)
        Me.cmdCancelar.Enabled = estat
        Me.cmdGuardar.Enabled = estat
        Me.cbEmpresa.Enabled = estat
        Application.DoEvents()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Call CopiarFitxer()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub DDiarioContaplus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setEmpreses()
        contaplusActual = New Contaplus
        Call validateControls()
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

End Class
