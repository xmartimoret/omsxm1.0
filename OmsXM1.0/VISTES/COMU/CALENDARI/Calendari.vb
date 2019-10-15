Option Explicit On
Imports System.ComponentModel
Imports System.Windows.Forms
Public Class Calendari
    Private Enum lang
        CAT = 1
        es
        en
        de
    End Enum
    Private idiomaActual As lang
    Private dataAct As Date
    Private limitInferior As Date
    Private limitSuperior As Date
    Private d As Integer
    Private m As Integer
    Private a As Integer
    Private isUnload As Boolean
    Public Function getDate(Optional titol As String = "", Optional idiomaCalendari As String = "CAT") As Date
        dataAct = Now
        m = Month(dataAct)
        a = Year(dataAct)
        Call setIdioma(idiomaCalendari)
        If titol = "" Then
            If idiomaActual = lang.CAT Then
                Me.Text = "CALENDARI"
            ElseIf idiomaActual = lang.de Then
                Me.Text = "KALENDER"
            ElseIf idiomaActual = lang.en Then
                Me.Text = "CALENDAR"
            ElseIf idiomaActual = lang.es Then
                Me.Text = "CALENDARIO"
            End If
        Else
            Me.Text = titol
        End If
        Me.ShowDialog()
        If Not isUnload Then
            getDate = dataAct
        Else
            getDate = Nothing
        End If
        Me.Dispose()
    End Function
    Public Function getDate(dataActual As Date, Optional titol As String = "", Optional idiomaCalendari As String = "CAT") As Date
        If dataActual < DateSerial(1900, 1, 1) Then
            dataAct = Now
        Else
            dataAct = dataActual
        End If
        m = Month(dataAct)
        a = Year(dataAct)
        Call setIdioma(idiomaCalendari)
        If titol = "" Then
            If idiomaActual = lang.CAT Then
                Me.Text = "CALENDARI"
            ElseIf idiomaActual = lang.de Then
                Me.Text = "KALENDER"
            ElseIf idiomaActual = lang.en Then
                Me.Text = "CALENDAR"
            ElseIf idiomaActual = lang.es Then
                Me.Text = "CALENDARIO"
            End If
        Else
            Me.Text = titol
        End If
        Me.ShowDialog()
        If Not isUnload Then
            getDate = dataAct
        Else
            getDate = Nothing
        End If
        Me.Dispose()
    End Function
    Public Function getDate(dataActual As Date, dataLimit As Date, esLimitInferior As Boolean, Optional titol As String = "", Optional idiomaCalendari As String = "CAT") As Date
        If dataActual < DateSerial(1900, 1, 1) Then
            dataAct = Now
        Else
            dataAct = dataActual
        End If
        m = Month(dataAct)
        a = Year(dataAct)
        If esLimitInferior Then
            limitInferior = dataLimit
        Else
            limitSuperior = dataLimit
        End If
        Call setIdioma(idiomaCalendari)
        If titol = "" Then
            If idiomaActual = lang.CAT Then
                Me.Text = "CALENDARI"
            ElseIf idiomaActual = lang.de Then
                Me.Text = "KALENDER"
            ElseIf idiomaActual = lang.en Then
                Me.Text = "CALENDAR"
            ElseIf idiomaActual = lang.es Then
                Me.Text = "CALENDARIO"
            End If
        Else
            Me.Text = titol
        End If
        Me.ShowDialog()
        If Not isUnload Then
            getDate = dataAct
        Else
            getDate = Nothing
        End If
        Me.Dispose()
    End Function
    Public Function getDate(dataActual As Date, dataInferior As Date, dataSuperior As Date, Optional titol As String = "", Optional idiomaCalendari As String = "CAT") As Date
        If dataActual < DateSerial(1900, 1, 1) Then
            dataAct = Now
        Else
            dataAct = dataActual
        End If

        m = Month(dataAct)
        a = Year(dataAct)
        limitInferior = dataInferior
        limitSuperior = dataSuperior
        Call setIdioma(idiomaCalendari)
        If titol = "" Then
            If idiomaActual = lang.CAT Then
                Me.Text = "CALENDARI"
            ElseIf idiomaActual = lang.de Then
                Me.Text = "KALENDER"
            ElseIf idiomaActual = lang.en Then
                Me.Text = "CALENDAR"
            ElseIf idiomaActual = lang.es Then
                Me.Text = "CALENDARIO"
            End If
        Else
            Me.Text = titol
        End If
        Me.ShowDialog()
        If Not isUnload Then
            getDate = dataAct
        Else
            getDate = Nothing
        End If
        Me.Dispose()
    End Function
    Private Sub setCalendari()
        Dim i As Integer, temp As Date
        Dim ini As Integer
        temp = DateSerial(a, m, 1)
        ini = diaSetmana(temp)
        lblMes.Text = CONFIG.mesNom(m)
        lblAny.Text = a
        For i = 1 To 38
            If i < ini Then
                Me.Controls("lbl" & i).Visible = False
            ElseIf Month(CDate(temp)) <> m Then
                Me.Controls("lbl" & i).Visible = False
            Else
                Me.Controls("lbl" & i).Visible = True
                If esDissabte(temp) Then
                    Me.Controls("lbl" & i).BackColor = Color.Gray
                    Me.Controls("lbl" & i).ForeColor = Color.Black
                ElseIf esDiumenge(temp) Then
                    Me.Controls("lbl" & i).BackColor = Color.Red
                    Me.Controls("lbl" & i).ForeColor = Color.White
                ElseIf esFestiu(i + 1 - ini) Then
                    Me.Controls("lbl" & i).BackColor = Color.Red
                    Me.Controls("lbl" & i).ForeColor = Color.White
                Else
                    Me.Controls("lbl" & i).BackColor = Color.White
                    Me.Controls("lbl" & i).ForeColor = Color.Black
                End If

                Me.Controls("lbl" & i).Text = i + 1 - ini

                If Not limitData(temp) Then
                    Me.Controls("lbl" & i).Enabled = False
                Else
                    Me.Controls("lbl" & i).Enabled = True
                End If
                temp = DateAdd(DateInterval.Day, 1, temp)
            End If
        Next i
    End Sub


    Private Sub lblDay_Click(sender As Object, e As EventArgs) Handles lbl1.Click, lbl2.Click, lbl3.Click, lbl4.Click, lbl5.Click, lbl6.Click, lbl7.Click, lbl8.Click, lbl9.Click, lbl10.Click,
                                                                       lbl11.Click, lbl12.Click, lbl13.Click, lbl14.Click, lbl15.Click, lbl16.Click, lbl17.Click, lbl18.Click, lbl19.Click, lbl20.Click,
                                                                       lbl21.Click, lbl22.Click, lbl23.Click, lbl24.Click, lbl25.Click, lbl26.Click, lbl27.Click, lbl28.Click, lbl29.Click, lbl30.Click,
                                                                       lbl31.Click, lbl32.Click, lbl33.Click, lbl34.Click, lbl35.Click, lbl36.Click, lbl37.Click, lbl38.Click

        dataAct = DateSerial(a, m, sender.text)
        isUnload = False
        Me.Hide()
    End Sub
    Private Sub txtDia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDia.KeyDown
        If e.Shift > 0 Then
            e.SuppressKeyPress = True
        ElseIf (e.KeyCode = 8 Or e.KeyCode = 9 Or e.KeyCode = 27 Or e.KeyCode = 37 Or e.KeyCode = 46) Then

        ElseIf Not IsDate(txtDia.Text & getDiaByKeycode(e.KeyCode) & "-" & m & "-" & a) Then
            e.SuppressKeyPress = True
        ElseIf ((e.KeyCode >= 48 And e.KeyCode <= 57) Or (e.KeyCode >= 96 And e.KeyCode <= 105)) Then
        ElseIf e.KeyCode = 13 Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtDia_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDia.KeyUp
        If e.KeyCode = 13 Then
            If IsDate(txtDia.Text & "/" & m & "/" & a) Then
                If limitData(txtDia.Text & "/" & m & "/" & a) Then
                    dataAct = DateSerial(a, m, txtDia.Text)
                    isUnload = False
                    Me.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub Calendari_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setCalendari()
        Call setTitolsDia()
        isUnload = False
        txtDia.Select()
    End Sub




    '------------------------------
    ' FUNCIONS AUXILIARS
    '------------------------------

    'SUB: setTitolsDia.
    '   Presenta els dies de la setmana segons l'idiomaActual.
    '   Hi ha quatre idomes disponibles: Anglès, Aleman, Castellà i Català
    Private Sub setTitolsDia()
        Dim titolsDia() As String, i As Integer
        Select Case idiomaActual
            Case lang.de
                titolsDia = {"Mon", "Die", "Mit", "Don", "Fre", "Sam", "Son"}
            Case lang.en
                titolsDia = {"Sun", "Mon", "Tue", "Wed", "Thu", "Wed", "Sat"}
            Case lang.es
                titolsDia = {"Lu", "Ma", "Mi", "Ju", "Vi", "Sa", "Do"}
            Case Else
                titolsDia = {"Dl", "Dm", "Dm", "Dj", "Dv", "Ds", "Dg"}
        End Select
        For i = 1 To 7
            Me.Controls("lblDia" & i).Text = titolsDia(i - 1)
        Next i
    End Sub
    Private Sub setIdioma(id As String)
        If UCase(Strings.Left(id, 2)) = "ES" Then
            idiomaActual = lang.es
        ElseIf UCase(Strings.Left(id, 2)) = "EN" Or UCase(Strings.Left(id, 2)) = "IN" Then
            idiomaActual = lang.en
        ElseIf UCase(Strings.Left(id, 1)) = "D" Or UCase(Strings.Left(id, 2)) = "AL" Then
            idiomaActual = lang.de
        Else
            idiomaActual = lang.CAT
        End If
    End Sub
    ' FUNCTION: diaSetmana
    '   Cerca el dia de la setmana (número) de la data que rep com a paràmetre
    '   Descrimina per idiomes
    ' PARAMETER: data_ (Date) , data a la qual cerca el dia.
    ' RETURN: (Integer). Número del dia de la setmama
    Private Function diaSetmana(data_ As Date) As Integer
        If idiomaActual = lang.en Then
            diaSetmana = Weekday(data_)
        Else
            diaSetmana = Weekday(data_, vbMonday)
        End If
    End Function

    ' FUNCTION: esDissabte
    '   Comprova si la data que rep com a paràmetre es dissabte.
    ' PARAMETER: data_ (Date), data a comprovar
    ' RETURN (Boolean), cert si és dissabte, fals en cas contrari
    Private Function esDissabte(data_ As Date) As Boolean
        If Weekday(data_) = 7 Then
            esDissabte = True
        Else
            esDissabte = False
        End If
    End Function

    ' FUNCTION: esDiumenge
    '   Comprova si la data que rep com a paràmetre es diumenge.
    ' PARAMETER: data_ (Date), data a comprovar
    ' RETURN (Boolean), cert si és diumenge, fals en cas contrari
    Private Function esDiumenge(data_ As Date) As Boolean
        If Weekday(data_) = 1 Then
            esDiumenge = True
        Else
            esDiumenge = False
        End If
    End Function

    ' FUNCTION: limitData
    '   Comprova si la data que rep està dintre els límits marcats
    ' PARAMETER: data_ (Date), data a comprovar
    ' RETURN (Boolean), cert si està dintre els límits, fals en cas contrari
    Private Function limitData(data_ As Date) As Boolean
        limitData = True
        If limitInferior > data_ Then
            limitData = False
        ElseIf limitSuperior < data_ And limitSuperior > DateSerial(1900, 1, 1) Then
            limitData = False
        End If
    End Function
    Private Function getNomMes(mes As Integer) As String
        Dim mesos() As String
        Select Case idiomaActual

            Case lang.de
                mesos = {"Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"}
            Case lang.en
                mesos = {"January", "February", "March", "April", "May", "June", "July", "August", "Setember", "Octuber", "November", "Decembrer"}
            Case lang.es
                mesos = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Deciembre"}
            Case Else
                mesos = {"Gener", "Febrer", "Març", "Abril", "Maig", "Juny", "Juliol", "Agost", "Setembre", "Octubre", "Novembre", "Desembre"}
        End Select
        getNomMes = mesos(mes - 1)
    End Function
    Private Function esFestiu(d As Integer) As Boolean
        esFestiu = False
        If m = 1 And (d = 1 Or d = 6) Then
            esFestiu = True
        ElseIf m = 5 And d = 1 Then
            esFestiu = True
        ElseIf m = 8 And d = 15 Then
            esFestiu = True
        ElseIf m = 9 And d = 11 And idiomaActual = lang.CAT Then
            esFestiu = True
        ElseIf m = 10 And d = 12 Then
            esFestiu = True
        ElseIf m = 11 And d = 1 Then
            esFestiu = True
        ElseIf m = 12 And (d = 6 Or d = 8) Then
            esFestiu = True
        ElseIf m = 12 And d = 24 And idiomaActual = lang.en Then
            esFestiu = True
        ElseIf m = 12 And d = 25 Then
            esFestiu = True
        ElseIf m = 12 And d = 26 And idiomaActual = lang.CAT Then
            esFestiu = True
        End If
    End Function
    Private Function getDiaByKeycode(KeyCode As Keys) As Integer
        Dim temp As Integer
        If KeyCode >= 48 And KeyCode <= 57 Then
            temp = 48
        ElseIf KeyCode >= 96 And KeyCode <= 105 Then
            temp = 96
        End If
        If temp > 0 Then
            getDiaByKeycode = KeyCode - temp
        Else
            getDiaByKeycode = 50
        End If
    End Function



    Private Sub cmdAnyAnterior_Click(sender As Object, e As EventArgs) Handles cmdAnyAnterior.Click
        a = a - 1
        Call setCalendari()
    End Sub

    Private Sub cmdMesAnterior_Click(sender As Object, e As EventArgs) Handles cmdMesAnterior.Click
        If m > 1 Then
            m = m - 1
        Else
            m = 12
            a = a - 1
        End If
        Call setCalendari()
    End Sub

    Private Sub cmdMesSeguent_Click(sender As Object, e As EventArgs) Handles cmdMesSeguent.Click
        If m < 12 Then
            m = m + 1
        Else
            m = 1
            a = a + 1
        End If
        Call setCalendari()
    End Sub

    Private Sub cmdAnySeguent_Click(sender As Object, e As EventArgs) Handles cmdAnySeguent.Click
        a = a + 1
        Call setCalendari()
    End Sub

    Private Sub Calendari_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        isUnload = True
    End Sub
End Class
