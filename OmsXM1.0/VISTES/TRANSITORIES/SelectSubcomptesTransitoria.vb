Public Class SelectSubcomptesTransitoria
    Inherits LVSubObjects2
    Friend Event selectObject(ByVal s As Subcompte)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDSubgrup As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        MyBase.New(True, False, True, "", "", IDIOMA.getString("cmdTreure"), True)
        Me.idParent = pIDSubgrup
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim subctes As List(Of Subcompte), s As Subcompte
        subctes = DSelectSubcomptes.getSubcomptes(0)
        If subctes IsNot Nothing Then
            For Each s In subctes
                Call modelPlantillaTransitoria.setSubcompte(s)
            Next
            Return True
        End If
        Return False
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim id As Integer
        id = CInt(ids(0))
        If id > -1 Then
            If MISSATGES.CONFIRM_QUIT_SUBCOMPTEGRUP() Then
                Call modelPlantillaTransitoria.removeSubcompte(id)
                Return True
            End If
        End If
        Return False
    End Function


    Public Overrides Function modificar(id As String) As Boolean

        Return False
    End Function


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Overrides Function filtrar(id As String) As DataList
        Return ModelSubcompte.getDataList(modelPlantillaTransitoria.getSubcomptes)
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim s As Subcompte
        If id <> "" Then
            s = modelPlantillaTransitoria.getSubcomptes.Find(Function(x) x.id = id)
            If s IsNot Nothing Then
                RaiseEvent selectObject(s)
                Return True
            End If
        End If
        Return False
    End Function
    Public Overrides Function canviarOrdre(obj1 As String, obj2 As String) As Boolean
        Call modelPlantillaTransitoria.changeOrderSubcomptes(Val(obj1), Val(obj2))
        Return True
    End Function
End Class

