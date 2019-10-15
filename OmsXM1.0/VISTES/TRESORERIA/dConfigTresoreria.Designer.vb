<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dConfigTresoreria
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
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.lblCobros = New OmsXM.LBLRIGHT()
        Me.txtCobros = New OmsXM.TXT()
        Me.lblPagaments = New OmsXM.LBLRIGHT()
        Me.txtPagaments = New OmsXM.TXT()
        Me.lblColumna = New OmsXM.LBLRIGHT()
        Me.txtColumna = New OmsXM.TXT()
        Me.lblNom = New OmsXM.LBLRIGHT()
        Me.txtNom = New OmsXM.TXT()
        Me.xecNom = New OmsXM.XEC()
        Me.gbImportacio = New System.Windows.Forms.GroupBox()
        Me.gbResum = New System.Windows.Forms.GroupBox()
        Me.txtFullaDades = New OmsXM.TXT()
        Me.lblFullDades = New OmsXM.LBLRIGHT()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.gbImportacio.SuspendLayout()
        Me.gbResum.SuspendLayout()
        Me.SuspendLayout()
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
        Me.cmdCancelar.Location = New System.Drawing.Point(407, 309)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(109, 30)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'lblCobros
        '
        Me.lblCobros.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobros.ForeColor = System.Drawing.Color.Black
        Me.lblCobros.Location = New System.Drawing.Point(4, 15)
        Me.lblCobros.Name = "lblCobros"
        Me.lblCobros.Size = New System.Drawing.Size(326, 24)
        Me.lblCobros.TabIndex = 2
        Me.lblCobros.Text = "Lblright1"
        Me.lblCobros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCobros
        '
        Me.txtCobros.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCobros.ForeColor = System.Drawing.Color.Blue
        Me.txtCobros.Location = New System.Drawing.Point(336, 13)
        Me.txtCobros.Name = "txtCobros"
        Me.txtCobros.Size = New System.Drawing.Size(154, 26)
        Me.txtCobros.TabIndex = 3
        '
        'lblPagaments
        '
        Me.lblPagaments.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagaments.ForeColor = System.Drawing.Color.Black
        Me.lblPagaments.Location = New System.Drawing.Point(4, 47)
        Me.lblPagaments.Name = "lblPagaments"
        Me.lblPagaments.Size = New System.Drawing.Size(326, 24)
        Me.lblPagaments.TabIndex = 4
        Me.lblPagaments.Text = "Lblright2"
        Me.lblPagaments.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPagaments
        '
        Me.txtPagaments.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPagaments.ForeColor = System.Drawing.Color.Blue
        Me.txtPagaments.Location = New System.Drawing.Point(336, 45)
        Me.txtPagaments.Name = "txtPagaments"
        Me.txtPagaments.Size = New System.Drawing.Size(154, 26)
        Me.txtPagaments.TabIndex = 5
        '
        'lblColumna
        '
        Me.lblColumna.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColumna.ForeColor = System.Drawing.Color.Black
        Me.lblColumna.Location = New System.Drawing.Point(14, 79)
        Me.lblColumna.Name = "lblColumna"
        Me.lblColumna.Size = New System.Drawing.Size(316, 24)
        Me.lblColumna.TabIndex = 6
        Me.lblColumna.Text = "Lblright3"
        Me.lblColumna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtColumna
        '
        Me.txtColumna.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtColumna.ForeColor = System.Drawing.Color.Blue
        Me.txtColumna.Location = New System.Drawing.Point(336, 77)
        Me.txtColumna.Name = "txtColumna"
        Me.txtColumna.Size = New System.Drawing.Size(154, 26)
        Me.txtColumna.TabIndex = 7
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.ForeColor = System.Drawing.Color.Black
        Me.lblNom.Location = New System.Drawing.Point(4, 141)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(326, 24)
        Me.lblNom.TabIndex = 8
        Me.lblNom.Text = "Lblright4"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(336, 139)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(97, 26)
        Me.txtNom.TabIndex = 9
        '
        'xecNom
        '
        Me.xecNom.Cursor = System.Windows.Forms.Cursors.Default
        Me.xecNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecNom.ForeColor = System.Drawing.Color.Black
        Me.xecNom.Location = New System.Drawing.Point(75, 111)
        Me.xecNom.Name = "xecNom"
        Me.xecNom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.xecNom.Size = New System.Drawing.Size(275, 22)
        Me.xecNom.TabIndex = 10
        Me.xecNom.Text = "Xec1"
        Me.xecNom.UseVisualStyleBackColor = True
        '
        'gbImportacio
        '
        Me.gbImportacio.Controls.Add(Me.xecNom)
        Me.gbImportacio.Controls.Add(Me.txtNom)
        Me.gbImportacio.Controls.Add(Me.lblNom)
        Me.gbImportacio.Controls.Add(Me.txtColumna)
        Me.gbImportacio.Controls.Add(Me.lblColumna)
        Me.gbImportacio.Controls.Add(Me.txtPagaments)
        Me.gbImportacio.Controls.Add(Me.lblPagaments)
        Me.gbImportacio.Controls.Add(Me.txtCobros)
        Me.gbImportacio.Controls.Add(Me.lblCobros)
        Me.gbImportacio.Location = New System.Drawing.Point(12, 12)
        Me.gbImportacio.Name = "gbImportacio"
        Me.gbImportacio.Size = New System.Drawing.Size(504, 187)
        Me.gbImportacio.TabIndex = 4
        Me.gbImportacio.TabStop = False
        Me.gbImportacio.Text = "GroupBox1"
        '
        'gbResum
        '
        Me.gbResum.Controls.Add(Me.txtFullaDades)
        Me.gbResum.Controls.Add(Me.lblFullDades)
        Me.gbResum.Location = New System.Drawing.Point(11, 205)
        Me.gbResum.Name = "gbResum"
        Me.gbResum.Size = New System.Drawing.Size(505, 87)
        Me.gbResum.TabIndex = 5
        Me.gbResum.TabStop = False
        Me.gbResum.Text = "GroupBox2"
        '
        'txtFullaDades
        '
        Me.txtFullaDades.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFullaDades.ForeColor = System.Drawing.Color.Blue
        Me.txtFullaDades.Location = New System.Drawing.Point(337, 19)
        Me.txtFullaDades.Name = "txtFullaDades"
        Me.txtFullaDades.Size = New System.Drawing.Size(154, 26)
        Me.txtFullaDades.TabIndex = 3
        '
        'lblFullDades
        '
        Me.lblFullDades.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullDades.ForeColor = System.Drawing.Color.Black
        Me.lblFullDades.Location = New System.Drawing.Point(50, 19)
        Me.lblFullDades.Name = "lblFullDades"
        Me.lblFullDades.Size = New System.Drawing.Size(281, 24)
        Me.lblFullDades.TabIndex = 2
        Me.lblFullDades.Text = "Lblright8"
        Me.lblFullDades.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardar
        '
        Me.cmdGuardar.AutoSize = True
        Me.cmdGuardar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(27, 309)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(109, 30)
        Me.cmdGuardar.TabIndex = 6
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'dConfigTresoreria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 352)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.gbResum)
        Me.Controls.Add(Me.gbImportacio)
        Me.Controls.Add(Me.cmdCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dConfigTresoreria"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dConfigTresoreria"
        Me.gbImportacio.ResumeLayout(False)
        Me.gbImportacio.PerformLayout()
        Me.gbResum.ResumeLayout(False)
        Me.gbResum.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents lblCobros As LBLRIGHT
    Friend WithEvents txtCobros As TXT
    Friend WithEvents lblPagaments As LBLRIGHT
    Friend WithEvents txtPagaments As TXT
    Friend WithEvents lblColumna As LBLRIGHT
    Friend WithEvents txtColumna As TXT
    Friend WithEvents lblNom As LBLRIGHT
    Friend WithEvents txtNom As TXT
    Friend WithEvents xecNom As XEC
    Friend WithEvents gbImportacio As GroupBox
    Friend WithEvents gbResum As GroupBox
    Friend WithEvents txtFullaDades As TXT
    Friend WithEvents lblFullDades As LBLRIGHT
    Friend WithEvents cmdGuardar As BOTO
End Class
