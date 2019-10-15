<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DSeccio
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
        Me.cmdGuardar = New BOTO()
        Me.cmdCancelar = New BOTO()
        Me.lstGrups = New System.Windows.Forms.ListBox()
        Me.lblGrups = New LBLRIGHT()
        Me.lblId = New LBLBLUE()
        Me.lblCaptionId = New LBLRIGHT()
        Me.lblCodi = New LBLRIGHT()
        Me.txtCodi = New TXT()
        Me.lblNom = New LBLRIGHT()
        Me.txtNom = New TXT()
        Me.lblNotes = New LBLRIGHT()
        Me.txtNotes = New TXT()
        Me.xecActiu = New XEC()
        Me.lblErrCodi = New LBLRED()
        Me.lblErrNom = New LBLRED()
        Me.SuspendLayout()
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
        Me.cmdGuardar.Location = New System.Drawing.Point(65, 282)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(83, 30)
        Me.cmdGuardar.TabIndex = 5
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
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
        Me.cmdCancelar.Location = New System.Drawing.Point(321, 282)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(83, 30)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'lstGrups
        '
        Me.lstGrups.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lstGrups.ForeColor = System.Drawing.Color.Blue
        Me.lstGrups.FormattingEnabled = True
        Me.lstGrups.ItemHeight = 18
        Me.lstGrups.Location = New System.Drawing.Point(89, 144)
        Me.lstGrups.Name = "lstGrups"
        Me.lstGrups.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstGrups.Size = New System.Drawing.Size(312, 94)
        Me.lstGrups.TabIndex = 3
        '
        'lblGrups
        '
        Me.lblGrups.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrups.ForeColor = System.Drawing.Color.Black
        Me.lblGrups.Location = New System.Drawing.Point(3, 144)
        Me.lblGrups.Name = "lblGrups"
        Me.lblGrups.Size = New System.Drawing.Size(81, 62)
        Me.lblGrups.TabIndex = 15
        Me.lblGrups.Text = "Lblright4"
        Me.lblGrups.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(89, 9)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(59, 18)
        Me.lblId.TabIndex = 2
        Me.lblId.Text = "Lblblue1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaptionId
        '
        Me.lblCaptionId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionId.ForeColor = System.Drawing.Color.Black
        Me.lblCaptionId.Location = New System.Drawing.Point(22, 9)
        Me.lblCaptionId.Name = "lblCaptionId"
        Me.lblCaptionId.Size = New System.Drawing.Size(61, 18)
        Me.lblCaptionId.TabIndex = 3
        Me.lblCaptionId.Text = "Lblright1"
        Me.lblCaptionId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.ForeColor = System.Drawing.Color.Black
        Me.lblCodi.Location = New System.Drawing.Point(22, 37)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(61, 18)
        Me.lblCodi.TabIndex = 4
        Me.lblCodi.Text = "Lblright2"
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodi
        '
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(89, 34)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(100, 26)
        Me.txtCodi.TabIndex = 0
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.ForeColor = System.Drawing.Color.Black
        Me.lblNom.Location = New System.Drawing.Point(22, 69)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(61, 18)
        Me.lblNom.TabIndex = 6
        Me.lblNom.Text = "Lblright3"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(89, 66)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(213, 26)
        Me.txtNom.TabIndex = 1
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.ForeColor = System.Drawing.Color.Black
        Me.lblNotes.Location = New System.Drawing.Point(22, 101)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(61, 18)
        Me.lblNotes.TabIndex = 8
        Me.lblNotes.Text = "Lblright4"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(89, 98)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(312, 40)
        Me.txtNotes.TabIndex = 2
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(89, 244)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 4
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'lblErrCodi
        '
        Me.lblErrCodi.AutoSize = True
        Me.lblErrCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodi.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodi.Location = New System.Drawing.Point(207, 37)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(54, 18)
        Me.lblErrCodi.TabIndex = 12
        Me.lblErrCodi.Text = "Lblred1"
        Me.lblErrCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrNom
        '
        Me.lblErrNom.AutoSize = True
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(308, 74)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(54, 18)
        Me.lblErrNom.TabIndex = 13
        Me.lblErrNom.Text = "Lblred2"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DSeccio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 327)
        Me.Controls.Add(Me.lblGrups)
        Me.Controls.Add(Me.lstGrups)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.lblErrCodi)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.txtCodi)
        Me.Controls.Add(Me.lblCodi)
        Me.Controls.Add(Me.lblCaptionId)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DSeccio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DSeccio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents lstGrups As ListBox
    Friend WithEvents lblGrups As LBLRIGHT
    Friend WithEvents lblId As LBLBLUE
    Friend WithEvents lblCaptionId As LBLRIGHT
    Friend WithEvents lblCodi As LBLRIGHT
    Friend WithEvents txtCodi As TXT
    Friend WithEvents lblNom As LBLRIGHT
    Friend WithEvents txtNom As TXT
    Friend WithEvents lblNotes As LBLRIGHT
    Friend WithEvents txtNotes As TXT
    Friend WithEvents xecActiu As XEC
    Friend WithEvents lblErrCodi As LBLRED
    Friend WithEvents lblErrNom As LBLRED
End Class
