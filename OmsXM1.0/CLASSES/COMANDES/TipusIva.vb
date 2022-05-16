Public Class TipusIva
    Inherits Base
    Public Property impost As Integer
    Public Property rEquivalencia As Double
    Public Property actiu As Boolean = True
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String)
        Me.id = pId
        Me.codi = pCodi
        Me.ordre = pNom
        Me.nom = pNom
        actiu = True
    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        actiu = True
    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String, pImpost As Integer, pREquivalencia As Double)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        actiu = True
        _impost = pImpost
        _rEquivalencia = pREquivalencia
    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String, pImpost As Integer, pREquivalencia As Double, pActiu As Boolean)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        _actiu = pActiu
        _impost = pImpost
        _rEquivalencia = pREquivalencia
    End Sub
    Public Function copy() As TipusIva
        copy = New TipusIva
        copy.id = Me.id
        copy.codi = Me.codi
        copy.nom = Me.nom
        copy.ordre = Me.ordre
        copy.impost = _impost
        copy.rEquivalencia = _rEquivalencia
        copy.actiu = _actiu
    End Function


    Public Overrides Function toString() As String
        Return nom
    End Function
End Class
