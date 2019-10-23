Imports Clases
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports DevExpress.XtraExport
Imports System.IO
Public Class frmVendedor
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsStoreProcNameGetData As String
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean = False
    Public gsCodeValue As String = ""
    Public gbEdit As Boolean = False
    Public gbAdd As Boolean = False
    Private Sub frmVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            CargagridLookUpsFromTables()
            If gbAdd Then
                seteaControlsNewRecord()
            End If
            If gbEdit Then
                CargaControlsFromOneRegister()
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al cargar los datos..." & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub seteaControlsNewRecord()
        If gbAdd Then
            Me.chkActivo.EditValue = True
        End If
    End Sub

    Sub CargagridLookUp(ByVal g As GridLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember

    End Sub

    Sub CargagridLookUpsFromTables()

        CargagridLookUp(Me.gridlookupTipo, "fafTipoVendedor", "IDTipo, Descr, Activo", "", "IDTipo", "Descr", "IDTipo")

    End Sub

    Sub CargaControlsFromOneRegister()

        tableData = cManager.ExecSPgetData(gsStoreProcNameGetData, gsCodeValue)
        Me.txtIDVendedor.EditValue = tableData.Rows(0).Item("IDVendedor").ToString()
        Me.txtIDVendedor.Enabled = False
        Me.txtNombre.EditValue = tableData.Rows(0).Item("Nombre").ToString()
        Me.txtemail.EditValue = tableData.Rows(0).Item("email").ToString()
        Me.chkActivo.EditValue = Convert.ToBoolean(tableData.Rows(0).Item("Activo"))
      
        Me.txtTelefono.EditValue = tableData.Rows(0).Item("Telefono").ToString()
        Me.txtCelular.EditValue = tableData.Rows(0).Item("Celular").ToString()
        Me.txtCedula.EditValue = tableData.Rows(0).Item("Cedula").ToString()
        Me.gridlookupTipo.EditValue = CInt(tableData.Rows(0).Item("IDTipo"))


    End Sub

    Private Sub BarButtonSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSave.ItemClick
        Dim storeName As String, sparameterValues As String
        Try
            If DatosValidos() = False Then

                Return
            End If
            storeName = "fafUpdateVendedor"
            sparameterValues = IIf(gbAdd = True, "'I',", "'U',")
            sparameterValues = sparameterValues & txtIDVendedor.Text & ",'"
            sparameterValues = sparameterValues & txtNombre.Text & "',"
            sparameterValues = sparameterValues & Me.gridlookupTipo.EditValue & ",'"
            sparameterValues = sparameterValues & Me.MemoEditDireccion.EditValue & "','"
            sparameterValues = sparameterValues & Me.txtTelefono.EditValue.ToString() & "','"
            sparameterValues = sparameterValues & Me.txtCelular.EditValue.ToString() & "','"
            sparameterValues = sparameterValues & Me.txtCedula.EditValue.ToString() & "'" & ","
            sparameterValues = sparameterValues & IIf(Me.chkActivo.Checked = True, 1, 0).ToString()
            
            cManager.ExecSP(storeName, sparameterValues)
            MessageBox.Show("El registro ha sido guardado exitosamente ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message & " parametros ")
        End Try

    End Sub
    Private Function DatosValidos() As Boolean
        If Len(txtIDVendedor.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtIDVendedor.Focus() : Return False : Exit Function
        If Len(txtNombre.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtNombre.Focus() : Return False : Exit Function
        If gridlookupTipo.EditValue = Nothing Then MsgBox("Debe seleccionar un Tipo de Cliente", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : Me.gridlookupTipo.Focus() : Return False : Exit Function
        If Len(Me.MemoEditDireccion.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : MemoEditDireccion.Focus() : Return False : Exit Function
        If Len(Me.txtCedula.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtCedula.Focus() : Return False : Exit Function
        If Len(Me.txtemail.Text.Trim) = 0 Then MsgBox("Dato no Puede quedar en Balnco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda") : txtemail.Focus() : Return False : Exit Function
        Return True
    End Function

    Private Sub BarButtonDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonDelete.ItemClick
        Dim storeName As String, sparameterValues As String
        Try
            If DatosValidos() = False Then

                Return
            End If
            storeName = "fafUpdateVendedor"
            sparameterValues = "'D',"
            sparameterValues = sparameterValues & txtIDVendedor.Text & ",'"
            sparameterValues = sparameterValues & txtNombre.Text & "'"
            cManager.ExecSP(storeName, sparameterValues)
            MessageBox.Show("El registro ha sido eliminado exitosamente ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message & " parametros ")
        End Try
    End Sub
End Class