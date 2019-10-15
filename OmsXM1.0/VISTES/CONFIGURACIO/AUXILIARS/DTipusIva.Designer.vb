<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DTipusIva
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
        Me.lblErrNom = New System.Windows.Forms.Label()
        Me.xecActiu = New OmsXM.XEC()
        Me.txtREquivalencia = New System.Windows.Forms.TextBox()
        Me.lblREquivalencia = New System.Windows.Forms.Label()
        Me.txtImpost = New System.Windows.Forms.TextBox()
        Me.lblImpost = New System.Windows.Forms.Label()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblErrCodi = New System.Windows.Forms.Label()
        Me.txtCodi = New System.Windows.Forms.TextBox()
        Me.lblCodi = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblErrImpost = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(392, 78)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(34, 23)
        Me.lblErrNom.TabIndex = 70
        Me.lblErrNom.Text = "(*) OBLIGATPORI"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(85, 171)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 59
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'txtREquivalencia
        '
        Me.txtREquivalencia.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtREquivalencia.ForeColor = System.Drawing.Color.Blue
        Me.txtREquivalencia.Location = New System.Drawing.Point(85, 139)
        Me.txtREquivalencia.Name = "txtREquivalencia"
        Me.txtREquivalencia.Size = New System.Drawing.Size(83, 26)
        Me.txtREquivalencia.TabIndex = 58
        '
        'lblREquivalencia
        '
        Me.lblREquivalencia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREquivalencia.Location = New System.Drawing.Point(5, 140)
        Me.lblREquivalencia.Name = "lblREquivalencia"
        Me.lblREquivalencia.Size = New System.Drawing.Size(71, 23)
        Me.lblREquivalencia.TabIndex = 68
        Me.lblREquivalencia.Text = "Label1"
        Me.lblREquivalencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImpost
        '
        Me.txtImpost.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtImpost.ForeColor = System.Drawing.Color.Blue
        Me.txtImpost.Location = New System.Drawing.Point(84, 107)
        Me.txtImpost.Name = "txtImpost"
        Me.txtImpost.Size = New System.Drawing.Size(83, 26)
        Me.txtImpost.TabIndex = 57
        '
        'lblImpost
        '
        Me.lblImpost.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpost.Location = New System.Drawing.Point(4, 108)
        Me.lblImpost.Name = "lblImpost"
        Me.lblImpost.Size = New System.Drawing.Size(71, 23)
        Me.lblImpost.TabIndex = 66
        Me.lblImpost.Text = "Label1"
        Me.lblImpost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(22, 4)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 5
        Me.cmdGuardar.Text = "OK"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(203, 4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "Cancel"
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(85, 77)
        Me.txtNom.Multiline = True
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(301, 27)
        Me.txtNom.TabIndex = 56
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(5, 81)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 65
        Me.lblNom.Text = "Label1"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrCodi
        '
        Me.lblErrCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodi.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodi.Location = New System.Drawing.Point(188, 45)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCodi.TabIndex = 64
        Me.lblErrCodi.Text = "(*) OBLIGATPORI"
        Me.lblErrCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodi
        '
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(85, 45)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(83, 26)
        Me.txtCodi.TabIndex = 55
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.Location = New System.Drawing.Point(5, 46)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(71, 23)
        Me.lblCodi.TabIndex = 63
        Me.lblCodi.Text = "Label1"
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(82, 6)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 62
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(5, 6)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 61
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.34043!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.65957!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdGuardar, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdCancelar, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(36, 204)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(376, 39)
        Me.TableLayoutPanel2.TabIndex = 60
        '
        'lblErrImpost
        '
        Me.lblErrImpost.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrImpost.ForeColor = System.Drawing.Color.Red
        Me.lblErrImpost.Location = New System.Drawing.Point(173, 108)
        Me.lblErrImpost.Name = "lblErrImpost"
        Me.lblErrImpost.Size = New System.Drawing.Size(213, 23)
        Me.lblErrImpost.TabIndex = 71
        Me.lblErrImpost.Text = "(*) OBLIGATPORI"
        Me.lblErrImpost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DTipusIva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 255)
        Me.Controls.Add(Me.lblErrImpost)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.txtREquivalencia)
        Me.Controls.Add(Me.lblREquivalencia)
        Me.Controls.Add(Me.txtImpost)
        Me.Controls.Add(Me.lblImpost)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.lblErrCodi)
        Me.Controls.Add(Me.txtCodi)
        Me.Controls.Add(Me.lblCodi)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DTipusIva"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DTipusIva"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblErrNom As Label
    Friend WithEvents xecActiu As XEC
    Friend WithEvents txtREquivalencia As TextBox
    Friend WithEvents lblREquivalencia As Label
    Friend WithEvents txtImpost As TextBox
    Friend WithEvents lblImpost As Label
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents txtNom As TextBox
    Friend WithEvents lblNom As Label
    Friend WithEvents lblErrCodi As Label
    Friend WithEvents txtCodi As TextBox
    Friend WithEvents lblCodi As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblErrImpost As Label
End Class
