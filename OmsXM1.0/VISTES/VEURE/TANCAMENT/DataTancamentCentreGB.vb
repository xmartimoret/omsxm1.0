Public Class DataTancamentCentreGB
    Inherits DGVObjects
    Private dadesInforme As dataReport
    Private subgrupsGb As List(Of SubGrupGB)
    Friend Event selectData(ByVal c As Centre, ByVal sg As SubGrupGB)
    Public Sub New(p As dataReport)
        MyBase.New(True)
        dadesInforme = p
        subgrupsGb = ModelSubGrupGB.getObjects("")
        Me.setColumnRow()
        Me.setData()
    End Sub
    Public Overrides Function getColumns() As List(Of CodiDescripcio)
        Dim c As Centre, llista As List(Of CodiDescripcio)
        llista = New List(Of CodiDescripcio)
        For Each c In dadesInforme.seccioActual.centres
            llista.Add(New CodiDescripcio(c.codi, c.tipTextProjectes))
        Next
        Return llista
        c = Nothing
    End Function
    Public Overrides Function getRows() As List(Of List(Of CodiDescripcio))
        Dim sg As SubGrupGB, c As Centre, dades As List(Of List(Of CodiDescripcio)), fila As List(Of CodiDescripcio), valor As Double
        dades = New List(Of List(Of CodiDescripcio))
        For Each sg In subgrupsGb
            fila = New List(Of CodiDescripcio)
            'todo cal posar els subgrups implicats amb el signe. 
            fila.Add(New CodiDescripcio(sg.ToString, ""))
            For Each c In dadesInforme.seccioActual.centres
                valor = c.saldoDetallGB(sg.id, dadesInforme.mesActual.num, dadesInforme.isValorAcumulat)
                fila.Add(New CodiDescripcio(Format(valor, "#,##0.00"), ""))
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
        Dim _c As Centre, sg As SubGrupGB
        _c = Nothing
        _c = dadesInforme.seccioActual.centres.Find(Function(x) UCase(x.codi) = UCase(c))
        If _c IsNot Nothing Then sg = _c.subgrupsGb.Find((Function(x) x.codi = f))
        If sg IsNot Nothing Then RaiseEvent selectData(_c, sg)
        _c = Nothing
        sg = Nothing
    End Sub
    Public Overrides Sub resetData()
        RaiseEvent selectData(Nothing, Nothing)
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        dadesInforme = Nothing
    End Sub
End Class
