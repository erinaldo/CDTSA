Imports Clases
Public Class btnZonas

    Private Sub btnCatCatCliente_Click(sender As Object, e As EventArgs) Handles btnCatCatCliente.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Categoria Cliente"
        frm.gsTableName = "fafCategoriaCliente"
        frm.gsCodeName = "IDCategoria"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDCategoria"

        frm.Show()

    End Sub

    Private Sub btnTipoCliente_Click(sender As Object, e As EventArgs) Handles btnTipoCliente.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Tipos de Cliente"
        frm.gsTableName = "fafTipoCliente"
        frm.gsCodeName = "IDTipo"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDTipo"
        frm.Show()
    End Sub

    Private Sub btnEstadoPedido_Click(sender As Object, e As EventArgs) Handles btnEstadoPedido.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Estados de Los Pedidos"
        frm.gsTableName = "fafEstadoPedido"
        frm.gsCodeName = "Estado"
        frm.gbCodeNumeric = False
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "Estado"

        frm.Show()

    End Sub

    Private Sub btnTipoEntrega_Click(sender As Object, e As EventArgs) Handles btnTipoEntrega.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Tipos de Entrega a Clientes"
        frm.gsTableName = "fafTipoEntrega"
        frm.gsCodeName = "IDTipoEntrega"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDTipoEntrega"

        frm.Show()

    End Sub

    Private Sub btnTipoFactura_Click(sender As Object, e As EventArgs) Handles btnTipoFactura.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Tipo de Factura"
        frm.gsTableName = "fafTipoFactura"
        frm.gsCodeName = "IDTipo"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDTipo"
        frm.Show()

    End Sub

    Private Sub cmdDepto_Click(sender As Object, e As EventArgs) Handles cmdDepto.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Departamentos"
        frm.gsTableName = "globalDepto"
        frm.gsCodeName = "IDDepto"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDDepto"
        frm.Show()

    End Sub

    Private Sub btnMunicipio_Click(sender As Object, e As EventArgs) Handles btnMunicipio.Click
        Dim frm As New frmSubCatalogo
        frm.gsCaptionFrm = "Master Departamento / Municipios"
        frm.gsStoreProcNameMaster = "fafGetMasterMunicipios"
        frm.gsParametersValuesMaster = "-1,-1"
        frm.gsTableNameMaster = "globalDepto"
        frm.gsCodeNameMaster = "IDDepto"
        frm.gbCodeNumericMaster = True
        frm.gsDescrNameMaster = "Descr"
        frm.gsFieldsRestMaster = "Activo"
        'frm.gsFieldsNameMaster = "IDDepto Codigo, Descr, Activo"
        frm.gsTableName = "globalMunicipio"
        frm.gsCodeName = "IDMunicipio"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        'frm.gsFieldsName = "IDMunicipio Codigo, Descr, Activo"
        frm.Show()

    End Sub

    Private Sub btnZona_Click(sender As Object, e As EventArgs) Handles btnZona.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Zonas"
        frm.gsTableName = "globalZona"
        frm.gsOrder = "IDZona"
        frm.gsCodeName = "IDZona"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = " Activo"
        frm.Show()

    End Sub

    Private Sub btnSubZonas_Click(sender As Object, e As EventArgs) Handles btnSubZonas.Click
        Dim frm As New frmSubCatalogo
        frm.gsCaptionFrm = "Master Zona / SubZona"
        frm.gsStoreProcNameMaster = "fafGetMasterSubZonas"
        frm.gsParametersValuesMaster = "-1,-1"
        frm.gsTableNameMaster = "globalZona"
        frm.gsCodeNameMaster = "IDZona"
        frm.gbCodeNumericMaster = True
        frm.gsDescrNameMaster = "Descr"
        frm.gsFieldsRestMaster = "Activo"
        frm.gsTableName = "globalSubZona"
        frm.gsCodeName = "IDSubZona"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"

        frm.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim frm As New frmClientes()
        frm.gsCodeName = "IDCliente"
        frm.gsCodeValue = 2
        frm.gsStoreProcNameGetData = "fafgetClientes"
        frm.gbCodeNumeric = True
        frm.gbEdit = True
        frm.gbAdd = False
        frm.Show()

    End Sub

    Private Sub btnPlazos_Click(sender As Object, e As EventArgs) Handles btnPlazos.Click
        Dim frm As New frmCatalogos()
        frm.gsCaptionFrm = "Plazos de Creditos"
        frm.gsTableName = "ccfPlazo"
        frm.gsCodeName = "Plazo"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "Plazo"

        frm.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm As New frmDetalles
        frm.gsFormDetalleName = "CLIENTE"
        frm.gsCaptionFrm = "Clientes"
        frm.gsTableName = "ccfClientes"
        frm.gsCodeName = "IDCliente"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Nombre"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDCliente"

        frm.Show()

    End Sub

    Private Sub btnVendedor_Click(sender As Object, e As EventArgs) Handles btnVendedor.Click
        Dim frm As New frmCatalogos
        frm.gsCaptionFrm = "Vendedores"
        frm.gsTableName = "fafVendedor"
        frm.gsCodeName = "IDVendedor"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Nombre"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDVendedor"

        frm.Show()

    End Sub

    Private Sub cmdNivel_Click(sender As Object, e As EventArgs) Handles cmdNivel.Click
        Dim frm As New frmCatalogos
        frm.gsCaptionFrm = "Niveles de Precios"
        frm.gsTableName = "fafNivelPrecio"
        frm.gsCodeName = "IDNivel"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Activo, IDMoneda"
        frm.gsOrder = "IDNivel"

        ' Campo Extra con control extragridedit
        frm.gbExtragridExiste = True
        frm.gbExtragridCodeNumeric = True
        frm.gsExtragridCodeName = "IDMoneda"
        frm.gsExtragridDescrName = "Moneda"
        frm.gsExtragridFieldsRest = "Descr"
        frm.gsExtragridFiltro = "Activo= 1"
        frm.gsExtragridLableText = "Moneda"
        frm.gsExtragridTableName = "globalMoneda"


        frm.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmDetalles
        frm.gsFormDetalleName = "VENDEDOR"
        frm.gsCaptionFrm = "Vendedores"
        frm.gsTableName = "fafVendedor"
        frm.gsCodeName = "IDVendedor"
        frm.gbCodeNumeric = True
        frm.gsDescrName = "Nombre"
        frm.gsFieldsRest = "Activo"
        frm.gsOrder = "IDVendedor"

        frm.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not CargaParametros() Then
            MessageBox.Show("No se han definido los parámetros de Facturación en el Sistema... LLame a su administrador de IT ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim td As New DataTable

        Dim cManager As New Clases.ClassManager
        Dim sParameters As String = "'" & gsUsuario & "', 1"
        td = cManager.ExecSPgetData("invgetBodegasFromUsuario", sParameters)
        If td.Rows.Count > 1 Then
            MessageBox.Show("El usuario tiene asignada más de una bodega para Facturar... debe tener una sola ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If td.Rows.Count <= 0 Then
            MessageBox.Show("El usuario debe tener asignada una bodega para Facturar... favor llamar al administrador de Sistemas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        gsSucursal = td.Rows(0)("IDBodega").ToString()
        Dim frm As New frmPedido()
        frm.Show()


    End Sub

    Private Sub btnBonif_Click(sender As Object, e As EventArgs) Handles btnBonif.Click
        Dim frm As New frmBonificaciones
        frm.Show()

    End Sub

    Private Sub btnPrecios_Click(sender As Object, e As EventArgs) Handles btnPrecios.Click
        Dim frm As New frmPrecios
        frm.ShowDialog()

    End Sub

    Private Sub btnAutorizaPedido_Click(sender As Object, e As EventArgs) Handles btnAutorizaPedido.Click
        Dim frm As New frmAutorizaPedido()
        frm.ShowDialog()

    End Sub

    Private Sub btnFactura_Click(sender As Object, e As EventArgs) Handles btnFactura.Click
        If Not CargaParametros() Then
            MessageBox.Show("No se han definido los parámetros del Sistema... LLame a su administrador de IT ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim td As New DataTable
        Dim lsCodigoConsecMask As String
        Dim cManager As New Clases.ClassManager
        Dim sParameters As String = "'" & gsUsuario & "', 1"
        td = cManager.ExecSPgetData("invgetBodegasFromUsuario", sParameters)

        If td.Rows.Count > 1 Then
            MessageBox.Show("El usuario tiene asignada más de una bodega para Facturar... debe tener una sola ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If td.Rows.Count <= 0 Then
            MessageBox.Show("El usuario debe tener asignada una bodega para Facturar... favor llamar al administrador de Sistemas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        gsSucursal = td.Rows(0)("IDBodega").ToString()
        lsCodigoConsecMask = td.Rows(0)("CodigoConsecMask").ToString()
        Dim frm As New frmFactura()
        If (frm IsNot Nothing) Then
            frm.gsConsecMask = lsCodigoConsecMask
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub btnConsecMask_Click(sender As Object, e As EventArgs) Handles btnConsecMask.Click
        Dim frm As New frmDetalles
        frm.gsFormDetalleName = "CONSECUTIVOMASK"
        frm.gsCaptionFrm = "Consecutivos"
        frm.gsTableName = "globalConsecMask"
        frm.gsCodeName = "Codigo"
        frm.gbCodeNumeric = False
        frm.gsDescrName = "Descr"
        frm.gsFieldsRest = "Consecutivo, Mascara,Activo"
        frm.gsOrder = "Codigo"

        frm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmParametrosFA.Show()
    End Sub

    Private Sub cmdPromociones_Click(sender As Object, e As EventArgs) Handles cmdPromociones.Click
        Dim frm As New frmPromociones
        frm.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New frmRemision
        frm.Show()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If Not CargaParametros() Then
            MessageBox.Show("No se han definido los parámetros del Sistema... LLame a su administrador de IT ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim td As New DataTable
        Dim lsCodigoConsecMask As String
        Dim cManager As New Clases.ClassManager
        Dim sParameters As String = "'" & gsUsuario & "', 1"
        td = cManager.ExecSPgetData("invgetBodegasFromUsuario", sParameters)

        If td.Rows.Count > 1 Then
            MessageBox.Show("El usuario tiene asignada más de una bodega para Facturar... debe tener una sola ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If td.Rows.Count <= 0 Then
            MessageBox.Show("El usuario debe tener asignada una bodega para Facturar... favor llamar al administrador de Sistemas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        gsSucursal = td.Rows(0)("IDBodega").ToString()
        lsCodigoConsecMask = td.Rows(0)("consecMaskDevolucion").ToString()
        Dim frm As New frmDevolucion()
        If (frm IsNot Nothing) Then
            frm.giIDFactura = 41
            frm.gsConsecMask = lsCodigoConsecMask
            frm.ShowDialog()
            frm.Dispose()
        End If


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim frm As New frmReporteIngresos
        frm.gbRINew = True
        frm.Show()
    End Sub
End Class