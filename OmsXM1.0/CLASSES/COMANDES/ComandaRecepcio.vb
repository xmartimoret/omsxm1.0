Public Class ComandaRecepcio
    Friend Property id As Integer = -1
    Friend Property num As Integer
    Friend Property idEmpresa As Integer
    Friend Property codiComanda As String = ""
    Friend Property idMydoc As Long
    Friend Property serie As String
    Friend Property codiEmpresa As String = ""
    Friend Property cifProveidor As String = ""
    Friend Property nomProveidor As String = ""
    Friend Property codiProjecte As String = ""
    Friend Property data As Date
    Friend Property tipusPagament As String
    Friend Property responsableCompra As String = ""
    Friend Property base As Double = 0
    Friend Property estat As Boolean
    Public Function isFilter(textFiltre As String, Optional opcionalP1 As String = "", Optional opcionalP2 As String = "") As Boolean
        'Dim filtres() As String, f As String, fComanda As String = ""
        'isFilter = False
        'If Len(textFiltre) = 0 Then
        '    isFilter = True
        'Else
        '    If Not IsNothing(_codiProjecte) Then fComanda = _projecte.codi
        '    If Not IsNothing(_proveidor) Then fComanda = fComanda & _proveidor.nom
        '    If Not IsNothing(_empresa) Then fComanda = fComanda & _empresa.nom
        '    filtres = Split(textFiltre, "+")
        '    For Each f In filtres
        '        If InStr(1, fComanda, f, vbTextCompare) > 0 Or
        '       (opcionalP1 <> "" And InStr(1, opcionalP1, f, vbTextCompare) > 0) Or
        '       (opcionalP2 <> "" And InStr(1, opcionalP2, f, vbTextCompare) > 0) Then
        '            isFilter = True
        '            Exit For
        '        Else
        '            isFilter = False
        '        End If
        '    Next
        '    If Not isFilter Then
        '        isFilter = False
        '        filtres = Split(textFiltre, "*")
        '        For Each f In filtres
        '            If InStr(1, fComanda, f, vbTextCompare) > 0 Or
        '           (opcionalP1 <> "" And InStr(1, opcionalP1, f, vbTextCompare) > 0) Or
        '           (opcionalP2 <> "" And InStr(1, opcionalP2, f, vbTextCompare) > 0) Then
        '                isFilter = True
        '                Exit For
        '            Else
        '                isFilter = False
        '            End If
        '        Next
        '    End If
        'End If
    End Function
    Public Overrides Function ToString() As String
        Return codiComanda
    End Function
End Class
