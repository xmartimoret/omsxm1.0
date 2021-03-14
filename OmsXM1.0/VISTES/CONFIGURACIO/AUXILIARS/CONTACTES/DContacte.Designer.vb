<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DContacte
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
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.txtTelefon1 = New System.Windows.Forms.TextBox()
        Me.lblTel1 = New System.Windows.Forms.Label()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.txtCodiPostal = New System.Windows.Forms.TextBox()
        Me.lblCodiPostal = New System.Windows.Forms.Label()
        Me.txtPoblacio = New System.Windows.Forms.TextBox()
        Me.lblPoblacio = New System.Windows.Forms.Label()
        Me.lblDireccio = New System.Windows.Forms.Label()
        Me.txtDireccio = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.pProvincia = New System.Windows.Forms.Panel()
        Me.xecActiu = New OmsXM.XEC()
        Me.pPais = New System.Windows.Forms.Panel()
        Me.lblCognoms = New System.Windows.Forms.Label()
        Me.txtCognom1 = New System.Windows.Forms.TextBox()
        Me.txtCognom2 = New System.Windows.Forms.TextBox()
        Me.xecPredeterminat = New OmsXM.XEC()
        Me.SuspendLayout()
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.Location = New System.Drawing.Point(11, 373)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(141, 40)
        Me.lblNotes.TabIndex = 115
        Me.lblNotes.Text = "Label1"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(162, 373)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(540, 82)
        Me.txtNotes.TabIndex = 12
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(553, 469)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 14
        Me.cmdCancelar.Text = "Cancel"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(161, 469)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 13
        Me.cmdGuardar.Text = "OK"
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtemail.ForeColor = System.Drawing.Color.Blue
        Me.txtemail.Location = New System.Drawing.Point(161, 313)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(540, 26)
        Me.txtemail.TabIndex = 9
        '
        'lblemail
        '
        Me.lblemail.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemail.Location = New System.Drawing.Point(11, 313)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(141, 23)
        Me.lblemail.TabIndex = 114
        Me.lblemail.Text = "Label1"
        Me.lblemail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTelefon1
        '
        Me.txtTelefon1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtTelefon1.ForeColor = System.Drawing.Color.Blue
        Me.txtTelefon1.Location = New System.Drawing.Point(161, 280)
        Me.txtTelefon1.Name = "txtTelefon1"
        Me.txtTelefon1.Size = New System.Drawing.Size(232, 26)
        Me.txtTelefon1.TabIndex = 8
        '
        'lblTel1
        '
        Me.lblTel1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTel1.Location = New System.Drawing.Point(11, 280)
        Me.lblTel1.Name = "lblTel1"
        Me.lblTel1.Size = New System.Drawing.Size(141, 23)
        Me.lblTel1.TabIndex = 112
        Me.lblTel1.Text = "lblTelefon1"
        Me.lblTel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPais
        '
        Me.lblPais.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPais.Location = New System.Drawing.Point(405, 254)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(58, 23)
        Me.lblPais.TabIndex = 111
        Me.lblPais.Text = "lblPais"
        Me.lblPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProvincia
        '
        Me.lblProvincia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvincia.Location = New System.Drawing.Point(14, 250)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(141, 23)
        Me.lblProvincia.TabIndex = 110
        Me.lblProvincia.Text = "lblProvincia"
        Me.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodiPostal
        '
        Me.txtCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodiPostal.ForeColor = System.Drawing.Color.Blue
        Me.txtCodiPostal.Location = New System.Drawing.Point(560, 219)
        Me.txtCodiPostal.Name = "txtCodiPostal"
        Me.txtCodiPostal.Size = New System.Drawing.Size(141, 26)
        Me.txtCodiPostal.TabIndex = 5
        '
        'lblCodiPostal
        '
        Me.lblCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiPostal.Location = New System.Drawing.Point(483, 222)
        Me.lblCodiPostal.Name = "lblCodiPostal"
        Me.lblCodiPostal.Size = New System.Drawing.Size(71, 23)
        Me.lblCodiPostal.TabIndex = 109
        Me.lblCodiPostal.Text = "Label1"
        Me.lblCodiPostal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPoblacio
        '
        Me.txtPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPoblacio.ForeColor = System.Drawing.Color.Blue
        Me.txtPoblacio.Location = New System.Drawing.Point(161, 216)
        Me.txtPoblacio.Name = "txtPoblacio"
        Me.txtPoblacio.Size = New System.Drawing.Size(232, 26)
        Me.txtPoblacio.TabIndex = 4
        '
        'lblPoblacio
        '
        Me.lblPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoblacio.Location = New System.Drawing.Point(11, 216)
        Me.lblPoblacio.Name = "lblPoblacio"
        Me.lblPoblacio.Size = New System.Drawing.Size(141, 23)
        Me.lblPoblacio.TabIndex = 108
        Me.lblPoblacio.Text = "Label1"
        Me.lblPoblacio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDireccio
        '
        Me.lblDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccio.Location = New System.Drawing.Point(12, 97)
        Me.lblDireccio.Name = "lblDireccio"
        Me.lblDireccio.Size = New System.Drawing.Size(141, 40)
        Me.lblDireccio.TabIndex = 107
        Me.lblDireccio.Text = "Label1"
        Me.lblDireccio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDireccio
        '
        Me.txtDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDireccio.ForeColor = System.Drawing.Color.Blue
        Me.txtDireccio.Location = New System.Drawing.Point(162, 97)
        Me.txtDireccio.Multiline = True
        Me.txtDireccio.Name = "txtDireccio"
        Me.txtDireccio.Size = New System.Drawing.Size(539, 107)
        Me.txtDireccio.TabIndex = 3
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(12, 25)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(141, 40)
        Me.lblNom.TabIndex = 106
        Me.lblNom.Text = "Label1"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(159, 7)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 104
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(12, 6)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(141, 23)
        Me.lblIdCaption.TabIndex = 103
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(162, 33)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(259, 26)
        Me.txtNom.TabIndex = 0
        '
        'pProvincia
        '
        Me.pProvincia.Location = New System.Drawing.Point(161, 248)
        Me.pProvincia.Name = "pProvincia"
        Me.pProvincia.Size = New System.Drawing.Size(232, 29)
        Me.pProvincia.TabIndex = 6
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(161, 345)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 10
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'pPais
        '
        Me.pPais.Location = New System.Drawing.Point(469, 248)
        Me.pPais.Name = "pPais"
        Me.pPais.Size = New System.Drawing.Size(232, 29)
        Me.pPais.TabIndex = 7
        '
        'lblCognoms
        '
        Me.lblCognoms.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCognoms.Location = New System.Drawing.Point(12, 57)
        Me.lblCognoms.Name = "lblCognoms"
        Me.lblCognoms.Size = New System.Drawing.Size(141, 40)
        Me.lblCognoms.TabIndex = 118
        Me.lblCognoms.Text = "Label1"
        Me.lblCognoms.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCognom1
        '
        Me.txtCognom1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCognom1.ForeColor = System.Drawing.Color.Blue
        Me.txtCognom1.Location = New System.Drawing.Point(162, 65)
        Me.txtCognom1.Name = "txtCognom1"
        Me.txtCognom1.Size = New System.Drawing.Size(259, 26)
        Me.txtCognom1.TabIndex = 1
        '
        'txtCognom2
        '
        Me.txtCognom2.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCognom2.ForeColor = System.Drawing.Color.Blue
        Me.txtCognom2.Location = New System.Drawing.Point(427, 65)
        Me.txtCognom2.Name = "txtCognom2"
        Me.txtCognom2.Size = New System.Drawing.Size(275, 26)
        Me.txtCognom2.TabIndex = 2
        '
        'xecPredeterminat
        '
        Me.xecPredeterminat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xecPredeterminat.AutoSize = True
        Me.xecPredeterminat.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecPredeterminat.ForeColor = System.Drawing.Color.Black
        Me.xecPredeterminat.Location = New System.Drawing.Point(553, 345)
        Me.xecPredeterminat.Name = "xecPredeterminat"
        Me.xecPredeterminat.Size = New System.Drawing.Size(141, 22)
        Me.xecPredeterminat.TabIndex = 11
        Me.xecPredeterminat.Text = "xecPredeterminat"
        Me.xecPredeterminat.UseVisualStyleBackColor = True
        '
        'DContacte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 512)
        Me.Controls.Add(Me.xecPredeterminat)
        Me.Controls.Add(Me.txtCognom2)
        Me.Controls.Add(Me.lblCognoms)
        Me.Controls.Add(Me.txtCognom1)
        Me.Controls.Add(Me.pPais)
        Me.Controls.Add(Me.pProvincia)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.lblemail)
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
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.Controls.Add(Me.txtNom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DContacte"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DProjecteContacte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents xecActiu As XEC
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents txtemail As TextBox
    Friend WithEvents lblemail As Label
    Friend WithEvents txtTelefon1 As TextBox
    Friend WithEvents lblTel1 As Label
    Friend WithEvents lblPais As Label
    Friend WithEvents lblProvincia As Label
    Friend WithEvents txtCodiPostal As TextBox
    Friend WithEvents lblCodiPostal As Label
    Friend WithEvents txtPoblacio As TextBox
    Friend WithEvents lblPoblacio As Label
    Friend WithEvents lblDireccio As Label
    Friend WithEvents txtDireccio As TextBox
    Friend WithEvents lblNom As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents pProvincia As Panel
    Friend WithEvents pPais As Panel
    Friend WithEvents lblCognoms As Label
    Friend WithEvents txtCognom1 As TextBox
    Friend WithEvents txtCognom2 As TextBox
    Friend WithEvents xecPredeterminat As XEC
End Class
