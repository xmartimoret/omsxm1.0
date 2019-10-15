<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DExportGB
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
        Me.PanelDir = New System.Windows.Forms.Panel()
        Me.lblErrFitxer = New OmsXM.LBLRED()
        Me.xecLog = New OmsXM.XEC()
        Me.xecTancar = New OmsXM.XEC()
        Me.lblErrMes = New OmsXM.LBLRED()
        Me.lblErrAny = New OmsXM.LBLRED()
        Me.lblErrParticipacio = New OmsXM.LBLRED()
        Me.lblErrorEmpresa = New OmsXM.LBLRED()
        Me.xecAny = New OmsXM.XEC()
        Me.cbMes = New OmsXM.CBBOX()
        Me.lblMes = New OmsXM.LBLRIGHT()
        Me.cbAny = New OmsXM.CBBOX()
        Me.lblAny = New OmsXM.LBLRIGHT()
        Me.Lblblue1 = New OmsXM.LBLBLUE()
        Me.txtParticipacio = New OmsXM.TXT()
        Me.lblParticipacio = New OmsXM.LBLRIGHT()
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.SuspendLayout()
        '
        'PanelDir
        '
        Me.PanelDir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDir.Location = New System.Drawing.Point(47, 168)
        Me.PanelDir.Name = "PanelDir"
        Me.PanelDir.Size = New System.Drawing.Size(440, 149)
        Me.PanelDir.TabIndex = 16
        '
        'lblErrFitxer
        '
        Me.lblErrFitxer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrFitxer.AutoSize = True
        Me.lblErrFitxer.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrFitxer.ForeColor = System.Drawing.Color.Red
        Me.lblErrFitxer.Location = New System.Drawing.Point(337, 141)
        Me.lblErrFitxer.Name = "lblErrFitxer"
        Me.lblErrFitxer.Size = New System.Drawing.Size(54, 18)
        Me.lblErrFitxer.TabIndex = 19
        Me.lblErrFitxer.Text = "Lblred4"
        Me.lblErrFitxer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecLog
        '
        Me.xecLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecLog.AutoSize = True
        Me.xecLog.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecLog.ForeColor = System.Drawing.Color.Black
        Me.xecLog.Location = New System.Drawing.Point(47, 392)
        Me.xecLog.Name = "xecLog"
        Me.xecLog.Size = New System.Drawing.Size(59, 22)
        Me.xecLog.TabIndex = 18
        Me.xecLog.Text = "Xec3"
        Me.xecLog.UseVisualStyleBackColor = True
        '
        'xecTancar
        '
        Me.xecTancar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecTancar.AutoSize = True
        Me.xecTancar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.xecTancar.ForeColor = System.Drawing.Color.Black
        Me.xecTancar.Location = New System.Drawing.Point(47, 323)
        Me.xecTancar.Name = "xecTancar"
        Me.xecTancar.Size = New System.Drawing.Size(51, 17)
        Me.xecTancar.TabIndex = 17
        Me.xecTancar.Text = "Xec2"
        Me.xecTancar.UseVisualStyleBackColor = True
        '
        'lblErrMes
        '
        Me.lblErrMes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrMes.AutoSize = True
        Me.lblErrMes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrMes.ForeColor = System.Drawing.Color.Red
        Me.lblErrMes.Location = New System.Drawing.Point(299, 116)
        Me.lblErrMes.Name = "lblErrMes"
        Me.lblErrMes.Size = New System.Drawing.Size(54, 18)
        Me.lblErrMes.TabIndex = 15
        Me.lblErrMes.Text = "Lblred4"
        Me.lblErrMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrAny
        '
        Me.lblErrAny.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrAny.AutoSize = True
        Me.lblErrAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrAny.Location = New System.Drawing.Point(299, 84)
        Me.lblErrAny.Name = "lblErrAny"
        Me.lblErrAny.Size = New System.Drawing.Size(54, 18)
        Me.lblErrAny.TabIndex = 14
        Me.lblErrAny.Text = "Lblred3"
        Me.lblErrAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrParticipacio
        '
        Me.lblErrParticipacio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrParticipacio.AutoSize = True
        Me.lblErrParticipacio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrParticipacio.ForeColor = System.Drawing.Color.Red
        Me.lblErrParticipacio.Location = New System.Drawing.Point(300, 52)
        Me.lblErrParticipacio.Name = "lblErrParticipacio"
        Me.lblErrParticipacio.Size = New System.Drawing.Size(54, 18)
        Me.lblErrParticipacio.TabIndex = 13
        Me.lblErrParticipacio.Text = "Lblred2"
        Me.lblErrParticipacio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrorEmpresa
        '
        Me.lblErrorEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorEmpresa.AutoSize = True
        Me.lblErrorEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorEmpresa.ForeColor = System.Drawing.Color.Red
        Me.lblErrorEmpresa.Location = New System.Drawing.Point(299, 20)
        Me.lblErrorEmpresa.Name = "lblErrorEmpresa"
        Me.lblErrorEmpresa.Size = New System.Drawing.Size(54, 18)
        Me.lblErrorEmpresa.TabIndex = 12
        Me.lblErrorEmpresa.Text = "Lblred1"
        Me.lblErrorEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecAny
        '
        Me.xecAny.AutoSize = True
        Me.xecAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecAny.ForeColor = System.Drawing.Color.Black
        Me.xecAny.Location = New System.Drawing.Point(108, 140)
        Me.xecAny.Name = "xecAny"
        Me.xecAny.Size = New System.Drawing.Size(59, 22)
        Me.xecAny.TabIndex = 11
        Me.xecAny.Text = "Xec1"
        Me.xecAny.UseVisualStyleBackColor = True
        '
        'cbMes
        '
        Me.cbMes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbMes.ForeColor = System.Drawing.Color.Blue
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(108, 108)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(125, 26)
        Me.cbMes.TabIndex = 10
        '
        'lblMes
        '
        Me.lblMes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Black
        Me.lblMes.Location = New System.Drawing.Point(12, 111)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(90, 18)
        Me.lblMes.TabIndex = 9
        Me.lblMes.Text = "Lblright4"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbAny
        '
        Me.cbAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbAny.ForeColor = System.Drawing.Color.Blue
        Me.cbAny.FormattingEnabled = True
        Me.cbAny.Location = New System.Drawing.Point(108, 76)
        Me.cbAny.Name = "cbAny"
        Me.cbAny.Size = New System.Drawing.Size(60, 26)
        Me.cbAny.TabIndex = 8
        '
        'lblAny
        '
        Me.lblAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.ForeColor = System.Drawing.Color.Black
        Me.lblAny.Location = New System.Drawing.Point(12, 79)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(90, 18)
        Me.lblAny.TabIndex = 7
        Me.lblAny.Text = "Lblright3"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lblblue1
        '
        Me.Lblblue1.AutoSize = True
        Me.Lblblue1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblblue1.ForeColor = System.Drawing.Color.Blue
        Me.Lblblue1.Location = New System.Drawing.Point(175, 52)
        Me.Lblblue1.Name = "Lblblue1"
        Me.Lblblue1.Size = New System.Drawing.Size(23, 18)
        Me.Lblblue1.TabIndex = 6
        Me.Lblblue1.Text = "%"
        '
        'txtParticipacio
        '
        Me.txtParticipacio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtParticipacio.ForeColor = System.Drawing.Color.Blue
        Me.txtParticipacio.Location = New System.Drawing.Point(109, 44)
        Me.txtParticipacio.Name = "txtParticipacio"
        Me.txtParticipacio.Size = New System.Drawing.Size(60, 26)
        Me.txtParticipacio.TabIndex = 5
        '
        'lblParticipacio
        '
        Me.lblParticipacio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParticipacio.ForeColor = System.Drawing.Color.Black
        Me.lblParticipacio.Location = New System.Drawing.Point(13, 47)
        Me.lblParticipacio.Name = "lblParticipacio"
        Me.lblParticipacio.Size = New System.Drawing.Size(90, 18)
        Me.lblParticipacio.TabIndex = 4
        Me.lblParticipacio.Text = "Lblright2"
        Me.lblParticipacio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(108, 12)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(185, 26)
        Me.cbEmpresa.TabIndex = 3
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(12, 15)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(90, 18)
        Me.lblEmpresa.TabIndex = 2
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmdCancelar.Location = New System.Drawing.Point(415, 351)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(58, 30)
        Me.cmdCancelar.TabIndex = 1
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
        Me.cmdGuardar.Location = New System.Drawing.Point(47, 346)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(58, 30)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'DExportGB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 413)
        Me.Controls.Add(Me.lblErrFitxer)
        Me.Controls.Add(Me.xecLog)
        Me.Controls.Add(Me.xecTancar)
        Me.Controls.Add(Me.PanelDir)
        Me.Controls.Add(Me.lblErrMes)
        Me.Controls.Add(Me.lblErrAny)
        Me.Controls.Add(Me.lblErrParticipacio)
        Me.Controls.Add(Me.lblErrorEmpresa)
        Me.Controls.Add(Me.xecAny)
        Me.Controls.Add(Me.cbMes)
        Me.Controls.Add(Me.lblMes)
        Me.Controls.Add(Me.cbAny)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.Lblblue1)
        Me.Controls.Add(Me.txtParticipacio)
        Me.Controls.Add(Me.lblParticipacio)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DExportGB"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DExportGB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents cbEmpresa As CBBOX
    Friend WithEvents lblParticipacio As LBLRIGHT
    Friend WithEvents txtParticipacio As TXT
    Friend WithEvents Lblblue1 As LBLBLUE
    Friend WithEvents cbAny As CBBOX
    Friend WithEvents lblAny As LBLRIGHT
    Friend WithEvents cbMes As CBBOX
    Friend WithEvents lblMes As LBLRIGHT
    Friend WithEvents xecAny As XEC
    Friend WithEvents lblErrorEmpresa As LBLRED
    Friend WithEvents lblErrParticipacio As LBLRED
    Friend WithEvents lblErrAny As LBLRED
    Friend WithEvents lblErrMes As LBLRED
    Friend WithEvents PanelDir As Panel
    Friend WithEvents xecTancar As XEC
    Friend WithEvents xecLog As XEC
    Friend WithEvents lblErrFitxer As LBLRED

End Class
