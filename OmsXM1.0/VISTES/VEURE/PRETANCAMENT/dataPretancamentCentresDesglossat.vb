Public Class dataPretancamentCentresDesglossat
    Inherits DGVObjects
    Private centreActual As Centre
    Private subgrupActual As Subgrup
    Private dataInforme As dataReport
    Private columnaActual As String
    Private filaActual As String
    Friend Event selectData(assentaments As List(Of Assentament))
    Friend Event selectDataTransitoria(c As Centre, sg As Subgrup)

    Public Sub New()
        MyBase.New(True)
    End Sub
    Public Sub New(pCentre As Centre, pSubGrup As Subgrup, pdata As dataReport)
        MyBase.New(True)
        centreActual = pCentre
        subgrupActual = pSubGrup
        dataInforme = pdata
        Me.setColumnRow()
        Me.setData()
    End Sub
    Public Overrides Function getColumns() As List(Of CodiDescripcio)
        Dim llista As List(Of CodiDescripcio)
        llista = New List(Of CodiDescripcio)
        llista.Add(New CodiDescripcio(subgrupActual.ToString, subgrupActual.toStringSubcomptes))
        getColumns = llista
        llista = Nothing
    End Function

    Public Overrides Function getRows() As List(Of List(Of CodiDescripcio))
        Dim dades As List(Of List(Of CodiDescripcio)), fila As List(Of CodiDescripcio), hiHadetall As Boolean = False
        dades = New List(Of List(Of CodiDescripcio))
        fila = New List(Of CodiDescripcio)
        hiHadetall = centreActual.isDetall(dataInforme.mesActual.num)
        If hiHadetall Then
            fila.Add(New CodiDescripcio(IDIOMA.getString("dadesTancament") & " (" & dataInforme.mesActual.nom & " " & dataInforme.contaplusActual.anyo & ")", IDIOMA.getString("dadesComptabilitatConsolidades")))
            fila.Add(New CodiDescripcio(centreActual.saldoDetall(subgrupActual.id, dataInforme.mesActual.num, dataInforme.isValorAcumulat)))
            dades.Add(fila)
        Else
            If dataInforme.mesActual.num > 1 And dataInforme.isValorAcumulat Then
                fila.Add(New CodiDescripcio(IDIOMA.getString("dadesTancamentMesAnterior") & " (" & CONFIG.mesNom(dataInforme.mesActual.num - 1) & " " & dataInforme.contaplusActual.anyo & ")", "Dades de Comptabilitat consolidades"))
                fila.Add(New CodiDescripcio(centreActual.saldoDetall(subgrupActual.id, dataInforme.mesActual.num - 1, dataInforme.isValorAcumulat)))
                dades.Add(fila)
            Else
                fila = New List(Of CodiDescripcio)
                fila.Add(New CodiDescripcio("", ""))
                fila.Add(New CodiDescripcio("", ""))
                dades.Add(fila)
            End If
        End If
        If Not hiHadetall Then
            fila = New List(Of CodiDescripcio)
            fila.Add(New CodiDescripcio(IDIOMA.getString("diarioMesActual") & " (" & dataInforme.mesActual.nom & " " & dataInforme.contaplusActual.anyo & ")", IDIOMA.getString("diarioAssentaments")))
            fila.Add(New CodiDescripcio(centreActual.saldoSubgrup(subgrupActual.id, dataInforme.mesActual.num, False, -1)))
            dades.Add(fila)

            fila = New List(Of CodiDescripcio)
            fila.Add(New CodiDescripcio(IDIOMA.getString("transitoriaMesActual"), IDIOMA.getString("descripcioTransitoriaMesActual")))
            fila.Add(New CodiDescripcio(centreActual.saldoTransitoria(subgrupActual.id, dataInforme.mesActual.num, False, -1)))
            dades.Add(fila)
        Else
            fila = New List(Of CodiDescripcio)
            fila.Add(New CodiDescripcio("", ""))
            fila.Add(New CodiDescripcio("", ""))
            dades.Add(fila)
            fila = New List(Of CodiDescripcio)
            fila.Add(New CodiDescripcio("", ""))
            fila.Add(New CodiDescripcio("", ""))
            dades.Add(fila)
        End If
        fila = New List(Of CodiDescripcio)
        fila.Add(New CodiDescripcio("", ""))
        fila.Add(New CodiDescripcio("", ""))
        dades.Add(fila)

        fila = New List(Of CodiDescripcio)
        fila.Add(New CodiDescripcio(IDIOMA.getString("dadesPretancament") & " (" & dataInforme.mesActual.nom & " " & dataInforme.contaplusActual.anyo & ")", IDIOMA.getString("dadesPretancamentMesActual")))
        fila.Add(New CodiDescripcio(centreActual.saldoPretancament(subgrupActual.id, dataInforme.mesActual.num, dataInforme.isValorAcumulat, -1)))
        dades.Add(fila)

        getRows = dades
        dades = Nothing
        fila = Nothing
    End Function
    Public Overrides Sub setData(c As String, f As String)
        If InStr(f, IDIOMA.getString("diario"), CompareMethod.Text) Then
            RaiseEvent selectData(centreActual.assentamentsSubGrupMes(subgrupActual.codi, dataInforme.mesActual.num, False))
        ElseIf InStr(f, IDIOMA.getString("transitoria"), CompareMethod.Text) Then
            If subgrupActual IsNot Nothing Then RaiseEvent selectDataTransitoria(centreActual, subgrupActual)
        Else
            Call resetData()
        End If
    End Sub
    Public Sub actualitzarSubformulari()
        'RaiseEvent selectData(centreActual.assentamentsProjecteSubcompteMes(columnaActual, filaActual, dataInforme.mesActual.num, dataInforme.isValorAcumulat))
    End Sub
    Public Overrides Sub resetData()
        RaiseEvent selectData(Nothing)
    End Sub
End Class
