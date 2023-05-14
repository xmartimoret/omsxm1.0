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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pComanda))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAfegir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEngatxar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbEstat = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.xecUrgent = New OmsXM.XEC()
        Me.cmdExcel = New System.Windows.Forms.Button()
        Me.cmdAdjunts = New System.Windows.Forms.Button()
        Me.cmdCopiar = New System.Windows.Forms.Button()
        Me.lblEstatComanda = New OmsXM.LBLRED()
        Me.lblComptadorEstat = New OmsXM.LBLRED()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdPDF = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdValidar = New System.Windows.Forms.Button()
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
        Me.cmdAfegirAdjunt = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pdfReader = New AxAcroPDFLib.AxAcroPDF()
        Me.lblAdjunts = New OmsXM.LBLRED()
        Me.cbAdjunts = New System.Windows.Forms.ComboBox()
        Me.openFile = New System.Windows.Forms.OpenFileDialog()
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
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
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
        'cbEstat
        '
        Me.cbEstat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbEstat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstat.ForeColor = System.Drawing.Color.Red
        Me.cbEstat.FormattingEnabled = True
        Me.cbEstat.Location = New System.Drawing.Point(341, 5)
        Me.cbEstat.Name = "cbEstat"
        Me.cbEstat.Size = New System.Drawing.Size(484, 24)
        Me.cbEstat.TabIndex = 37
        Me.cbEstat.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.xecUrgent)
        Me.Panel1.Controls.Add(Me.cmdExcel)
        Me.Panel1.Controls.Add(Me.cmdAdjunts)
        Me.Panel1.Controls.Add(Me.cmdCopiar)
        Me.Panel1.Controls.Add(Me.lblEstatComanda)
        Me.Panel1.Controls.Add(Me.lblComptadorEstat)
        Me.Panel1.Controls.Add(Me.cbEstat)
        Me.Panel1.Controls.Add(Me.cmdEliminar)
        Me.Panel1.Controls.Add(Me.cmdPDF)
        Me.Panel1.Controls.Add(Me.cmdGuardar)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1477, 32)
        Me.Panel1.TabIndex = 73
        '
        'xecUrgent
        '
        Me.xecUrgent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xecUrgent.AutoSize = True
        Me.xecUrgent.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecUrgent.ForeColor = System.Drawing.Color.Black
        Me.xecUrgent.Location = New System.Drawing.Point(1228, 7)
        Me.xecUrgent.Name = "xecUrgent"
        Me.xecUrgent.Size = New System.Drawing.Size(71, 22)
        Me.xecUrgent.TabIndex = 81
        Me.xecUrgent.Text = "Urgent"
        Me.xecUrgent.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExcel.Image = Global.OmsXM.My.Resources.Resources.excel
        Me.cmdExcel.Location = New System.Drawing.Point(106, 2)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(26, 28)
        Me.cmdExcel.TabIndex = 80
        Me.cmdExcel.TabStop = False
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'cmdAdjunts
        '
        Me.cmdAdjunts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdjunts.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAdjunts.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAdjunts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdjunts.Location = New System.Drawing.Point(1334, 2)
        Me.cmdAdjunts.Name = "cmdAdjunts"
        Me.cmdAdjunts.Size = New System.Drawing.Size(139, 28)
        Me.cmdAdjunts.TabIndex = 78
        Me.cmdAdjunts.Text = "Veure F56"
        Me.cmdAdjunts.UseVisualStyleBackColor = False
        '
        'cmdCopiar
        '
        Me.cmdCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCopiar.Image = Global.OmsXM.My.Resources.Resources.copiar
        Me.cmdCopiar.Location = New System.Drawing.Point(34, 2)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(26, 28)
        Me.cmdCopiar.TabIndex = 77
        Me.cmdCopiar.TabStop = False
        Me.cmdCopiar.UseVisualStyleBackColor = True
        '
        'lblEstatComanda
        '
        Me.lblEstatComanda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEstatComanda.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatComanda.ForeColor = System.Drawing.Color.Black
        Me.lblEstatComanda.Location = New System.Drawing.Point(225, 7)
        Me.lblEstatComanda.Name = "lblEstatComanda"
        Me.lblEstatComanda.Size = New System.Drawing.Size(113, 19)
        Me.lblEstatComanda.TabIndex = 73
        Me.lblEstatComanda.Text = "Cercador"
        Me.lblEstatComanda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblComptadorEstat
        '
        Me.lblComptadorEstat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComptadorEstat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComptadorEstat.ForeColor = System.Drawing.Color.Black
        Me.lblComptadorEstat.Location = New System.Drawing.Point(828, 5)
        Me.lblComptadorEstat.Name = "lblComptadorEstat"
        Me.lblComptadorEstat.Size = New System.Drawing.Size(378, 24)
        Me.lblComptadorEstat.TabIndex = 74
        Me.lblComptadorEstat.Text = "Cercador"
        Me.lblComptadorEstat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(66, 2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminar.TabIndex = 76
        Me.cmdEliminar.TabStop = False
        Me.cmdEliminar.Text = "                                                  "
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdPDF
        '
        Me.cmdPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPDF.Image = Global.OmsXM.My.Resources.Resources.pdf
        Me.cmdPDF.Location = New System.Drawing.Point(134, 1)
        Me.cmdPDF.Name = "cmdPDF"
        Me.cmdPDF.Size = New System.Drawing.Size(26, 28)
        Me.cmdPDF.TabIndex = 31
        Me.cmdPDF.TabStop = False
        Me.cmdPDF.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGuardar.Image = Global.OmsXM.My.Resources.Resources.BotoGuardar
        Me.cmdGuardar.Location = New System.Drawing.Point(2, 2)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(26, 28)
        Me.cmdGuardar.TabIndex = 28
        Me.cmdGuardar.TabStop = False
        Me.cmdGuardar.Text = "                                                  "
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'cmdValidar
        '
        Me.cmdValidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdValidar.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdValidar.Location = New System.Drawing.Point(69, 561)
        Me.cmdValidar.Name = "cmdValidar"
        Me.cmdValidar.Size = New System.Drawing.Size(156, 28)
        Me.cmdValidar.TabIndex = 79
        Me.cmdValidar.Text = "ValidarComanda"
        Me.cmdValidar.UseVisualStyleBackColor = False
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
        Me.SplitC.Panel2.Controls.Add(Me.cmdAfegirAdjunt)
        Me.SplitC.Panel2.Controls.Add(Me.Panel2)
        Me.SplitC.Panel2.Controls.Add(Me.lblAdjunts)
        Me.SplitC.Panel2.Controls.Add(Me.cbAdjunts)
        Me.SplitC.Size = New System.Drawing.Size(1472, 510)
        Me.SplitC.SplitterDistance = 918
        Me.SplitC.SplitterWidth = 8
        Me.SplitC.TabIndex = 74
        '
        'lblTotalIva
        '
        Me.lblTotalIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalIva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIva.ForeColor = System.Drawing.Color.Black
        Me.lblTotalIva.Location = New System.Drawing.Point(595, 482)
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
        Me.lblTotal.Location = New System.Drawing.Point(721, 482)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(170, 23)
        Me.lblTotal.TabIndex = 74
        Me.lblTotal.Text = "Cercador"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(290, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(623, 129)
        Me.Panel8.TabIndex = 75
        '
        'lblTotalBI
        '
        Me.lblTotalBI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalBI.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBI.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBI.Location = New System.Drawing.Point(452, 482)
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
        Me.Panel7.Size = New System.Drawing.Size(271, 129)
        Me.Panel7.TabIndex = 74
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(280, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(302, 128)
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
        Me.panelArticle.Location = New System.Drawing.Point(3, 137)
        Me.panelArticle.Name = "panelArticle"
        Me.panelArticle.Size = New System.Drawing.Size(907, 331)
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
        Me.Panel3.Size = New System.Drawing.Size(893, 32)
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
        Me.cmdAfegirFila.TabStop = False
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
        Me.cmdEngantxarArticle.TabStop = False
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
        Me.cmdCopiarArticle.TabStop = False
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
        Me.cmdTreureFila.TabStop = False
        Me.cmdTreureFila.UseVisualStyleBackColor = True
        '
        'txtFiltrarArticle
        '
        Me.txtFiltrarArticle.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFiltrarArticle.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrarArticle.Location = New System.Drawing.Point(497, 2)
        Me.txtFiltrarArticle.Name = "txtFiltrarArticle"
        Me.txtFiltrarArticle.Size = New System.Drawing.Size(369, 26)
        Me.txtFiltrarArticle.TabIndex = 35
        Me.txtFiltrarArticle.TabStop = False
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
        Me.cmdCercadorArticle.Location = New System.Drawing.Point(886, 2)
        Me.cmdCercadorArticle.Name = "cmdCercadorArticle"
        Me.cmdCercadorArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdCercadorArticle.TabIndex = 33
        Me.cmdCercadorArticle.TabStop = False
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
        Me.cmdEliminarArticle.TabStop = False
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
        Me.cmdModificarArticle.TabStop = False
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
        Me.DGVArticles.Location = New System.Drawing.Point(1, 37)
        Me.DGVArticles.Name = "DGVArticles"
        Me.DGVArticles.RowHeadersWidth = 30
        Me.DGVArticles.Size = New System.Drawing.Size(894, 198)
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
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
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
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
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
        'cmdAfegirAdjunt
        '
        Me.cmdAfegirAdjunt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAfegirAdjunt.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAfegirAdjunt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegirAdjunt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAfegirAdjunt.Location = New System.Drawing.Point(418, 3)
        Me.cmdAfegirAdjunt.Name = "cmdAfegirAdjunt"
        Me.cmdAfegirAdjunt.Size = New System.Drawing.Size(107, 28)
        Me.cmdAfegirAdjunt.TabIndex = 81
        Me.cmdAfegirAdjunt.Text = "Veure F56"
        Me.cmdAfegirAdjunt.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.pdfReader)
        Me.Panel2.Location = New System.Drawing.Point(3, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(522, 472)
        Me.Panel2.TabIndex = 76
        '
        'pdfReader
        '
        Me.pdfReader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfReader.Enabled = True
        Me.pdfReader.Location = New System.Drawing.Point(0, 0)
        Me.pdfReader.Name = "pdfReader"
        Me.pdfReader.OcxState = CType(resources.GetObject("pdfReader.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfReader.Size = New System.Drawing.Size(522, 472)
        Me.pdfReader.TabIndex = 0
        '
        'lblAdjunts
        '
        Me.lblAdjunts.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjunts.ForeColor = System.Drawing.Color.Black
        Me.lblAdjunts.Location = New System.Drawing.Point(26, 8)
        Me.lblAdjunts.Name = "lblAdjunts"
        Me.lblAdjunts.Size = New System.Drawing.Size(148, 19)
        Me.lblAdjunts.TabIndex = 75
        Me.lblAdjunts.Text = "Cercador"
        Me.lblAdjunts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbAdjunts
        '
        Me.cbAdjunts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAdjunts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAdjunts.ForeColor = System.Drawing.Color.Blue
        Me.cbAdjunts.FormattingEnabled = True
        Me.cbAdjunts.Location = New System.Drawing.Point(180, 3)
        Me.cbAdjunts.Name = "cbAdjunts"
        Me.cbAdjunts.Size = New System.Drawing.Size(232, 24)
        Me.cbAdjunts.TabIndex = 74
        '
        'pComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.cmdValidar)
        Me.Controls.Add(Me.SplitC)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "pComanda"
        Me.Size = New System.Drawing.Size(1487, 609)
        Me.mnuContextual.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitC.Panel1.ResumeLayout(False)
        Me.SplitC.Panel2.ResumeLayout(False)
        CType(Me.SplitC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitC.ResumeLayout(False)
        Me.panelArticle.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DGVArticles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdPDF As Button
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
    Friend WithEvents cmdAdjunts As Button
    Friend WithEvents cmdValidar As Button
    Friend WithEvents cmdExcel As Button
    Friend WithEvents pdfReader As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents lblAdjunts As LBLRED
    Friend WithEvents cbAdjunts As ComboBox
    Friend WithEvents Panel2 As Panel
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
    Friend WithEvents cmdAfegirAdjunt As Button
    Friend WithEvents openFile As OpenFileDialog
    Friend WithEvents xecUrgent As XEC
End Class
