Imports System.Windows.Forms

Public Class DProveidor
    Private proveidorActual As Proveidor
    'Private paisos As LstPaisos
    Private paisos As lstAuxiliars1
    Private provincies As lstAuxiliars1
    Private tPagaments As lstAuxiliars1
    Private elements As List(Of String)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        elements = getControls()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function getProveidor(pProveidor As Proveidor) As Proveidor
        proveidorActual = pProveidor
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getProveidor = getData()
        Else
            getProveidor = Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblCif.Text = IDIOMA.getString("cif")
        Me.lblCodiPostal.Text = IDIOMA.getString("cp")
        Me.lblDireccio.Text = IDIOMA.getString("direccio")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.lblErrCif.Text = IDIOMA.getString("campObligatori")
        Me.lblIban1.Text = IDIOMA.getString("iban") & "1"
        Me.lblIban2.Text = IDIOMA.getString("iban") & "2"
        Me.lblIban3.Text = IDIOMA.getString("iban") & "3"
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNomComercial.Text = IDIOMA.getString("nomComercial")
        Me.lblNomFiscal.Text = IDIOMA.getString("nomFiscal")
        Me.lblPoblacio.Text = IDIOMA.getString("poblacio")
        Me.lblProvincia.Text = IDIOMA.getString("provincia")
        Me.lblPais.Text = IDIOMA.getString("pais")
        Me.lblTipusPagament.Text = IDIOMA.getString("tipusPagament")
        Me.gbDadesBancaries.Text = IDIOMA.getString("dadesBancaries")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        Me.lblEmail.Text = IDIOMA.getString("email")
        Me.lblErrCodiComptable.Text = IDIOMA.getString("campObligatori")
        Me.lblCodiComptable.Text = IDIOMA.getString("codiComptable")
        Me.xecNoValidar.Text = IDIOMA.getString("noValidarDocument")
        If proveidorActual.id > -1 Then
            Me.Text = IDIOMA.getString("modificarProveidor")
        Else

            Me.Text = IDIOMA.getString("afegirProveidor")
        End If
    End Sub
    Private Sub validateControls()
        Me.lblErrCif.Visible = False
        Me.lblErrNom.Visible = False
        Me.lblErrCodiComptable.Visible = False
        Me.cmdGuardar.Enabled = True
        If Me.txtCif.Text.Length = 0 Then
            Me.lblErrCif.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtCodiComptable.Text.Length = 0 Then
            Me.lblErrCodiComptable.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtNomFiscal.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Sub setData()
        'Me.cbPais.Items.Clear()
        'Me.cbPais.Items.AddRange(ModelPais.getListObjects)
        'Me.cbProvincia.Items.Clear()
        'Me.cbProvincia.Items.AddRange(ModelProvincia.getListObjects)
        'Me.cbTipusPagament.Items.Clear()
        'Me.cbTipusPagament.Items.AddRange(ModelTipusPagament.getListObjects)
        provincies = New lstAuxiliars1(proveidorActual.provincia, DBCONNECT.getTaulaProvincia, IDIOMA.getString("afegirProvincia"))
        'paisos = New LstPaisos(proveidorActual.pais)
        paisos = New lstAuxiliars1(proveidorActual.pais, DBCONNECT.getTaulaPais)
        tPagaments = New lstAuxiliars1(proveidorActual.tipusPagament, DBCONNECT.getTaulaTipusPagament)
        pProvincia.Controls.Clear()
        pPais.Controls.Clear()
        pTPagament.Controls.Clear()
        provincies.Dock = DockStyle.Fill
        paisos.Dock = DockStyle.Fill
        tPagaments.Dock = DockStyle.Fill
        pProvincia.Controls.Add(provincies)
        pPais.Controls.Add(paisos)
        pTPagament.Controls.Add(tPagaments)
        Me.txtEmail.Text = proveidorActual.email
        Me.lblId.Text = proveidorActual.id
        Me.txtCif.Text = proveidorActual.codi
        Me.txtCodiComptable.Text = proveidorActual.codiComptable

        Me.txtCodiPostal.Text = proveidorActual.codiPostal
        Me.txtDireccio.Text = proveidorActual.direccio
        Me.txtIban1.Text = proveidorActual.iban1
        Me.txtIban2.Text = proveidorActual.iban2
        Me.txtIban3.Text = proveidorActual.iban3
        Me.txtNomComercial.Text = proveidorActual.nom
        Me.txtNomFiscal.Text = proveidorActual.nomFiscal
        Me.txtPoblacio.Text = proveidorActual.poblacio
        Me.xecActiu.Checked = proveidorActual.actiu
    End Sub
    'Private Function indexPais() As Integer

    'End Function
    'Private Function indexProvincia() As Integer

    'End Function
    'Private Function indexPagament() As Integer

    'End Function

    Private Function getData() As Proveidor
        getData = proveidorActual.copy
        getData.codi = Me.txtCif.Text
        getData.codiComptable = Me.txtCodiComptable.Text
        getData.codiPostal = Me.txtCodiPostal.Text
        getData.direccio = Me.txtDireccio.Text
        getData.iban1 = Me.txtIban1.Text
        getData.iban2 = Me.txtIban2.Text
        getData.iban3 = Me.txtIban3.Text
        getData.nom = Me.txtNomComercial.Text
        getData.nomFiscal = Me.txtNomFiscal.Text
        getData.poblacio = Me.txtPoblacio.Text
        getData.pais = Me.paisos.obj
        getData.provincia = Me.provincies.obj
        If getData.pais Is Nothing Then getData.pais = ModelPais.getAuxiliar.getObject(0)
        If getData.provincia Is Nothing Then getData.provincia = ModelProvincia.getAuxiliar.getObject(0)
        getData.email = Me.txtEmail.Text
        getData.tipusPagament = Me.tPagaments.obj
        If getData.tipusPagament Is Nothing Then getData.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(0)
        getData.actiu = Me.xecActiu.Checked
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If Not xecNoValidar.Checked And Not VALIDAR.esDocumentCorrecte(txtCif.Text) Then
            Call ERRORS.ERR_CIF_INCORRECTE()
            txtCif.Select()
        ElseIf ModelProveidor.existCodi(proveidorActual.id, txtCif.Text) Then
            Call ERRORS.ERR_CIF_EXIST()
            txtCif.Select()
        Else
            Me.DialogResult = DialogResult.OK
            Me.Hide()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txtCif_TextChanged(sender As Object, e As EventArgs) Handles txtCif.TextChanged
        Call validateControls()

    End Sub

    Private Sub txtNomFiscal_TextChanged(sender As Object, e As EventArgs) Handles txtNomFiscal.TextChanged
        Call validateControls()
    End Sub

    Private Sub DProveidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()
        Call validateControls()
        txtCif.Select()
    End Sub
    Private Sub getTab(sender As Object, p As Integer)
        Dim i As Integer
        For i = 0 To elements.Count - 1
            If sender.name = elements(i) Then
                Exit For
            End If
        Next
        If i + p = elements.Count Then
            Me.Controls(elements(0)).Select()
        ElseIf i + p < 0 Then
            Me.Controls(elements(elements.Count - 1)).Select()
        Else
            Me.Controls(elements(i + p)).Select()
        End If
    End Sub
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCif.KeyDown,
                                                                         txtCodiComptable.KeyDown,
                                                                         txtNomFiscal.KeyDown,
                                                                         txtNomComercial.KeyDown,
                                                                         txtDireccio.KeyDown,
                                                                         txtPoblacio.KeyDown,
                                                                         txtCodiPostal.KeyDown,
                                                                         pProvincia.KeyDown,
                                                                         pPais.KeyDown,
                                                                         txtEmail.KeyDown,
                                                                         pTPagament.KeyDown,
                                                                         txtIban1.KeyDown,
                                                                         txtIban2.KeyDown,
                                                                         txtIban3.KeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Down Then
            e.Handled = False
            Call SendKeys.Send("{tab}")
        ElseIf e.KeyValue = Keys.Up Then
            e.Handled = False
            Call getTab(sender, -1)
        End If

    End Sub
    Private Function getControls() As List(Of String)
        getControls = New List(Of String)
        getControls.Add(txtCif.Name)
        getControls.Add(txtCodiComptable.Name)
        getControls.Add(txtNomFiscal.Name)
        getControls.Add(txtNomComercial.Name)
        getControls.Add(txtDireccio.Name)
        getControls.Add(txtPoblacio.Name)
        getControls.Add(txtCodiPostal.Name)
        getControls.Add(pProvincia.Name)
        getControls.Add(pPais.Name)
        getControls.Add(txtEmail.Name)
        getControls.Add(pTPagament.Name)
        getControls.Add(txtIban1.Name)
        getControls.Add(txtIban2.Name)
        getControls.Add(txtIban3.Name)
        getControls.Add(cmdGuardar.Name)
        getControls.Add(cmdCancelar.Name)
    End Function

    Protected Overrides Sub Finalize()
        paisos = Nothing
        provincies = Nothing
        tPagaments = Nothing

        MyBase.Finalize()
    End Sub

    Private Sub txtCodiComptable_TextChanged(sender As Object, e As EventArgs) Handles txtCodiComptable.TextChanged
        Call validateControls()
    End Sub

    Private Sub txtIban1_TextChanged(sender As Object, e As EventArgs) Handles txtIban1.TextChanged

    End Sub

    Private Sub cmdImprimirExcel_Click(sender As Object, e As EventArgs) Handles cmdImprimirExcel.Click
        Call modulInfoProveidor.execute(getData, False)
    End Sub

    Private Sub cmdImprimirPDF_Click(sender As Object, e As EventArgs) Handles cmdImprimirPDF.Click
        Call modulInfoProveidor.execute(getData, True)
    End Sub
End Class
