Public Class pArticles
    Private panelArticles As SelectArticles
    Private panelArticlesPreus As SelectarticlePreus
    Private articleActual As article
    Private articlePreuActual As ArticlePreu
    Private esSelect As Boolean
    Private filtre As String
    Friend Event selectArticles(article As article)
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(pEsSelect As Boolean, pFiltre As String)
        ' This call is required by the designer.
        InitializeComponent()
        esSelect = pEsSelect
        filtre = pFiltre

    End Sub
    Private Sub setArticles()
        If esSelect Then
            panelArticles = New SelectArticles(0, True, True, filtre, IDIOMA.getString("articles"), 1)
            AddHandler panelArticles.doubleClick, AddressOf getArticles
        Else
            panelArticles = New SelectArticles(1, False, True, IDIOMA.getString("articles"), 1)
        End If
        AddHandler panelArticles.selectObject, AddressOf getArticle
        panelArticles.Dock = DockStyle.Fill
        panelArticles.Show()
        Me.Controls.Add(panelArticles)
    End Sub
    Private Sub getArticle(a As article)
        articleActual = a
        RaiseEvent selectArticles(articleActual)
    End Sub
    Private Sub getArticles()
        RaiseEvent selectArticles(articleActual)
    End Sub

    Private Sub pArticles_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setArticles()
    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

End Class
