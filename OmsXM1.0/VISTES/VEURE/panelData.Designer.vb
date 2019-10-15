<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class panelData
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optAcumulat = New System.Windows.Forms.RadioButton()
        Me.optIncremental = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTitol = New OmsXM.LBLMIDDLE()
        Me.lblDades = New OmsXM.LBLRIGHT()
        Me.cbDades = New OmsXM.CBBOX()
        Me.lblMes = New OmsXM.LBLRIGHT()
        Me.cbMes = New OmsXM.CBBOX()
        Me.lblSeccio = New OmsXM.LBLRIGHT()
        Me.cbSeccio = New OmsXM.CBBOX()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lblTitol)
        Me.Panel1.Controls.Add(Me.lblDades)
        Me.Panel1.Controls.Add(Me.cbDades)
        Me.Panel1.Controls.Add(Me.optAcumulat)
        Me.Panel1.Controls.Add(Me.optIncremental)
        Me.Panel1.Controls.Add(Me.lblMes)
        Me.Panel1.Controls.Add(Me.cbMes)
        Me.Panel1.Controls.Add(Me.lblSeccio)
        Me.Panel1.Controls.Add(Me.cbSeccio)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1217, 29)
        Me.Panel1.TabIndex = 10
        '
        'optAcumulat
        '
        Me.optAcumulat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optAcumulat.Checked = True
        Me.optAcumulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optAcumulat.Location = New System.Drawing.Point(1116, 4)
        Me.optAcumulat.Name = "optAcumulat"
        Me.optAcumulat.Size = New System.Drawing.Size(83, 22)
        Me.optAcumulat.TabIndex = 14
        Me.optAcumulat.TabStop = True
        Me.optAcumulat.Text = "RadioButton2"
        Me.optAcumulat.UseVisualStyleBackColor = True
        '
        'optIncremental
        '
        Me.optIncremental.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optIncremental.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optIncremental.Location = New System.Drawing.Point(1015, 6)
        Me.optIncremental.Name = "optIncremental"
        Me.optIncremental.Size = New System.Drawing.Size(81, 19)
        Me.optIncremental.TabIndex = 13
        Me.optIncremental.Text = "RadioButton1"
        Me.optIncremental.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1214, 365)
        Me.Panel2.TabIndex = 11
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitol.Location = New System.Drawing.Point(488, 5)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(234, 23)
        Me.lblTitol.TabIndex = 18
        Me.lblTitol.Text = "lblTitol"
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDades
        '
        Me.lblDades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDades.ForeColor = System.Drawing.Color.Black
        Me.lblDades.Location = New System.Drawing.Point(1, 5)
        Me.lblDades.Name = "lblDades"
        Me.lblDades.Size = New System.Drawing.Size(63, 19)
        Me.lblDades.TabIndex = 17
        Me.lblDades.Text = "Lblright1"
        Me.lblDades.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbDades
        '
        Me.cbDades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDades.ForeColor = System.Drawing.Color.Blue
        Me.cbDades.FormattingEnabled = True
        Me.cbDades.Location = New System.Drawing.Point(70, 2)
        Me.cbDades.Name = "cbDades"
        Me.cbDades.Size = New System.Drawing.Size(187, 21)
        Me.cbDades.TabIndex = 16
        '
        'lblMes
        '
        Me.lblMes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Black
        Me.lblMes.Location = New System.Drawing.Point(746, 6)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(47, 13)
        Me.lblMes.TabIndex = 12
        Me.lblMes.Text = "Lblright2"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbMes
        '
        Me.cbMes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMes.ForeColor = System.Drawing.Color.Blue
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(799, 1)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(185, 21)
        Me.cbMes.TabIndex = 11
        '
        'lblSeccio
        '
        Me.lblSeccio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeccio.ForeColor = System.Drawing.Color.Black
        Me.lblSeccio.Location = New System.Drawing.Point(263, 7)
        Me.lblSeccio.Name = "lblSeccio"
        Me.lblSeccio.Size = New System.Drawing.Size(47, 13)
        Me.lblSeccio.TabIndex = 10
        Me.lblSeccio.Text = "Lblright1"
        Me.lblSeccio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbSeccio
        '
        Me.cbSeccio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSeccio.ForeColor = System.Drawing.Color.Blue
        Me.cbSeccio.FormattingEnabled = True
        Me.cbSeccio.Location = New System.Drawing.Point(316, 2)
        Me.cbSeccio.Name = "cbSeccio"
        Me.cbSeccio.Size = New System.Drawing.Size(166, 21)
        Me.cbSeccio.TabIndex = 9
        '
        'panelData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "panelData"
        Me.Size = New System.Drawing.Size(1217, 395)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblDades As LBLRIGHT
    Friend WithEvents cbDades As CBBOX
    Friend WithEvents optAcumulat As RadioButton
    Friend WithEvents optIncremental As RadioButton
    Friend WithEvents lblMes As LBLRIGHT
    Friend WithEvents cbMes As CBBOX
    Friend WithEvents lblSeccio As LBLRIGHT
    Friend WithEvents cbSeccio As CBBOX
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTitol As LBLMIDDLE
End Class
