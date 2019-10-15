Public Class BOTO
    Inherits System.Windows.Forms.Button
    Sub New()
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FlatAppearance.BorderSize = 1
        Me.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.UseVisualStyleBackColor = False
    End Sub
End Class
Public Class TXT
    Inherits System.Windows.Forms.TextBox
    Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.ForeColor = System.Drawing.Color.Blue
    End Sub
End Class
Public Class CBBOX
    Inherits System.Windows.Forms.ComboBox
    Public Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.ForeColor = System.Drawing.Color.Blue
    End Sub
End Class
Public Class LSTBOX
    Inherits System.Windows.Forms.ListBox
    Public Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.ForeColor = System.Drawing.Color.Blue
    End Sub
End Class
Public Class LBLRED
    Inherits System.Windows.Forms.Label
    Public Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Red
        Me.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    End Sub
End Class
Public Class LBLREDTopLeft
    Inherits System.Windows.Forms.Label
    Public Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Red
        Me.TextAlign = System.Drawing.ContentAlignment.TopLeft
    End Sub
End Class
Public Class LBLRIGHT
    Inherits System.Windows.Forms.Label
    Public Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AutoSize = False
    End Sub
End Class
Public Class LBLMIDDLE
    Inherits System.Windows.Forms.Label
    Public Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.AutoSize = False
    End Sub
End Class
Public Class LBLBLUE
    Inherits System.Windows.Forms.Label
    Public Sub New()
        Me.Font = New System.Drawing.Font("ARIAL", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Blue
        'Me.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    End Sub
End Class
Public Class XEC
    Inherits System.Windows.Forms.CheckBox
    Public Sub New()
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UseVisualStyleBackColor = True
        Me.AutoSize = True
    End Sub


End Class
Public Class XECBUTTON
    Inherits System.Windows.Forms.CheckBox
    Public Sub New()
        Me.Appearance = System.Windows.Forms.Appearance.Button
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "XecButton1"
        Me.AutoSize = False
        Me.Size = New System.Drawing.Size(91, 48)
        Me.TabIndex = 1
        'Me.Cursor = Cursors.Hand
    End Sub
    Private Sub XECBUTTON_CheckedChanged(sender As Object, e As EventArgs) Handles Me.CheckedChanged
        If Me.Checked Then
            Me.BackColor = Color.GreenYellow
        Else
            Me.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
End Class