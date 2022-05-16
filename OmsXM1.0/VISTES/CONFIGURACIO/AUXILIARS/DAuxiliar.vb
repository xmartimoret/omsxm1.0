Imports System.Windows.Forms
Public Class DAuxiliar
    Private objectActual As Object
    Private NumCaracters As Integer
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getobject(pobject As Object, Optional titol As String = "", Optional pCaractersCodi As Integer = 3) As Object
        objectActual = pobject
        NumCaracters = pCaractersCodi
        If objectActual Is Nothing Then
            If titol = "" Then
                Me.Text = IDIOMA.getString("dobjectAfegirobject")
            Else
                Me.Text = titol
            End If
        Else
            If titol = "" Then
                Me.Text = IDIOMA.getString("dobjectModificarobject")
            Else
                Me.Text = titol
            End If
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getobject = getData()
            Me.Close()
        Else
            getobject = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        If objectActual Is Nothing Then
            lblId.Text = -1
            txtCodi.Text = ""
            txtNom.Text = ""
        Else
            lblId.Text = objectActual.id
            txtCodi.Text = objectActual.codi
            txtNom.Text = objectActual.nom
        End If
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
    Private Function getData() As Object
        getData = New Object
        If objectActual IsNot Nothing Then
            getData = objectActual.copy
        End If

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

    Private Sub Dobject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub

    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        Call validateControls()
    End Sub
    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, sender.Text.Length, NumCaracters)
    End Sub
End Class
