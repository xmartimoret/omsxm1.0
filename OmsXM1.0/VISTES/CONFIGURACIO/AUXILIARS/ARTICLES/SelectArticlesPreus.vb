Public Class SelectarticlePreus
    Inherits LVSubObjects
    Friend Property articlePreu As List(Of ArticlePreu)
    Friend Event selectObject(p As ArticlePreu)
    Public Sub New(pIdArticle As Integer, pNomProjecte As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdArticle
        Me.titol = pTitol
        Me.orderColumn = 1
        articlePreu = New List(Of ArticlePreu)
    End Sub

    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As ArticlePreu
        d = ModelarticlePreu.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_ARTICLE_PREU(d.ToString) Then
                Return ModelarticlePreu.remove(d)
            End If
        End If
        Return False
    End Function


    Private Function save(obj As ArticlePreu) As Integer
        If Not obj Is Nothing Then

            RaiseEvent selectObject(obj)
                Return ModelarticlePreu.save(obj)

        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        articlePreu = Nothing
    End Sub
    Public Overrides Function filtrar(id As Integer) As DataList
        Return ModelarticlePreu.getDataList(ModelarticlePreu.getObjects(id))
    End Function

    Public Overrides Function afegir(id As Integer) As Boolean
        Return save(DArticlePreu.getArticlePreu(New ArticlePreu(Me.idParent)))
    End Function

    Public Overrides Function modificar(id As Integer) As Boolean
        Return save(DArticlePreu.getArticlePreu(ModelarticlePreu.getObject(id)))
    End Function
End Class
