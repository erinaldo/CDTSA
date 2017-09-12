namespace CG
{
    partial class frmConsultaSaldoCentro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaSaldoCentro));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.bntMonedaDolar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonedaLoca = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtTotalDebitos = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalCredito = new DevExpress.XtraEditors.TextEdit();
            this.txtSaldoFinal = new DevExpress.XtraEditors.TextEdit();
            this.txtSaldoInicial = new DevExpress.XtraEditors.TextEdit();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SaldoInicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Debitos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Credito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SaldoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.dtpFechaInicial = new DevExpress.XtraEditors.DateEdit();
            this.slkupCuenta = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDebitos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCredito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnCancelar,
            this.lblStatus,
            this.btnExportar,
            this.btnRefrescar,
            this.bntMonedaDolar,
            this.btnMonedaLoca});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 6;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(741, 143);
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
            // bntMonedaDolar
            // 
            this.bntMonedaDolar.Caption = "Moneda Dolar";
            this.bntMonedaDolar.Glyph = ((System.Drawing.Image)(resources.GetObject("bntMonedaDolar.Glyph")));
            this.bntMonedaDolar.Id = 4;
            this.bntMonedaDolar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bntMonedaDolar.LargeGlyph")));
            this.bntMonedaDolar.Name = "bntMonedaDolar";
            this.bntMonedaDolar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bntMonedaDolar_ItemClick);
            // 
            // btnMonedaLoca
            // 
            this.btnMonedaLoca.Caption = "Moneda Local";
            this.btnMonedaLoca.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMonedaLoca.Glyph")));
            this.btnMonedaLoca.Id = 5;
            this.btnMonedaLoca.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMonedaLoca.LargeGlyph")));
            this.btnMonedaLoca.Name = "btnMonedaLoca";
            this.btnMonedaLoca.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonedaLoca_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Operaciones Consulta de Saldo Cuenta";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.bntMonedaDolar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMonedaLoca);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefrescar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtTotalDebitos);
            this.layoutControl1.Controls.Add(this.txtTotalCredito);
            this.layoutControl1.Controls.Add(this.txtSaldoFinal);
            this.layoutControl1.Controls.Add(this.txtSaldoInicial);
            this.layoutControl1.Controls.Add(this.grid);
            this.layoutControl1.Controls.Add(this.dtpFechaFinal);
            this.layoutControl1.Controls.Add(this.dtpFechaInicial);
            this.layoutControl1.Controls.Add(this.slkupCuenta);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(951, 182, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(741, 268);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtTotalDebitos
            // 
            this.txtTotalDebitos.Enabled = false;
            this.txtTotalDebitos.Location = new System.Drawing.Point(194, 76);
            this.txtTotalDebitos.MenuManager = this.ribbonControl;
            this.txtTotalDebitos.Name = "txtTotalDebitos";
            this.txtTotalDebitos.Size = new System.Drawing.Size(85, 20);
            this.txtTotalDebitos.StyleController = this.layoutControl1;
            this.txtTotalDebitos.TabIndex = 12;
            // 
            // txtTotalCredito
            // 
            this.txtTotalCredito.Enabled = false;
            this.txtTotalCredito.Location = new System.Drawing.Point(283, 76);
            this.txtTotalCredito.MenuManager = this.ribbonControl;
            this.txtTotalCredito.Name = "txtTotalCredito";
            this.txtTotalCredito.Size = new System.Drawing.Size(85, 20);
            this.txtTotalCredito.StyleController = this.layoutControl1;
            this.txtTotalCredito.TabIndex = 11;
            // 
            // txtSaldoFinal
            // 
            this.txtSaldoFinal.Enabled = false;
            this.txtSaldoFinal.Location = new System.Drawing.Point(372, 76);
            this.txtSaldoFinal.MenuManager = this.ribbonControl;
            this.txtSaldoFinal.Name = "txtSaldoFinal";
            this.txtSaldoFinal.Size = new System.Drawing.Size(108, 20);
            this.txtSaldoFinal.StyleController = this.layoutControl1;
            this.txtSaldoFinal.TabIndex = 10;
            // 
            // txtSaldoInicial
            // 
            this.txtSaldoInicial.EditValue = "";
            this.txtSaldoInicial.Enabled = false;
            this.txtSaldoInicial.Location = new System.Drawing.Point(103, 76);
            this.txtSaldoInicial.MenuManager = this.ribbonControl;
            this.txtSaldoInicial.Name = "txtSaldoInicial";
            this.txtSaldoInicial.Size = new System.Drawing.Size(87, 20);
            this.txtSaldoInicial.StyleController = this.layoutControl1;
            this.txtSaldoInicial.TabIndex = 9;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(12, 122);
            this.grid.MainView = this.gridView1;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(717, 134);
            this.grid.TabIndex = 8;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CentroCosto,
            this.Descr,
            this.SaldoInicial,
            this.Debitos,
            this.Credito,
            this.SaldoFinal});
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // CentroCosto
            // 
            this.CentroCosto.Caption = "Centro de Costo";
            this.CentroCosto.FieldName = "Centro";
            this.CentroCosto.Name = "CentroCosto";
            this.CentroCosto.OptionsColumn.AllowEdit = false;
            this.CentroCosto.OptionsColumn.AllowFocus = false;
            this.CentroCosto.OptionsColumn.ReadOnly = true;
            this.CentroCosto.Visible = true;
            this.CentroCosto.VisibleIndex = 0;
            // 
            // Descr
            // 
            this.Descr.Caption = "Descripción";
            this.Descr.FieldName = "DescrCentroCosto";
            this.Descr.Name = "Descr";
            this.Descr.OptionsColumn.AllowFocus = false;
            this.Descr.Visible = true;
            this.Descr.VisibleIndex = 1;
            // 
            // SaldoInicial
            // 
            this.SaldoInicial.Caption = "Saldo Inicial";
            this.SaldoInicial.Name = "SaldoInicial";
            this.SaldoInicial.OptionsColumn.AllowFocus = false;
            this.SaldoInicial.Visible = true;
            this.SaldoInicial.VisibleIndex = 2;
            // 
            // Debitos
            // 
            this.Debitos.Caption = "Débitos";
            this.Debitos.Name = "Debitos";
            this.Debitos.OptionsColumn.AllowFocus = false;
            this.Debitos.Visible = true;
            this.Debitos.VisibleIndex = 3;
            // 
            // Credito
            // 
            this.Credito.Caption = "Créditos";
            this.Credito.Name = "Credito";
            this.Credito.OptionsColumn.AllowFocus = false;
            this.Credito.Visible = true;
            this.Credito.VisibleIndex = 4;
            // 
            // SaldoFinal
            // 
            this.SaldoFinal.Caption = "Saldo Final";
            this.SaldoFinal.Name = "SaldoFinal";
            this.SaldoFinal.OptionsColumn.AllowFocus = false;
            this.SaldoFinal.Visible = true;
            this.SaldoFinal.VisibleIndex = 5;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.EditValue = null;
            this.dtpFechaFinal.Location = new System.Drawing.Point(460, 36);
            this.dtpFechaFinal.MenuManager = this.ribbonControl;
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaFinal.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtpFechaFinal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpFechaFinal.Size = new System.Drawing.Size(269, 20);
            this.dtpFechaFinal.StyleController = this.layoutControl1;
            this.dtpFechaFinal.TabIndex = 6;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.EditValue = null;
            this.dtpFechaInicial.Location = new System.Drawing.Point(100, 36);
            this.dtpFechaInicial.MenuManager = this.ribbonControl;
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaInicial.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtpFechaInicial.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpFechaInicial.Size = new System.Drawing.Size(268, 20);
            this.dtpFechaInicial.StyleController = this.layoutControl1;
            this.dtpFechaInicial.TabIndex = 5;
            // 
            // slkupCuenta
            // 
            this.slkupCuenta.Location = new System.Drawing.Point(100, 12);
            this.slkupCuenta.MenuManager = this.ribbonControl;
            this.slkupCuenta.Name = "slkupCuenta";
            this.slkupCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupCuenta.Properties.View = this.searchLookUpEdit1View;
            this.slkupCuenta.Size = new System.Drawing.Size(629, 20);
            this.slkupCuenta.StyleController = this.layoutControl1;
            this.slkupCuenta.TabIndex = 4;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(741, 268);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.slkupCuenta;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(721, 24);
            this.layoutControlItem1.Text = "Cuenta Contable:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtpFechaInicial;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(360, 24);
            this.layoutControlItem2.Text = "Periodo del:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grid;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 110);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(721, 138);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 88);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 22);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 22);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(721, 22);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtpFechaFinal;
            this.layoutControlItem3.Location = new System.Drawing.Point(360, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(361, 24);
            this.layoutControlItem3.Text = "Al:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtSaldoInicial;
            this.layoutControlItem6.Location = new System.Drawing.Point(91, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(91, 40);
            this.layoutControlItem6.Text = "Saldo Inicial:";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtSaldoFinal;
            this.layoutControlItem7.Location = new System.Drawing.Point(360, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(112, 40);
            this.layoutControlItem7.Text = "Saldo Final";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtTotalCredito;
            this.layoutControlItem4.Location = new System.Drawing.Point(271, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(89, 40);
            this.layoutControlItem4.Text = "Total Créditos";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtTotalDebitos;
            this.layoutControlItem8.Location = new System.Drawing.Point(182, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(89, 40);
            this.layoutControlItem8.Text = "Total Débitos";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(85, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(91, 40);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(472, 48);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(249, 40);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmConsultaSaldoCentro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 411);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaSaldoCentro";
            this.Ribbon = this.ribbonControl;
            this.Text = "Consulta Saldo Centro";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDebitos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCredito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarButtonItem btnRefrescar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit dtpFechaFinal;
        private DevExpress.XtraEditors.DateEdit dtpFechaInicial;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn Descr;
        private DevExpress.XtraGrid.Columns.GridColumn Debitos;
        private DevExpress.XtraEditors.TextEdit txtTotalDebitos;
        private DevExpress.XtraEditors.TextEdit txtTotalCredito;
        private DevExpress.XtraEditors.TextEdit txtSaldoFinal;
        private DevExpress.XtraEditors.TextEdit txtSaldoInicial;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn Credito;
        private DevExpress.XtraGrid.Columns.GridColumn SaldoFinal;
        private DevExpress.XtraBars.BarButtonItem bntMonedaDolar;
        private DevExpress.XtraBars.BarButtonItem btnMonedaLoca;
        private DevExpress.XtraGrid.Columns.GridColumn SaldoInicial;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}