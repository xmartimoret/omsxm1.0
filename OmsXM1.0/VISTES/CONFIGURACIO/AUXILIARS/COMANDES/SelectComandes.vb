Public Class SelectComandes
    Inherits LVObjectsCopiar
    Friend Property comandaActual As Comanda
    Friend Property comandes As List(Of Comanda)
    Friend Event selectObject(p As Comanda)

    Public Sub New(pTitol As String, pComandes As List(Of Comanda))
        Me.accio = 0
        Me.multiselect = False
        Me.isForm = False
        Me.titol = pTitol
        Me.orderColumn = 1
        comandes = pComandes
    End Sub
    Public Overrides Function eliminar() As Boolean
        If comandaActual IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_COMANDA(comandaActual.ToString) Then
                Return ModelComanda.remove(comandaActual)
            End If
        End If
        Return False
    End Function
    Public Overrides Function filtrar(txt As String) As DataList
        Dim a As Comanda, altres As String = "", objects As List(Of Comanda)
        objects = New List(Of Comanda)
        For Each a In comandes
            If a.proveidor IsNot Nothing Then altres = a.proveidor.nom
            If a.projecte IsNot Nothing Then altres = altres & a.projecte.nom
            If a.empresa IsNot Nothing Then altres = altres & a.empresa.nom
            If a.codi IsNot Nothing Then altres = altres & a.codi
            altres = altres & a.data
            altres = altres & a.total
            altres = altres & a.base
            If altres <> "" Then
                If a.isFilter(txt, altres) Then
                    objects.Add(a)
                End If
            Else
                If a.isFilter(txt) Then
                    objects.Add(a)
                End If
            End If
        Next
        filtrar = ModelComanda.getDataList(objects)
        objects = Nothing
    End Function


    Public Overrides Function seleccionar(id As Integer, estat As Integer) As Boolean
        If id >= 0 Then
            If estat = 2 Then
                comandaActual = ModelComanda.getObject(id)
            Else
                comandaActual = ModelComandaEnEdicio.getObject(id)
            End If
            Return True
            End If
            Return False
    End Function
    Private Function save(obj As Comanda) As Integer
        Return -1
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        comandes = Nothing
    End Sub

    Public Overrides Function copiar() As Integer
        Dim c As Comanda, codiC As CodiComanda
        If comandaActual IsNot Nothing Then
            If MISSATGES.CONFIRM_COPY_COMANDA = True Then
                c = comandaActual.copy
                c.id = -1
                c.estat = 0
                c.serie = Year(Now)
                c.data = Now
                codiC = ModelCodiComanda.getObject(c.serie, c.empresa.id)
                If Not IsNothing(codiC) Then
                    c.codi = codiC.codi
                    codiC.codi = codiC.codi + 1
                Else
                    codiC = New CodiComanda(-1, c.serie, 1, c.empresa.id, "")
                    c.codi = 1
                    codiC.codi = 2
                End If
                Dim p As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("copiantComanda"), c.ToString)
                c.id = ModelComandaEnEdicio.save(c)
                If c.id > 0 Then
                    Call ModelCodiComanda.save(codiC)
                    Call frmIniComanda.modificarComanda(c)
                    frmIniComanda.updatecomanda()
                End If
                p.tancar()
                Return c.id
            End If
        End If
        Return Nothing
    End Function

    Public Overrides Function mostrar() As Boolean
        If comandaActual IsNot Nothing Then
            RaiseEvent selectObject(comandaActual)
            Return True
        End If
        Return False
    End Function

    Public Overrides Sub imprimir(pdf As Boolean, dades As List(Of List(Of String)), filtre As String)

        Call ModulInfoAuxiliar.infoComandes(dades, pdf, IDIOMA.getString("comandes"), filtre)
    End Sub
End Class
