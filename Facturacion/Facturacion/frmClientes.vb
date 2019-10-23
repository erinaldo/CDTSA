Imports Clases
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports DevExpress.XtraExport
Imports System.IO

Public Class frmClientes
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsStoreProcNameGetData As String
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean = False
    Public gsCodeValue As String = ""
    Public gbEdit As Boolean = False
    Public gbAdd As Boolean = False
    Public gImage As Image

    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            CargagridLookUpsFromTables()
            If gbAdd Then
                seteaControlsNewRecord()
            End If
            If gbEdit Then
                CargaControlsFromOneRegister()
            End If
            Me.DateEditIngreso.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al cargar los datos..." & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Sub seteaControlsNewRecord()
        If gbAdd Then
            tableData = cManager.GetDataTable("ccfClientes", "isnull(Max(IDCliente),0) IDCliente", "", "IDCliente")
            If tableData.Rows.Count > 0 Then
                Me.txtIDCliente.Text = CInt(tableData.Rows(0)(0)) + 1
            End If
            Me.chkActivo.EditValue = True
            Me.DateEditIngreso.EditValue = Today()
            Me.chkActivo.Enabled = False
            Me.chkCredito.Enabled = True
            Me.chkCredito.Checked = True
            Me.chkEditaNombre.Checked = False
            Me.DateEditIngreso.Enabled = False
            Me.txtLimite.Text = "0"
            Me.txtInteres.Text = "0"
            Me.txtNombre.Text = ""
            Me.txtRuc.Text = ""
            Me.txtTelefono.Text = ""
            Me.txtweb.Text = ""
            Me.txtFarmacia.Text = ""
            Me.txtemail.Text = ""
            Me.txtDueno.Text = ""
            Me.txtCedula.Text = ""
            Me.txtCelular.Text = ""
            Me.gridlookupTipo.Text = ""
            Me.gridLookUpNivel.Text = ""
            Me.gridLookUpMoneda.Text = ""
            Me.gridLookUpPlazo.Text = ""
            Me.gridlookupSucursal.Text = ""
            Me.GridLookUpCategoria.Text = ""
            Me.gridlookupVendedor.Text = ""
            Me.gridlookupDepto.Text = ""
            Me.gridlookupMunicipio.Text = ""
            Me.gridlookupZona.Text = ""
            Me.gridlookupSubZona.Text = ""
            Me.chkEditaNombre.Text = ""
            Me.SearchLookUpEditClienteCorp.Text = ""
        End If
    End Sub

    Sub CargagridLookUpsFromTables()
        CargagridLookUp(Me.GridLookUpCategoria, "fafCategoriaCliente", "IDCategoria, Descr, Activo", "", "IDCategoria", "Descr", "IDCategoria")
        CargagridLookUp(Me.gridlookupTipo, "fafTipoCliente", "IDTipo, Descr, Activo", "", "IDTipo", "Descr", "IDTipo")
        CargagridLookUp(Me.gridLookUpNivel, "fafNivelPrecio", "IDNivel, Descr, IDMoneda", "", "IDNivel", "Descr", "IDNivel")
        CargagridLookUp(Me.gridLookUpMoneda, "GlobalMoneda", "IDMoneda, Descr, Activo", "", "IDMoneda", "Descr", "IDMoneda")
        CargagridLookUp(Me.gridlookupVendedor, "fafVendedor", "IDVendedor, Nombre, Activo", "", "IDVendedor", "Nombre", "IDVendedor")
        CargagridLookUp(Me.gridlookupDepto, "globalDepto", "IDDepto, Descr, Activo", "", "IDDepto", "Descr", "IDDepto")
        ' el municipio se debe cargar cuando se haya selecionado el depto
        CargagridLookUp(Me.gridlookupZona, "globalZona", "IDZona, Descr, Activo", "", "IDZona", "Descr", "IDZona")
        ' la SubZona se debe cargar cuando se haya selecionado la Zona
        CargagridLookUp(Me.gridlookupSucursal, "invBodega", "IDBodega, Descr, Activo", "", "IDBodega", "Descr", "IDBodega")
        CargagridLookUp(Me.gridLookUpPlazo, "ccfPlazo", "Plazo, Descr, Activo", "", "Plazo", "Descr", "Plazo")
        CargagridSearchLookUp(Me.SearchLookUpEditClienteCorp, "ccfClientes", "IDCliente, Nombre, Activo", "EsCorporacion=1", "Nombre", "Nombre", "IDCliente")
        gridLookUpMoneda.ReadOnly = True
    End Sub

    Sub CargaControlsFromOneRegister()

        tableData = cManager.ExecSPgetData(gsStoreProcNameGetData, gsCodeValue)
        Me.txtIDCliente.EditValue = tableData.Rows(0).Item("IDCliente").ToString()
        Me.txtIDCliente.Enabled = False
        Me.txtNombre.EditValue = tableData.Rows(0).Item("Nombre").ToString()
        Me.txtRuc.EditValue = tableData.Rows(0).Item("RUC").ToString()
        Me.txtDueno.EditValue = tableData.Rows(0).Item("Dueno").ToString()
        Me.txtemail.EditValue = tableData.Rows(0).Item("email").ToString()
        Me.txtweb.EditValue = tableData.Rows(0).Item("pweb").ToString()
        Me.txtweb.EditValue = tableData.Rows(0).Item("pweb").ToString()
        Me.DateEditIngreso.EditValue = tableData.Rows(0).Item("FechaIngreso")
        If Not IsDBNull(tableData.Rows(0).Item("LimiteCredito")) Then
            '    Me.txtLimite.EditValue = vbNull
            'Else
            Me.txtLimite.EditValue = CDbl(tableData.Rows(0).Item("LimiteCredito"))
        End If
        If Not IsDBNull(tableData.Rows(0).Item("PorcInteres")) Then
            Me.txtInteres.EditValue = CDbl(tableData.Rows(0).Item("PorcInteres"))
        End If

        Me.chkActivo.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("Activo"))
        Me.chkFarmacia.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("EsFarmacia"))
        If Not IsDBNull(tableData.Rows(0).Item("Farmacia")) Then
            Me.txtFarmacia.EditValue = tableData.Rows(0).Item("Farmacia").ToString()
        End If
        If Not IsDBNull(tableData.Rows(0).Item("Direccion")) Then
            Me.MemoEditDireccion.EditValue = tableData.Rows(0).Item("Direccion").ToString()
        End If

        If Not IsDBNull(tableData.Rows(0).Item("Telefono")) Then
            Me.txtTelefono.EditValue = tableData.Rows(0).Item("Telefono").ToString()
        End If

        If Not IsDBNull(tableData.Rows(0).Item("Celular")) Then
            Me.txtCelular.EditValue = tableData.Rows(0).Item("Celular").ToString()
        End If


        If Not IsDBNull(tableData.Rows(0).Item("Cedula")) Then
            Me.txtCedula.EditValue = tableData.Rows(0).Item("Cedula").ToString()
        End If


        Me.gridlookupTipo.EditValue = CInt(tableData.Rows(0).Item("IDTipo"))
        Me.gridLookUpNivel.EditValue = CInt(tableData.Rows(0).Item("IDNivel"))
        Me.gridLookUpMoneda.EditValue = CInt(tableData.Rows(0).Item("IDMoneda"))
        Me.gridLookUpPlazo.EditValue = CInt(tableData.Rows(0).Item("Plazo"))
        Me.gridlookupSucursal.EditValue = CInt(tableData.Rows(0).Item("IDSucursal"))
        Me.GridLookUpCategoria.EditValue = CInt(tableData.Rows(0).Item("IDCategoria"))
        Me.gridlookupVendedor.EditValue = CInt(tableData.Rows(0).Item("IDVendedor"))
        Me.gridlookupDepto.EditValue = CInt(tableData.Rows(0).Item("IDDepto"))
        Me.gridlookupMunicipio.EditValue = CInt(tableData.Rows(0).Item("IDMunicipio"))
        Me.gridlookupZona.EditValue = CInt(tableData.Rows(0).Item("IDZona"))
        Me.gridlookupSubZona.EditValue = CInt(tableData.Rows(0).Item("IDSubZona"))
        Me.chkEditaNombre.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("EditaNombre"))
        If IsDBNull(tableData.Rows(0).Item("Escorporacion")) Then
            Me.chkMiembroCorp.EditValue = False
        Else
            Convert.ToBoolean(tableData.Rows(0).Item("Escorporacion"))
        End If
        If IsDBNull(tableData.Rows(0).Item("MiembroCorp")) Then
            Me.chkCorporativo.EditValue = False
        Else
            Me.chkMiembroCorp.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("Escorporacion"))
        End If
        If IsDBNull(tableData.Rows(0).Item("IDClienteCorp")) Then
            SearchLookUpEditClienteCorp.EditValue = ""
        Else
            SearchLookUpEditClienteCorp.EditValue = CInt(tableData.Rows(0).Item("IDClienteCorp"))
        End If



        Dim imageBytes As Byte()
        If Not IsDBNull(tableData.Rows(0)("Foto")) Then
            imageBytes = CType(tableData.Rows(0)("Foto"), Byte())
            Dim stream As Stream = New MemoryStream(imageBytes)
            Dim BMP As Bitmap = New Bitmap(stream)
            PictureBoxFoto.Image = CType(BMP.Clone, Bitmap)
            PictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage
        End If



    End Sub

    
    Sub CargagridLookUp(ByVal g As GridLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.NullText = ""
    End Sub

    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit 'DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        'g.Properties.PopupFormSize = New Size(250, 250)
        g.Properties.NullText = ""
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick

    End Sub

    Private Sub gridlookupDepto_EditValueChanged(sender As Object, e As EventArgs) Handles gridlookupDepto.EditValueChanged
        Dim sWhere As String
        If gridlookupDepto.Text <> "" Then
            sWhere = " IDDepto = " & gridlookupDepto.EditValue.ToString()
            CargagridLookUp(Me.gridlookupMunicipio, "globalMunicipio", "IDMunicipio, Descr, Activo", sWhere, "IDMunicipio", "Descr", "IDMunicipio")
        End If
    End Sub

    Private Sub gridlookupZona_EditValueChanged(sender As Object, e As EventArgs) Handles gridlookupZona.EditValueChanged
        Dim sWhere As String
        If gridlookupZona.Text <> "" Then
            sWhere = " IDZona = " & gridlookupZona.EditValue.ToString()
            CargagridLookUp(Me.gridlookupSubZona, "globalSubZona", "IDSubZona, Descr, Activo", sWhere, "IDSubZona", "Descr", "IDSubZona")
        End If
    End Sub



    Private Sub PictureEditFoto_DoubleClick(sender As Object, e As EventArgs)
        Dim file As New OpenFileDialog()
        file.Filter = "Archivo JPG|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            PictureBoxFoto.Image = Image.FromFile(file.FileName)
        End If

    End Sub


    Private Sub BarButtonSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSave.ItemClick
        Dim storeName As String, sparameterValues As String
        Try
            If DatosValidos() = False Then

                Return
            End If
            storeName = "fafUpdateCliente"
            sparameterValues = IIf(gbAdd = True, "'I',", "'U',")
            sparameterValues = sparameterValues & txtIDCliente.Text & ",'"
            sparameterValues = sparameterValues & txtNombre.Text & "',"
            sparameterValues = sparameterValues & IIf(Me.chkFarmacia.Checked = True, 1, 0).ToString() & ","
            sparameterValues = sparameterValues & Me.gridlookupTipo.EditValue & ",'"
            sparameterValues = sparameterValues & Me.txtFarmacia.EditValue.ToString() & "',"
            sparameterValues = sparameterValues & Me.GridLookUpCategoria.EditValue.ToString() & ","
            sparameterValues = sparameterValues & Me.gridlookupVendedor.EditValue.ToString() & ","
            sparameterValues = sparameterValues & Me.gridlookupDepto.EditValue.ToString() & ","
            sparameterValues = sparameterValues & Me.gridlookupMunicipio.EditValue.ToString() & ","
            sparameterValues = sparameterValues & Me.gridlookupZona.EditValue.ToString() & ","
            sparameterValues = sparameterValues & Me.gridlookupSubZona.EditValue.ToString() & ","
            If IsNothing(Me.txtRuc.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.txtRuc.EditValue & "',"
            End If

            If IsNothing(Me.txtLimite.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & Me.txtLimite.EditValue & ","
            End If

            sparameterValues = sparameterValues & Me.gridlookupSucursal.EditValue.ToString() & ","

            If IsNothing(Me.MemoEditDireccion.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.MemoEditDireccion.EditValue & "',"
            End If


            If IsNothing(Me.txtTelefono.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.txtTelefono.EditValue.ToString() & "',"
            End If
            If IsNothing(Me.txtCelular.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.txtCelular.EditValue.ToString() & "',"
            End If

            If IsNothing(Me.txtDueno.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.txtDueno.EditValue.ToString() & "',"
            End If

            If IsNothing(Me.txtInteres.EditValue) Then
                sparameterValues = sparameterValues & "0,"
            Else
                sparameterValues = sparameterValues & Me.txtInteres.EditValue.ToString() & ","
            End If
            If Not IsNothing(Me.gridLookUpPlazo.EditValue) Then
                sparameterValues = sparameterValues & Me.gridLookUpPlazo.EditValue.ToString() & ","
            End If


            If IsNothing(Me.txtemail.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.txtemail.EditValue.ToString() & "',"
            End If

            If IsNothing(Me.txtweb.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.txtweb.EditValue.ToString() & "',"
            End If

            sparameterValues = sparameterValues & IIf(Me.chkActivo.Checked = True, 1, 0).ToString() & ","
            If IsNothing(Me.txtCedula.EditValue) Then
                sparameterValues = sparameterValues & "null,"
            Else
                sparameterValues = sparameterValues & "'" & Me.txtCedula.EditValue.ToString() & "'" & ","
            End If

            sparameterValues = sparameterValues & Me.gridLookUpNivel.EditValue.ToString() & ","
            sparameterValues = sparameterValues & Me.gridLookUpMoneda.EditValue.ToString() & ","
            sparameterValues = sparameterValues & IIf(Me.chkEditaNombre.Checked = True, 1, 0).ToString() & ","
            sparameterValues = sparameterValues & IIf(Me.chkCredito.Checked = True, 1, 0).ToString() & ","
            sparameterValues = sparameterValues & IIf(Me.chkCorporativo.Checked = True, 1, 0).ToString() & ","
            sparameterValues = sparameterValues & IIf(Me.chkMiembroCorp.Checked = True, 1, 0).ToString() & ","
            If IsNothing(Me.SearchLookUpEditClienteCorp.EditValue) Then
                sparameterValues = sparameterValues & "null"
            Else
                sparameterValues = sparameterValues & Me.SearchLookUpEditClienteCorp.EditValue.ToString()
            End If
            'sparameterValues = sparameterValues & IIf(Me.SearchLookUpEditClienteCorp.Text = "", "null", Me.SearchLookUpEditClienteCorp.EditValue.ToString())
            gImage = PictureBoxFoto.Image
            cManager.ExecSPwithImage(storeName, sparameterValues, gImage)
            'If Not gImage Is Nothing Then
            '    cManager.ExecSPwithImage(storeName, sparameterValues, gImage)
            'Else
            '    sparameterValues = sparameterValues & "null"
            '    cManager.ExecSP(storeName, sparameterValues)

            'End If

            MessageBox.Show("El registro ha sido guardado exitosamente ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message & " parametros ")
        End Try

    End Sub



    Private Sub PictureBoxFoto_Click(sender As Object, e As EventArgs) Handles PictureBoxFoto.Click
        Dim file As New OpenFileDialog()
        file.Filter = "Archivo JPG|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            gImage = Image.FromFile(file.FileName)
            PictureBoxFoto.Image = gImage
            PictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage

        End If
    End Sub
    ' Exisgir campso solo letras y campos solo numeros
    Private Sub ValidaLetraNumero(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtIDCliente.KeyPress, txtNombre.KeyPress, txtRuc.KeyPress, txtLimite.KeyPress, txtTelefono.KeyPress, txtCelular.KeyPress, txtInteres.KeyPress       ' etc 
        Select Case sender.name
            ' Case "txtNombre" ', "tex_otros"
            '    e.KeyChar = Chr(Solo_Letras(Asc(e.KeyChar)))
            Case "txtIDCliente", "txtRuc", "txtLimite", "txtTelefono", "txtCelular", "txtInteres"
                e.KeyChar = Chr(Solo_Numeros(Asc(e.KeyChar)))
        End Select
    End Sub
    ' validar blancos y nullos
    Private Function DatosValidos() As Boolean
        If Len(txtIDCliente.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtIDCliente.Focus() : Return False : Exit Function
        If Len(txtNombre.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtNombre.Focus() : Return False : Exit Function
        If Len(txtFarmacia.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtFarmacia.Focus() : Return False : Exit Function
        If gridlookupTipo.EditValue = Nothing Then MsgBox("Debe seleccionar un Tipo de Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupTipo.Focus() : Return False : Exit Function
        If GridLookUpCategoria.EditValue = Nothing Then MsgBox("Debe seleccionar una Categoria del Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.GridLookUpCategoria.Focus() : Return False : Exit Function
        If Me.DateEditIngreso.EditValue = Nothing Then MsgBox("La feha de ingreso no puede quedar vacia", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.DateEditIngreso.Focus() : Return False : Exit Function
        If gridLookUpNivel.EditValue = Nothing Then MsgBox("Debe seleccionar un NIvel de Precios del Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridLookUpNivel.Focus() : Return False : Exit Function
        If gridLookUpMoneda.EditValue = Nothing Then MsgBox("Debe seleccionar una Moneda para el Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridLookUpMoneda.Focus() : Return False : Exit Function
        If gridLookUpPlazo.EditValue = Nothing Then MsgBox("Debe seleccionar un Plazo del Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridLookUpPlazo.Focus() : Return False : Exit Function
        If gridlookupDepto.EditValue = Nothing Then MsgBox("Debe seleccionar un Departamento para el Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupDepto.Focus() : Return False : Exit Function
        If gridlookupMunicipio.EditValue = Nothing Then MsgBox("Debe seleccionar un Departamento para el Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupMunicipio.Focus() : Return False : Exit Function
        If gridlookupZona.EditValue = Nothing Then MsgBox("Debe seleccionar una Zona para el Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupZona.Focus() : Return False : Exit Function
        If gridlookupSubZona.EditValue = Nothing Then MsgBox("Debe seleccionar una SubZona para el Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupSubZona.Focus() : Return False : Exit Function
        If gridlookupSucursal.EditValue = Nothing Then MsgBox("Debe seleccionar una Sucursal para el Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupSucursal.Focus() : Return False : Exit Function
        If gridlookupVendedor.EditValue = Nothing Then MsgBox("Debe seleccionar un Vendedor para el Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupVendedor.Focus() : Return False : Exit Function
        'If Len(Me.MemoEditDireccion.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : MemoEditDireccion.Focus() : Return False : Exit Function
        'If Len(Me.txtDueno.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtDueno.Focus() : Return False : Exit Function
        'If Len(Me.txtCedula.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtCedula.Focus() : Return False : Exit Function
        'If Len(Me.txtemail.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtemail.Focus() : Return False : Exit Function
        'If Len(Me.txtweb.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtweb.Focus() : Return False : Exit Function
        'If Me.PictureBoxFoto.Image Is Nothing Then MsgBox("Por favor seleccione una foto para el cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.PictureBoxFoto.Focus() : Return False : Exit Function
        Return True
    End Function



    Private Sub chkFarmacia_CheckedChanged(sender As Object, e As EventArgs) Handles chkFarmacia.CheckedChanged
        If chkFarmacia.EditValue = True Then
            txtFarmacia.Enabled = True
        Else
            txtFarmacia.Text = ""
            txtFarmacia.Enabled = False
        End If
    End Sub

    Private Sub BarButtonNuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonNuevo.ItemClick
        'Me.Dispose()
        'Dim frm As New frmClientes()
        'frm.gsCodeName = "IDCliente"
        'frm.gsCodeValue = 2
        'frm.gsStoreProcNameGetData = "fafgetClientes"
        'frm.gbCodeNumeric = True
        'frm.gbAdd = True
        'frm.Show()
        gbCodeNumeric = True
        gsCodeValue = "0"
        gbAdd = True
        gbEdit = False

        seteaControlsNewRecord()

    End Sub

    Private Sub BarButtonDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonDelete.ItemClick
        Dim storeName As String, sparameterValues As String
        Try
            If DatosValidos() = False Then

                Return
            End If
            storeName = "fafUpdateCliente"
            sparameterValues = "'D',"
            sparameterValues = sparameterValues & txtIDCliente.Text & ",'"
            sparameterValues = sparameterValues & txtNombre.Text & "'" 
            cManager.ExecSPwithImage(storeName, sparameterValues, gImage)

            MessageBox.Show("El registro ha sido eliminado exitosamente ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Close()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message & " parametros ")
        End Try

    End Sub


    Private Sub gridLookUpNivel_EditValueChanged(sender As Object, e As EventArgs) Handles gridLookUpNivel.EditValueChanged
        Dim IDMoneda As Object = gridLookUpNivel.Properties.View.GetFocusedRowCellValue("IDMoneda")
        Me.gridLookUpMoneda.EditValue = IDMoneda
    End Sub

    Private Sub chkCorporativo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCorporativo.CheckedChanged
        If chkCorporativo.Checked = True And chkMiembroCorp.Checked Then
            MessageBox.Show("Un cliente no puede ser Corporativo Matriz y Miembro a la vez ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            chkMiembroCorp.Checked = False
            Return
        End If
        If chkCorporativo.Checked = True Then
            Me.SearchLookUpEditClienteCorp.Text = ""
            Me.SearchLookUpEditClienteCorp.Enabled = False
        End If
    End Sub

    Private Sub chkMiembroCorp_CheckedChanged(sender As Object, e As EventArgs) Handles chkMiembroCorp.CheckedChanged
        If chkCorporativo.Checked = True And chkMiembroCorp.Checked Then
            MessageBox.Show("Un cliente no puede ser Corporativo Matriz y Miembro a la vez ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            chkCorporativo.Checked = False
            Return
        End If
        If chkMiembroCorp.Checked = True Then
            Me.SearchLookUpEditClienteCorp.Enabled = True


        End If

    End Sub

    Private Sub BarButtonOut_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonOut.ItemClick
        Close()
    End Sub
End Class
