<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LVObjects
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.xecTots = New System.Windows.Forms.CheckBox()
        Me.tTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnoAfegir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnoModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnoActualitzar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSortir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdSeleccionar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdAfegir = New System.Windows.Forms.Button()
        Me.mnuContextual.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCount.Location = New System.Drawing.Point(187, 434)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(394, 21)
        Me.lblCount.TabIndex = 16
        Me.lblCount.Text = "lblCount"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrar.Location = New System.Drawing.Point(89, 32)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(499, 22)
        Me.txtFiltrar.TabIndex = 12
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.ForeColor = System.Drawing.Color.Red
        Me.lblFiltrar.Location = New System.Drawing.Point(3, 36)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(80, 13)
        Me.lblFiltrar.TabIndex = 15
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
        Me.lstData.Location = New System.Drawing.Point(0, 56)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(588, 373)
        Me.lstData.TabIndex = 13
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(172, 1)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(384, 24)
        Me.lblTitol.TabIndex = 20
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'xecTots
        '
        Me.xecTots.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecTots.AutoSize = True
        Me.xecTots.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.xecTots.Location = New System.Drawing.Point(7, 435)
        Me.xecTots.Name = "xecTots"
        Me.xecTots.Size = New System.Drawing.Size(92, 20)
        Me.xecTots.TabIndex = 21
        Me.xecTots.Text = "SelectTots"
        Me.xecTots.UseVisualStyleBackColor = True
        '
        'mnuContextual
        '
        Me.mnuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnoAfegir, Me.mnoModificar, Me.mnuEliminar, Me.mnoActualitzar, Me.mnuImprimir, Me.mnuSortir})
        Me.mnuContextual.Name = "mnuContextual"
        Me.mnuContextual.Size = New System.Drawing.Size(183, 136)
        '
        'mnoAfegir
        '
        Me.mnoAfegir.Name = "mnoAfegir"
        Me.mnoAfegir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mnoAfegir.Size = New System.Drawing.Size(182, 22)
        Me.mnoAfegir.Text = "AFEGIR"
        '
        'mnoModificar
        '
        Me.mnoModificar.Name = "mnoModificar"
        Me.mnoModificar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.mnoModificar.Size = New System.Drawing.Size(182, 22)
        Me.mnoModificar.Text = "MODIFICAR"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuEliminar.Size = New System.Drawing.Size(182, 22)
        Me.mnuEliminar.Text = "ELIMINAR"
        '
        'mnoActualitzar
        '
        Me.mnoActualitzar.Name = "mnoActualitzar"
        Me.mnoActualitzar.Size = New System.Drawing.Size(182, 22)
        Me.mnoActualitzar.Text = "ACTUALITZAR"
        '
        'mnuImprimir
        '
        Me.mnuImprimir.Name = "mnuImprimir"
        Me.mnuImprimir.Size = New System.Drawing.Size(182, 22)
        Me.mnuImprimir.Text = "IMPRIMIR"
        '
        'mnuSortir
        '
        Me.mnuSortir.Name = "mnuSortir"
        Me.mnuSortir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuSortir.Size = New System.Drawing.Size(182, 22)
        Me.mnuSortir.Text = "SORTIR"
        '
        'cmdSeleccionar
        '
        Me.cmdSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSeleccionar.Image = Global.OmsXM.My.Resources.Resources.Seleccionar
        Me.cmdSeleccionar.Location = New System.Drawing.Point(0, 2)
        Me.cmdSeleccionar.Name = "cmdSeleccionar"
        Me.cmdSeleccionar.Size = New System.Drawing.Size(26, 28)
        Me.cmdSeleccionar.TabIndex = 27
        Me.cmdSeleccionar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCancelar.Image = Global.OmsXM.My.Resources.Resources.BotoSortir
        Me.cmdCancelar.Location = New System.Drawing.Point(562, 3)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(26, 28)
        Me.cmdCancelar.TabIndex = 26
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimir.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.cmdImprimir.Location = New System.Drawing.Point(125, 1)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(26, 28)
        Me.cmdImprimir.TabIndex = 25
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(92, 1)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminar.TabIndex = 24
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdModificar.Image = Global.OmsXM.My.Resources.Resources.BotoModificar
        Me.cmdModificar.Location = New System.Drawing.Point(63, 1)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(26, 28)
        Me.cmdModificar.TabIndex = 23
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdAfegir
        '
        Me.cmdAfegir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegir.Image = Global.OmsXM.My.Resources.Resources.BotoNou
        Me.cmdAfegir.Location = New System.Drawing.Point(35, 1)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(26, 28)
        Me.cmdAfegir.TabIndex = 22
        Me.cmdAfegir.UseVisualStyleBackColor = True
        '
        'LVObjects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSeleccionar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cmdAfegir)
        Me.Controls.Add(Me.xecTots)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.lblFiltrar)
        Me.Controls.Add(Me.lstData)
        Me.Name = "LVObjects"
        Me.Size = New System.Drawing.Size(596, 458)
        Me.mnuContextual.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCount As Label
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents lblFiltrar As Label
    Friend WithEvents lstData As ListView
    Friend WithEvents lblTitol As Label
    Friend WithEvents xecTots As CheckBox
    Friend WithEvents cmdAfegir As Button
    Friend WithEvents cmdModificar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents tTip1 As ToolTip
    Friend WithEvents mnuContextual As ContextMenuStrip
    Friend WithEvents mnoAfegir As ToolStripMenuItem
    Friend WithEvents mnoModificar As ToolStripMenuItem
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents mnoActualitzar As ToolStripMenuItem
    Friend WithEvents mnuImprimir As ToolStripMenuItem
    Friend WithEvents mnuSortir As ToolStripMenuItem
    Friend WithEvents cmdSeleccionar As Button
End Class
