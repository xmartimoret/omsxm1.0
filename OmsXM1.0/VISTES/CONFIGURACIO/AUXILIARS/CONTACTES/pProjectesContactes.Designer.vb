<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pProjectesContactes
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
        Me.SContainer = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1.SuspendLayout()
        CType(Me.SContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SContainer.Panel2.SuspendLayout()
        Me.SContainer.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SContainer)
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(979, 490)
        Me.Panel1.TabIndex = 0
        '
        'SContainer
        '
        Me.SContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SContainer.Location = New System.Drawing.Point(0, 0)
        Me.SContainer.Name = "SContainer"
        Me.SContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SContainer.Panel2
        '
        Me.SContainer.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SContainer.Size = New System.Drawing.Size(979, 490)
        Me.SContainer.SplitterDistance = 292
        Me.SContainer.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Size = New System.Drawing.Size(979, 194)
        Me.SplitContainer1.SplitterDistance = 509
        Me.SplitContainer1.TabIndex = 0
        '
        'pProjectesContactes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "pProjectesContactes"
        Me.Size = New System.Drawing.Size(982, 524)
        Me.Panel1.ResumeLayout(False)
        Me.SContainer.Panel2.ResumeLayout(False)
        CType(Me.SContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SContainer.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SContainer As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
