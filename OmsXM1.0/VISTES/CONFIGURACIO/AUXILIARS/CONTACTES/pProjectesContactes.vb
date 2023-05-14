Public Class pProjectesContactes
    Private Sub setLanguage()

    End Sub
    Private Sub pProjectesContactes_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim p As SelectProjecte
        'p = New SelectProjecte(IDIOMA.getString("projectesEntreguesContactes"), 1)
        'SContainer.Panel1.Controls.Clear()
        'p.Dock = DockStyle.Fill
        'SContainer.Panel1.Controls.Add(p)
        'AddHandler p.selectObject, AddressOf setAuxiliars
        'Call setLanguage()
        'p.Show()        
        Dim p As SelectProjectes
        p = New SelectProjectes(0, -1, 1, False, True, "", 1)
        SContainer.Panel1.Controls.Clear()
        p.Dock = DockStyle.Fill
        SContainer.Panel1.Controls.Add(p)
        AddHandler p.selectObject, AddressOf setAuxiliars
        Call setLanguage()
        p.Show()
    End Sub
    Private Sub setAuxiliars(p As Projecte)
        Call setContactes(p)
        Call setLlocsEntrega(p)
    End Sub
    Private Sub setContactes(p As Projecte)
        Dim contactes As Selectprojectecontacte
        contactes = New Selectprojectecontacte(p.id, p.nom, IDIOMA.getString("contactes") & " - " & p.ToString)
        contactes.contactes = ModelProjecteContacte.getObjects(p.id)
        contactes.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel2.Controls.Clear()
        contactes.Show()
        Me.SplitContainer1.Panel2.Controls.Add(contactes)
    End Sub
    Private Sub setLlocsEntrega(p As Projecte)
        Dim entregues As SelectProjecteEntrega
        entregues = New SelectProjecteEntrega(p.id, p.nom, IDIOMA.getString("magatzems") & " - " & p.ToString)
        entregues.llocsEntrega = ModelProjecteEntrega.getObjects(p.id)
        entregues.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel1.Controls.Clear()
        entregues.Show()
        Me.SplitContainer1.Panel1.Controls.Add(entregues)
    End Sub

    Private Sub SContainer_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SContainer.Panel1.Paint

    End Sub
End Class
