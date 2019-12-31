Imports System.Windows.Forms

Public Class DArticles
    Private articles As pArticles
    Private articleActual As article
    Public Function getArticle(pSelect As Boolean, pFiltrar As String) As article
        articles = New pArticles(pSelect, pFiltrar)
        setPanel()
        Me.ShowDialog()
        getArticle = articleActual
        Me.Dispose()
    End Function

    Public Sub New()
        InitializeComponent()
        articles = New pArticles()
        setPanel()
    End Sub
    Public Sub New(pSelect As Boolean, pFiltrar As String)
        InitializeComponent()
        articles = New pArticles(pSelect, pFiltrar)
        setPanel()
    End Sub
    Private Sub setPanel()
        Me.Controls.Clear()
        articles.Dock = DockStyle.Fill
        AddHandler articles.selectArticles, AddressOf getArticle
        Me.Controls.Add(articles)
        articles.Show()

    End Sub
    Private Sub getArticle(a As article)
        Me.DialogResult = DialogResult.OK
        articleActual = a
        Me.Hide()

    End Sub

End Class
