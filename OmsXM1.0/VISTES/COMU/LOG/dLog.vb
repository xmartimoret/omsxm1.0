Imports System.Windows.Forms

Public Class dLog
    Public Sub setMostrar(e As EntradaLog)
        Call setLanguage()
        Me.Text = "LOG  ACTUAL"
        If e.codi = CONFIG.tipusEntradaLog.AVIS_log Then
            Me.lblTipus.Text = IDIOMA.getString("avisLog")
        Else
            Me.lblTipus.Text = IDIOMA.getString("errorLog")
        End If
        Me.lblCodi.Text = e.titol
        Me.lblDescripcio.Text = e.descripcio
        Me.ShowDialog()
    End Sub
    Private Sub setLanguage()
        Me.lblCaptionDescripcio.Text = IDIOMA.getString("descripcio")
        Me.lblCaptionTipus.Text = IDIOMA.getString("tipus")
        Me.lblCaptionCodi.Text = IDIOMA.getString("codi")
        Me.cmdTancar.Text = IDIOMA.getString("cmdTancar")
    End Sub

    Private Sub cmdTancar_Click(sender As Object, e As EventArgs) Handles cmdTancar.Click
        Me.Close()
    End Sub

    Private Sub dLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
