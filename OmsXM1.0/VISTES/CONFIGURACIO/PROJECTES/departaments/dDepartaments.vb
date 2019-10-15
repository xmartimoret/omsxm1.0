Imports System.Windows.Forms

Public Class dDepartaments
    Private p As SelectDepartament
    Public Function getDepartaments() As List(Of Departament)
        p = New SelectDepartament(0, True, True, IDIOMA.getString("departaments"), 1)
        Me.Text = IDIOMA.getString("selectDepartament")
        p.Dock = DockStyle.Fill
        pData.Controls.Clear()
        pData.Controls.Add(p)
        p.Show()
        Me.ShowDialog()
        getDepartaments = p.departaments
        Me.Dispose()
    End Function

    Public Sub New()
        InitializeComponent()
    End Sub

End Class
