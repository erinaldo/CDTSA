Imports Clases
Imports System.ComponentModel
Public Class frmPopupCliente
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Dim currentRow As DataRow
    Public gsIDSucursal As String
    Public gsIDCliente As String
    Public gsNombre As String
    Public gsFarmacia As String
    Public gsVendedor As String
    Public gsNombreVendedor As String
    Public gsIDNivel As String
    Public gsIDMoneda As String
    Public gsPlazo As String
    Public gsPorcInteres As String

    Private Sub frmPopupCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub
    Sub RefreshGrid()
        Try
            tableData = cManager.ExecSPgetData("fafgetClientes", "0" & "," & gsIDSucursal)
            GridControl1.DataSource = tableData
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Sub GridViewClientes_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewClientes.FocusedRowChanged
        Dim dr As DataRow = GridViewClientes.GetFocusedDataRow()
        currentRow = dr
        If dr IsNot Nothing Then
            gsIDCliente = dr("IDCliente").ToString()
            gsNombre = dr("Nombre").ToString()
            gsFarmacia = dr("Farmacia").ToString()
            gsVendedor = dr("IDVendedor").ToString()
            gsNombreVendedor = dr("NombreVendedor").ToString()
            gsIDNivel = dr("IDNivel").ToString()
            gsIDMoneda = dr("IDMoneda").ToString()
            gsPlazo = dr("Plazo").ToString()
            gsPorcInteres = dr("PorcInteres").ToString()
        End If
    End Sub


    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Me.Close()
    End Sub

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            Me.Close()
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class