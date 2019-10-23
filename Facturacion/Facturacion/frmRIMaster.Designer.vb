<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRIMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRIMaster))
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.ComboBoxEditEstado = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkDejarVend = New DevExpress.XtraEditors.CheckEdit()
        Me.DateEditHasta = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditDesde = New DevExpress.XtraEditors.DateEdit()
        Me.SearchLookUpEditVendedor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SearchLookUpEditSucursal = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SearchLookUpEditCliente = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDRI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Fecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IDVendedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Vendedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IDCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IDClase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Documento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButtonRefresh = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.ComboBoxEditEstado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDejarVend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditVendedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditSucursal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.ComboBoxEditEstado)
        Me.LayoutControl2.Controls.Add(Me.chkDejarVend)
        Me.LayoutControl2.Controls.Add(Me.DateEditHasta)
        Me.LayoutControl2.Controls.Add(Me.DateEditDesde)
        Me.LayoutControl2.Controls.Add(Me.SearchLookUpEditVendedor)
        Me.LayoutControl2.Controls.Add(Me.SearchLookUpEditSucursal)
        Me.LayoutControl2.Controls.Add(Me.SearchLookUpEditCliente)
        Me.LayoutControl2.Location = New System.Drawing.Point(4, 2)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup3
        Me.LayoutControl2.Size = New System.Drawing.Size(866, 118)
        Me.LayoutControl2.TabIndex = 30
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'ComboBoxEditEstado
        '
        Me.ComboBoxEditEstado.EditValue = ""
        Me.ComboBoxEditEstado.Location = New System.Drawing.Point(380, 72)
        Me.ComboBoxEditEstado.Name = "ComboBoxEditEstado"
        Me.ComboBoxEditEstado.Properties.AutoComplete = False
        Me.ComboBoxEditEstado.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEditEstado.Properties.Items.AddRange(New Object() {"Iniciado", "Finalizado", "Anulado"})
        Me.ComboBoxEditEstado.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEditEstado.Size = New System.Drawing.Size(88, 20)
        Me.ComboBoxEditEstado.StyleController = Me.LayoutControl2
        Me.ComboBoxEditEstado.TabIndex = 18
        '
        'chkDejarVend
        '
        Me.chkDejarVend.Location = New System.Drawing.Point(640, 48)
        Me.chkDejarVend.Name = "chkDejarVend"
        Me.chkDejarVend.Properties.Caption = "Mantener Vendedor"
        Me.chkDejarVend.Size = New System.Drawing.Size(202, 19)
        Me.chkDejarVend.StyleController = Me.LayoutControl2
        Me.chkDejarVend.TabIndex = 17
        '
        'DateEditHasta
        '
        Me.DateEditHasta.EditValue = Nothing
        Me.DateEditHasta.Location = New System.Drawing.Point(655, 72)
        Me.DateEditHasta.Name = "DateEditHasta"
        Me.DateEditHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditHasta.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditHasta.Size = New System.Drawing.Size(95, 20)
        Me.DateEditHasta.StyleController = Me.LayoutControl2
        Me.DateEditHasta.TabIndex = 15
        '
        'DateEditDesde
        '
        Me.DateEditDesde.EditValue = Nothing
        Me.DateEditDesde.Location = New System.Drawing.Point(521, 72)
        Me.DateEditDesde.Name = "DateEditDesde"
        Me.DateEditDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDesde.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDesde.Size = New System.Drawing.Size(81, 20)
        Me.DateEditDesde.StyleController = Me.LayoutControl2
        Me.DateEditDesde.TabIndex = 14
        '
        'SearchLookUpEditVendedor
        '
        Me.SearchLookUpEditVendedor.Location = New System.Drawing.Point(380, 48)
        Me.SearchLookUpEditVendedor.Name = "SearchLookUpEditVendedor"
        Me.SearchLookUpEditVendedor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditVendedor.Properties.View = Me.SearchLookUpEdit1View
        Me.SearchLookUpEditVendedor.Size = New System.Drawing.Size(256, 20)
        Me.SearchLookUpEditVendedor.StyleController = Me.LayoutControl2
        Me.SearchLookUpEditVendedor.TabIndex = 13
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'SearchLookUpEditSucursal
        '
        Me.SearchLookUpEditSucursal.Location = New System.Drawing.Point(73, 48)
        Me.SearchLookUpEditSucursal.Name = "SearchLookUpEditSucursal"
        Me.SearchLookUpEditSucursal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditSucursal.Properties.View = Me.GridView4
        Me.SearchLookUpEditSucursal.Size = New System.Drawing.Size(254, 20)
        Me.SearchLookUpEditSucursal.StyleController = Me.LayoutControl2
        Me.SearchLookUpEditSucursal.TabIndex = 5
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'SearchLookUpEditCliente
        '
        Me.SearchLookUpEditCliente.Location = New System.Drawing.Point(73, 72)
        Me.SearchLookUpEditCliente.Name = "SearchLookUpEditCliente"
        Me.SearchLookUpEditCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditCliente.Properties.View = Me.GridView1
        Me.SearchLookUpEditCliente.Size = New System.Drawing.Size(254, 20)
        Me.SearchLookUpEditCliente.StyleController = Me.LayoutControl2
        Me.SearchLookUpEditCliente.TabIndex = 13
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "Root"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(866, 118)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CaptionImage = CType(resources.GetObject("LayoutControlGroup4.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem10, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(846, 98)
        Me.LayoutControlGroup4.Text = "Filtros"
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(730, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(92, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SearchLookUpEditSucursal
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(307, 24)
        Me.LayoutControlItem10.Text = "Sucursal"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.ComboBoxEditEstado
        Me.LayoutControlItem4.Location = New System.Drawing.Point(307, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(141, 26)
        Me.LayoutControlItem4.Text = "Estado"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SearchLookUpEditCliente
        Me.LayoutControlItem6.CustomizationFormText = "Vendedor"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(307, 26)
        Me.LayoutControlItem6.Text = "Cliente"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SearchLookUpEditVendedor
        Me.LayoutControlItem1.Location = New System.Drawing.Point(307, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(309, 24)
        Me.LayoutControlItem1.Text = "Vendedor"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.chkDejarVend
        Me.LayoutControlItem5.Location = New System.Drawing.Point(616, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(206, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DateEditDesde
        Me.LayoutControlItem2.Location = New System.Drawing.Point(448, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(134, 26)
        Me.LayoutControlItem2.Text = "Desde"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DateEditHasta
        Me.LayoutControlItem3.Location = New System.Drawing.Point(582, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.Text = "Hasta"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(46, 13)
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(12, 118)
        Me.GridControl1.MainView = Me.GridViewDetalle
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(850, 388)
        Me.GridControl1.TabIndex = 31
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetalle})
        '
        'GridViewDetalle
        '
        Me.GridViewDetalle.Appearance.ColumnFilterButton.Options.UseTextOptions = True
        Me.GridViewDetalle.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewDetalle.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDRI, Me.RI, Me.Fecha, Me.IDVendedor, Me.Vendedor, Me.IDCliente, Me.Cliente, Me.IDClase, Me.Documento, Me.Total})
        Me.GridViewDetalle.GridControl = Me.GridControl1
        Me.GridViewDetalle.GroupPanelText = "Agrupe una Columna Aqui :"
        Me.GridViewDetalle.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Me.Vendedor, "{Count = {0}}")})
        Me.GridViewDetalle.Name = "GridViewDetalle"
        Me.GridViewDetalle.OptionsBehavior.ReadOnly = True
        Me.GridViewDetalle.OptionsFind.AlwaysVisible = True
        Me.GridViewDetalle.OptionsView.ShowAutoFilterRow = True
        Me.GridViewDetalle.OptionsView.ShowFooter = True
        Me.GridViewDetalle.OptionsView.ShowGroupPanel = False
        '
        'IDRI
        '
        Me.IDRI.Caption = "IDRI"
        Me.IDRI.FieldName = "IDRI"
        Me.IDRI.Name = "IDRI"
        Me.IDRI.Width = 20
        '
        'RI
        '
        Me.RI.Caption = "RI"
        Me.RI.FieldName = "RI"
        Me.RI.Name = "RI"
        Me.RI.Visible = True
        Me.RI.VisibleIndex = 0
        Me.RI.Width = 66
        '
        'Fecha
        '
        Me.Fecha.Caption = "Fecha"
        Me.Fecha.FieldName = "Fecha3"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Visible = True
        Me.Fecha.VisibleIndex = 7
        Me.Fecha.Width = 82
        '
        'IDVendedor
        '
        Me.IDVendedor.Caption = "IDVendedor"
        Me.IDVendedor.FieldName = "IDVendedor"
        Me.IDVendedor.Name = "IDVendedor"
        Me.IDVendedor.OptionsColumn.AllowEdit = False
        Me.IDVendedor.Visible = True
        Me.IDVendedor.VisibleIndex = 1
        Me.IDVendedor.Width = 69
        '
        'Vendedor
        '
        Me.Vendedor.Caption = "Vendedor"
        Me.Vendedor.FieldName = "Vendedor"
        Me.Vendedor.Name = "Vendedor"
        Me.Vendedor.OptionsColumn.AllowEdit = False
        Me.Vendedor.Visible = True
        Me.Vendedor.VisibleIndex = 2
        Me.Vendedor.Width = 177
        '
        'IDCliente
        '
        Me.IDCliente.Caption = "IDCliente"
        Me.IDCliente.FieldName = "IDCliente"
        Me.IDCliente.Name = "IDCliente"
        Me.IDCliente.Visible = True
        Me.IDCliente.VisibleIndex = 3
        Me.IDCliente.Width = 53
        '
        'Cliente
        '
        Me.Cliente.Caption = "Cliente"
        Me.Cliente.FieldName = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Visible = True
        Me.Cliente.VisibleIndex = 4
        Me.Cliente.Width = 86
        '
        'IDClase
        '
        Me.IDClase.Caption = "IDClase"
        Me.IDClase.FieldName = "IDClase"
        Me.IDClase.Name = "IDClase"
        Me.IDClase.Visible = True
        Me.IDClase.VisibleIndex = 5
        Me.IDClase.Width = 81
        '
        'Documento
        '
        Me.Documento.Caption = "Documento"
        Me.Documento.FieldName = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.OptionsColumn.AllowEdit = False
        Me.Documento.Visible = True
        Me.Documento.VisibleIndex = 6
        Me.Documento.Width = 99
        '
        'Total
        '
        Me.Total.Caption = "Total"
        Me.Total.FieldName = "MontoOriginal"
        Me.Total.Name = "Total"
        Me.Total.Visible = True
        Me.Total.VisibleIndex = 8
        Me.Total.Width = 119
        '
        'btnExcel
        '
        Me.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.Location = New System.Drawing.Point(883, 378)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(41, 43)
        Me.btnExcel.TabIndex = 41
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(883, 263)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(41, 43)
        Me.btnEdit.TabIndex = 40
        '
        'btnAdd
        '
        Me.btnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(883, 209)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(41, 43)
        Me.btnAdd.TabIndex = 39
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(883, 322)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(41, 43)
        Me.btnDelete.TabIndex = 42
        '
        'SimpleButtonRefresh
        '
        Me.SimpleButtonRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.SimpleButtonRefresh.Image = CType(resources.GetObject("SimpleButtonRefresh.Image"), System.Drawing.Image)
        Me.SimpleButtonRefresh.Location = New System.Drawing.Point(882, 33)
        Me.SimpleButtonRefresh.Name = "SimpleButtonRefresh"
        Me.SimpleButtonRefresh.Size = New System.Drawing.Size(42, 36)
        Me.SimpleButtonRefresh.TabIndex = 43
        '
        'frmRIMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 512)
        Me.Controls.Add(Me.SimpleButtonRefresh)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Name = "frmRIMaster"
        Me.Text = "Reporte de Ingresos"
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.ComboBoxEditEstado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDejarVend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditVendedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditSucursal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents chkDejarVend As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DateEditHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SearchLookUpEditVendedor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SearchLookUpEditSucursal As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ComboBoxEditEstado As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDRI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IDVendedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Vendedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Documento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Fecha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButtonRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SearchLookUpEditCliente As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents IDCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IDClase As DevExpress.XtraGrid.Columns.GridColumn
End Class
