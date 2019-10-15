Option Explicit On
Public Class PrefixSubcte
    Inherits ComparadorOrdre
    Public Property prefix As String
    Public Property idSubcompte As Integer
    Public Property codiSubcompte As String
    Public Property descripcioSubcompte As String
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pIdSubcompte As Integer, pPrefix As String, pCodiSubcompte As String, pDescripcioSubcompte As String)
        Me.id = pId
        _idSubcompte = pIdSubcompte
        _prefix = pPrefix
        Me.ordre = 7 - pPrefix.Length
        _codiSubcompte = pCodiSubcompte
        _descripcioSubcompte = pDescripcioSubcompte
    End Sub
    Public ReadOnly Property copy() As PrefixSubcte
        Get
            copy = New PrefixSubcte
            copy.id = Me.id
            copy.ordre = Me.ordre
            copy.prefix = _prefix
            copy.idSubcompte = _idSubcompte
            copy.codiSubcompte = _codiSubcompte
            copy.descripcioSubcompte = _descripcioSubcompte
        End Get
    End Property
    Public ReadOnly Property isfilter(p As String) As Boolean
        Get
            isfilter = False
            If Len(p) = 0 Then
                isfilter = True
            Else
                If IsNumeric(p) Then
                    If Left(_codiSubcompte, Len(p)) = p Then
                        isfilter = True
                    End If
                Else
                    If InStr(1, _descripcioSubcompte, p, vbTextCompare) <> 0 Then
                        isfilter = True
                    ElseIf InStr(1, _prefix, p, vbTextCompare) <> 0 Then
                        isfilter = True
                    End If
                End If
            End If
        End Get
    End Property
    Public Overrides Function toString() As String
        Return _prefix
    End Function
End Class
