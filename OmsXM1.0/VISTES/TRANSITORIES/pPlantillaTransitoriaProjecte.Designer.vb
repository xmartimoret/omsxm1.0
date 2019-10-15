<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pPlantillaTransitoriaProjecte
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
        Me.panelDir = New System.Windows.Forms.Panel()
        Me.lblErrorDir = New OmsXM.LBLRED()
        Me.lblErrorProjectes = New OmsXM.LBLRED()
        Me.lblProjectes = New OmsXM.LBLRIGHT()
        Me.cmdTreure = New OmsXM.BOTO()
        Me.cmdAfegir = New OmsXM.BOTO()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.lstProjectes = New OmsXM.LSTBOX()
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.txtAny = New OmsXM.TXT()
        Me.lblErrAny = New OmsXM.LBLRED()
        Me.lblErrorEmpresa = New OmsXM.LBLRED()
        Me.lblAny = New OmsXM.LBLRIGHT()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.SuspendLayout()
        '
        'panelDir
        '
        Me.panelDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelDir.Location = New System.Drawing.Point(157, 237)
        Me.panelDir.Name = "panelDir"
        Me.panelDir.Size = New System.Drawing.Size(480, 123)
        Me.panelDir.TabIndex = 99
        '
        'lblErrorDir
        '
        Me.lblErrorDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorDir.AutoSize = True
        Me.lblErrorDir.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblErrorDir.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDir.Location = New System.Drawing.Point(565, 220)
        Me.lblErrorDir.Name = "lblErrorDir"
        Me.lblErrorDir.Size = New System.Drawing.Size(47, 14)
        Me.lblErrorDir.TabIndex = 101
        Me.lblErrorDir.Text = "Lblred1"
        Me.lblErrorDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrorProjectes
        '
        Me.lblErrorProjectes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorProjectes.AutoSize = True
        Me.lblErrorProjectes.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblErrorProjectes.ForeColor = System.Drawing.Color.Red
        Me.lblErrorProjectes.Location = New System.Drawing.Point(565, 66)
        Me.lblErrorProjectes.Name = "lblErrorProjectes"
        Me.lblErrorProjectes.Size = New System.Drawing.Size(47, 14)
        Me.lblErrorProjectes.TabIndex = 100
        Me.lblErrorProjectes.Text = "Lblred1"
        Me.lblErrorProjectes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProjectes
        '
        Me.lblProjectes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjectes.ForeColor = System.Drawing.Color.Black
        Me.lblProjectes.Location = New System.Drawing.Point(24, 83)
        Me.lblProjectes.Name = "lblProjectes"
        Me.lblProjectes.Size = New System.Drawing.Size(127, 18)
        Me.lblProjectes.TabIndex = 53
        Me.lblProjectes.Text = "Lblright3"
        Me.lblProjectes.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cmdTreure
        '
        Me.cmdTreure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTreure.AutoSize = True
        Me.cmdTreure.BackColor = System.Drawing.Color.SeaShell
        Me.cmdTreure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTreure.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdTreure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdTreure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTreure.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdTreure.Location = New System.Drawing.Point(644, 152)
        Me.cmdTreure.Name = "cmdTreure"
        Me.cmdTreure.Size = New System.Drawing.Size(102, 34)
        Me.cmdTreure.TabIndex = 52
        Me.cmdTreure.Text = "cmdTreure"
        Me.cmdTreure.UseVisualStyleBackColor = False
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
        Me.cmdAfegir.Location = New System.Drawing.Point(644, 106)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(102, 30)
        Me.cmdAfegir.TabIndex = 51
        Me.cmdAfegir.Text = "cmdAfegir"
        Me.cmdAfegir.UseVisualStyleBackColor = False
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
        Me.cmdCancelar.Location = New System.Drawing.Point(644, 374)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(116, 30)
        Me.cmdCancelar.TabIndex = 50
        Me.cmdCancelar.Text = "cmdcancelar"
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
        Me.cmdGuardar.Location = New System.Drawing.Point(105, 374)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(126, 30)
        Me.cmdGuardar.TabIndex = 49
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'lstProjectes
        '
        Me.lstProjectes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProjectes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lstProjectes.ForeColor = System.Drawing.Color.Blue
        Me.lstProjectes.FormattingEnabled = True
        Me.lstProjectes.ItemHeight = 18
        Me.lstProjectes.Location = New System.Drawing.Point(157, 83)
        Me.lstProjectes.Name = "lstProjectes"
        Me.lstProjectes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstProjectes.Size = New System.Drawing.Size(481, 112)
        Me.lstProjectes.TabIndex = 48
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(157, 37)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(185, 26)
        Me.cbEmpresa.TabIndex = 47
        '
        'txtAny
        '
        Me.txtAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAny.ForeColor = System.Drawing.Color.Blue
        Me.txtAny.Location = New System.Drawing.Point(157, 5)
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
        Me.lblErrAny.Location = New System.Drawing.Point(348, 9)
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
        Me.lblErrorEmpresa.Location = New System.Drawing.Point(348, 38)
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
        Me.lblAny.Location = New System.Drawing.Point(24, 13)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(127, 18)
        Me.lblAny.TabIndex = 43
        Me.lblAny.Text = "Lblright3"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(24, 45)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(127, 18)
        Me.lblEmpresa.TabIndex = 42
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pPlantillaTransitoriaProjecte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblErrorDir)
        Me.Controls.Add(Me.lblErrorProjectes)
        Me.Controls.Add(Me.panelDir)
        Me.Controls.Add(Me.lblProjectes)
        Me.Controls.Add(Me.cmdTreure)
        Me.Controls.Add(Me.cmdAfegir)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.lstProjectes)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.txtAny)
        Me.Controls.Add(Me.lblErrAny)
        Me.Controls.Add(Me.lblErrorEmpresa)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Name = "pPlantillaTransitoriaProjecte"
        Me.Size = New System.Drawing.Size(805, 418)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAny As TXT
    Friend WithEvents lblErrAny As LBLRED
    Friend WithEvents lblErrorEmpresa As LBLRED
    Friend WithEvents lblAny As LBLRIGHT
    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents cbEmpresa As CBBOX
    Friend WithEvents lstProjectes As LSTBOX
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents cmdAfegir As BOTO
    Friend WithEvents cmdTreure As BOTO
    Friend WithEvents lblProjectes As LBLRIGHT
    Friend WithEvents panelDir As Panel
    Friend WithEvents lblErrorProjectes As LBLRED
    Friend WithEvents lblErrorDir As LBLRED
End Class
