Public Class CodiDescripcio
    Public Property codi As String
    Public Property descripcio As String
    Public Sub New()

    End Sub

    Public Sub New(pCodi As String)
        _codi = pCodi
        _descripcio = ""
    End Sub
    Public Sub New(pCodi As String, pDescripcio As String)
        _codi = pCodi
        _descripcio = pDescripcio
    End Sub
End Class
