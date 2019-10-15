<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DMesos
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
        Me.cmdCancelar = New BOTO()
        Me.lstMes = New LSTBOX()
        Me.txtAny = New TXT()
        Me.lblAny = New LBLRIGHT()
        Me.lblMes = New LBLRIGHT()
        Me.xecBorrar = New XEC()
        Me.xecLog = New XEC()
        Me.xecTots = New XEC()
        Me.lblErrAny = New LBLRED()
        Me.SuspendLayout()
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.AutoSize = True
        Me.cmdGuardar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(12, 379)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(75, 30)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(142, 379)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 30)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'lstMes
        '
        Me.lstMes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lstMes.ForeColor = System.Drawing.Color.Blue
        Me.lstMes.FormattingEnabled = True
        Me.lstMes.ItemHeight = 18
        Me.lstMes.Location = New System.Drawing.Point(12, 83)
        Me.lstMes.Name = "lstMes"
        Me.lstMes.Size = New System.Drawing.Size(205, 238)
        Me.lstMes.TabIndex = 2
        '
        'txtAny
        '
        Me.txtAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAny.ForeColor = System.Drawing.Color.Blue
        Me.txtAny.Location = New System.Drawing.Point(12, 33)
        Me.txtAny.Name = "txtAny"
        Me.txtAny.Size = New System.Drawing.Size(100, 26)
        Me.txtAny.TabIndex = 3
        '
        'lblAny
        '
        Me.lblAny.AutoSize = True
        Me.lblAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.ForeColor = System.Drawing.Color.Black
        Me.lblAny.Location = New System.Drawing.Point(9, 12)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(61, 18)
        Me.lblAny.TabIndex = 4
        Me.lblAny.Text = "Lblright1"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Black
        Me.lblMes.Location = New System.Drawing.Point(12, 62)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(61, 18)
        Me.lblMes.TabIndex = 5
        Me.lblMes.Text = "Lblright2"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xecBorrar
        '
        Me.xecBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecBorrar.AutoSize = True
        Me.xecBorrar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecBorrar.ForeColor = System.Drawing.Color.Black
        Me.xecBorrar.Location = New System.Drawing.Point(12, 338)
        Me.xecBorrar.Name = "xecBorrar"
        Me.xecBorrar.Size = New System.Drawing.Size(59, 22)
        Me.xecBorrar.TabIndex = 6
        Me.xecBorrar.Text = "Xec1"
        Me.xecBorrar.UseVisualStyleBackColor = True
        '
        'xecLog
        '
        Me.xecLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecLog.AutoSize = True
        Me.xecLog.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecLog.ForeColor = System.Drawing.Color.Black
        Me.xecLog.Location = New System.Drawing.Point(11, 415)
        Me.xecLog.Name = "xecLog"
        Me.xecLog.Size = New System.Drawing.Size(59, 22)
        Me.xecLog.TabIndex = 7
        Me.xecLog.Text = "Xec2"
        Me.xecLog.UseVisualStyleBackColor = True
        '
        'xecTots
        '
        Me.xecTots.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xecTots.AutoSize = True
        Me.xecTots.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecTots.ForeColor = System.Drawing.Color.Black
        Me.xecTots.Location = New System.Drawing.Point(158, 338)
        Me.xecTots.Name = "xecTots"
        Me.xecTots.Size = New System.Drawing.Size(59, 22)
        Me.xecTots.TabIndex = 8
        Me.xecTots.Text = "Xec3"
        Me.xecTots.UseVisualStyleBackColor = True
        '
        'lblErrAny
        '
        Me.lblErrAny.AutoSize = True
        Me.lblErrAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrAny.Location = New System.Drawing.Point(118, 41)
        Me.lblErrAny.Name = "lblErrAny"
        Me.lblErrAny.Size = New System.Drawing.Size(54, 18)
        Me.lblErrAny.TabIndex = 9
        Me.lblErrAny.Text = "Lblred1"
        Me.lblErrAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DMesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(237, 442)
        Me.Controls.Add(Me.lblErrAny)
        Me.Controls.Add(Me.xecTots)
        Me.Controls.Add(Me.xecLog)
        Me.Controls.Add(Me.xecBorrar)
        Me.Controls.Add(Me.lblMes)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.txtAny)
        Me.Controls.Add(Me.lstMes)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DMesos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DMesos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents lstMes As LSTBOX
    Friend WithEvents txtAny As TXT
    Friend WithEvents lblAny As LBLRIGHT
    Friend WithEvents lblMes As LBLRIGHT
    Friend WithEvents xecBorrar As XEC
    Friend WithEvents xecLog As XEC
    Friend WithEvents xecTots As XEC
    Friend WithEvents lblErrAny As LBLRED
End Class
