Imports System.Windows.Forms

Public Class DLlocEntrega
    Private LlocEntregaActual As LlocEntrega
    Private provincies As lstAuxiliars1
    Private paisos As lstAuxiliars1
    Private elements As List(Of Control)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        elements = getelements()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Function getLlocEntrega(pLlocEntrega As LlocEntrega) As LlocEntrega
        LlocEntregaActual = pLlocEntrega
        xecPredeterminat.Enabled = False
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            Return getData()
        Else
            Return Nothing
        End If
        Me.Dispose()
    End Function
    Public Function getProjectetLlocEntrega(pLlocEntrega As LlocEntrega) As LlocEntrega
        LlocEntregaActual = pLlocEntrega
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
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        Me.xecPredeterminat.Text = IDIOMA.getString("predeterminat")

        If LlocEntregaActual.id > -1 Then
            Me.Text = IDIOMA.getString("modificarLlocEntrega") & " " & LlocEntregaActual.ToString
        Else
            Me.Text = IDIOMA.getString("afegirLlocEntrega")
        End If

    End Sub

    Private Sub setData()

        'Me.cbPais.Items.Clear()
        'Me.cbPais.Items.AddRange(ModelPais.getListObjects)
        'Me.cbProvincia.Items.Clear()
        'Me.cbProvincia.Items.AddRange(ModelProvincia.getListObjects)
        provincies = New lstAuxiliars1(LlocEntregaActual.provincia, DBCONNECT.getTaulaProvincia)
        paisos = New lstAuxiliars1(LlocEntregaActual.pais, DBCONNECT.getTaulaPais)
        pProvincia.Controls.Clear()
        provincies.Dock = DockStyle.Fill
        pProvincia.Controls.Add(provincies)
        pPais.Controls.Clear()
        paisos.Dock = DockStyle.Fill
        pPais.Controls.Add(paisos)
        Me.lblId.Text = LlocEntregaActual.id
        Me.txtCodiPostal.Text = LlocEntregaActual.codiPostal
        Me.txtDireccio.Text = LlocEntregaActual.direccio
        Me.txtNom.Text = LlocEntregaActual.nom
        Me.txtPoblacio.Text = LlocEntregaActual.poblacio
        Me.txtNotes.Text = LlocEntregaActual.notes
        Me.xecActiu.Checked = LlocEntregaActual.actiu
        If xecPredeterminat.Enabled Then Me.xecPredeterminat.Checked = LlocEntregaActual.predeterminat
    End Sub
    'Private Function indexPais() As Integer

    'End Function
    'Private Function indexProvincia() As Integer

    'End Function
    'Private Function indexPagament() As Integer

    'End Function

    Private Function getData() As LlocEntrega
        getData = LlocEntregaActual.copy
        getData.codiPostal = Me.txtCodiPostal.Text
        getData.direccio = Me.txtDireccio.Text
        getData.nom = Me.txtNom.Text
        getData.poblacio = Me.txtPoblacio.Text
        getData.pais = paisos.obj
        getData.provincia = provincies.obj
        getData.notes = Me.txtNotes.Text
        getData.actiu = Me.xecActiu.Checked
        getData.predeterminat = Me.xecPredeterminat.Checked
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
    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodiPostal.KeyPress, txtNom.KeyPress, txtDireccio.KeyPress, txtNotes.KeyPress, txtPoblacio.KeyPress
        If sender.Equals(txtCodiPostal) Then
            e.KeyChar = VALIDAR.Enter(e.KeyChar, txtCodiPostal.Text.Length, 5)
        ElseIf sender.Equals(txtNom) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 254)
        ElseIf sender.Equals(txtDireccio) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 254)
        ElseIf sender.Equals(txtNotes) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 254)
        ElseIf sender.Equals(txtPoblacio) Then
            e.KeyChar = VALIDAR.texte(e.KeyChar, sender.Text.length, 254)
        End If
    End Sub
    Private Sub getTab(sender As Object, p As Integer)
        Dim i As Integer
        For i = 0 To elements.Count - 1
            If sender.name = elements(i).Name Then
                Exit For
            End If
        Next
        If i + p = elements.Count Then
            elements(0).Select()
        ElseIf i + p < 0 Then
            elements(elements.Count - 1).Select()
        Else
            elements(i + p).Select()
        End If
    End Sub
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNom.KeyDown,
                                                                         txtDireccio.KeyDown,
                                                                         txtPoblacio.KeyDown,
                                                                         txtCodiPostal.KeyDown,
                                                                         pProvincia.KeyDown,
                                                                         pPais.KeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Down Then
            e.Handled = False
            Call SendKeys.Send("{tab}")
        ElseIf e.KeyValue = Keys.Up Then
            e.Handled = False
            Call getTab(sender, -1)
        End If

    End Sub
    Private Function getelements() As List(Of Control)
        getelements = New List(Of Control)
        getelements.Add(txtNom)
        getelements.Add(txtDireccio)
        getelements.Add(txtPoblacio)
        getelements.Add(txtCodiPostal)
        getelements.Add(pProvincia)
        getelements.Add(pPais)
        getelements.Add(xecActiu)
        getelements.Add(xecPredeterminat)
        getelements.Add(txtNotes)
        getelements.Add(cmdGuardar)
        getelements.Add(cmdCancelar)
    End Function

    Protected Overrides Sub Finalize()
        LlocEntregaActual = Nothing
        provincies = Nothing
        paisos = Nothing
        MyBase.Finalize()
    End Sub
    Private Sub cmdImprimirPDF_Click(sender As Object, e As EventArgs) Handles cmdImprimirPDF.Click
        Call modulInfoLlocEntrega.execute(getData, True)
    End Sub
    Private Sub cmdImprimirExcel_Click(sender As Object, e As EventArgs) Handles cmdImprimirExcel.Click
        Call modulInfoLlocEntrega.execute(getData, False)
    End Sub
End Class
