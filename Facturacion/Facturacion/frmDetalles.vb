Imports Clases
Imports System.ComponentModel
Public Class frmDetalles
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsFormDetalleName As String
    'Check the Enum type
    Public gsCaptionFrm As String = ""
    Public gsTableName As String = ""
    Public gsCodeName As String = ""
    Public gbCodeNumeric As Boolean
    Public gsDescrName As String
    Public gsFieldsRest As String
    Dim gsFieldsName As String
    Public gsWHere As String = ""
    Public gsOrder As String = ""
    Public gsNombreStoreProcedure As String = ""

    Dim bEdit As Boolean = False
    Dim bAdd As Boolean = False


    Private Sub frmDetalles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = gsCaptionFrm
        gsFieldsName = gsCodeName & " Codigo," & gsDescrName & " Descr" & IIf(gsFieldsRest <> "", "," & gsFieldsRest, "")
        RefreshGrid()
    End Sub


    Sub RefreshGrid()
        Try
            tableData = cManager.GetDataTable(gsTableName, gsFieldsName, gsWHere, gsOrder)
            GridControl1.DataSource = tableData
            GridColumn2.Caption = gsDescrName
            GridColumn2.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "Elementos Registrados : {0:n0} ")
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Select Case UCase(gsFormDetalleName)
            Case "CLIENTE"
                Dim frm As New frmClientes()
                gsNombreStoreProcedure = "fafgetClientes"
                frm.gsStoreProcNameGetData = gsNombreStoreProcedure
                frm.gbCodeNumeric = True
                frm.gsCodeValue = "0"
                frm.gbAdd = True
                frm.ShowDialog()
                frm.Dispose()
            Case "VENDEDOR"
                Dim frm As New frmVendedor()
                gsNombreStoreProcedure = "fafgetVendedores"
                frm.gsStoreProcNameGetData = gsNombreStoreProcedure
                frm.gbCodeNumeric = True
                frm.gbAdd = True
                frm.ShowDialog()
                frm.Dispose()
            Case "CONSECUTIVOMASK"
                Dim frm As New frmConsecMask
                gsNombreStoreProcedure = "globalgetConsecMask"
                frm.gsStoreProcNameGetData = gsNombreStoreProcedure
                frm.gbCodeNumeric = False
                frm.gbAdd = True
                frm.ShowDialog()
                frm.Dispose()
        End Select

        RefreshGrid()


    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Select UCase(gsFormDetalleName)
            Case "CLIENTE"
                Dim dr As DataRow = GridView1.GetFocusedDataRow()
                Dim sCodigo As String
                sCodigo = dr(0).ToString()
                Dim frm As New frmClientes()
                frm.gsCodeName = "IDCliente"
                frm.gsCodeValue = sCodigo
                gsNombreStoreProcedure = "fafgetClientes"
                frm.gsStoreProcNameGetData = gsNombreStoreProcedure
                frm.gbCodeNumeric = True
                frm.gbEdit = True
                frm.ShowDialog()
                frm.Dispose()
            Case "VENDEDOR"
                Dim dr As DataRow = GridView1.GetFocusedDataRow()
                Dim sCodigo As String
                sCodigo = dr(0).ToString()
                Dim frm As New frmVendedor()
                frm.gsCodeName = "IDVendedor"
                frm.gsCodeValue = sCodigo
                gsNombreStoreProcedure = "fafgetVendedores"
                frm.gsStoreProcNameGetData = gsNombreStoreProcedure
                frm.gbCodeNumeric = True
                frm.gbEdit = True
                frm.ShowDialog()
                frm.Dispose()
            Case "CONSECUTIVOMASK"
                Dim dr As DataRow = GridView1.GetFocusedDataRow()
                Dim sCodigo As String
                sCodigo = dr(0).ToString()
                Dim frm As New frmConsecMask
                frm.gsCodeName = "Codigo"
                frm.gsCodeValue = sCodigo
                gsNombreStoreProcedure = "globalgetConsecMask"
                frm.gsStoreProcNameGetData = gsNombreStoreProcedure
                frm.gbCodeNumeric = True
                frm.gbEdit = True
                frm.ShowDialog()
                frm.Dispose()
        End Select
        RefreshGrid()
    End Sub


    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim storeName As String, sparameterValues As String
        Dim sCodigo As String
        Dim sDescr As String

        Try
                    Select UCase(gsFormDetalleName)
                Case "CLIENTE"
                    Dim dr As DataRow = GridView1.GetFocusedDataRow()
                    sCodigo = dr(0).ToString()
                    sDescr = dr(1).ToString()
                    If MessageBox.Show("Está Ud seguro de eliminar el registro " & sDescr, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        storeName = "fafUpdateCliente"
                        sparameterValues = " 'D',"
                        sparameterValues = sparameterValues & sCodigo & ",'" & sDescr & "'"
                        cManager.ExecSP(storeName, sparameterValues)
                        MessageBox.Show("El registro ha sido eliminado exitosamente ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        RefreshGrid()
                    End If
                Case "CONSECUTIVOMASK"
                    Dim dr As DataRow = GridView1.GetFocusedDataRow()
                    sCodigo = dr(0).ToString()
                    sDescr = dr(1).ToString()
                    If MessageBox.Show("Está Ud seguro de eliminar el registro " & sDescr, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        storeName = "globalUpdateglobalConsecMask"
                        sparameterValues = " 'D',"
                        sparameterValues = sparameterValues & "'" & sCodigo & "'," & "'', 0, '', '', 0, 1"
                        cManager.ExecSP(storeName, sparameterValues)
                        MessageBox.Show("El registro ha sido eliminado exitosamente ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        RefreshGrid()
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class