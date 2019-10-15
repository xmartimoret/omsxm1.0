Option Explicit On
Module ModelSubcomptesGrup
    Private objects As List(Of SubcompteGrup)
    Private Const N_COLUMNS As Integer = 6
    Private dateUpdate As DateTime

    ''' <summary>
    ''' Obté tots els Subcomptes d'un subgrup
    ''' </summary>
    ''' <param name="idSubGrup">subgrup Comptable</param>
    ''' <returns>Llista de SubcompteGrup</returns>
    Public Function getObjects(idSubGrup As Integer) As List(Of SubcompteGrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idSubGrup = idSubGrup)
    End Function
    ''' <summary>
    ''' Obté tots els Subcomptes d'un subgrup
    ''' </summary>
    ''' <param name="idSubGrup">subgrup Comptable</param>
    ''' <returns>Llista de SubcompteGrup</returns>
    Public Function getObjects(idSubGrup As Integer, filtre As String) As List(Of SubcompteGrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idSubGrup = idSubGrup And x.isFilter(filtre))
    End Function
    ''' <summary>
    ''' Obté tots els Subcomptes d'un subgrup
    ''' </summary>
    ''' <param name="id">id SubcompteGrup</param>
    ''' <returns>Llista de SubcompteGrup</returns>
    Public Function getObject(id As String) As SubcompteGrup
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    ' NOTES XMARTI S'ESBORRA LA FUNCTION GEToBJECTSoRDRE.
    '...
    ''' <summary>
    ''' Obte una copia dels subcomptes d'un SubgrupComptable
    ''' </summary>
    ''' <param name="idSubGrup"> SubgrupComptable</param>
    ''' <returns>llista SubcompteGrup</returns>
    Public Function copyObjects(idSubGrup As Integer) As List(Of SubcompteGrup)
        Dim sg As SubcompteGrup
        copyObjects = New List(Of SubcompteGrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each sg In objects
            If sg.idSubGrup = idSubGrup Then
                copyObjects.Add(sg.copy)
            End If
        Next sg
        sg = Nothing
    End Function
    Public Function getDataList(subcomptesSubgrup As List(Of SubcompteGrup)) As DataList
        Dim sg As SubcompteGrup, strCompra As String, strVariable As String
        getDataList = New DataList
        If subcomptesSubgrup.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.SUB_COMPRA)
            getDataList.columns.Add(COLUMN.SUB_VARIABLE)
            For Each sg In subcomptesSubgrup
                If sg.esDespesaCompra Then
                    strCompra = IDIOMA.getString("si")
                Else
                    strCompra = IDIOMA.getString("no")
                End If
                If sg.esDespesaVariable Then
                    strVariable = IDIOMA.getString("si")
                Else
                    strVariable = IDIOMA.getString("no")
                End If
                getDataList.rows.Add(New ListViewItem(New String() {sg.id, sg.idSubcompte, sg.codiSubcompte, sg.nomSubcompte, strCompra, strVariable}))
            Next
        End If
        sg = Nothing
    End Function

    ''' <summary>
    ''' Obté una llista de tots els subgrups que contenen un subcompte
    ''' </summary>
    ''' <param name="idSubcompte">id del subcompte a cercar</param>
    ''' <returns>Integer() de tots els subgups que contenen el Subcompte</returns>
    Public Function getIdSubgrups(idSubcompte As Integer) As Integer()
        Dim dades(1000) As Integer, sg As SubcompteGrup, i As Integer
        Dim temp() As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        i = 0
        For Each sg In objects
            If sg.idSubcompte = idSubcompte Then
                dades(i) = sg.idSubGrup
                i = i + 1
            End If
        Next sg
        If i > 1 Then
            ReDim temp(i - 1)
            For i = LBound(temp) To UBound(temp)
                temp(i) = dades(i)
            Next i
        Else
            ReDim temp(0)
        End If
        getIdSubgrups = temp
        sg = Nothing
    End Function
    ''' <summary>
    ''' Guarda un subcompteSubgrup Comptable a la BBDD.
    ''' Si no existeix l'inserta, sinó l'actualitza
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a guardar</param>
    ''' <returns>Cert si l'operació s'ha dut a terme,fals en cas contrari</returns>
    Public Function save(obj As SubcompteGrup) As Boolean
        Dim result As Boolean
        If Not exist(obj) Then
            result = dbSubcomptesGrup.insert(obj)
        Else
            result = dbSubcomptesGrup.update(obj)
        End If
        If result Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Actualitza els camps despesa variable i despesa de compra de tot un Subgrup Comptable
    ''' </summary>
    ''' <param name="obj"> SubGrup a actualitzar</param>
    ''' <returns>Cert si es dur a terme l'operació, fals en cas contrari</returns>
    Public Function saveSubgrup(obj As Subgrup) As Boolean
        If dbSubcomptesGrup.updateSubgrup(obj) Then
            Call resetIndex()
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    '''  Elimina un SubcompteSubgrup  de la BBDD
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a eliminar</param>
    ''' <returns>Cert si es dur a terme l'acció, fals en cas contrari</returns>
    Public Function remove(obj As SubcompteGrup) As Boolean
        If dbSubcomptesGrup.remove(obj) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    '''  Elimina totes les subcomptes d'un subgrup a la BBDD
    ''' </summary>
    ''' <param name="idGrup">Id del Subgrup  a l'eliminar els Subcomptes</param>
    ''' <returns>Cert si es dur a terme l'acció, fals en cas contrari</returns>
    Public Function removeGroup(idGrup As Integer) As Boolean
        If dbSubcomptesGrup.removeGroup(idGrup) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(X) X.idGrup = idGrup)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Comprova si existeix un subcompte en un subgrup
    ''' </summary>
    ''' <param name="idSubcompte">Subcompte</param>
    ''' <param name="idGrup">GrupComptable</param>
    ''' <returns>Cert si existeix, fals en cas contrari</returns>
    Public Function existSubcompteInGrup(idSubcompte As Integer, idGrup As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(X) X.idSubcompte = idSubcompte And X.idGrup = idGrup)
    End Function
    'NOTES XMARTI. ES SUPRIMERIX LA FUNCTION EXIST I ES DIU  existSubcompteGrup
    ''' <summary>
    ''' Comprova si existeix un subcompte en un subgrup
    ''' </summary>
    ''' <param name="obj">SubcompteGrup</param>
    ''' <returns>Cert si existeix, fals en cas contrari</returns>
    Public Function existSubcompteInGrup(obj As SubcompteGrup) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(X) X.idSubcompte = obj.idSubcompte And X.idGrup = obj.idGrup)
    End Function
    Public Function exist(obj As SubcompteGrup) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(X) X.id = obj.id)
    End Function
    Public Function exist(id As String) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(X) X.id = id)
    End Function
    Public Function exist(idSubcompte As Integer, idSubgrup As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idSubcompte = idSubcompte And x.idSubGrup = idSubgrup)
    End Function
    ''' <summary>
    ''' Comprova si existeix un subcompte 
    ''' </summary>
    ''' <param name="idSubcompte">Subcompte</param>
    ''' <returns>cert si existeix, fals en cas contrari</returns>
    Public Function existSubcompte(idSubcompte As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idSubcompte = idSubcompte)
    End Function
    'NOTES XMARTI ES SUPRIMEIXEN DOS FUNCTIONS QUE FEIEN EL MATEIX EXISTSUBCOMPTEBYCODCE I ETC
    ''' <summary>
    ''' Comprova si existeix el codi Subcompte
    ''' </summary>
    ''' <param name="codiSubcompte">Codi Subcompte</param>
    ''' <returns>Cert si existeix, fals en cas contrari</returns>
    Public Function existSubcompte(codiSubcompte As String) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.codiSubcompte = codiSubcompte)
    End Function

    'PRIVATE FUNCTION 
    ''' <summary>
    ''' Obté tots els objectes SubcompteSubgrup de la base de dades
    ''' </summary>
    ''' <returns>Llista de subcompteGrup</returns>
    Private Function getRemoteObjects() As List(Of SubcompteGrup)
        dateUpdate = Now()
        Return dbSubcomptesGrup.getObjects
    End Function

    ''' <summary>
    ''' Descarrega l'index d'objectes
    ''' </summary>
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    ''' <summary>
    ''' Comprova si la taula de la BBDD ha estat actualitzada
    ''' </summary>
    ''' <returns>Cert si ha estat actualitzada, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    ''' <summary>
    ''' Obté el nom de la taula de dades SubcompteGrup
    ''' </summary>
    ''' <returns>String (nom de la taula)</returns>
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaSubcomptesGrup
    End Function
    ''' <summary>
    ''' Obte el nom de la taula Subcompte a la base de dades
    ''' </summary>
    ''' <returns>String (nom de la taula)</returns>
    Private Function getTableSubcomptes() As String
        getTableSubcomptes = DBCONNECT.getTaulaSubcomptes
    End Function
    ''' <summary>
    ''' Obté el nom de la taula Subgrups de  la base de dades
    ''' </summary>
    ''' <returns>String (nom de la taula)</returns>
    Private Function getTableSubgrups() As String
        getTableSubgrups = DBCONNECT.getTaulaSubGrups
    End Function
End Module
