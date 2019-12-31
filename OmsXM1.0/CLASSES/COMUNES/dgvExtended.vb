Public Class dgvExtended
    Inherits DataGridView
    Public Sub New()

    End Sub

    <System.Security.Permissions.UIPermission(
            System.Security.Permissions.SecurityAction.LinkDemand,
            Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)>
    Protected Overrides Function ProcessDialogKey(
            ByVal keyData As Keys) As Boolean

        ' Extract the key code from the key value.   
        Dim key As Keys = keyData And Keys.KeyCode

        ' Handle the ENTER key as if it were a RIGHT ARROW key.   
        If key = Keys.Enter Then
            Return Me.ProcessTabKey(keyData)
        End If

        Return MyBase.ProcessDialogKey(keyData)

    End Function

    <System.Security.Permissions.SecurityPermission(
            System.Security.Permissions.SecurityAction.LinkDemand, Flags:=
            System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)>
    Protected Overrides Function ProcessDataGridViewKey(
            ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean

        ' Handle the ENTER key as if it were a RIGHT ARROW key.   
        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessTabKey(e.KeyData)

        End If

        Return MyBase.ProcessDataGridViewKey(e)

    End Function

End Class
