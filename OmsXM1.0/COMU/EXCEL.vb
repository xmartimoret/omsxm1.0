Option Explicit On
Imports XLS = Microsoft.Office.Interop.Excel

Module EXCEL
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Private Declare Auto Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr,
              ByRef lpdwProcessId As Integer) As Integer
    Private idMacros As Integer
    Private Const FITXER_MACROS As String = "macros.xlam"
    Public Function getWorkbook(wbName As String) As XLS.Workbook
        Dim wb As XLS.Workbook, xlsApplication As XLS.Application
        Dim pID As Integer
        getWorkbook = Nothing
        If existProcess("excel") Then
            xlsApplication = Interaction.GetObject(, "excel.application")
            GetWindowThreadProcessId(xlsApplication.Hwnd, pID)
            For Each wb In xlsApplication.Workbooks
                If StrComp(wb.Name, wbName, vbTextCompare) = 0 Then
                    getWorkbook = wb
                    Exit For
                End If
            Next wb
        End If
    End Function
    Public Function getWorkbookByCodeName(wbCodeName As String) As XLS.Workbook
        Dim wb As XLS.Workbook, xlsApplication As XLS.Application
        Dim pID As Integer
        getWorkbookByCodeName = Nothing
        If existProcess("excel") Then
            xlsApplication = Interaction.GetObject(, "excel.application")
            GetWindowThreadProcessId(xlsApplication.Hwnd, pID)
            For Each wb In xlsApplication.Workbooks
                If StrComp(wb.CodeName, wbCodeName, vbTextCompare) = 0 Then
                    getWorkbookByCodeName = wb
                    Exit For
                End If
            Next wb
        End If
    End Function
    Public Function openWorkbook(ruta As String, Optional updateLinks As Boolean = False, Optional nomesLectura As Boolean = False) As XLS.Workbook
        Dim xlsApplication As XLS.Application, pId As Integer
        If existProcess("excel") Then
            xlsApplication = Interaction.GetObject(, "excel.application")
        Else
            xlsApplication = New XLS.Application
        End If

        xlsApplication.Visible = True
        GetWindowThreadProcessId(xlsApplication.Hwnd, pId)
        openWorkbook = xlsApplication.Workbooks.Open(ruta, updateLinks, nomesLectura)

    End Function

    Public Function existWorkbookOpen(wbName As String) As Boolean
        Dim wb As XLS.Workbook, xlsApplication As XLS.Application, pId As Integer
        xlsApplication = New XLS.Application
        GetWindowThreadProcessId(xlsApplication.Hwnd, pId)
        existWorkbookOpen = False
        For Each wb In xlsApplication.Workbooks
            If StrComp(wb.Name, wbName, vbTextCompare) = 0 Then
                existWorkbookOpen = True
                Exit For
            End If
        Next wb
        Call resetObject(xlsApplication, pId)
        Call resetObject(wb)
    End Function
    Public Function getWorkSheet(wb As XLS.Workbook, codeName As String) As XLS.Worksheet
        Dim ws As XLS.Worksheet
        getWorkSheet = Nothing
        For Each ws In wb.Worksheets
            If UCase(ws.CodeName) = UCase(codeName) Then
                getWorkSheet = ws
                Exit For
            End If
        Next ws
        Call resetObject(ws)
    End Function
    Public Function getWorkSheetByName(wb As XLS.Workbook, nom As String) As XLS.Worksheet
        Dim ws As XLS.Worksheet
        getWorkSheetByName = Nothing
        For Each ws In wb.Worksheets
            If UCase(ws.Name) = UCase(nom) Then
                getWorkSheetByName = ws
                Exit For
            End If
        Next ws
        Call resetObject(ws)
    End Function
    Public Function existWorkSheet(wb As XLS.Workbook, nom As String) As Boolean
        Dim ws As XLS.Worksheet
        existWorkSheet = False
        For Each ws In wb.Worksheets
            If StrComp(ws.Name, nom, vbTextCompare) = 0 Then
                existWorkSheet = True
                Exit For
            End If
        Next ws
        Call resetObject(ws)
    End Function
    ''' <summary>
    ''' Comprova que existeix un nom de rang en un llibre excel passat com a parametre
    ''' </summary>
    ''' <param name="wb">WorkBook</param>
    ''' <param name="p">Nom</param>
    ''' <returns>Cert si existeix, fals en cas contrari</returns>
    Public Function existNameRange(wb As XLS.Workbook, p As String) As Boolean
        Dim i As Integer
        existNameRange = False
        For i = 1 To wb.Names.Count
            If wb.Names.Item(i).NameLocal = p Then
                existNameRange = True
                Exit For
            End If
        Next i

    End Function
    ''' <summary>
    ''' Afefeix un nom a un rang excel.
    ''' </summary>
    ''' <param name="ws">nom de la fulla</param>
    ''' <param name="rang">String. adreça on s'inserirà el nom</param>
    ''' <param name="nom">String. Nom del rang</param>
    Public Sub setNameRange(ws As XLS.Worksheet, rang As String, nom As String)
        Call ws.Names.Add(nom, "=" & ws.Name & "!" & rang)
    End Sub
    Public Function getNewWorkbook() As XLS.Workbook
        Dim xlsApplication As XLS.Application, pID As Integer
        If existProcess("excel") Then
            xlsApplication = Interaction.GetObject(, "excel.application")
        Else
            xlsApplication = New XLS.Application
        End If
        GetWindowThreadProcessId(xlsApplication.Hwnd, pID)
        getNewWorkbook = xlsApplication.Workbooks.Add
        ' Call resetObject(xlsApplication, pID)
    End Function
    Public Sub killProcessId(pid As Integer)
        Dim myProcesses() As Process, p As Process
        myProcesses = Process.GetProcessesByName("EXCEL")
        For Each p In myProcesses
            If p.Id = pid Then
                Call p.Kill()
                Exit For
            End If
        Next
    End Sub
    Public Sub killProcessPDF()
        Dim myProcesses() As Process, p As Process
        myProcesses = Process.GetProcessesByName("AcroRd32")
        For Each p In myProcesses
            p.Kill()
        Next
    End Sub
    Private Function existProcess(nomProces As String) As Boolean
        Dim myProcesses() As Process, p As Process
        myProcesses = Process.GetProcessesByName(nomProces)
        For Each p In myProcesses
            Return True
        Next
        Return False
    End Function
    Public Sub resetObject(ByVal obj As Object, Optional pID As Integer = -1)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            If pID > 0 Then Call killProcessId(pID)
        End Try
    End Sub
    Public Sub LiberarMemoria()
        Try
            Dim memoria As Process
            memoria = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)
        Catch ex As Exception
        End Try
    End Sub
    Public Function getMacros() As XLS.Application
        Dim xlapplication As XLS.Application, ad As XLS.AddIn, esObert As Boolean
        Dim adds As XLS.AddIns2
        xlapplication = New XLS.Application
        adds = xlapplication.AddIns2
        For Each ad In adds
            If InStr(1, ad.Name, "MACROS", vbTextCompare) > 0 And InStr(1, ad.Name, "xlam", vbTextCompare) > 0 Then
                If ad.IsOpen Then
                    getMacros = ad
                    Exit For
                End If
            End If
        Next ad
        If Not esObert Then
            xlapplication.Workbooks.Open(CONFIG.getRutaApliMacros & FITXER_MACROS)
        End If
        GetWindowThreadProcessId(xlapplication.Hwnd, idMacros)
        Return xlapplication
    End Function
    Public Sub closeMacros(xlapplication As XLS.Application)
        For Each ad In xlapplication.AddIns2
            If InStr(1, ad.Name, "MACROS", vbTextCompare) > 0 And InStr(1, ad.Name, "xlam", vbTextCompare) > 0 Then
                If ad.IsOpen Then

                    Call resetObject(ad)
                    Exit For
                End If
            End If
        Next ad
        Call resetObject(xlapplication, idMacros)
    End Sub
    Public Function getFitxersGBOberts() As List(Of String)
        Dim wb As XLS.Workbook, xlsApplication As XLS.Application
        getFitxersGBOberts = New List(Of String)
        If existProcess("excel") Then
            xlsApplication = Interaction.GetObject(, "excel.application")
            For Each wb In xlsApplication.Workbooks
                If EXCEL.existWorkSheet(wb, "DADESOMS") Then
                    getFitxersGBOberts.Add(setFolder(wb.Path) & wb.Name)
                End If
            Next wb
            Call resetObject(xlsApplication)
        End If
        wb = Nothing
    End Function
    Public Function getAplicacioExcel() As XLS.Application
        If existProcess("excel") Then Return Interaction.GetObject(, "excel.application")
        Return Nothing
    End Function
    Public Sub closeWorkbook(nom As String)
        Dim wb As XLS.Workbook, xlsApplication As XLS.Application
        If existProcess("excel") Then
            xlsApplication = Interaction.GetObject(, "excel.application")
            For Each wb In xlsApplication.Workbooks
                If wb.Name = nom Then
                    wb.Close(False)
                End If
            Next wb
            Call resetObject(xlsApplication)
        End If
        wb = Nothing
    End Sub
End Module
