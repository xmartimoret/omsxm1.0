Imports System.Windows.Forms

Public Class DProjecte
    Private projecteActual As Projecte
    Public Sub New()
        InitializeComponent()

    End Sub
    Public Function getProjecte(pProjecte As Projecte) As Projecte
        projecteActual = pProjecte
        If projecteActual.id = -1 Then
            Me.Text = IDIOMA.getString("dProjecteAfegirProjecte")
        Else
            Me.Text = IDIOMA.getString("dProjecteModificarProjecte")
        End If
        Call setEmpreses()
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getProjecte = getData()
            Me.Close()
        Else
            getProjecte = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = projecteActual.id
        txtCodi.Text = projecteActual.codi
        cbEmpresa.SelectedIndex = getIdEmpresa()
        txtNom.Text = projecteActual.nom
        txtNotes.Text = projecteActual.notes
        txtReponsable.Text = projecteActual.responsable
        txtDirector.Text = projecteActual.director
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblErrEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.lblDirector.Text = IDIOMA.getString("director")
        Me.lblResponsable.Text = IDIOMA.getString("responsable")
    End Sub
    Private Sub validateControls()
        Me.lblErrEmpresa.Visible = False
        Me.lblErrCodi.Visible = False
        Me.lblErrNom.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If cbEmpresa.SelectedIndex = -1 Then
            Me.lblErrEmpresa.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Function getIdEmpresa() As Integer
        Dim i As Integer
        For i = 0 To cbEmpresa.Items.Count - 1
            If cbEmpresa.Items(i).id = projecteActual.idEmpresa Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub setEmpreses()
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects())
    End Sub
    Private Function getData() As Projecte
        getData = projecteActual.copy
        getData.codi = txtCodi.Text
        getData.idEmpresa = cbEmpresa.SelectedItem.id
        getData.nom = txtNom.Text
        getData.notes = txtNotes.Text
        getData.toStringEmpresa = cbEmpresa.Text
        getData.responsable = txtReponsable.Text
        getData.director = txtDirector.Text

    End Function


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DProjecte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        Call validateControls()
    End Sub

    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        Call validateControls()
    End Sub
End Class
