<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DClient
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblErrNom = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.opt8 = New System.Windows.Forms.RadioButton()
        Me.opt6 = New System.Windows.Forms.RadioButton()
        Me.opt4 = New System.Windows.Forms.RadioButton()
        Me.opt46 = New System.Windows.Forms.RadioButton()
        Me.opt23 = New System.Windows.Forms.RadioButton()
        Me.opt7 = New System.Windows.Forms.RadioButton()
        Me.opt40 = New System.Windows.Forms.RadioButton()
        Me.opt = New System.Windows.Forms.RadioButton()
        Me.xecActiu = New XEC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdGuardar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdCancelar, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(72, 197)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(440, 39)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(43, 4)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "OK"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(256, 4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancel"
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(92, 71)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(420, 46)
        Me.txtNotes.TabIndex = 27
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.Location = New System.Drawing.Point(12, 75)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(71, 23)
        Me.lblNotes.TabIndex = 26
        Me.lblNotes.Text = "lblNotes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(289, 40)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(156, 23)
        Me.lblErrNom.TabIndex = 22
        Me.lblErrNom.Text = "(*) OBLIGATPORI"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(92, 39)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(191, 26)
        Me.txtNom.TabIndex = 20
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(12, 43)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 19
        Me.lblNom.Text = "lblNom"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(90, 6)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 16
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(13, 6)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 15
        Me.lblIdCaption.Text = "lblId"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblColor
        '
        Me.lblColor.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.Location = New System.Drawing.Point(15, 123)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(71, 23)
        Me.lblColor.TabIndex = 28
        Me.lblColor.Text = "Label1"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'opt8
        '
        Me.opt8.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.opt8.Location = New System.Drawing.Point(94, 123)
        Me.opt8.Name = "opt8"
        Me.opt8.Size = New System.Drawing.Size(47, 40)
        Me.opt8.TabIndex = 29
        Me.opt8.TabStop = True
        Me.opt8.Text = "BL"
        Me.opt8.UseMnemonic = False
        Me.opt8.UseVisualStyleBackColor = False
        '
        'opt6
        '
        Me.opt6.BackColor = System.Drawing.Color.Yellow
        Me.opt6.Location = New System.Drawing.Point(147, 123)
        Me.opt6.Name = "opt6"
        Me.opt6.Size = New System.Drawing.Size(47, 40)
        Me.opt6.TabIndex = 30
        Me.opt6.TabStop = True
        Me.opt6.Text = "YE"
        Me.opt6.UseVisualStyleBackColor = False
        '
        'opt4
        '
        Me.opt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.opt4.Location = New System.Drawing.Point(200, 123)
        Me.opt4.Name = "opt4"
        Me.opt4.Size = New System.Drawing.Size(47, 40)
        Me.opt4.TabIndex = 31
        Me.opt4.TabStop = True
        Me.opt4.Text = "GR"
        Me.opt4.UseVisualStyleBackColor = False
        '
        'opt46
        '
        Me.opt46.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.opt46.Location = New System.Drawing.Point(253, 123)
        Me.opt46.Name = "opt46"
        Me.opt46.Size = New System.Drawing.Size(47, 40)
        Me.opt46.TabIndex = 32
        Me.opt46.TabStop = True
        Me.opt46.Text = "OR"
        Me.opt46.UseVisualStyleBackColor = False
        '
        'opt23
        '
        Me.opt23.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.opt23.Location = New System.Drawing.Point(306, 123)
        Me.opt23.Name = "opt23"
        Me.opt23.Size = New System.Drawing.Size(47, 40)
        Me.opt23.TabIndex = 33
        Me.opt23.TabStop = True
        Me.opt23.Text = "BL1"
        Me.opt23.UseVisualStyleBackColor = False
        '
        'opt7
        '
        Me.opt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.opt7.Location = New System.Drawing.Point(359, 123)
        Me.opt7.Name = "opt7"
        Me.opt7.Size = New System.Drawing.Size(47, 40)
        Me.opt7.TabIndex = 34
        Me.opt7.TabStop = True
        Me.opt7.Text = "PK"
        Me.opt7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.opt7.UseVisualStyleBackColor = False
        '
        'opt40
        '
        Me.opt40.AutoEllipsis = True
        Me.opt40.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.opt40.Location = New System.Drawing.Point(412, 123)
        Me.opt40.Name = "opt40"
        Me.opt40.Size = New System.Drawing.Size(47, 40)
        Me.opt40.TabIndex = 35
        Me.opt40.TabStop = True
        Me.opt40.Text = "BR"
        Me.opt40.UseVisualStyleBackColor = False
        '
        'opt
        '
        Me.opt.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.opt.Location = New System.Drawing.Point(465, 123)
        Me.opt.Name = "opt"
        Me.opt.Size = New System.Drawing.Size(47, 40)
        Me.opt.TabIndex = 36
        Me.opt.TabStop = True
        Me.opt.Text = "GR"
        Me.opt.UseVisualStyleBackColor = False
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(94, 169)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 37
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'DClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 248)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.opt)
        Me.Controls.Add(Me.opt40)
        Me.Controls.Add(Me.opt7)
        Me.Controls.Add(Me.opt23)
        Me.Controls.Add(Me.opt46)
        Me.Controls.Add(Me.opt4)
        Me.Controls.Add(Me.opt6)
        Me.Controls.Add(Me.opt8)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DClient"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DClient"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents lblErrNom As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents lblNom As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents lblColor As Label
    Friend WithEvents opt8 As RadioButton
    Friend WithEvents opt6 As RadioButton
    Friend WithEvents opt4 As RadioButton
    Friend WithEvents opt46 As RadioButton
    Friend WithEvents opt23 As RadioButton
    Friend WithEvents opt7 As RadioButton
    Friend WithEvents opt40 As RadioButton
    Friend WithEvents opt As RadioButton
    Friend WithEvents xecActiu As XEC
End Class
