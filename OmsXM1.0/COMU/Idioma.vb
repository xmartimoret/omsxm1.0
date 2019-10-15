Option Explicit On
Imports System.Globalization
Imports System.Resources
Imports System.Threading
Module IDIOMA
    Private rsActual As ResourceSet
    Private Sub setValues()
        Dim a As Reflection.Assembly, rm As ResourceManager
        rsActual = Nothing
        rm = New ResourceManager("OmsXM.lang", GetType(IDIOMA).Assembly)
        rsActual = rm.GetResourceSet(CultureInfo.CurrentCulture, True, True)
        a = Nothing
        rm = Nothing
    End Sub
    Public Function getString(key As String)
        If rsActual Is Nothing Then Call setValues()
        Try
            Return rsActual.GetString(key)
        Catch ex As Exception
            Return "-"
        End Try

    End Function
    Public Sub setIdioma(keyIdioma As String)
        Thread.CurrentThread.CurrentCulture = New CultureInfo(keyIdioma)
        Call setValues()
    End Sub
    Public Function getIdioma() As String
        Return CultureInfo.CurrentCulture.ToString
    End Function
    Public Sub resetValues()
        rsActual = Nothing
    End Sub
End Module


