<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DSubGrupGB
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
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.txtFormula = New OmsXM.TXT()
        Me.lblSubgrupGb = New OmsXM.LBLRIGHT()
        Me.lblSubgrup = New OmsXM.LBLRIGHT()
        Me.cbSubGrupGB = New OmsXM.CBBOX()
        Me.cbSubgrup = New OmsXM.CBBOX()
        Me.lblFormulaCaption = New OmsXM.LBLRIGHT()
        Me.lblErrNom = New OmsXM.LBLRED()
        Me.txtNom = New OmsXM.TXT()
        Me.lblNom = New OmsXM.LBLRIGHT()
        Me.lblErrCodi = New OmsXM.LBLRED()
        Me.txtCodi = New OmsXM.TXT()
        Me.lblCodi = New OmsXM.LBLRIGHT()
        Me.lblId = New OmsXM.LBLBLUE()
        Me.lblIdCaption = New OmsXM.LBLRIGHT()
        Me.xecTotal = New OmsXM.XEC()
        Me.optSumar = New System.Windows.Forms.RadioButton()
        Me.optRestar = New System.Windows.Forms.RadioButton()
        Me.optMultiplicar = New System.Windows.Forms.RadioButton()
        Me.optDividir = New System.Windows.Forms.RadioButton()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(89, 322)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(428, 39)
        Me.TableLayoutPanel1.TabIndex = 39
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
        Me.cmdCancelar.Location = New System.Drawing.Point(247, 4)
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
        'txtFormula
        '
        Me.txtFormula.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFormula.ForeColor = System.Drawing.Color.Blue
        Me.txtFormula.Location = New System.Drawing.Point(99, 181)
        Me.txtFormula.Multiline = True
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(423, 111)
        Me.txtFormula.TabIndex = 59
        '
        'lblSubgrupGb
        '
        Me.lblSubgrupGb.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubgrupGb.ForeColor = System.Drawing.Color.Black
        Me.lblSubgrupGb.Location = New System.Drawing.Point(250, 124)
        Me.lblSubgrupGb.Name = "lblSubgrupGb"
        Me.lblSubgrupGb.Size = New System.Drawing.Size(154, 23)
        Me.lblSubgrupGb.TabIndex = 58
        Me.lblSubgrupGb.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblSubgrup
        '
        Me.lblSubgrup.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubgrup.ForeColor = System.Drawing.Color.Black
        Me.lblSubgrup.Location = New System.Drawing.Point(96, 123)
        Me.lblSubgrup.Name = "lblSubgrup"
        Me.lblSubgrup.Size = New System.Drawing.Size(151, 23)
        Me.lblSubgrup.TabIndex = 57
        Me.lblSubgrup.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbSubGrupGB
        '
        Me.cbSubGrupGB.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbSubGrupGB.ForeColor = System.Drawing.Color.Blue
        Me.cbSubGrupGB.FormattingEnabled = True
        Me.cbSubGrupGB.Location = New System.Drawing.Point(253, 150)
        Me.cbSubGrupGB.Name = "cbSubGrupGB"
        Me.cbSubGrupGB.Size = New System.Drawing.Size(151, 26)
        Me.cbSubGrupGB.TabIndex = 55
        '
        'cbSubgrup
        '
        Me.cbSubgrup.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbSubgrup.ForeColor = System.Drawing.Color.Blue
        Me.cbSubgrup.FormattingEnabled = True
        Me.cbSubgrup.Location = New System.Drawing.Point(99, 149)
        Me.cbSubgrup.Name = "cbSubgrup"
        Me.cbSubgrup.Size = New System.Drawing.Size(148, 26)
        Me.cbSubgrup.TabIndex = 54
        '
        'lblFormulaCaption
        '
        Me.lblFormulaCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormulaCaption.ForeColor = System.Drawing.Color.Black
        Me.lblFormulaCaption.Location = New System.Drawing.Point(4, 172)
        Me.lblFormulaCaption.Name = "lblFormulaCaption"
        Me.lblFormulaCaption.Size = New System.Drawing.Size(79, 23)
        Me.lblFormulaCaption.TabIndex = 48
        Me.lblFormulaCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(377, 78)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(139, 23)
        Me.lblErrNom.TabIndex = 47
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(95, 74)
        Me.txtNom.Multiline = True
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(276, 27)
        Me.txtNom.TabIndex = 46
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.ForeColor = System.Drawing.Color.Black
        Me.lblNom.Location = New System.Drawing.Point(15, 78)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 45
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrCodi
        '
        Me.lblErrCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodi.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodi.Location = New System.Drawing.Point(187, 45)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCodi.TabIndex = 44
        Me.lblErrCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodi
        '
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(95, 42)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(86, 26)
        Me.txtCodi.TabIndex = 43
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.ForeColor = System.Drawing.Color.Black
        Me.lblCodi.Location = New System.Drawing.Point(15, 46)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(71, 23)
        Me.lblCodi.TabIndex = 42
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(92, 13)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(64, 23)
        Me.lblId.TabIndex = 41
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.ForeColor = System.Drawing.Color.Black
        Me.lblIdCaption.Location = New System.Drawing.Point(15, 13)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 40
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xecTotal
        '
        Me.xecTotal.AutoSize = True
        Me.xecTotal.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecTotal.ForeColor = System.Drawing.Color.Black
        Me.xecTotal.Location = New System.Drawing.Point(95, 107)
        Me.xecTotal.Name = "xecTotal"
        Me.xecTotal.Size = New System.Drawing.Size(59, 22)
        Me.xecTotal.TabIndex = 60
        Me.xecTotal.Text = "Xec1"
        Me.xecTotal.UseVisualStyleBackColor = True
        '
        'optSumar
        '
        Me.optSumar.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSumar.AutoSize = True
        Me.optSumar.Checked = True
        Me.optSumar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSumar.Location = New System.Drawing.Point(410, 145)
        Me.optSumar.Name = "optSumar"
        Me.optSumar.Size = New System.Drawing.Size(29, 30)
        Me.optSumar.TabIndex = 62
        Me.optSumar.TabStop = True
        Me.optSumar.Text = "+"
        Me.optSumar.UseVisualStyleBackColor = True
        '
        'optRestar
        '
        Me.optRestar.Appearance = System.Windows.Forms.Appearance.Button
        Me.optRestar.AutoSize = True
        Me.optRestar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRestar.Location = New System.Drawing.Point(439, 145)
        Me.optRestar.Name = "optRestar"
        Me.optRestar.Size = New System.Drawing.Size(25, 30)
        Me.optRestar.TabIndex = 63
        Me.optRestar.TabStop = True
        Me.optRestar.Text = "-"
        Me.optRestar.UseVisualStyleBackColor = True
        '
        'optMultiplicar
        '
        Me.optMultiplicar.Appearance = System.Windows.Forms.Appearance.Button
        Me.optMultiplicar.AutoSize = True
        Me.optMultiplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMultiplicar.Location = New System.Drawing.Point(468, 145)
        Me.optMultiplicar.Name = "optMultiplicar"
        Me.optMultiplicar.Size = New System.Drawing.Size(27, 30)
        Me.optMultiplicar.TabIndex = 64
        Me.optMultiplicar.TabStop = True
        Me.optMultiplicar.Text = "x"
        Me.optMultiplicar.UseVisualStyleBackColor = True
        '
        'optDividir
        '
        Me.optDividir.Appearance = System.Windows.Forms.Appearance.Button
        Me.optDividir.AutoSize = True
        Me.optDividir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDividir.Location = New System.Drawing.Point(497, 145)
        Me.optDividir.Name = "optDividir"
        Me.optDividir.Size = New System.Drawing.Size(24, 30)
        Me.optDividir.TabIndex = 65
        Me.optDividir.TabStop = True
        Me.optDividir.Text = "/"
        Me.optDividir.UseVisualStyleBackColor = True
        '
        'DSubGrupGB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 364)
        Me.Controls.Add(Me.optDividir)
        Me.Controls.Add(Me.optMultiplicar)
        Me.Controls.Add(Me.optRestar)
        Me.Controls.Add(Me.optSumar)
        Me.Controls.Add(Me.xecTotal)
        Me.Controls.Add(Me.txtFormula)
        Me.Controls.Add(Me.lblSubgrupGb)
        Me.Controls.Add(Me.lblSubgrup)
        Me.Controls.Add(Me.cbSubGrupGB)
        Me.Controls.Add(Me.cbSubgrup)
        Me.Controls.Add(Me.lblFormulaCaption)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblErrCodi)
        Me.Controls.Add(Me.txtCodi)
        Me.Controls.Add(Me.lblCodi)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DSubGrupGB"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DSubGrupGB"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents lblErrNom As LBLRED
    Friend WithEvents txtNom As TXT
    Friend WithEvents lblNom As LBLRIGHT
    Friend WithEvents lblErrCodi As LBLRED
    Friend WithEvents txtCodi As TXT
    Friend WithEvents lblCodi As LBLRIGHT
    Friend WithEvents lblId As LBLBLUE
    Friend WithEvents lblIdCaption As LBLRIGHT
    Friend WithEvents lblFormulaCaption As LBLRIGHT
    Friend WithEvents cbSubgrup As CBBOX
    Friend WithEvents cbSubGrupGB As CBBOX
    Friend WithEvents lblSubgrup As LBLRIGHT
    Friend WithEvents lblSubgrupGb As LBLRIGHT
    Friend WithEvents txtFormula As TXT
    Friend WithEvents xecTotal As XEC
    Friend WithEvents optSumar As RadioButton
    Friend WithEvents optRestar As RadioButton
    Friend WithEvents optMultiplicar As RadioButton
    Friend WithEvents optDividir As RadioButton
End Class
