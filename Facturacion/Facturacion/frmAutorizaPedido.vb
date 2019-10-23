Imports Clases
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.GridView
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class frmAutorizaPedido
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Dim currentRow As DataRow

    Dim sVerPedidos As String = ""
    Dim sEstadoPedido As String = ""
    Public gbAutoriza As Boolean = True
    Public gbPuedeCrearFactura As Boolean = False
    Public gsIDPedido As String = ""
    Public gsIDBodega As String = ""
    Public gsIDCliente As String = ""
    Public gsFarmacia As String = ""
    Public gsIDVendedor As String = ""
    Public gsIDNivel As String = ""
    Public gsIDMoneda As String = ""
    Public gsIDPlazo As String = ""
    Public gbPedidoParaFactura As Boolean = False
    Dim bNacional As Boolean = False

    Private Sub frmAutorizaPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' si quisiera mostar en la moneda del pedido= CBool(tableData.Rows(0)("Nacional"))
        bNacional = True ' Fuerzo a que solo vean pedidos en cordobas
        Me.DateEditHasta.EditValue = DateTime.Now
        Me.DateEditDesde.Refresh()
        Me.DateEditHasta.Refresh()
        FormatControlNumber(txtCantidad)
        FormatControlNumber(txtCantBonif)
        FormatControlNumber(txtPrecio)
        FormatControlNumber(txtPorcDescEsp)
        FormatControlNumber(txtDescuentoEsp)
        gbPedidoParaFactura = False
        If gbAutoriza = True Then
            Me.btnAnular.Enabled = True
            Me.btnAprobar.Enabled = True
            Me.btnFactura.Enabled = False
            Me.rbTodos.Enabled = True
            Me.rbtDenegados.Enabled = True
            Me.btnActivaDenegado.Enabled = True
            Me.btnDenegar.Enabled = True
            Me.rbSoloCreados.Enabled = True
            Me.rbSoloCreados.Checked = True
            txtCantidad.Enabled = True
            txtCantBonif.Enabled = True
            txtPrecio.Enabled = True
            chkBonifica.Enabled = True
            chkBonifProd.Enabled = True
            cmdAplicar.Enabled = True
        Else
            txtCantidad.Enabled = False
            txtCantBonif.Enabled = False
            txtPrecio.Enabled = False
            chkBonifica.Enabled = False
            chkBonifProd.Enabled = False
            cmdAplicar.Enabled = False
            Me.rbtDenegados.Enabled = False
            Me.btnActivaDenegado.Enabled = False
            Me.btnDenegar.Enabled = False

            Me.btnAnular.Enabled = False
            Me.btnAprobar.Enabled = False
            Me.btnFactura.Enabled = True
            Me.rbTodos.Enabled = False
            Me.rbSoloCreados.Enabled = True
            Me.rbSoloCreados.Checked = True
        End If
        If gbPuedeCrearFactura = True Then
            Me.rbAprobados.Enabled = True
            Me.rbAprobados.Checked = True
            Me.rbSoloCreados.Checked = False
            Me.rbSoloCreados.Enabled = False
            Me.rbTodos.Checked = False
            Me.rbTodos.Enabled = False
            Me.rbtDenegados.Enabled = False
            Me.btnActivaDenegado.Enabled = False
            Me.btnDenegar.Enabled = False
        End If
        CreaColmunastoGrid()


    End Sub
    Sub RefreshGrid(Optional sIDPedido As String = "")
        Try
            Dim sParameters As String
            If sIDPedido = "" Or sIDPedido = "*" Then
                sParameters = "0,0,'" & CDate(Me.DateEditDesde.EditValue).ToString("yyyyMMdd") & "','" & CDate(Me.DateEditHasta.EditValue).ToString("yyyyMMdd") & "', '" & sVerPedidos & "',1"
            Else
                sParameters = sIDPedido & ",0,'" & CDate(Me.DateEditDesde.EditValue).ToString("yyyyMMdd") & "','" & CDate(Me.DateEditHasta.EditValue).ToString("yyyyMMdd") & "', '" & sVerPedidos & "',1"
            End If

            tableData = cManager.ExecSPgetData("fafgetPedido", sParameters)
            GridControl1.DataSource = Nothing
            GridControl1.DataSource = tableData
            If tableData.Rows.Count > 0 Then

                GridControl1.Refresh()
                HideColumnsPedido(bNacional)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Sub CreaColmunastoGrid()

        Me.GridViewProducto.Columns.AddField("IDPedido")
        Me.GridViewProducto.Columns(0).Visible = True
        Me.GridViewProducto.Columns(0).Width = 50
        Me.GridViewProducto.Columns.AddField("Fecha")
        Me.GridViewProducto.Columns(1).Width = 50
        Me.GridViewProducto.Columns(1).Visible = True
        Me.GridViewProducto.Columns(1).OptionsColumn.ReadOnly = True


        Me.GridViewProducto.Columns.AddField("DescrEstado")
        Me.GridViewProducto.Columns(2).Width = 50
        Me.GridViewProducto.Columns(2).Caption = "Estado"
        Me.GridViewProducto.Columns(2).Visible = True
        Me.GridViewProducto.Columns(2).OptionsColumn.ReadOnly = True
        Me.GridViewProducto.Columns.AddField("Nombre")
        Me.GridViewProducto.Columns(3).Width = 150
        Me.GridViewProducto.Columns(3).Caption = "Nombre"
        Me.GridViewProducto.Columns(3).Visible = True


        Me.GridViewProducto.Columns.AddField("DescuentoLocal")
        Me.GridViewProducto.Columns(4).Visible = False
        Me.GridViewProducto.Columns(4).Caption = "Descuento"
        Me.GridViewProducto.Columns(4).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(4).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("DescuentoDolar")
        Me.GridViewProducto.Columns(5).Visible = False
        Me.GridViewProducto.Columns(5).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(5).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("DescuentoEspecialLocal")
        Me.GridViewProducto.Columns(6).Visible = False
        Me.GridViewProducto.Columns(6).Caption = "DescEspecial"
        Me.GridViewProducto.Columns(6).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(6).DisplayFormat.FormatString = "n2"


        Me.GridViewProducto.Columns.AddField("DescuentoEspecialDolar")
        Me.GridViewProducto.Columns(7).Visible = False
        Me.GridViewProducto.Columns(7).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(7).DisplayFormat.FormatString = "n2"


        Me.GridViewProducto.Columns.AddField("SubTotalLocal")
        Me.GridViewProducto.Columns(8).Visible = False
        Me.GridViewProducto.Columns(8).Caption = "SubTotal"
        Me.GridViewProducto.Columns(8).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(8).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("SubTotalDolar")
        Me.GridViewProducto.Columns(9).Visible = False
        Me.GridViewProducto.Columns(9).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(9).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("ImpuestoLocal")
        Me.GridViewProducto.Columns(10).Visible = False
        Me.GridViewProducto.Columns(10).Caption = "Impuesto"
        Me.GridViewProducto.Columns(10).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(10).DisplayFormat.FormatString = "n2"


        Me.GridViewProducto.Columns.AddField("ImpuestoDolar")
        Me.GridViewProducto.Columns(11).Visible = True
        Me.GridViewProducto.Columns(11).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(11).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("SubTotalFinalLocal")
        Me.GridViewProducto.Columns(12).Visible = False
        Me.GridViewProducto.Columns(12).Caption = "SubTotalFinal"
        Me.GridViewProducto.Columns(12).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(12).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("SubTotalFinalDolar")
        Me.GridViewProducto.Columns(13).Visible = False
        Me.GridViewProducto.Columns(13).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(13).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("TotalFinalLocal")
        Me.GridViewProducto.Columns(14).Visible = False
        Me.GridViewProducto.Columns(14).Caption = "TotalFinal"
        Me.GridViewProducto.Columns(14).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(14).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("TotalFinalDolar")
        Me.GridViewProducto.Columns(15).Visible = False
        Me.GridViewProducto.Columns(15).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(15).DisplayFormat.FormatString = "n2"


        Me.GridViewDetalle.Columns.AddField("IDProducto")
        Me.GridViewDetalle.Columns(0).Visible = True
        Me.GridViewDetalle.Columns(0).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("Descr")
        Me.GridViewDetalle.Columns(1).Width = 150
        Me.GridViewDetalle.Columns(1).Caption = "Descr"
        Me.GridViewDetalle.Columns(1).Visible = True
        Me.GridViewDetalle.Columns(1).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("Cantidad")
        Me.GridViewDetalle.Columns(2).Visible = True
        Me.GridViewDetalle.Columns(2).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(2).DisplayFormat.FormatString = "n2"


        Me.GridViewDetalle.Columns.AddField("PrecioLocal")
        Me.GridViewDetalle.Columns(3).Visible = True
        Me.GridViewDetalle.Columns(3).Caption = "Precio"
        Me.GridViewDetalle.Columns(3).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(3).DisplayFormat.FormatString = "n2"

        Me.GridViewDetalle.Columns.AddField("PrecioDolar")
        Me.GridViewDetalle.Columns(4).Visible = False
        Me.GridViewDetalle.Columns(4).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(4).DisplayFormat.FormatString = "n2"

        Me.GridViewDetalle.Columns.AddField("DescuentoLocal")
        Me.GridViewDetalle.Columns(5).Visible = False
        Me.GridViewDetalle.Columns(5).Caption = "Descuento"
        Me.GridViewDetalle.Columns(5).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(5).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(5).OptionsColumn.ReadOnly = True


        Me.GridViewDetalle.Columns.AddField("DescuentoDolar")
        Me.GridViewDetalle.Columns(6).Visible = False
        Me.GridViewDetalle.Columns(6).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(6).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(6).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("DescuentoEspecialLocal")
        Me.GridViewDetalle.Columns(7).Visible = False
        Me.GridViewDetalle.Columns(7).Caption = "DescEspecial"
        Me.GridViewDetalle.Columns(7).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(7).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(7).OptionsColumn.ReadOnly = True


        Me.GridViewDetalle.Columns.AddField("DescuentoEspecialDolar")
        Me.GridViewDetalle.Columns(8).Visible = True
        Me.GridViewDetalle.Columns(8).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(8).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(8).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("SubTotalLocal")
        Me.GridViewDetalle.Columns(9).Visible = False
        Me.GridViewDetalle.Columns(9).Caption = "SubTotal"
        Me.GridViewDetalle.Columns(9).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(9).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(9).OptionsColumn.ReadOnly = True


        Me.GridViewDetalle.Columns.AddField("SubTotalDolar")
        Me.GridViewDetalle.Columns(10).Visible = False
        Me.GridViewDetalle.Columns(10).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(10).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(10).OptionsColumn.ReadOnly = True


        Me.GridViewDetalle.Columns.AddField("SubTotalFinalLocal")
        Me.GridViewDetalle.Columns(11).Visible = False
        Me.GridViewDetalle.Columns(11).Caption = "SubTotalFinal"
        Me.GridViewDetalle.Columns(11).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(11).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(11).OptionsColumn.ReadOnly = True


        Me.GridViewDetalle.Columns.AddField("SubTotalFinalDolar")
        Me.GridViewDetalle.Columns(12).Visible = False
        Me.GridViewDetalle.Columns(12).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(12).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(12).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("ImpuestoLocal")
        Me.GridViewDetalle.Columns(13).Visible = False
        Me.GridViewDetalle.Columns(13).Caption = "Impuesto"
        Me.GridViewDetalle.Columns(13).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(13).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(13).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("ImpuestoDolar")
        Me.GridViewDetalle.Columns(14).Visible = False
        Me.GridViewDetalle.Columns(14).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(14).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(14).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("TotalFinalLocal")
        Me.GridViewDetalle.Columns(14).Visible = False
        Me.GridViewDetalle.Columns(14).Caption = "TotalFinal"
        Me.GridViewDetalle.Columns(14).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(14).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(14).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("TotalFinalDolar")
        Me.GridViewDetalle.Columns(15).Visible = False
        Me.GridViewDetalle.Columns(15).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(15).DisplayFormat.FormatString = "n2"
        Me.GridViewDetalle.Columns(15).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("Bonifica")
        Me.GridViewDetalle.Columns(16).Visible = False
        Me.GridViewDetalle.Columns(16).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(16).OptionsColumn.ReadOnly = True
        Me.GridViewDetalle.Columns.AddField("BonificaConProd")
        Me.GridViewDetalle.Columns(17).Visible = False
        Me.GridViewDetalle.Columns(17).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(17).OptionsColumn.ReadOnly = True

        Me.GridViewDetalle.Columns.AddField("CantBonificada")
        Me.GridViewDetalle.Columns(17).Visible = False
        Me.GridViewDetalle.Columns(17).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewDetalle.Columns(17).OptionsColumn.ReadOnly = True

    End Sub

    Private Sub HideColumnsPedido(bNacional As Boolean)
        If bNacional Then

            Me.GridViewProducto.Columns("DescuentoLocal").Visible = True
            Me.GridViewProducto.Columns("DescuentoEspecialLocal").Visible = True
            Me.GridViewProducto.Columns("ImpuestoLocal").Visible = True
            Me.GridViewProducto.Columns("SubTotalLocal").Visible = True
            Me.GridViewProducto.Columns("SubTotalFinalLocal").Visible = True
            Me.GridViewProducto.Columns("TotalFinalLocal").Visible = True


            Me.GridViewProducto.Columns("DescuentoDolar").Visible = False
            Me.GridViewProducto.Columns("DescuentoEspecialDolar").Visible = False
            Me.GridViewProducto.Columns("ImpuestoDolar").Visible = False
            Me.GridViewProducto.Columns("SubTotalDolar").Visible = False
            Me.GridViewProducto.Columns("SubTotalFinalDolar").Visible = False
            Me.GridViewProducto.Columns("TotalFinalDolar").Visible = False

        Else

            Me.GridViewProducto.Columns("DescuentoLocal").Visible = False
            Me.GridViewProducto.Columns("DescuentoEspecialLocal").Visible = False
            Me.GridViewProducto.Columns("ImpuestoLocal").Visible = False
            Me.GridViewProducto.Columns("SubTotalLocal").Visible = False
            Me.GridViewProducto.Columns("SubTotalFinalLocal").Visible = False
            Me.GridViewProducto.Columns("TotalFinalLocal").Visible = False


            Me.GridViewProducto.Columns("DescuentoDolar").Visible = True
            Me.GridViewProducto.Columns("DescuentoEspecialDolar").Visible = True
            Me.GridViewProducto.Columns("ImpuestoDolar").Visible = True
            Me.GridViewProducto.Columns("SubTotalDolar").Visible = True
            Me.GridViewProducto.Columns("SubTotalFinalDolar").Visible = True
            Me.GridViewProducto.Columns("TotalFinalDolar").Visible = True
        End If



    End Sub


    Private Sub HideColumnsDetalle(bNacional As Boolean)
        If bNacional Then
            Me.GridViewDetalle.Columns("PrecioLocal").Visible = True
            Me.GridViewDetalle.Columns("DescuentoLocal").Visible = True
            Me.GridViewDetalle.Columns("DescuentoEspecialLocal").Visible = True
            Me.GridViewDetalle.Columns("ImpuestoLocal").Visible = True
            Me.GridViewDetalle.Columns("SubTotalLocal").Visible = True
            Me.GridViewDetalle.Columns("SubTotalFinalLocal").Visible = True
            Me.GridViewDetalle.Columns("TotalFinalLocal").Visible = True
            Me.GridViewDetalle.Columns("PrecioDolar").Visible = False
            Me.GridViewDetalle.Columns("DescuentoDolar").Visible = False
            Me.GridViewDetalle.Columns("DescuentoEspecialDolar").Visible = False
            Me.GridViewDetalle.Columns("ImpuestoDolar").Visible = False
            Me.GridViewDetalle.Columns("SubTotalDolar").Visible = False
            Me.GridViewDetalle.Columns("SubTotalFinalDolar").Visible = False
            Me.GridViewDetalle.Columns("TotalFinalDolar").Visible = False
        Else
            Me.GridViewDetalle.Columns("PrecioDolar").Visible = True
            Me.GridViewDetalle.Columns("DescuentoDolar").Visible = True
            Me.GridViewDetalle.Columns("DescuentoEspecialDolar").Visible = True
            Me.GridViewDetalle.Columns("ImpuestoDolar").Visible = True
            Me.GridViewDetalle.Columns("SubTotalDolar").Visible = True
            Me.GridViewDetalle.Columns("SubTotalFinalDolar").Visible = True
            Me.GridViewDetalle.Columns("TotalFinalDolar").Visible = True

            Me.GridViewDetalle.Columns("PrecioLocal").Visible = False
            Me.GridViewDetalle.Columns("DescuentoLocal").Visible = False
            Me.GridViewDetalle.Columns("DescuentoEspecialLocal").Visible = False
            Me.GridViewDetalle.Columns("ImpuestoLocal").Visible = False
            Me.GridViewDetalle.Columns("SubTotalLocal").Visible = False
            Me.GridViewDetalle.Columns("SubTotalFinalLocal").Visible = False
            Me.GridViewDetalle.Columns("TotalFinalLocal").Visible = False

        End If



    End Sub


    'Private Sub GridViewDetalle_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridViewDetalle.ValidateRow
    '    Try
    '        Dim IDProducto As Int32 = Convert.ToDecimal(GridViewDetalle.GetRowCellValue(e.RowHandle, "IDProducto"))
    '        Dim Cantidad As Decimal = Convert.ToDecimal(GridViewDetalle.GetRowCellValue(e.RowHandle, "Cantidad"))
    '        Dim Precio As Decimal = Convert.ToDecimal(GridViewDetalle.GetRowCellValue(e.RowHandle, "PrecioLocal"))
    '        Dim CantidadBonif As Decimal = Convert.ToDecimal(GridViewDetalle.GetRowCellValue(e.RowHandle, "CantidadBonif"))
    '        Dim Bonifica As Decimal = Convert.ToInt16(GridViewDetalle.GetRowCellValue(e.RowHandle, "Bonifica"))
    '        Dim BonificaProd As Decimal = Convert.ToInt16(GridViewDetalle.GetRowCellValue(e.RowHandle, "BonificaProd"))
    '        Dim PorcDescuentoEsp As Decimal = Convert.ToDecimal(GridViewDetalle.GetRowCellValue(e.RowHandle, "PrecioLocal"))
    '        If (Cantidad > 0) And (Precio > 0) Then
    '            ActualizaLineaPedido(IDProducto, Cantidad, Precio, Bonifica, BonificaProd, CantidadBonif, PorcDescuentoEsp)
    '            'MessageBox.Show("Ud no puede asignar más que la existencia en ese lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            'GridViewProducto.SetRowCellValue(GridViewProducto.FocusedRowHandle, GridViewProducto.FocusedColumn, 0)
    '            'gbErrorEnLote = True
    '        Else
    '            'gbErrorEnLote = False
    '            'TotalizaGrid()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Ha ocurrido un error  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub Editor_KeyDown(sender As Object, e As KeyEventArgs)
    '    Try
    '        If (e.KeyCode = Keys.Enter) Then
    '            GridViewDetalle.CloseEditor()
    '            GridViewDetalle.UpdateCurrentRow()
    '            If GridViewDetalle.FocusedColumn.FieldName = "PrecioLocal" Or GridViewDetalle.FocusedColumn.FieldName = "PrecioDolar" Then
    '                MessageBox.Show("Edito y enter en precio ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            End If
    '            If GridViewDetalle.FocusedColumn.FieldName = "Cantidad" Then
    '                MessageBox.Show("Edito y enter Cantidad ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            End If

    '            e.Handled = True



    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Ha ocurrido un error  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub ActualizaLineaPedido(iIDProducto As Int32, dCantidad As Decimal, dPrecio As Decimal, bBonifica As Int16, bBonifProd As Int16, dCantBonif As Decimal, dPorcDescuentoEsp As Decimal)
        Dim storeName As String, sparameters As String
        storeName = "fafUpdatePedidoProd"
        sparameters = "'U'" & "," & gsIDPedido & "," & gsIDBodega & "," & iIDProducto.ToString() & "," & _
        dCantidad.ToString() & "," & dPrecio.ToString() & "," & 0.ToString() & "," & 0.ToString() & "," & _
        0.ToString() & "," & 0.ToString() & "," & 0.ToString() & "," & 0.ToString() & "," & 0.ToString() & "," & _
        bBonifica.ToString() & "," & bBonifProd.ToString() & "," & _
        dCantBonif.ToString() & "," & 0.ToString() & "," & 0.ToString() & "," & dPorcDescuentoEsp.ToString() & "," & _
        0.ToString() & "," & 0.ToString()

        cManager.ExecSP(storeName, sparameters)
    End Sub

    Private Sub btnRefresh_Click_1(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Me.rbTodos.Checked = True Then
            sVerPedidos = "*"
        End If
        If Me.rbSoloCreados.Checked = True Then
            sVerPedidos = "C"
        End If
        If Me.rbAprobados.Checked = True Then
            sVerPedidos = "A" ' Puede crear facturas y solo necesita refrescar los pedidos Aprobados
        End If
        If Me.rbtDenegados.Checked = True Then
            sVerPedidos = "D" ' Puede crear facturas y solo necesita refrescar los pedidos Aprobados
        End If
        RefreshGrid("")
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Try
            If sEstadoPedido = "A" Then
                MessageBox.Show("Este pedido ya está autorizado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If MessageBox.Show("Ud va a aprobar el Pedido " & gsIDPedido & " del Cliente " & txtNombre.Text, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cManager.Update("fafPedido", "Estado = 'A'", " IDPedido = " & gsIDPedido & " and IDBodega = " & gsIDBodega)
                RefreshGrid("")

            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try
    End Sub


    Private Sub GridViewProducto_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProducto.FocusedRowChanged
        Dim index As Integer = GridViewProducto.FocusedRowHandle
        If index > -1 Then
            Dim dr As DataRow = GridViewProducto.GetFocusedDataRow()
            currentRow = dr
            If dr IsNot Nothing Then
                gsIDPedido = dr("IDPedido").ToString()
                gsIDBodega = dr("IDBodega").ToString()
                gsIDNivel = dr("IDNivel").ToString()
                gsIDMoneda = dr("IDMoneda").ToString()
                gsIDPlazo = dr("IDPlazo").ToString()
                Me.txtIDPedido.EditValue = dr("IDPedido").ToString()
                sEstadoPedido = dr("Estado").ToString()
                Me.txtNombre.EditValue = dr("Nombre").ToString()
                Me.GridControl2.DataSource = Nothing
                Me.GridControl2.DataSource = cManager.ExecSPgetData("fafgetPedido", gsIDPedido & "," & gsIDBodega & ",null, null, '" & sEstadoPedido & "',0")
                HideColumnsDetalle(bNacional)
                'Me.txtNombre.EditValue = dr("Nombre")
                'gsFarmacia = dr("Farmacia").ToString()
                'gsIDVendedor = dr("IDVendedor").ToString()
            End If
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If MessageBox.Show("Está Ud seguro de Anular el Pedido " & gsIDPedido & "No lo podrá utilizar más ...", "Advertencia", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                cManager.Update("fafPedido", "Estado = 'N', Anulado= 1", " IDPedido = " & gsIDPedido & " and IDBodega = " & gsIDBodega)
                RefreshGrid("")
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error " & ex.Message)
            End Try

        End If
    End Sub


    Private Sub btnFactura_Click(sender As Object, e As EventArgs) Handles btnFactura.Click
        If gsIDPedido = "" Or gsIDBodega = "" Then
            MessageBox.Show("Ud debe seleccionar un Pedido... por favor corra el proceso Refresh para que Ud pueda seleccionar un pedido", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            gbPedidoParaFactura = False
            Return
        Else
            gbPedidoParaFactura = True
            Me.Close()
        End If
    End Sub

    Private Sub RefreshControlsFromGrid()
        Dim dr As DataRow = GridViewDetalle.GetFocusedDataRow()
        currentRow = dr
        If dr IsNot Nothing Then
            Me.txtCodigo.EditValue = dr("IDProducto").ToString()
            Me.txtDescr.EditValue = dr("Descr").ToString()
            Me.txtCantidad.EditValue = dr("Cantidad")
            Me.txtCantBonif.EditValue = dr("CantBonificada")
            Me.txtPrecio.EditValue = dr("PrecioLocal")
            Me.chkBonifica.EditValue = dr("Bonifica")
            Me.chkBonifProd.EditValue = dr("BonifconProd")
            ' para obtener el PorcDescuentoEspecial
            Dim t As DataTable
            Dim sparam As String = txtCodigo.EditValue.ToString() & ",'" & CDate(Date.Now).ToString("yyyyMMdd") & "'"
            t = cManager.ExecFunction("fafGetPorcDescuento", sparam)
            Me.txtPorcDescEsp.EditValue = t.Rows(0).Item(0)
            Me.txtDescuentoEsp.EditValue = CDec(txtCantidad.EditValue) * CDec(txtPrecio.EditValue) * CDec(txtPorcDescEsp.EditValue / 100)
            'Me.chkBonifProd.EditValue = dr("BonifProd")
            'Else
            '    ClearControlslinea()
        End If
    End Sub


    Private Sub GridViewDetalle_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalle.FocusedRowChanged
        RefreshControlsFromGrid()
    End Sub

    'Private Sub GridViewDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewDetalle.KeyDown

    '    Editor_KeyDown(sender, e)
    'End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub cmdAplicar_Click(sender As Object, e As EventArgs) Handles cmdAplicar.Click
        ActualizaLineaPedido(txtCodigo.EditValue, txtCantidad.EditValue, txtPrecio.EditValue, chkBonifica.EditValue, chkBonifProd.EditValue, txtCantBonif.EditValue, 0)
        RefreshGrid(gsIDPedido)
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        If gsIDPedido = "" Or gsIDBodega = "" Then
            MessageBox.Show("Ud debe seleccionar un Pedido... por favor corra el proceso Refresh para que Ud pueda seleccionar un pedido", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            gbPedidoParaFactura = False
            Return
        Else
            gbPedidoParaFactura = True
            Me.Close()
        End If
    End Sub


    Private Sub btnDenegar_Click(sender As Object, e As EventArgs) Handles btnDenegar.Click
        Try
            If sEstadoPedido = "D" Then
                MessageBox.Show("Este pedido ya está Denegado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If sEstadoPedido <> "C" Then
                MessageBox.Show("Solo se puede Denegar un Pedido Creado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If MessageBox.Show("Ud va a Denegar el Pedido " & gsIDPedido & " del Cliente " & txtNombre.Text, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cManager.Update("fafPedido", "Estado = 'D'", " IDPedido = " & gsIDPedido & " and IDBodega = " & gsIDBodega)
                RefreshGrid("")

            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try
    End Sub

    Private Sub btnActivaDenegado_Click(sender As Object, e As EventArgs) Handles btnActivaDenegado.Click
        Try
            If sEstadoPedido = "C" Then
                MessageBox.Show("Este pedido no puede ser Activado ya que está creado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If sEstadoPedido <> "D" Then
                MessageBox.Show("Solo se puede Activar un pedido que ha sido Denegado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If MessageBox.Show("Ud va a Activar el Pedido " & gsIDPedido & " del Cliente " & txtNombre.Text, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cManager.Update("fafPedido", "Estado = 'C'", " IDPedido = " & gsIDPedido & " and IDBodega = " & gsIDBodega)
                sVerPedidos = "*"
                RefreshGrid("")

            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try
    End Sub
End Class