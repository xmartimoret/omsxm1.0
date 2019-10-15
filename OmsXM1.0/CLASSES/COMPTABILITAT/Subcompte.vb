Public Class Subcompte
    Inherits Base
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
    End Sub
    Public ReadOnly Property copy As Subcompte
        Get
            copy = New Subcompte
            copy.id = Me.id
            copy.ordre = Me.ordre
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.notes = Me.notes
        End Get
    End Property
End Class
