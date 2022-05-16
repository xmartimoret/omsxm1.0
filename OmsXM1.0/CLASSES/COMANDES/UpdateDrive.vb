Public Class UpdateDrive
    Public Property id As Integer
    Public Property taula As Integer
    Public Property accio As Integer
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pTaula As Integer, pAccio As Integer)
        _id = pId
        _taula = pTaula
        _accio = pAccio
    End Sub
End Class
