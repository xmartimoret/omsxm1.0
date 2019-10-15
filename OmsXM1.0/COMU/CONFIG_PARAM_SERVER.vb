Option Explicit On
Imports System.Data.SqlClient
Module CONFIG_PARAM_SERVER
    Private objects As List(Of Parametre)
    Private Const ETIQUETA As String = "TAG"
    Private Const VALOR As String = "VALOR"
    Private dateUpdate As DateTime
    Private Enum tag
        TAG_FULLA_PARAMETRES_VOSS = 1
        TAG_FULLA_INFORME_VOSS
        TAG_FULLA_DADES_VOSS
        TAG_RANG_ANY_VOSS
        TAG_RANG_DADES_ANY_ACTUAL
        TAG_RANG_DADES_ANY_SEGUENT
        TAG_RANG_INFO_ANY_ACTUAL
        TAG_RANG_INFO_ANY_SEGUENT
        TAG_RANG_CODI_SUBGRUP_VOSS
        TAG_FULLA_BUDGET_EXPLOTACIONS
        TAG_FULLA_BUDGET_OBRES
        TAG_FULLA_BUDGET_HEAD
        TAG_RANG_NOM_PROJECTE_VOSS
        TAG_PARAMETRE_COBRO_TRESORERIA
        TAG_PARAMETRE_PAGAMENT_TRESORERIA
        TAG_XEC_NOM_PROJECTE_TRESORERIA
        TAG_PARAMETRE_NOM_TRESORERIA
        TAG_PARAMETRE_FULLA_CASH
        TAG_PARAMETRE_COLUMNA_TRESORERIA
        TAG_FULLA_IDIOMA_VOSS
        TAG_SUBCOMPTE_DEURE_TRANSITORIA
        TAG_SUBCOMPTE_HAVER_TRANSITORIA
    End Enum
    Private Function getValor(tag As Integer) As String
        Dim p As Parametre
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.Find(Function(x) x.id = tag)
        If p IsNot Nothing Then
            Return p.valor
        Else
            Return ""
        End If
    End Function
    Private Sub setValor(p As Parametre)
        Dim sc As SqlCommand, i As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        If Not objects.Exists(Function(x) x.id = p.id) Then
            sc = New SqlCommand("INSERT INTO " & getTable() & "(" & ETIQUETA & "," & VALOR & ") VALUES(@id,@valor) ", DBCONNECT.getConnection)
        Else
            sc = New SqlCommand("UPDATE " & getTable() & " SET " & VALOR & " = @valor   WHERE " & ETIQUETA & " = @id", DBCONNECT.getConnection)
        End If

        sc.Parameters.Add("@id", SqlDbType.Int).Value = p.id
        sc.Parameters.Add("@valor", SqlDbType.VarChar).Value = p.valor
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            dateUpdate = Now()
            objects.Remove(p)
            objects.Add(p)
        End If
    End Sub
    ' accessors
    Public Function getFullaParametresVoss() As String
        getFullaParametresVoss = getValor(tag.TAG_FULLA_PARAMETRES_VOSS)
    End Function
    Public Sub setFullaParametresVoss(valor As String)
        Call setValor(New Parametre(tag.TAG_FULLA_PARAMETRES_VOSS, valor))
    End Sub

    Public Function getFullaInformeVoss() As String
        getFullaInformeVoss = getValor(tag.TAG_FULLA_INFORME_VOSS)
    End Function
    Public Sub setFullaInformeVoss(valor As String)
        Call setValor(New Parametre(tag.TAG_FULLA_INFORME_VOSS, valor))
    End Sub

    Public Function getFullaDadesVoss() As String
        getFullaDadesVoss = getValor(tag.TAG_FULLA_DADES_VOSS)
    End Function
    Public Sub setFullaDadesVoss(valor As String)
        Call setValor(New Parametre(tag.TAG_FULLA_DADES_VOSS, valor))
    End Sub
    Public Function getFullaIdiomaVoss() As String
        getFullaIdiomaVoss = getValor(tag.TAG_FULLA_IDIOMA_VOSS)
    End Function
    Public Sub setFullaIdiomaVoss(valor As String)
        Call setValor(New Parametre(tag.TAG_FULLA_IDIOMA_VOSS, valor))
    End Sub
    Public Function getRangAnyVoss() As String
        getRangAnyVoss = getValor(tag.TAG_RANG_ANY_VOSS)
    End Function
    Public Sub setRangAnyVoss(valor As String)
        Call setValor(New Parametre(tag.TAG_RANG_ANY_VOSS, valor))
    End Sub

    Public Function getRangDadesAnyActual() As String
        getRangDadesAnyActual = getValor(tag.TAG_RANG_DADES_ANY_ACTUAL)
    End Function
    Public Sub setRangDadesAnyActual(valor As String)
        Call setValor(New Parametre(tag.TAG_RANG_DADES_ANY_ACTUAL, valor))
    End Sub
    Public Function getRangDadesAnySeguent() As String
        getRangDadesAnySeguent = getValor(tag.TAG_RANG_DADES_ANY_SEGUENT)
    End Function
    Public Sub setRangDadesAnySeguent(valor As String)
        Call setValor(New Parametre(tag.TAG_RANG_DADES_ANY_SEGUENT, valor))
    End Sub

    Public Function getRangInfoAnyActual() As String
        getRangInfoAnyActual = getValor(tag.TAG_RANG_INFO_ANY_ACTUAL)
    End Function
    Public Sub setRangInfoAnyActual(valor As String)
        Call setValor(New Parametre(tag.TAG_RANG_INFO_ANY_ACTUAL, valor))
    End Sub
    Public Function getRangInfoAnySeguent() As String
        getRangInfoAnySeguent = getValor(tag.TAG_RANG_INFO_ANY_SEGUENT)
    End Function
    Public Sub setRangInfoAnySeguent(valor As String)
        Call setValor(New Parametre(tag.TAG_RANG_INFO_ANY_SEGUENT, valor))
    End Sub

    Public Function getRangCodiSubgrupVoss() As String
        getRangCodiSubgrupVoss = getValor(tag.TAG_RANG_CODI_SUBGRUP_VOSS)
    End Function
    Public Sub setRangCodiSubgrupVoss(valor As String)
        Call setValor(New Parametre(tag.TAG_RANG_CODI_SUBGRUP_VOSS, valor))
    End Sub

    Public Function getFullaBudgetExplotacions() As String
        getFullaBudgetExplotacions = getValor(tag.TAG_FULLA_BUDGET_EXPLOTACIONS)
    End Function
    Public Sub setFullaBudgetExplotacions(valor As String)
        Call setValor(New Parametre(tag.TAG_FULLA_BUDGET_EXPLOTACIONS, valor))
    End Sub
    Public Function getFullaBudgetHeadquarters() As String
        getFullaBudgetHeadquarters = getValor(tag.TAG_FULLA_BUDGET_HEAD)
    End Function
    Public Sub setFullaBudgetHeadquarters(valor As String)

        Call setValor(New Parametre(tag.TAG_FULLA_BUDGET_HEAD, valor))
    End Sub

    Public Function getFullaBudgetObres() As String
        getFullaBudgetObres = getValor(tag.TAG_FULLA_BUDGET_OBRES)
    End Function
    Public Sub setFullaBudgetObres(valor As String)
        Call setValor(New Parametre(tag.TAG_FULLA_BUDGET_OBRES, valor))
    End Sub
    Public Function getRangNomProjecteVOSS() As String
        getRangNomProjecteVOSS = getValor(tag.TAG_RANG_NOM_PROJECTE_VOSS)
    End Function
    Public Sub setRangNomProjecteVOSS(valor As String)
        Call setValor(New Parametre(tag.TAG_RANG_NOM_PROJECTE_VOSS, valor))
    End Sub

    Public Sub setParametresPerDefecte()
        Call CONFIG_PARAM_SERVER.setFullaBudgetExplotacions("PRETANCAMENT")
        Call CONFIG_PARAM_SERVER.setFullaBudgetHeadquarters("SM+FACT+HEAD")
        Call CONFIG_PARAM_SERVER.setFullaBudgetObres("PROJ.BUDGET")
        Call CONFIG_PARAM_SERVER.setFullaDadesVoss("Hilfsdatei HR Cognos")
        Call CONFIG_PARAM_SERVER.setFullaInformeVoss("Eingabe Planzahlen")
        Call CONFIG_PARAM_SERVER.setFullaParametresVoss("Eingabeparameter")
        Call CONFIG_PARAM_SERVER.setRangAnyVoss("D17")
        Call CONFIG_PARAM_SERVER.setRangCodiSubgrupVoss("BQ26")
        Call CONFIG_PARAM_SERVER.setRangDadesAnyActual("CU26")
        Call CONFIG_PARAM_SERVER.setRangDadesAnySeguent("DH26")
        Call CONFIG_PARAM_SERVER.setRangInfoAnyActual("BS6")
        Call CONFIG_PARAM_SERVER.setRangInfoAnySeguent("CG6")

        Call CONFIG_PARAM_SERVER.setParametreCobroTresoreria("INGRES")
        Call CONFIG_PARAM_SERVER.setParametreColumnaTresoreria("CONCEPTE")
        Call CONFIG_PARAM_SERVER.setParametrePagamentTresoreria("PAGAMENT")
        Call CONFIG_PARAM_SERVER.setXecNomProjecteTresoreria(True)
        Call CONFIG_PARAM_SERVER.setParametreFullaCash("DADES_TRESORERIA")
        Call CONFIG_PARAM_SERVER.setParametreNomTresoreria("")
    End Sub
    Private Sub setTemp()
        Call CONFIG_PARAM_SERVER.setParametreCobroTresoreria("INGRES")
        Call CONFIG_PARAM_SERVER.setParametreColumnaTresoreria("CONCEPTE")
        Call CONFIG_PARAM_SERVER.setParametrePagamentTresoreria("PAGAMENT")
        Call CONFIG_PARAM_SERVER.setXecNomProjecteTresoreria(True)
        Call CONFIG_PARAM_SERVER.setParametreFullaCash("DADES_TRESORERIA")
        Call CONFIG_PARAM_SERVER.setParametreNomTresoreria("")
    End Sub

    'TAG_PARAMETRE_COBRO_TRESORERIA
    Public Function getParametreCobroTresoreria() As String
        getParametreCobroTresoreria = getValor(tag.TAG_PARAMETRE_COBRO_TRESORERIA)
    End Function
    Public Sub setParametreCobroTresoreria(valor As String)
        Call setValor(New Parametre(tag.TAG_PARAMETRE_COBRO_TRESORERIA, valor))
    End Sub

    '    TAG_PARAMETRE_PAGAMENT_TRESORERIA
    Public Function getParametrePagamentTresoreria() As String
        getParametrePagamentTresoreria = getValor(tag.TAG_PARAMETRE_PAGAMENT_TRESORERIA)
    End Function
    Public Sub setParametrePagamentTresoreria(valor As String)
        Call setValor(New Parametre(tag.TAG_PARAMETRE_PAGAMENT_TRESORERIA, valor))
    End Sub
    '    TAG_XEC_NOM_PROJECTE_TRESORERIA
    Public Function getXecNomProjecteTresoreria() As Boolean
        If getValor(tag.TAG_XEC_NOM_PROJECTE_TRESORERIA) = "" Then
            getXecNomProjecteTresoreria = False
        Else
            getXecNomProjecteTresoreria = CBool(getValor(tag.TAG_XEC_NOM_PROJECTE_TRESORERIA))
        End If
    End Function
    Public Sub setXecNomProjecteTresoreria(valor As Boolean)
        Call setValor(New Parametre(tag.TAG_XEC_NOM_PROJECTE_TRESORERIA, valor))
    End Sub
    '    TAG_PARAMETRE_NOM_TRESORERIA
    Public Function getParametreNomTresoreria() As String
        getParametreNomTresoreria = getValor(tag.TAG_PARAMETRE_NOM_TRESORERIA)
    End Function
    Public Sub setParametreNomTresoreria(valor As String)
        Call setValor(New Parametre(tag.TAG_PARAMETRE_NOM_TRESORERIA, valor))
    End Sub
    '    TAG_PARAMETRE_FULLA_CASH
    Public Function getParametreFullaCash() As String
        getParametreFullaCash = getValor(tag.TAG_PARAMETRE_FULLA_CASH)
    End Function
    Public Sub setParametreFullaCash(valor As String)
        Call setValor(New Parametre(tag.TAG_PARAMETRE_FULLA_CASH, valor))
    End Sub

    '    TAG_PARAMETRE_COLUMNA_TRESORERIA
    Public Function getParametreColumnaTresoreria() As String
        getParametreColumnaTresoreria = getValor(tag.TAG_PARAMETRE_COLUMNA_TRESORERIA)
    End Function
    Public Sub setParametreColumnaTresoreria(valor As String)
        Call setValor(New Parametre(tag.TAG_PARAMETRE_COLUMNA_TRESORERIA, valor))
    End Sub
    'TAG_SUBCOMPTE_DEURE_TRANSITORIA
    Public Function getSubcompteTransitoriaSaldoDeure() As String
        getSubcompteTransitoriaSaldoDeure = getValor(tag.TAG_SUBCOMPTE_DEURE_TRANSITORIA)
    End Function
    Public Sub setSubcompteTransitoriaSaldoDeure(valor As String)
        Call setValor(New Parametre(tag.TAG_SUBCOMPTE_DEURE_TRANSITORIA, valor))
    End Sub
    'TAG_SUBCOMPTE_DEURE_TRANSITORIA
    Public Function getSubcompteTransitoriaSaldoHaver() As String
        getSubcompteTransitoriaSaldoHaver = getValor(tag.TAG_SUBCOMPTE_HAVER_TRANSITORIA)
    End Function
    Public Sub setSubcompteTransitoriaSaldoHaver(valor As String)
        Call setValor(New Parametre(tag.TAG_SUBCOMPTE_HAVER_TRANSITORIA, valor))
    End Sub

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

    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of Parametre)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getRemoteObjects = New List(Of Parametre)
        sc = New SqlCommand("SELECT * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getRemoteObjects.Add(New Parametre(sdr(ETIQUETA), CONFIG.validarNull(sdr(VALOR))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        dateUpdate = Now()
        getRemoteObjects.Sort()
        Return getRemoteObjects
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaParametres
    End Function
End Module
