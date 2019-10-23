Imports Clases
Imports System.ComponentModel
Public Class frmPopupProducto
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Dim currentRow As DataRow
    Public gsIDProducto As String = ""
    Public gsDescr As String = ""
    Public gdCostoPromLocal As Decimal = 0
    Public gdCostoPromDolar As Decimal = 0
    Private Sub frmPopupProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub
    Sub RefreshGrid()
        Try
            tableData = cManager.ExecSPgetData("fafgetProductos", "0")
            GridControl1.DataSource = tableData
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Sub GridViewProducto_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProducto.FocusedRowChanged
        Dim dr As DataRow = GridViewProducto.GetFocusedDataRow()
        currentRow = dr
        If dr IsNot Nothing Then
            gsIDProducto = dr("IDProducto").ToString()
            gsDescr = dr("Descr").ToString()
            gdCostoPromLocal = dr("CostoPromLocal").ToString()
            gdCostoPromDolar = dr("CostoPromDolar").ToString()
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

    'Private Sub btn_ShowBonif_Click(sender As Object, e As EventArgs) Handles btn_ShowBonif.Click
    '    MsgBox("entro")
    '    Dim frm As New frmPopupBonificacion()
    '    frm.ShowDialog()
    '    frm.Dispose()
    'End Sub

    'Private Sub btn_ShowBonif_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btn_ShowBonif.ButtonClick
    '    MsgBox("entro")
    '    Dim frm As New frmPopupBonificacion()
    '    frm.ShowDialog()
    '    frm.Dispose()
    'End Sub

    'Private Sub btnVerBonif_Click(sender As Object, e As EventArgs) Handles btnVerBonif.Click
    '    Dim frm As New frmPopupBonificacion()
    '    frm.ShowDialog()
    '    frm.Dispose()
    'End Sub

    Private Sub btnVerBonif_Click(sender As Object, e As EventArgs) Handles btnVerBonif.Click
        Dim frm As New frmPopupBonificacion()
        frm.gsProductoID = gsIDProducto
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub frmPopupProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnVerBonif_Click(sender, e)
            e.Handled = False
        End If
    End Sub
End Class