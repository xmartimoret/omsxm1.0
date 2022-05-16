<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pArticlesComandes
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
        Me.panelComandes = New System.Windows.Forms.Panel()
        Me.splitCercador = New System.Windows.Forms.SplitContainer()
        Me.lblBase = New OmsXM.LBLRIGHT()
        Me.lblIva = New OmsXM.LBLRIGHT()
        Me.lblTotal = New OmsXM.LBLRIGHT()
        CType(Me.splitCercador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitCercador.Panel2.SuspendLayout()
        Me.splitCercador.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelComandes
        '
        Me.panelComandes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelComandes.Cursor = System.Windows.Forms.Cursors.Default
        Me.panelComandes.Location = New System.Drawing.Point(3, 3)
        Me.panelComandes.Name = "panelComandes"
        Me.panelComandes.Size = New System.Drawing.Size(1449, 478)
        Me.panelComandes.TabIndex = 0
        '
        'splitCercador
        '
        Me.splitCercador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitCercador.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.splitCercador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCercador.Location = New System.Drawing.Point(0, 0)
        Me.splitCercador.Name = "splitCercador"
        Me.splitCercador.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitCercador.Panel1
        '
        Me.splitCercador.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'splitCercador.Panel2
        '
        Me.splitCercador.Panel2.Controls.Add(Me.lblBase)
        Me.splitCercador.Panel2.Controls.Add(Me.lblIva)
        Me.splitCercador.Panel2.Controls.Add(Me.lblTotal)
        Me.splitCercador.Panel2.Controls.Add(Me.panelComandes)
        Me.splitCercador.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.splitCercador.Size = New System.Drawing.Size(1457, 688)
        Me.splitCercador.SplitterDistance = 147
        Me.splitCercador.TabIndex = 1
        '
        'lblBase
        '
        Me.lblBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBase.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBase.ForeColor = System.Drawing.Color.Black
        Me.lblBase.Location = New System.Drawing.Point(843, 484)
        Me.lblBase.Name = "lblBase"
        Me.lblBase.Size = New System.Drawing.Size(182, 23)
        Me.lblBase.TabIndex = 3
        Me.lblBase.Text = "0,00 €"
        Me.lblBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIva
        '
        Me.lblIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIva.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva.ForeColor = System.Drawing.Color.Black
        Me.lblIva.Location = New System.Drawing.Point(1031, 484)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(182, 23)
        Me.lblIva.TabIndex = 2
        Me.lblIva.Text = "0,00 € "
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(1219, 484)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(182, 23)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "0,00 €"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pArticlesComandes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitCercador)
        Me.Name = "pArticlesComandes"
        Me.Size = New System.Drawing.Size(1457, 688)
        Me.splitCercador.Panel2.ResumeLayout(False)
        CType(Me.splitCercador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitCercador.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelComandes As Panel
    Friend WithEvents splitCercador As SplitContainer
    Friend WithEvents lblBase As LBLRIGHT
    Friend WithEvents lblIva As LBLRIGHT
    Friend WithEvents lblTotal As LBLRIGHT
End Class
