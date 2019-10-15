Imports System.Windows.Forms
Imports System.IO
Public Class dLogs
    Private logActual As Log
    Private entradaActual As EntradaLog
    Public Sub setLog(pLog As Log)
        logActual = pLog
        Me.Text = pLog.titol
        Call setAvisos()
        Call setErrors()
        Call setLanguage()
        Call validateControls()
        Me.ShowDialog()
    End Sub
    Private Sub setLanguage()
        Me.cmdImprimir.Text = IDIOMA.getString("cmdImprimir")
        Me.cmdTancar.Text = IDIOMA.getString("cmdTancar")
        Me.cmdVeure.Text = IDIOMA.getString("cmdMostrar")
    End Sub
    Private Sub validateControls()
        If entradaActual Is Nothing Then
            Me.cmdVeure.Enabled = False
        Else
            Me.cmdVeure.Enabled = True
        End If
    End Sub
    Private Sub setAvisos()
        Dim sLogs As SelectLog
        sLogs = New SelectLog(logActual, IDIOMA.getString("avisos"), CONFIG.tipusEntradaLog.AVIS_log)
        sLogs.Dock = DockStyle.Fill
        Me.PanelAvisos.Controls.Clear()
        Me.PanelAvisos.Controls.Add(sLogs)
        AddHandler sLogs.selectObject, AddressOf setEntradaLog
        AddHandler sLogs.ShowObject, AddressOf mostrarLog
        sLogs.Show()
    End Sub
    Private Sub setEntradaLog(e As EntradaLog)
        entradaActual = e
        Call validateControls()
    End Sub
    Private Sub setErrors()
        Dim sLogs As SelectLog
        sLogs = New SelectLog(logActual, IDIOMA.getString("errors"), CONFIG.tipusEntradaLog.ERR_LOG)
        sLogs.Dock = DockStyle.Fill
        sLogs.lstData.ForeColor = Color.Red
        Me.PanelErrors.Controls.Clear()
        Me.PanelErrors.Controls.Add(sLogs)
        AddHandler sLogs.selectObject, AddressOf setEntradaLog
        AddHandler sLogs.ShowObject, AddressOf mostrarLog
        sLogs.Show()
    End Sub
    Private Sub mostrarLog(l As EntradaLog)
        Call dLog.setMostrar(l)
    End Sub
    Private Sub dLogs_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        logActual = Nothing
        entradaActual = Nothing
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim ruta As String, ent As EntradaLog, o As Integer
        ruta = CONFIG.setFolder(CONFIG.getdirectoriLogAplicacio)
        ruta = ruta & logActual.titol & Format(Now(), "yy") & Format(Now(), "MM") & Format(Now(), "dd") & Format(Now(), "hh") & Format(Now(), "nn") & ".txt"
        Using fitxer As StreamWriter = New StreamWriter(ruta)
            If ModelLog.getNumAvisos(logActual.entrades) > 0 Then
                fitxer.WriteLine(IDIOMA.getString("infoAvisos") & ": " & logActual.titol)
                fitxer.WriteLine(IDIOMA.getString("data") & ": " & Format(Now(), "dd-MM-yy hh:mm"))
                fitxer.WriteLine("**************************************************************")
                For Each ent In logActual.entrades
                    If ent.codi = CONFIG.tipusEntradaLog.AVIS_log Then fitxer.WriteLine(ent.ToString)
                Next ent
                fitxer.WriteLine("-------------------------------------------------------")
            End If
            If ModelLog.getNumErrors(logActual.entrades) > 0 Then
                fitxer.WriteLine(IDIOMA.getString("infoErrors") & ": " & logActual.titol)
                fitxer.WriteLine(IDIOMA.getString("data") & ": " & Format(Now(), "dd-MM-yy hhh:mm"))
                fitxer.WriteLine("************************************************************")
                For Each ent In logActual.entrades
                    If ent.codi = CONFIG.tipusEntradaLog.ERR_LOG Then fitxer.WriteLine(ent.ToString)
                Next ent
                fitxer.WriteLine("-------------------------------------------------------")
            End If
        End Using
        o = Shell("C:\WINDOWS\notepad.exe" & " " & ruta, vbMaximizedFocus)
        Call Interaction.AppActivate(o)
    End Sub

    Private Sub cmdVeure_Click(sender As Object, e As EventArgs) Handles cmdVeure.Click
        Call mostrarLog(entradaActual)
    End Sub

    Private Sub cmdTancar_Click(sender As Object, e As EventArgs) Handles cmdTancar.Click
        Me.Close()
    End Sub

    Private Sub dLogs_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        logActual = Nothing
        entradaActual = Nothing
    End Sub

End Class
