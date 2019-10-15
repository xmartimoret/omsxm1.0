Option Explicit On
Public Class CentreFullaGB
    Inherits ComparadorOrdre
    Public Property idCentre As Integer
    Public Property nomCentre As String
    Public Property codiCentre As String
    Public Property codiSeccio As String
    Public Property codiEmpresa As String
    Public Property nomGb As String

    Public Sub New()
    End Sub

    Public ReadOnly Property toStringCentre() As String
        Get
            Return "(" & _codiEmpresa & "-" & _codiSeccio & ") " & _nomCentre
        End Get
    End Property
End Class
