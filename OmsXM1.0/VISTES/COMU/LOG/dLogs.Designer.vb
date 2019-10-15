<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dLogs
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
        Me.cmdVeure = New OmsXM.BOTO()
        Me.cmdTancar = New OmsXM.BOTO()
        Me.PanelAvisos = New System.Windows.Forms.Panel()
        Me.PanelErrors = New System.Windows.Forms.Panel()
        Me.cmdImprimir = New OmsXM.BOTO()
        Me.SuspendLayout()
        '
        'cmdVeure
        '
        Me.cmdVeure.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdVeure.AutoSize = True
        Me.cmdVeure.BackColor = System.Drawing.Color.SeaShell
        Me.cmdVeure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdVeure.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdVeure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdVeure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdVeure.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdVeure.Location = New System.Drawing.Point(27, 435)
        Me.cmdVeure.Name = "cmdVeure"
        Me.cmdVeure.Size = New System.Drawing.Size(129, 30)
        Me.cmdVeure.TabIndex = 0
        Me.cmdVeure.Text = "Boto1"
        Me.cmdVeure.UseVisualStyleBackColor = False
        '
        'cmdTancar
        '
        Me.cmdTancar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTancar.AutoSize = True
        Me.cmdTancar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdTancar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTancar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdTancar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdTancar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTancar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdTancar.Location = New System.Drawing.Point(546, 435)
        Me.cmdTancar.Name = "cmdTancar"
        Me.cmdTancar.Size = New System.Drawing.Size(121, 30)
        Me.cmdTancar.TabIndex = 1
        Me.cmdTancar.Text = "Boto2"
        Me.cmdTancar.UseVisualStyleBackColor = False
        '
        'PanelAvisos
        '
        Me.PanelAvisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelAvisos.Location = New System.Drawing.Point(3, 3)
        Me.PanelAvisos.Name = "PanelAvisos"
        Me.PanelAvisos.Size = New System.Drawing.Size(676, 198)
        Me.PanelAvisos.TabIndex = 2
        '
        'PanelErrors
        '
        Me.PanelErrors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelErrors.Location = New System.Drawing.Point(3, 207)
        Me.PanelErrors.Name = "PanelErrors"
        Me.PanelErrors.Size = New System.Drawing.Size(676, 202)
        Me.PanelErrors.TabIndex = 3
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdImprimir.AutoSize = True
        Me.cmdImprimir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdImprimir.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdImprimir.Location = New System.Drawing.Point(285, 415)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(121, 30)
        Me.cmdImprimir.TabIndex = 4
        Me.cmdImprimir.Text = "Boto2"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'dLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 477)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.PanelErrors)
        Me.Controls.Add(Me.PanelAvisos)
        Me.Controls.Add(Me.cmdTancar)
        Me.Controls.Add(Me.cmdVeure)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dLogs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dLogs"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdVeure As BOTO
    Friend WithEvents cmdTancar As BOTO
    Friend WithEvents PanelAvisos As Panel
    Friend WithEvents PanelErrors As Panel
    Friend WithEvents cmdImprimir As BOTO
End Class
