Imports System.Windows.Forms
Imports System.IO
Public Class DMissatges
    Public Sub setText(titol As String, txt As String)
        Me.lblText.Text = txt
        Me.Text = titol
        Call setLanguage()
        Me.ShowDialog()
    End Sub
    Private Sub setLanguage()
        Me.cmdImprimir.Text = IDIOMA.getString("imprimir")
        Me.cmdSortir.Text = IDIOMA.getString("sortir")
    End Sub

    Private Sub cmdSortir_Click(sender As Object, e As EventArgs) Handles cmdSortir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim ruta As String, o As Integer
        ruta = CONFIG.setFolder(CONFIG.getdirectoriLogAplicacio)
        ruta = ruta & IDIOMA.getString("missatge") & Format(Now(), "yy") & Format(Now(), "MM") & Format(Now(), "dd") & Format(Now(), "hh") & Format(Now(), "nn") & ".txt"
        Using fitxer As StreamWriter = New StreamWriter(ruta)
            fitxer.Write(lblText.Text)
        End Using
        o = Shell("C:\WINDOWS\notepad.exe" & " " & ruta, vbMaximizedFocus)
        Call Interaction.AppActivate(o)
    End Sub

End Class
