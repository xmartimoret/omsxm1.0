Imports System.Windows.Forms
Public Class DArticlePreu
    Private objectActual As ArticlePreu
    Private proveidors As lstProveidor
    Public Function getArticlePreu(p As ArticlePreu) As ArticlePreu
        objectActual = p

        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getArticlePreu = getData()
        Else
            getArticlePreu = Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblArticleCaption.Text = IDIOMA.getString("article")
        Me.lblProveidor.Text = IDIOMA.getString("proveidor")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.lblData.Text = IDIOMA.getString("data")
        Me.lblBase.Text = IDIOMA.getString("import")
        Me.lblDescompte.Text = IDIOMA.getString("descompte")
    End Sub
    Private Sub setData()
        proveidors = New lstProveidor(ModelProveidor.getObject(objectActual.idProveidor))
        ModelArticle.getObject(objectActual.idArticle)
        lblArticle.Text = ModelArticle.getObject(objectActual.idArticle).ToString
        pProveidor.Controls.Clear()
        proveidors.Dock = DockStyle.Fill
        pProveidor.Controls.Add(proveidors)
        Me.lblId.Text = objectActual.id
        cData.dataActual = objectActual.data
        txtBase.Text = objectActual.base
        txtDescompte.Text = objectActual.descompte
    End Sub

    Private Function getData() As ArticlePreu
        getData = objectActual.copy
        If proveidors.cb.SelectedIndex > -1 Then
            getData.idProveidor = proveidors.cb.SelectedItem.id
        End If
        getData.data = cData.txtData.Text
        getData.descompte = txtDescompte.Text
        getData.base = txtBase.Text
    End Function
    Private Sub txtBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBase.KeyPress
        e.KeyChar = VALIDAR.DecimalNegatiu(e.KeyChar, txtBase.Text, txtBase.SelectionStart, txtBase.Text.Length, 12, 2)
    End Sub
    Private Sub txtDescompte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescompte.KeyPress
        e.KeyChar = VALIDAR.EnterMax(e.KeyChar, txtDescompte.Text.Length, 3, txtDescompte.Text, 100)
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DArticlePreu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()
    End Sub
End Class
