Module ModelResponsableCompra
    Private auxiliar As ModelAuxiliar
    Public Function getAuxiliar() As ModelAuxiliar
        If auxiliar Is Nothing Then auxiliar = New ModelAuxiliar(DBCONNECT.getTaulaResponsableCompra)
        Return auxiliar
    End Function
    Public Function getListString() As String()
        Dim ll As List(Of Object), o() As String, i As Integer
        ll = getAuxiliar.getObjects()
        If ll.Count > 0 Then
            ReDim o(ll.Count - 1)
            For Each t As ResponsableCompra In ll
                o(i) = t.codi
                i = i + 1
            Next
            Return o
        End If
        Return Nothing
    End Function
    Public Function getObject(id As String) As Object
        Dim p As Object
        p = getAuxiliar.getObjects.Find(Function(x) LCase(x.codi) = LCase(id))
        Return p
    End Function
    Public Function getObject(nom As String, cognom As String) As Object
        Dim p As Object
        p = getAuxiliar.getObjects.Find(Function(x) (InStr(x.nom, nom, CompareMethod.Text) > 0 And InStr(x.nom, cognom, CompareMethod.Text) > 0))
        Return p
    End Function
    Public Function save(obj As ResponsableCompra) As Integer
        Dim result As Integer
        result = auxiliar.save(obj)
        If result > 0 Then If Not GOOGLE_SHEETS.save(obj) Then Call ERRORS.ERR_UPDATE_GOOGLE_SHEETS()
        Return result
    End Function
    Public Function remove(obj As ResponsableCompra) As Integer
        Dim result As Boolean
        result = auxiliar.remove(obj)
        If result Then If Not GOOGLE_SHEETS.remove(obj) Then Call ERRORS.ERR_UPDATE_GOOGLE_SHEETS()
        Return obj.id
    End Function
    Public Sub resetIndex()
        auxiliar = Nothing
    End Sub
End Module
