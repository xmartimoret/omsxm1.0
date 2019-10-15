Option Explicit On
Module ModelUnitat
    Private auxiliar As ModelAuxiliar
    Public Function getAuxiliar() As ModelAuxiliar
        If auxiliar Is Nothing Then auxiliar = New ModelAuxiliar(DBCONNECT.getTaulaUnitat)
        Return auxiliar
    End Function
    Public Sub resetIndex()
        auxiliar = Nothing
    End Sub
End Module
