<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DInici
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
        Me.cmdComptabilitat = New OmsXM.BOTO()
        Me.cmdFacturacio = New OmsXM.BOTO()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdCompres = New OmsXM.BOTO()
        Me.SuspendLayout()
        '
        'cmdComptabilitat
        '
        Me.cmdComptabilitat.AutoSize = True
        Me.cmdComptabilitat.BackColor = System.Drawing.Color.SeaShell
        Me.cmdComptabilitat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdComptabilitat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdComptabilitat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdComptabilitat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdComptabilitat.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdComptabilitat.Location = New System.Drawing.Point(12, 27)
        Me.cmdComptabilitat.Name = "cmdComptabilitat"
        Me.cmdComptabilitat.Size = New System.Drawing.Size(187, 30)
        Me.cmdComptabilitat.TabIndex = 0
        Me.cmdComptabilitat.Text = "Boto1"
        Me.cmdComptabilitat.UseVisualStyleBackColor = False
        '
        'cmdFacturacio
        '
        Me.cmdFacturacio.AutoSize = True
        Me.cmdFacturacio.BackColor = System.Drawing.Color.SeaShell
        Me.cmdFacturacio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFacturacio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdFacturacio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdFacturacio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFacturacio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdFacturacio.Location = New System.Drawing.Point(12, 63)
        Me.cmdFacturacio.Name = "cmdFacturacio"
        Me.cmdFacturacio.Size = New System.Drawing.Size(187, 30)
        Me.cmdFacturacio.TabIndex = 1
        Me.cmdFacturacio.Text = "Boto2"
        Me.cmdFacturacio.UseVisualStyleBackColor = False
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
        Me.cmdCancelar.Location = New System.Drawing.Point(79, 162)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(120, 30)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Boto3"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdCompres
        '
        Me.cmdCompres.AutoSize = True
        Me.cmdCompres.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCompres.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCompres.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCompres.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCompres.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCompres.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCompres.Location = New System.Drawing.Point(12, 99)
        Me.cmdCompres.Name = "cmdCompres"
        Me.cmdCompres.Size = New System.Drawing.Size(187, 30)
        Me.cmdCompres.TabIndex = 3
        Me.cmdCompres.Text = "Boto2"
        Me.cmdCompres.UseVisualStyleBackColor = False
        '
        'DInici
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(211, 201)
        Me.Controls.Add(Me.cmdCompres)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdFacturacio)
        Me.Controls.Add(Me.cmdComptabilitat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DInici"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdComptabilitat As BOTO
    Friend WithEvents cmdFacturacio As BOTO
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdCompres As BOTO
End Class
