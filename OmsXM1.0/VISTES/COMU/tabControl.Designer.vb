<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tabControl
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
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTitol.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.Location = New System.Drawing.Point(3, 3)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(125, 22)
        Me.lblTitol.TabIndex = 4
        Me.lblTitol.Text = "PROVEIDORS"
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(128, 3)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(32, 22)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "X"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Name = "tabControl"
        Me.Size = New System.Drawing.Size(163, 28)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitol As Label
    Friend WithEvents cmdCancelar As Button
End Class
