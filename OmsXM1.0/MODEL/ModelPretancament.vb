Option Explicit On
Module ModelPretancament
    Public Function getObject(e As Empresa, cPlus As Contaplus, idCentre As Integer, anyo As Integer, mes As Integer) As Pretancament
        Dim c As Centre
        c = ModelCentre.getObject(idCentre)
        getObject = Nothing
        If c IsNot Nothing Then
            getObject = New Pretancament
            getObject.anyo = anyo
            getObject.mes = mes
            getObject.idCentre = idCentre
            If Not ModelEstatMes.getEstatTransitoria(e.id, anyo, mes) Then
                getObject.transitories = ModelTransitoria.getObjectsByCentreAnyMes(e, c, anyo, mes)
                getObject.assentaments = ModelDiario.getAssentamentsPretancamentCentreByMes(e, cPlus, c.codisProjecte, mes, False)
            Else
                getObject.assentaments = ModelDiario.getAssentamentsPretancamentCentreByMes(e, cPlus, c.codisProjecte, mes, True)
            End If
            If mes > 1 Then
                getObject.importsDetallMesAnterior = ModulActualitzacioGB.getValuesMes(idCentre, anyo, mes - 1)
            End If
        End If
        c = Nothing
    End Function
    Public Function getImportsSubgrupCentre(p As Pretancament) As List(Of Subgrup)
        Dim sg As Subgrup, subgrups As List(Of Subgrup)
        subgrups = ModelSubgrup.copyObjects()
        For Each sg In subgrups
            sg.saldoPretancament = p.valorPretancament(sg.id)
        Next sg
        getImportsSubgrupCentre = subgrups
        subgrups = Nothing
    End Function

    Private Function revisarTransitoria(assentaments As List(Of Assentament), transitories As List(Of Transitoria)) As List(Of Transitoria)
        Dim a As Assentament, t As Transitoria, p As Projecte, s As Subcompte, tempTransitories As List(Of Transitoria)
        tempTransitories = New List(Of Transitoria)
        tempTransitories = transitories
        For Each a In assentaments
            If InStr(1, a.concepte, "TRANSITORIA", vbTextCompare) <> 0 Then
                p = ModelProjecte.getObject(CStr(a.departamentAssentament & a.clave))
                s = ModelSubcompte.getobject(CStr(a.subcompteAssentament))
                For Each t In transitories
                    If t.idProjecte = s.id And t.idSubcompte = s.id And Month(a.dataAssentament) = t.mes And a.saldo = t.codiAcrualsSafetiesAny Then
                        tempTransitories.Remove(t)
                    End If
                Next t
            End If
        Next a
        revisarTransitoria = tempTransitories
        t = Nothing
        a = Nothing
        s = Nothing
        p = Nothing
        tempTransitories = Nothing
    End Function
End Module
