Public Class DataTancamentCentresMes
    Inherits DGVObjects
    Private dadesInforme As dataReport
    Private centreActual As Centre
    Private subgrupActual As Subgrup
    Friend Event selectData(ByVal c As Centre, ByVal mesActual As Integer)
    Public Sub New(p As dataReport)
        MyBase.New(True)
        dadesInforme = p
        Me.setColumnRow()
        Me.setData()
    End Sub
    Public Sub New(pCentre As Centre, pSubgrup As Subgrup, p As dataReport)
        MyBase.New(True)
        centreActual = pCentre
        subgrupActual = pSubgrup
        dadesInforme = p
        Me.setColumnRow()
        Me.setData()
    End Sub
    Public Overrides Function getColumns() As List(Of CodiDescripcio)
        Dim m As Integer, llista As List(Of CodiDescripcio)
        llista = New List(Of CodiDescripcio)
        For m = 1 To dadesInforme.mesActual.num
            llista.Add(New CodiDescripcio(CONFIG.mesNom(m) & "-" & dadesInforme.contaplusActual.anyo, ""))
        Next
        Return llista

    End Function
    Public Overrides Function getRows() As List(Of List(Of CodiDescripcio))
        Dim dades As List(Of List(Of CodiDescripcio)), fila As List(Of CodiDescripcio), valor As Double, m As Integer
        dades = New List(Of List(Of CodiDescripcio))

        fila = New List(Of CodiDescripcio)
        fila.Add(New CodiDescripcio(centreActual.codi & " - " & IDIOMA.getString("tancament"), centreActual.ToString))
        For m = 1 To dadesInforme.mesActual.num
            valor = centreActual.saldoDetall(subgrupActual.id, m, dadesInforme.isValorAcumulat)
            fila.Add(New CodiDescripcio(Format(valor, "#,##0.00"), ""))
        Next
        dades.Add(fila)

        fila = New List(Of CodiDescripcio)
        fila.Add(New CodiDescripcio(centreActual.codi & " - " & IDIOMA.getString("budget"), centreActual.ToString))
        For m = 1 To dadesInforme.mesActual.num
            valor = centreActual.saldoBudget(subgrupActual.id, m, dadesInforme.isValorAcumulat)
            fila.Add(New CodiDescripcio(Format(valor, "#,##0.00"), ""))
        Next
        dades.Add(fila)
        getRows = dades
        dades = Nothing
        fila = Nothing
    End Function
    Public Overrides Sub setData(c As String, f As String)
        Dim _c As Centre
        _c = Nothing
        _c = dadesInforme.seccioActual.centres.Find(Function(x) StrComp(x.codi, c, CompareMethod.Text))
        If _c IsNot Nothing Then If IsNumeric(f) Then RaiseEvent selectData(_c, Val(f))
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
