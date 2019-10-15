<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAvis
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
        Me.lblComptador = New System.Windows.Forms.Label()
        Me.lblMissatge = New System.Windows.Forms.Label()
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblComptador
        '
        Me.lblComptador.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComptador.ForeColor = System.Drawing.Color.Blue
        Me.lblComptador.Location = New System.Drawing.Point(17, 149)
        Me.lblComptador.Name = "lblComptador"
        Me.lblComptador.Size = New System.Drawing.Size(432, 30)
        Me.lblComptador.TabIndex = 5
        Me.lblComptador.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblMissatge
        '
        Me.lblMissatge.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblMissatge.ForeColor = System.Drawing.Color.Red
        Me.lblMissatge.Location = New System.Drawing.Point(50, 76)
        Me.lblMissatge.Name = "lblMissatge"
        Me.lblMissatge.Size = New System.Drawing.Size(399, 64)
        Me.lblMissatge.TabIndex = 4
        '
        'lblTitol
        '
        Me.lblTitol.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.Location = New System.Drawing.Point(13, 10)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(436, 48)
        Me.lblTitol.TabIndex = 3
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'frmAvis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblComptador)
        Me.Controls.Add(Me.lblMissatge)
        Me.Controls.Add(Me.lblTitol)
        Me.Name = "frmAvis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAvis"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblComptador As Label
    Friend WithEvents lblMissatge As Label
    Friend WithEvents lblTitol As Label
End Class
