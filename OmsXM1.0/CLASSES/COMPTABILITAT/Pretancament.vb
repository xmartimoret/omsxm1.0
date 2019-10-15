Option Explicit On
Public Class Pretancament
    Public Property idCentre As Integer
    Public Property anyo As Integer
    Public Property mes As Integer
    Public Property importsDetallMesAnterior As List(Of ImportMesSubgrup)
    Public Property transitories As List(Of Transitoria)
    Public Property assentaments As List(Of Assentament)
    Public Sub New()
        _importsDetallMesAnterior = New List(Of ImportMesSubgrup)
        _transitories = New List(Of Transitoria)
        _assentaments = New List(Of Assentament)
    End Sub
    Public ReadOnly Property valorAssentaments(idSubgrup As Integer) As Double
        Get
            Dim a As Assentament, valor As EnterLlarg
            valor = New EnterLlarg
            For Each a In _assentaments
                If ModelSubcomptesGrup.exist(ModelSubcompte.getId(a.subcompteAssentament), idSubgrup) Then
                    valor.valorLong = a.saldo
                End If
            Next a
            valorAssentaments = valor.valordecimal
            a = Nothing
            valor = Nothing
        End Get
    End Property

    Public ReadOnly Property valorTransitories(idSubgrup As Integer) As Double
        Get
            Dim t As Transitoria, valor As EnterLlarg
            valor = New EnterLlarg
            For Each t In _transitories
                If ModelSubcomptesGrup.exist(t.idSubcompte, idSubgrup) Then
                    valor.valordecimal = t.valorAS
                End If
            Next t
            valorTransitories = valor.valordecimal
            t = Nothing
        End Get
    End Property
    Public ReadOnly Property valorImportDetall(idSubgrup) As Double
        Get
            Dim ims As ImportMesSubgrup, valor As EnterLlarg
            valor = New EnterLlarg
            For Each ims In _importsDetallMesAnterior
                If idSubgrup = ims.idSubgrup Then
                    valor.valordecimal = ims.valor
                End If
            Next ims
            valorImportDetall = valor.valordecimal
            ims = Nothing
        End Get
    End Property


    Public ReadOnly Property valorPretancament(idSubgrup As Integer) As Double
        Get
            valorPretancament = valorImportDetall(idSubgrup) + (Math.Round(valorTransitories(idSubgrup) * -1, 2)) + Math.Round(valorAssentaments(idSubgrup) * -1, 2)
        End Get
    End Property
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _importsDetallMesAnterior = Nothing
        _transitories = Nothing
        _assentaments = Nothing
    End Sub
End Class
