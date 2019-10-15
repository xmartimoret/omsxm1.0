<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dLog
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
        Me.cmdTancar = New OmsXM.BOTO()
        Me.lblCaptionTipus = New OmsXM.LBLRIGHT()
        Me.lblTipus = New OmsXM.LBLBLUE()
        Me.lblCaptionDescripcio = New OmsXM.LBLRIGHT()
        Me.lblDescripcio = New OmsXM.LBLBLUE()
        Me.lblCodi = New OmsXM.LBLBLUE()
        Me.lblCaptionCodi = New OmsXM.LBLRIGHT()
        Me.SuspendLayout()
        '
        'cmdTancar
        '
        Me.cmdTancar.AutoSize = True
        Me.cmdTancar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdTancar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTancar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdTancar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdTancar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTancar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdTancar.Location = New System.Drawing.Point(338, 230)
        Me.cmdTancar.Name = "cmdTancar"
        Me.cmdTancar.Size = New System.Drawing.Size(75, 30)
        Me.cmdTancar.TabIndex = 0
        Me.cmdTancar.Text = "Boto1"
        Me.cmdTancar.UseVisualStyleBackColor = False
        '
        'lblCaptionTipus
        '
        Me.lblCaptionTipus.AutoSize = True
        Me.lblCaptionTipus.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionTipus.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionTipus.Location = New System.Drawing.Point(12, 21)
        Me.lblCaptionTipus.Name = "lblCaptionTipus"
        Me.lblCaptionTipus.Size = New System.Drawing.Size(61, 18)
        Me.lblCaptionTipus.TabIndex = 1
        Me.lblCaptionTipus.Text = "Lblright1"
        Me.lblCaptionTipus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipus
        '
        Me.lblTipus.AutoSize = True
        Me.lblTipus.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipus.ForeColor = System.Drawing.Color.Blue
        Me.lblTipus.Location = New System.Drawing.Point(79, 21)
        Me.lblTipus.Name = "lblTipus"
        Me.lblTipus.Size = New System.Drawing.Size(59, 18)
        Me.lblTipus.TabIndex = 2
        Me.lblTipus.Text = "Lblblue1"
        '
        'lblCaptionDescripcio
        '
        Me.lblCaptionDescripcio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionDescripcio.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionDescripcio.Location = New System.Drawing.Point(12, 105)
        Me.lblCaptionDescripcio.Name = "lblCaptionDescripcio"
        Me.lblCaptionDescripcio.Size = New System.Drawing.Size(61, 18)
        Me.lblCaptionDescripcio.TabIndex = 3
        Me.lblCaptionDescripcio.Text = "llll"
        Me.lblCaptionDescripcio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCaptionDescripcio.UseWaitCursor = True
        '
        'lblDescripcio
        '
        Me.lblDescripcio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcio.ForeColor = System.Drawing.Color.Blue
        Me.lblDescripcio.Location = New System.Drawing.Point(79, 105)
        Me.lblDescripcio.Name = "lblDescripcio"
        Me.lblDescripcio.Size = New System.Drawing.Size(334, 122)
        Me.lblDescripcio.TabIndex = 4
        Me.lblDescripcio.Text = "Lblblue2"
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.ForeColor = System.Drawing.Color.Blue
        Me.lblCodi.Location = New System.Drawing.Point(79, 50)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(334, 55)
        Me.lblCodi.TabIndex = 6
        Me.lblCodi.Text = "Lblblue1"
        '
        'lblCaptionCodi
        '
        Me.lblCaptionCodi.AutoSize = True
        Me.lblCaptionCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionCodi.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionCodi.Location = New System.Drawing.Point(12, 50)
        Me.lblCaptionCodi.Name = "lblCaptionCodi"
        Me.lblCaptionCodi.Size = New System.Drawing.Size(61, 18)
        Me.lblCaptionCodi.TabIndex = 5
        Me.lblCaptionCodi.Text = "Lblright1"
        Me.lblCaptionCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 270)
        Me.Controls.Add(Me.lblCodi)
        Me.Controls.Add(Me.lblCaptionCodi)
        Me.Controls.Add(Me.lblDescripcio)
        Me.Controls.Add(Me.lblCaptionDescripcio)
        Me.Controls.Add(Me.lblTipus)
        Me.Controls.Add(Me.lblCaptionTipus)
        Me.Controls.Add(Me.cmdTancar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dLog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dLog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdTancar As BOTO
    Friend WithEvents lblCaptionTipus As LBLRIGHT
    Friend WithEvents lblTipus As LBLBLUE
    Friend WithEvents lblCaptionDescripcio As LBLRIGHT
    Friend WithEvents lblDescripcio As LBLBLUE
    Friend WithEvents lblCodi As LBLBLUE
    Friend WithEvents lblCaptionCodi As LBLRIGHT
End Class
