<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRemision))
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEditHasta = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditDesde = New DevExpress.XtraEditors.DateEdit()
        Me.GridHeader = New DevExpress.XtraGrid.GridControl()
        Me.GridViewHeader = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemisionada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPesoKG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTipoEntrega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridProducto = New DevExpress.XtraGrid.GridControl()
        Me.GridViewProducto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcIDProducto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcDescr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcFactura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcBonifProd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcEntregar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcCantFacturada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcCantBonificada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLoteInterno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcLoteProveedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcIDBodega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.rbRemisionados = New System.Windows.Forms.RadioButton()
        Me.rbNoRemisionada = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.txtPesoKG = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdRemisionar = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GridColumnDescrtipoentrega = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.DateEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPesoKG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(361, 26)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(98, 22)
        Me.btnRefresh.TabIndex = 50
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.ToolTip = "Refresca las facturas con los parametros establecidos"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(198, 27)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl3.TabIndex = 49
        Me.LabelControl3.Text = "Hasta :"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 26)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 48
        Me.LabelControl2.Text = "Desde :"
        '
        'DateEditHasta
        '
        Me.DateEditHasta.EditValue = Nothing
        Me.DateEditHasta.Location = New System.Drawing.Point(259, 23)
        Me.DateEditHasta.Name = "DateEditHasta"
        Me.DateEditHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditHasta.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditHasta.Size = New System.Drawing.Size(81, 20)
        Me.DateEditHasta.TabIndex = 47
        '
        'DateEditDesde
        '
        Me.DateEditDesde.EditValue = New Date(2018, 1, 1, 0, 0, 0, 0)
        Me.DateEditDesde.Location = New System.Drawing.Point(68, 23)
        Me.DateEditDesde.Name = "DateEditDesde"
        Me.DateEditDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDesde.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDesde.Size = New System.Drawing.Size(80, 20)
        Me.DateEditDesde.TabIndex = 46
        '
        'GridHeader
        '
        Me.GridHeader.Location = New System.Drawing.Point(14, 95)
        Me.GridHeader.MainView = Me.GridViewHeader
        Me.GridHeader.Name = "GridHeader"
        Me.GridHeader.Size = New System.Drawing.Size(1007, 231)
        Me.GridHeader.TabIndex = 51
        Me.GridHeader.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewHeader})
        '
        'GridViewHeader
        '
        Me.GridViewHeader.Appearance.ColumnFilterButton.Options.UseTextOptions = True
        Me.GridViewHeader.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridViewHeader.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn13, Me.GridColumn15, Me.GridColumn17, Me.GridColumn20, Me.GridColumnRemisionada, Me.GridColumnPesoKG, Me.GridColumnDescrtipoentrega, Me.GridColumnTipoEntrega})
        Me.GridViewHeader.GridControl = Me.GridHeader
        Me.GridViewHeader.GroupPanelText = "Agrupe una Columna Aqui :"
        Me.GridViewHeader.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Nothing, "{Count = {0}}")})
        Me.GridViewHeader.Name = "GridViewHeader"
        Me.GridViewHeader.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewHeader.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewHeader.OptionsBehavior.Editable = False
        Me.GridViewHeader.OptionsFind.AlwaysVisible = True
        Me.GridViewHeader.OptionsView.ShowAutoFilterRow = True
        Me.GridViewHeader.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Cliente"
        Me.GridColumn9.FieldName = "IDCliente"
        Me.GridColumn9.ImageAlignment = System.Drawing.StringAlignment.Center
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 49
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Nombre"
        Me.GridColumn10.FieldName = "Nombre"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        Me.GridColumn10.Width = 185
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "IDFactura"
        Me.GridColumn13.FieldName = "IDFactura"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 53
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Factura"
        Me.GridColumn15.FieldName = "Factura"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 3
        Me.GridColumn15.Width = 101
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Fecha"
        Me.GridColumn17.DisplayFormat.FormatString = "d"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn17.FieldName = "FECHA"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 4
        Me.GridColumn17.Width = 89
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Bodega"
        Me.GridColumn20.FieldName = "IDBodega"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 7
        Me.GridColumn20.Width = 45
        '
        'GridColumnRemisionada
        '
        Me.GridColumnRemisionada.Caption = "Remisionada"
        Me.GridColumnRemisionada.FieldName = "Remisionada"
        Me.GridColumnRemisionada.Name = "GridColumnRemisionada"
        Me.GridColumnRemisionada.Visible = True
        Me.GridColumnRemisionada.VisibleIndex = 5
        Me.GridColumnRemisionada.Width = 71
        '
        'GridColumnPesoKG
        '
        Me.GridColumnPesoKG.Caption = "PesoKG"
        Me.GridColumnPesoKG.FieldName = "PesoKG"
        Me.GridColumnPesoKG.Name = "GridColumnPesoKG"
        Me.GridColumnPesoKG.Visible = True
        Me.GridColumnPesoKG.VisibleIndex = 6
        Me.GridColumnPesoKG.Width = 49
        '
        'GridColumnTipoEntrega
        '
        Me.GridColumnTipoEntrega.Caption = "TipoEntrega"
        Me.GridColumnTipoEntrega.FieldName = "IDTipoEntrega"
        Me.GridColumnTipoEntrega.Name = "GridColumnTipoEntrega"
        '
        'GridProducto
        '
        Me.GridProducto.Location = New System.Drawing.Point(12, 343)
        Me.GridProducto.MainView = Me.GridViewProducto
        Me.GridProducto.Name = "GridProducto"
        Me.GridProducto.Size = New System.Drawing.Size(1009, 175)
        Me.GridProducto.TabIndex = 52
        Me.GridProducto.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProducto})
        '
        'GridViewProducto
        '
        Me.GridViewProducto.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcIDProducto, Me.gcDescr, Me.gcFactura, Me.gcBonifProd, Me.gcEntregar, Me.gcCantFacturada, Me.gcCantBonificada, Me.GridColumnLoteInterno, Me.gcLoteProveedor, Me.gcIDBodega})
        Me.GridViewProducto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.GridViewProducto.GridControl = Me.GridProducto
        Me.GridViewProducto.Name = "GridViewProducto"
        Me.GridViewProducto.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewProducto.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewProducto.OptionsBehavior.AutoPopulateColumns = False
        Me.GridViewProducto.OptionsBehavior.Editable = False
        Me.GridViewProducto.OptionsBehavior.ReadOnly = True
        Me.GridViewProducto.OptionsView.ShowGroupPanel = False
        '
        'gcIDProducto
        '
        Me.gcIDProducto.AppearanceCell.Options.UseTextOptions = True
        Me.gcIDProducto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gcIDProducto.Caption = "ID"
        Me.gcIDProducto.FieldName = "IDProducto"
        Me.gcIDProducto.Name = "gcIDProducto"
        Me.gcIDProducto.Visible = True
        Me.gcIDProducto.VisibleIndex = 0
        Me.gcIDProducto.Width = 44
        '
        'gcDescr
        '
        Me.gcDescr.Caption = "Descr"
        Me.gcDescr.FieldName = "DescrProducto"
        Me.gcDescr.Name = "gcDescr"
        Me.gcDescr.Visible = True
        Me.gcDescr.VisibleIndex = 1
        Me.gcDescr.Width = 235
        '
        'gcFactura
        '
        Me.gcFactura.AppearanceHeader.Options.UseTextOptions = True
        Me.gcFactura.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.gcFactura.Caption = "Factura"
        Me.gcFactura.FieldName = "Factura"
        Me.gcFactura.Name = "gcFactura"
        Me.gcFactura.Visible = True
        Me.gcFactura.VisibleIndex = 2
        '
        'gcBonifProd
        '
        Me.gcBonifProd.AppearanceHeader.Options.UseTextOptions = True
        Me.gcBonifProd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcBonifProd.Caption = "BonifiProd"
        Me.gcBonifProd.FieldName = "BonificaProducto"
        Me.gcBonifProd.Name = "gcBonifProd"
        Me.gcBonifProd.Visible = True
        Me.gcBonifProd.VisibleIndex = 6
        Me.gcBonifProd.Width = 67
        '
        'gcEntregar
        '
        Me.gcEntregar.AppearanceHeader.Options.UseTextOptions = True
        Me.gcEntregar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gcEntregar.Caption = "Entregar"
        Me.gcEntregar.DisplayFormat.FormatString = "n2"
        Me.gcEntregar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcEntregar.FieldName = "Entregar"
        Me.gcEntregar.Name = "gcEntregar"
        Me.gcEntregar.Visible = True
        Me.gcEntregar.VisibleIndex = 5
        Me.gcEntregar.Width = 71
        '
        'gcCantFacturada
        '
        Me.gcCantFacturada.AppearanceHeader.Options.UseTextOptions = True
        Me.gcCantFacturada.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gcCantFacturada.Caption = "Facturado"
        Me.gcCantFacturada.DisplayFormat.FormatString = "n2"
        Me.gcCantFacturada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcCantFacturada.FieldName = "CantFacturada"
        Me.gcCantFacturada.Name = "gcCantFacturada"
        Me.gcCantFacturada.Visible = True
        Me.gcCantFacturada.VisibleIndex = 7
        Me.gcCantFacturada.Width = 85
        '
        'gcCantBonificada
        '
        Me.gcCantBonificada.AppearanceHeader.Options.UseTextOptions = True
        Me.gcCantBonificada.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gcCantBonificada.Caption = "Bonificado"
        Me.gcCantBonificada.DisplayFormat.FormatString = "n2"
        Me.gcCantBonificada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcCantBonificada.FieldName = "CantBonificada"
        Me.gcCantBonificada.Name = "gcCantBonificada"
        Me.gcCantBonificada.Visible = True
        Me.gcCantBonificada.VisibleIndex = 8
        Me.gcCantBonificada.Width = 84
        '
        'GridColumnLoteInterno
        '
        Me.GridColumnLoteInterno.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnLoteInterno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnLoteInterno.Caption = "LoteInterno"
        Me.GridColumnLoteInterno.FieldName = "LoteInterno"
        Me.GridColumnLoteInterno.Name = "GridColumnLoteInterno"
        Me.GridColumnLoteInterno.Visible = True
        Me.GridColumnLoteInterno.VisibleIndex = 4
        Me.GridColumnLoteInterno.Width = 67
        '
        'gcLoteProveedor
        '
        Me.gcLoteProveedor.AppearanceHeader.Options.UseTextOptions = True
        Me.gcLoteProveedor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.gcLoteProveedor.Caption = "LoteProveedor"
        Me.gcLoteProveedor.DisplayFormat.FormatString = "n2"
        Me.gcLoteProveedor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcLoteProveedor.FieldName = "LoteProveedor"
        Me.gcLoteProveedor.Name = "gcLoteProveedor"
        Me.gcLoteProveedor.Visible = True
        Me.gcLoteProveedor.VisibleIndex = 3
        Me.gcLoteProveedor.Width = 87
        '
        'gcIDBodega
        '
        Me.gcIDBodega.Caption = "Bodega"
        Me.gcIDBodega.FieldName = "IDBodega"
        Me.gcIDBodega.Name = "gcIDBodega"
        '
        'cmdPrint
        '
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.Location = New System.Drawing.Point(256, 26)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(107, 22)
        Me.cmdPrint.TabIndex = 50
        Me.cmdPrint.Text = "Print"
        '
        'rbRemisionados
        '
        Me.rbRemisionados.Location = New System.Drawing.Point(154, 46)
        Me.rbRemisionados.Name = "rbRemisionados"
        Me.rbRemisionados.Size = New System.Drawing.Size(99, 25)
        Me.rbRemisionados.TabIndex = 55
        Me.rbRemisionados.Text = "Remisionadas"
        Me.rbRemisionados.UseVisualStyleBackColor = True
        '
        'rbNoRemisionada
        '
        Me.rbNoRemisionada.Checked = True
        Me.rbNoRemisionada.Location = New System.Drawing.Point(32, 45)
        Me.rbNoRemisionada.Name = "rbNoRemisionada"
        Me.rbNoRemisionada.Size = New System.Drawing.Size(116, 25)
        Me.rbNoRemisionada.TabIndex = 54
        Me.rbNoRemisionada.TabStop = True
        Me.rbNoRemisionada.Text = "No Remisionadas"
        Me.rbNoRemisionada.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.Location = New System.Drawing.Point(259, 46)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(65, 25)
        Me.rbTodos.TabIndex = 53
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'txtPesoKG
        '
        Me.txtPesoKG.Location = New System.Drawing.Point(72, 28)
        Me.txtPesoKG.Name = "txtPesoKG"
        Me.txtPesoKG.Size = New System.Drawing.Size(55, 20)
        Me.txtPesoKG.TabIndex = 56
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 31)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 57
        Me.LabelControl1.Text = "Peso en KG:"
        '
        'cmdRemisionar
        '
        Me.cmdRemisionar.Image = CType(resources.GetObject("cmdRemisionar.Image"), System.Drawing.Image)
        Me.cmdRemisionar.Location = New System.Drawing.Point(152, 27)
        Me.cmdRemisionar.Name = "cmdRemisionar"
        Me.cmdRemisionar.Size = New System.Drawing.Size(98, 22)
        Me.cmdRemisionar.TabIndex = 58
        Me.cmdRemisionar.Text = "Remisionar"
        Me.cmdRemisionar.ToolTip = "Se Marca la Factura como remisionada y ademas guarda el Peso en KG del Pedido o F" & _
    "actura"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.DateEditHasta)
        Me.GroupControl1.Controls.Add(Me.DateEditDesde)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.rbRemisionados)
        Me.GroupControl1.Controls.Add(Me.rbNoRemisionada)
        Me.GroupControl1.Controls.Add(Me.rbTodos)
        Me.GroupControl1.Controls.Add(Me.btnRefresh)
        Me.GroupControl1.Location = New System.Drawing.Point(39, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(464, 73)
        Me.GroupControl1.TabIndex = 59
        Me.GroupControl1.Text = "Filtros"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.txtPesoKG)
        Me.GroupControl2.Controls.Add(Me.cmdRemisionar)
        Me.GroupControl2.Controls.Add(Me.cmdPrint)
        Me.GroupControl2.Location = New System.Drawing.Point(564, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(368, 74)
        Me.GroupControl2.TabIndex = 60
        Me.GroupControl2.Text = "Acciones"
        '
        'GridColumnDescrtipoentrega
        '
        Me.GridColumnDescrtipoentrega.Caption = "TipoEntrega"
        Me.GridColumnDescrtipoentrega.FieldName = "DescrEntrega"
        Me.GridColumnDescrtipoentrega.Name = "GridColumnDescrtipoentrega"
        Me.GridColumnDescrtipoentrega.Visible = True
        Me.GridColumnDescrtipoentrega.VisibleIndex = 8
        Me.GridColumnDescrtipoentrega.Width = 84
        '
        'frmRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 562)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GridProducto)
        Me.Controls.Add(Me.GridHeader)
        Me.Name = "frmRemision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmRemision"
        CType(Me.DateEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPesoKG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEditHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridHeader As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewHeader As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridProducto As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProducto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcIDProducto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcDescr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcEntregar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcCantFacturada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcFactura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcBonifProd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcCantBonificada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLoteInterno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcLoteProveedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcIDBodega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents rbRemisionados As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoRemisionada As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents txtPesoKG As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdRemisionar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnRemisionada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPesoKG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTipoEntrega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridColumnDescrtipoentrega As DevExpress.XtraGrid.Columns.GridColumn
End Class
