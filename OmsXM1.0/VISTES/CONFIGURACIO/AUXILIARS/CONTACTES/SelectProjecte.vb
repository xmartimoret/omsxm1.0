Public Class SelectProjecte
    Inherits LVSelectObject
    Friend Event selectObject(p As Projecte)
    Public Sub New(Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelProjecte.getDataList(ModelProjecte.getObjects(txt))
    End Function
    Public Overrides Function seleccionar(id As Integer) As Boolean
        RaiseEvent selectObject(ModelProjecte.getObject(id))
        Return True
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DProjecteResponsables.getProjecte(ModelProjecte.getObject(id)))
    End Function
    Private Function save(obj As Projecte) As Integer
        If Not obj Is Nothing Then
            If Not ModelProjecte.exist(obj) Then
                Return ModelProjecte.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function
End Class
