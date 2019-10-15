Imports System.Windows.Forms

Public Class DColumna
    Private columnaActual As Columna
    Private actualitzar As Boolean
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getColumna(pColumna As Columna) As Columna
        columnaActual = pColumna
        If columnaActual.id = "-1" Then
            Me.Text = IDIOMA.getString("dColumnaAfegirColumna")
            xecTotalitzador.Enabled = True
        Else
            Me.Text = IDIOMA.getString("dColumnaModificarColumna")
            xecTotalitzador.Enabled = False
        End If
        Call setLanguage()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getColumna = getData()
            Me.Close()
        Else
            getColumna = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        actualitzar = False
        lblCodi.Text = columnaActual.codi
        txtNom.Text = columnaActual.nom
        xecTotalitzador.Checked = columnaActual.totalitzador
        actualitzar = True
    End Sub
    Private Sub setLanguage()
        Me.lblCaptionCodi.Text = IDIOMA.getString("codi")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.xecTotalitzador.Text = IDIOMA.getString("lblTotalitzador")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
    End Sub
    Private Sub validateControls()
        Me.lblErrNom.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub

    Private Function getData() As Columna
        getData = columnaActual.copy
        getData.nom = txtNom.Text
        getData.totalitzador = xecTotalitzador.Checked
    End Function
    Private Sub DColumna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub
    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        If actualitzar Then Call validateControls()
    End Sub
    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNom.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, txtNom.Text.Length, 15)
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Hide()
    End Sub
End Class
