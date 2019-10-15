Option Explicit On
Public Class Assentament
    Inherits ComparadorOrdre
    Public Property numero As Long
    Public Property dataAssentament As Date
    Public Property document As String
    Public Property departamentAssentament As String
    Public Property projecteAssentament As String
    Public Property subcompteAssentament As String
    Public Property contrapartida As String
    Public Property clave As String
    Public Property concepte As String
    Public Property deure As Long
    Public Property haver As Long
    Private _ordre As String
    Public Property seleccionat As Boolean
    Public Property saldoAcumulat As Long
    Public Sub New()
        _deure = 0
        _haver = 0
        _ordre = ""
        _seleccionat = True
    End Sub
    Public Sub New(pNumero As Long, pFecha As Date, pContra As String, pSubcompte As String, pConcepte As String, pDocument As String, pDeparta As String, pClave As String, pDeure As Long, pHaver As Long)
        _numero = pNumero
        _dataAssentament = pFecha
        _contrapartida = pContra
        _subcompteAssentament = pSubcompte
        _concepte = pConcepte
        _departamentAssentament = pDeparta
        _clave = pClave
        _deure = pDeure
        _haver = pHaver
        _document = pDocument
    End Sub
    Public Overrides Property ordre() As String
        Get
            If Len(_ordre) = 0 Then
                ordre = CStr(_numero)
            Else
                ordre = _ordre
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set
    End Property
    Public ReadOnly Property isfilter(filter As String) As Boolean
        Get
            isfilter = False
            If Len(filter) = 0 Then
                isfilter = True
            Else
                If InStr(1, _numero, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _dataAssentament, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _clave, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _departamentAssentament, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _projecteAssentament, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _contrapartida, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _concepte, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _subcompteAssentament, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _deure, filter, vbTextCompare) > 0 Then
                    isfilter = True
                ElseIf InStr(1, _haver, filter, vbTextCompare) > 0 Then
                    isfilter = True
                End If
            End If
        End Get
    End Property
    Public ReadOnly Property saldo() As Long
        Get
            saldo = _deure - _haver
        End Get
    End Property
    Public Overrides Function toString() As String
        toString = _numero & " - " & _concepte
    End Function
End Class
