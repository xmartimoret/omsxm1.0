Option Explicit On
Public Class Parametre
    Inherits ComparadorOrdre
    Public Property valor As String
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pValor As String)
        Me.id = pId

        _valor = pValor
    End Sub
End Class
