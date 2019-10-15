<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelDesplagable
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblAccio = New OmsXM.LBLBLUE()
        Me.lblTitol = New OmsXM.LBLBLUE()
        Me.SuspendLayout()
        '
        'panelData
        '
        Me.panelData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelData.BackColor = System.Drawing.Color.Transparent
        Me.panelData.Location = New System.Drawing.Point(18, 17)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(502, 56)
        Me.panelData.TabIndex = 73
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(0, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(1, 1)
        Me.Button1.TabIndex = 74
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
        Me.lblAccio.Location = New System.Drawing.Point(1, 0)
        Me.lblAccio.Name = "lblAccio"
        Me.lblAccio.Size = New System.Drawing.Size(11, 14)
        Me.lblAccio.TabIndex = 72
        Me.lblAccio.Text = "-"
        Me.lblAccio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Blue
        Me.lblTitol.Location = New System.Drawing.Point(20, -1)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(501, 15)
        Me.lblTitol.TabIndex = 0
        '
        'panelDesplagable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panelData)
        Me.Controls.Add(Me.lblAccio)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.Button1)
        Me.Name = "panelDesplagable"
        Me.Size = New System.Drawing.Size(521, 79)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitol As LBLBLUE
    Friend WithEvents panelData As Panel
    Friend WithEvents lblAccio As LBLBLUE
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button1 As Button
End Class
