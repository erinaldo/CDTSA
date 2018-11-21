namespace CI
{
    partial class frmConsultaExistenciaBodega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaExistenciaBodega));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnFiltrar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dtgConsultaExistencia = new DevExpress.XtraGrid.GridControl();
            this.gridViewConsultaExistencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDBodega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrBodega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDLote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoteInterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoteProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaVence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaIngreso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Existencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Reserva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultaExistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConsultaExistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnFiltrar,
            this.btnCancelar,
            this.lblStatus,
            this.btnExportar,
            this.btnRefrescar});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 4;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(779, 143);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Caption = "Filtro";
            this.btnFiltrar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Glyph")));
            this.btnFiltrar.Id = 1;
            this.btnFiltrar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.LargeGlyph")));
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFiltrar_ItemClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Glyph")));
            this.btnCancelar.Id = 4;
            this.btnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.LargeGlyph")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelar_ItemClick);
            // 
            // lblStatus
            // 
            this.lblStatus.Id = 1;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnExportar
            // 
            this.btnExportar.Caption = "Exportar";
            this.btnExportar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportar.Glyph")));
            this.btnExportar.Id = 2;
            this.btnExportar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportar.LargeGlyph")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportar_ItemClick);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Caption = "Refrescar";
            this.btnRefrescar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Glyph")));
            this.btnRefrescar.Id = 3;
            this.btnRefrescar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.LargeGlyph")));
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefrescar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Operaciones Concsecutivos";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFiltrar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefrescar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtgConsultaExistencia);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(779, 387);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dtgConsultaExistencia
            // 
            this.dtgConsultaExistencia.Location = new System.Drawing.Point(12, 12);
            this.dtgConsultaExistencia.MainView = this.gridViewConsultaExistencia;
            this.dtgConsultaExistencia.MenuManager = this.ribbonControl;
            this.dtgConsultaExistencia.Name = "dtgConsultaExistencia";
            this.dtgConsultaExistencia.Size = new System.Drawing.Size(755, 363);
            this.dtgConsultaExistencia.TabIndex = 4;
            this.dtgConsultaExistencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewConsultaExistencia});
            // 
            // gridViewConsultaExistencia
            // 
            this.gridViewConsultaExistencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDBodega,
            this.DescrBodega,
            this.IDProducto,
            this.DescrProducto,
            this.IDLote,
            this.LoteInterno,
            this.LoteProveedor,
            this.FechaVence,
            this.FechaIngreso,
            this.Existencia,
            this.Reserva});
            this.gridViewConsultaExistencia.GridControl = this.dtgConsultaExistencia;
            this.gridViewConsultaExistencia.Name = "gridViewConsultaExistencia";
            this.gridViewConsultaExistencia.OptionsBehavior.Editable = false;
            this.gridViewConsultaExistencia.OptionsBehavior.ReadOnly = true;
            this.gridViewConsultaExistencia.OptionsView.ColumnAutoWidth = false;
            this.gridViewConsultaExistencia.OptionsView.ShowAutoFilterRow = true;
            // 
            // IDBodega
            // 
            this.IDBodega.Caption = "IDBodega";
            this.IDBodega.FieldName = "IDBodega";
            this.IDBodega.Name = "IDBodega";
            this.IDBodega.OptionsColumn.FixedWidth = true;
            this.IDBodega.Visible = true;
            this.IDBodega.VisibleIndex = 0;
            this.IDBodega.Width = 61;
            // 
            // DescrBodega
            // 
            this.DescrBodega.Caption = "Descr Bodega";
            this.DescrBodega.FieldName = "DescrBodega";
            this.DescrBodega.Name = "DescrBodega";
            this.DescrBodega.OptionsColumn.FixedWidth = true;
            this.DescrBodega.Visible = true;
            this.DescrBodega.VisibleIndex = 1;
            this.DescrBodega.Width = 84;
            // 
            // IDProducto
            // 
            this.IDProducto.Caption = "ID Producto";
            this.IDProducto.FieldName = "IDProducto";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.OptionsColumn.FixedWidth = true;
            this.IDProducto.Visible = true;
            this.IDProducto.VisibleIndex = 2;
            // 
            // DescrProducto
            // 
            this.DescrProducto.Caption = "Descr Producto";
            this.DescrProducto.FieldName = "DescrProducto";
            this.DescrProducto.Name = "DescrProducto";
            this.DescrProducto.Visible = true;
            this.DescrProducto.VisibleIndex = 3;
            this.DescrProducto.Width = 51;
            // 
            // IDLote
            // 
            this.IDLote.Caption = "ID Lote";
            this.IDLote.FieldName = "IDLote";
            this.IDLote.Name = "IDLote";
            this.IDLote.OptionsColumn.FixedWidth = true;
            this.IDLote.Visible = true;
            this.IDLote.VisibleIndex = 4;
            this.IDLote.Width = 63;
            // 
            // LoteInterno
            // 
            this.LoteInterno.Caption = "Lote Interno";
            this.LoteInterno.FieldName = "LoteInterno";
            this.LoteInterno.Name = "LoteInterno";
            this.LoteInterno.Visible = true;
            this.LoteInterno.VisibleIndex = 5;
            this.LoteInterno.Width = 48;
            // 
            // LoteProveedor
            // 
            this.LoteProveedor.Caption = "Lote Proveedor";
            this.LoteProveedor.FieldName = "LoteProveedor";
            this.LoteProveedor.Name = "LoteProveedor";
            this.LoteProveedor.Visible = true;
            this.LoteProveedor.VisibleIndex = 6;
            this.LoteProveedor.Width = 36;
            // 
            // FechaVence
            // 
            this.FechaVence.Caption = "Fecha Vence";
            this.FechaVence.FieldName = "FechaVencimiento";
            this.FechaVence.Name = "FechaVence";
            this.FechaVence.OptionsColumn.FixedWidth = true;
            this.FechaVence.Visible = true;
            this.FechaVence.VisibleIndex = 7;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.Caption = "Fecha Ingreso";
            this.FechaIngreso.FieldName = "FechaIngreso";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.OptionsColumn.FixedWidth = true;
            this.FechaIngreso.Visible = true;
            this.FechaIngreso.VisibleIndex = 8;
            this.FechaIngreso.Width = 84;
            // 
            // Existencia
            // 
            this.Existencia.Caption = "Existencia";
            this.Existencia.FieldName = "Existencia";
            this.Existencia.Name = "Existencia";
            this.Existencia.OptionsColumn.FixedWidth = true;
            this.Existencia.Visible = true;
            this.Existencia.VisibleIndex = 9;
            // 
            // Reserva
            // 
            this.Reserva.Caption = "Reserva";
            this.Reserva.FieldName = "Reserva";
            this.Reserva.Name = "Reserva";
            this.Reserva.OptionsColumn.FixedWidth = true;
            this.Reserva.Visible = true;
            this.Reserva.VisibleIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(779, 387);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtgConsultaExistencia;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(759, 367);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmConsultaExistenciaBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 530);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaExistenciaBodega";
            this.Ribbon = this.ribbonControl;
            this.Text = "Existencias de Productos";
            this.Load += new System.EventHandler(this.frmConsultaExistenciaBodega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultaExistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConsultaExistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnFiltrar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarButtonItem btnRefrescar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl dtgConsultaExistencia;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewConsultaExistencia;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn IDBodega;
        private DevExpress.XtraGrid.Columns.GridColumn DescrBodega;
        private DevExpress.XtraGrid.Columns.GridColumn IDProducto;
        private DevExpress.XtraGrid.Columns.GridColumn DescrProducto;
        private DevExpress.XtraGrid.Columns.GridColumn IDLote;
        private DevExpress.XtraGrid.Columns.GridColumn LoteInterno;
        private DevExpress.XtraGrid.Columns.GridColumn LoteProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn FechaVence;
        private DevExpress.XtraGrid.Columns.GridColumn FechaIngreso;
        private DevExpress.XtraGrid.Columns.GridColumn Existencia;
        private DevExpress.XtraGrid.Columns.GridColumn Reserva;
    }
}