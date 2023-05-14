Module ModelComandaRecepcio
    Private objects As List(Of ComandaRecepcio)
    Private dateUpdate As DateTime
    Private anyActual As Integer
    Public Function getObjects(Optional filtre As String = "") As List(Of ComandaRecepcio)
        Dim a As ComandaRecepcio, altres As String = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of ComandaRecepcio)
        For Each a In objects
            If a.nomProveidor IsNot Nothing Then altres = a.nomProveidor
            If a.codiProjecte IsNot Nothing Then altres = altres & a.codiProjecte
            If a.codiEmpresa IsNot Nothing Then altres = altres & a.codiEmpresa
            If altres <> "" Then
                If a.isFilter(filtre, altres) Then
                    getObjects.Add(a)
                End If
            Else
                If a.isFilter(filtre) Then
                    getObjects.Add(a)
                End If
            End If

        Next
    End Function
    Public Function getObjects(dIni As Date, dFi As Date) As List(Of ComandaRecepcio)
        Dim a As ComandaRecepcio
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of ComandaRecepcio)
        For Each a In objects
            If a.data >= dIni And a.data <= dFi Then
                getObjects.Add(a)
            End If
        Next
        a = Nothing
    End Function
    'Public Function getDataList(comandes As List(Of Comanda)) As DataList
    '    Dim a As Comanda, esEnviada As String, comentString As String, cm As ComentariMD, esUrgent As String, i As Integer
    '    getDataList = New DataList
    '    comandes.Sort()
    '    If comandes.Count > 0 Then
    '        getDataList.columns.Add(COLUMN.ID)
    '        getDataList.columns.Add(COLUMN.GENERICA("urgent", 65, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("codi", 90, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("data", 90, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("empresa", 50, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("proveidor", 150, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("base", 100, HorizontalAlignment.Right))
    '        getDataList.columns.Add(COLUMN.GENERICA("iva", 100, HorizontalAlignment.Right))
    '        getDataList.columns.Add(COLUMN.GENERICA("total", 100, HorizontalAlignment.Right))
    '        getDataList.columns.Add(COLUMN.GENERICA("myDoc", 100, HorizontalAlignment.Right))
    '        getDataList.columns.Add(COLUMN.GENERICA("estatMydoc", 200, HorizontalAlignment.Left))
    '        getDataList.columns.Add(COLUMN.GENERICA("dataEntradaMydoc", 100, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("enviadaAProveidor", 50, HorizontalAlignment.Center))
    '        getDataList.columns.Add(COLUMN.GENERICA("comentaris", 300, HorizontalAlignment.Left))
    '        i = 0
    '        For Each a In comandes
    '            If a.empresa Is Nothing Then a.empresa = New Empresa
    '            If a.projecte Is Nothing Then a.projecte = New Projecte
    '            If a.proveidor Is Nothing Then a.proveidor = New Proveidor
    '            If a.idMydoc > 0 And a.docMyDoc Is Nothing Then
    '                esEnviada = IDIOMA.getString("si")
    '            Else
    '                esEnviada = IDIOMA.getString("no")
    '            End If
    '            If a.urgent Then
    '                esUrgent = IDIOMA.getString("si")
    '            Else
    '                esUrgent = IDIOMA.getString("no")
    '            End If
    '            comentString = ""
    '            For Each cm In a.comentaris
    '                If comentString = "" Then
    '                    comentString = Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
    '                Else
    '                    comentString = comentString & " --> " & Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
    '                End If

    '            Next
    '            If a.empresa.id = 1 Then
    '                getDataList.rows.Add(New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString}))
    '            Else
    '                getDataList.rows.Add(New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString}))
    '            End If
    '            If a.urgent Then
    '                getDataList.rows(i).BackColor = Color.Cyan
    '            Else
    '                getDataList.rows(i).BackColor = Color.White
    '            End If
    '            i = i + 1
    '        Next
    '    End If
    '    a = Nothing
    'End Function
    'Public Function getListViewItem(a As Comanda) As ListViewItem
    '    Dim esUrgent As String, esEnviada As String, comentString As String
    '    If a.idMydoc > 0 And a.docMyDoc Is Nothing Then
    '        esEnviada = IDIOMA.getString("si")
    '    Else
    '        esEnviada = IDIOMA.getString("no")
    '    End If
    '    If a.urgent Then
    '        esUrgent = IDIOMA.getString("si")
    '    Else
    '        esUrgent = IDIOMA.getString("no")
    '    End If
    '    comentString = ""
    '    For Each cm In a.comentaris
    '        If comentString = "" Then
    '            comentString = Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
    '        Else
    '            comentString = comentString & " --> " & Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
    '        End If

    '    Next
    '    If a.empresa.id = 1 Then
    '        '{a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString}
    '        Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
    '    Else
    '        Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
    '    End If

    'End Function
    'Public Function getListViewItem(id As Integer) As ListViewItem
    '    Dim a As Comanda, esUrgent As String, esEnviada As String, comentString As String
    '    a = getObject(id)
    '    If a.idMydoc > 0 And a.docMyDoc Is Nothing Then
    '        esEnviada = IDIOMA.getString("si")
    '    Else
    '        esEnviada = IDIOMA.getString("no")
    '    End If
    '    If a.urgent Then
    '        esUrgent = IDIOMA.getString("si")
    '    Else
    '        esUrgent = IDIOMA.getString("no")
    '    End If
    '    comentString = ""
    '    For Each cm In a.comentaris
    '        If comentString = "" Then
    '            comentString = Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
    '        Else
    '            comentString = comentString & " --> " & Format(cm.dataIni, "dd-MM-yy hh:mm") & " (" & cm.loginUsuari & ") - " & cm.comentari
    '        End If

    '    Next
    '    If a IsNot Nothing Then
    '        If a.empresa.id = 1 Then
    '            Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, "REM", a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
    '        Else
    '            Return New ListViewItem(New String() {a.id, esUrgent, a.codi, a.data, a.empresa.codi, a.projecte.codi, a.proveidor.nom, Format(a.baseComanda, "#,##0.00 €"), Format(a.ivaComanda, "#,##0.00 €"), Format(a.totalComanda, "#,##0.00 €"), a.idMydoc, a.getStringTascaMydoc, a.getDataTascaMydoc, esEnviada, comentString})
    '        End If

    '    End If
    '    Return Nothing
    'End Function
    Public Function getObject(id As Integer) As ComandaRecepcio
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObjectBYCodi(idEmpresa As Integer, c As Integer) As ComandaRecepcio
        Return objects.Find(Function(x) x.num = c And x.idEmpresa = idEmpresa)
    End Function
    Public Function getCodi(id As Integer) As String
        Dim c As ComandaRecepcio
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        c = objects.Find(Function(x) x.id = id)
        If c IsNot Nothing Then Return c.codicomanda
        Return Nothing
    End Function
    Public Function getNom(id As Integer) As String
        Dim a As ComandaRecepcio
        getNom = ""
        'If Not isUpdated(ANYO) Then objects = getRemoteObjects(ANYO)
        a = objects.Find(Function(x) x.id = id)
        If a IsNot Nothing Then getNom = a.nomProveidor
        a = Nothing
    End Function

    Public Function exist(obj As ComandaRecepcio) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codiComanda = obj.codiComanda)
    End Function
    Public Function existCodi(obj As ComandaRecepcio) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codiComanda = obj.codiComanda)
    End Function
    Public Function existObject(id As Integer, p As Object) As Boolean
        Return dbComanda.exist(id, p, 0)
    End Function
    Public Function save(obj As ComandaRecepcio) As Integer
        Dim a As articleComanda
        If Not isUpdated() Then objects = getRemoteObjects()
        If obj.id = -1 Then
            obj.id = dbComandaRecepcio.insert(obj)
        Else
            obj.id = dbComandaRecepcio.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function insert(obj As ComandaRecepcio) As Integer
        Dim a As articleComanda
        If Not isUpdated() Then objects = getRemoteObjects()
        obj.id = dbComandaRecepcio.insert(obj)
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(estat As Boolean) As Boolean
        If dbComandaRecepcio.remove(estat) Then Call resetIndex()

    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of ComandaRecepcio)
        dateUpdate = Now()
        Return dbComandaRecepcio.getObjects(-1)
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaComandaEdicio)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
