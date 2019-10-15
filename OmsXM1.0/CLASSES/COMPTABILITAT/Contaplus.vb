Option Explicit On
Public Class Contaplus : Implements IComparable
    Public Property id As Integer = -1
    Public Property anyo As Integer
    Public Property nom As String
    Public Property idEmpresa As Integer
    Public Property esContaplus As Boolean
    Public Property actualitzar As Boolean = False
    Public Sub New()

    End Sub
    Public Sub New(pidEmpresa As Integer)
        _idEmpresa = pidEmpresa
    End Sub
    Public Sub New(pId As Integer, pidEmpresa As Integer, pAnyo As Integer, pNom As String, pEsContaplus As Boolean)
        _id = pId
        _anyo = pAnyo
        _idEmpresa = pidEmpresa
        _nom = pNom
        _esContaplus = pEsContaplus
    End Sub
    Public ReadOnly Property copy As Contaplus
        Get
            copy = New Contaplus
            copy.id = _id
            copy.anyo = _anyo
            copy.idEmpresa = _idEmpresa
            copy.nom = _nom
            copy.esContaplus = _esContaplus
            copy.actualitzar = _actualitzar
        End Get
    End Property
    Public Overrides Function GetHashCode() As Integer
        Return _id
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse obj.GetType Is Me.GetType Then Return False
        Return obj.id = _id
    End Function
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse obj.GetType IsNot Me.GetType Then Return -1
        If obj.anyo = _anyo Then
            Return 0
        ElseIf obj.anyo > anyo Then
            Return -1
        Else
            Return 1
        End If
    End Function
    Public Overrides Function ToString() As String
        Return _anyo
    End Function
End Class
