Option Explicit On
Imports System.IO
Imports System.Text
Module FILE_IN_OUT
    Private Const SEPARATOR As String = "#@#@"
    Public Sub setFile(ruta As String, dades As List(Of List(Of String)))
        Dim c As String, str As New StringBuilder, fila As List(Of String)
        Using fitxer As New IO.StreamWriter(ruta)
            For Each fila In dades
                str = New StringBuilder
                For Each c In fila
                    str.Append(c).Append(SEPARATOR)
                Next
                fitxer.WriteLine(str.ToString)

            Next
        End Using
        str = Nothing
    End Sub
    Public Sub setInClipBoard(dades As List(Of List(Of String)))
        Dim c As String, str As New StringBuilder, fila As List(Of String)
        str = New StringBuilder
        For Each fila In dades
            For Each c In fila
                str.Append(c).Append(SEPARATOR)
            Next
        Next
        My.Computer.Clipboard.SetText(str.ToString)
        str = Nothing
    End Sub
    Public Function getFile(ruta As String) As List(Of List(Of String))
        Dim dades As List(Of List(Of String)), fila As List(Of String), filaactual() As String
        dades = New List(Of List(Of String))
        If CONFIG.fileExist(ruta) Then
            Using fitxer As New Microsoft.VisualBasic.FileIO.TextFieldParser(ruta)
                fitxer.TextFieldType = FileIO.FieldType.Delimited
                fitxer.SetDelimiters(SEPARATOR)
                While Not fitxer.EndOfData

                    filaactual = fitxer.ReadFields
                        fila = New List(Of String)
                        For i = LBound(filaactual) To UBound(filaactual)
                            fila.Add(filaactual(i))
                        Next
                        dades.Add(fila)

                End While

            End Using
        End If
        Return dades
    End Function


End Module
