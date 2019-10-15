Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModulFitxersTransitoria
    Private Const FITXER_PLANTILLA As String = "plantillaTransitoriaProjecte.xls" 'nom fitxer on es guarda la configuració
    Private Const RANG_CODI_PROJECTE As String = "B3"
    Private Const RANG_DATA_ACTUAL As String = "D3"
    Private Const MARCA_RESUMEN As String = "RESUMEN"
    Private Const WORKSHEET_TRANSITORIA As String = "WSTRANSITORIA"
    Private projectesActuals As List(Of Projecte)
    Private rutaExportacio As String
    Private anyActual As Integer
    Private codiEmpresa As String
    Public Sub executePlantilla(projectes As List(Of Projecte), cEmpresa As String, rExportacio As String, anyo As Integer)
        projectesActuals = projectes
        rutaExportacio = rExportacio
        anyActual = anyo
        codiEmpresa = cEmpresa
        Call crearFitxers()
        projectesActuals = Nothing
    End Sub
    Private Sub crearFitxers()
        Dim fitxerPlantilla As String, apliExcel As Application, p As Projecte, avis As frmAvis
        fitxerPlantilla = CONFIG.setFolder(DBCONNECT.getRutaDBActual)
        fitxerPlantilla = fitxerPlantilla & FITXER_PLANTILLA
        rutaExportacio = CONFIG.setFolder(rutaExportacio)
        avis = New frmAvis(IDIOMA.getString("crearFitxersPlantillaTransitoria"), "", "")
        apliExcel = EXCEL.getMacros
        If CONFIG.fileExist(fitxerPlantilla) Then
            For Each p In projectesActuals
                avis.setData(p.ToString, "", "")
                If Not apliExcel.Run("crearFitxerTransitoria", fitxerPlantilla, rutaExportacio, anyActual, p.ToString, codiEmpresa) Then
                    Call ERRORS.ERR_NO_PLANTILLA_TRANSITORIA()
                    Exit For
                End If
            Next
        Else
            Call ERRORS.ERR_NO_PLANTILLA_TRANSITORIA()
        End If
        avis.tancar()
        apliExcel.Run("tancarPlantillaFitxerTtransitoria", fitxerPlantilla)
        Call EXCEL.closeMacros(apliExcel)
        avis = Nothing
        apliExcel = Nothing
    End Sub
End Module
