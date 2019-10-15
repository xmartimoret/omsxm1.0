' 24/08/2017. cal provar, 
' falta crear el formulari frmTransitoria, ja es pot fer.
Option Explicit On
Imports ADODB

Module ModelAssentamentTransitoria

    Private Const NUMERO_ASSENTAMENT As Integer = 1
    Private Const TEMP_NOM As String = "temp.dbf"
    Private Const TEMP_NOM_EXTORN As String = "tempex.dbf"

    Public Function getAssentaments(at As AssentamentTransitoria, transitories As List(Of Transitoria), Optional isExtorn As Boolean = False) As Collection
        Dim a As Assentament, t As Transitoria
        getAssentaments = New Collection
        For Each t In transitories
            a = New Assentament
            If t.idSubcompte > 0 Then
                If isExtorn Then
                    a.concepte = at.concepteExtorn
                    a.dataAssentament = at.fechaExtorn
                    a.numero = NUMERO_ASSENTAMENT + 1
                Else
                    a.concepte = at.concepte
                    a.dataAssentament = at.fecha
                    a.numero = NUMERO_ASSENTAMENT
                End If
                a.document = at.document
                a.projecteAssentament = ModelProjecte.getCodi(t.idProjecte)
                a.clave = Right(a.projecteAssentament, 6)
                a.departamentAssentament = Left(a.projecteAssentament, 3)
                a.subcompteAssentament = ModelSubcompte.getCodi(t.idSubcompte)
                If isExtorn Then
                    If t.valorAS > 0 Then
                        a.haver = Math.Round(t.valorAS * 100, 0)
                    Else
                        a.deure = Math.Round(t.valorAS * -100, 0)
                    End If
                Else
                    If t.valorAS > 0 Then
                        a.deure = Math.Round(t.valorAS * 100, 0)
                    Else
                        a.haver = Math.Round(t.valorAS * -100, 0)
                    End If
                End If
                getAssentaments.Add(a)
            End If
        Next t
        a = Nothing
        t = Nothing
    End Function

    Private Function save(at As AssentamentTransitoria) As Boolean
        Dim cn As ADODB.Connection, rc As ADODB.Recordset, a As Assentament, aExt As Assentament
        Dim tempNom As String
        rc = New ADODB.Recordset
        If CONFIG.fileExist(CONFIG.setFolder(at.ruta) & TEMP_NOM) Then Call Kill(CONFIG.setFolder(at.ruta) & TEMP_NOM)
        If CONFIG.fileExist(CONFIG.setFolder(at.ruta) & TEMP_NOM_EXTORN) Then Call Kill(CONFIG.setFolder(at.ruta) & TEMP_NOM_EXTORN)
        cn = DBCONNECT.connectDBF(at.ruta)

        ' 1 assentamnet saldoCompres transitoria
        a = New Assentament
        aExt = New Assentament
        a.concepte = at.concepte
        a.dataAssentament = at.fecha
        a.document = at.document
        a.numero = NUMERO_ASSENTAMENT
        a.subcompteAssentament = at.subcteSaldoDeure
        If at.saldoCompres > 0 Then
            a.haver = at.saldoCompres ' per saldar
        Else
            a.deure = at.saldoCompres * -1
        End If
        at.assentaments.Add(a) 'safegeix

        '2 assentament saldoCompres extorntransitoria
        aExt.concepte = at.concepteExtorn
        aExt.dataAssentament = at.fechaExtorn
        aExt.document = at.document
        aExt.numero = NUMERO_ASSENTAMENT + 1
        aExt.subcompteAssentament = at.subcteSaldoDeure
        If at.saldoCompresExtorn > 0 Then
            aExt.deure = at.saldoCompresExtorn 'per saldart
        Else
            aExt.haver = at.saldoCompresExtorn * -1
        End If
        at.assentamentsExtorn.Add(aExt)

        ' 3 assentament saldar vendes transitoria
        a = New Assentament
        aExt = New Assentament
        a.concepte = at.concepte
        a.dataAssentament = at.fecha
        a.document = at.document
        a.numero = NUMERO_ASSENTAMENT
        a.subcompteAssentament = at.subcteSaldoHaver
        If at.saldoVendes > 0 Then
            a.haver = at.saldoVendes
        Else
            a.deure = at.saldoVendes * -1
        End If
        at.assentaments.Add(a)

        ' 4 assentament saldar vendes transitoria extorn
        aExt.concepte = at.concepteExtorn
        aExt.dataAssentament = at.fechaExtorn
        aExt.document = at.document
        aExt.numero = NUMERO_ASSENTAMENT + 1
        aExt.subcompteAssentament = at.subcteSaldoHaver
        If at.saldoVendesExtorn > 0 Then
            aExt.deure = at.saldoVendesExtorn
        Else
            aExt.haver = at.saldoVendesExtorn * -1
        End If
        at.assentamentsExtorn.Add(aExt)

        rc.Open(getSQLCreate(TEMP_NOM), cn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        For Each a In at.assentaments
            If a.saldo <> 0 Then rc.Open(getSQLInsert(TEMP_NOM, a), cn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Next a

        If at.isUnFitxer Then
            tempNom = TEMP_NOM
        Else
            tempNom = TEMP_NOM_EXTORN
            rc.Open(getSQLCreate(tempNom), cn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        End If
        For Each a In at.assentamentsExtorn
            If a.saldo <> 0 Then rc.Open(getSQLInsert(tempNom, a), cn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Next a

        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()
        FileCopy(CONFIG.setFolder(at.ruta) & TEMP_NOM, at.pathFitxer)
        If Not at.isUnFitxer Then FileCopy(CONFIG.setFolder(at.ruta) & TEMP_NOM_EXTORN, at.pathFitxerExtorn)
        If CONFIG.fileExist(at.ruta & TEMP_NOM) Then Call Kill(CONFIG.setFolder(at.ruta) & TEMP_NOM)
        If CONFIG.fileExist(at.ruta & TEMP_NOM_EXTORN) Then Call Kill(CONFIG.setFolder(at.ruta) & TEMP_NOM_EXTORN)
        rc = Nothing
        cn = Nothing
        a = Nothing
        Return True
    End Function

    Private Function getSQLCreate(taula As String)
        getSQLCreate = "CREATE TABLE  " & taula & " ([ASIEN] numeric(6),[FECHA] date,[SUBCTA] char(12),[CONTRA] char(12),[PTADEBE] numeric(16,2) ,[CONCEPTO] char(25),[PTAHABER] numeric(16, 2),[FACTURA] numeric(8),[BASEIMPO] numeric(16, 2),[IVA] numeric(5),[RECEQUIV] numeric(5, 2),[DOCUMENTO] char(10)," &
                                                                 "[DEPARTA] char(3),[CLAVE] char(6),ESTADO char(1),[NCASADO] numeric(6),[TCASADO] numeric(1),[TRANS] numeric(6),[CAMBIO] numeric(16, 6),[DEBEME] numeric(16, 2),[HABERME] numeric(16, 2),[AUXILIAR] char(1),[SERIE] char(1),[SUCURSAL] char(4)," &
                                                                 "CODDIVISA char(5),IMPAUXME numeric(16, 2),MONEDAUSO char(1),EURODEBE numeric(16, 2),EUROHABER numeric(16, 2),BASEEURO numeric(16, 2),NOCONV logical,NUMEROINV char(10), SERIE_RT char(1),FACTU_RT numeric(8),BASEIMP_RT numeric(16, 2)," &
                                                                 "BASEIMP_RF numeric(16, 2),RECTIFICA logical,FECHA_RT date,NIC char(1),LPERIODICO LOGICAL,CODMOVPER numeric(6),LINTERRUMP LOGICAL,SEGACTIV char(6),SEGGEOGR char(6),LRECT349 logical,FECHA_OP date,FECHA_EX date,TIPOOPE char(1)," &
                                                                 "NFACTICK numeric(8),NUMACUINI char(40),NUMACUFIN char(40),TERIDNIF numeric(1),TERNIF char(15),TERNOM char(40),TERNIF14 char(9),TBIENTRAN logical,TBIENCOD char(10),TRANSINM logical,METAL logical,METALIMP numeric(16, 2),CLIENTE char(12),OPBIENES numeric(1)," &
                                                                 "FACTURAEX char(40),[GUID] char(40),[L340] logical) "

    End Function

    Private Function getSQLInsert(taula As String, a As Assentament)
        getSQLInsert = "INSERT INTO " & taula & "(ASIEN, FECHA, SUBCTA, PTADEBE, CONCEPTO, PTAHABER, FACTURA, BASEIMPO, IVA, RECEQUIV, DOCUMENTO, DEPARTA, CLAVE, NCASADO, TCASADO, TRANS, CAMBIO, DEBEME, HABERME, IMPAUXME, MONEDAUSO, EURODEBE, EUROHABER, BASEEURO, NOCONV, FACTU_RT, BASEIMP_RT, BASEIMP_RF, RECTIFICA, NIC, LPERIODICO, CODMOVPER, LINTERRUMP, LRECT349)" &
                                                    " VALUES  (" & a.numero & " ,'" & a.dataAssentament & "','" & a.subcompteAssentament & "',0,'" & a.concepte & "',0,0,0,0,0,'" & a.document & "','" & a.departamentAssentament & "','" & a.clave & "',0,0,0,0,0,0,0,'2','" & Math.Round(a.deure / 100, 2) & "','" & Math.Round(a.haver / 100, 2) & "','0',0,0,0,0,0,'E',0,0,0,0)"
    End Function

    'todo
    Public Function execute() As Boolean
        Dim a As AssentamentTransitoria
        a = dAssentamentTransitories.getAssentament
        If a IsNot Nothing Then
            Call save(a)
            Call MISSATGES.ASSENTAMENT_TRANSITORIA_EXPORT(a.pathFitxer)
            execute = True
        Else
            execute = False
        End If
        a = Nothing
    End Function

End Module
