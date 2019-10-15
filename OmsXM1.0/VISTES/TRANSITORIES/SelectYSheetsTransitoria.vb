Public Class SelectYSheetsTransitoria
    Inherits LVSubObjects2
    Friend Event selectObject(ByVal s As YSheet)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDSubgrup As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        MyBase.New(True, False, True, "", "", IDIOMA.getString("cmdTreure"), True)
        Me.idParent = pIDSubgrup
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim ysheets As List(Of YSheet), y As YSheet, result As Boolean
        ysheets = dSelectYSheets.getSubcomptes
        result = False
        For Each y In ysheets
            Call modelPlantillaTransitoria.setYSheets(y)
            result = True
        Next
        Return result
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim id As Integer
        id = CInt(ids(0))
        If id > -1 Then
            If MISSATGES.CONFIRM_QUIT_SUBCOMPTEGRUP() Then
                Call modelPlantillaTransitoria.removeYSheets(id)
                Return True
            End If
        End If
        Return False
    End Function


    Public Overrides Function modificar(id As String) As Boolean

        Return False
    End Function

    'Private Function save(obj As Seccio) As Boolean
    '    Dim saved As Boolean
    '    If Not obj Is Nothing Then
    '        If Not ModelSeccio.exist(obj) Then
    '            saved = ModelSeccio.save(obj)
    '            If saved Then RaiseEvent selectObject(obj)
    '        Else
    '            Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
    '        End If
    '    End If
    '    Return saved
    'End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Overrides Function filtrar(id As String) As DataList
        Return ModelYSheet.getDataList(modelPlantillaTransitoria.getySheets)
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim y As YSheet
        y = modelPlantillaTransitoria.getySheets.Find(Function(x) x.id = id)
        If y IsNot Nothing Then
            RaiseEvent selectObject(y)
            Return True
        End If
        Return False
    End Function
    Public Overrides Function canviarOrdre(obj1 As String, obj2 As String) As Boolean
        Call modelPlantillaTransitoria.changeOrderYSheets(obj1, obj2)
        Return True
    End Function
End Class
