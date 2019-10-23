<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBonificaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBonificaciones))
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
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkVerTabla = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDejarProv = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTodosProd = New DevExpress.XtraEditors.CheckEdit()
        Me.DateEditHasta = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditDesde = New DevExpress.XtraEditors.DateEdit()
        Me.SearchLookUpEditProveedor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtBonoProv = New DevExpress.XtraEditors.TextEdit()
        Me.txtBonoDist = New DevExpress.XtraEditors.TextEdit()
        Me.txtBono = New DevExpress.XtraEditors.TextEdit()
        Me.SearchLookUpEditProducto = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtRequerido = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPrecio = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtPublico = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Precio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Publico = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.chkVerTabla.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDejarProv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTodosProd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditProveedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBonoProv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBonoDist.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditProducto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRequerido.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPublico.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(12, 219)
        Me.GridControl1.MainView = Me.GridViewDetalle
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(933, 289)
        Me.GridControl1.TabIndex = 27
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetalle})
        '
        'GridViewDetalle
        '
        Me.GridViewDetalle.Appearance.ColumnFilterButton.Options.UseTextOptions = True
        Me.GridViewDetalle.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewDetalle.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDTabla, Me.IDProveedor, Me.Nombre, Me.Codigo, Me.GridColumn2, Me.Requerido, Me.Bono, Me.CantBonifProv, Me.CantBonifDist, Me.Desde, Me.Hasta, Me.Precio, Me.Publico})
        Me.GridViewDetalle.GridControl = Me.GridControl1
        Me.GridViewDetalle.GroupPanelText = "Agrupe una Columna Aqui :"
        Me.GridViewDetalle.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Me.GridColumn2, "{Count = {0}}")})
        Me.GridViewDetalle.Name = "GridViewDetalle"
        Me.GridViewDetalle.OptionsBehavior.ReadOnly = True
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
        Me.Nombre.Width = 139
        '
        'Codigo
        '
        Me.Codigo.Caption = "Código"
        Me.Codigo.FieldName = "IDProducto"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.OptionsColumn.AllowEdit = False
        Me.Codigo.Visible = True
        Me.Codigo.VisibleIndex = 1
        Me.Codigo.Width = 54
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Descr"
        Me.GridColumn2.FieldName = "Descr"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 204
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
        Me.Bono.Width = 42
        '
        'CantBonifProv
        '
        Me.CantBonifProv.Caption = "BonifProv"
        Me.CantBonifProv.FieldName = "CantBonifProv"
        Me.CantBonifProv.Name = "CantBonifProv"
        Me.CantBonifProv.Visible = True
        Me.CantBonifProv.VisibleIndex = 5
        Me.CantBonifProv.Width = 59
        '
        'CantBonifDist
        '
        Me.CantBonifDist.Caption = "BonifDist"
        Me.CantBonifDist.FieldName = "CantBonifDist"
        Me.CantBonifDist.Name = "CantBonifDist"
        Me.CantBonifDist.Visible = True
        Me.CantBonifDist.VisibleIndex = 6
        Me.CantBonifDist.Width = 58
        '
        'Desde
        '
        Me.Desde.Caption = "Desde"
        Me.Desde.FieldName = "Desde"
        Me.Desde.Name = "Desde"
        Me.Desde.Visible = True
        Me.Desde.VisibleIndex = 7
        Me.Desde.Width = 55
        '
        'Hasta
        '
        Me.Hasta.Caption = "Hasta"
        Me.Hasta.FieldName = "Hasta"
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Visible = True
        Me.Hasta.VisibleIndex = 8
        Me.Hasta.Width = 65
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.txtPublico)
        Me.LayoutControl2.Controls.Add(Me.txtPrecio)
        Me.LayoutControl2.Controls.Add(Me.chkVerTabla)
        Me.LayoutControl2.Controls.Add(Me.chkDejarProv)
        Me.LayoutControl2.Controls.Add(Me.chkTodosProd)
        Me.LayoutControl2.Controls.Add(Me.DateEditHasta)
        Me.LayoutControl2.Controls.Add(Me.DateEditDesde)
        Me.LayoutControl2.Controls.Add(Me.SearchLookUpEditProveedor)
        Me.LayoutControl2.Controls.Add(Me.txtBonoProv)
        Me.LayoutControl2.Controls.Add(Me.txtBonoDist)
        Me.LayoutControl2.Controls.Add(Me.txtBono)
        Me.LayoutControl2.Controls.Add(Me.SearchLookUpEditProducto)
        Me.LayoutControl2.Controls.Add(Me.txtRequerido)
        Me.LayoutControl2.Location = New System.Drawing.Point(5, -1)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup3
        Me.LayoutControl2.Size = New System.Drawing.Size(934, 175)
        Me.LayoutControl2.TabIndex = 28
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'chkVerTabla
        '
        Me.chkVerTabla.Location = New System.Drawing.Point(475, 131)
        Me.chkVerTabla.Name = "chkVerTabla"
        Me.chkVerTabla.Properties.Caption = "Ver toda la Tabla de Bonificación"
        Me.chkVerTabla.Size = New System.Drawing.Size(201, 19)
        Me.chkVerTabla.StyleController = Me.LayoutControl2
        Me.chkVerTabla.TabIndex = 18
        '
        'chkDejarProv
        '
        Me.chkDejarProv.Location = New System.Drawing.Point(787, 48)
        Me.chkDejarProv.Name = "chkDejarProv"
        Me.chkDejarProv.Properties.Caption = "Mantener Proveedor"
        Me.chkDejarProv.Size = New System.Drawing.Size(123, 19)
        Me.chkDejarProv.StyleController = Me.LayoutControl2
        Me.chkDejarProv.TabIndex = 17
        '
        'chkTodosProd
        '
        Me.chkTodosProd.Location = New System.Drawing.Point(680, 131)
        Me.chkTodosProd.Name = "chkTodosProd"
        Me.chkTodosProd.Properties.Caption = "Aplicar a todos los productos del Proveedor"
        Me.chkTodosProd.Size = New System.Drawing.Size(230, 19)
        Me.chkTodosProd.StyleController = Me.LayoutControl2
        Me.chkTodosProd.TabIndex = 16
        '
        'DateEditHasta
        '
        Me.DateEditHasta.EditValue = Nothing
        Me.DateEditHasta.Location = New System.Drawing.Point(830, 107)
        Me.DateEditHasta.Name = "DateEditHasta"
        Me.DateEditHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditHasta.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditHasta.Size = New System.Drawing.Size(80, 20)
        Me.DateEditHasta.StyleController = Me.LayoutControl2
        Me.DateEditHasta.TabIndex = 15
        '
        'DateEditDesde
        '
        Me.DateEditDesde.EditValue = Nothing
        Me.DateEditDesde.Location = New System.Drawing.Point(666, 107)
        Me.DateEditDesde.Name = "DateEditDesde"
        Me.DateEditDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDesde.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDesde.Size = New System.Drawing.Size(80, 20)
        Me.DateEditDesde.StyleController = Me.LayoutControl2
        Me.DateEditDesde.TabIndex = 14
        '
        'SearchLookUpEditProveedor
        '
        Me.SearchLookUpEditProveedor.Location = New System.Drawing.Point(104, 48)
        Me.SearchLookUpEditProveedor.Name = "SearchLookUpEditProveedor"
        Me.SearchLookUpEditProveedor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditProveedor.Properties.View = Me.SearchLookUpEdit1View
        Me.SearchLookUpEditProveedor.Size = New System.Drawing.Size(679, 20)
        Me.SearchLookUpEditProveedor.StyleController = Me.LayoutControl2
        Me.SearchLookUpEditProveedor.TabIndex = 13
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'txtBonoProv
        '
        Me.txtBonoProv.EditValue = ""
        Me.txtBonoProv.Location = New System.Drawing.Point(398, 107)
        Me.txtBonoProv.Name = "txtBonoProv"
        Me.txtBonoProv.Size = New System.Drawing.Size(50, 20)
        Me.txtBonoProv.StyleController = Me.LayoutControl2
        Me.txtBonoProv.TabIndex = 12
        '
        'txtBonoDist
        '
        Me.txtBonoDist.EditValue = ""
        Me.txtBonoDist.Location = New System.Drawing.Point(532, 107)
        Me.txtBonoDist.Name = "txtBonoDist"
        Me.txtBonoDist.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBonoDist.Size = New System.Drawing.Size(50, 20)
        Me.txtBonoDist.StyleController = Me.LayoutControl2
        Me.txtBonoDist.TabIndex = 7
        '
        'txtBono
        '
        Me.txtBono.EditValue = ""
        Me.txtBono.Location = New System.Drawing.Point(251, 107)
        Me.txtBono.Name = "txtBono"
        Me.txtBono.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBono.Size = New System.Drawing.Size(63, 20)
        Me.txtBono.StyleController = Me.LayoutControl2
        Me.txtBono.TabIndex = 6
        '
        'SearchLookUpEditProducto
        '
        Me.SearchLookUpEditProducto.Location = New System.Drawing.Point(104, 83)
        Me.SearchLookUpEditProducto.Name = "SearchLookUpEditProducto"
        Me.SearchLookUpEditProducto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditProducto.Properties.View = Me.GridView4
        Me.SearchLookUpEditProducto.Size = New System.Drawing.Size(806, 20)
        Me.SearchLookUpEditProducto.StyleController = Me.LayoutControl2
        Me.SearchLookUpEditProducto.TabIndex = 5
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'txtRequerido
        '
        Me.txtRequerido.EditValue = ""
        Me.txtRequerido.Location = New System.Drawing.Point(104, 107)
        Me.txtRequerido.Name = "txtRequerido"
        Me.txtRequerido.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRequerido.Size = New System.Drawing.Size(63, 20)
        Me.txtRequerido.StyleController = Me.LayoutControl2
        Me.txtRequerido.TabIndex = 4
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(934, 175)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CaptionImage = CType(resources.GetObject("LayoutControlGroup4.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.LayoutControlItem9, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem21, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem4, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(914, 155)
        Me.LayoutControlGroup4.Text = "Captación de la Bonificación"
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SearchLookUpEditProducto
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 35)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(890, 24)
        Me.LayoutControlItem10.Text = "Producto"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtRequerido
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 59)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(147, 24)
        Me.LayoutControlItem9.Text = "Requerido"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtBono
        Me.LayoutControlItem11.Location = New System.Drawing.Point(147, 59)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(147, 24)
        Me.LayoutControlItem11.Text = "Bono"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtBonoDist
        Me.LayoutControlItem12.Location = New System.Drawing.Point(428, 59)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem12.Text = "Bono Distrib"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.txtBonoProv
        Me.LayoutControlItem21.Location = New System.Drawing.Point(294, 59)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem21.Text = "Bono Proveedor"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SearchLookUpEditProveedor
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(763, 24)
        Me.LayoutControlItem1.Text = "Proveedor"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DateEditDesde
        Me.LayoutControlItem2.Location = New System.Drawing.Point(562, 59)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(164, 24)
        Me.LayoutControlItem2.Text = "Desde"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DateEditHasta
        Me.LayoutControlItem3.Location = New System.Drawing.Point(726, 59)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(164, 24)
        Me.LayoutControlItem3.Text = "Hasta"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(77, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(890, 11)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.chkTodosProd
        Me.LayoutControlItem4.Location = New System.Drawing.Point(656, 83)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(234, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.chkDejarProv
        Me.LayoutControlItem5.Location = New System.Drawing.Point(763, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(127, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(294, 83)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(157, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.chkVerTabla
        Me.LayoutControlItem6.Location = New System.Drawing.Point(451, 83)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(205, 24)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'btnExcel
        '
        Me.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.Location = New System.Drawing.Point(251, 177)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(42, 36)
        Me.btnExcel.TabIndex = 33
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(127, 177)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(42, 36)
        Me.btnEdit.TabIndex = 32
        '
        'btnAdd
        '
        Me.btnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(64, 177)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(42, 36)
        Me.btnAdd.TabIndex = 31
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(189, 177)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(42, 36)
        Me.btnDelete.TabIndex = 34
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(104, 131)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(63, 20)
        Me.txtPrecio.StyleController = Me.LayoutControl2
        Me.txtPrecio.TabIndex = 19
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtPrecio
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 83)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(147, 24)
        Me.LayoutControlItem7.Text = "Precio"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(77, 13)
        '
        'txtPublico
        '
        Me.txtPublico.Location = New System.Drawing.Point(251, 131)
        Me.txtPublico.Name = "txtPublico"
        Me.txtPublico.Size = New System.Drawing.Size(63, 20)
        Me.txtPublico.StyleController = Me.LayoutControl2
        Me.txtPublico.TabIndex = 20
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtPublico
        Me.LayoutControlItem8.Location = New System.Drawing.Point(147, 83)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(147, 24)
        Me.LayoutControlItem8.Text = "Publico"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(77, 13)
        '
        'Precio
        '
        Me.Precio.Caption = "Precio"
        Me.Precio.FieldName = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.Visible = True
        Me.Precio.VisibleIndex = 9
        Me.Precio.Width = 81
        '
        'Publico
        '
        Me.Publico.Caption = "Publico"
        Me.Publico.FieldName = "PrecioPublico"
        Me.Publico.Name = "Publico"
        Me.Publico.Visible = True
        Me.Publico.VisibleIndex = 10
        Me.Publico.Width = 96
        '
        'frmBonificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 514)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "frmBonificaciones"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Bonificaciones"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.chkVerTabla.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDejarProv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTodosProd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditProveedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBonoProv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBonoDist.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditProducto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRequerido.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPublico.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Codigo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Requerido As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DateEditHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SearchLookUpEditProveedor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtBonoProv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtBonoDist As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtBono As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SearchLookUpEditProducto As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtRequerido As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents chkTodosProd As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents IDTabla As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IDProveedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Bono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CantBonifProv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CantBonifDist As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Desde As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Hasta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkDejarProv As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkVerTabla As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPublico As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPrecio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Precio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Publico As DevExpress.XtraGrid.Columns.GridColumn
End Class
