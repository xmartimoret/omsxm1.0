Imports System.Windows.Forms
Public Class DProjecteResponsables
    Private projecteActual As Projecte
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getProjecte(pProjecte As Projecte) As Projecte
        projecteActual = pProjecte
        Me.Text = IDIOMA.getString("dProjecteModificarProjecte")
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
        txtReponsable.Text = projecteActual.responsable
        txtDirector.Text = projecteActual.director
    End Sub
    Private Sub setLanguage()
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblDirector.Text = IDIOMA.getString("director")
        Me.lblResponsable.Text = IDIOMA.getString("responsable")
    End Sub
    Private Sub validateControls()
    End Sub
    Private Function getData() As Projecte
        getData = projecteActual.copy
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

    Private Sub DProjecteResponsables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtReponsable.Select()
    End Sub
End Class
