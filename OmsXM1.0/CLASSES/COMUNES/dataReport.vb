Public Class dataReport
    Public Property tipusInforme As String
    Public Property empresaActual As Empresa
    Public Property contaplusActual As Contaplus
    Public Property seccioActual As Seccio
    Public Property grupComptable As Grup
    Public Property mesActual As Mes
    Public Property isValorAcumulat As Boolean

    Public Sub New()
    End Sub
    Public Sub New(pTipus As String)
        _tipusInforme = pTipus
    End Sub
    Public Sub New(pTipus As String, pEmpresa As Empresa, pContaplus As Contaplus)
        _tipusInforme = pTipus
        _empresaActual = pEmpresa
        _contaplusActual = pContaplus
    End Sub
    Public Sub New(pTipus As String, pEmpresa As Empresa, pContaplus As Contaplus, pSeccio As Seccio, pGrup As Grup)
        _tipusInforme = pTipus
        _empresaActual = pEmpresa
        _contaplusActual = pContaplus
        _seccioActual = pSeccio
        _grupComptable = pGrup
    End Sub
    Public Sub New(pTipus As String, pEmpresa As Empresa, pContaplus As Contaplus, pSeccio As Seccio, pGrup As Grup, pMes As Mes, pAbsolut As Boolean)
        _tipusInforme = pTipus
        _empresaActual = pEmpresa
        _contaplusActual = pContaplus
        _seccioActual = pSeccio
        _grupComptable = pGrup
        _mesActual = pMes
        _isValorAcumulat = pAbsolut
    End Sub
End Class
