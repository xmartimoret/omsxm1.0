Imports System.Windows.Forms

Public Class DCodiComanda
    Private codiActual As CodiComanda


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Function getCodi(pCodi As CodiComanda) As CodiComanda
        codiActual = pCodi
        Me.Text = IDIOMA.getString("modificarCodiComanda")
        Call setLanguage()

        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getCodi = getData()
        Else
            getCodi = Nothing
        End If
        Me.Close()
    End Function
    Private Sub setLanguage()
        Me.lblSerieCaption.Text = IDIOMA.getString("serie")
        Me.lblEmpresaCaption.Text = IDIOMA.getString("empresa")
        Me.lblCodiCaption.Text = IDIOMA.getString("codi")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
    End Sub
    Private Sub setData()
        Me.txtCodi.Text = codiActual.codi
        Me.lblSerie.Text = codiActual.serie
        Me.lblId.Text = codiActual.id
        Me.lblEmpresa.Text = ModelEmpresa.getNom(codiActual.idEmpresa)
        Me.txtCodi.Text = codiActual.codi
        Me.txtNotes.Text = codiActual.notes
    End Sub
    Private Function getData() As CodiComanda
        getData = codiActual.copy
        getData.codi = Me.txtCodi.Text
        getData.notes = Me.txtNotes.Text
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If ModelCodiComanda.exist(getData) Then
            Call ERRORS.ERR_ACTUALITZACIO_CODI_COMANDA
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()
        End If
    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, sender.Text.Length, 10)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Me.Dispose()
    End Sub

    Private Sub DCodiComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
