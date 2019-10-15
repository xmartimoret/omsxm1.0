<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DPrefixSubcompte
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
        Me.cmdCancelar = New BOTO()
        Me.cmdGuardar = New BOTO()
        Me.lblErrSubcompte = New LBLRED()
        Me.lblSubcompte = New LBLRIGHT()
        Me.lblErrPrefix = New LBLRED()
        Me.txtPrefix = New TXT()
        Me.lblPrefix = New LBLRIGHT()
        Me.lblId = New LBLBLUE()
        Me.lblIdCaption = New LBLRIGHT()
        Me.cbSubcompte = New CBBOX()
        Me.cmdActualitzarSubcomptes = New BOTO()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(89, 125)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(406, 39)
        Me.TableLayoutPanel1.TabIndex = 28
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
        Me.cmdCancelar.Location = New System.Drawing.Point(230, 4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancel"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdGuardar.AutoSize = True
        Me.cmdGuardar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(35, 4)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "OK"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'lblErrSubcompte
        '
        Me.lblErrSubcompte.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrSubcompte.ForeColor = System.Drawing.Color.Red
        Me.lblErrSubcompte.Location = New System.Drawing.Point(371, 72)
        Me.lblErrSubcompte.Name = "lblErrSubcompte"
        Me.lblErrSubcompte.Size = New System.Drawing.Size(139, 23)
        Me.lblErrSubcompte.TabIndex = 36
        Me.lblErrSubcompte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubcompte
        '
        Me.lblSubcompte.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubcompte.ForeColor = System.Drawing.Color.Black
        Me.lblSubcompte.Location = New System.Drawing.Point(12, 73)
        Me.lblSubcompte.Name = "lblSubcompte"
        Me.lblSubcompte.Size = New System.Drawing.Size(71, 23)
        Me.lblSubcompte.TabIndex = 34
        Me.lblSubcompte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrPrefix
        '
        Me.lblErrPrefix.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrPrefix.ForeColor = System.Drawing.Color.Red
        Me.lblErrPrefix.Location = New System.Drawing.Point(229, 39)
        Me.lblErrPrefix.Name = "lblErrPrefix"
        Me.lblErrPrefix.Size = New System.Drawing.Size(156, 23)
        Me.lblErrPrefix.TabIndex = 33
        Me.lblErrPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrefix
        '
        Me.txtPrefix.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPrefix.ForeColor = System.Drawing.Color.Blue
        Me.txtPrefix.Location = New System.Drawing.Point(89, 36)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(134, 26)
        Me.txtPrefix.TabIndex = 32
        '
        'lblPrefix
        '
        Me.lblPrefix.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefix.ForeColor = System.Drawing.Color.Black
        Me.lblPrefix.Location = New System.Drawing.Point(9, 40)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(71, 23)
        Me.lblPrefix.TabIndex = 31
        Me.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Location = New System.Drawing.Point(86, 7)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 30
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.ForeColor = System.Drawing.Color.Black
        Me.lblIdCaption.Location = New System.Drawing.Point(9, 7)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(71, 23)
        Me.lblIdCaption.TabIndex = 29
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbSubcompte
        '
        Me.cbSubcompte.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbSubcompte.ForeColor = System.Drawing.Color.Blue
        Me.cbSubcompte.Location = New System.Drawing.Point(89, 72)
        Me.cbSubcompte.Name = "cbSubcompte"
        Me.cbSubcompte.Size = New System.Drawing.Size(276, 26)
        Me.cbSubcompte.TabIndex = 37
        '
        'cmdActualitzarSubcomptes
        '
        Me.cmdActualitzarSubcomptes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdActualitzarSubcomptes.AutoSize = True
        Me.cmdActualitzarSubcomptes.BackColor = System.Drawing.Color.SeaShell
        Me.cmdActualitzarSubcomptes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdActualitzarSubcomptes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdActualitzarSubcomptes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdActualitzarSubcomptes.Location = New System.Drawing.Point(319, 3)
        Me.cmdActualitzarSubcomptes.Name = "cmdActualitzarSubcomptes"
        Me.cmdActualitzarSubcomptes.Size = New System.Drawing.Size(176, 31)
        Me.cmdActualitzarSubcomptes.TabIndex = 38
        Me.cmdActualitzarSubcomptes.UseVisualStyleBackColor = False
        '
        'DPrefixSubcompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 176)
        Me.Controls.Add(Me.cmdActualitzarSubcomptes)
        Me.Controls.Add(Me.cbSubcompte)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblErrSubcompte)
        Me.Controls.Add(Me.lblSubcompte)
        Me.Controls.Add(Me.lblErrPrefix)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DPrefixSubcompte"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DPrefixSubcompte"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents lblErrSubcompte As LBLRED
    Friend WithEvents lblSubcompte As LBLRIGHT
    Friend WithEvents lblErrPrefix As LBLRED
    Friend WithEvents txtPrefix As TXT
    Friend WithEvents lblPrefix As LBLRIGHT
    Friend WithEvents lblId As LBLBLUE
    Friend WithEvents lblIdCaption As LBLRIGHT
    Friend WithEvents cbSubcompte As CBBOX
    Friend WithEvents cmdActualitzarSubcomptes As BOTO
End Class
