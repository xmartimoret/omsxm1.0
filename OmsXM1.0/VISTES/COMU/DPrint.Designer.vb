<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DPrint
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
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdGuardar = New OmsXM.BOTO()
        Me.lblTipus = New OmsXM.LBLRIGHT()
        Me.LblTipusInforme = New OmsXM.LBLRIGHT()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.optRegistres = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optRegistreActual = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.optExcel = New System.Windows.Forms.RadioButton()
        Me.optPdf = New System.Windows.Forms.RadioButton()
        Me.panelDirectori = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(227, 276)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 30)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.AutoSize = True
        Me.cmdGuardar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(51, 276)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(75, 30)
        Me.cmdGuardar.TabIndex = 2
        Me.cmdGuardar.Text = "Boto1"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'lblTipus
        '
        Me.lblTipus.AutoSize = True
        Me.lblTipus.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipus.ForeColor = System.Drawing.Color.Black
        Me.lblTipus.Location = New System.Drawing.Point(13, 96)
        Me.lblTipus.Name = "lblTipus"
        Me.lblTipus.Size = New System.Drawing.Size(112, 18)
        Me.lblTipus.TabIndex = 6
        Me.lblTipus.Text = "Tipus Impressio"
        Me.lblTipus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTipusInforme
        '
        Me.LblTipusInforme.AutoSize = True
        Me.LblTipusInforme.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipusInforme.ForeColor = System.Drawing.Color.Black
        Me.LblTipusInforme.Location = New System.Drawing.Point(12, 9)
        Me.LblTipusInforme.Name = "LblTipusInforme"
        Me.LblTipusInforme.Size = New System.Drawing.Size(72, 18)
        Me.LblTipusInforme.TabIndex = 8
        Me.LblTipusInforme.Text = "Registres:"
        Me.LblTipusInforme.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(50, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 66)
        Me.Panel1.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.optRegistres)
        Me.Panel3.Location = New System.Drawing.Point(3, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(238, 28)
        Me.Panel3.TabIndex = 12
        '
        'optRegistres
        '
        Me.optRegistres.AutoSize = True
        Me.optRegistres.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.optRegistres.Location = New System.Drawing.Point(3, 3)
        Me.optRegistres.Name = "optRegistres"
        Me.optRegistres.Size = New System.Drawing.Size(107, 17)
        Me.optRegistres.TabIndex = 9
        Me.optRegistres.TabStop = True
        Me.optRegistres.Text = "Registres Actuals"
        Me.optRegistres.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optRegistreActual)
        Me.Panel2.Location = New System.Drawing.Point(53, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(238, 28)
        Me.Panel2.TabIndex = 11
        '
        'optRegistreActual
        '
        Me.optRegistreActual.AutoSize = True
        Me.optRegistreActual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.optRegistreActual.Location = New System.Drawing.Point(3, 3)
        Me.optRegistreActual.Name = "optRegistreActual"
        Me.optRegistreActual.Size = New System.Drawing.Size(123, 17)
        Me.optRegistreActual.TabIndex = 9
        Me.optRegistreActual.TabStop = True
        Me.optRegistreActual.Text = "Registre Seleccionat"
        Me.optRegistreActual.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.optExcel)
        Me.Panel4.Controls.Add(Me.optPdf)
        Me.Panel4.Location = New System.Drawing.Point(53, 117)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(192, 40)
        Me.Panel4.TabIndex = 13
        '
        'optExcel
        '
        Me.optExcel.Image = Global.OmsXM.My.Resources.Resources.excel
        Me.optExcel.Location = New System.Drawing.Point(21, 3)
        Me.optExcel.Name = "optExcel"
        Me.optExcel.Size = New System.Drawing.Size(64, 35)
        Me.optExcel.TabIndex = 5
        Me.optExcel.TabStop = True
        Me.optExcel.UseVisualStyleBackColor = True
        '
        'optPdf
        '
        Me.optPdf.Image = Global.OmsXM.My.Resources.Resources.pdf
        Me.optPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.optPdf.Location = New System.Drawing.Point(91, 1)
        Me.optPdf.Name = "optPdf"
        Me.optPdf.Size = New System.Drawing.Size(55, 37)
        Me.optPdf.TabIndex = 7
        Me.optPdf.TabStop = True
        Me.optPdf.UseVisualStyleBackColor = True
        '
        'panelDirectori
        '
        Me.panelDirectori.Location = New System.Drawing.Point(5, 163)
        Me.panelDirectori.Name = "panelDirectori"
        Me.panelDirectori.Size = New System.Drawing.Size(317, 95)
        Me.panelDirectori.TabIndex = 13
        '
        'DPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 318)
        Me.Controls.Add(Me.panelDirectori)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblTipusInforme)
        Me.Controls.Add(Me.lblTipus)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DPrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdGuardar As BOTO
    Friend WithEvents optExcel As RadioButton
    Friend WithEvents lblTipus As LBLRIGHT
    Friend WithEvents optPdf As RadioButton
    Friend WithEvents LblTipusInforme As LBLRIGHT
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents optRegistres As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents optRegistreActual As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents panelDirectori As Panel
End Class
