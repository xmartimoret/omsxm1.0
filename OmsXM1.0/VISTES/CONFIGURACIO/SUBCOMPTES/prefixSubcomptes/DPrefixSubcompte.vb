Imports System.Windows.Forms

Public Class DPrefixSubcompte
    Private subcompteActual As PrefixSubcte
    Private actualitzar As Boolean = True
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getPrefix(pPrefix As PrefixSubcte) As PrefixSubcte
        subcompteActual = pPrefix
        If subcompteActual.id = -1 Then
            Me.Text = IDIOMA.getString("dPrefixSubcompteAfegirPrefix")
        Else
            Me.Text = IDIOMA.getString("dPrefixSubcompteModificarPrefix")
        End If
        Call setSubcomptes()
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getPrefix = getData()
            Me.Close()
        Else
            getPrefix = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        actualitzar = False
        lblId.Text = subcompteActual.id
        txtPrefix.Text = subcompteActual.prefix
        cbSubcompte.SelectedIndex = getIdSubcompte()
        actualitzar = True
    End Sub
    Private Sub setSubcomptes()
        actualitzar = False
        cbSubcompte.Items.Clear()
        cbSubcompte.Items.AddRange(ModelSubcomptePretancament.getListObjects(ModelSubcomptePretancament.getObjects))
        actualitzar = True
    End Sub
    Private Function getIdSubcompte() As Integer
        Dim i As Integer
        For i = 0 To cbSubcompte.Items.Count - 1
            If cbSubcompte.Items(i).id = subcompteActual.idSubcompte Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub setLanguage()
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblPrefix.Text = IDIOMA.getString("prefixSubcompte")
        Me.lblErrPrefix.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblErrSubcompte.Text = IDIOMA.getString("campObligatori")
        Me.cmdActualitzarSubcomptes.Text = IDIOMA.getString("actualitzarSubtes")
        Me.lblSubcompte.Text = IDIOMA.getString("sbcte")
    End Sub
    Private Sub validateControls()
        Me.lblErrPrefix.Visible = False
        Me.lblErrSubcompte.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtPrefix.Text.Length = 0 Then
            Me.lblErrPrefix.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If cbSubcompte.SelectedIndex = -1 Then
            Me.lblErrSubcompte.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub

    Private Function getData() As PrefixSubcte
        getData = subcompteActual.copy
        getData.prefix = txtPrefix.Text
        getData.ordre = txtPrefix.Text
        getData.idSubcompte = cbSubcompte.SelectedItem.id
        getData.codiSubcompte = cbSubcompte.SelectedItem.codi
        getData.descripcioSubcompte = cbSubcompte.SelectedItem.nom
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DSubcompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub

    Private Sub txtPrefix_TextChanged(sender As Object, e As EventArgs) Handles txtPrefix.TextChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub txtPrefix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrefix.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, txtPrefix.Text.Length, 7)
    End Sub

    Private Sub cbSubcompte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubcompte.SelectedIndexChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub cmdActualitzarSubcomptes_Click(sender As Object, e As EventArgs) Handles cmdActualitzarSubcomptes.Click
        If ModelSubcomptePretancament.actualitzar Then
            Call setSubcomptes()
            Call setData()
            Call validateControls()
        End If
    End Sub
End Class
