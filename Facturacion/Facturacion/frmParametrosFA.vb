Imports Clases
Imports DevExpress.XtraEditors
Public Class frmParametrosFA
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Dim iIDParametros As Integer
    Private Sub frmParametrosFA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargagridLookUpsFromTables()

        CargaControlsFromRegister()

    End Sub
    Sub CargaControlsFromRegister()
        Try
            Dim t As DataTable

            t = cManager.GetDataTable("fafParametros", "IDParametros", "IDParametros >0", "IDParametros")
            If t.Rows.Count > 0 Then
                iIDParametros = t.Rows(0).Item(0)
            Else
                iIDParametros = 0
            End If
            tableData = cManager.ExecSPgetData("fafgetParametros", iIDParametros.ToString)
            If tableData.Rows.Count > 0 Then
                Me.SearchLookUpEditPrecioPublico.EditValue = tableData.Rows(0).Item("IDNivelPrecioPub")
                Me.SearchLookUpEditCondicionContado.EditValue = tableData.Rows(0).Item("IDPlazoCont")
                Me.SearchLookUpEditTCFacturacion.EditValue = tableData.Rows(0).Item("TipoCambioFact")
                Me.SearchLookUpEditTCContaibilidad.EditValue = tableData.Rows(0).Item("TipoCambioCont")
                Me.chkIntContable.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("IntegracionCont"))
                Me.txtLineasFac.EditValue = CInt(tableData.Rows(0).Item("NumeroLineasFact"))
                Me.SearchLookUpEditPaquete.EditValue = tableData.Rows(0).Item("IDPaquete")
                Me.SearchLookUpEditCentroImp.EditValue = tableData.Rows(0).Item("ctrImpuesto")
                Me.SearchLookUpEditCtaImpuesto.EditValue = tableData.Rows(0).Item("ctaImpuesto")
                Me.chkEditAutorizaPrecioFac.EditValue = tableData.Rows(0).Item("AutorizaPrecioPorFactura")
                Me.txtAltoFactura.EditValue = tableData.Rows(0).Item("paginaFacturaAltura")
                Me.txtAnchoFactura.EditValue = tableData.Rows(0).Item("paginaFacturaAncho")
                Me.chkPersonalizada.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("FacturaPersonalizada"))
                Me.chkDefTipo.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("DefaultTipoFact"))
                Me.SearchLookUpEditTipoFact.EditValue = tableData.Rows(0).Item("TipoFactDefault")
                Me.chkDefTipEnt.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("DefaultTipoEntrega"))
                Me.SearchLookUpEditEntrega.EditValue = tableData.Rows(0).Item("TipoEntregaDefault")
                Me.chkEditaPrecPedido.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("EditaPrecioPedidoenFactura"))
                Me.chkEditaCantidadPedFact.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("EditaCantidadPedidoenFactura"))
            End If
        Catch ex As Exception
            MessageBox.Show("Error al obtener los Parámetros Globales " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub CargagridLookUpsFromTables()

        'CargagridSearchLookUp(Me.SearchLookUpEditCliente, "vClientes", "IDCliente, Nombre, Telefono, Farmacia,Direccion, DescrTipo, DescrCategoria, Activo", "", "IDCliente", "Nombre", "IDCliente")
        CargagridSearchLookUp(Me.SearchLookUpEditPrecioPublico, "fafNivelPrecio", "IDNivel, Descr, Activo", "", "IDNivel", "Descr", "IDNivel")
        CargagridSearchLookUp(Me.SearchLookUpEditCondicionContado, "ccfPlazo", "Plazo, Descr, Activo", "", "Plazo", "Descr", "Plazo")
        CargagridSearchLookUp(Me.SearchLookUpEditTCFacturacion, "globalTipoCambio", "IDTipoCambio, Descr, Activo", "", "IDTipoCambio", "Descr", "IDTipoCambio")
        CargagridSearchLookUp(Me.SearchLookUpEditTCContaibilidad, "globalTipoCambio", "IDTipoCambio, Descr, Activo", "", "IDTipoCambio", "Descr", "IDTipoCambio")
        CargagridSearchLookUp(Me.SearchLookUpEditPaquete, "invPaquete", "IDPaquete, Paquete, Descr", "", "IDPaquete", "Descr", "IDPaquete")
        CargagridSearchLookUp(Me.SearchLookUpEditCentroImp, "cntCentroCosto", "IDCentro, Centro, Descr", "", "IDCentro", "Descr", "IDCentro")
        CargagridSearchLookUp(Me.SearchLookUpEditCtaImpuesto, "cntCuenta", "IDCuenta, Cuenta, Descr", "", "IDCuenta", "Descr", "IDCuenta")
        CargagridSearchLookUp(Me.SearchLookUpEditTipoFact, "fafTipoFactura", "IDTipo, Descr", "", "IDTipo", "Descr", "IDTipo")
        CargagridSearchLookUp(Me.SearchLookUpEditEntrega, "fafTipoEntrega", "IDTipoEntrega, Descr", "", "IDTipoEntrega", "Descr", "IDTipoEntrega")
    End Sub
    'Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
    '    g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
    '    g.Properties.DisplayMember = sDisplayMember
    '    g.Properties.ValueMember = sValueMember
    '    g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
    '    g.Properties.PopupFormSize = New Size(250, 250)
    '    g.Properties.NullText = ""

    'End Sub

    Private Function DatosOk() As Boolean

        If SearchLookUpEditPrecioPublico.EditValue = Nothing Then MsgBox("Debe seleccionar un NIvel de Precios al Publico", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.SearchLookUpEditPrecioPublico.Focus() : Return False : Exit Function
        If SearchLookUpEditCondicionContado.EditValue < 0 Then MsgBox("Debe seleccionar un Plazo para el Cliente de Contado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.SearchLookUpEditCondicionContado.Focus() : Return False : Exit Function
        If SearchLookUpEditTCFacturacion.EditValue = Nothing Then MsgBox("Debe seleccionar un tipo de Cambio para la Facturación", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.SearchLookUpEditTCFacturacion.Focus() : Return False : Exit Function
        If SearchLookUpEditTCContaibilidad.EditValue = Nothing Then MsgBox("Debe seleccionar un tipo de Cambio para la Contabilizacion de la Factura", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.SearchLookUpEditTCContaibilidad.Focus() : Return False : Exit Function
        If Len(txtLineasFac.Text.Trim) = 0 Or Val(txtLineasFac.Text) = 0 Then MsgBox("El Numero de Lineas de la Factura no puede quedar vacio o Debe ser Mayor que Cero", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtLineasFac.Focus() : Return False : Exit Function
        If SearchLookUpEditPaquete.EditValue = Nothing Then MsgBox("Debe seleccionar un Paquete de Inventario para la Factura", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.SearchLookUpEditPaquete.Focus() : Return False : Exit Function
        If SearchLookUpEditCentroImp.EditValue = Nothing And SearchLookUpEditCentroImp.Text = "" Then MsgBox("Debe seleccionar un Centro de Costo para el Impuesto de la Factura", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.SearchLookUpEditCentroImp.Focus() : Return False : Exit Function
        If SearchLookUpEditCtaImpuesto.EditValue = Nothing And SearchLookUpEditCtaImpuesto.Text = "" Then MsgBox("Debe seleccionar una Cuenta Contable para el Impuesto de la Factura", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.SearchLookUpEditCtaImpuesto.Focus() : Return False : Exit Function
        If chkPersonalizada.Checked Then
            If Len(txtAltoFactura.Text.Trim) = 0 Or Val(txtAltoFactura.Text) = 0 Then MsgBox("El Alto de la Página de la Factura no puede quedar vacio o Debe ser Mayor que Cero en Centimetros", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtAltoFactura.Focus() : Return False : Exit Function
            If Len(txtAnchoFactura.Text.Trim) = 0 Or Val(txtAnchoFactura.Text) = 0 Then MsgBox("El Ancho de la Página de la Factura no puede quedar vacio o Debe ser Mayor que Cero en Centimetros", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtAnchoFactura.Focus() : Return False : Exit Function
        Else
            txtAltoFactura.Text = "0"
            txtAnchoFactura.Text = "0"
        End If
        Return True
    End Function
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If Not DatosOk() Then

                'MessageBox.Show("Favor Revise los datos de Parámetros Globales ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If CInt(Me.SearchLookUpEditCondicionContado.EditValue) > 1 Then
                MessageBox.Show("Error en el Plazo para los clientes de Contado... debe ser Cero dias de Plazo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim sParameters As String
            sParameters = iIDParametros.ToString() & ",'" & Me.SearchLookUpEditPrecioPublico.EditValue.ToString() & "'," & _
             Me.SearchLookUpEditCondicionContado.EditValue.ToString() & ",'" & Me.SearchLookUpEditTCFacturacion.EditValue.ToString() & "','" & _
            Me.SearchLookUpEditTCContaibilidad.EditValue.ToString() & "'," & Me.txtLineasFac.EditValue.ToString() & "," & IIf(Me.chkIntContable.EditValue = True, "1", "0") & _
             ", " & Me.SearchLookUpEditPaquete.EditValue.ToString() & "," & Me.SearchLookUpEditCentroImp.EditValue.ToString() & "," & Me.SearchLookUpEditCtaImpuesto.EditValue.ToString() & "," & IIf(Me.chkEditAutorizaPrecioFac.EditValue = True, "1", "0") & _
             ", " & Me.txtAltoFactura.EditValue.ToString() & ", " & Me.txtAnchoFactura.EditValue.ToString() & "," & IIf(Me.chkPersonalizada.EditValue = True, "1", "0") & "," & IIf(Me.chkDefTipo.EditValue = True, "1", "0") & "," & Me.SearchLookUpEditTipoFact.EditValue.ToString() & _
            "," & IIf(Me.chkDefTipEnt.EditValue = True, "1", "0") & "," & Me.SearchLookUpEditEntrega.EditValue.ToString() & "," & IIf(Me.chkEditaPrecPedido.EditValue = True, "1", "0") & "," & IIf(Me.chkEditaCantidadPedFact.EditValue = True, "1", "0")
            If cManager.ExecSP("fafUpdateParametros", sParameters) Then
                MessageBox.Show("Parámetros Globales actualizados exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al actualizar los Parámetros Globales " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkPersonalizada_CheckedChanged(sender As Object, e As EventArgs) Handles chkPersonalizada.CheckedChanged
        If chkPersonalizada.Checked Then
            Me.txtAltoFactura.Enabled = True
            Me.txtAnchoFactura.Enabled = True
        Else
            txtAltoFactura.Text = "0"
            txtAnchoFactura.Text = "0"
            Me.txtAltoFactura.Enabled = False
            Me.txtAnchoFactura.Enabled = False

        End If
    End Sub

    Private Sub chkDefTipo_CheckedChanged(sender As Object, e As EventArgs) Handles chkDefTipo.CheckedChanged
        If chkDefTipo.Checked Then
            Me.SearchLookUpEditTipoFact.Enabled = True
        Else
            Me.SearchLookUpEditTipoFact.Enabled = False
        End If
    End Sub

    Private Sub chkDefTipEnt_CheckedChanged(sender As Object, e As EventArgs) Handles chkDefTipEnt.CheckedChanged
        If chkDefTipEnt.Checked Then
            Me.SearchLookUpEditEntrega.Enabled = True
        Else
            Me.SearchLookUpEditEntrega.Enabled = False
        End If
    End Sub
End Class