Imports System.Windows.Forms

Public Class DPais
    Private paisActual As Pais
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getPais(pPais As Pais) As Pais
        paisActual = pPais
        If paisActual.id = -1 Then
            Me.Text = IDIOMA.getString("dPaisAfegirPais")
        Else
            Me.Text = IDIOMA.getString("dPaisModificarPais")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getPais = getData()
            Me.Close()
        Else
            getPais = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = paisActual.id
        txtCodi.Text = paisActual.codi
        txtAbreviatura.Text = paisActual.abreviatura
        txtNom.Text = paisActual.nom
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblAbreviatura.Text = IDIOMA.getString("abrev.")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrAbreviatura.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.lblErrAbreviatura.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtAbreviatura.Text.Length = 0 Then
            Me.lblErrAbreviatura.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Function getData() As Pais
        getData = paisActual.copy
        getData.codi = txtCodi.Text
        getData.abreviatura = txtAbreviatura.Text
        getData.nom = txtNom.Text
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DPais_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub

    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress, txtAbreviatura.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, sender.Text.Length, 3)
    End Sub

    Private Sub txtAbreviatura_TextChanged(sender As Object, e As EventArgs) Handles txtAbreviatura.TextChanged
        Call validateControls()
    End Sub
End Class
