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
    Private Const C_CODI As String = "CODI"
    Private Const C_DESCRIPCIO As String = "DESCRIPCIO"
    Private Const C_IVA As String = "IVA"
    Private Const C_IMPORT As String = "IMPORT"
    Private Const C_QUANTITAT As String = "QUANTITAT"
    Private Const C_UNITAT As String = "UNITAT"
    Private Const C_DESCOMPTE As String = "DESCOMPTE"
    Private Const C_BASE As String = "BASE"
    Private Const C_TOTAL As String = "TOTAL"
    Friend Event removeItem(c As Comanda, tipusComanda As Integer)
    Friend Event addComanda(c As Comanda, tipusComanda As Integer)
    Private tipusComanda As Integer

    Public Sub New(p As Comanda, pTipusComanda As Boolean)
        actualitzar = False
        tipusComanda = pTipusComanda
        InitializeComponent()
        comandaActual = p
        DGVArticles.Rows.Add(30)
        panelProv = New panelDesplagableProveidor(Me.Height * 0.4, "p", comandaActual.proveidor, comandaActual.contacteProveidor)
        panelEmpr = New panelDesplegableEmpresa(Me.Height * 0.4, "e", comandaActual.empresa, comandaActual.projecte, comandaActual.magatzem, comandaActual.contacte)
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
        actualitzar = True

        Call validateControls()
        Call validateControlsArticles()
        Call setEstat()

    End Sub
    Private Sub pComanda_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel7.Width = Me.Width / 3 - (20)
        Panel6.Width = Panel7.Width
        Panel8.Width = Panel7.Width
        Panel6.Left = Panel7.Left + Panel7.Width + 10
        Panel8.Left = Panel6.Left + Panel6.Width + 10
        DGVArticles.Columns(0).Width = DGVArticles.Width * 0.15
        DGVArticles.Columns(1).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(2).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(3).Width = DGVArticles.Width * 0.31
        DGVArticles.Columns(4).Width = DGVArticles.Width * 0.1
        DGVArticles.Columns(5).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(6).Width = DGVArticles.Width * 0.1
        DGVArticles.Columns(7).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(8).Width = DGVArticles.Width * 0.1
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
            Me.cmdValidar.Enabled = False
        Else
            Me.cmdValidar.Enabled = True
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
        If columna = 1 Or columna = 4 Or columna = 5 Then
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



        lblEstatComanda.Text = IDIOMA.getString("estatComanda") & ":"
        DGVArticles.Columns(0).HeaderText = IDIOMA.getString("ref.")
        DGVArticles.Columns(1).HeaderText = IDIOMA.getString("qnt.")
        DGVArticles.Columns(2).HeaderText = IDIOMA.getString("uni.")
        DGVArticles.Columns(3).HeaderText = IDIOMA.getString("descripcio")
        DGVArticles.Columns(4).HeaderText = IDIOMA.getString("base")
        DGVArticles.Columns(5).HeaderText = IDIOMA.getString("dte.")
        DGVArticles.Columns(6).HeaderText = IDIOMA.getString("totalBase")
        DGVArticles.Columns(6).DefaultCellStyle.ForeColor = Color.Gray
        DGVArticles.Columns(7).HeaderText = IDIOMA.getString("iva")
        DGVArticles.Columns(8).HeaderText = IDIOMA.getString("total")
        DGVArticles.Columns(8).DefaultCellStyle.ForeColor = Color.Gray
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
        actualitzar = False
        panelComanda.dataActual = comandaActual.data
        panelComanda.dataEntregaActual = comandaActual.dataEntrega
        panelComanda.dataMuntatgeActual = comandaActual.dataMuntatge
        panelComanda.dadesBancaries = comandaActual.dadesBancaries
        panelComanda.tipuspagament = comandaActual.tipusPagament
        panelComanda.oferta = comandaActual.nOferta
        panelComanda.intAval = comandaActual.interAval
        Call setArticles(comandaActual.articles)
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
        actualitzar = False
        r.Cells(C_BASE).Value = Math.Round((r.Cells(C_QUANTITAT).Value * r.Cells(C_IMPORT).Value) - (r.Cells(C_QUANTITAT).Value * r.Cells(C_IMPORT).Value) * (r.Cells(C_DESCOMPTE).Value / 100), 2)
        r.Cells(C_TOTAL).Value = Math.Round(r.Cells(C_BASE).Value + (r.Cells(C_BASE).Value * ModelTipusIva.getValor(r.Cells(C_IVA).Value)), 2)
        actualitzar = True
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
    Private Sub setAccio()
        Dim mida As Decimal
        mida = Panel7.Height
        If mida < Panel6.Height Then mida = Panel6.Height
        If mida < Panel8.Height Then mida = Panel8.Height
        panelArticle.Top = Panel6.Top + mida + 2
        panelArticle.Height = Me.Height - Panel1.Height - mida - 2
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
            r.Cells(C_CODI).Value = ac.codi
            r.Cells(C_UNITAT).Value = ac.unitat.codi
            r.Cells(C_IVA).Value = ac.tIva.nom
            r.Cells(C_QUANTITAT).Value = ac.quantitat
            r.Cells(C_DESCRIPCIO).Value = ac.nom
            r.Cells(C_IMPORT).Value = ac.preu
            r.Cells(C_DESCOMPTE).Value = ac.tpcDescompte
            DGVArticles.Refresh()
        End If
        r = Nothing
        actualitzar = True
    End Sub
    Private Sub setArticles(articles As List(Of articleComanda))
        Dim r As DataGridViewRow, a As articleComanda
        actualitzar = False
        For Each a In articles
            r = DGVArticles.Rows(a.pos)
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
        c.contacte = panelEmpr.contacteActual
        c.contacteProveidor = panelProv.contacteActual
        c.dadesBancaries = panelComanda.txtDadesBancaries.Text
        c.data = panelComanda.dataActual
        c.dataEntrega = panelComanda.dataEntregaActual
        c.dataMuntatge = panelComanda.dataMuntatgeActual
        c.director = panelEmpr.txtDirector.Text
        c.empresa = panelEmpr.empresaActual
        c.interAval = panelComanda.intAval
        c.magatzem = panelEmpr.llocActual
        c.nOferta = panelComanda.oferta
        c.ports = panelComanda.ports
        c.projecte = panelEmpr.projecteActual
        c.proveidor = panelProv.proveidorActual
        c.contacteProveidor = panelProv.contacteActual
        c.responsable = panelEmpr.txtResponsable.Text
        c.retencio = panelComanda.retencio
        c.tipusPagament = panelComanda.tipuspagament
        Return c
    End Function
    Private Function getArticle(r As DataGridViewRow) As articleComanda
        Dim ac As articleComanda
        ac = New articleComanda(-1, comandaActual.id, r.Index, r.Cells(C_CODI).Value, r.Cells(C_DESCRIPCIO).Value)
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
            If r.Cells(C_CODI).Value <> "" Or r.Cells(C_DESCRIPCIO).Value <> "" Then ' O be la referencia o la descripcio
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
        Dim r As DataGridViewRow, i As Integer, r1 As DataGridViewRow
        actualitzar = False
        i = DGVArticles.CurrentCell.RowIndex
        For Each r In filesCopiades
            r1 = DGVArticles.Rows(i)
            r1.Cells(C_CODI).Value = r.Cells(0).Value
            r1.Cells(C_QUANTITAT).Value = r.Cells(C_QUANTITAT).Value
            r1.Cells(C_UNITAT).Value = r.Cells(C_UNITAT).Value
            r1.Cells(C_DESCRIPCIO).Value = r.Cells(C_DESCRIPCIO).Value
            r1.Cells(C_IMPORT).Value = r.Cells(C_IMPORT).Value
            r1.Cells(C_DESCOMPTE).Value = r.Cells(C_DESCOMPTE).Value
            r1.Cells(C_BASE).Value = r.Cells(C_BASE).Value
            r1.Cells(C_IVA).Value = r.Cells(C_IVA).Value
            r1.Cells(C_TOTAL).Value = r.Cells(C_TOTAL).Value
            i = i + 1
            If DGVArticles.Rows.Count <= i Then DGVArticles.Rows.Add()
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
        If DGVArticles.CurrentCell.ColumnIndex <> 7 And DGVArticles.CurrentCell.ColumnIndex <> 2 Then
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf validarKeyPress
        End If
    End Sub
    Private Sub DGVArticles_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellValueChanged
        If actualitzar Then
            Dim r As DataGridViewRow = DGVArticles.CurrentRow, c As DataGridViewCell = DGVArticles.CurrentCell, cIndex As Integer = DGVArticles.CurrentCell.ColumnIndex
            If Not IsNothing(c) Then
                If cIndex = 1 Or cIndex = 4 Or cIndex = 5 Or cIndex = 7 Then
                    Call setTotal(r)
                    Call setTotals()
                ElseIf cIndex = 0 And actualitzar Then
                    If r.Cells(C_CODI).Value <> "" Then
                        Dim a As article
                        a = ModelArticle.getObject(Strings.UCase(r.Cells(C_CODI).Value))
                        If Not IsNothing(a) Then
                            a.preusProveidors = ModelarticlePreu.getObjects(a.id)
                            articleComandaActual = New articleComanda
                            articleComandaActual.codi = a.codi
                            articleComandaActual.quantitat = 1
                            articleComandaActual.nom = a.nom
                            If Not IsNothing(panelProv.proveidorActual) Then
                                articleComandaActual.preu = a.getUltimPreu(panelProv.proveidorActual.id).base
                            Else
                                articleComandaActual.preu = a.getUltimPreu(-1).base
                            End If
                            actualitzar = False
                            Call setNewArticle(articleComandaActual)
                            Call setTotal(r)
                            Call setTotals()
                            actualitzar = True
                        End If

                    End If
                End If
                Call validateControlsArticles()
            End If
        End If
    End Sub
    Private Sub DGVArticles_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGVArticles.RowHeaderMouseClick
        If e.Button = MouseButtons.Right Then
            mnuContextual.Top = e.Y
            mnuContextual.Left = e.X
            mnuContextual.Visible = True
        End If
    End Sub
    Private Sub DGVArticles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellDoubleClick
        Call modificarArticleComanda()
    End Sub

    'EVENTS  BUTTON
    Private Sub CmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercadorArticle.Click
        Dim a As article
        a = DArticles.getArticle(True, txtFiltrarArticle.Text)
        If a IsNot Nothing Then
            articleComandaActual = New articleComanda(-1, comandaActual.id, DGVArticles.Rows.Count, a.codi, a.nom)
            Call setNewArticle(articleComandaActual)
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
        Call modificarArticleComanda()
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

    Private Sub cmdCopiarArticle_Click(sender As Object, e As EventArgs) Handles cmdCopiarArticle.Click
        filesCopiades = copyRow()
    End Sub
    Private Sub cmdEngantxarArticle_Click(sender As Object, e As EventArgs) Handles cmdEngantxarArticle.Click
        Call RowPaste()
    End Sub
    Private Sub cmdAfegirFila_Click(sender As Object, e As EventArgs) Handles cmdAfegirFila.Click
        If DGVArticles.SelectedRows.Count > 0 Then Call afegirFila(DGVArticles.CurrentCell.RowIndex)
    End Sub
    Private Sub cmdTreureFila_Click(sender As Object, e As EventArgs) Handles cmdTreureFila.Click
        For Each row As DataGridViewRow In DGVArticles.SelectedRows
            DGVArticles.Rows.Remove(row)
        Next
    End Sub
    Private Sub cmdValidar_Click(sender As Object, e As EventArgs) Handles cmdValidar.Click
        Dim c As Comanda, id As Integer
        c = getComanda()
        c.articles = getArticles()
        Select Case tipusComanda
            Case 0
                c.id = -1
                c.estat = 1
                If MISSATGES.CONFIRM_CREAR_COMANDA(c.empresa.ToString) Then
                    id = ModelComanda.save(c)
                    If id > -1 Then
                        RaiseEvent removeItem(c, 0)
                        Call MISSATGES.COMANDA_CREADA(c.ToStringCodi)
                        RaiseEvent addComanda(c, 1)
                        Call setEstat()
                    End If
                End If
                'ENS CAL PASAR A COMANDA EDITADA
                'AVISAR DE QUE ES CREARÀ LA COMANDA PER LA EMPRESA 'X' I AMB EL NUMERO 'Y'
                'ESBORRAR LA SOLICITUT I AFEGIR LA COMANDA. LLAVORS CALDRAN DOS EVENTS UN EVENT REMOVESSOLICITU I UN EVENT ADDCOMANDA
            Case 1
                'ENS CAL PASSAR A COMANDA VALIDADA
            Case 2
                'ENS CAL PASSAR A COMANDA ENVIADA
            Case 3
                'ENS CAL COPIAR LA COMANDA
        End Select

        If c.estat = 0 Then ' es una solicitud
            c.id = -1
            c.estat = 1
        End If

    End Sub


    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim c As Comanda
        c = getComanda()
        c.articles = getArticles()
        Select Case tipusComanda
            Case 0
                Call ModelComanda.save(c)
                Call MISSATGES.COMANDA_GUARDADA(c.getCodiString)
            Case Else
                Call ModelComanda.save(c)
                Call MISSATGES.COMANDA_GUARDADA(c.getCodiString)
        End Select
        c = Nothing
    End Sub


    '*** EVENTS  TEXTBOX
    Private Sub txtFiltrarArticle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrarArticle.KeyDown
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

    Private Sub cmdEliminarArticle_Click(sender As Object, e As EventArgs) Handles cmdEliminarArticle.Click
        Call removeItemsSelected()
    End Sub
    Private Sub setEstat()
        Select Case tipusComanda
            Case 0
                cmdValidar.Text = IDIOMA.getString("crearComanda")
                lblTipusComanda.Text = IDIOMA.getString("solicitutF56")
                Panel1.BackColor = Color.Gold
                cmdGuardar.Enabled = True
            Case 1
                cmdValidar.Text = IDIOMA.getString("validarComanda")
                lblTipusComanda.Text = IDIOMA.getString("comandaEditar")
                Panel1.BackColor = Color.LimeGreen
                cmdGuardar.Enabled = True
            Case 2
                cmdValidar.Text = IDIOMA.getString("enviarComanda")
                lblTipusComanda.Text = IDIOMA.getString("comandaValidar")
                cmdGuardar.Enabled = True
                Panel1.BackColor = Color.Gray
            Case 3
                cmdValidar.Text = IDIOMA.getString("copiarComanda")
                lblTipusComanda.Text = IDIOMA.getString("comandaEnviada")
                cmdGuardar.Enabled = False
                Panel1.BackColor = Color.Chocolate
        End Select



    End Sub


    Private Sub pComanda_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.C + e.KeyCode = Keys.ControlKey) AndAlso (Me.DGVArticles.Focused) Then
            MsgBox("ok")
        End If
    End Sub

End Class
