<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LVObjectsParent
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
        Me.xecTots = New System.Windows.Forms.CheckBox()
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.cmdCancelar = New BOTO()
        Me.cmdEliminar = New BOTO()
        Me.cmdModificar = New BOTO()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.cmdAfegir = New BOTO()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'xecTots
        '
        Me.xecTots.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecTots.AutoSize = True
        Me.xecTots.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.xecTots.Location = New System.Drawing.Point(27, 326)
        Me.xecTots.Name = "xecTots"
        Me.xecTots.Size = New System.Drawing.Size(92, 20)
        Me.xecTots.TabIndex = 31
        Me.xecTots.Text = "SelectTots"
        Me.xecTots.UseVisualStyleBackColor = True
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(10, 8)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(617, 24)
        Me.lblTitol.TabIndex = 30
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(520, 349)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(107, 30)
        Me.cmdCancelar.TabIndex = 29
        Me.cmdCancelar.Text = "cmdCancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.AutoSize = True
        Me.cmdEliminar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEliminar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminar.Location = New System.Drawing.Point(240, 349)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(107, 30)
        Me.cmdEliminar.TabIndex = 28
        Me.cmdEliminar.Text = "cmdEliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdModificar.AutoSize = True
        Me.cmdModificar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdModificar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdModificar.Location = New System.Drawing.Point(127, 349)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(107, 30)
        Me.cmdModificar.TabIndex = 27
        Me.cmdModificar.Text = "cmdModificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCount.Location = New System.Drawing.Point(221, 322)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(394, 21)
        Me.lblCount.TabIndex = 26
        Me.lblCount.Text = "lblCount"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAfegir
        '
        Me.cmdAfegir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAfegir.AutoSize = True
        Me.cmdAfegir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdAfegir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAfegir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAfegir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAfegir.Location = New System.Drawing.Point(14, 349)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(107, 30)
        Me.cmdAfegir.TabIndex = 24
        Me.cmdAfegir.Text = "cmdAfegir"
        Me.cmdAfegir.UseVisualStyleBackColor = True
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrar.Location = New System.Drawing.Point(96, 35)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(531, 22)
        Me.txtFiltrar.TabIndex = 22
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.ForeColor = System.Drawing.Color.Red
        Me.lblFiltrar.Location = New System.Drawing.Point(10, 40)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(80, 13)
        Me.lblFiltrar.TabIndex = 25
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
        Me.lstData.CheckBoxes = True
        Me.lstData.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lstData.ForeColor = System.Drawing.Color.Blue
        Me.lstData.FullRowSelect = True
        Me.lstData.GridLines = True
        Me.lstData.HideSelection = False
        Me.lstData.Location = New System.Drawing.Point(14, 63)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(613, 256)
        Me.lstData.TabIndex = 23
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'LVObjectsParent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.xecTots)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.cmdAfegir)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.lblFiltrar)
        Me.Controls.Add(Me.lstData)
        Me.Name = "LVObjectsParent"
        Me.Size = New System.Drawing.Size(638, 382)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents xecTots As CheckBox
    Friend WithEvents lblTitol As Label
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdEliminar As BOTO
    Friend WithEvents cmdModificar As BOTO
    Friend WithEvents lblCount As Label
    Friend WithEvents cmdAfegir As BOTO
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents lblFiltrar As Label
    Friend WithEvents lstData As ListView
End Class
