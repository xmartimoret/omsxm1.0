<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DCentresMan
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
        Me.panelData = New System.Windows.Forms.Panel()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.lblFitxerMan = New OmsXM.LBLBLUE()
        Me.lblFitxerCaption = New OmsXM.LBLRIGHT()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.SuspendLayout()
        '
        'panelData
        '
        Me.panelData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelData.Location = New System.Drawing.Point(77, 35)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(571, 267)
        Me.panelData.TabIndex = 10
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(535, 317)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(113, 30)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Boto1"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'lblFitxerMan
        '
        Me.lblFitxerMan.AutoSize = True
        Me.lblFitxerMan.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFitxerMan.ForeColor = System.Drawing.Color.Blue
        Me.lblFitxerMan.Location = New System.Drawing.Point(161, 14)
        Me.lblFitxerMan.Name = "lblFitxerMan"
        Me.lblFitxerMan.Size = New System.Drawing.Size(62, 16)
        Me.lblFitxerMan.TabIndex = 8
        Me.lblFitxerMan.Text = "Lblblue1"
        '
        'lblFitxerCaption
        '
        Me.lblFitxerCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFitxerCaption.ForeColor = System.Drawing.Color.Black
        Me.lblFitxerCaption.Location = New System.Drawing.Point(7, 10)
        Me.lblFitxerCaption.Name = "lblFitxerCaption"
        Me.lblFitxerCaption.Size = New System.Drawing.Size(148, 22)
        Me.lblFitxerCaption.TabIndex = 7
        Me.lblFitxerCaption.Text = "Lblright1"
        Me.lblFitxerCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.AutoSize = True
        Me.cmdGuardar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(77, 317)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(113, 30)
        Me.cmdGuardar.TabIndex = 6
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'DCentresMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 359)
        Me.Controls.Add(Me.panelData)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.lblFitxerMan)
        Me.Controls.Add(Me.lblFitxerCaption)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DCentresMan"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DCentresMan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelData As Panel
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents lblFitxerMan As LBLBLUE
    Friend WithEvents lblFitxerCaption As LBLRIGHT
    Friend WithEvents cmdGuardar As BOTO
End Class
