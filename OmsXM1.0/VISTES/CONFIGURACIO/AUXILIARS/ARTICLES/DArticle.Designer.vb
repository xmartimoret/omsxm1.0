<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DArticle
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
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblErrCodi = New System.Windows.Forms.Label()
        Me.txtCodi = New System.Windows.Forms.TextBox()
        Me.lblCodi = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.lblErrNom = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.lblFabricant = New System.Windows.Forms.Label()
        Me.PFabricant = New System.Windows.Forms.Panel()
        Me.lblUnitat = New System.Windows.Forms.Label()
        Me.pUnitat = New System.Windows.Forms.Panel()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.pIva = New System.Windows.Forms.Panel()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.pFamilia = New System.Windows.Forms.Panel()
        Me.cmdImprimirExcel = New System.Windows.Forms.Button()
        Me.cmdImprimirPDF = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(562, 298)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 8
        Me.cmdCancelar.Text = "Cancel"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(170, 298)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 7
        Me.cmdGuardar.Text = "OK"
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(20, 63)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(141, 40)
        Me.lblNom.TabIndex = 82
        Me.lblNom.Text = "Label1"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrCodi
        '
        Me.lblErrCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodi.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodi.Location = New System.Drawing.Point(344, 36)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCodi.TabIndex = 79
        Me.lblErrCodi.Text = "(*) OBLIGATPORI"
        Me.lblErrCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodi
        '
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(170, 36)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(153, 26)
        Me.txtCodi.TabIndex = 0
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.Location = New System.Drawing.Point(20, 36)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(141, 23)
        Me.lblCodi.TabIndex = 78
        Me.lblCodi.Text = "Label1"
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(167, 7)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 77
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(20, 6)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(141, 23)
        Me.lblIdCaption.TabIndex = 76
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(554, 45)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(156, 23)
        Me.lblErrNom.TabIndex = 81
        Me.lblErrNom.Text = "(*) OBLIGATPORI"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(170, 71)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(540, 26)
        Me.txtNom.TabIndex = 1
        '
        'lblFamilia
        '
        Me.lblFamilia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilia.Location = New System.Drawing.Point(20, 105)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(141, 23)
        Me.lblFamilia.TabIndex = 90
        Me.lblFamilia.Text = "Label1"
        Me.lblFamilia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFabricant
        '
        Me.lblFabricant.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFabricant.Location = New System.Drawing.Point(20, 140)
        Me.lblFabricant.Name = "lblFabricant"
        Me.lblFabricant.Size = New System.Drawing.Size(141, 23)
        Me.lblFabricant.TabIndex = 92
        Me.lblFabricant.Text = "Label1"
        Me.lblFabricant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PFabricant
        '
        Me.PFabricant.Location = New System.Drawing.Point(170, 136)
        Me.PFabricant.Name = "PFabricant"
        Me.PFabricant.Size = New System.Drawing.Size(349, 29)
        Me.PFabricant.TabIndex = 3
        '
        'lblUnitat
        '
        Me.lblUnitat.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitat.Location = New System.Drawing.Point(20, 171)
        Me.lblUnitat.Name = "lblUnitat"
        Me.lblUnitat.Size = New System.Drawing.Size(141, 23)
        Me.lblUnitat.TabIndex = 94
        Me.lblUnitat.Text = "Label1"
        Me.lblUnitat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pUnitat
        '
        Me.pUnitat.Location = New System.Drawing.Point(170, 171)
        Me.pUnitat.Name = "pUnitat"
        Me.pUnitat.Size = New System.Drawing.Size(199, 29)
        Me.pUnitat.TabIndex = 4
        '
        'lblIva
        '
        Me.lblIva.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva.Location = New System.Drawing.Point(20, 210)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(141, 23)
        Me.lblIva.TabIndex = 92
        Me.lblIva.Text = "Label1"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pIva
        '
        Me.pIva.Location = New System.Drawing.Point(170, 206)
        Me.pIva.Name = "pIva"
        Me.pIva.Size = New System.Drawing.Size(199, 29)
        Me.pIva.TabIndex = 5
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.Location = New System.Drawing.Point(20, 243)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(141, 40)
        Me.lblNotes.TabIndex = 96
        Me.lblNotes.Text = "Label1"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(170, 251)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(540, 26)
        Me.txtNotes.TabIndex = 6
        '
        'pFamilia
        '
        Me.pFamilia.Location = New System.Drawing.Point(170, 101)
        Me.pFamilia.Name = "pFamilia"
        Me.pFamilia.Size = New System.Drawing.Size(349, 29)
        Me.pFamilia.TabIndex = 2
        '
        'cmdImprimirExcel
        '
        Me.cmdImprimirExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimirExcel.Image = Global.OmsXM.My.Resources.Resources.excel
        Me.cmdImprimirExcel.Location = New System.Drawing.Point(662, 4)
        Me.cmdImprimirExcel.Name = "cmdImprimirExcel"
        Me.cmdImprimirExcel.Size = New System.Drawing.Size(26, 28)
        Me.cmdImprimirExcel.TabIndex = 98
        Me.cmdImprimirExcel.UseVisualStyleBackColor = True
        '
        'cmdImprimirPDF
        '
        Me.cmdImprimirPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimirPDF.Image = Global.OmsXM.My.Resources.Resources.pdf
        Me.cmdImprimirPDF.Location = New System.Drawing.Point(688, 4)
        Me.cmdImprimirPDF.Name = "cmdImprimirPDF"
        Me.cmdImprimirPDF.Size = New System.Drawing.Size(32, 28)
        Me.cmdImprimirPDF.TabIndex = 97
        Me.cmdImprimirPDF.UseVisualStyleBackColor = True
        '
        'DArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 341)
        Me.Controls.Add(Me.cmdImprimirExcel)
        Me.Controls.Add(Me.cmdImprimirPDF)
        Me.Controls.Add(Me.pFamilia)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.lblIva)
        Me.Controls.Add(Me.lblUnitat)
        Me.Controls.Add(Me.lblFabricant)
        Me.Controls.Add(Me.lblFamilia)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblCodi)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.lblErrCodi)
        Me.Controls.Add(Me.txtCodi)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.pIva)
        Me.Controls.Add(Me.pUnitat)
        Me.Controls.Add(Me.PFabricant)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DArticle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DArticle"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents lblNom As Label
    Friend WithEvents lblErrCodi As Label
    Friend WithEvents txtCodi As TextBox
    Friend WithEvents lblCodi As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents lblErrNom As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents lblFamilia As Label
    Friend WithEvents lblFabricant As Label
    Friend WithEvents PFabricant As Panel
    Friend WithEvents lblUnitat As Label
    Friend WithEvents pUnitat As Panel
    Friend WithEvents lblIva As Label
    Friend WithEvents pIva As Panel
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents pFamilia As Panel
    Friend WithEvents cmdImprimirExcel As Button
    Friend WithEvents cmdImprimirPDF As Button
End Class
