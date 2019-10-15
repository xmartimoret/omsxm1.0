<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pPlantillaTransitoria
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
        Me.pSubcomptes = New System.Windows.Forms.Panel()
        Me.pYsheets = New System.Windows.Forms.Panel()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.txtAny = New OmsXM.TXT()
        Me.lblErrAny = New OmsXM.LBLRED()
        Me.lblErrorEmpresa = New OmsXM.LBLRED()
        Me.lblAny = New OmsXM.LBLRIGHT()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.SuspendLayout()
        '
        'pSubcomptes
        '
        Me.pSubcomptes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSubcomptes.BackColor = System.Drawing.SystemColors.Control
        Me.pSubcomptes.Location = New System.Drawing.Point(31, 117)
        Me.pSubcomptes.Name = "pSubcomptes"
        Me.pSubcomptes.Size = New System.Drawing.Size(1024, 217)
        Me.pSubcomptes.TabIndex = 48
        '
        'pYsheets
        '
        Me.pYsheets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pYsheets.BackColor = System.Drawing.SystemColors.Control
        Me.pYsheets.Location = New System.Drawing.Point(31, 340)
        Me.pYsheets.Name = "pYsheets"
        Me.pYsheets.Size = New System.Drawing.Size(1024, 207)
        Me.pYsheets.TabIndex = 49
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
        Me.cmdCancelar.Location = New System.Drawing.Point(958, 553)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(58, 30)
        Me.cmdCancelar.TabIndex = 51
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
        Me.cmdGuardar.Location = New System.Drawing.Point(109, 553)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(58, 30)
        Me.cmdGuardar.TabIndex = 50
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(109, 29)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(185, 26)
        Me.cbEmpresa.TabIndex = 47
        '
        'txtAny
        '
        Me.txtAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAny.ForeColor = System.Drawing.Color.Blue
        Me.txtAny.Location = New System.Drawing.Point(109, 67)
        Me.txtAny.Name = "txtAny"
        Me.txtAny.Size = New System.Drawing.Size(93, 26)
        Me.txtAny.TabIndex = 46
        '
        'lblErrAny
        '
        Me.lblErrAny.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrAny.AutoSize = True
        Me.lblErrAny.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblErrAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrAny.Location = New System.Drawing.Point(300, 71)
        Me.lblErrAny.Name = "lblErrAny"
        Me.lblErrAny.Size = New System.Drawing.Size(47, 14)
        Me.lblErrAny.TabIndex = 45
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
        Me.lblErrorEmpresa.Location = New System.Drawing.Point(300, 35)
        Me.lblErrorEmpresa.Name = "lblErrorEmpresa"
        Me.lblErrorEmpresa.Size = New System.Drawing.Size(47, 14)
        Me.lblErrorEmpresa.TabIndex = 44
        Me.lblErrorEmpresa.Text = "Lblred1"
        Me.lblErrorEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAny
        '
        Me.lblAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.ForeColor = System.Drawing.Color.Black
        Me.lblAny.Location = New System.Drawing.Point(28, 71)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(75, 18)
        Me.lblAny.TabIndex = 43
        Me.lblAny.Text = "Lblright3"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(28, 38)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(75, 18)
        Me.lblEmpresa.TabIndex = 42
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pPlantillaTransitoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.pYsheets)
        Me.Controls.Add(Me.pSubcomptes)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.txtAny)
        Me.Controls.Add(Me.lblErrAny)
        Me.Controls.Add(Me.lblErrorEmpresa)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Name = "pPlantillaTransitoria"
        Me.Size = New System.Drawing.Size(1075, 586)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAny As TXT
    Friend WithEvents lblErrAny As LBLRED
    Friend WithEvents lblErrorEmpresa As LBLRED
    Friend WithEvents lblAny As LBLRIGHT
    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents cbEmpresa As CBBOX
    Friend WithEvents pSubcomptes As Panel
    Friend WithEvents pYsheets As Panel
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
End Class
