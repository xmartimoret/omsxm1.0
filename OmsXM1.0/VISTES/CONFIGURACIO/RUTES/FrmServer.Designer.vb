<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtClau = New System.Windows.Forms.TextBox()
        Me.lblClau = New System.Windows.Forms.Label()
        Me.txtUsuari = New System.Windows.Forms.TextBox()
        Me.lblUsuari = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.optSql = New System.Windows.Forms.RadioButton()
        Me.lblEscollir = New System.Windows.Forms.Label()
        Me.optDBF = New System.Windows.Forms.RadioButton()
        Me.PanelRuta = New System.Windows.Forms.Panel()
        Me.gbSql = New System.Windows.Forms.GroupBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSql.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtClau
        '
        Me.txtClau.BackColor = System.Drawing.Color.White
        Me.txtClau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClau.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtClau.ForeColor = System.Drawing.Color.Blue
        Me.txtClau.Location = New System.Drawing.Point(143, 84)
        Me.txtClau.Margin = New System.Windows.Forms.Padding(4)
        Me.txtClau.Name = "txtClau"
        Me.txtClau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClau.Size = New System.Drawing.Size(118, 26)
        Me.txtClau.TabIndex = 10
        '
        'lblClau
        '
        Me.lblClau.AutoSize = True
        Me.lblClau.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblClau.Location = New System.Drawing.Point(140, 62)
        Me.lblClau.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClau.Name = "lblClau"
        Me.lblClau.Size = New System.Drawing.Size(104, 18)
        Me.lblClau.TabIndex = 15
        Me.lblClau.Text = "Servidor dades"
        '
        'txtUsuari
        '
        Me.txtUsuari.BackColor = System.Drawing.Color.White
        Me.txtUsuari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuari.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtUsuari.ForeColor = System.Drawing.Color.Blue
        Me.txtUsuari.Location = New System.Drawing.Point(12, 84)
        Me.txtUsuari.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsuari.Name = "txtUsuari"
        Me.txtUsuari.Size = New System.Drawing.Size(87, 26)
        Me.txtUsuari.TabIndex = 9
        Me.txtUsuari.Text = "ASDFSA"
        '
        'lblUsuari
        '
        Me.lblUsuari.AutoSize = True
        Me.lblUsuari.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblUsuari.Location = New System.Drawing.Point(9, 62)
        Me.lblUsuari.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsuari.Name = "lblUsuari"
        Me.lblUsuari.Size = New System.Drawing.Size(104, 18)
        Me.lblUsuari.TabIndex = 14
        Me.lblUsuari.Text = "Servidor dades"
        '
        'txtServer
        '
        Me.txtServer.BackColor = System.Drawing.Color.White
        Me.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServer.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtServer.ForeColor = System.Drawing.Color.Blue
        Me.txtServer.Location = New System.Drawing.Point(12, 34)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(321, 26)
        Me.txtServer.TabIndex = 8
        Me.txtServer.Text = "ASDFSA"
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblData.Location = New System.Drawing.Point(9, 12)
        Me.lblData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(104, 18)
        Me.lblData.TabIndex = 11
        Me.lblData.Text = "Servidor dades"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancel.Location = New System.Drawing.Point(320, 380)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(109, 41)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Button2"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdSave.Location = New System.Drawing.Point(22, 380)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(109, 41)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "Button1"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'optSql
        '
        Me.optSql.AutoSize = True
        Me.optSql.Location = New System.Drawing.Point(28, 27)
        Me.optSql.Name = "optSql"
        Me.optSql.Size = New System.Drawing.Size(90, 17)
        Me.optSql.TabIndex = 16
        Me.optSql.TabStop = True
        Me.optSql.Text = "RadioButton1"
        Me.optSql.UseVisualStyleBackColor = True
        '
        'lblEscollir
        '
        Me.lblEscollir.AutoSize = True
        Me.lblEscollir.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblEscollir.Location = New System.Drawing.Point(3, 6)
        Me.lblEscollir.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEscollir.Name = "lblEscollir"
        Me.lblEscollir.Size = New System.Drawing.Size(104, 18)
        Me.lblEscollir.TabIndex = 17
        Me.lblEscollir.Text = "Servidor dades"
        '
        'optDBF
        '
        Me.optDBF.AutoSize = True
        Me.optDBF.Location = New System.Drawing.Point(153, 27)
        Me.optDBF.Name = "optDBF"
        Me.optDBF.Size = New System.Drawing.Size(90, 17)
        Me.optDBF.TabIndex = 18
        Me.optDBF.TabStop = True
        Me.optDBF.Text = "RadioButton2"
        Me.optDBF.UseVisualStyleBackColor = True
        '
        'PanelRuta
        '
        Me.PanelRuta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PanelRuta.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelRuta.Location = New System.Drawing.Point(22, 219)
        Me.PanelRuta.Name = "PanelRuta"
        Me.PanelRuta.Size = New System.Drawing.Size(407, 140)
        Me.PanelRuta.TabIndex = 19
        '
        'gbSql
        '
        Me.gbSql.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSql.Controls.Add(Me.txtServer)
        Me.gbSql.Controls.Add(Me.lblData)
        Me.gbSql.Controls.Add(Me.lblUsuari)
        Me.gbSql.Controls.Add(Me.lblClau)
        Me.gbSql.Controls.Add(Me.txtUsuari)
        Me.gbSql.Controls.Add(Me.txtClau)
        Me.gbSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbSql.Location = New System.Drawing.Point(22, 50)
        Me.gbSql.Name = "gbSql"
        Me.gbSql.Size = New System.Drawing.Size(407, 156)
        Me.gbSql.TabIndex = 20
        Me.gbSql.TabStop = False
        Me.gbSql.Text = "GroupBox1"
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 428)
        Me.Controls.Add(Me.gbSql)
        Me.Controls.Add(Me.PanelRuta)
        Me.Controls.Add(Me.optDBF)
        Me.Controls.Add(Me.lblEscollir)
        Me.Controls.Add(Me.optSql)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Name = "frmServer"
        Me.Text = "FrmServer"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSql.ResumeLayout(False)
        Me.gbSql.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtClau As TextBox
    Friend WithEvents lblClau As Label
    Friend WithEvents txtUsuari As TextBox
    Friend WithEvents lblUsuari As Label
    Friend WithEvents txtServer As TextBox
    Friend WithEvents lblData As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents optDBF As RadioButton
    Friend WithEvents lblEscollir As Label
    Friend WithEvents optSql As RadioButton
    Friend WithEvents PanelRuta As Panel
    Friend WithEvents gbSql As GroupBox
End Class
