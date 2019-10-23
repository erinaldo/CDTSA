Imports Clases
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Win
Imports DevExpress.XtraGrid.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.GridControl

Public Class frmPedidoinicial
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsStoreProcNameGetData As String
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean = False
    Public gsCodeValue As String = ""
    Dim viewSelectedRow As GridView
    Dim currentRow As DataRow
    Private Sub frmPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargagridLookUpsFromTables()
        AssignFieldsToGrid()
        AddCollumnsToDataTableGrid()
    End Sub

    Private Function ControlsHeaderOk() As Boolean
        Dim lbok As Boolean
        lbok = True
        If Not (Me.SearchLookUpEditSucursales.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.SearchLookUpEditCliente.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.SearchLookUpEditVendedores.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.DateEditFechaRequerida.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If
        If Not (Me.DateEditFechaPedido.EditValue IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        If Not (Me.txtPedido.Text IsNot Nothing) Then
            lbok = False
            Return lbok
        End If

        Return lbok
    End Function

    Sub CargagridLookUpsFromTables()

        CargagridSearchLookUp(Me.SearchLookUpEditCliente, "ccfClientes", "IDCliente, Nombre, Activo", "", "IDCliente", "Nombre", "IDCliente")
        CargagridSearchLookUp(Me.SearchLookUpEditSucursales, "invBodega", "IDBodega, Descr, Activo", "", "IDBodega", "Descr", "IDBodega")
        CargagridSearchLookUp(Me.SearchLookUpEditVendedor, "fafVendedor", "IDVendedor, Nombre, Activo", "", "IDVendedor", "Nombre", "IDVendedor")
        CargagridSearchLookUp(Me.SearchLookUpEditProducto, "invProducto", "IDProducto, Descr, Activo", "", "IDProducto", "Descr", "IDProducto")
        Me.DateEditFechaPedido.EditValue = Date.Now
        Me.DateEditFechaRequerida.EditValue = Date.Now
    End Sub
    Sub CargagridLookUp(ByVal g As GridLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.PopupFilterMode = PopupFilterMode.Default
        g.Properties.NullText = ""

    End Sub
    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        g.Properties.PopupFormSize = New Size(250, 250)
        g.Properties.NullText = ""

    End Sub

    Sub AssignFieldsToGrid()
        GridColumnProd.FieldName = "IDProducto"
        GridColumnDescr.FieldName = "Descr"
        GridColumnCant.FieldName = "Cantidad"
        GridColumnCant.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridColumnCant.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridColumnPrecio.FieldName = "PrecioLocal"
        GridColumnPrecio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridColumnPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridColumnSubTotal.FieldName = "SubTotal"
        GridColumnSubTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridColumnSubTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    End Sub

    Sub AddCollumnsToDataTableGrid()
        tableData.Columns.Add("IDBodega")
        tableData.Columns.Add("IDProducto")
        tableData.Columns.Add("Descr")
        tableData.Columns.Add("Cantidad")
        tableData.Columns.Add("PrecioLocal")
        tableData.Columns.Add("SubTotal")

    End Sub

    Private Sub btnAddLinea_Click(sender As Object, e As EventArgs) Handles btnAddLinea.Click
        If Not ControlsHeaderOk() Then
            MessageBox.Show("Por favor revise los datos del Pedido, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.searchLookUpEditSucursales.Focus()
            Return
        End If
        Dim foundRow() As DataRow
        foundRow = tableData.Select("IDProducto =" & Me.SearchLookUpEditProducto.EditValue.ToString())

        If foundRow IsNot Nothing And foundRow.Count > 0 Then
            MessageBox.Show("Ese Producto ya Existe, por favor revise", "Advertencia", MessageBoxButtons.OK)
            Return

        End If

        AddDataToGrid()
    End Sub

    Sub AddDataToGrid()
        Dim r As DataRow = tableData.NewRow

        r("IDProducto") = Me.SearchLookUpEditProducto.EditValue
        r("Descr") = Me.SearchLookUpEditProducto.Text
        r("IDBodega") = Me.searchLookUpEditSucursales.EditValue
        r("Cantidad") = Me.txtCantidad.Text
        r("PrecioLocal") = Me.txtPrecio.Text
        r("SubTotal") = CDbl(Me.txtPrecio.Text) * CDbl(txtCantidad.Text)
        tableData.Rows.Add(r)
        Me.GridControl1.DataSource = tableData
    End Sub


    Private Sub OnFormKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim form As PopupSearchLookUpEditForm = TryCast(sender, PopupSearchLookUpEditForm)
        Dim popup As SearchEditLookUpPopup = TryCast(form.ActiveControl, SearchEditLookUpPopup)
        Dim grid As GridControl = TryCast(popup.lciGrid.Control, GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.KeyCode = Keys.Enter Then
            If view.DataRowCount > 0 Then
                Dim val As Object = view.GetRowCellValue(0, form.OwnerEdit.Properties.ValueMember)
                form.OwnerEdit.ClosePopup()
                form.OwnerEdit.EditValue = val
            End If
        End If
    End Sub

    Private Sub SearchLookUpEditCliente_Popup(sender As Object, e As EventArgs) Handles SearchLookUpEditCliente.Popup
        Dim form As PopupSearchLookUpEditForm = TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupSearchLookUpEditForm)
        form.KeyPreview = True
        RemoveHandler form.KeyDown, AddressOf OnFormKeyDown
        AddHandler form.KeyDown, AddressOf OnFormKeyDown
    End Sub

    Private Sub SearchLookUpEditProducto_Popup(sender As Object, e As EventArgs) Handles SearchLookUpEditProducto.Popup
        Dim form As PopupSearchLookUpEditForm = TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupSearchLookUpEditForm)
        form.KeyPreview = True
        RemoveHandler form.KeyDown, AddressOf OnFormKeyDown
        AddHandler form.KeyDown, AddressOf OnFormKeyDown
    End Sub

    Private Sub SearchLookUpEditVendedores_Popup(sender As Object, e As EventArgs) Handles SearchLookUpEditVendedores.Popup
        Dim form As PopupSearchLookUpEditForm = TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupSearchLookUpEditForm)
        form.KeyPreview = True
        RemoveHandler form.KeyDown, AddressOf OnFormKeyDown
        AddHandler form.KeyDown, AddressOf OnFormKeyDown
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If tableData.Rows.Count > 0 Then
            GridViewDetalle.DeleteRow(GridViewDetalle.FocusedRowHandle())
            MessageBox.Show("Registros" & tableData.Rows.Count.ToString)
        Else
            MessageBox.Show("No existen Registros ")
        End If

    End Sub




    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not ControlsHeaderOk() Then
            MessageBox.Show("Por favor revise los datos del Pedido, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.searchLookUpEditSucursales.Focus()
            Return
        End If
        currentRow("Cantidad") = txtCantidad.Text
        currentRow("PrecioLocal") = Me.txtPrecio.Text
        currentRow("SubTotal") = CDbl(Me.txtPrecio.Text) * CDbl(txtCantidad.Text)
    End Sub

    Private Sub GridViewDetalle_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalle.FocusedRowChanged
        Dim dr As DataRow = GridViewDetalle.GetFocusedDataRow()
        currentRow = dr
        If dr IsNot Nothing Then
            Me.SearchLookUpEditProducto.EditValue = dr("IDProducto").ToString()
            Me.txtCantidad.Text = dr("Cantidad")
            Me.txtPrecio.Text = dr("PrecioLocal")
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub



    Private Sub GridLookUpEditSucursal_EditValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class