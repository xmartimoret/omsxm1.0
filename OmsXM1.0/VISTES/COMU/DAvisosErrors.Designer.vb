<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DAvisosErrors
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
        Me.cmdSortir = New OmsXM.BOTO()
        Me.cmdImprimir = New OmsXM.BOTO()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblText = New OmsXM.LBLBLUE()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblErrors = New OmsXM.LBLBLUE()
        Me.LblAvisosCaption = New OmsXM.LBLBLUE()
        Me.lblErrorsCaption = New OmsXM.LBLBLUE()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.cmdSortir.Location = New System.Drawing.Point(450, 503)
        Me.cmdSortir.Name = "cmdSortir"
        Me.cmdSortir.Size = New System.Drawing.Size(129, 30)
        Me.cmdSortir.TabIndex = 9
        Me.cmdSortir.Text = "Boto1"
        Me.cmdSortir.UseVisualStyleBackColor = False
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
        Me.cmdImprimir.Location = New System.Drawing.Point(12, 503)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(129, 30)
        Me.cmdImprimir.TabIndex = 8
        Me.cmdImprimir.Text = "Boto1"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblText)
        Me.Panel1.Location = New System.Drawing.Point(12, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(564, 213)
        Me.Panel1.TabIndex = 10
        '
        'lblText
        '
        Me.lblText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblText.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.ForeColor = System.Drawing.Color.Blue
        Me.lblText.Location = New System.Drawing.Point(0, 0)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(564, 213)
        Me.lblText.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblErrors)
        Me.Panel2.Location = New System.Drawing.Point(12, 276)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 221)
        Me.Panel2.TabIndex = 11
        '
        'lblErrors
        '
        Me.lblErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblErrors.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrors.ForeColor = System.Drawing.Color.Red
        Me.lblErrors.Location = New System.Drawing.Point(0, 0)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(564, 221)
        Me.lblErrors.TabIndex = 1
        '
        'LblAvisosCaption
        '
        Me.LblAvisosCaption.AutoSize = True
        Me.LblAvisosCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAvisosCaption.ForeColor = System.Drawing.Color.Blue
        Me.LblAvisosCaption.Location = New System.Drawing.Point(12, 9)
        Me.LblAvisosCaption.Name = "LblAvisosCaption"
        Me.LblAvisosCaption.Size = New System.Drawing.Size(62, 16)
        Me.LblAvisosCaption.TabIndex = 12
        Me.LblAvisosCaption.Text = "Lblblue1"
        '
        'lblErrorsCaption
        '
        Me.lblErrorsCaption.AutoSize = True
        Me.lblErrorsCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorsCaption.ForeColor = System.Drawing.Color.Red
        Me.lblErrorsCaption.Location = New System.Drawing.Point(12, 257)
        Me.lblErrorsCaption.Name = "lblErrorsCaption"
        Me.lblErrorsCaption.Size = New System.Drawing.Size(62, 16)
        Me.lblErrorsCaption.TabIndex = 13
        Me.lblErrorsCaption.Text = "Lblblue2"
        '
        'DAvisosErrors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 545)
        Me.Controls.Add(Me.lblErrorsCaption)
        Me.Controls.Add(Me.LblAvisosCaption)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdSortir)
        Me.Controls.Add(Me.cmdImprimir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DAvisosErrors"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DAvisosErrors"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSortir As BOTO
    Friend WithEvents cmdImprimir As BOTO
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblAvisosCaption As LBLBLUE
    Friend WithEvents lblErrorsCaption As LBLBLUE
    Friend WithEvents lblText As LBLBLUE
    Friend WithEvents lblErrors As LBLBLUE
End Class
