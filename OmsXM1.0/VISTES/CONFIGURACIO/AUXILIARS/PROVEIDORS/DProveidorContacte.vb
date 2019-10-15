Imports System.Windows.Forms

Public Class DProveidorContacte
    Private contacteActual As ProveidorCont
    Private paisos As lstAuxiliars1
    Private provincies As lstAuxiliars1
    Private elements As List(Of String)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        elements = getControls()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function getProveidor(pProveidor As ProveidorCont) As ProveidorCont
        contacteActual = pProveidor

        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            Return getData()
        Else
            Return Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblDepartament.Text = IDIOMA.getString("departament")
        Me.lblCodiPostal.Text = IDIOMA.getString("cp")
        Me.lblDireccio.Text = IDIOMA.getString("direccio")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNomFiscal.Text = IDIOMA.getString("nomFiscal")
        Me.lblPoblacio.Text = IDIOMA.getString("poblacio")
        Me.lblProvincia.Text = IDIOMA.getString("provincia")
        Me.lblPais.Text = IDIOMA.getString("pais")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.lblTel1.Text = IDIOMA.getString("telefon") & "1"
        Me.lblTel2.Text = IDIOMA.getString("telefon") & "2"
        Me.lblemail.Text = IDIOMA.getString("email")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        If contacteActual.id > -1 Then
            Me.Text = IDIOMA.getString("modificarContacteProveidor")
        Else
            Me.Text = IDIOMA.getString("afegirNouContacteProveidor")
        End If
    End Sub

    Private Sub setData()
        provincies = New lstAuxiliars1(contacteActual.provincia, DBCONNECT.getTaulaProvincia, IDIOMA.getString("afegirProvincia"))
        paisos = New lstAuxiliars1(contacteActual.pais, DBCONNECT.getTaulaPais)
        pProvincia.Controls.Clear()
        pPais.Controls.Clear()
        provincies.Dock = DockStyle.Fill
        paisos.Dock = DockStyle.Fill
        pProvincia.Controls.Add(provincies)
        pPais.Controls.Add(paisos)
        Me.lblId.Text = contacteActual.id
        Me.txtDepartament.Text = contacteActual.departament
        Me.txtCodiPostal.Text = contacteActual.codiPostal
        Me.txtDireccio.Text = contacteActual.direccio
        Me.txtNom.Text = contacteActual.nom
        Me.txtPoblacio.Text = contacteActual.poblacio
        Me.txtTelefon1.Text = contacteActual.telefon1
        Me.txtTelefon2.Text = contacteActual.telefon2
        Me.txtEmail.Text = contacteActual.email
        Me.txtNotes.Text = contacteActual.notes
        Me.xecActiu.Checked = contacteActual.actiu
    End Sub
    'Private Function indexPais() As Integer

    'End Function
    'Private Function indexProvincia() As Integer

    'End Function
    'Private Function indexPagament() As Integer

    'End Function

    Private Function getData() As ProveidorCont
        getData = contacteActual.copy
        getData.departament = Me.txtDepartament.Text
        getData.codiPostal = Me.txtCodiPostal.Text
        getData.direccio = Me.txtDireccio.Text
        getData.nom = Me.txtNom.Text
        getData.poblacio = Me.txtPoblacio.Text
        getData.pais = paisos.obj
        getData.provincia = provincies.obj
        getData.telefon1 = Me.txtTelefon1.Text
        getData.telefon2 = Me.txtTelefon2.Text
        getData.email = Me.txtEmail.Text
        getData.notes = Me.txtNotes.Text
        getData.actiu = Me.xecActiu.Checked
        If getData.pais Is Nothing Then getData.pais = ModelPais.getAuxiliar.getObject(0)
        If getData.provincia Is Nothing Then getData.provincia = ModelProvincia.getAuxiliar.getObject(0)
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub
    Private Sub DProveidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()
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
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDepartament.KeyDown,
                                                                         txtNom.KeyDown,
                                                                         txtNotes.KeyDown,
                                                                         txtDireccio.KeyDown,
                                                                         txtPoblacio.KeyDown,
                                                                         txtCodiPostal.KeyDown,
                                                                         pProvincia.KeyDown,
                                                                         pPais.KeyDown,
                                                                         txtEmail.KeyDown,
                                                                         txtTelefon1.KeyDown,
                                                                         txtTelefon2.KeyDown,
                                                                         xecActiu.KeyDown


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
        getControls.Add(txtDepartament.Name)
        getControls.Add(txtNom.Name)
        getControls.Add(txtDireccio.Name)
        getControls.Add(txtPoblacio.Name)
        getControls.Add(txtCodiPostal.Name)
        getControls.Add(pProvincia.Name)
        getControls.Add(pPais.Name)
        getControls.Add(txtTelefon1.Name)
        getControls.Add(txtTelefon2.Name)
        getControls.Add(txtEmail.Name)
        getControls.Add(xecActiu.Name)
        getControls.Add(txtNotes.Name)
        getControls.Add(cmdGuardar.Name)
        getControls.Add(cmdCancelar.Name)
    End Function
    Protected Overrides Sub Finalize()
        contacteActual = Nothing
        paisos = Nothing
        provincies = Nothing
        MyBase.Finalize()
    End Sub
End Class
