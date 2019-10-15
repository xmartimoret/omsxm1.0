Public Class pContactes
    Private panelContactes As SelectContactes
    Private contacteActual As Contacte
    Private Sub setContactes()
        panelContactes = New SelectContactes(1, False, True, IDIOMA.getString("contactes"), 1)
        AddHandler panelContactes.selectObject, AddressOf getContacte
        Me.panelData.Controls.Clear()
        panelContactes.Dock = DockStyle.Fill
        panelData.Controls.Add(panelContactes)
        panelContactes.Show()
    End Sub
    Private Sub getContacte(a As Contacte)
        contacteActual = a
    End Sub
    Private Sub pArticles_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setContactes()
    End Sub
End Class
