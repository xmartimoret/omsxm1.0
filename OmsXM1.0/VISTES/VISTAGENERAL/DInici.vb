Imports System.Windows.Forms

Public Class DInici

    Private Sub setLanguage()
        Me.Text = IDIOMA.getString("escollirModulAplicacio")
        Me.cmdCompres.Text = IDIOMA.getString("cmdCompres")
        Me.cmdComptabilitat.Text = IDIOMA.getString("cmdComptabilitat")
        Me.cmdFacturacio.Text = IDIOMA.getString("cmdFacturacio")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdSortir")
    End Sub
    Private Sub DInici_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setLanguage()
    End Sub

    Private Sub cmdComptabilitat_Click(sender As Object, e As EventArgs) Handles cmdComptabilitat.Click
        Call FrmApliOms.Show()
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub cmdFacturacio_Click(sender As Object, e As EventArgs) Handles cmdFacturacio.Click
        MsgBox("en obres")
    End Sub

    Private Sub cmdCompres_Click(sender As Object, e As EventArgs) Handles cmdCompres.Click
        Call frmIniComanda.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
