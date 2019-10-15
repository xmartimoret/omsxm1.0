Imports System.Windows.Forms

Public Class DDepartament
    Private departamentActual As Departament
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getDepartament(pDepartament As Departament) As Departament
        departamentActual = pDepartament
        If departamentActual.id = -1 Then
            Me.Text = IDIOMA.getString("dDepartamentAfegirDepartament")
        Else
            Me.Text = IDIOMA.getString("dDepartamentModificarDepartament")
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getDepartament = getData()
            Me.Close()
        Else
            getDepartament = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = departamentActual.id
        txtCodi.Text = departamentActual.codi
        txtNom.Text = departamentActual.nom
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub
    Private Function getData() As Departament
        getData = departamentActual.copy
        getData.codi = txtCodi.Text
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

    Private Sub DDepartament_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub


    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, txtCodi.Text.Length, 3)
    End Sub
End Class
