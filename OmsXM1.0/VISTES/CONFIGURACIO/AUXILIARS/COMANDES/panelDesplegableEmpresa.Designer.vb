﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelDesplegableEmpresa
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
        Me.components = New System.ComponentModel.Container()
        Me.panelMagatzem = New System.Windows.Forms.Panel()
        Me.lblDireccio = New System.Windows.Forms.Label()
        Me.PanelContacte = New System.Windows.Forms.Panel()
        Me.lblTelEmail = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.panelData = New System.Windows.Forms.Panel()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.txtDirector = New System.Windows.Forms.TextBox()
        Me.lblResponsables = New OmsXM.LBLRIGHT()
        Me.lblContacte = New OmsXM.LBLRIGHT()
        Me.lblProjecte = New OmsXM.LBLRIGHT()
        Me.cbProjecte = New OmsXM.CBBOX()
        Me.lblMagatzem = New OmsXM.LBLRIGHT()
        Me.PanelTipTool = New System.Windows.Forms.Panel()
        Me.lblTipTool = New OmsXM.LBLBLUE()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblAccio = New OmsXM.LBLBLUE()
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.panelData.SuspendLayout()
        Me.PanelTipTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelMagatzem
        '
        Me.panelMagatzem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelMagatzem.Location = New System.Drawing.Point(129, 36)
        Me.panelMagatzem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelMagatzem.Name = "panelMagatzem"
        Me.panelMagatzem.Size = New System.Drawing.Size(431, 34)
        Me.panelMagatzem.TabIndex = 4
        '
        'lblDireccio
        '
        Me.lblDireccio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccio.Location = New System.Drawing.Point(128, 74)
        Me.lblDireccio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDireccio.Name = "lblDireccio"
        Me.lblDireccio.Size = New System.Drawing.Size(432, 64)
        Me.lblDireccio.TabIndex = 78
        '
        'PanelContacte
        '
        Me.PanelContacte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelContacte.Location = New System.Drawing.Point(128, 142)
        Me.PanelContacte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelContacte.Name = "PanelContacte"
        Me.PanelContacte.Size = New System.Drawing.Size(432, 37)
        Me.PanelContacte.TabIndex = 87
        '
        'lblTelEmail
        '
        Me.lblTelEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelEmail.Location = New System.Drawing.Point(124, 182)
        Me.lblTelEmail.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTelEmail.Name = "lblTelEmail"
        Me.lblTelEmail.Size = New System.Drawing.Size(436, 31)
        Me.lblTelEmail.TabIndex = 90
        '
        'panelData
        '
        Me.panelData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelData.Controls.Add(Me.LinkLabel1)
        Me.panelData.Controls.Add(Me.txtResponsable)
        Me.panelData.Controls.Add(Me.txtDirector)
        Me.panelData.Controls.Add(Me.lblResponsables)
        Me.panelData.Controls.Add(Me.lblContacte)
        Me.panelData.Controls.Add(Me.panelMagatzem)
        Me.panelData.Controls.Add(Me.lblProjecte)
        Me.panelData.Controls.Add(Me.cbProjecte)
        Me.panelData.Controls.Add(Me.lblMagatzem)
        Me.panelData.Controls.Add(Me.lblDireccio)
        Me.panelData.Controls.Add(Me.PanelContacte)
        Me.panelData.Controls.Add(Me.lblTelEmail)
        Me.panelData.Location = New System.Drawing.Point(4, 41)
        Me.panelData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(573, 255)
        Me.panelData.TabIndex = 88
        '
        'txtResponsable
        '
        Me.txtResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResponsable.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponsable.ForeColor = System.Drawing.Color.Blue
        Me.txtResponsable.Location = New System.Drawing.Point(132, 217)
        Me.txtResponsable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtResponsable.Multiline = True
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(239, 30)
        Me.txtResponsable.TabIndex = 97
        '
        'txtDirector
        '
        Me.txtDirector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDirector.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirector.ForeColor = System.Drawing.Color.Blue
        Me.txtDirector.Location = New System.Drawing.Point(372, 217)
        Me.txtDirector.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDirector.Multiline = True
        Me.txtDirector.Name = "txtDirector"
        Me.txtDirector.Size = New System.Drawing.Size(190, 30)
        Me.txtDirector.TabIndex = 98
        '
        'lblResponsables
        '
        Me.lblResponsables.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblResponsables.ForeColor = System.Drawing.Color.Black
        Me.lblResponsables.Location = New System.Drawing.Point(15, 225)
        Me.lblResponsables.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblResponsables.Name = "lblResponsables"
        Me.lblResponsables.Size = New System.Drawing.Size(113, 22)
        Me.lblResponsables.TabIndex = 96
        Me.lblResponsables.Text = "Lblright3"
        Me.lblResponsables.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblContacte
        '
        Me.lblContacte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblContacte.ForeColor = System.Drawing.Color.Black
        Me.lblContacte.Location = New System.Drawing.Point(8, 138)
        Me.lblContacte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblContacte.Name = "lblContacte"
        Me.lblContacte.Size = New System.Drawing.Size(119, 22)
        Me.lblContacte.TabIndex = 95
        Me.lblContacte.Text = "Lblright3"
        Me.lblContacte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProjecte
        '
        Me.lblProjecte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblProjecte.ForeColor = System.Drawing.Color.Black
        Me.lblProjecte.Location = New System.Drawing.Point(8, 6)
        Me.lblProjecte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProjecte.Name = "lblProjecte"
        Me.lblProjecte.Size = New System.Drawing.Size(112, 22)
        Me.lblProjecte.TabIndex = 2
        Me.lblProjecte.Text = "Lblright2"
        Me.lblProjecte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbProjecte
        '
        Me.cbProjecte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbProjecte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProjecte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProjecte.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbProjecte.ForeColor = System.Drawing.Color.Blue
        Me.cbProjecte.FormattingEnabled = True
        Me.cbProjecte.Location = New System.Drawing.Point(128, 1)
        Me.cbProjecte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbProjecte.Name = "cbProjecte"
        Me.cbProjecte.Size = New System.Drawing.Size(433, 31)
        Me.cbProjecte.TabIndex = 3
        '
        'lblMagatzem
        '
        Me.lblMagatzem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMagatzem.ForeColor = System.Drawing.Color.Black
        Me.lblMagatzem.Location = New System.Drawing.Point(29, 36)
        Me.lblMagatzem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMagatzem.Name = "lblMagatzem"
        Me.lblMagatzem.Size = New System.Drawing.Size(96, 21)
        Me.lblMagatzem.TabIndex = 5
        Me.lblMagatzem.Text = "Lblright3"
        Me.lblMagatzem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelTipTool
        '
        Me.PanelTipTool.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelTipTool.Controls.Add(Me.lblTipTool)
        Me.PanelTipTool.Location = New System.Drawing.Point(16, 39)
        Me.PanelTipTool.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelTipTool.Name = "PanelTipTool"
        Me.PanelTipTool.Size = New System.Drawing.Size(557, 46)
        Me.PanelTipTool.TabIndex = 5
        '
        'lblTipTool
        '
        Me.lblTipTool.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTipTool.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblTipTool.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblTipTool.Location = New System.Drawing.Point(0, 0)
        Me.lblTipTool.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipTool.Name = "lblTipTool"
        Me.lblTipTool.Size = New System.Drawing.Size(557, 46)
        Me.lblTipTool.TabIndex = 1
        Me.lblTipTool.Text = "Lblblue1"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(7, 12)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(13, 12)
        Me.Button1.TabIndex = 90
        Me.Button1.Text = "cmdAccelerator"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblAccio
        '
        Me.lblAccio.AutoSize = True
        Me.lblAccio.BackColor = System.Drawing.Color.Silver
        Me.lblAccio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAccio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccio.ForeColor = System.Drawing.Color.Blue
        Me.lblAccio.Location = New System.Drawing.Point(5, 12)
        Me.lblAccio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAccio.Name = "lblAccio"
        Me.lblAccio.Size = New System.Drawing.Size(13, 16)
        Me.lblAccio.TabIndex = 89
        Me.lblAccio.Text = "-"
        Me.lblAccio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(136, 4)
        Me.cbEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(436, 31)
        Me.cbEmpresa.TabIndex = 1
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(39, 7)
        Me.lblEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(93, 22)
        Me.lblEmpresa.TabIndex = 0
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 98)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(77, 17)
        Me.LinkLabel1.TabIndex = 99
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LinkLabel1"
        '
        'panelDesplegableEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelTipTool)
        Me.Controls.Add(Me.lblAccio)
        Me.Controls.Add(Me.panelData)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "panelDesplegableEmpresa"
        Me.Size = New System.Drawing.Size(581, 302)
        Me.panelData.ResumeLayout(False)
        Me.panelData.PerformLayout()
        Me.PanelTipTool.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents cbEmpresa As CBBOX
    Friend WithEvents cbProjecte As CBBOX
    Friend WithEvents lblProjecte As LBLRIGHT
    Friend WithEvents panelMagatzem As Panel
    Friend WithEvents lblMagatzem As LBLRIGHT
    Friend WithEvents lblDireccio As Label
    Friend WithEvents PanelContacte As Panel
    Friend WithEvents lblTelEmail As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents panelData As Panel
    Friend WithEvents lblAccio As LBLBLUE
    Friend WithEvents Button1 As Button
    Friend WithEvents PanelTipTool As Panel
    Friend WithEvents lblContacte As LBLRIGHT
    Friend WithEvents lblTipTool As LBLBLUE
    Friend WithEvents txtResponsable As TextBox
    Friend WithEvents txtDirector As TextBox
    Friend WithEvents lblResponsables As LBLRIGHT
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
