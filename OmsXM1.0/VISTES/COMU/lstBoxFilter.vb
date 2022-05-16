Public Class lstBoxFilter
    Private objects() As Object
    Public Sub New(pTitol As String, pObjects() As Object)
        InitializeComponent()
        Me.lblTitol.Text = pTitol
        objects = pObjects
        Call setData()
    End Sub
    Private Sub setData()
        Call filtrar(txtFiltrar.Text)
    End Sub
    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged
        Call setData()
    End Sub
    Private Sub filtrar(p As String)
        Dim o As Object
        lstData.Items.Clear()
        For Each o In objects
            If InStr(o.ToString, p, CompareMethod.Text) > 0 Then
                lstData.Items.Add(o)
            End If
        Next
        lstData.Sorted = True
    End Sub
    Public Function getSelectedObjects() As List(Of Object)
        Dim o As Object
        getSelectedObjects = New List(Of Object)
        For Each o In lstData.SelectedItems
            getSelectedObjects.Add(o)
        Next
        o = Nothing
    End Function

    Private Sub lstData_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
