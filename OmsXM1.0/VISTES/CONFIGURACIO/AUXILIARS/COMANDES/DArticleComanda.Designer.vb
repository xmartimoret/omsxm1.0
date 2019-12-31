<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DArticleComanda
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
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblCaptionTotal = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.panelTipusIva = New System.Windows.Forms.Panel()
        Me.lblDescompte = New System.Windows.Forms.Label()
        Me.txtDescompte = New System.Windows.Forms.TextBox()
        Me.lblPreu = New System.Windows.Forms.Label()
        Me.txtPreu = New System.Windows.Forms.TextBox()
        Me.lblDescripcio = New System.Windows.Forms.Label()
        Me.txtDescripcio = New System.Windows.Forms.TextBox()
        Me.lblUnitat = New System.Windows.Forms.Label()
        Me.panelUnitats = New System.Windows.Forms.Panel()
        Me.txtQuantitat = New System.Windows.Forms.TextBox()
        Me.lblQuantitat = New System.Windows.Forms.Label()
        Me.txtCodi = New System.Windows.Forms.TextBox()
        Me.lblCodi = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCercador = New System.Windows.Forms.Button()
        Me.cmdCercadorPreus = New System.Windows.Forms.Button()
        Me.lblInfoPreu = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdGuardar, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdCancelar, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(50, 251)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(376, 36)
        Me.TableLayoutPanel2.TabIndex = 90
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
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(92, 223)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(128, 20)
        Me.lblTotal.TabIndex = 89
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblCaptionTotal
        '
        Me.lblCaptionTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionTotal.Location = New System.Drawing.Point(12, 224)
        Me.lblCaptionTotal.Name = "lblCaptionTotal"
        Me.lblCaptionTotal.Size = New System.Drawing.Size(71, 20)
        Me.lblCaptionTotal.TabIndex = 88
        Me.lblCaptionTotal.Text = "Label1"
        Me.lblCaptionTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIva
        '
        Me.lblIva.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva.Location = New System.Drawing.Point(12, 185)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(71, 20)
        Me.lblIva.TabIndex = 87
        Me.lblIva.Text = "Label1"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelTipusIva
        '
        Me.panelTipusIva.Location = New System.Drawing.Point(92, 180)
        Me.panelTipusIva.Name = "panelTipusIva"
        Me.panelTipusIva.Size = New System.Drawing.Size(177, 30)
        Me.panelTipusIva.TabIndex = 86
        '
        'lblDescompte
        '
        Me.lblDescompte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescompte.Location = New System.Drawing.Point(12, 147)
        Me.lblDescompte.Name = "lblDescompte"
        Me.lblDescompte.Size = New System.Drawing.Size(71, 20)
        Me.lblDescompte.TabIndex = 85
        Me.lblDescompte.Text = "Label1"
        Me.lblDescompte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescompte
        '
        Me.txtDescompte.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDescompte.ForeColor = System.Drawing.Color.Blue
        Me.txtDescompte.Location = New System.Drawing.Point(92, 144)
        Me.txtDescompte.Name = "txtDescompte"
        Me.txtDescompte.Size = New System.Drawing.Size(59, 26)
        Me.txtDescompte.TabIndex = 84
        '
        'lblPreu
        '
        Me.lblPreu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreu.Location = New System.Drawing.Point(12, 117)
        Me.lblPreu.Name = "lblPreu"
        Me.lblPreu.Size = New System.Drawing.Size(71, 20)
        Me.lblPreu.TabIndex = 83
        Me.lblPreu.Text = "Label1"
        Me.lblPreu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPreu
        '
        Me.txtPreu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPreu.ForeColor = System.Drawing.Color.Blue
        Me.txtPreu.Location = New System.Drawing.Point(92, 114)
        Me.txtPreu.Name = "txtPreu"
        Me.txtPreu.Size = New System.Drawing.Size(128, 26)
        Me.txtPreu.TabIndex = 82
        '
        'lblDescripcio
        '
        Me.lblDescripcio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcio.Location = New System.Drawing.Point(12, 83)
        Me.lblDescripcio.Name = "lblDescripcio"
        Me.lblDescripcio.Size = New System.Drawing.Size(71, 20)
        Me.lblDescripcio.TabIndex = 81
        Me.lblDescripcio.Text = "Label1"
        Me.lblDescripcio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescripcio
        '
        Me.txtDescripcio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcio.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDescripcio.ForeColor = System.Drawing.Color.Blue
        Me.txtDescripcio.Location = New System.Drawing.Point(92, 80)
        Me.txtDescripcio.Name = "txtDescripcio"
        Me.txtDescripcio.Size = New System.Drawing.Size(334, 26)
        Me.txtDescripcio.TabIndex = 80
        '
        'lblUnitat
        '
        Me.lblUnitat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnitat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitat.Location = New System.Drawing.Point(172, 48)
        Me.lblUnitat.Name = "lblUnitat"
        Me.lblUnitat.Size = New System.Drawing.Size(71, 20)
        Me.lblUnitat.TabIndex = 79
        Me.lblUnitat.Text = "Label1"
        Me.lblUnitat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelUnitats
        '
        Me.panelUnitats.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelUnitats.Location = New System.Drawing.Point(249, 44)
        Me.panelUnitats.Name = "panelUnitats"
        Me.panelUnitats.Size = New System.Drawing.Size(177, 30)
        Me.panelUnitats.TabIndex = 78
        '
        'txtQuantitat
        '
        Me.txtQuantitat.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtQuantitat.ForeColor = System.Drawing.Color.Blue
        Me.txtQuantitat.Location = New System.Drawing.Point(92, 44)
        Me.txtQuantitat.Multiline = True
        Me.txtQuantitat.Name = "txtQuantitat"
        Me.txtQuantitat.Size = New System.Drawing.Size(59, 24)
        Me.txtQuantitat.TabIndex = 75
        Me.txtQuantitat.Text = "1"
        '
        'lblQuantitat
        '
        Me.lblQuantitat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantitat.Location = New System.Drawing.Point(12, 48)
        Me.lblQuantitat.Name = "lblQuantitat"
        Me.lblQuantitat.Size = New System.Drawing.Size(71, 20)
        Me.lblQuantitat.TabIndex = 77
        Me.lblQuantitat.Text = "Label1"
        Me.lblQuantitat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodi
        '
        Me.txtCodi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCodi.Location = New System.Drawing.Point(92, 12)
        Me.txtCodi.Name = "txtCodi"
        Me.txtCodi.Size = New System.Drawing.Size(157, 26)
        Me.txtCodi.TabIndex = 74
        '
        'lblCodi
        '
        Me.lblCodi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodi.Location = New System.Drawing.Point(12, 16)
        Me.lblCodi.Name = "lblCodi"
        Me.lblCodi.Size = New System.Drawing.Size(71, 20)
        Me.lblCodi.TabIndex = 76
        Me.lblCodi.Text = "Label1"
        Me.lblCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(157, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 20)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "%"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmdCercador
        '
        Me.cmdCercador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCercador.Image = Global.OmsXM.My.Resources.Resources.BotoCercar
        Me.cmdCercador.Location = New System.Drawing.Point(255, 11)
        Me.cmdCercador.Name = "cmdCercador"
        Me.cmdCercador.Size = New System.Drawing.Size(26, 28)
        Me.cmdCercador.TabIndex = 92
        Me.cmdCercador.UseVisualStyleBackColor = True
        '
        'cmdCercadorPreus
        '
        Me.cmdCercadorPreus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCercadorPreus.Image = Global.OmsXM.My.Resources.Resources.BotoCercar
        Me.cmdCercadorPreus.Location = New System.Drawing.Point(226, 113)
        Me.cmdCercadorPreus.Name = "cmdCercadorPreus"
        Me.cmdCercadorPreus.Size = New System.Drawing.Size(26, 28)
        Me.cmdCercadorPreus.TabIndex = 94
        Me.cmdCercadorPreus.UseVisualStyleBackColor = True
        '
        'lblInfoPreu
        '
        Me.lblInfoPreu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoPreu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblInfoPreu.Location = New System.Drawing.Point(258, 114)
        Me.lblInfoPreu.Name = "lblInfoPreu"
        Me.lblInfoPreu.Size = New System.Drawing.Size(168, 54)
        Me.lblInfoPreu.TabIndex = 95
        '
        'DArticleComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 299)
        Me.Controls.Add(Me.lblInfoPreu)
        Me.Controls.Add(Me.cmdCercadorPreus)
        Me.Controls.Add(Me.cmdCercador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblCaptionTotal)
        Me.Controls.Add(Me.lblIva)
        Me.Controls.Add(Me.panelTipusIva)
        Me.Controls.Add(Me.lblDescompte)
        Me.Controls.Add(Me.txtDescompte)
        Me.Controls.Add(Me.lblPreu)
        Me.Controls.Add(Me.txtPreu)
        Me.Controls.Add(Me.lblDescripcio)
        Me.Controls.Add(Me.txtDescripcio)
        Me.Controls.Add(Me.lblUnitat)
        Me.Controls.Add(Me.panelUnitats)
        Me.Controls.Add(Me.txtQuantitat)
        Me.Controls.Add(Me.lblQuantitat)
        Me.Controls.Add(Me.txtCodi)
        Me.Controls.Add(Me.lblCodi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DArticleComanda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DArticleComanda"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdGuardar As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblCaptionTotal As Label
    Friend WithEvents lblIva As Label
    Friend WithEvents panelTipusIva As Panel
    Friend WithEvents lblDescompte As Label
    Friend WithEvents txtDescompte As TextBox
    Friend WithEvents lblPreu As Label
    Friend WithEvents txtPreu As TextBox
    Friend WithEvents lblDescripcio As Label
    Friend WithEvents txtDescripcio As TextBox
    Friend WithEvents lblUnitat As Label
    Friend WithEvents panelUnitats As Panel
    Friend WithEvents txtQuantitat As TextBox
    Friend WithEvents lblQuantitat As Label
    Friend WithEvents txtCodi As TextBox
    Friend WithEvents lblCodi As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCercador As Button
    Friend WithEvents cmdCercadorPreus As Button
    Friend WithEvents lblInfoPreu As Label
End Class
