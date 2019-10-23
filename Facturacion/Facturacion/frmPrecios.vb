Imports Clases
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors

Public Class frmPrecios
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Dim tableDataCli As New DataTable()
    Dim viewSelectedRow As GridView
    Dim currentRow As DataRow
    Private Sub frmPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateEditDesde.EditValue = Now
        DateEditHasta.EditValue = Now
        CargagridLookUpsFromTables()
        ' RefreshGrid()
        Me.chkTodos.Checked = True
        Me.chkTodosNiveles.Checked = True
        Me.chkTodosProd.Checked = True
        chktodosNvelesCli.ReadOnly = True
        Me.SearchLookUpEditNivelCliente.ReadOnly = True
        Me.SearchLookUpEditmonCli.ReadOnly = True
        InitGrids()
    End Sub
    Private Sub InitGrids()
        'sParametros = IIf(sProducto = "", "0", sProducto) & "," & IIf(sNivel = "", "0", sNivel) & "," & IIf(sProveedor = "", "0", sProveedor)
        tableData = cManager.ExecSPgetData("fafgetListaPrecio", "-1,-1,-1")
        GridControl1.DataSource = tableData
        tableDataCli = cManager.ExecSPgetData("fafgetPreciosCliente", "-1,-1,-1,-1")
        dgPrecioCliente.DataSource = tableDataCli
    End Sub
    Sub RefreshGrid()
        Dim sParametros As String
        Dim sProducto As String = "0"
        Dim sNivel As String = "0"
        Dim sProveedor As String = "0"
        Try


            If Not chkTodosProd.Checked Then
                If txtIDProducto.Text = "" Then
                    sProducto = "0"
                Else
                    sProducto = txtIDProducto.Text
                End If

            End If
            If chkTodosNiveles.Checked Then
                If Me.SearchLookUpEditNivel.Text = "" Then
                    sNivel = "0"
                Else
                    sNivel = Me.SearchLookUpEditNivel.EditValue.ToString()
                End If
            End If
            If chkTodos.Checked Then
                sProveedor = " 0"
            Else
                sProveedor = Me.SearchLookUpEditProveedor.EditValue.ToString()
            End If
            sParametros = IIf(sProducto = "", "0", sProducto) & "," & IIf(sNivel = "", "0", sNivel) & "," & IIf(sProveedor = "", "0", sProveedor)
            tableData = cManager.ExecSPgetData("fafgetListaPrecio", sParametros)
            GridControl1.DataSource = tableData
            'tableDataCli = cManager.ExecSPgetData("fafgetPreciosCliente", "0")
            'dgPrecioCliente.DataSource = tableDataCli

            'dgPrecioCliente.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Sub RefreshGridCliente()
        Dim sCliente As String = "0"
        Dim sParametros As String
        Dim sProducto As String = "0"
        Dim sNivel As String = "0"
        Dim sProveedor As String = "0"
        Try


            If Me.txtCliente.Text = "" Then
                sCliente = "0"
            Else
                sCliente = txtCliente.Text
            End If

            If txtProdcli.Text = "" Then
                sProducto = "0"
            Else
                sProducto = txtProdcli.Text
            End If

            If Me.SearchLookUpEditNivelCliente.Text = "" Then
                sNivel = "0"
            Else
                sNivel = Me.SearchLookUpEditNivelCliente.EditValue.ToString()
            End If

            If Me.SearchLookUpEditProvCli.Text = "" Then
                sProveedor = "0"
            Else
                sProveedor = Me.SearchLookUpEditProveedor.EditValue.ToString()
            End If

            sParametros = IIf(sCliente = "", "0", sCliente) & "," & IIf(sProducto = "", "0", sProducto) & "," & IIf(sNivel = "", "0", sNivel) & "," & IIf(sProveedor = "", "0", sProveedor)
            tableDataCli = cManager.ExecSPgetData("fafgetPreciosCliente", sParametros)
            Me.dgPrecioCliente.DataSource = tableDataCli

        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Sub RefreshGridCli()
        Dim sCliente As String = "0"
        Dim sParametros As String
        Dim sProducto As String = "0"
        Dim sNivel As String = "0"
        Dim sProveedor As String = "0"
        Try

            If Not Me.chkTodosClientes.Checked Then
                If Me.txtCliente.Text = "" Then
                    sCliente = "0"
                Else
                    sCliente = txtCliente.Text
                End If

            End If



            If Not chkTodosProdCli.Checked Then
                If txtProdcli.Text = "" Then
                    sProducto = "0"
                Else
                    sProducto = txtProdcli.Text
                End If

            End If
            If chktodosNvelesCli.Checked Then
                If Me.SearchLookUpEditNivelCliente.Text = "" Then
                    sNivel = "0"
                Else
                    sNivel = Me.SearchLookUpEditNivelCliente.EditValue.ToString()
                End If
            End If
            If chkTodosProvCli.Checked Then
                sProveedor = " 0"
            Else
                sProveedor = Me.SearchLookUpEditProveedor.EditValue.ToString()
            End If
            sParametros = IIf(sCliente = "", "0", sCliente) & "," & IIf(sProducto = "", "0", sProducto) & "," & IIf(sNivel = "", "0", sNivel) & "," & IIf(sProveedor = "", "0", sProveedor)
            tableDataCli = cManager.ExecSPgetData("fafgetPreciosCliente", "0")
            dgPrecioCliente.DataSource = tableDataCli
            'GridColumn2.Caption = gsDescrName
            'GridColumn2.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "Elementos Registrados : {0:n0} ")
            dgPrecioCliente.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Sub CargagridLookUpsFromTables()

        CargagridSearchLookUp(Me.SearchLookUpEditNivel, "fafNivelPrecio", "IDNivel, Descr,IDMoneda", "", "IDNivel", "Descr", "IDNivel")
        CargagridSearchLookUp(Me.SearchLookUpEditNivelCliente, "fafNivelPrecio", "IDNivel, Descr,IDMoneda", "", "IDNivel", "Descr", "IDNivel")
        CargagridSearchLookUp(Me.SearchLookUpEditMoneda, "globalMoneda", "IDMoneda, Descr, Activo,Simbolo", "", "IDMoneda", "Descr", "IDMoneda")
        CargagridSearchLookUp(Me.SearchLookUpEditmonCli, "globalMoneda", "IDMoneda, Descr, Activo,Simbolo", "", "IDMoneda", "Descr", "IDMoneda")

        CargagridSearchLookUp(Me.SearchLookUpEditProveedor, "cppProveedor", "IDProveedor, Nombre,Activo", "", "IDProveedor", "Nombre", "IDProveedor")
        CargagridSearchLookUp(Me.SearchLookUpEditProvCli, "cppProveedor", "IDProveedor, Nombre,Activo", "", "IDProveedor", "Nombre", "IDProveedor")
        Me.SearchLookUpEditMoneda.ReadOnly = True
        Me.SearchLookUpEditmonCli.ReadOnly = True
        Me.SearchLookUpEditNivel.ReadOnly = False

    End Sub
    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        'g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        ' g.Properties.PopupFormSize = New Size(250, 250)
        g.Properties.NullText = ""

    End Sub

    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        Dim frm As New frmPopupProducto()
        frm.ShowDialog()
        Me.txtIDProducto.EditValue = frm.gsIDProducto
        Me.txtDescr.EditValue = frm.gsDescr
        Me.SearchLookUpEditNivel.Text = ""
        Me.SearchLookUpEditMoneda.Text = ""
        Me.txtPrecio.Text = 0
        Me.txtPublico.Text = 0
        frm.Dispose()

    End Sub

    Private Sub ClearControlsCli()
        Me.txtPrecioCliente.Text = ""
        Me.txtDescrProdCliente.Text = ""
        Me.txtProdcli.Text = ""
        If Me.chkDejarCliente.EditValue = False Then
            Me.txtNombre.Text = ""
            Me.txtCliente.Text = ""
        End If
        Me.SearchLookUpEditmonCli.Text = ""
        Me.SearchLookUpEditNivelCliente.Text = ""
    End Sub

    Private Sub ClearControls()
        Me.txtPrecio.Text = ""
        Me.txtIDProducto.Text = ""
        Me.txtDescr.Text = ""
        Me.SearchLookUpEditNivel.Text = ""
        Me.SearchLookUpEditMoneda.Text = ""


    End Sub
    ' Exisgir campso solo letras y campos solo numeros
    Private Sub ValidaLetraNumero(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles txtPrecio.KeyPress
        Dim strListaControles As String
        strListaControles = "txtPrecio,txtPublico"
        If strListaControles.Contains(sender.name) = True And Asc(e.KeyChar) <> Keys.Return Then
            e.KeyChar = Chr(Solo_Numeros(Asc(e.KeyChar)))
        End If
    End Sub

    Private Function ControlsOk() As Boolean
        Dim lbok As Boolean = True
        If txtIDProducto.Text Is Nothing Or String.IsNullOrEmpty(txtIDProducto.Text) Then
            lbok = False
            Return lbok
        End If
        If txtPrecio.Text Is Nothing Or String.IsNullOrEmpty(txtPrecio.Text) Then
            lbok = False
            Return lbok
        End If
        If Val(txtPrecio.Text) = 0 Then
            lbok = False
            Return lbok
        End If
        If Val(txtPublico.Text) = 0 Then
            lbok = False
            Return lbok
        End If
        If Me.SearchLookUpEditNivel.Text = "" Then
            lbok = False
            Return lbok
        End If
        If Me.SearchLookUpEditMoneda.Text = "" Then
            lbok = False
            Return lbok
        End If
        Return lbok
    End Function

    Private Function ControlsOkCli() As Boolean
        Dim lbok As Boolean = True
        If txtCliente.Text Is Nothing Or String.IsNullOrEmpty(txtCliente.Text) Then
            lbok = False
            Return lbok
        End If

        If Me.SearchLookUpEditNivelCliente.EditValue Is Nothing Or String.IsNullOrEmpty(SearchLookUpEditNivelCliente.Text) Then
            lbok = False
            SearchLookUpEditNivelCliente.Focus()
            Return lbok
        End If

        If txtProdcli.Text Is Nothing Or String.IsNullOrEmpty(txtProdcli.Text) Then
            lbok = False
            txtProdcli.Focus()
            Return lbok
        End If
        If txtPrecioCliente.Text Is Nothing Or String.IsNullOrEmpty(txtPrecioCliente.Text) Or txtPrecioCliente.Text = "0" Then
            lbok = False
            txtPrecioCliente.Focus()
            Return lbok
        End If
        If Me.SearchLookUpEditmonCli.Text = "" Then
            lbok = False
            SearchLookUpEditmonCli.Focus()
            Return lbok
        End If


        Return lbok
    End Function

    Sub AddDataToGrid(Optional ByVal sOperacion As String = "I")
        Try

            Dim sParameters As String
            sParameters = "'" & sOperacion & "'," & txtIDProducto.EditValue.ToString() & " ," & SearchLookUpEditNivel.EditValue.ToString() & "," & SearchLookUpEditMoneda.EditValue.ToString() & "," & _
            Me.txtPrecio.EditValue.ToString() & " ," & Me.txtPublico.EditValue.ToString()
            tableData = cManager.ExecSPgetData("fafUpdatePrecios", sParameters)
            RefreshGrid()


        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try

    End Sub
    Sub AddDataToGridCli(Optional ByVal sOperacion As String = "I")
        Try

            Dim sParameters As String
            sParameters = "'" & sOperacion & "'," & txtCliente.Text & "," & Me.txtProdcli.EditValue.ToString() & " ," & Me.SearchLookUpEditNivelCliente.EditValue.ToString() & "," & Me.SearchLookUpEditmonCli.EditValue.ToString() & "," & _
            Me.txtPrecioCliente.EditValue.ToString() & ",'" & gsUsuario & "'"
            cManager.ExecSP("fafUpdatePrecioCliente", sParameters)
            ' RefreshGridCliente()
            tableDataCli = cManager.ExecSPgetData("fafgetPreciosCliente", "-1,-1,-1,-1")
            dgPrecioCliente.DataSource = tableDataCli


        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos , existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtPrecio.Focus()
                Return
            End If

            Dim foundRow() As DataRow
            Dim sCondicion As String
            sCondicion = "IDProducto=" & Me.txtIDProducto.Text & " and IDNivel =" & Me.SearchLookUpEditNivel.EditValue.ToString() & " and IDNivel =" & Me.SearchLookUpEditMoneda.EditValue.ToString()

            foundRow = tableData.Select(sCondicion)

            If foundRow IsNot Nothing And foundRow.Count > 0 Then
                MessageBox.Show("Ese precio ya fue asignado en ese producto, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            AddDataToGrid("I")
            RefreshGrid()
            ClearControls()
            'ubico el cursor en la fila del filtro y no en la primera row
            GridViewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al agregar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridViewDetalle_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalle.FocusedRowChanged
        Dim dr As DataRow = GridViewDetalle.GetFocusedDataRow()
        currentRow = dr
        If dr IsNot Nothing Then
            txtIDProducto.EditValue = dr("IDProducto").ToString()
            txtDescr.EditValue = dr("Descr").ToString()
            Me.SearchLookUpEditNivel.EditValue = dr("IDNivel").ToString()
            Me.SearchLookUpEditMoneda.EditValue = dr("IDMoneda").ToString()
            Me.txtPrecio.EditValue = dr("Precio")
            Me.txtPublico.EditValue = dr("Publico")

            Me.SearchLookUpEditmonCli.EditValue = dr("IDMoneda").ToString()
            If chkDejarCliente.EditValue = False Then
                Me.txtCliente.Text = ""
                Me.txtNombre.Text = ""
            End If
            ' Me.txtPrecioCliente.Text = "0"
        End If

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtIDProducto.Focus()
                Return
            End If


            Dim foundRow() As DataRow
            Dim sCondicion As String
            sCondicion = "IDProducto=" & Me.txtIDProducto.Text & " and IDNivel =" & Me.SearchLookUpEditNivel.EditValue.ToString() & " and IDMoneda =" & Me.SearchLookUpEditMoneda.EditValue.ToString()

            foundRow = tableData.Select(sCondicion)
            If foundRow IsNot Nothing And foundRow.Count > 0 Then

                AddDataToGrid("U")
                ClearControls()
                'ubico el cursor en la fila del filtro y no en la primera row
                GridViewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
                Return
            Else
                MessageBox.Show("Ese precio no Existe, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return

            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al editar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos de Precios, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtIDProducto.Focus()
                Return
            End If
            If MessageBox.Show("Ud va a Eliminar la bonificación del producto " & Me.txtDescr.Text & ", Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If



            AddDataToGrid("D")

            ClearControls()
            'ubico el cursor en la fila del filtro y no en la primera row
            GridViewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al eliminar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim file As New SaveFileDialog()
        file.Filter = "Archivo XLS|*.xls"
        If file.ShowDialog() = DialogResult.OK Then
            Me.GridControl1.ExportToXls(file.FileName)


        End If
    End Sub


    Private Sub btnAddCli_Click(sender As Object, e As EventArgs) Handles btnAddCli.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOkCli() Then
                MessageBox.Show("Por favor revise los datos , existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtCliente.Focus()
                Return
            End If


            Dim sCondicion As String
            sCondicion = "IDProducto=" & Me.txtProdcli.Text & " and IDmONEDA =" & Me.SearchLookUpEditmonCli.EditValue.ToString() & " and IDCliente =" & Me.txtCliente.Text.ToString() & " and IDNivel =" & Me.SearchLookUpEditNivelCliente.EditValue.ToString()
            If cManager.ExistsInTable("fafPrecioCliente", "Precio", sCondicion, "IDCliente") Then
                MessageBox.Show("Ese precio ya fue asignado en ese producto para ese cliente, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            AddDataToGridCli("I")
            RefreshGridCli()
            ClearControlsCli()
            'ubico el cursor en la fila del filtro y no en la primera row
            GridViewPrecioCliente.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al agregar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim frm As New frmPopupCliente()
        frm.gsIDSucursal = gsSucursal
        frm.ShowDialog()
        Me.txtCliente.EditValue = frm.gsIDCliente
        Me.txtNombre.EditValue = frm.gsNombre
        Me.txtPrecioCliente.Text = "0"
        Me.SearchLookUpEditNivelCliente.EditValue = CInt(frm.gsIDNivel)
        Me.SearchLookUpEditmonCli.EditValue = CInt(frm.gsIDMoneda)
        Me.SearchLookUpEditNivelCliente.Enabled = False
        Me.SearchLookUpEditmonCli.Enabled = False
        Me.txtProdcli.Text = ""
        Me.txtDescrProdCliente.Text = ""
        Me.txtPrecioCliente.Text = "0"
        frm.Dispose()
    End Sub

    Private Sub btnEditCli_Click(sender As Object, e As EventArgs) Handles btnEditCli.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOkCli() Then
                MessageBox.Show("Por favor revise los datos, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtCliente.Focus()
                Return
            End If
            If tableDataCli.Rows.Count < 0 Then
                MessageBox.Show("No existe registro que pueda ser actualizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim foundRow() As DataRow
            Dim sCondicion As String
            sCondicion = "IDProducto=" & Me.txtProdcli.Text & " and IDmONEDA =" & Me.SearchLookUpEditmonCli.EditValue.ToString() & " and IDCliente =" & Me.txtCliente.Text.ToString() & " AND IDNivel =" & Me.SearchLookUpEditNivelCliente.EditValue.ToString()

            foundRow = Me.tableDataCli.Select(sCondicion)

            If foundRow IsNot Nothing And foundRow.Count > 0 Then

                AddDataToGridCli("U")
                ClearControlsCli()
                'ubico el cursor en la fila del filtro y no en la primera row
                GridViewPrecioCliente.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
                Return
            Else
                AddDataToGridCli("I")
                MessageBox.Show("Precio registrado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return

            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al editar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub GridViewPrecioCliente_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewPrecioCliente.FocusedRowChanged
        Dim dr As DataRow = GridViewPrecioCliente.GetFocusedDataRow()
        currentRow = dr
        If dr IsNot Nothing Then
            txtProdcli.EditValue = dr("IDProducto").ToString()
            txtDescrProdCliente.EditValue = dr("Descr").ToString()
            txtCliente.EditValue = dr("IDCliente").ToString()
            txtNombre.EditValue = dr("Nombre").ToString()
            Me.SearchLookUpEditmonCli.EditValue = dr("IDMoneda").ToString()
            Me.SearchLookUpEditNivelCliente.EditValue = dr("IDNivel").ToString()
            Me.txtPrecioCliente.EditValue = dr("Precio")
        End If
    End Sub

    Private Sub btnExcelcli_Click(sender As Object, e As EventArgs) Handles btnExcelcli.Click
        Dim file As New SaveFileDialog()
        file.Filter = "Archivo XLS|*.xls"
        If file.ShowDialog() = DialogResult.OK Then
            Me.dgPrecioCliente.ExportToXls(file.FileName)


        End If
    End Sub

    Private Sub btnDeletecli_Click(sender As Object, e As EventArgs) Handles btnDeletecli.Click
        Try

            If Not ControlsOkCli() Then
                MessageBox.Show("Por favor revise los datos de Precios, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtIDProducto.Focus()
                Return
            End If
            If MessageBox.Show("Ud va a Eliminar un Precio del producto para el cliente " & Me.txtNombre.Text & ", Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If



            AddDataToGridCli("D")
            'ubico el cursor en la fila del filtro y no en la primera row

            GridViewPrecioCliente.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al eliminar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtIDProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strDescr As String = cManager.GetDescrFromTable("invProducto", "Descr", "IDProducto =" & txtIDProducto.Text, "IDProducto")
            If strDescr = "" Then
                txtIDProducto.EditValue = ""
                txtDescr.EditValue = ""
                MessageBox.Show("No existe ningun registro con ese Código, por favor revise ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Me.txtDescr.Text = strDescr
                Me.SearchLookUpEditNivel.Focus()
            End If

        End If
    End Sub

    Private Sub txtIDProducto_EditValueChanged(sender As Object, e As EventArgs) Handles txtIDProducto.EditValueChanged

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strDescr As String = cManager.GetDescrFromTable("ccfClientes", "Nombre", "IDCliente =" & txtCliente.Text, "IDCliente")
            If strDescr = "" Then
                txtCliente.EditValue = ""
                txtNombre.EditValue = ""
                MessageBox.Show("No existe ningun registro con ese Código, por favor revise ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Me.txtNombre.Text = strDescr
                Me.chkDejarCliente.Focus()
            End If

        End If
    End Sub

    Private Sub SearchLookUpEditNivel_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEditNivel.EditValueChanged
        Dim IDMoneda As Object = Me.SearchLookUpEditNivel.Properties.View.GetFocusedRowCellValue("IDMoneda")
        Me.SearchLookUpEditMoneda.EditValue = IDMoneda
    End Sub

    Private Sub btnProdCli_Click(sender As Object, e As EventArgs) Handles btnProdCli.Click
        Dim frm As New frmPopupProducto()
        frm.ShowDialog()
        Me.txtProdcli.EditValue = frm.gsIDProducto
        Me.txtDescrProdCliente.EditValue = frm.gsDescr
        Me.txtPrecioCliente.Text = 0
        frm.Dispose()
    End Sub
    Sub RefreshGridBitacora()
        Try
            Dim sParameters As String = "'" & CDate(Me.DateEditDesde.EditValue).ToString("yyyyMMdd") & "','" & CDate(Me.DateEditHasta.EditValue).ToString("yyyyMMdd") & "'"
            tableData = cManager.ExecSPgetData("fafGetBitacoraPrecio", sParameters)
            GridControlBitacora.DataSource = tableData
            If tableData.Rows.Count > 0 Then
                GridControlBitacora.Refresh()
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message())
        End Try
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshGridBitacora()
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then
            Me.SearchLookUpEditProveedor.Text = ""
            Me.SearchLookUpEditProveedor.Enabled = False
        Else
            Me.SearchLookUpEditProveedor.Enabled = True
            Me.SearchLookUpEditProveedor.Text = ""
        End If
    End Sub

    Private Sub chkTodosProd_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosProd.CheckedChanged
        If chkTodosProd.Checked Then
            Me.txtIDProducto.Text = ""
            Me.txtDescr.Text = ""
            Me.txtIDProducto.Enabled = False
            Me.txtDescr.Enabled = False
            Me.btnProducto.Enabled = False
        Else
            Me.txtIDProducto.Text = ""
            Me.txtDescr.Text = ""
            Me.txtIDProducto.Enabled = True
            Me.txtDescr.Enabled = True
            Me.btnProducto.Enabled = True
        End If
    End Sub

    Private Sub chkTodosNiveles_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosNiveles.CheckedChanged
        If chkTodosNiveles.Checked Then
            Me.SearchLookUpEditNivel.Text = ""
            Me.SearchLookUpEditNivel.Enabled = False
            Me.SearchLookUpEditMoneda.Text = ""

        Else
            Me.SearchLookUpEditNivel.Enabled = True
            Me.SearchLookUpEditNivel.Text = ""
            Me.SearchLookUpEditMoneda.Text = ""
        End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        RefreshGrid()
    End Sub

    Private Sub chkTodosProvCli_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosProvCli.CheckedChanged
        If Me.chkTodosProvCli.Checked Then
            Me.SearchLookUpEditProvCli.Text = ""
            Me.SearchLookUpEditProvCli.Enabled = False
        Else
            Me.SearchLookUpEditProvCli.Enabled = True
            Me.SearchLookUpEditProvCli.Text = ""
        End If
    End Sub

    Private Sub chkTodosClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosClientes.CheckedChanged
        If chkTodosClientes.Checked Then
            Me.txtCliente.Text = ""
            Me.txtNombre.Text = ""
            Me.SearchLookUpEditNivelCliente.Text = ""
            Me.SearchLookUpEditmonCli.Text = ""
            Me.SearchLookUpEditNivelCliente.Enabled = False
            SearchLookUpEditmonCli.Enabled = False
            Me.txtCliente.Enabled = False
            Me.txtNombre.Enabled = False
            Me.btnCliente.Enabled = False
        Else
            Me.txtCliente.Text = ""
            Me.txtNombre.Text = ""
            Me.txtCliente.Enabled = True
            Me.txtNombre.Enabled = True
            Me.btnCliente.Enabled = True
            Me.SearchLookUpEditNivelCliente.Enabled = True
            SearchLookUpEditmonCli.Enabled = True
        End If
    End Sub

    Private Sub chktodosNvelesCli_CheckedChanged(sender As Object, e As EventArgs) Handles chktodosNvelesCli.CheckedChanged
        'If chktodosNvelesCli.Checked Then
        '    Me.SearchLookUpEditNivelCliente.Text = ""
        '    Me.SearchLookUpEditNivelCliente.Enabled = False
        '    Me.SearchLookUpEditNivelCliente.Text = ""

        'Else
        '    Me.SearchLookUpEditNivelCliente.Text = ""
        '    Me.SearchLookUpEditNivelCliente.Enabled = True


        'End If
    End Sub

    Private Sub chkTodosProdCli_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosProdCli.CheckedChanged
        If chkTodosProdCli.Checked Then
            Me.txtProdcli.Text = ""
            Me.txtDescrProdCliente.Text = ""
            Me.txtProdcli.Enabled = False
            Me.txtDescrProdCliente.Enabled = False
            Me.btnProdCli.Enabled = False
        Else
            Me.txtProdcli.Text = ""
            Me.txtDescrProdCliente.Text = ""
            Me.txtProdcli.Enabled = True
            Me.txtDescrProdCliente.Enabled = True
            Me.btnProdCli.Enabled = True
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles btnRefreshCliente.Click
        RefreshGridCliente()
    End Sub

    Private Sub chkIncrementaPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncrementaPrecio.CheckedChanged
        If chkIncrementaPrecio.EditValue = True Then
            Me.txtPorcIncremento.Enabled = True
            Me.cmdAplicaIncremento.Enabled = True
            Me.SearchLookUpEditNivel.Enabled = True
            Me.SearchLookUpEditMoneda.Enabled = True
        Else

            Me.txtPorcIncremento.Enabled = False
            Me.cmdAplicaIncremento.Enabled = False
        End If
    End Sub

    Private Sub cmdAplicaIncremento_Click(sender As Object, e As EventArgs) Handles cmdAplicaIncremento.Click
        Try
            If Me.SearchLookUpEditMoneda.Text = "" Or Me.SearchLookUpEditNivel.Text = "" Then
                MessageBox.Show("Para poder correr el proceso de incrementar Precios, debe seleccionar el Nivel de Precios y la Moneda ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Me.txtPorcIncremento.EditValue <= 0 Or IsNothing(Me.txtPorcIncremento) Then
                MessageBox.Show("Para poder correr el proceso de incrementar Precios, el Porcentaje de incremento debe ser mayor que cero ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If MessageBox.Show("Ud. va a incrementar Precios para el Nivel " & Me.SearchLookUpEditNivel.Text & " y la Moneda " & Me.SearchLookUpEditMoneda.Text & _
                             " con un Porcentaje de incremento de % " & txtPorcIncremento.EditValue.ToString(), "Advertencia", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                IncrementaPrecios(CDec(txtPorcIncremento.EditValue), CInt(SearchLookUpEditNivel.EditValue), CInt(SearchLookUpEditMoneda.EditValue))
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al incrementar los Precios " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub IncrementaPrecios(dPorcIncremento As Decimal, iIDNivel As Int16, iIDMoneda As Int16)
        Dim storeName As String, sparameters As String
        Dim dFecha As Date = Now
        storeName = "fafIncrementaListaPrecios"
        sparameters = dPorcIncremento.ToString() & ",'" & dFecha.ToString("yyyy-MM-dd HH:mm:ss") & "'" & "," & iIDNivel.ToString() & "," & iIDMoneda.ToString() & ", '" & gsUsuario & "'"

        cManager.ExecSP(storeName, sparameters)
        Me.chkTodosNiveles.EditValue = False
        RefreshGrid()
        MessageBox.Show("Proceso Exitoso...  ", "Exito", MessageBoxButtons.OK)
    End Sub
End Class