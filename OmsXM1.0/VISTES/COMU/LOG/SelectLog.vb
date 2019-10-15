Public Class SelectLog
    Inherits LVSubObjectsSelect
    Private logActual As Log
    Friend Event selectObject(ByVal c As EntradaLog)
    Friend Event ShowObject(ByVal c As EntradaLog)
    Public Sub New(pLog As Log, pTitol As String, pTipusLog As Integer)
        logActual = pLog
        Me.titol = pTitol
        Me.idParent = pTipusLog
    End Sub
    Public Overrides Function filtrar(idParent As String) As DataList
        If logActual IsNot Nothing Then
            Return ModelLog.getDataList(logActual, idParent)
        End If
        Return Nothing
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim obj As EntradaLog
        obj = logActual.entrades.Find(Function(x) x.id = id)
        If obj IsNot Nothing Then
            RaiseEvent selectObject(obj)
            Return True
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Function mostrar(id As String) As Boolean
        Dim obj As EntradaLog
        obj = logActual.entrades.Find(Function(x) x.id = id)
        If obj IsNot Nothing Then
            RaiseEvent ShowObject(obj)
            Return True
        End If
        Return False
    End Function
End Class
