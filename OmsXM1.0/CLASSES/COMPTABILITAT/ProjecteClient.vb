Option Explicit On
Public Class ProjecteClient : Implements IComparable
    Public Property idProjecte As Integer
    Public Property idEmpresa As Integer
    Public Property idClient As Integer
    Public Property clau As String
    Public Property departa As String
    Private _ordre As String

    Public Property toStringTransitoria As String
    Public Property identificador As String
    Public Property transitories As Collection

    Public Sub New()
        _transitories = New Collection
    End Sub

    Public Sub New(pIDClient As String, pIdProjecte As Integer, pIdEmpresa As Integer, pCodi As String, pNom As String, pOrdre As String)
        _idClient = pIDClient
        _idProjecte = pIdProjecte
        _clau = Right(pCodi, Len(pCodi) - 3)
        _departa = Left(pCodi, 3)
        _toStringTransitoria = pCodi & " - " & pNom
        _idEmpresa = pIdEmpresa
        _ordre = pOrdre
        _transitories = New Collection
    End Sub
    Public Property ordre() As String
        Get
            If _ordre = "" Then
                ordre = _idProjecte
            Else
                ordre = _ordre
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set
    End Property

    Public ReadOnly Property id() As String
        Get
            Return "C" & _idClient & "P" & _idProjecte
        End Get

    End Property

    Public ReadOnly Property transitoriesMes(m As Integer) As Collection
        Get
            Dim t As Transitoria
            transitoriesMes = New Collection
            For Each t In transitories
                If t.mes = m Then transitoriesMes.Add(t)
            Next t
            t = Nothing
        End Get
    End Property

    Public Function isfilter(p As String) As Boolean
        isfilter = False
        If Len(p) = 0 Then
            isfilter = True
        Else
            If InStr(1, ToString, p, vbTextCompare) > 0 Then
                isfilter = True
            End If
        End If
    End Function


    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsNumeric(_ordre) And IsNumeric(obj.ordre) Then
            If _ordre < obj.ordre Then
                Return -1
            ElseIf _ordre > obj.ordre Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return StrComp(_ordre, obj.ordre)
        End If
    End Function

    Protected Overrides Sub Finalize()
        _transitories = Nothing
        MyBase.Finalize()
    End Sub
End Class
