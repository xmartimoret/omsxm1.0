Option Explicit On
Public Class Columna
    Inherits Base
    Public Property totalitzador As Boolean
    Public Property projectes As List(Of ProjecteColumna)
    Public Property columnes As List(Of ColumnaFilla)
    Public Sub New()
        _projectes = New List(Of ProjecteColumna)
        _columnes = New List(Of ColumnaFilla)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, esPTotalitzadora As Boolean, pProjectes As List(Of ProjecteColumna), pColumnes As List(Of ColumnaFilla))
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        _totalitzador = esPTotalitzadora
        _projectes = pProjectes
        _columnes = pColumnes
    End Sub

    Public Overrides Property ordre() As String
        Get
            ordre = ""
            If Len(Me.codi) > 0 Then
                ordre = Right(Me.codi, Len(Me.codi) - 1)
            End If
        End Get
        Set(value As String)

        End Set
    End Property
    Public ReadOnly Property copy As Columna
        Get
            copy = New Columna
            copy.id = Me.id
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.ordre = Me.ordre
            copy.notes = Me.notes
            copy.totalitzador = _totalitzador
            copy.columnes = _columnes
            copy.projectes = _projectes

        End Get
    End Property
    Protected Overrides Sub Finalize()
        _columnes = Nothing
        _projectes = Nothing
        MyBase.Finalize()
    End Sub

End Class
