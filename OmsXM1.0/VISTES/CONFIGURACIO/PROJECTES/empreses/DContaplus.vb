Imports System.Windows.Forms

Public Class DContaplus
    Private empresaActual As Contaplus
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getEmpresa(pEmpresa As Contaplus, Optional nomEmpresa As String = "") As Contaplus
        empresaActual = pEmpresa
        If empresaActual.id = -1 Then
            Me.Text = IDIOMA.getString("dEmpresaAfegirEmpresa")
        Else
            Me.Text = IDIOMA.getString("dEmpresaModificarEmpresa")
        End If
        lblEmpresa.Text = nomEmpresa
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getEmpresa = getData()
            Me.Close()
        Else
            getEmpresa = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = empresaActual.id
        txtAny.Text = empresaActual.anyo
        txtNom.Text = empresaActual.nom
        xecNoContaplus.Checked = Not empresaActual.esContaplus
    End Sub
    Private Function getData() As Contaplus
        getData = empresaActual.copy
        empresaActual.anyo = txtAny.Text
        If xecNoContaplus.Checked Then
            empresaActual.nom = ""
        Else
            empresaActual.nom = txtNom.Text
        End If
        empresaActual.esContaplus = Not xecNoContaplus.Checked

    End Function
    Private Sub setLanguage()
        Me.lblAny.Text = IDIOMA.getString("anyComptable")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        lblEmpresaCaption.Text = IDIOMA.getString("empresa")
        Me.lblErrAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.xecNoContaplus.Text = IDIOMA.getString("noContaplus")
    End Sub
    Private Sub validateControls()
        Me.lblErrAny.Visible = False
        Me.lblErrNom.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtAny.Text.Length = 0 Then
            Me.lblErrAny.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If txtNom.Text.Length = 0 And xecNoContaplus.Checked = False Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub

    Private Sub txtAny_TextChanged(sender As Object, e As EventArgs) Handles txtAny.TextChanged
        Call validateControls()
    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        Call validateControls()
    End Sub

    Private Sub xecNoContaplus_CheckedChanged(sender As Object, e As EventArgs) Handles xecNoContaplus.CheckedChanged
        Call validateControls()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If saveData() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Hide()
    End Sub
    Private Function saveData() As Boolean
        ' todo cal comprovar que existeix la ruta contaplus
        Call getData()
        If ModelEmpresaContaplus.existAny(empresaActual) Then
            Call ERRORS.ERR_EXIST_ANY_COMPTABLE()
            Return False
        ElseIf ModelEmpresaContaplus.existName(empresaActual) And Not xecNoContaplus.Checked Then
            Call ERRORS.ERR_EXIST_NAME_CONTAPLUS(empresaActual.nom)
            Return False
        End If
        Return True
    End Function
    Private Sub txtAny_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAny.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, txtAny.Text.Length, 4)
        e.Handled = False
    End Sub

End Class
