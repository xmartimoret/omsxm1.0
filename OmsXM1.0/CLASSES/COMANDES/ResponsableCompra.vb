Public Class ResponsableCompra
    Inherits Base
    Public Property actiu As Boolean = True
    Public Sub New()
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pNotes As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pNotes As String, pActiu As Boolean)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        _actiu = pActiu
    End Sub
    Public Function copy() As ResponsableCompra
        copy = New ResponsableCompra
        copy.id = Me.id
        copy.codi = Me.codi
        copy.nom = Me.nom
        copy.actiu = _actiu
        copy.notes = Me.notes
    End Function
    Public Overrides Function toString() As String
        Return nom
    End Function
End Class
