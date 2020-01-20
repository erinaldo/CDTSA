namespace CO
{
    partial class frmImportFromExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportFromExcel));
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.dtgDetalle = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkupIDProducto = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescrProduto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkupDescrProducto = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDProductoDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrProdDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDescrStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupIDProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupDescrProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "openFileDialog1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 26);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = " Archivo:";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCancelar);
            this.layoutControl1.Controls.Add(this.btnAceptar);
            this.layoutControl1.Controls.Add(this.dtgDetalle);
            this.layoutControl1.Controls.Add(this.txtFileName);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(230, 285, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(944, 467);
            this.layoutControl1.TabIndex = 16;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(757, 433);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 22);
            this.btnCancelar.StyleController = this.layoutControl1;
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(859, 433);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(73, 22);
            this.btnAceptar.StyleController = this.layoutControl1;
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtgDetalle
            // 
            this.dtgDetalle.Location = new System.Drawing.Point(12, 68);
            this.dtgDetalle.MainView = this.gridView1;
            this.dtgDetalle.Name = "dtgDetalle";
            this.dtgDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.slkupIDProducto,
            this.slkupDescrProducto});
            this.dtgDetalle.Size = new System.Drawing.Size(920, 361);
            this.dtgDetalle.TabIndex = 14;
            this.dtgDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDProducto,
            this.colDescrProduto,
            this.colCantidad,
            this.colPrecio,
            this.colImpuesto,
            this.colDesc,
            this.colPorcDesc,
            this.colComentario,
            this.ColStatus,
            this.ColDescrStatus});
            this.gridView1.GridControl = this.dtgDetalle;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colIDProducto
            // 
            this.colIDProducto.Caption = "ID Producto";
            this.colIDProducto.ColumnEdit = this.slkupIDProducto;
            this.colIDProducto.FieldName = "IDProducto";
            this.colIDProducto.Name = "colIDProducto";
            this.colIDProducto.Visible = true;
            this.colIDProducto.VisibleIndex = 0;
            this.colIDProducto.Width = 69;
            // 
            // slkupIDProducto
            // 
            this.slkupIDProducto.AutoHeight = false;
            this.slkupIDProducto.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupIDProducto.Name = "slkupIDProducto";
            this.slkupIDProducto.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDProducto,
            this.DescrProd});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // IDProducto
            // 
            this.IDProducto.Caption = "ID Producto";
            this.IDProducto.FieldName = "IDProducto";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.Visible = true;
            this.IDProducto.VisibleIndex = 0;
            // 
            // DescrProd
            // 
            this.DescrProd.Caption = "Descripción";
            this.DescrProd.FieldName = "Descr";
            this.DescrProd.Name = "DescrProd";
            this.DescrProd.Visible = true;
            this.DescrProd.VisibleIndex = 1;
            // 
            // colDescrProduto
            // 
            this.colDescrProduto.Caption = "Descr Producto";
            this.colDescrProduto.ColumnEdit = this.slkupDescrProducto;
            this.colDescrProduto.FieldName = "IDProducto";
            this.colDescrProduto.Name = "colDescrProduto";
            this.colDescrProduto.Visible = true;
            this.colDescrProduto.VisibleIndex = 1;
            this.colDescrProduto.Width = 181;
            // 
            // slkupDescrProducto
            // 
            this.slkupDescrProducto.AutoHeight = false;
            this.slkupDescrProducto.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupDescrProducto.Name = "slkupDescrProducto";
            this.slkupDescrProducto.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDProductoDes,
            this.DescrProdDescr});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // IDProductoDes
            // 
            this.IDProductoDes.Caption = "ID Producto";
            this.IDProductoDes.FieldName = "IDProducto";
            this.IDProductoDes.Name = "IDProductoDes";
            this.IDProductoDes.Visible = true;
            this.IDProductoDes.VisibleIndex = 0;
            // 
            // DescrProdDescr
            // 
            this.DescrProdDescr.Caption = "Descripción";
            this.DescrProdDescr.FieldName = "Descr";
            this.DescrProdDescr.Name = "DescrProdDescr";
            this.DescrProdDescr.Visible = true;
            this.DescrProdDescr.VisibleIndex = 1;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 2;
            this.colCantidad.Width = 64;
            // 
            // colPrecio
            // 
            this.colPrecio.Caption = "Precio Unitario";
            this.colPrecio.FieldName = "PrecioUnitario";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Visible = true;
            this.colPrecio.VisibleIndex = 3;
            this.colPrecio.Width = 73;
            // 
            // colImpuesto
            // 
            this.colImpuesto.Caption = "Impuesto";
            this.colImpuesto.FieldName = "Impuesto";
            this.colImpuesto.Name = "colImpuesto";
            this.colImpuesto.Visible = true;
            this.colImpuesto.VisibleIndex = 4;
            this.colImpuesto.Width = 56;
            // 
            // colDesc
            // 
            this.colDesc.Caption = "Descuento";
            this.colDesc.DisplayFormat.FormatString = "$ 00.00";
            this.colDesc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDesc.FieldName = "MontoDesc";
            this.colDesc.Name = "colDesc";
            this.colDesc.Visible = true;
            this.colDesc.VisibleIndex = 5;
            this.colDesc.Width = 60;
            // 
            // colPorcDesc
            // 
            this.colPorcDesc.Caption = "Porc Desc";
            this.colPorcDesc.DisplayFormat.FormatString = "0.00 \\%";
            this.colPorcDesc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colPorcDesc.FieldName = "PorcDesc";
            this.colPorcDesc.Name = "colPorcDesc";
            this.colPorcDesc.Visible = true;
            this.colPorcDesc.VisibleIndex = 6;
            this.colPorcDesc.Width = 52;
            // 
            // colComentario
            // 
            this.colComentario.Caption = "Comentario";
            this.colComentario.FieldName = "Comentario";
            this.colComentario.Name = "colComentario";
            this.colComentario.Visible = true;
            this.colComentario.VisibleIndex = 7;
            this.colComentario.Width = 118;
            // 
            // ColStatus
            // 
            this.ColStatus.Caption = "Estatus";
            this.ColStatus.FieldName = "Status";
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.Visible = true;
            this.ColStatus.VisibleIndex = 8;
            this.ColStatus.Width = 46;
            // 
            // ColDescrStatus
            // 
            this.ColDescrStatus.Caption = "Descr Status";
            this.ColDescrStatus.FieldName = "DescrStatus";
            this.ColDescrStatus.Name = "ColDescrStatus";
            this.ColDescrStatus.Visible = true;
            this.ColDescrStatus.VisibleIndex = 9;
            this.ColDescrStatus.Width = 183;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(133, 28);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Properties.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(527, 20);
            this.txtFileName.StyleController = this.layoutControl1;
            this.txtFileName.TabIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.emptySpaceItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(944, 467);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 14);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(121, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtgDetalle;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(924, 365);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtFileName;
            this.layoutControlItem2.Location = new System.Drawing.Point(121, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(531, 40);
            this.layoutControlItem2.Text = "Nombre del Archivo:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(97, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(652, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(272, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(121, 14);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 40);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(0, 16);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(10, 16);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(924, 16);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 421);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(745, 26);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCancelar;
            this.layoutControlItem6.Location = new System.Drawing.Point(745, 421);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(86, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(86, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(86, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnAceptar;
            this.layoutControlItem5.Location = new System.Drawing.Point(847, 421);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(77, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(831, 421);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(16, 0);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(16, 10);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(16, 26);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("ok", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "ok");
            this.imageCollection1.InsertGalleryImage("error", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "error");
            // 
            // frmImportFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 467);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmImportFromExcel";
            this.Text = "fmrImportFromExcel";
            this.Load += new System.EventHandler(this.fmrImportFromExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupIDProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupDescrProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraGrid.GridControl dtgDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIDProducto;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slkupIDProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn IDProducto;
        private DevExpress.XtraGrid.Columns.GridColumn DescrProd;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrProduto;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slkupDescrProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn IDProductoDes;
        private DevExpress.XtraGrid.Columns.GridColumn DescrProdDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn colImpuesto;
        private DevExpress.XtraGrid.Columns.GridColumn colDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colComentario;
        private DevExpress.XtraGrid.Columns.GridColumn ColStatus;
        private DevExpress.XtraGrid.Columns.GridColumn ColDescrStatus;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        
    }
}