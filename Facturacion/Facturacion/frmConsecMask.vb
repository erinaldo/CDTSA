Imports Clases
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports DevExpress.XtraExport
Imports System.IO
Public Class frmConsecMask
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsStoreProcNameGetData As String
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean = False
    Public gsCodeValue As String = ""
    Public gbEdit As Boolean = False
    Public gbAdd As Boolean = False
    Private Sub frmConsecMask_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.txtMascara.Properties.Mask.EditMask = "\\p{Lu}+"
            'Me.txtMascara.Properties.Mask.MaskType = Mask.MaskType.RegEx
            CargagridSearchLookUp(Me.SearchLookUpEditModulo, "secModulo", "IDModulo, Descr", "", "IDModulo", "Descr", "IDModulo")
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
            Me.txtConsecutivo.EditValue = ""
            Me.txtDescr.EditValue = ""
            Me.txtDescr.EditValue = ""
            Me.txtLongitud.EditValue = ""
            Me.SearchLookUpEditModulo.Text = ""
        End If
    End Sub
    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)

        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit 'DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        g.Properties.PopupFormSize = New Size(250, 250)

        'g.ForceInitialize()
        'g.Properties.View.Columns("IDModulo").OptionsColumn.FixedWidth = True
        'g.Properties.View.Columns("IDModulo").Width = 200
        'g.Properties.View.Columns("Descr").OptionsColumn.FixedWidth = False


        g.Properties.NullText = ""
    End Sub
    Sub CargaControlsFromOneRegister()

        tableData = cManager.ExecSPgetData(gsStoreProcNameGetData, gsCodeValue)
        Me.txtCodigo.EditValue = tableData.Rows(0).Item("Codigo").ToString()
        Me.txtCodigo.Enabled = False
        Me.txtDescr.Text = tableData.Rows(0).Item("Descr").ToString()
        Me.txtLongitud.EditValue = tableData.Rows(0).Item("Longitud").ToString()
        Me.txtMascara.EditValue = tableData.Rows(0).Item("Mascara") '--.ToString()
        Me.txtConsecutivo.EditValue = tableData.Rows(0).Item("Consecutivo") '.ToString()
        Me.SearchLookUpEditModulo.EditValue = CInt(tableData.Rows(0).Item("IDModulo"))
    End Sub



    
    Private Sub BarButtonItemSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemSave.ItemClick
        Dim storeName As String, sparameterValues As String
        Try
            If DatosOk() Then
                storeName = "globalUpdateglobalConsecMask"
                sparameterValues = IIf(gbAdd = True, "'I',", "'U',")
                sparameterValues = sparameterValues & "'" & txtCodigo.Text & "','"
                sparameterValues = sparameterValues & txtDescr.Text & "',"
                sparameterValues = sparameterValues & txtLongitud.Text & ",'"
                sparameterValues = sparameterValues & txtMascara.Text & "','"
                sparameterValues = sparameterValues & txtConsecutivo.Text & "',"
                sparameterValues = sparameterValues & IIf(Me.chkActivo.Checked = True, 1, 0).ToString() & ","
                sparameterValues = sparameterValues & Me.SearchLookUpEditModulo.EditValue.ToString()
                cManager.ExecSP(storeName, sparameterValues)
                MessageBox.Show("El registro ha sido guardado exitosamente ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message & " parametros ")
        End Try
    End Sub

    Private Function DatosOk() As Boolean
        Dim lbOk As Boolean = True
        If String.IsNullOrEmpty(Me.txtCodigo.EditValue) Then
            MessageBox.Show("El código del consecutivo no es correcto... favor revise", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
        End If

        If String.IsNullOrEmpty(Me.txtDescr.EditValue) Then
            MessageBox.Show("La descripción del consecutivo no es correcta... favor revise", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
        End If

        If Me.SearchLookUpEditModulo.Text = Nothing Then
            MsgBox("Debe seleccionar un Módulo", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Ayuda")
            Me.SearchLookUpEditModulo.Focus()
            lbOk = False
        End If

        If IsNumeric(txtLongitud.EditValue) = False Or txtLongitud.Text = "" Then
            MessageBox.Show("El valor de la longitud no es el correcto... favor revise", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
        End If

        If String.IsNullOrEmpty(Me.txtMascara.EditValue) Then
            MessageBox.Show("La máscara del consecutivo no es correcta, no debe quedar en blanco... favor revise", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
        End If

        If String.IsNullOrEmpty(Me.txtConsecutivo.EditValue) Then
            MessageBox.Show("La máscara del consecutivo no es correcta, no debe quedar en blanco... favor revise", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
        End If

        If txtLongitud.EditValue <> Len(Me.txtMascara.EditValue) Or txtLongitud.EditValue <> Len(Me.txtConsecutivo.EditValue) Then
            MessageBox.Show("Tanto la Máscara como el valor del Consecutivo deben tener el mismo valor del campo Longitud... favor revise", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
        End If
        If Not IsMaskOK(txtMascara.EditValue, txtConsecutivo.EditValue) Then
            'MessageBox.Show("El Consecutivo no Coindide con la Máscara, revise la longitud, la coindicencia de valores numéricos y alfanuméricos... favor revise", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
        End If
        Return lbOk

    End Function



    Private Sub BarButtonAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonAdd.ItemClick
        Me.Dispose()
        Dim frm As New frmConsecMask
        frm.gsStoreProcNameGetData = "globalgetConsecMask"
        frm.gbCodeNumeric = False
        frm.gbAdd = True
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub txtMascara_EditValueChanging(sender As Object, e As Controls.ChangingEventArgs) Handles txtMascara.EditValueChanging
        If Not (String.IsNullOrEmpty(e.NewValue)) Then
            If String.IsNullOrEmpty(Me.txtLongitud.EditValue) Then
                MessageBox.Show("La longitud de la Máscara debe tener un valor ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
            If Not IsNumeric(Me.txtLongitud.EditValue) Then
                MessageBox.Show("La longitud de la Máscara debe tener un valor numérico...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If

            If e.NewValue.ToString().Length > Convert.ToInt32(txtLongitud.EditValue) Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtMascara_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMascara.KeyPress

        e.KeyChar = UCase(Chr(Solo_AN(Asc(e.KeyChar))))
        'If e.KeyChar <> "N" And e.KeyChar <> "A" Then
        '    If Len(txtMascara.Text) > Convert.ToInt32(txtLongitud.Text) Then
        '        Exit Sub
        '    End If
        'End If
    End Sub


    Private Sub txtConsecutivo_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtConsecutivo.EditValueChanging
        Dim i As Integer
        Dim edit As TextEdit = CType(sender, TextEdit)
        If Not (String.IsNullOrEmpty(e.NewValue)) Then
            If String.IsNullOrEmpty(Me.txtLongitud.EditValue) Then
                MessageBox.Show("La longitud de la Máscara debe tener un valor ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
            If Not IsNumeric(Me.txtLongitud.EditValue) Then
                MessageBox.Show("La longitud de la Máscara debe tener un valor numérico...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If

            If e.NewValue.ToString().Length > Convert.ToInt32(txtLongitud.Text) Then
                e.Cancel = True
            End If
            If String.IsNullOrEmpty(Me.txtMascara.Text) Then
                MessageBox.Show("La Máscara debe tener un valor ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
        End If


        i = txtConsecutivo.Text.Length
        If i > 0 Then
            If Mid(Me.txtMascara.Text, i, 1) = "A" And Not IsAlphaNumeric(Mid(Me.txtConsecutivo.Text, i, 1)) Then

                e.Cancel = True
                BeginInvoke(New MethodInvoker(Sub()
                                                  edit.SelectionStart = edit.Text.Length
                                              End Sub))
            End If


            If Mid(Me.txtMascara.Text, i, 1) = "N" And Not IsNumeric(Mid(Me.txtConsecutivo.Text, i, 1)) Then
                e.Cancel = True
                BeginInvoke(New MethodInvoker(Sub()
                                                  edit.SelectionStart = edit.Text.Length
                                              End Sub))

            End If
        End If

    End Sub

End Class