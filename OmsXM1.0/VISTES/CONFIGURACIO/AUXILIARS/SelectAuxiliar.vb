Option Explicit On
Public Class SelectAuxiliar
    Inherits LVObjects
    Friend Property objects As List(Of Object)
    Private auxiliar As ModelAuxiliar
    Public Sub New(taulaAuxiliar As String, pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        auxiliar = New ModelAuxiliar(taulaAuxiliar)
        objects = New List(Of Object)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Select Case auxiliar.taulaActual
            Case DBCONNECT.getTaulaProvincia : Return save(DAuxiliar.getobject(New Provincia))
            Case DBCONNECT.getTaulaPais : Return save(DPais.getPais(New Pais))
            Case DBCONNECT.getTaulaTipusIva : Return save(DTipusIva.gettipusIva(New TipusIva))
            Case DBCONNECT.getTaulaTipusPagament : Return save(DTipusPagament.gettipusPagament(New TipusPagament))
            Case DBCONNECT.getTaulaFamilia : Return save(DAuxiliar.getobject(New Familia))
            Case DBCONNECT.getTaulaUnitat : Return save(DAuxiliar.getobject(New Unitat))
            Case DBCONNECT.getTaulaFabricant : Return save(DAuxiliar.getobject(New Fabricant))
        End Select
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As Object
        d = auxiliar.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_PROVINCIA() Then
                Return auxiliar.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList

        Return auxiliar.getDataList(auxiliar.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Select Case auxiliar.taulaActual
            Case DBCONNECT.getTaulaPais : Return save(DPais.getPais(auxiliar.getObject(id)))
            Case DBCONNECT.getTaulaTipusIva : Return save(DTipusIva.gettipusIva(auxiliar.getObject(id)))
            Case DBCONNECT.getTaulaTipusPagament : Return save(DTipusPagament.gettipusPagament(auxiliar.getObject(id)))
            Case Else : Return save(DAuxiliar.getobject(auxiliar.getObject(id)))
        End Select
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        objects = New List(Of Object)
        If ids.Count >= 0 Then
            For Each i In ids
                objects.Add(auxiliar.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Object) As Integer
        If Not obj Is Nothing Then
            If Not auxiliar.exist(obj) Then
                If Not auxiliar.existCodi(obj) Then
                    Return auxiliar.save(obj)
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
        objects = Nothing
    End Sub
    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function
End Class
