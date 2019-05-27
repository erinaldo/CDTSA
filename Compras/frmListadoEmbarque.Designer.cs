namespace CO
{
    partial class frmListadoEmbarque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoEmbarque));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dtpFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.dtpFechaInicial = new DevExpress.XtraEditors.DateEdit();
            this.txtEmbarque = new DevExpress.XtraEditors.TextEdit();
            this.txtOrdenCompra = new DevExpress.XtraEditors.TextEdit();
            this.dtgEmbarques = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAsiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmbarque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdenCompra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbarques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnCancelar,
            this.btnEliminar,
            this.lblStatus,
            this.btnExportar,
            this.btnRefrescar});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 4;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(639, 143);
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
            this.ribbonPage1.Text = "Operaciones Concsecutivos";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefrescar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtpFechaFinal);
            this.layoutControl1.Controls.Add(this.dtpFechaInicial);
            this.layoutControl1.Controls.Add(this.txtEmbarque);
            this.layoutControl1.Controls.Add(this.txtOrdenCompra);
            this.layoutControl1.Controls.Add(this.dtgEmbarques);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(639, 358);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.EditValue = null;
            this.dtpFechaFinal.Location = new System.Drawing.Point(399, 63);
            this.dtpFechaFinal.MenuManager = this.ribbonControl;
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaFinal.Size = new System.Drawing.Size(228, 20);
            this.dtpFechaFinal.StyleController = this.layoutControl1;
            this.dtpFechaFinal.TabIndex = 8;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.EditValue = null;
            this.dtpFechaInicial.Location = new System.Drawing.Point(89, 63);
            this.dtpFechaInicial.MenuManager = this.ribbonControl;
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaInicial.Size = new System.Drawing.Size(229, 20);
            this.dtpFechaInicial.StyleController = this.layoutControl1;
            this.dtpFechaInicial.TabIndex = 7;
            // 
            // txtEmbarque
            // 
            this.txtEmbarque.Location = new System.Drawing.Point(399, 39);
            this.txtEmbarque.MenuManager = this.ribbonControl;
            this.txtEmbarque.Name = "txtEmbarque";
            this.txtEmbarque.Size = new System.Drawing.Size(228, 20);
            this.txtEmbarque.StyleController = this.layoutControl1;
            this.txtEmbarque.TabIndex = 6;
            // 
            // txtOrdenCompra
            // 
            this.txtOrdenCompra.Location = new System.Drawing.Point(89, 39);
            this.txtOrdenCompra.MenuManager = this.ribbonControl;
            this.txtOrdenCompra.Name = "txtOrdenCompra";
            this.txtOrdenCompra.Size = new System.Drawing.Size(229, 20);
            this.txtOrdenCompra.StyleController = this.layoutControl1;
            this.txtOrdenCompra.TabIndex = 5;
            // 
            // dtgEmbarques
            // 
            this.dtgEmbarques.Location = new System.Drawing.Point(12, 87);
            this.dtgEmbarques.MainView = this.gridView1;
            this.dtgEmbarques.MenuManager = this.ribbonControl;
            this.dtgEmbarques.Name = "dtgEmbarques";
            this.dtgEmbarques.Size = new System.Drawing.Size(615, 259);
            this.dtgEmbarques.TabIndex = 4;
            this.dtgEmbarques.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dtgEmbarques.DoubleClick += new System.EventHandler(this.dtgEmbarques_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDEmbarque,
            this.colEmbarque,
            this.colFecha,
            this.colAsiento,
            this.colUsuario});
            this.gridView1.GridControl = this.dtgEmbarques;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIDEmbarque
            // 
            this.colIDEmbarque.Caption = "ID Embarque";
            this.colIDEmbarque.FieldName = "IDEmbarque";
            this.colIDEmbarque.Name = "colIDEmbarque";
            this.colIDEmbarque.Visible = true;
            this.colIDEmbarque.VisibleIndex = 0;
            this.colIDEmbarque.Width = 88;
            // 
            // colEmbarque
            // 
            this.colEmbarque.Caption = "Embarque";
            this.colEmbarque.FieldName = "Embarque";
            this.colEmbarque.Name = "colEmbarque";
            this.colEmbarque.Visible = true;
            this.colEmbarque.VisibleIndex = 1;
            this.colEmbarque.Width = 112;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            this.colFecha.Width = 73;
            // 
            // colAsiento
            // 
            this.colAsiento.Caption = "Asiento";
            this.colAsiento.FieldName = "Asiento";
            this.colAsiento.Name = "colAsiento";
            this.colAsiento.Visible = true;
            this.colAsiento.VisibleIndex = 3;
            this.colAsiento.Width = 261;
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 4;
            this.colUsuario.Width = 63;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(639, 358);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseFont = true;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 27);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 27);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(619, 27);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "Listado de Embarques";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(74, 0);
            this.emptySpaceItem1.TextVisible = true;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtgEmbarques;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(619, 263);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtOrdenCompra;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem2.Text = "Orden Compra:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtpFechaInicial;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 51);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem4.Text = "Fecha Inicial:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtpFechaFinal;
            this.layoutControlItem5.Location = new System.Drawing.Point(310, 51);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(309, 24);
            this.layoutControlItem5.Text = "Fecha Final:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEmbarque;
            this.layoutControlItem3.Location = new System.Drawing.Point(310, 27);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(309, 24);
            this.layoutControlItem3.Text = "Embarque:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(74, 13);
            // 
            // frmListadoEmbarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 501);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "frmListadoEmbarque";
            this.Ribbon = this.ribbonControl;
            this.Text = "frmListadoEmbarque";
            this.Load += new System.EventHandler(this.frmListadoEmbarque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmbarque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdenCompra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbarques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarButtonItem btnRefrescar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl dtgEmbarques;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtOrdenCompra;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit dtpFechaFinal;
        private DevExpress.XtraEditors.DateEdit dtpFechaInicial;
        private DevExpress.XtraEditors.TextEdit txtEmbarque;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colIDEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colAsiento;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
    }
}