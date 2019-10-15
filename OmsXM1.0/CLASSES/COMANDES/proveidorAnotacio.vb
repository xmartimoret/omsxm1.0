Option Explicit On
Public Class proveidorAnotacio
    Inherits Base
    Public Property idProveidor As Integer
    Public Property estat As Boolean
    Public Sub New()
    End Sub
    Public Sub New(pIdProveidor As Integer)
        _idProveidor = pIdProveidor
    End Sub
    Public Sub New(pId As Integer, pIdProveidor As Integer, pNotes As String, pEstat As Boolean)
        Me.id = pId
        _idProveidor = pIdProveidor
        Me.notes = pNotes
        _estat = pEstat
    End Sub
    Public Function copy() As proveidorAnotacio
        copy = New proveidorAnotacio
        copy.id = Me.id
        copy.notes = Me.notes
        copy.idProveidor = _idProveidor
        copy.estat = _estat
    End Function
End Class
