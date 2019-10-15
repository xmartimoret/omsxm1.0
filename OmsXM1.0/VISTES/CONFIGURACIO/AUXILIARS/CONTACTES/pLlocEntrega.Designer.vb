<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pLlocEntrega
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
        Me.panelData = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'panelData
        '
        Me.panelData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelData.Location = New System.Drawing.Point(3, 3)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(125, 108)
        Me.panelData.TabIndex = 1
        '
        'pLlocEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panelData)
        Me.Name = "pLlocEntrega"
        Me.Size = New System.Drawing.Size(131, 114)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelData As Panel
End Class
