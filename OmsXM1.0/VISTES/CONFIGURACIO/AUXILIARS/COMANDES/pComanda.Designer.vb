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
        Me.txtFiltrar = New OmsXM.TXT()
        Me.lblCercador = New OmsXM.LBLRED()
        Me.cmdCercador = New System.Windows.Forms.Button()
        Me.cmdActualitzar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdAfegir = New System.Windows.Forms.Button()
        Me.DGVArticles = New System.Windows.Forms.DataGridView()
        Me.c1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.c8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdCrear = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdValidar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
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
        Me.Panel3.Controls.Add(Me.txtFiltrar)
        Me.Panel3.Controls.Add(Me.lblCercador)
        Me.Panel3.Controls.Add(Me.cmdCercador)
        Me.Panel3.Controls.Add(Me.cmdActualitzar)
        Me.Panel3.Controls.Add(Me.cmdImprimir)
        Me.Panel3.Controls.Add(Me.cmdEliminar)
        Me.Panel3.Controls.Add(Me.cmdModificar)
        Me.Panel3.Controls.Add(Me.cmdAfegir)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1210, 32)
        Me.Panel3.TabIndex = 72
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrar.Location = New System.Drawing.Point(331, 1)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(249, 26)
        Me.txtFiltrar.TabIndex = 35
        '
        'lblCercador
        '
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.ForeColor = System.Drawing.Color.Red
        Me.lblCercador.Location = New System.Drawing.Point(234, 2)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(91, 23)
        Me.lblCercador.TabIndex = 34
        Me.lblCercador.Text = "Cercador"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCercador
        '
        Me.cmdCercador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCercador.Image = Global.OmsXM.My.Resources.Resources.BotoCercar
        Me.cmdCercador.Location = New System.Drawing.Point(586, 1)
        Me.cmdCercador.Name = "cmdCercador"
        Me.cmdCercador.Size = New System.Drawing.Size(26, 28)
        Me.cmdCercador.TabIndex = 33
        Me.cmdCercador.UseVisualStyleBackColor = True
        '
        'cmdActualitzar
        '
        Me.cmdActualitzar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdActualitzar.Image = Global.OmsXM.My.Resources.Resources.actualitzar
        Me.cmdActualitzar.Location = New System.Drawing.Point(137, 1)
        Me.cmdActualitzar.Name = "cmdActualitzar"
        Me.cmdActualitzar.Size = New System.Drawing.Size(26, 28)
        Me.cmdActualitzar.TabIndex = 32
        Me.cmdActualitzar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimir.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.cmdImprimir.Location = New System.Drawing.Point(169, 1)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(26, 28)
        Me.cmdImprimir.TabIndex = 31
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(60, 1)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminar.TabIndex = 30
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdModificar.Image = Global.OmsXM.My.Resources.Resources.BotoModificar
        Me.cmdModificar.Location = New System.Drawing.Point(31, 1)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(26, 28)
        Me.cmdModificar.TabIndex = 29
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdAfegir
        '
        Me.cmdAfegir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegir.Image = Global.OmsXM.My.Resources.Resources.BotoNou
        Me.cmdAfegir.Location = New System.Drawing.Point(2, 1)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(26, 28)
        Me.cmdAfegir.TabIndex = 28
        Me.cmdAfegir.UseVisualStyleBackColor = True
        '
        'DGVArticles
        '
        Me.DGVArticles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVArticles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DGVArticles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
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
        Me.DGVArticles.Location = New System.Drawing.Point(3, 45)
        Me.DGVArticles.Name = "DGVArticles"
        Me.DGVArticles.Size = New System.Drawing.Size(1241, 419)
        Me.DGVArticles.TabIndex = 70
        '
        'c1
        '
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
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmdCrear)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.cmdValidar)
        Me.Panel1.Controls.Add(Me.cmdGuardar)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1261, 32)
        Me.Panel1.TabIndex = 73
        '
        'cmdCrear
        '
        Me.cmdCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCrear.Image = Global.OmsXM.My.Resources.Resources.afegir
        Me.cmdCrear.Location = New System.Drawing.Point(311, 3)
        Me.cmdCrear.Name = "cmdCrear"
        Me.cmdCrear.Size = New System.Drawing.Size(26, 28)
        Me.cmdCrear.TabIndex = 33
        Me.cmdCrear.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = Global.OmsXM.My.Resources.Resources.BotoNou
        Me.Button1.Location = New System.Drawing.Point(3, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 28)
        Me.Button1.TabIndex = 32
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.Button3.Location = New System.Drawing.Point(169, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(26, 28)
        Me.Button3.TabIndex = 31
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.Button4.Location = New System.Drawing.Point(119, 1)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(26, 28)
        Me.Button4.TabIndex = 30
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmdValidar
        '
        Me.cmdValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdValidar.Image = Global.OmsXM.My.Resources.Resources.validar
        Me.cmdValidar.Location = New System.Drawing.Point(279, 3)
        Me.cmdValidar.Name = "cmdValidar"
        Me.cmdValidar.Size = New System.Drawing.Size(26, 28)
        Me.cmdValidar.TabIndex = 29
        Me.cmdValidar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGuardar.Image = Global.OmsXM.My.Resources.Resources.BotoGuardar
        Me.cmdGuardar.Location = New System.Drawing.Point(247, 4)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(26, 28)
        Me.cmdGuardar.TabIndex = 28
        Me.cmdGuardar.Text = "                                                  "
        Me.cmdGuardar.UseVisualStyleBackColor = True
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
    Friend WithEvents DGVArticles As DataGridView
    Friend WithEvents c1 As DataGridViewTextBoxColumn
    Friend WithEvents c2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents c4 As DataGridViewTextBoxColumn
    Friend WithEvents c5 As DataGridViewTextBoxColumn
    Friend WithEvents c6 As DataGridViewTextBoxColumn
    Friend WithEvents c7 As DataGridViewComboBoxColumn
    Friend WithEvents c8 As DataGridViewTextBoxColumn
    Friend WithEvents cmdCercador As Button
    Friend WithEvents cmdActualitzar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdModificar As Button
    Friend WithEvents cmdAfegir As Button
    Friend WithEvents txtFiltrar As TXT
    Friend WithEvents lblCercador As LBLRED
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents cmdValidar As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cmdCrear As Button
End Class
