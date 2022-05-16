Imports System.Windows.Forms

Public Class dActualitzar

    Public Sub mostrar()
        Dim d As Date
        d = Now
        Me.Show()
        While d < d.AddSeconds(20)
            Application.DoEvents()
        End While
        Me.Dispose()
    End Sub


End Class
