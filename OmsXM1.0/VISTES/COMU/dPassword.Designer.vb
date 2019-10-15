<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class dPassword
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmdAcceptar = New OmsXM.BOTO()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.lblClau = New OmsXM.LBLRIGHT()
        Me.txtClau = New OmsXM.TXT()
        Me.SuspendLayout()
        '
        'cmdAcceptar
        '
        Me.cmdAcceptar.AutoSize = True
        Me.cmdAcceptar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdAcceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAcceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdAcceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAcceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAcceptar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdAcceptar.Location = New System.Drawing.Point(45, 75)
        Me.cmdAcceptar.Name = "cmdAcceptar"
        Me.cmdAcceptar.Size = New System.Drawing.Size(106, 30)
        Me.cmdAcceptar.TabIndex = 0
        Me.cmdAcceptar.Text = "Boto1"
        Me.cmdAcceptar.UseVisualStyleBackColor = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(181, 75)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(119, 30)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'lblClau
        '
        Me.lblClau.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClau.ForeColor = System.Drawing.Color.Black
        Me.lblClau.Location = New System.Drawing.Point(12, 32)
        Me.lblClau.Name = "lblClau"
        Me.lblClau.Size = New System.Drawing.Size(135, 18)
        Me.lblClau.TabIndex = 2
        Me.lblClau.Text = "Lblright1"
        Me.lblClau.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtClau
        '
        Me.txtClau.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtClau.ForeColor = System.Drawing.Color.Blue
        Me.txtClau.Location = New System.Drawing.Point(153, 24)
        Me.txtClau.Name = "txtClau"
        Me.txtClau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClau.Size = New System.Drawing.Size(147, 26)
        Me.txtClau.TabIndex = 3
        '
        'dPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 121)
        Me.Controls.Add(Me.txtClau)
        Me.Controls.Add(Me.lblClau)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAcceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dPassword"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LoginForm1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdAcceptar As BOTO
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents lblClau As LBLRIGHT
    Friend WithEvents txtClau As TXT
End Class
