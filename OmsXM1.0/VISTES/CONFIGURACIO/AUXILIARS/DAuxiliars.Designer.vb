<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DAuxiliars
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.PData = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'PData
        '
        Me.PData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PData.Location = New System.Drawing.Point(0, 0)
        Me.PData.Name = "PData"
        Me.PData.Size = New System.Drawing.Size(625, 448)
        Me.PData.TabIndex = 0
        '
        'DAuxiliars
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 448)
        Me.Controls.Add(Me.PData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DAuxiliars"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "D"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PData As Panel
End Class
