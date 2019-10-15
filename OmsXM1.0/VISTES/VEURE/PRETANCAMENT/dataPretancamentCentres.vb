Public Class dataPretancamentCentres
    Inherits DGVObjects
    Private dadesInforme As dataReport
    Friend Event selectData(ByVal c As Centre, ByVal sg As Subgrup)
    Public Sub New(p As dataReport)
        MyBase.New(True)
        dadesInforme = p
        Me.setColumnRow()
        Me.setData()
    End Sub
    Public Overrides Function getColumns() As List(Of CodiDescripcio)
        Dim c As Centre, llista As List(Of CodiDescripcio)
        llista = New List(Of CodiDescripcio)
        For Each c In dadesInforme.seccioActual.centres
            For m As Integer = 1 To 12
                c.isDetall(m) = ModulActualitzacioGB.existCentreMes(dadesInforme.contaplusActual.anyo, c.id, m)
            Next
            llista.Add(New CodiDescripcio(c.codi, c.tipTextProjectes))
            Next
            Return llista
        c = Nothing
    End Function
    Public Overrides Function getRows() As List(Of List(Of CodiDescripcio))
        Dim sg As Subgrup, c As Centre, dades As List(Of List(Of CodiDescripcio)), fila As List(Of CodiDescripcio)
        dades = New List(Of List(Of CodiDescripcio))
        For Each sg In dadesInforme.grupComptable.subgrups
            fila = New List(Of CodiDescripcio)
            fila.Add(New CodiDescripcio(sg.codi, sg.toStringSubcomptes))
            For Each c In dadesInforme.seccioActual.centres
                fila.Add(New CodiDescripcio(c.saldoPretancament(sg.id, dadesInforme.mesActual.num, dadesInforme.isValorAcumulat, -1)))
            Next
            dades.Add(fila)

        Next
        getRows = dades
        dades = Nothing
        fila = Nothing
        sg = Nothing
        c = Nothing
    End Function

    Public Overrides Sub setData(c As String, f As String)
        Dim sg As Subgrup, _c As Centre
        sg = Nothing
        _c = Nothing
        _c = dadesInforme.seccioActual.centres.Find(Function(x) x.codi = c)
        If _c IsNot Nothing Then sg = _c.subGrups.Find((Function(x) x.codi = f))
        If sg IsNot Nothing Then RaiseEvent selectData(_c, sg)

        sg = Nothing
        _c = Nothing
    End Sub
    Public Overrides Sub resetData()
        RaiseEvent selectData(Nothing, Nothing)
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        dadesInforme = Nothing
    End Sub
End Class
