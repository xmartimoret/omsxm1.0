Option Explicit On
Module ModelSeccioGrup
    Private objects As List(Of SeccioGrup)
    Private dateUpdate As DateTime

    ''' <summary>
    ''' Obté tots els grups comptables d'una secció
    ''' </summary>
    ''' <param name="idSeccio">id seccio</param>
    ''' <returns>Llista de Grups Comptables</returns>
    Public Function getObjects(idSeccio As Integer) As List(Of SeccioGrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idSeccio)
    End Function
    ''' <summary>
    ''' Guarda un grup comptable per una seccio
    ''' </summary>
    ''' <param name="idSeccio"> id seccio</param>
    ''' <param name="idGrup">id  grup</param>
    ''' <returns>cert si es dur a terme l'operacio, fals en cas contrari</returns>
    Public Function save(idSeccio As Integer, idGrup As Integer) As Boolean
        If Not exist(idSeccio, idGrup) Then
            If dbSeccioGrup.insert(idSeccio, idGrup) Then
                dateUpdate = Now()
                objects.Add(New SeccioGrup(idSeccio, idGrup))
                Return True
            End If
        End If
        Return False

    End Function
    ''' <summary>
    '''     Elimina un grup Comptable associat a una seccio
    ''' </summary>
    ''' <param name="idSeccio">id de la seccio</param>
    ''' <param name="idGrup">id del grup</param>
    ''' <returns>Cert  si l'operació es dur a terme, fals en cas contrari</returns>
    Public Function remove(idSeccio As Integer, idGrup As Integer) As Boolean

        If dbSeccioGrup.remove(idSeccio, idGrup) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idSeccio = idSeccio And x.idGrup = idGrup)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Elimina tots els grups Comptables d'una seccio
    ''' </summary>
    ''' <param name="idSeccio">idSeccio</param>
    ''' <returns>cert si l'operació es dur a terme, fals en cas contrari</returns>
    Public Function removeSeccio(idSeccio As Integer) As Boolean
        If dbSeccioGrup.removeSeccio(idSeccio) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idSeccio = idSeccio)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    '''  Comprova si existeix un grup per una seccio
    ''' </summary>
    ''' <param name="idSeccio">Identificador de la seccio </param>
    ''' <param name="idGrup">identificado del grup comptable</param>
    ''' <returns>Cert si existeix, fals en cas contrari</returns>
    Public Function exist(idSeccio As Integer, idGrup As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idSeccio = idSeccio And x.idGrup = idGrup)
    End Function
    ''' <summary>
    ''' Reseta els objectes que estan en memòria
    ''' </summary>
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    'PRIVATE FUNCTIONS
    ''' <summary>
    ''' obté tots els seccioGrup de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SeccioGrup de la BBDD</returns>
    Private Function getRemoteObjects() As List(Of SeccioGrup)
        dateUpdate = Now()
        Return dbSeccioGrup.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    ''' <summary>
    ''' Obté el nom de la base de dades de la BBDD
    ''' </summary>
    ''' <returns> String. NomTaulaDades</returns>
    Private Function getTable() As String
        Return DBCONNECT.getTaulaGrupsSeccio
    End Function

End Module
