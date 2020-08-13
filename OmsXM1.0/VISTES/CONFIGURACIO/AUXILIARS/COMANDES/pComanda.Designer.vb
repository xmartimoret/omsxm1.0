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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.mnuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAfegir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEngatxar = New System.Windows.Forms.ToolStripMenuItem()
        Me.panelArticle = New System.Windows.Forms.Panel()
        Me.lblTotalIva = New OmsXM.LBLRED()
        Me.lblTotal = New OmsXM.LBLRED()
        Me.lblTotalBI = New OmsXM.LBLRED()
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
        Me.codi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantitat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitat = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.descripcio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.import = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descompte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iva = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdValidar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cbEstat = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTipusComanda = New OmsXM.LBLRED()
        Me.lblComptadorEstat = New OmsXM.LBLRED()
        Me.lblEstatComanda = New OmsXM.LBLRED()
        Me.mnuContextual.SuspendLayout()
        Me.panelArticle.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DGVArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(540, 44)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(574, 107)
        Me.Panel6.TabIndex = 66
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Location = New System.Drawing.Point(4, 44)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(527, 107)
        Me.Panel7.TabIndex = 67
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(1123, 43)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(562, 108)
        Me.Panel8.TabIndex = 68
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
        'panelArticle
        '
        Me.panelArticle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelArticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelArticle.Controls.Add(Me.lblTotalIva)
        Me.panelArticle.Controls.Add(Me.lblTotal)
        Me.panelArticle.Controls.Add(Me.lblTotalBI)
        Me.panelArticle.Controls.Add(Me.Panel3)
        Me.panelArticle.Controls.Add(Me.DGVArticles)
        Me.panelArticle.Location = New System.Drawing.Point(8, 159)
        Me.panelArticle.Margin = New System.Windows.Forms.Padding(4)
        Me.panelArticle.Name = "panelArticle"
        Me.panelArticle.Size = New System.Drawing.Size(1677, 577)
        Me.panelArticle.TabIndex = 72
        '
        'lblTotalIva
        '
        Me.lblTotalIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalIva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIva.ForeColor = System.Drawing.Color.Black
        Me.lblTotalIva.Location = New System.Drawing.Point(1264, 535)
        Me.lblTotalIva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIva.Name = "lblTotalIva"
        Me.lblTotalIva.Size = New System.Drawing.Size(173, 28)
        Me.lblTotalIva.TabIndex = 75
        Me.lblTotalIva.Text = "Cercador"
        Me.lblTotalIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(1432, 535)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(227, 28)
        Me.lblTotal.TabIndex = 74
        Me.lblTotal.Text = "Cercador"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalBI
        '
        Me.lblTotalBI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalBI.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBI.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBI.Location = New System.Drawing.Point(1073, 535)
        Me.lblTotalBI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalBI.Name = "lblTotalBI"
        Me.lblTotalBI.Size = New System.Drawing.Size(196, 28)
        Me.lblTotalBI.TabIndex = 73
        Me.lblTotalBI.Text = "Cercador"
        Me.lblTotalBI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Panel3.Location = New System.Drawing.Point(3, 4)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1655, 39)
        Me.Panel3.TabIndex = 72
        '
        'cmdAfegirFila
        '
        Me.cmdAfegirFila.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegirFila.Image = Global.OmsXM.My.Resources.Resources.afegirFila
        Me.cmdAfegirFila.Location = New System.Drawing.Point(236, 1)
        Me.cmdAfegirFila.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAfegirFila.Name = "cmdAfegirFila"
        Me.cmdAfegirFila.Size = New System.Drawing.Size(35, 34)
        Me.cmdAfegirFila.TabIndex = 39
        Me.cmdAfegirFila.UseVisualStyleBackColor = True
        '
        'cmdEngantxarArticle
        '
        Me.cmdEngantxarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEngantxarArticle.Image = Global.OmsXM.My.Resources.Resources.engantxar
        Me.cmdEngantxarArticle.Location = New System.Drawing.Point(179, 1)
        Me.cmdEngantxarArticle.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdEngantxarArticle.Name = "cmdEngantxarArticle"
        Me.cmdEngantxarArticle.Size = New System.Drawing.Size(35, 34)
        Me.cmdEngantxarArticle.TabIndex = 38
        Me.cmdEngantxarArticle.UseVisualStyleBackColor = True
        '
        'cmdCopiarArticle
        '
        Me.cmdCopiarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCopiarArticle.Image = Global.OmsXM.My.Resources.Resources.copiar
        Me.cmdCopiarArticle.Location = New System.Drawing.Point(141, 1)
        Me.cmdCopiarArticle.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCopiarArticle.Name = "cmdCopiarArticle"
        Me.cmdCopiarArticle.Size = New System.Drawing.Size(35, 34)
        Me.cmdCopiarArticle.TabIndex = 37
        Me.cmdCopiarArticle.UseVisualStyleBackColor = True
        '
        'cmdTreureFila
        '
        Me.cmdTreureFila.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdTreureFila.Image = Global.OmsXM.My.Resources.Resources.treureFila
        Me.cmdTreureFila.Location = New System.Drawing.Point(273, 1)
        Me.cmdTreureFila.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdTreureFila.Name = "cmdTreureFila"
        Me.cmdTreureFila.Size = New System.Drawing.Size(35, 34)
        Me.cmdTreureFila.TabIndex = 36
        Me.cmdTreureFila.UseVisualStyleBackColor = True
        '
        'txtFiltrarArticle
        '
        Me.txtFiltrarArticle.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFiltrarArticle.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrarArticle.Location = New System.Drawing.Point(1264, 1)
        Me.txtFiltrarArticle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltrarArticle.Name = "txtFiltrarArticle"
        Me.txtFiltrarArticle.Size = New System.Drawing.Size(331, 26)
        Me.txtFiltrarArticle.TabIndex = 35
        '
        'lblCercador
        '
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.ForeColor = System.Drawing.Color.Red
        Me.lblCercador.Location = New System.Drawing.Point(1135, 2)
        Me.lblCercador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(121, 28)
        Me.lblCercador.TabIndex = 34
        Me.lblCercador.Text = "Cercador"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCercadorArticle
        '
        Me.cmdCercadorArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCercadorArticle.Image = Global.OmsXM.My.Resources.Resources.BotoCercar
        Me.cmdCercadorArticle.Location = New System.Drawing.Point(1604, 1)
        Me.cmdCercadorArticle.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCercadorArticle.Name = "cmdCercadorArticle"
        Me.cmdCercadorArticle.Size = New System.Drawing.Size(35, 34)
        Me.cmdCercadorArticle.TabIndex = 33
        Me.cmdCercadorArticle.UseVisualStyleBackColor = True
        '
        'cmdEliminarArticle
        '
        Me.cmdEliminarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminarArticle.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminarArticle.Location = New System.Drawing.Point(80, 1)
        Me.cmdEliminarArticle.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdEliminarArticle.Name = "cmdEliminarArticle"
        Me.cmdEliminarArticle.Size = New System.Drawing.Size(35, 34)
        Me.cmdEliminarArticle.TabIndex = 30
        Me.cmdEliminarArticle.UseVisualStyleBackColor = True
        '
        'cmdModificarArticle
        '
        Me.cmdModificarArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdModificarArticle.Image = Global.OmsXM.My.Resources.Resources.BotoModificar
        Me.cmdModificarArticle.Location = New System.Drawing.Point(37, 1)
        Me.cmdModificarArticle.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdModificarArticle.Name = "cmdModificarArticle"
        Me.cmdModificarArticle.Size = New System.Drawing.Size(35, 34)
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
        Me.DGVArticles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codi, Me.quantitat, Me.unitat, Me.descripcio, Me.import, Me.descompte, Me.base, Me.iva, Me.total})
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
        Me.DGVArticles.Location = New System.Drawing.Point(-1, 55)
        Me.DGVArticles.Margin = New System.Windows.Forms.Padding(4)
        Me.DGVArticles.Name = "DGVArticles"
        Me.DGVArticles.RowHeadersWidth = 51
        Me.DGVArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticles.Size = New System.Drawing.Size(1660, 476)
        Me.DGVArticles.TabIndex = 70
        '
        'codi
        '
        Me.codi.ContextMenuStrip = Me.mnuContextual
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codi.DefaultCellStyle = DataGridViewCellStyle2
        Me.codi.Frozen = True
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
        'cmdGuardar
        '
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGuardar.Image = Global.OmsXM.My.Resources.Resources.BotoGuardar
        Me.cmdGuardar.Location = New System.Drawing.Point(564, 5)
        Me.cmdGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(35, 34)
        Me.cmdGuardar.TabIndex = 28
        Me.cmdGuardar.Text = "                                                  "
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'cmdValidar
        '
        Me.cmdValidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdValidar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdValidar.Location = New System.Drawing.Point(1489, 1)
        Me.cmdValidar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdValidar.Name = "cmdValidar"
        Me.cmdValidar.Size = New System.Drawing.Size(188, 34)
        Me.cmdValidar.TabIndex = 29
        Me.cmdValidar.Text = " VALIDAR"
        Me.cmdValidar.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.Button3.Location = New System.Drawing.Point(607, 5)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(35, 34)
        Me.Button3.TabIndex = 31
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cbEstat
        '
        Me.cbEstat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbEstat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstat.ForeColor = System.Drawing.Color.Red
        Me.cbEstat.FormattingEnabled = True
        Me.cbEstat.Location = New System.Drawing.Point(805, 6)
        Me.cbEstat.Margin = New System.Windows.Forms.Padding(4)
        Me.cbEstat.Name = "cbEstat"
        Me.cbEstat.Size = New System.Drawing.Size(448, 24)
        Me.cbEstat.TabIndex = 37
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.lblTipusComanda)
        Me.Panel1.Controls.Add(Me.lblComptadorEstat)
        Me.Panel1.Controls.Add(Me.lblEstatComanda)
        Me.Panel1.Controls.Add(Me.cbEstat)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.cmdValidar)
        Me.Panel1.Controls.Add(Me.cmdGuardar)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1681, 39)
        Me.Panel1.TabIndex = 73
        '
        'lblTipusComanda
        '
        Me.lblTipusComanda.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipusComanda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipusComanda.Location = New System.Drawing.Point(9, 5)
        Me.lblTipusComanda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipusComanda.Name = "lblTipusComanda"
        Me.lblTipusComanda.Size = New System.Drawing.Size(518, 28)
        Me.lblTipusComanda.TabIndex = 75
        Me.lblTipusComanda.Text = "Cercador"
        Me.lblTipusComanda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblComptadorEstat
        '
        Me.lblComptadorEstat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComptadorEstat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComptadorEstat.ForeColor = System.Drawing.Color.Black
        Me.lblComptadorEstat.Location = New System.Drawing.Point(1262, 5)
        Me.lblComptadorEstat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblComptadorEstat.Name = "lblComptadorEstat"
        Me.lblComptadorEstat.Size = New System.Drawing.Size(219, 28)
        Me.lblComptadorEstat.TabIndex = 74
        Me.lblComptadorEstat.Text = "Cercador"
        Me.lblComptadorEstat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstatComanda
        '
        Me.lblEstatComanda.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatComanda.ForeColor = System.Drawing.Color.Red
        Me.lblEstatComanda.Location = New System.Drawing.Point(650, 5)
        Me.lblEstatComanda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstatComanda.Name = "lblEstatComanda"
        Me.lblEstatComanda.Size = New System.Drawing.Size(147, 28)
        Me.lblEstatComanda.TabIndex = 73
        Me.lblEstatComanda.Text = "Cercador"
        Me.lblEstatComanda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelArticle)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "pComanda"
        Me.Size = New System.Drawing.Size(1695, 740)
        Me.mnuContextual.ResumeLayout(False)
        Me.panelArticle.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DGVArticles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents mnuContextual As ContextMenuStrip
    Friend WithEvents mnuAfegir As ToolStripMenuItem
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents mnuCopiar As ToolStripMenuItem
    Friend WithEvents mnuEngatxar As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    'Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    'Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    'Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    'Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    'Friend WithEvents NumericGridColumn1 As gridExtension.NumericGridColumn
    'Friend WithEvents NumericGridColumn2 As gridExtension.NumericGridColumn
    Friend WithEvents panelArticle As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DGVArticles As dgvExtended
    Friend WithEvents cmdCercadorArticle As Button
    Friend WithEvents cmdEliminarArticle As Button
    Friend WithEvents cmdModificarArticle As Button
    Friend WithEvents txtFiltrarArticle As TXT
    Friend WithEvents lblCercador As LBLRED
    Friend WithEvents lblTotalIva As LBLRED
    Friend WithEvents lblTotal As LBLRED
    Friend WithEvents lblTotalBI As LBLRED
    Friend WithEvents cmdAfegirFila As Button
    Friend WithEvents cmdEngantxarArticle As Button
    Friend WithEvents cmdCopiarArticle As Button
    Friend WithEvents cmdTreureFila As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdValidar As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents cbEstat As ComboBox
    Friend WithEvents lblEstatComanda As LBLRED
    Friend WithEvents lblComptadorEstat As LBLRED
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTipusComanda As LBLRED
    Friend WithEvents codi As DataGridViewTextBoxColumn
    Friend WithEvents quantitat As DataGridViewTextBoxColumn
    Friend WithEvents unitat As DataGridViewComboBoxColumn
    Friend WithEvents descripcio As DataGridViewTextBoxColumn
    Friend WithEvents import As DataGridViewTextBoxColumn
    Friend WithEvents descompte As DataGridViewTextBoxColumn
    Friend WithEvents base As DataGridViewTextBoxColumn
    Friend WithEvents iva As DataGridViewComboBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
End Class
