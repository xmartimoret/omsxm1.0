Option Explicit On
Public Class Log
    Public Property id As Integer
    Public Property titol As String
    Public Property descripcio As String
    Public Property entrades As List(Of EntradaLog)
    Public Sub New()
        _entrades = New List(Of EntradaLog)
    End Sub
    Public Sub New(pId As Integer, pTitol As String, pDescripcio As String)
        _id = pId
        _titol = pTitol
        _descripcio = pDescripcio
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _entrades = Nothing
    End Sub
End Class
