Option Explicit On
Public Class EntradaLog
    Inherits ComparadorOrdre
    Public Property codi As Integer
    Public Property titol As String
    Public Property descripcio As String
    Private _ordre As String = ""
    Public Overrides Property ordre() As String
        Get
            If _ordre = "" Then
                Return CStr(Me.id)
            Else
                Return _ordre
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return _titol & " - " & _descripcio
    End Function

End Class
