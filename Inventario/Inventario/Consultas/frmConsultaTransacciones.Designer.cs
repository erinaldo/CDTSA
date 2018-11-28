namespace CI
{
    partial class frmConsultaTransacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaTransacciones));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnFiltrar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dtgDetalleTransacciones = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.referencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Bodega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Transaccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaVence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PrecioLocal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.precioDolar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CostoLocal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoCambio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Asiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleTransacciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.ribbonControl.Size = new System.Drawing.Size(703, 143);
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
            // dtgDetalleTransacciones
            // 
            this.dtgDetalleTransacciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDetalleTransacciones.Location = new System.Drawing.Point(0, 143);
            this.dtgDetalleTransacciones.MainView = this.gridView1;
            this.dtgDetalleTransacciones.MenuManager = this.ribbonControl;
            this.dtgDetalleTransacciones.Name = "dtgDetalleTransacciones";
            this.dtgDetalleTransacciones.Size = new System.Drawing.Size(703, 239);
            this.dtgDetalleTransacciones.TabIndex = 1;
            this.dtgDetalleTransacciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.paquete,
            this.documento,
            this.FechaDoc,
            this.referencia,
            this.IdProducto,
            this.DescrProd,
            this.Cantidad,
            this.Bodega,
            this.Transaccion,
            this.Lote,
            this.FechaVence,
            this.PrecioLocal,
            this.precioDolar,
            this.CostoLocal,
            this.TipoCambio,
            this.Asiento,
            this.FechaRegistro});
            this.gridView1.GridControl = this.dtgDetalleTransacciones;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // paquete
            // 
            this.paquete.Caption = "Paquete";
            this.paquete.FieldName = "DescrPaquete";
            this.paquete.Name = "paquete";
            this.paquete.Visible = true;
            this.paquete.VisibleIndex = 0;
            // 
            // documento
            // 
            this.documento.Caption = "Documento";
            this.documento.FieldName = "Documento";
            this.documento.Name = "documento";
            this.documento.Visible = true;
            this.documento.VisibleIndex = 1;
            this.documento.Width = 97;
            // 
            // FechaDoc
            // 
            this.FechaDoc.Caption = "Fecha Documento";
            this.FechaDoc.FieldName = "Fecha";
            this.FechaDoc.Name = "FechaDoc";
            this.FechaDoc.Visible = true;
            this.FechaDoc.VisibleIndex = 2;
            this.FechaDoc.Width = 97;
            // 
            // referencia
            // 
            this.referencia.Caption = "Referencia";
            this.referencia.FieldName = "Referencia";
            this.referencia.Name = "referencia";
            this.referencia.Visible = true;
            this.referencia.VisibleIndex = 3;
            this.referencia.Width = 117;
            // 
            // IdProducto
            // 
            this.IdProducto.Caption = "ID Producto";
            this.IdProducto.FieldName = "IDProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.Visible = true;
            this.IdProducto.VisibleIndex = 4;
            // 
            // DescrProd
            // 
            this.DescrProd.Caption = "Descr Producto";
            this.DescrProd.FieldName = "DescrProducto";
            this.DescrProd.Name = "DescrProd";
            this.DescrProd.Visible = true;
            this.DescrProd.VisibleIndex = 5;
            this.DescrProd.Width = 119;
            // 
            // Cantidad
            // 
            this.Cantidad.Caption = "Cantidad";
            this.Cantidad.FieldName = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Visible = true;
            this.Cantidad.VisibleIndex = 10;
            // 
            // Bodega
            // 
            this.Bodega.Caption = "Bodega";
            this.Bodega.FieldName = "DescrBodega";
            this.Bodega.Name = "Bodega";
            this.Bodega.Visible = true;
            this.Bodega.VisibleIndex = 6;
            // 
            // Transaccion
            // 
            this.Transaccion.Caption = "Transacción";
            this.Transaccion.FieldName = "DescrTipoTran";
            this.Transaccion.Name = "Transaccion";
            this.Transaccion.Visible = true;
            this.Transaccion.VisibleIndex = 7;
            // 
            // Lote
            // 
            this.Lote.Caption = "Lote";
            this.Lote.FieldName = "LoteProveedor";
            this.Lote.Name = "Lote";
            this.Lote.Visible = true;
            this.Lote.VisibleIndex = 8;
            // 
            // FechaVence
            // 
            this.FechaVence.Caption = "Fecha Vence";
            this.FechaVence.FieldName = "FechaVencimiento";
            this.FechaVence.Name = "FechaVence";
            this.FechaVence.Visible = true;
            this.FechaVence.VisibleIndex = 9;
            // 
            // PrecioLocal
            // 
            this.PrecioLocal.Caption = "P.U Local";
            this.PrecioLocal.FieldName = "PrecioUntLocal";
            this.PrecioLocal.Name = "PrecioLocal";
            this.PrecioLocal.Visible = true;
            this.PrecioLocal.VisibleIndex = 11;
            // 
            // precioDolar
            // 
            this.precioDolar.Caption = "P.U Dolar";
            this.precioDolar.FieldName = "PrecioUntDolar";
            this.precioDolar.Name = "precioDolar";
            this.precioDolar.Visible = true;
            this.precioDolar.VisibleIndex = 12;
            // 
            // CostoLocal
            // 
            this.CostoLocal.Caption = "C.U Local";
            this.CostoLocal.FieldName = "CostoUntLocal";
            this.CostoLocal.Name = "CostoLocal";
            this.CostoLocal.Visible = true;
            this.CostoLocal.VisibleIndex = 13;
            // 
            // TipoCambio
            // 
            this.TipoCambio.Caption = "Tipo Cambio";
            this.TipoCambio.FieldName = "TipoCambio";
            this.TipoCambio.Name = "TipoCambio";
            this.TipoCambio.Visible = true;
            this.TipoCambio.VisibleIndex = 14;
            // 
            // Asiento
            // 
            this.Asiento.Caption = "Asiento";
            this.Asiento.FieldName = "Asiento";
            this.Asiento.Name = "Asiento";
            this.Asiento.Visible = true;
            this.Asiento.VisibleIndex = 15;
            this.Asiento.Width = 85;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.Caption = "Fecha Registro";
            this.FechaRegistro.FieldName = "CreateDate";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.Visible = true;
            this.FechaRegistro.VisibleIndex = 16;
            this.FechaRegistro.Width = 102;
            // 
            // frmConsultaTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 382);
            this.Controls.Add(this.dtgDetalleTransacciones);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaTransacciones";
            this.Ribbon = this.ribbonControl;
            this.Text = "Consulta de Transacciones de Inventario";
            this.Load += new System.EventHandler(this.frmConsultaTransacciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleTransacciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl dtgDetalleTransacciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn paquete;
        private DevExpress.XtraGrid.Columns.GridColumn documento;
        private DevExpress.XtraGrid.Columns.GridColumn FechaDoc;
        private DevExpress.XtraGrid.Columns.GridColumn referencia;
        private DevExpress.XtraGrid.Columns.GridColumn IdProducto;
        private DevExpress.XtraGrid.Columns.GridColumn DescrProd;
        private DevExpress.XtraGrid.Columns.GridColumn Cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn Bodega;
        private DevExpress.XtraGrid.Columns.GridColumn Transaccion;
        private DevExpress.XtraGrid.Columns.GridColumn Lote;
        private DevExpress.XtraGrid.Columns.GridColumn FechaVence;
        private DevExpress.XtraGrid.Columns.GridColumn PrecioLocal;
        private DevExpress.XtraGrid.Columns.GridColumn precioDolar;
        private DevExpress.XtraGrid.Columns.GridColumn CostoLocal;
        private DevExpress.XtraGrid.Columns.GridColumn TipoCambio;
        private DevExpress.XtraGrid.Columns.GridColumn Asiento;
        private DevExpress.XtraGrid.Columns.GridColumn FechaRegistro;
    }
}