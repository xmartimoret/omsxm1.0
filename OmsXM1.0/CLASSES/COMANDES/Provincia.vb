Public Class Provincia
    Inherits Base
    Public Property actiu As Boolean = True
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String)
        Me.id = pId
        Me.codi = pCodi
        Me.ordre = pNom
        Me.nom = pNom
    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pCodi As String, pNom As String)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
    End Sub
    Public Function copy() As Provincia
        copy = New Provincia()
        copy.id = Me.id
        copy.codi = Me.codi
        copy.nom = Me.nom
    End Function
    Public Overrides Function ToString() As String
        Return nom
    End Function
End Class
