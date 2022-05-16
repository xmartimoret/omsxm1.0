<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DCodiComanda
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblSerieCaption = New System.Windows.Forms.Label()
        Me.lblEmpresaCaption = New System.Windows.Forms.Label()
        Me.lblSerie = New OmsXM.LBLBLUE()
        Me.lblEmpresa = New OmsXM.LBLBLUE()
        Me.txtCodi = New System.Windows.Forms.TextBox()
        Me.lblCodiCaption = New System.Windows.Forms.Label()
        Me.lblId = New OmsXM.LBLBLUE()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdGuardar, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdCancelar, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(15, 209)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(376, 36)
        Me.TableLayoutPanel2.TabIndex = 91
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(27, 3)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 30)
        Me.cmdGuardar.TabIndex = 4
        Me.cmdGuardar.Text = "OK"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(208, 3)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 30)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancel"
        '
        'lblSerieCaption
        '
        Me.lblSerieCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerieCaption.Location = New System.Drawing.Point(25, 17)
        Me.lblSerieCaption.Name = "lblSerieCaption"
        Me.lblSerieCaption.Size = New System.Drawing.Size(82, 20)
        Me.lblSerieCaption.TabIndex = 92
        Me.lblSerieCaption.Text = "Serie"
        Me.lblSerieCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmpresaCaption
        '
        Me.lblEmpresaCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaCaption.Location = New System.Drawing.Point(25, 37)
        Me.lblEmpresaCaption.Name = "lblEmpresaCaption"
        Me.lblEmpresaCaption.Size = New System.Drawing.Size(82, 20)
        Me.lblEmpresaCaption.TabIndex = 93
        Me.lblEmpresaCaption.Text = "Serie"
        Me.lblEmpresaCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerie.ForeColor = System.Drawing.Color.Blue
        Me.lblSerie.Location = New System.Drawing.Point(113, 19)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(13, 16)
        Me.lblSerie.TabIndex = 94
        Me.lblSerie.Text = "-"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpresa.Location = New System.Drawing.Point(113, 41)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(13, 16)
        Me.lblEmpresa.TabIndex = 95
        Me.lblEmpresa.Text = "-"
        '
        'txtCodi
        '
        Me.txtCodi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(116, 60)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(102, 26)
        Me.txtCodi.TabIndex = 96
        '
        'lblCodiCaption
        '
        Me.lblCodiCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiCaption.Location = New System.Drawing.Point(36, 64)
        Me.lblCodiCaption.Name = "lblCodiCaption"
        Me.lblCodiCaption.Size = New System.Drawing.Size(71, 20)
        Me.lblCodiCaption.TabIndex = 97
        Me.lblCodiCaption.Text = "Label1"
        Me.lblCodiCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(329, 9)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(62, 16)
        Me.lblId.TabIndex = 99
        Me.lblId.Text = "Lblblue3"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(116, 92)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(249, 90)
        Me.txtNotes.TabIndex = 100
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.Location = New System.Drawing.Point(36, 96)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(71, 20)
        Me.lblNotes.TabIndex = 101
        Me.lblNotes.Text = "Label1"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DCodiComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 268)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtCodi)
        Me.Controls.Add(Me.lblCodiCaption)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.lblSerie)
        Me.Controls.Add(Me.lblEmpresaCaption)
        Me.Controls.Add(Me.lblSerieCaption)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DCodiComanda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents lblSerieCaption As Label
    Friend WithEvents lblEmpresaCaption As Label
    Friend WithEvents lblSerie As LBLBLUE
    Friend WithEvents lblEmpresa As LBLBLUE
    Friend WithEvents txtCodi As TextBox
    Friend WithEvents lblCodiCaption As Label
    Friend WithEvents lblId As LBLBLUE
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
End Class
