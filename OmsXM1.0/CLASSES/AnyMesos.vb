Option Explicit On
Public Class AnyMesos
    Public Property any As Integer
    Private _mesos(12) As Boolean
    Private _esReal(12) As Boolean
    Private _esGB(12) As Boolean
    Public Property idEmpresa As Integer
    Public Property participacio As Integer
    Public Property isLog As Boolean
    Public Property ruta As String
    Public Sub setMes(m As Integer, estat As Boolean)
        _mesos(m) = estat
    End Sub
    Public Sub setReal(m As Integer, estat As Boolean)
        _esReal(m) = estat
    End Sub
    Public Sub setGB(m As Integer, estat As Boolean)
        _esGB(m) = estat
    End Sub

    Public ReadOnly Property esReal(m As Integer) As Boolean
        Get
            Return _esReal(m)
        End Get
    End Property
    Public ReadOnly Property esGB(m As Integer) As Boolean
        Get
            Return _esGB(m)
        End Get
    End Property
    Public ReadOnly Property esActiu(m As Integer) As Boolean
        Get
            Return _mesos(m)
        End Get
    End Property

    Public ReadOnly Property mesos() As Boolean()
        Get
            Return _mesos
        End Get

    End Property
End Class
