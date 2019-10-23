Imports Clases

Public Class frmPopupBonificacion
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsProductoID As String = "0"
    Public gdRequerido As Decimal
    Public gdBono As Decimal
    Public gdBonoDistr As Decimal
    Public gdBonoProv As Decimal

    Private Sub frmPopupBonificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub
    Sub RefreshGrid()
        Try
            tableData = cManager.ExecSPgetData("fafgetTablaBonificacion", "0" + "," + gsProductoID)
            GridControl1.DataSource = tableData
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Sub GridViewDetalle_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalle.FocusedRowChanged
        Dim dr As DataRow = GridViewDetalle.GetFocusedDataRow()
        If dr IsNot Nothing Then
            gdRequerido = String.Format("{0:0.00}", dr("Requerido"))
            gdBono = String.Format("{0:0.00}", dr("Bono"))
            gdBonoDistr = String.Format("{0:0.00}", dr("CantBonifProv"))
            gdBonoProv = String.Format("{0:0.00}", dr("CantBonifDist"))
        End If
    End Sub
End Class