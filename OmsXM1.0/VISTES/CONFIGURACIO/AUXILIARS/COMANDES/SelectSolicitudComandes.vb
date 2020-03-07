Public Class SelectSolicitudComandes
    Inherits LVObjects
    Friend Property solicitudsComanda As List(Of Comanda)
    Friend Event selectObject(p As Comanda)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        solicitudsComanda = New List(Of Comanda)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pFiltre As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.txtFiltrar.Text = pFiltre
        Me.orderColumn = 1
        solicitudsComanda = New List(Of Comanda)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        'aqui cal obrir la finestra per crear una nova comanda

        'no ens caldrà guardar la comanda o es una nova comanda que te vida per si sola.
        'ens caldrà posar un control de actualització cada vegada que s'activi la pestanya. (per si s'en guarda una de nova com si es valida una d'actualitzada
        ' Return save(DComanda.getComanda(New Comanda))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As Comanda
        d = ModelComandaSolicitud.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_SOLICITUD_COMANDA(d.ToString) Then
                Return ModelComandaSolicitud.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelComanda.getDataList(ModelComandaSolicitud.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        'AGAFAR LA ID I OBRIR UNA NOVA FINESTRA.
        ' CALDRA COMPROVAR SI JA ESTÀ OBERTA. AMB F56 (NUMERO) 

        ' el mateix que afegir, cal veure com
        Call frmIniComanda.modificarSolicitudComanda(ModelComandaSolicitud.getObject(id))
        'Return save(DComanda.getComanda(ModelComanda.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        solicitudsComanda = New List(Of Comanda)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                solicitudsComanda.Add(ModelComandaSolicitud.getObject(i))
            Next
            RaiseEvent selectObject(solicitudsComanda.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Comanda) As Integer
        If Not obj Is Nothing Then
            If Not ModelComanda.exist(obj) Then
                If Not ModelComanda.existCodi(obj) Then
                    RaiseEvent selectObject(obj)
                    Return ModelComanda.save(obj)
                Else
                    Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
                End If
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        solicitudsComanda = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function
End Class


