Option Explicit On
Module CopyDB
    Private fAvis As frmAvis
    Public Sub copy()
        Dim rutaOrigen As String, rutaDesti As String
        fAvis = New frmAvis(IDIOMA.getString("actualitzarDirectoriServidor"))
        Call fAvis.setData(IDIOMA.getString("copiarFitxer"), "", "xcopy")

        rutaOrigen = CONFIG.setFolder(CONFIG_FILE.getTag(TAG.RUTA_SERVIDOR_DADES))
        If CONFIG.folderExist(CONFIG_FILE.getTag(TAG.RUTA_SERVIDOR_DADES)) Then
            rutaDesti = CONFIG.setFolder(CONFIG.getDirectoriBDLocal)
            If CONFIG.folderExist(CONFIG.getDirectoriBDLocal) Then
                Call copiarDirectori(rutaOrigen, rutaDesti)
            Else
                Call ERRORS.ERR_RUTA_SERVIDOR_LOCAL()
            End If
        Else
            Call ERRORS.ERR_RUTA_SERVIDOR()
        End If
            fAvis.Close()
    End Sub

    Private Sub copiarDirectori(rutaOrigen As String, rutaDesti As String)
        Dim fs As Object, carpeta As Object, fitxer As Object
        fs = CreateObject("Scripting.FileSystemObject")
        carpeta = fs.getFolder(rutaOrigen)
        rutaDesti = CONFIG.setFolder(rutaDesti)
        For Each fitxer In carpeta.FILES
            If Not CONFIG.folderExist(rutaDesti) Then
                Call MkDir(rutaDesti)

            End If
            Call copiarFitxer(fitxer.path, rutaDesti & fitxer.Name)
        Next fitxer
        For Each carpeta In carpeta.subFolders
            Call copiarDirectori(carpeta.path, rutaDesti & carpeta.Name)
        Next carpeta
        fs = Nothing
        carpeta = Nothing
        fitxer = Nothing
    End Sub

    Private Sub copiarFitxer(rutaIn As String, rutaOut As String)
        On Error GoTo err70
        Dim isCopy As Boolean
        isCopy = True
        If CONFIG.fileExist(rutaOut) Then
            If CONFIG.getDateFileModified(rutaIn) = CONFIG.getDateFileModified(rutaOut) Then isCopy = False
        End If
        If isCopy Then
            Call fAvis.setData(IDIOMA.getString("copiarFitxer"), rutaIn, "xcopy")
            Call FileCopy(rutaIn, rutaOut)
        End If
        Exit Sub
err70:
        If Not Err.Number = 70 Then
            Call MsgBox(Err.Description, vbCritical, "ERROR Nº " & Err.Number)
        End If
    End Sub


End Module
