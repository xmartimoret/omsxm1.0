Public Class pComanda

    Private panelProv As panelDesplagableProveidor
    ' Private listProveidor As lstProveidor
    Private comandaActual As Comanda
    Private articleComandaActual As articleComanda
    Private panelEmpr As panelDesplegableEmpresa
    Private panelComanda As panelDesplegableComanda
    Private actualitzar As Boolean
    Public Sub New()
        actualitzar = False
        '      proveidorActual = New Proveidor
        ' This call is required by the designer.
        InitializeComponent()
        comandaActual = New Comanda
        ' listProveidor = New lstProveidor(Nothing)
        panelProv = New panelDesplagableProveidor(Me.Height * 0.4, "p", comandaActual.proveidor)
        panelEmpr = New panelDesplegableEmpresa(Me.Height * 0.4, "e", comandaActual.empresa)
        panelComanda = New panelDesplegableComanda(Me.Height * 0.4, "c", comandaActual)
        AddHandler panelProv.accioMostrar, AddressOf setAccio
        AddHandler panelEmpr.accioMostrar, AddressOf setAccio
        AddHandler panelComanda.accioMostrar, AddressOf setAccio
        AddHandler panelProv.selectObject, AddressOf setProveidor

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
        'listProveidor = New lstProveidor(Nothing)
        panelProv = New panelDesplagableProveidor(Me.Height * 0.5, "p", comandaActual.proveidor)
        panelEmpr = New panelDesplegableEmpresa(Me.Height * 0.5, "e", comandaActual.empresa, comandaActual.projecte)
        panelComanda = New panelDesplegableComanda(Me.Height * 0.5, "c", comandaActual)
        AddHandler panelProv.accioMostrar, AddressOf setAccio
        AddHandler panelEmpr.accioMostrar, AddressOf setAccio
        AddHandler panelComanda.accioMostrar, AddressOf setAccio
        AddHandler panelProv.selectObject, AddressOf setProveidor

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
    Private Sub setLanguage()
        mnuAfegir.Text = IDIOMA.getString("afegir")
        mnuEliminar.Text = IDIOMA.getString("eliminar")
        mnuCopiar.Text = IDIOMA.getString("copiar")
        mnuEngatxar.Text = IDIOMA.getString("engantxar")

        DGVArticles.Columns(0).HeaderText = IDIOMA.getString("ref.")
        DGVArticles.Columns(1).HeaderText = IDIOMA.getString("qnt.")
        DGVArticles.Columns(2).HeaderText = IDIOMA.getString("uni.")
        DGVArticles.Columns(3).HeaderText = IDIOMA.getString("descripcio")
        DGVArticles.Columns(4).HeaderText = IDIOMA.getString("import")
        DGVArticles.Columns(5).HeaderText = IDIOMA.getString("dte.")
        DGVArticles.Columns(6).HeaderText = IDIOMA.getString("iva")
        DGVArticles.Columns(7).HeaderText = IDIOMA.getString("total")
    End Sub


    Private Sub validatecontrols()
        If articleComandaActual IsNot Nothing Then
            cmdModificar.Enabled = True
            cmdEliminar.Enabled = True
        Else
            cmdModificar.Enabled = False
            cmdEliminar.Enabled = False
        End If
    End Sub
    Private Sub setAccio()
        Dim mida As Decimal
        mida = Panel7.Height
        If mida < Panel6.Height Then mida = Panel6.Height
        If mida < Panel8.Height Then mida = Panel8.Height
        panelArticle.Top = Panel6.Top + mida + 2
    End Sub
    Private Sub setProveidor(p As Proveidor)
        comandaActual.proveidor = p
        If Not IsNothing(comandaActual.proveidor) Then Call setTipusPagament(p.tipusPagament)
    End Sub
    Private Sub setTipusPagament(t As TipusPagament)
        comandaActual.tipusPagament = t
        panelComanda.listCondicionsPagament.cb.SelectedItem = t
    End Sub
    Private Sub Boto1_Click(sender As Object, e As EventArgs)
        Call panelProv.gravarDades()
        Call panelEmpr.gravarDades()

    End Sub

    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        For Each row As DataGridViewRow In DGVArticles.SelectedRows
            DGVArticles.Rows.Remove(row)
        Next
    End Sub

    Private Sub pComanda_Load(sender As Object, e As EventArgs) Handles Me.Load
        DGVArticles.ContextMenuStrip = Me.mnuContextual
        Call setLanguage()

        c7.Items.Clear()

        c7.Items.AddRange(ModelTipusIva.getListStringIvaActiva)
        actualitzar = True
        Call setProveidor(comandaActual.proveidor)
        Call validatecontrols()
    End Sub
    Private Sub setClipBoard(t As String)
        Dim x As Integer, y As Integer, text As String = ""
        x = DGVArticles.CurrentCell.RowIndex
        y = DGVArticles.CurrentCell.ColumnIndex
        DGVArticles.Rows(x).Cells(y).Value = t

    End Sub

    Private Sub mnuEngatxar_Click(sender As Object, e As EventArgs) Handles mnuEngatxar.Click
        Call setClipBoard(My.Computer.Clipboard.GetText)
    End Sub
    Private Sub dataGridView1_EditingControlShowing(
        ByVal sender As Object,
        ByVal e As DataGridViewEditingControlShowingEventArgs) _
            Handles DGVArticles.EditingControlShowing
        If DGVArticles.CurrentCell.ColumnIndex <> 6 And DGVArticles.CurrentCell.ColumnIndex <> 0 Then
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf validarKeyPress
        End If
    End Sub
    Private Sub validarKeyPress(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna  
        Dim columna As Integer = DGVArticles.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 1 o 3  
        If columna = 1 Or columna = 4 Or columna = 5 Then

            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            e.KeyChar = VALIDAR.DecimalNegatiu(e.KeyChar, sender.text, sender.selectionstart, sender.text.length, 10, 3)
            ' comprobar si el caracter es un número o el retroceso  
            'If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            '    'Me.Text = e.KeyChar  
            '    e.KeyChar = Chr(0)
            'End If
        End If
    End Sub

    ' DGVARTICLES
    Private Sub DGVArticles_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellContentClick
        Call validatecontrols()
    End Sub
    Private Sub DGVArticles_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellValueChanged
        If actualitzar Then
            Dim columna As Integer = DGVArticles.CurrentCell.ColumnIndex
            If columna = 1 Or columna = 4 Or columna = 5 Then
                DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(7).Value = DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(1).Value * DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(4).Value - DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(4).Value * (DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(5).Value / 100)
            End If
            Call validatecontrols()
        End If
    End Sub
    Private Sub DGVArticles_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArticles.CellEndEdit
        Dim a As article
        If actualitzar Then
            If DGVArticles.CurrentCell.ColumnIndex = 0 Then
                If Not IsNothing(DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(0).Value) Then
                    a = ModelArticle.getObject(DGVArticles.Rows(DGVArticles.CurrentCell.RowIndex).Cells(0).Value)
                    If Not IsNothing(a) Then
                        articleComandaActual = New articleComanda
                        articleComandaActual.article = a
                        Call setArticle()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercador.Click
        Dim a As article
        a = DArticles.getArticle(True, txtFiltrar.Text)
        If a IsNot Nothing Then
            articleComandaActual = New articleComanda(-1, comandaActual.id, DGVArticles.Rows.Count, a.nom)
            articleComandaActual.article = a
            Call setArticle()
        End If
        Call validatecontrols()
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
        DGVArticles.Rows(r).Cells(0).Value = articleComandaActual.article.codi
        DGVArticles.Rows(r).Cells(1).Value = articleComandaActual.quantitat
        DGVArticles.Rows(r).Cells(2).Value = articleComandaActual.unitat.codi
        DGVArticles.Rows(r).Cells(3).Value = articleComandaActual.nom
        DGVArticles.Rows(r).Cells(4).Value = articleComandaActual.preu.base
        DGVArticles.Rows(r).Cells(5).Value = articleComandaActual.preu.descompte
        DGVArticles.Rows(r).Cells(6).Value = articleComandaActual.article.iva.nom
        DGVArticles.Refresh()
        Call validatecontrols()
    End Sub
    Private Sub mnuContextual_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuContextual.Opening
        mnuContextual.Visible = False
    End Sub

    Private Sub mnuAfegir_Click(sender As Object, e As EventArgs) Handles mnuAfegir.Click
        DGVArticles.Rows.Add()
    End Sub

    Private Sub cmdAfegir_Click(sender As Object, e As EventArgs) Handles cmdAfegir.Click
        Dim ac As articleComanda, d As DArticleComanda
        d = New DArticleComanda
        ac = d.getNewArticle(comandaActual.proveidor)
        If ac IsNot Nothing Then
            articleComandaActual = ac
            Call setArticle()
        End If
        ac = Nothing
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim ac As articleComanda
        ac = DArticleComanda.getArticle(articleComandaActual, comandaActual.proveidor)
        If ac IsNot Nothing Then
            articleComandaActual = ac
            Call setArticle()
        End If
        ac = Nothing
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
        DGVArticles.Columns(3).Width = DGVArticles.Width * 0.4
        DGVArticles.Columns(4).Width = DGVArticles.Width * 0.1
        DGVArticles.Columns(5).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(6).Width = DGVArticles.Width * 0.05
        DGVArticles.Columns(7).Width = DGVArticles.Width * 0.15
    End Sub

    Private Sub cmdValidar_Click(sender As Object, e As EventArgs) Handles cmdValidar.Click
        If validarComanda() Then

        End If
    End Sub



    Private Function validarComanda() As Boolean
        Dim isEmpresa As Boolean, isProjecte As Boolean, isContacte As Boolean, isMagatzem As Boolean, isProveidor As Boolean, isContacteProveidor As Boolean
        Dim avisos As String = "", errors As String = ""
        If IsNothing(panelEmpr.empresaActual) Then
            isEmpresa = True
        Else
            If IsNothing(panelEmpr.projecteActual) Then isProjecte = True
            If IsNothing(panelEmpr.contacteActual) Then isContacte = True
            If IsNothing(panelEmpr.llocActual) Then isMagatzem = True
        End If
        If IsNothing(panelProv.proveidorActual) Then isProveidor = True
        If IsNothing(panelProv.contacteActual) Then isContacteProveidor = True
        If isEmpresa Or isProjecte Or isContacte Or isMagatzem Or isProveidor Or isContacteProveidor Then
            If isEmpresa Then
                errors = IDIOMA.getString("noEmpresaComanda") & vbCrLf
            ElseIf isProjecte Then
                errors = IDIOMA.getString("noProjecteComanda") & vbCrLf
            Else
                If isMagatzem Then avisos = IDIOMA.getString("noMagatzemComanda") & vbCrLf
                If isContacte Then avisos = avisos & IDIOMA.getString("noContacteComanda") & vbCrLf

            End If

            If isProveidor Then
                errors = errors & IDIOMA.getString("noProveidorComanda")
            Else
                If isContacteProveidor Then avisos = avisos & IDIOMA.getString("noContacteProveidorComanda")
            End If
            Call DAvisosErrors.setText(IDIOMA.getString("revisarAnomalies"), avisos, errors)
            Return False
        Else
            Return True
        End If
    End Function

End Class
