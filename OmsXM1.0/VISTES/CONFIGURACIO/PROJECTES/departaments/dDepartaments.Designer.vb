<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dDepartaments
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
        Me.pData = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pData
        '
        Me.pData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pData.Location = New System.Drawing.Point(0, 0)
        Me.pData.Name = "pData"
        Me.pData.Size = New System.Drawing.Size(435, 315)
        Me.pData.TabIndex = 0
        '
        'dDepartaments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.pData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dDepartaments"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dDepartaments"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pData As Panel
End Class
