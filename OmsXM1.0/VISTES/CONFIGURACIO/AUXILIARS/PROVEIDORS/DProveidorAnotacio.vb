Imports System.Windows.Forms
Public Class DProveidorAnotacio
    Private anotacioActual As proveidorAnotacio
    Public Function getAnotacio(pProveidor As proveidorAnotacio) As proveidorAnotacio
        anotacioActual = pProveidor
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            Return getData()
        Else
            Return Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setLanguage()
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        If anotacioActual.id > -1 Then
            Me.Text = IDIOMA.getString("modificarAvis")
        Else
            Me.Text = IDIOMA.getString("afegirAvis")
        End If
    End Sub

    Private Sub setData()
        Me.lblId.Text = anotacioActual.id
        Me.txtNotes.Text = anotacioActual.notes
        Me.xecActiu.Checked = anotacioActual.estat
    End Sub
    'Private Function indexPais() As Integer

    'End Function
    'Private Function indexProvincia() As Integer

    'End Function
    'Private Function indexPagament() As Integer

    'End Function

    Private Function getData() As proveidorAnotacio
        getData = anotacioActual.copy
        getData.notes = Me.txtNotes.Text
        getData.estat = Me.xecActiu.Checked
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DProveidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()

    End Sub
End Class
