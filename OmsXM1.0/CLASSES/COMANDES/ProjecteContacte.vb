Option Explicit On
Public Class ProjecteContacte
    Public Property idProjecte As Integer
    Public Property idContacte As Integer
    Public Property predeterminat As Boolean
    Public Sub New()
    End Sub
    Public Sub New(pIdProjecte As Integer, pContacte As Integer)
        _idProjecte = pIdProjecte
        _idContacte = pContacte
    End Sub
    Public Sub New(pIdProjecte As Integer, pContacte As Integer, pPredeterminat As Boolean)
        _idProjecte = pIdProjecte
        _idContacte = pContacte
        _predeterminat = pPredeterminat
    End Sub
    Public Function copy() As ProjecteContacte
        copy = New ProjecteContacte
        copy.idProjecte = _idProjecte
        copy.idContacte = _idContacte
        copy.predeterminat = _predeterminat
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
