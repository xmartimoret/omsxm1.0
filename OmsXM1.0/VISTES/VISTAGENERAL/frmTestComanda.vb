Public Class frmTestComanda
    Private Sub frmTestComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As pComanda
        c = New pComanda(New Comanda)
        Panel1.Controls.Clear()
        c.Dock = DockStyle.Fill
        Panel1.Controls.Add(c)

    End Sub
End Class