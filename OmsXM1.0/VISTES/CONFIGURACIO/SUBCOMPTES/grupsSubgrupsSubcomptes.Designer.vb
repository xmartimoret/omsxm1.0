<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class grupsSubgrupsSubcomptes
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
        Me.txtCercador = New System.Windows.Forms.TextBox()
        Me.lblCercador = New System.Windows.Forms.Label()
        Me.cmdTancar = New System.Windows.Forms.Button()
        Me.cbGrup = New System.Windows.Forms.ComboBox()
        Me.lblGrup = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PanelSubgrups = New System.Windows.Forms.Panel()
        Me.PanelSubcomptes = New System.Windows.Forms.Panel()
        Me.cmdEditarGrups = New OmsXM.BOTO()
        Me.cmdCercador = New OmsXM.BOTO()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCercador
        '
        Me.txtCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCercador.ForeColor = System.Drawing.Color.Blue
        Me.txtCercador.Location = New System.Drawing.Point(199, 501)
        Me.txtCercador.Name = "txtCercador"
        Me.txtCercador.Size = New System.Drawing.Size(213, 26)
        Me.txtCercador.TabIndex = 40
        '
        'lblCercador
        '
        Me.lblCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.Location = New System.Drawing.Point(3, 504)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(190, 18)
        Me.lblCercador.TabIndex = 39
        Me.lblCercador.Text = "Label1"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmdTancar.Location = New System.Drawing.Point(943, 496)
        Me.cmdTancar.Name = "cmdTancar"
        Me.cmdTancar.Size = New System.Drawing.Size(108, 32)
        Me.cmdTancar.TabIndex = 42
        Me.cmdTancar.Text = "OK"
        Me.cmdTancar.UseVisualStyleBackColor = False
        '
        'cbGrup
        '
        Me.cbGrup.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.cbGrup.ForeColor = System.Drawing.Color.Blue
        Me.cbGrup.FormattingEnabled = True
        Me.cbGrup.Location = New System.Drawing.Point(122, 13)
        Me.cbGrup.Name = "cbGrup"
        Me.cbGrup.Size = New System.Drawing.Size(420, 32)
        Me.cbGrup.TabIndex = 44
        '
        'lblGrup
        '
        Me.lblGrup.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrup.Location = New System.Drawing.Point(3, 13)
        Me.lblGrup.Name = "lblGrup"
        Me.lblGrup.Size = New System.Drawing.Size(113, 23)
        Me.lblGrup.TabIndex = 43
        Me.lblGrup.Text = "Label1"
        Me.lblGrup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(6, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1045, 425)
        Me.Panel1.TabIndex = 46
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelSubgrups)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelSubcomptes)
        Me.SplitContainer1.Size = New System.Drawing.Size(1045, 425)
        Me.SplitContainer1.SplitterDistance = 510
        Me.SplitContainer1.TabIndex = 0
        '
        'PanelSubgrups
        '
        Me.PanelSubgrups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSubgrups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSubgrups.Location = New System.Drawing.Point(0, 0)
        Me.PanelSubgrups.Name = "PanelSubgrups"
        Me.PanelSubgrups.Size = New System.Drawing.Size(510, 425)
        Me.PanelSubgrups.TabIndex = 1
        '
        'PanelSubcomptes
        '
        Me.PanelSubcomptes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSubcomptes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSubcomptes.Location = New System.Drawing.Point(0, 0)
        Me.PanelSubcomptes.Name = "PanelSubcomptes"
        Me.PanelSubcomptes.Size = New System.Drawing.Size(531, 425)
        Me.PanelSubcomptes.TabIndex = 2
        '
        'cmdEditarGrups
        '
        Me.cmdEditarGrups.AutoSize = True
        Me.cmdEditarGrups.BackColor = System.Drawing.Color.SeaShell
        Me.cmdEditarGrups.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEditarGrups.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEditarGrups.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdEditarGrups.Location = New System.Drawing.Point(561, 15)
        Me.cmdEditarGrups.Name = "cmdEditarGrups"
        Me.cmdEditarGrups.Size = New System.Drawing.Size(75, 30)
        Me.cmdEditarGrups.TabIndex = 45
        Me.cmdEditarGrups.Text = "OK"
        Me.cmdEditarGrups.UseVisualStyleBackColor = False
        '
        'cmdCercador
        '
        Me.cmdCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCercador.AutoSize = True
        Me.cmdCercador.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCercador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCercador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCercador.Location = New System.Drawing.Point(418, 496)
        Me.cmdCercador.Name = "cmdCercador"
        Me.cmdCercador.Size = New System.Drawing.Size(108, 32)
        Me.cmdCercador.TabIndex = 41
        Me.cmdCercador.UseVisualStyleBackColor = False
        '
        'grupsSubgrupsSubcomptes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdEditarGrups)
        Me.Controls.Add(Me.cbGrup)
        Me.Controls.Add(Me.lblGrup)
        Me.Controls.Add(Me.cmdTancar)
        Me.Controls.Add(Me.cmdCercador)
        Me.Controls.Add(Me.txtCercador)
        Me.Controls.Add(Me.lblCercador)
        Me.Name = "grupsSubgrupsSubcomptes"
        Me.Size = New System.Drawing.Size(1062, 544)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCercador As TextBox
    Friend WithEvents lblCercador As Label
    Friend WithEvents cmdTancar As Button
    Friend WithEvents cbGrup As ComboBox
    Friend WithEvents lblGrup As Label
    Friend WithEvents cmdCercador As BOTO
    Friend WithEvents cmdEditarGrups As BOTO
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PanelSubgrups As Panel
    Friend WithEvents PanelSubcomptes As Panel
End Class
