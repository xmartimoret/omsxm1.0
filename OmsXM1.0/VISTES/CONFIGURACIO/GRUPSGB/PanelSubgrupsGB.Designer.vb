<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelSubgrupsGB
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panelData = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'panelData
        '
        Me.panelData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelData.Location = New System.Drawing.Point(0, 0)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(373, 182)
        Me.panelData.TabIndex = 0
        '
        'PanelSubgrupsGB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panelData)
        Me.Name = "PanelSubgrupsGB"
        Me.Size = New System.Drawing.Size(373, 182)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelData As Panel
End Class
