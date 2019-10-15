Public Class dataDiarioProjectes
    Inherits DGVObjects
    Private centreActual As Centre
    Private subgrupActual As Subgrup
    Private dataInforme As dataReport
    Private columnaActual As String
    Private filaActual As String
    Friend Event selectData(assentaments As List(Of Assentament))
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
        Dim pc As ProjecteCentre, llista As List(Of CodiDescripcio)
        llista = New List(Of CodiDescripcio)
        For Each pc In centreActual.projectes
            llista.Add(New CodiDescripcio(pc.codiProjecte, pc.tostring))
        Next
        getColumns = llista
        pc = Nothing
    End Function

    Public Overrides Function getRows() As List(Of List(Of CodiDescripcio))
        Dim s As SubcompteGrup, pc As ProjecteCentre, dades As List(Of List(Of CodiDescripcio)), fila As List(Of CodiDescripcio)
        dades = New List(Of List(Of CodiDescripcio))
        For Each s In subgrupActual.subcomptes
            If hiHaSaldo(s.assentaments, centreActual) Then
                fila = New List(Of CodiDescripcio)
                fila.Add(New CodiDescripcio(s.codiSubcompte, s.toStringSubcompte))
                For Each pc In centreActual.projectes
                    fila.Add(New CodiDescripcio(centreActual.saldoProjecteSubcompte(subgrupActual.codi, s.codiSubcompte, pc.codiProjecte, dataInforme.mesActual.num, dataInforme.isValorAcumulat, -1)))
                Next
                dades.Add(fila)
            End If
        Next
        getRows = dades
        dades = Nothing
        fila = Nothing
        s = Nothing
        pc = Nothing
    End Function
    Public Overrides Sub setData(c As String, f As String)
        filaActual = f
        columnaActual = c
        RaiseEvent selectData(centreActual.assentamentsProjecteSubcompteMes(c, f, dataInforme.mesActual.num, dataInforme.isValorAcumulat))
    End Sub
    Public Sub actualitzarAssentaments()
        RaiseEvent selectData(centreActual.assentamentsProjecteSubcompteMes(columnaActual, filaActual, dataInforme.mesActual.num, dataInforme.isValorAcumulat))
    End Sub
    Public Overrides Sub resetData()
        RaiseEvent selectData(Nothing)
    End Sub
    Private Function hiHaSaldo(assentaments As List(Of Assentament), c As Centre) As Boolean
        Dim a As Assentament, pe As ProjecteCentre
        hiHaSaldo = False
        For Each a In assentaments
            For Each pe In c.projectes
                If pe.codiProjecte = a.departamentAssentament & a.clave Then
                    If a.saldo <> 0 Then
                        hiHaSaldo = True
                        Exit For
                    End If
                End If
            Next
            If hiHaSaldo Then Exit For
        Next
        a = Nothing
        pe = Nothing
    End Function
End Class
