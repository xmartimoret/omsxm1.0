<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dImportUtes
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
        Me.PanelRuta = New System.Windows.Forms.Panel()
        Me.lblErrRutaXls = New OmsXM.LBLRED()
        Me.xecLog = New OmsXM.XEC()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.xecAny = New OmsXM.XEC()
        Me.lblErrMes = New OmsXM.LBLRED()
        Me.lblErrAny = New OmsXM.LBLRED()
        Me.cbMes = New OmsXM.CBBOX()
        Me.lblMes = New OmsXM.LBLRIGHT()
        Me.cbAny = New OmsXM.CBBOX()
        Me.lblAny = New OmsXM.LBLRIGHT()
        Me.lblRutaDiari = New OmsXM.LBLMIDDLE()
        Me.SuspendLayout()
        '
        'PanelRuta
        '
        Me.PanelRuta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelRuta.Location = New System.Drawing.Point(25, 227)
        Me.PanelRuta.Name = "PanelRuta"
        Me.PanelRuta.Size = New System.Drawing.Size(400, 137)
        Me.PanelRuta.TabIndex = 23
        '
        'lblErrRutaXls
        '
        Me.lblErrRutaXls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrRutaXls.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrRutaXls.ForeColor = System.Drawing.Color.Red
        Me.lblErrRutaXls.Location = New System.Drawing.Point(271, 206)
        Me.lblErrRutaXls.Name = "lblErrRutaXls"
        Me.lblErrRutaXls.Size = New System.Drawing.Size(154, 18)
        Me.lblErrRutaXls.TabIndex = 27
        Me.lblErrRutaXls.Text = "Lblred4"
        Me.lblErrRutaXls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecLog
        '
        Me.xecLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xecLog.AutoSize = True
        Me.xecLog.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecLog.ForeColor = System.Drawing.Color.Black
        Me.xecLog.Location = New System.Drawing.Point(24, 406)
        Me.xecLog.Name = "xecLog"
        Me.xecLog.Size = New System.Drawing.Size(59, 22)
        Me.xecLog.TabIndex = 26
        Me.xecLog.Text = "Xec3"
        Me.xecLog.UseVisualStyleBackColor = True
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
        Me.cmdCancelar.Location = New System.Drawing.Point(334, 370)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(91, 30)
        Me.cmdCancelar.TabIndex = 25
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
        Me.cmdGuardar.Location = New System.Drawing.Point(25, 370)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(97, 30)
        Me.cmdGuardar.TabIndex = 24
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'xecAny
        '
        Me.xecAny.AutoSize = True
        Me.xecAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecAny.ForeColor = System.Drawing.Color.Black
        Me.xecAny.Location = New System.Drawing.Point(89, 167)
        Me.xecAny.Name = "xecAny"
        Me.xecAny.Size = New System.Drawing.Size(75, 22)
        Me.xecAny.TabIndex = 22
        Me.xecAny.Text = "xecAny"
        Me.xecAny.UseVisualStyleBackColor = True
        '
        'lblErrMes
        '
        Me.lblErrMes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrMes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrMes.ForeColor = System.Drawing.Color.Red
        Me.lblErrMes.Location = New System.Drawing.Point(248, 143)
        Me.lblErrMes.Name = "lblErrMes"
        Me.lblErrMes.Size = New System.Drawing.Size(152, 18)
        Me.lblErrMes.TabIndex = 21
        Me.lblErrMes.Text = "Lblred4"
        Me.lblErrMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrAny
        '
        Me.lblErrAny.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrAny.Location = New System.Drawing.Point(248, 111)
        Me.lblErrAny.Name = "lblErrAny"
        Me.lblErrAny.Size = New System.Drawing.Size(152, 18)
        Me.lblErrAny.TabIndex = 20
        Me.lblErrAny.Text = "Lblred3"
        Me.lblErrAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbMes
        '
        Me.cbMes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbMes.ForeColor = System.Drawing.Color.Blue
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(88, 135)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(125, 26)
        Me.cbMes.TabIndex = 19
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Black
        Me.lblMes.Location = New System.Drawing.Point(21, 138)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(61, 18)
        Me.lblMes.TabIndex = 18
        Me.lblMes.Text = "Lblright4"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbAny
        '
        Me.cbAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbAny.ForeColor = System.Drawing.Color.Blue
        Me.cbAny.FormattingEnabled = True
        Me.cbAny.Location = New System.Drawing.Point(88, 103)
        Me.cbAny.Name = "cbAny"
        Me.cbAny.Size = New System.Drawing.Size(60, 26)
        Me.cbAny.TabIndex = 17
        '
        'lblAny
        '
        Me.lblAny.AutoSize = True
        Me.lblAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.ForeColor = System.Drawing.Color.Black
        Me.lblAny.Location = New System.Drawing.Point(21, 106)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(61, 18)
        Me.lblAny.TabIndex = 16
        Me.lblAny.Text = "Lblright3"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRutaDiari
        '
        Me.lblRutaDiari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRutaDiari.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblRutaDiari.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRutaDiari.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblRutaDiari.Location = New System.Drawing.Point(2, 0)
        Me.lblRutaDiari.Name = "lblRutaDiari"
        Me.lblRutaDiari.Size = New System.Drawing.Size(423, 63)
        Me.lblRutaDiari.TabIndex = 0
        Me.lblRutaDiari.Text = "Lblmiddle1"
        '
        'dImportUtes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 436)
        Me.Controls.Add(Me.lblErrRutaXls)
        Me.Controls.Add(Me.xecLog)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.PanelRuta)
        Me.Controls.Add(Me.xecAny)
        Me.Controls.Add(Me.lblErrMes)
        Me.Controls.Add(Me.lblErrAny)
        Me.Controls.Add(Me.cbMes)
        Me.Controls.Add(Me.lblMes)
        Me.Controls.Add(Me.cbAny)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.lblRutaDiari)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dImportUtes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dImportUtes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRutaDiari As LBLMIDDLE
    Friend WithEvents lblErrMes As LBLRED
    Friend WithEvents lblErrAny As LBLRED
    Friend WithEvents cbMes As CBBOX
    Friend WithEvents lblMes As LBLRIGHT
    Friend WithEvents cbAny As CBBOX
    Friend WithEvents lblAny As LBLRIGHT
    Friend WithEvents xecAny As XEC
    Friend WithEvents PanelRuta As Panel
    Friend WithEvents xecLog As XEC
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents lblErrRutaXls As LBLRED
End Class
