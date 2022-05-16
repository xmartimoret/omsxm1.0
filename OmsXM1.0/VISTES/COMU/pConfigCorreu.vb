Option Explicit On
Public Class pConfigCorreu
    Private Sub pConfigCorreu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDireccio.Text = IDIOMA.getString("correuPredeterminat")
        lblCaption.Text = IDIOMA.getString("configSignEmail")
        txtCorreu.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.CORREU_PREDETERMINAT)
        txtSign.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.FIRMA_CORREU)
        Boto1.Text = IDIOMA.getString("guardarSignaturaEmail")
    End Sub
    Private Sub Boto1_Click(sender As Object, e As EventArgs) Handles Boto1.Click
        Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.CORREU_PREDETERMINAT, txtCorreu.Text)
        Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.FIRMA_CORREU, txtSign.Text)
    End Sub
    'Private Function getSignPredeterminada() As String
    '    Dim ruta As String, result As String = ""
    '    ruta = CONFIG.getRutaFitxerSignaturaCorreu
    '    If CONFIG.fileExist(ruta) Then
    '        Using fitxer As New IO.StreamReader(ruta, System.Text.Encoding.GetEncoding(1252)) ' obre el fitxer                 
    '            If Not fitxer.EndOfStream Then
    '                result = result & fitxer.ReadLine
    '            End If
    '        End Using
    '    End If
    '    Return result
    'End Function
End Class
