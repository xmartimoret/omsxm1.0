Public Class Subcompte
    Inherits Base
    Friend Property saldo As Double
    Public Sub New()
        _saldo = 0
    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        _saldo = 0
    End Sub
    Public ReadOnly Property copy As Subcompte
        Get
            copy = New Subcompte
            copy.id = Me.id
            copy.ordre = Me.ordre
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.notes = Me.notes
            copy.saldo = Me.saldo
        End Get
    End Property
End Class
