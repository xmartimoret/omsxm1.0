Public Class projecteEntrega
    Public Property idProjecte As Integer
    Public Property idEntrega As Integer
    Public Sub New()
    End Sub
    Public Sub New(pIdProjecte As Integer, pEntrega As Integer)
        _idProjecte = pIdProjecte
        _idEntrega = pEntrega
    End Sub

    Public Function copy() As projecteEntrega
        copy = New projecteEntrega
        copy.idProjecte = _idProjecte
        copy.idEntrega = _idEntrega
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
