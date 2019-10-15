

Public Class SelectEmpresesContaplus
    Inherits LVSubObjects
    Friend Property empreses As List(Of Contaplus)
    Friend Property nomEmpresa As String
    Public Sub New(pIdEmpresa As Integer, pNomEmpresa As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdEmpresa
        _nomEmpresa = pNomEmpresa
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        empreses = New List(Of Contaplus)
    End Sub
    Public Overrides Function afegir(id As Integer) As Boolean
        Return save(DContaplus.getEmpresa(New Contaplus(id), nomEmpresa))
    End Function

    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim e As Contaplus
        e = ModelEmpresaContaplus.getObject(id)
        If e.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_EMPRESA(e.ToString) Then
                Return ModelEmpresaContaplus.remove(e)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(idParent As Integer) As DataList
        Return ModelEmpresaContaplus.getDataList(ModelEmpresaContaplus.getObjects(idParent))
    End Function

    Public Overrides Function modificar(id As Integer) As Boolean
        Return save(DContaplus.getEmpresa(ModelEmpresaContaplus.getObject(id), nomEmpresa))
    End Function
    Private Function save(obj As Contaplus) As Boolean
        If Not obj Is Nothing Then
            If Not ModelEmpresaContaplus.existName(obj) Then
                If Not ModelEmpresaContaplus.existAny(obj) Then
                    Return ModelEmpresaContaplus.save(obj)
                Else
                    Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_ANY_REGISTRE)
                End If
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        empreses = Nothing
    End Sub
End Class
