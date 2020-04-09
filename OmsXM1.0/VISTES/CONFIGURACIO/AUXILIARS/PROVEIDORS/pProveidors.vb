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
        Dim contactes As SelectContacteProveidor, anotacions As SelectProveidorAnotacio
        contactes = New SelectContacteProveidor(p.id, p.nom, IDIOMA.getString("contactes") & " - " & p.ToString)
        anotacions = New SelectProveidorAnotacio(p.id, p.nom, IDIOMA.getString("avisos") & " - " & p.ToString)
        contactes.Dock = DockStyle.Fill
        anotacions.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel1.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Clear()
        contactes.Show()
        anotacions.Show()
        SplitContainer1.Panel1.Controls.Add(contactes)
        SplitContainer1.Panel2.Controls.Add(anotacions)
    End Sub

    Private Sub SplitData_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitData.Panel1.Paint

    End Sub
End Class
