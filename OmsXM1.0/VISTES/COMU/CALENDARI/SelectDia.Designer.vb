<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectDia))
        Me.cmdData = New System.Windows.Forms.Button()
        Me.txtData = New OmsXM.TXT()
        Me.SuspendLayout()
        '
        'cmdData
        '
        Me.cmdData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdData.Image = CType(resources.GetObject("cmdData.Image"), System.Drawing.Image)
        Me.cmdData.Location = New System.Drawing.Point(127, 0)
        Me.cmdData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdData.Name = "cmdData"
        Me.cmdData.Size = New System.Drawing.Size(28, 28)
        Me.cmdData.TabIndex = 0
        Me.cmdData.TabStop = False
        Me.cmdData.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdData.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmdData.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtData.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.ForeColor = System.Drawing.Color.Blue
        Me.txtData.Location = New System.Drawing.Point(0, 0)
        Me.txtData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(123, 27)
        Me.txtData.TabIndex = 1
        Me.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SelectDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.cmdData)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SelectDia"
        Me.Size = New System.Drawing.Size(155, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdData As Button
    Friend WithEvents txtData As TXT
End Class
