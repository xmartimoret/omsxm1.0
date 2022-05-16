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
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbSql = New System.Windows.Forms.GroupBox()
        Me.lblTaulaPedidos = New System.Windows.Forms.Label()
        Me.txtTaulaPedidos = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.lblUsuari = New System.Windows.Forms.Label()
        Me.lblClau = New System.Windows.Forms.Label()
        Me.txtUsuari = New System.Windows.Forms.TextBox()
        Me.txtClau = New System.Windows.Forms.TextBox()
        Me.PanelRuta = New System.Windows.Forms.Panel()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSql.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancel.Location = New System.Drawing.Point(262, 350)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(109, 39)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Button2"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdSave.Location = New System.Drawing.Point(12, 350)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(109, 39)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "Button1"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'gbSql
        '
        Me.gbSql.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSql.Controls.Add(Me.lblTaulaPedidos)
        Me.gbSql.Controls.Add(Me.txtTaulaPedidos)
        Me.gbSql.Controls.Add(Me.txtServer)
        Me.gbSql.Controls.Add(Me.lblData)
        Me.gbSql.Controls.Add(Me.lblUsuari)
        Me.gbSql.Controls.Add(Me.lblClau)
        Me.gbSql.Controls.Add(Me.txtUsuari)
        Me.gbSql.Controls.Add(Me.txtClau)
        Me.gbSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbSql.Location = New System.Drawing.Point(12, 12)
        Me.gbSql.Name = "gbSql"
        Me.gbSql.Size = New System.Drawing.Size(359, 178)
        Me.gbSql.TabIndex = 21
        Me.gbSql.TabStop = False
        Me.gbSql.Text = "GroupBox1"
        '
        'lblTaulaPedidos
        '
        Me.lblTaulaPedidos.AutoSize = True
        Me.lblTaulaPedidos.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblTaulaPedidos.Location = New System.Drawing.Point(11, 129)
        Me.lblTaulaPedidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTaulaPedidos.Name = "lblTaulaPedidos"
        Me.lblTaulaPedidos.Size = New System.Drawing.Size(104, 18)
        Me.lblTaulaPedidos.TabIndex = 17
        Me.lblTaulaPedidos.Text = "Servidor dades"
        '
        'txtTaulaPedidos
        '
        Me.txtTaulaPedidos.BackColor = System.Drawing.Color.White
        Me.txtTaulaPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaulaPedidos.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtTaulaPedidos.ForeColor = System.Drawing.Color.Blue
        Me.txtTaulaPedidos.Location = New System.Drawing.Point(14, 152)
        Me.txtTaulaPedidos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTaulaPedidos.Name = "txtTaulaPedidos"
        Me.txtTaulaPedidos.Size = New System.Drawing.Size(229, 26)
        Me.txtTaulaPedidos.TabIndex = 11
        '
        'txtServer
        '
        Me.txtServer.BackColor = System.Drawing.Color.White
        Me.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServer.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtServer.ForeColor = System.Drawing.Color.Blue
        Me.txtServer.Location = New System.Drawing.Point(14, 49)
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
        Me.lblData.Location = New System.Drawing.Point(11, 79)
        Me.lblData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(104, 18)
        Me.lblData.TabIndex = 11
        Me.lblData.Text = "Servidor dades"
        '
        'lblUsuari
        '
        Me.lblUsuari.AutoSize = True
        Me.lblUsuari.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblUsuari.Location = New System.Drawing.Point(11, 27)
        Me.lblUsuari.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsuari.Name = "lblUsuari"
        Me.lblUsuari.Size = New System.Drawing.Size(104, 18)
        Me.lblUsuari.TabIndex = 14
        Me.lblUsuari.Text = "Servidor dades"
        '
        'lblClau
        '
        Me.lblClau.AutoSize = True
        Me.lblClau.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblClau.Location = New System.Drawing.Point(120, 77)
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
        Me.txtUsuari.Location = New System.Drawing.Point(14, 99)
        Me.txtUsuari.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsuari.Name = "txtUsuari"
        Me.txtUsuari.Size = New System.Drawing.Size(87, 26)
        Me.txtUsuari.TabIndex = 9
        Me.txtUsuari.Text = "ASDFSA"
        '
        'txtClau
        '
        Me.txtClau.BackColor = System.Drawing.Color.White
        Me.txtClau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClau.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtClau.ForeColor = System.Drawing.Color.Blue
        Me.txtClau.Location = New System.Drawing.Point(123, 99)
        Me.txtClau.Margin = New System.Windows.Forms.Padding(4)
        Me.txtClau.Name = "txtClau"
        Me.txtClau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClau.Size = New System.Drawing.Size(118, 26)
        Me.txtClau.TabIndex = 10
        '
        'PanelRuta
        '
        Me.PanelRuta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelRuta.Location = New System.Drawing.Point(15, 197)
        Me.PanelRuta.Name = "PanelRuta"
        Me.PanelRuta.Size = New System.Drawing.Size(358, 138)
        Me.PanelRuta.TabIndex = 22
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 406)
        Me.Controls.Add(Me.PanelRuta)
        Me.Controls.Add(Me.gbSql)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Name = "frmServer"
        Me.Text = "FrmServer"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSql.ResumeLayout(False)
        Me.gbSql.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents gbSql As GroupBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents lblData As Label
    Friend WithEvents lblUsuari As Label
    Friend WithEvents lblClau As Label
    Friend WithEvents txtUsuari As TextBox
    Friend WithEvents txtClau As TextBox
    Friend WithEvents PanelRuta As Panel
    Friend WithEvents lblTaulaPedidos As Label
    Friend WithEvents txtTaulaPedidos As TextBox
End Class
