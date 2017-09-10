namespace CG
{
    partial class frmRelacionCuentaGrupoEstadosFinancieros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelacionCuentaGrupoEstadosFinancieros));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbGrupoEstadoFinanciero = new DevExpress.XtraEditors.ComboBoxEdit();
            this.treeCuenta = new DevExpress.XtraTreeList.TreeList();
            this.ColumnCuenta = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnDescr = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnIDCuenta = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnIdGrupo2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Tag = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeGrupoCuenta = new DevExpress.XtraTreeList.TreeList();
            this.ColumnCuentaG = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnDescrG = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.IDCuenta = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnIDGrupo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrupoEstadoFinanciero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeGrupoCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmbGrupoEstadoFinanciero);
            this.layoutControl1.Controls.Add(this.treeCuenta);
            this.layoutControl1.Controls.Add(this.treeGrupoCuenta);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(857, 409);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbGrupoEstadoFinanciero
            // 
            this.cmbGrupoEstadoFinanciero.Location = new System.Drawing.Point(187, 12);
            this.cmbGrupoEstadoFinanciero.Name = "cmbGrupoEstadoFinanciero";
            this.cmbGrupoEstadoFinanciero.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGrupoEstadoFinanciero.Properties.Items.AddRange(new object[] {
            "Balanza de Comprobación",
            "Estado de Resultado",
            "Balance General"});
            this.cmbGrupoEstadoFinanciero.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbGrupoEstadoFinanciero.Size = new System.Drawing.Size(214, 20);
            this.cmbGrupoEstadoFinanciero.StyleController = this.layoutControl1;
            this.cmbGrupoEstadoFinanciero.TabIndex = 6;
            this.cmbGrupoEstadoFinanciero.SelectedIndexChanged += new System.EventHandler(this.cmbGrupoEstadoFinanciero_SelectedIndexChanged);
            // 
            // treeCuenta
            // 
            this.treeCuenta.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColumnCuenta,
            this.ColumnDescr,
            this.columnIDCuenta,
            this.ColumnIdGrupo2,
            this.Tag});
            this.treeCuenta.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeCuenta.KeyFieldName = "IDCuenta";
            this.treeCuenta.Location = new System.Drawing.Point(456, 28);
            this.treeCuenta.Name = "treeCuenta";
            this.treeCuenta.OptionsBehavior.Editable = false;
            this.treeCuenta.OptionsDragAndDrop.AcceptOuterNodes = true;
            this.treeCuenta.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Multiple;
            this.treeCuenta.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Standard;
            this.treeCuenta.OptionsSelection.MultiSelect = true;
            this.treeCuenta.ParentFieldName = "IDCuentaMayor";
            this.treeCuenta.PreviewFieldName = "IDCuenta";
            this.treeCuenta.Size = new System.Drawing.Size(389, 369);
            this.treeCuenta.TabIndex = 5;
            // 
            // ColumnCuenta
            // 
            this.ColumnCuenta.Caption = "Cuenta";
            this.ColumnCuenta.FieldName = "Cuenta";
            this.ColumnCuenta.Name = "ColumnCuenta";
            this.ColumnCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.ColumnCuenta.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ColumnCuenta.Visible = true;
            this.ColumnCuenta.VisibleIndex = 0;
            this.ColumnCuenta.Width = 173;
            // 
            // ColumnDescr
            // 
            this.ColumnDescr.Caption = "Descripción";
            this.ColumnDescr.FieldName = "Descripcion";
            this.ColumnDescr.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.ColumnDescr.Name = "ColumnDescr";
            this.ColumnDescr.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.ColumnDescr.Visible = true;
            this.ColumnDescr.VisibleIndex = 1;
            this.ColumnDescr.Width = 198;
            // 
            // columnIDCuenta
            // 
            this.columnIDCuenta.Caption = "IDCuenta";
            this.columnIDCuenta.FieldName = "IDCuenta";
            this.columnIDCuenta.Name = "columnIDCuenta";
            // 
            // ColumnIdGrupo2
            // 
            this.ColumnIdGrupo2.Caption = "IDGrupo";
            this.ColumnIdGrupo2.FieldName = "IDGrupo";
            this.ColumnIdGrupo2.Name = "ColumnIdGrupo2";
            // 
            // Tag
            // 
            this.Tag.Caption = "Tag";
            this.Tag.FieldName = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.Width = 85;
            // 
            // treeGrupoCuenta
            // 
            this.treeGrupoCuenta.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColumnCuentaG,
            this.ColumnDescrG,
            this.IDCuenta,
            this.ColumnIDGrupo});
            this.treeGrupoCuenta.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeGrupoCuenta.KeyFieldName = "";
            this.treeGrupoCuenta.Location = new System.Drawing.Point(12, 52);
            this.treeGrupoCuenta.Name = "treeGrupoCuenta";
            this.treeGrupoCuenta.OptionsBehavior.Editable = false;
            this.treeGrupoCuenta.OptionsDragAndDrop.AcceptOuterNodes = true;
            this.treeGrupoCuenta.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Multiple;
            this.treeGrupoCuenta.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Standard;
            this.treeGrupoCuenta.OptionsSelection.MultiSelect = true;
            this.treeGrupoCuenta.ParentFieldName = "";
            this.treeGrupoCuenta.RootValue = 1;
            this.treeGrupoCuenta.Size = new System.Drawing.Size(389, 345);
            this.treeGrupoCuenta.TabIndex = 4;

            // 
            // ColumnCuentaG
            // 
            this.ColumnCuentaG.Caption = "Cuenta";
            this.ColumnCuentaG.FieldName = "Cuenta";
            this.ColumnCuentaG.Name = "ColumnCuentaG";
            this.ColumnCuentaG.Visible = true;
            this.ColumnCuentaG.VisibleIndex = 0;
            this.ColumnCuentaG.Width = 141;
            // 
            // ColumnDescrG
            // 
            this.ColumnDescrG.Caption = "Descripción";
            this.ColumnDescrG.FieldName = "Descripcion";
            this.ColumnDescrG.Name = "ColumnDescrG";
            this.ColumnDescrG.SortOrder = System.Windows.Forms.SortOrder.Descending;
            this.ColumnDescrG.Visible = true;
            this.ColumnDescrG.VisibleIndex = 1;
            this.ColumnDescrG.Width = 230;
            // 
            // IDCuenta
            // 
            this.IDCuenta.Caption = "IDCuenta";
            this.IDCuenta.FieldName = "IDCuenta";
            this.IDCuenta.Name = "IDCuenta";
            // 
            // ColumnIDGrupo
            // 
            this.ColumnIDGrupo.Caption = "IDGrupo";
            this.ColumnIDGrupo.FieldName = "IDGrupo";
            this.ColumnIDGrupo.Name = "ColumnIDGrupo";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(857, 409);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeGrupoCuenta;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(393, 365);
            this.layoutControlItem1.Text = "Cuenta - Grupo Estados Financieros";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(172, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.treeCuenta;
            this.layoutControlItem2.Location = new System.Drawing.Point(444, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(393, 389);
            this.layoutControlItem2.Text = "Cuentas Contables";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(172, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(393, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(51, 389);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmbGrupoEstadoFinanciero;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(393, 24);
            this.layoutControlItem3.Text = "Grupo Estados Financieros:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(172, 13);
            // 
            // frmRelacionCuentaGrupoEstadosFinancieros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 409);
            this.Controls.Add(this.layoutControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelacionCuentaGrupoEstadosFinancieros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relación Cuenta - Grupo Estados Financieros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRelacionCuentaGrupoEstadosFinancieros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrupoEstadoFinanciero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeGrupoCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraTreeList.TreeList treeCuenta;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnCuenta;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnDescr;
        private DevExpress.XtraTreeList.TreeList treeGrupoCuenta;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnCuentaG;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnDescrG;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Tag;
        private DevExpress.XtraTreeList.Columns.TreeListColumn IDCuenta;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnIDCuenta;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnIDGrupo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnIdGrupo2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbGrupoEstadoFinanciero;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

    }
}