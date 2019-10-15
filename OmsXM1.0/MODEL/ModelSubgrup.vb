Option Explicit On
''' <summary>
''' Model Subgrup. Es qui s'encarrega dels objectes subgrup.
''' Un subgrup pertany a un grup i un conté subcomptes. Comptables
''' <autor>xmarti. agost 2017</autor>
''' </summary>
Public Module ModelSubgrup
    Private objects As List(Of Subgrup)
    Private dateUpdate As DateTime
    Private Const N_COLUMNS As Integer = 5
    ''' <summary>
    ''' Obté els diferents subgrups del sistema.
    ''' Opcionalment  pot  filtrar  per grup Comptable
    ''' </summary>
    ''' <returns>Llista de Subgrups Comptables</returns>
    Public Function getObjects() As List(Of Subgrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function
    ''' <summary>
    ''' Obté els diferents subgrups del sistema.
    ''' Opcionalment  pot  filtrar  per grup Comptable
    ''' </summary>
    ''' <param name="g">grup Comptable, dels subgrups</param>
    ''' <param name="filtre">Texte pel qual es filtrarà el Subgrup</param>
    ''' <returns>Llista de Subgrups Comptables</returns>
    Public Function getObjects(g As Grup, Optional filtre As String = "") As List(Of Subgrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        If g Is Nothing Then
            If filtre = "" Then
                Return objects
            Else
                Return objects.FindAll(Function(x) x.isFilter(filtre))
            End If
        Else
            If filtre = "" Then
                Return objects.FindAll(Function(x) x.idGrup = g.id)
            Else
                Return objects.FindAll(Function(x) x.idGrup = g.id And x.isFilter(filtre))
            End If
        End If
    End Function

    ''' <summary>
    ''' Obté els diferents subgrups del sistema.
    ''' Opcionalment  pot  filtrar  per grup Comptable
    ''' </summary>
    ''' <param name="idGrup">grup Comptable, dels subgrups</param>
    ''' <param name="filtre">Texte pel qual es filtrarà el Subgrup</param>
    ''' <returns>Llista de Subgrups Comptables</returns>
    Public Function getObjects(idGrup As Integer, Optional filtre As String = "") As List(Of Subgrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        If filtre = "" Then
            Return objects.FindAll(Function(x) x.idGrup = idGrup)
        Else
            Return objects.FindAll(Function(x) x.idGrup = idGrup And x.isFilter(filtre))
        End If
    End Function
    ''' <summary>
    ''' Obté els subgrups que pertanyen a un grupComptable.
    ''' </summary>
    ''' <param name="g">Grup Comptable a cercar els Subgrupsº</param>
    ''' <returns>Llista de subgrupsComptables</returns>
    Public Function getObjectesByGrup(g As Grup)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idGrup = g.id)
    End Function
    Public Function getListObjects(Optional idGrup As Integer = 0) As Object()
        Dim obj As Subgrup, i As Integer = 0, objectes() As Object, temp As List(Of Subgrup)
        If idGrup = 0 Then
            temp = ModelSubgrup.getObjects()
        Else
            temp = ModelSubgrup.getObjects(idGrup)
        End If
        ReDim objectes(temp.Count - 1)

        For Each obj In temp
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
        temp = Nothing
    End Function
    Public Function copyObjects(Optional idGrup As Integer = 0) As List(Of Subgrup)
        Dim sg As Subgrup, temp As Subgrup, temp1 As String
        copyObjects = New List(Of Subgrup)
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each sg In objects
            If (idGrup > 0 And sg.idGrup = idGrup) Or idGrup = 0 Then
                temp = New Subgrup
                If sg.idGrup < 10 And sg.ordre < 10 Then
                    temp1 = "0" & sg.idGrup & "0" & sg.ordre
                ElseIf sg.idGrup < 10 Then
                    temp1 = "0" & sg.idGrup & sg.ordre
                ElseIf sg.ordre < 10 Then
                    temp1 = sg.idGrup & "0" & sg.ordre
                Else
                    temp1 = sg.idGrup & sg.ordre
                End If
                temp.ordre = temp1
                temp.actualitzat = sg.actualitzat
                temp.codi = sg.codi
                temp.nom = sg.nom
                temp.id = sg.id
                temp.idGrup = sg.idGrup
                temp.notes = sg.notes
                temp.subcomptes = ModelSubcomptesGrup.copyObjects(sg.id)
                temp.tipusCodi = sg.tipusCodi
                temp.esDespesaCompra = sg.esDespesaCompra
                temp.esDespesaVariable = sg.esDespesaVariable
                copyObjects.Add(temp)
            End If
        Next sg
        sg = Nothing
        temp = Nothing
    End Function
    ''' <summary>
    ''' Obté una llista(Datalist) per poder presentar a l'usuari mitjançant un formulari
    ''' </summary>
    ''' <param name="subgrups">Conjunt d'objectes a llistar</param>
    ''' <returns>DataList  amb les dades dels objectes que s'han passat com a paràmetre</returns>
    Public Function getDataList(subgrups As List(Of Subgrup)) As DataList
        Dim sg As Subgrup, strCompra As String, strVariable As String
        getDataList = New DataList
        If subgrups.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.SUB_COMPRA)
            getDataList.columns.Add(COLUMN.SUB_VARIABLE)
            For Each sg In subgrups
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
                getDataList.rows.Add(New ListViewItem(New String() {sg.id, sg.codi, sg.nom, strCompra, strVariable}))
            Next
        End If
        sg = Nothing
    End Function
    ''' <summary>
    ''' Obté un subgrupComptable a partir del seu identificador.
    ''' </summary>
    ''' <param name="id">Identificador</param>
    ''' <returns>Subgrup Comptable</returns>
    Public Function getObject(id As Long) As Subgrup
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    ''' <summary>
    ''' Obté un subgrupComptable a partir del codi
    ''' </summary>
    ''' <param name="codi">Paràmetre</param>
    ''' <returns>Si existeix el codi retorna el subgrupComptable</returns>
    Public Function getObject(codi As String) As Subgrup
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = codi)
    End Function
    ''' <summary>
    ''' Obté el nom d'un subgrupComptable a partir del seu codi
    ''' </summary>
    ''' <param name="code">codi d'un subgrupcomptable</param>
    ''' <returns>el nom del subgrup, en cas que existeixi el codi.</returns>
    Public Function getNameByCode(code As String) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = code).nom
    End Function
    ''' <summary>
    ''' Obté el codi d'un subgrupcomptable a partir de l'identificador
    ''' </summary>
    ''' <param name="id">identificador</param>
    ''' <returns>el codi del subgrup en cas que existeixi l'idntificador</returns>
    Public Function getCodi(id As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id).codi
    End Function
    ''' <summary>
    ''' Comprova que existeix un subgrupcomptable.
    ''' </summary>
    ''' <param name="id">identificador del subgrup Comptable</param>
    ''' <returns>cert si exiteix, fals en cas contrari</returns>
    Public Function exist(id As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id = id)
    End Function
    ''' <summary>
    ''' Comprova si existeix un subgrupcomptable
    ''' </summary>
    ''' <param name="obj">subgrup comptable</param>
    ''' <returns>cert si existeix, fals en cas contrari</returns>
    Public Function exist(obj As Subgrup) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.codi, obj.codi, CompareMethod.Text) = 0)
    End Function
    ''' <summary>
    ''' Obté el número de subgrupsComptables
    ''' </summary>
    ''' <returns>Enter. Número de subgrups Comptables</returns>
    Public Function getCount() As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Count
    End Function
    ''' <summary>
    ''' Guardar un subgrup comptable a la base de dades.
    ''' Si no existeix l'insereix, sino l'actualitza
    ''' </summary>
    ''' <param name="obj">subgrupComptable a guardar</param>
    ''' <returns>l'identificador del subgrup comptable guardat</returns>
    Public Function save(obj As Subgrup) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrder(obj.idGrup) + 1
            i = dbSubgrup.insert(obj)
        Else
            i = dbSubgrup.update(obj)
        End If
        If i > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Call ModelSubcomptesGrup.saveSubgrup(obj)
            Return obj.id
        End If
        Return -1
    End Function
    ''' <summary>
    ''' Elimina un subgrup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="obj">Subgrup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Public Function remove(obj As Subgrup) As Boolean
        If dbSubgrup.remove(obj) Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        End If
        Return False
    End Function

    Public Function removeGrup(g As Grup) As Boolean
        If dbSubgrup.removeGrup(g) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idGrup = g.id)
            Return True
        End If
        removeGrup = True
        
    End Function
    ''' <summary>
    ''' Calcula l'ordre maxim dins un grup Comptable
    ''' </summary>
    ''' <param name="idGrup">Grup comptable a calcular</param>
    ''' <returns>Enter, l'ordre max d'un grup comptable</returns>
    Private Function getMaxOrder(idGrup As Integer) As Integer
        Dim obj As Subgrup
        If Not isUpdated() Then objects = getRemoteObjects()
        getMaxOrder = 0
        For Each obj In objects
            If obj.idGrup = idGrup Then If obj.ordre > getMaxOrder Then getMaxOrder = obj.ordre
        Next obj
        obj = Nothing
    End Function
    ''' <summary>
    ''' Canvia l'ordre de dos subgrupsComptables
    ''' </summary>
    ''' <param name="s1">subgrupComptable </param>
    ''' <param name="s2">SubgrupComptable</param>
    Public Sub changeOrder(s1 As Subgrup, s2 As Subgrup)
        Dim temp As Integer
        If UCase(TypeName(s1)) = UCase("Subgrup") And UCase(TypeName(s2)) = UCase("Subgrup") Then
            If s1.id > 0 And s2.id > 0 Then
                temp = s1.ordre
                s1.ordre = s2.ordre
                s2.ordre = temp
                Call save(s1)
                Call save(s2)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Reseteja els subgrups del sistema. Borra els objectes residents en memòria
    ''' </summary>
    Public Sub resetIndex()
        objects = Nothing
    End Sub


    ' private module
    ''' <summary>
    ''' obté tots els subgrupsComptables de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SubgrupsComptables de la BBDD</returns>
    Private Function getRemoteObjects() As List(Of Subgrup)
        dateUpdate = Now()
        Return dbSubgrup.getObjects
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

End Module

'   