<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DProveidorContacte
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
        Me.lblPais = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.txtCodiPostal = New System.Windows.Forms.TextBox()
        Me.lblCodiPostal = New System.Windows.Forms.Label()
        Me.txtPoblacio = New System.Windows.Forms.TextBox()
        Me.lblPoblacio = New System.Windows.Forms.Label()
        Me.lblDireccio = New System.Windows.Forms.Label()
        Me.txtDireccio = New System.Windows.Forms.TextBox()
        Me.lblNomFiscal = New System.Windows.Forms.Label()
        Me.txtDepartament = New System.Windows.Forms.TextBox()
        Me.lblDepartament = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.txtTelefon1 = New System.Windows.Forms.TextBox()
        Me.lblTel1 = New System.Windows.Forms.Label()
        Me.txtTelefon2 = New System.Windows.Forms.TextBox()
        Me.lblTel2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.xecActiu = New OmsXM.XEC()
        Me.pPais = New System.Windows.Forms.Panel()
        Me.pProvincia = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'lblPais
        '
        Me.lblPais.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPais.Location = New System.Drawing.Point(396, 169)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(58, 23)
        Me.lblPais.TabIndex = 78
        Me.lblPais.Text = "lblPais"
        Me.lblPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProvincia
        '
        Me.lblProvincia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvincia.Location = New System.Drawing.Point(11, 165)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(141, 23)
        Me.lblProvincia.TabIndex = 76
        Me.lblProvincia.Text = "lblProvincia"
        Me.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodiPostal
        '
        Me.txtCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodiPostal.ForeColor = System.Drawing.Color.Blue
        Me.txtCodiPostal.Location = New System.Drawing.Point(557, 134)
        Me.txtCodiPostal.Name = "txtCodiPostal"
        Me.txtCodiPostal.Size = New System.Drawing.Size(141, 26)
        Me.txtCodiPostal.TabIndex = 4
        '
        'lblCodiPostal
        '
        Me.lblCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiPostal.Location = New System.Drawing.Point(480, 137)
        Me.lblCodiPostal.Name = "lblCodiPostal"
        Me.lblCodiPostal.Size = New System.Drawing.Size(71, 23)
        Me.lblCodiPostal.TabIndex = 73
        Me.lblCodiPostal.Text = "Label1"
        Me.lblCodiPostal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPoblacio
        '
        Me.txtPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPoblacio.ForeColor = System.Drawing.Color.Blue
        Me.txtPoblacio.Location = New System.Drawing.Point(158, 131)
        Me.txtPoblacio.Name = "txtPoblacio"
        Me.txtPoblacio.Size = New System.Drawing.Size(232, 26)
        Me.txtPoblacio.TabIndex = 3
        '
        'lblPoblacio
        '
        Me.lblPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoblacio.Location = New System.Drawing.Point(8, 131)
        Me.lblPoblacio.Name = "lblPoblacio"
        Me.lblPoblacio.Size = New System.Drawing.Size(141, 23)
        Me.lblPoblacio.TabIndex = 72
        Me.lblPoblacio.Text = "Label1"
        Me.lblPoblacio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDireccio
        '
        Me.lblDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccio.Location = New System.Drawing.Point(8, 98)
        Me.lblDireccio.Name = "lblDireccio"
        Me.lblDireccio.Size = New System.Drawing.Size(141, 26)
        Me.lblDireccio.TabIndex = 70
        Me.lblDireccio.Text = "Label1"
        Me.lblDireccio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDireccio
        '
        Me.txtDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDireccio.ForeColor = System.Drawing.Color.Blue
        Me.txtDireccio.Location = New System.Drawing.Point(158, 98)
        Me.txtDireccio.Name = "txtDireccio"
        Me.txtDireccio.Size = New System.Drawing.Size(540, 26)
        Me.txtDireccio.TabIndex = 2
        '
        'lblNomFiscal
        '
        Me.lblNomFiscal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomFiscal.Location = New System.Drawing.Point(8, 65)
        Me.lblNomFiscal.Name = "lblNomFiscal"
        Me.lblNomFiscal.Size = New System.Drawing.Size(141, 27)
        Me.lblNomFiscal.TabIndex = 68
        Me.lblNomFiscal.Text = "Label1"
        Me.lblNomFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDepartament
        '
        Me.txtDepartament.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDepartament.ForeColor = System.Drawing.Color.Blue
        Me.txtDepartament.Location = New System.Drawing.Point(158, 38)
        Me.txtDepartament.Name = "txtDepartament"
        Me.txtDepartament.Size = New System.Drawing.Size(340, 26)
        Me.txtDepartament.TabIndex = 0
        '
        'lblDepartament
        '
        Me.lblDepartament.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartament.Location = New System.Drawing.Point(8, 38)
        Me.lblDepartament.Name = "lblDepartament"
        Me.lblDepartament.Size = New System.Drawing.Size(141, 23)
        Me.lblDepartament.TabIndex = 63
        Me.lblDepartament.Text = "Label1"
        Me.lblDepartament.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(155, 9)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 62
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(8, 8)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(141, 23)
        Me.lblIdCaption.TabIndex = 61
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(158, 66)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(540, 26)
        Me.txtNom.TabIndex = 1
        '
        'txtTelefon1
        '
        Me.txtTelefon1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtTelefon1.ForeColor = System.Drawing.Color.Blue
        Me.txtTelefon1.Location = New System.Drawing.Point(158, 195)
        Me.txtTelefon1.Name = "txtTelefon1"
        Me.txtTelefon1.Size = New System.Drawing.Size(232, 26)
        Me.txtTelefon1.TabIndex = 7
        '
        'lblTel1
        '
        Me.lblTel1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTel1.Location = New System.Drawing.Point(8, 195)
        Me.lblTel1.Name = "lblTel1"
        Me.lblTel1.Size = New System.Drawing.Size(141, 23)
        Me.lblTel1.TabIndex = 80
        Me.lblTel1.Text = "lblTelefon1"
        Me.lblTel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTelefon2
        '
        Me.txtTelefon2.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtTelefon2.ForeColor = System.Drawing.Color.Blue
        Me.txtTelefon2.Location = New System.Drawing.Point(158, 227)
        Me.txtTelefon2.Name = "txtTelefon2"
        Me.txtTelefon2.Size = New System.Drawing.Size(232, 26)
        Me.txtTelefon2.TabIndex = 8
        '
        'lblTel2
        '
        Me.lblTel2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTel2.Location = New System.Drawing.Point(8, 227)
        Me.lblTel2.Name = "lblTel2"
        Me.lblTel2.Size = New System.Drawing.Size(141, 23)
        Me.lblTel2.TabIndex = 82
        Me.lblTel2.Text = "Label1"
        Me.lblTel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtEmail.ForeColor = System.Drawing.Color.Blue
        Me.txtEmail.Location = New System.Drawing.Point(158, 259)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(540, 26)
        Me.txtEmail.TabIndex = 9
        '
        'lblemail
        '
        Me.lblemail.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemail.Location = New System.Drawing.Point(8, 259)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(141, 23)
        Me.lblemail.TabIndex = 84
        Me.lblemail.Text = "Label1"
        Me.lblemail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(557, 418)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 14
        Me.cmdCancelar.Text = "Cancel"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(158, 418)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 13
        Me.cmdGuardar.Text = "OK"
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.Location = New System.Drawing.Point(8, 319)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(141, 40)
        Me.lblNotes.TabIndex = 88
        Me.lblNotes.Text = "Label1"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(158, 319)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(540, 82)
        Me.txtNotes.TabIndex = 12
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(158, 291)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 10
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'pPais
        '
        Me.pPais.Location = New System.Drawing.Point(466, 167)
        Me.pPais.Name = "pPais"
        Me.pPais.Size = New System.Drawing.Size(232, 29)
        Me.pPais.TabIndex = 90
        '
        'pProvincia
        '
        Me.pProvincia.Location = New System.Drawing.Point(158, 163)
        Me.pProvincia.Name = "pProvincia"
        Me.pProvincia.Size = New System.Drawing.Size(232, 29)
        Me.pProvincia.TabIndex = 89
        '
        'DProveidorContacte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 461)
        Me.Controls.Add(Me.pPais)
        Me.Controls.Add(Me.pProvincia)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblemail)
        Me.Controls.Add(Me.txtTelefon2)
        Me.Controls.Add(Me.lblTel2)
        Me.Controls.Add(Me.txtTelefon1)
        Me.Controls.Add(Me.lblTel1)
        Me.Controls.Add(Me.lblPais)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.txtCodiPostal)
        Me.Controls.Add(Me.lblCodiPostal)
        Me.Controls.Add(Me.txtPoblacio)
        Me.Controls.Add(Me.lblPoblacio)
        Me.Controls.Add(Me.lblDireccio)
        Me.Controls.Add(Me.txtDireccio)
        Me.Controls.Add(Me.lblNomFiscal)
        Me.Controls.Add(Me.txtDepartament)
        Me.Controls.Add(Me.lblDepartament)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.Controls.Add(Me.txtNom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DProveidorContacte"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DProveidorContacte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPais As Label
    Friend WithEvents lblProvincia As Label
    Friend WithEvents txtCodiPostal As TextBox
    Friend WithEvents lblCodiPostal As Label
    Friend WithEvents txtPoblacio As TextBox
    Friend WithEvents lblPoblacio As Label
    Friend WithEvents lblDireccio As Label
    Friend WithEvents txtDireccio As TextBox
    Friend WithEvents lblNomFiscal As Label
    Friend WithEvents txtDepartament As TextBox
    Friend WithEvents lblDepartament As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents txtTelefon1 As TextBox
    Friend WithEvents lblTel1 As Label
    Friend WithEvents txtTelefon2 As TextBox
    Friend WithEvents lblTel2 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblemail As Label
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents xecActiu As XEC
    Friend WithEvents pPais As Panel
    Friend WithEvents pProvincia As Panel
End Class
