Imports System.Windows.Forms

Public Class DAnyEmpresaCodi
    Private idEmpresaActual As Integer
    Public Function getCodiComanda() As AnyMesos
        Me.Text = IDIOMA.getString("cercarComandesCodi")
        idEmpresaActual = 1
        Call setEmpreses()
        Call setLanguage()
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getCodiComanda = getData()
        Else
            getCodiComanda = Nothing
        End If
        Me.Dispose()
    End Function
    'Public Function getCodiMyDoc() As AnyMesos
    '    Me.Text = IDIOMA.getString("cercarComandesMydoc")
    '    idEmpresaActual = 1
    '    Call setEmpreses()
    '    Me.ShowDialog()
    '    If Me.DialogResult = DialogResult.OK Then
    '        Return getData()
    '    End If
    '    Return Nothing
    'End Function

    Private Sub setLanguage()
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblAny.Text = IDIOMA.getString("any") & ":"
        Me.lblEmpresa.Text = IDIOMA.getString("empresa") & ":"
        Me.lblCodi.Text = IDIOMA.getString("codi") & ":"
    End Sub
    Private Sub setEmpreses()
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        cbEmpresa.SelectedIndex = getListIndexEmpresa(idEmpresaActual)
    End Sub
    Private Function getListIndexEmpresa(idEmpresa As Integer) As Integer
        Dim i As Integer
        For i = 0 To cbEmpresa.Items.Count - 1
            If cbEmpresa.Items(i).id = idEmpresa Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Function getData() As AnyMesos
        Dim m As Mes
        getData = New AnyMesos
        getData.any = Val(txtAny.Text)
        getData.ruta = txtCodi.Text
        If cbEmpresa.SelectedIndex > -1 Then
            getData.idEmpresa = cbEmpresa.SelectedItem.id
        End If
    End Function
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub txtAny_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAny.KeyPress, txtCodi.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, sender.Text.Length, 4)
    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

End Class
