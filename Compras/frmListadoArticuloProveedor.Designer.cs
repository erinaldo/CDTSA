﻿namespace CO
{
    partial class frmListadoArticuloProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoArticuloProveedor));
            DevExpress.XtraBars.Ribbon.ReduceOperation reduceOperation1 = new DevExpress.XtraBars.Ribbon.ReduceOperation();
            DevExpress.XtraBars.Ribbon.ReduceOperation reduceOperation2 = new DevExpress.XtraBars.Ribbon.ReduceOperation();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefrescar = new DevExpress.XtraEditors.SimpleButton();
            this.dtgpDetalle = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridIdProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDescrProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColIDPaisManoFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescrPais = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoteMinCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPesoMinCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkupProveedor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDProveedor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgpDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnAgregar,
            this.btnEditar,
            this.btnCancelar,
            this.btnEliminar,
            this.btnExportar});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.Size = new System.Drawing.Size(602, 143);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Glyph")));
            this.btnAgregar.Id = 1;
            this.btnAgregar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.LargeGlyph")));
            this.btnAgregar.Name = "btnAgregar";
            // 
            // btnEditar
            // 
            this.btnEditar.Caption = "Editar";
            this.btnEditar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.Glyph")));
            this.btnEditar.Id = 2;
            this.btnEditar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.LargeGlyph")));
            this.btnEditar.Name = "btnEditar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Glyph")));
            this.btnCancelar.Id = 4;
            this.btnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.LargeGlyph")));
            this.btnCancelar.Name = "btnCancelar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Glyph")));
            this.btnEliminar.Id = 5;
            this.btnEliminar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEliminar.LargeGlyph")));
            this.btnEliminar.Name = "btnEliminar";
            // 
            // btnExportar
            // 
            this.btnExportar.Caption = "Exportar";
            this.btnExportar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportar.Glyph")));
            this.btnExportar.Id = 1;
            this.btnExportar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportar.LargeGlyph")));
            this.btnExportar.Name = "btnExportar";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            reduceOperation1.Behavior = DevExpress.XtraBars.Ribbon.ReduceOperationBehavior.Single;
            reduceOperation1.Group = null;
            reduceOperation1.ItemLinkIndex = 0;
            reduceOperation1.ItemLinksCount = 0;
            reduceOperation1.Operation = DevExpress.XtraBars.Ribbon.ReduceOperationType.LargeButtons;
            reduceOperation2.Behavior = DevExpress.XtraBars.Ribbon.ReduceOperationBehavior.Single;
            reduceOperation2.Group = null;
            reduceOperation2.ItemLinkIndex = 0;
            reduceOperation2.ItemLinksCount = 0;
            reduceOperation2.Operation = DevExpress.XtraBars.Ribbon.ReduceOperationType.Gallery;
            this.ribbonPage1.ReduceOperations.Add(reduceOperation1);
            this.ribbonPage1.ReduceOperations.Add(reduceOperation2);
            this.ribbonPage1.Text = "Opciones Generales";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAgregar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEditar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClear);
            this.layoutControl1.Controls.Add(this.btnRefrescar);
            this.layoutControl1.Controls.Add(this.dtgpDetalle);
            this.layoutControl1.Controls.Add(this.slkupProveedor);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(602, 369);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(408, 39);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 38);
            this.btnClear.StyleController = this.layoutControl1;
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Limpiar";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.Location = new System.Drawing.Point(489, 39);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(91, 38);
            this.btnRefrescar.StyleController = this.layoutControl1;
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar";
            // 
            // dtgpDetalle
            // 
            this.dtgpDetalle.Location = new System.Drawing.Point(12, 100);
            this.dtgpDetalle.MainView = this.gridView1;
            this.dtgpDetalle.MenuManager = this.ribbonControl1;
            this.dtgpDetalle.Name = "dtgpDetalle";
            this.dtgpDetalle.Size = new System.Drawing.Size(578, 257);
            this.dtgpDetalle.TabIndex = 5;
            this.dtgpDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dtgpDetalle.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridIdProd,
            this.gridDescrProd,
            this.colIDProveedor,
            this.gridProveedor,
            this.ColIDPaisManoFactura,
            this.colDescrPais,
            this.colLoteMinCompra,
            this.colPesoMinCompra});
            this.gridView1.GridControl = this.dtgpDetalle;
            this.gridView1.Name = "gridView1";
            // 
            // gridIdProd
            // 
            this.gridIdProd.Caption = "ID Producto";
            this.gridIdProd.FieldName = "IDProducto";
            this.gridIdProd.Name = "gridIdProd";
            this.gridIdProd.OptionsColumn.FixedWidth = true;
            this.gridIdProd.Visible = true;
            this.gridIdProd.VisibleIndex = 0;
            // 
            // gridDescrProd
            // 
            this.gridDescrProd.Caption = "DescrProducto";
            this.gridDescrProd.FieldName = "DescrProducto";
            this.gridDescrProd.Name = "gridDescrProd";
            this.gridDescrProd.Visible = true;
            this.gridDescrProd.VisibleIndex = 1;
            this.gridDescrProd.Width = 266;
            // 
            // colIDProveedor
            // 
            this.colIDProveedor.Caption = "IDProveedor";
            this.colIDProveedor.FieldName = "IDProveedor";
            this.colIDProveedor.Name = "colIDProveedor";
            this.colIDProveedor.OptionsColumn.FixedWidth = true;
            this.colIDProveedor.Visible = true;
            this.colIDProveedor.VisibleIndex = 2;
            this.colIDProveedor.Width = 69;
            // 
            // gridProveedor
            // 
            this.gridProveedor.Caption = "Proveedor";
            this.gridProveedor.FieldName = "NombreProveedor";
            this.gridProveedor.Name = "gridProveedor";
            this.gridProveedor.Visible = true;
            this.gridProveedor.VisibleIndex = 3;
            this.gridProveedor.Width = 72;
            // 
            // ColIDPaisManoFactura
            // 
            this.ColIDPaisManoFactura.Caption = "ID Pais Manofactura";
            this.ColIDPaisManoFactura.FieldName = "IDPaisManofactura";
            this.ColIDPaisManoFactura.Name = "ColIDPaisManoFactura";
            this.ColIDPaisManoFactura.OptionsColumn.FixedWidth = true;
            this.ColIDPaisManoFactura.Visible = true;
            this.ColIDPaisManoFactura.VisibleIndex = 4;
            this.ColIDPaisManoFactura.Width = 114;
            // 
            // colDescrPais
            // 
            this.colDescrPais.Caption = "Descr Pais";
            this.colDescrPais.FieldName = "DescrPais";
            this.colDescrPais.Name = "colDescrPais";
            this.colDescrPais.Visible = true;
            this.colDescrPais.VisibleIndex = 5;
            this.colDescrPais.Width = 171;
            // 
            // colLoteMinCompra
            // 
            this.colLoteMinCompra.Caption = "Lote Minimo Compra";
            this.colLoteMinCompra.FieldName = "LoteMinCompra";
            this.colLoteMinCompra.Name = "colLoteMinCompra";
            this.colLoteMinCompra.OptionsColumn.FixedWidth = true;
            this.colLoteMinCompra.Visible = true;
            this.colLoteMinCompra.VisibleIndex = 6;
            this.colLoteMinCompra.Width = 116;
            // 
            // colPesoMinCompra
            // 
            this.colPesoMinCompra.Caption = "Peso Min Compra";
            this.colPesoMinCompra.FieldName = "PesoMinimoCompra";
            this.colPesoMinCompra.Name = "colPesoMinCompra";
            this.colPesoMinCompra.OptionsColumn.FixedWidth = true;
            this.colPesoMinCompra.Visible = true;
            this.colPesoMinCompra.VisibleIndex = 7;
            this.colPesoMinCompra.Width = 111;
            // 
            // slkupProveedor
            // 
            this.slkupProveedor.Location = new System.Drawing.Point(79, 49);
            this.slkupProveedor.MenuManager = this.ribbonControl1;
            this.slkupProveedor.Name = "slkupProveedor";
            this.slkupProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupProveedor.Properties.View = this.searchLookUpEdit1View;
            this.slkupProveedor.Size = new System.Drawing.Size(325, 20);
            this.slkupProveedor.StyleController = this.layoutControl1;
            this.slkupProveedor.TabIndex = 4;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDProveedor2,
            this.colNombre2});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colIDProveedor2
            // 
            this.colIDProveedor2.Caption = "ID Proveedor";
            this.colIDProveedor2.FieldName = "IDProveedor";
            this.colIDProveedor2.Name = "colIDProveedor2";
            this.colIDProveedor2.Visible = true;
            this.colIDProveedor2.VisibleIndex = 0;
            // 
            // colNombre2
            // 
            this.colNombre2.Caption = "Nombre";
            this.colNombre2.FieldName = "Nombre";
            this.colNombre2.Name = "colNombre2";
            this.colNombre2.Visible = true;
            this.colNombre2.VisibleIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(602, 369);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.slkupProveedor;
            this.layoutControlItem1.Location = new System.Drawing.Point(10, 37);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(386, 24);
            this.layoutControlItem1.Text = "Proveedor:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtgpDetalle;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 88);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(582, 261);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnRefrescar;
            this.layoutControlItem3.Location = new System.Drawing.Point(477, 27);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(95, 42);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(95, 42);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(95, 44);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClear;
            this.layoutControlItem4.Location = new System.Drawing.Point(396, 27);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(81, 42);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(81, 42);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(81, 44);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptySpaceItem2.AppearanceItemCaption.Options.UseFont = true;
            this.emptySpaceItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(582, 27);
            this.emptySpaceItem2.Text = "Listado de Productos asociados al Proveedor";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(54, 0);
            this.emptySpaceItem2.TextVisible = true;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(10, 27);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(386, 10);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(10, 61);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(386, 10);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 27);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(10, 44);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(572, 27);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(10, 44);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 71);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 17);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 17);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(582, 17);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmListadoArticuloProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 512);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmListadoArticuloProveedor";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Listado de Productos por Proveedor";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgpDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnRefrescar;
        private DevExpress.XtraGrid.GridControl dtgpDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraGrid.Columns.GridColumn gridIdProd;
        private DevExpress.XtraGrid.Columns.GridColumn gridDescrProd;
        private DevExpress.XtraGrid.Columns.GridColumn colIDProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn gridProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn ColIDPaisManoFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrPais;
        private DevExpress.XtraGrid.Columns.GridColumn colLoteMinCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colPesoMinCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colIDProveedor2;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre2;
    }
}