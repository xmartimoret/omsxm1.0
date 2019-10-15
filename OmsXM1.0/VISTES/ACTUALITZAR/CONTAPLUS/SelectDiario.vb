

Public Class SelectDiario
    Inherits LVSubObjectsSelect
    Friend Event selectObject(ByVal c As Contaplus)
    Public Sub New(pIdEmpresa As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdEmpresa
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function filtrar(idParent As String) As DataList
        If IsNumeric(idParent) Then
            Return ModelEmpresaContaplus.getDataList(ModelEmpresaContaplus.getObjects(Val(idParent)))
        End If
        Return Nothing
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim c As Contaplus
        If IsNumeric(id) Then
            c = ModelEmpresaContaplus.getObject(id)
            If c IsNot Nothing Then
                RaiseEvent selectObject(c)
                Return True
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Function mostrar(id As String) As Boolean
        Throw New NotImplementedException()
    End Function
End Class
