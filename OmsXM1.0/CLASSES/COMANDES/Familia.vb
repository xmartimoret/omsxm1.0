﻿Public Class Familia
    Inherits Base
    Public Sub New()
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
    End Sub
    Public Function copy() As Familia
        copy = New Familia
        copy.id = Me.id
        copy.codi = Me.codi
        copy.nom = Me.nom
    End Function
    Public Overrides Function toString() As String
        Return nom
    End Function
End Class
