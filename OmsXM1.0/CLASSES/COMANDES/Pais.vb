Public Class Pais
    Inherits Base
    Public Property abreviatura As String
    Public Property actiu As Boolean = True
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pAbreviatura As String, pCodi As String, pNom As String)
        Me.id = pId
        Me.codi = pCodi
        Me.ordre = pNom

        Me.nom = pNom
        _abreviatura = pAbreviatura
    End Sub
    Public Sub New(pId As Integer, pOrdre As String, pAbreviatura As String, pCodi As String, pNom As String)
        Me.id = pId
        Me.ordre = pOrdre
        Me.codi = pCodi
        Me.nom = pNom
        _abreviatura = pAbreviatura
    End Sub
    Public Function copy() As Pais
        copy = New Pais()
        copy.id = Me.id
        copy.codi = Me.codi
        copy.abreviatura = Me.abreviatura
        copy.nom = Me.nom
    End Function
    Public Overrides Function ToString() As String
        Return nom
    End Function
End Class
