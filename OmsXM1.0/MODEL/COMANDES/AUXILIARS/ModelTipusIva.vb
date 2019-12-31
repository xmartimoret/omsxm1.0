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
    Public Function getValor(p As String) As Single
        Dim ll As List(Of Object)
        ll = getAuxiliar.getObjects()
        If ll.Count > 0 Then
            For Each t As TipusIva In ll
                If StrComp(p, t.toString) = 0 Then
                    Return t.impost / 100
                End If
            Next
        End If
        Return 0
    End Function
    Public Function getObjectByToString(p As String) As TipusIva
        Dim ll As List(Of Object)
        ll = getAuxiliar.getObjects()
        If ll.Count > 0 Then
            For Each t As TipusIva In ll
                If StrComp(p, t.toString) = 0 Then
                    Return t
                End If
            Next
        End If
        Return Nothing
    End Function
    Public Sub resetIndex()
        auxiliar = Nothing
    End Sub
End Module
