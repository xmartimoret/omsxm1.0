<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DYsheet
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
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.lblErrNom = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblErrCodi = New System.Windows.Forms.Label()
        Me.txtCodi = New System.Windows.Forms.TextBox()
        Me.lblCodi = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(52, 173)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(406, 39)
        Me.TableLayoutPanel1.TabIndex = 28
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(230, 4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancel"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(35, 4)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "OK"
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(372, 73)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(139, 23)
        Me.lblErrNom.TabIndex = 36
        Me.lblErrNom.Text = "(*) OBLIGATPORI"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(90, 69)
        Me.txtNom.Multiline = True
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(276, 46)
        Me.txtNom.TabIndex = 35
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(10, 73)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 34
        Me.lblNom.Text = "Label1"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrCodi
        '
        Me.lblErrCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodi.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodi.Location = New System.Drawing.Point(287, 38)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCodi.TabIndex = 33
        Me.lblErrCodi.Text = "(*) OBLIGATPORI"
        Me.lblErrCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodi
        '
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(90, 37)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(191, 26)
        Me.txtCodi.TabIndex = 32
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.Location = New System.Drawing.Point(10, 41)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(71, 23)
        Me.lblCodi.TabIndex = 31
        Me.lblCodi.Text = "Label1"
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(87, 8)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 30
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(10, 8)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 29
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Blue
        Me.txtNotes.Location = New System.Drawing.Point(90, 121)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(406, 46)
        Me.txtNotes.TabIndex = 38
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.Location = New System.Drawing.Point(10, 125)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(71, 23)
        Me.lblNotes.TabIndex = 37
        Me.lblNotes.Text = "lblNotes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DYsheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 231)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
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
        Me.Name = "DYsheet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DYsheet"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents lblErrNom As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents lblNom As Label
    Friend WithEvents lblErrCodi As Label
    Friend WithEvents txtCodi As TextBox
    Friend WithEvents lblCodi As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
End Class
