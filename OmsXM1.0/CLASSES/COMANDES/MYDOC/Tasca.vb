Option Explicit On
Public Class Tasca
    Inherits Base
    Public Sub New()

    End Sub
    Public Sub New(pID As Integer, pDescripcio As String, pOrdre As String)
        Me.id = pID
        Me.nom = pDescripcio
        Me.ordre = pOrdre
    End Sub
End Class
