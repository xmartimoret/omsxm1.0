Public Class SelectArticles
    Inherits LVObjects
    Friend Property articles As List(Of article)
    Friend Event selectObject(p As article)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol

        Me.orderColumn = 1
        articles = New List(Of article)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pFiltre As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.txtFiltrar.Text = pFiltre
        Me.orderColumn = 1
        articles = New List(Of article)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DArticle.getarticle(New article))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As article
        d = ModelArticle.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_ARTICLE(d.ToString) Then
                Return ModelArticle.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelArticle.getDataList(ModelArticle.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DArticle.getarticle(ModelArticle.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        articles = New List(Of article)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                articles.Add(ModelArticle.getObject(i))
            Next
            RaiseEvent selectObject(articles.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As article) As Integer
        If Not obj Is Nothing Then
            If Not ModelArticle.exist(obj) Then
                If Not ModelArticle.existCodi(obj) Then
                    RaiseEvent selectObject(obj)
                    Return ModelArticle.save(obj)
                Else
                    Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
                End If
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        articles = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelArticle.getListViewItem(id)
    End Function
    Private Function getOrderedObjects() As List(Of article)
        Dim i As Integer, o As article
        getOrderedObjects = New List(Of article)
        For Each i In Me.getIndexs
            o = ModelArticle.getObject(i)
            getOrderedObjects.Add(o)
        Next
    End Function
    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        Call modulInfoArticle.execute(getOrderedObjects, pdf.ToString, filtre)
    End Sub

    Public Overrides Sub actualitzar(id As List(Of Integer))

    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class
