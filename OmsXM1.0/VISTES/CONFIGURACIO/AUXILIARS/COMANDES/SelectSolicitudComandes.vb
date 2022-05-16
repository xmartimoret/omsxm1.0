Public Class SelectSolicitudComandes
    Inherits LVObjects
    Friend Property solicitudsComanda As List(Of SolicitudComanda)
    Friend Event selectObject(p As SolicitudComanda)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        solicitudsComanda = New List(Of SolicitudComanda)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pFiltre As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.txtFiltrar.Text = pFiltre
        Me.orderColumn = 1
        solicitudsComanda = New List(Of SolicitudComanda)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        'aqui cal obrir la finestra per crear una nova comanda

        'no ens caldrà guardar la comanda o es una nova comanda que te vida per si sola.
        'ens caldrà posar un control de actualització cada vegada que s'activi la pestanya. (per si s'en guarda una de nova com si es valida una d'actualitzada
        ' Return save(DComanda.getComanda(New Comanda))
        Return -1
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As SolicitudComanda
        d = ModelComandaSolicitud.getObject(id, 0)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_SOLICITUD_COMANDA(d.ToString) Then
                Return ModelComandaSolicitud.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelComandaSolicitud.getDataList(ModelComandaSolicitud.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        'AGAFAR LA ID I OBRIR UNA NOVA FINESTRA.
        ' CALDRA COMPROVAR SI JA ESTÀ OBERTA. AMB F56 (NUMERO) 

        ' el mateix que afegir, cal veure com
        Call frmIniComanda.modificarSolicitut(ModelComandaSolicitud.getObject(id, 0), 0)
        'Return save(DComanda.getComanda(ModelComanda.getObject(id)))
        Return id
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        solicitudsComanda = New List(Of SolicitudComanda)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                solicitudsComanda.Add(ModelComandaSolicitud.getObject(i, 0))
            Next
            RaiseEvent selectObject(solicitudsComanda.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As SolicitudComanda) As Integer
        If Not obj Is Nothing Then
            If Not ModelComandaSolicitud.exist(obj, 0) Then
                If Not ModelComandaSolicitud.existCodi(obj, 0) Then
                    RaiseEvent selectObject(obj)
                    Return ModelComandaSolicitud.save(obj)
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

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelComandaSolicitud.getListViewItem(id)
    End Function
    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
    Public Overrides Sub actualitzar(id As List(Of Integer))

    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class


