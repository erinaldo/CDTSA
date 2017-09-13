namespace CG
{
    partial class frmConsultaSaldoCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaSaldoCuenta));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SaldoInicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Debitos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Creditos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SaldoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtHasta = new DevExpress.XtraEditors.DateEdit();
            this.dtDesde = new DevExpress.XtraEditors.DateEdit();
            this.slkupCentroCosto = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSaldoInicial = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalDebitos = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalCredito = new DevExpress.XtraEditors.TextEdit();
            this.txtSaldoFinal = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonedaDolar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonedaLocal = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.DescrCentro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDebitos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCredito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grid);
            this.layoutControl1.Controls.Add(this.dtHasta);
            this.layoutControl1.Controls.Add(this.dtDesde);
            this.layoutControl1.Controls.Add(this.slkupCentroCosto);
            this.layoutControl1.Controls.Add(this.txtSaldoInicial);
            this.layoutControl1.Controls.Add(this.txtTotalDebitos);
            this.layoutControl1.Controls.Add(this.txtTotalCredito);
            this.layoutControl1.Controls.Add(this.txtSaldoFinal);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(576, 208, 387, 405);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(864, 277);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(12, 119);
            this.grid.MainView = this.gridView1;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(840, 146);
            this.grid.TabIndex = 8;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CentroCosto,
            this.DescrCentro,
            this.Cuenta,
            this.Descripcion,
            this.SaldoInicial,
            this.Debitos,
            this.Creditos,
            this.SaldoFinal});
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cuenta, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // Cuenta
            // 
            this.Cuenta.Caption = "Cuenta";
            this.Cuenta.FieldName = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.OptionsColumn.AllowFocus = false;
            this.Cuenta.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.Cuenta.Visible = true;
            this.Cuenta.VisibleIndex = 2;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "DescrCuenta";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.OptionsColumn.AllowFocus = false;
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 3;
            // 
            // SaldoInicial
            // 
            this.SaldoInicial.Caption = "Saldo Inicial";
            this.SaldoInicial.FieldName = "SaldoAnterior";
            this.SaldoInicial.Name = "SaldoInicial";
            this.SaldoInicial.OptionsColumn.AllowFocus = false;
            this.SaldoInicial.Visible = true;
            this.SaldoInicial.VisibleIndex = 4;
            // 
            // Debitos
            // 
            this.Debitos.Caption = "Débitos";
            this.Debitos.FieldName = "Debito";
            this.Debitos.Name = "Debitos";
            this.Debitos.OptionsColumn.AllowFocus = false;
            this.Debitos.Visible = true;
            this.Debitos.VisibleIndex = 5;
            // 
            // Creditos
            // 
            this.Creditos.Caption = "Créditos";
            this.Creditos.FieldName = "Credito";
            this.Creditos.Name = "Creditos";
            this.Creditos.OptionsColumn.AllowFocus = false;
            this.Creditos.Visible = true;
            this.Creditos.VisibleIndex = 6;
            // 
            // SaldoFinal
            // 
            this.SaldoFinal.Caption = "Saldo Final";
            this.SaldoFinal.FieldName = "Saldo";
            this.SaldoFinal.Name = "SaldoFinal";
            this.SaldoFinal.OptionsColumn.AllowFocus = false;
            this.SaldoFinal.Visible = true;
            this.SaldoFinal.VisibleIndex = 7;
            // 
            // dtHasta
            // 
            this.dtHasta.EditValue = null;
            this.dtHasta.Location = new System.Drawing.Point(336, 36);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtHasta.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtHasta.Size = new System.Drawing.Size(196, 20);
            this.dtHasta.StyleController = this.layoutControl1;
            this.dtHasta.TabIndex = 6;
            // 
            // dtDesde
            // 
            this.dtDesde.EditValue = null;
            this.dtDesde.Location = new System.Drawing.Point(82, 36);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDesde.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtDesde.Size = new System.Drawing.Size(180, 20);
            this.dtDesde.StyleController = this.layoutControl1;
            this.dtDesde.TabIndex = 5;
            // 
            // slkupCentroCosto
            // 
            this.slkupCentroCosto.Location = new System.Drawing.Point(82, 12);
            this.slkupCentroCosto.Name = "slkupCentroCosto";
            this.slkupCentroCosto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupCentroCosto.Properties.View = this.searchLookUpEdit1View;
            this.slkupCentroCosto.Size = new System.Drawing.Size(770, 20);
            this.slkupCentroCosto.StyleController = this.layoutControl1;
            this.slkupCentroCosto.TabIndex = 4;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtSaldoInicial
            // 
            this.txtSaldoInicial.Location = new System.Drawing.Point(121, 76);
            this.txtSaldoInicial.Name = "txtSaldoInicial";
            this.txtSaldoInicial.Properties.ReadOnly = true;
            this.txtSaldoInicial.Size = new System.Drawing.Size(123, 20);
            this.txtSaldoInicial.StyleController = this.layoutControl1;
            this.txtSaldoInicial.TabIndex = 10;
            // 
            // txtTotalDebitos
            // 
            this.txtTotalDebitos.Location = new System.Drawing.Point(248, 76);
            this.txtTotalDebitos.Name = "txtTotalDebitos";
            this.txtTotalDebitos.Properties.ReadOnly = true;
            this.txtTotalDebitos.Size = new System.Drawing.Size(144, 20);
            this.txtTotalDebitos.StyleController = this.layoutControl1;
            this.txtTotalDebitos.TabIndex = 11;
            // 
            // txtTotalCredito
            // 
            this.txtTotalCredito.Location = new System.Drawing.Point(396, 76);
            this.txtTotalCredito.Name = "txtTotalCredito";
            this.txtTotalCredito.Properties.ReadOnly = true;
            this.txtTotalCredito.Size = new System.Drawing.Size(136, 20);
            this.txtTotalCredito.StyleController = this.layoutControl1;
            this.txtTotalCredito.TabIndex = 12;
            // 
            // txtSaldoFinal
            // 
            this.txtSaldoFinal.Location = new System.Drawing.Point(536, 76);
            this.txtSaldoFinal.Name = "txtSaldoFinal";
            this.txtSaldoFinal.Properties.ReadOnly = true;
            this.txtSaldoFinal.Size = new System.Drawing.Size(151, 20);
            this.txtSaldoFinal.StyleController = this.layoutControl1;
            this.txtSaldoFinal.TabIndex = 13;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.simpleLabelItem1,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(864, 277);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.slkupCentroCosto;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(844, 24);
            this.layoutControlItem1.Text = "Centro Costo";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtDesde;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(254, 24);
            this.layoutControlItem2.Text = "Desde :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtHasta;
            this.layoutControlItem3.Location = new System.Drawing.Point(254, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(270, 24);
            this.layoutControlItem3.Text = "Hasta:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grid;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 107);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(844, 150);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 88);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 19);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 19);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(844, 19);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.CustomizationFormText = "Moneda";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 48);
            this.simpleLabelItem1.MaxSize = new System.Drawing.Size(109, 17);
            this.simpleLabelItem1.MinSize = new System.Drawing.Size(109, 17);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(109, 40);
            this.simpleLabelItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem1.Text = "Moneda";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtSaldoInicial;
            this.layoutControlItem7.CustomizationFormText = "Saldo Inicial";
            this.layoutControlItem7.Location = new System.Drawing.Point(109, 48);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(127, 40);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(127, 40);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(127, 40);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "Saldo Inicial";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtTotalDebitos;
            this.layoutControlItem8.CustomizationFormText = "Total Débitos";
            this.layoutControlItem8.Location = new System.Drawing.Point(236, 48);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(148, 40);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(148, 40);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(148, 40);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "Total Débitos";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtTotalCredito;
            this.layoutControlItem9.CustomizationFormText = "Total Créditos";
            this.layoutControlItem9.Location = new System.Drawing.Point(384, 48);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(140, 40);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "Total Créditos";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtSaldoFinal;
            this.layoutControlItem10.CustomizationFormText = "Saldo Final";
            this.layoutControlItem10.Location = new System.Drawing.Point(524, 48);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(155, 40);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(155, 40);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(320, 40);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "Saldo Final";
            this.layoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(67, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(524, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(320, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnCancelar,
            this.lblStatus,
            this.btnExportar,
            this.btnMonedaDolar,
            this.btnMonedaLocal,
            this.barButtonItem3,
            this.barButtonItem1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 10;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(864, 143);
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
            // btnMonedaDolar
            // 
            this.btnMonedaDolar.Caption = "Moneda Dolar";
            this.btnMonedaDolar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMonedaDolar.Glyph")));
            this.btnMonedaDolar.Id = 4;
            this.btnMonedaDolar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMonedaDolar.LargeGlyph")));
            this.btnMonedaDolar.Name = "btnMonedaDolar";
            this.btnMonedaDolar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonedaDolar_ItemClick);
            // 
            // btnMonedaLocal
            // 
            this.btnMonedaLocal.Caption = "Moneda Local";
            this.btnMonedaLocal.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMonedaLocal.Glyph")));
            this.btnMonedaLocal.Id = 5;
            this.btnMonedaLocal.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMonedaLocal.LargeGlyph")));
            this.btnMonedaLocal.Name = "btnMonedaLocal";
            this.btnMonedaLocal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonedaLocal_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Impriir";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 6;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMonedaDolar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMonedaLocal);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefrescar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
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
            // DescrCentro
            // 
            this.DescrCentro.Caption = "DescrCentro";
            this.DescrCentro.FieldName = "DescrCentroCosto";
            this.DescrCentro.Name = "DescrCentro";
            this.DescrCentro.OptionsColumn.AllowFocus = false;
            this.DescrCentro.OptionsColumn.ReadOnly = true;
            this.DescrCentro.Visible = true;
            this.DescrCentro.VisibleIndex = 1;
            // 
            // CentroCosto
            // 
            this.CentroCosto.Caption = "Centro";
            this.CentroCosto.FieldName = "Centro";
            this.CentroCosto.Name = "CentroCosto";
            this.CentroCosto.OptionsColumn.AllowFocus = false;
            this.CentroCosto.OptionsColumn.ReadOnly = true;
            this.CentroCosto.Visible = true;
            this.CentroCosto.VisibleIndex = 0;
            // 
            // frmConsultaSaldoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 420);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaSaldoCuenta";
            this.Ribbon = this.ribbonControl;
            this.Text = "Consulta de Saldos de Cuentas";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDebitos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCredito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit dtHasta;
        private DevExpress.XtraEditors.DateEdit dtDesde;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupCentroCosto;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn Cuenta;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn SaldoInicial;
        private DevExpress.XtraGrid.Columns.GridColumn Debitos;
        private DevExpress.XtraGrid.Columns.GridColumn Creditos;
        private DevExpress.XtraGrid.Columns.GridColumn SaldoFinal;
        private DevExpress.XtraEditors.TextEdit txtSaldoInicial;
        private DevExpress.XtraEditors.TextEdit txtTotalDebitos;
        private DevExpress.XtraEditors.TextEdit txtTotalCredito;
        private DevExpress.XtraEditors.TextEdit txtSaldoFinal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraBars.BarButtonItem btnMonedaDolar;
        private DevExpress.XtraBars.BarButtonItem btnMonedaLocal;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnRefrescar;
        private DevExpress.XtraGrid.Columns.GridColumn CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn DescrCentro;
    }
}