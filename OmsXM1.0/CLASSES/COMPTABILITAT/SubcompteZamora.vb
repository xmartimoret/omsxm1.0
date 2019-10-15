Option Explicit On
Public Class SubcompteZamora
    Inherits Base
    Public Property idSubcompte As Integer
    Public Property assentaments As List(Of Assentament)
    Public Property esUnic As Boolean = False

    Public Sub New()
        _assentaments = New List(Of Assentament)
    End Sub
    Public Sub New(pId As Integer, pIdSubcompte As Integer, pNom As String, pUnic As Boolean)
        Me.id = pId
        Me.nom = pNom
        _idSubcompte = pIdSubcompte
        _esUnic = pUnic
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _assentaments = Nothing
    End Sub
End Class
