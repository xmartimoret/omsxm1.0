Imports OmsXM

Public Class SelectPreus
    Inherits LVSubObjectsSelect

    Friend Event selectObject(ByVal ap As ArticlePreu)
    Public Sub New(pIdArticle As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdArticle
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function filtrar(idParent As String) As DataList
        If IsNumeric(idParent) Then
            Return ModelarticlePreu.getDataList(ModelarticlePreu.getObjects(Val(idParent)))
        End If
        Return Nothing
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim ap As ArticlePreu
        If IsNumeric(id) Then
            ap = ModelarticlePreu.getObject(id)

            If ap IsNot Nothing Then
                RaiseEvent selectObject(ap)
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
