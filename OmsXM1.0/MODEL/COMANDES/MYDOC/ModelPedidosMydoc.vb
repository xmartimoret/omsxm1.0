Module ModelPedidosMydoc
    Private objects As List(Of PedidoMD)
    Private objectsGestor As List(Of PedidoMD)
    Public Function getRemoteObject(id As Integer) As PedidoMD
        Dim p As PedidoMD
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.Find(Function(x) x.id = id)
        If IsNothing(p) Then
            p = dbPedidosMD.getObject(id)
            If Not IsNothing(p) Then objects.Add(p)
        End If
        Return p
    End Function
    Public Function getObject(id As Integer) As PedidoMD
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function


    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub setdata()
        If Not isUpdated() Then objects = getRemoteObjects()
    End Sub
    Public Function save(obj As PedidoMD) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        If dbPedidosMD.update(obj.id, obj.estat) Then
            objects.Remove(obj)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function
    Public Function updateEnviado(obj As PedidoMD) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        If dbPedidosMD.updateEnviado(obj.id, obj.estat) Then
            objects.Remove(obj)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function
    Private Function getRemoteObjects() As List(Of PedidoMD)
        Return dbPedidosMD.getObjects
    End Function
    Private Function getRemoteObjectsGestor() As List(Of PedidoMD)
        Return dbPedidosMD.getObjects(1)
    End Function
    Public Function getidMydoc(codiComanda() As String, idEmpresa As Integer) As Long
        Dim p As PedidoMD, tempCodi() As String
        For Each p In objectsGestor
            tempCodi = Split(p.codi, "-")
            If UBound(tempCodi) >= 2 Then
                If esEmpresa(idEmpresa, p.empresa) Then
                    If Val(tempCodi(0)) = Val(codiComanda(0)) Then
                        If Val(tempCodi(2)) = Val(codiComanda(2)) Then
                            If Val(tempCodi(1)) = Val(codiComanda(1)) Then
                                Return p.id
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Return -1
    End Function
    Private Function esEmpresa(idEmpresa As Integer, nomEmpresa As String) As Boolean
        Select Case idEmpresa
            Case 1 : If (InStr(nomEmpresa, "OMS", CompareMethod.Text) > 0 Or InStr(nomEmpresa, "AGUA", CompareMethod.Text) > 0) Then Return True
            Case 2 : If (InStr(nomEmpresa, "LLOBREGAT", CompareMethod.Text) > 0 Or InStr(nomEmpresa, "PSARU", CompareMethod.Text) > 0) Then Return True
            Case 3 : If (InStr(nomEmpresa, "DENIA", CompareMethod.Text) > 0) Then Return True
            Case 7 : If (InStr(nomEmpresa, "MONTSI", CompareMethod.Text) > 0) Then Return True
            Case 8 : If (InStr(nomEmpresa, "CESMED", CompareMethod.Text) > 0) Then Return True
            Case 10 : If (InStr(nomEmpresa, "RIO", CompareMethod.Text) > 0 Or InStr(nomEmpresa, "SEGURA", CompareMethod.Text) > 0) Then Return True
            Case 11 : If (InStr(nomEmpresa, "IBERIA", CompareMethod.Text) > 0) Then Return True
            Case Else : Return False
        End Select
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Public Sub CarregarDadesGestor()
        objectsGestor = getRemoteObjectsGestor()
    End Sub
    Private Function isUpdated() As Boolean
        If objects Is Nothing Then
            Return False
        End If
        Return True
    End Function

End Module
