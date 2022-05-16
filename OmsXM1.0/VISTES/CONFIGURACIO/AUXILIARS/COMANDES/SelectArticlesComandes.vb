Public Class SelectArticlesComandes
    Inherits LVObjectsCopiar
    Friend Property comandes As List(Of Comanda)

    Friend Event selectObject(p As Comanda)

    Public Sub New(pTitol As String, pComandes As List(Of Comanda))
        Me.accio = 0
        Me.multiselect = False
        Me.isForm = False
        Me.titol = pTitol
        Me.orderColumn = 1
        comandes = pComandes

    End Sub
    Public Overrides Function eliminar() As Boolean
        Return False
    End Function
    Public Overrides Function filtrar(txt As String) As DataList
        Dim a As Comanda, altres As String = "", objects As List(Of Comanda), ac As articleComanda, articles As List(Of articleComanda), aCopia As Comanda
        objects = New List(Of Comanda)
        For Each a In comandes
            If a.proveidor IsNot Nothing Then altres = a.proveidor.nom
            If a.projecte IsNot Nothing Then altres = altres & a.projecte.nom
            If a.empresa IsNot Nothing Then altres = altres & a.empresa.nom
            altres = altres & a.total
            altres = altres & a.base
            For Each ac In a.articles
                altres = altres & ac.codi & ac.preu & ac.base & ac.nom
            Next
            articles = New List(Of articleComanda)
            If altres <> "" Then
                If a.isFilter(txt, altres) Then
                    aCopia = a.copy
                    For Each ac In aCopia.articles
                        If ac.isFilter(txt) Then articles.Add(ac)
                    Next
                    aCopia.articles = articles
                    objects.Add(aCopia)
                End If
            Else
                If a.isFilter(txt) Then
                    aCopia = a.copy
                    For Each ac In aCopia.articles
                        If ac.isFilter(txt) Then articles.Add(ac)
                    Next
                    aCopia.articles = articles
                    objects.Add(aCopia)
                End If
            End If
        Next
        filtrar = ModelComanda.getDataListArticles(objects)
        objects = Nothing
    End Function


    Public Overrides Function seleccionar(id As Integer, estat As Integer) As Boolean
        Return False
    End Function
    Private Function save(obj As Comanda) As Integer
        Return -1
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        comandes = Nothing
    End Sub

    Public Overrides Function copiar() As Integer

        Return Nothing
    End Function

    Public Overrides Function mostrar() As Boolean
        Return False
    End Function

    Public Overrides Sub imprimir(pdf As Boolean, dades As List(Of List(Of String)), filtre As String)
        Call modulInfoArticle.execute(dades, pdf, filtre)
    End Sub
End Class
