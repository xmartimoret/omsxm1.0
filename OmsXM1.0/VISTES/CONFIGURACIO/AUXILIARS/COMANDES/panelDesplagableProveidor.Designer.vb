<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelDesplagableProveidor
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
        Me.panelData = New System.Windows.Forms.Panel()
        Me.panelProvincia = New System.Windows.Forms.Panel()
        Me.lblContacte = New System.Windows.Forms.Label()
        Me.txtTelefon = New System.Windows.Forms.TextBox()
        Me.PanelContacte = New System.Windows.Forms.Panel()
        Me.txtCodiPostal = New System.Windows.Forms.TextBox()
        Me.lblTelEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblPoblacio = New System.Windows.Forms.Label()
        Me.txtPoblacio = New System.Windows.Forms.TextBox()
        Me.txtDireccio = New System.Windows.Forms.TextBox()
        Me.lblDireccio = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.panelList = New System.Windows.Forms.Panel()
        Me.panelTipTool = New System.Windows.Forms.Panel()
        Me.lblTitpTool = New OmsXM.LBLBLUE()
        Me.lblTitol = New OmsXM.LBLRIGHT()
        Me.lblAccio = New OmsXM.LBLBLUE()
        Me.panelData.SuspendLayout()
        Me.panelTipTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelData
        '
        Me.panelData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelData.BackColor = System.Drawing.Color.Transparent
        Me.panelData.Controls.Add(Me.panelProvincia)
        Me.panelData.Controls.Add(Me.lblContacte)
        Me.panelData.Controls.Add(Me.txtTelefon)
        Me.panelData.Controls.Add(Me.PanelContacte)
        Me.panelData.Controls.Add(Me.txtCodiPostal)
        Me.panelData.Controls.Add(Me.lblTelEmail)
        Me.panelData.Controls.Add(Me.txtEmail)
        Me.panelData.Controls.Add(Me.lblProvincia)
        Me.panelData.Controls.Add(Me.lblPoblacio)
        Me.panelData.Controls.Add(Me.txtPoblacio)
        Me.panelData.Controls.Add(Me.txtDireccio)
        Me.panelData.Controls.Add(Me.lblDireccio)
        Me.panelData.Location = New System.Drawing.Point(10, 36)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(482, 167)
        Me.panelData.TabIndex = 77
        '
        'panelProvincia
        '
        Me.panelProvincia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelProvincia.Location = New System.Drawing.Point(107, 72)
        Me.panelProvincia.Name = "panelProvincia"
        Me.panelProvincia.Size = New System.Drawing.Size(373, 30)
        Me.panelProvincia.TabIndex = 4
        '
        'lblContacte
        '
        Me.lblContacte.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContacte.Location = New System.Drawing.Point(6, 108)
        Me.lblContacte.Name = "lblContacte"
        Me.lblContacte.Size = New System.Drawing.Size(101, 25)
        Me.lblContacte.TabIndex = 98
        Me.lblContacte.Text = "Label7"
        Me.lblContacte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTelefon
        '
        Me.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefon.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefon.ForeColor = System.Drawing.Color.Blue
        Me.txtTelefon.Location = New System.Drawing.Point(155, 135)
        Me.txtTelefon.Multiline = True
        Me.txtTelefon.Name = "txtTelefon"
        Me.txtTelefon.Size = New System.Drawing.Size(122, 25)
        Me.txtTelefon.TabIndex = 6
        '
        'PanelContacte
        '
        Me.PanelContacte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelContacte.Location = New System.Drawing.Point(107, 103)
        Me.PanelContacte.Name = "PanelContacte"
        Me.PanelContacte.Size = New System.Drawing.Size(373, 30)
        Me.PanelContacte.TabIndex = 5
        '
        'txtCodiPostal
        '
        Me.txtCodiPostal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodiPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodiPostal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodiPostal.ForeColor = System.Drawing.Color.Blue
        Me.txtCodiPostal.Location = New System.Drawing.Point(350, 46)
        Me.txtCodiPostal.Multiline = True
        Me.txtCodiPostal.Name = "txtCodiPostal"
        Me.txtCodiPostal.Size = New System.Drawing.Size(129, 25)
        Me.txtCodiPostal.TabIndex = 3
        '
        'lblTelEmail
        '
        Me.lblTelEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelEmail.Location = New System.Drawing.Point(48, 135)
        Me.lblTelEmail.Name = "lblTelEmail"
        Me.lblTelEmail.Size = New System.Drawing.Size(101, 25)
        Me.lblTelEmail.TabIndex = 97
        Me.lblTelEmail.Text = "Label6"
        Me.lblTelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.Color.Blue
        Me.txtEmail.Location = New System.Drawing.Point(275, 135)
        Me.txtEmail.Multiline = True
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(204, 25)
        Me.txtEmail.TabIndex = 7
        '
        'lblProvincia
        '
        Me.lblProvincia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvincia.Location = New System.Drawing.Point(7, 74)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(101, 28)
        Me.lblProvincia.TabIndex = 96
        Me.lblProvincia.Text = "Label3"
        Me.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPoblacio
        '
        Me.lblPoblacio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoblacio.Location = New System.Drawing.Point(6, 44)
        Me.lblPoblacio.Name = "lblPoblacio"
        Me.lblPoblacio.Size = New System.Drawing.Size(101, 25)
        Me.lblPoblacio.TabIndex = 95
        Me.lblPoblacio.Text = "Label2"
        Me.lblPoblacio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPoblacio
        '
        Me.txtPoblacio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPoblacio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPoblacio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPoblacio.ForeColor = System.Drawing.Color.Blue
        Me.txtPoblacio.Location = New System.Drawing.Point(107, 46)
        Me.txtPoblacio.Multiline = True
        Me.txtPoblacio.Name = "txtPoblacio"
        Me.txtPoblacio.Size = New System.Drawing.Size(244, 25)
        Me.txtPoblacio.TabIndex = 2
        '
        'txtDireccio
        '
        Me.txtDireccio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccio.ForeColor = System.Drawing.Color.Blue
        Me.txtDireccio.Location = New System.Drawing.Point(107, 1)
        Me.txtDireccio.Multiline = True
        Me.txtDireccio.Name = "txtDireccio"
        Me.txtDireccio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccio.Size = New System.Drawing.Size(372, 44)
        Me.txtDireccio.TabIndex = 1
        '
        'lblDireccio
        '
        Me.lblDireccio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccio.Location = New System.Drawing.Point(3, 1)
        Me.lblDireccio.Name = "lblDireccio"
        Me.lblDireccio.Size = New System.Drawing.Size(101, 44)
        Me.lblDireccio.TabIndex = 94
        Me.lblDireccio.Text = "Label1"
        Me.lblDireccio.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(3, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(1, 1)
        Me.Button1.TabIndex = 78
        Me.Button1.Text = "cmdAccelerator"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'panelList
        '
        Me.panelList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelList.BackColor = System.Drawing.Color.Transparent
        Me.panelList.Location = New System.Drawing.Point(122, 3)
        Me.panelList.Name = "panelList"
        Me.panelList.Size = New System.Drawing.Size(367, 27)
        Me.panelList.TabIndex = 0
        '
        'panelTipTool
        '
        Me.panelTipTool.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelTipTool.BackColor = System.Drawing.Color.Transparent
        Me.panelTipTool.Controls.Add(Me.lblTitpTool)
        Me.panelTipTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelTipTool.Location = New System.Drawing.Point(19, 29)
        Me.panelTipTool.Name = "panelTipTool"
        Me.panelTipTool.Size = New System.Drawing.Size(467, 29)
        Me.panelTipTool.TabIndex = 1
        '
        'lblTitpTool
        '
        Me.lblTitpTool.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitpTool.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblTitpTool.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblTitpTool.Location = New System.Drawing.Point(0, 0)
        Me.lblTitpTool.Name = "lblTitpTool"
        Me.lblTitpTool.Size = New System.Drawing.Size(467, 29)
        Me.lblTitpTool.TabIndex = 0
        Me.lblTitpTool.Text = "Lblblue1"
        '
        'lblTitol
        '
        Me.lblTitol.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(33, 8)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(84, 18)
        Me.lblTitol.TabIndex = 0
        Me.lblTitol.Text = "Lblright1"
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.lblAccio.TabIndex = 76
        Me.lblAccio.Text = "-"
        Me.lblAccio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'panelDesplagableProveidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panelTipTool)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.panelList)
        Me.Controls.Add(Me.panelData)
        Me.Controls.Add(Me.lblAccio)
        Me.Controls.Add(Me.Button1)
        Me.Name = "panelDesplagableProveidor"
        Me.Size = New System.Drawing.Size(492, 206)
        Me.panelData.ResumeLayout(False)
        Me.panelData.PerformLayout()
        Me.panelTipTool.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelData As Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lblAccio As LBLBLUE
    Friend WithEvents Button1 As Button
    Friend WithEvents panelList As Panel
    Friend WithEvents lblTitol As LBLRIGHT
    Friend WithEvents panelProvincia As Panel
    Friend WithEvents lblContacte As Label
    Friend WithEvents txtTelefon As TextBox
    Friend WithEvents PanelContacte As Panel
    Friend WithEvents txtCodiPostal As TextBox
    Friend WithEvents lblTelEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblProvincia As Label
    Friend WithEvents lblPoblacio As Label
    Friend WithEvents txtPoblacio As TextBox
    Friend WithEvents txtDireccio As TextBox
    Friend WithEvents lblDireccio As Label
    Friend WithEvents panelTipTool As Panel
    Friend WithEvents lblTitpTool As LBLBLUE
End Class
