<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DColumna
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
        Me.lblErrNom = New LBLRED()
        Me.xecTotalitzador = New XEC()
        Me.txtNom = New TXT()
        Me.lblNom = New LBLRIGHT()
        Me.lblCodi = New LBLBLUE()
        Me.lblCaptionCodi = New LBLRIGHT()
        Me.cmdCancelar = New BOTO()
        Me.cmdGuardar = New BOTO()
        Me.SuspendLayout()
        '
        'lblErrNom
        '
        Me.lblErrNom.AutoSize = True
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(300, 33)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(54, 18)
        Me.lblErrNom.TabIndex = 7
        Me.lblErrNom.Text = "Lblred1"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecTotalitzador
        '
        Me.xecTotalitzador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecTotalitzador.ForeColor = System.Drawing.Color.Black
        Me.xecTotalitzador.Location = New System.Drawing.Point(99, 62)
        Me.xecTotalitzador.Name = "xecTotalitzador"
        Me.xecTotalitzador.Size = New System.Drawing.Size(325, 22)
        Me.xecTotalitzador.TabIndex = 6
        Me.xecTotalitzador.Text = "Xec1"
        Me.xecTotalitzador.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.xecTotalitzador.UseVisualStyleBackColor = True
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(99, 30)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(195, 26)
        Me.txtNom.TabIndex = 5
        '
        'lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.ForeColor = System.Drawing.Color.Black
        Me.lblNom.Location = New System.Drawing.Point(29, 33)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(61, 18)
        Me.lblNom.TabIndex = 4
        Me.lblNom.Text = "Lblright2"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodi
        '
        Me.lblCodi.AutoSize = True
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.ForeColor = System.Drawing.Color.Blue
        Me.lblCodi.Location = New System.Drawing.Point(96, 9)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(59, 18)
        Me.lblCodi.TabIndex = 3
        Me.lblCodi.Text = "Lblblue1"
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaptionCodi
        '
        Me.lblCaptionCodi.AutoSize = True
        Me.lblCaptionCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionCodi.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionCodi.Location = New System.Drawing.Point(29, 9)
        Me.lblCaptionCodi.Name = "lblCaptionCodi"
        Me.lblCaptionCodi.Size = New System.Drawing.Size(61, 18)
        Me.lblCaptionCodi.TabIndex = 2
        Me.lblCaptionCodi.Text = "Lblright1"
        Me.lblCaptionCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmdCancelar.Location = New System.Drawing.Point(330, 107)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 30)
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
        Me.cmdGuardar.Location = New System.Drawing.Point(34, 107)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(75, 30)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'DColumna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 157)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.xecTotalitzador)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblCodi)
        Me.Controls.Add(Me.lblCaptionCodi)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DColumna"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DColumna"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents lblCaptionCodi As LBLRIGHT
    Friend WithEvents lblCodi As LBLBLUE
    Friend WithEvents lblNom As LBLRIGHT
    Friend WithEvents txtNom As TXT
    Friend WithEvents xecTotalitzador As XEC
    Friend WithEvents lblErrNom As LBLRED
End Class
