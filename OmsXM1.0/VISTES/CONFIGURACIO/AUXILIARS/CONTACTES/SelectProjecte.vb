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
End Class
