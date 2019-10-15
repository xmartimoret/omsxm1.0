<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DMesosEmpresa
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
        Me.txtAny = New OmsXM.TXT()
        Me.lstMes = New OmsXM.LSTBOX()
        Me.lblErrMes = New OmsXM.LBLRED()
        Me.xecLog = New OmsXM.XEC()
        Me.xecTots = New OmsXM.XEC()
        Me.lblErrAny = New OmsXM.LBLRED()
        Me.lblErrorEmpresa = New OmsXM.LBLRED()
        Me.lblMes = New OmsXM.LBLRIGHT()
        Me.lblAny = New OmsXM.LBLRIGHT()
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.SuspendLayout()
        '
        'txtAny
        '
        Me.txtAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAny.ForeColor = System.Drawing.Color.Blue
        Me.txtAny.Location = New System.Drawing.Point(86, 38)
        Me.txtAny.Name = "txtAny"
        Me.txtAny.Size = New System.Drawing.Size(93, 26)
        Me.txtAny.TabIndex = 54
        '
        'lstMes
        '
        Me.lstMes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lstMes.ForeColor = System.Drawing.Color.Blue
        Me.lstMes.FormattingEnabled = True
        Me.lstMes.ItemHeight = 18
        Me.lstMes.Location = New System.Drawing.Point(86, 76)
        Me.lstMes.Name = "lstMes"
        Me.lstMes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstMes.Size = New System.Drawing.Size(185, 220)
        Me.lstMes.TabIndex = 53
        '
        'lblErrMes
        '
        Me.lblErrMes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrMes.AutoSize = True
        Me.lblErrMes.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblErrMes.ForeColor = System.Drawing.Color.Red
        Me.lblErrMes.Location = New System.Drawing.Point(277, 76)
        Me.lblErrMes.Name = "lblErrMes"
        Me.lblErrMes.Size = New System.Drawing.Size(47, 14)
        Me.lblErrMes.TabIndex = 52
        Me.lblErrMes.Text = "Lblred4"
        Me.lblErrMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecLog
        '
        Me.xecLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecLog.AutoSize = True
        Me.xecLog.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecLog.ForeColor = System.Drawing.Color.Black
        Me.xecLog.Location = New System.Drawing.Point(22, 376)
        Me.xecLog.Name = "xecLog"
        Me.xecLog.Size = New System.Drawing.Size(59, 22)
        Me.xecLog.TabIndex = 51
        Me.xecLog.Text = "Xec3"
        Me.xecLog.UseVisualStyleBackColor = True
        '
        'xecTots
        '
        Me.xecTots.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecTots.AutoSize = True
        Me.xecTots.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecTots.ForeColor = System.Drawing.Color.Black
        Me.xecTots.Location = New System.Drawing.Point(85, 303)
        Me.xecTots.Name = "xecTots"
        Me.xecTots.Size = New System.Drawing.Size(59, 22)
        Me.xecTots.TabIndex = 50
        Me.xecTots.Text = "Xec2"
        Me.xecTots.UseVisualStyleBackColor = True
        '
        'lblErrAny
        '
        Me.lblErrAny.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrAny.AutoSize = True
        Me.lblErrAny.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblErrAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrAny.Location = New System.Drawing.Point(277, 42)
        Me.lblErrAny.Name = "lblErrAny"
        Me.lblErrAny.Size = New System.Drawing.Size(47, 14)
        Me.lblErrAny.TabIndex = 49
        Me.lblErrAny.Text = "Lblred3"
        Me.lblErrAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrorEmpresa
        '
        Me.lblErrorEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorEmpresa.AutoSize = True
        Me.lblErrorEmpresa.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblErrorEmpresa.ForeColor = System.Drawing.Color.Red
        Me.lblErrorEmpresa.Location = New System.Drawing.Point(277, 6)
        Me.lblErrorEmpresa.Name = "lblErrorEmpresa"
        Me.lblErrorEmpresa.Size = New System.Drawing.Size(47, 14)
        Me.lblErrorEmpresa.TabIndex = 48
        Me.lblErrorEmpresa.Text = "Lblred1"
        Me.lblErrorEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMes
        '
        Me.lblMes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Black
        Me.lblMes.Location = New System.Drawing.Point(5, 76)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(75, 18)
        Me.lblMes.TabIndex = 47
        Me.lblMes.Text = "Lblright4"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblAny
        '
        Me.lblAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.ForeColor = System.Drawing.Color.Black
        Me.lblAny.Location = New System.Drawing.Point(5, 42)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(75, 18)
        Me.lblAny.TabIndex = 46
        Me.lblAny.Text = "Lblright3"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(86, 6)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(185, 26)
        Me.cbEmpresa.TabIndex = 45
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(5, 9)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(75, 18)
        Me.lblEmpresa.TabIndex = 44
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomRight
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
        Me.cmdCancelar.Location = New System.Drawing.Point(339, 331)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(58, 30)
        Me.cmdCancelar.TabIndex = 43
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
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
        Me.cmdGuardar.Location = New System.Drawing.Point(86, 331)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(58, 30)
        Me.cmdGuardar.TabIndex = 42
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'DMesosEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 408)
        Me.Controls.Add(Me.txtAny)
        Me.Controls.Add(Me.lstMes)
        Me.Controls.Add(Me.lblErrMes)
        Me.Controls.Add(Me.xecLog)
        Me.Controls.Add(Me.xecTots)
        Me.Controls.Add(Me.lblErrAny)
        Me.Controls.Add(Me.lblErrorEmpresa)
        Me.Controls.Add(Me.lblMes)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DMesosEmpresa"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DMesosEmpresa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAny As TXT
    Friend WithEvents lstMes As LSTBOX
    Friend WithEvents lblErrMes As LBLRED
    Friend WithEvents xecLog As XEC
    Friend WithEvents xecTots As XEC
    Friend WithEvents lblErrAny As LBLRED
    Friend WithEvents lblErrorEmpresa As LBLRED
    Friend WithEvents lblMes As LBLRIGHT
    Friend WithEvents lblAny As LBLRIGHT
    Friend WithEvents cbEmpresa As CBBOX
    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
End Class
