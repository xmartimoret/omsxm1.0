Option Explicit On
Public Class SelectColumnes
    Inherits LVSubObjects1
    Friend Property columnes As List(Of Columna)
    Friend Event selectObject(ByVal cf As Columna)
    Public Sub New(idEmpresa As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = idParent
        Me.orderColumn = pOrdre
        Me.titol = pTitol
        _columnes = New List(Of Columna)
    End Sub
    Private Function save(obj As Columna) As Boolean
        If Not obj Is Nothing Then
            If Not ModelColumna.exist(obj) Then
                Return ModelColumna.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub


    Public Overrides Function seleccionar(id As String) As Boolean
        Dim c As Columna
        If IsNumeric(id) Then
            c = ModelColumna.getObject(CInt(id))
            If Not c Is Nothing Then
                RaiseEvent selectObject(c)
                Return True
            End If
        End If
        Return False
    End Function

    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim c As Columna
        c = DColumna.getColumna(New Columna)
        If c IsNot Nothing Then
            Return save(c)
        End If
        Return False
    End Function

    Public Overrides Function modificar(id As String) As Boolean
        Dim c As Columna
        If IsNumeric(id) Then
            c = DColumna.getColumna(ModelColumna.getObject(CInt(id)))
            If c IsNot Nothing Then Return save(c)
        End If
        Return False
    End Function

    Public Overrides Function eliminar(id As String) As Boolean
        Dim c As Columna
        If IsNumeric(id) Then
            c = ModelColumna.getObject(CInt(id))
            If c IsNot Nothing Then
                If c.columnes.Count > 0 Then
                    Call ERRORS.ERR_REMOVE_COLUMNA_BY_COLUMNA()
                ElseIf c.PROJECTES.Count > 0 Then
                    Call ERRORS.ERR_REMOVE_COLUMNA_BY_PROJECTE()
                Else
                    If MISSATGES.CONFIRM_REMOVE_COLUMNA(c.ToString) Then
                        Return ModelColumna.remove(c)
                    End If
                End If
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(id As String, txt As String) As DataList
        Return ModelColumna.getDataList(ModelColumna.getObjects(txt))
    End Function
End Class

