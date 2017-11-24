namespace ControlBancario
{
    partial class frmListadoDocumentosBancarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoDocumentosBancarios));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFiltro = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridDocumentos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CuentaBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Alias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPagaderoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Monto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Usuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CConceptoContable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnAgregar,
            this.btnCancelar,
            this.btnAnular,
            this.lblStatus,
            this.btnExportar,
            this.btnRefrescar,
            this.btnFiltro});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 5;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(750, 143);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Glyph")));
            this.btnAgregar.Id = 1;
            this.btnAgregar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.LargeGlyph")));
            this.btnAgregar.Name = "btnAgregar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Glyph")));
            this.btnCancelar.Id = 4;
            this.btnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.LargeGlyph")));
            this.btnCancelar.Name = "btnCancelar";
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAnular.Glyph")));
            this.btnAnular.Id = 5;
            this.btnAnular.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnular.LargeGlyph")));
            this.btnAnular.Name = "btnAnular";
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
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Caption = "Refrescar";
            this.btnRefrescar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Glyph")));
            this.btnRefrescar.Id = 3;
            this.btnRefrescar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.LargeGlyph")));
            this.btnRefrescar.Name = "btnRefrescar";
            // 
            // btnFiltro
            // 
            this.btnFiltro.Caption = "Filtro";
            this.btnFiltro.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFiltro.Glyph")));
            this.btnFiltro.Id = 4;
            this.btnFiltro.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFiltro.LargeGlyph")));
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnFiltro_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Operaciones Documentos";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFiltro);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAgregar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAnular);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefrescar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridDocumentos);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(750, 423);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridDocumentos
            // 
            this.gridDocumentos.Location = new System.Drawing.Point(12, 12);
            this.gridDocumentos.MainView = this.gridView1;
            this.gridDocumentos.MenuManager = this.ribbonControl;
            this.gridDocumentos.Name = "gridDocumentos";
            this.gridDocumentos.Size = new System.Drawing.Size(726, 399);
            this.gridDocumentos.TabIndex = 4;
            this.gridDocumentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Fecha,
            this.CuentaBanco,
            this.Tipo,
            this.SubTipo,
            this.Nombre,
            this.Alias,
            this.cPagaderoa,
            this.Monto,
            this.Usuario,
            this.CReferencia,
            this.CConceptoContable});
            this.gridView1.GridControl = this.gridDocumentos;
            this.gridView1.Name = "gridView1";
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 0;
            // 
            // CuentaBanco
            // 
            this.CuentaBanco.Caption = "Cuenta Banco";
            this.CuentaBanco.FieldName = "DescrCuentaBancaria";
            this.CuentaBanco.Name = "CuentaBanco";
            this.CuentaBanco.Visible = true;
            this.CuentaBanco.VisibleIndex = 1;
            // 
            // Tipo
            // 
            this.Tipo.Caption = "Tipo";
            this.Tipo.FieldName = "DescrTipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Visible = true;
            this.Tipo.VisibleIndex = 2;
            // 
            // SubTipo
            // 
            this.SubTipo.Caption = "Sub Tipo";
            this.SubTipo.FieldName = "DescrSubTipo";
            this.SubTipo.Name = "SubTipo";
            this.SubTipo.Visible = true;
            this.SubTipo.VisibleIndex = 3;
            // 
            // Nombre
            // 
            this.Nombre.Caption = "Nombre";
            this.Nombre.FieldName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Visible = true;
            this.Nombre.VisibleIndex = 4;
            // 
            // Alias
            // 
            this.Alias.Caption = "Alias";
            this.Alias.FieldName = "Alias";
            this.Alias.Name = "Alias";
            this.Alias.Visible = true;
            this.Alias.VisibleIndex = 5;
            // 
            // cPagaderoa
            // 
            this.cPagaderoa.Caption = "Pagadero A";
            this.cPagaderoa.FieldName = "Pagadero_a";
            this.cPagaderoa.Name = "cPagaderoa";
            this.cPagaderoa.Visible = true;
            this.cPagaderoa.VisibleIndex = 6;
            // 
            // Monto
            // 
            this.Monto.Caption = "Monto";
            this.Monto.FieldName = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.Visible = true;
            this.Monto.VisibleIndex = 7;
            // 
            // Usuario
            // 
            this.Usuario.Caption = "Usuario";
            this.Usuario.FieldName = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.Visible = true;
            this.Usuario.VisibleIndex = 8;
            // 
            // CReferencia
            // 
            this.CReferencia.Caption = "Referencia";
            this.CReferencia.FieldName = "Referencia";
            this.CReferencia.Name = "CReferencia";
            this.CReferencia.Visible = true;
            this.CReferencia.VisibleIndex = 9;
            // 
            // CConceptoContable
            // 
            this.CConceptoContable.Caption = "Concepto Contable";
            this.CConceptoContable.FieldName = "ConceptoContable";
            this.CConceptoContable.Name = "CConceptoContable";
            this.CConceptoContable.Visible = true;
            this.CConceptoContable.VisibleIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(750, 423);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridDocumentos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(730, 403);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmListadoDocumentosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 566);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "frmListadoDocumentosBancarios";
            this.Ribbon = this.ribbonControl;
            this.Text = "frmListadoDocumentosBancarios";
            this.Load += new System.EventHandler(this.frmListadoDocumentosBancarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarButtonItem btnRefrescar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridDocumentos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem btnFiltro;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn CuentaBanco;
        private DevExpress.XtraGrid.Columns.GridColumn Tipo;
        private DevExpress.XtraGrid.Columns.GridColumn SubTipo;
        private DevExpress.XtraGrid.Columns.GridColumn Nombre;
        private DevExpress.XtraGrid.Columns.GridColumn Alias;
        private DevExpress.XtraGrid.Columns.GridColumn cPagaderoa;
        private DevExpress.XtraGrid.Columns.GridColumn Monto;
        private DevExpress.XtraGrid.Columns.GridColumn Usuario;
        private DevExpress.XtraGrid.Columns.GridColumn CReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn CConceptoContable;
    }
}