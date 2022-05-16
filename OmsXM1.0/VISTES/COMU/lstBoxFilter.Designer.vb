<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lstBoxFilter
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
        Me.lblTitol = New OmsXM.LBLRIGHT()
        Me.lstData = New OmsXM.LSTBOX()
        Me.txtFiltrar = New OmsXM.TXT()
        Me.SuspendLayout()
        '
        'lblTitol
        '
        Me.lblTitol.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(3, 1)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(117, 18)
        Me.lblTitol.TabIndex = 17
        Me.lblTitol.Text = "Lblright1"
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstData
        '
        Me.lstData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstData.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lstData.ForeColor = System.Drawing.Color.Blue
        Me.lstData.FormattingEnabled = True
        Me.lstData.HorizontalScrollbar = True
        Me.lstData.Location = New System.Drawing.Point(3, 22)
        Me.lstData.Name = "lstData"
        Me.lstData.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstData.Size = New System.Drawing.Size(305, 134)
        Me.lstData.TabIndex = 16
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrar.Location = New System.Drawing.Point(134, 1)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(174, 20)
        Me.txtFiltrar.TabIndex = 18
        '
        'lstBoxFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.lstData)
        Me.Name = "lstBoxFilter"
        Me.Size = New System.Drawing.Size(308, 160)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitol As LBLRIGHT
    Friend WithEvents lstData As LSTBOX
    Friend WithEvents txtFiltrar As TXT
End Class
