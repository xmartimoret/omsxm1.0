Imports System.Math
Public Class EnterLlarg
    Private Const maxim As Long = 2000000000
    Private valorEnter As Long
    Private comptador As Integer
    Public Sub New()
        valorEnter = 0
        comptador = 0
    End Sub
    Public Property valordecimal() As Double
        Get
            valordecimal = Math.Round((valorEnter + maxim * comptador) / 100, 2)
        End Get
        Set(value As Double)
            If valorEnter + Round(value * 100, 0) > maxim Then
                comptador = comptador + 1
                valorEnter = valorEnter - maxim + Round(value * 100, 0)
            Else
                valorEnter = valorEnter + Round(value * 100, 0)
            End If
        End Set
    End Property

    Public WriteOnly Property valorLong() As Long
        Set(value As Long)
            If valorEnter + value > maxim Then
                comptador = comptador + 1
                valorEnter = valorEnter - maxim + value
            Else
                valorEnter = valorEnter + value
            End If
        End Set
    End Property
End Class
