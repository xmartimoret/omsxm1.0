Module MISSATGES
    Private Function ABORT() As String
        Return IDIOMA.getString("abort")
    End Function
    Private Function AVIS() As String
        Return IDIOMA.getString("avis")
    End Function
    Private Function REALITZADA() As String
        Return IDIOMA.getString("realitzada")
    End Function
    Private Function CONFIRMAR() As String
        Return IDIOMA.getString("confirmar")
    End Function
    Public Sub ERR_SERVER_DATA()
        Call MsgBox(IDIOMA.getString("missatge_errserverdata"), MsgBoxStyle.Critical, ABORT)
    End Sub
    Public Sub ERR_SAVE_FILE_CONFIG(missatge As String)
        Call MsgBox(missatge, MsgBoxStyle.Critical, ABORT)
    End Sub
    Public Sub ERR_LOGIN()
        Call MsgBox(IDIOMA.getString("missatge.errlogin"), MsgBoxStyle.Critical, ABORT)
    End Sub
    Public Sub ERR_PASSWORD()
        Call MsgBox(IDIOMA.getString("missatge.errpassword"), MsgBoxStyle.Critical, ABORT)
    End Sub
    Public Sub ERR_ACTION_ABORT(Optional m As String = "")
        If m = "" Then
            Call MsgBox(IDIOMA.getString("error.general"), MsgBoxStyle.Critical, ABORT)
        Else
            Call MsgBox(m, MsgBoxStyle.Critical, ABORT)
        End If
    End Sub
    'CONFIRM_REMOVE_REPORT
    Public Function CONFIRM_REMOVE_REPORT(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatge.eliminar.informe"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatge.eliminar.informe") & " (" & m & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_QUIT_SUBCOMPTEGRUP
    Public Function CONFIRM_QUIT_SUBCOMPTEGRUP(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeTreureSubcompteGrup"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeTreureSubcompteGrup") & " (" & m & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function CONFIRM_SOBREESCRIURE_FITXER(nom As String) As Boolean
        If MsgBox(IDIOMA.getString("missatge.confirmar.elFitxer") & " " & UCase(nom) & " " & IDIOMA.getString("missatge.confirmar.jaExisteix") & vbCrLf & IDIOMA.getString("missatge.confirmar.sobreEscriure"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
    Public Sub REALITZAT_INFORME()
        Call MsgBox(IDIOMA.getString("missatge.informeRealitzat"), MsgBoxStyle.Exclamation, REALITZADA)
    End Sub
    Public Sub ERR_NO_PERMISS(nom As String)
        Call MsgBox(IDIOMA.getString("missatge.errNoPermisTaula") & UCase(nom), MsgBoxStyle.Critical, ABORT)
    End Sub
    Public Sub ERR_FITXER_NO_TROBAT()
        Call MsgBox(IDIOMA.getString("missatge.errFitxerNoTrobat"), MsgBoxStyle.Critical, ABORT)
    End Sub
    Public Function CONFIRM_REMOVE_PROJECTE(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarProjecteActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarProjecte") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_SUBCOMPTE(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarSubcompteActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarSubcompte") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_EMPRESA(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarEmpresaActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarEmpresa") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_SUBGRUP(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarSubgrupActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarSubgrup") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    '
    Public Function CONFIRM_REMOVE_SECCIO(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarSeccioActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarSeccio") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_REMOVE_PROJECTE_CENTRE
    Public Function CONFIRM_REMOVE_PROJECTE_CENTRE() As Boolean
        If MsgBox(IDIOMA.getString("missatgeEliminarProjecteCentre"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_CENTRE(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarCentreActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarCentre") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_REMOVE_COLUMNA
    Public Function CONFIRM_REMOVE_COLUMNA(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarColumnaActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarColumna") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_REMOVE_CLIENT
    Public Function CONFIRM_REMOVE_CLIENT(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarClientActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarClient") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_QUIT_COLUMNAFILLA
    Public Function CONFIRM_QUIT_COLUMNAFILLA() As Boolean
        If MsgBox(IDIOMA.getString("missatgeEliminarColumnaFilla"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
    ' CONFIRM_QUIT_COLUMNAPROJECTE
    Public Function CONFIRM_QUIT_COLUMNAPROJECTE() As Boolean
        If MsgBox(IDIOMA.getString("missatgeEliminarProjecteColumna"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_PROJECTE_CLIENT() As Boolean
        If MsgBox(IDIOMA.getString("missatgeTreureProjecteClient"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
    Public Sub NOT_SEARCH_ANOTHER_ACCOUNT()
        Call MsgBox(IDIOMA.getString("NOT_SEARCH_ANOTHER_ACCOUNT"), MsgBoxStyle.Exclamation, IDIOMA.getString("abort"))
    End Sub
    Public Sub NOT_SEARCH_ACCOUNT()
        Call MsgBox(IDIOMA.getString("NOT_SEARCH_ACCOUNT"), MsgBoxStyle.Exclamation, IDIOMA.getString("abort"))
    End Sub
    'CONFIRM_REMOVE_DEPARTAMENT
    Public Function CONFIRM_REMOVE_DEPARTAMENT() As Boolean
        If MsgBox(IDIOMA.getString("missatgeEliminarDepartament"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
    Public Function CONFIRM_COPYFILE(origen As String, desti As String) As Boolean
        If MsgBox(IDIOMA.getString("actualitzarFitxerDiario") & vbCrLf & vbCrLf & IDIOMA.getString("actualitzarFitxerDiarioOrigen") & vbCrLf & vbTab & origen & vbCrLf & vbCrLf & "*** A (DESTÍ): " & vbCrLf & vbTab & desti, MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            CONFIRM_COPYFILE = True
        Else
            CONFIRM_COPYFILE = False
        End If
    End Function
    Public Sub FILE_UPDATED()
        Call MsgBox(IDIOMA.getString("actualitzarFitxerDiarioFitxerActualitzat"), vbExclamation, REALITZADA)
    End Sub
    Public Sub DATA_UPDATED()
        Call MsgBox(IDIOMA.getString("dadesActualitzades"), vbExclamation, REALITZADA)
    End Sub
    Public Function CONFIRM_CLOSE_MONTH(m As Integer, a As Integer, e As Empresa) As Boolean
        If MsgBox(IDIOMA.getString("tancarMesActual") & vbCrLf & CONFIG.mesNom(m) & "-" & a & " " & IDIOMA.getString("de") & " " & UCase(e.nom), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            CONFIRM_CLOSE_MONTH = True
        Else
            CONFIRM_CLOSE_MONTH = False
        End If
    End Function
    Public Function CONFIRM_CLOSE_TRANSITORIA(m As Integer, a As Integer, e As Empresa) As Boolean
        If MsgBox(IDIOMA.getString("tancarTransitoriaActual") & vbCrLf & CONFIG.mesNom(m) & "-" & a & " de " & UCase(e.nom), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            CONFIRM_CLOSE_TRANSITORIA = True
        Else
            CONFIRM_CLOSE_TRANSITORIA = False
        End If
    End Function
    Public Function CONFIRM_REOPEN_MONTH(m As Integer, a As Integer, e As Empresa) As Boolean
        If MsgBox(IDIOMA.getString("obrirMesActual") & vbCrLf & CONFIG.mesNom(m) & "-" & a & " " & IDIOMA.getString("de") & " " & UCase(e.nom), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            CONFIRM_REOPEN_MONTH = True
        Else
            CONFIRM_REOPEN_MONTH = False
        End If
    End Function
    Public Function CONFIRM_REOPEN_TRANSITORIA(m As Integer, a As Integer, e As Empresa) As Boolean
        If MsgBox(IDIOMA.getString("obrirTransitoriaActual") & vbCrLf & CONFIG.mesNom(m) & "-" & a & " " & IDIOMA.getString("de") & " " & UCase(e.nom), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            CONFIRM_REOPEN_TRANSITORIA = True
        Else
            CONFIRM_REOPEN_TRANSITORIA = False
        End If
    End Function
    Public Sub GB_NO_OBERTA()
        Call MsgBox(IDIOMA.getString("fitxerGBNoObert"), MsgBoxStyle.Critical, ABORT)
    End Sub
    Public Sub ASSENTAMENT_TRANSITORIA_EXPORT(p As String)
        Call MsgBox(IDIOMA.getString("assentamentTransitoriaExportat") & vbCrLf & p, MsgBoxStyle.Information, REALITZADA)
    End Sub


    Public Function CONFIRM_SEGUIR_LLIBRE_MAJOR() As Boolean
        If MsgBox(IDIOMA.getString("seguirExportDadesLlibreMajor"), vbQuestion + vbYesNo, CONFIRMAR) = vbYes Then
            CONFIRM_SEGUIR_LLIBRE_MAJOR = True
        Else
            CONFIRM_SEGUIR_LLIBRE_MAJOR = False
        End If
    End Function
    Public Sub NEW_USER(p As Integer)
        If p = 0 Then
            MsgBox(IDIOMA.getString("usuariActual") & ": " & IDIOMA.getString("usuariExplotacions"), vbInformation, REALITZADA)
        ElseIf p = 1 Then
            MsgBox(IDIOMA.getString("usuariActual") & ": " & IDIOMA.getString("usuariAdministrador"), vbInformation, REALITZADA)
        Else
            MsgBox(IDIOMA.getString("usuariActual") & ": " & IDIOMA.getString("usuariSuperAdministrador"), vbInformation, REALITZADA)
        End If
    End Sub

    Public Function CONFIRM_REMOVE_PAIS(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarPaisActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarPaisActual") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_PROVINCIA(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarProvinciaActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarProvinciaActual") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function CONFIRM_REMOVE_TIPUS_PAGAMENT(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarTipusPagamentActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarTipusPagamentActual") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_TIPUS_PROVEIDOR(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarTipusPagamentActual"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarTipusPagamentActual") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_ANOTACIO_PROVEIDOR(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarProveidor"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarProveidor") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_CONTACTE_PROVEIDOR(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarContacteProveidor"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarContacteProveidor") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_PROJECTE_CONTACTE(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeDesvincularContacte"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeDesvincularContacte") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_REMOVE_PROVEIDOR
    Public Function CONFIRM_REMOVE_PROVEIDOR(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarProveidor"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarProveidor") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function CONFIRM_REMOVE_ARTICLE(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarArticle"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarArticle") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_REMOVE_ARTICLE_PREU
    Public Function CONFIRM_REMOVE_ARTICLE_PREU(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarArticlePreu"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarArticlePreu") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    'CONFIRM_REMOVE_Contacte
    Public Function CONFIRM_REMOVE_CONTACTE(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarContacte"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarContacte") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_LLOC_ENTREGA(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarLlocEntrega"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarLlocEntrega") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function CONFIRM_REMOVE_PROJECTE_ENTREGA(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarProjecteEntrega"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarProjecteEntrega") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_SOLICITUD_COMANDA(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarSolicitudComanda"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarSolicitudComanda") & " (" & m & ")?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CONFIRM_REMOVE_COMANDA(Optional m As String = "") As Boolean
        If m = "" Then
            If MsgBox(IDIOMA.getString("missatgeEliminarComanda") & "?.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        Else
            If MsgBox(IDIOMA.getString("missatgeEliminarComanda") & " (" & m & ")?.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Sub ANOTACIONS_PROVEIDOR(p As String, a As String)
        Call MsgBox(IDIOMA.getString("proveidorTeAvisos") & ": " & vbCrLf & a, MsgBoxStyle.Exclamation, AVIS() & "-" & p)
    End Sub
    Public Sub SOLICITUT_GUARDADA(p As String)
        Call MsgBox(IDIOMA.getString("solicitutF56") & ": " & p & ". " & IDIOMA.getString("solicitutGuardada") & ".", MsgBoxStyle.Exclamation, REALITZADA)
    End Sub
    Public Sub COMANDA_GUARDADA(p As String)
        Call MsgBox(IDIOMA.getString("comanda") & ": " & p & ". " & IDIOMA.getString("solicitutGuardada") & ".", MsgBoxStyle.Exclamation, REALITZADA)
    End Sub
    Public Function CONFIRM_CREAR_COMANDA(empresa As String) As Boolean
        If MsgBox(IDIOMA.getString("volsCrearComanda") & " " & empresa & "? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
    Public Sub COMANDA_CREADA(p As String)
        Call MsgBox(IDIOMA.getString("comandaCreada") & ": " & p & ". ", MsgBoxStyle.Exclamation, REALITZADA)
    End Sub
    Public Function CONFIRM_EDITAR_COMANDA(empresa As String) As Boolean
        If MsgBox(IDIOMA.getString("volsf56Comanda") & " " & empresa & "? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CONFIRMAR) = vbYes Then
            Return True
        End If
        Return False
    End Function
End Module

