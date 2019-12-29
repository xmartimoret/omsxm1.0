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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdCercadorArticle = New System.Windows.Forms.Button()
        Me.cmdEliminarArticle = New System.Windows.Forms.Button()
        Me.cmdModificarArticle = New System.Windows.Forms.Button()
        Me.cmdAfegirArticle = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbEstat = New System.Windows.Forms.ComboBox()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdNovaComanda = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmdEliminarComanda = New System.Windows.Forms.Button()
        Me.cmdValidar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.lblComptadorEstat = New OmsXM.LBLRED()
        Me.lblEstatComanda = New OmsXM.LBLRED()
        Me.txtFiltrarArticle = New OmsXM.TXT()
        Me.lblCercador = New OmsXM.LBLRED()
        Me.DGVArticles = New OmsXM.dgvExtended()
        Me.c1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.c8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuContextual.SuspendLayout()
        Me.panelArticle.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(405, 36)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(431, 87)
        Me.Panel6.TabIndex = 66
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Location = New System.Drawing.Point(3, 36)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(396, 87)
        Me.Panel7.TabIndex = 67
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(842, 35)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(422, 88)
        Me.Panel8.TabIndex = 68
        '
        'mnuContextual
        '
        Me.mnuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAfegir, Me.mnuEliminar, Me.ToolStripSeparator1, Me.mnuCopiar, Me.mnuEngatxar})
        Me.mnuContextual.Name = "mnuContextual"
        Me.mnuContextual.Size = New System.Drawing.Size(169, 98)
        '
        'mnuAfegir
        '
        Me.mnuAfegir.Name = "mnuAfegir"
        Me.mnuAfegir.Size = New System.Drawing.Size(168, 22)
        Me.mnuAfegir.Text = "Afegir"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuEliminar.Size = New System.Drawing.Size(168, 22)
        Me.mnuEliminar.Text = "eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'mnuCopiar
        '
        Me.mnuCopiar.Name = "mnuCopiar"
        Me.mnuCopiar.ShortcutKeyDisplayString = ""
        Me.mnuCopiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuCopiar.Size = New System.Drawing.Size(168, 22)
        Me.mnuCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuEngatxar
        '
        Me.mnuEngatxar.Name = "mnuEngatxar"
        Me.mnuEngatxar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnuEngatxar.Size = New System.Drawing.Size(168, 22)
        Me.mnuEngatxar.Text = "Engantxar"
        '
        'panelArticle
        '
        Me.panelArticle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelArticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelArticle.Controls.Add(Me.Panel3)
        Me.panelArticle.Controls.Add(Me.DGVArticles)
        Me.panelArticle.Location = New System.Drawing.Point(6, 129)
        Me.panelArticle.Name = "panelArticle"
        Me.panelArticle.Size = New System.Drawing.Size(1258, 469)
        Me.panelArticle.TabIndex = 72
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.txtFiltrarArticle)
        Me.Panel3.Controls.Add(Me.lblCercador)
        Me.Panel3.Controls.Add(Me.cmdCercadorArticle)
        Me.Panel3.Controls.Add(Me.cmdEliminarArticle)
        Me.Panel3.Controls.Add(Me.cmdModificarArticle)
        Me.Panel3.Controls.Add(Me.cmdAfegirArticle)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1241, 32)
        Me.Panel3.TabIndex = 72
        '
        'cmdCercadorArticle
        '
        Me.cmdCercadorArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCercadorArticle.Image = Global.OmsXM.My.Resources.Resources.BotoCercar
        Me.cmdCercadorArticle.Location = New System.Drawing.Point(450, 1)
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
        Me.cmdModificarArticle.Location = New System.Drawing.Point(31, 1)
        Me.cmdModificarArticle.Name = "cmdModificarArticle"
        Me.cmdModificarArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdModificarArticle.TabIndex = 29
        Me.cmdModificarArticle.UseVisualStyleBackColor = True
        '
        'cmdAfegirArticle
        '
        Me.cmdAfegirArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegirArticle.Image = Global.OmsXM.My.Resources.Resources.BotoNou
        Me.cmdAfegirArticle.Location = New System.Drawing.Point(2, 1)
        Me.cmdAfegirArticle.Name = "cmdAfegirArticle"
        Me.cmdAfegirArticle.Size = New System.Drawing.Size(26, 28)
        Me.cmdAfegirArticle.TabIndex = 28
        Me.cmdAfegirArticle.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.lblComptadorEstat)
        Me.Panel1.Controls.Add(Me.lblEstatComanda)
        Me.Panel1.Controls.Add(Me.cbEstat)
        Me.Panel1.Controls.Add(Me.cmdModificar)
        Me.Panel1.Controls.Add(Me.cmdNovaComanda)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.cmdEliminarComanda)
        Me.Panel1.Controls.Add(Me.cmdValidar)
        Me.Panel1.Controls.Add(Me.cmdGuardar)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1261, 32)
        Me.Panel1.TabIndex = 73
        '
        'cbEstat
        '
        Me.cbEstat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbEstat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstat.ForeColor = System.Drawing.Color.Red
        Me.cbEstat.FormattingEnabled = True
        Me.cbEstat.Location = New System.Drawing.Point(495, 4)
        Me.cbEstat.Name = "cbEstat"
        Me.cbEstat.Size = New System.Drawing.Size(609, 24)
        Me.cbEstat.TabIndex = 37
        '
        'cmdModificar
        '
        Me.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdModificar.Image = Global.OmsXM.My.Resources.Resources.BotoModificar
        Me.cmdModificar.Location = New System.Drawing.Point(31, 1)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(27, 28)
        Me.cmdModificar.TabIndex = 36
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdNovaComanda
        '
        Me.cmdNovaComanda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdNovaComanda.Image = Global.OmsXM.My.Resources.Resources.BotoNou
        Me.cmdNovaComanda.Location = New System.Drawing.Point(3, 1)
        Me.cmdNovaComanda.Name = "cmdNovaComanda"
        Me.cmdNovaComanda.Size = New System.Drawing.Size(26, 28)
        Me.cmdNovaComanda.TabIndex = 32
        Me.cmdNovaComanda.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.Button3.Location = New System.Drawing.Point(140, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(26, 28)
        Me.Button3.TabIndex = 31
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmdEliminarComanda
        '
        Me.cmdEliminarComanda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminarComanda.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminarComanda.Location = New System.Drawing.Point(62, 1)
        Me.cmdEliminarComanda.Name = "cmdEliminarComanda"
        Me.cmdEliminarComanda.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminarComanda.TabIndex = 30
        Me.cmdEliminarComanda.UseVisualStyleBackColor = True
        '
        'cmdValidar
        '
        Me.cmdValidar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdValidar.Location = New System.Drawing.Point(202, 1)
        Me.cmdValidar.Name = "cmdValidar"
        Me.cmdValidar.Size = New System.Drawing.Size(141, 28)
        Me.cmdValidar.TabIndex = 29
        Me.cmdValidar.Text = "CREAR COMANDA"
        Me.cmdValidar.UseVisualStyleBackColor = False
        '
        'cmdGuardar
        '
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGuardar.Image = Global.OmsXM.My.Resources.Resources.BotoGuardar
        Me.cmdGuardar.Location = New System.Drawing.Point(94, 3)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(26, 28)
        Me.cmdGuardar.TabIndex = 28
        Me.cmdGuardar.Text = "                                                  "
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'lblComptadorEstat
        '
        Me.lblComptadorEstat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComptadorEstat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComptadorEstat.ForeColor = System.Drawing.Color.Black
        Me.lblComptadorEstat.Location = New System.Drawing.Point(1110, 3)
        Me.lblComptadorEstat.Name = "lblComptadorEstat"
        Me.lblComptadorEstat.Size = New System.Drawing.Size(148, 23)
        Me.lblComptadorEstat.TabIndex = 74
        Me.lblComptadorEstat.Text = "Cercador"
        Me.lblComptadorEstat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstatComanda
        '
        Me.lblEstatComanda.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatComanda.ForeColor = System.Drawing.Color.Red
        Me.lblEstatComanda.Location = New System.Drawing.Point(349, 3)
        Me.lblEstatComanda.Name = "lblEstatComanda"
        Me.lblEstatComanda.Size = New System.Drawing.Size(140, 23)
        Me.lblEstatComanda.TabIndex = 73
        Me.lblEstatComanda.Text = "Cercador"
        Me.lblEstatComanda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFiltrarArticle
        '
        Me.txtFiltrarArticle.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFiltrarArticle.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrarArticle.Location = New System.Drawing.Point(195, 2)
        Me.txtFiltrarArticle.Name = "txtFiltrarArticle"
        Me.txtFiltrarArticle.Size = New System.Drawing.Size(249, 26)
        Me.txtFiltrarArticle.TabIndex = 35
        '
        'lblCercador
        '
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.ForeColor = System.Drawing.Color.Red
        Me.lblCercador.Location = New System.Drawing.Point(98, 4)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(91, 23)
        Me.lblCercador.TabIndex = 34
        Me.lblCercador.Text = "Cercador"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGVArticles
        '
        Me.DGVArticles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVArticles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVArticles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVArticles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c1, Me.c2, Me.Column3, Me.c4, Me.c5, Me.c6, Me.c7, Me.c8})
        Me.DGVArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGVArticles.Location = New System.Drawing.Point(5, 45)
        Me.DGVArticles.Name = "DGVArticles"
        Me.DGVArticles.Size = New System.Drawing.Size(1239, 419)
        Me.DGVArticles.TabIndex = 70
        '
        'c1
        '
        Me.c1.ContextMenuStrip = Me.mnuContextual
        Me.c1.Frozen = True
        Me.c1.HeaderText = "Referència"
        Me.c1.MinimumWidth = 30
        Me.c1.Name = "c1"
        Me.c1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.c1.Width = 150
        '
        'c2
        '
        Me.c2.HeaderText = "QUAT"
        Me.c2.MaxInputLength = 10
        Me.c2.Name = "c2"
        Me.c2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column3
        '
        DataGridViewCellStyle2.Format = "##,##0.00"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "UNIT."
        Me.Column3.MaxInputLength = 5
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 40
        '
        'c4
        '
        Me.c4.HeaderText = "DESCRIPCIO"
        Me.c4.MaxInputLength = 50
        Me.c4.Name = "c4"
        Me.c4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.c4.Width = 300
        '
        'c5
        '
        Me.c5.HeaderText = "import"
        Me.c5.MaxInputLength = 10
        Me.c5.Name = "c5"
        Me.c5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'c6
        '
        Me.c6.HeaderText = "DTO."
        Me.c6.MaxInputLength = 10
        Me.c6.Name = "c6"
        '
        'c7
        '
        Me.c7.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.c7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.c7.HeaderText = "IVA"
        Me.c7.Name = "c7"
        '
        'c8
        '
        Me.c8.HeaderText = "TOTAL"
        Me.c8.Name = "c8"
        Me.c8.ReadOnly = True
        '
        'pComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelArticle)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Name = "pComanda"
        Me.Size = New System.Drawing.Size(1271, 601)
        Me.mnuContextual.ResumeLayout(False)
        Me.panelArticle.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DGVArticles, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdAfegirArticle As Button
    Friend WithEvents txtFiltrarArticle As TXT
    Friend WithEvents lblCercador As LBLRED
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents cmdEliminarComanda As Button
    Friend WithEvents cmdValidar As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdNovaComanda As Button
    Friend WithEvents c1 As DataGridViewTextBoxColumn
    Friend WithEvents c2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents c4 As DataGridViewTextBoxColumn
    Friend WithEvents c5 As DataGridViewTextBoxColumn
    Friend WithEvents c6 As DataGridViewTextBoxColumn
    Friend WithEvents c7 As DataGridViewComboBoxColumn
    Friend WithEvents c8 As DataGridViewTextBoxColumn
    Friend WithEvents cmdModificar As Button
    Friend WithEvents lblComptadorEstat As LBLRED
    Friend WithEvents lblEstatComanda As LBLRED
    Friend WithEvents cbEstat As ComboBox
End Class
