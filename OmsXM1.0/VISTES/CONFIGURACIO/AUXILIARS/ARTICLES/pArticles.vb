Public Class pArticles
    Private panelArticles As SelectArticles
    Private panelArticlesPreus As SelectarticlePreus
    Private articleActual As article
    Private articlePreuActual As ArticlePreu
    Private esSelect As Boolean
    Private filtre As String
    Friend Event selectArticles(article As article)

    Public Sub New(pEsSelect As Boolean, pFiltre As String)
        ' This call is required by the designer.
        InitializeComponent()
        esSelect = pEsSelect
        filtre = pFiltre

    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub setArticles()
        If esSelect Then
            panelArticles = New SelectArticles(0, True, True, filtre, IDIOMA.getString("articles"), 1)
            AddHandler panelArticles.doubleClick, AddressOf getArticles
        Else
            panelArticles = New SelectArticles(1, False, True, IDIOMA.getString("articles"), 1)
        End If
        AddHandler panelArticles.selectObject, AddressOf getArticle
        Me.SplitContainer1.Panel1.Controls.Clear()
        panelArticles.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel1.Controls.Add(panelArticles)
        panelArticles.Show()
    End Sub
    Private Sub getArticle(a As article)

        articleActual = a
        If articleActual IsNot Nothing Then
            setArticlesPreu()
        End If
    End Sub
    Private Sub getArticles()
        RaiseEvent selectArticles(articleActual)
    End Sub

    Private Sub pArticles_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setArticles()
    End Sub
    Private Sub setArticlesPreu()
        panelArticlesPreus = New SelectarticlePreus(articleActual.id, "", "", 2)
        AddHandler panelArticlesPreus.selectObject, AddressOf getArticlePreu
        Me.SplitContainer1.Panel2.Controls.Clear()
        panelArticlesPreus.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel2.Controls.Add(panelArticlesPreus)
        panelArticlesPreus.Show()
    End Sub
    Private Sub getArticlePreu(a As ArticlePreu)
        articlePreuActual = a
        Me.Dispose()
    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub


End Class
