namespace CG.Consultas
{
    partial class frmConsultaPeriodoContable
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.slkupCuentaContable = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.slkupPeriodo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.slkuCentroCosto = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkSoloConMovimientos = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Centro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrCentro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescrCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SaldoInicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Creditos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Debitos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SaldoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCuentaContable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkuCentroCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoloConMovimientos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grid);
            this.layoutControl1.Controls.Add(this.chkSoloConMovimientos);
            this.layoutControl1.Controls.Add(this.slkuCentroCosto);
            this.layoutControl1.Controls.Add(this.slkupPeriodo);
            this.layoutControl1.Controls.Add(this.slkupCuentaContable);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(612, 391);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(612, 391);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // slkupCuentaContable
            // 
            this.slkupCuentaContable.Location = new System.Drawing.Point(101, 60);
            this.slkupCuentaContable.Name = "slkupCuentaContable";
            this.slkupCuentaContable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupCuentaContable.Properties.View = this.searchLookUpEdit1View;
            this.slkupCuentaContable.Size = new System.Drawing.Size(499, 20);
            this.slkupCuentaContable.StyleController = this.layoutControl1;
            this.slkupCuentaContable.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.slkupCuentaContable;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(592, 24);
            this.layoutControlItem1.Text = "Cuenta Contable:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(85, 13);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // slkupPeriodo
            // 
            this.slkupPeriodo.Location = new System.Drawing.Point(101, 12);
            this.slkupPeriodo.Name = "slkupPeriodo";
            this.slkupPeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupPeriodo.Properties.View = this.searchLookUpEdit2View;
            this.slkupPeriodo.Size = new System.Drawing.Size(499, 20);
            this.slkupPeriodo.StyleController = this.layoutControl1;
            this.slkupPeriodo.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.slkupPeriodo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(592, 24);
            this.layoutControlItem2.Text = "Periodo:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(85, 13);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // slkuCentroCosto
            // 
            this.slkuCentroCosto.Location = new System.Drawing.Point(101, 36);
            this.slkuCentroCosto.Name = "slkuCentroCosto";
            this.slkuCentroCosto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkuCentroCosto.Properties.View = this.searchLookUpEdit3View;
            this.slkuCentroCosto.Size = new System.Drawing.Size(499, 20);
            this.slkuCentroCosto.StyleController = this.layoutControl1;
            this.slkuCentroCosto.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.slkuCentroCosto;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(592, 24);
            this.layoutControlItem3.Text = "Centro Costo:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(85, 13);
            // 
            // searchLookUpEdit3View
            // 
            this.searchLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit3View.Name = "searchLookUpEdit3View";
            this.searchLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // chkSoloConMovimientos
            // 
            this.chkSoloConMovimientos.Location = new System.Drawing.Point(12, 84);
            this.chkSoloConMovimientos.Name = "chkSoloConMovimientos";
            this.chkSoloConMovimientos.Properties.Caption = "checkEdit1";
            this.chkSoloConMovimientos.Size = new System.Drawing.Size(588, 19);
            this.chkSoloConMovimientos.StyleController = this.layoutControl1;
            this.chkSoloConMovimientos.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkSoloConMovimientos;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(592, 23);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(12, 117);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(588, 262);
            this.grid.TabIndex = 8;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Centro,
            this.DescrCentro,
            this.Cuenta,
            this.DescrCuenta,
            this.SaldoInicial,
            this.Creditos,
            this.Debitos,
            this.SaldoFinal});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grid;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 105);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(592, 266);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 95);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(592, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Centro
            // 
            this.Centro.Caption = "Centro";
            this.Centro.FieldName = "Centro";
            this.Centro.Name = "Centro";
            this.Centro.Visible = true;
            this.Centro.VisibleIndex = 0;
            // 
            // DescrCentro
            // 
            this.DescrCentro.Caption = "Descr Centro";
            this.DescrCentro.FieldName = "DescrCentro";
            this.DescrCentro.Name = "DescrCentro";
            this.DescrCentro.Visible = true;
            this.DescrCentro.VisibleIndex = 1;
            // 
            // Cuenta
            // 
            this.Cuenta.Caption = "Cuenta";
            this.Cuenta.FieldName = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.Visible = true;
            this.Cuenta.VisibleIndex = 2;
            // 
            // DescrCuenta
            // 
            this.DescrCuenta.Caption = "DescrCuenta";
            this.DescrCuenta.FieldName = "DescrCuenta";
            this.DescrCuenta.Name = "DescrCuenta";
            this.DescrCuenta.Visible = true;
            this.DescrCuenta.VisibleIndex = 3;
            // 
            // SaldoInicial
            // 
            this.SaldoInicial.Caption = "Saldo Inicial";
            this.SaldoInicial.FieldName = "SaldoInicial";
            this.SaldoInicial.Name = "SaldoInicial";
            this.SaldoInicial.Visible = true;
            this.SaldoInicial.VisibleIndex = 4;
            // 
            // Creditos
            // 
            this.Creditos.Caption = "Créditos";
            this.Creditos.FieldName = "Creditos";
            this.Creditos.Name = "Creditos";
            this.Creditos.Visible = true;
            this.Creditos.VisibleIndex = 5;
            // 
            // Debitos
            // 
            this.Debitos.Caption = "Déditos";
            this.Debitos.FieldName = "Debitos";
            this.Debitos.Name = "Debitos";
            this.Debitos.Visible = true;
            this.Debitos.VisibleIndex = 6;
            // 
            // SaldoFinal
            // 
            this.SaldoFinal.Caption = "Saldo Final";
            this.SaldoFinal.FieldName = "SaldoFinal";
            this.SaldoFinal.Name = "SaldoFinal";
            this.SaldoFinal.Visible = true;
            this.SaldoFinal.VisibleIndex = 7;
            // 
            // frmConsultaPeriodoContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 391);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmConsultaPeriodoContable";
            this.Text = "frmConsultaPeriodoContable";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCuentaContable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkuCentroCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoloConMovimientos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn Centro;
        private DevExpress.XtraGrid.Columns.GridColumn DescrCentro;
        private DevExpress.XtraGrid.Columns.GridColumn Cuenta;
        private DevExpress.XtraGrid.Columns.GridColumn DescrCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn SaldoInicial;
        private DevExpress.XtraGrid.Columns.GridColumn Creditos;
        private DevExpress.XtraGrid.Columns.GridColumn Debitos;
        private DevExpress.XtraGrid.Columns.GridColumn SaldoFinal;
        private DevExpress.XtraEditors.CheckEdit chkSoloConMovimientos;
        private DevExpress.XtraEditors.SearchLookUpEdit slkuCentroCosto;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit3View;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupPeriodo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupCuentaContable;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}