<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DSubgrup
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
        Me.cmdCancelar = New BOTO
        Me.cmdGuardar = New BOTO
        Me.lblErrNom = New LBLRED
        Me.txtNom = New TXT
        Me.lblNom = New LBLRIGHT
        Me.lblErrCodi = New LBLRED
        Me.txtCodi = New TXT
        Me.lblCodi = New LBLRIGHT
        Me.lblId = New LBLBLUE
        Me.lblIdCaption = New LBLRIGHT
        Me.xecCompres = New XEC
        Me.xecVariables = New XEC
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(89, 161)
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

        '
        'cmdGuardar
        '

        Me.cmdGuardar.Location = New System.Drawing.Point(35, 4)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 0
        '
        'lblErrNom

        Me.lblErrNom.Location = New System.Drawing.Point(374, 76)
        Me.lblErrNom.Name = "lblErrNom"
        Me.lblErrNom.Size = New System.Drawing.Size(139, 23)
        Me.lblErrNom.TabIndex = 36


        '
        'txtNom
        '

        Me.txtNom.Location = New System.Drawing.Point(92, 72)
        Me.txtNom.Multiline = True
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(276, 27)
        Me.txtNom.TabIndex = 35
        '
        'lblNom
        '

        Me.lblNom.Location = New System.Drawing.Point(12, 76)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(71, 23)
        Me.lblNom.TabIndex = 34
        '
        'lblErrCodi
        '

        Me.lblErrCodi.Location = New System.Drawing.Point(184, 43)
        Me.lblErrCodi.Name = "lblErrCodi"
        Me.lblErrCodi.Size = New System.Drawing.Size(156, 23)
        Me.lblErrCodi.TabIndex = 33

        '
        'txtCodi
        '

        Me.txtCodi.Location = New System.Drawing.Point(92, 40)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(86, 26)
        Me.txtCodi.TabIndex = 32
        '
        'lblCodi
        '

        Me.lblCodi.Location = New System.Drawing.Point(12, 44)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(71, 23)
        Me.lblCodi.TabIndex = 31


        '
        'lblId
        '

        Me.lblId.Location = New System.Drawing.Point(89, 11)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(64, 23)
        Me.lblId.TabIndex = 30


        '
        'lblIdCaption
        '

        Me.lblIdCaption.Location = New System.Drawing.Point(12, 11)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 29


        '
        'xecCompres
        '

        Me.xecCompres.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecCompres.Location = New System.Drawing.Point(92, 105)
        Me.xecCompres.Name = "xecCompres"
        Me.xecCompres.Size = New System.Drawing.Size(99, 22)
        Me.xecCompres.TabIndex = 37


        '
        'xecVariables
        '

        Me.xecVariables.Location = New System.Drawing.Point(92, 133)
        Me.xecVariables.Name = "xecVariables"
        Me.xecVariables.Size = New System.Drawing.Size(99, 22)
        Me.xecVariables.TabIndex = 38

        '
        'DSubgrup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 212)
        Me.Controls.Add(Me.xecVariables)
        Me.Controls.Add(Me.xecCompres)
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
        Me.Name = "DSubgrup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DSubgrup"
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
    Friend WithEvents xecCompres As CheckBox
    Friend WithEvents xecVariables As CheckBox
End Class
