Module ModulCrearDB
    Public Sub crearTaulaDia(cn As ADODB.Connection, ruta As String)
        Dim rc As ADODB.Recordset, sqlString As String
        rc = New ADODB.Recordset
        If Not CONFIG.fileExist(ruta) Then
            sqlString = "CREATE TABLE  " & CONFIG.getFitxer(ruta) & " (ASIEN numeric(6),FECHA date,[SUBCTA] char(12),[CONTRA] char(12),[PTADEBEN] numeric(16,2) ,CONCEPTO char(25),PTAHABER numeric(16, 2),FACTURA numeric(8),BASEIMPO numeric(16, 2),IVA numeric(5),RECEQUIV numeric(5, 2),DOCUMENTO char(10)," &
                                                                     "departa char(3),clave char(6),ESTADO char(1),NCASADO numeric(6),TCASADO numeric(1),TRANS numeric(6),CAMBIO numeric(16, 6),DEBEME numeric(16, 2),HABERME numeric(16, 2),AUXILIAR char(1),SERIE char(1),SUCURSAL char(4)," &
                                                                     "CODDIVISA char(5),IMPAUXME numeric(16, 2),MONEDAUSO char(1),EURODEBE numeric(16, 2),EUROHABER numeric(16, 2),BASEEURO numeric(16, 2),NOCONV logical,NUMEROINV char(10), SERIE_RT char(1),FACTU_RT numeric(8),BASEIMP_RT numeric(16, 2)," &
                                                                     "BASEIMP_RF numeric(16, 2),RECTIFICA logical,FECHA_RT date,NIC char(1),LPERIODICO LOGICAL,CODMOVPER numeric(6),LINTERRUMP LOGICAL,SEGACTIV char(6),SEGGEOGR char(6),LRECT349 logical,FECHA_OP date,FECHA_EX date,TIPOOPE char(1)," &
                                                                     "NFACTICK numeric(8),NUMACUINI char(40),NUMACUFIN char(40),TERIDNIF numeric(1),TERNIF char(15),TERNOM char(40),TERNIF14 char(9),TBIENTRAN logical,TBIENCOD char(10),TRANSINM logical,METAL logical,METALIMP numeric(16, 2),CLIENTE char(12),OPBIENES numeric(1)," &
                                                                     "FACTURAEX char(40),[GUID] char(40),[L340] logical) "
            Call rc.Open(sqlString, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        End If
        Application.DoEvents()
        If rc.State = 1 Then rc.Close()
        rc = Nothing
    End Sub
End Module
