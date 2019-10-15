<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelDataTransitories
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.split1 = New System.Windows.Forms.SplitContainer()
        Me.split1.SuspendLayout()
        Me.SuspendLayout()
        '
        'split1
        '
        Me.split1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.split1.Location = New System.Drawing.Point(0, 0)
        Me.split1.Name = "split1"
        Me.split1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'split1.Panel2
        '
        Me.split1.Size = New System.Drawing.Size(307, 227)
        Me.split1.SplitterDistance = 129
        Me.split1.TabIndex = 1
        '
        'panelDataTransitories
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.split1)
        Me.Name = "panelDataTransitories"
        Me.Size = New System.Drawing.Size(307, 227)
        Me.split1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents split1 As SplitContainer
End Class
