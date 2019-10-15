Public Class ExcepcioSql : Inherits Exception
    Public Shared ERR_CONNECT_DB As String = IDIOMA.getString("errSqlConnectDb")
    Public Shared ERR_REMOVE As String = IDIOMA.getString("excepcioSqlRemove")
    Public Shared ERR_EXIST_CODI_REGISTRE As String = IDIOMA.getString("ERR_EXIST_CODI_REGISTRE")
    Public Shared ERR_EXIST_NOM_REGISTRE As String = IDIOMA.getString("ERR_EXIST_NOM_REGISTRE")
    Public Shared ERR_EXIST_ANY_REGISTRE As String = IDIOMA.getString("ERR_EXIST_ANY_REGISTRE")
    'ERR_EXIST_NOM_REGISTRE
    Public Sub New()
    End Sub
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
