<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DMissatges
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
        Me.PanelErrors = New System.Windows.Forms.Panel()
        Me.lblText = New OmsXM.LBLBLUE()
        Me.cmdImprimir = New OmsXM.BOTO()
        Me.cmdSortir = New OmsXM.BOTO()
        Me.PanelErrors.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelErrors
        '
        Me.PanelErrors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelErrors.Controls.Add(Me.lblText)
        Me.PanelErrors.Location = New System.Drawing.Point(12, 12)
        Me.PanelErrors.Name = "PanelErrors"
        Me.PanelErrors.Size = New System.Drawing.Size(629, 255)
        Me.PanelErrors.TabIndex = 5
        '
        'lblText
        '
        Me.lblText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblText.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.ForeColor = System.Drawing.Color.Blue
        Me.lblText.Location = New System.Drawing.Point(0, 0)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(629, 255)
        Me.lblText.TabIndex = 0
        Me.lblText.Text = "Lblblue1"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdImprimir.AutoSize = True
        Me.cmdImprimir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdImprimir.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdImprimir.Location = New System.Drawing.Point(12, 273)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(129, 30)
        Me.cmdImprimir.TabIndex = 4
        Me.cmdImprimir.Text = "Boto1"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'cmdSortir
        '
        Me.cmdSortir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSortir.AutoSize = True
        Me.cmdSortir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdSortir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSortir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdSortir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdSortir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSortir.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdSortir.Location = New System.Drawing.Point(512, 273)
        Me.cmdSortir.Name = "cmdSortir"
        Me.cmdSortir.Size = New System.Drawing.Size(129, 30)
        Me.cmdSortir.TabIndex = 6
        Me.cmdSortir.Text = "Boto1"
        Me.cmdSortir.UseVisualStyleBackColor = False
        '
        'DMissatges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 315)
        Me.Controls.Add(Me.cmdSortir)
        Me.Controls.Add(Me.PanelErrors)
        Me.Controls.Add(Me.cmdImprimir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DMissatges"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DMissatges"
        Me.PanelErrors.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelErrors As Panel
    Friend WithEvents lblText As LBLBLUE
    Friend WithEvents cmdImprimir As BOTO
    Friend WithEvents cmdSortir As BOTO
End Class
