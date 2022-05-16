<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DProveidor
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
        Me.lblErrCif = New System.Windows.Forms.Label()
        Me.txtCif = New System.Windows.Forms.TextBox()
        Me.lblCif = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblErrNom = New System.Windows.Forms.Label()
        Me.txtNomComercial = New System.Windows.Forms.TextBox()
        Me.lblNomComercial = New System.Windows.Forms.Label()
        Me.txtNomFiscal = New System.Windows.Forms.TextBox()
        Me.lblNomFiscal = New System.Windows.Forms.Label()
        Me.txtDireccio = New System.Windows.Forms.TextBox()
        Me.lblDireccio = New System.Windows.Forms.Label()
        Me.txtPoblacio = New System.Windows.Forms.TextBox()
        Me.lblPoblacio = New System.Windows.Forms.Label()
        Me.lblCodiPostal = New System.Windows.Forms.Label()
        Me.txtCodiPostal = New System.Windows.Forms.TextBox()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.lblTipusPagament = New System.Windows.Forms.Label()
        Me.gbDadesBancaries = New System.Windows.Forms.GroupBox()
        Me.pTPagament = New System.Windows.Forms.Panel()
        Me.txtIban3 = New System.Windows.Forms.TextBox()
        Me.lblIban3 = New System.Windows.Forms.Label()
        Me.txtIban2 = New System.Windows.Forms.TextBox()
        Me.lblIban2 = New System.Windows.Forms.Label()
        Me.txtIban1 = New System.Windows.Forms.TextBox()
        Me.lblIban1 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.pProvincia = New System.Windows.Forms.Panel()
        Me.pPais = New System.Windows.Forms.Panel()
        Me.txtCodiComptable = New System.Windows.Forms.TextBox()
        Me.lblCodiComptable = New System.Windows.Forms.Label()
        Me.lblErrCodiComptable = New System.Windows.Forms.Label()
        Me.xecActiu = New OmsXM.XEC()
        Me.xecNoValidar = New OmsXM.XEC()
        Me.cmdImprimirExcel = New System.Windows.Forms.Button()
        Me.cmdImprimirPDF = New System.Windows.Forms.Button()
        Me.gbDadesBancaries.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblErrCif
        '
        Me.lblErrCif.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCif.ForeColor = System.Drawing.Color.Red
        Me.lblErrCif.Location = New System.Drawing.Point(340, 41)
        Me.lblErrCif.Name = "lblErrCif"
        Me.lblErrCif.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCif.TabIndex = 43
        Me.lblErrCif.Text = "(*) OBLIGATPORI"
        Me.lblErrCif.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCif
        '
        Me.txtCif.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCif.ForeColor = System.Drawing.Color.Blue
        Me.txtCif.Location = New System.Drawing.Point(166, 41)
        Me.txtCif.Name = "txtCif"
        Me.txtCif.Size = New System.Drawing.Size(153, 26)
        Me.txtCif.TabIndex = 0
        '
        'lblCif
        '
        Me.lblCif.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCif.Location = New System.Drawing.Point(16, 41)
        Me.lblCif.Name = "lblCif"
        Me.lblCif.Size = New System.Drawing.Size(141, 23)
        Me.lblCif.TabIndex = 42
        Me.lblCif.Text = "Label1"
        Me.lblCif.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(163, 12)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 41
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(16, 11)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(141, 23)
        Me.lblIdCaption.TabIndex = 40
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(96, 483)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 15
        Me.cmdGuardar.Text = "OK"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(558, 483)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 16
        Me.cmdCancelar.Text = "Cancel"
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(570, 72)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(136, 23)
        Me.lblErrNom.TabIndex = 46
        Me.lblErrNom.Text = "(*) OBLIGATPORI"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNomComercial
        '
        Me.txtNomComercial.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNomComercial.ForeColor = System.Drawing.Color.Blue
        Me.txtNomComercial.Location = New System.Drawing.Point(166, 128)
        Me.txtNomComercial.Name = "txtNomComercial"
        Me.txtNomComercial.Size = New System.Drawing.Size(540, 26)
        Me.txtNomComercial.TabIndex = 3
        '
        'lblNomComercial
        '
        Me.lblNomComercial.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomComercial.Location = New System.Drawing.Point(20, 132)
        Me.lblNomComercial.Name = "lblNomComercial"
        Me.lblNomComercial.Size = New System.Drawing.Size(141, 23)
        Me.lblNomComercial.TabIndex = 45
        Me.lblNomComercial.Text = "Label1"
        Me.lblNomComercial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNomFiscal
        '
        Me.txtNomFiscal.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNomFiscal.ForeColor = System.Drawing.Color.Blue
        Me.txtNomFiscal.Location = New System.Drawing.Point(166, 98)
        Me.txtNomFiscal.Name = "txtNomFiscal"
        Me.txtNomFiscal.Size = New System.Drawing.Size(540, 26)
        Me.txtNomFiscal.TabIndex = 2
        '
        'lblNomFiscal
        '
        Me.lblNomFiscal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomFiscal.Location = New System.Drawing.Point(16, 98)
        Me.lblNomFiscal.Name = "lblNomFiscal"
        Me.lblNomFiscal.Size = New System.Drawing.Size(141, 27)
        Me.lblNomFiscal.TabIndex = 48
        Me.lblNomFiscal.Text = "Label1"
        Me.lblNomFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDireccio
        '
        Me.txtDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDireccio.ForeColor = System.Drawing.Color.Blue
        Me.txtDireccio.Location = New System.Drawing.Point(166, 158)
        Me.txtDireccio.Name = "txtDireccio"
        Me.txtDireccio.Size = New System.Drawing.Size(540, 26)
        Me.txtDireccio.TabIndex = 4
        '
        'lblDireccio
        '
        Me.lblDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccio.Location = New System.Drawing.Point(16, 162)
        Me.lblDireccio.Name = "lblDireccio"
        Me.lblDireccio.Size = New System.Drawing.Size(141, 26)
        Me.lblDireccio.TabIndex = 50
        Me.lblDireccio.Text = "Label1"
        Me.lblDireccio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPoblacio
        '
        Me.txtPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPoblacio.ForeColor = System.Drawing.Color.Blue
        Me.txtPoblacio.Location = New System.Drawing.Point(166, 196)
        Me.txtPoblacio.Name = "txtPoblacio"
        Me.txtPoblacio.Size = New System.Drawing.Size(232, 26)
        Me.txtPoblacio.TabIndex = 5
        '
        'lblPoblacio
        '
        Me.lblPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoblacio.Location = New System.Drawing.Point(20, 197)
        Me.lblPoblacio.Name = "lblPoblacio"
        Me.lblPoblacio.Size = New System.Drawing.Size(141, 23)
        Me.lblPoblacio.TabIndex = 52
        Me.lblPoblacio.Text = "Label1"
        Me.lblPoblacio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodiPostal
        '
        Me.lblCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiPostal.Location = New System.Drawing.Point(489, 202)
        Me.lblCodiPostal.Name = "lblCodiPostal"
        Me.lblCodiPostal.Size = New System.Drawing.Size(71, 23)
        Me.lblCodiPostal.TabIndex = 53
        Me.lblCodiPostal.Text = "Label1"
        Me.lblCodiPostal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodiPostal
        '
        Me.txtCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodiPostal.ForeColor = System.Drawing.Color.Blue
        Me.txtCodiPostal.Location = New System.Drawing.Point(566, 198)
        Me.txtCodiPostal.Name = "txtCodiPostal"
        Me.txtCodiPostal.Size = New System.Drawing.Size(141, 26)
        Me.txtCodiPostal.TabIndex = 6
        '
        'lblProvincia
        '
        Me.lblProvincia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvincia.Location = New System.Drawing.Point(20, 229)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(141, 23)
        Me.lblProvincia.TabIndex = 56
        Me.lblProvincia.Text = "lblProvincia"
        Me.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPais
        '
        Me.lblPais.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPais.Location = New System.Drawing.Point(405, 233)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(58, 23)
        Me.lblPais.TabIndex = 58
        Me.lblPais.Text = "lblPais"
        Me.lblPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipusPagament
        '
        Me.lblTipusPagament.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipusPagament.Location = New System.Drawing.Point(0, 21)
        Me.lblTipusPagament.Name = "lblTipusPagament"
        Me.lblTipusPagament.Size = New System.Drawing.Size(139, 23)
        Me.lblTipusPagament.TabIndex = 60
        Me.lblTipusPagament.Text = "lblProvincia"
        Me.lblTipusPagament.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbDadesBancaries
        '
        Me.gbDadesBancaries.Controls.Add(Me.pTPagament)
        Me.gbDadesBancaries.Controls.Add(Me.txtIban3)
        Me.gbDadesBancaries.Controls.Add(Me.lblIban3)
        Me.gbDadesBancaries.Controls.Add(Me.txtIban2)
        Me.gbDadesBancaries.Controls.Add(Me.lblIban2)
        Me.gbDadesBancaries.Controls.Add(Me.txtIban1)
        Me.gbDadesBancaries.Controls.Add(Me.lblIban1)
        Me.gbDadesBancaries.Controls.Add(Me.lblTipusPagament)
        Me.gbDadesBancaries.Location = New System.Drawing.Point(97, 290)
        Me.gbDadesBancaries.Name = "gbDadesBancaries"
        Me.gbDadesBancaries.Size = New System.Drawing.Size(610, 151)
        Me.gbDadesBancaries.TabIndex = 10
        Me.gbDadesBancaries.TabStop = False
        Me.gbDadesBancaries.Text = "GroupBox1"
        '
        'pTPagament
        '
        Me.pTPagament.Location = New System.Drawing.Point(145, 15)
        Me.pTPagament.Name = "pTPagament"
        Me.pTPagament.Size = New System.Drawing.Size(454, 29)
        Me.pTPagament.TabIndex = 10
        '
        'txtIban3
        '
        Me.txtIban3.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtIban3.ForeColor = System.Drawing.Color.Blue
        Me.txtIban3.Location = New System.Drawing.Point(145, 114)
        Me.txtIban3.Name = "txtIban3"
        Me.txtIban3.Size = New System.Drawing.Size(454, 26)
        Me.txtIban3.TabIndex = 13
        '
        'lblIban3
        '
        Me.lblIban3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIban3.Location = New System.Drawing.Point(65, 115)
        Me.lblIban3.Name = "lblIban3"
        Me.lblIban3.Size = New System.Drawing.Size(71, 23)
        Me.lblIban3.TabIndex = 66
        Me.lblIban3.Text = "Label1"
        Me.lblIban3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIban2
        '
        Me.txtIban2.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtIban2.ForeColor = System.Drawing.Color.Blue
        Me.txtIban2.Location = New System.Drawing.Point(145, 82)
        Me.txtIban2.Name = "txtIban2"
        Me.txtIban2.Size = New System.Drawing.Size(454, 26)
        Me.txtIban2.TabIndex = 12
        '
        'lblIban2
        '
        Me.lblIban2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIban2.Location = New System.Drawing.Point(65, 83)
        Me.lblIban2.Name = "lblIban2"
        Me.lblIban2.Size = New System.Drawing.Size(71, 23)
        Me.lblIban2.TabIndex = 64
        Me.lblIban2.Text = "Label1"
        Me.lblIban2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIban1
        '
        Me.txtIban1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtIban1.ForeColor = System.Drawing.Color.Blue
        Me.txtIban1.Location = New System.Drawing.Point(145, 50)
        Me.txtIban1.Name = "txtIban1"
        Me.txtIban1.Size = New System.Drawing.Size(454, 26)
        Me.txtIban1.TabIndex = 11
        '
        'lblIban1
        '
        Me.lblIban1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIban1.Location = New System.Drawing.Point(65, 51)
        Me.lblIban1.Name = "lblIban1"
        Me.lblIban1.Size = New System.Drawing.Size(71, 23)
        Me.lblIban1.TabIndex = 62
        Me.lblIban1.Text = "Label1"
        Me.lblIban1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtEmail.ForeColor = System.Drawing.Color.Blue
        Me.txtEmail.Location = New System.Drawing.Point(166, 259)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(540, 26)
        Me.txtEmail.TabIndex = 9
        '
        'lblEmail
        '
        Me.lblEmail.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(16, 259)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(141, 23)
        Me.lblEmail.TabIndex = 63
        Me.lblEmail.Text = "Label1"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pProvincia
        '
        Me.pProvincia.Location = New System.Drawing.Point(166, 223)
        Me.pProvincia.Name = "pProvincia"
        Me.pProvincia.Size = New System.Drawing.Size(232, 29)
        Me.pProvincia.TabIndex = 7
        '
        'pPais
        '
        Me.pPais.Location = New System.Drawing.Point(475, 228)
        Me.pPais.Name = "pPais"
        Me.pPais.Size = New System.Drawing.Size(232, 29)
        Me.pPais.TabIndex = 8
        '
        'txtCodiComptable
        '
        Me.txtCodiComptable.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodiComptable.ForeColor = System.Drawing.Color.Blue
        Me.txtCodiComptable.Location = New System.Drawing.Point(166, 70)
        Me.txtCodiComptable.Name = "txtCodiComptable"
        Me.txtCodiComptable.Size = New System.Drawing.Size(153, 26)
        Me.txtCodiComptable.TabIndex = 1
        '
        'lblCodiComptable
        '
        Me.lblCodiComptable.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiComptable.Location = New System.Drawing.Point(7, 70)
        Me.lblCodiComptable.Name = "lblCodiComptable"
        Me.lblCodiComptable.Size = New System.Drawing.Size(150, 23)
        Me.lblCodiComptable.TabIndex = 65
        Me.lblCodiComptable.Text = "Label1"
        Me.lblCodiComptable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrCodiComptable
        '
        Me.lblErrCodiComptable.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodiComptable.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodiComptable.Location = New System.Drawing.Point(340, 72)
        Me.lblErrCodiComptable.Name = "lblErrCodiComptable"
        Me.lblErrCodiComptable.Size = New System.Drawing.Size(136, 23)
        Me.lblErrCodiComptable.TabIndex = 66
        Me.lblErrCodiComptable.Text = "(*) OBLIGATPORI"
        Me.lblErrCodiComptable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(146, 450)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 14
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'xecNoValidar
        '
        Me.xecNoValidar.AutoSize = True
        Me.xecNoValidar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecNoValidar.ForeColor = System.Drawing.Color.Black
        Me.xecNoValidar.Location = New System.Drawing.Point(558, 41)
        Me.xecNoValidar.Name = "xecNoValidar"
        Me.xecNoValidar.Size = New System.Drawing.Size(161, 22)
        Me.xecNoValidar.TabIndex = 67
        Me.xecNoValidar.Text = "No validar document"
        Me.xecNoValidar.UseVisualStyleBackColor = True
        '
        'cmdImprimirExcel
        '
        Me.cmdImprimirExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimirExcel.Image = Global.OmsXM.My.Resources.Resources.excel
        Me.cmdImprimirExcel.Location = New System.Drawing.Point(680, 6)
        Me.cmdImprimirExcel.Name = "cmdImprimirExcel"
        Me.cmdImprimirExcel.Size = New System.Drawing.Size(26, 28)
        Me.cmdImprimirExcel.TabIndex = 69
        Me.cmdImprimirExcel.UseVisualStyleBackColor = True
        '
        'cmdImprimirPDF
        '
        Me.cmdImprimirPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimirPDF.Image = Global.OmsXM.My.Resources.Resources.pdf
        Me.cmdImprimirPDF.Location = New System.Drawing.Point(711, 6)
        Me.cmdImprimirPDF.Name = "cmdImprimirPDF"
        Me.cmdImprimirPDF.Size = New System.Drawing.Size(32, 28)
        Me.cmdImprimirPDF.TabIndex = 68
        Me.cmdImprimirPDF.UseVisualStyleBackColor = True
        '
        'DProveidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 526)
        Me.Controls.Add(Me.cmdImprimirExcel)
        Me.Controls.Add(Me.cmdImprimirPDF)
        Me.Controls.Add(Me.xecNoValidar)
        Me.Controls.Add(Me.lblErrCodiComptable)
        Me.Controls.Add(Me.txtCodiComptable)
        Me.Controls.Add(Me.lblCodiComptable)
        Me.Controls.Add(Me.pPais)
        Me.Controls.Add(Me.pProvincia)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.gbDadesBancaries)
        Me.Controls.Add(Me.lblPais)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.txtCodiPostal)
        Me.Controls.Add(Me.lblCodiPostal)
        Me.Controls.Add(Me.txtPoblacio)
        Me.Controls.Add(Me.lblPoblacio)
        Me.Controls.Add(Me.lblDireccio)
        Me.Controls.Add(Me.txtDireccio)
        Me.Controls.Add(Me.lblNomFiscal)
        Me.Controls.Add(Me.lblErrCif)
        Me.Controls.Add(Me.txtCif)
        Me.Controls.Add(Me.lblCif)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.txtNomComercial)
        Me.Controls.Add(Me.lblNomComercial)
        Me.Controls.Add(Me.txtNomFiscal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DProveidor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DProveidor"
        Me.gbDadesBancaries.ResumeLayout(False)
        Me.gbDadesBancaries.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblErrCif As Label
    Friend WithEvents txtCif As TextBox
    Friend WithEvents lblCif As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents lblErrNom As Label
    Friend WithEvents txtNomComercial As TextBox
    Friend WithEvents lblNomComercial As Label
    Friend WithEvents txtNomFiscal As TextBox
    Friend WithEvents lblNomFiscal As Label
    Friend WithEvents txtDireccio As TextBox
    Friend WithEvents lblDireccio As Label
    Friend WithEvents txtPoblacio As TextBox
    Friend WithEvents lblPoblacio As Label
    Friend WithEvents lblCodiPostal As Label
    Friend WithEvents txtCodiPostal As TextBox
    Friend WithEvents lblProvincia As Label
    Friend WithEvents lblPais As Label
    Friend WithEvents lblTipusPagament As Label
    Friend WithEvents gbDadesBancaries As GroupBox
    Friend WithEvents txtIban3 As TextBox
    Friend WithEvents lblIban3 As Label
    Friend WithEvents txtIban2 As TextBox
    Friend WithEvents lblIban2 As Label
    Friend WithEvents txtIban1 As TextBox
    Friend WithEvents lblIban1 As Label
    Friend WithEvents xecActiu As XEC
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents pTPagament As Panel
    Friend WithEvents pProvincia As Panel
    Friend WithEvents pPais As Panel
    Friend WithEvents txtCodiComptable As TextBox
    Friend WithEvents lblCodiComptable As Label
    Friend WithEvents lblErrCodiComptable As Label
    Friend WithEvents xecNoValidar As XEC
    Friend WithEvents cmdImprimirExcel As Button
    Friend WithEvents cmdImprimirPDF As Button
End Class
