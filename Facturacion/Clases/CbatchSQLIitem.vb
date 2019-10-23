Public Class CbatchSQLIitem
    Public sql As String
    Public gRetornaIDNumerico As Boolean = False
    Public UsaAutoNumericInteger As Boolean = False
    Public EsParentID As Boolean = False
    Public UsaParentID As Boolean = False
    Public sProcesoPadre As String = ""
    Public sProcesoHijo As String = ""

    Sub New()
        Me.sql = ""
        Me.gRetornaIDNumerico = False
        Me.UsaAutoNumericInteger = False
        Me.EsParentID = False
        Me.UsaParentID = False
        Me.sProcesoPadre = ""
        Me.sProcesoHijo = ""
    End Sub
    Sub New(psql As String, pRetornaIDNumerico As Boolean, pUsaAutoNumericInteger As Boolean, pEsParentID As Boolean, pUsaParentID As Boolean, pProcesoPadre As String, pProcesoHijo As String)
        Me.sql = psql
        Me.gRetornaIDNumerico = pRetornaIDNumerico
        Me.UsaAutoNumericInteger = pUsaAutoNumericInteger
        Me.EsParentID = pEsParentID
        Me.UsaParentID = pUsaParentID
        Me.sProcesoPadre = pProcesoPadre
        Me.sProcesoHijo = pProcesoHijo
    End Sub

End Class
