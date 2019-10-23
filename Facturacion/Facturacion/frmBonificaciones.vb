Imports Clases
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Win
Imports DevExpress.XtraGrid.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.GridControl

Public Class frmBonificaciones
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsStoreProcNameGetData As String
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean = False
    Public gsCodeValue As String = ""
    Dim viewSelectedRow As GridView
    Dim currentRow As DataRow
    Dim sIDTabla As String = "0"


    Sub CargagridLookUpsFromTables()

        CargagridSearchLookUp(Me.SearchLookUpEditProveedor, "cppProveedor", "IDProveedor, Nombre, Activo", "", "IDProveedor", "Nombre", "IDProveedor")
        CargagridSearchLookUp(Me.SearchLookUpEditProducto, "invProducto", "IDProducto, Descr, Activo", "", "IDProducto", "Descr", "IDProducto")

    End Sub
    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        g.Properties.PopupFormSize = New Size(250, 250)
        g.Properties.NullText = ""

    End Sub

    Private Sub frmBonificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargagridLookUpsFromTables()
        RefreshGrid()
    End Sub
    Sub RefreshGrid()
        Try
            Dim sProveedor As String
            If Me.chkDejarProv.EditValue = True And Me.SearchLookUpEditProveedor.Text <> "" Then
                sProveedor = SearchLookUpEditProveedor.EditValue.ToString
            Else
                sProveedor = "0"
            End If
            tableData = cManager.ExecSPgetData("fafgetTablaBonificacion", sProveedor)
            GridControl1.DataSource = tableData
            'GridColumn2.Caption = gsDescrName
            'GridColumn2.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "Elementos Registrados : {0:n0} ")
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub
    'Sub AssignFieldsToGrid()
    '    Me.GridViewDetalle.Columns.AddField("IDProveedor)
    '    Me.GridViewProducto.Columns(0).Visible = True

    '    Me.GridViewDetalle.Columns.AddField("IDProducto")
    '    Me.GridViewProducto.Columns(0).Visible = True
    '    Me.GridViewProducto.Columns(0).Width = 50
    '    Me.GridViewProducto.Columns.AddField("Descr")
    '    Me.GridViewProducto.Columns(1).Width = 200
    '    Me.GridViewProducto.Columns(1).Visible = True
    '    Me.GridViewProducto.Columns.AddField("Cantidad")
    '    Me.GridViewProducto.Columns(2).Visible = True
    '    Me.GridViewProducto.Columns.AddField("PrecioLocal")
    '    Me.GridViewProducto.Columns(3).Caption = "Precio"
    '    Me.GridViewProducto.Columns(3).DisplayFormat.FormatString = "d2"
    '    Me.GridViewProducto.Columns(3).Visible = True
    '    Me.GridViewProducto.Columns.AddField("Impuesto")
    '    Me.GridViewProducto.Columns(4).Visible = True
    '    Me.GridViewProducto.Columns(4).DisplayFormat.FormatString = "d2"
    '    Me.GridViewProducto.Columns.AddField("SubTotal")
    '    Me.GridViewProducto.Columns(5).Visible = True
    '    Me.GridViewProducto.Columns(5).DisplayFormat.FormatString = "d2"
    '    Me.GridViewProducto.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '    Me.GridViewProducto.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '    Me.GridViewProducto.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '    Me.GridViewProducto.Columns(3).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '    Me.GridViewProducto.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '    Me.GridViewProducto.Columns(4).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '    Me.GridViewProducto.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '    Me.GridViewProducto.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

    'End Sub


    Sub AddDataToGrid(Optional ByVal sTodos As String = "0", Optional ByVal sOperacion As String = "I")
        Try

            Dim sParameters As String
            Dim sFechadesde As String = CDate(Me.DateEditDesde.EditValue).ToString("yyyyMMdd")
            Dim sFechaHasta As String = CDate(Me.DateEditHasta.EditValue).ToString("yyyyMMdd")
            sParameters = "'" & sOperacion & "'," & sIDTabla & " ," & SearchLookUpEditProveedor.EditValue.ToString() & "," & _
            SearchLookUpEditProducto.EditValue.ToString() & "," & txtRequerido.Text & "," & txtBono.Text & "," & _
            txtBonoProv.Text & "," & txtBonoDist.Text & ", '" & sFechadesde & "','" & sFechaHasta & "'" & "," & sTodos & "," & txtPrecio.Text & "," & txtPublico.Text
            tableData = cManager.ExecSPgetData("fafUpdateTablaBonificacion", sParameters)
            RefreshGrid()


        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try

    End Sub
    Private Function ControlsOk() As Boolean
        Dim lbok As Boolean = True
        If txtRequerido.Text Is Nothing Or String.IsNullOrEmpty(txtRequerido.Text) Then
            lbok = False
            Return lbok
        End If
        If txtPrecio.Text Is Nothing Or String.IsNullOrEmpty(txtPrecio.Text) Then
            lbok = False
            Return lbok
        End If
        If txtPublico.Text Is Nothing Or String.IsNullOrEmpty(txtPublico.Text) Then
            lbok = False
            Return lbok
        End If
        If txtBono.Text Is Nothing Or String.IsNullOrEmpty(txtBono.Text) Then
            lbok = False
            Return lbok
        End If
        If txtBonoProv.Text Is Nothing Or String.IsNullOrEmpty(txtBono.Text) Then
            lbok = False
            Return lbok
        End If
        If txtBonoDist.Text Is Nothing Or String.IsNullOrEmpty(txtBonoDist.Text) Then
            lbok = False
            Return lbok
        End If
        If Not IsDate(Me.DateEditDesde.Text) Then
            lbok = False
            Return lbok
        End If
        If Not IsDate(Me.DateEditHasta.Text) Then
            lbok = False
            Return lbok
        End If
        If Me.DateEditDesde.EditValue > Me.DateEditHasta.EditValue Then
            lbok = False
            Return lbok
        End If
        Return lbok
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos de la bonificación, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtRequerido.Focus()
                Return
            End If

            If Me.chkTodosProd.EditValue = True Then
                If MessageBox.Show("Ud va a aplicar a todos los productos del Proveeedor la misma bonificación en las mismas fechas, Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    sTodos = "1"
                End If
            Else
                sTodos = "0"
                Dim foundRow() As DataRow
                Dim sCondicion As String
                sCondicion = "IDProveedor=" & Me.SearchLookUpEditProveedor.EditValue.ToString() & " and IDProducto =" & Me.SearchLookUpEditProducto.EditValue.ToString() & _
                    " And Bono =" & txtBono.Text & " And " & " Requerido = " & txtRequerido.Text
                foundRow = tableData.Select(sCondicion)

                If foundRow IsNot Nothing And foundRow.Count > 0 Then
                    MessageBox.Show("Esa Bonificación ya Existe, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return

                End If
            End If



            AddDataToGrid(sTodos, "I")
            If Me.chkTodosProd.EditValue = True Then
                Me.chkTodosProd.EditValue = False
            End If
            If chkDejarProv.EditValue = False Then
                Me.SearchLookUpEditProveedor.Text = ""
            End If
        
            'ubico el cursor en la fila del filtro y no en la primera row
            GridViewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
            ClearControls()
            SearchLookUpEditProducto.Focus()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al agregar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearControls()
        Me.txtRequerido.Text = ""
        Me.txtBono.Text = ""
        Me.txtBonoDist.Text = ""
        Me.txtBonoProv.Text = ""
        Me.txtPrecio.Text = ""
        Me.txtPublico.Text = ""
        Me.DateEditDesde.Text = ""
        Me.DateEditHasta.Text = ""
        Me.SearchLookUpEditProducto.Text = ""
        If chkDejarProv.EditValue = False Then
            Me.SearchLookUpEditProveedor.Text = ""
        End If
    End Sub
    ' Exisgir campso solo letras y campos solo numeros
    Private Sub ValidaLetraNumero(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles txtRequerido.KeyPress, txtBono.KeyPress, txtBonoProv.KeyPress, txtBonoDist.KeyPress, DateEditDesde.KeyPress, DateEditHasta.KeyPress
        Dim strListaControles As String
        strListaControles = "txtRequerido, txtBono , txtBonoProv , txtBonoDist"
        If strListaControles.Contains(sender.name) = True And Asc(e.KeyChar) <> Keys.Return Then
            e.KeyChar = Chr(Solo_Numeros(Asc(e.KeyChar)))
        End If
        If sender.name = "txtRequerido" And Asc(e.KeyChar) = Keys.Return Then
            txtBono.Focus()
        End If
        If sender.name = "txtBono" And Asc(e.KeyChar) = Keys.Return Then
            Me.txtBonoProv.Focus()
        End If
        If sender.name = "txtBonoProv" And Asc(e.KeyChar) = Keys.Return Then
            Me.txtBonoDist.Focus()
        End If

        If sender.name = "txtBonoDist" And Asc(e.KeyChar) = Keys.Return Then
            Me.DateEditDesde.Focus()
        End If
        If sender.name = "DateEditDesde" And Asc(e.KeyChar) = Keys.Return Then
            Me.DateEditHasta.Focus()
        End If
    End Sub

    Private Sub txtRequerido_EditValueChanged(sender As Object, e As EventArgs) Handles txtRequerido.EditValueChanged

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos de la bonificación, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtRequerido.Focus()
                Return
            End If

            If Me.chkTodosProd.EditValue = True Then
                If MessageBox.Show("Ud va a aplicar a todos los productos del Proveeedor la misma bonificación en las mismas fechas, Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    sTodos = "1"
                End If
            Else
                sTodos = "0"

                Dim foundRow() As DataRow
                Dim sCondicion As String
                sCondicion = "IDProveedor=" & Me.SearchLookUpEditProveedor.EditValue.ToString() & " and IDProducto =" & Me.SearchLookUpEditProducto.EditValue.ToString() & _
                    " And Bono =" & txtBono.Text & " And " & " Requerido = " & txtRequerido.Text
                foundRow = tableData.Select(sCondicion)

                If (foundRow IsNot Nothing And foundRow.Count > 0) Then
                    MessageBox.Show("Esa Bonificación Existe, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return

                End If
            End If



            AddDataToGrid(sTodos, "U")
            If Me.chkTodosProd.EditValue = True Then
                Me.chkTodosProd.EditValue = False
            End If
            '            TotalizaGrid()
            'ubico el cursor en la fila del filtro y no en la primera row
            GridViewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
            ClearControls()
            SearchLookUpEditProducto.Focus()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al agregar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridViewDetalle_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalle.FocusedRowChanged
        Dim index As Integer = GridViewDetalle.FocusedRowHandle
        If index > -1 Then
            Dim dr As DataRow = GridViewDetalle.GetFocusedDataRow()
            currentRow = dr
            If dr IsNot Nothing Then
                sIDTabla = dr("IDTabla").ToString()
                Me.SearchLookUpEditProveedor.EditValue = dr("IDProveedor").ToString()
                Me.SearchLookUpEditProducto.EditValue = dr("IDProducto").ToString()
                Me.txtRequerido.Text = dr("Requerido")
                Me.txtBono.Text = dr("Bono")
                Me.txtBonoProv.Text = dr("CantBonifProv")
                Me.txtBonoDist.Text = dr("CantBonifDist")
                Me.DateEditDesde.EditValue = CDate(dr("Desde"))
                Me.DateEditHasta.EditValue = CDate(dr("Hasta"))
                Me.txtPrecio.EditValue = dr("Precio")
                Me.txtPublico.EditValue = dr("PrecioPublico")
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos de la bonificación, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtRequerido.Focus()
                Return
            End If

            If Me.chkTodosProd.EditValue = True Then
                If MessageBox.Show("Ud va a Eliminar la bonificación de todos los productos del Proveeedor, Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    sTodos = "1"
                End If
            Else
                sTodos = "0"

                If MessageBox.Show("Ud va a Eliminar la bonificación del producto " & Me.SearchLookUpEditProducto.Text & ", Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

            End If

            AddDataToGrid(sTodos, "D")
            If Me.chkTodosProd.EditValue = True Then
                Me.chkTodosProd.EditValue = False
            End If
            ClearControls()
            'ubico el cursor en la fila del filtro y no en la primera row
            GridViewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
            SearchLookUpEditProducto.Focus()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al eliminar el registro " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SearchLookUpEditProveedor_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEditProveedor.EditValueChanged
        Try
            If Me.SearchLookUpEditProveedor.Text = "" Then
                Return
            End If
            tableData = cManager.ExecSPgetData("fafgetTablaBonificacion", Me.SearchLookUpEditProveedor.EditValue.ToString())
            GridControl1.DataSource = tableData
            'GridColumn2.Caption = gsDescrName
            'GridColumn2.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "Elementos Registrados : {0:n0} ")
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim file As New SaveFileDialog()
        file.Filter = "Archivo XLS|*.xls"
        If file.ShowDialog() = DialogResult.OK Then
            Me.GridControl1.ExportToXls(file.FileName)


        End If
    End Sub

    Private Sub chkVerTabla_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTabla.CheckedChanged
        If Me.chkVerTabla.EditValue = True Then
            RefreshGrid()
            ClearControls()
        End If
    End Sub

    'Private Sub GridViewDetalle_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridViewDetalle.CustomDrawCell
    '    Dim view As GridView = sender
    '    Dim prevRow = e.RowHandle - 1
    '    If prevRow < 0 Or view.IsRowVisible(prevRow) <> RowVisibleState.Visible Then
    '        Return
    '    End If
    '    Dim preValue As Object = view.GetRowCellValue(prevRow, e.Column)
    '    Dim curValue As Object = e.CellValue
    '    If (curValue <> vbNull And curValue.Equals(preValue)) Then
    '        e.Style.FillRectangle(e.Graphics, e.Bounds)
    '        'e.System 
    '        'e.Graphics.FillRectangle(Brushes.Aqua, e.Bounds)
    '        'e.Handled = True
    '    End If

    'End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class