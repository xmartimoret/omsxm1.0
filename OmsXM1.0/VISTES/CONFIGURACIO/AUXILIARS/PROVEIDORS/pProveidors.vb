Public Class pProveidors
    Private proveidorActual As Proveidor
    Private Sub pProveidors_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tp As SelectProveidor
        tp = New SelectProveidor(1, False, True, IDIOMA.getString("proveidors"), 1)
        Me.Text = IDIOMA.getString("proveidors")
        tp.Dock = DockStyle.Fill
        SplitData.Panel1.Controls.Clear()
        SplitData.Panel1.Controls.Add(tp)
        AddHandler tp.selectObject, AddressOf setProveidor
        tp.Show()
    End Sub

    Private Sub setProveidor(p As Proveidor)
        Dim contactes As SelectContacteProveidorSub, anotacions As SelectProveidorAnotacio
        proveidorActual = p
        contactes = New SelectContacteProveidorSub(p.id, p.nom, IDIOMA.getString("contactes") & " - " & p.ToString)
        anotacions = New SelectProveidorAnotacio(p.id, p.nom, IDIOMA.getString("avisos") & " - " & p.ToString)
        contactes.Dock = DockStyle.Fill
        anotacions.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel1.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Clear()
        contactes.Show()
        anotacions.Show()
        SplitContainer1.Panel1.Controls.Add(contactes)
        SplitContainer1.Panel2.Controls.Add(anotacions)
        AddHandler anotacions.updateObject, AddressOf updateAnotacio
        AddHandler contactes.updateObject, AddressOf updateContactes

        ' todo ens cal posar  un event per tal de guardar les anotacions en el contenidor actual 

    End Sub
    Private Sub updateAnotacio()
        proveidorActual.anotacions = ModelProveidorAnotacio.getObjects(proveidorActual.id)
    End Sub
    Private Sub updateContactes()
        proveidorActual.contactes = ModelProveidorContacte.getObjects(proveidorActual.id)
    End Sub

    Private Sub SplitData_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitData.Panel1.Paint

    End Sub

    'Private Sub SplitData_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitData.Panel1.Paint
    '    Dim p As Proveidor

    '    p = DAuxiliars.getProveidors()


    'End Sub
End Class
