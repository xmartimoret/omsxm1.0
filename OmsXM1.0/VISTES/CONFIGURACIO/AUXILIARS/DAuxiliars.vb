Imports System.Windows.Forms
Public Class DAuxiliars
    Public Function getPaisos() As List(Of Object)
        Dim p As SelectAuxiliar
        p = New SelectAuxiliar(DBCONNECT.getTaulaPais, 0, True, True, IDIOMA.getString("paisos"), 1)
        Me.Text = IDIOMA.getString("selectPais")
        p.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(p)
        p.Show()
        Me.ShowDialog()
        getPaisos = p.objects
        Me.Dispose()
    End Function
    Public Sub setPaisos()
        Dim p As SelectAuxiliar
        p = New SelectAuxiliar(DBCONNECT.getTaulaPais, 1, True, True, IDIOMA.getString("paisos"), 1)
        Me.Text = IDIOMA.getString("paisos")
        p.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(p)
        p.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub

    Public Function getProvincies() As List(Of Object)
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaProvincia, 0, True, True, IDIOMA.getString("provincies"), 1)
        Me.Text = IDIOMA.getString("selectProvincia")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        getProvincies = pr.objects
        Me.Dispose()
    End Function
    Public Sub setProvincies()
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaProvincia, 1, True, True, IDIOMA.getString("provincies"), 1)
        Me.Text = IDIOMA.getString("provincies")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Function getUnitats() As List(Of Object)
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaUnitat, 0, True, True, IDIOMA.getString("unitats"), 1)
        Me.Text = IDIOMA.getString("selectUnitat")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        getUnitats = pr.objects
        Me.Dispose()
    End Function
    Public Sub setUnitats()
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaUnitat, 1, True, True, IDIOMA.getString("unitats"), 1)
        Me.Text = IDIOMA.getString("unitats")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Function getFabricants() As List(Of Object)
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaFabricant, 0, True, True, IDIOMA.getString("fabricants"), 1)
        Me.Text = IDIOMA.getString("selectFabricant")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        getFabricants = pr.objects
        Me.Dispose()
    End Function
    Public Sub setFabricants()
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaFabricant, 1, True, True, IDIOMA.getString("fabricants"), 1)
        Me.Text = IDIOMA.getString("fabricants")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Function getFamilies() As List(Of Object)
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaFamilia, 0, True, True, IDIOMA.getString("families"), 1)
        Me.Text = IDIOMA.getString("selectFamilia")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        getFamilies = pr.objects
        Me.Dispose()
    End Function
    Public Sub setFamilies()
        Dim pr As SelectAuxiliar
        pr = New SelectAuxiliar(DBCONNECT.getTaulaFamilia, 1, True, True, IDIOMA.getString("families"), 1)
        Me.Text = IDIOMA.getString("families")
        pr.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(pr)
        pr.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getTipusPagament() As List(Of Object)
        Dim tp As SelectAuxiliar
        tp = New SelectAuxiliar(DBCONNECT.getTaulaTipusPagament, 0, True, True, IDIOMA.getString("tipusPagament"), 1)
        Me.Text = IDIOMA.getString("selectTipusPagament")
        tp.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(tp)
        tp.Show()
        Me.ShowDialog()
        getTipusPagament = tp.objects
        Me.Dispose()
    End Function
    Public Sub setTipusPagament()
        Dim tp As SelectAuxiliar
        tp = New SelectAuxiliar(DBCONNECT.getTaulaTipusPagament, 1, True, True, IDIOMA.getString("tipusPagament"), 1)
        Me.Text = IDIOMA.getString("tipusPagament")
        tp.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(tp)
        tp.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Function getTipusIva() As List(Of Object)
        Dim tp As SelectAuxiliar
        tp = New SelectAuxiliar(DBCONNECT.getTaulaTipusIva, 0, True, True, IDIOMA.getString("tipusIva"), 1)
        Me.Text = IDIOMA.getString("selectTipusIva")
        tp.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(tp)
        tp.Show()
        Me.ShowDialog()
        getTipusIva = tp.objects
        Me.Dispose()
    End Function
    Public Sub setTipusIva()
        Dim tp As SelectAuxiliar
        tp = New SelectAuxiliar(DBCONNECT.getTaulaTipusIva, 1, True, True, IDIOMA.getString("tipusIva"), 1)
        Me.Text = IDIOMA.getString("tipusiva")
        tp.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(tp)
        tp.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Function getProveidors() As List(Of Proveidor)
        Dim p As SelectProveidor
        p = New SelectProveidor(0, True, True, IDIOMA.getString("proveidors"), 1)
        Me.Text = IDIOMA.getString("selectProveidor")
        p.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(p)
        p.Show()
        Me.ShowDialog()
        getProveidors = p.proveidors
        Me.Dispose()
    End Function
    Public Sub setProveidors()
        Dim tp As SelectProveidor
        tp = New SelectProveidor(1, True, True, IDIOMA.getString("proveidors"), 1)
        Me.Text = IDIOMA.getString("proveidors")
        tp.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(tp)
        tp.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Function getContactes() As List(Of Contacte)
        Dim p As SelectContactes
        p = New SelectContactes(0, True, True, IDIOMA.getString("contactes"), 1)
        Me.Text = IDIOMA.getString("selectContactes")
        p.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(p)
        p.Show()
        Me.ShowDialog()
        getContactes = p.contactes
        Me.Dispose()
    End Function
    Public Sub setContactes()
        Dim tp As SelectContactes
        tp = New SelectContactes(1, True, True, IDIOMA.getString("contactes"), 1)
        Me.Text = IDIOMA.getString("contactes")
        tp.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(tp)
        tp.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub
    Public Function getEntregues() As List(Of LlocEntrega)
        Dim p As SelectLlocEntrega
        p = New SelectLlocEntrega(0, True, True, IDIOMA.getString("magatzems"), 1)
        Me.Text = IDIOMA.getString("selectMagatzems")
        p.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(p)
        p.Show()
        Me.ShowDialog()
        getEntregues = p.LlocEntregas()
        Me.Dispose()
    End Function
    Public Sub setEntregues()
        Dim tp As SelectLlocEntrega
        tp = New SelectLlocEntrega(1, True, True, IDIOMA.getString("magatzems"), 1)
        Me.Text = IDIOMA.getString("magatzems")
        tp.Dock = DockStyle.Fill
        PData.Controls.Clear()
        PData.Controls.Add(tp)
        tp.Show()
        Me.ShowDialog()
        Me.Dispose()
    End Sub

    Private Sub DAuxiliars_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
