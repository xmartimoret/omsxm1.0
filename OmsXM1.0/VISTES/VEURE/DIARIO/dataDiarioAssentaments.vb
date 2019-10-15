Public Class dataDiarioAssentaments
    Inherits DGVObjects
    Friend Property assentaments As List(Of Assentament)
    Public Sub New()
        MyBase.New(False)
    End Sub
    Public Sub New(pAssentaments As List(Of Assentament))
        MyBase.New(False)
        _assentaments = pAssentaments
        Me.setColumnRow()
        Me.setData()
    End Sub
    Public Overrides Function getColumns() As List(Of CodiDescripcio)
        Dim llista As List(Of CodiDescripcio)
        llista = New List(Of CodiDescripcio)
        llista.Add(New CodiDescripcio(IDIOMA.getString("asien"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("data"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("subcompte"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("concepte"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("doc"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("projecte"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("deure"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("haver"), ""))
        llista.Add(New CodiDescripcio(IDIOMA.getString("saldo"), ""))
        Return llista
    End Function
    Public Overrides Function getRows() As List(Of List(Of CodiDescripcio))
        Dim dades As List(Of List(Of CodiDescripcio)), fila As List(Of CodiDescripcio), a As Assentament, saldo As Double
        dades = New List(Of List(Of CodiDescripcio))
        saldo = 0
        For Each a In _assentaments
            fila = New List(Of CodiDescripcio)
            fila.Add(New CodiDescripcio("'" & a.numero, ""))
            fila.Add(New CodiDescripcio(a.dataAssentament, ""))
            fila.Add(New CodiDescripcio("'" & a.subcompteAssentament, ""))
            fila.Add(New CodiDescripcio(a.concepte, ""))
            fila.Add(New CodiDescripcio("'" & a.document))
            fila.Add(New CodiDescripcio(a.departamentAssentament & a.clave))
            fila.Add(New CodiDescripcio(Math.Round(a.deure / 100, 2)))
            fila.Add(New CodiDescripcio(Math.Round(a.haver / 100, 2)))
            saldo = saldo + Math.Round(a.saldo / 100, 2)
            fila.Add(New CodiDescripcio(saldo))
            dades.Add(fila)
        Next
        getRows = dades
        dades = Nothing
        fila = Nothing
    End Function
    Public Overrides Sub setData(c As String, f As String)
    End Sub
    Public Overrides Sub resetData()
    End Sub
End Class
