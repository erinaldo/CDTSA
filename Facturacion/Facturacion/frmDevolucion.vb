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
Public Class frmDevolucion
    Public giIDFactura As Int64
    Public gsConsecMask As String
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Dim gbError As Boolean = False
    Dim gsMascara As String
    Private Sub frmDevolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            AssignFieldsToGrid()
            CargaDatosFactura()
            Me.LayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.True
            CargaConsecutivo()

        Catch ex As Exception
            MessageBox.Show("Error al cargar la pantalla de Devoluciones " & Err.Description, "Error", MessageBoxButtons.OK)
        End Try

    End Sub

    Sub AssignFieldsToGrid()
        ' Me.GridViewProducto.OptionsBehavior.Editable = True
        Me.GridViewProducto.Columns.AddField("IDFactura")
        Me.GridViewProducto.Columns(0).Caption = "IDFactura"
        Me.GridViewProducto.Columns(0).Visible = True
        Me.GridViewProducto.Columns("IDFactura").OptionsColumn.AllowEdit = False
        Me.GridViewProducto.Columns(0).Width = 60
        Me.GridViewProducto.Columns.AddField("IDProducto")
        Me.GridViewProducto.Columns(1).Caption = "Producto"
        Me.GridViewProducto.Columns(1).Visible = True
        Me.GridViewProducto.Columns("IDProducto").OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns(1).Width = 60
        Me.GridViewProducto.Columns.AddField("DescrProducto")
        Me.GridViewProducto.Columns(2).Width = 200
        Me.GridViewProducto.Columns(2).Visible = True
        Me.GridViewProducto.Columns(2).OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns.AddField("IDLote")
        Me.GridViewProducto.Columns(3).Caption = "IDLote"
        Me.GridViewProducto.Columns(3).Visible = True
        Me.GridViewProducto.Columns(3).OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns.AddField("Precio")
        Me.GridViewProducto.Columns(4).Width = 80
        Me.GridViewProducto.Columns(4).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(4).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(4).Caption = "Precio"
        Me.GridViewProducto.Columns(4).Visible = True
        Me.GridViewProducto.Columns(4).OptionsColumn.AllowEdit = False


        Me.GridViewProducto.Columns.AddField("PorcDescBonif")
        Me.GridViewProducto.Columns(5).Width = 80
        Me.GridViewProducto.Columns(5).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(5).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(5).Caption = "%DescBonif"
        Me.GridViewProducto.Columns(5).Visible = True
        Me.GridViewProducto.Columns(5).FieldName = "PorcDescBonif"
        Me.GridViewProducto.Columns(5).OptionsColumn.ReadOnly = True

        Me.GridViewProducto.Columns.AddField("porcDescuentoEsp")
        Me.GridViewProducto.Columns(6).Width = 80
        Me.GridViewProducto.Columns(6).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(6).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(6).Caption = "%DescEsp"
        Me.GridViewProducto.Columns(6).Visible = True
        Me.GridViewProducto.Columns(6).FieldName = "porcDescuentoEsp"
        Me.GridViewProducto.Columns(6).OptionsColumn.ReadOnly = False

        Me.GridViewProducto.Columns.AddField("LoteProveedor")
        Me.GridViewProducto.Columns(7).Width = 80
        Me.GridViewProducto.Columns(7).Caption = "LoteProveedor"
        Me.GridViewProducto.Columns(7).Visible = True
        Me.GridViewProducto.Columns(7).OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns.AddField("CantidadLote")
        Me.GridViewProducto.Columns(8).Width = 80
        Me.GridViewProducto.Columns(8).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(8).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(8).Caption = "Cantidad"
        Me.GridViewProducto.Columns(8).Visible = True
        Me.GridViewProducto.Columns(8).OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns.AddField("CantADev")
        Me.GridViewProducto.Columns(9).Width = 80
        Me.GridViewProducto.Columns(9).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(9).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns(9).Caption = "CantDevuelta"
        Me.GridViewProducto.Columns(9).Visible = True
        Me.GridViewProducto.Columns(9).FieldName = "CantADev"
        Me.GridViewProducto.Columns(9).AppearanceHeader.ForeColor = Color.Red
        Me.GridViewProducto.Columns(9).AppearanceCell.ForeColor = Color.Red
        Me.GridViewProducto.Columns(9).OptionsColumn.ReadOnly = False
        Me.GridViewProducto.Columns(9).OptionsColumn.AllowEdit = True


        ' add unbound column
        Dim ubColumn As New DevExpress.XtraGrid.Columns.GridColumn() With {
        .Caption = "Monto",
        .FieldName = "Monto",
        .UnboundType = DevExpress.Data.UnboundColumnType.Decimal,
        .Visible = True,
        .UnboundExpression = "(CantADev*Precio)-((CantADev*Precio)*(porcDescuentoEsp/100)+ (CantADev*Precio)*(PorcDescBonif/100))"
            }
        Me.GridViewProducto.Columns.Add(ubColumn)
        Me.GridViewProducto.Columns(10).OptionsColumn.ReadOnly = True
        Me.GridViewProducto.Columns(10).DisplayFormat.FormatType = FormatType.Numeric
        Me.GridViewProducto.Columns(10).DisplayFormat.FormatString = "n2"
        'Me.GridViewProducto.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {
        '.Caption = "Monto",
        '.FieldName = "Monto",
        '.UnboundType = DevExpress.Data.UnboundColumnType.Decimal,
        '.Visible = True,
        '.UnboundExpression = "(CantADev*Precio)-((CantADev*Precio)*(porcDescuentoEsp/100) *(PorcDescBonif/100))"
        '    })


    End Sub
    
    Private Sub CargaDatosFactura()
        If giIDFactura <> 0 Then
            Dim sParameters As String = giIDFactura.ToString()
            tableData = cManager.ExecSPgetData("fafPrintFacturaLote", sParameters)
            CargagridLookUpsFromTables()
            If tableData.Rows.Count > 0 Then

                Me.SearchLookUpEditSucursal.EditValue = CInt(tableData.Rows(0)("IDBodega"))
                Me.SearchLookUpEditPlazo.EditValue = CInt(tableData.Rows(0)("IDPlazo"))
                Me.SearchLookUpEditVendedor.EditValue = CInt(tableData.Rows(0)("IDVendedor"))
                Me.SearchLookUpEditTipoFact.EditValue = CInt(tableData.Rows(0)("IDTipo"))
                Me.SearchLookUpEditTipoEntrega.EditValue = CInt(tableData.Rows(0)("IDTipoEntrega"))
                Me.txtIDCliente.EditValue = CInt(tableData.Rows(0)("IDCliente"))
                Me.SearchLookUpEditNivel.EditValue = CInt(tableData.Rows(0)("IDNivel"))
                Me.SearchLookUpEditMoneda.EditValue = CInt(tableData.Rows(0)("IDMoneda"))
                Me.txtNombre.EditValue = tableData.Rows(0)("Nombre").ToString()

                If CBool(tableData.Rows(0)("EsTeleventa")) = True Then
                    Me.CheckEditTeleVenta.EditValue = CBool(tableData.Rows(0)("EsTeleventa"))
                End If
                Me.DateEditFecha.EditValue = Convert.ToDateTime(tableData.Rows(0)("Fecha"))
                Me.txtFactura.EditValue = tableData.Rows(0)("Factura").ToString()
                Me.txtTipoCambio.EditValue = tableData.Rows(0)("TipoCambio").ToString()
                tableData.Columns("CantADev").ReadOnly = False
                Me.GridControl1.DataSource = tableData

            End If
        End If
    End Sub
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

        Me.SearchLookUpEditSucursal.EditValue = gsSucursal

        Me.SearchLookUpEditSucursal.ReadOnly = True
    End Sub
    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit 'DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        g.Properties.PopupFormSize = New Size(250, 250)
        g.Properties.NullText = ""
    End Sub

    Private Sub GridViewProducto_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridViewProducto.ValidateRow
        Try
            Dim CantADev As Decimal = Convert.ToDecimal(GridViewProducto.GetRowCellValue(e.RowHandle, "CantADev"))
            Dim Cantidad As Decimal = Convert.ToDecimal(GridViewProducto.GetRowCellValue(e.RowHandle, "CantidadLote"))
            If CantADev < 0 Then
                MessageBox.Show("El valor a Devolver debe ser mayor que Cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GridViewProducto.SetRowCellValue(GridViewProducto.FocusedRowHandle, GridViewProducto.FocusedColumn, 0)
                gbError = True
                Return
            End If

            If CantADev > Cantidad Then
                MessageBox.Show("Ud no puede devolver más que la Cantidad Facturada en ese lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GridViewProducto.SetRowCellValue(GridViewProducto.FocusedRowHandle, GridViewProducto.FocusedColumn, 0)
                gbError = True
            Else
                gbError = False
                'TotalizaGrid()
            End If
        Catch ex As Exception
            gbError = True
            MessageBox.Show("Ha ocurrido un error  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GeneraDevolucion()
        Dim strCriteria As String = "CantADev> 0"
        Dim drSelect As DataRow() = tableData.Select(strCriteria)
        Dim localDataTable As DataTable = tableData.Clone
        Try
            If Not IsMaskOK(gsMascara, Me.txtDevolucion.EditValue) Then
                'MessageBox.Show("El valor de la Devolución no cumple con el patron de la   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtDevolucion.Focus()
            End If

            If drSelect.Length > 0 Then
                For Each drItem As DataRow In drSelect
                    Dim nrow As DataRow = drItem
                    localDataTable.ImportRow(nrow)
                Next
                ' Registro la Cabecera de la Devolucion
                ' Preparando los datos de la cabecera 

                Dim sParameters As String
                sParameters = "'I'," & giIDFactura.ToString() & ",'" & CDate(Me.DateEditFechaDevolucion.EditValue).ToString("yyyyMMdd") & "','" & gsConsecMask & "','" & Me.txtDevolucion.Text & "'," & Me.SearchLookUpEditMoneda.EditValue.ToString() & ", '" & gsUsuario & "'," & _
                    Me.txtTipoCambio.EditValue.ToString() & ", 0," & IIf(Me.CheckEditNotaCredito.EditValue = True, "1", "0")
                'creando la instruccion de insercion en la cabecera
                Dim sSql As String = cManager.CreateStoreProcSql("fafUpdateDevolucion", sParameters)
                Dim clase As New CbatchSQLIitem(sSql, True, False, True, False, "fafUpdateDevolucion", "fafUpdateDevolucion")
                cManager.batchSQLLista.Add(clase)
                cManager.batchSQLitem.Clear()
                cManager.batchSQLitem.Add(sSql)
                ' Recorro las lineas de la devolucion filtrados
                Dim dValorDev As Decimal
                For Each dr As DataRow In localDataTable.Rows
                    dValorDev = CDec(dr("Precio")) * CDec(dr("CantADev")) - (CDec(dr("Precio")) * CDec(dr("CantADev"))) * CDec(dr("PorcDescBonif")) / 100 - (CDec(dr("Precio")) * CDec(dr("CantADev"))) * CDec(dr("PorcDescuentoEsp")) / 100
                    sParameters = "'I'" & ",@@Identity" & "," & dr("IDProducto").ToString() & "," & dr("IDLote").ToString() & "," & dr("CantADev").ToString() & "," & dr("Precio").ToString() & "," & _
                                 dr("PorcDescBonif").ToString() & "," & dr("PorcDescuentoEsp").ToString() & "," & dValorDev.ToString()

                    sSql = cManager.CreateStoreProcSql("fafUpdateDevDetalle", sParameters)
                    clase = New CbatchSQLIitem(sSql, True, True, True, True, "fafUpdateDevolucion", "fafUpdateDevDetalle")
                    cManager.batchSQLitem.Add(sSql)
                    cManager.batchSQLLista.Add(clase)
                Next
                If cManager.ExecCmdWithTransaction() Then
                    MessageBox.Show("Devolucion registrada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Error al registrar la Devolucion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CargaConsecutivo()
        Dim sParameters As String
        Dim td As New DataTable
        sParameters = "'" & gsConsecMask & "'"
        td = cManager.ExecFunction("getNextConsecMask", sParameters)
        If td.Rows.Count <= 0 Then
            MessageBox.Show("No existe un Consecutivo con Mascara para la Devolucion, por favor llamar al Adminstrador del Sistema, debe definirlo en la Bodega correspondiente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.txtDevolucion.EditValue = td.Rows(0)(0)
        Me.DateEditFechaDevolucion.EditValue = Now
        td = cManager.ExecFunction("getMascaraFromConsecMask", sParameters)
        gsMascara = td.Rows(0)(0)


    End Sub

    Private Sub btnDevolver_Click(sender As Object, e As EventArgs) Handles btnDevolver.Click
        GeneraDevolucion()
    End Sub


    Private Sub txtDevolucion_LostFocus(sender As Object, e As EventArgs) Handles txtDevolucion.LostFocus
        If Not IsMaskOK(gsMascara, Me.txtDevolucion.EditValue) Then
            Me.txtDevolucion.Focus()
        End If
    End Sub

    Private Sub CheckEditNotaCredito_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditNotaCredito.CheckedChanged
        If CheckEditNotaCredito.Checked = True Then
            Me.gcNotaCredito.Enabled = True
        Else
            Me.gcNotaCredito.Enabled = False
        End If
    End Sub
End Class