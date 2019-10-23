Imports Clases
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Public Class frmRemision
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Dim tableDataCli As New DataTable()
    Dim viewSelectedRow As GridView
    Dim currentRow As DataRow
    Dim gsIDFactura As String
    Dim gbControlPesoOk As Boolean = False
    Private Sub frmRemision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateEditDesde.EditValue = Now
        DateEditHasta.EditValue = Now
    End Sub

    Private Sub GridViewHeader_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewHeader.FocusedRowChanged
        Dim index As Integer = GridViewHeader.FocusedRowHandle
        If index > -1 Then
            Dim dr As DataRow = GridViewHeader.GetFocusedDataRow()
            currentRow = dr
            If dr IsNot Nothing Then
                Me.rbRemisionados.Enabled = True
                Me.rbNoRemisionada.Enabled = True
                Me.rbTodos.Enabled = True
                Me.rbTodos.Checked = True
                gbControlPesoOk = ControlPesoKG(dr("IDTipoEntrega"))
                If Not CBool(dr("Remisionada")) Then
                    Me.cmdRemisionar.Enabled = True
                    If gbControlPesoOk Then
                        txtPesoKG.Enabled = True
                        'Else
                        '    txtPesoKG.Text = dr("PesoKG")
                        '    txtPesoKG.Enabled = False
                    End If
                Else
                    Me.cmdRemisionar.Enabled = False
                    'If ControlPesoKG(dr("IDTipoEntrega")) Then
                    '    txtPesoKG.Enabled = False
                    'Else
                    txtPesoKG.Enabled = False
                End If

            End If
            gsIDFactura = dr("IDFactura").ToString()
            Me.GridProducto.DataSource = cManager.ExecSPgetData("fafGetFacturaEntregaProducto", gsIDFactura)
        End If

    End Sub
    Sub RefreshGrid()
        Try
            Dim iRemisionados As Integer
            If rbTodos.Checked = True Then
                iRemisionados = -1
            End If
            If rbRemisionados.Checked = True Then
                iRemisionados = 1
            End If
            If rbNoRemisionada.Checked = True Then
                iRemisionados = 0
            End If

            Dim sParameters As String = "'" & CDate(Me.DateEditDesde.EditValue).ToString("yyyyMMdd") & "','" & CDate(Me.DateEditHasta.EditValue).ToString("yyyyMMdd") & "', " & iRemisionados.ToString()
            tableData = cManager.ExecSPgetData("fafGetFacturaEntrega", sParameters)
            GridHeader.DataSource = tableData
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub


    Private Function ControlPesoKG(iIDTipoEntrega As Integer) As Boolean
        Dim bControlPesoKG As Boolean = False
        tableData = cManager.GetDataTable("fafTipoEntrega", "ControlPesoKG", "IDTipoEntrega=" & iIDTipoEntrega.ToString(), "IDTipoEntrega")
        If tableData.Rows.Count > 0 Then
            bControlPesoKG = CBool(tableData.Rows(0)("ControlPesoKG"))
        End If
        Return bControlPesoKG
    End Function
    Private Sub PrintReport(pIDFactura)
        tableData = cManager.ExecSPgetData("fafGetFacturaEntregaProducto", pIDFactura.ToString())
        If tableData.Rows.Count > 0 Then

            Dim report As DevExpress.XtraReports.UI.XtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptRemision.repx", True)
            report.DataSource = vbNull
            report.DataSource = tableData
            report.DataMember = "fafGetFacturaEntregaProducto"

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        PrintReport(CInt(gsIDFactura))
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshGrid()
    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub

    Private Sub cmdRemisionar_Click(sender As Object, e As EventArgs) Handles cmdRemisionar.Click
        Try
            If gbControlPesoOk Then
                If txtPesoKG.Text = "" Then
                    MessageBox.Show("Debe digitar un valor en el Peso en KG, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If Not IsNumeric(txtPesoKG.Text) Then
                    MessageBox.Show("Debe digitar un valor numerico en el Peso en KG, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If Val(txtPesoKG.Text) <= 0 Then
                    MessageBox.Show("Debe digitar un valor numerico mayor que cero en el Peso en KG, por favor revise", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Else
                txtPesoKG.Text = "0"
            End If
            Dim sParameters As String
            sParameters = gsIDFactura & "," & txtPesoKG.Text
            cManager.ExecSP("fafUpdateFacturaRemision", sParameters)
            RefreshGrid()
            MessageBox.Show("La Factura ha sido Marcada como remisionada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & ex.Message)
        End Try

    End Sub
End Class