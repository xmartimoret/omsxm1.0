Public Class YSheet
    Inherits Base
    Public Sub New()
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pOrdre As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.ordre = pOrdre
    End Sub
    Public ReadOnly Property copy As YSheet
        Get
            copy = New YSheet
            copy.id = Me.id
            copy.ordre = Me.ordre
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.notes = Me.notes
        End Get
    End Property
End Class
