'TODO CAL PREVEURE QUAN ES MOSTRIN COMANDES EXISTENTS, ES A DIR QUE NO SIGUIN SOLICITUTS
Class pComanda
    Private modeEdicio As Boolean
    Private panelProv As panelDesplagableProveidor
    Private comandaActual As Comanda
    Private articleComandaActual As articleComanda
    Private articleCopiat As articleComanda
    Private panelEmpr As panelDesplegableEmpresa
    Private panelComanda As panelDesplegableComanda
    Private actualitzar As Boolean
    Private filesCopiades As List(Of DataGridViewRow)
    Private waitSave As Boolean
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
    Private rutaOfertes As String
    Friend Event UpdateComanda()
    Friend Event UpdateEliminada()
    Private ampladaSplit As Double
    Private Const RUTA_SCANER_MYDOC As String = "\\serveroms\workspace\ESCANER\_BD_00011"
    Private Enum estat
        pendentEliminar = -1
        enEdicio = 0
        enValidacio = 1
        aEnviar = 2
    End Enum

    Public Sub New(p As Comanda, pModeEdicio As Boolean)
        actualitzar = False
        rutaOfertes = CONFIG.setFolder(CONFIG.getDirectoriServidorOfertes)
        modeEdicio = pModeEdicio
        InitializeComponent()
        SplitC.Panel2Collapsed = True
        comandaActual = p
        DGVArticles.Rows.Add(30)
        panelProv = New panelDesplagableProveidor(Me.Height * 0.4, "p", comandaActual.proveidor, comandaActual.contacteProveidor)
        panelEmpr = New panelDesplegableEmpresa(Me.Height * 0.4, "e", comandaActual.empresa, comandaActual.projecte, comandaActual.magatzem, comandaActual.contacte, comandaActual.responsableCompra)
        panelComanda = New panelDesplegableComanda(Me.Height * 0.4, "c", comandaActual)
        AddHandler panelProv.accioMostrar, AddressOf setAccio
        AddHandler panelEmpr.accioMostrar, AddressOf setAccio
        AddHandler panelComanda.accioMostrar, AddressOf setAccio
        AddHandler panelComanda.selectObject, AddressOf setEmpresa
        AddHandler panelProv.selectObject, AddressOf setProveidor
        AddHandler panelEmpr.selectObject, AddressOf setEmpresa
        AddHandler panelEmpr.selectProjecte, AddressOf setProjecte
        AddHandler panelEmpr.selectResponsable, AddressOf setResponsable
        Call setObjects(pModeEdicio)
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

        If Not IsNothing(comandaActual.documentacio) Then
            If comandaActual.documentacio.Count > 0 Then
                cmdAdjunts.Text = IDIOMA.getString("fitxersAdjunts")
                Call setAdjunts(comandaActual.documentacio)
                cmdAdjunts.Visible = True
            Else
                cmdAdjunts.Text = IDIOMA.getString("afegirFitxerAdjunt")
                cmdAdjunts.Visible = True
            End If
        End If
        actualitzar = True
        If cbAdjunts.Items.Count > 0 Then cbAdjunts.SelectedIndex = 0
        Call validateControls()
        Call validateControlsArticles()
        waitSave = False

    End Sub
    Private Sub pComanda_Resize(sender As Object, e As EventArgs) Handles SplitC.Panel1.Resize
        Panel7.Width = SplitC.Panel1.Width / 3 - (20)
        Panel6.Width = Panel7.Width
        Panel8.Width = SplitC.Panel1.Width - Panel7.Width - Panel6.Width - 10
        Panel6.Left = Panel7.Left + Panel7.Width + 5
        Panel8.Left = Panel6.Left + Panel6.Width + 5

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
    '*** PROCEDIMENTS DE VALIDACIO***
    Private Sub validateControls()
        Dim p As String
        comandaActual = getComanda()
        comandaActual.articles = getArticles()

        cbEstat.Items.Clear()
        cbEstat.Text = ""
        For Each p In comandaActual.errorsComanda
            cbEstat.Items.Add(p)
        Next
        For Each p In comandaActual.avisosComanda
            cbEstat.Items.Add(p)
        Next
        If cbEstat.Items.Count > 0 Then cbEstat.SelectedIndex = 0
        lblComptadorEstat.Text = comandaActual.errorsComanda.Count & " " & IDIOMA.getString("errors") & ". " & comandaActual.avisosComanda.Count & IDIOMA.getString("avisos") & "."

    End Sub
    Private Sub validateControlsArticles()
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

    '*** SETS***

    Private Sub setLanguage()
        mnuAfegir.Text = IDIOMA.getString("afegir")
        mnuEliminar.Text = IDIOMA.getString("eliminar")
        mnuCopiar.Text = IDIOMA.getString("copiar")
        mnuEngatxar.Text = IDIOMA.getString("engantxar")

        cmdAfegirAdjunt.Text = IDIOMA.getString("afegirFitxerAdjunt")
        lblAdjunts.Text = IDIOMA.getString("fitxersAdjunts")
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
        If comandaActual.estat = estat.enEdicio Or comandaActual.estat = estat.pendentEliminar Then
            Me.cmdValidar.Text = IDIOMA.getString("enviarAValidar")
        Else
            Me.cmdValidar.Text = IDIOMA.getString("enviarEdicio")
        End If

    End Sub
    Private Sub setPanelArticles(activar As Boolean)
        cmdCercadorArticle.Enabled = activar
        cmdEliminarArticle.Enabled = activar
        cmdModificarArticle.Enabled = activar
        txtFiltrarArticle.Enabled = activar
        DGVArticles.Enabled = activar
    End Sub
    Private Sub setEmpresa()
        If actualitzar Then
            Call validateControls()
            waitSave = True
        End If
    End Sub
    Private Sub setProjecte()
        If actualitzar Then
            Call validateControls()
            waitSave = True
            If comandaActual.estat > 0 Then panelComanda.lblComanda.Text = comandaActual.getCodi.ToString
        End If
    End Sub
    Private Sub setResponsable()
        If actualitzar Then
            Call validateControls()
            waitSave = True
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
        panelComanda.entrega = comandaActual.entrega
        panelComanda.FacturacioPedido = comandaActual.inici
        panelComanda.iniciTreballs = comandaActual.entregaEquips
        For i = DGVArticles.Rows.Count To comandaActual.getMaxFilesArticles
            DGVArticles.Rows.Add()
        Next
        Call setArticles(comandaActual.articles, comandaActual.getTotalFiles)
        actualitzar = True
        If actualitzar Then
            Call validateControls()
        End If

    End Sub
    Private Sub setObjects(estat As Boolean)
        Panel3.Visible = estat
        Me.cmdGuardar.Enabled = estat
        Me.cmdEliminar.Enabled = estat
    End Sub
    Private Sub setProveidor(p As Proveidor)

        comandaActual.proveidor = p
        If Not IsNothing(comandaActual.proveidor) Then Call setTipusPagament(p.tipusPagament)
        If actualitzar Then
            Call validateControls()
            waitSave = True
        End If
    End Sub
    Private Sub setTipusPagament(t As TipusPagament)
        comandaActual.tipusPagament = t
        panelComanda.listCondicionsPagament.cb.SelectedItem = t
        If actualitzar Then
            Call validateControls()
            waitSave = True
        End If
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
    Private Sub setAdjunts(docs As List(Of doc))
        cbAdjunts.Items.Clear()
        cbAdjunts.Items.AddRange(CONFIG.getListObjects(docs))
    End Sub

    Private Sub setAccio()
        Dim mida As Decimal
        mida = Panel7.Height
        If mida < Panel6.Height Then mida = Panel6.Height
        If mida < Panel8.Height Then mida = Panel8.Height
        panelArticle.Top = Panel6.Top + mida + 10
        panelArticle.Height = Me.Height - Panel1.Height - mida - 10 - (SplitC.Panel1.Height - lblTotal.Top)
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
            If Not IsNothing(a.tIva) Then
                If a.tIva.id = -1 Then
                    r.Cells(C_IVA).Value = ModelTipusIva.getAuxiliar().getObject(1).nom
                Else
                    r.Cells(C_IVA).Value = a.tIva.nom
                End If
            Else
                r.Cells(C_IVA).Value = ModelTipusIva.getAuxiliar().getObject(1).nom
            End If
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
        c.serie = Year(panelComanda.dataActual)
        c.dataEntrega = panelComanda.dataEntregaActual
        c.dataMuntatge = panelComanda.dataMuntatgeActual
        c.responsableCompra = panelEmpr.responsable
        c.empresa = panelEmpr.empresa
        c.inici = panelComanda.FacturacioPedido
        c.magatzem = panelEmpr.magatzem
        c.nOferta = panelComanda.oferta
        c.ports = panelComanda.ports
        c.projecte = panelEmpr.projecte
        c.proveidor = panelProv.proveidor
        c.entregaEquips = panelComanda.iniciTreballs
        c.entrega = panelComanda.entrega
        c.tipusPagament = panelComanda.tipuspagament
        c.responsableCompra = panelEmpr.responsable
        c.solicitutF56 = comandaActual.solicitutF56
        c.documentacio = comandaActual.documentacio
        c.docMyDoc = comandaActual.docMyDoc
        Return c
    End Function
    Private Function getArticle(r As DataGridViewRow) As articleComanda
        Dim ac As articleComanda
        ac = New articleComanda(r.Cells(C_ID).Value, comandaActual.id, r.Index + 1, r.Cells(C_CODI).Value, r.Cells(C_DESCRIPCIO).Value)
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
        Call AfegirFila(i, filesCopiades.Count)
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
    Private Sub AfegirFila(i As Integer, nFiles As Integer)
        DGVArticles.Rows.InsertCopies(i, i - DGVArticles.SelectedRows.Count, nFiles)
    End Sub
    Private Sub MnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click, cmdEliminarArticle.Click
        Call RemoveItemsSelected()
    End Sub
    Private Sub MnuContextual_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuContextual.Opening
        mnuContextual.Visible = False
    End Sub
    Private Sub MnuAfegir_Click(sender As Object, e As EventArgs) Handles mnuAfegir.Click, cmdAfegirFila.Click
        If DGVArticles.SelectedRows.Count > 0 Then Call AfegirFila(DGVArticles.CurrentCell.RowIndex + 1, DGVArticles.SelectedRows.Count)
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
                waitSave = True
                Call validateControlsArticles()
            End If
            Call validateControls()
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

    Private Sub cmdTreureFila_Click(sender As Object, e As EventArgs) Handles cmdTreureFila.Click
        For Each row As DataGridViewRow In DGVArticles.SelectedRows
            DGVArticles.Rows.Remove(row)
        Next
    End Sub



    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim c As Comanda, isSave As Boolean
        c = getComanda()
        c.articles = getArticles()
        isSave = True
        If c.estat = -1 Then
            If MISSATGES.CONFIRM_EDITAR_COMANDA_ELIMINADA Then
                RaiseEvent UpdateEliminada()
            Else
                isSave = False
            End If
        End If
        If isSave Then
            c.estat = 0
            c.id = ModelComandaEnEdicio.save(c)
            If c.id > 0 Then Call MISSATGES.COMANDA_GUARDADA(c.getCodi)
            RaiseEvent UpdateComanda()

            c = Nothing
            waitSave = False
        End If
    End Sub


    '*** EVENTS  TEXTBOX


    Private Sub cmdEliminarArticle_Click(sender As Object, e As EventArgs)
        Call RemoveItemsSelected()
    End Sub

    Private Sub cmdF56_Click(sender As Object, e As EventArgs) Handles cmdAdjunts.Click
        Dim amplada As String
        If cmdAdjunts.Text = IDIOMA.getString("fitxersAdjunts") Then
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
            cmdAdjunts.Text = IDIOMA.getString("amagarFitxersAdjunts")
        ElseIf cmdAdjunts.Text = IDIOMA.getString("afegirFitxerAdjunt") Then
            If afegirAdjunt() Then
                If Not IsNothing(comandaActual.documentacio) Then
                    If comandaActual.documentacio.Count > 0 Then
                        cmdAdjunts.Text = IDIOMA.getString("fitxersAdjunts")
                        Call setAdjunts(comandaActual.documentacio)
                        cmdAdjunts.Visible = True
                    Else
                        cmdAdjunts.Text = IDIOMA.getString("afegirFitxerAdjunt")
                        cmdAdjunts.Visible = True
                    End If
                End If
            End If
        Else

                CONFIG_FILE.setTag(CONFIG_FILE.TAG.WIDHT_SPLIT_COMANDES, SplitC.SplitterDistance)
            SplitC.Panel2Collapsed = True
            cmdAdjunts.Text = IDIOMA.getString("fitxersAdjunts")
        End If

    End Sub
    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Call validateControls()
        If MISSATGES.CONFIRM_PENDENT_REMOVE_COMANDA() Then
            comandaActual.estat = estat.pendentEliminar
            If ModelComandaEnEdicio.aBassura(comandaActual) Then
                RaiseEvent UpdateComanda()
                RaiseEvent UpdateEliminada()
                Call frmIniComanda.activatePrevious()
            End If
        End If
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdPDF.Click
        comandaActual = getComanda()
        Dim f As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintComanda"), comandaActual.ToString)
        comandaActual.articles = getArticles()
        Call ModulExportarComanda.execute(comandaActual, True, CONFIG.getDirectoriPDFComandes & comandaActual.getCodi)
        Call f.tancar()
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

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup
        Dim texte As String = "-1"
        Select Case e.AssociatedControl.Name
            Case Me.cmdGuardar.Name : texte = IDIOMA.getString("guardarComandaToolTip")
            Case Me.cmdEliminar.Name : texte = IDIOMA.getString("eliminarComandaToolTip")
            Case Me.cmdCopiar.Name : texte = IDIOMA.getString("copiarComandaToolTip")
            Case Me.cmdCopiarArticle.Name : texte = IDIOMA.getString("copiarArticleToolTip")
            Case Me.cmdEliminarArticle.Name : texte = IDIOMA.getString("eliminarArticleToolTip")
            Case Me.cmdEngantxarArticle.Name : texte = IDIOMA.getString("engantxarArticleToolTip")

            Case Me.cmdValidar.Name : texte = IDIOMA.getString("validarComandaToolTip")
            Case Me.cmdCercadorArticle.Name : texte = IDIOMA.getString("cercaArticleToolTip")
            Case Me.cbEstat.Name : texte = IDIOMA.getString("estatComandaToolTip")
            Case Me.txtFiltrarArticle.Name : texte = IDIOMA.getString("cercaArticleToolTip")
            Case cmdAdjunts.Name : texte = IDIOMA.getString("mostraAmagaF56ToolTip")
        End Select
        If texte <> "-1" Then
            'ToolTip1.SetToolTip(e.AssociatedControl, texte)
            ToolTip1.Show(texte, e.AssociatedControl)
        End If

    End Sub

    Private Sub cmdValidar_Click_1(sender As Object, e As EventArgs) Handles cmdValidar.Click
        Dim isValidate As Boolean, ac As articleComanda, ap As ArticlePreu, a As article, d As doc, rutaFitxer As String, enviarAValidar As Boolean
        Dim rutaAdjuntsMydoc As String = ""
        Call validateControls()
        waitSave = False
        If comandaActual.errorsComanda.Count > 0 Then
            Call ERRORS.ERR_NO_VALIDAR_COMANDA(comandaActual.errorsComanda)
            isValidate = False
        ElseIf comandaActual.avisosComanda.Count > 0 Then
            isValidate = MISSATGES.CONFIRM_VALIDAR_COMANDA_AVISOS(comandaActual.avisosComanda)
        Else
            isValidate = MISSATGES.CONFIRM_VALIDAR_COMANDA(toolTipComanda)
        End If
        If isValidate Then
            For Each ac In comandaActual.articles
                If ac.codi <> "" Then
                    If Not ModelArticle.exist(ac.codi) Then
                        If MISSATGES.CONFIRM_ADD_ARTICLE(ac) Then
                            a = New article(-1, ac.codi, ac.nom, "")
                            a.iva = ac.tIva
                            a.unitat = ac.unitat
                            a = DArticle.getArticle(a)
                            If a IsNot Nothing Then
                                ModelArticle.save(a)
                                ap = New ArticlePreu
                                ap.base = ac.preu
                                ap.idArticle = a.id
                                ap.idProveidor = comandaActual.proveidor.id
                                ap.data = comandaActual.data
                                ap.descompte = ac.tpcDescompte
                                Call ModelarticlePreu.save(ap)
                            End If
                        End If
                    Else
                        a = ModelArticle.getObject(ac.codi)
                        ap = ModelarticlePreu.getLastObject(a.id, comandaActual.proveidor.id)
                        If Not IsNothing(ap) Then
                            If Not ap.Equals(New ArticlePreu(-1, a.id, comandaActual.proveidor.id, comandaActual.data, ac.preu, ac.tpcDescompte)) Then
                                ap = New ArticlePreu
                                ap.base = ac.preu
                                ap.idArticle = a.id
                                ap.idProveidor = comandaActual.proveidor.id
                                ap.data = comandaActual.data
                                ap.descompte = ac.tpcDescompte
                                Call ModelarticlePreu.save(ap)
                            End If
                        Else
                            ap = New ArticlePreu
                            ap.base = ac.preu
                            ap.idArticle = a.id
                            ap.idProveidor = comandaActual.proveidor.id
                            ap.data = comandaActual.data
                            ap.descompte = ac.tpcDescompte
                            Call ModelarticlePreu.save(ap)
                        End If

                    End If
                End If
            Next
            comandaActual.estat = 1
            If ModelComandaEnEdicio.save(comandaActual) > -1 Then
                Dim f As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintComanda"), "")
                rutaFitxer = ModulExportarComanda.execute(comandaActual, True, CONFIG.getDirectoriPDFComandesEnValidacio & comandaActual.getCodi, False)
                RaiseEvent UpdateComanda()
                f.setData(IDIOMA.getString("enviarComandaMyDoc"), comandaActual.getCodi)

                ' NOM FITXER, CODI COMANDA, PROVEIDOR, PROJECTE
                '1 ENS CAL COPIAR  ELS ADJUNTS  A LA CARPETA PREDETERMINADA
                '2  ENS  CAL COPIAR  ELS ADJUNTS A LA CARPETA 3 

                enviarAValidar = True
                If Not IsNothing(comandaActual.docMyDoc) Then
                    If comandaActual.docMyDoc.id > 0 Then
                        If Not MISSATGES.CONFIRM_ENVIAR_VALIDAR(comandaActual) Then enviarAValidar = False
                    End If
                End If
                If enviarAValidar Then
                    rutaAdjuntsMydoc = CONFIG.setFolder(CONFIG_FILE.getRutafitxersMydoc) & "adjuntos\"
                    If CONFIG.folderExist(rutaAdjuntsMydoc) Then
                        For Each d In comandaActual.documentacio
                            If CONFIG.fileExist(CONFIG.setFolder(CONFIG.getDirectoriServidorOfertes) & d.nom) Then
                                FileCopy(CONFIG.setFolder(CONFIG.getDirectoriServidorOfertes) & d.nom, rutaAdjuntsMydoc & d.codi & " - " & comandaActual.getCodi & "-" & d.nom)
                            End If
                        Next
                    End If
                        If CONFIG.fileExist(rutaFitxer) Then
                            FileCopy(rutaFitxer, CONFIG.setFolder(RUTA_SCANER_MYDOC) & toStringMydoc() & ".pdf")
                            'MsgBox(CONFIG.setFolder(RUTA_SCANER_MYDOC) & toStringMydoc() & ".pdf")
                        End If
                    End If

                    f.tancar()
                    frmIniComanda.activateComandaValidada(comandaActual)
                    frmIniComanda.updateComandesEnviades()
                End If
            End If
    End Sub
    ' todo cal revisar 
    Private Function toStringMydoc() As String
        If Not IsNothing(comandaActual.solicitutF56) Then
            Return comandaActual.empresa.nom & "@" & comandaActual.projecte.codi & "@" & comandaActual.projecte.nom & "@" & comandaActual.solicitutF56.departament & "@" & comandaActual.proveidor.nomFiscal & "@" & comandaActual.getCodi & "@" & comandaActual.responsableCompra.nom & "@" & comandaActual.tipusComanda
        Else
            Return comandaActual.empresa.nom & "@" & comandaActual.projecte.codi & "@" & comandaActual.projecte.nom & "@EXPLOTACIONES@" & comandaActual.proveidor.nomFiscal & "@" & comandaActual.getCodi & "@" & comandaActual.responsableCompra.nom & "@" & comandaActual.tipusComanda
        End If
    End Function
    Private Sub cmdExcel_Click(sender As Object, e As EventArgs) Handles cmdExcel.Click
        comandaActual = getComanda()
        Dim f As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintComanda"), comandaActual.ToString)
        comandaActual.articles = getArticles()
        Call ModulExportarComanda.execute(comandaActual, False, "")
        f.tancar()
    End Sub
    Private Function toolTipComanda() As String
        Dim t As String
        t = IDIOMA.getString("numeroComanda") & ": " & comandaActual.getCodi & ". " & IDIOMA.getString("data") & ": " & Format(comandaActual.data, "dd-mm-yy") & vbCrLf
        t = t & IDIOMA.getString("empresa") & ": " & comandaActual.empresa.nom & vbCrLf
        t = t & "   " & comandaActual.projecte.ToString & vbCrLf
        t = t & "        " & comandaActual.magatzem.toString & vbCrLf
        t = t & "        " & comandaActual.contacte.tostring & vbCrLf & vbCrLf
        t = t & IDIOMA.getString("proveidor") & ": " & comandaActual.proveidor.ToString & vbCrLf
        t = t & "   " & comandaActual.contacteProveidor.toString & vbCrLf & vbCrLf
        t = t & IDIOMA.getString("base") & ": " & comandaActual.base & "; "
        t = t & IDIOMA.getString("iva") & ": " & comandaActual.iva & "; "
        t = t & IDIOMA.getString("total") & ": " & comandaActual.total & ". " & vbCrLf
        t = t & IDIOMA.getString("tipusPagament") & ": " & comandaActual.tipusPagament.ToString
        Return t
    End Function

    Friend Sub saveComanda()
        If waitSave Then
            If MISSATGES.CONFIRM_SAVE_COMANDA Then
                Dim c As Comanda
                c = getComanda()
                c.articles = getArticles()
                c.id = ModelComandaEnEdicio.save(c)
                If c.id > 0 Then Call MISSATGES.COMANDA_GUARDADA(c.getCodi)
                RaiseEvent UpdateComanda()
                c = Nothing
                waitSave = False
            End If
        End If
    End Sub

    Private Sub cmdCopiar_Click(sender As Object, e As EventArgs) Handles cmdCopiar.Click
        Dim c As Comanda, codiC As CodiComanda
        c = comandaActual.copy
        c.id = -1
        c.estat = 0
        c.serie = Year(Now)
        codiC = ModelCodiComanda.getObject(c.serie, c.empresa.id)
        If Not IsNothing(codiC) Then
            c.codi = codiC.codi
            codiC.codi = codiC.codi + 1
        Else
            codiC = New CodiComanda(-1, c.serie, 1, c.empresa.id, "")
            c.codi = 1
            codiC.codi = 2
        End If
        If MISSATGES.CONFIRM_COPY_COMANDA() Then
            Dim p As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("copiantComanda"), c.ToString)
            c.id = ModelComandaEnEdicio.save(c)
            If c.id > 0 Then
                Call ModelCodiComanda.save(codiC)
                Call frmIniComanda.modificarComanda(c)
                frmIniComanda.updatecomanda()
            End If
            p.tancar()
        End If
    End Sub


    Private Sub txtFiltrarArticle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltrarArticle.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            Call CmdCercador_Click(sender, Nothing)
        End If
    End Sub


    Private Sub cbAdjunts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAdjunts.SelectedIndexChanged
        If actualitzar Then
            If cbAdjunts.SelectedIndex > -1 Then
                If CONFIG.fileExist(rutaOfertes & cbAdjunts.SelectedItem.nom) Then
                    pdfReader.LoadFile(rutaOfertes & cbAdjunts.SelectedItem.nom)
                    pdfReader.setShowScrollbars(False)
                    pdfReader.setShowToolbar(False)
                End If
            End If
        End If
    End Sub

    Private Sub cmdAfegirAdjunt_Click(sender As Object, e As EventArgs) Handles cmdAfegirAdjunt.Click
        If afegirAdjunt() Then
            If Not IsNothing(comandaActual.documentacio) Then
                If comandaActual.documentacio.Count > 0 Then
                    Call setAdjunts(comandaActual.documentacio)
                End If
            End If
        End If
    End Sub

    Private Function afegirAdjunt() As Boolean
        Dim d As doc
        openFile.Title = IDIOMA.getString("escollirFitxerAdjuntar")
        openFile.Filter = "(*.pdf)|*.pdf"

        If openFile.ShowDialog Then
            If CONFIG.fileExist(openFile.FileName) Then
                d = New doc(-1, -1, comandaActual.id, -1)
                d.nom = CONFIG.getFitxer(openFile.FileName)
                d.anyo = comandaActual.getAnyo
                If ModelDocumentacio.save(d) > 0 Then
                    Call FileCopy(openFile.FileName, CONFIG.setSeparator(CONFIG.getDirectoriServidorOfertes) & d.nom)
                    comandaActual.documentacio.Add(d)
                    Return True
                End If
            End If
        End If
        Return False
    End Function


End Class



