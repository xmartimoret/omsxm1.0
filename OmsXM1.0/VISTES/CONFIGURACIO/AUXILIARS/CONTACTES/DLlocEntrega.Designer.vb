<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DLlocEntrega
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
        Me.pPais = New System.Windows.Forms.Panel()
        Me.pProvincia = New System.Windows.Forms.Panel()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
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
        Me.xecActiu = New OmsXM.XEC()
        Me.xecPredeterminat = New OmsXM.XEC()
        Me.SuspendLayout()
        '
        'pPais
        '
        Me.pPais.Location = New System.Drawing.Point(462, 214)
        Me.pPais.Name = "pPais"
        Me.pPais.Size = New System.Drawing.Size(232, 29)
        Me.pPais.TabIndex = 6
        '
        'pProvincia
        '
        Me.pProvincia.Location = New System.Drawing.Point(154, 214)
        Me.pProvincia.Name = "pProvincia"
        Me.pProvincia.Size = New System.Drawing.Size(232, 29)
        Me.pProvincia.TabIndex = 5
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.Location = New System.Drawing.Point(4, 280)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(141, 40)
        Me.lblNotes.TabIndex = 143
        Me.lblNotes.Text = "Label1"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(155, 280)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(540, 82)
        Me.txtNotes.TabIndex = 9
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(546, 377)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 11
        Me.cmdCancelar.Text = "Cancel"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(155, 377)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 10
        Me.cmdGuardar.Text = "OK"
        '
        'lblPais
        '
        Me.lblPais.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPais.Location = New System.Drawing.Point(398, 220)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(58, 23)
        Me.lblPais.TabIndex = 140
        Me.lblPais.Text = "lblPais"
        Me.lblPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProvincia
        '
        Me.lblProvincia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvincia.Location = New System.Drawing.Point(7, 216)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(141, 23)
        Me.lblProvincia.TabIndex = 139
        Me.lblProvincia.Text = "lblProvincia"
        Me.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodiPostal
        '
        Me.txtCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodiPostal.ForeColor = System.Drawing.Color.Blue
        Me.txtCodiPostal.Location = New System.Drawing.Point(553, 185)
        Me.txtCodiPostal.Name = "txtCodiPostal"
        Me.txtCodiPostal.Size = New System.Drawing.Size(141, 26)
        Me.txtCodiPostal.TabIndex = 4
        '
        'lblCodiPostal
        '
        Me.lblCodiPostal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiPostal.Location = New System.Drawing.Point(476, 188)
        Me.lblCodiPostal.Name = "lblCodiPostal"
        Me.lblCodiPostal.Size = New System.Drawing.Size(71, 23)
        Me.lblCodiPostal.TabIndex = 138
        Me.lblCodiPostal.Text = "Label1"
        Me.lblCodiPostal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPoblacio
        '
        Me.txtPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPoblacio.ForeColor = System.Drawing.Color.Blue
        Me.txtPoblacio.Location = New System.Drawing.Point(154, 182)
        Me.txtPoblacio.Name = "txtPoblacio"
        Me.txtPoblacio.Size = New System.Drawing.Size(232, 26)
        Me.txtPoblacio.TabIndex = 3
        '
        'lblPoblacio
        '
        Me.lblPoblacio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoblacio.Location = New System.Drawing.Point(4, 182)
        Me.lblPoblacio.Name = "lblPoblacio"
        Me.lblPoblacio.Size = New System.Drawing.Size(141, 23)
        Me.lblPoblacio.TabIndex = 137
        Me.lblPoblacio.Text = "Label1"
        Me.lblPoblacio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDireccio
        '
        Me.lblDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccio.Location = New System.Drawing.Point(5, 63)
        Me.lblDireccio.Name = "lblDireccio"
        Me.lblDireccio.Size = New System.Drawing.Size(141, 40)
        Me.lblDireccio.TabIndex = 136
        Me.lblDireccio.Text = "Label1"
        Me.lblDireccio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDireccio
        '
        Me.txtDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDireccio.ForeColor = System.Drawing.Color.Blue
        Me.txtDireccio.Location = New System.Drawing.Point(155, 63)
        Me.txtDireccio.Multiline = True
        Me.txtDireccio.Name = "txtDireccio"
        Me.txtDireccio.Size = New System.Drawing.Size(539, 107)
        Me.txtDireccio.TabIndex = 2
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(5, 25)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(141, 40)
        Me.lblNom.TabIndex = 135
        Me.lblNom.Text = "Label1"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(152, 7)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 134
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(5, 6)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(141, 23)
        Me.lblIdCaption.TabIndex = 133
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(155, 33)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(539, 26)
        Me.txtNom.TabIndex = 1
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(154, 252)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 7
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'xecPredeterminat
        '
        Me.xecPredeterminat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xecPredeterminat.AutoSize = True
        Me.xecPredeterminat.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecPredeterminat.ForeColor = System.Drawing.Color.Black
        Me.xecPredeterminat.Location = New System.Drawing.Point(550, 249)
        Me.xecPredeterminat.Name = "xecPredeterminat"
        Me.xecPredeterminat.Size = New System.Drawing.Size(141, 22)
        Me.xecPredeterminat.TabIndex = 8
        Me.xecPredeterminat.Text = "xecPredeterminat"
        Me.xecPredeterminat.UseVisualStyleBackColor = True
        '
        'DLlocEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 420)
        Me.Controls.Add(Me.xecPredeterminat)
        Me.Controls.Add(Me.pPais)
        Me.Controls.Add(Me.pProvincia)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
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
        Me.Name = "DLlocEntrega"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DLlocEntrega"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pPais As Panel
    Friend WithEvents pProvincia As Panel
    Friend WithEvents xecActiu As XEC
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdGuardar As Button
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
    Friend WithEvents xecPredeterminat As XEC
End Class
