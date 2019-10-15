<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelProjecteClients
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PanelClient = New System.Windows.Forms.Panel()
        Me.panelProjecte = New System.Windows.Forms.Panel()
        Me.txtCercador = New System.Windows.Forms.TextBox()
        Me.lblCercador = New System.Windows.Forms.Label()
        Me.cmdCercador = New BOTO()
        Me.cmdSortir = New BOTO()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 399)
        Me.Panel1.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelClient)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.panelProjecte)
        Me.SplitContainer1.Size = New System.Drawing.Size(734, 399)
        Me.SplitContainer1.SplitterDistance = 215
        Me.SplitContainer1.TabIndex = 1
        '
        'PanelClient
        '
        Me.PanelClient.BackColor = System.Drawing.SystemColors.Control
        Me.PanelClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelClient.Location = New System.Drawing.Point(0, 0)
        Me.PanelClient.Name = "PanelClient"
        Me.PanelClient.Size = New System.Drawing.Size(734, 215)
        Me.PanelClient.TabIndex = 0
        '
        'panelProjecte
        '
        Me.panelProjecte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelProjecte.Location = New System.Drawing.Point(0, 0)
        Me.panelProjecte.Name = "panelProjecte"
        Me.panelProjecte.Size = New System.Drawing.Size(734, 180)
        Me.panelProjecte.TabIndex = 1
        '
        'txtCercador
        '
        Me.txtCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCercador.ForeColor = System.Drawing.Color.Blue
        Me.txtCercador.Location = New System.Drawing.Point(200, 408)
        Me.txtCercador.Name = "txtCercador"
        Me.txtCercador.Size = New System.Drawing.Size(213, 26)
        Me.txtCercador.TabIndex = 47
        '
        'lblCercador
        '
        Me.lblCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.Location = New System.Drawing.Point(53, 411)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(141, 18)
        Me.lblCercador.TabIndex = 46
        Me.lblCercador.Text = "Label1"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCercador
        '
        Me.cmdCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCercador.AutoSize = True
        Me.cmdCercador.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCercador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCercador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCercador.Location = New System.Drawing.Point(419, 403)
        Me.cmdCercador.Name = "cmdCercador"
        Me.cmdCercador.Size = New System.Drawing.Size(108, 32)
        Me.cmdCercador.TabIndex = 48
        Me.cmdCercador.UseVisualStyleBackColor = False
        '
        'cmdSortir
        '
        Me.cmdSortir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSortir.AutoSize = True
        Me.cmdSortir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdSortir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSortir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdSortir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdSortir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSortir.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdSortir.Location = New System.Drawing.Point(636, 404)
        Me.cmdSortir.Name = "cmdSortir"
        Me.cmdSortir.Size = New System.Drawing.Size(88, 30)
        Me.cmdSortir.TabIndex = 45
        Me.cmdSortir.Text = "Boto1"
        Me.cmdSortir.UseVisualStyleBackColor = False
        '
        'PanelProjecteClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdCercador)
        Me.Controls.Add(Me.txtCercador)
        Me.Controls.Add(Me.lblCercador)
        Me.Controls.Add(Me.cmdSortir)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PanelProjecteClients"
        Me.Size = New System.Drawing.Size(737, 450)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PanelClient As Panel
    Friend WithEvents panelProjecte As Panel
    Friend WithEvents cmdCercador As BOTO
    Friend WithEvents txtCercador As TextBox
    Friend WithEvents lblCercador As Label
    Friend WithEvents cmdSortir As BOTO
End Class
