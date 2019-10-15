<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Directori
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
        Me.fileBrowser = New System.Windows.Forms.OpenFileDialog()
        Me.folderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdDirectori = New BOTO()
        Me.lblDirectori = New LBLBLUE()
        Me.lblCaptionDirectori = New LBLRIGHT()
        Me.SuspendLayout()
        '
        'fileBrowser
        '
        Me.fileBrowser.FileName = "OpenFileDialog1"
        '
        'cmdDirectori
        '
        Me.cmdDirectori.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDirectori.AutoSize = True
        Me.cmdDirectori.BackColor = System.Drawing.Color.SeaShell
        Me.cmdDirectori.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdDirectori.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdDirectori.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdDirectori.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDirectori.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdDirectori.Location = New System.Drawing.Point(261, 22)
        Me.cmdDirectori.Name = "cmdDirectori"
        Me.cmdDirectori.Size = New System.Drawing.Size(58, 46)
        Me.cmdDirectori.TabIndex = 2
        Me.cmdDirectori.Text = "Boto1"
        Me.cmdDirectori.UseVisualStyleBackColor = False
        '
        'lblDirectori
        '
        Me.lblDirectori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDirectori.BackColor = System.Drawing.SystemColors.Control
        Me.lblDirectori.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirectori.ForeColor = System.Drawing.Color.Blue
        Me.lblDirectori.Location = New System.Drawing.Point(21, 22)
        Me.lblDirectori.Name = "lblDirectori"
        Me.lblDirectori.Size = New System.Drawing.Size(237, 49)
        Me.lblDirectori.TabIndex = 1
        Me.lblDirectori.Text = "Directori"
        '
        'lblCaptionDirectori
        '
        Me.lblCaptionDirectori.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaptionDirectori.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionDirectori.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionDirectori.Location = New System.Drawing.Point(6, 0)
        Me.lblCaptionDirectori.Name = "lblCaptionDirectori"
        Me.lblCaptionDirectori.Size = New System.Drawing.Size(313, 18)
        Me.lblCaptionDirectori.TabIndex = 0
        Me.lblCaptionDirectori.Text = "Caption"
        Me.lblCaptionDirectori.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Directori
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdDirectori)
        Me.Controls.Add(Me.lblDirectori)
        Me.Controls.Add(Me.lblCaptionDirectori)
        Me.Name = "Directori"
        Me.Size = New System.Drawing.Size(322, 71)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCaptionDirectori As LBLRIGHT
    Friend WithEvents lblDirectori As LBLBLUE
    Friend WithEvents cmdDirectori As BOTO
    Friend WithEvents fileBrowser As OpenFileDialog
    Friend WithEvents folderBrowser As FolderBrowserDialog
End Class
