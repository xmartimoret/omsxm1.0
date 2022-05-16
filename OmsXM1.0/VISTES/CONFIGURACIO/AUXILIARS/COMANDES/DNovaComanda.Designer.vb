<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DNovaComanda
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
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.cbProjecte = New OmsXM.CBBOX()
        Me.lblProjecte = New OmsXM.LBLRIGHT()
        Me.lblProveidor = New OmsXM.LBLRIGHT()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.pProveidor = New System.Windows.Forms.Panel()
        Me.cbResponsable = New OmsXM.CBBOX()
        Me.lblResponsable = New OmsXM.LBLRIGHT()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(107, 12)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(356, 26)
        Me.cbEmpresa.TabIndex = 0
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(15, 15)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(86, 18)
        Me.lblEmpresa.TabIndex = 2
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbProjecte
        '
        Me.cbProjecte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbProjecte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProjecte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProjecte.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbProjecte.ForeColor = System.Drawing.Color.Blue
        Me.cbProjecte.FormattingEnabled = True
        Me.cbProjecte.Location = New System.Drawing.Point(107, 44)
        Me.cbProjecte.Name = "cbProjecte"
        Me.cbProjecte.Size = New System.Drawing.Size(356, 26)
        Me.cbProjecte.TabIndex = 1
        '
        'lblProjecte
        '
        Me.lblProjecte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblProjecte.ForeColor = System.Drawing.Color.Black
        Me.lblProjecte.Location = New System.Drawing.Point(15, 47)
        Me.lblProjecte.Name = "lblProjecte"
        Me.lblProjecte.Size = New System.Drawing.Size(86, 18)
        Me.lblProjecte.TabIndex = 4
        Me.lblProjecte.Text = "Lblright1"
        Me.lblProjecte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProveidor
        '
        Me.lblProveidor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblProveidor.ForeColor = System.Drawing.Color.Black
        Me.lblProveidor.Location = New System.Drawing.Point(15, 133)
        Me.lblProveidor.Name = "lblProveidor"
        Me.lblProveidor.Size = New System.Drawing.Size(86, 18)
        Me.lblProveidor.TabIndex = 6
        Me.lblProveidor.Text = "Lblright1"
        Me.lblProveidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdGuardar, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdCancelar, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(89, 183)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(380, 36)
        Me.TableLayoutPanel2.TabIndex = 91
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(28, 3)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(211, 3)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 30)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancel"
        '
        'pProveidor
        '
        Me.pProveidor.Location = New System.Drawing.Point(107, 125)
        Me.pProveidor.Name = "pProveidor"
        Me.pProveidor.Size = New System.Drawing.Size(356, 37)
        Me.pProveidor.TabIndex = 3
        '
        'cbResponsable
        '
        Me.cbResponsable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbResponsable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbResponsable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbResponsable.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbResponsable.ForeColor = System.Drawing.Color.Blue
        Me.cbResponsable.FormattingEnabled = True
        Me.cbResponsable.Location = New System.Drawing.Point(107, 76)
        Me.cbResponsable.Name = "cbResponsable"
        Me.cbResponsable.Size = New System.Drawing.Size(356, 26)
        Me.cbResponsable.TabIndex = 2
        '
        'lblResponsable
        '
        Me.lblResponsable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblResponsable.ForeColor = System.Drawing.Color.Black
        Me.lblResponsable.Location = New System.Drawing.Point(-3, 79)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(104, 18)
        Me.lblResponsable.TabIndex = 93
        Me.lblResponsable.Text = "Lblright1"
        Me.lblResponsable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DNovaComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 231)
        Me.Controls.Add(Me.cbResponsable)
        Me.Controls.Add(Me.lblResponsable)
        Me.Controls.Add(Me.pProveidor)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.lblProveidor)
        Me.Controls.Add(Me.cbProjecte)
        Me.Controls.Add(Me.lblProjecte)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.lblEmpresa)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DNovaComanda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DNovaComanda"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cbEmpresa As CBBOX
    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents cbProjecte As CBBOX
    Friend WithEvents lblProjecte As LBLRIGHT
    Friend WithEvents lblProveidor As LBLRIGHT
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents pProveidor As Panel
    Friend WithEvents cbResponsable As CBBOX
    Friend WithEvents lblResponsable As LBLRIGHT
End Class
