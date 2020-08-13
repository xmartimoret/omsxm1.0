Imports System.Windows.Forms

Public Class DNovaComanda
    Private Const SOLICITUD_COMANDA As String = "NOVA"
    Private actualitzar As Boolean
    Private empresaActual As Empresa
    Private listProveidors As lstProveidor
    Private projecteActual As Projecte
    Private proveidorActual As Proveidor
    Public Sub New()
        InitializeComponent()
        actualitzar = False
        Call setLanguage()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        Me.pProveidor.Controls.Clear()
        listProveidors = New lstProveidor(New Proveidor)
        listProveidors.Dock = DockStyle.Fill
        Me.pProveidor.Controls.Add(listProveidors)
        Call validateControls()
        actualitzar = True
        If cbEmpresa.Items.Count > 0 Then cbEmpresa.SelectedIndex = 0
    End Sub
    Public Function getComanda() As Comanda
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getComanda = New Comanda(-1, "", listProveidors.obj, empresaActual, projecteActual)
            getComanda.codi = -1
        Else
            getComanda = Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblProjecte.Text = IDIOMA.getString("projecte")
        Me.lblProveidor.Text = IDIOMA.getString("proveidor")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdAcceptar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.Text = IDIOMA.getString("crearNovaComanda")
    End Sub
    Private Sub validateControls()
        If IsNothing(empresaActual) Then
            cbProjecte.SelectedIndex = -1
            cbProjecte.Enabled = False
        Else
            cbProjecte.Enabled = True
        End If
    End Sub
    Private Sub setEmpresa()
        actualitzar = False
        If Not IsNothing(empresaActual) Then
            cbProjecte.Items.Clear()
            cbProjecte.Items.AddRange(ModelProjecte.getListObjects(empresaActual.id))
        Else
            cbProjecte.Items.Clear()
            cbProjecte.SelectedIndex = -1
        End If

        actualitzar = True
        Call validateControls()
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = cbEmpresa.SelectedItem
                setEmpresa()
            Else
                empresaActual = Nothing
            End If
            Call validateControls()
        End If

    End Sub

    Private Sub cbProjecte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProjecte.SelectedIndexChanged
        If actualitzar Then
            projecteActual = cbProjecte.SelectedItem
            Call validateControls()
        End If
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        empresaActual = Nothing
        listProveidors = Nothing
        projecteActual = Nothing
        proveidorActual = Nothing
    End Sub
End Class
