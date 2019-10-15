<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LVSubObjectsSelect
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
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(-1, 4)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(405, 24)
        Me.lblTitol.TabIndex = 38
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCount.Location = New System.Drawing.Point(226, 225)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(178, 21)
        Me.lblCount.TabIndex = 35
        Me.lblCount.Text = "lblCount"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstData
        '
        Me.lstData.AllowColumnReorder = True
        Me.lstData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstData.BackColor = System.Drawing.SystemColors.HighlightText
        Me.lstData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstData.CheckBoxes = True
        Me.lstData.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lstData.ForeColor = System.Drawing.Color.Blue
        Me.lstData.FullRowSelect = True
        Me.lstData.GridLines = True
        Me.lstData.HideSelection = False
        Me.lstData.Location = New System.Drawing.Point(3, 31)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(401, 191)
        Me.lstData.TabIndex = 33
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'LVSubObjectsSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.lstData)
        Me.Name = "LVSubObjectsSelect"
        Me.Size = New System.Drawing.Size(407, 257)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitol As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents lstData As ListView
End Class
