<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopupBonificacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDTabla = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IDProveedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Codigo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Requerido = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Bono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CantBonifProv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CantBonifDist = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Desde = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Hasta = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(7, 6)
        Me.GridControl1.MainView = Me.GridViewDetalle
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(933, 419)
        Me.GridControl1.TabIndex = 28
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetalle})
        '
        'GridViewDetalle
        '
        Me.GridViewDetalle.Appearance.ColumnFilterButton.Options.UseTextOptions = True
        Me.GridViewDetalle.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewDetalle.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDTabla, Me.IDProveedor, Me.Nombre, Me.Codigo, Me.GridColumn2, Me.Requerido, Me.Bono, Me.CantBonifProv, Me.CantBonifDist, Me.Desde, Me.Hasta})
        Me.GridViewDetalle.GridControl = Me.GridControl1
        Me.GridViewDetalle.GroupPanelText = "Agrupe una Columna Aqui :"
        Me.GridViewDetalle.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Me.GridColumn2, "{Count = {0}}")})
        Me.GridViewDetalle.Name = "GridViewDetalle"
        Me.GridViewDetalle.OptionsFind.AlwaysVisible = True
        Me.GridViewDetalle.OptionsView.ShowAutoFilterRow = True
        Me.GridViewDetalle.OptionsView.ShowFooter = True
        Me.GridViewDetalle.OptionsView.ShowGroupPanel = False
        '
        'IDTabla
        '
        Me.IDTabla.Caption = "IDTabla"
        Me.IDTabla.FieldName = "IDTabla"
        Me.IDTabla.Name = "IDTabla"
        '
        'IDProveedor
        '
        Me.IDProveedor.Caption = "IDProveedor"
        Me.IDProveedor.FieldName = "IDProveedor"
        Me.IDProveedor.Name = "IDProveedor"
        Me.IDProveedor.Width = 20
        '
        'Nombre
        '
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Visible = True
        Me.Nombre.VisibleIndex = 0
        Me.Nombre.Width = 132
        '
        'Codigo
        '
        Me.Codigo.Caption = "Código"
        Me.Codigo.FieldName = "IDProducto"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.OptionsColumn.AllowEdit = False
        Me.Codigo.Visible = True
        Me.Codigo.VisibleIndex = 1
        Me.Codigo.Width = 51
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Descr"
        Me.GridColumn2.FieldName = "Descr"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 205
        '
        'Requerido
        '
        Me.Requerido.Caption = "Requerido"
        Me.Requerido.FieldName = "Requerido"
        Me.Requerido.ImageAlignment = System.Drawing.StringAlignment.Center
        Me.Requerido.Name = "Requerido"
        Me.Requerido.OptionsColumn.AllowEdit = False
        Me.Requerido.Visible = True
        Me.Requerido.VisibleIndex = 3
        Me.Requerido.Width = 62
        '
        'Bono
        '
        Me.Bono.Caption = "Bono"
        Me.Bono.FieldName = "Bono"
        Me.Bono.Name = "Bono"
        Me.Bono.Visible = True
        Me.Bono.VisibleIndex = 4
        Me.Bono.Width = 39
        '
        'CantBonifProv
        '
        Me.CantBonifProv.Caption = "BonifProv"
        Me.CantBonifProv.FieldName = "CantBonifProv"
        Me.CantBonifProv.Name = "CantBonifProv"
        Me.CantBonifProv.Visible = True
        Me.CantBonifProv.VisibleIndex = 5
        Me.CantBonifProv.Width = 56
        '
        'CantBonifDist
        '
        Me.CantBonifDist.Caption = "BonifDist"
        Me.CantBonifDist.FieldName = "CantBonifDist"
        Me.CantBonifDist.Name = "CantBonifDist"
        Me.CantBonifDist.Visible = True
        Me.CantBonifDist.VisibleIndex = 6
        Me.CantBonifDist.Width = 55
        '
        'Desde
        '
        Me.Desde.Caption = "Desde"
        Me.Desde.FieldName = "Desde"
        Me.Desde.Name = "Desde"
        Me.Desde.Visible = True
        Me.Desde.VisibleIndex = 7
        Me.Desde.Width = 52
        '
        'Hasta
        '
        Me.Hasta.Caption = "Hasta"
        Me.Hasta.FieldName = "Hasta"
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Visible = True
        Me.Hasta.VisibleIndex = 8
        Me.Hasta.Width = 62
        '
        'frmPopupBonificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 427)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "frmPopupBonificacion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabla de Bonificación"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDTabla As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IDProveedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Codigo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Requerido As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Bono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CantBonifProv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CantBonifDist As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Desde As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Hasta As DevExpress.XtraGrid.Columns.GridColumn
End Class
