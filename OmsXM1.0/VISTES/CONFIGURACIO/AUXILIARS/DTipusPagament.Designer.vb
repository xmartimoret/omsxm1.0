<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DTipusPagament
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
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblErrCodi = New System.Windows.Forms.Label()
        Me.txtCodi = New System.Windows.Forms.TextBox()
        Me.lblCodi = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtDies = New System.Windows.Forms.TextBox()
        Me.lblDies = New System.Windows.Forms.Label()
        Me.etqDies = New System.Windows.Forms.Label()
        Me.etqDiaMes = New System.Windows.Forms.Label()
        Me.txtDia = New System.Windows.Forms.TextBox()
        Me.lblDia = New System.Windows.Forms.Label()
        Me.xecActiu = New OmsXM.XEC()
        Me.lblErrNom = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtNom.ForeColor = System.Drawing.Color.Blue
        Me.txtNom.Location = New System.Drawing.Point(88, 78)
        Me.txtNom.Multiline = True
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(301, 27)
        Me.txtNom.TabIndex = 1
        '
        'lblNom
        '
        Me.lblNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(8, 82)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 44
        Me.lblNom.Text = "Label1"
        Me.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrCodi
        '
        Me.lblErrCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrCodi.ForeColor = System.Drawing.Color.Red
        Me.lblErrCodi.Location = New System.Drawing.Point(191, 46)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCodi.TabIndex = 43
        Me.lblErrCodi.Text = "(*) OBLIGATPORI"
        Me.lblErrCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodi
        '
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(88, 46)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(83, 26)
        Me.txtCodi.TabIndex = 0
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.Location = New System.Drawing.Point(8, 47)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(71, 23)
        Me.lblCodi.TabIndex = 42
        Me.lblCodi.Text = "Label1"
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(85, 7)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 41
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(8, 7)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 40
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(35, 213)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(376, 39)
        Me.TableLayoutPanel2.TabIndex = 39
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
        'txtDies
        '
        Me.txtDies.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDies.ForeColor = System.Drawing.Color.Blue
        Me.txtDies.Location = New System.Drawing.Point(87, 108)
        Me.txtDies.Name = "txtDies"
        Me.txtDies.Size = New System.Drawing.Size(83, 26)
        Me.txtDies.TabIndex = 2
        '
        'lblDies
        '
        Me.lblDies.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDies.Location = New System.Drawing.Point(7, 109)
        Me.lblDies.Name = "lblDies"
        Me.lblDies.Size = New System.Drawing.Size(71, 23)
        Me.lblDies.TabIndex = 48
        Me.lblDies.Text = "Label1"
        Me.lblDies.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'etqDies
        '
        Me.etqDies.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.etqDies.ForeColor = System.Drawing.Color.Blue
        Me.etqDies.Location = New System.Drawing.Point(176, 109)
        Me.etqDies.Name = "etqDies"
        Me.etqDies.Size = New System.Drawing.Size(253, 23)
        Me.etqDies.TabIndex = 49
        Me.etqDies.Text = "Label1"
        Me.etqDies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'etqDiaMes
        '
        Me.etqDiaMes.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.etqDiaMes.ForeColor = System.Drawing.Color.Blue
        Me.etqDiaMes.Location = New System.Drawing.Point(177, 141)
        Me.etqDiaMes.Name = "etqDiaMes"
        Me.etqDiaMes.Size = New System.Drawing.Size(261, 23)
        Me.etqDiaMes.TabIndex = 52
        Me.etqDiaMes.Text = "Label2"
        Me.etqDiaMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDia
        '
        Me.txtDia.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDia.ForeColor = System.Drawing.Color.Blue
        Me.txtDia.Location = New System.Drawing.Point(88, 140)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.Size = New System.Drawing.Size(83, 26)
        Me.txtDia.TabIndex = 3
        '
        'lblDia
        '
        Me.lblDia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDia.Location = New System.Drawing.Point(8, 141)
        Me.lblDia.Name = "lblDia"
        Me.lblDia.Size = New System.Drawing.Size(71, 23)
        Me.lblDia.TabIndex = 51
        Me.lblDia.Text = "Label1"
        Me.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xecActiu
        '
        Me.xecActiu.AutoSize = True
        Me.xecActiu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecActiu.ForeColor = System.Drawing.Color.Black
        Me.xecActiu.Location = New System.Drawing.Point(88, 172)
        Me.xecActiu.Name = "xecActiu"
        Me.xecActiu.Size = New System.Drawing.Size(59, 22)
        Me.xecActiu.TabIndex = 4
        Me.xecActiu.Text = "Xec1"
        Me.xecActiu.UseVisualStyleBackColor = True
        '
        'lblErrNom
        '
        Me.lblErrNom.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNom.ForeColor = System.Drawing.Color.Red
        Me.lblErrNom.Location = New System.Drawing.Point(395, 79)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(34, 23)
        Me.lblErrNom.TabIndex = 54
        Me.lblErrNom.Text = "(*) OBLIGATPORI"
        Me.lblErrNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DTipusPagament
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 264)
        Me.Controls.Add(Me.lblErrNom)
        Me.Controls.Add(Me.xecActiu)
        Me.Controls.Add(Me.etqDiaMes)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.lblDia)
        Me.Controls.Add(Me.etqDies)
        Me.Controls.Add(Me.txtDies)
        Me.Controls.Add(Me.lblDies)
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
        Me.Name = "DTipusPagament"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DTipusPagament"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNom As TextBox
    Friend WithEvents lblNom As Label
    Friend WithEvents lblErrCodi As Label
    Friend WithEvents txtCodi As TextBox
    Friend WithEvents lblCodi As Label
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents txtDies As TextBox
    Friend WithEvents lblDies As Label
    Friend WithEvents etqDies As Label
    Friend WithEvents etqDiaMes As Label
    Friend WithEvents txtDia As TextBox
    Friend WithEvents lblDia As Label
    Friend WithEvents xecActiu As XEC
    Friend WithEvents lblErrNom As Label
End Class
