<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopupCliente
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
        Me.GridViewClientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Activo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Farmacia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Direccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Telefono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCredito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEditaNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDMoneda = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDNivel = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(3, 12)
        Me.GridControl1.MainView = Me.GridViewClientes
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(987, 448)
        Me.GridControl1.TabIndex = 27
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewClientes})
        '
        'GridViewClientes
        '
        Me.GridViewClientes.Appearance.ColumnFilterButton.Options.UseTextOptions = True
        Me.GridViewClientes.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewClientes.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDCliente, Me.Nombre, Me.Activo, Me.Farmacia, Me.Direccion, Me.Telefono, Me.GridColumnCredito, Me.GridColumnEditaNombre, Me.GridColumnIDNivel, Me.GridColumnIDMoneda})
        Me.GridViewClientes.GridControl = Me.GridControl1
        Me.GridViewClientes.GroupPanelText = "Agrupe una Columna Aqui :"
        Me.GridViewClientes.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Me.Nombre, "{Count = {0}}")})
        Me.GridViewClientes.Name = "GridViewClientes"
        Me.GridViewClientes.OptionsBehavior.Editable = False
        Me.GridViewClientes.OptionsFind.AlwaysVisible = True
        Me.GridViewClientes.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewClientes.OptionsView.ShowAutoFilterRow = True
        Me.GridViewClientes.OptionsView.ShowFooter = True
        Me.GridViewClientes.OptionsView.ShowGroupPanel = False
        '
        'IDCliente
        '
        Me.IDCliente.Caption = "Código"
        Me.IDCliente.FieldName = "IDCliente"
        Me.IDCliente.Name = "IDCliente"
        Me.IDCliente.OptionsColumn.AllowEdit = False
        Me.IDCliente.Visible = True
        Me.IDCliente.VisibleIndex = 0
        Me.IDCliente.Width = 37
        '
        'Nombre
        '
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.OptionsColumn.AllowEdit = False
        Me.Nombre.Visible = True
        Me.Nombre.VisibleIndex = 1
        Me.Nombre.Width = 149
        '
        'Activo
        '
        Me.Activo.Caption = "Activo"
        Me.Activo.FieldName = "Activo"
        Me.Activo.ImageAlignment = System.Drawing.StringAlignment.Center
        Me.Activo.Name = "Activo"
        Me.Activo.OptionsColumn.AllowEdit = False
        Me.Activo.Visible = True
        Me.Activo.VisibleIndex = 5
        Me.Activo.Width = 46
        '
        'Farmacia
        '
        Me.Farmacia.Caption = "Farmacia"
        Me.Farmacia.FieldName = "Farmacia"
        Me.Farmacia.Name = "Farmacia"
        Me.Farmacia.Visible = True
        Me.Farmacia.VisibleIndex = 2
        Me.Farmacia.Width = 135
        '
        'Direccion
        '
        Me.Direccion.Caption = "Direccion"
        Me.Direccion.FieldName = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.Visible = True
        Me.Direccion.VisibleIndex = 3
        Me.Direccion.Width = 244
        '
        'Telefono
        '
        Me.Telefono.Caption = "Telefono"
        Me.Telefono.FieldName = "Telefono"
        Me.Telefono.Name = "Telefono"
        Me.Telefono.Visible = True
        Me.Telefono.VisibleIndex = 4
        Me.Telefono.Width = 84
        '
        'GridColumnCredito
        '
        Me.GridColumnCredito.Caption = "Credito"
        Me.GridColumnCredito.FieldName = "Credito"
        Me.GridColumnCredito.Name = "GridColumnCredito"
        Me.GridColumnCredito.Visible = True
        Me.GridColumnCredito.VisibleIndex = 6
        Me.GridColumnCredito.Width = 45
        '
        'GridColumnEditaNombre
        '
        Me.GridColumnEditaNombre.Caption = "EditaNombre"
        Me.GridColumnEditaNombre.FieldName = "EditaNombre"
        Me.GridColumnEditaNombre.Name = "GridColumnEditaNombre"
        Me.GridColumnEditaNombre.Visible = True
        Me.GridColumnEditaNombre.VisibleIndex = 7
        '
        'GridColumnIDMoneda
        '
        Me.GridColumnIDMoneda.Caption = "IDMoneda"
        Me.GridColumnIDMoneda.FieldName = "IDMoneda"
        Me.GridColumnIDMoneda.Name = "GridColumnIDMoneda"
        '
        'GridColumnIDNivel
        '
        Me.GridColumnIDNivel.Caption = "IDNivel"
        Me.GridColumnIDNivel.FieldName = "IDNivel"
        Me.GridColumnIDNivel.Name = "GridColumnIDNivel"
        '
        'frmPopupCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 462)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "frmPopupCliente"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Clientes"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewClientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Activo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Farmacia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Direccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Telefono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCredito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEditaNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDMoneda As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDNivel As DevExpress.XtraGrid.Columns.GridColumn
End Class
