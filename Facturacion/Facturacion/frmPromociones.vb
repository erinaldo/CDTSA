Imports Clases
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Win
Imports DevExpress.XtraGrid.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.GridControl
Public Class frmPromociones
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsStoreProcNameGetData As String
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean = False
    Public gsCodeValue As String = ""
    Dim viewSelectedRow As GridView
    Dim currentRow As DataRow
    Dim sIDTabla As String = "0"
    Private Sub frmPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargagridLookUpsFromTables()
        RefreshGrid()
    End Sub

    Sub CargagridLookUpsFromTables()

        CargagridSearchLookUp(Me.SearchLookUpEditProveedor, "cppProveedor", "IDProveedor, Nombre, Activo", "", "IDProveedor", "Nombre", "IDProveedor")
        CargagridSearchLookUp(Me.SearchLookUpEditProducto, "invProducto", "IDProducto, Descr, Activo", "", "IDProducto", "Descr", "IDProducto")

    End Sub
    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        ' g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        ' g.Properties.PopupFormSize = New Size(900, 300)
        g.Properties.NullText = ""

    End Sub
    Sub RefreshGrid()
        Try
            Dim sProveedor As String
            If Me.chkDejarProv.EditValue = True And Me.SearchLookUpEditProveedor.Text <> "" Then
                sProveedor = SearchLookUpEditProveedor.EditValue.ToString
            Else
                sProveedor = "0"
            End If
            tableData = cManager.ExecSPgetData("fafgetPromociones", sProveedor)
            GridControl1.DataSource = tableData
            'GridColumn2.Caption = gsDescrName
            'GridColumn2.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "Elementos Registrados : {0:n0} ")
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub
    Sub AddDataToGrid(Optional ByVal sTodos As String = "0", Optional ByVal sOperacion As String = "I")
        Try

            Dim sParameters As String
            Dim sFechadesde As String = CDate(Me.DateEditDesde.EditValue).ToString("yyyyMMdd")
            Dim sFechaHasta As String = CDate(Me.DateEditHasta.EditValue).ToString("yyyyMMdd")
            sParameters = "'" & sOperacion & "'," & sIDTabla & " ," & SearchLookUpEditProveedor.EditValue.ToString() & "," & _
            SearchLookUpEditProducto.EditValue.ToString() & "," & _
             txtPorcDesc.Text & ", '" & sFechadesde & "','" & sFechaHasta & "'" & "," & sTodos
            tableData = cManager.ExecSPgetData("fafUpdatePromociones", sParameters)
            RefreshGrid()


        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try

    End Sub
    Private Function ControlsOk() As Boolean
        Dim lbok As Boolean = True

        If txtPorcDesc.Text Is Nothing Or String.IsNullOrEmpty(txtPorcDesc.Text) Then
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
    Private Sub ClearControls()
        Me.txtPorcDesc.Text = ""
        Me.DateEditDesde.Text = ""
        Me.DateEditHasta.Text = ""
        Me.SearchLookUpEditProducto.Text = ""
        If chkDejarProv.EditValue = False Then
            Me.SearchLookUpEditProveedor.Text = ""
        End If
    End Sub
    Private Sub GridViewDetalle_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalle.FocusedRowChanged
        Dim index As Integer = GridViewDetalle.FocusedRowHandle
        If index > -1 Then
            Dim dr As DataRow = GridViewDetalle.GetFocusedDataRow()
            currentRow = dr
            If dr IsNot Nothing Then
                sIDTabla = dr("IDPromocion").ToString()
                Me.SearchLookUpEditProveedor.EditValue = dr("IDProveedor").ToString()
                Me.SearchLookUpEditProducto.EditValue = dr("IDProducto").ToString()
                Me.txtPorcDesc.Text = dr("PorcDesc")
                Me.DateEditDesde.EditValue = CDate(dr("Desde"))
                Me.DateEditHasta.EditValue = CDate(dr("Hasta"))
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos de la bonificación, existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtPorcDesc.Focus()
                Return
            End If

            If Me.chkTodosProd.EditValue = True Then
                If MessageBox.Show("Ud va a aplicar a todos los productos del Proveeedor el mismo descuento en las mismas fechas, Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    sTodos = "1"
                End If
            Else
                sTodos = "0"
                Dim foundRow() As DataRow
                Dim sCondicion As String
                sCondicion = "IDProveedor=" & Me.SearchLookUpEditProveedor.EditValue.ToString() & " and IDProducto =" & Me.SearchLookUpEditProducto.EditValue.ToString() & _
                    " And Desde ='" & Me.DateEditDesde.EditValue.ToString() & "' And " & " Hasta = '" & Me.DateEditHasta.EditValue.ToString() & "'"
                foundRow = tableData.Select(sCondicion)

                If foundRow IsNot Nothing And foundRow.Count > 0 Then
                    MessageBox.Show("Ese Descuento ya Existe, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos , existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtPorcDesc.Focus()
                Return
            End If

            If Me.chkTodosProd.EditValue = True Then
                If MessageBox.Show("Ud va a Eliminar todos los descuentos de todos los productos del Proveeedor, Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    sTodos = "1"
                End If
            Else
                sTodos = "0"

                If MessageBox.Show("Ud va a Eliminar un descuento para el producto " & Me.SearchLookUpEditProducto.Text & ", Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim sTodos As String = "0"
            If Not ControlsOk() Then
                MessageBox.Show("Por favor revise los datos , existe un campo incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtPorcDesc.Focus()
                Return
            End If

            If Me.chkTodosProd.EditValue = True Then
                If MessageBox.Show("Ud va a aplicar a todos los productos del Proveeedor el mismo descuento en las mismas fechas, Ud está de acuerdo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    sTodos = "1"
                End If
            Else
                sTodos = "0"

                'Dim foundRow() As DataRow
                'Dim sCondicion As String
                'sCondicion = "IDProveedor=" & Me.SearchLookUpEditProveedor.EditValue.ToString() & " and IDProducto =" & Me.SearchLookUpEditProducto.EditValue.ToString() 
                'foundRow = tableData.Select(sCondicion)

                'If (foundRow IsNot Nothing And foundRow.Count > 0) Then
                '    MessageBox.Show("Esa Descuento no Existe, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Return

                'End If
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

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim file As New SaveFileDialog()
        file.Filter = "Archivo XLS|*.xls"
        If file.ShowDialog() = DialogResult.OK Then
            Me.GridControl1.ExportToXls(file.FileName)

        End If
    End Sub

    Private Sub chkVerTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTodos.CheckedChanged
        If Me.chkVerTodos.EditValue = True Then
            RefreshGrid()
            ClearControls()
        End If
    End Sub
End Class