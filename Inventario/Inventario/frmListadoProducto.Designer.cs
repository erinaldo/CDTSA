namespace CI
{
    partial class frmListadoProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoProducto));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFiltro = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridIdProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdAlias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdFactorEmpaque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEsMuestra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEsControlado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEsEtico = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnAgregar,
            this.btnEditar,
            this.btnFiltro,
            this.btnCancelar,
            this.btnEliminar,
            this.btnExportar,
            this.btnRefrescar});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 4;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(702, 143);
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
            // btnFiltro
            // 
            this.btnFiltro.Caption = "Filtro";
            this.btnFiltro.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFiltro.Glyph")));
            this.btnFiltro.Id = 3;
            this.btnFiltro.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFiltro.LargeGlyph")));
            this.btnFiltro.Name = "btnFiltro";
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
            this.btnExportar.Id = 2;
            this.btnExportar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportar.LargeGlyph")));
            this.btnExportar.Name = "btnExportar";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Caption = "Refrescar";
            this.btnRefrescar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Glyph")));
            this.btnRefrescar.Id = 3;
            this.btnRefrescar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.LargeGlyph")));
            this.btnRefrescar.Name = "btnRefrescar";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Operaciones Centro Costo";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFiltro);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAgregar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEditar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefrescar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(702, 309);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 36);
            this.gridControl1.MainView = this.gridView;
            this.gridControl1.MenuManager = this.ribbonControl;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(678, 261);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridIdProducto,
            this.grdDescr,
            this.grdAlias,
            this.grdFactorEmpaque,
            this.grdEsMuestra,
            this.grdEsControlado,
            this.grdEsEtico});
            this.gridView.GridControl = this.gridControl1;
            this.gridView.Name = "gridView";
            // 
            // gridIdProducto
            // 
            this.gridIdProducto.Caption = "ID Producto";
            this.gridIdProducto.FieldName = "IDProducto";
            this.gridIdProducto.Name = "gridIdProducto";
            this.gridIdProducto.Visible = true;
            this.gridIdProducto.VisibleIndex = 0;
            // 
            // grdDescr
            // 
            this.grdDescr.Caption = "Descripción";
            this.grdDescr.FieldName = "Descr";
            this.grdDescr.Name = "grdDescr";
            this.grdDescr.Visible = true;
            this.grdDescr.VisibleIndex = 1;
            // 
            // grdAlias
            // 
            this.grdAlias.Caption = "Alias";
            this.grdAlias.FieldName = "Alias";
            this.grdAlias.Name = "grdAlias";
            this.grdAlias.Visible = true;
            this.grdAlias.VisibleIndex = 2;
            // 
            // grdFactorEmpaque
            // 
            this.grdFactorEmpaque.Caption = "FactorEmpaque";
            this.grdFactorEmpaque.FieldName = "FactorEmpaque";
            this.grdFactorEmpaque.Name = "grdFactorEmpaque";
            this.grdFactorEmpaque.Visible = true;
            this.grdFactorEmpaque.VisibleIndex = 3;
            // 
            // grdEsMuestra
            // 
            this.grdEsMuestra.Caption = "Es Muestra";
            this.grdEsMuestra.FieldName = "EsMuestra";
            this.grdEsMuestra.Name = "grdEsMuestra";
            this.grdEsMuestra.Visible = true;
            this.grdEsMuestra.VisibleIndex = 4;
            // 
            // grdEsControlado
            // 
            this.grdEsControlado.Caption = "Es Controlado";
            this.grdEsControlado.FieldName = "EsControlado";
            this.grdEsControlado.Name = "grdEsControlado";
            this.grdEsControlado.Visible = true;
            this.grdEsControlado.VisibleIndex = 5;
            // 
            // grdEsEtico
            // 
            this.grdEsEtico.Caption = "EsEtico";
            this.grdEsEtico.FieldName = "EsEtico";
            this.grdEsEtico.Name = "grdEsEtico";
            this.grdEsEtico.Visible = true;
            this.grdEsEtico.VisibleIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DeepPink;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(678, 20);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Listado de Productos";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(702, 309);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelControl1;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(122, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(682, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Listado de Productos";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(682, 265);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmListadoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 452);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "frmListadoProducto";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Productos";
            this.Load += new System.EventHandler(this.frmListadoProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem btnFiltro;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarButtonItem btnRefrescar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridIdProducto;
        private DevExpress.XtraGrid.Columns.GridColumn grdDescr;
        private DevExpress.XtraGrid.Columns.GridColumn grdAlias;
        private DevExpress.XtraGrid.Columns.GridColumn grdFactorEmpaque;
        private DevExpress.XtraGrid.Columns.GridColumn grdEsMuestra;
        private DevExpress.XtraGrid.Columns.GridColumn grdEsControlado;
        private DevExpress.XtraGrid.Columns.GridColumn grdEsEtico;
    }
}