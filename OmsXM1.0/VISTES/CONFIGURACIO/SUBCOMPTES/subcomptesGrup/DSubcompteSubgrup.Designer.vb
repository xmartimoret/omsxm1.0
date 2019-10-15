<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DSubcompteSubgrup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.cmdGuardar = New BOTO()
        Me.lblSubcompte = New LBLRED()
        Me.xecCompres = New XEC()
        Me.xecVariables = New XEC()
        Me.cmdCancelar = New BOTO()
        Me.SuspendLayout()
        '
        'cmdGuardar
        '
        Me.cmdGuardar.AutoSize = True
        Me.cmdGuardar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(82, 119)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(58, 30)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'lblSubcompte
        '
        Me.lblSubcompte.AutoSize = True
        Me.lblSubcompte.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubcompte.ForeColor = System.Drawing.Color.Red
        Me.lblSubcompte.Location = New System.Drawing.Point(12, 9)
        Me.lblSubcompte.Name = "lblSubcompte"
        Me.lblSubcompte.Size = New System.Drawing.Size(54, 18)
        Me.lblSubcompte.TabIndex = 1
        Me.lblSubcompte.Text = "Lblred1"
        Me.lblSubcompte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecCompres
        '
        Me.xecCompres.AutoSize = True
        Me.xecCompres.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecCompres.ForeColor = System.Drawing.Color.Black
        Me.xecCompres.Location = New System.Drawing.Point(72, 45)
        Me.xecCompres.Name = "xecCompres"
        Me.xecCompres.Size = New System.Drawing.Size(59, 22)
        Me.xecCompres.TabIndex = 2
        Me.xecCompres.Text = "Xec1"
        Me.xecCompres.UseVisualStyleBackColor = True
        '
        'xecVariables
        '
        Me.xecVariables.AutoSize = True
        Me.xecVariables.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecVariables.ForeColor = System.Drawing.Color.Black
        Me.xecVariables.Location = New System.Drawing.Point(72, 73)
        Me.xecVariables.Name = "xecVariables"
        Me.xecVariables.Size = New System.Drawing.Size(59, 22)
        Me.xecVariables.TabIndex = 3
        Me.xecVariables.Text = "Xec2"
        Me.xecVariables.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(300, 119)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(58, 30)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'DSubcompteSubgrup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 166)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.xecVariables)
        Me.Controls.Add(Me.xecCompres)
        Me.Controls.Add(Me.lblSubcompte)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DSubcompteSubgrup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DSubcompteSubgrup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents lblSubcompte As LBLRED
    Friend WithEvents xecCompres As XEC
    Friend WithEvents xecVariables As XEC
    Friend WithEvents cmdCancelar As BOTO
End Class
