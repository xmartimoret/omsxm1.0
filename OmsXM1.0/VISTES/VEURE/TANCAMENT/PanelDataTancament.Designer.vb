<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelDataTancament
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
        Me.Split1 = New System.Windows.Forms.SplitContainer()
        Me.Split1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Split1
        '
        Me.Split1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Split1.Location = New System.Drawing.Point(0, 0)
        Me.Split1.Name = "Split1"
        Me.Split1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Split1.Panel1
        '
        Me.Split1.Size = New System.Drawing.Size(479, 361)
        Me.Split1.SplitterDistance = 310
        Me.Split1.TabIndex = 0
        '
        'PanelDataTancament
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Split1)
        Me.Name = "PanelDataTancament"
        Me.Size = New System.Drawing.Size(479, 361)
        Me.Split1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Split1 As SplitContainer
End Class
