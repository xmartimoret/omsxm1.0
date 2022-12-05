<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LVObjectsCopiar
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdCopiar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.mnuImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnoCopiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.cmdMostrar = New System.Windows.Forms.Button()
        Me.cmdImprimirExcel = New System.Windows.Forms.Button()
        Me.cmdImprimirPDF = New System.Windows.Forms.Button()
        Me.mnuContextual.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCopiar
        '
        Me.cmdCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCopiar.Image = Global.OmsXM.My.Resources.Resources.copiar
        Me.cmdCopiar.Location = New System.Drawing.Point(67, 4)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(26, 28)
        Me.cmdCopiar.TabIndex = 39
        Me.cmdCopiar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCancelar.Image = Global.OmsXM.My.Resources.Resources.BotoSortir
        Me.cmdCancelar.Location = New System.Drawing.Point(867, 5)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(26, 28)
        Me.cmdCancelar.TabIndex = 38
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(95, 4)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminar.TabIndex = 36
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'mnuImprimir
        '
        Me.mnuImprimir.Name = "mnuImprimir"
        Me.mnuImprimir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mnuImprimir.Size = New System.Drawing.Size(194, 22)
        Me.mnuImprimir.Text = "IMPRIMIR"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuEliminar.Size = New System.Drawing.Size(194, 22)
        Me.mnuEliminar.Text = "ELIMINAR"
        '
        'mnoCopiar
        '
        Me.mnoCopiar.Name = "mnoCopiar"
        Me.mnoCopiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnoCopiar.Size = New System.Drawing.Size(194, 22)
        Me.mnoCopiar.Text = "COPIAR"
        '
        'mnuContextual
        '
        Me.mnuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMostrar, Me.mnoCopiar, Me.mnuEliminar, Me.mnuImprimir})
        Me.mnuContextual.Name = "mnuContextual"
        Me.mnuContextual.Size = New System.Drawing.Size(195, 114)
        '
        'mnuMostrar
        '
        Me.mnuMostrar.Name = "mnuMostrar"
        Me.mnuMostrar.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.mnuMostrar.Size = New System.Drawing.Size(194, 22)
        Me.mnuMostrar.Text = "VEURECOMANDA"
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(191, 4)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(647, 24)
        Me.lblTitol.TabIndex = 32
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCount.Location = New System.Drawing.Point(128, 540)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(765, 21)
        Me.lblCount.TabIndex = 31
        Me.lblCount.Text = "lblCount"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtFiltrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrar.Location = New System.Drawing.Point(92, 35)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(801, 22)
        Me.txtFiltrar.TabIndex = 28
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.ForeColor = System.Drawing.Color.Red
        Me.lblFiltrar.Location = New System.Drawing.Point(6, 39)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(80, 13)
        Me.lblFiltrar.TabIndex = 30
        Me.lblFiltrar.Text = "FILTRAR PER:"
        '
        'lstData
        '
        Me.lstData.AllowColumnReorder = True
        Me.lstData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstData.BackColor = System.Drawing.SystemColors.HighlightText
        Me.lstData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstData.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lstData.ForeColor = System.Drawing.Color.Blue
        Me.lstData.FullRowSelect = True
        Me.lstData.GridLines = True
        Me.lstData.HideSelection = False
        Me.lstData.Location = New System.Drawing.Point(3, 59)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(890, 478)
        Me.lstData.TabIndex = 29
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'cmdMostrar
        '
        Me.cmdMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdMostrar.Image = Global.OmsXM.My.Resources.Resources.Seleccionar
        Me.cmdMostrar.Location = New System.Drawing.Point(9, 5)
        Me.cmdMostrar.Name = "cmdMostrar"
        Me.cmdMostrar.Size = New System.Drawing.Size(26, 28)
        Me.cmdMostrar.TabIndex = 40
        Me.cmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdImprimirExcel
        '
        Me.cmdImprimirExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimirExcel.Image = Global.OmsXM.My.Resources.Resources.excel
        Me.cmdImprimirExcel.Location = New System.Drawing.Point(127, 5)
        Me.cmdImprimirExcel.Name = "cmdImprimirExcel"
        Me.cmdImprimirExcel.Size = New System.Drawing.Size(26, 28)
        Me.cmdImprimirExcel.TabIndex = 42
        Me.cmdImprimirExcel.UseVisualStyleBackColor = True
        '
        'cmdImprimirPDF
        '
        Me.cmdImprimirPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimirPDF.Image = Global.OmsXM.My.Resources.Resources.pdf
        Me.cmdImprimirPDF.Location = New System.Drawing.Point(153, 5)
        Me.cmdImprimirPDF.Name = "cmdImprimirPDF"
        Me.cmdImprimirPDF.Size = New System.Drawing.Size(32, 28)
        Me.cmdImprimirPDF.TabIndex = 41
        Me.cmdImprimirPDF.UseVisualStyleBackColor = True
        '
        'LVObjectsCopiar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdImprimirExcel)
        Me.Controls.Add(Me.cmdImprimirPDF)
        Me.Controls.Add(Me.cmdMostrar)
        Me.Controls.Add(Me.cmdCopiar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.lblFiltrar)
        Me.Controls.Add(Me.lstData)
        Me.Name = "LVObjectsCopiar"
        Me.Size = New System.Drawing.Size(908, 571)
        Me.mnuContextual.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCopiar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents mnuImprimir As ToolStripMenuItem
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents mnoCopiar As ToolStripMenuItem
    Friend WithEvents mnuContextual As ContextMenuStrip
    Friend WithEvents tTip1 As ToolTip
    Friend WithEvents lblTitol As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents lblFiltrar As Label
    Friend WithEvents lstData As ListView
    Friend WithEvents cmdMostrar As Button
    Friend WithEvents mnuMostrar As ToolStripMenuItem
    Friend WithEvents cmdImprimirExcel As Button
    Friend WithEvents cmdImprimirPDF As Button
End Class
