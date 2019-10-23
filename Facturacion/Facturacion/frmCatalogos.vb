Imports Clases
Imports System.Windows.Forms
Public Class frmCatalogos
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsCaptionFrm As String = ""
    Public gsTableName As String = ""
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean
    Public gsDescrName As String = ""
    Public gsFieldsRest As String = ""
    Dim gsFieldsName As String
    Public gsWHere As String = ""
    Public gsOrder As String = ""

    ' para el campo extra del extragrid 

    Public gbExtragridExiste As Boolean = False
    Public gsExtragridTableName As String = ""
    Public gsExtragridCodeName As String = ""
    Public gsExtragridDescrName As String = ""
    Public gsExtragridFieldsRest As String = ""
    Dim gsExtragridFieldsName As String = ""

    Public gbExtragridCodeNumeric As Boolean = True
    Public gsExtragridFiltro As String = ""
    Public gsExtragridLableText As String = ""
    Dim bEdit As Boolean = False
    Dim bAdd As Boolean = False
    Dim sFieldsValueUpdate As String
    Private Sub frmCatalogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = gsCaptionFrm
        gsFieldsName = gsCodeName & " Codigo," & gsDescrName & IIf(gsFieldsRest <> "", "," & gsFieldsRest, "")
        If gbExtragridExiste Then
            gsFieldsName = gsFieldsName & " IDExtra" ' alieas del ID del Campo Extra, asi lo conoce el Grid IDEXtra
            gsExtragridFieldsName = gsExtragridCodeName & " IDExtra, " & gsExtragridDescrName & "," & gsExtragridFieldsRest

            GridView1.Columns(3).Visible = True
            GridView1.Columns(4).Visible = True
            GridView1.Columns(3).Caption = gsExtragridCodeName
            GridView1.Columns(4).Caption = gsExtragridDescrName
        Else
            GridView1.Columns(3).Visible = False
            GridView1.Columns(4).Visible = False
        End If
        RefreshGrid()
    End Sub

    Sub RefreshGrid()
        Try
            If gbExtragridExiste = True Then
                gridLookUpEditExtra.Visible = True
                Me.lblExtragridLookup.Visible = True
                gridLookUpEditExtra.Properties.DataSource = cManager.GetDataTable(gsExtragridTableName, gsExtragridFieldsName, "Activo=1", gsExtragridCodeName)
                gridLookUpEditExtra.Properties.DisplayMember = gsExtragridDescrName
                gridLookUpEditExtra.Properties.ValueMember = "IDExtra" ' gsExtragridCodeName
                gridLookUpEditExtra.EditValue = "" 'gridLookupDepto.Properties.GetKeyValue(0)
                Me.lblExtragridLookup.Text = gsExtragridLableText
                gridLookUpEditExtra.Refresh()

                Me.searchLookUpEdit.DataSource = cManager.GetDataTable(gsExtragridTableName, gsExtragridFieldsName, "Activo=1", gsExtragridCodeName)
                Me.searchLookUpEdit.DisplayMember = gsExtragridDescrName

                Me.searchLookUpEdit.ValueMember = "IDExtra"

                Me.searchLookUpEdit.NullText = "Seleccione su " & gsExtragridLableText

                ' GridColumnIDExtra.FieldName = gsExtragridCodeName

            End If
            EnableControls(False)
            tableData = cManager.GetDataTable(gsTableName, gsFieldsName, gsWHere, gsOrder)
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
        Me.gridLookUpEditExtra.EditValue = ""
        chkActivo.Checked = False
    End Sub

    Private Sub EnableControls(bActiva As Boolean)
        txtCodigo.Enabled = bActiva
        txtDescr.Enabled = bActiva
        chkActivo.Enabled = bActiva
        If gbExtragridExiste Then
            Me.gridLookUpEditExtra.Enabled = bActiva
        End If
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
        SetDataFromGridToCtrls()
    End Sub

    Sub SetDataFromGridToCtrls()
        Dim dr As DataRow = GridView1.GetFocusedDataRow()
        txtCodigo.Text = dr(0).ToString()
        txtDescr.Text = dr(1).ToString()
        If gbExtragridExiste Then
            Me.gridLookUpEditExtra.EditValue = CInt(dr(3)) '.ToString() '  CInt(tableData.Rows(0).Item("IDExtra"))
            Me.gridLookUpEditExtra.Refresh()
        End If
        chkActivo.Checked = CBool(dr(2))
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PreparaControles()
    End Sub
    Sub PreparaControles()
        ClearControls()
        RefreshGrid()
        RefreshButonsInit()

    End Sub


    Sub RefreshButonsInit()
        btnAdd.Enabled = True
        btnDelete.Enabled = True
        btnEdit.Enabled = True
        btnsave.Enabled = False

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
        Dim sCodigo As String
        Dim sDescr As String
        Dim sWhere As String
        sCodigo = dr(0).ToString()
        sDescr = dr(1).ToString()

        If MessageBox.Show("Está Ud seguro de eliminar el Registro " & sDescr, "Advertencia", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If gbCodeNumeric = True Then
                sWhere = gsCodeName & "=" & sCodigo
            Else
                sWhere = gsCodeName & "='" & sCodigo & "'"
            End If
            cManager.Delete(gsTableName, sWhere)
            RefreshGrid()
            RefreshButonsInit()
        End If
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim smg As String
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
            If gbCodeNumeric = True Then
                sWhere = gsCodeName & "=" & txtCodigo.Text
            Else
                sWhere = gsCodeName & "='" & txtCodigo.Text & "'"
            End If
            If gbExtragridExiste Then
                Dim sExtra As String = getWordsBeforeOneWord("IDExtra", gsExtragridFieldsName)
                Dim sValueExtra As String = getValueIDExtra()
                Dim sExtraUpd As String = "," & IIf(gbExtragridCodeNumeric = True, "", "'") & sValueExtra & IIf(gbCodeNumeric = True, "", "'")
                sFieldsValueUpdate = gsDescrName & " = '" & txtDescr.Text & "', Activo = " & IIf(chkActivo.Checked = True, 1, 0).ToString() & "," & sExtra & "=" & sValueExtra
            Else
                sFieldsValueUpdate = gsDescrName & " = '" & txtDescr.Text & "', Activo = " & IIf(chkActivo.Checked = True, 1, 0).ToString()
            End If
            cManager.Update(gsTableName, sFieldsValueUpdate, sWhere)
        End If
    End Sub
    Sub AdicionaRegistro()

        Dim sInsertValues As String
        Dim sInsertFields As String
        Dim sCodeName As String
        Dim sValueExtra As String
        If bAdd Then
            sInsertFields = gsCodeName & "," & gsDescrName & " ," & " Activo " & IIf(gbExtragridExiste = True, "," & IIf(gbCodeNumeric = True, "", "'") & gsExtragridCodeName & IIf(gbCodeNumeric = True, "", "'"), "")
            sCodeName = IIf(gbCodeNumeric = True, txtCodigo.Text, "'" & txtCodigo.Text & "'")

            sValueExtra = getValueIDExtra()
            sInsertValues = sCodeName & ",'" & txtDescr.Text & "'," & IIf(chkActivo.Checked = True, 1, 0).ToString() & IIf(gbExtragridExiste = True, "," & IIf(gbExtragridCodeNumeric = True, "", "'") & sValueExtra & IIf(gbExtragridCodeNumeric = True, "", "'"), "")
            cManager.Insert(gsTableName, sInsertFields, sInsertValues)
        End If
    End Sub


    Function getValueIDExtra() As String
        Dim sValueExtra As String
        Try

            If gbExtragridExiste Then
                Dim row As DataRowView = TryCast(gridLookUpEditExtra.Properties.GetRowByKeyValue(gridLookUpEditExtra.EditValue), DataRowView)
                sValueExtra = row("IDExtra").ToString()
            Else
                sValueExtra = ""
            End If
        Catch ex As Exception
            sValueExtra = ""
        End Try

        Return sValueExtra
    End Function



    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub


End Class

