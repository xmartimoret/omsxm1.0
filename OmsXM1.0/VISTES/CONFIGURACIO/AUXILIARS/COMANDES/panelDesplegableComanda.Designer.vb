<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class panelDesplegableComanda
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
        Me.components = New System.ComponentModel.Container()
        Me.panelTipTool = New System.Windows.Forms.Panel()
        Me.lblTitpTool = New OmsXM.LBLBLUE()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.panelData = New System.Windows.Forms.Panel()
        Me.txtInterAval = New OmsXM.TXT()
        Me.lblInterAval = New System.Windows.Forms.Label()
        Me.txtDadesBancaries = New OmsXM.TXT()
        Me.lblDadesBancaries = New System.Windows.Forms.Label()
        Me.panelCondicionsPagament = New System.Windows.Forms.Panel()
        Me.lblCondicionsPagament = New System.Windows.Forms.Label()
        Me.txtOferta = New OmsXM.TXT()
        Me.lblOferta = New System.Windows.Forms.Label()
        Me.txtRetencio = New OmsXM.TXT()
        Me.lblRetencio = New System.Windows.Forms.Label()
        Me.panelDataMuntatge = New System.Windows.Forms.Panel()
        Me.lblEntregaMuntatge = New System.Windows.Forms.Label()
        Me.panelDataEquips = New System.Windows.Forms.Panel()
        Me.lblEntregaEquips = New System.Windows.Forms.Label()
        Me.txtPorts = New OmsXM.TXT()
        Me.lblPorts = New System.Windows.Forms.Label()
        Me.PanelDate = New System.Windows.Forms.Panel()
        Me.lblData = New System.Windows.Forms.Label()
        Me.lblAccio = New OmsXM.LBLBLUE()
        Me.lblComanda = New OmsXM.LBLRIGHT()
        Me.panelTipTool.SuspendLayout()
        Me.panelData.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelTipTool
        '
        Me.panelTipTool.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelTipTool.BackColor = System.Drawing.Color.Transparent
        Me.panelTipTool.Controls.Add(Me.lblTitpTool)
        Me.panelTipTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelTipTool.Location = New System.Drawing.Point(9, 31)
        Me.panelTipTool.Name = "panelTipTool"
        Me.panelTipTool.Size = New System.Drawing.Size(0, 29)
        Me.panelTipTool.TabIndex = 81
        '
        'lblTitpTool
        '
        Me.lblTitpTool.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitpTool.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblTitpTool.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblTitpTool.Location = New System.Drawing.Point(0, 0)
        Me.lblTitpTool.Name = "lblTitpTool"
        Me.lblTitpTool.Size = New System.Drawing.Size(0, 29)
        Me.lblTitpTool.TabIndex = 0
        Me.lblTitpTool.Text = "Lblblue1"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(9, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(1, 1)
        Me.Button1.TabIndex = 84
        Me.Button1.Text = "cmdAccelerator"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'panelData
        '
        Me.panelData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelData.BackColor = System.Drawing.SystemColors.Control
        Me.panelData.Controls.Add(Me.txtInterAval)
        Me.panelData.Controls.Add(Me.lblInterAval)
        Me.panelData.Controls.Add(Me.txtDadesBancaries)
        Me.panelData.Controls.Add(Me.lblDadesBancaries)
        Me.panelData.Controls.Add(Me.panelCondicionsPagament)
        Me.panelData.Controls.Add(Me.lblCondicionsPagament)
        Me.panelData.Controls.Add(Me.txtOferta)
        Me.panelData.Controls.Add(Me.lblOferta)
        Me.panelData.Controls.Add(Me.txtRetencio)
        Me.panelData.Controls.Add(Me.lblRetencio)
        Me.panelData.Controls.Add(Me.panelDataMuntatge)
        Me.panelData.Controls.Add(Me.lblEntregaMuntatge)
        Me.panelData.Controls.Add(Me.panelDataEquips)
        Me.panelData.Controls.Add(Me.lblEntregaEquips)
        Me.panelData.Controls.Add(Me.txtPorts)
        Me.panelData.Controls.Add(Me.lblPorts)
        Me.panelData.Controls.Add(Me.PanelDate)
        Me.panelData.Controls.Add(Me.lblData)
        Me.panelData.Location = New System.Drawing.Point(2, 38)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(416, 210)
        Me.panelData.TabIndex = 83
        '
        'txtInterAval
        '
        Me.txtInterAval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInterAval.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtInterAval.ForeColor = System.Drawing.Color.Blue
        Me.txtInterAval.Location = New System.Drawing.Point(275, 89)
        Me.txtInterAval.Name = "txtInterAval"
        Me.txtInterAval.Size = New System.Drawing.Size(138, 26)
        Me.txtInterAval.TabIndex = 5
        '
        'lblInterAval
        '
        Me.lblInterAval.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInterAval.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblInterAval.Location = New System.Drawing.Point(225, 87)
        Me.lblInterAval.Name = "lblInterAval"
        Me.lblInterAval.Size = New System.Drawing.Size(44, 25)
        Me.lblInterAval.TabIndex = 118
        Me.lblInterAval.Text = "Label5"
        Me.lblInterAval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDadesBancaries
        '
        Me.txtDadesBancaries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDadesBancaries.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDadesBancaries.ForeColor = System.Drawing.Color.Blue
        Me.txtDadesBancaries.Location = New System.Drawing.Point(116, 183)
        Me.txtDadesBancaries.Name = "txtDadesBancaries"
        Me.txtDadesBancaries.Size = New System.Drawing.Size(296, 26)
        Me.txtDadesBancaries.TabIndex = 8
        '
        'lblDadesBancaries
        '
        Me.lblDadesBancaries.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDadesBancaries.Location = New System.Drawing.Point(1, 187)
        Me.lblDadesBancaries.Name = "lblDadesBancaries"
        Me.lblDadesBancaries.Size = New System.Drawing.Size(109, 25)
        Me.lblDadesBancaries.TabIndex = 116
        Me.lblDadesBancaries.Text = "Label5"
        Me.lblDadesBancaries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelCondicionsPagament
        '
        Me.panelCondicionsPagament.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelCondicionsPagament.Location = New System.Drawing.Point(116, 149)
        Me.panelCondicionsPagament.Name = "panelCondicionsPagament"
        Me.panelCondicionsPagament.Size = New System.Drawing.Size(296, 30)
        Me.panelCondicionsPagament.TabIndex = 7
        '
        'lblCondicionsPagament
        '
        Me.lblCondicionsPagament.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCondicionsPagament.Location = New System.Drawing.Point(1, 154)
        Me.lblCondicionsPagament.Name = "lblCondicionsPagament"
        Me.lblCondicionsPagament.Size = New System.Drawing.Size(109, 25)
        Me.lblCondicionsPagament.TabIndex = 114
        Me.lblCondicionsPagament.Text = "Label5"
        Me.lblCondicionsPagament.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOferta
        '
        Me.txtOferta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOferta.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtOferta.ForeColor = System.Drawing.Color.Blue
        Me.txtOferta.Location = New System.Drawing.Point(116, 117)
        Me.txtOferta.Name = "txtOferta"
        Me.txtOferta.Size = New System.Drawing.Size(296, 26)
        Me.txtOferta.TabIndex = 6
        '
        'lblOferta
        '
        Me.lblOferta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblOferta.Location = New System.Drawing.Point(1, 121)
        Me.lblOferta.Name = "lblOferta"
        Me.lblOferta.Size = New System.Drawing.Size(109, 25)
        Me.lblOferta.TabIndex = 112
        Me.lblOferta.Text = "Label5"
        Me.lblOferta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRetencio
        '
        Me.txtRetencio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtRetencio.ForeColor = System.Drawing.Color.Blue
        Me.txtRetencio.Location = New System.Drawing.Point(116, 89)
        Me.txtRetencio.Name = "txtRetencio"
        Me.txtRetencio.Size = New System.Drawing.Size(103, 26)
        Me.txtRetencio.TabIndex = 4
        '
        'lblRetencio
        '
        Me.lblRetencio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblRetencio.Location = New System.Drawing.Point(1, 92)
        Me.lblRetencio.Name = "lblRetencio"
        Me.lblRetencio.Size = New System.Drawing.Size(109, 25)
        Me.lblRetencio.TabIndex = 110
        Me.lblRetencio.Text = "Label5"
        Me.lblRetencio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelDataMuntatge
        '
        Me.panelDataMuntatge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelDataMuntatge.Location = New System.Drawing.Point(275, 62)
        Me.panelDataMuntatge.Name = "panelDataMuntatge"
        Me.panelDataMuntatge.Size = New System.Drawing.Size(138, 25)
        Me.panelDataMuntatge.TabIndex = 3
        '
        'lblEntregaMuntatge
        '
        Me.lblEntregaMuntatge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEntregaMuntatge.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEntregaMuntatge.Location = New System.Drawing.Point(225, 62)
        Me.lblEntregaMuntatge.Name = "lblEntregaMuntatge"
        Me.lblEntregaMuntatge.Size = New System.Drawing.Size(44, 25)
        Me.lblEntregaMuntatge.TabIndex = 108
        Me.lblEntregaMuntatge.Text = "Label5"
        Me.lblEntregaMuntatge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelDataEquips
        '
        Me.panelDataEquips.Location = New System.Drawing.Point(116, 62)
        Me.panelDataEquips.Name = "panelDataEquips"
        Me.panelDataEquips.Size = New System.Drawing.Size(103, 25)
        Me.panelDataEquips.TabIndex = 2
        '
        'lblEntregaEquips
        '
        Me.lblEntregaEquips.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEntregaEquips.Location = New System.Drawing.Point(1, 67)
        Me.lblEntregaEquips.Name = "lblEntregaEquips"
        Me.lblEntregaEquips.Size = New System.Drawing.Size(109, 25)
        Me.lblEntregaEquips.TabIndex = 106
        Me.lblEntregaEquips.Text = "Label5"
        Me.lblEntregaEquips.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPorts
        '
        Me.txtPorts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPorts.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPorts.ForeColor = System.Drawing.Color.Blue
        Me.txtPorts.Location = New System.Drawing.Point(116, 32)
        Me.txtPorts.Name = "txtPorts"
        Me.txtPorts.Size = New System.Drawing.Size(296, 26)
        Me.txtPorts.TabIndex = 1
        '
        'lblPorts
        '
        Me.lblPorts.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblPorts.Location = New System.Drawing.Point(66, 29)
        Me.lblPorts.Name = "lblPorts"
        Me.lblPorts.Size = New System.Drawing.Size(44, 25)
        Me.lblPorts.TabIndex = 104
        Me.lblPorts.Text = "Label5"
        Me.lblPorts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelDate
        '
        Me.PanelDate.Location = New System.Drawing.Point(116, 4)
        Me.PanelDate.Name = "PanelDate"
        Me.PanelDate.Size = New System.Drawing.Size(136, 25)
        Me.PanelDate.TabIndex = 0
        '
        'lblData
        '
        Me.lblData.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblData.Location = New System.Drawing.Point(66, 4)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(44, 25)
        Me.lblData.TabIndex = 102
        Me.lblData.Text = "Label5"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAccio
        '
        Me.lblAccio.AutoSize = True
        Me.lblAccio.BackColor = System.Drawing.Color.Silver
        Me.lblAccio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAccio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccio.ForeColor = System.Drawing.Color.Blue
        Me.lblAccio.Location = New System.Drawing.Point(4, 10)
        Me.lblAccio.Name = "lblAccio"
        Me.lblAccio.Size = New System.Drawing.Size(11, 14)
        Me.lblAccio.TabIndex = 82
        Me.lblAccio.Text = "-"
        Me.lblAccio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblComanda
        '
        Me.lblComanda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComanda.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComanda.ForeColor = System.Drawing.Color.Blue
        Me.lblComanda.Location = New System.Drawing.Point(32, 10)
        Me.lblComanda.Name = "lblComanda"
        Me.lblComanda.Size = New System.Drawing.Size(386, 18)
        Me.lblComanda.TabIndex = 80
        Me.lblComanda.Text = "Lblright1"
        Me.lblComanda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panelDesplegableComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblAccio)
        Me.Controls.Add(Me.panelTipTool)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblComanda)
        Me.Controls.Add(Me.panelData)
        Me.Name = "panelDesplegableComanda"
        Me.Size = New System.Drawing.Size(421, 257)
        Me.panelTipTool.ResumeLayout(False)
        Me.panelData.ResumeLayout(False)
        Me.panelData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblAccio As LBLBLUE
    Friend WithEvents lblTitpTool As LBLBLUE
    Friend WithEvents panelTipTool As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents lblComanda As LBLRIGHT
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents panelData As Panel
    Friend WithEvents txtDadesBancaries As TXT
    Friend WithEvents lblDadesBancaries As Label
    Friend WithEvents panelCondicionsPagament As Panel
    Friend WithEvents lblCondicionsPagament As Label
    Friend WithEvents txtOferta As TXT
    Friend WithEvents lblOferta As Label
    Friend WithEvents txtRetencio As TXT
    Friend WithEvents lblRetencio As Label
    Friend WithEvents panelDataMuntatge As Panel
    Friend WithEvents lblEntregaMuntatge As Label
    Friend WithEvents panelDataEquips As Panel
    Friend WithEvents lblEntregaEquips As Label
    Friend WithEvents txtPorts As TXT
    Friend WithEvents lblPorts As Label
    Friend WithEvents PanelDate As Panel
    Friend WithEvents lblData As Label
    Friend WithEvents txtInterAval As TXT
    Friend WithEvents lblInterAval As Label
End Class
