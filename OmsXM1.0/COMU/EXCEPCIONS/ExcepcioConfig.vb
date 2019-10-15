Public Class ExcepcioConfig : Inherits Exception
    Public Shared ERR_GET_VALUE As String = IDIOMA.getString("excepcioconfig_getvalue")
    Public Shared ERR_SET_VALUE As String = IDIOMA.getString("excepcioconfig_setvalue")
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
