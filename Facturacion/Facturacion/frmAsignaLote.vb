Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid.GridView
Imports Clases
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraRichEdit.Layout

Public Class frmAsignaLote
    Dim cManager As New ClassManager
    Public tableData As New DataTable()
    Public tableLotesAsignados As New DataTable()
    Public gbAsignaLotes As Boolean
    Dim tblBonif As New DataTable()
    Dim t As New DataTable()
    Public gsIDProducto As String
    Public gsIDBodega As String
    Public gsDescr As String
    Public gsCantidad As String
    Public gsCantidadBonifPedido As String = ""
    Public gbLotesAsignados As Boolean = False
    Public gbBonifica As Boolean = False
    Public gbBonificaProd As Boolean = False
    Public gdTotalBonificado As Decimal = 0
    Dim gbErrorEnLote As Boolean = False

    Private Sub frmAsignaLote_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
 
    End Sub


    Private Sub frmAsignaLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lbok As Boolean
        Try
            gbLotesAsignados = False
            Me.chkBonifica.Enabled = True
            Me.chkBonifProd.Enabled = True
            FormatNumbers()
            If gsCantidadBonifPedido <> "" And Val(gsCantidadBonifPedido) <> 0 Then
                Me.lblBonifPedido.Visible = True
                Me.txtBonifPedido.Visible = True
                Me.txtBonifPedido.EditValue = CDec(gsCantidadBonifPedido)
                'Me.chkBonifica.Checked = True
                'Me.chkBonifProd.Checked = True
            Else
                Me.lblBonifPedido.Visible = False
                Me.txtBonifPedido.Visible = False
                'Me.chkBonifica.Checked = False
                'Me.chkBonifProd.Checked = False
            End If
            txtProducto.Text = gsDescr
            txtCantidad.EditValue = CDec(gsCantidad)

            If gbAsignaLotes = False Then ' Solamente quiere ver el detalle de lotes asignado y no asignar
                tableData = cManager.ExecSPgetData("fafgetProductoLote", "-1111" & "," & "-1")
                FiltraProducto(gsIDBodega, gsIDProducto)
                AssignFieldsToGrid()
                Me.datagridLotes.DataSource = tableData
                TotalizaGrid()
                lbok = True
                btnAplicar.Enabled = False

                Exit Sub

            End If

            'BORRO LOS REGISTROS DE LOTE DEL PRODUCTO 14 10 18
            If tableLotesAsignados.Rows.Count > 0 Then
                Dim foundRows As DataRow() = tableLotesAsignados.Select("IDProducto =" & gsIDProducto)
                If foundRows.Count > 0 Then

                    For Each foundrow In foundRows
                        foundrow.Delete()
                    Next foundrow
                End If
            End If
            tableData = cManager.ExecSPgetData("fafgetProductoLote", gsIDBodega & "," & gsIDProducto)
            AssignFieldsToGrid()
            Me.datagridLotes.DataSource = tableData
            SetCantLotes(CDec(gsCantidad))
            SetBonifLotes(CDec(txtBonifPedido.EditValue))
            TotalizaGrid()
            Me.GridViewProducto.Columns("AsignadoBO").OptionsColumn.AllowEdit = False
            Me.chkBonifica.Checked = gbBonifica
            Me.chkBonifProd.Checked = gbBonificaProd
            Me.chkBonifica.Enabled = False
            Me.chkBonifProd.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub FormatNumbers()
        FormatControlNumber(txtTotalBO)
        FormatControlNumber(txtTotalExistencia)
        FormatControlNumber(txtTotalAsignado)
        FormatControlNumber(txtCantidad)
        FormatControlNumber(txtBonifPedido)
    End Sub
    Private Sub FiltraProducto(sBodega As String, sIDProducto As String)
        Dim strCriteria As String = "IDBodega=" + sBodega + " and IDProducto=" + sIDProducto
        Dim drSelect As DataRow() = dtFacturaLineaLote.Select(strCriteria)
        If drSelect.Length > 0 Then
            For Each row As DataRow In drSelect
                Dim r As DataRow = tableData.NewRow
                r("IDBodega") = row("IDBodega")
                r("IDProducto") = row("IDProducto")
                r("Descr") = Me.txtProducto.Text  ' row("Descr")
                r("IDLote") = row("IDLote")
                r("LoteInterno") = row("LoteInterno")
                r("LoteProveedor") = row("LoteProveedor")
                r("FechaVencimiento") = row("Vencimiento")
                r("Existencia") = Convert.ToDecimal(row("Existencia"))
                r("AsignadoFA") = Convert.ToDecimal(row("AsignadoFA"))
                r("AsignadoBO") = Convert.ToDecimal(row("AsignadoBO"))

                tableData.Rows.Add(r)
            Next
            datagridLotes.DataSource = tableData
        End If
    End Sub
    Sub AssignFieldsToGrid()
        'Me.GridViewProducto.OptionsBehavior.Editable = False
        Me.GridViewProducto.Columns.AddField("IDBodega")
        Me.GridViewProducto.Columns(0).Caption = "Bodega"
        Me.GridViewProducto.Columns(0).Visible = True
        Me.GridViewProducto.Columns("IDBodega").OptionsColumn.AllowEdit = False
        Me.GridViewProducto.Columns(0).Width = 60
        Me.GridViewProducto.Columns.AddField("IDProducto")
        Me.GridViewProducto.Columns(1).Caption = "Producto"
        Me.GridViewProducto.Columns(1).Visible = True
        Me.GridViewProducto.Columns("IDProducto").OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns(1).Width = 60
        Me.GridViewProducto.Columns.AddField("Descr")
        Me.GridViewProducto.Columns(2).Width = 200
        Me.GridViewProducto.Columns(2).Visible = True
        Me.GridViewProducto.Columns(2).OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns.AddField("IDLote")
        Me.GridViewProducto.Columns(3).Caption = "IDLote"
        Me.GridViewProducto.Columns(3).Visible = True
        Me.GridViewProducto.Columns(3).OptionsColumn.AllowEdit = False

        Me.GridViewProducto.Columns.AddField("LoteInterno")
        Me.GridViewProducto.Columns(4).Width = 80
        Me.GridViewProducto.Columns(4).Visible = True
        Me.GridViewProducto.Columns(4).OptionsColumn.AllowEdit = False
        Me.GridViewProducto.Columns.AddField("LoteProveedor")
        Me.GridViewProducto.Columns(5).Width = 80
        Me.GridViewProducto.Columns(5).Caption = "LoteProveedor"
        Me.GridViewProducto.Columns(5).Visible = True
        Me.GridViewProducto.Columns(5).OptionsColumn.AllowEdit = False
        Me.GridViewProducto.Columns.AddField("FechaVencimiento")
        Me.GridViewProducto.Columns(6).Caption = "Vencimiento"
        Me.GridViewProducto.Columns(6).Visible = True
        Me.GridViewProducto.Columns(6).OptionsColumn.AllowEdit = False
        Me.GridViewProducto.Columns(6).Width = 70
        Me.GridViewProducto.Columns.AddField("Existencia")
        Me.GridViewProducto.Columns(7).Visible = True
        Me.GridViewProducto.Columns(7).OptionsColumn.AllowEdit = False
        Me.GridViewProducto.Columns(7).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns.AddField("AsignadoFA")
        Me.GridViewProducto.Columns(8).Visible = True
        Me.GridViewProducto.Columns(8).DisplayFormat.FormatString = "n2"
        If gbAsignaLotes Then
            Me.GridViewProducto.Columns(8).OptionsColumn.AllowEdit = True
        Else
            Me.GridViewProducto.Columns(8).OptionsColumn.AllowEdit = False
        End If
        ' Me.GridViewProducto.Columns(8).DisplayFormat.FormatString = "n2"
        Me.GridViewProducto.Columns.AddField("AsignadoBO")
        Me.GridViewProducto.Columns(9).Visible = True
        If gbAsignaLotes Then
            Me.GridViewProducto.Columns(9).OptionsColumn.AllowEdit = True
        Else
            Me.GridViewProducto.Columns(9).OptionsColumn.AllowEdit = False
        End If
        Me.GridViewProducto.Columns(9).DisplayFormat.FormatString = "n2"

        Me.GridViewProducto.Columns.AddField("LoteAsignado")
        Me.GridViewProducto.Columns(10).Visible = False
        Me.GridViewProducto.Columns(10).OptionsColumn.AllowEdit = False

    End Sub



    Sub AddDataToGrid(dt As DataTable)
        Try

            t.Columns.Add("IDBodega")
            t.Columns.Add("IDProducto")
            t.Columns.Add("Descr")
            t.Columns.Add("IDLote")
            t.Columns.Add("LoteInterno")
            t.Columns.Add("LoteProveedor")
            t.Columns.Add("FechaVencimiento")

            Dim dataColumn As DataColumn = New DataColumn("Existencia")
            dataColumn.DataType = System.Type.GetType("System.Decimal")
            dataColumn.DefaultValue = 0
            t.Columns.Add(dataColumn)
            't.Columns.Add("Existencia")
            Dim dataColumn2 As DataColumn = New DataColumn("AsignadoFA")
            dataColumn2.DataType = System.Type.GetType("System.Decimal")
            dataColumn2.DefaultValue = 0
            t.Columns.Add(dataColumn2)
            Dim dataColumn3 As DataColumn = New DataColumn("AsignadoBO")
            dataColumn3.DataType = System.Type.GetType("System.Decimal")
            dataColumn3.DefaultValue = 0
            t.Columns.Add(dataColumn3)
            Dim dCantidad As Decimal = Convert.ToDecimal(gsCantidad)
            Dim dCantAsignada As Decimal = 0
            For Each row As DataRow In dt.Rows
                Dim r As DataRow = t.NewRow
                Dim foundRow() As DataRow

                r("IDProducto") = row("IDProducto")
                r("Descr") = row("Descr")
                r("IDBodega") = row("IDBodega")
                r("IDLote") = row("IDLote")
                r("LoteInterno") = row("LoteInterno")
                r("LoteProveedor") = row("LoteProveedor")
                r("FechaVencimiento") = row("FechaVencimiento")
                'If dCantAsignada < dCantidad Then

                'End If
                If dCantAsignada <= Convert.ToDecimal(row("Existencia")) Then
                    dCantAsignada = dCantAsignada + Convert.ToDecimal(row("Existencia"))
                Else
                    dCantAsignada = dCantAsignada + Convert.ToDecimal(row("Existencia"))
                End If
                r("Existencia") = Convert.ToDecimal(row("Existencia"))
                r("AsignadoFA") = Convert.ToDecimal(row("AsignadoFA"))
                r("AsignadoBO") = Convert.ToDecimal(row("AsignadoBO"))
                foundRow = t.Select("IDProducto =" & row("IDProducto").ToString() & " And IDLote = " & row("IDLote").ToString())


                If Not (foundRow IsNot Nothing And foundRow.Count > 0) Then
                    t.Rows.Add(r)
                    't.ImportRow(r)
                    'row = Nothing
                End If

            Next row

            Me.datagridLotes.DataSource = t
            TotalizaGrid()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try

    End Sub

    Private Sub TotalizaGrid()
        Dim Existencia As Decimal = 0
        Dim Asignado As Decimal = 0
        Dim Bonificado As Decimal = 0
        If tableData.Rows.Count > 0 Then
            Existencia = Me.tableData.Compute("Sum(Existencia)", "")
            Asignado = tableData.Compute("Sum(AsignadoFA)", "")
            Bonificado = tableData.Compute("Sum(AsignadoBO)", "")
        End If
        Me.txtTotalAsignado.EditValue = Asignado
        Me.txtTotalExistencia.EditValue = Existencia
        Me.txtTotalBO.EditValue = Bonificado
        If Me.txtCantidad.EditValue > Asignado Then
            MessageBox.Show("La cantidad asignada en los lotes no cubre la cantidad a Facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        If Asignado > Me.txtCantidad.EditValue Then
            MessageBox.Show("La cantidad asignada en los lotes es mayor a la cantidad a Facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            gbErrorEnLote = True
        End If
        If Me.txtTotalExistencia.EditValue < (Asignado + Bonificado) Then
            MessageBox.Show("La cantidad existente en bodega es menor que la cantidad a Asignada y Bonificada, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub



    Private Sub GridViewProducto_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridViewProducto.ValidateRow
        Try
            Dim asignada As Decimal = Convert.ToDecimal(GridViewProducto.GetRowCellValue(e.RowHandle, "AsignadoFA"))
            Dim asignadaBO As Decimal = Convert.ToDecimal(GridViewProducto.GetRowCellValue(e.RowHandle, "AsignadoBO"))
            Dim Existencia As Decimal = Convert.ToDecimal(GridViewProducto.GetRowCellValue(e.RowHandle, "Existencia"))
            If (asignada + asignadaBO) > Existencia Then
                MessageBox.Show("Ud no puede asignar más que la existencia en ese lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GridViewProducto.SetRowCellValue(GridViewProducto.FocusedRowHandle, GridViewProducto.FocusedColumn, 0)
                gbErrorEnLote = True
            Else
                gbErrorEnLote = False
                TotalizaGrid()
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Editor_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            GridViewProducto.CloseEditor()
            GridViewProducto.UpdateCurrentRow()
            If gbErrorEnLote Then
                Exit Sub
            End If
            e.Handled = True
            Dim firstColumn As GridColumn = GridViewProducto.VisibleColumns(0)
            Dim lastColumn As GridColumn = GridViewProducto.VisibleColumns(GridViewProducto.VisibleColumns.Count - 1)
            Dim lastColumnIndex As Integer = lastColumn.VisibleIndex
            Dim nextColumnIndex As Integer = GridViewProducto.FocusedColumn.VisibleIndex + 1

            If nextColumnIndex <= lastColumnIndex Then
                GridViewProducto.FocusedRowHandle = GridViewProducto.FocusedRowHandle + 1
                'GridViewProducto.FocusedColumn = GridViewProducto.VisibleColumns(GridViewProducto.FocusedColumn.VisibleIndex + 1)
            Else
                GridViewProducto.MoveNext()
            End If
            TotalizaGrid()

        End If
    End Sub

    Private Sub GridViewProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProducto.KeyDown
        Editor_KeyDown(sender, e)
    End Sub

    Private Sub SetCantLotes(dCantFact As Decimal)
        Dim i As Integer = 0, bContinue As Boolean = True
        Dim valorFA As Decimal = 0, valorRestanteFA As Decimal

        valorRestanteFA = dCantFact

        While i <= (GridViewProducto.DataRowCount - 1) And bContinue = True
            'Para la cantidad a Facturar
            If CDec(GridViewProducto.GetRowCellValue(i, "Existencia")) >= valorRestanteFA Then
                valorFA = valorRestanteFA
                bContinue = False
                valorRestanteFA = 0
            Else
                valorRestanteFA = valorRestanteFA - CDec(GridViewProducto.GetRowCellValue(i, "Existencia"))
                valorFA = CDec(GridViewProducto.GetRowCellValue(i, "Existencia"))

            End If
            GridViewProducto.SetRowCellValue(i, "AsignadoFA", valorFA)

            i = i + 1
        End While
    End Sub


    Private Sub SetBonifLotes(dCantBonif As Decimal)
        Dim i As Integer = 0, bContinue As Boolean = True
        Dim valorBO As Decimal = 0, ValorRestanteBO As Decimal
        ValorRestanteBO = dCantBonif
        While i <= (GridViewProducto.DataRowCount - 1) And bContinue = True
            'Para la cantidad a BONIFICAR
            If CDec(GridViewProducto.GetRowCellValue(i, "Existencia")) - CDec(GridViewProducto.GetRowCellValue(i, "AsignadoFA")) >= ValorRestanteBO Then
                valorBO = ValorRestanteBO
                bContinue = False
                ValorRestanteBO = 0
            Else
                If CDec(GridViewProducto.GetRowCellValue(i, "Existencia")) - CDec(GridViewProducto.GetRowCellValue(i, "AsignadoFA")) > 0 Then
                    ValorRestanteBO = ValorRestanteBO - CDec(GridViewProducto.GetRowCellValue(i, "Existencia")) - CDec(GridViewProducto.GetRowCellValue(i, "AsignadoFA"))
                    valorBO = CDec(GridViewProducto.GetRowCellValue(i, "Existencia")) - CDec(GridViewProducto.GetRowCellValue(i, "AsignadoFA"))


                End If



            End If
            GridViewProducto.SetRowCellValue(i, "AsignadoBO", valorBO)
            i = i + 1
        End While
    End Sub


    Private Sub AplicaLote()
        If gsCantidadBonifPedido <> "" And Val(gsCantidadBonifPedido) <> 0 And Not Me.chkBonifica.Checked Then
            MessageBox.Show("En el Pedido se bonificó una cantidad y Ud no ha bonificado. Por favor marque Bonifica y luego digite el valor a bonificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If CDec(txtTotalAsignado.EditValue) > CDec(txtCantidad.EditValue) Then
            MessageBox.Show("Ud no puede asignar más que la cantidad a Facturar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If (CDec(txtTotalAsignado.EditValue) + CDec(txtTotalBO.EditValue)) > CDec(txtTotalExistencia.EditValue) Then
            MessageBox.Show("Ud no puede asignar más que la cantidad en Existencia ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        gdTotalBonificado = CDec(Me.txtTotalBO.EditValue)
        gbLotesAsignados = True
        If chkBonifica.Checked Then
            gbBonifica = True
        End If
        If chkBonifProd.Checked And chkBonifica.Checked Then
            gbBonificaProd = True
        End If
        CopyRows()

    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        AplicaLote()
        Me.Close()
    End Sub

    Private Sub CopyRows()
        Dim strCriteria As String = "AsignadoFA> 0 or AsignadoBO>0"
        Dim drSelect As DataRow() = tableData.Select(strCriteria)
        Dim localDataTable As DataTable = tableData.Clone

        If drSelect.Length > 0 Then
            For Each drItem As DataRow In drSelect
                Dim nrow As DataRow = drItem
                localDataTable.ImportRow(nrow)
            Next
            Me.tableLotesAsignados = localDataTable.Copy()
        End If
    End Sub

    Private Sub chkBonifica_CheckedChanged(sender As Object, e As EventArgs) Handles chkBonifica.CheckedChanged
        If chkBonifica.Checked = True Then

            'chkBonifProd.Enabled = True
            'chkBonifProd.Checked = True
            Me.GridViewProducto.Columns("AsignadoBO").OptionsColumn.AllowEdit = True

        Else
            'chkBonifProd.Checked = False
            'chkBonifProd.Enabled = False
            Me.GridViewProducto.Columns("AsignadoBO").OptionsColumn.AllowEdit = False
        End If
    End Sub

    'Sub AddDataFiltradaToGrid()
    '    Try
    '        Dim r As DataRow = dtFacturaLinea.NewRow

    '        r("IDProducto") = Me.txtCodigo.EditValue  ' Me.SearchLookUpEditProducto.EditValue
    '        ' r("Descr") = Me.SearchLookUpEditProducto.Text
    '        r("Descr") = Me.txtDescr.EditValue
    '        r("IDBodega") = Me.SearchLookUpEditSucursal.EditValue
    '        r("Cantidad") = Me.txtCantidad.Text
    '        r("PrecioLocal") = CDbl(Me.txtPrecio.Text)
    '        r("ImpuestoLocal") = CDbl(Me.txtImpuesto.Text)
    '        r("SubTotal") = CDbl(Me.txtPrecio.Text) * CDbl(txtCantidad.Text)
    '        r("PorcImp") = CDbl(txtPorcImp.Text)
    '        r("Total") = CDbl(Me.txtPrecio.Text) * CDbl(txtCantidad.Text) + CDbl(Me.txtImpuesto.Text)
    '        r("Bonifica") = CBool(chkBonifica.Checked)
    '        r("BonifConProd") = CBool(chkBonificaProd.Checked)
    '        r("LoteASignado") = gbLoteAsignado
    '        r("DescuentoEspecial") = 0
    '        r("Descuento") = 0
    '        dtFacturaLinea.Rows.Add(r)
    '        Me.GridControl1.DataSource = dtFacturaLinea
    '        gbLoteAsignado = False
    '    Catch ex As Exception
    '        MessageBox.Show("Ha ocurrido un error " & ex.Message)
    '    End Try

    'End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnBonif_Click(sender As Object, e As EventArgs) Handles btnBonif.Click
        Dim frm As New frmPopupBonificacion()
        frm.gsProductoID = gsIDProducto
        frm.ShowDialog()
        Me.txtRequerido.Text = frm.gdRequerido
        Me.txtBono.Text = frm.gdBono
        frm.Dispose()
    End Sub
End Class