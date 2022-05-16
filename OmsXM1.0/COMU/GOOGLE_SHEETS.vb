Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Sheets.v4
Imports Google.Apis.Sheets.v4.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Module GOOGLE_SHEETS
    Private Scopes() As String = {SheetsService.Scope.Drive}
    Private ApplicationName As String = "OMSXM1.0"
    Private Const ID_SHEET As String = "1Zm8C_mszCFS6qx8VrdtBcF0J6KjdBGhqCrWV2rBtnNE"
    'Private Const ID_SHEET As String = "12lmlCu0whHXCEQMNFmrb1JFjuVXzzbKx__-XdSIS0yY"
    Private Const FITXER_IDENTIFICACIO As String = "credentials.json"
    Private Const FITXER_TOKEN As String = "token.json"
    Private Const TAULA_PROVEIDOR As String = "PROVEIDORS"
    Private Const TAULA_CONTACTE_PROVEIDOR As String = "CONTACTES_PROVEIDORS"
    Private Const TAULA_PROJECTE As String = "PROJECTES"
    Private Const TAULA_CONTACTE_MAGATZEM As String = "USUARIS"
    Private Const TAULA_MAGATZEM As String = "MAGATZEMS"
    Private Const TAULA_RESPONSABLE As String = "RESPONSABLES"
    Private Const TAULA_EMPRESA As String = "EMPRESES"
    Private Const TAULA_SUBPROJECTE As String = "SUBPROJECTES"
    Private service As SheetsService
    Private sheetsActuals As IList(Of Sheet)
    Public Function save(p As Object) As Boolean
        Dim s As GoogleSheet, r As Long, demanda As SpreadsheetsResource.ValuesResource.UpdateRequest, valorsRang As ValueRange
        Call connectService()
        s = getSheet(getTaula(p))
        If Not s Is Nothing Then
            r = getRow(s, p.id)
            If r > 0 Then
                valorsRang = New ValueRange
                valorsRang.Values = New List(Of IList(Of Object))
                valorsRang.Values.Add(getValor(p))
                demanda = service.Spreadsheets.Values.Update(valorsRang, ID_SHEET, s.nom & "!A" & r + 1 & ":" & UCase(s.getCharColumn))
                demanda.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW
                Call demanda.Execute()
                Return True

            Else
                If s.numFiles > 0 Then
                    Call insertRow(s, s.numFiles - 1, s.numFiles)
                    valorsRang = New ValueRange
                    valorsRang.Values = New List(Of IList(Of Object))
                    valorsRang.Values.Add(getValor(p))
                    demanda = service.Spreadsheets.Values.Update(valorsRang, ID_SHEET, s.nom & "!A" & s.numFiles & ":" & s.getCharColumn)
                    demanda.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW
                    Call demanda.Execute()
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Public Function remove(p As Object) As Boolean
        Dim s As GoogleSheet, r As Long
        Call connectService()
        s = getSheet(getTaula(p))
        If Not s Is Nothing Then
            r = getRow(s, p.id)
            If r > 0 Then
                Call remove(s, r, r + 1)
                Return True
            End If
        End If
        Return False
    End Function

    Public Function saveAll(dades As List(Of Object), o As Object) As Boolean
        Dim rang As String, p As Object, s As GoogleSheet, f As frmAvis
        Dim demanda As SpreadsheetsResource.ValuesResource.UpdateRequest
        Dim valuesRange As New ValueRange()
        Call connectService()
        f = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("actualitzantTaula"), getTaula(o))
        s = getSheet(getTaula(o))
        If removeAll(s) Then
            s.numFiles = dades.Count
            If insertAll(s) Then
                rang = getTaula(o) & "!A2:" & s.getCharColumn
                valuesRange.Values = New List(Of IList(Of Object))()
                For Each p In dades
                    valuesRange.Values.Add(getValor(p))
                Next
                demanda = service.Spreadsheets.Values.Update(valuesRange, ID_SHEET, rang)
                demanda.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW
                Call demanda.Execute()
                f.tancar()
                Return True
            End If
        End If
        f.tancar()
        Return False
    End Function

    'LOCAL FUNCTION
    Public Sub connectService()
        If service Is Nothing Then
            Dim credential As UserCredential
            Using Stream = New FileStream("credentials.json", FileMode.Open, FileAccess.ReadWrite)

                Dim credPath As String = "token.json"
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(Stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None
                       ).Result
                Console.WriteLine("Credential file saved to: " + credPath)
            End Using
            service = New SheetsService(New BaseClientService.Initializer() With
                {
                    .HttpClientInitializer = credential,
                    .ApplicationName = ApplicationName
                })
            sheetsActuals = getSheets()
        End If

    End Sub
    Public Sub closeService()
        If Not service Is Nothing Then
            Call service.Dispose()
        End If
        service = Nothing
    End Sub
    Private Function getRow(id As Integer, rang As String) As Long
        Dim demanda As SpreadsheetsResource.ValuesResource.GetRequest, valors As IList(Of IList(Of Object)), sortida As ValueRange, i As Integer
        demanda = service.Spreadsheets.Values.Get(ID_SHEET, rang)
        sortida = demanda.Execute()
        valors = sortida.Values
        i = 2
        If valors IsNot Nothing And valors.Count > 0 Then
            For Each r In valors
                If r(0) = id Then Return i
                i = i + 1
            Next
        End If
        Return -1
    End Function



    Private Function remove(sheet As GoogleSheet, startRow As Long, endRow As Long)
        Dim RequestContainer As List(Of Request), DeleteRequest As BatchUpdateSpreadsheetRequest, deletion As SpreadsheetsResource.BatchUpdateRequest
        If Not IsNothing(sheet) Then
            Dim r As New Request
            r.DeleteDimension = New DeleteDimensionRequest
            r.DeleteDimension.Range = New DimensionRange()
            With r.DeleteDimension.Range
                .SheetId = sheet.id
                .Dimension = "ROWS"
                .StartIndex = startRow
                .EndIndex = endRow
            End With
            RequestContainer = New List(Of Request)
            RequestContainer.Add(r)
            DeleteRequest = New BatchUpdateSpreadsheetRequest
            DeleteRequest.Requests = RequestContainer
            deletion = New SpreadsheetsResource.BatchUpdateRequest(service, DeleteRequest, ID_SHEET)
            deletion.Execute()
            Return True
        End If
        Return False
    End Function
    Private Function removeAll(sheet As GoogleSheet) As Boolean
        Dim RequestContainer As List(Of Request), DeleteRequest As BatchUpdateSpreadsheetRequest, deletion As SpreadsheetsResource.BatchUpdateRequest
        If Not IsNothing(sheet) Then
            Dim r As New Request
            r.DeleteDimension = New DeleteDimensionRequest
            r.DeleteDimension.Range = New DimensionRange()
            With r.DeleteDimension.Range
                .SheetId = sheet.id
                .Dimension = "ROWS"
                .StartIndex = 1
                .EndIndex = sheet.numFiles - 1
            End With
            RequestContainer = New List(Of Request)
            RequestContainer.Add(r)
            DeleteRequest = New BatchUpdateSpreadsheetRequest
            DeleteRequest.Requests = RequestContainer
            deletion = New SpreadsheetsResource.BatchUpdateRequest(service, DeleteRequest, ID_SHEET)
            deletion.Execute()
            Return True
        End If
        Return False
    End Function
    Private Function insertRow(sheet As GoogleSheet, startRow As Long, endRow As Long) As Boolean
        Dim RequestContainer As List(Of Request), insertRequest As BatchUpdateSpreadsheetRequest, ist As SpreadsheetsResource.BatchUpdateRequest
        If Not IsNothing(sheet) Then
            Dim r As New Request
            r.InsertDimension = New InsertDimensionRequest
            r.InsertDimension.Range = New DimensionRange()
            With r.InsertDimension.Range
                .SheetId = sheet.id
                .Dimension = "ROWS"
                .StartIndex = startRow
                .EndIndex = endRow
            End With
            RequestContainer = New List(Of Request)
            RequestContainer.Add(r)
            insertRequest = New BatchUpdateSpreadsheetRequest
            insertRequest.Requests = RequestContainer
            ist = New SpreadsheetsResource.BatchUpdateRequest(service, insertRequest, ID_SHEET)
            ist.Execute()
            Return True
        End If
        Return False
    End Function
    Private Function insertAll(sheet As GoogleSheet) As Boolean
        Dim RequestContainer As List(Of Request), insertRequest As BatchUpdateSpreadsheetRequest, ist As SpreadsheetsResource.BatchUpdateRequest
        If Not IsNothing(sheet) Then
            Dim r As New Request
            r.InsertDimension = New InsertDimensionRequest
            r.InsertDimension.Range = New DimensionRange()
            With r.InsertDimension.Range
                .SheetId = sheet.id
                .Dimension = "ROWS"
                .StartIndex = 1
                .EndIndex = sheet.numFiles - 1
            End With
            RequestContainer = New List(Of Request)
            RequestContainer.Add(r)
            insertRequest = New BatchUpdateSpreadsheetRequest
            insertRequest.Requests = RequestContainer
            ist = New SpreadsheetsResource.BatchUpdateRequest(service, insertRequest, ID_SHEET)
            ist.Execute()
            Return True
        End If
        Return False
    End Function
    Private Function getSheets() As IList(Of Sheet)
        Dim request As SpreadsheetsResource.GetRequest
        Dim response As Data.Spreadsheet
        request = service.Spreadsheets.Get(ID_SHEET)
        request.Ranges = New List(Of String)
        request.IncludeGridData = False
        response = request.Execute()
        Return response.Sheets
    End Function
    Private Function getSheet(p As String) As GoogleSheet
        Dim s As Sheet
        Dim rangs = New List(Of String)
        For Each s In sheetsActuals
            If p = s.Properties.Title Then
                Return New GoogleSheet(s.Properties.SheetId, s.Properties.Title, s.Properties.GridProperties.RowCount, s.Properties.GridProperties.ColumnCount)
            End If
        Next
        Return Nothing
    End Function
    Private Function getRow(sheet As GoogleSheet, id As Long) As Long
        Dim demanda As SpreadsheetsResource.ValuesResource.GetRequest, sortida As ValueRange, valors As IList(Of IList(Of Object)), i As Integer
        demanda = service.Spreadsheets.Values.Get(ID_SHEET, sheet.nom & "!A2:A")
        sortida = demanda.Execute()
        valors = sortida.Values
        i = 1
        If valors IsNot Nothing And valors.Count > 0 Then
            For Each r In valors
                If r.Count > 0 Then
                    If r(0) = id Then
                        Return i
                    End If
                End If
                i = i + 1
            Next
        End If
        Return -1
    End Function
    Private Function getTaula(p As Object) As String
        Select Case p.GetType.Name
            Case "Proveidor" : Return TAULA_PROVEIDOR
            Case "ProveidorCont" : Return TAULA_CONTACTE_PROVEIDOR
            Case "Contacte" : Return TAULA_CONTACTE_MAGATZEM
            Case "LlocEntrega" : Return TAULA_MAGATZEM
            Case "Projecte" : Return TAULA_PROJECTE
            Case "Empresa" : Return TAULA_EMPRESA
            Case "ResponsableCompra" : Return TAULA_RESPONSABLE
        End Select
    End Function
    Private Function getValor(p As Object) As List(Of Object)
        Select Case p.GetType.Name
            Case "Proveidor" : Return New List(Of Object)({p.id, p.codi, p.nomFiscal, p.direccio, p.poblacio, p.codiPostal, p.actiu, p.pais.nom, p.provincia.nom, p.email})
            Case "ProveidorCont" : Return New List(Of Object)({p.id, p.idproveidor, p.departament, p.nom, p.direccio, p.poblacio, p.codiPostal, p.pais.nom, p.provincia.nom, p.telefon1, p.telefon2, p.email, p.notes, p.actiu})
            Case "Contacte" : Return New List(Of Object)({p.id, p.nom, p.cognom1, p.cognom2, p.direccio, p.poblacio, p.codiPostal, p.pais.nom, p.provincia.nom, p.telefon, p.email, p.notes, p.actiu})
            Case "LlocEntrega" : Return New List(Of Object)({p.id, p.nom, p.direccio, p.poblacio, p.codiPostal, p.pais.nom, p.provincia.nom, p.actiu})
            Case "Projecte" : Return New List(Of Object)({p.id, p.idEmpresa, p.codi, p.nom})
            Case "Empresa" : Return New List(Of Object)({p.id, p.codi, p.nom})
            Case "ResponsableCompra" : Return New List(Of Object)({p.id, p.codi, p.nom, p.actiu})
            Case Else : Return Nothing
        End Select
    End Function
End Module
