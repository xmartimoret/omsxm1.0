Option Explicit On
Public Class Departament
    Inherits Base
    Private _assentaments As List(Of Assentament)
    Public Property projectes As List(Of ProjecteDepartament)
    Public Property idEmpresa As Integer
    Public Sub New()
        _projectes = New List(Of ProjecteDepartament)
        _assentaments = New List(Of Assentament)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pOrdre As String)
        _projectes = New List(Of ProjecteDepartament)
        _assentaments = New List(Of Assentament)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.ordre = pOrdre
    End Sub
    Public Property assentaments() As List(Of Assentament)
        Get
            Return _assentaments
        End Get
        Set(value As List(Of Assentament))
            _assentaments = value
            Call setAssentaments()
        End Set
    End Property
    Private Sub setAssentaments()
        Dim a As Assentament
        For Each a In _assentaments
            Call setAssentament(a)
        Next a
        a = Nothing
    End Sub
    Private Sub setAssentament(a As Assentament)
        Dim pD As ProjecteDepartament, existeix As Boolean, p As Projecte
        existeix = False
        For Each pD In _projectes
            If StrComp(pD.codiProjecte, a.departamentAssentament & a.clave, vbTextCompare) = 0 Then
                Call pD.setAssentament(a)
                existeix = True
                Exit For
            End If
        Next pD
        If Not existeix Then
            p = ModelProjecte.getObject(a.departamentAssentament & a.clave, _idEmpresa)
            pD = New ProjecteDepartament
            If TypeName(p) = "Projecte" Then
                pD.idDepartament = Me.id
                pD.idProjecte = p.id
                pD.nomProjecte = p.nom
                pD.codiProjecte = p.codi
                _projectes.Add(pD)
            Else
                pD.idDepartament = Me.id
                pD.codiProjecte = a.departamentAssentament & a.clave
                pD.nomProjecte = IDIOMA.getString("departamentProjecteNoDonatAlta")
                _projectes.Add(pD)
            End If
            Call pD.setAssentament(a)
        End If
        pD = Nothing
        p = Nothing
    End Sub
    Public ReadOnly Property deure() As Double
        Get
            Dim e As New EnterLlarg, a As Assentament
            For Each a In _assentaments
                e.valorLong = a.deure
            Next a
            deure = e.valordecimal
            e = Nothing
        End Get
    End Property
    Public ReadOnly Property haver() As Double
        Get
            Dim e As New EnterLlarg, a As Assentament
            For Each a In _assentaments
                e.valorLong = a.haver
            Next a
            haver = e.valordecimal
            e = Nothing
        End Get
    End Property

    Public ReadOnly Property saldo() As Double
        Get
            Dim e As New EnterLlarg, a As Assentament
            For Each a In _assentaments
                e.valorLong = a.saldo
            Next a
            saldo = e.valordecimal
            e = Nothing
        End Get
    End Property
    Public ReadOnly Property copy As Departament
        Get
            copy = New Departament
            copy.id = Me.id
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.idEmpresa = _idEmpresa
            copy.ordre = Me.ordre
            copy.assentaments = _assentaments
            copy.projectes = _projectes
        End Get
    End Property
    Protected Overrides Sub Finalize()
        _projectes = Nothing
        _assentaments = Nothing
        MyBase.Finalize()
    End Sub
End Class
