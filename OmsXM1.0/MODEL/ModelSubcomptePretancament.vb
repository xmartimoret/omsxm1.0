Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModelSubcomptePretancament
    Private objects As List(Of Subcompte)
    Private dateUpdate As DateTime
    Public Function getObjects() As List(Of Subcompte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function
    Public Function getListObjects(subcomptes As List(Of Subcompte)) As Object()
        Dim obj As Subcompte, i As Integer = 0, objectes() As Object
        ReDim objectes(subcomptes.Count - 1)
        For Each obj In subcomptes
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getObject(id As Integer) As Subcompte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function actualitzar() As Boolean
        Dim wb As Workbook, fitxerPlantilla As String, ws As Worksheet, i As Integer, xls As Object
        Dim id As Integer, j As Integer
        If isUpdated() Then objects = getRemoteObjects()
        fitxerPlantilla = CONFIG.setFolder(DBCONNECT.getRutaDBActual) & CONFIG.getPlantillaLlibreMajor
        actualitzar = False
        If CONFIG.fileExist(fitxerPlantilla) Then
            wb = EXCEL.getWorkbook(CONFIG.getPlantillaLlibreMajor)
            If TypeName(wb) <> "Workbook" Then wb = EXCEL.openWorkbook(fitxerPlantilla, False, True)
            If esPlantilla(wb) Then
                ws = EXCEL.getWorkSheet(wb, "WSPRETANCAMENT")
                xls = ws.Range("a1")
                For i = 1 To 500
                    If xls(i, 1).text.Length = 7 Then
                        If IsNumeric(xls(i, 1).text) Then
                            If Not existCode(xls(i, 1).text) Then
                                id = ModelSubcompte.getId(xls(i, 1).text)
                                If id > 0 Then
                                    If dbSubcomptePretancament.insert(id) Then
                                        objects.Add(ModelSubcompte.getObject(id))
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next i
                actualitzar = True
            End If
            wb.Close(False)
        End If
        wb = Nothing
        ws = Nothing
        xls = Nothing
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Function exist(s As Subcompte) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id = s.id)
    End Function
    Public Function existCode(codi As String) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.codi = codi)
    End Function
    Private Function esPlantilla(wb As Workbook) As Boolean
        Dim ws As Worksheet, nomFulles() As String, trobada As Boolean, i As Integer
        esPlantilla = True
        nomFulles = New String() {"WSBALANS", "WSMAJORANALITIC", "WSOBSERVACIONS", "WSPRETANCAMENT"}
        For i = LBound(nomFulles) To UBound(nomFulles)
            trobada = False
            For Each ws In wb.Worksheets
                If UCase(ws.codeName) = nomFulles(i) Then
                    trobada = True
                    Exit For
                End If
            Next ws
            If Not trobada Then
                esPlantilla = False
                Exit For
            End If
        Next i
        ws = Nothing
    End Function
    Private Function getRemoteObjects() As List(Of Subcompte)
        dateUpdate = Now()
        Return dbSubcomptePretancament.getObjects
    End Function
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaSubcomptePretancament
    End Function
End Module
