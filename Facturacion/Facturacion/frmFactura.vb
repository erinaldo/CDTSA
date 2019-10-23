Imports Clases
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Win
Imports DevExpress.XtraGrid.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.GridControl
Imports DevExpress.Utils
Imports DevExpress.XtraReports.UI
Imports DevExpress.LookAndFeel
Imports System.Globalization

Public Class frmFactura
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()


    'Dim dtFacturaLineaBonif As New DataTable()
    Dim currentRow As DataRow ' esta row es del grid, linea producto de la factura 
    Dim gsPedidoID As String
    Dim gsIDBodega As String
    Dim gsIDProducto As String
    Dim gbUsaPedido As Boolean = False
    Dim gbBonifica As Boolean = False
    Dim gbBonifConProd As Boolean = False
    Dim gbLoteAsignado As Boolean = False
    Dim gdTotalBonificado As Decimal = 0
    Dim gdPorcInteres As Decimal = 0
    Dim gIDPlazo As Integer
    Public gsConsecMask As String
    Dim gsMascara As String
    Dim iNumeroLineasFactura As Integer = 0


    Sub CargagridLookUp(ByVal g As GridLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.PopupFilterMode = PopupFilterMode.Default
        g.Properties.NullText = ""

    End Sub

    'Private Sub InserttblRowFacturaLinea(bLoteAsignado As Boolean, iIDBodega As Integer, iIDProducto As Integer, sDescr As String, dCantidad As Decimal, dPrecio As Decimal, dDescuento As Decimal, dDescuentoEspecial As Decimal, dImpuesto As Decimal, dPorcImp As Decimal, dSubTotal As Decimal, dCantBonificada As Decimal, dCantFacturada As Decimal, dPorcDescuentoEsp As Decimal)
    '    Dim dTotal As Decimal
    '    dSubTotal = (dCantidad * dPrecio) - dDescuento - dDescuentoEspecial
    '    dTotal = dSubTotal + dImpuesto
    '    'dTotal = dSubTotal + (Convert.ToDecimal(IIf(txtPorcImp.Text = "", "0", txtPorcImp.Text)) / 100) * dSubTotal
    '    dtFacturaLinea.Rows.Add(bLoteAsignado, iIDBodega, iIDProducto, sDescr, dCantidad, dPrecio, dDescuento, dDescuentoEspecial, dImpuesto, dPorcImp, dSubTotal, dTotal, False, False, dCantBonificada, dCantFacturada, dPorcDescuentoEsp)
    'End Sub

    Private Sub InserttblRowFacturaLinea(bLoteAsignado As Boolean, iIDBodega As Integer, iIDProducto As Integer, sDescr As String, dCantidad As Decimal, dPrecio As Decimal, dDescuento As Decimal, dDescuentoEspecial As Decimal, _
            dImpuesto As Decimal, dPorcImp As Decimal, dSubTotal As Decimal, dSubTotalFinal As Decimal, dTotal As Decimal, bBonifica As Boolean, bBonifConProd As Boolean, dCantBonificada As Decimal, dCantFacturada As Decimal, dPorcDescuentoEsp As Decimal)

        dtFacturaLinea.Rows.Add(bLoteAsignado, iIDBodega, iIDProducto, sDescr, dCantidad, dPrecio, dDescuento, dDescuentoEspecial, dImpuesto, dPorcImp, dSubTotal,
            dSubTotalFinal, dTotal, bBonifica, bBonifConProd, dCantBonificada, dCantFacturada, 0, 0, dPorcDescuentoEsp)
    End Sub

    Private Sub FillTableFacturalinea()
        Dim dPrecio As Decimal, dDescuento As Decimal, dDescuentoEspecial As Decimal, _
            dImpuesto As Decimal, dSubTotal As Decimal, dSubTotalFinal As Decimal, dTotal As Decimal
        If gbUsaPedido Then
            For Each dr In tableData.Rows ' Me.dtFacturaLinea.Rows
                If CBool(dr("Nacional")) Then
                    dPrecio = CDec(dr("PrecioLocal"))
                    dImpuesto = CDec(dr("ImpuestoLocal"))
                    dSubTotal = CDec(dr("SubTotalLocal"))
                    dSubTotalFinal = CDec(dr("SubTotalFinalLocal"))
                    dDescuento = CDec(dr("DescuentoLocal"))
                    dDescuentoEspecial = CDec(dr("DescuentoEspecialLocal"))
                    dTotal = dSubTotalFinal + dImpuesto
                Else
                    dPrecio = CDec(dr("PrecioDolar"))
                    dImpuesto = CDec(dr("ImpuestoDolar"))
                    dSubTotal = CDec(dr("SubTotalDolar"))
                    dSubTotalFinal = CDec(dr("SubTotalFinalDolar"))
                    dDescuento = CDec(dr("DescuentoDolar"))
                    dDescuentoEspecial = CDec(dr("DescuentoEspecialDolar"))
                    dTotal = dSubTotalFinal + dImpuesto
                End If

                InserttblRowFacturaLinea(False, Convert.ToInt32(dr("IDBodega")), Convert.ToInt32(dr("IDProducto")), dr("Descr").ToString(), _
                                        Convert.ToDecimal(dr("Cantidad")), dPrecio, _
                                        dDescuento, dDescuentoEspecial, _
                                       dImpuesto, Convert.ToDecimal(dr("PorcImp")), _
                                        dSubTotal, dSubTotalFinal, dTotal, CBool(dr("Bonifica")), _
                                        CBool(dr("BonifConProd")), _
                                Convert.ToDecimal(dr("CantBonificada")), 0, Convert.ToDecimal(dr("PorcDescuentoEsp")))
            Next dr
        End If
    End Sub

    Private Sub InserttblRowFacturaLineaLote(iIDLote As Integer, iIDProducto As Integer, dCantidad As Decimal)
        dtFacturaLineaLote.Rows.Add(iIDLote, iIDProducto, dCantidad)
    End Sub

    'Private Sub FillTableFacturaLineaLote(dtLotes As DataTable)
    '    For Each dr In dtLotes.Rows
    '        'InserttblRowFacturaLineaLote(Convert.ToInt32(dr("IDLote")), Convert.ToInt32(dr("IDProducto")), (Convert.ToDecimal(dr("AsignadoFA")) + Convert.ToDecimal(dr("AsignadoBO"))))
    '        dtFacturaLineaLote.Rows.Add(Convert.ToInt32(dr("IDLote")), Convert.ToInt32(dr("IDProducto")), (Convert.ToDecimal(dr("AsignadoFA")) + Convert.ToDecimal(dr("AsignadoBO"))))
    '    Next dr
    'End Sub

    ' UpdateDatatable LInea de Factura
    Sub UpdateDataTableRowFacLin(strCriterio As String)
        Dim myRow() As Data.DataRow
        myRow = dtFacturaLinea.Select(strCriterio)
        If myRow.Count > 0 Then
            txtDescLinea.EditValue = txtCantBonif.EditValue * CDbl(txtPrecio.EditValue)
            myRow(0)("Precio") = txtPrecio.EditValue
            myRow(0)("Impuesto") = CDbl(Me.txtImpuesto.EditValue)
            myRow(0)("SubTotal") = CDbl(Me.txtPrecio.EditValue) * CDbl(txtCantidad.EditValue)
            myRow(0)("DescuentoEspecial") = CDec(Me.txtDescEspLinea.EditValue)
            myRow(0)("Descuento") = txtCantBonif.EditValue * CDbl(txtPrecio.EditValue)
            myRow(0)("SubTotalFinal") = CDec(myRow(0)("SubTotal")) - CDec(myRow(0)("Descuento")) - CDec(myRow(0)("DescuentoEspecial"))
            myRow(0)("Total") = CDec(myRow(0)("SubTotalFinal")) + CDec(Me.txtImpuesto.Text)

        End If
    End Sub

    Sub CreateFieldsToDataTable()
        dtFacturaLinea = New DataTable
        dtFacturaLineaLote = New DataTable

        ' Campos del detalle de la factura
        dtFacturaLinea.Columns.Add("LoteAsignado", GetType(Boolean))
        dtFacturaLinea.Columns.Add("IDBodega", GetType(Integer))
        dtFacturaLinea.Columns.Add("IDProducto", GetType(Integer))
        dtFacturaLinea.Columns.Add("Descr", GetType(String))
        dtFacturaLinea.Columns.Add("Cantidad", GetType(Decimal))
        dtFacturaLinea.Columns.Add("Precio", GetType(Decimal))
        dtFacturaLinea.Columns.Add("Descuento", GetType(Decimal))
        dtFacturaLinea.Columns.Add("DescuentoEspecial", GetType(Decimal))
        dtFacturaLinea.Columns.Add("Impuesto", GetType(Decimal))
        dtFacturaLinea.Columns.Add("PorcImp", GetType(Decimal))
        dtFacturaLinea.Columns.Add("SubTotal", GetType(Decimal))
        dtFacturaLinea.Columns.Add("SubTotalFinal", GetType(Decimal))
        dtFacturaLinea.Columns.Add("Total", GetType(Decimal))
        dtFacturaLinea.Columns.Add("Bonifica", GetType(Boolean))
        dtFacturaLinea.Columns.Add("BonifConProd", GetType(Boolean))
        dtFacturaLinea.Columns.Add("CantBonificada", GetType(Decimal))
        dtFacturaLinea.Columns.Add("CantFacturada", GetType(Decimal))
        dtFacturaLinea.Columns.Add("CostoLocal", GetType(Decimal))
        dtFacturaLinea.Columns.Add("CostoDolar", GetType(Decimal))
        dtFacturaLinea.Columns.Add("PorcDescuentoEsp", GetType(Decimal))

        'Lotes/fact/Bonificacion
        dtFacturaLineaLote.Columns.Add("IDBodega", GetType(Integer))
        dtFacturaLineaLote.Columns.Add("IDProducto", GetType(Integer))
        dtFacturaLineaLote.Columns.Add("IDLote", GetType(Integer))
        dtFacturaLineaLote.Columns.Add("CantFacturada", GetType(Decimal))
        dtFacturaLineaLote.Columns.Add("CantBonificada", GetType(Decimal))
        dtFacturaLineaLote.Columns.Add("Cantidad", GetType(Decimal))
        dtFacturaLineaLote.Columns.Add("Requerido", GetType(Decimal))
        dtFacturaLineaLote.Columns.Add("Bono", GetType(Decimal))
        ' Extras para cuando quieran ver lo que ya fue asignado
        dtFacturaLineaLote.Columns.Add("Descr", GetType(String))
        dtFacturaLineaLote.Columns.Add("LoteInterno", GetType(String))
        dtFacturaLineaLote.Columns.Add("LoteProveedor", GetType(String))
        dtFacturaLineaLote.Columns.Add("Vencimiento", GetType(Date))
        dtFacturaLineaLote.Columns.Add("Existencia", GetType(Decimal))
        dtFacturaLineaLote.Columns.Add("AsignadoFA", GetType(Decimal))
        dtFacturaLineaLote.Columns.Add("AsignadoBO", GetType(Decimal))


    End Sub


    'Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
    '    g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
    '    g.Properties.DisplayMember = sDisplayMember
    '    g.Properties.ValueMember = sValueMember
    '    g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit 'DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
    '    g.Properties.PopupFormSize = New Size(250, 250)
    '    g.Properties.NullText = ""
    'End Sub

    Sub CargagridLookUpsFromTables()

        'CargagridSearchLookUp(Me.SearchLookUpEditCliente, "vClientes", "IDCliente, Nombre, Telefono, Farmacia,Direccion, DescrTipo, DescrCategoria, Activo", "", "IDCliente", "Nombre", "IDCliente")
        CargagridSearchLookUp(Me.SearchLookUpEditPlazo, "ccfPlazo", "Plazo, Descr, Activo", "", "Plazo", "Descr", "Plazo")
        CargagridSearchLookUp(Me.SearchLookUpEditTipoFact, "fafTipoFactura", "IDTipo, Descr, Activo", "", "IDTipo", "Descr", "IDTipo")
        CargagridSearchLookUp(Me.SearchLookUpEditSucursal, "invBodega", "IDBodega, Descr, Activo", "", "IDBodega", "Descr", "IDBodega")
        CargagridSearchLookUp(Me.SearchLookUpEditVendedor, "fafVendedor", "IDVendedor, Nombre, Activo", "", "IDVendedor", "Nombre", "IDVendedor")
        CargagridSearchLookUp(Me.SearchLookUpEditTipoEntrega, "fafTipoEntrega", "IDTipoEntrega, Descr, Activo", "", "IDTipoEntrega", "Descr", "IDTipoEntrega")
        CargagridSearchLookUp(Me.SearchLookUpEditNivel, "fafNivelPrecio", "IDNivel, Descr, Activo", "", "IDNivel", "Descr", "IDNivel")
        CargagridSearchLookUp(Me.SearchLookUpEditMoneda, "globalMoneda", "IDMoneda, Descr, Activo", "", "IDMoneda", "Descr", "IDMoneda")
        'CargagridSearchLookUp(Me.SearchLookUpEditProducto, "invProducto", "IDProducto, Descr, Activo", "", "IDProducto", "Descr", "IDProducto")
        Me.DateEditFecha.EditValue = Date.Now
        Me.txtTipoCambio.EditValue = getTipoCambio(Me.DateEditFecha.EditValue, gParametros.TipoCambioFact)
        Me.SearchLookUpEditSucursal.EditValue = gsSucursal
        gsIDBodega = gsSucursal
        Me.SearchLookUpEditSucursal.ReadOnly = True
        If gParametros.DefaultTipoFact Then
            Me.SearchLookUpEditTipoFact.EditValue = gParametros.TipoFactDefault
        End If
        If gParametros.DefaultTipoEntrega Then
            Me.SearchLookUpEditTipoEntrega.EditValue = gParametros.TipoEntregaDefault
        End If
    End Sub
    Private Sub btnPedidos_Click(sender As Object, e As EventArgs) Handles btnPedidos.Click
        Try
            If MessageBox.Show("Ud. va a generar una factura que proviene de un Pedido. Esta de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                gbUsaPedido = True
                Dim frm As New frmAutorizaPedido()
                frm.gbAutoriza = False
                frm.gbPuedeCrearFactura = True
                frm.ShowDialog()
                If frm.gbPedidoParaFactura = False Then
                    frm.Dispose()
                    gbUsaPedido = False
                    Me.txtIDCliente.Text = ""
                    Me.txtNombre.Text = ""
                    Me.txtFarmacia.Text = ""
                    Me.MemoEditNota.Text = ""
                    Me.SearchLookUpEditVendedor.Text = ""
                    CreateFieldsToDataTable()
                    CargagridLookUpsFromTables()
                    CargaConsecutivo()
                    dtFacturaLinea.Clear()
                    dtFacturaLineaLote.Clear()
                    tableData.Clear()
                    ClearControlslinea()
                    ClearControlsTotales()
                    gbUsaPedido = False
                    Me.GridControl1.DataSource = Nothing
                    Exit Sub
                End If
                If frm.gsIDPedido = "" And frm.gsIDBodega = "" Then
                    frm.Dispose()
                    gbUsaPedido = False
                    Exit Sub
                End If
                If gParametros.EditaPrecioPedidoenFactura Then
                    txtPrecio.Enabled = True
                Else
                    txtPrecio.Enabled = False
                End If
                If gParametros.EditaCantidadPedidoenFactura Then
                    txtCantidad.Enabled = True
                Else
                    txtCantidad.Enabled = False
                End If
                gsPedidoID = frm.gsIDPedido
                gsIDBodega = frm.gsIDBodega
                Me.SearchLookUpEditSucursal.EditValue = CInt(gsIDBodega)
                Me.SearchLookUpEditNivel.EditValue = frm.gsIDNivel
                Me.SearchLookUpEditMoneda.EditValue = frm.gsIDMoneda
                Me.SearchLookUpEditPlazo.EditValue = frm.gsIDPlazo
                ' GetImpuestoDescuentoEspecialPrecio()
                ' Cargar el Pedido seleccionadoº
                RefreshGrid()
                TotalizaGrid()
                frm.Dispose()



                If gsPedidoID <> "" And gsIDBodega <> "" Then
                    gbUsaPedido = True
                Else
                    gbUsaPedido = False
                End If
            Else
                gbUsaPedido = False
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al cargar el Pedido " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            gbUsaPedido = False
        End Try
    End Sub


    Sub RefreshGridFromPedido()
        Try
            If gbUsaPedido Then
                If gsPedidoID <> "" Then
                    Dim sParameters As String = gsPedidoID & "," & gsIDBodega & ",null, null,  'A'," & "0"
                    tableData = cManager.ExecSPgetData("fafgetPedido", sParameters)
                    If tableData.Rows.Count > 0 Then
                        dtFacturaLinea.Clear()
                        dtFacturaLineaLote.Clear()
                        Me.SearchLookUpEditSucursal.EditValue = CInt(tableData.Rows(0)("IDBodega"))
                        Me.SearchLookUpEditVendedor.EditValue = CInt(tableData.Rows(0)("IDVendedor"))
                        Me.SearchLookUpEditTipoEntrega.EditValue = CInt(tableData.Rows(0)("IDTipoEntrega"))
                        Me.txtIDCliente.EditValue = CInt(tableData.Rows(0)("IDCliente"))
                        Me.txtNombre.EditValue = tableData.Rows(0)("Nombre").ToString()
                        Me.txtFarmacia.EditValue = tableData.Rows(0)("Farmacia").ToString()
                        If CBool(tableData.Rows(0)("EsTeleventa")) = True Then
                            Me.CheckEditTeleVenta.EditValue = CBool(tableData.Rows(0)("EsTeleventa"))
                        End If

                        FillTableFacturalinea()
                        If dtFacturaLinea.Rows.Count > 0 Then
                            GridControl1.DataSource = dtFacturaLinea
                            GridControl1.Refresh()
                        End If
                    End If
                End If
                gbUsaPedido = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Sub RefreshGrid()
        Try
            If gbUsaPedido Then
                If gsPedidoID <> "" Then
                    Dim sParameters As String = gsPedidoID & "," & gsIDBodega & ",null, null,  'A'," & "0"
                    tableData = cManager.ExecSPgetData("fafgetPedido", sParameters)
                    If tableData.Rows.Count > 0 Then
                        dtFacturaLinea.Clear()
                        dtFacturaLineaLote.Clear()
                        Me.SearchLookUpEditSucursal.EditValue = CInt(tableData.Rows(0)("IDBodega"))
                        Me.SearchLookUpEditVendedor.EditValue = CInt(tableData.Rows(0)("IDVendedor"))
                        Me.SearchLookUpEditTipoEntrega.EditValue = CInt(tableData.Rows(0)("IDTipoEntrega"))
                        Me.txtIDCliente.EditValue = CInt(tableData.Rows(0)("IDCliente"))
                        Me.txtNombre.EditValue = tableData.Rows(0)("Nombre").ToString()
                        Me.txtFarmacia.EditValue = tableData.Rows(0)("Farmacia").ToString()
                        If CBool(tableData.Rows(0)("EsTeleventa")) = True Then
                            Me.CheckEditTeleVenta.EditValue = CBool(tableData.Rows(0)("EsTeleventa"))
                        End If

                        FillTableFacturalinea()
                        If dtFacturaLinea.Rows.Count > 0 Then
                            GridControl1.DataSource = dtFacturaLinea
                            GridControl1.Refresh()
                        End If
                    End If
                End If
                gbUsaPedido = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub
    Sub AssignFieldsToGrid()
        Me.GridViewProducto.Columns.AddField("LoteAsignado")
        Me.GridViewProducto.Columns(0).Caption = "√"

        Me.GridViewProducto.Columns(0).Visible = True
        Me.GridViewProducto.Columns(0).Width = 25
        Me.GridViewProducto.Columns.AddField("Descr")
        Me.GridViewProducto.Columns(1).Width = 200
        Me.GridViewProducto.Columns(1).Caption = "Producto"
        Me.GridViewProducto.Columns(1).Visible = True
        Me.GridViewProducto.Columns.AddField("Cantidad")
        Me.GridViewProducto.Columns(2).Visible = True
        Me.GridViewProducto.Columns(2).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(2).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns.AddField("Precio")
        Me.GridViewProducto.Columns(3).Caption = "Precio"
        Me.GridViewProducto.Columns(3).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(3).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(3).Visible = True

        Me.GridViewProducto.Columns.AddField("Descuento")
        Me.GridViewProducto.Columns(4).Caption = "Descuento"
        Me.GridViewProducto.Columns(4).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(4).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(4).Visible = True

        Me.GridViewProducto.Columns.AddField("DescuentoEspecial")
        Me.GridViewProducto.Columns(5).Caption = "DescEsp"
        Me.GridViewProducto.Columns(5).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(5).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(5).Visible = True


        Me.GridViewProducto.Columns.AddField("Impuesto")
        Me.GridViewProducto.Columns(6).Visible = True
        Me.GridViewProducto.Columns(6).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(6).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns.AddField("SubTotal")
        Me.GridViewProducto.Columns(7).Visible = True
        Me.GridViewProducto.Columns(7).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(7).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("Bonifica")
        Me.GridViewProducto.Columns(8).Visible = False

        Me.GridViewProducto.Columns.AddField("BonifConProd")
        Me.GridViewProducto.Columns(9).Visible = False
        'Me.GridViewProducto.Columns.AddField("LoteAsignado")
        'Me.GridViewProducto.Columns(6).DisplayFormat.FormatString = "yn"
        'Me.GridViewProducto.Columns(6).Visible = False
        Me.GridViewProducto.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewProducto.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewProducto.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewProducto.Columns(3).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewProducto.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewProducto.Columns(4).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewProducto.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewProducto.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

    End Sub
    Private Function getTipoCambio(dFecha As Date, sIDTipoCambio As String) As Decimal
        Try
            '  Dim cManager As New Clases.ClassManagerCDate(Me.DateEditFecha.EditValue).ToString("yyyyMMdd")
            Dim t As DataTable
            Dim sParameter As String
            sParameter = "'" & dFecha.ToString("yyyyMMdd") & "','" & sIDTipoCambio & "'"
            t = cManager.ExecFunction("globalGetLastTipoCambio", sParameter)
            Return t.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
            MessageBox.Show("Error al Obtener el Tipo de Cambio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Sub frmFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                CallPopUpProducto()
            Case Keys.F2
                AgregaProducto()
            Case Keys.F3
                CallPopUpClientes()
            Case Keys.F4
                NuevoProducto()
            Case Keys.F6
                EliminaItem()
            Case Keys.F10
                GrabarFactura()
        End Select


    End Sub
    Private Sub frmFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CreateFieldsToDataTable()
            'AssignFieldsToGrid()
            CargagridLookUpsFromTables()
            CargaConsecutivo()
            FormattextNumbers()
            RefreshGrid()

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al cargar los datos de Factura " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub CargaConsecutivo()
        Dim sParameters As String
        Dim td As New DataTable
        sParameters = "'" & gsConsecMask & "'"
        td = cManager.ExecFunction("getNextConsecMask", sParameters)
        If td.Rows.Count <= 0 Then
            MessageBox.Show("No existe un Consecutivo con Mascara para la Factura, por favor llamar al Adminstrador del Sistema ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.txtFactura.EditValue = td.Rows(0)(0)
        td = cManager.ExecFunction("getMascaraFromConsecMask", sParameters)
        gsMascara = td.Rows(0)(0)


    End Sub
    Private Sub GridViewProducto_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridViewProducto.RowCellStyle
        Dim view As GridView = sender

        If e.Column.FieldName = "LoteAsignado" Then
            Dim sConlote As String = (view.GetRowCellDisplayText(e.RowHandle, view.Columns("LoteAsignado")))
            If UCase(sConlote) = UCase("NO SELECCIONADO") Then
                e.Appearance.BackColor = Color.Bisque
            End If
        End If
    End Sub

    'Sub(sender, e)
    '    Dim view As GridView = TryCast(sender, GridView)
    '    Dim _mark As Boolean = CBool(View.GetRowCellValue(e.RowHandle, "Mark"))
    '    If e.Column.FieldName = "Name" Then
    '        e.Appearance.BackColor = If(_mark, Color.LightGreen, Color.LightSalmon)
    '        e.Appearance.TextOptions.HAlignment = If(_mark, HorzAlignment.Far, HorzAlignment.Near)
    '    End If
    'End Sub

    Private Sub TotalizaGrid()
        If dtFacturaLinea.Rows.Count > 0 Then
            Dim SubTotal As Decimal = dtFacturaLinea.Compute("Sum(SubTotal)", "") 'Convert.ToDecimal(tableData.AsEnumerable().Sum(Function(row) row.Field(Of String)("SubTotal")))
            Dim Impuesto As Decimal = dtFacturaLinea.Compute("Sum(Impuesto)", "") 'Convert.ToDouble(tableData.AsEnumerable().Sum(Function(row) row.Field(Of String)("Impuesto")))
            Dim Descuento As Decimal = dtFacturaLinea.Compute("Sum(Descuento)", "")
            Dim DescuentoEsp As Decimal = dtFacturaLinea.Compute("Sum(DescuentoEspecial)", "")
            Me.txtSubTotal.EditValue = SubTotal
            Me.txtSubTotalFinal.EditValue = (SubTotal - Descuento - DescuentoEsp)
            Me.txtIGV.EditValue = Impuesto
            Me.txtTotal.EditValue = (SubTotal - Descuento - DescuentoEsp) + Impuesto
            Me.txtDcto.EditValue = Descuento
            Me.txtDctoEsp.EditValue = DescuentoEsp

        Else
            Me.txtSubTotal.EditValue = 0
            Me.txtIGV.EditValue = 0
            Me.txtDcto.EditValue = 0
            Me.txtDctoEsp.EditValue = 0
            Me.txtTotal.EditValue = 0
        End If

    End Sub

    Private Sub GridViewProducto_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProducto.FocusedRowChanged
        RefreshDataFromGridToControls()
    End Sub

    Private Sub FormattextNumbers()
        FormatControlNumber(txtCantidad)
        FormatControlNumber(txtImpuesto)
        FormatControlNumber(txtDescLinea)
        FormatControlNumber(txtDescEspLinea)
        FormatControlNumber(txtTotLinea)
        FormatControlNumber(txtPrecio)
        FormatControlNumber(txtSubTotal)
        FormatControlNumber(txtSubTotLin)
        FormatControlNumber(txtSubTotalFinalLin)
        FormatControlNumber(txtPorcDescEsp)
        FormatControlNumber(txtPorcImpt)
        FormatControlNumber(txtExistencia)
        FormatControlNumber(txtCantBonif)

    End Sub
    Private Sub RefreshDataFromGridToControls()
        Dim dr As DataRow = GridViewProducto.GetFocusedDataRow()
        currentRow = dr
        If dr IsNot Nothing Then
            Me.txtCodigo.Text = dr("IDProducto").ToString()

            Me.txtDescr.EditValue = dr("Descr")
            Me.txtCantidad.EditValue = dr("Cantidad") ' String.Format("{0:0.00}", dr("Cantidad"))
            Me.txtPorcImpt.EditValue = dr("PorcImp") ' String.Format("{0:0.00}", dr("PorcImp"))
            Me.txtImpuesto.EditValue = dr("Impuesto") ' String.Format("{0:0.00}", dr("Impuesto"))
            Me.txtDescLinea.EditValue = dr("CantBonificada") * dr("Precio") ' String.Format("{0:0.00}", dr("CantBonificada") * dr("Precio"))
            Me.txtDescEspLinea.EditValue = dr("DescuentoEspecial") ' String.Format("{0:0.00}", dr("DescuentoEspecial"))
            Me.txtCantBonif.EditValue = dr("CantBonificada") 'String.Format("{0:0.00}", dr("CantBonificada"))
            'FormatControlNumber(txtSubTotLin)
            'txtSubTotLin.Properties.DisplayFormat.FormatString = "#,###,##0.##"
            Me.txtSubTotLin.EditValue = dr("SubTotal") 'String.Format("{0:n2}", dr("SubTotal"))
            Me.txtSubTotalFinalLin.EditValue = dr("SubTotalFinal") ' String.Format("{0:0.00}", dr("SubTotalFinal")) ' CDec(dr("SubTotalFinal")).ToString("n2") ' String.Format("{0:0.00}", dr("SubTotalFinal"))


            'txtTotLinea.Properties.DisplayFormat.FormatString = "#,###,##0.##"
            Me.txtTotLinea.EditValue = dr("Total") 'String.Format("{0:0.00}", dr("Total"))
            Me.txtCostoPromLocal.EditValue = dr("CostoLocal") '  String.Format("{0:0.00}", dr("CostoLocal"))
            Me.txtCostoPromDolar.EditValue = dr("CostoDolar") 'String.Format("{0:0.00}", dr("CostoDolar"))
            Me.chkBonifica.Checked = Convert.ToBoolean(dr("Bonifica"))
            Me.chkBonificaProd.Checked = Convert.ToBoolean(dr("BonifConProd"))
            Me.txtPorcDescEsp.EditValue = dr("PorcDescuentoEsp") ' String.Format("{0:0.00}", dr("PorcDescuentoEsp"))
            Me.txtPrecio.EditValue = dr("Precio") ' String.Format("{0:0.00}", dr("Precio"))

            TotalizaGrid()
        End If
    End Sub

    Private Sub GridViewProducto_DoubleClick(sender As Object, e As EventArgs) Handles GridViewProducto.DoubleClick
        Dim row As DataRow = GridViewProducto.GetDataRow(GridViewProducto.GetSelectedRows()(0))
        Dim bVerLotesdePedido As Boolean = False
        If row IsNot Nothing Then


            If gbUsaPedido = True And Convert.ToBoolean(row("LoteAsignado")) = True Then

                If MessageBox.Show("Este producto ya tiene asignado sus lotes, Ud desea ver los lotes asignados o reasignar los lotes. Si Ud dice que SI solamente verá los lotes asignados, si dice NO se reasignarán los lotes ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    bVerLotesdePedido = True
                End If
            End If

            If (gbUsaPedido = True And Convert.ToBoolean(row("LoteAsignado")) = False) Or (gbUsaPedido And Convert.ToBoolean(row("LoteAsignado")) = True And bVerLotesdePedido = False) Then
                gsIDBodega = row.Item("IDBodega").ToString()
                gsIDProducto = row.Item("IDProducto").ToString()
                row("LoteAsignado") = False
                'BORRO LOS REGISTROS DE LOTE DEL PRODUCTO delete dtFacturaLineaLote.Clear() where producto = x
                Dim foundRows As DataRow() = dtFacturaLineaLote.Select("IDProducto =" & Me.txtCodigo.EditValue)
                If foundRows.Count > 0 Then

                    For Each foundrow In foundRows
                        foundrow.Delete()
                    Next foundrow
                End If

                PopUpAsignaLote(gsIDBodega, gsIDProducto, row.Item("Cantidad").ToString(), row.Item("Descr").ToString(), True, Me.txtCantBonif.EditValue, CBool(chkBonifica.EditValue), CBool(chkBonificaProd.EditValue))
                Exit Sub
            End If

            ' FACTURA SIN PEDIDO
            If gbUsaPedido = False And Convert.ToBoolean(row("LoteAsignado")) = True Then

                If MessageBox.Show("Este producto ya tiene asignado sus lotes, Ud desea ver los lotes asignados o reasignar los lotes. Si Ud dice que SI solamente verá los lotes asignados, si dice NO se reasignarán los lotes ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    bVerLotesdePedido = True
                End If
            End If
            If bVerLotesdePedido = False Then
                row("LoteAsignado") = False
                'BORRO LOS REGISTROS DE LOTE DEL PRODUCTO delete dtFacturaLineaLote.Clear() where producto = x
                Dim foundRows As DataRow() = dtFacturaLineaLote.Select("IDProducto =" & Me.txtCodigo.EditValue)
                If foundRows.Count > 0 Then

                    For Each foundrow In foundRows
                        foundrow.Delete()
                    Next foundrow
                End If
                PopUpAsignaLote(gsIDBodega, gsIDProducto, row.Item("Cantidad").ToString(), row.Item("Descr").ToString(), True, Me.txtCantBonif.EditValue)

                Return
            End If
            ' Solo para ver los lotes asignado de un producto provenga o no de un pedido
            If (bVerLotesdePedido And Convert.ToBoolean(row("LoteAsignado")) = True) Or (gbUsaPedido = False) Then
                gsIDBodega = row.Item("IDBodega").ToString()
                gsIDProducto = row.Item("IDProducto").ToString()
                PopUpAsignaLote(gsIDBodega, gsIDProducto, row.Item("Cantidad").ToString(), row.Item("Descr").ToString(), False)
                'Else
                '    MessageBox.Show("Ud no ha asignado los lotes a este producto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub PopUpAsignaLote(sBodega As String, sIDProducto As String, sCantidad As String, sDescr As String, bAsignaLotes As Boolean, Optional sCantBonifPedido As String = "", Optional bBonifica As Boolean = False, Optional bBonifConProd As Boolean = False)
        gsIDBodega = sBodega ' row.Item("IDBodega").ToString()
        gsIDProducto = sIDProducto '  row.Item("IDProducto").ToString()
        Dim frm As New frmAsignaLote()
        frm.gsIDBodega = gsIDBodega
        frm.gsIDProducto = gsIDProducto
        frm.gsCantidad = sCantidad  'row.Item("Cantidad").ToString()
        frm.gsDescr = sDescr ' row.Item("Descr").ToString()
        frm.gbAsignaLotes = bAsignaLotes
        frm.gsCantidadBonifPedido = sCantBonifPedido
        frm.gbBonifica = bBonifica
        frm.gbBonificaProd = bBonifConProd
        frm.ShowDialog()
        If frm.gbLotesAsignados = True Then
            gbLoteAsignado = frm.gbLotesAsignados
            gbBonifica = frm.gbBonifica
            gbBonifConProd = frm.gbBonificaProd
            chkBonifica.Checked = gbBonifica
            chkBonificaProd.Checked = gbBonifConProd
            gdTotalBonificado = frm.gdTotalBonificado
            ' nuevo el dia 14 de octubre18

            ' LIMPIAR dtFacturaLineaLote. CON EL ID DEL PRODUCTO
            'BORRO LOS REGISTROS DE LOTE DEL PRODUCTO delete dtFacturaLineaLote.Clear() where producto = x
            Dim foundRows As DataRow() = dtFacturaLineaLote.Select("IDProducto =" & Me.txtCodigo.EditValue)
            If foundRows.Count > 0 Then

                For Each foundrow In foundRows
                    foundrow.Delete()
                Next foundrow
            End If
            Dim bLoteAsignado As Boolean = False
            For Each row In frm.tableLotesAsignados.Rows
                If CDec(row("AsignadoFA")) > 0 Or CDec(row("AsignadoBO")) > 0 Then
                    dtFacturaLineaLote.Rows.Add(Convert.ToInt32(gsIDBodega), Convert.ToInt32(row("IDProducto")), Convert.ToInt32(row("IDLote")), Convert.ToDecimal(row("AsignadoFA")), Convert.ToDecimal(row("AsignadoBO")), (Convert.ToDecimal(row("AsignadoFA")) + Convert.ToDecimal(row("AsignadoBO"))), 0, 0, _
                                                row("Descr").ToString(), row("LoteInterno").ToString(), row("LoteProveedor").ToString(), _
                                                Convert.ToDateTime(row("FechaVencimiento")), Convert.ToDecimal(row("Existencia")), Convert.ToDecimal(row("AsignadoFA")), Convert.ToDecimal(row("AsignadoBO")))
                    bLoteAsignado = True
                    'FillTableFacturaLineaLote(frm.tableLotesAsignados)
                    'Me.tableData.ImportRow(row)
                    'MessageBox.Show(row("IDProducto").ToString() + " " + row("AsignadoFA").ToString() + " " + row("AsignadoBO").ToString())
                    'GridControl1.DataSource = tableData
                    'GridControl1.Refresh()
                End If
            Next
            If bLoteAsignado Then
                UpdateFieldsToGrid()
                Me.txtCantBonif.EditValue = gdTotalBonificado
                Me.txtDescLinea.EditValue = gdTotalBonificado * txtPrecio.EditValue
                TotalizaGrid()
            End If
        End If

        frm.Dispose()

    End Sub
    Private Sub DeleteRows(sBodega As String, sIDProducto As String)
        Dim strCriteria As String = "IDBodega=" + sBodega + " and IDProducto=" + sIDProducto
        Dim drSelect As DataRow() = tableData.Select(strCriteria)
        If drSelect.Length > 0 Then
            For Each drItem As DataRow In drSelect
                Dim nrow As DataRow = drItem
                tableData.Rows.Remove(nrow)
            Next
        End If
    End Sub

    Private Sub CallPopUpClientes()
        Try
            If Me.SearchLookUpEditSucursal.Text = "" Then
                MessageBox.Show("Debe seleccionar una sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If gsPedidoID <> "" And gsIDBodega <> "" And gbUsaPedido Then
                If MessageBox.Show("Previamente Ud cargo un pedido. Está seguro de ignorar la creacion de la factura a partir del Pedido  ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    dtFacturaLinea.Clear()
                    dtFacturaLineaLote.Clear()
                    tableData.Clear()
                    ClearControlslinea()
                    ClearControlsTotales()
                    gbUsaPedido = False
                Else
                    Exit Sub
                End If
            End If

            Dim frm As New frmPopupCliente()
            frm.gsIDSucursal = Me.SearchLookUpEditSucursal.EditValue.ToString()
            frm.ShowDialog()
            If frm.gsIDCliente <> "" Then
                Me.txtIDCliente.EditValue = frm.gsIDCliente
                Me.txtNombre.EditValue = frm.gsNombre
                Me.txtFarmacia.EditValue = frm.gsFarmacia
                Me.SearchLookUpEditVendedor.EditValue = CInt(frm.gsVendedor)
                Me.SearchLookUpEditNivel.EditValue = CInt(frm.gsIDNivel)
                Me.SearchLookUpEditMoneda.EditValue = CInt(frm.gsIDMoneda)
                Me.SearchLookUpEditPlazo.EditValue = CInt(frm.gsPlazo)
                gIDPlazo = CInt(frm.gsPlazo)
                gdPorcInteres = CDec(frm.gsPorcInteres)
                CalculaFechaVencimiento()
            End If
            frm.Dispose()

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al cargar los clientes " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        CallPopUpClientes()
    End Sub

    Private Sub CalculaFechaVencimiento()
        Me.DateEditVencimiento.EditValue = DateAdd(DateInterval.Day, CDbl(Me.SearchLookUpEditPlazo.EditValue), Me.DateEditFecha.EditValue)
        Me.DateEditVencimiento.Refresh()
    End Sub
    Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs) Handles txtCantidad.GotFocus
        txtCantidad.SelectionStart = 0
        txtCantidad.SelectionLength = txtCantidad.Text.Length
        txtCantidad.SelectAll()
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPrecio.Focus()

        End If
    End Sub

    Private Sub TrataLote()
        Try
            If gbUsaPedido Then
                MessageBox.Show("No se puede alterar la cantidad en un pedido ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            PopUpAsignaLote(Me.SearchLookUpEditSucursal.EditValue.ToString(), txtCodigo.EditValue.ToString(), txtCantidad.EditValue.ToString(), txtDescr.EditValue.ToString(), True, CBool(chkBonifica.EditValue), CBool(chkBonificaProd.EditValue))

            Me.txtDescEspLinea.EditValue = CDec(txtPorcDescEsp.EditValue) / 100 * CDec(txtCantidad.EditValue) * CDec(txtPrecio.EditValue)
            txtImpuesto.EditValue = CalculaImpuesto()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error en el proceso de Lotes " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        CallPopUpProducto()
    End Sub

    Private Sub CallPopUpProducto()
        Try

            If Not ControlsHeaderOk() Then
                MessageBox.Show("Por favor revise los datos de la Factura, existe un campo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If gbUsaPedido Then
                MessageBox.Show("No se puede alterar los productos en un en un pedido ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim frm As New frmPopupProducto()
            frm.ShowDialog()
            Me.txtCodigo.EditValue = frm.gsIDProducto
            Me.txtDescr.EditValue = frm.gsDescr
            Me.txtCostoPromLocal.EditValue = frm.gdCostoPromLocal
            Me.txtCostoPromDolar.EditValue = frm.gdCostoPromDolar

            gsIDProducto = txtCodigo.EditValue
            GetImpuestoDescuentoEspecialPrecio()
            txtCantidad.EditValue = ""
            Me.txtCantidad.Focus()
            frm.Dispose()

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al consultar el Precio " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetImpuestoDescuentoEspecialPrecio()
        Dim dPrecio As Decimal
        Dim t As DataTable
        't = cManager.ExecFunction("getPorcImpuestoFromProducto", txtCodigo.EditValue.ToString)
        'PorcImpuesto = t.Rows(0).Item(0)
        'txtPorcImpt.Text = PorcImpuesto.ToString("n2")

        '' para obtener el PorcDescuentoEspecial
        'Dim sparam As String = txtCodigo.EditValue.ToString() & ",'" & CDate(Me.DateEditFecha.EditValue).ToString("yyyyMMdd") & "'"
        't = cManager.ExecFunction("fafGetPorcDescuento", sparam)
        'Me.txtPorcDescEsp.EditValue = t.Rows(0).Item(0)

        GetPorcImuestoYDescuentoEspecial()
        ' para obtener el Precio
        Dim sParametros As String
        sParametros = txtIDCliente.Text & "," & Me.SearchLookUpEditNivel.EditValue.ToString() & "," & txtCodigo.Text & "," & Me.SearchLookUpEditMoneda.EditValue.ToString()
        t = cManager.ExecFunction("fafGetPrecio", sParametros)
        dPrecio = t.Rows(0).Item(0)
        txtPrecio.EditValue = dPrecio
    End Sub

    Private Sub GetPorcImuestoYDescuentoEspecial()
        Dim PorcImpuesto As Decimal
        Dim t As DataTable
        t = cManager.ExecFunction("getPorcImpuestoFromProducto", txtCodigo.EditValue.ToString)
        PorcImpuesto = t.Rows(0).Item(0)
        txtPorcImpt.EditValue = PorcImpuesto.ToString("n2")

        ' para obtener el PorcDescuentoEspecial
        Dim sparam As String = txtCodigo.EditValue.ToString() & ",'" & CDate(Me.DateEditFecha.EditValue).ToString("yyyyMMdd") & "'"
        t = cManager.ExecFunction("fafGetPorcDescuento", sparam)
        Me.txtPorcDescEsp.EditValue = t.Rows(0).Item(0)
    End Sub

    Private Sub UpdateFieldsToGrid()
        If dtFacturaLinea.Rows.Count > 0 Then
            Dim customerRow() As Data.DataRow
            customerRow = dtFacturaLinea.Select("IDProducto =" & gsIDProducto)
            If customerRow.Count > 0 Then
                customerRow(0)("LoteAsignado") = True
                currentRow("Bonifica") = gbBonifica
                currentRow("BonifConProd") = gbBonifConProd
                currentRow("Descuento") = gdTotalBonificado * CDec(txtPrecio.EditValue)
                Me.chkBonifica.Checked = gbBonifica
                Me.chkBonificaProd.Checked = gbBonifConProd

            End If
        End If
    End Sub


    Private Function ControlsHeaderOk() As Boolean
        Dim lbok As Boolean
        lbok = True
        If Not (Me.SearchLookUpEditSucursal.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.SearchLookUpEditTipoFact.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.SearchLookUpEditPlazo.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.txtIDCliente.Text IsNot Nothing Or txtNombre.Text IsNot Nothing) Then
            lbok = False
            Return lbok
        End If


        If Not (Me.SearchLookUpEditTipoEntrega.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.SearchLookUpEditVendedor.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.DateEditFecha.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.txtFactura.Text IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        Return lbok
    End Function
    Private Function ControlsDetalleOk() As Boolean
        Dim lbok As Boolean = True
        If txtCodigo.Text Is Nothing Or String.IsNullOrEmpty(txtCodigo.Text) Then
            lbok = False
            Return lbok
        End If
        If txtCantidad.Text Is Nothing Or String.IsNullOrEmpty(txtCantidad.Text) Then
            lbok = False
            Return lbok
        End If
        If txtPrecio.Text Is Nothing Or String.IsNullOrEmpty(txtCantidad.Text) Then
            lbok = False
            Return lbok
        End If
        If Val(txtCantidad.Text) <= 0 Or Val(txtPrecio.Text) <= 0 Then
            lbok = False
            Return lbok
        End If
        Return lbok
    End Function

    Sub AddDataToGrid()
        Try
            Dim r As DataRow = dtFacturaLinea.NewRow

            r("IDProducto") = Me.txtCodigo.EditValue  ' Me.SearchLookUpEditProducto.EditValue
            r("Descr") = Me.txtDescr.EditValue
            r("IDBodega") = Me.SearchLookUpEditSucursal.EditValue
            r("Cantidad") = Me.txtCantidad.EditValue
            r("Precio") = CDbl(Me.txtPrecio.EditValue)
            r("Impuesto") = CDbl(Me.txtImpuesto.EditValue)
            r("SubTotal") = CDbl(Me.txtPrecio.EditValue) * CDbl(txtCantidad.EditValue)
            r("PorcImp") = CDbl(txtPorcImpt.EditValue)

            r("Bonifica") = CBool(chkBonifica.Checked)
            r("BonifConProd") = CBool(chkBonificaProd.Checked)
            r("LoteASignado") = gbLoteAsignado
            r("DescuentoEspecial") = CDec(Me.txtDescEspLinea.EditValue)
            r("Descuento") = gdTotalBonificado * CDbl(txtPrecio.EditValue)
            r("CantFacturada") = CDec(r("Cantidad"))
            r("CantBonificada") = gdTotalBonificado
            r("CostoLocal") = CDec(Me.txtCostoPromLocal.EditValue)
            r("CostoDolar") = CDec(Me.txtCostoPromDolar.EditValue)
            r("PorcDescuentoEsp") = CDec(Me.txtPorcDescEsp.EditValue)
            r("SubTotalFinal") = CDec(r("SubTotal")) - CDec(r("Descuento")) - CDec(r("DescuentoEspecial"))
            r("Total") = CDec(r("SubTotalFinal")) + CDec(Me.txtImpuesto.EditValue)
            dtFacturaLinea.Rows.Add(r)
            Me.GridControl1.DataSource = Nothing
            Me.GridControl1.DataSource = dtFacturaLinea
            gbLoteAsignado = False
            gdTotalBonificado = 0
            iNumeroLineasFactura = iNumeroLineasFactura + 1
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try

    End Sub
    Private Sub AgregaProducto()
        Try
            If Not ControlsHeaderOk() Then
                MessageBox.Show("Por favor revise los datos de la Factura, existe un campo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Not ControlsDetalleOk() Then
                MessageBox.Show("Por favor revise los datos del producto, existe un campo incorrecto... revise Cantidad, Precio ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If iNumeroLineasFactura >= gParametros.NumeroLineasFact Then
                MessageBox.Show("El número máximo de lineas de una factura es " & gParametros.NumeroLineasFact.ToString() & " ... No puede agregar más lineas a la Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return

            End If

            TrataLote() ' se asignan los lotes
            If dtFacturaLinea.Rows.Count > 0 Then
                Dim foundRow() As DataRow
                foundRow = dtFacturaLinea.Select("IDProducto =" & Me.txtCodigo.EditValue.ToString())

                If foundRow IsNot Nothing And foundRow.Count > 0 Then
                    MessageBox.Show("Ese Producto ya Existe, por favor revise", "Advertencia", MessageBoxButtons.OK)
                    Return

                End If
            End If
            Me.txtDescLinea.EditValue = CDec(txtCantBonif.EditValue) * CDec(txtPrecio.EditValue)
            Me.txtSubTotLin.EditValue = CDec(Me.txtPrecio.EditValue) * CDec(txtCantidad.EditValue)
            txtSubTotalFinalLin.EditValue = Me.txtSubTotLin.EditValue - Me.txtDescLinea.EditValue - Me.txtDescEspLinea.EditValue
            txtImpuesto.EditValue = CalculaImpuesto()
            AddDataToGrid()

            If dtFacturaLinea.Rows.Count > 0 Then
                GridControl1.DataSource = dtFacturaLinea
                GridControl1.Refresh()
            End If
            TotalizaGrid()
            'Me.GridViewProducto.FocusedRowHandle
            GridViewProducto.MoveFirst()
            RefreshDataFromGridToControls()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al agregar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AgregaProducto()
    End Sub
    Private Function CalculaImpuesto() As Double
        Dim dImpuesto As Double = 0
        ' Me.txtSubTotalFinalLin.EditValue = Me.txtSubTotLin.EditValue - Me.txtDescLinea.EditValue - Me.txtDescEspLinea.EditValue
        'dImpuesto = CDbl(If(String.IsNullOrEmpty(Me.txtCantidad.Text), 0, Me.txtCantidad.Text)) * CDbl(If(String.IsNullOrEmpty(Me.txtPrecio.Text), 0, Me.txtPrecio.Text)) * CDbl(If(String.IsNullOrEmpty(Me.txtPorcImpt.Text), 0, Me.txtPorcImpt.Text)) / 100
        dImpuesto = CDbl(Me.txtSubTotalFinalLin.EditValue) * CDbl(If(String.IsNullOrEmpty(Me.txtPorcImpt.EditValue), 0, Me.txtPorcImpt.EditValue)) / 100
        'txtImpuesto.EditValue = dImpuesto
        Return dImpuesto
    End Function
    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtImpuesto.EditValue = CalculaImpuesto()
        End If
    End Sub

    Private Sub txtPrecio_EditValueChanged(sender As Object, e As EventArgs) Handles txtPrecio.EditValueChanged
        Dim strCriterio As String
        CalcDescuentoEspLinea()
        If Not IsNothing(txtCodigo.EditValue) Then
            strCriterio = "IDProducto = " & txtCodigo.EditValue.ToString()
            UpdateDataTableRowFacLin(strCriterio)
            TotalizaGrid()
        End If
    End Sub

    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        If txtCodigo.Text Is Nothing Or String.IsNullOrEmpty(txtCodigo.Text) Then
            Exit Sub
        End If
        txtImpuesto.EditValue = CalculaImpuesto()
    End Sub

    Private Sub CalculaDatosLineaFactura()
        If txtCantidad.Text <> "0" Then
            txtImpuesto.EditValue = CalculaImpuesto()
        End If
    End Sub

    Private Sub SearchLookUpEditSucursal_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEditSucursal.EditValueChanged
        gsIDBodega = SearchLookUpEditSucursal.EditValue.ToString()
    End Sub

    Private Sub NuevoProducto()
        Try
            If iNumeroLineasFactura >= gParametros.NumeroLineasFact Then
                MessageBox.Show("El número máximo de lineas de una factura es " & gParametros.NumeroLineasFact.ToString() & " ... No puede agregar más lineas a la Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return

            End If
            ClearControlslinea()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        NuevoProducto()
    End Sub
    Private Sub ClearControlslinea()
        Me.txtCodigo.EditValue = 0
        Me.txtDescr.Text = ""
        Me.chkBonifica.Checked = False
        Me.chkBonificaProd.Checked = False
        Me.txtCantidad.EditValue = 0
        Me.txtPorcImpt.EditValue = 0
        Me.txtIGV.EditValue = 0
        Me.txtImpuesto.EditValue = 0
        Me.txtPrecio.EditValue = 0
        Me.txtExistencia.EditValue = 0
        Me.txtSubTotLin.EditValue = 0
        Me.txtDescEspLinea.EditValue = 0
        Me.txtDescLinea.EditValue = 0
        Me.txtTotLinea.EditValue = 0
        Me.txtSubTotalFinalLin.EditValue = 0
        Me.txtPorcDescEsp.EditValue = 0
        Me.txtCantBonif.EditValue = 0
        Me.txtCostoPromLocal.EditValue = 0
        Me.txtCostoPromDolar.EditValue = 0
        Me.btnProducto.Focus()
    End Sub

    Private Sub ClearControlsTotales()
        Me.txtSubTotal.EditValue = 0
        Me.txtDcto.EditValue = 0
        txtDctoEsp.EditValue = 0
        txtSubTotalFinal.EditValue = 0
        txtIGV.EditValue = 0
        txtTotal.EditValue = 0
    End Sub
    Private Sub DateEditFecha_KeyUp(sender As Object, e As KeyEventArgs) Handles DateEditFecha.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            CalculaFechaVencimiento()
        End If
    End Sub

    Private Sub SearchLookUpEditTipoFact_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEditTipoFact.EditValueChanged
        If Me.SearchLookUpEditTipoFact.EditValue IsNot Nothing And SearchLookUpEditTipoFact.EditValue = 1 Then
            ' si la factura es de Contado
            Me.SearchLookUpEditPlazo.EditValue = gParametros.IDPlazoCont
        End If
        If Me.SearchLookUpEditTipoFact.EditValue IsNot Nothing And Me.SearchLookUpEditTipoFact.EditValue = 2 Then
            Me.SearchLookUpEditPlazo.EditValue = gIDPlazo
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        If Not CargaParametros() Then
            MessageBox.Show("No se han definido los Parámetros del Módulo de Facturación ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Return
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SearchLookUpEditPlazo_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEditPlazo.EditValueChanged
        If Me.SearchLookUpEditTipoFact.EditValue = 1 Then
            Me.SearchLookUpEditPlazo.EditValue = gParametros.IDPlazoCont
        End If
        If Me.SearchLookUpEditTipoFact.EditValue IsNot Nothing And Me.SearchLookUpEditTipoFact.EditValue = 2 Then
            Me.SearchLookUpEditPlazo.EditValue = gIDPlazo
        End If
        CalculaFechaVencimiento()
    End Sub

    Private Sub EliminaItem()
        Try
            If MessageBox.Show("Está seguro de eliminar el registro " & Me.txtDescr.EditValue, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbNo Then
                Exit Sub
            End If
            Dim foundRows As DataRow() = dtFacturaLineaLote.Select("IDProducto =" & Me.txtCodigo.Text)
            If foundRows.Count > 0 Then

                For Each foundrow In foundRows
                    foundrow.Delete()
                Next foundrow
            End If

            Dim foundRowsLin As DataRow() = dtFacturaLinea.Select("IDProducto =" & Me.txtCodigo.Text)
            If foundRowsLin.Count > 0 Then

                For Each foundrow In foundRowsLin
                    foundrow.Delete()
                Next foundrow
            End If
            If iNumeroLineasFactura > 0 Then
                iNumeroLineasFactura = iNumeroLineasFactura - 1
            End If
            dtFacturaLineaLote.AcceptChanges()
            dtFacturaLinea.AcceptChanges()
            ClearControlslinea()
            RefreshDataFromGridToControls()
            TotalizaGrid()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al eliminar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtFacturaLineaLote.RejectChanges()
            dtFacturaLinea.RejectChanges()
        End Try


    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        EliminaItem()
    End Sub

    Private Sub GrabarFactura()
        Dim sSql As String
        Dim sParameters As String
        Dim dPrecioLocal As Decimal, dPrecioDolar As Decimal, dImpuestoLocal As Decimal, dImpuestoDolar As Decimal, dSubTotalLocal As Decimal, dSubTotalDolar As Decimal
        Dim dSubTotalFinalLocal As Decimal, dSubTotalFinalDolar As Decimal
        Try

            If Not IsMaskOK(gsMascara, Me.txtFactura.EditValue) Then
                Me.txtFactura.Focus()
                Return
            End If

            If cManager.ExistsInTable("fafFactura", "Factura", "Factura='" & txtFactura.EditValue.ToString() & "' and IDBodega = " & gsIDBodega, "Factura") Then
                MessageBox.Show("Por favor revise los datos de la Factura, esa Factura ya Existe en la base de datos para esa bodega", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If Not ControlsHeaderOk() Then
                MessageBox.Show("Por favor revise los datos de la Factura, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.SearchLookUpEditSucursal.Focus()
                Return
            End If
            If dtFacturaLinea.Rows.Count <= 0 Then
                MessageBox.Show("No Existen productos grabados para la Factura, favor revise", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If dtFacturaLinea.Rows.Count > 0 Then
                Dim foundRow() As DataRow
                foundRow = dtFacturaLinea.Select("LoteAsignado=0")

                If foundRow IsNot Nothing And foundRow.Count > 0 Then
                    MessageBox.Show("Existe al menos un Producto al que Ud no ha asignado los lotes correspondientes, por favor revise", "Advertencia", MessageBoxButtons.OK)
                    Return

                End If
            End If
            If dtFacturaLineaLote.Rows.Count <= 0 Then
                MessageBox.Show("No Existen Lotes productos grabados para la Factura, favor revise", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If Not gsPedidoID IsNot Nothing Then
                gsPedidoID = "null"
            End If
            If Not MemoEditNota.EditValue IsNot Nothing Then
                MemoEditNota.EditValue = " "
            End If
            ' Preparando los datos de la cabecera 
            sParameters = "'I'," & Me.SearchLookUpEditSucursal.EditValue.ToString() & ",'" & Me.txtFactura.Text & "'," & Me.SearchLookUpEditTipoFact.EditValue.ToString() & ", " & _
                Me.txtIDCliente.Text & ",'" & txtNombre.EditValue.ToString() & "'," & Me.SearchLookUpEditVendedor.EditValue.ToString() & "," & Me.SearchLookUpEditTipoEntrega.EditValue.ToString() & ", '" & _
                CDate(Me.DateEditFecha.EditValue).ToString("yyyyMMdd") & "',0," & IIf(Me.CheckEditTeleVenta.EditValue = True, "1", "0") & "," & gsPedidoID & "," & _
                Me.SearchLookUpEditNivel.EditValue.ToString() & "," & Me.SearchLookUpEditMoneda.EditValue.ToString() & "," & Me.SearchLookUpEditPlazo.EditValue.ToString() & "," & _
                Me.txtTipoCambio.EditValue.ToString() & ",'" & gsConsecMask & "','" & MemoEditNota.EditValue.ToString() & "'"

            'creando la instruccion de insercion en la cabecera
            sSql = cManager.CreateStoreProcSql("fafUpdateFactura", sParameters)
            Dim clase As New CbatchSQLIitem(sSql, True, False, True, False, "fafUpdateFactura", "fafUpdateFactura")
            cManager.batchSQLLista.Add(clase)
            cManager.batchSQLitem.Clear()
            cManager.batchSQLitem.Add(sSql)

            ' REcorrer las lineas de la Factura a nivel de Producto 
            Dim lbEsMonedaLocal As Boolean = EsMonedaLocal(CInt(Me.SearchLookUpEditMoneda.EditValue))
            Dim dPorcImp As Decimal
            Dim dPorcDescuentoEsp As Decimal = 0, dCostoLocal As Decimal = 0, dCostoDolar As Decimal, dDescuentoLocal As Decimal, dDescuentoDolar As Decimal, dDescuentoEspLocal As Decimal, dDescuentoEspDolar As Decimal
            For Each dr In dtFacturaLinea.Rows

                If lbEsMonedaLocal Then
                    dPrecioLocal = CDec(dr("Precio"))
                    dPrecioDolar = CDec(dr("Precio")) / CDec(txtTipoCambio.EditValue)
                    dImpuestoLocal = CDec(dr("Impuesto"))
                    dImpuestoDolar = CDec(dr("Impuesto")) / CDec(txtTipoCambio.EditValue)
                    dSubTotalLocal = CDec(dr("SubTotal"))
                    dSubTotalDolar = CDec(dr("SubTotal")) / CDec(txtTipoCambio.EditValue)
                    dDescuentoLocal = CDec(dr("Descuento"))
                    dDescuentoDolar = CDec(dr("Descuento")) / CDec(txtTipoCambio.EditValue)
                    dDescuentoEspLocal = CDec(dr("DescuentoEspecial"))
                    dDescuentoEspDolar = CDec(dr("DescuentoEspecial")) / CDec(txtTipoCambio.EditValue)
                    dSubTotalFinalLocal = CDec(dr("SubTotalFinal"))
                    dSubTotalFinalDolar = CDec(dr("SubTotalFinal")) / CDec(txtTipoCambio.EditValue)
                Else
                    dPrecioDolar = CDec(dr("Precio"))
                    dPrecioLocal = CDec(dr("Precio")) * CDec(txtTipoCambio.EditValue)
                    dImpuestoDolar = CDec(dr("Impuesto"))
                    dImpuestoLocal = CDec(dr("Impuesto")) * CDec(txtTipoCambio.EditValue)
                    dSubTotalDolar = CDec(dr("SubTotal"))
                    dSubTotalLocal = CDec(dr("SubTotal")) * CDec(txtTipoCambio.EditValue)
                    dDescuentoDolar = CDec(dr("Descuento"))
                    dDescuentoLocal = CDec(dr("Descuento")) * CDec(txtTipoCambio.EditValue)
                    dDescuentoEspDolar = CDec(dr("DescuentoEspecial"))
                    dDescuentoEspLocal = CDec(dr("DescuentoEspecial")) * CDec(txtTipoCambio.EditValue)
                    dSubTotalFinalDolar = CDec(dr("SubTotalFinal"))
                    dSubTotalFinalLocal = CDec(dr("SubTotalFinal")) * CDec(txtTipoCambio.EditValue)
                End If
                dPorcImp = CDec(dr("PorcImp"))
                dPorcDescuentoEsp = CDec(dr("PorcDescuentoEsp"))
                sParameters = "'I'" & ",@@Identity" & "," & Me.SearchLookUpEditSucursal.EditValue.ToString() & "," & dr("IDProducto").ToString() & "," & _
                    IIf(CBool(dr("Bonifica")) = True, "1", "0") & ",0,0," & IIf(CBool(dr("BonifConProd")) = True, "1", "0") & "," & dr("CantBonificada").ToString() & "," & dr("CantFacturada").ToString() & "," & _
                dPrecioLocal.ToString() & "," & dPrecioDolar.ToString() & "," & dCostoLocal.ToString() & "," & dCostoDolar.ToString() & "," & _
                dDescuentoLocal.ToString() & "," & dDescuentoDolar.ToString() & "," & dDescuentoEspLocal.ToString() & "," & dDescuentoEspDolar.ToString() & "," & _
                dSubTotalLocal.ToString() & "," & dSubTotalDolar.ToString() & "," & dSubTotalFinalLocal.ToString() & "," & dSubTotalFinalDolar.ToString() & "," & dImpuestoLocal.ToString() & "," & dImpuestoDolar.ToString() & ", 1," & dPorcDescuentoEsp.ToString() & "," & dPorcImp.ToString()

                sSql = cManager.CreateStoreProcSql("fafUpdateFacturaProd", sParameters)
                clase = New CbatchSQLIitem(sSql, True, True, True, True, "fafUpdateFactura", "fafUpdateFacturaProd")

                cManager.batchSQLitem.Add(sSql)
                cManager.batchSQLLista.Add(clase)
                ' REcorrer las lineas de los productos  a nivel de Lotes asignados
                Dim foundRowLotes = dtFacturaLineaLote.Select("IDProducto=" & dr("IDProducto").ToString())
                For Each drl In foundRowLotes
                    sParameters = "'I'" & ",@@Identity" & "," & drl("IDLote").ToString() & "," & drl("CantBonificada").ToString() & "," & drl("CantFacturada").ToString()
                    sSql = cManager.CreateStoreProcSql("fafUpdateFacturaProdLote", sParameters)
                    clase = New CbatchSQLIitem(sSql, False, True, False, True, "fafUpdateFacturaProd", "fafUpdateFacturaProdLote")

                    cManager.batchSQLitem.Add(sSql)
                    cManager.batchSQLLista.Add(clase)
                Next drl
            Next dr

            ' Actualizo el valor del consecutivo de la factura
            sSql = cManager.CreateUpdateSql("globalConsecMask", "CONSECUTIVO ='" & Me.txtFactura.EditValue.ToString() & "'", "Codigo='" & gsConsecMask & "'")
            clase = New CbatchSQLIitem(sSql, False, False, False, False, "", "")
            cManager.batchSQLitem.Add(sSql)
            cManager.batchSQLLista.Add(clase)
            ' si la factura es de Credito 
            If UCase(Me.SearchLookUpEditTipoFact.GetSelectedDataRow(1).ToString) = "CREDITO" Then
                'creando la instruccion de insercion en la cartera Documento CC
                Dim dDiasVencimiento As Integer
                Dim iIDDocumento As Integer = 0
                dDiasVencimiento = DateDiff(DateInterval.Day, Me.DateEditFecha.EditValue, Me.DateEditVencimiento.EditValue)

                sParameters = "'I'," & " -1 , " & Me.txtIDCliente.EditValue.ToString & "," & Me.SearchLookUpEditSucursal.EditValue.ToString() & ","
                sParameters = sParameters & "'D','FAC', 1, '" & Me.txtFactura.Text & "','" & CDate(Me.DateEditFecha.EditValue).ToString("yyyyMMdd") & "'," & dDiasVencimiento.ToString() & ","
                sParameters = sParameters & txtTotal.EditValue.ToString() & "," & gdPorcInteres & ", 'FACTURA DE CREDITO','FACTURA DE CREDITO'" & ","
                sParameters = sParameters & "'" & txtNombre.EditValue.ToString() & "','" & gsUsuario & "'," & txtTipoCambio.EditValue.ToString()
                sSql = cManager.CreateStoreProcSql("ccfUpdateccfDocumentosCC", sParameters)
                clase = New CbatchSQLIitem(sSql, False, False, False, False, "ccfUpdateccfDocumentosCC", "ccfUpdateccfDocumentosCC")
                cManager.batchSQLLista.Add(clase)
                cManager.batchSQLitem.Clear()
                cManager.batchSQLitem.Add(sSql)

            End If
            If cManager.ExecCmdWithTransaction() Then
                Me.btnAdd.Enabled = False
                Me.btnSave.Enabled = False
                cManager.Update("fafPedido", "Estado = 'F'", " IDPedido = " & gsPedidoID & " and IDBodega = " & gsIDBodega)
                ' Actualizar Bitacora de Precios y Precios Cliente
                sParameters = cManager.IDAutoFirstParent.ToString() & ",'" & gsUsuario & "'"
                cManager.ExecSP("fafUpdateBitacoraPrecio", sParameters)
                MessageBox.Show("La Factura ha sido Guardada Exitosamente la factura con ID " & cManager.IDAutoFirstParent.ToString(), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                PrintReport(cManager.IDAutoFirstParent)
                Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al Guardar la Factura " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        GrabarFactura()
    End Sub



    Private Sub txtFactura_LostFocus(sender As Object, e As EventArgs) Handles txtFactura.LostFocus
        If Not IsMaskOK(gsMascara, Me.txtFactura.EditValue) Then
            Me.SearchLookUpEditVendedor.Focus()
        End If
    End Sub

    Private Sub CalcDescuentoEspecial()
        Me.txtDescEspLinea.EditValue = CDec(txtPorcDescEsp.EditValue) / 100 * CDec(txtCantidad.EditValue) * CDec(txtPrecio.EditValue)
    End Sub


    Private Sub txtCantidad_EditValueChanged(sender As Object, e As EventArgs) Handles txtCantidad.EditValueChanged
        CalcDescuentoEspLinea()

    End Sub


    Private Sub CalcDescuentoEspLinea()
        Me.txtDescLinea.EditValue = CDec(IIf(Me.txtCantBonif.Text = "", 0, Me.txtCantBonif.Text)) * CDec(IIf(Me.txtPrecio.Text = "", 0, Me.txtPrecio.Text))
        Me.txtDescEspLinea.EditValue = CDec(IIf(Me.txtPorcDescEsp.Text = "", 0, Me.txtPorcDescEsp.Text)) / 100 * CDec(IIf(Me.txtCantidad.Text = "", 0, Me.txtCantidad.Text)) * CDec(IIf(Me.txtPrecio.Text = "", 0, Me.txtPrecio.Text))
        'Me.txtDescEspLinea.Text = String.Format("{0:0.00}", txtDescEspLinea.EditValue)
        Me.txtSubTotLin.EditValue = CDbl(IIf(Me.txtPrecio.Text = "", 0, Me.txtPrecio.Text)) * CDbl(IIf(Me.txtCantidad.Text = "", 0, Me.txtCantidad.Text))

        Me.txtSubTotalFinalLin.EditValue = Me.txtSubTotLin.EditValue - Me.txtDescLinea.EditValue - Me.txtDescEspLinea.EditValue
        txtImpuesto.EditValue = CalculaImpuesto()
        Me.txtTotLinea.EditValue = Me.txtSubTotalFinalLin.EditValue + txtImpuesto.EditValue
    End Sub

    Private Sub txtSubTotalFinalLin_EditValueChanged(sender As Object, e As EventArgs)
        txtImpuesto.EditValue = CalculaImpuesto()
        txtImpuesto.Refresh()
    End Sub

    Private Sub DateEditFecha_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditFecha.EditValueChanged
        CalculaFechaVencimiento()
    End Sub

    Private Sub PrintReport(pIDFactura As Int64)
        tableData = cManager.ExecSPgetData("fafPrintFacturaLote", pIDFactura.ToString())
        If tableData.Rows.Count > 0 Then

            Dim report As DevExpress.XtraReports.UI.XtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptFacturaV2.repx", True)
            report.DataSource = vbNull
            report.DataSource = tableData
            report.DataMember = "fafPrintFacturaLote"
            If gParametros.FacturaPersonalizada Then
                report.PaperKind = System.Drawing.Printing.PaperKind.Custom
                report.ReportUnit = ReportUnit.TenthsOfAMillimeter
                report.PageHeight = gParametros.paginaFacturaAltura * 100
                report.PageWidth = gParametros.paginaFacturaAncho * 100
            Else
                report.PaperKind = System.Drawing.Printing.PaperKind.Letter
            End If
            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        End If
    End Sub


    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim strCriteria As String

        If Asc(e.KeyChar) = Keys.Return Then
            If txtCodigo.EditValue.ToString() <> "" Then
                strCriteria = "IDProducto=" & txtCodigo.Text
                tableData = cManager.GetDataTable("invProducto", "IDProducto, Descr", strCriteria, "IDProducto")

                If tableData.Rows.Count > 0 Then
                    txtDescr.EditValue = tableData.Rows(0)(1)
                    txtCantidad.Focus()
                End If
            End If
        End If
    End Sub



    Private Sub txtIDCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDCliente.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Return Then

                If gsIDBodega = "" Then
                    MessageBox.Show("Debe seleccionar una sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If gsPedidoID <> "" And gsIDBodega <> "" And gbUsaPedido Then
                    If MessageBox.Show("Previamente Ud cargo un pedido. Está seguro de ignorar la creacion de la factura a partir del Pedido  ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        dtFacturaLinea.Clear()
                        dtFacturaLineaLote.Clear()
                        tableData.Clear()
                        ClearControlslinea()
                        ClearControlsTotales()
                        gbUsaPedido = False
                    Else
                        Exit Sub
                    End If
                End If


                If txtIDCliente.EditValue.ToString() <> "" Then
                    tableData = cManager.ExecSPgetData("fafgetClientes", txtIDCliente.EditValue.ToString() & "," & gsSucursal)

                    If tableData.Rows.Count > 0 Then
                        Me.txtIDCliente.EditValue = txtIDCliente.EditValue.ToString()
                        Me.txtNombre.EditValue = tableData.Rows(0)("Nombre")
                        Me.txtFarmacia.EditValue = tableData.Rows(0)("Farmacia")
                        Me.SearchLookUpEditVendedor.EditValue = CInt(tableData.Rows(0)("IDVendedor"))
                        Me.SearchLookUpEditNivel.EditValue = CInt(tableData.Rows(0)("IDNivel"))
                        Me.SearchLookUpEditMoneda.EditValue = CInt(tableData.Rows(0)("IDMoneda"))
                        Me.SearchLookUpEditPlazo.EditValue = CInt(tableData.Rows(0)("Plazo"))
                        gIDPlazo = CInt(tableData.Rows(0)("Plazo"))
                        gdPorcInteres = CDec(tableData.Rows(0)("Plazo"))
                        CalculaFechaVencimiento()
                    Else
                        MessageBox.Show("No existe ningun Cliente con el codigo digitado  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al carga el cliente " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


End Class