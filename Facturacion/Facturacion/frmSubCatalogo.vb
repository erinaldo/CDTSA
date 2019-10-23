Imports Clases
Public Class frmSubCatalogo
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsTableNameMaster As String
    Dim gsFieldsNameMaster As String
    Public gsFieldsRestMaster As String = ""
    Public gsCodeNameMaster As String = ""
    Public gbCodeNumericMaster As Boolean
    Public gsStoreProcNameMaster As String
    Public gsParametersValuesMaster As String
    Public gsCaptionFrm As String = ""
    Public gsTableName As String = ""
    Public gsFieldsRest As String = ""
    Dim gsFieldsName As String
    Public gsWHere As String = ""
    Public gsOrder As String = ""
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean
    Public gsDescrName As String ' descripcion de la tabla a actualizar
    Public gsDescrNameMaster As String ' descripcion del master
    Dim bEdit As Boolean = False
    Dim bAdd As Boolean = False
    Dim sFieldsValueUpdate As String
    Private Sub frmSubCatalogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsFieldsName = gsCodeName & " Codigo," & gsDescrName & IIf(gsFieldsRest <> "", "," & gsFieldsRest, "")
        gsFieldsNameMaster = gsCodeNameMaster & " Codigo," & gsDescrNameMaster & IIf(gsFieldsRestMaster <> "", "," & gsFieldsRestMaster, "")
        Text = gsCaptionFrm
        RefreshGrid()
    End Sub

    Private Sub EnableControls(bActiva As Boolean)
        txtCodigo.Enabled = bActiva
        txtDescr.Enabled = bActiva
        Me.gridLookupDepto.Enabled = bActiva
        chkActivo.Enabled = bActiva
        If bAdd Or bEdit Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnsave.Enabled = True
            btnCancel.Enabled = True
        Else
            btnsave.Enabled = False
            btnCancel.Enabled = False
        End If


    End Sub

    Sub RefreshGrid()
        Try
            gridLookupDepto.Properties.DataSource = cManager.GetDataTable(gsTableNameMaster, gsFieldsNameMaster, "", gsCodeNameMaster)
            gridLookupDepto.Properties.DisplayMember = gsDescrName
            gridLookupDepto.Properties.ValueMember = "Codigo"
            gridLookupDepto.EditValue = "" 'gridLookupDepto.Properties.GetKeyValue(0)
            gridLookupDepto.Refresh()
            EnableControls(False)
            tableData = cManager.ExecSPgetData(gsStoreProcNameMaster, gsParametersValuesMaster)
            GridControl1.DataSource = tableData
            GridColumn2.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "Elementos Registrados : {0:n0} ")
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            PreparaAdicion()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & ex.Message, "Error", MessageBoxButtons.OK)
        End Try
    End Sub
    Sub PreparaAdicion()
        bEdit = False
        bAdd = True
        ClearControls()
        chkActivo.Checked = True
        EnableControls(True)
        txtCodigo.Focus()
    End Sub


    Private Sub ClearControls()
        txtCodigo.Text = ""
        txtDescr.Text = ""
        chkActivo.Checked = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            EliminaRegistro()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & ex.Message, "Error", MessageBoxButtons.OK)
        End Try

    End Sub

    Sub EliminaRegistro()
        Dim dr As DataRow = GridView1.GetFocusedDataRow()
        Dim sCodigo As String, sCodigoMaster As String
        Dim sDescr As String
        Dim sWhere As String
        sCodigoMaster = dr(0).ToString()
        sCodigo = dr(2).ToString()
        sDescr = dr(3).ToString()

        If MessageBox.Show("Está Ud seguro de eliminar el Registro " & sDescr, "Advertencia", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If gbCodeNumericMaster = True Then
                sWhere = gsCodeNameMaster & "=" & sCodigoMaster
            Else
                sWhere = gsCodeNameMaster & "='" & sCodigoMaster & "'"
            End If
            If gbCodeNumeric = True Then
                sWhere = sWhere & " AND " & gsCodeName & "=" & sCodigo
            Else
                sWhere = sWhere & " AND" & gsCodeName & "='" & sCodigo & "'"
            End If

            cManager.Delete(gsTableName, sWhere)
            RefreshGrid()
            RefreshButonsInit()
        End If
    End Sub
    Sub RefreshButonsInit()
        btnAdd.Enabled = True
        btnDelete.Enabled = True
        btnEdit.Enabled = True
        btnsave.Enabled = False

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            PreparaEdicion()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & ex.Message, "Error", MessageBoxButtons.OK)
        End Try

    End Sub

    Sub PreparaEdicion()
        bEdit = True
        bAdd = False
        EnableControls(True)
        txtCodigo.Enabled = False
        Me.gridLookupDepto.Enabled = False
        SetDataFromGridToCtrls()
    End Sub

    Sub SetDataFromGridToCtrls()
        Dim dr As DataRow = GridView1.GetFocusedDataRow()
        Me.gridLookupDepto.EditValue = CInt(dr(0))
        txtCodigo.Text = dr(2).ToString()
        txtDescr.Text = dr(3).ToString()
        chkActivo.Checked = CBool(dr(4))
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PreparaControles()
    End Sub
    Sub PreparaControles()
        ClearControls()
        RefreshGrid()
        RefreshButonsInit()

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim smg As String
        smg = DatoCorrecto(Me.gridLookupDepto.EditValue.ToString, False)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCodigo.Focus()
            Exit Sub
        End If
        smg = DatoCorrecto(Me.txtCodigo.Text, gbCodeNumeric)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCodigo.Focus()
            Exit Sub
        End If
        smg = DatoCorrecto(Me.txtDescr.Text, False)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDescr.Focus()
            Exit Sub
        End If
        ' AQUI VALIDAR INTEGRIDAD REFERENCIAL 
        Try
            If bEdit = True Then
                EditaRegistro()
            End If
            If bAdd Then
                AdicionaRegistro()
            End If

            PreparaControles()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & ex.Message, "Error", MessageBoxButtons.OK)
        End Try

    End Sub
    Sub EditaRegistro()
        Dim sWhere As String

        If bEdit = True Then
            If gbCodeNumericMaster = True Then
                sWhere = gsCodeNameMaster & "=" & gridLookupDepto.EditValue
            Else
                sWhere = gsCodeNameMaster & "='" & gridLookupDepto.EditValue & "'"
            End If
            If gbCodeNumeric = True Then
                sWhere = sWhere & " AND " & gsCodeName & "=" & txtCodigo.Text
            Else
                sWhere = sWhere & " AND" & gsCodeName & "='" & txtCodigo.Text & "'"
            End If

            sFieldsValueUpdate = gsDescrName & " = '" & txtDescr.Text & "', Activo = " & IIf(chkActivo.Checked = True, 1, 0).ToString()

            cManager.Update(gsTableName, sFieldsValueUpdate, sWhere)
        End If
    End Sub
    Sub AdicionaRegistro()

        Dim sInsertValues As String
        Dim sInsertFields As String
        Dim sCodeName As String
        If bAdd Then
            sInsertFields = gsCodeNameMaster & "," & gsCodeName & "," & gsDescrName & "," & " Activo "
            sCodeName = IIf(gbCodeNumericMaster = True, gridLookupDepto.EditValue.ToString(), "'" & gridLookupDepto.EditValue.ToString() & "'") & "," & IIf(gbCodeNumeric = True, txtCodigo.Text, "'" & txtCodigo.Text & "'")
            sInsertValues = sCodeName & ",'" & txtDescr.Text & "'," & IIf(chkActivo.Checked = True, 1, 0).ToString()
            cManager.Insert(gsTableName, sInsertFields, sInsertValues)
        End If
    End Sub
End Class