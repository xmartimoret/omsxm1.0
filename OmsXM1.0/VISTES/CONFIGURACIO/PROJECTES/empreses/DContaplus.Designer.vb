<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DContaplus
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
        Me.lblErrAny = New System.Windows.Forms.Label()
        Me.txtAny = New System.Windows.Forms.TextBox()
        Me.lblAny = New System.Windows.Forms.Label()
        Me.lblEmpresaCaption = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblErrNom = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.xecNoContaplus = New System.Windows.Forms.CheckBox()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(34, 180)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(463, 39)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(49, 4)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(273, 4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancel"
        '
        'lblErrAny
        '
        Me.lblErrAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrAny.Location = New System.Drawing.Point(341, 68)
        Me.lblErrAny.Name = "lblErrAny"
        Me.lblErrAny.Size = New System.Drawing.Size(156, 23)
        Me.lblErrAny.TabIndex = 22
        Me.lblErrAny.Text = "(*) OBLIGATPORI"
        Me.lblErrAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAny
        '
        Me.txtAny.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAny.ForeColor = System.Drawing.Color.Blue
        Me.txtAny.Location = New System.Drawing.Point(144, 67)
        Me.txtAny.Name = "txtAny"
        Me.txtAny.Size = New System.Drawing.Size(104, 26)
        Me.txtAny.TabIndex = 20
        '
        'lblAny
        '
        Me.lblAny.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.Location = New System.Drawing.Point(64, 71)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(71, 23)
        Me.lblAny.TabIndex = 19
        Me.lblAny.Text = "Label1"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmpresaCaption
        '
        Me.lblEmpresaCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaCaption.Location = New System.Drawing.Point(64, 38)
        Me.lblEmpresaCaption.Name = "lblEmpresaCaption"
        Me.lblEmpresaCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblEmpresaCaption.TabIndex = 17
        Me.lblEmpresaCaption.Text = "Label1"
        Me.lblEmpresaCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(141, 9)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 16
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(64, 9)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 15
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpresa.Location = New System.Drawing.Point(141, 38)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(194, 23)
        Me.lblEmpresa.TabIndex = 26
        Me.lblEmpresa.Text = "Label1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(341, 100)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(156, 23)
        Me.lblErrNom.TabIndex = 29
        Me.lblErrNom.Text = "(*) OBLIGATPORI"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(144, 99)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(191, 26)
        Me.txtNom.TabIndex = 28
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(64, 103)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 27
        Me.lblNom.Text = "Label1"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xecNoContaplus
        '
        Me.xecNoContaplus.AutoSize = True
        Me.xecNoContaplus.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecNoContaplus.Location = New System.Drawing.Point(144, 131)
        Me.xecNoContaplus.Name = "xecNoContaplus"
        Me.xecNoContaplus.Size = New System.Drawing.Size(99, 22)
        Me.xecNoContaplus.TabIndex = 30
        Me.xecNoContaplus.Text = "CheckBox1"
        Me.xecNoContaplus.UseVisualStyleBackColor = True
        '
        'DContaplus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 231)
        Me.Controls.Add(Me.xecNoContaplus)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblErrAny)
        Me.Controls.Add(Me.txtAny)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.lblEmpresaCaption)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DContaplus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DContaplus"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents lblErrAny As Label
    Friend WithEvents txtAny As TextBox
    Friend WithEvents lblAny As Label
    Friend WithEvents lblEmpresaCaption As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents lblErrNom As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents lblNom As Label
    Friend WithEvents xecNoContaplus As CheckBox
End Class
