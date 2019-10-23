Imports Clases
Public Class frmReport
    Dim cManager As New ClassManager
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet = New DataSet("ds")
        Dim dt As DataTable = New DataTable("dt")
        dt = cManager.ExecSPgetData("fafgetPedido", "0")
        ds.Tables.Add(dt)
        Dim report As New rptPedido

        report.DataSource = ds
        'report.lblCantidad.DataBindings("Cantidad")
        DocumentViewer1.DocumentSource = report
        report.CreateDocument()

    End Sub

    Private Sub DocumentViewer1_Load(sender As Object, e As EventArgs) Handles DocumentViewer1.Load

    End Sub
End Class