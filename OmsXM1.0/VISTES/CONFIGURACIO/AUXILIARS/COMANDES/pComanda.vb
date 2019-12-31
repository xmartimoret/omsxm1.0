'TODO CAL PREVEURE QUAN ES MOSTRIN COMANDES EXISTENTS, ES A DIR QUE NO SIGUIN SOLICITUTS
Class pComanda
    Private Const SOLICITUD_COMANDA As String = "NOVA"
    Private panelProv As panelDesplagableProveidor
    ' Private listProveidor As lstProveidor
    Private comandaActual As Comanda
    Private articleComandaActual As articleComanda
    Private articleCopiat As articleComanda
    Private panelEmpr As panelDesplegableEmpresa
    Private panelComanda As panelDesplegableComanda
    Private actualitzar As Boolean
    Private filesCopiades As List(Of DataGridViewRow)
    Private isEnterCell As Boolean
    Public Sub New()
        actualitzar = False
        '      proveidorActual = New Proveidor
        ' This call is required by the designer.
        InitializeComponent()
        comandaActual = New Comanda
        comandaActual.codi = ModelComandaFitxer.getNewCode
        DGVArticles.Rows.Add(30)
        ' listProveidor = New lstProveidor(Nothing)
        panelProv = New panelDesplagableProveidor(Me.Height * 0.4, "p", comandaActual.proveidor)
        panelEmpr = New panelDesplegableEmpresa(Me.Height * 0.4, "e", comandaActual.empresa)
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
    Public Sub New(p As Comanda)
        actualitzar = False

        InitializeComponent()
        comandaActual = p
        DGVArticles.Rows.Add(30)
        panelProv = New panelDesplagableProveidor(Me.Height * 0.4, "p", comandaActual.proveidor)
        panelEmpr = New panelDesplegableEmpresa(Me.Height * 0.4, "e", comandaActual.empresa, comandaActual.projecte)
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
        iva.Items.Clear()
        iva.Items.AddRange(ModelTipusIva.getListStringIvaActiva)
        unitat.Items.Clear()
        unitat.Items.AddRange(ModelUnitat.getListString)
        Call setProveidor(comandaActual.proveidor)
        actualitzar = True
        Call validateControls()
        Call validateControlsArticles()
        panelComanda.lblComanda.Text = comandaActual.getCodiSolicitud
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
        lblComptadorEstat.Text = errors.Count & " errors. " & avisos.Count & " Avisos."
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
        cmdValidar.Text = IDIOMA.getString("crearComanda")

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
            panelComanda.lblComanda.Text = comandaActual.getCodiSolicitud
        End If
    End Sub
    Private Sub setComanda()
        If actualitzar Then Call validateControls()
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
    Private Sub setTotal(r As Integer)
        DGVArticles.Rows(r).Cells(6).Value = Math.Round((DGVArticles.Rows(r).Cells(1).Value * DGVArticles.Rows(r).Cells(4).Value) - (DGVArticles.Rows(r).Cells(1).Value * DGVArticles.Rows(r).Cells(4).Value) * (DGVArticles.Rows(r).Cells(5).Value / 100), 2)
        DGVArticles.Rows(r).Cells(8).Value = Math.Round(DGVArticles.Rows(r).Cells(6).Value + (DGVArticles.Rows(r).Cells(6).Value * ModelTipusIva.getValor(DGVArticles.Rows(r).Cells(7).Value)), 2)
    End Sub
    Private Sub setTotals()
        Dim r As DataGridViewRow, base As Double = 0, iva As Double = 0
        For Each r In DGVArticles.Rows
            base = base + r.Cells(6).Value
            iva = iva + r.Cells(6).Value * (ModelTipusIva.getValor(r.Cells(7).Value))
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
    Private Sub setArticle()
        Dim r As Integer
        If DGVArticles.CurrentCell Is Nothing Then
            DGVArticles.Rows.Add()
            DGVArticles.Rows.Add()
            r = DGVArticles.CurrentCell.RowIndex

        Else
            r = DGVArticles.CurrentCell.RowIndex
        End If
        actualitzar = False
        DGVArticles.Rows(r).Cells(0).Value = articleComandaActual.article.codi
        DGVArticles.Rows(r).Cells(1).Value = articleComandaActual.quantitat
        DGVArticles.Rows(r).Cells(2).Value = articleComandaActual.article.unitat.codi
        DGVArticles.Rows(r).Cells(3).Value = articleComandaActual.nom
        DGVArticles.Rows(r).Cells(4).Value = articleComandaActual.preu.base
        DGVArticles.Rows(r).Cells(5).Value = articleComandaActual.preu.descompte
        DGVArticles.Rows(r).Cells(7).Value = articleComandaActual.article.iva.nom
        DGVArticles.Refresh()
        actualitzar = True
    End Sub

    '*** GETS***
    Private Function getComanda() As Comanda
        Dim c As Comanda
        c = New Comanda()
        c.codi = comandaActual.codi
        c.contacte = panelEmpr.contacteActual
        c.contacteProveidor = panelProv.contacteActual
        c.dadesBancaries = panelComanda.txtDadesBancaries.Text
        c.data = panelComanda.dataActual
        c.dataEntrega = panelComanda.dataEntregaActual
        c.dataMuntatge = panelComanda.dataMuntatgeActual
        c.director = panelEmpr.txtDirector.Text
        c.empresa = panelEmpr.empresaActual
        c.id = -1
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
    Private Function getArticle(r As Integer) As articleComanda
        Dim ac As articleComanda
        ac = New articleComanda(-1, comandaActual.id, r, DGVArticles.Rows(r).Cells(3).Value)
        ac.article = ModelArticle.getObject(Convert.ToString(DGVArticles.Rows(r).Cells(0).Value))
        ac.quantitat = DGVArticles.Rows(r).Cells(1).Value
        ac.unitat = ModelUnitat.getObject(Convert.ToString(DGVArticles.Rows(r).Cells(2).Value))
        ac.preu.base = DGVArticles.Rows(r).Cells(4).Value
        ac.preu.descompte = DGVArticles.Rows(r).Cells(5).Value
        ac.tIva = ModelTipusIva.getObjectByToString(Convert.ToString(DGVArticles.Rows(r).Cells(7).Value))
        Return ac
    End Function
    Private Function getArticles() As List(Of articleComanda)
        Dim a As articleComanda, llista As List(Of articleComanda), i As Integer, r As DataGridViewRow
        llista = New List(Of articleComanda)
        For i = 0 To DGVArticles.Rows.Count - 1
            r = DGVArticles.Rows(i)
            If r.Cells("codi").Value <> "" Or r.Cells("descripcio").Value <> "" Then ' O be la referencia o la descripcio
                a = New articleComanda
                a.codi = r.Cells("codi").Value
                a.preu.descompte = r.Cells("descompte").Value
                a.idComanda = comandaActual.id
                If r.Cells("iva").Value <> "" Then a.tIva = ModelTipusIva.getObjectByToString(r.Cells("iva").Value)
                a.pos = i
                a.preu.base = r.Cells("import").Value
                a.quantitat = r.Cells("quantitat").Value
                If r.Cells("unitat").Value <> "" Then a.unitat = ModelUnitat.getObject(r.Cells("unitat").Value)
                a.nom = r.Cells("descripcio").Value
                llista.Add(a)
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
            r1.Cells(0).Value = r.Cells(0).Value
            r1.Cells(1).Value = r.Cells(1).Value
            r1.Cells(2).Value = r.Cells(2).Value
            r1.Cells(3).Value = r.Cells(3).Value
            r1.Cells(4).Value = r.Cells(4).Value
            r1.Cells(5).Value = r.Cells(5).Value
            r1.Cells(6).Value = r.Cells(6).Value
            r1.Cells(7).Value = r.Cells(7).Value
            r1.Cells(8).Value = r.Cells(8).Value
            i = i + 1
            If DGVArticles.Rows.Count <= i Then DGVArticles.Rows.Add()
        Next
        actualitzar = True
        Call setTotals()
    End Sub
    Private Sub removeItemsSelected()
        For Each row As DataGridViewRow In DGVArticles.SelectedRows
            DGVArticles.Rows.Remove(row)
        Next
        Call setTotals()
    End Sub
    Private Sub afegirFila(i As Integer)

        DGVArticles.Rows.AddCopies(i, DGVArticles.SelectedRows.Count)
    End Sub
    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        Call removeItemsSelected()
    End Sub
    Private Sub mnuContextual_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuContextual.Opening
        mnuContextual.Visible = False
    End Sub
    Private Sub mnuAfegir_Click(sender As Object, e As EventArgs) Handles mnuAfegir.Click
        If DGVArticles.SelectedRows.Count > 0 Then Call afegirFila(DGVArticles.CurrentCell.RowIndex)
    End Sub
    Private Sub mnuCopiar_Click(sender As Object, e As EventArgs) Handles mnuCopiar.Click
        Call copyRow()
    End Sub
    Private Sub mnuEngatxar_Click(sender As Object, e As EventArgs) Handles mnuEngatxar.Click
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
            Dim columna As Integer = DGVArticles.CurrentCell.ColumnIndex
            If Not IsNothing(DGVArticles.CurrentCell) Then
                If columna = 1 Or columna = 4 Or columna = 5 Or columna = 7 Then
                    Call setTotal(DGVArticles.CurrentCell.RowIndex)
                    Call setTotals()
                ElseIf columna = 0 And actualitzar Then
                    If DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(0).Value <> "" Then
                        Dim a As article
                        a = ModelArticle.getObject(Strings.UCase(DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(0).Value))
                        If Not IsNothing(a) Then
                            a.preusProveidors = ModelarticlePreu.getObjects(a.id)
                            articleComandaActual = New articleComanda
                            articleComandaActual.article = a
                            articleComandaActual.quantitat = 1
                            articleComandaActual.nom = a.nom
                            If Not IsNothing(panelProv.proveidorActual) Then
                                articleComandaActual.preu = a.getUltimPreu(panelProv.proveidorActual.id)
                            Else
                                articleComandaActual.preu = a.getUltimPreu(-1)
                            End If
                            actualitzar = False
                            Call setArticle()
                            Call setTotal(DGVArticles.CurrentCell.RowIndex)
                            Call setTotals()
                            actualitzar = True
                        End If
                        a = Nothing
                    End If
                End If
                Call validateControlsArticles()
            End If
        End If
    End Sub
    Private Sub DGVArticles_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGVArticles.RowHeaderMouseClick
        If e.Button = MouseButtons.Right Then
            mnuContextual.Top = e.X
            mnuContextual.Left = e.Y
            mnuContextual.Visible = True
        End If
    End Sub
    Private Sub DGVArticles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellDoubleClick
        Call modificarArticleComanda()
    End Sub

    'EVENTS  BUTTON
    Private Sub cmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercadorArticle.Click
        Dim a As article
        a = DArticles.getArticle(True, txtFiltrarArticle.Text)
        If a IsNot Nothing Then
            articleComandaActual = New articleComanda(-1, comandaActual.id, DGVArticles.Rows.Count, a.nom)
            articleComandaActual.article = a
            Call setArticle()
        End If
        Call validateControlsArticles()
    End Sub
    Private Sub cmdAfegir_Click(sender As Object, e As EventArgs)
        Dim ac As articleComanda

        ac = DArticleComanda.getNewArticle(comandaActual.proveidor, comandaActual.id)
        If ac IsNot Nothing Then
            articleComandaActual = ac
            Call setArticle()
        End If
        Call validateControlsArticles()
        ac = Nothing
    End Sub
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificarArticle.Click
        Call modificarArticleComanda()
    End Sub
    Private Sub modificarArticleComanda()
        Dim ac As articleComanda
        If Not IsNothing(DGVArticles.CurrentCell) Then
            ac = DArticleComanda.getArticle(getArticle(DGVArticles.CurrentCell.RowIndex), comandaActual.proveidor)
            If ac IsNot Nothing Then
                articleComandaActual = ac
                Call setArticle()
                Call setTotal(DGVArticles.CurrentCell.RowIndex)
                Call setTotals()
            End If
            Call validateControlsArticles()
        End If
        ac = Nothing
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

    End Sub

    'todo cal implementar
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim c As Comanda
        c = getComanda()
        c.articles = getArticles()
        Call ModelComandaFitxer.saveEditComanda(c)
        c = Nothing
    End Sub


    '*** EVENTS  TEXTBOX
    Private Sub txtFiltrarArticle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrarArticle.KeyDown
        If e.KeyCode = 13 Then
            Dim a As article
            a = DArticles.getArticle(True, txtFiltrarArticle.Text)
            If a IsNot Nothing Then
                articleComandaActual = New articleComanda(-1, comandaActual.id, DGVArticles.Rows.Count, a.nom)
                articleComandaActual.article = a
                Call setArticle()
            End If
            Call validateControlsArticles()
        End If
    End Sub

    Private Sub cmdEliminarArticle_Click(sender As Object, e As EventArgs) Handles cmdEliminarArticle.Click
        Call removeItemsSelected()
    End Sub
End Class
