Option Explicit On
Module ModelUnitat
    Private auxiliar As ModelAuxiliar
    Public Function getAuxiliar() As ModelAuxiliar
        If auxiliar Is Nothing Then auxiliar = New ModelAuxiliar(DBCONNECT.getTaulaUnitat)
        Return auxiliar
    End Function
    Public Function getListString() As String()
        Dim ll As List(Of Object), o() As String, i As Integer
        ll = getAuxiliar.getObjects()
        If ll.Count > 0 Then
            ReDim o(ll.Count - 1)
            For Each t As Unitat In ll
                o(i) = t.codi
                i = i + 1
            Next
            Return o
        End If
        Return Nothing
    End Function
    Public Function getObject(id As String) As Object
        Dim p As Object
        p = getAuxiliar.getObjects.Find(Function(x) x.codi = id)
        Return p
    End Function


    Public Sub resetIndex()
        auxiliar = Nothing
    End Sub
End Module
