Imports System.Windows.Forms

Public Class DArticle
    Private articleActual As article
    Private families As lstAuxiliars1
    Private fabricants As lstAuxiliars1
    Private ives As lstAuxiliars1
    Private unitats As lstAuxiliars1
    Private elements As List(Of String)
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        elements = getControls()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function getArticle(pArticle As article) As article
        articleActual = pArticle
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getArticle = getData()
        Else
            getArticle = Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblFabricant.Text = IDIOMA.getString("fabricant")
        Me.lblFamilia.Text = IDIOMA.getString("familia")
        Me.lblUnitat.Text = IDIOMA.getString("unitat")
        Me.lblIva.Text = IDIOMA.getString("iva")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.lblNotes.Text = IDIOMA.getString("notes")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.lblErrNom.Visible = False
        Me.cmdGuardar.Enabled = True
        If Me.txtCodi.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Me.txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Sub setData()
        families = New lstAuxiliars1(articleActual.familia, DBCONNECT.getTaulaFamilia)
        fabricants = New lstAuxiliars1(articleActual.fabricant, DBCONNECT.getTaulaFabricant)
        unitats = New lstAuxiliars1(articleActual.unitat, DBCONNECT.getTaulaUnitat)
        ives = New lstAuxiliars1(articleActual.iva, DBCONNECT.getTaulaTipusIva)
        pFamilia.Controls.Clear()
        PFabricant.Controls.Clear()
        pUnitat.Controls.Clear()
        pIva.Controls.Clear()
        families.Dock = DockStyle.Fill
        fabricants.Dock = DockStyle.Fill
        unitats.Dock = DockStyle.Fill
        ives.Dock = DockStyle.Fill
        AddHandler ives.selectObject, AddressOf selectIVA
        AddHandler families.selectObject, AddressOf selectFamilies
        AddHandler fabricants.selectObject, AddressOf selectFabricants
        AddHandler unitats.selectObject, AddressOf selectUnitats
        pFamilia.Controls.Add(families)
        PFabricant.Controls.Add(fabricants)
        pUnitat.Controls.Add(unitats)
        pIva.Controls.Add(ives)
        Me.lblId.Text = articleActual.id
        Me.txtCodi.Text = articleActual.codi
        Me.txtNom.Text = articleActual.nom
        Me.txtNotes.Text = articleActual.notes
    End Sub
    Private Sub selectIVA()

    End Sub
    Private Sub selectFamilies()

    End Sub
    Private Sub selectFabricants()

    End Sub
    Private Sub selectUnitats()

    End Sub
    Private Function getData() As article
        getData = articleActual.copy
        getData.codi = Me.txtCodi.Text
        getData.nom = Me.txtNom.Text
        getData.notes = Me.txtNotes.Text
        getData.familia = Me.families.obj
        getData.fabricant = Me.fabricants.obj
        getData.unitat = Me.unitats.obj
        getData.iva = Me.ives.obj

        'If getData.pais Is Nothing Then getData.pais = ModelPais.getAuxiliar.getObject(0)
        'If getData.provincia Is Nothing Then getData.provincia = ModelProvincia.getAuxiliar.getObject(0)        
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()

    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        Call validateControls()
    End Sub

    Private Sub DArticle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()
        Call validateControls()
        txtCodi.Select()
    End Sub



    Protected Overrides Sub Finalize()
        ' families = Nothing
        fabricants = Nothing
        unitats = Nothing
        ives = Nothing

        MyBase.Finalize()
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodi.KeyDown, txtNom.KeyDown, txtNotes.KeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Down Then
            e.Handled = False
            Call SendKeys.Send("{tab}")
        ElseIf e.KeyValue = Keys.UP Then
            e.Handled = False
            Call getTab(sender, -1)
        End If

    End Sub
    Private Function getControls() As List(Of String)
        getControls = New List(Of String)
        getControls.Add(txtCodi.Name)
        getControls.Add(txtNom.Name)
        getControls.Add(pFamilia.Name)
        getControls.Add(PFabricant.Name)
        getControls.Add(pUnitat.Name)
        getControls.Add(txtNotes.Name)
        getControls.Add(cmdGuardar.Name)
        getControls.Add(cmdCancelar.Name)
    End Function
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


End Class
