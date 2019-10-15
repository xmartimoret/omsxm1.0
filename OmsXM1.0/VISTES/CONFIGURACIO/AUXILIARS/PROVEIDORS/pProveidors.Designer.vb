<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pProveidors
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
        Me.SplitData = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.SplitData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitData.Panel2.SuspendLayout()
        Me.SplitData.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitData
        '
        Me.SplitData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitData.Location = New System.Drawing.Point(0, 0)
        Me.SplitData.Name = "SplitData"
        Me.SplitData.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitData.Panel1
        '
        '
        'SplitData.Panel2
        '
        Me.SplitData.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitData.Size = New System.Drawing.Size(1259, 553)
        Me.SplitData.SplitterDistance = 401
        Me.SplitData.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Size = New System.Drawing.Size(1257, 146)
        Me.SplitContainer1.SplitterDistance = 932
        Me.SplitContainer1.TabIndex = 0
        '
        'pProveidors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitData)
        Me.Name = "pProveidors"
        Me.Size = New System.Drawing.Size(1259, 553)
        Me.SplitData.Panel2.ResumeLayout(False)
        CType(Me.SplitData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitData.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitData As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
