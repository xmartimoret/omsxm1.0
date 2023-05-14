Public Class doc
    Inherits Base
    Public Property idSolicitut As Integer
    Public Property idComandaEnEdicio As Integer
    Public Property idComanda As Integer
    Public Property anyo As Integer
    Public Property idProveidor As Integer
    Public Property nomProveidor As String
    Public Property data As Date
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pIdSolicitut As Integer, pIdComandaE As Integer, pIdComanda As Integer)
        Me.id = pId
        _idSolicitut = pIdSolicitut
        _idComandaEnEdicio = pIdComandaE
        _idComanda = pIdComanda
    End Sub
    Public Sub New(pId As Integer, pIdSolicitut As Integer, pIdComandaE As Integer, pIdComanda As Integer, pCodi As String, pNom As String)
        Me.id = pId
        _idSolicitut = pIdSolicitut
        _idComandaEnEdicio = pIdComandaE
        _idComanda = pIdComanda
        Me.codi = pCodi
        Me.nom = pNom
    End Sub

End Class
