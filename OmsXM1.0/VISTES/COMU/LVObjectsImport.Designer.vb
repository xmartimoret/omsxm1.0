<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LVObjectsImport
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
        Me.cmdSeleccionar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdAfegir = New System.Windows.Forms.Button()
        Me.mnuSortir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnoActualitzar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnoModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnoAfegir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.xecTots = New System.Windows.Forms.CheckBox()
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.mnuContextual.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSeleccionar
        '
        Me.cmdSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSeleccionar.Image = Global.OmsXM.My.Resources.Resources.Seleccionar
        Me.cmdSeleccionar.Location = New System.Drawing.Point(4, 6)
        Me.cmdSeleccionar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSeleccionar.Name = "cmdSeleccionar"
        Me.cmdSeleccionar.Size = New System.Drawing.Size(35, 34)
        Me.cmdSeleccionar.TabIndex = 39
        Me.cmdSeleccionar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimir.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.cmdImprimir.Location = New System.Drawing.Point(171, 5)
        Me.cmdImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(35, 34)
        Me.cmdImprimir.TabIndex = 37
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(127, 5)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(35, 34)
        Me.cmdEliminar.TabIndex = 36
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdAfegir
        '
        Me.cmdAfegir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegir.Image = Global.OmsXM.My.Resources.Resources.BotoNou
        Me.cmdAfegir.Location = New System.Drawing.Point(51, 5)
        Me.cmdAfegir.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(35, 34)
        Me.cmdAfegir.TabIndex = 34
        Me.cmdAfegir.UseVisualStyleBackColor = True
        '
        'mnuSortir
        '
        Me.mnuSortir.Name = "mnuSortir"
        Me.mnuSortir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuSortir.Size = New System.Drawing.Size(182, 22)
        Me.mnuSortir.Text = "SORTIR"
        '
        'mnuImprimir
        '
        Me.mnuImprimir.Name = "mnuImprimir"
        Me.mnuImprimir.Size = New System.Drawing.Size(182, 22)
        Me.mnuImprimir.Text = "IMPRIMIR"
        '
        'mnoActualitzar
        '
        Me.mnoActualitzar.Name = "mnoActualitzar"
        Me.mnoActualitzar.Size = New System.Drawing.Size(182, 22)
        Me.mnoActualitzar.Text = "ACTUALITZAR"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuEliminar.Size = New System.Drawing.Size(182, 22)
        Me.mnuEliminar.Text = "ELIMINAR"
        '
        'mnoModificar
        '
        Me.mnoModificar.Name = "mnoModificar"
        Me.mnoModificar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.mnoModificar.Size = New System.Drawing.Size(182, 22)
        Me.mnoModificar.Text = "MODIFICAR"
        '
        'mnoAfegir
        '
        Me.mnoAfegir.Name = "mnoAfegir"
        Me.mnoAfegir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mnoAfegir.Size = New System.Drawing.Size(182, 22)
        Me.mnoAfegir.Text = "AFEGIR"
        '
        'mnuContextual
        '
        Me.mnuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnoAfegir, Me.mnoModificar, Me.mnuEliminar, Me.mnoActualitzar, Me.mnuImprimir, Me.mnuSortir})
        Me.mnuContextual.Name = "mnuContextual"
        Me.mnuContextual.Size = New System.Drawing.Size(183, 136)
        '
        'xecTots
        '
        Me.xecTots.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecTots.AutoSize = True
        Me.xecTots.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.xecTots.Location = New System.Drawing.Point(4, 622)
        Me.xecTots.Margin = New System.Windows.Forms.Padding(4)
        Me.xecTots.Name = "xecTots"
        Me.xecTots.Size = New System.Drawing.Size(92, 20)
        Me.xecTots.TabIndex = 33
        Me.xecTots.Text = "SelectTots"
        Me.xecTots.UseVisualStyleBackColor = True
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(233, 5)
        Me.lblTitol.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(643, 30)
        Me.lblTitol.TabIndex = 32
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCount.Location = New System.Drawing.Point(202, 616)
        Me.lblCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(673, 26)
        Me.lblCount.TabIndex = 31
        Me.lblCount.Text = "-"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrar.Location = New System.Drawing.Point(123, 43)
        Me.txtFiltrar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(752, 22)
        Me.txtFiltrar.TabIndex = 28
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.ForeColor = System.Drawing.Color.Red
        Me.lblFiltrar.Location = New System.Drawing.Point(8, 48)
        Me.lblFiltrar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(98, 16)
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
        Me.lstData.Location = New System.Drawing.Point(4, 73)
        Me.lstData.Margin = New System.Windows.Forms.Padding(4)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(871, 539)
        Me.lstData.TabIndex = 29
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'LVObjectsImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSeleccionar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdAfegir)
        Me.Controls.Add(Me.xecTots)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.lblFiltrar)
        Me.Controls.Add(Me.lstData)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "LVObjectsImport"
        Me.Size = New System.Drawing.Size(880, 680)
        Me.mnuContextual.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSeleccionar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdAfegir As Button
    Friend WithEvents mnuSortir As ToolStripMenuItem
    Friend WithEvents mnuImprimir As ToolStripMenuItem
    Friend WithEvents mnoActualitzar As ToolStripMenuItem
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents mnoModificar As ToolStripMenuItem
    Friend WithEvents mnoAfegir As ToolStripMenuItem
    Friend WithEvents mnuContextual As ContextMenuStrip
    Friend WithEvents tTip1 As ToolTip
    Friend WithEvents xecTots As CheckBox
    Friend WithEvents lblTitol As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents lblFiltrar As Label
    Friend WithEvents lstData As ListView
End Class
