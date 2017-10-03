namespace CG
{
    partial class frmAsiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsiento));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnMayorizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnCuadreTemporal = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btnColumnas = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowLessColumns = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDirenciaDolar = new DevExpress.XtraEditors.TextEdit();
            this.txtCreditoDolar = new DevExpress.XtraEditors.TextEdit();
            this.txtDebitoDolar = new DevExpress.XtraEditors.TextEdit();
            this.txtDiferencia = new DevExpress.XtraEditors.TextEdit();
            this.txtCreditoLocal = new DevExpress.XtraEditors.TextEdit();
            this.txtDebitoLocal = new DevExpress.XtraEditors.TextEdit();
            this.txtAnuladoPor = new DevExpress.XtraEditors.TextEdit();
            this.txtFechaMayorizado = new DevExpress.XtraEditors.TextEdit();
            this.txtFechaCreacion = new DevExpress.XtraEditors.TextEdit();
            this.txtAnuladorPor = new DevExpress.XtraEditors.TextEdit();
            this.txtMayorizadoPor = new DevExpress.XtraEditors.TextEdit();
            this.txtCreadoPor = new DevExpress.XtraEditors.TextEdit();
            this.txtTipoCambio = new DevExpress.XtraEditors.TextEdit();
            this.txtFecha = new DevExpress.XtraEditors.TextEdit();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Linea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkupCentroCostoGrid = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Centro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrCentro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CuentaContable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkupCuentaContableGrid = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescripcionCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrCuentaContable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Debito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDebitoGrid = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Creditos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtCreditoGrid = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Referencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtAsiento = new DevExpress.XtraEditors.TextEdit();
            this.txtEjercicio = new DevExpress.XtraEditors.TextEdit();
            this.txtConcepto = new System.Windows.Forms.RichTextBox();
            this.dtpFecha = new DevExpress.XtraEditors.DateEdit();
            this.txtEstado = new DevExpress.XtraEditors.TextEdit();
            this.slkupTipo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtModuloFuente = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.TabGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TabAuditoria = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lyTotalDebito = new DevExpress.XtraLayout.LayoutControlItem();
            this.lyTotalCredito = new DevExpress.XtraLayout.LayoutControlItem();
            this.lyDiferencia = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.imgCollection = new DevExpress.Utils.ImageCollection();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirenciaDolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoDolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoDolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnuladoPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaMayorizado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCreacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnuladorPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMayorizadoPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreadoPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCostoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCuentaContableGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEjercicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModuloFuente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabAuditoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyTotalDebito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyTotalCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyDiferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnEditar,
            this.btnGuardar,
            this.btnCancelar,
            this.btnEliminar,
            this.lblStatus,
            this.btnMayorizar,
            this.btnAnular,
            this.btnCuadreTemporal,
            this.btnImprimir,
            this.btnColumnas,
            this.btnShowLessColumns});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 10;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(852, 143);
            // 
            // btnEditar
            // 
            this.btnEditar.Caption = "Editar";
            this.btnEditar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.Glyph")));
            this.btnEditar.Id = 2;
            this.btnEditar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.LargeGlyph")));
            this.btnEditar.Name = "btnEditar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Glyph")));
            this.btnGuardar.Id = 3;
            this.btnGuardar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGuardar.LargeGlyph")));
            this.btnGuardar.Name = "btnGuardar";
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
            // lblStatus
            // 
            this.lblStatus.Id = 1;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnMayorizar
            // 
            this.btnMayorizar.Caption = "Mayorizar";
            this.btnMayorizar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMayorizar.Glyph")));
            this.btnMayorizar.Id = 2;
            this.btnMayorizar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMayorizar.LargeGlyph")));
            this.btnMayorizar.Name = "btnMayorizar";
            this.btnMayorizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMayorizar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAnular.Glyph")));
            this.btnAnular.Id = 3;
            this.btnAnular.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnular.LargeGlyph")));
            this.btnAnular.Name = "btnAnular";
            // 
            // btnCuadreTemporal
            // 
            this.btnCuadreTemporal.Caption = "Cuadre Temporal";
            this.btnCuadreTemporal.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCuadreTemporal.Glyph")));
            this.btnCuadreTemporal.Id = 4;
            this.btnCuadreTemporal.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCuadreTemporal.LargeGlyph")));
            this.btnCuadreTemporal.Name = "btnCuadreTemporal";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Glyph")));
            this.btnImprimir.Id = 5;
            this.btnImprimir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImprimir.LargeGlyph")));
            this.btnImprimir.Name = "btnImprimir";
            // 
            // btnColumnas
            // 
            this.btnColumnas.Caption = "Columnas";
            this.btnColumnas.Glyph = ((System.Drawing.Image)(resources.GetObject("btnColumnas.Glyph")));
            this.btnColumnas.Id = 6;
            this.btnColumnas.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnColumnas.LargeGlyph")));
            this.btnColumnas.Name = "btnColumnas";
            // 
            // btnShowLessColumns
            // 
            this.btnShowLessColumns.Caption = "Ocultar Detalle";
            this.btnShowLessColumns.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShowLessColumns.Glyph")));
            this.btnShowLessColumns.Id = 9;
            this.btnShowLessColumns.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShowLessColumns.LargeGlyph")));
            this.btnShowLessColumns.Name = "btnShowLessColumns";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Operaciones Asiento Contable";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEditar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGuardar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMayorizar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAnular);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCuadreTemporal);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnImprimir);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnColumnas);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnShowLessColumns);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDirenciaDolar);
            this.layoutControl1.Controls.Add(this.txtCreditoDolar);
            this.layoutControl1.Controls.Add(this.txtDebitoDolar);
            this.layoutControl1.Controls.Add(this.txtDiferencia);
            this.layoutControl1.Controls.Add(this.txtCreditoLocal);
            this.layoutControl1.Controls.Add(this.txtDebitoLocal);
            this.layoutControl1.Controls.Add(this.txtAnuladoPor);
            this.layoutControl1.Controls.Add(this.txtFechaMayorizado);
            this.layoutControl1.Controls.Add(this.txtFechaCreacion);
            this.layoutControl1.Controls.Add(this.txtAnuladorPor);
            this.layoutControl1.Controls.Add(this.txtMayorizadoPor);
            this.layoutControl1.Controls.Add(this.txtCreadoPor);
            this.layoutControl1.Controls.Add(this.txtTipoCambio);
            this.layoutControl1.Controls.Add(this.txtFecha);
            this.layoutControl1.Controls.Add(this.grid);
            this.layoutControl1.Controls.Add(this.txtAsiento);
            this.layoutControl1.Controls.Add(this.txtEjercicio);
            this.layoutControl1.Controls.Add(this.txtConcepto);
            this.layoutControl1.Controls.Add(this.dtpFecha);
            this.layoutControl1.Controls.Add(this.txtEstado);
            this.layoutControl1.Controls.Add(this.slkupTipo);
            this.layoutControl1.Controls.Add(this.txtModuloFuente);
            this.layoutControl1.Controls.Add(this.txtPeriodo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1009, 396, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(852, 514);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDirenciaDolar
            // 
            this.txtDirenciaDolar.Location = new System.Drawing.Point(468, 465);
            this.txtDirenciaDolar.MenuManager = this.ribbonControl;
            this.txtDirenciaDolar.Name = "txtDirenciaDolar";
            this.txtDirenciaDolar.Properties.Mask.EditMask = "n4";
            this.txtDirenciaDolar.Properties.ReadOnly = true;
            this.txtDirenciaDolar.Size = new System.Drawing.Size(194, 20);
            this.txtDirenciaDolar.StyleController = this.layoutControl1;
            this.txtDirenciaDolar.TabIndex = 28;
            // 
            // txtCreditoDolar
            // 
            this.txtCreditoDolar.Location = new System.Drawing.Point(276, 465);
            this.txtCreditoDolar.MenuManager = this.ribbonControl;
            this.txtCreditoDolar.Name = "txtCreditoDolar";
            this.txtCreditoDolar.Properties.Mask.EditMask = "n4";
            this.txtCreditoDolar.Properties.ReadOnly = true;
            this.txtCreditoDolar.Size = new System.Drawing.Size(178, 20);
            this.txtCreditoDolar.StyleController = this.layoutControl1;
            this.txtCreditoDolar.TabIndex = 27;
            // 
            // txtDebitoDolar
            // 
            this.txtDebitoDolar.Location = new System.Drawing.Point(92, 465);
            this.txtDebitoDolar.MenuManager = this.ribbonControl;
            this.txtDebitoDolar.Name = "txtDebitoDolar";
            this.txtDebitoDolar.Properties.Mask.EditMask = "n4";
            this.txtDebitoDolar.Properties.ReadOnly = true;
            this.txtDebitoDolar.Size = new System.Drawing.Size(170, 20);
            this.txtDebitoDolar.StyleController = this.layoutControl1;
            this.txtDebitoDolar.TabIndex = 26;
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.Location = new System.Drawing.Point(468, 441);
            this.txtDiferencia.MenuManager = this.ribbonControl;
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.Properties.Mask.EditMask = "n4";
            this.txtDiferencia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiferencia.Properties.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(194, 20);
            this.txtDiferencia.StyleController = this.layoutControl1;
            this.txtDiferencia.TabIndex = 25;
            // 
            // txtCreditoLocal
            // 
            this.txtCreditoLocal.Location = new System.Drawing.Point(276, 441);
            this.txtCreditoLocal.MenuManager = this.ribbonControl;
            this.txtCreditoLocal.Name = "txtCreditoLocal";
            this.txtCreditoLocal.Properties.Mask.EditMask = "n4";
            this.txtCreditoLocal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCreditoLocal.Properties.ReadOnly = true;
            this.txtCreditoLocal.Size = new System.Drawing.Size(178, 20);
            this.txtCreditoLocal.StyleController = this.layoutControl1;
            this.txtCreditoLocal.TabIndex = 24;
            // 
            // txtDebitoLocal
            // 
            this.txtDebitoLocal.Location = new System.Drawing.Point(92, 441);
            this.txtDebitoLocal.MenuManager = this.ribbonControl;
            this.txtDebitoLocal.Name = "txtDebitoLocal";
            this.txtDebitoLocal.Properties.Mask.EditMask = "n4";
            this.txtDebitoLocal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDebitoLocal.Properties.ReadOnly = true;
            this.txtDebitoLocal.Size = new System.Drawing.Size(170, 20);
            this.txtDebitoLocal.StyleController = this.layoutControl1;
            this.txtDebitoLocal.TabIndex = 23;
            // 
            // txtAnuladoPor
            // 
            this.txtAnuladoPor.Location = new System.Drawing.Point(415, 132);
            this.txtAnuladoPor.MenuManager = this.ribbonControl;
            this.txtAnuladoPor.Name = "txtAnuladoPor";
            this.txtAnuladoPor.Properties.ReadOnly = true;
            this.txtAnuladoPor.Size = new System.Drawing.Size(403, 20);
            this.txtAnuladoPor.StyleController = this.layoutControl1;
            this.txtAnuladoPor.TabIndex = 22;
            // 
            // txtFechaMayorizado
            // 
            this.txtFechaMayorizado.Location = new System.Drawing.Point(415, 108);
            this.txtFechaMayorizado.MenuManager = this.ribbonControl;
            this.txtFechaMayorizado.Name = "txtFechaMayorizado";
            this.txtFechaMayorizado.Properties.ReadOnly = true;
            this.txtFechaMayorizado.Size = new System.Drawing.Size(403, 20);
            this.txtFechaMayorizado.StyleController = this.layoutControl1;
            this.txtFechaMayorizado.TabIndex = 21;
            // 
            // txtFechaCreacion
            // 
            this.txtFechaCreacion.Location = new System.Drawing.Point(415, 84);
            this.txtFechaCreacion.MenuManager = this.ribbonControl;
            this.txtFechaCreacion.Name = "txtFechaCreacion";
            this.txtFechaCreacion.Properties.ReadOnly = true;
            this.txtFechaCreacion.Size = new System.Drawing.Size(403, 20);
            this.txtFechaCreacion.StyleController = this.layoutControl1;
            this.txtFechaCreacion.TabIndex = 20;
            // 
            // txtAnuladorPor
            // 
            this.txtAnuladorPor.Location = new System.Drawing.Point(106, 132);
            this.txtAnuladorPor.MenuManager = this.ribbonControl;
            this.txtAnuladorPor.Name = "txtAnuladorPor";
            this.txtAnuladorPor.Properties.ReadOnly = true;
            this.txtAnuladorPor.Size = new System.Drawing.Size(274, 20);
            this.txtAnuladorPor.StyleController = this.layoutControl1;
            this.txtAnuladorPor.TabIndex = 19;
            // 
            // txtMayorizadoPor
            // 
            this.txtMayorizadoPor.Location = new System.Drawing.Point(106, 108);
            this.txtMayorizadoPor.MenuManager = this.ribbonControl;
            this.txtMayorizadoPor.Name = "txtMayorizadoPor";
            this.txtMayorizadoPor.Properties.ReadOnly = true;
            this.txtMayorizadoPor.Size = new System.Drawing.Size(274, 20);
            this.txtMayorizadoPor.StyleController = this.layoutControl1;
            this.txtMayorizadoPor.TabIndex = 18;
            // 
            // txtCreadoPor
            // 
            this.txtCreadoPor.Location = new System.Drawing.Point(106, 84);
            this.txtCreadoPor.MenuManager = this.ribbonControl;
            this.txtCreadoPor.Name = "txtCreadoPor";
            this.txtCreadoPor.Properties.ReadOnly = true;
            this.txtCreadoPor.Size = new System.Drawing.Size(274, 20);
            this.txtCreadoPor.StyleController = this.layoutControl1;
            this.txtCreadoPor.TabIndex = 17;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(510, 70);
            this.txtTipoCambio.MenuManager = this.ribbonControl;
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtTipoCambio.Size = new System.Drawing.Size(318, 18);
            this.txtTipoCambio.StyleController = this.layoutControl1;
            this.txtTipoCambio.TabIndex = 16;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(106, 70);
            this.txtFecha.MenuManager = this.ribbonControl;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFecha.Size = new System.Drawing.Size(318, 18);
            this.txtFecha.StyleController = this.layoutControl1;
            this.txtFecha.TabIndex = 15;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(12, 229);
            this.grid.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grid.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grid.MainView = this.gridView1;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.slkupCentroCostoGrid,
            this.slkupCuentaContableGrid,
            this.txtDebitoGrid,
            this.txtCreditoGrid});
            this.grid.Size = new System.Drawing.Size(828, 175);
            this.grid.TabIndex = 14;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid.FocusedViewChanged += new DevExpress.XtraGrid.ViewFocusEventHandler(this.grid_FocusedViewChanged);
            this.grid.Leave += new System.EventHandler(this.grid_Leave);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.TopNewRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Linea,
            this.CentroCosto,
            this.DescrCentro,
            this.CuentaContable,
            this.DescrCuentaContable,
            this.Debito,
            this.Creditos,
            this.Documento,
            this.Referencia});
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView1.OptionsEditForm.FormCaptionFormat = "Línea de Asiento";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // Linea
            // 
            this.Linea.Caption = "Linea";
            this.Linea.FieldName = "Linea";
            this.Linea.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Linea.MaxWidth = 40;
            this.Linea.MinWidth = 40;
            this.Linea.Name = "Linea";
            this.Linea.OptionsColumn.AllowEdit = false;
            this.Linea.OptionsColumn.AllowMove = false;
            this.Linea.OptionsColumn.FixedWidth = true;
            this.Linea.Visible = true;
            this.Linea.VisibleIndex = 0;
            this.Linea.Width = 40;
            // 
            // CentroCosto
            // 
            this.CentroCosto.Caption = "Centro Costo";
            this.CentroCosto.ColumnEdit = this.slkupCentroCostoGrid;
            this.CentroCosto.FieldName = "IDCentro";
            this.CentroCosto.MaxWidth = 96;
            this.CentroCosto.MinWidth = 96;
            this.CentroCosto.Name = "CentroCosto";
            this.CentroCosto.OptionsColumn.AllowMove = false;
            this.CentroCosto.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.True;
            this.CentroCosto.OptionsEditForm.StartNewRow = true;
            this.CentroCosto.OptionsEditForm.VisibleIndex = 1;
            this.CentroCosto.Visible = true;
            this.CentroCosto.VisibleIndex = 1;
            this.CentroCosto.Width = 96;
            // 
            // slkupCentroCostoGrid
            // 
            this.slkupCentroCostoGrid.AutoHeight = false;
            this.slkupCentroCostoGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupCentroCostoGrid.Name = "slkupCentroCostoGrid";
            this.slkupCentroCostoGrid.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Centro,
            this.Descripcion});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Centro
            // 
            this.Centro.Caption = "Centro";
            this.Centro.FieldName = "Centro";
            this.Centro.Name = "Centro";
            this.Centro.Visible = true;
            this.Centro.VisibleIndex = 0;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripción";
            this.Descripcion.FieldName = "Descr";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 1;
            // 
            // DescrCentro
            // 
            this.DescrCentro.Caption = "Descr CentroCosto";
            this.DescrCentro.FieldName = "DescrCentro";
            this.DescrCentro.MinWidth = 100;
            this.DescrCentro.Name = "DescrCentro";
            this.DescrCentro.OptionsColumn.AllowEdit = false;
            this.DescrCentro.OptionsColumn.AllowFocus = false;
            this.DescrCentro.OptionsColumn.AllowMove = false;
            this.DescrCentro.OptionsColumn.ReadOnly = true;
            this.DescrCentro.OptionsEditForm.VisibleIndex = 2;
            this.DescrCentro.Visible = true;
            this.DescrCentro.VisibleIndex = 2;
            this.DescrCentro.Width = 120;
            // 
            // CuentaContable
            // 
            this.CuentaContable.Caption = "Cuenta Contable";
            this.CuentaContable.ColumnEdit = this.slkupCuentaContableGrid;
            this.CuentaContable.FieldName = "IDCuenta";
            this.CuentaContable.MaxWidth = 128;
            this.CuentaContable.MinWidth = 128;
            this.CuentaContable.Name = "CuentaContable";
            this.CuentaContable.OptionsColumn.AllowMove = false;
            this.CuentaContable.OptionsEditForm.StartNewRow = true;
            this.CuentaContable.OptionsEditForm.VisibleIndex = 3;
            this.CuentaContable.Visible = true;
            this.CuentaContable.VisibleIndex = 3;
            this.CuentaContable.Width = 128;
            // 
            // slkupCuentaContableGrid
            // 
            this.slkupCuentaContableGrid.AutoHeight = false;
            this.slkupCuentaContableGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupCuentaContableGrid.Name = "slkupCuentaContableGrid";
            this.slkupCuentaContableGrid.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cuenta,
            this.DescripcionCuenta});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // Cuenta
            // 
            this.Cuenta.Caption = "Cuenta";
            this.Cuenta.FieldName = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.Visible = true;
            this.Cuenta.VisibleIndex = 0;
            // 
            // DescripcionCuenta
            // 
            this.DescripcionCuenta.Caption = "Descripción";
            this.DescripcionCuenta.FieldName = "Descr";
            this.DescripcionCuenta.Name = "DescripcionCuenta";
            this.DescripcionCuenta.Visible = true;
            this.DescripcionCuenta.VisibleIndex = 1;
            // 
            // DescrCuentaContable
            // 
            this.DescrCuentaContable.Caption = "Descr Cuenta Contable";
            this.DescrCuentaContable.FieldName = "DescrCuenta";
            this.DescrCuentaContable.MinWidth = 100;
            this.DescrCuentaContable.Name = "DescrCuentaContable";
            this.DescrCuentaContable.OptionsColumn.AllowEdit = false;
            this.DescrCuentaContable.OptionsColumn.AllowFocus = false;
            this.DescrCuentaContable.OptionsColumn.AllowMove = false;
            this.DescrCuentaContable.OptionsColumn.ReadOnly = true;
            this.DescrCuentaContable.OptionsEditForm.VisibleIndex = 4;
            this.DescrCuentaContable.Visible = true;
            this.DescrCuentaContable.VisibleIndex = 4;
            this.DescrCuentaContable.Width = 145;
            // 
            // Debito
            // 
            this.Debito.Caption = "Débito";
            this.Debito.ColumnEdit = this.txtDebitoGrid;
            this.Debito.DisplayFormat.FormatString = "C2";
            this.Debito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Debito.FieldName = "Debito";
            this.Debito.MinWidth = 93;
            this.Debito.Name = "Debito";
            this.Debito.OptionsColumn.AllowMove = false;
            this.Debito.OptionsEditForm.StartNewRow = true;
            this.Debito.OptionsEditForm.VisibleIndex = 5;
            this.Debito.Visible = true;
            this.Debito.VisibleIndex = 5;
            this.Debito.Width = 93;
            // 
            // txtDebitoGrid
            // 
            this.txtDebitoGrid.AutoHeight = false;
            this.txtDebitoGrid.Name = "txtDebitoGrid";
            // 
            // Creditos
            // 
            this.Creditos.Caption = "Créditos";
            this.Creditos.ColumnEdit = this.txtCreditoGrid;
            this.Creditos.DisplayFormat.FormatString = "C2";
            this.Creditos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Creditos.FieldName = "Credito";
            this.Creditos.MinWidth = 93;
            this.Creditos.Name = "Creditos";
            this.Creditos.OptionsColumn.AllowMove = false;
            this.Creditos.OptionsEditForm.VisibleIndex = 6;
            this.Creditos.Visible = true;
            this.Creditos.VisibleIndex = 6;
            this.Creditos.Width = 95;
            // 
            // txtCreditoGrid
            // 
            this.txtCreditoGrid.AutoHeight = false;
            this.txtCreditoGrid.Name = "txtCreditoGrid";
            // 
            // Documento
            // 
            this.Documento.Caption = "Documento";
            this.Documento.FieldName = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.OptionsColumn.AllowMove = false;
            this.Documento.OptionsEditForm.StartNewRow = true;
            this.Documento.OptionsEditForm.VisibleIndex = 7;
            this.Documento.Visible = true;
            this.Documento.VisibleIndex = 7;
            this.Documento.Width = 114;
            // 
            // Referencia
            // 
            this.Referencia.Caption = "Referencia";
            this.Referencia.FieldName = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.OptionsColumn.AllowMove = false;
            this.Referencia.OptionsEditForm.VisibleIndex = 8;
            this.Referencia.Visible = true;
            this.Referencia.VisibleIndex = 8;
            this.Referencia.Width = 178;
            // 
            // txtAsiento
            // 
            this.txtAsiento.Location = new System.Drawing.Point(106, 46);
            this.txtAsiento.MenuManager = this.ribbonControl;
            this.txtAsiento.Name = "txtAsiento";
            this.txtAsiento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAsiento.Properties.Appearance.Options.UseFont = true;
            this.txtAsiento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtAsiento.Size = new System.Drawing.Size(318, 18);
            this.txtAsiento.StyleController = this.layoutControl1;
            this.txtAsiento.TabIndex = 13;
            // 
            // txtEjercicio
            // 
            this.txtEjercicio.Location = new System.Drawing.Point(106, 94);
            this.txtEjercicio.MenuManager = this.ribbonControl;
            this.txtEjercicio.Name = "txtEjercicio";
            this.txtEjercicio.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtEjercicio.Size = new System.Drawing.Size(318, 18);
            this.txtEjercicio.StyleController = this.layoutControl1;
            this.txtEjercicio.TabIndex = 12;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(106, 166);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(722, 47);
            this.txtConcepto.TabIndex = 9;
            this.txtConcepto.Text = "";
            // 
            // dtpFecha
            // 
            this.dtpFecha.EditValue = null;
            this.dtpFecha.Location = new System.Drawing.Point(510, 118);
            this.dtpFecha.MenuManager = this.ribbonControl;
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFecha.Size = new System.Drawing.Size(318, 20);
            this.dtpFecha.StyleController = this.layoutControl1;
            this.dtpFecha.TabIndex = 8;
            this.dtpFecha.EditValueChanged += new System.EventHandler(this.dtpFecha_EditValueChanged);
            this.dtpFecha.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFecha_Validating);
            this.dtpFecha.Validated += new System.EventHandler(this.dtpFecha_Validated);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(510, 46);
            this.txtEstado.MenuManager = this.ribbonControl;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtEstado.Size = new System.Drawing.Size(318, 18);
            this.txtEstado.StyleController = this.layoutControl1;
            this.txtEstado.TabIndex = 7;
            // 
            // slkupTipo
            // 
            this.slkupTipo.Location = new System.Drawing.Point(106, 142);
            this.slkupTipo.MenuManager = this.ribbonControl;
            this.slkupTipo.Name = "slkupTipo";
            this.slkupTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupTipo.Properties.View = this.searchLookUpEdit1View;
            this.slkupTipo.Size = new System.Drawing.Size(722, 20);
            this.slkupTipo.StyleController = this.layoutControl1;
            this.slkupTipo.TabIndex = 6;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtModuloFuente
            // 
            this.txtModuloFuente.Location = new System.Drawing.Point(106, 118);
            this.txtModuloFuente.MenuManager = this.ribbonControl;
            this.txtModuloFuente.Name = "txtModuloFuente";
            this.txtModuloFuente.Properties.ReadOnly = true;
            this.txtModuloFuente.Size = new System.Drawing.Size(318, 20);
            this.txtModuloFuente.StyleController = this.layoutControl1;
            this.txtModuloFuente.TabIndex = 5;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(510, 94);
            this.txtPeriodo.MenuManager = this.ribbonControl;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPeriodo.Size = new System.Drawing.Size(318, 18);
            this.txtPeriodo.StyleController = this.layoutControl1;
            this.txtPeriodo.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1,
            this.layoutControlItem11,
            this.lyTotalDebito,
            this.lyTotalCredito,
            this.lyDiferencia,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem7,
            this.emptySpaceItem8,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem23,
            this.emptySpaceItem9,
            this.emptySpaceItem10,
            this.emptySpaceItem11});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(852, 514);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.TabGeneral;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(832, 217);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.TabGeneral,
            this.TabAuditoria});
            // 
            // TabGeneral
            // 
            this.TabGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.layoutControlItem7,
            this.layoutControlItem10,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.TabGeneral.Location = new System.Drawing.Point(0, 0);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(808, 171);
            this.TabGeneral.Text = "General";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtEjercicio;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(133, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Ejercicio:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtModuloFuente;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(133, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Modulo Fuente:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtConcepto;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 51);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(103, 51);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(808, 51);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "Concepto:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPeriodo;
            this.layoutControlItem5.Location = new System.Drawing.Point(404, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem5.Text = "Periodo";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.dtpFecha;
            this.layoutControlItem8.Location = new System.Drawing.Point(404, 72);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem8.Text = "Fecha:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtEstado;
            this.layoutControlItem7.Location = new System.Drawing.Point(404, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem7.Text = "Estado:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.slkupTipo;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(133, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(808, 24);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "Tipo:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtFecha;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(133, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Fecha:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtAsiento;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(133, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Asiento:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTipoCambio;
            this.layoutControlItem2.Location = new System.Drawing.Point(404, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(404, 24);
            this.layoutControlItem2.Text = "Tipo Cambio:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(79, 13);
            // 
            // TabAuditoria
            // 
            this.TabAuditoria.CustomizationFormText = "Auditoria";
            this.TabAuditoria.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.emptySpaceItem1,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4});
            this.TabAuditoria.Location = new System.Drawing.Point(0, 0);
            this.TabAuditoria.Name = "TabAuditoria";
            this.TabAuditoria.Size = new System.Drawing.Size(808, 171);
            this.TabAuditoria.Text = "Auditoría";
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtCreadoPor;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(360, 24);
            this.layoutControlItem12.Text = "Creado por:";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtMayorizadoPor;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 62);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(360, 24);
            this.layoutControlItem13.Text = "Mayorizado por:";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtAnuladorPor;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 86);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(360, 24);
            this.layoutControlItem14.Text = "Anulado por:";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(79, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 110);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(798, 61);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtFechaCreacion;
            this.layoutControlItem15.Location = new System.Drawing.Point(391, 38);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(407, 24);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtFechaMayorizado;
            this.layoutControlItem16.Location = new System.Drawing.Point(391, 62);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(407, 24);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txtAnuladoPor;
            this.layoutControlItem17.Location = new System.Drawing.Point(391, 86);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(407, 24);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(360, 38);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(31, 72);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(798, 38);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(798, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 171);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.grid;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 217);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(832, 179);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // lyTotalDebito
            // 
            this.lyTotalDebito.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lyTotalDebito.AppearanceItemCaption.Options.UseFont = true;
            this.lyTotalDebito.Control = this.txtDebitoLocal;
            this.lyTotalDebito.Location = new System.Drawing.Point(80, 413);
            this.lyTotalDebito.Name = "lyTotalDebito";
            this.lyTotalDebito.Size = new System.Drawing.Size(174, 40);
            this.lyTotalDebito.Text = "Total Débitos";
            this.lyTotalDebito.TextLocation = DevExpress.Utils.Locations.Top;
            this.lyTotalDebito.TextSize = new System.Drawing.Size(79, 13);
            // 
            // lyTotalCredito
            // 
            this.lyTotalCredito.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lyTotalCredito.AppearanceItemCaption.Options.UseFont = true;
            this.lyTotalCredito.Control = this.txtCreditoLocal;
            this.lyTotalCredito.Location = new System.Drawing.Point(264, 413);
            this.lyTotalCredito.Name = "lyTotalCredito";
            this.lyTotalCredito.Size = new System.Drawing.Size(182, 40);
            this.lyTotalCredito.Text = "Total Créditos";
            this.lyTotalCredito.TextLocation = DevExpress.Utils.Locations.Top;
            this.lyTotalCredito.TextSize = new System.Drawing.Size(79, 13);
            // 
            // lyDiferencia
            // 
            this.lyDiferencia.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lyDiferencia.AppearanceItemCaption.Options.UseFont = true;
            this.lyDiferencia.Control = this.txtDiferencia;
            this.lyDiferencia.Location = new System.Drawing.Point(456, 413);
            this.lyDiferencia.Name = "lyDiferencia";
            this.lyDiferencia.Size = new System.Drawing.Size(198, 40);
            this.lyDiferencia.Text = "Diferencia:";
            this.lyDiferencia.TextLocation = DevExpress.Utils.Locations.Top;
            this.lyDiferencia.TextSize = new System.Drawing.Size(79, 13);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 396);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(0, 17);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(10, 17);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(832, 17);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 413);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(80, 24);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(80, 24);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(80, 24);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(654, 413);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(178, 64);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(0, 477);
            this.emptySpaceItem8.MaxSize = new System.Drawing.Size(0, 17);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(10, 17);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(832, 17);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtDebitoDolar;
            this.layoutControlItem21.Location = new System.Drawing.Point(80, 453);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(174, 24);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txtCreditoDolar;
            this.layoutControlItem22.Location = new System.Drawing.Point(264, 453);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.txtDirenciaDolar;
            this.layoutControlItem23.Location = new System.Drawing.Point(456, 453);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(198, 24);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(0, 437);
            this.emptySpaceItem9.MaxSize = new System.Drawing.Size(80, 24);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(80, 24);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(80, 40);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(254, 413);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(10, 64);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(446, 413);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(10, 64);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // imgCollection
            // 
            this.imgCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imgCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCollection.ImageStream")));
            this.imgCollection.InsertGalleryImage("showdetail_32x32.png", "images/spreadsheet/showdetail_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/showdetail_32x32.png"), 0);
            this.imgCollection.Images.SetKeyName(0, "showdetail_32x32.png");
            this.imgCollection.InsertGalleryImage("hidedetail_32x32.png", "images/spreadsheet/hidedetail_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/hidedetail_32x32.png"), 1);
            this.imgCollection.Images.SetKeyName(1, "hidedetail_32x32.png");
            // 
            // frmAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 657);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAsiento";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asiento Contable";
            this.Load += new System.EventHandler(this.frmAsiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDirenciaDolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoDolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoDolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnuladoPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaMayorizado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCreacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnuladorPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMayorizadoPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreadoPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCostoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCuentaContableGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEjercicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModuloFuente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabAuditoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyTotalDebito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyTotalCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyDiferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtAsiento;
        private DevExpress.XtraEditors.TextEdit txtEjercicio;
        private System.Windows.Forms.RichTextBox txtConcepto;
        private DevExpress.XtraEditors.DateEdit dtpFecha;
        private DevExpress.XtraEditors.TextEdit txtEstado;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupTipo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtModuloFuente;
        private DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup TabGeneral;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.TextEdit txtTipoCambio;
        private DevExpress.XtraEditors.TextEdit txtFecha;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup TabAuditoria;
        private DevExpress.XtraEditors.TextEdit txtCreadoPor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.TextEdit txtAnuladoPor;
        private DevExpress.XtraEditors.TextEdit txtFechaMayorizado;
        private DevExpress.XtraEditors.TextEdit txtFechaCreacion;
        private DevExpress.XtraEditors.TextEdit txtAnuladorPor;
        private DevExpress.XtraEditors.TextEdit txtMayorizadoPor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraBars.BarButtonItem btnMayorizar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarButtonItem btnCuadreTemporal;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn Linea;
        private DevExpress.XtraGrid.Columns.GridColumn CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn CuentaContable;
        private DevExpress.XtraGrid.Columns.GridColumn Debito;
        private DevExpress.XtraGrid.Columns.GridColumn Creditos;
        private DevExpress.XtraGrid.Columns.GridColumn Documento;
        private DevExpress.XtraGrid.Columns.GridColumn Referencia;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slkupCentroCostoGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slkupCuentaContableGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn Centro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Cuenta;
        private DevExpress.XtraGrid.Columns.GridColumn DescripcionCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn DescrCentro;
        private DevExpress.XtraGrid.Columns.GridColumn DescrCuentaContable;
        private DevExpress.XtraEditors.TextEdit txtDiferencia;
        private DevExpress.XtraEditors.TextEdit txtCreditoLocal;
        private DevExpress.XtraEditors.TextEdit txtDebitoLocal;
        private DevExpress.XtraLayout.LayoutControlItem lyTotalDebito;
        private DevExpress.XtraLayout.LayoutControlItem lyTotalCredito;
        private DevExpress.XtraLayout.LayoutControlItem lyDiferencia;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraEditors.TextEdit txtDirenciaDolar;
        private DevExpress.XtraEditors.TextEdit txtCreditoDolar;
        private DevExpress.XtraEditors.TextEdit txtDebitoDolar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraBars.BarButtonItem btnColumnas;
        private DevExpress.Utils.ImageCollection imgCollection;

        private DevExpress.XtraBars.BarButtonItem btnShowLessColumns;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtDebitoGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtCreditoGrid;
    }
}