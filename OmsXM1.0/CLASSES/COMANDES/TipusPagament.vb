Public Class TipusPagament
    Inherits Base
    Public Property dies As Integer
    Public Property diaPagament As Integer
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
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String, pDies As Integer, pDiaPagament As Integer)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        Me.dies = pDies
        Me.diaPagament = pDiaPagament
        actiu = True
    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String, pDies As Integer, pDiaPagament As Integer, pActiu As Boolean)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        Me.dies = pDies
        Me.diaPagament = pDiaPagament
        actiu = pActiu
    End Sub
    Public Function copy() As TipusPagament
        copy = New TipusPagament
        copy.id = Me.id
        copy.codi = Me.codi
        copy.nom = Me.nom
        copy.ordre = Me.ordre
        copy.dies = _dies
        copy.diaPagament = _diaPagament
        copy.actiu = _actiu
    End Function
End Class
