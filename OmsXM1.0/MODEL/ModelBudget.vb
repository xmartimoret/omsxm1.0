Option Explicit On
Imports System.Data.SqlClient
Module ModelBudget
    Private objects(12) As List(Of ValorMes)
    Private dateUpdate As DateTime
    Private indexCarregat As Boolean
    Private empresaActual As Empresa
    Private anyActual As Integer
    Public Function getObjectsByCentreMes(c As Centre, mes As Integer, anyo As Integer) As List(Of ValorMes)
        Dim v As ValorMes, p As ProjecteCentre
        If Not isUpdated(anyo) Then Call SetRemoteObjects()
        getObjectsByCentreMes = New List(Of ValorMes)
        For Each v In objects(mes)
            For Each p In c.projectes
                If v.idProjecte = p.idProjecte Then
                    getObjectsByCentreMes.Add(v)
                    Exit For
                End If
            Next
        Next
        v = Nothing
        p = Nothing
    End Function
    Public Function getObjectsByCentreAny(e As Empresa, c As Centre, anyo As Integer) As List(Of ValorMes)
        Dim v As ValorMes, p As ProjecteCentre
        If Not isUpdated(anyo) Then Call SetRemoteObjects()
        getObjectsByCentreAny = New List(Of ValorMes)
        For m = 1 To 12
            If objects(m) IsNot Nothing Then
                For Each v In objects(m)
                    For Each p In c.projectes
                        If v.idEmpresa = e.id And p.idProjecte = v.idProjecte And anyo = v.any Then getObjectsByCentreAny.Add(v)
                    Next p
                Next v
            End If
        Next
        v = Nothing
        p = Nothing
    End Function
    Public Sub saveProjecteAny(obj As ProjecteCentre, a As Integer)
        For m As Integer = 1 To 12
            Call saveMesAny(obj.importsBudgets.FindAll(Function(x) x.mes = m And x.any = a), a, m)
        Next
    End Sub

    Public Function saveMesAny(valors As List(Of ValorMes), a As Integer, m As Integer) As Boolean
        Call dbBudget.saveMesAny(valors, a, m)
        Call resetIndex()
        Return True
    End Function

    Private Function removeBudget(idProjecte As Integer, mes As Integer, anyo As Integer) As Boolean
        If dbBudget.remove(idProjecte, mes, anyo) Then
            dateUpdate = Now()
            Call resetIndex()
            Return True
        End If
        Return False
    End Function

    ' todo cal pensar com borrar els diferents subgrups. 
    Public Function removeBudgetSubgrupR(idProjecte As Integer, mes As Integer, anyo As Integer)
        '    Dim sc As SqlCommand, i As Integer
        '    If mes > 0 Then
        '        sc = New SqlCommand("DELETE * FROM " & getTable() & " WHERE " & VALOR & "=0", DBCONNECT.getConnection)
        '    Else
        '    End If
        '    i = sc.ExecuteNonQuery
        '    sc = Nothing
        '    If i > 1 Then
        '        dateUpdate = Now()
        '        Call resetIndex()
        '        Return True
        '    End If
        '    Return False

        '    Dim rc As ADODB.Recordset
        'Set rc = New ADODB.Recordset
        ' changeOrder()


        '    If mes > 0 Then
        '        rc.Open "DELETE * FROM " & getTable() & " WHERE idprojecte= " & idProjecte & " And IDSUBGRUP<= 25 And ANYO= " & anyo & " And  MES = " & mes, DBCONNECT.currentConnect, adOpenDynamic, adLockOptimistic
        '    Else
        '        rc.Open "DELETE * FROM " & getTable() & " WHERE idprojecte= " & idProjecte & " And idSUBGRUP<= 25 And ANYO= " & anyo, DBCONNECT.currentConnect, adOpenDynamic, adLockOptimistic
        '    End If

        '    If rc.State = 1 Then
        '        removeBudgetSubgrupR = False
        '        rc.Close()
        '    Else
        '        removeBudgetSubgrupR = True
        '    End If

        'Set rc = Nothing

    End Function
    Public Function hihaDades(idProjecte As Integer, anyo As Integer) As Boolean
        Return dbBudget.hihaDades(idProjecte, anyo)
    End Function
    Public Function DeleteZeroValues() As Boolean
        If dbBudget.DeleteZeroValues Then
            dateUpdate = Now()
            Call resetIndex()
            Return True
        End If
        Return False
    End Function
    Private Function exist(obj As ValorMes) As Boolean
        If Not isUpdated(obj.any) Then SetRemoteObjects()
        Return objects(obj.mes).Exists(Function(x) x.id = obj.id)
    End Function
    Private Function exist(idProjecte As Integer, mes As Integer, anyo As Integer) As Boolean
        If Not isUpdated(anyo) Then SetRemoteObjects()
        Return objects(mes).Exists(Function(x) x.idProjecte = idProjecte)
    End Function
    Private Function exist(idProjecte As Integer, anyo As Integer) As Boolean
        Dim m As Integer
        If Not isUpdated(anyo) Then SetRemoteObjects()
        For m = 1 To 12
            If objects(m).Exists(Function(x) x.idProjecte = idProjecte) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function getAnyos(idEmpresa As Integer) As List(Of Integer)
        Return dbBudget.getAnyos(idEmpresa)
    End Function
    Public Sub clearData()
        Dim logActual As Log, dAvis As frmAvis
        Dim centres As CentresGB, p As Projecte
        Dim i As Integer
        centres = dBorrarDades.getProjectesBudget()
        Call ModelLog.resetIndex()
        logActual = New Log
        logActual.titol = IDIOMA.getString("logEsborrarBudgets")
        logActual.descripcio = IDIOMA.getString("logEsborrarBudgets1")
        If centres IsNot Nothing Then
            dAvis = New frmAvis(IDIOMA.getString("esborrarBudget"), IDIOMA.getString("esborrarDadesDe"), "-")
            i = 1
            For Each p In centres.projectes
                Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("esborrar"), IDIOMA.getString("esborrarBudgetDe") & " " & p.ToString))
                dAvis.setData(IDIOMA.getString("esborrarDadesDe"), p.ToString, i & " " & IDIOMA.getString("de") & " " & centres.projectes.Count)
                If removeBudget(p.id, centres.mesActual, centres.anyActual) Then
                    Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("esborrarOk"), IDIOMA.getString("esborrarBudgetDe") & " " & p.ToString))
                Else
                    Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("error"), IDIOMA.getString("esborrarErr") & " " & p.ToString & ". " & IDIOMA.getString("esborrarErr1")))
                End If
                i = i + 1
            Next p
            dAvis.tancar()
            Call MISSATGES.DATA_UPDATED()
            Call resetIndex()
        Else
            Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("cmdCancelar"), IDIOMA.getString("cancelarOperacio")))
        End If
        centres = Nothing
        p = Nothing
        logActual = Nothing
        dAvis = Nothing
    End Sub
    Public Sub clearDataCentres()
        Dim logActual As Log, dAvis As frmAvis
        Dim centres As CentresGB, c As Centre, p As ProjecteCentre
        centres = dBorrarDades.getCentresBudget
        Call ModelLog.resetIndex()
        logActual = New Log
        logActual.titol = IDIOMA.getString("logEsborrarBudgets")
        logActual.descripcio = IDIOMA.getString ("logEsborrarBudgets1")
        If centres IsNot Nothing Then
            dAvis = New frmAvis(IDIOMA.getString("esborrarBudget"), IDIOMA.getString("esborrarDadesDe"), "-")
            For Each c In centres.centres
                For Each p In c.projectes
                    Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("esborrar"), IDIOMA.getString("esborrarBudgetDe") & " " & c.ToString))
                    dAvis.setData(IDIOMA.getString("esborrarDadesDe"), p.codiProjecte, "")
                    If removeBudget(p.idProjecte, centres.mesActual, centres.anyActual) Then
                        Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("esborrarOk"), IDIOMA.getString("esborrarBudgetDe") & " " & p.tostring))
                    Else
                        Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("error"), IDIOMA.getString("esborrarErr") & " " & p.tostring & ". " & IDIOMA.getString("esborrarErr1")))
                    End If
                Next p
            Next c
            dAvis.tancar()
            MISSATGES.DATA_UPDATED()
            Call resetIndex()
        Else
            Call logActual.entrades.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("cmdCancelar"), IDIOMA.getString("cancelarOperacio")))
        End If
        centres = Nothing
        c = Nothing
        logActual = Nothing
        dAvis = Nothing
    End Sub
    Public Sub clearDataGrupR()
        '    Dim logActual As Log, dAvis As frmAvis
        '    Dim centres As CentresGB, c As Projecte
        '    centres = dBorrarDades.getProjectesBudget
        '    logActual = New Log
        '    logActual.titol = IDIOMA.getString("logEsborrarBudgets")
        '    logActual.descripcio = IDIOMA.getString("logEsborrarBudgets1")
        '    If centres IsNot Nothing Then
        '        dAvis = New frmAvis(IDIOMA.getString("esborrarBudget"), IDIOMA.getString("esborrarDadesDe"), "-")
        '        For Each c In centres.centres
        '            Call logActual.entrades.dades.add(ModelLog.getEntradaLog(AVIS_log, "ESBORRAR", "S'esborren budgets de " & c.ToString))
        '            Call frmCarregarDades.actualitzar(c.codi)
        '            If removeBudgetSubgrupR(c.id, centres.mesActual, centres.anyActual) Then
        '                Call logActual.entrades.dades.add(ModelLog.getEntradaLog(MIS_LOG, "ESBORRAR.OK", "ESBORRATS budgets de " & c.ToString))
        '            Else
        '                Call logActual.entrades.dades.add(ModelLog.getEntradaLog(AVIS_log, "ERROR", "No s'ha esborrat els budgets " & c.ToString & ". Comprovar si existeixen"))
        '            End If
        '        Next c
        '        Call frmCarregarDades.tancar
        '        Call MISSATGE.DATA_ACTULITZADES
        '        Call ModelCompact.DBBudget
        '        Call resetIndex()
        '    Else
        '        Call logActual.entrades.dades.add(ModelLog.getEntradaLog(AVIS_log, "CANCEL", "S'ha cancel·lat l'operació d'esborrar"))
        '    End If
        'Set centres = Nothing
        'Set c = Nothing
        'Set logActual = Nothing
    End Sub
    Public Sub removeProjecte(idProjecte As Integer, calendari As AnyMesos)
        Dim m As Integer
        For m = 1 To 12
            If calendari.esActiu(m) Then
                Call removeBudget(idProjecte, m, calendari.any)
            End If
        Next m
    End Sub

    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Private Sub SetRemoteObjects()
        objects = dbBudget.getObjects(anyActual)
        dateUpdate = Now
        indexCarregat = True
    End Sub
    Private Function isUpdated(a As Integer) As Boolean
        isUpdated = True
        If Not indexCarregat Then
            isUpdated = False
        ElseIf a <> anyActual Then
            isUpdated = False
        ElseIf Not DBCONNECT.isUpdated(dateUpdate, getTable)
            isUpdated = False
        End If
        anyActual = a
        dateUpdate = Now
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaPretancament
    End Function

End Module
