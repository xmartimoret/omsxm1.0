<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dBorrarDades
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
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.lblErrorMes = New System.Windows.Forms.Label()
        Me.cbMes = New System.Windows.Forms.ComboBox()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.lblErrorAny = New System.Windows.Forms.Label()
        Me.cbAny = New System.Windows.Forms.ComboBox()
        Me.lblAny = New System.Windows.Forms.Label()
        Me.lblErrorEmpresa = New System.Windows.Forms.Label()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.xecLog = New System.Windows.Forms.CheckBox()
        Me.xecAny = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdGuardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(106, 125)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(96, 45)
        Me.cmdGuardar.TabIndex = 3
        Me.cmdGuardar.Text = "ESBORRAR"
        '
        'lblErrorMes
        '
        Me.lblErrorMes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorMes.ForeColor = System.Drawing.Color.Red
        Me.lblErrorMes.Location = New System.Drawing.Point(305, 73)
        Me.lblErrorMes.Name = "lblErrorMes"
        Me.lblErrorMes.Size = New System.Drawing.Size(114, 20)
        Me.lblErrorMes.TabIndex = 17
        Me.lblErrorMes.Text = "(*)OBLIGATORI"
        Me.lblErrorMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbMes
        '
        Me.cbMes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMes.ForeColor = System.Drawing.Color.Blue
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(106, 69)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(181, 24)
        Me.cbMes.TabIndex = 2
        '
        'lblMes
        '
        Me.lblMes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.Location = New System.Drawing.Point(13, 68)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(87, 20)
        Me.lblMes.TabIndex = 16
        Me.lblMes.Text = "Empresa:"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrorAny
        '
        Me.lblErrorAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrorAny.Location = New System.Drawing.Point(305, 43)
        Me.lblErrorAny.Name = "lblErrorAny"
        Me.lblErrorAny.Size = New System.Drawing.Size(114, 20)
        Me.lblErrorAny.TabIndex = 15
        Me.lblErrorAny.Text = "(*)OBLIGATORI"
        Me.lblErrorAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAny
        '
        Me.cbAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAny.ForeColor = System.Drawing.Color.Blue
        Me.cbAny.FormattingEnabled = True
        Me.cbAny.Location = New System.Drawing.Point(106, 39)
        Me.cbAny.Name = "cbAny"
        Me.cbAny.Size = New System.Drawing.Size(111, 24)
        Me.cbAny.TabIndex = 1
        '
        'lblAny
        '
        Me.lblAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.Location = New System.Drawing.Point(13, 38)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(87, 20)
        Me.lblAny.TabIndex = 14
        Me.lblAny.Text = "Empresa:"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrorEmpresa
        '
        Me.lblErrorEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorEmpresa.ForeColor = System.Drawing.Color.Red
        Me.lblErrorEmpresa.Location = New System.Drawing.Point(305, 13)
        Me.lblErrorEmpresa.Name = "lblErrorEmpresa"
        Me.lblErrorEmpresa.Size = New System.Drawing.Size(114, 20)
        Me.lblErrorEmpresa.TabIndex = 13
        Me.lblErrorEmpresa.Text = "(*)OBLIGATORI"
        Me.lblErrorEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(106, 9)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(181, 24)
        Me.cbEmpresa.TabIndex = 0
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(13, 8)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(87, 20)
        Me.lblEmpresa.TabIndex = 10
        Me.lblEmpresa.Text = "Empresa:"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xecLog
        '
        Me.xecLog.AutoSize = True
        Me.xecLog.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xecLog.Location = New System.Drawing.Point(39, 181)
        Me.xecLog.Name = "xecLog"
        Me.xecLog.Size = New System.Drawing.Size(71, 20)
        Me.xecLog.TabIndex = 18
        Me.xecLog.Text = "xecAny"
        Me.xecLog.UseVisualStyleBackColor = True
        '
        'xecAny
        '
        Me.xecAny.AutoSize = True
        Me.xecAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xecAny.Location = New System.Drawing.Point(106, 99)
        Me.xecAny.Name = "xecAny"
        Me.xecAny.Size = New System.Drawing.Size(71, 20)
        Me.xecAny.TabIndex = 19
        Me.xecAny.Text = "xecAny"
        Me.xecAny.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(299, 125)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 45)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Text = "ESBORRAR"
        Me.cmdCancel.UseMnemonic = False
        '
        'dBorrarDades
        '
        Me.AcceptButton = Me.cmdGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 219)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.xecAny)
        Me.Controls.Add(Me.xecLog)
        Me.Controls.Add(Me.lblErrorMes)
        Me.Controls.Add(Me.cbMes)
        Me.Controls.Add(Me.lblMes)
        Me.Controls.Add(Me.lblErrorAny)
        Me.Controls.Add(Me.cbAny)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.lblErrorEmpresa)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dBorrarDades"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dBorrarDades"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents lblErrorMes As Label
    Friend WithEvents cbMes As ComboBox
    Friend WithEvents lblMes As Label
    Friend WithEvents lblErrorAny As Label
    Friend WithEvents cbAny As ComboBox
    Friend WithEvents lblAny As Label
    Friend WithEvents lblErrorEmpresa As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents xecLog As CheckBox
    Friend WithEvents xecAny As CheckBox
    Friend WithEvents cmdCancel As Button
End Class
