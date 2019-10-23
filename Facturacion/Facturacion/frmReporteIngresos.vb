Imports Clases
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraGrid.Columns

Public Class frmReporteIngresos
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gbRINew As Boolean = False
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New frmAplicaciones
        frm.Show()
    End Sub

    Private Sub frmReporteIngresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gbRINew Then
            CargagridSearchLookUp(Me.SearchLookUpEditSucursal, "invBodega", "IDBodega, Descr, Activo", "", "IDBodega", "Descr", "IDBodega")
            Me.SearchLookUpEditSucursal.EditValue = gsSucursal
            CargagridSearchLookUp(Me.SearchLookUpEditVendedor, "fafVendedor", "IDVendedor, Nombre, Activo", "", "IDVendedor", "Nombre", "IDVendedor")
            DateEditFecha.EditValue = Now
            ComboBoxEditEstado.EditValue = "Iniciado"
            txtSaldo.EditValue = 0
            txtTotal.EditValue = 0
            txtCheque.EditValue = 0
            txtEfectivo.EditValue = 0
            txtMinuta.EditValue = 0
            txtNC.EditValue = 0
            txtRET.EditValue = 0

        End If
    End Sub
    'Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
    '    g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
    '    g.Properties.DisplayMember = sDisplayMember
    '    g.Properties.ValueMember = sValueMember
    '    'g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
    '    g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
    '    g.Properties.PopupFormSize = New Size(300, 300)
    '    g.Properties.NullText = ""
    'End Sub

    Private Sub CargaConsecutivoRI(sIDBodega As String, sIDVendedor As String)
        Dim sParameters As String
        Dim iRI As Integer
        Dim td As New DataTable
        sParameters = sIDBodega & "," & sIDVendedor
        td = cManager.ExecFunction("fafGetNextRI", sParameters)
        If td.Rows.Count <= 0 Then
            MessageBox.Show("Esa bodega/sucursal no permite RI , por favor llamar al Adminstrador del Sistema ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        iRI = td.Rows(0)(0)
        If iRI = 0 Then
            MessageBox.Show("Esa bodega/sucursal no permite RI , por favor llamar al Adminstrador del Sistema ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Me.txtRI.EditValue = iRI
    End Sub

    Private Sub SearchLookUpEditVendedor_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEditVendedor.EditValueChanged
        CargaConsecutivoRI(SearchLookUpEditSucursal.EditValue.ToString, SearchLookUpEditVendedor.EditValue.ToString)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim smg As String

        smg = DatoCorrecto(Me.txtRI.Text, True)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRI.Focus()
            Exit Sub
        End If


        smg = DatoCorrecto(Me.SearchLookUpEditVendedor.Text, False)
        If smg <> "OK" Then
            smg = smg & " Vendedor incorrecto "
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SearchLookUpEditVendedor.Focus()
            Exit Sub
        End If


        smg = DatoCorrecto(Me.txtEfectivo.Text, True)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEfectivo.Focus()
            Exit Sub
        End If
        smg = DatoCorrecto(txtMinuta.Text, True)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMinuta.Focus()
            Exit Sub
        End If
        smg = DatoCorrecto(txtNC.Text, True)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNC.Focus()
            Exit Sub
        End If
        smg = DatoCorrecto(txtRET.Text, True)
        If smg <> "OK" Then
            MessageBox.Show(smg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRET.Focus()
            Exit Sub
        End If


        ' AQUI VALIDAR INTEGRIDAD REFERENCIAL 
        'Try
        '    If bEdit = True Then
        '        EditaRegistro()
        '    End If
        '    If bAdd Then
        '        AdicionaRegistro()
        '    End If

        '    PreparaControles()
        'Catch ex As Exception
        '    MessageBox.Show("Ha ocurrido el siguiente error :" & ex.Message, "Error", MessageBoxButtons.OK)
        'End Try

    End Sub
End Class