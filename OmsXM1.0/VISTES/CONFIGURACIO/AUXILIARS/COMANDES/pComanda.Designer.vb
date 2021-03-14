<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pComanda
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAfegir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEngatxar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCrear = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cbEstat = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdF56 = New System.Windows.Forms.Button()
        Me.cmdCopiar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.SplitC = New System.Windows.Forms.SplitContainer()
        Me.lblTotalIva = New OmsXM.LBLRED()
        Me.lblTotal = New OmsXM.LBLRED()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblTotalBI = New OmsXM.LBLRED()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.panelArticle = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdAfegirFila = New System.Windows.Forms.Button()
        Me.cmdEngantxarArticle = New System.Windows.Forms.Button()
        Me.cmdCopiarArticle = New System.Windows.Forms.Button()
        Me.cmdTreureFila = New System.Windows.Forms.Button()
        Me.txtFiltrarArticle = New OmsXM.TXT()
        Me.lblCercador = New OmsXM.LBLRED()
        Me.cmdCercadorArticle = New System.Windows.Forms.Button()
        Me.cmdEliminarArticle = New System.Windows.Forms.Button()
        Me.cmdModificarArticle = New System.Windows.Forms.Button()
        Me.DGVArticles = New OmsXM.dgvExtended()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantitat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitat = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.descripcio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.import = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descompte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iva = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTitolF56 = New OmsXM.LBLRIGHT()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtaltres = New OmsXM.TXT()
        Me.txtComparatiu = New OmsXM.TXT()
        Me.txtOferta3 = New OmsXM.TXT()
        Me.txtOferta2 = New OmsXM.TXT()
        Me.txtOferta1 = New OmsXM.TXT()
        Me.txtDataMuntatge = New OmsXM.TXT()
        Me.txtDataEnrtrega = New OmsXM.TXT()
        Me.txtDataComanda = New OmsXM.TXT()
        Me.txtContacteEntrega = New OmsXM.TXT()
        Me.txtLlocEntrega = New OmsXM.TXT()
        Me.txtAlcancePedido = New OmsXM.TXT()
        Me.txtContacteProveidor = New OmsXM.TXT()
        Me.txtProveidor = New OmsXM.TXT()
        Me.txtDepartament = New OmsXM.TXT()
        Me.txtProjecte = New OmsXM.TXT()
        Me.txtEmpresa = New OmsXM.TXT()
        Me.Lblblue3 = New OmsXM.LBLBLUE()
        Me.lblAltres = New OmsXM.LBLRIGHT()
        Me.lblOferta2 = New OmsXM.LBLRIGHT()
        Me.lblMagatzem = New OmsXM.LBLRIGHT()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblDataComanda = New System.Windows.Forms.Label()
        Me.lblCaptionProveidor = New OmsXM.LBLRIGHT()
        Me.lblCaptionEmpresa = New OmsXM.LBLRIGHT()
        Me.lblComparatiu = New OmsXM.LBLRIGHT()
        Me.lblOferta3 = New OmsXM.LBLRIGHT()
        Me.lblOferta1 = New OmsXM.LBLRIGHT()
        Me.lblDocumentacioAportada = New OmsXM.LBLRIGHT()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblEntregaMuntatge = New System.Windows.Forms.Label()
        Me.lblEntregaEquips = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCaptionEntrega = New OmsXM.LBLRIGHT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblProveidor = New OmsXM.LBLRIGHT()
        Me.lblAlcancePedido = New OmsXM.LBLRIGHT()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblProjecte = New OmsXM.LBLRIGHT()
        Me.lblTotalCaption = New OmsXM.LBLRIGHT()
        Me.Lblright1 = New OmsXM.LBLRIGHT()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvArticlesF56 = New OmsXM.dgvExtended()
        Me.referenciaF56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantitatF56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitatF56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcioF56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.baseF56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descompteF56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalF56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.lblComptadorEstat = New OmsXM.LBLRED()
        Me.lblEstatComanda = New OmsXM.LBLRED()
        Me.mnuContextual.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitC.Panel1.SuspendLayout()
        Me.SplitC.Panel2.SuspendLayout()
        Me.SplitC.SuspendLayout()
        Me.panelArticle.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DGVArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvArticlesF56, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuContextual
        '
        Me.mnuContextual.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAfegir, Me.mnuEliminar, Me.ToolStripSeparator1, Me.mnuCopiar, Me.mnuEngatxar})
        Me.mnuContextual.Name = "mnuContextual"
        Me.mnuContextual.Size = New System.Drawing.Size(132, 114)
        '
        'mnuAfegir
        '
        Me.mnuAfegir.Image = Global.OmsXM.My.Resources.Resources.afegirFila
        Me.mnuAfegir.Name = "mnuAfegir"
        Me.mnuAfegir.Size = New System.Drawing.Size(131, 26)
        Me.mnuAfegir.Text = "Afegir"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Image = Global.OmsXM.My.Resources.Resources.treureFila
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(131, 26)
        Me.mnuEliminar.Text = "eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(128, 6)
        '
        'mnuCopiar
        '
        Me.mnuCopiar.Image = Global.OmsXM.My.Resources.Resources.copiar
        Me.mnuCopiar.Name = "mnuCopiar"
        Me.mnuCopiar.ShortcutKeyDisplayString = ""
        Me.mnuCopiar.Size = New System.Drawing.Size(131, 26)
        Me.mnuCopiar.Text = "copiar"
        Me.mnuCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuEngatxar
        '
        Me.mnuEngatxar.Image = Global.OmsXM.My.Resources.Resources.engantxar
        Me.mnuEngatxar.Name = "mnuEngatxar"
        Me.mnuEngatxar.Size = New System.Drawing.Size(131, 26)
        Me.mnuEngatxar.Text = "Engantxar"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGuardar.Image = Global.OmsXM.My.Resources.Resources.BotoGuardar
        Me.cmdGuardar.Location = New System.Drawing.Point(2, 2)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(26, 28)
        Me.cmdGuardar.TabIndex = 28
        Me.cmdGuardar.Text = "                                                  "
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'cmdCrear
        '
        Me.cmdCrear.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCrear.Location = New System.Drawing.Point(162, 3)
        Me.cmdCrear.Name = "cmdCrear"
        Me.cmdCrear.Size = New System.Drawing.Size(93, 28)
        Me.cmdCrear.TabIndex = 29
        Me.cmdCrear.Text = "ENVIAR"
        Me.cmdCrear.UseVisualStyleBackColor = False
        '
        'cmdImprimir
        '
        Me.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimir.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.cmdImprimir.Location = New System.Drawing.Point(112, 2)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(26, 28)
        Me.cmdImprimir.TabIndex = 31
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cbEstat
        '
        Me.cbEstat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbEstat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstat.ForeColor = System.Drawing.Color.Red
        Me.cbEstat.FormattingEnabled = True
        Me.cbEstat.Location = New System.Drawing.Point(300, 676)
        Me.cbEstat.Name = "cbEstat"
        Me.cbEstat.Size = New System.Drawing.Size(716, 24)
        Me.cbEstat.TabIndex = 37
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.cmdF56)
        Me.Panel1.Controls.Add(Me.cmdCopiar)
        Me.Panel1.Controls.Add(Me.cmdEliminar)
        Me.Panel1.Controls.Add(Me.cmdImprimir)
        Me.Panel1.Controls.Add(Me.cmdCrear)
        Me.Panel1.Controls.Add(Me.cmdGuardar)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1294, 32)
        Me.Panel1.TabIndex = 73
        '
        'cmdF56
        '
        Me.cmdF56.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdF56.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdF56.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdF56.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdF56.Location = New System.Drawing.Point(1184, 2)
        Me.cmdF56.Name = "cmdF56"
        Me.cmdF56.Size = New System.Drawing.Size(93, 28)
        Me.cmdF56.TabIndex = 78
        Me.cmdF56.Text = "Veure F56"
        Me.cmdF56.UseVisualStyleBackColor = False
        '
        'cmdCopiar
        '
        Me.cmdCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCopiar.Image = Global.OmsXM.My.Resources.Resources.copiar
        Me.cmdCopiar.Location = New System.Drawing.Point(34, 2)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(26, 28)
        Me.cmdCopiar.TabIndex = 77
        Me.cmdCopiar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(66, 2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminar.TabIndex = 76
        Me.cmdEliminar.Text = "                                                  "
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'SplitC
        '
        Me.SplitC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitC.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitC.Location = New System.Drawing.Point(8, 39)
        Me.SplitC.Name = "SplitC"
        '
        'SplitC.Panel1
        '
        Me.SplitC.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitC.Panel1.Controls.Add(Me.lblTotalIva)
        Me.SplitC.Panel1.Controls.Add(Me.lblTotal)
        Me.SplitC.Panel1.Controls.Add(Me.Panel8)
        Me.SplitC.Panel1.Controls.Add(Me.lblTotalBI)
        Me.SplitC.Panel1.Controls.Add(Me.Panel7)
        Me.SplitC.Panel1.Controls.Add(Me.Panel6)
        Me.SplitC.Panel1.Controls.Add(Me.panelArticle)
        '
        'SplitC.Panel2
        '
        Me.SplitC.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SplitC.Panel2.Controls.Add(Me.lblTitolF56)
        Me.SplitC.Panel2.Controls.Add(Me.Panel2)
        Me.SplitC.Size = New System.Drawing.Size(1289, 625)
        Me.SplitC.SplitterDistance = 712
        Me.SplitC.SplitterWidth = 8
        Me.SplitC.TabIndex = 74
        '
        'lblTotalIva
        '
        Me.lblTotalIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalIva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIva.ForeColor = System.Drawing.Color.Black
        Me.lblTotalIva.Location = New System.Drawing.Point(389, 597)
        Me.lblTotalIva.Name = "lblTotalIva"
        Me.lblTotalIva.Size = New System.Drawing.Size(130, 23)
        Me.lblTotalIva.TabIndex = 75
        Me.lblTotalIva.Text = "Cercador"
        Me.lblTotalIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(515, 597)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(170, 23)
        Me.lblTotal.TabIndex = 74
        Me.lblTotal.Text = "Cercador"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(588, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(316, 92)
        Me.Panel8.TabIndex = 75
        '
        'lblTotalBI
        '
        Me.lblTotalBI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalBI.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBI.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBI.Location = New System.Drawing.Point(246, 597)
        Me.lblTotalBI.Name = "lblTotalBI"
        Me.lblTotalBI.Size = New System.Drawing.Size(147, 23)
        Me.lblTotalBI.TabIndex = 73
        Me.lblTotalBI.Text = "Cercador"
        Me.lblTotalBI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(271, 92)
        Me.Panel7.TabIndex = 74
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(280, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(302, 91)
        Me.Panel6.TabIndex = 73
        '
        'panelArticle
        '
        Me.panelArticle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelArticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelArticle.Controls.Add(Me.Panel3)
        Me.panelArticle.Controls.Add(Me.DGVArticles)
        Me.panelArticle.Location = New System.Drawing.Point(3, 96)
        Me.panelArticle.Name = "panelArticle"
        Me.panelArticle.Size = New System.Drawing.Size(701, 487)
        Me.panelArticle.TabIndex = 76
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.cmdAfegirFila)
        Me.Panel3.Controls.Add(Me.cmdEngantxarArticle)
        Me.Panel3.Controls.Add(Me.cmdCopiarArticle)
        Me.Panel3.Controls.Add(Me.cmdTreureFila)
        Me.Panel3.Controls.Add(Me.txtFiltrarArticle)
        Me.Panel3.Controls.Add(Me.lblCercador)
        Me.Panel3.Controls.Add(Me.cmdCercadorArticle)
        Me.Panel3.Controls.Add(Me.cmdEliminarArticle)
        Me.Panel3.Controls.Add(Me.cmdModificarArticle)
        Me.Panel3.Location = New System.Drawing.Point(2, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(687, 32)
        Me.Panel3.TabIndex = 72
        '
        'cmdAfegirFila
        '
        Me.cmdAfegirFila.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegirFila.Image = Global.OmsXM.My.Resources.Resources.afegirFila
        Me.cmdAfegirFila.Location = New System.Drawing.Point(177, 1)
        Me.cmdAfegirFila.Name = "cmdAfegirFila"
        Me.cmdAfegirFila.Size = New System.Drawing.Size(26, 28)
        Me.cmdAfegirFila.TabIndex = 39
        Me.cmdAfegirFila.UseVisualStyleBackColor = True
        '
        'cmdEngantxarArticle
        '
        Me.cmdEngantxarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEngantxarArticle.Image = Global.OmsXM.My.Resources.Resources.engantxar
        Me.cmdEngantxarArticle.Location = New System.Drawing.Point(134, 1)
        Me.cmdEngantxarArticle.Name = "cmdEngantxarArticle"
        Me.cmdEngantxarArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdEngantxarArticle.TabIndex = 38
        Me.cmdEngantxarArticle.UseVisualStyleBackColor = True
        '
        'cmdCopiarArticle
        '
        Me.cmdCopiarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCopiarArticle.Image = Global.OmsXM.My.Resources.Resources.copiar
        Me.cmdCopiarArticle.Location = New System.Drawing.Point(106, 1)
        Me.cmdCopiarArticle.Name = "cmdCopiarArticle"
        Me.cmdCopiarArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdCopiarArticle.TabIndex = 37
        Me.cmdCopiarArticle.UseVisualStyleBackColor = True
        '
        'cmdTreureFila
        '
        Me.cmdTreureFila.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdTreureFila.Image = Global.OmsXM.My.Resources.Resources.treureFila
        Me.cmdTreureFila.Location = New System.Drawing.Point(205, 1)
        Me.cmdTreureFila.Name = "cmdTreureFila"
        Me.cmdTreureFila.Size = New System.Drawing.Size(26, 28)
        Me.cmdTreureFila.TabIndex = 36
        Me.cmdTreureFila.UseVisualStyleBackColor = True
        '
        'txtFiltrarArticle
        '
        Me.txtFiltrarArticle.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFiltrarArticle.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrarArticle.Location = New System.Drawing.Point(497, 2)
        Me.txtFiltrarArticle.Name = "txtFiltrarArticle"
        Me.txtFiltrarArticle.Size = New System.Drawing.Size(186, 26)
        Me.txtFiltrarArticle.TabIndex = 35
        '
        'lblCercador
        '
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.ForeColor = System.Drawing.Color.Black
        Me.lblCercador.Location = New System.Drawing.Point(400, 2)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(91, 23)
        Me.lblCercador.TabIndex = 34
        Me.lblCercador.Text = "Cercador"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCercadorArticle
        '
        Me.cmdCercadorArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCercadorArticle.Image = Global.OmsXM.My.Resources.Resources.BotoCercar
        Me.cmdCercadorArticle.Location = New System.Drawing.Point(689, 1)
        Me.cmdCercadorArticle.Name = "cmdCercadorArticle"
        Me.cmdCercadorArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdCercadorArticle.TabIndex = 33
        Me.cmdCercadorArticle.UseVisualStyleBackColor = True
        '
        'cmdEliminarArticle
        '
        Me.cmdEliminarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminarArticle.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminarArticle.Location = New System.Drawing.Point(60, 1)
        Me.cmdEliminarArticle.Name = "cmdEliminarArticle"
        Me.cmdEliminarArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminarArticle.TabIndex = 30
        Me.cmdEliminarArticle.UseVisualStyleBackColor = True
        '
        'cmdModificarArticle
        '
        Me.cmdModificarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdModificarArticle.Image = Global.OmsXM.My.Resources.Resources.BotoModificar
        Me.cmdModificarArticle.Location = New System.Drawing.Point(28, 1)
        Me.cmdModificarArticle.Name = "cmdModificarArticle"
        Me.cmdModificarArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdModificarArticle.TabIndex = 29
        Me.cmdModificarArticle.UseVisualStyleBackColor = True
        '
        'DGVArticles
        '
        Me.DGVArticles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVArticles.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVArticles.CausesValidation = False
        Me.DGVArticles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVArticles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.codi, Me.quantitat, Me.unitat, Me.descripcio, Me.import, Me.descompte, Me.base, Me.iva, Me.total})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Lucida Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVArticles.DefaultCellStyle = DataGridViewCellStyle9
        Me.DGVArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGVArticles.EnableHeadersVisualStyles = False
        Me.DGVArticles.Location = New System.Drawing.Point(1, 45)
        Me.DGVArticles.Name = "DGVArticles"
        Me.DGVArticles.RowHeadersWidth = 30
        Me.DGVArticles.Size = New System.Drawing.Size(688, 346)
        Me.DGVArticles.TabIndex = 70
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ID.Visible = False
        '
        'codi
        '
        Me.codi.ContextMenuStrip = Me.mnuContextual
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codi.DefaultCellStyle = DataGridViewCellStyle2
        Me.codi.HeaderText = "Referència"
        Me.codi.MaxInputLength = 30
        Me.codi.MinimumWidth = 30
        Me.codi.Name = "codi"
        Me.codi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codi.Width = 150
        '
        'quantitat
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.quantitat.DefaultCellStyle = DataGridViewCellStyle3
        Me.quantitat.HeaderText = "QUAT"
        Me.quantitat.MaxInputLength = 10
        Me.quantitat.MinimumWidth = 6
        Me.quantitat.Name = "quantitat"
        Me.quantitat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.quantitat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.quantitat.Width = 125
        '
        'unitat
        '
        Me.unitat.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.unitat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.unitat.HeaderText = "UNIT."
        Me.unitat.MinimumWidth = 6
        Me.unitat.Name = "unitat"
        Me.unitat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.unitat.Width = 40
        '
        'descripcio
        '
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descripcio.DefaultCellStyle = DataGridViewCellStyle4
        Me.descripcio.HeaderText = "DESCRIPCIO"
        Me.descripcio.MaxInputLength = 200
        Me.descripcio.MinimumWidth = 6
        Me.descripcio.Name = "descripcio"
        Me.descripcio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descripcio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descripcio.Width = 300
        '
        'import
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.import.DefaultCellStyle = DataGridViewCellStyle5
        Me.import.HeaderText = "BASE"
        Me.import.MaxInputLength = 10
        Me.import.MinimumWidth = 6
        Me.import.Name = "import"
        Me.import.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.import.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.import.Width = 125
        '
        'descompte
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.descompte.DefaultCellStyle = DataGridViewCellStyle6
        Me.descompte.HeaderText = "DTO."
        Me.descompte.MaxInputLength = 10
        Me.descompte.MinimumWidth = 6
        Me.descompte.Name = "descompte"
        Me.descompte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descompte.Width = 125
        '
        'base
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.base.DefaultCellStyle = DataGridViewCellStyle7
        Me.base.HeaderText = "TOTAL BASE"
        Me.base.MaxInputLength = 20
        Me.base.MinimumWidth = 6
        Me.base.Name = "base"
        Me.base.ReadOnly = True
        Me.base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.base.Width = 125
        '
        'iva
        '
        Me.iva.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.iva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.iva.HeaderText = "IVA"
        Me.iva.MinimumWidth = 6
        Me.iva.Name = "iva"
        Me.iva.Width = 125
        '
        'total
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.total.DefaultCellStyle = DataGridViewCellStyle8
        Me.total.HeaderText = "TOTAL"
        Me.total.MaxInputLength = 20
        Me.total.MinimumWidth = 6
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        Me.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.total.Width = 125
        '
        'lblTitolF56
        '
        Me.lblTitolF56.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitolF56.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitolF56.ForeColor = System.Drawing.Color.Black
        Me.lblTitolF56.Location = New System.Drawing.Point(10, 4)
        Me.lblTitolF56.Name = "lblTitolF56"
        Me.lblTitolF56.Size = New System.Drawing.Size(525, 25)
        Me.lblTitolF56.TabIndex = 417
        Me.lblTitolF56.Text = "F546- SOL.LICUT DE COMANDA"
        Me.lblTitolF56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.txtaltres)
        Me.Panel2.Controls.Add(Me.txtComparatiu)
        Me.Panel2.Controls.Add(Me.txtOferta3)
        Me.Panel2.Controls.Add(Me.txtOferta2)
        Me.Panel2.Controls.Add(Me.txtOferta1)
        Me.Panel2.Controls.Add(Me.txtDataMuntatge)
        Me.Panel2.Controls.Add(Me.txtDataEnrtrega)
        Me.Panel2.Controls.Add(Me.txtDataComanda)
        Me.Panel2.Controls.Add(Me.txtContacteEntrega)
        Me.Panel2.Controls.Add(Me.txtLlocEntrega)
        Me.Panel2.Controls.Add(Me.txtAlcancePedido)
        Me.Panel2.Controls.Add(Me.txtContacteProveidor)
        Me.Panel2.Controls.Add(Me.txtProveidor)
        Me.Panel2.Controls.Add(Me.txtDepartament)
        Me.Panel2.Controls.Add(Me.txtProjecte)
        Me.Panel2.Controls.Add(Me.txtEmpresa)
        Me.Panel2.Controls.Add(Me.Lblblue3)
        Me.Panel2.Controls.Add(Me.lblAltres)
        Me.Panel2.Controls.Add(Me.lblOferta2)
        Me.Panel2.Controls.Add(Me.lblMagatzem)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.lblDataComanda)
        Me.Panel2.Controls.Add(Me.lblCaptionProveidor)
        Me.Panel2.Controls.Add(Me.lblCaptionEmpresa)
        Me.Panel2.Controls.Add(Me.lblComparatiu)
        Me.Panel2.Controls.Add(Me.lblOferta3)
        Me.Panel2.Controls.Add(Me.lblOferta1)
        Me.Panel2.Controls.Add(Me.lblDocumentacioAportada)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.lblEntregaMuntatge)
        Me.Panel2.Controls.Add(Me.lblEntregaEquips)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.lblCaptionEntrega)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lblProveidor)
        Me.Panel2.Controls.Add(Me.lblAlcancePedido)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lblProjecte)
        Me.Panel2.Controls.Add(Me.lblTotalCaption)
        Me.Panel2.Controls.Add(Me.Lblright1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dgvArticlesF56)
        Me.Panel2.Controls.Add(Me.lblEmpresa)
        Me.Panel2.Location = New System.Drawing.Point(3, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(532, 588)
        Me.Panel2.TabIndex = 1
        '
        'txtaltres
        '
        Me.txtaltres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtaltres.BackColor = System.Drawing.SystemColors.Menu
        Me.txtaltres.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtaltres.ForeColor = System.Drawing.Color.Blue
        Me.txtaltres.Location = New System.Drawing.Point(110, 1145)
        Me.txtaltres.Name = "txtaltres"
        Me.txtaltres.Size = New System.Drawing.Size(1308, 26)
        Me.txtaltres.TabIndex = 436
        '
        'txtComparatiu
        '
        Me.txtComparatiu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComparatiu.BackColor = System.Drawing.SystemColors.Menu
        Me.txtComparatiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtComparatiu.ForeColor = System.Drawing.Color.Blue
        Me.txtComparatiu.Location = New System.Drawing.Point(110, 1119)
        Me.txtComparatiu.Name = "txtComparatiu"
        Me.txtComparatiu.Size = New System.Drawing.Size(1308, 26)
        Me.txtComparatiu.TabIndex = 435
        '
        'txtOferta3
        '
        Me.txtOferta3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOferta3.BackColor = System.Drawing.SystemColors.Menu
        Me.txtOferta3.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtOferta3.ForeColor = System.Drawing.Color.Blue
        Me.txtOferta3.Location = New System.Drawing.Point(110, 1093)
        Me.txtOferta3.Name = "txtOferta3"
        Me.txtOferta3.Size = New System.Drawing.Size(1308, 26)
        Me.txtOferta3.TabIndex = 434
        '
        'txtOferta2
        '
        Me.txtOferta2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOferta2.BackColor = System.Drawing.SystemColors.Menu
        Me.txtOferta2.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtOferta2.ForeColor = System.Drawing.Color.Blue
        Me.txtOferta2.Location = New System.Drawing.Point(110, 1067)
        Me.txtOferta2.Name = "txtOferta2"
        Me.txtOferta2.Size = New System.Drawing.Size(1308, 26)
        Me.txtOferta2.TabIndex = 433
        '
        'txtOferta1
        '
        Me.txtOferta1.BackColor = System.Drawing.SystemColors.Menu
        Me.txtOferta1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtOferta1.ForeColor = System.Drawing.Color.Blue
        Me.txtOferta1.Location = New System.Drawing.Point(110, 1041)
        Me.txtOferta1.Name = "txtOferta1"
        Me.txtOferta1.Size = New System.Drawing.Size(495, 26)
        Me.txtOferta1.TabIndex = 432
        '
        'txtDataMuntatge
        '
        Me.txtDataMuntatge.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDataMuntatge.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDataMuntatge.ForeColor = System.Drawing.Color.Blue
        Me.txtDataMuntatge.Location = New System.Drawing.Point(493, 988)
        Me.txtDataMuntatge.Name = "txtDataMuntatge"
        Me.txtDataMuntatge.Size = New System.Drawing.Size(137, 26)
        Me.txtDataMuntatge.TabIndex = 431
        '
        'txtDataEnrtrega
        '
        Me.txtDataEnrtrega.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDataEnrtrega.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDataEnrtrega.ForeColor = System.Drawing.Color.Blue
        Me.txtDataEnrtrega.Location = New System.Drawing.Point(305, 987)
        Me.txtDataEnrtrega.Name = "txtDataEnrtrega"
        Me.txtDataEnrtrega.Size = New System.Drawing.Size(120, 26)
        Me.txtDataEnrtrega.TabIndex = 430
        '
        'txtDataComanda
        '
        Me.txtDataComanda.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDataComanda.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDataComanda.ForeColor = System.Drawing.Color.Blue
        Me.txtDataComanda.Location = New System.Drawing.Point(110, 987)
        Me.txtDataComanda.Name = "txtDataComanda"
        Me.txtDataComanda.Size = New System.Drawing.Size(126, 26)
        Me.txtDataComanda.TabIndex = 429
        '
        'txtContacteEntrega
        '
        Me.txtContacteEntrega.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContacteEntrega.BackColor = System.Drawing.SystemColors.Menu
        Me.txtContacteEntrega.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtContacteEntrega.ForeColor = System.Drawing.Color.Blue
        Me.txtContacteEntrega.Location = New System.Drawing.Point(110, 940)
        Me.txtContacteEntrega.Multiline = True
        Me.txtContacteEntrega.Name = "txtContacteEntrega"
        Me.txtContacteEntrega.Size = New System.Drawing.Size(1308, 39)
        Me.txtContacteEntrega.TabIndex = 428
        '
        'txtLlocEntrega
        '
        Me.txtLlocEntrega.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLlocEntrega.BackColor = System.Drawing.SystemColors.Menu
        Me.txtLlocEntrega.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtLlocEntrega.ForeColor = System.Drawing.Color.Blue
        Me.txtLlocEntrega.Location = New System.Drawing.Point(110, 908)
        Me.txtLlocEntrega.Name = "txtLlocEntrega"
        Me.txtLlocEntrega.Size = New System.Drawing.Size(1308, 26)
        Me.txtLlocEntrega.TabIndex = 427
        '
        'txtAlcancePedido
        '
        Me.txtAlcancePedido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlcancePedido.BackColor = System.Drawing.SystemColors.Menu
        Me.txtAlcancePedido.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAlcancePedido.ForeColor = System.Drawing.Color.Blue
        Me.txtAlcancePedido.Location = New System.Drawing.Point(15, 838)
        Me.txtAlcancePedido.Multiline = True
        Me.txtAlcancePedido.Name = "txtAlcancePedido"
        Me.txtAlcancePedido.Size = New System.Drawing.Size(1403, 41)
        Me.txtAlcancePedido.TabIndex = 426
        '
        'txtContacteProveidor
        '
        Me.txtContacteProveidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContacteProveidor.BackColor = System.Drawing.SystemColors.Menu
        Me.txtContacteProveidor.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtContacteProveidor.ForeColor = System.Drawing.Color.Blue
        Me.txtContacteProveidor.Location = New System.Drawing.Point(103, 142)
        Me.txtContacteProveidor.Multiline = True
        Me.txtContacteProveidor.Name = "txtContacteProveidor"
        Me.txtContacteProveidor.Size = New System.Drawing.Size(313, 57)
        Me.txtContacteProveidor.TabIndex = 425
        '
        'txtProveidor
        '
        Me.txtProveidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProveidor.BackColor = System.Drawing.SystemColors.Menu
        Me.txtProveidor.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtProveidor.ForeColor = System.Drawing.Color.Blue
        Me.txtProveidor.Location = New System.Drawing.Point(102, 110)
        Me.txtProveidor.Name = "txtProveidor"
        Me.txtProveidor.Size = New System.Drawing.Size(314, 26)
        Me.txtProveidor.TabIndex = 424
        '
        'txtDepartament
        '
        Me.txtDepartament.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepartament.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDepartament.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDepartament.ForeColor = System.Drawing.Color.Blue
        Me.txtDepartament.Location = New System.Drawing.Point(4049, 28)
        Me.txtDepartament.Name = "txtDepartament"
        Me.txtDepartament.Size = New System.Drawing.Size(178, 26)
        Me.txtDepartament.TabIndex = 423
        '
        'txtProjecte
        '
        Me.txtProjecte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjecte.BackColor = System.Drawing.SystemColors.Menu
        Me.txtProjecte.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtProjecte.ForeColor = System.Drawing.Color.Blue
        Me.txtProjecte.Location = New System.Drawing.Point(105, 63)
        Me.txtProjecte.Name = "txtProjecte"
        Me.txtProjecte.Size = New System.Drawing.Size(311, 26)
        Me.txtProjecte.TabIndex = 422
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmpresa.BackColor = System.Drawing.SystemColors.Menu
        Me.txtEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.txtEmpresa.Location = New System.Drawing.Point(105, 27)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(311, 26)
        Me.txtEmpresa.TabIndex = 421
        '
        'Lblblue3
        '
        Me.Lblblue3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lblblue3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblblue3.ForeColor = System.Drawing.Color.Blue
        Me.Lblblue3.Location = New System.Drawing.Point(4238, 60)
        Me.Lblblue3.Name = "Lblblue3"
        Me.Lblblue3.Size = New System.Drawing.Size(96, 23)
        Me.Lblblue3.TabIndex = 420
        Me.Lblblue3.Text = "Lblblue3"
        '
        'lblAltres
        '
        Me.lblAltres.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAltres.ForeColor = System.Drawing.Color.Black
        Me.lblAltres.Location = New System.Drawing.Point(21, 1145)
        Me.lblAltres.Name = "lblAltres"
        Me.lblAltres.Size = New System.Drawing.Size(83, 20)
        Me.lblAltres.TabIndex = 415
        Me.lblAltres.Text = "Oferta1:"
        Me.lblAltres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOferta2
        '
        Me.lblOferta2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblOferta2.ForeColor = System.Drawing.Color.Black
        Me.lblOferta2.Location = New System.Drawing.Point(18, 1067)
        Me.lblOferta2.Name = "lblOferta2"
        Me.lblOferta2.Size = New System.Drawing.Size(86, 23)
        Me.lblOferta2.TabIndex = 412
        Me.lblOferta2.Text = "Oferta1:"
        Me.lblOferta2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMagatzem
        '
        Me.lblMagatzem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMagatzem.ForeColor = System.Drawing.Color.Black
        Me.lblMagatzem.Location = New System.Drawing.Point(21, 909)
        Me.lblMagatzem.Name = "lblMagatzem"
        Me.lblMagatzem.Size = New System.Drawing.Size(88, 17)
        Me.lblMagatzem.TabIndex = 392
        Me.lblMagatzem.Text = "Lblright3"
        Me.lblMagatzem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 903)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(4697, 2)
        Me.Label8.TabIndex = 403
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDataComanda
        '
        Me.lblDataComanda.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDataComanda.Location = New System.Drawing.Point(21, 987)
        Me.lblDataComanda.Name = "lblDataComanda"
        Me.lblDataComanda.Size = New System.Drawing.Size(85, 25)
        Me.lblDataComanda.TabIndex = 409
        Me.lblDataComanda.Text = "Label5"
        Me.lblDataComanda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaptionProveidor
        '
        Me.lblCaptionProveidor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblCaptionProveidor.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionProveidor.Location = New System.Drawing.Point(24, 92)
        Me.lblCaptionProveidor.Name = "lblCaptionProveidor"
        Me.lblCaptionProveidor.Size = New System.Drawing.Size(134, 14)
        Me.lblCaptionProveidor.TabIndex = 417
        Me.lblCaptionProveidor.Text = "Proveedor:"
        Me.lblCaptionProveidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaptionEmpresa
        '
        Me.lblCaptionEmpresa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblCaptionEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionEmpresa.Location = New System.Drawing.Point(24, 7)
        Me.lblCaptionEmpresa.Name = "lblCaptionEmpresa"
        Me.lblCaptionEmpresa.Size = New System.Drawing.Size(134, 14)
        Me.lblCaptionEmpresa.TabIndex = 416
        Me.lblCaptionEmpresa.Text = "EMPRESA:"
        Me.lblCaptionEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblComparatiu
        '
        Me.lblComparatiu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblComparatiu.ForeColor = System.Drawing.Color.Black
        Me.lblComparatiu.Location = New System.Drawing.Point(24, 1119)
        Me.lblComparatiu.Name = "lblComparatiu"
        Me.lblComparatiu.Size = New System.Drawing.Size(80, 23)
        Me.lblComparatiu.TabIndex = 414
        Me.lblComparatiu.Text = "Oferta1:"
        Me.lblComparatiu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOferta3
        '
        Me.lblOferta3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblOferta3.ForeColor = System.Drawing.Color.Black
        Me.lblOferta3.Location = New System.Drawing.Point(18, 1093)
        Me.lblOferta3.Name = "lblOferta3"
        Me.lblOferta3.Size = New System.Drawing.Size(86, 23)
        Me.lblOferta3.TabIndex = 413
        Me.lblOferta3.Text = "Oferta1:"
        Me.lblOferta3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOferta1
        '
        Me.lblOferta1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblOferta1.ForeColor = System.Drawing.Color.Black
        Me.lblOferta1.Location = New System.Drawing.Point(15, 1041)
        Me.lblOferta1.Name = "lblOferta1"
        Me.lblOferta1.Size = New System.Drawing.Size(89, 23)
        Me.lblOferta1.TabIndex = 411
        Me.lblOferta1.Text = "Oferta1:"
        Me.lblOferta1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDocumentacioAportada
        '
        Me.lblDocumentacioAportada.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDocumentacioAportada.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentacioAportada.Location = New System.Drawing.Point(31, 1013)
        Me.lblDocumentacioAportada.Name = "lblDocumentacioAportada"
        Me.lblDocumentacioAportada.Size = New System.Drawing.Size(182, 23)
        Me.lblDocumentacioAportada.TabIndex = 410
        Me.lblDocumentacioAportada.Text = "Documentacion aportada"
        Me.lblDocumentacioAportada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 1036)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(4697, 2)
        Me.Label10.TabIndex = 408
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEntregaMuntatge
        '
        Me.lblEntregaMuntatge.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEntregaMuntatge.Location = New System.Drawing.Point(426, 987)
        Me.lblEntregaMuntatge.Name = "lblEntregaMuntatge"
        Me.lblEntregaMuntatge.Size = New System.Drawing.Size(61, 25)
        Me.lblEntregaMuntatge.TabIndex = 407
        Me.lblEntregaMuntatge.Text = "Label5"
        Me.lblEntregaMuntatge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEntregaEquips
        '
        Me.lblEntregaEquips.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEntregaEquips.Location = New System.Drawing.Point(242, 987)
        Me.lblEntregaEquips.Name = "lblEntregaEquips"
        Me.lblEntregaEquips.Size = New System.Drawing.Size(57, 25)
        Me.lblEntregaEquips.TabIndex = 406
        Me.lblEntregaEquips.Text = "Label5"
        Me.lblEntregaEquips.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 982)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(4697, 2)
        Me.Label9.TabIndex = 405
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaptionEntrega
        '
        Me.lblCaptionEntrega.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblCaptionEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionEntrega.Location = New System.Drawing.Point(29, 882)
        Me.lblCaptionEntrega.Name = "lblCaptionEntrega"
        Me.lblCaptionEntrega.Size = New System.Drawing.Size(134, 18)
        Me.lblCaptionEntrega.TabIndex = 404
        Me.lblCaptionEntrega.Text = "Entrega"
        Me.lblCaptionEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(4697, 2)
        Me.Label4.TabIndex = 395
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProveidor
        '
        Me.lblProveidor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblProveidor.ForeColor = System.Drawing.Color.Black
        Me.lblProveidor.Location = New System.Drawing.Point(12, 116)
        Me.lblProveidor.Name = "lblProveidor"
        Me.lblProveidor.Size = New System.Drawing.Size(84, 18)
        Me.lblProveidor.TabIndex = 394
        Me.lblProveidor.Text = "Lblright1"
        Me.lblProveidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAlcancePedido
        '
        Me.lblAlcancePedido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAlcancePedido.ForeColor = System.Drawing.Color.Black
        Me.lblAlcancePedido.Location = New System.Drawing.Point(29, 821)
        Me.lblAlcancePedido.Name = "lblAlcancePedido"
        Me.lblAlcancePedido.Size = New System.Drawing.Size(134, 14)
        Me.lblAlcancePedido.TabIndex = 402
        Me.lblAlcancePedido.Text = "Alcance del Pedido"
        Me.lblAlcancePedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 835)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(4213, 2)
        Me.Label7.TabIndex = 399
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProjecte
        '
        Me.lblProjecte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblProjecte.ForeColor = System.Drawing.Color.Black
        Me.lblProjecte.Location = New System.Drawing.Point(14, 64)
        Me.lblProjecte.Name = "lblProjecte"
        Me.lblProjecte.Size = New System.Drawing.Size(83, 18)
        Me.lblProjecte.TabIndex = 393
        Me.lblProjecte.Text = "Lblright2"
        Me.lblProjecte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCaption
        '
        Me.lblTotalCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCaption.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCaption.ForeColor = System.Drawing.Color.Black
        Me.lblTotalCaption.Location = New System.Drawing.Point(4040, 800)
        Me.lblTotalCaption.Name = "lblTotalCaption"
        Me.lblTotalCaption.Size = New System.Drawing.Size(179, 25)
        Me.lblTotalCaption.TabIndex = 401
        Me.lblTotalCaption.Text = "TOTAL:"
        Me.lblTotalCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lblright1
        '
        Me.Lblright1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lblright1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lblright1.ForeColor = System.Drawing.Color.Black
        Me.Lblright1.Location = New System.Drawing.Point(4235, 461)
        Me.Lblright1.Name = "Lblright1"
        Me.Lblright1.Size = New System.Drawing.Size(108, 25)
        Me.Lblright1.TabIndex = 400
        Me.Lblright1.Text = "lbltotal"
        Me.Lblright1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(4697, 2)
        Me.Label6.TabIndex = 397
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(4697, 2)
        Me.Label5.TabIndex = 396
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvArticlesF56
        '
        Me.dgvArticlesF56.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArticlesF56.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvArticlesF56.CausesValidation = False
        Me.dgvArticlesF56.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArticlesF56.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvArticlesF56.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticlesF56.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.referenciaF56, Me.quantitatF56, Me.unitatF56, Me.descripcioF56, Me.baseF56, Me.descompteF56, Me.totalF56})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Lucida Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvArticlesF56.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvArticlesF56.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvArticlesF56.EnableHeadersVisualStyles = False
        Me.dgvArticlesF56.Location = New System.Drawing.Point(15, 207)
        Me.dgvArticlesF56.Name = "dgvArticlesF56"
        Me.dgvArticlesF56.RowHeadersWidth = 30
        Me.dgvArticlesF56.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticlesF56.Size = New System.Drawing.Size(492, 598)
        Me.dgvArticlesF56.TabIndex = 398
        '
        'referenciaF56
        '
        Me.referenciaF56.HeaderText = "REFERENCIA"
        Me.referenciaF56.Name = "referenciaF56"
        '
        'quantitatF56
        '
        Me.quantitatF56.HeaderText = "Qunaitat"
        Me.quantitatF56.Name = "quantitatF56"
        '
        'unitatF56
        '
        Me.unitatF56.HeaderText = "UNIT."
        Me.unitatF56.MinimumWidth = 6
        Me.unitatF56.Name = "unitatF56"
        Me.unitatF56.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.unitatF56.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.unitatF56.Width = 60
        '
        'descripcioF56
        '
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descripcioF56.DefaultCellStyle = DataGridViewCellStyle11
        Me.descripcioF56.HeaderText = "DESCRIPCIO"
        Me.descripcioF56.MaxInputLength = 200
        Me.descripcioF56.MinimumWidth = 6
        Me.descripcioF56.Name = "descripcioF56"
        Me.descripcioF56.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descripcioF56.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descripcioF56.Width = 300
        '
        'baseF56
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.baseF56.DefaultCellStyle = DataGridViewCellStyle12
        Me.baseF56.HeaderText = "BASE"
        Me.baseF56.MaxInputLength = 10
        Me.baseF56.MinimumWidth = 6
        Me.baseF56.Name = "baseF56"
        Me.baseF56.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.baseF56.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.baseF56.Width = 125
        '
        'descompteF56
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.descompteF56.DefaultCellStyle = DataGridViewCellStyle13
        Me.descompteF56.HeaderText = "DTO."
        Me.descompteF56.MaxInputLength = 10
        Me.descompteF56.MinimumWidth = 6
        Me.descompteF56.Name = "descompteF56"
        Me.descompteF56.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descompteF56.Width = 125
        '
        'totalF56
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.Format = "C2"
        DataGridViewCellStyle14.NullValue = "0"
        Me.totalF56.DefaultCellStyle = DataGridViewCellStyle14
        Me.totalF56.HeaderText = "TOTAL"
        Me.totalF56.MaxInputLength = 20
        Me.totalF56.MinimumWidth = 6
        Me.totalF56.Name = "totalF56"
        Me.totalF56.ReadOnly = True
        Me.totalF56.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.totalF56.Width = 125
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(10, 32)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(87, 18)
        Me.lblEmpresa.TabIndex = 391
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblComptadorEstat
        '
        Me.lblComptadorEstat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComptadorEstat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComptadorEstat.ForeColor = System.Drawing.Color.Black
        Me.lblComptadorEstat.Location = New System.Drawing.Point(1022, 676)
        Me.lblComptadorEstat.Name = "lblComptadorEstat"
        Me.lblComptadorEstat.Size = New System.Drawing.Size(271, 24)
        Me.lblComptadorEstat.TabIndex = 74
        Me.lblComptadorEstat.Text = "Cercador"
        Me.lblComptadorEstat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstatComanda
        '
        Me.lblEstatComanda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEstatComanda.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatComanda.ForeColor = System.Drawing.Color.Black
        Me.lblEstatComanda.Location = New System.Drawing.Point(184, 676)
        Me.lblEstatComanda.Name = "lblEstatComanda"
        Me.lblEstatComanda.Size = New System.Drawing.Size(110, 19)
        Me.lblEstatComanda.TabIndex = 73
        Me.lblEstatComanda.Text = "Cercador"
        Me.lblEstatComanda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.SplitC)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblComptadorEstat)
        Me.Controls.Add(Me.cbEstat)
        Me.Controls.Add(Me.lblEstatComanda)
        Me.Name = "pComanda"
        Me.Size = New System.Drawing.Size(1304, 724)
        Me.mnuContextual.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitC.Panel1.ResumeLayout(False)
        Me.SplitC.Panel2.ResumeLayout(False)
        CType(Me.SplitC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitC.ResumeLayout(False)
        Me.panelArticle.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DGVArticles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvArticlesF56, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents mnuContextual As ContextMenuStrip
    Friend WithEvents mnuAfegir As ToolStripMenuItem
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents mnuCopiar As ToolStripMenuItem
    Friend WithEvents mnuEngatxar As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCrear As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cbEstat As ComboBox
    Friend WithEvents lblEstatComanda As LBLRED
    Friend WithEvents lblComptadorEstat As LBLRED
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdCopiar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents SplitC As SplitContainer
    Friend WithEvents panelArticle As Panel
    Friend WithEvents lblTotalIva As LBLRED
    Friend WithEvents lblTotal As LBLRED
    Friend WithEvents lblTotalBI As LBLRED
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmdAfegirFila As Button
    Friend WithEvents cmdEngantxarArticle As Button
    Friend WithEvents cmdCopiarArticle As Button
    Friend WithEvents cmdTreureFila As Button
    Friend WithEvents txtFiltrarArticle As TXT
    Friend WithEvents lblCercador As LBLRED
    Friend WithEvents cmdCercadorArticle As Button
    Friend WithEvents cmdEliminarArticle As Button
    Friend WithEvents cmdModificarArticle As Button
    Friend WithEvents DGVArticles As dgvExtended
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents cmdF56 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Lblblue3 As LBLBLUE
    Friend WithEvents lblAltres As LBLRIGHT
    Friend WithEvents lblOferta2 As LBLRIGHT
    Friend WithEvents lblMagatzem As LBLRIGHT
    Friend WithEvents Label8 As Label
    Friend WithEvents lblDataComanda As Label
    Friend WithEvents lblCaptionProveidor As LBLRIGHT
    Friend WithEvents lblCaptionEmpresa As LBLRIGHT
    Friend WithEvents lblComparatiu As LBLRIGHT
    Friend WithEvents lblOferta3 As LBLRIGHT
    Friend WithEvents lblOferta1 As LBLRIGHT
    Friend WithEvents lblDocumentacioAportada As LBLRIGHT
    Friend WithEvents Label10 As Label
    Friend WithEvents lblEntregaMuntatge As Label
    Friend WithEvents lblEntregaEquips As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCaptionEntrega As LBLRIGHT
    Friend WithEvents Label4 As Label
    Friend WithEvents lblProveidor As LBLRIGHT
    Friend WithEvents lblAlcancePedido As LBLRIGHT
    Friend WithEvents Label7 As Label
    Friend WithEvents lblProjecte As LBLRIGHT
    Friend WithEvents lblTotalCaption As LBLRIGHT
    Friend WithEvents Lblright1 As LBLRIGHT
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvArticlesF56 As dgvExtended
    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents lblTitolF56 As LBLRIGHT
    Friend WithEvents txtDepartament As TXT
    Friend WithEvents txtProjecte As TXT
    Friend WithEvents txtContacteProveidor As TXT
    Friend WithEvents txtProveidor As TXT
    Friend WithEvents txtAlcancePedido As TXT
    Friend WithEvents txtaltres As TXT
    Friend WithEvents txtComparatiu As TXT
    Friend WithEvents txtOferta3 As TXT
    Friend WithEvents txtOferta2 As TXT
    Friend WithEvents txtOferta1 As TXT
    Friend WithEvents txtDataMuntatge As TXT
    Friend WithEvents txtDataEnrtrega As TXT
    Friend WithEvents txtDataComanda As TXT
    Friend WithEvents txtContacteEntrega As TXT
    Friend WithEvents txtLlocEntrega As TXT
    Friend WithEvents referenciaF56 As DataGridViewTextBoxColumn
    Friend WithEvents quantitatF56 As DataGridViewTextBoxColumn
    Friend WithEvents unitatF56 As DataGridViewTextBoxColumn
    Friend WithEvents descripcioF56 As DataGridViewTextBoxColumn
    Friend WithEvents baseF56 As DataGridViewTextBoxColumn
    Friend WithEvents descompteF56 As DataGridViewTextBoxColumn
    Friend WithEvents totalF56 As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents codi As DataGridViewTextBoxColumn
    Friend WithEvents quantitat As DataGridViewTextBoxColumn
    Friend WithEvents unitat As DataGridViewComboBoxColumn
    Friend WithEvents descripcio As DataGridViewTextBoxColumn
    Friend WithEvents import As DataGridViewTextBoxColumn
    Friend WithEvents descompte As DataGridViewTextBoxColumn
    Friend WithEvents base As DataGridViewTextBoxColumn
    Friend WithEvents iva As DataGridViewComboBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
    Friend WithEvents txtEmpresa As TXT
End Class
