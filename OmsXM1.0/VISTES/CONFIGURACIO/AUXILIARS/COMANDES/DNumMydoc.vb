Imports System.Windows.Forms

Public Class DNumMydoc
    Private numActual As Long
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Function getCodi(c As Comanda) As Long

        Me.Text = IDIOMA.getString("modificarCodiMydoc") & " " & c.getCodi
        If IsNothing(c.docMyDoc) Then c.docMyDoc = New PedidoMD
        Me.txtCodi.Text = c.docMyDoc.id
        Call setLanguage()


        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getCodi = getData()
        Else
            getCodi = Nothing
        End If
        Me.Close()
    End Function
    Private Sub setLanguage()
        Me.lblMydoc.Text = IDIOMA.getString("numMydoc") & ":"
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
    End Sub

    Private Function getData() As Long
        getData = txtCodi.Text

    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()

    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, sender.Text.Length, 10)
    End Sub
End Class
