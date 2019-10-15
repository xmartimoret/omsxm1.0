<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DGrup
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
        Me.cmdCancelar = New BOTO()
        Me.cmdGuardar = New BOTO()
        Me.lblNotes = New LBLRIGHT()
        Me.txtNotes = New TXT()
        Me.lblId = New LBLBLUE()
        Me.lblIdCaption = New LBLRIGHT()
        Me.xecResum = New XEC()
        Me.lblErrNom = New LBLRED()
        Me.txtNom = New TXT()
        Me.lblNom = New LBLRIGHT()
        Me.lblErrCodi = New LBLRED()
        Me.txtCodi = New TXT()
        Me.lblCodi = New LBLRIGHT()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdCancelar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdGuardar, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(107, 191)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(406, 39)
        Me.TableLayoutPanel1.TabIndex = 51
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(230, 4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdGuardar
        '
        Me.cmdGuardar.AutoSize = True
        Me.cmdGuardar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(3, 3)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.ForeColor = System.Drawing.Color.Black
        Me.lblNotes.Location = New System.Drawing.Point(20, 110)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(71, 23)
        Me.lblNotes.TabIndex = 62
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(97, 106)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(276, 51)
        Me.txtNotes.TabIndex = 61
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(94, 12)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(64, 23)
        Me.lblId.TabIndex = 53
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.ForeColor = System.Drawing.Color.Black
        Me.lblIdCaption.Location = New System.Drawing.Point(17, 12)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 52
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xecResum
        '
        Me.xecResum.AutoSize = True
        Me.xecResum.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecResum.ForeColor = System.Drawing.Color.Black
        Me.xecResum.Location = New System.Drawing.Point(97, 163)
        Me.xecResum.Name = "xecResum"
        Me.xecResum.Size = New System.Drawing.Size(15, 14)
        Me.xecResum.TabIndex = 60
        Me.xecResum.UseVisualStyleBackColor = True
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(379, 77)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(139, 23)
        Me.lblErrNom.TabIndex = 59
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(97, 73)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(276, 26)
        Me.txtNom.TabIndex = 58
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.ForeColor = System.Drawing.Color.Black
        Me.lblNom.Location = New System.Drawing.Point(17, 77)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 57
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrCodi
        '
        Me.lblErrCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodi.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodi.Location = New System.Drawing.Point(149, 44)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCodi.TabIndex = 56
        Me.lblErrCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodi
        '
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(97, 41)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(46, 26)
        Me.txtCodi.TabIndex = 55
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.ForeColor = System.Drawing.Color.Black
        Me.lblCodi.Location = New System.Drawing.Point(17, 45)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(71, 23)
        Me.lblCodi.TabIndex = 54
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGrup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 243)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.Controls.Add(Me.xecResum)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblErrCodi)
        Me.Controls.Add(Me.txtCodi)
        Me.Controls.Add(Me.lblCodi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DGrup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DGrup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNotes As LBLRIGHT
    Friend WithEvents txtNotes As TXT
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents lblId As LBLBLUE
    Friend WithEvents lblIdCaption As LBLRIGHT
    Friend WithEvents xecResum As XEC
    Friend WithEvents lblErrNom As LBLRED
    Friend WithEvents txtNom As TXT
    Friend WithEvents lblNom As LBLRIGHT
    Friend WithEvents lblErrCodi As LBLRED
    Friend WithEvents txtCodi As TXT
    Friend WithEvents lblCodi As LBLRIGHT
End Class
