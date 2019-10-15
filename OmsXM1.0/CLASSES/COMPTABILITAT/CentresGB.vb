Option Explicit On
Public Class CentresGB
    Public Property anyActual As Integer
    Public Property mesActual As Integer
    Public Property totAny As Boolean
    Public Property seccions As List(Of Seccio)
    Public Property centres As List(Of Centre)
    Public Property projectes As List(Of Projecte)
    Public Property empresa As Empresa
    Public Property contaplus As Contaplus
    Public Property participacio As Integer
    Public Property rutaGB As String
    Public Property isLog As Boolean
    Public Property isClose As Boolean
    Public Sub New()
        _projectes = New List(Of Projecte)
        _centres = New List(Of Centre)
        _seccions = New List(Of Seccio)
    End Sub
    Public ReadOnly Property mesos As Boolean()
        Get
            Dim temp(12) As Boolean
            If _totAny Then
                For i As Integer = 1 To 12
                    temp(i) = True
                Next
            Else
                For i As Integer = 1 To 12
                    If _mesActual = i Then
                        temp(i) = True
                    Else
                        temp(i) = False
                    End If
                Next
            End If
            Return temp
        End Get
    End Property
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _projectes = Nothing
        _centres = Nothing
        _seccions = Nothing
    End Sub
End Class
