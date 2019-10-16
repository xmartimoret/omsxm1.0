Module COLUMN
    Public Function ID() As ColumnHeader
        ID = New ColumnHeader("id")
        ID.Text = IDIOMA.getString("id").ToString
        ID.Width = 100
    End Function
    Public Function ORDRE() As ColumnHeader
        ORDRE = New ColumnHeader("ordre")
        ORDRE.Text = IDIOMA.getString("ordre").ToString
        ORDRE.Width = 100
        ORDRE.TextAlign = HorizontalAlignment.Right
    End Function
    Public Function CODI() As ColumnHeader
        CODI = New ColumnHeader("codi")
        CODI.Text = IDIOMA.getString("codi").ToString
        CODI.Width = 100
        CODI.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function NOM(Optional llargada As Integer = 300) As ColumnHeader
        NOM = New ColumnHeader("nom")
        NOM.Text = IDIOMA.getString("nom").ToString
        NOM.Width = llargada
        NOM.TextAlign = HorizontalAlignment.Left
    End Function
    Public Function NOTES() As ColumnHeader
        NOTES = New ColumnHeader("notes")
        NOTES.Text = IDIOMA.getString("notes").ToString
        NOTES.Width = 150
        NOTES.TextAlign = HorizontalAlignment.Left
    End Function
    Public Function ESTAT() As ColumnHeader
        ESTAT = New ColumnHeader("estat")
        ESTAT.Text = IDIOMA.getString("estat").ToString
        ESTAT.Width = 100
        ESTAT.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function EMPRESA() As ColumnHeader
        EMPRESA = New ColumnHeader("empresa")
        EMPRESA.Text = IDIOMA.getString("empresa").ToString
        EMPRESA.Width = 150
        EMPRESA.TextAlign = HorizontalAlignment.Left
    End Function
    Public Function SECCIO() As ColumnHeader
        SECCIO = New ColumnHeader("seccio")
        SECCIO.Text = IDIOMA.getString("seccio").ToString
        SECCIO.Width = 100
        SECCIO.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function CENTRE() As ColumnHeader
        CENTRE = New ColumnHeader("centre")
        CENTRE.Text = IDIOMA.getString("centre").ToString
        CENTRE.Width = 100
        CENTRE.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function PARTICIPACIO() As ColumnHeader
        PARTICIPACIO = New ColumnHeader("participacio")
        PARTICIPACIO.Text = IDIOMA.getString("participacio").ToString
        PARTICIPACIO.Width = 100
        PARTICIPACIO.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function ANYO() As ColumnHeader
        ANYO = New ColumnHeader("anyo")
        ANYO.Text = IDIOMA.getString("anyo").ToString
        ANYO.Width = 50
        ANYO.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function DATA_MODIFICAT() As ColumnHeader
        DATA_MODIFICAT = New ColumnHeader("dataModificat")
        DATA_MODIFICAT.Text = IDIOMA.getString("dataModificat").ToString
        DATA_MODIFICAT.Width = -2
        DATA_MODIFICAT.TextAlign = HorizontalAlignment.Center
    End Function
    'IDIOMA.getString("SubCompra")
    Public Function SUB_COMPRA() As ColumnHeader
        SUB_COMPRA = New ColumnHeader("subCompra")
        SUB_COMPRA.Text = IDIOMA.getString("SubCompra").ToString
        SUB_COMPRA.Width = 100
        SUB_COMPRA.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function SUB_VARIABLE() As ColumnHeader
        SUB_VARIABLE = New ColumnHeader("subVariable")
        SUB_VARIABLE.Text = IDIOMA.getString("SubVariable").ToString
        SUB_VARIABLE.Width = 100
        SUB_VARIABLE.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function SUBCOMPTE() As ColumnHeader
        SUBCOMPTE = New ColumnHeader("subcompte")
        SUBCOMPTE.Text = IDIOMA.getString("subcompte").ToString
        SUBCOMPTE.Width = 200
        SUBCOMPTE.TextAlign = HorizontalAlignment.Left
    End Function
    Public Function PREFIX() As ColumnHeader
        PREFIX = New ColumnHeader("prefix")
        PREFIX.Text = IDIOMA.getString("prefixSubcompte").ToString
        PREFIX.Width = 100
        PREFIX.TextAlign = HorizontalAlignment.Left
    End Function
    Public Function TOTALITZA() As ColumnHeader
        TOTALITZA = New ColumnHeader("totalitza")
        TOTALITZA.Text = IDIOMA.getString("totalitza").ToString
        TOTALITZA.Width = 100
        TOTALITZA.TextAlign = HorizontalAlignment.Center
    End Function
    Public Function GENERICA(titol As String, amplada As Integer, hAlign As HorizontalAlignment) As ColumnHeader
        GENERICA = New ColumnHeader(titol)
        GENERICA.Text = IDIOMA.getString(titol)
        GENERICA.Width = amplada
        GENERICA.TextAlign = hAlign
    End Function
End Module
