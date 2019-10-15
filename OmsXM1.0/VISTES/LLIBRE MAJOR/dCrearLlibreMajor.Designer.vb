<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dCrearLlibreMajor
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
        Me.pDataIni = New System.Windows.Forms.Panel()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblErrorEmpresa = New System.Windows.Forms.Label()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblErrorAny = New System.Windows.Forms.Label()
        Me.cbAny = New System.Windows.Forms.ComboBox()
        Me.lblAny = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pDataFinal = New System.Windows.Forms.Panel()
        Me.lblDataIni = New System.Windows.Forms.Label()
        Me.lblDataFi = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pDirectori = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblErrProjectes = New System.Windows.Forms.Label()
        Me.lblErrorDataDeparta = New System.Windows.Forms.Label()
        Me.lblErrorSelectAny = New System.Windows.Forms.Label()
        Me.lblDepartamentProjecte = New System.Windows.Forms.Label()
        Me.cmdDepartaments = New OmsXM.BOTO()
        Me.lstDepartaments = New OmsXM.LSTBOX()
        Me.lstProjectes = New OmsXM.LSTBOX()
        Me.cmdProjectes = New OmsXM.BOTO()
        Me.cmdCancelar = New OmsXM.BOTO()
        Me.cmdCrear = New OmsXM.BOTO()
        Me.lblInfoImport = New OmsXM.LBLBLUE()
        Me.lblBorrarDeparta = New System.Windows.Forms.LinkLabel()
        Me.lblBorrarProjecte = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'pDataIni
        '
        Me.pDataIni.Location = New System.Drawing.Point(127, 323)
        Me.pDataIni.Name = "pDataIni"
        Me.pDataIni.Size = New System.Drawing.Size(111, 25)
        Me.pDataIni.TabIndex = 0
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(0, 4)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(119, 20)
        Me.lblEmpresa.TabIndex = 53
        Me.lblEmpresa.Text = "Empresa:"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrorEmpresa
        '
        Me.lblErrorEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorEmpresa.ForeColor = System.Drawing.Color.Red
        Me.lblErrorEmpresa.Location = New System.Drawing.Point(312, 8)
        Me.lblErrorEmpresa.Name = "lblErrorEmpresa"
        Me.lblErrorEmpresa.Size = New System.Drawing.Size(128, 20)
        Me.lblErrorEmpresa.TabIndex = 57
        Me.lblErrorEmpresa.Text = "(*)OBLIGATORI"
        Me.lblErrorEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(125, 4)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(181, 24)
        Me.cbEmpresa.TabIndex = 56
        '
        'lblErrorAny
        '
        Me.lblErrorAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrorAny.Location = New System.Drawing.Point(312, 38)
        Me.lblErrorAny.Name = "lblErrorAny"
        Me.lblErrorAny.Size = New System.Drawing.Size(128, 20)
        Me.lblErrorAny.TabIndex = 63
        Me.lblErrorAny.Text = "(*)OBLIGATORI"
        Me.lblErrorAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAny
        '
        Me.cbAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAny.ForeColor = System.Drawing.Color.Blue
        Me.cbAny.FormattingEnabled = True
        Me.cbAny.Location = New System.Drawing.Point(125, 34)
        Me.cbAny.Name = "cbAny"
        Me.cbAny.Size = New System.Drawing.Size(111, 24)
        Me.cbAny.TabIndex = 61
        '
        'lblAny
        '
        Me.lblAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAny.Location = New System.Drawing.Point(0, 33)
        Me.lblAny.Name = "lblAny"
        Me.lblAny.Size = New System.Drawing.Size(119, 20)
        Me.lblAny.TabIndex = 62
        Me.lblAny.Text = "Empresa:"
        Me.lblAny.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(480, 2)
        Me.Label5.TabIndex = 68
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pDataFinal
        '
        Me.pDataFinal.Location = New System.Drawing.Point(365, 323)
        Me.pDataFinal.Name = "pDataFinal"
        Me.pDataFinal.Size = New System.Drawing.Size(112, 25)
        Me.pDataFinal.TabIndex = 1
        '
        'lblDataIni
        '
        Me.lblDataIni.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataIni.Location = New System.Drawing.Point(9, 323)
        Me.lblDataIni.Name = "lblDataIni"
        Me.lblDataIni.Size = New System.Drawing.Size(112, 18)
        Me.lblDataIni.TabIndex = 70
        Me.lblDataIni.Text = "Empresa:"
        Me.lblDataIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDataFi
        '
        Me.lblDataFi.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataFi.Location = New System.Drawing.Point(253, 323)
        Me.lblDataFi.Name = "lblDataFi"
        Me.lblDataFi.Size = New System.Drawing.Size(106, 18)
        Me.lblDataFi.TabIndex = 71
        Me.lblDataFi.Text = "Empresa:"
        Me.lblDataFi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 318)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(480, 2)
        Me.Label3.TabIndex = 72
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pDirectori
        '
        Me.pDirectori.Location = New System.Drawing.Point(14, 358)
        Me.pDirectori.Name = "pDirectori"
        Me.pDirectori.Size = New System.Drawing.Size(463, 69)
        Me.pDirectori.TabIndex = 73
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 450)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(480, 2)
        Me.Label6.TabIndex = 75
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblErrProjectes
        '
        Me.lblErrProjectes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrProjectes.ForeColor = System.Drawing.Color.Red
        Me.lblErrProjectes.Location = New System.Drawing.Point(20, 212)
        Me.lblErrProjectes.Name = "lblErrProjectes"
        Me.lblErrProjectes.Size = New System.Drawing.Size(378, 20)
        Me.lblErrProjectes.TabIndex = 80
        Me.lblErrProjectes.Text = "(*)OBLIGATORI"
        Me.lblErrProjectes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrorDataDeparta
        '
        Me.lblErrorDataDeparta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDataDeparta.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDataDeparta.Location = New System.Drawing.Point(12, 430)
        Me.lblErrorDataDeparta.Name = "lblErrorDataDeparta"
        Me.lblErrorDataDeparta.Size = New System.Drawing.Size(466, 20)
        Me.lblErrorDataDeparta.TabIndex = 81
        Me.lblErrorDataDeparta.Text = "(*)OBLIGATORI"
        Me.lblErrorDataDeparta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrorSelectAny
        '
        Me.lblErrorSelectAny.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorSelectAny.ForeColor = System.Drawing.Color.Red
        Me.lblErrorSelectAny.Location = New System.Drawing.Point(12, 323)
        Me.lblErrorSelectAny.Name = "lblErrorSelectAny"
        Me.lblErrorSelectAny.Size = New System.Drawing.Size(465, 32)
        Me.lblErrorSelectAny.TabIndex = 83
        Me.lblErrorSelectAny.Text = "(*)OBLIGATORI"
        Me.lblErrorSelectAny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDepartamentProjecte
        '
        Me.lblDepartamentProjecte.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamentProjecte.Location = New System.Drawing.Point(17, 110)
        Me.lblDepartamentProjecte.Name = "lblDepartamentProjecte"
        Me.lblDepartamentProjecte.Size = New System.Drawing.Size(463, 20)
        Me.lblDepartamentProjecte.TabIndex = 85
        Me.lblDepartamentProjecte.Text = "Empresa:"
        Me.lblDepartamentProjecte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDepartaments
        '
        Me.cmdDepartaments.AutoSize = True
        Me.cmdDepartaments.BackColor = System.Drawing.Color.SeaShell
        Me.cmdDepartaments.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdDepartaments.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdDepartaments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdDepartaments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDepartaments.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdDepartaments.Location = New System.Drawing.Point(380, 133)
        Me.cmdDepartaments.Name = "cmdDepartaments"
        Me.cmdDepartaments.Size = New System.Drawing.Size(97, 33)
        Me.cmdDepartaments.TabIndex = 84
        Me.cmdDepartaments.Text = "Boto3"
        Me.cmdDepartaments.UseVisualStyleBackColor = False
        '
        'lstDepartaments
        '
        Me.lstDepartaments.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lstDepartaments.ForeColor = System.Drawing.Color.Blue
        Me.lstDepartaments.FormattingEnabled = True
        Me.lstDepartaments.ItemHeight = 18
        Me.lstDepartaments.Location = New System.Drawing.Point(18, 133)
        Me.lstDepartaments.Name = "lstDepartaments"
        Me.lstDepartaments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstDepartaments.Size = New System.Drawing.Size(356, 76)
        Me.lstDepartaments.TabIndex = 83
        '
        'lstProjectes
        '
        Me.lstProjectes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lstProjectes.ForeColor = System.Drawing.Color.Blue
        Me.lstProjectes.FormattingEnabled = True
        Me.lstProjectes.ItemHeight = 18
        Me.lstProjectes.Location = New System.Drawing.Point(20, 235)
        Me.lstProjectes.Name = "lstProjectes"
        Me.lstProjectes.Size = New System.Drawing.Size(354, 76)
        Me.lstProjectes.TabIndex = 82
        '
        'cmdProjectes
        '
        Me.cmdProjectes.AutoSize = True
        Me.cmdProjectes.BackColor = System.Drawing.Color.SeaShell
        Me.cmdProjectes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdProjectes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdProjectes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdProjectes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProjectes.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdProjectes.Location = New System.Drawing.Point(380, 235)
        Me.cmdProjectes.Name = "cmdProjectes"
        Me.cmdProjectes.Size = New System.Drawing.Size(97, 33)
        Me.cmdProjectes.TabIndex = 78
        Me.cmdProjectes.Text = "Boto3"
        Me.cmdProjectes.UseVisualStyleBackColor = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.AutoSize = True
        Me.cmdCancelar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(329, 459)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(111, 30)
        Me.cmdCancelar.TabIndex = 77
        Me.cmdCancelar.Text = "Boto2"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdCrear
        '
        Me.cmdCrear.AutoSize = True
        Me.cmdCrear.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCrear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCrear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCrear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCrear.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCrear.Location = New System.Drawing.Point(32, 459)
        Me.cmdCrear.Name = "cmdCrear"
        Me.cmdCrear.Size = New System.Drawing.Size(140, 30)
        Me.cmdCrear.TabIndex = 76
        Me.cmdCrear.Text = "Boto1"
        Me.cmdCrear.UseVisualStyleBackColor = False
        '
        'lblInfoImport
        '
        Me.lblInfoImport.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoImport.ForeColor = System.Drawing.Color.Blue
        Me.lblInfoImport.Location = New System.Drawing.Point(15, 61)
        Me.lblInfoImport.Name = "lblInfoImport"
        Me.lblInfoImport.Size = New System.Drawing.Size(455, 46)
        Me.lblInfoImport.TabIndex = 64
        '
        'lblBorrarDeparta
        '
        Me.lblBorrarDeparta.AutoSize = True
        Me.lblBorrarDeparta.Location = New System.Drawing.Point(381, 196)
        Me.lblBorrarDeparta.Name = "lblBorrarDeparta"
        Me.lblBorrarDeparta.Size = New System.Drawing.Size(68, 13)
        Me.lblBorrarDeparta.TabIndex = 86
        Me.lblBorrarDeparta.TabStop = True
        Me.lblBorrarDeparta.Text = "Borrar Select"
        '
        'lblBorrarProjecte
        '
        Me.lblBorrarProjecte.AutoSize = True
        Me.lblBorrarProjecte.Location = New System.Drawing.Point(381, 287)
        Me.lblBorrarProjecte.Name = "lblBorrarProjecte"
        Me.lblBorrarProjecte.Size = New System.Drawing.Size(59, 13)
        Me.lblBorrarProjecte.TabIndex = 87
        Me.lblBorrarProjecte.TabStop = True
        Me.lblBorrarProjecte.Text = "LinkLabel2"
        '
        'dCrearLlibreMajor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 495)
        Me.Controls.Add(Me.lblBorrarProjecte)
        Me.Controls.Add(Me.lblBorrarDeparta)
        Me.Controls.Add(Me.lblDepartamentProjecte)
        Me.Controls.Add(Me.lblErrProjectes)
        Me.Controls.Add(Me.cmdDepartaments)
        Me.Controls.Add(Me.lblErrorSelectAny)
        Me.Controls.Add(Me.lstDepartaments)
        Me.Controls.Add(Me.lstProjectes)
        Me.Controls.Add(Me.lblErrorDataDeparta)
        Me.Controls.Add(Me.cmdProjectes)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdCrear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pDirectori)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDataFi)
        Me.Controls.Add(Me.lblDataIni)
        Me.Controls.Add(Me.pDataFinal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblInfoImport)
        Me.Controls.Add(Me.lblErrorAny)
        Me.Controls.Add(Me.cbAny)
        Me.Controls.Add(Me.lblAny)
        Me.Controls.Add(Me.lblErrorEmpresa)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.pDataIni)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dCrearLlibreMajor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dCrearLlibreMajor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pDataIni As Panel
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents lblErrorEmpresa As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents lblErrorAny As Label
    Friend WithEvents cbAny As ComboBox
    Friend WithEvents lblAny As Label
    Friend WithEvents lblInfoImport As LBLBLUE
    Friend WithEvents Label5 As Label
    Friend WithEvents pDataFinal As Panel
    Friend WithEvents lblDataIni As Label
    Friend WithEvents lblDataFi As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pDirectori As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdCrear As BOTO
    Friend WithEvents cmdCancelar As BOTO
    Friend WithEvents cmdProjectes As BOTO
    Friend WithEvents lblErrProjectes As Label
    Friend WithEvents lblErrorDataDeparta As Label
    Friend WithEvents lstProjectes As LSTBOX
    Friend WithEvents lblErrorSelectAny As Label
    Friend WithEvents lstDepartaments As LSTBOX
    Friend WithEvents cmdDepartaments As BOTO
    Friend WithEvents lblDepartamentProjecte As Label
    Friend WithEvents lblBorrarDeparta As LinkLabel
    Friend WithEvents lblBorrarProjecte As LinkLabel
End Class
