Option Explicit On
Module ModelLog
    Private id As Integer
    Public Function getDataList(c As Log, Optional tipus As tipusEntradaLog = 0) As DataList
        Dim obj As EntradaLog
        getDataList = New DataList
        If c.entrades.Count > 0 Then
            getDataList.columns.Add(COLUMN.GENERICA("id", 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("tipus", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("codi", 200, HorizontalAlignment.Left))
            getDataList.columns.Add(COLUMN.GENERICA("descripcio", 500, HorizontalAlignment.Left))
            For Each obj In c.entrades
                If obj.codi = tipus Or tipus = 0 Then
                    getDataList.rows.Add(New ListViewItem(New String() {obj.id, CONFIG.getTipusEntradaLog(obj.codi), obj.titol, obj.descripcio}))
                End If
            Next
        End If
    End Function

    Public Function hihaErrors(c As List(Of EntradaLog)) As Boolean
        Return c.Exists(Function(x) x.codi = CONFIG.tipusEntradaLog.ERR_LOG Or x.codi = CONFIG.tipusEntradaLog.AVIS_log)
    End Function
    Public Function getNumAvisos(c As List(Of EntradaLog)) As Integer
        Return c.FindAll(Function(x) x.codi = CONFIG.tipusEntradaLog.AVIS_log).Count
    End Function
    Public Function getNumErrors(c As List(Of EntradaLog)) As Integer
        Return c.FindAll(Function(x) x.codi = CONFIG.tipusEntradaLog.ERR_LOG).Count
    End Function
    Public Sub resetIndex()
        id = 0
    End Sub
    Public Function getEntradaLog(tipusEntrada As tipusEntradaLog, titol As String, descripcio As String) As EntradaLog
        getEntradaLog = New EntradaLog
        getEntradaLog.id = id
        id = id + 1
        getEntradaLog.codi = tipusEntrada
        getEntradaLog.titol = titol
        getEntradaLog.descripcio = descripcio
    End Function
End Module
