Imports System.Windows.Forms

Public Class DArticleComanda
    Private articleComandaActual As articleComanda
    Private idComandaActual As Integer
    Private preuArticleActual As ArticlePreu
    Private proveidorActual As Proveidor
    Private listIva As lstAuxiliars1
    Private listUnitats As lstAuxiliars1
    Private actualitzar As Boolean
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Function getNewArticle(pProveidor As Proveidor, idComanda As Integer) As articleComanda
        articleComandaActual = New articleComanda
        proveidorActual = pProveidor
        idComandaActual = idComanda
        If Not IsNothing(pProveidor) Then
            Me.Text = IDIOMA.getString("afegirNouArticle") & " " & IDIOMA.getString("de") & " " & proveidorActual.ToString
        Else
            Me.Text = IDIOMA.getString("afegirNouArticle")
            proveidorActual = New Proveidor
        End If
        Call setLanguage()
        Call setPanels()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            Return getData()
        Else
            Return Nothing
        End If
    End Function
    Public Function getArticle(pArticle As articleComanda, pProveidor As Proveidor) As articleComanda
        articleComandaActual = pArticle
        idComandaActual = pArticle.idComanda
        proveidorActual = pProveidor
        If Not IsNothing(pProveidor) Then
            Me.Text = IDIOMA.getString("modificarArticle") & " " & IDIOMA.getString("de") & " " & proveidorActual.ToString
        Else
            Me.Text = IDIOMA.getString("modificarArticle")
            proveidorActual = New Proveidor
        End If
        Call setLanguage()
        Call setPanels()
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            Return getData()
        Else
            Return Nothing
        End If
    End Function
    Private Sub setLanguage()
        Me.lblCaptionTotal.Text = IDIOMA.getString("total")
        Me.lblCodi.Text = IDIOMA.getString("referencia")
        Me.lblDescompte.Text = IDIOMA.getString("descompte")
        Me.lblDescripcio.Text = IDIOMA.getString("descripcio")
        Me.lblIva.Text = IDIOMA.getString("tipusIva")
        Me.lblPreu.Text = IDIOMA.getString("preu")
        Me.lblQuantitat.Text = IDIOMA.getString("quantitat")
        Me.lblUnitat.Text = IDIOMA.getString("unitats")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
    End Sub
    Private Sub setPanels()
        listIva = New lstAuxiliars1(articleComandaActual.tIva, DBCONNECT.getTaulaTipusIva)
        listUnitats = New lstAuxiliars1(articleComandaActual.unitat, DBCONNECT.getTaulaUnitat)

        Me.panelTipusIva.Controls.Clear()
        listIva.Dock = DockStyle.Fill
        Me.panelTipusIva.Controls.Add(listIva)

        Me.panelUnitats.Controls.Clear()
        listUnitats.Dock = DockStyle.Fill
        Me.panelUnitats.Controls.Add(listUnitats)
    End Sub
    Private Sub setData()
        actualitzar = False
        Me.txtCodi.Text = articleComandaActual.codi
        listUnitats.obj = articleComandaActual.unitat
        listIva.obj = articleComandaActual.tIva
        Me.txtDescompte.Text = articleComandaActual.tpcDescompte
        Me.txtDescripcio.Text = articleComandaActual.nom
        Me.txtPreu.Text = articleComandaActual.preu
        'Call setInfoPreu(articleComandaActual.preu)
        actualitzar = True
    End Sub
    Private Sub setTotal()
        Me.lblTotal.Text = Format(Val(txtQuantitat.Text) * Val(txtPreu.Text) - (Val(txtQuantitat.Text) * Val(txtPreu.Text)) * (Val(txtDescompte.Text) / 100), "#,##0.00")
    End Sub
    Private Sub setInfoPreu(ap As ArticlePreu)
        lblInfoPreu.Text = ap.base & vbCrLf & ModelProveidor.getNom(ap.idProveidor)
    End Sub
    Private Function getData() As articleComanda
        If IsNothing(articleComandaActual) Then
            getData = New articleComanda
        Else
            getData = articleComandaActual.copy
        End If
        getData.codi = Me.txtCodi.Text
        getData.quantitat = Me.txtQuantitat.Text
        getData.tpcDescompte = Me.txtDescompte.Text
        getData.nom = Me.txtDescripcio.Text
        getData.preu = Me.txtPreu.Text
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txtQuantitat_TextChanged(sender As Object, e As EventArgs) Handles txtQuantitat.TextChanged
        If actualitzar Then Call setTotal()
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantitat.KeyPress, txtPreu.KeyPress, txtDescompte.KeyPress
        If sender.Equals(txtQuantitat) Or sender.Equals(txtPreu) Then
            e.KeyChar = VALIDAR.DecimalNegatiu(e.KeyChar, sender.Text, sender.SelectionStart, sender.Text.Length, 16, 4)
        ElseIf sender.Equals(txtDescompte) Then
            e.KeyChar = VALIDAR.EnterMax(e.KeyChar, sender.Text.Length, 3, sender.Text, 100)
        End If
    End Sub

    Private Sub cmdCercadorPreus_Click(sender As Object, e As EventArgs) Handles cmdCercadorPreus.Click
        Dim ap As ArticlePreu, a As article
        a = ModelArticle.getObject(Me.lblCodi.Text)
        If Not IsNothing(a) Then
            ap = dArticlePreus.getPreuArticle(a.id)
            If ap IsNot Nothing Then
                preuArticleActual = ap
                Call setInfoPreu(ap)
                Me.txtPreu.Text = preuArticleActual.base
                Me.txtDescompte.Text = preuArticleActual.descompte
                Call setTotal()
            End If
        End If
        ap = Nothing
    End Sub

    Private Function getArticle(filtre As String) As articleComanda
        Dim a As article, ac As articleComanda, ap As ArticlePreu
        a = DArticles.getArticle(True, txtCodi.Text)
        If a IsNot Nothing Then
            a.preusProveidors = ModelarticlePreu.getObjects(a.id)
            ac = New articleComanda(-1, idComandaActual, 0, a.codi, a.nom)
            ac.codi = a.codi
            ac.unitat = a.unitat
            ac.nom = a.nom
            ac.tIva = a.iva
            ap = a.getUltimPreu(proveidorActual.id)
            If ap IsNot Nothing Then
                ac.preu = ap.base
                ac.tpcDescompte = ap.descompte
            End If
            a = Nothing
                Return ac
            End If
            Return Nothing
    End Function

    Private Sub cmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercador.Click
        articleComandaActual = getArticle(txtCodi.Text)
        If articleComandaActual IsNot Nothing Then Call setData()
    End Sub


    Private Sub txtPreu_TextChanged(sender As Object, e As EventArgs) Handles txtPreu.TextChanged
        If actualitzar Then Call setTotal()
    End Sub

    Private Sub txtDescompte_TextChanged(sender As Object, e As EventArgs) Handles txtDescompte.TextChanged
        If actualitzar Then Call setTotal()
    End Sub

    Private Sub DArticleComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
