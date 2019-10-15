Imports System.Windows.Forms

Public Class DContacte
    Private contacteActual As Contacte
    Private provincies As lstAuxiliars1
    Private paisos As lstAuxiliars1
    Private elements As List(Of String)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        elements = getControls()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function getContacte(pContacte As Contacte) As Contacte
        contacteActual = pContacte
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            Return getData()
        Else
            Return Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblCodiPostal.Text = IDIOMA.getString("cp")
        Me.lblDireccio.Text = IDIOMA.getString("direccio")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblPoblacio.Text = IDIOMA.getString("poblacio")
        Me.lblProvincia.Text = IDIOMA.getString("provincia")
        Me.lblPais.Text = IDIOMA.getString("pais")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.lblTel1.Text = IDIOMA.getString("telefon")
        Me.lblemail.Text = IDIOMA.getString("email")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        Me.lblCognoms.Text = IDIOMA.getString("cognoms")
        If contacteActual.id > -1 Then
            Me.Text = IDIOMA.getString("modificarContacte") & " " & contacteActual.ToString
        Else
            Me.Text = IDIOMA.getString("afegirContacte")
        End If

    End Sub

    Private Sub setData()

        'Me.cbPais.Items.Clear()
        'Me.cbPais.Items.AddRange(ModelPais.getListObjects)
        'Me.cbProvincia.Items.Clear()
        'Me.cbProvincia.Items.AddRange(ModelProvincia.getListObjects)
        provincies = New lstAuxiliars1(contacteActual.provincia, DBCONNECT.getTaulaProvincia)
        paisos = New lstAuxiliars1(contacteActual.pais, DBCONNECT.getTaulaPais)
        pProvincia.Controls.Clear()
        provincies.Dock = DockStyle.Fill
        pProvincia.Controls.Add(provincies)
        pPais.Controls.Clear()
        paisos.Dock = DockStyle.Fill
        pPais.Controls.Add(paisos)
        Me.lblId.Text = contacteActual.id
        Me.txtCodiPostal.Text = contacteActual.codiPostal
        Me.txtDireccio.Text = contacteActual.direccio
        Me.txtNom.Text = contacteActual.nom
        Me.txtCognom1.Text = contacteActual.cognom1
        Me.txtCognom2.Text = contacteActual.cognom2
        Me.txtPoblacio.Text = contacteActual.poblacio
        Me.txtTelefon1.Text = contacteActual.telefon
        Me.txtemail.Text = contacteActual.email
        Me.txtNotes.Text = contacteActual.notes
        Me.xecActiu.Checked = contacteActual.estat
    End Sub
    'Private Function indexPais() As Integer

    'End Function
    'Private Function indexProvincia() As Integer

    'End Function
    'Private Function indexPagament() As Integer

    'End Function

    Private Function getData() As Contacte
        getData = contacteActual.copy
        getData.codiPostal = Me.txtCodiPostal.Text
        getData.direccio = Me.txtDireccio.Text
        getData.nom = Me.txtNom.Text
        getData.cognom1 = Me.txtCognom1.Text
        getData.cognom2 = Me.txtCognom2.Text
        getData.poblacio = Me.txtPoblacio.Text
        getData.pais = paisos.obj
        getData.provincia = provincies.obj
        getData.telefon = Me.txtTelefon1.Text
        getData.email = Me.txtemail.Text
        getData.notes = Me.txtNotes.Text
        getData.estat = Me.xecActiu.Checked
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
        Me.txtNom.Select()
    End Sub
    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodiPostal.KeyPress, txtNom.KeyPress, txtCognom1.KeyPress, txtCognom2.KeyPress, txtemail.KeyPress, txtDireccio.KeyPress, txtNotes.KeyPress, txtPoblacio.KeyPress, txtTelefon1.KeyPress
        If sender.Equals(txtCodiPostal) Then
            e.KeyChar = VALIDAR.Enter(e.KeyChar, txtCodiPostal.Text.Length, 5)
        ElseIf sender.Equals(txtNom) Or sender.Equals(txtCognom1) Or sender.Equals(txtCognom2) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 49)
        ElseIf sender.Equals(txtTelefon1) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 25)
        Else
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 254)
        End If
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
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNom.KeyDown,
                                                                         txtCognom1.KeyDown,
                                                                         txtCognom1.KeyDown,
                                                                         txtDireccio.KeyDown,
                                                                         txtPoblacio.KeyDown,
                                                                         txtCodiPostal.KeyDown,
                                                                         pProvincia.KeyDown,
                                                                         pPais.KeyDown,
                                                                         txtemail.KeyDown

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
        getControls.Add(txtNom.Name)
        getControls.Add(txtCognom1.Name)
        getControls.Add(txtCognom2.Name)
        getControls.Add(txtDireccio.Name)
        getControls.Add(txtPoblacio.Name)
        getControls.Add(txtCodiPostal.Name)
        getControls.Add(pProvincia.Name)
        getControls.Add(pPais.Name)
        getControls.Add(txtTelefon1.Name)
        getControls.Add(txtemail.Name)
        getControls.Add(xecActiu.Name)
        getControls.Add(txtNotes.Name)
        getControls.Add(cmdGuardar.Name)
        getControls.Add(cmdCancelar.Name)
    End Function

    Protected Overrides Sub Finalize()
        contacteActual = Nothing
        provincies = Nothing
        paisos = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged

    End Sub
End Class
