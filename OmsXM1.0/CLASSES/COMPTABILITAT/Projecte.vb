Public Class Projecte
    Inherits Base
    Public Property idEmpresa As Integer
    Public Property toStringEmpresa As String
    Public Property magatzems As List(Of projecteEntrega)
    Public Property contactes As List(Of ProjecteContacte)
    Public Property responsable As String
    Public Property director As String
    Public Sub New()
        _magatzems = New List(Of projecteEntrega)
        _contactes = New List(Of ProjecteContacte)
    End Sub
    Public Sub New(pId As Integer, pIdEmpresa As Integer, pOrdre As String, pCodi As String, pNom As String, pNotes As String)
        Me.id = pId
        _idEmpresa = pIdEmpresa
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        _magatzems = New List(Of projecteEntrega)
        _contactes = New List(Of ProjecteContacte)
    End Sub
    Public Sub New(pId As Integer, pIdEmpresa As Integer, pOrdre As String, pCodi As String, pNom As String, pNotes As String, pToStringEmpresa As String)
        Me.id = pId
        _idEmpresa = pIdEmpresa
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        _toStringEmpresa = pToStringEmpresa
        _magatzems = New List(Of projecteEntrega)
        _contactes = New List(Of ProjecteContacte)
    End Sub
    Public Sub New(pId As Integer, pIdEmpresa As Integer, pOrdre As String, pCodi As String, pNom As String, pNotes As String, pToStringEmpresa As String, pResponsable As String, pDirector As String)
        Me.id = pId
        _idEmpresa = pIdEmpresa
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.responsable = pResponsable
        Me.director = pDirector
        _toStringEmpresa = pToStringEmpresa
        _magatzems = New List(Of projecteEntrega)
        _contactes = New List(Of ProjecteContacte)
    End Sub


    Public ReadOnly Property copy As Projecte
        Get
            copy = New Projecte
            copy.id = Me.id
            copy.idEmpresa = _idEmpresa
            copy.ordre = Me.ordre
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.notes = Me.notes
            copy.toStringEmpresa = _toStringEmpresa
            copy.magatzems = _magatzems
            copy.contactes = _contactes
            copy.responsable = _responsable
            copy.director = _director

        End Get
    End Property
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _magatzems = Nothing
        _contactes = Nothing
    End Sub
End Class
