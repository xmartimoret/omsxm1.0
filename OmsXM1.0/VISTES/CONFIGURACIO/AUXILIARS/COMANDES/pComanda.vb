'TODO CAL PREVEURE QUAN ES MOSTRIN COMANDES EXISTENTS, ES A DIR QUE NO SIGUIN SOLICITUTS
Class pComanda
    Private panelProv As panelDesplagableProveidor
    Private comandaActual As Comanda
    Private articleComandaActual As articleComanda
    Private articleCopiat As articleComanda
    Private panelEmpr As panelDesplegableEmpresa
    Private panelComanda As panelDesplegableComanda
    Private actualitzar As Boolean
    Private filesCopiades As List(Of DataGridViewRow)
    Private isEnterCell As Boolean
    Private Const C_ID As String = "ID"
    Private Const C_CODI As String = "CODI"
    Private Const C_DESCRIPCIO As String = "DESCRIPCIO"
    Private Const C_IVA As String = "IVA"
    Private Const C_IMPORT As String = "IMPORT"
    Private Const C_QUANTITAT As String = "QUANTITAT"
    Private Const C_UNITAT As String = "UNITAT"
    Private Const C_DESCOMPTE As String = "DESCOMPTE"
    Private Const C_BASE As String = "BASE"
    Private Const C_TOTAL As String = "TOTAL"
    Private Const C_CODI_F56 As String = "REFERENCIAF56"
    Private Const C_DESCRIPCIO_F56 As String = "DESCRIPCIOF56"
    Private Const C_BASE_F56 As String = "BASEF56"
    Private Const C_QUANTITAT_f56 As String = "QUANTITATF56"
    Private Const C_UNITAT_F56 As String = "UNITATF56"
    Private Const C_DESCOMPTE_F56 As String = "DESCOMPTEF56"
    Private Const C_TOTAL_F56 As String = "TOTALF56"
    Friend Event UpdateComanda()
    Private dataclipBoard(,) As String
    'Private actionMouseDown As Boolean

    Public Sub New(p As Comanda)
        actualitzar = False

        InitializeComponent()
        SplitC.Panel2Collapsed = True
        comandaActual = p
        DGVArticles.Rows.Add(30)
        panelProv = New panelDesplagableProveidor(Me.Height * 0.4, "p", comandaActual.proveidor, comandaActual.contacteProveidor)
        panelEmpr = New panelDesplegableEmpresa(Me.Height * 0.4, "e", comandaActual.empresa, comandaActual.projecte, comandaActual.magatzem, comandaActual.contacte, comandaActual.responsable, comandaActual.director)
        panelComanda = New panelDesplegableComanda(Me.Height * 0.4, "c", comandaActual)
        AddHandler panelProv.accioMostrar, AddressOf setAccio
        AddHandler panelEmpr.accioMostrar, AddressOf setAccio
        AddHandler panelComanda.accioMostrar, AddressOf setAccio
        AddHandler panelComanda.selectObject, AddressOf setEmpresa
        AddHandler panelProv.selectObject, AddressOf setProveidor
        AddHandler panelEmpr.selectObject, AddressOf setEmpresa
        AddHandler panelEmpr.selectProjecte, AddressOf setProjecte

        ' Add any initialization after the InitializeComponent() call.
        Panel6.Controls.Clear()
        Panel7.Controls.Clear()
        Panel8.Controls.Clear()
        panelProv.Dock = DockStyle.Fill
        panelEmpr.Dock = DockStyle.Fill
        panelComanda.Dock = DockStyle.Fill
        Panel6.Controls.Add(panelProv)
        Panel7.Controls.Add(panelEmpr)
        Panel8.Controls.Add(panelComanda)
        panelProv.setAccio()
        panelEmpr.setAccio()
        panelComanda.setAccio()

    End Sub
    Private Sub pComanda_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setLanguage()
        IVA.Items.Clear()
        IVA.Items.AddRange(ModelTipusIva.getListStringIvaActiva)
        UNITAT.Items.Clear()
        UNITAT.Items.AddRange(ModelUnitat.getListString)
        Call setProveidor(comandaActual.proveidor)
        Call setComanda()
        If comandaActual.idSolicitut > 0 Then
            Call setsolicitutComanda(comandaActual.solicitutF56)
            cmdF56.Enabled = True
        Else
            cmdF56.Enabled = False
        End If
        actualitzar = True

        Call validateControls()
        Call validateControlsArticles()


    End Sub
    Private Sub pComanda_Resize(sender As Object, e As EventArgs) Handles SplitC.Panel1.Resize
        Panel7.Width = SplitC.Panel1.Width / 3 - (20)
        Panel6.Width = Panel7.Width
        Panel8.Width = Panel7.Width
        Panel6.Left = Panel7.Left + Panel7.Width + 10
        Panel8.Left = Panel6.Left + Panel6.Width + 10

    End Sub
    Private Sub DGVArticles_Resize(sender As Object, e As EventArgs) Handles DGVArticles.Resize
        DGVArticles.Columns(1).Width = DGVArticles.Width * 0.15
        DGVArticles.Columns(2).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(3).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(4).Width = DGVArticles.Width * 0.31
        DGVArticles.Columns(5).Width = DGVArticles.Width * 0.1
        DGVArticles.Columns(6).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(7).Width = DGVArticles.Width * 0.1
        DGVArticles.Columns(8).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(9).Width = DGVArticles.Width * 0.1
    End Sub
    Private Sub DGVArticlesF56_Resize(sender As Object, e As EventArgs) Handles dgvArticlesF56.Resize
        dgvArticlesF56.Columns(0).Width = dgvArticlesF56.Width * 0.15
        dgvArticlesF56.Columns(1).Width = dgvArticlesF56.Width * 0.05
        dgvArticlesF56.Columns(2).Width = dgvArticlesF56.Width * 0.05
        dgvArticlesF56.Columns(3).Width = dgvArticlesF56.Width * 0.3

        dgvArticlesF56.Columns(4).Width = dgvArticlesF56.Width * 0.15
        dgvArticlesF56.Columns(5).Width = dgvArticlesF56.Width * 0.15
        dgvArticlesF56.Columns(6).Width = dgvArticlesF56.Width * 0.15


    End Sub
    '*** PROCEDIMENTS DE VALIDACIO***
    Private Sub validateControls()
        Dim errors As List(Of String), avisos As List(Of String), p As String
        comandaActual = getComanda()
        errors = comandaActual.errorsComanda
        avisos = comandaActual.avisosComanda
        cbEstat.Items.Clear()
        cbEstat.Text = ""
        For Each p In errors
            cbEstat.Items.Add(p)
        Next
        For Each p In avisos
            cbEstat.Items.Add(p)
        Next
        If errors.Count > 0 Then
            Me.cmdCrear.Enabled = False
        Else
            Me.cmdCrear.Enabled = True
        End If
        If cbEstat.Items.Count > 0 Then cbEstat.SelectedIndex = 0
        lblComptadorEstat.Text = errors.Count & " " & IDIOMA.getString("errors") & ". " & avisos.Count & IDIOMA.getString("avisos") & "."
        errors = Nothing
        avisos = Nothing
    End Sub
    Private Sub validateControlsArticles()
        'If panelProv.proveidorActual Is Nothing Then
        '    Call setPanelArticles(False)
        'Else
        '    Call setPanelArticles(True)
        'End If

        If Not IsNothing(DGVArticles.CurrentCell) Then
            cmdModificarArticle.Enabled = True
            cmdEliminarArticle.Enabled = True
        Else
            cmdModificarArticle.Enabled = False
            cmdEliminarArticle.Enabled = False
        End If
    End Sub
    Private Sub validarKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = DGVArticles.CurrentCell.ColumnIndex


        If columna = 2 Or columna = 5 Or columna = 6 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            e.KeyChar = VALIDAR.DecimalNegatiu(e.KeyChar, sender.text, sender.selectionstart, sender.text.length, 10, 3)
        End If
    End Sub
    'Private Sub validarKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    '    If e.Control And e.KeyCode = Keys.C Then
    '        Call copiar()
    '    ElseIf e.Control And e.keycode = keys.V Then
    '        Call Engantxar()
    '    End If
    'End Sub
    '*** SETS***
    Private Sub setLanguage()
        mnuAfegir.Text = IDIOMA.getString("afegir")
        mnuEliminar.Text = IDIOMA.getString("eliminar")
        mnuCopiar.Text = IDIOMA.getString("copiar")
        mnuEngatxar.Text = IDIOMA.getString("engantxar")
        cmdF56.Text = IDIOMA.getString("veureF56")


        lblEstatComanda.Text = IDIOMA.getString("estatComanda") & ":"
        DGVArticles.Columns(1).HeaderText = IDIOMA.getString("ref.")
        DGVArticles.Columns(2).HeaderText = IDIOMA.getString("qnt.")
        DGVArticles.Columns(3).HeaderText = IDIOMA.getString("uni.")
        DGVArticles.Columns(4).HeaderText = IDIOMA.getString("descripcio")
        DGVArticles.Columns(5).HeaderText = IDIOMA.getString("base")
        DGVArticles.Columns(6).HeaderText = IDIOMA.getString("dte.")
        DGVArticles.Columns(7).HeaderText = IDIOMA.getString("totalBase")
        DGVArticles.Columns(7).DefaultCellStyle.ForeColor = Color.Gray
        DGVArticles.Columns(8).HeaderText = IDIOMA.getString("iva")
        DGVArticles.Columns(9).HeaderText = IDIOMA.getString("total")
        DGVArticles.Columns(9).DefaultCellStyle.ForeColor = Color.Gray
        Me.lblAlcancePedido.Text = IDIOMA.getString("alcancePedido")
        Me.lblCaptionEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.lblProjecte.Text = IDIOMA.getString("projecte")
        Me.lblCaptionProveidor.Text = IDIOMA.getString("proveidor")
        Me.lblProveidor.Text = IDIOMA.getString("proveidor")
        Me.lblAlcancePedido.Text = IDIOMA.getString("")
        Me.lblAltres.Text = IDIOMA.getString("altres")
        Me.lblComparatiu.Text = IDIOMA.getString("comparatiu")
        Me.lblDataComanda.Text = IDIOMA.getString("dataComanda")
        Me.lblDocumentacioAportada.Text = IDIOMA.getString("documentacioAportada")
        Me.lblEntregaEquips.Text = IDIOMA.getString("dataEquips")
        Me.lblEntregaMuntatge.Text = IDIOMA.getString("dataMuntatge")
        Me.lblMagatzem.Text = IDIOMA.getString("magatzemLlocEntrega")
        Me.lblOferta1.Text = IDIOMA.getString("oferta1")
        Me.lblOferta2.Text = IDIOMA.getString("oferta2")
        Me.lblOferta3.Text = IDIOMA.getString("oferta3")
        Me.lblTitolF56.Text = IDIOMA.getString("solicitutComanda")
        dgvArticlesF56.Columns(0).HeaderText = IDIOMA.getString("ref.")
        dgvArticlesF56.Columns(1).HeaderText = IDIOMA.getString("qnt.")
        dgvArticlesF56.Columns(2).HeaderText = IDIOMA.getString("uni.")
        dgvArticlesF56.Columns(3).HeaderText = IDIOMA.getString("descripcio")
        dgvArticlesF56.Columns(4).HeaderText = IDIOMA.getString("base")
        dgvArticlesF56.Columns(5).HeaderText = IDIOMA.getString("dte.")
        dgvArticlesF56.Columns(6).HeaderText = IDIOMA.getString("total")
        Me.lblTotalCaption.Text = IDIOMA.getString("total")
    End Sub
    Private Sub setPanelArticles(activar As Boolean)
        cmdCercadorArticle.Enabled = activar
        cmdEliminarArticle.Enabled = activar
        cmdModificarArticle.Enabled = activar
        txtFiltrarArticle.Enabled = activar
        DGVArticles.Enabled = activar
    End Sub
    Private Sub setEmpresa()
        If actualitzar Then Call validateControls()
    End Sub
    Private Sub setProjecte()
        If actualitzar Then
            Call validateControls()
            panelComanda.lblComanda.Text = comandaActual.ToStringCodi
        End If
    End Sub
    Private Sub setComanda()
        Dim i As Integer
        actualitzar = False
        panelComanda.dataActual = comandaActual.data
        panelComanda.dataEntregaActual = comandaActual.dataEntrega
        panelComanda.dataMuntatgeActual = comandaActual.dataMuntatge
        panelComanda.dadesBancaries = comandaActual.dadesBancaries
        panelComanda.tipuspagament = comandaActual.tipusPagament
        panelComanda.oferta = comandaActual.nOferta
        panelComanda.intAval = comandaActual.interAval
        For i = DGVArticles.Rows.Count To comandaActual.getMaxFilesArticles
            DGVArticles.Rows.Add()
        Next
        Call setArticles(comandaActual.articles, comandaActual.getTotalFiles)
        actualitzar = True
        If actualitzar Then
            Call validateControls()
        End If

    End Sub
    Private Sub setProveidor(p As Proveidor)
        comandaActual.proveidor = p
        If Not IsNothing(comandaActual.proveidor) Then Call setTipusPagament(p.tipusPagament)
        If actualitzar Then Call validateControls()
    End Sub
    Private Sub setTipusPagament(t As TipusPagament)
        comandaActual.tipusPagament = t
        panelComanda.listCondicionsPagament.cb.SelectedItem = t
        If actualitzar Then Call validateControls()
    End Sub
    Private Sub setTotal(r As DataGridViewRow)
        r.Cells(C_BASE).Value = Math.Round((r.Cells(C_QUANTITAT).Value * r.Cells(C_IMPORT).Value) - (r.Cells(C_QUANTITAT).Value * r.Cells(C_IMPORT).Value) * (r.Cells(C_DESCOMPTE).Value / 100), 2)
        r.Cells(C_TOTAL).Value = Math.Round(r.Cells(C_BASE).Value + (r.Cells(C_BASE).Value * ModelTipusIva.getValor(r.Cells(C_IVA).Value)), 2)
    End Sub
    Private Sub setTotals()
        Dim r As DataGridViewRow, base As Double = 0, iva As Double = 0
        For Each r In DGVArticles.Rows
            base = base + r.Cells(C_BASE).Value
            iva = iva + r.Cells(C_BASE).Value * (ModelTipusIva.getValor(r.Cells(C_IVA).Value))
        Next
        lblTotalBI.Text = IDIOMA.getString("totalBase") & ": " & Format(base, "#,##0.00;-#,##0.00")
        lblTotalIva.Text = IDIOMA.getString("totalIva") & ": " & Format(iva, "#,##0.00;-#,##0.00")
        lblTotal.Text = IDIOMA.getString("total") & ": " & Format(base + iva, "#,##0.00;-#,##0.00")
        r = Nothing
    End Sub
    Private Sub setsolicitutComanda(p As SolicitudComanda)
        txtEmpresa.Text = p.empresa.ToString
        txtProjecte.Text = p.codiProjecte
        txtProveidor.Text = p.proveidor.ToString
        txtContacteProveidor.Text = p.contacteProveidor
        If p.postaApunt Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("postaApunt") & ", "
        If p.postaServei Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("postaServei") & ", "
        If p.provesObra Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("provesObra") & ", "
        If p.provesTaller Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("provesTaller") & ", "
        If p.supervisio Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("supervisio") & ", "
        If p.suministreMaterial Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("suministreMaterial") & ", "
        If p.transport Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("transport") & ", "
        If p.embalatge Then txtAlcancePedido.Text = txtAlcancePedido.Text & IDIOMA.getString("embalatge") & ", "
        If Strings.Right(txtAlcancePedido.Text, 2) = ", " Then txtAlcancePedido.Text = Strings.Left(txtAlcancePedido.Text, txtAlcancePedido.TextLength - 2)
        txtLlocEntrega.Text = p.llocEntrega.ToString
        txtContacteEntrega.Text = p.direccioEntrega
        txtContacteEntrega.Text = txtContacteEntrega.Text & vbCrLf & p.contacteEntrega.ToString
        txtDataComanda.Text = Format(p.dataComanda, "dd-mm-yyyy")
        txtDataEnrtrega.Text = Format(p.dataEntrega, "dd-mm-yyyy")
        txtDataMuntatge.Text = Format(p.dataFinalitzacio, "dd-mm-yyyy")
        txtOferta1.Text = p.oferta1
        txtOferta2.Text = p.oferta2
        txtOferta3.Text = p.oferta3
        txtComparatiu.Text = p.comparatiu
        txtaltres.Text = p.altresDocumentacio
        Call setArticlesSolicitut(p.articles, p.getTotalFiles)
    End Sub
    Private Sub setArticlesSolicitut(articles As List(Of ArticleSolicitut), nFiles As Integer)
        Dim r As DataGridViewRow, a As ArticleSolicitut, i As Integer
        actualitzar = False
        For i = dgvArticlesF56.Rows.Count - 1 To nFiles
            dgvArticlesF56.Rows.Add()
        Next
        For Each a In articles
            r = dgvArticlesF56.Rows(a.pos)
            r.Cells(C_CODI_F56).Value = a.codi
            If a.quantitat <> 0 Then r.Cells(C_QUANTITAT_f56).Value = a.quantitat
            If Not IsNothing(a.unitat) Then r.Cells(C_UNITAT_F56).Value = a.unitat
            r.Cells(C_DESCRIPCIO_F56).Value = a.nom
            If a.preu <> 0 Then r.Cells(C_BASE_F56).Value = a.preu
            If a.tpcDescompte <> 0 Then r.Cells(C_DESCOMPTE_F56).Value = a.tpcDescompte
            If a.total <> 0 Then r.Cells(C_TOTAL_F56).Value = a.total
        Next

        actualitzar = True
    End Sub
    Private Sub setAccio()
        Dim mida As Decimal
        mida = Panel7.Height
        If mida < Panel6.Height Then mida = Panel6.Height
        If mida < Panel8.Height Then mida = Panel8.Height
        panelArticle.Top = Panel6.Top + mida + 2
        panelArticle.Height = Me.Height - Panel1.Height - mida - 2 - (SplitC.Panel1.Height - lblTotal.Top)
    End Sub
    Private Sub setNewArticle(ac As articleComanda)
        Dim r As DataGridViewRow
        If DGVArticles.CurrentCell Is Nothing Then
            DGVArticles.Rows.Add()
            DGVArticles.Rows.Add()
            r = DGVArticles.CurrentRow
        Else
            r = DGVArticles.CurrentRow
        End If
        actualitzar = False
        If Not IsNothing(ac) Then
            r.Cells(C_ID).Value = ac.id
            r.Cells(C_CODI).Value = ac.codi
            If r.Cells(C_UNITAT).Value = "" Then r.Cells(C_UNITAT).Value = ac.unitat.codi
            If r.Cells(C_IVA).Value = "" Then r.Cells(C_IVA).Value = ac.tIva.nom
            If r.Cells(C_QUANTITAT).Value = 0 Then r.Cells(C_QUANTITAT).Value = ac.quantitat
            If r.Cells(C_DESCRIPCIO).Value = "" Then r.Cells(C_DESCRIPCIO).Value = ac.nom
            If r.Cells(C_IMPORT).Value = 0 Then r.Cells(C_IMPORT).Value = ac.preu
            If r.Cells(C_DESCOMPTE).Value = 0 Then r.Cells(C_DESCOMPTE).Value = ac.tpcDescompte
            DGVArticles.Refresh()
        End If
        r = Nothing
        actualitzar = True
    End Sub
    Private Sub setArticles(articles As List(Of articleComanda), nFiles As Integer)
        Dim r As DataGridViewRow, a As articleComanda, i As Integer
        actualitzar = False
        For i = DGVArticles.Rows.Count - 1 To nFiles
            DGVArticles.Rows.Add()
        Next
        For Each r In DGVArticles.Rows
            r.Cells(C_ID).Value = -1
        Next
        For Each a In articles
            r = DGVArticles.Rows(a.pos)
            r.Cells(C_ID).Value = a.id
            r.Cells(C_CODI).Value = a.codi
            If a.quantitat <> 0 Then r.Cells(C_QUANTITAT).Value = a.quantitat
            If Not IsNothing(a.unitat) Then r.Cells(C_UNITAT).Value = a.unitat.codi
            r.Cells(C_DESCRIPCIO).Value = a.nom
            If a.preu <> 0 Then r.Cells(C_IMPORT).Value = a.preu
            If a.tpcDescompte <> 0 Then r.Cells(C_DESCOMPTE).Value = a.tpcDescompte
            If Not IsNothing(a.tIva) Then r.Cells(C_IVA).Value = a.tIva.nom
            Call setTotal(r)
        Next
        Call setTotals()
        actualitzar = True
    End Sub

    '*** GETS***
    Private Function getComanda() As Comanda
        Dim c As Comanda
        c = New Comanda()
        c.id = comandaActual.id
        c.idSolicitut = comandaActual.idSolicitut
        c.codi = comandaActual.codi
        c.estat = comandaActual.estat
        c.nomFitxerSolicitut = comandaActual.nomFitxerSolicitut
        c.contacte = panelEmpr.contacteProjecte
        c.contacteProveidor = panelProv.contacte
        c.dadesBancaries = panelComanda.txtDadesBancaries.Text
        c.data = panelComanda.dataActual
        c.dataEntrega = panelComanda.dataEntregaActual
        c.dataMuntatge = panelComanda.dataMuntatgeActual
        c.director = panelEmpr.txtDirector.Text
        c.empresa = panelEmpr.empresa
        c.interAval = panelComanda.intAval
        c.magatzem = panelEmpr.magatzem
        c.nOferta = panelComanda.oferta
        c.ports = panelComanda.ports
        c.projecte = panelEmpr.projecte
        c.proveidor = panelProv.proveidor
        c.responsable = panelEmpr.txtResponsable.Text
        c.retencio = panelComanda.retencio
        c.tipusPagament = panelComanda.tipuspagament
        Return c
    End Function
    Private Function getArticle(r As DataGridViewRow) As articleComanda
        Dim ac As articleComanda
        ac = New articleComanda(r.Cells(C_ID).Value, comandaActual.id, r.Index, r.Cells(C_CODI).Value, r.Cells(C_DESCRIPCIO).Value)
        ac.quantitat = r.Cells(C_QUANTITAT).Value
        ac.unitat = ModelUnitat.getObject(Convert.ToString(r.Cells(C_UNITAT).Value))
        ac.preu = r.Cells(C_IMPORT).Value
        ac.tpcDescompte = r.Cells(C_DESCOMPTE).Value
        If r.Cells(C_IVA).Value <> "" Then ac.tIva = ModelTipusIva.getObjectByToString(Convert.ToString(r.Cells(C_IVA).Value))
        If r.Cells("unitat").Value <> "" Then ac.unitat = ModelUnitat.getObject(r.Cells(C_UNITAT).Value)
        Return ac
    End Function
    Private Function getArticles() As List(Of articleComanda)
        Dim llista As List(Of articleComanda), i As Integer, r As DataGridViewRow
        llista = New List(Of articleComanda)
        For i = 0 To DGVArticles.Rows.Count - 1
            r = DGVArticles.Rows(i)
            If r.Cells(C_CODI).Value <> "" Or r.Cells(C_DESCRIPCIO).Value <> "" Then
                llista.Add(getArticle(r))
            End If
        Next
        Return llista
    End Function

    '*** ELEMENTS DE MENU ***'
    Private Function copyRow() As List(Of DataGridViewRow)
        Dim r As DataGridViewRow
        copyRow = New List(Of DataGridViewRow)
        For Each r In DGVArticles.SelectedRows
            copyRow.Add(r)
        Next
        r = Nothing
    End Function
    Private Sub RowPaste()
        Dim r As DataGridViewRow, i As Integer, r1 As DataGridViewRow, j As Integer
        actualitzar = False
        i = DGVArticles.CurrentCell.RowIndex
        For j = filesCopiades.Count - 1 To 0 Step -1
            r = filesCopiades(j)
            'For Each r In filesCopiades
            r1 = DGVArticles.Rows(i)
            r1.Cells(C_ID).Value = -1
            r1.Cells(C_CODI).Value = r.Cells(C_CODI).Value
            r1.Cells(C_QUANTITAT).Value = r.Cells(C_QUANTITAT).Value
            r1.Cells(C_UNITAT).Value = r.Cells(C_UNITAT).Value
            r1.Cells(C_DESCRIPCIO).Value = r.Cells(C_DESCRIPCIO).Value
            r1.Cells(C_IMPORT).Value = r.Cells(C_IMPORT).Value
            r1.Cells(C_DESCOMPTE).Value = r.Cells(C_DESCOMPTE).Value

            r1.Cells(C_BASE).Value = r.Cells(C_BASE).Value
            r1.Cells(C_IVA).Value = r.Cells(C_IVA).Value
            r1.Cells(C_TOTAL).Value = r.Cells(C_TOTAL).Value
            i = i + 1
            If DGVArticles.Rows.Count < i Then DGVArticles.Rows.Add()
        Next
        actualitzar = True
        Call setTotals()
    End Sub
    Private Sub RemoveItemsSelected()
        For Each row As DataGridViewRow In DGVArticles.SelectedRows
            DGVArticles.Rows.Remove(row)
        Next
        Call setTotals()
    End Sub
    Private Sub AfegirFila(i As Integer)
        DGVArticles.Rows.AddCopies(i, DGVArticles.SelectedRows.Count)
    End Sub
    Private Sub MnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        Call RemoveItemsSelected()
    End Sub
    Private Sub MnuContextual_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuContextual.Opening
        mnuContextual.Visible = False
    End Sub
    Private Sub MnuAfegir_Click(sender As Object, e As EventArgs) Handles mnuAfegir.Click
        If DGVArticles.SelectedRows.Count > 0 Then Call AfegirFila(DGVArticles.CurrentCell.RowIndex)
    End Sub
    Private Sub MnuCopiar_Click(sender As Object, e As EventArgs) Handles mnuCopiar.Click
        filesCopiades = copyRow()
    End Sub
    Private Sub MnuEngatxar_Click(sender As Object, e As EventArgs) Handles mnuEngatxar.Click
        Call RowPaste()
    End Sub

    '*** EVENTS DATAGRIDVIEW   ***
    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVArticles.EditingControlShowing
        If DGVArticles.CurrentCell.ColumnIndex <> 8 And DGVArticles.CurrentCell.ColumnIndex <> 3 Then
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf validarKeyPress
            'AddHandler validar.KeyDown, AddressOf validarKeyDown
        End If
    End Sub
    Private Sub DGVArticles_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellValueChanged
        If actualitzar Then
            Dim r As DataGridViewRow = DGVArticles.CurrentRow, c As DataGridViewCell = DGVArticles.CurrentCell, cIndex As Integer = DGVArticles.CurrentCell.ColumnIndex
            If Not IsNothing(c) Then
                If cIndex = r.Cells(C_QUANTITAT).ColumnIndex Or cIndex = r.Cells(C_IMPORT).ColumnIndex Or cIndex = r.Cells(C_DESCOMPTE).ColumnIndex Or cIndex = r.Cells(C_IVA).ColumnIndex Then
                    Call setTotal(r)
                    Call setTotals()
                ElseIf cIndex = r.Cells(C_CODI).ColumnIndex And actualitzar Then
                    If r.Cells(C_CODI).Value <> "" Then
                        Dim a As article
                        a = ModelArticle.getObject(Strings.UCase(r.Cells(C_CODI).Value))
                        If Not IsNothing(a) Then
                            a.preusProveidors = ModelarticlePreu.getObjects(a.id)
                            articleComandaActual = New articleComanda
                            articleComandaActual.codi = a.codi
                            articleComandaActual.quantitat = 1
                            If a.unitat IsNot Nothing Then articleComandaActual.unitat = a.unitat
                            articleComandaActual.nom = a.nom
                            If Not IsNothing(panelProv.proveidor) Then
                                articleComandaActual.preu = a.getUltimPreu(panelProv.proveidor.id).base
                            Else
                                articleComandaActual.preu = a.getUltimPreu(-1).base
                            End If
                            If a.iva IsNot Nothing Then articleComandaActual.tIva = a.iva
                            Call setNewArticle(articleComandaActual)
                                Call setTotal(r)
                                Call setTotals()

                            End If

                        End If
                End If
                Call validateControlsArticles()
            End If
        End If
    End Sub

    Private Sub DGVArticles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellDoubleClick
        Call ModificarArticleComanda()
    End Sub

    'EVENTS  BUTTON
    Private Sub CmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercadorArticle.Click
        Dim a As article
        a = DArticles.getArticle(True, txtFiltrarArticle.Text)
        If Not IsNothing(a) Then
            a.preusProveidors = ModelarticlePreu.getObjects(a.id)
            articleComandaActual = New articleComanda
            articleComandaActual.codi = a.codi
            articleComandaActual.quantitat = 1
            If a.unitat IsNot Nothing Then articleComandaActual.unitat = a.unitat
            articleComandaActual.nom = a.nom
            If Not IsNothing(panelProv.proveidor) Then
                articleComandaActual.preu = a.getUltimPreu(panelProv.proveidor.id).base
            Else
                articleComandaActual.preu = a.getUltimPreu(-1).base
            End If
            If a.iva IsNot Nothing Then articleComandaActual.tIva = a.iva
            Call setNewArticle(articleComandaActual)
            Call setTotal(DGVArticles.CurrentRow)
            Call setTotals()
        End If
        Call validateControlsArticles()
    End Sub
    Private Sub CmdAfegir_Click(sender As Object, e As EventArgs)
        Dim ac As articleComanda
        ac = DArticleComanda.getNewArticle(comandaActual.proveidor, comandaActual.id)
        If ac IsNot Nothing Then
            articleComandaActual = ac
            Call setNewArticle(articleComandaActual)
        End If
        Call validateControlsArticles()
        ac = Nothing
    End Sub
    Private Sub CmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificarArticle.Click
        Call ModificarArticleComanda()
    End Sub
    Private Sub ModificarArticleComanda()
        Dim ac As articleComanda, r As DataGridViewRow = DGVArticles.CurrentRow
        If Not IsNothing(DGVArticles.CurrentCell) Then
            ac = DArticleComanda.getArticle(getArticle(r), comandaActual.proveidor)
            If ac IsNot Nothing Then
                articleComandaActual = ac
                Call setNewArticle(articleComandaActual)
                Call setTotal(r)
                Call setTotals()
            End If
            Call validateControlsArticles()
        End If
    End Sub

    Private Sub cmdCopiarArticle_Click(sender As Object, e As EventArgs) Handles cmdCercadorArticle.Click
        filesCopiades = copyRow()
    End Sub
    Private Sub cmdEngantxarArticle_Click(sender As Object, e As EventArgs) Handles cmdEngantxarArticle.Click
        Call RowPaste()
    End Sub
    Private Sub cmdAfegirFila_Click(sender As Object, e As EventArgs) Handles cmdAfegirFila.Click
        If DGVArticles.SelectedRows.Count > 0 Then Call AfegirFila(DGVArticles.CurrentCell.RowIndex)
    End Sub
    Private Sub cmdTreureFila_Click(sender As Object, e As EventArgs) Handles cmdTreureFila.Click
        For Each row As DataGridViewRow In DGVArticles.SelectedRows
            DGVArticles.Rows.Remove(row)
        Next
    End Sub
    Private Sub cmdValidar_Click(sender As Object, e As EventArgs) Handles cmdCrear.Click
        Dim c As Comanda
        c = getComanda()
        c.articles = getArticles()
        c.id = -1
        ' ENS CAL GUARDAR LA COMANDA I ENVIAR-LA  
        If MISSATGES.CONFIRM_CREAR_COMANDA(c.empresa.ToString) Then

            Call ModulExportarComanda.execute(c)
            'id = ModelComanda.save(c)
            'If id > -1 Then
            '    Call MISSATGES.COMANDA_CREADA(c.ToStringCodi)
            '    RaiseEvent UpdateComanda()
            'End If
        End If
    End Sub


    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim c As Comanda
        c = getComanda()
        c.articles = getArticles()
        c.id = ModelComandaEnEdicio.save(c)
        If c.id > 0 Then Call MISSATGES.COMANDA_GUARDADA(c.ToStringCodi)
        RaiseEvent UpdateComanda()
        c = Nothing
    End Sub


    '*** EVENTS  TEXTBOX
    Private Sub txtFiltrarArticle_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Dim a As article
            a = DArticles.getArticle(True, txtFiltrarArticle.Text)
            If a IsNot Nothing Then
                articleComandaActual = New articleComanda(-1, comandaActual.id, DGVArticles.Rows.Count, a.codi, a.nom)
                Call setNewArticle(articleComandaActual)
            End If
            Call validateControlsArticles()
        End If
    End Sub

    Private Sub cmdEliminarArticle_Click(sender As Object, e As EventArgs)
        Call RemoveItemsSelected()
    End Sub




    Private Sub cmdF56_Click(sender As Object, e As EventArgs) Handles cmdF56.Click
        Dim amplada As String
        If cmdF56.Text = IDIOMA.getString("veureF56") Then
            SplitC.Panel2Collapsed = False
            amplada = CONFIG_FILE.getTag(CONFIG_FILE.TAG.WIDHT_SPLIT_COMANDES)
            If IsNumeric(amplada) Then
                If amplada > 50 Then
                    SplitC.SplitterDistance = amplada
                Else
                    SplitC.SplitterDistance = 800
                End If
            Else
                SplitC.SplitterDistance = 800
            End If
            cmdF56.Text = IDIOMA.getString("amagarF56")
        Else
            SplitC.Panel2Collapsed = True
            cmdF56.Text = IDIOMA.getString("veureF56")
        End If

    End Sub

    Private Sub txtFiltrarArticle_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrarArticle.TextChanged

    End Sub
    Private Sub cmdCopiar_Click(sender As Object, e As EventArgs) Handles cmdCopiar.Click
        '1 cal preguntar si es vol crear una copia 

    End Sub

    Private Sub cmdEliminarArticle_Click_1(sender As Object, e As EventArgs) Handles cmdEliminarArticle.Click
        '1 eliminar la fila actual 


    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        '1 eliminar la comanda actual  
        If MISSATGES.CONFIRM_REMOVE_COMANDA() Then
            If ModelComandaEnEdicio.remove(comandaActual) Then
                RaiseEvent UpdateComanda()
                Call frmIniComanda.activatePrevious()
            End If
        End If

    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        ' ens cal emplenar el kritter i imprimir amb pdf


    End Sub
    Private Sub copiar()
        'Dim c As DataGridViewCell, i As Integer, j As Integer, temp(1000, 1000) As String
        'For Each c In DGVArticles.SelectedCells
        '    'temp(c.RowIndex, c.ColumnIndex) = c.Value
        '    MsgBox(c.Value)
        'Next



    End Sub

    Private Sub Engantxar()
        Try
            'Dim textSeleccionat As String = Clipboard.GetText(), linies() As String, errors As Integer = 0, i As Integer, j As Integer
            'Dim celles() As String, r As DataGridViewRow
            'linies = textSeleccionat.Split(vbLf)
            'i = DGVArticles.CurrentCell.RowIndex
            'j = DGVArticles.CurrentCell.ColumnIndex
            'For Each linia As String In linies
            '    If (i < DGVArticles.RowCount And linia.Length > 0) Then
            '        r = DGVArticles.Rows(i)
            '        celles = linia.Split(vbTab)
            '        For index As Integer = 0 To UBound(celles)
            '            If j + index < DGVArticles.ColumnCount Then
            '                r.Cells(j + index).Value = celles(index)

            '            End If
            '        Next
            '    End If
            '    i = i + 1
            'Next

        Catch

        End Try
    End Sub

    Private Sub DGVArticles_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGVArticles.CellMouseClick
        If e.Button = MouseButtons.Right Then

            mnuContextual.Visible = True
            If filesCopiades Is Nothing Then
                mnuContextual.Items("mnuEngatxar").Enabled = False
            Else
                mnuContextual.Items("mnuEngatxar").Enabled = True
            End If
            mnuContextual.Top = Cursor.Position.Y
            mnuContextual.Left = Cursor.Position.X
        End If
    End Sub


End Class

