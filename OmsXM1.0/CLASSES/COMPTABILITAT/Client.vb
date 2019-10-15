Option Explicit On
Public Class Client
    Inherits Base
    Public Property actiu As Boolean = True
    Public Property color As Integer
    Public Property projectes As List(Of ProjecteClient)
    Public Sub New()
        _projectes = New List(Of ProjecteClient)
    End Sub
    Public Sub New(pId As Integer, pNom As String, pNotes As String, pOrdre As String, pActiu As Boolean, pColor As Integer)
        Me.id = pId
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _actiu = pActiu
        _color = pColor
        _projectes = New List(Of ProjecteClient)
    End Sub
    Public Sub New(pId As Integer, pNom As String, pNotes As String, pOrdre As String, pActiu As Boolean, pColor As Integer, pProjectes As List(Of ProjecteClient))
        Me.id = pId
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _actiu = pActiu
        _color = pColor
        _projectes = pProjectes
    End Sub
    Public ReadOnly Property copy As Client
        Get
            copy = New Client
            copy.id = Me.id
            copy.nom = Me.nom
            copy.notes = Me.notes
            copy.ordre = Me.ordre
            copy.color = _color
            copy.actiu = _actiu
            copy.projectes = _projectes
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return Me.nom
    End Function
    Protected Overrides Sub Finalize()
        _projectes = Nothing
        MyBase.Finalize()
    End Sub
End Class
