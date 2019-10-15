Option Explicit On
''' MODULE: VALIDAR
''' <summary>
''' VALIDAR CAMPS DE TEXT DELS DIFERENTS FORMULARIS DE L'APLICACIO
''' </summary>
Module VALIDAR
    Private Const MAJUSC As Integer = 16
    Private Const INICI As Integer = 36
    Private Const final As Integer = 35
    Private Const intro As Integer = 13
    Private Const INSERT_ As Integer = 45
    Private Const CRTL_ As Integer = 17
    Private Const ALT_ As Integer = 18
    Private Const ESC As Integer = 27
    Private Const SUPR As Integer = 46
    Private Const BACK As Integer = 8
    Private Const TAB_ As Integer = 9
    Private Const FLETXA_E As Integer = 37
    Private Const FLETXA_D As Integer = 39
    Private Const FLETXA_UP As Integer = 38
    Private Const FLETXA_DOWN As Integer = 40
    Private Const COMA As Integer = 44
    Private Const PUNT As Integer = 46
    Private Const ZERO As Integer = 48
    Private Const NOU As Integer = 57
    Private Const BARRA As Integer = 47
    Private Const GUIO As Integer = 45
    Private Const GUIO_BAIX As Integer = 95
    Private Const A_MIN As Integer = 97
    Private Const A_MAJ As Integer = 65
    Private Const Z_MIN As Integer = 122
    Private Const Z_MAJ As Integer = 90
    Private Const ENYE_MIN As Integer = 241
    Private Const ENYE_MAJ As Integer = 209
    Private Const C_TRENCADA_MIN As Integer = 231
    Private Const C_TRENCADA_MAJ As Integer = 199
    Private maxCaracters As Integer
    Private caracters As Integer
    Private KeyCode As Integer
    Private text As String
    Private posCursor As Integer
    Private numDecimals As Integer
    Public Function Enter(keyChar As String, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        Enter = Chr(0)
        If hiHaEspai() Then
            If Not teclaControl() Then
                If validarNumeric() Then
                    Enter = Chr(KeyCode)
                End If
            End If
        End If
    End Function
    Public Function EnterMax(keyChar As String, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0, Optional valorActual As String = "", Optional valorMax As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        EnterMax = ""
        If hiHaEspai() Then
            If validarNumeric() Or teclaControl() Then
                If Val(valorActual & keyChar) <= valorMax Then
                    EnterMax = Chr(KeyCode)
                End If
            End If
        Else
            If teclaControl() Then
                EnterMax = Chr(KeyCode)
            End If
        End If
    End Function

    Public Function EnterNegatiu(keyChar As String, textActual As String, posicioCursor As Integer, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        text = textActual
        posCursor = posicioCursor
        EnterNegatiu = ""
        If hiHaEspai() Then
            If validarNumeric() Then
                EnterNegatiu = Chr(KeyCode)
            ElseIf teclaControl() Then
                EnterNegatiu = Chr(KeyCode)
            ElseIf esNEGATIU() Then
                EnterNegatiu = Chr(KeyCode)
            End If
        Else
            If teclaControl() Then
                EnterNegatiu = Chr(KeyCode)
            End If
        End If
    End Function
    Public Function Decimal_(keyChar As String, textActual As String, posicioCursor As Integer, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0, Optional numeroDecimals As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        text = textActual
        posCursor = posicioCursor
        numDecimals = numeroDecimals
        Decimal_ = ""
        If hiHaEspai() Then
            If Not teclaControl() Then
                If esDecimal() Then
                    Decimal_ = ","
                ElseIf validarNumeric() Then
                    If validNumDecimal() Then
                        Decimal_ = Chr(KeyCode)
                    End If
                End If
            End If
        End If
    End Function
    Public Function DecimalNegatiu(keyChar As String, textActual As String, posicioCursor As Integer, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0, Optional numeroDecimals As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        text = textActual
        posCursor = posicioCursor
        DecimalNegatiu = ""
        numDecimals = numeroDecimals
        If hiHaEspai() Then
            If Not teclaControl() Then
                If validarNumeric() Then
                    If validNumDecimal() Then
                        DecimalNegatiu = Chr(KeyCode)
                    End If
                ElseIf esNEGATIU() Then
                    DecimalNegatiu = Chr(KeyCode)
                ElseIf esDecimal() Then
                    DecimalNegatiu = ","
                End If
            End If
        End If
    End Function
    Public Function texte(keyChar As String, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        texte = 0
        If hiHaEspai() Then
            If Not teclaControl() Then texte = Chr(KeyCode)
        End If
    End Function
    Public Function AlfaNumeric(keyChar As String, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        AlfaNumeric = ""
        If hiHaEspai() Then
            If Not teclaControl() Then
                If validarAlfaNumeric() Then
                    AlfaNumeric = Chr(KeyCode)
                End If
            End If
        End If
    End Function
    Public Function signeAlfaNumeric(keyChar As String, Optional caractersActuals As Integer = 0, Optional maxDigits As Integer = 0) As String
        maxCaracters = maxDigits
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        signeAlfaNumeric = ""
        If hiHaEspai() Then
            If Not teclaControl() Then
                If validarSigneAlfaNumeric() Then
                    signeAlfaNumeric = Chr(KeyCode)
                End If
            End If
        End If
    End Function
    Public Function Data(keyChar As String, texteActual As String, caractersActuals As Integer, posicioCursor As Integer) As String
        maxCaracters = 10
        caracters = caractersActuals
        KeyCode = Asc(keyChar)
        If KeyCode = BACK Then Return keyChar
        caracters = caractersActuals
        posCursor = posicioCursor
        text = texteActual
        Data = ""
        If hiHaEspai() Then
            If Not teclaControl() Then
                If validarNumeric() Or separadorData() Then
                    Data = Chr(KeyCode)
                End If
            End If
        End If
    End Function


    Private Function validarNumeric() As Boolean
        validarNumeric = False
        If KeyCode = BACK Then Return True
        If InStr(posCursor + 1, text, "-", vbTextCompare) = 0 Then
            If (KeyCode >= ZERO And KeyCode <= NOU) Then
                validarNumeric = True
            End If
        End If
    End Function
    Private Function validarAlfaNumeric() As Boolean
        If KeyCode = BACK Then Return True
        validarAlfaNumeric = False

        If KeyCode >= ZERO And KeyCode <= NOU Then
            validarAlfaNumeric = True
        ElseIf KeyCode >= A_MIN And KeyCode <= Z_MIN Then
            validarAlfaNumeric = True
        ElseIf KeyCode = C_TRENCADA_MIN Or KeyCode = ENYE_MIN Then
            validarAlfaNumeric = True
        ElseIf KeyCode >= A_MAJ And KeyCode <= Z_MAJ Then
            validarAlfaNumeric = True
        ElseIf KeyCode = C_TRENCADA_MAJ Or KeyCode = ENYE_MAJ Then
            validarAlfaNumeric = True
        End If
    End Function
    Private Function validarSigneAlfaNumeric() As Boolean
        If KeyCode = BACK Then Return True
        validarSigneAlfaNumeric = False
        If validarAlfaNumeric() Then
            validarSigneAlfaNumeric = True
        ElseIf KeyCode = GUIO Or KeyCode = GUIO_BAIX Or KeyCode = PUNT Then
            validarSigneAlfaNumeric = True
        End If
    End Function
    Private Function esNEGATIU() As Boolean
        If KeyCode = BACK Then Return True
        esNEGATIU = False
        If posCursor = 0 And InStr(1, text, "-", vbTextCompare) = 0 Then
            If KeyCode = GUIO Then
                esNEGATIU = True
            End If
        End If
    End Function
    Private Function esDecimal() As Boolean
        If KeyCode = BACK Then Return True
        esDecimal = False
        If (KeyCode = COMA Or KeyCode = PUNT) Then
            If posCursor > 0 And InStr(1, text, ",", vbTextCompare) = 0 Then
                esDecimal = True
            End If
        End If
    End Function
    Private Function teclaControl() As Boolean

        If KeyCode = FLETXA_E Or KeyCode = FLETXA_D Or KeyCode = FLETXA_DOWN Or KeyCode = FLETXA_UP Or
           KeyCode = TAB_ Or KeyCode = ESC Or KeyCode = intro Or
           KeyCode = MAJUSC Or KeyCode = INICI Or KeyCode = final Or KeyCode = 0 Then
            teclaControl = True
        Else
            teclaControl = False
        End If
    End Function
    Private Function hiHaEspai() As Boolean
        If maxCaracters > caracters Or maxCaracters = 0 Then
            hiHaEspai = True
        Else
            hiHaEspai = False
        End If
    End Function
    Private Function validNumDecimal() As Boolean
        Dim i As Integer, dreta As Boolean
        If KeyCode = BACK Then Return True
        validNumDecimal = True
        For i = 1 To posCursor
            If Mid(text, i, 1) = "," Then
                dreta = True
                Exit For
            End If
        Next i
        If dreta Then
            If Len(text) - InStr(1, text, ",", vbTextCompare) >= numDecimals Then
                validNumDecimal = False
            End If
        End If
    End Function
    Private Function separadorData() As Boolean
        If KeyCode = BACK Then Return True
        If posCursor = 0 Or posCursor > 6 Then
            separadorData = False
        Else
            If numSeparadorsData() > 1 Then
                separadorData = False
            ElseIf Mid(text, posCursor, 1) = "/" Or Mid(text, posCursor, 1) = "-" _
           Or Mid(text, posCursor + 1, 1) = "/" Or Mid(text, posCursor + 1, 1) = "-" Then
                separadorData = False
            ElseIf GUIO = KeyCode Or BARRA = KeyCode Then
                separadorData = True
            Else
                separadorData = False
            End If
        End If
    End Function
    Private Function numSeparadorsData() As Integer
        Dim i As Integer
        numSeparadorsData = 0
        For i = 1 To text.Length
            If Mid(text, i, 1) = "/" Or Mid(text, i, 1) = "-" Then
                numSeparadorsData = numSeparadorsData + 1
            End If
        Next i
    End Function

End Module
