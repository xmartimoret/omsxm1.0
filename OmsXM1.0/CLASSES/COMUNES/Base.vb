Public Class Base
    Inherits ComparadorOrdre
    Public Overridable Property codi As String = ""
    Public Property nom As String = ""
    Public Property notes As String = ""


    Public Overridable Function isFilter(textFiltre As String, Optional opcionalP1 As String = "", Optional opcionalP2 As String = "") As Boolean
        Dim filtres() As String, f As String
        isFilter = False
        If Len(textFiltre) = 0 Then
            isFilter = True
        Else
            filtres = Split(textFiltre, "+")

            'If UBound(filtres) = 0 Then filtres = Split(textFiltre, "*")
            For Each f In filtres
                'ANOTACIONS. 
                ' si hi ha  el caracter comodí as l'esquerra 

                If InStr(1, Me.nom, f, vbTextCompare) > 0 Or
               InStr(1, Me.codi, f, vbTextCompare) > 0 Or
               (opcionalP1 <> "" And InStr(1, opcionalP1, f, vbTextCompare) > 0) Or
               (opcionalP2 <> "" And InStr(1, opcionalP2, f, vbTextCompare) > 0) Then
                    isFilter = True
                    Exit For
                Else
                    isFilter = False
                End If
                Next
            End If
    End Function
    Public Overrides Function ToString() As String
        Return _codi & " - " & _nom
    End Function
End Class
