<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lstContactesProveidor
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
        Me.cb = New OmsXM.CBBOX()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdModificar = New OmsXM.BOTO()
        Me.cmdAfegir = New OmsXM.BOTO()
        Me.SuspendLayout()
        '
        'cb
        '
        Me.cb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cb.ForeColor = System.Drawing.Color.Blue
        Me.cb.Location = New System.Drawing.Point(0, 0)
        Me.cb.Name = "cb"
        Me.cb.Size = New System.Drawing.Size(269, 26)
        Me.cb.TabIndex = 4
        '
        'cmdModificar
        '
        Me.cmdModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdModificar.AutoSize = True
        Me.cmdModificar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdModificar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdModificar.Image = Global.OmsXM.My.Resources.Resources.BotoModificarPetit
        Me.cmdModificar.Location = New System.Drawing.Point(293, 0)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(23, 26)
        Me.cmdModificar.TabIndex = 6
        Me.cmdModificar.TabStop = False
        Me.cmdModificar.UseVisualStyleBackColor = False
        '
        'cmdAfegir
        '
        Me.cmdAfegir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAfegir.AutoSize = True
        Me.cmdAfegir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdAfegir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAfegir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdAfegir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAfegir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAfegir.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdAfegir.Image = Global.OmsXM.My.Resources.Resources.BotoNouPetit
        Me.cmdAfegir.Location = New System.Drawing.Point(269, 0)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(23, 26)
        Me.cmdAfegir.TabIndex = 7
        Me.cmdAfegir.TabStop = False
        Me.cmdAfegir.UseVisualStyleBackColor = False
        '
        'lstContactesProveidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdAfegir)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cb)
        Me.Name = "lstContactesProveidor"
        Me.Size = New System.Drawing.Size(316, 26)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cb As CBBOX
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmdModificar As BOTO
    Friend WithEvents cmdAfegir As BOTO
End Class
