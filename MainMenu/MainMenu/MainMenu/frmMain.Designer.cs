namespace MainMenu
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lblUsuario = new DevExpress.XtraBars.BarStaticItem();
            this.lblTipoCambio = new DevExpress.XtraBars.BarStaticItem();
            this.lblCompania = new DevExpress.XtraBars.BarStaticItem();
            this.lblFecha = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.navbarImageCollectionLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.navbarImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navGroupCuentasxPagar = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer6 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treelstCuentasPorPagar = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.NavBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeListInventario = new DevExpress.XtraTreeList.TreeList();
            this.TreeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.NavBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeListContabilidad = new DevExpress.XtraTreeList.TreeList();
            this.TreeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeListAdministracion = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer4 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeListControlBancario = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer5 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treelstCompras = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navGroupInventario = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGroupFacturación = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGroupTeleVenta = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGroupContabilidad = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGroupControlBancario = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGroupCuentasXCobrar = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGroupCompras = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGroupAdministracion = new DevExpress.XtraNavBar.NavBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navbarImageCollectionLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navbarImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            this.navBarControl.SuspendLayout();
            this.navBarGroupControlContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelstCuentasPorPagar)).BeginInit();
            this.NavBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListInventario)).BeginInit();
            this.NavBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListContabilidad)).BeginInit();
            this.navBarGroupControlContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListAdministracion)).BeginInit();
            this.navBarGroupControlContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListControlBancario)).BeginInit();
            this.navBarGroupControlContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelstCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.lblUsuario,
            this.lblTipoCambio,
            this.lblCompania,
            this.lblFecha});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 11;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonHelp});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.Size = new System.Drawing.Size(721, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Caption = "barStaticItem1";
            this.lblUsuario.Glyph = ((System.Drawing.Image)(resources.GetObject("lblUsuario.Glyph")));
            this.lblUsuario.Id = 4;
            this.lblUsuario.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("lblUsuario.LargeGlyph")));
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblTipoCambio.Caption = "barStaticItem2";
            this.lblTipoCambio.Glyph = ((System.Drawing.Image)(resources.GetObject("lblTipoCambio.Glyph")));
            this.lblTipoCambio.Id = 6;
            this.lblTipoCambio.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("lblTipoCambio.LargeGlyph")));
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCompania
            // 
            this.lblCompania.Caption = "barStaticItem1";
            this.lblCompania.Glyph = ((System.Drawing.Image)(resources.GetObject("lblCompania.Glyph")));
            this.lblCompania.Id = 8;
            this.lblCompania.Name = "lblCompania";
            this.lblCompania.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblFecha
            // 
            this.lblFecha.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblFecha.Caption = "barStaticItem1";
            this.lblFecha.Glyph = ((System.Drawing.Image)(resources.GetObject("lblFecha.Glyph")));
            this.lblFecha.Id = 9;
            this.lblFecha.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("lblFecha.LargeGlyph")));
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonHelp
            // 
            this.ribbonHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonHelp.Name = "ribbonHelp";
            this.ribbonHelp.Text = "Ayuda";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblUsuario);
            this.ribbonStatusBar.ItemLinks.Add(this.lblFecha);
            this.ribbonStatusBar.ItemLinks.Add(this.lblTipoCambio);
            this.ribbonStatusBar.ItemLinks.Add(this.lblCompania);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 524);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(721, 31);
            // 
            // navbarImageCollectionLarge
            // 
            this.navbarImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.navbarImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("navbarImageCollectionLarge.ImageStream")));
            this.navbarImageCollectionLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.navbarImageCollectionLarge.Images.SetKeyName(0, "Cardboard Box.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(1, "POS Terminal.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(2, "Customer Support-48.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(3, "Courses-48.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(4, "Library-48.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(5, "Donate-48.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(6, "Refund-48.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(7, "Sell Stock-48.png");
            this.navbarImageCollectionLarge.Images.SetKeyName(8, "Settings-48.png");
            // 
            // navbarImageCollection
            // 
            this.navbarImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("navbarImageCollection.ImageStream")));
            this.navbarImageCollection.TransparentColor = System.Drawing.Color.Transparent;
            this.navbarImageCollection.Images.SetKeyName(0, "Box.png");
            this.navbarImageCollection.Images.SetKeyName(1, "POS Terminal-48.png");
            this.navbarImageCollection.Images.SetKeyName(2, "Customer Support-48.png");
            this.navbarImageCollection.Images.SetKeyName(3, "Courses-48.png");
            this.navbarImageCollection.Images.SetKeyName(4, "Library-48.png");
            this.navbarImageCollection.Images.SetKeyName(5, "Donate-48.png");
            this.navbarImageCollection.Images.SetKeyName(6, "Refund-48.png");
            this.navbarImageCollection.Images.SetKeyName(7, "Sell Stock-48.png");
            this.navbarImageCollection.Images.SetKeyName(8, "Settings-48.png");
            this.navbarImageCollection.Images.SetKeyName(9, "Folder-48.png");
            this.navbarImageCollection.Images.SetKeyName(10, "Open Folder-48.png");
            this.navbarImageCollection.Images.SetKeyName(11, "Document-48.png");
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.navGroupCuentasxPagar;
            this.navBarControl.Controls.Add(this.NavBarGroupControlContainer1);
            this.navBarControl.Controls.Add(this.NavBarGroupControlContainer2);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer3);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer4);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer5);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer6);
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navGroupInventario,
            this.navGroupFacturación,
            this.navGroupTeleVenta,
            this.navGroupContabilidad,
            this.navGroupControlBancario,
            this.navGroupCuentasxPagar,
            this.navGroupCuentasXCobrar,
            this.navGroupCompras,
            this.navGroupAdministracion});
            this.navBarControl.LargeImages = this.navbarImageCollectionLarge;
            this.navBarControl.Location = new System.Drawing.Point(0, 143);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.NavigationPaneGroupClientHeight = 200;
            this.navBarControl.OptionsNavPane.ExpandedWidth = 198;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(198, 381);
            this.navBarControl.SmallImages = this.navbarImageCollection;
            this.navBarControl.TabIndex = 29;
            this.navBarControl.Text = "navBarControl1";
            this.navBarControl.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // navGroupCuentasxPagar
            // 
            this.navGroupCuentasxPagar.Caption = "Cuentas por Pagar";
            this.navGroupCuentasxPagar.ControlContainer = this.navBarGroupControlContainer6;
            this.navGroupCuentasxPagar.Expanded = true;
            this.navGroupCuentasxPagar.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupCuentasxPagar.GroupClientHeight = 214;
            this.navGroupCuentasxPagar.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupCuentasxPagar.LargeImageIndex = 5;
            this.navGroupCuentasxPagar.Name = "navGroupCuentasxPagar";
            this.navGroupCuentasxPagar.SmallImageIndex = 5;
            // 
            // navBarGroupControlContainer6
            // 
            this.navBarGroupControlContainer6.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer6.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer6.Controls.Add(this.treelstCuentasPorPagar);
            this.navBarGroupControlContainer6.Name = "navBarGroupControlContainer6";
            this.navBarGroupControlContainer6.Size = new System.Drawing.Size(198, 214);
            this.navBarGroupControlContainer6.TabIndex = 5;
            // 
            // treelstCuentasPorPagar
            // 
            this.treelstCuentasPorPagar.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn6});
            this.treelstCuentasPorPagar.Cursor = System.Windows.Forms.Cursors.Default;
            this.treelstCuentasPorPagar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treelstCuentasPorPagar.Location = new System.Drawing.Point(0, 0);
            this.treelstCuentasPorPagar.Name = "treelstCuentasPorPagar";
            this.treelstCuentasPorPagar.OptionsBehavior.Editable = false;
            this.treelstCuentasPorPagar.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.treelstCuentasPorPagar.OptionsLayout.AddNewColumns = false;
            this.treelstCuentasPorPagar.OptionsView.ShowColumns = false;
            this.treelstCuentasPorPagar.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treelstCuentasPorPagar.OptionsView.ShowHorzLines = false;
            this.treelstCuentasPorPagar.OptionsView.ShowIndentAsRowStyle = true;
            this.treelstCuentasPorPagar.OptionsView.ShowIndicator = false;
            this.treelstCuentasPorPagar.OptionsView.ShowVertLines = false;
            this.treelstCuentasPorPagar.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.Default;
            this.treelstCuentasPorPagar.Size = new System.Drawing.Size(198, 214);
            this.treelstCuentasPorPagar.StateImageList = this.navbarImageCollection;
            this.treelstCuentasPorPagar.TabIndex = 3;
            this.treelstCuentasPorPagar.DoubleClick += new System.EventHandler(this.treelstCuentasPorPagar_DoubleClick);
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "TreeListColumn2";
            this.treeListColumn6.FieldName = "TreeListColumn2";
            this.treeListColumn6.MinWidth = 87;
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 0;
            this.treeListColumn6.Width = 87;
            // 
            // NavBarGroupControlContainer1
            // 
            this.NavBarGroupControlContainer1.Controls.Add(this.treeListInventario);
            this.NavBarGroupControlContainer1.Name = "NavBarGroupControlContainer1";
            this.NavBarGroupControlContainer1.Size = new System.Drawing.Size(198, 260);
            this.NavBarGroupControlContainer1.TabIndex = 0;
            // 
            // treeListInventario
            // 
            this.treeListInventario.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.TreeListColumn2});
            this.treeListInventario.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListInventario.Location = new System.Drawing.Point(0, 0);
            this.treeListInventario.Name = "treeListInventario";
            this.treeListInventario.OptionsBehavior.Editable = false;
            this.treeListInventario.OptionsLayout.AddNewColumns = false;
            this.treeListInventario.OptionsView.ShowColumns = false;
            this.treeListInventario.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListInventario.OptionsView.ShowHorzLines = false;
            this.treeListInventario.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListInventario.OptionsView.ShowIndicator = false;
            this.treeListInventario.OptionsView.ShowVertLines = false;
            this.treeListInventario.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.Default;
            this.treeListInventario.Size = new System.Drawing.Size(198, 260);
            this.treeListInventario.StateImageList = this.navbarImageCollection;
            this.treeListInventario.TabIndex = 0;
            this.treeListInventario.DoubleClick += new System.EventHandler(this.treeListInventario_DoubleClick);
            // 
            // TreeListColumn2
            // 
            this.TreeListColumn2.Caption = "TreeListColumn2";
            this.TreeListColumn2.FieldName = "TreeListColumn2";
            this.TreeListColumn2.MinWidth = 87;
            this.TreeListColumn2.Name = "TreeListColumn2";
            this.TreeListColumn2.Visible = true;
            this.TreeListColumn2.VisibleIndex = 0;
            this.TreeListColumn2.Width = 87;
            // 
            // NavBarGroupControlContainer2
            // 
            this.NavBarGroupControlContainer2.Controls.Add(this.treeListContabilidad);
            this.NavBarGroupControlContainer2.Name = "NavBarGroupControlContainer2";
            this.NavBarGroupControlContainer2.Size = new System.Drawing.Size(198, 260);
            this.NavBarGroupControlContainer2.TabIndex = 1;
            // 
            // treeListContabilidad
            // 
            this.treeListContabilidad.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.TreeListColumn1});
            this.treeListContabilidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListContabilidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListContabilidad.Location = new System.Drawing.Point(0, 0);
            this.treeListContabilidad.Name = "treeListContabilidad";
            this.treeListContabilidad.OptionsBehavior.Editable = false;
            this.treeListContabilidad.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.treeListContabilidad.OptionsLayout.AddNewColumns = false;
            this.treeListContabilidad.OptionsView.ShowColumns = false;
            this.treeListContabilidad.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListContabilidad.OptionsView.ShowHorzLines = false;
            this.treeListContabilidad.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListContabilidad.OptionsView.ShowIndicator = false;
            this.treeListContabilidad.OptionsView.ShowVertLines = false;
            this.treeListContabilidad.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.Default;
            this.treeListContabilidad.Size = new System.Drawing.Size(198, 260);
            this.treeListContabilidad.StateImageList = this.navbarImageCollection;
            this.treeListContabilidad.TabIndex = 1;
            // 
            // TreeListColumn1
            // 
            this.TreeListColumn1.Caption = "TreeListColumn2";
            this.TreeListColumn1.FieldName = "TreeListColumn2";
            this.TreeListColumn1.MinWidth = 87;
            this.TreeListColumn1.Name = "TreeListColumn1";
            this.TreeListColumn1.Visible = true;
            this.TreeListColumn1.VisibleIndex = 0;
            this.TreeListColumn1.Width = 87;
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer3.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer3.Controls.Add(this.treeListAdministracion);
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(198, 223);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // treeListAdministracion
            // 
            this.treeListAdministracion.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3});
            this.treeListAdministracion.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListAdministracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListAdministracion.Location = new System.Drawing.Point(0, 0);
            this.treeListAdministracion.Name = "treeListAdministracion";
            this.treeListAdministracion.OptionsBehavior.Editable = false;
            this.treeListAdministracion.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.treeListAdministracion.OptionsLayout.AddNewColumns = false;
            this.treeListAdministracion.OptionsView.ShowColumns = false;
            this.treeListAdministracion.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListAdministracion.OptionsView.ShowHorzLines = false;
            this.treeListAdministracion.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListAdministracion.OptionsView.ShowIndicator = false;
            this.treeListAdministracion.OptionsView.ShowVertLines = false;
            this.treeListAdministracion.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.Default;
            this.treeListAdministracion.Size = new System.Drawing.Size(198, 223);
            this.treeListAdministracion.StateImageList = this.navbarImageCollection;
            this.treeListAdministracion.TabIndex = 2;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "TreeListColumn2";
            this.treeListColumn3.FieldName = "TreeListColumn2";
            this.treeListColumn3.MinWidth = 87;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 87;
            // 
            // navBarGroupControlContainer4
            // 
            this.navBarGroupControlContainer4.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer4.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer4.Controls.Add(this.treeListControlBancario);
            this.navBarGroupControlContainer4.Name = "navBarGroupControlContainer4";
            this.navBarGroupControlContainer4.Size = new System.Drawing.Size(198, 260);
            this.navBarGroupControlContainer4.TabIndex = 3;
            // 
            // treeListControlBancario
            // 
            this.treeListControlBancario.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn4});
            this.treeListControlBancario.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListControlBancario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListControlBancario.Location = new System.Drawing.Point(0, 0);
            this.treeListControlBancario.Name = "treeListControlBancario";
            this.treeListControlBancario.OptionsBehavior.Editable = false;
            this.treeListControlBancario.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.treeListControlBancario.OptionsLayout.AddNewColumns = false;
            this.treeListControlBancario.OptionsView.ShowColumns = false;
            this.treeListControlBancario.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListControlBancario.OptionsView.ShowHorzLines = false;
            this.treeListControlBancario.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListControlBancario.OptionsView.ShowIndicator = false;
            this.treeListControlBancario.OptionsView.ShowVertLines = false;
            this.treeListControlBancario.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.Default;
            this.treeListControlBancario.Size = new System.Drawing.Size(198, 260);
            this.treeListControlBancario.StateImageList = this.navbarImageCollection;
            this.treeListControlBancario.TabIndex = 2;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "TreeListColumn2";
            this.treeListColumn4.FieldName = "TreeListColumn2";
            this.treeListColumn4.MinWidth = 87;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            this.treeListColumn4.Width = 87;
            // 
            // navBarGroupControlContainer5
            // 
            this.navBarGroupControlContainer5.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer5.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer5.Controls.Add(this.treelstCompras);
            this.navBarGroupControlContainer5.Name = "navBarGroupControlContainer5";
            this.navBarGroupControlContainer5.Size = new System.Drawing.Size(198, 260);
            this.navBarGroupControlContainer5.TabIndex = 4;
            // 
            // treelstCompras
            // 
            this.treelstCompras.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn5});
            this.treelstCompras.Cursor = System.Windows.Forms.Cursors.Default;
            this.treelstCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treelstCompras.Location = new System.Drawing.Point(0, 0);
            this.treelstCompras.Name = "treelstCompras";
            this.treelstCompras.OptionsBehavior.Editable = false;
            this.treelstCompras.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.treelstCompras.OptionsLayout.AddNewColumns = false;
            this.treelstCompras.OptionsView.ShowColumns = false;
            this.treelstCompras.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treelstCompras.OptionsView.ShowHorzLines = false;
            this.treelstCompras.OptionsView.ShowIndentAsRowStyle = true;
            this.treelstCompras.OptionsView.ShowIndicator = false;
            this.treelstCompras.OptionsView.ShowVertLines = false;
            this.treelstCompras.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.Default;
            this.treelstCompras.Size = new System.Drawing.Size(198, 260);
            this.treelstCompras.StateImageList = this.navbarImageCollection;
            this.treelstCompras.TabIndex = 2;
            this.treelstCompras.DoubleClick += new System.EventHandler(this.treelstCompras_DoubleClick);
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "TreeListColumn2";
            this.treeListColumn5.FieldName = "TreeListColumn2";
            this.treeListColumn5.MinWidth = 87;
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 0;
            this.treeListColumn5.Width = 87;
            // 
            // navGroupInventario
            // 
            this.navGroupInventario.Caption = "Inventario";
            this.navGroupInventario.ControlContainer = this.NavBarGroupControlContainer1;
            this.navGroupInventario.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupInventario.GroupClientHeight = 250;
            this.navGroupInventario.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupInventario.LargeImageIndex = 0;
            this.navGroupInventario.Name = "navGroupInventario";
            this.navGroupInventario.SmallImageIndex = 0;
            // 
            // navGroupFacturación
            // 
            this.navGroupFacturación.Caption = "Facturación";
            this.navGroupFacturación.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupFacturación.LargeImageIndex = 1;
            this.navGroupFacturación.Name = "navGroupFacturación";
            this.navGroupFacturación.SmallImageIndex = 1;
            // 
            // navGroupTeleVenta
            // 
            this.navGroupTeleVenta.Caption = "Tele Venta";
            this.navGroupTeleVenta.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupTeleVenta.LargeImageIndex = 2;
            this.navGroupTeleVenta.Name = "navGroupTeleVenta";
            this.navGroupTeleVenta.SmallImageIndex = 2;
            this.navGroupTeleVenta.Visible = false;
            // 
            // navGroupContabilidad
            // 
            this.navGroupContabilidad.Caption = "Contabilidad";
            this.navGroupContabilidad.ControlContainer = this.NavBarGroupControlContainer2;
            this.navGroupContabilidad.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupContabilidad.GroupClientHeight = 223;
            this.navGroupContabilidad.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupContabilidad.LargeImageIndex = 3;
            this.navGroupContabilidad.Name = "navGroupContabilidad";
            this.navGroupContabilidad.SmallImageIndex = 3;
            // 
            // navGroupControlBancario
            // 
            this.navGroupControlBancario.Caption = "Control Bancario";
            this.navGroupControlBancario.ControlContainer = this.navBarGroupControlContainer4;
            this.navGroupControlBancario.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupControlBancario.GroupClientHeight = 223;
            this.navGroupControlBancario.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupControlBancario.LargeImageIndex = 4;
            this.navGroupControlBancario.Name = "navGroupControlBancario";
            this.navGroupControlBancario.SmallImageIndex = 4;
            // 
            // navGroupCuentasXCobrar
            // 
            this.navGroupCuentasXCobrar.Caption = "Cuentas por Cobrar";
            this.navGroupCuentasXCobrar.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupCuentasXCobrar.LargeImageIndex = 6;
            this.navGroupCuentasXCobrar.Name = "navGroupCuentasXCobrar";
            this.navGroupCuentasXCobrar.SmallImageIndex = 6;
            this.navGroupCuentasXCobrar.Visible = false;
            // 
            // navGroupCompras
            // 
            this.navGroupCompras.Caption = "Compras";
            this.navGroupCompras.ControlContainer = this.navBarGroupControlContainer5;
            this.navGroupCompras.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupCompras.GroupClientHeight = 260;
            this.navGroupCompras.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupCompras.LargeImageIndex = 7;
            this.navGroupCompras.Name = "navGroupCompras";
            this.navGroupCompras.SmallImageIndex = 7;
            // 
            // navGroupAdministracion
            // 
            this.navGroupAdministracion.Caption = "Administración";
            this.navGroupAdministracion.ControlContainer = this.navBarGroupControlContainer3;
            this.navGroupAdministracion.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navGroupAdministracion.GroupClientHeight = 223;
            this.navGroupAdministracion.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupAdministracion.LargeImageIndex = 8;
            this.navGroupAdministracion.Name = "navGroupAdministracion";
            this.navGroupAdministracion.SmallImageIndex = 8;
            // 
            // frmMain
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 555);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "ERP CEDETSA / DASA";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navbarImageCollectionLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navbarImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.navBarControl.ResumeLayout(false);
            this.navBarGroupControlContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treelstCuentasPorPagar)).EndInit();
            this.NavBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListInventario)).EndInit();
            this.NavBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListContabilidad)).EndInit();
            this.navBarGroupControlContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListAdministracion)).EndInit();
            this.navBarGroupControlContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListControlBancario)).EndInit();
            this.navBarGroupControlContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treelstCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.Utils.ImageCollection navbarImageCollectionLarge;
        private DevExpress.Utils.ImageCollection navbarImageCollection;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupInventario;
        internal DevExpress.XtraNavBar.NavBarGroupControlContainer NavBarGroupControlContainer1;
        internal DevExpress.XtraTreeList.TreeList treeListInventario;
        internal DevExpress.XtraTreeList.Columns.TreeListColumn TreeListColumn2;
        internal DevExpress.XtraNavBar.NavBarGroupControlContainer NavBarGroupControlContainer2;
        internal DevExpress.XtraTreeList.TreeList treeListContabilidad;
        internal DevExpress.XtraTreeList.Columns.TreeListColumn TreeListColumn1;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupFacturación;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupTeleVenta;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupContabilidad;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupControlBancario;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupCuentasxPagar;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupCuentasXCobrar;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupCompras;
        internal DevExpress.XtraNavBar.NavBarGroup navGroupAdministracion;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
        internal DevExpress.XtraTreeList.TreeList treeListAdministracion;
        internal DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraBars.BarStaticItem lblUsuario;
        private DevExpress.XtraBars.BarStaticItem lblTipoCambio;
        private DevExpress.XtraBars.BarStaticItem lblCompania;
        private DevExpress.XtraBars.BarStaticItem lblFecha;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer4;
        internal DevExpress.XtraTreeList.TreeList treeListControlBancario;
        internal DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer5;
        internal DevExpress.XtraTreeList.TreeList treelstCompras;
        internal DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer6;
        internal DevExpress.XtraTreeList.TreeList treelstCuentasPorPagar;
        internal DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
    }
}