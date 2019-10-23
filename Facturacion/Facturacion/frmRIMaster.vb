Imports Clases
Public Class frmRIMaster
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Private Sub frmRIMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Sub RefreshGrid()
    '    Try
    '        tableData = cManager.ExecSPgetData("", 
    '        GridControl1.DataSource = tableData
    '        GridColumn2.Caption = gsDescrName
    '        GridColumn2.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "Elementos Registrados : {0:n0} ")
    '        GridControl1.Refresh()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message())
    '    End Try
    'End Sub
End Class