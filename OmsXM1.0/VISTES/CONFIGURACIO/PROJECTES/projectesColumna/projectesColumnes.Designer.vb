<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class projectesColumnes
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
        Me.PanelProjectes = New System.Windows.Forms.Panel()
        Me.panelColumnes = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdTancar = New System.Windows.Forms.Button()
        Me.cmdCercador = New OmsXM.BOTO()
        Me.txtCercador = New System.Windows.Forms.TextBox()
        Me.lblCercador = New System.Windows.Forms.Label()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelProjectes
        '
        Me.PanelProjectes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelProjectes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelProjectes.Location = New System.Drawing.Point(0, 0)
        Me.PanelProjectes.Name = "PanelProjectes"
        Me.PanelProjectes.Size = New System.Drawing.Size(318, 244)
        Me.PanelProjectes.TabIndex = 4
        '
        'panelColumnes
        '
        Me.panelColumnes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelColumnes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelColumnes.Location = New System.Drawing.Point(0, 0)
        Me.panelColumnes.Name = "panelColumnes"
        Me.panelColumnes.Size = New System.Drawing.Size(294, 244)
        Me.panelColumnes.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.panelColumnes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelProjectes)
        Me.SplitContainer1.Size = New System.Drawing.Size(616, 244)
        Me.SplitContainer1.SplitterDistance = 294
        Me.SplitContainer1.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 244)
        Me.Panel1.TabIndex = 6
        '
        'cmdTancar
        '
        Me.cmdTancar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTancar.AutoSize = True
        Me.cmdTancar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdTancar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTancar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdTancar.FlatAppearance.BorderSize = 2
        Me.cmdTancar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdTancar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTancar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdTancar.Location = New System.Drawing.Point(508, 250)
        Me.cmdTancar.Name = "cmdTancar"
        Me.cmdTancar.Size = New System.Drawing.Size(108, 32)
        Me.cmdTancar.TabIndex = 46
        Me.cmdTancar.Text = "OK"
        Me.cmdTancar.UseVisualStyleBackColor = False
        '
        'cmdCercador
        '
        Me.cmdCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCercador.AutoSize = True
        Me.cmdCercador.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCercador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCercador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCercador.Location = New System.Drawing.Point(362, 250)
        Me.cmdCercador.Name = "cmdCercador"
        Me.cmdCercador.Size = New System.Drawing.Size(108, 32)
        Me.cmdCercador.TabIndex = 45
        Me.cmdCercador.UseVisualStyleBackColor = False
        '
        'txtCercador
        '
        Me.txtCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCercador.ForeColor = System.Drawing.Color.Blue
        Me.txtCercador.Location = New System.Drawing.Point(143, 255)
        Me.txtCercador.Name = "txtCercador"
        Me.txtCercador.Size = New System.Drawing.Size(213, 26)
        Me.txtCercador.TabIndex = 44
        '
        'lblCercador
        '
        Me.lblCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.Location = New System.Drawing.Point(-53, 258)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(190, 18)
        Me.lblCercador.TabIndex = 43
        Me.lblCercador.Text = "lblCercador"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'projectesColumnes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdTancar)
        Me.Controls.Add(Me.cmdCercador)
        Me.Controls.Add(Me.txtCercador)
        Me.Controls.Add(Me.lblCercador)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "projectesColumnes"
        Me.Size = New System.Drawing.Size(623, 292)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelProjectes As Panel
    Friend WithEvents panelColumnes As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdTancar As Button
    Friend WithEvents cmdCercador As BOTO
    Friend WithEvents txtCercador As TextBox
    Friend WithEvents lblCercador As Label
End Class
