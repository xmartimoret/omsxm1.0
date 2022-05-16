Public Class PedidoMD
    Inherits Base
    Friend Property estat As Integer
    Friend Property codiProjecte As String
    Friend Property projecte As String
    Friend Property proveidor As String
    Friend Property empresa As String
    Friend Property usuari As String
    Friend Property departament As String
    Friend Property events As List(Of EventsMD)
    Public Sub New()
        _events = New List(Of EventsMD)
    End Sub
    Public Sub New(pID As Integer, pCodi As String, pNom As String, pEstat As Integer)
        Me.id = pID
        Me.codi = pCodi
        Me.nom = pNom
        _estat = pEstat
        _events = New List(Of EventsMD)
    End Sub


    Public Function getEstatWorkflow() As EventsMD
        Dim e As EventsMD
        If Not IsNothing(events) Then
            For Each e In events
                If e.finalitzat = 0 Then
                    Return e
                End If
            Next
        End If
        Return Nothing
    End Function
End Class
