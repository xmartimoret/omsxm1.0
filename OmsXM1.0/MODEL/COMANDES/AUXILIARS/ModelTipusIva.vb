Option Explicit On
Module ModelTipusIva
    Private auxiliar As ModelAuxiliar
    Public Function getAuxiliar() As ModelAuxiliar
        If auxiliar Is Nothing Then auxiliar = New ModelAuxiliar(DBCONNECT.getTaulaTipusIva)
        Return auxiliar
    End Function
    Public Function getListStringIvaActiva() As String()
        Dim ll As List(Of Object), o() As String, i As Integer
        ll = getAuxiliar.getObjectsActius()
        If ll.Count > 0 Then
            ReDim o(ll.Count - 1)
            For Each t As TipusIva In ll
                o(i) = t.toString
                i = i + 1
            Next
            Return o
        End If
        Return Nothing
    End Function

    Public Sub resetIndex()
        auxiliar = Nothing
    End Sub
End Module
