<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LstAuxiliars
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
        Me.lblNou = New System.Windows.Forms.LinkLabel()
        Me.lst = New OmsXM.LSTBOX()
        Me.txt = New OmsXM.TXT()
        Me.SuspendLayout()
        '
        'lblNou
        '
        Me.lblNou.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNou.BackColor = System.Drawing.SystemColors.Control
        Me.lblNou.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblNou.LinkColor = System.Drawing.Color.Red
        Me.lblNou.Location = New System.Drawing.Point(444, 0)
        Me.lblNou.Name = "lblNou"
        Me.lblNou.Size = New System.Drawing.Size(31, 26)
        Me.lblNou.TabIndex = 2000
        Me.lblNou.TabStop = True
        Me.lblNou.Text = "NOU"
        Me.lblNou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lst
        '
        Me.lst.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lst.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lst.ForeColor = System.Drawing.Color.Blue
        Me.lst.FormattingEnabled = True
        Me.lst.IntegralHeight = False
        Me.lst.Location = New System.Drawing.Point(3, 31)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(472, 166)
        Me.lst.TabIndex = 1
        '
        'txt
        '
        Me.txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txt.ForeColor = System.Drawing.Color.Blue
        Me.txt.Location = New System.Drawing.Point(0, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(438, 26)
        Me.txt.TabIndex = 0
        '
        'LstAuxiliars
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lst)
        Me.Controls.Add(Me.lblNou)
        Me.Controls.Add(Me.txt)
        Me.Name = "LstAuxiliars"
        Me.Size = New System.Drawing.Size(475, 201)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt As TXT
    Friend WithEvents lst As LSTBOX
    Friend WithEvents lblNou As LinkLabel
End Class
