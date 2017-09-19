namespace CG
{
    partial class frmBalanceGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalanceGeneral));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.slkupCentroCostoHasta = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.slkupCentroCostoDesde = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaInicial = new DevExpress.XtraEditors.DateEdit();
            this.dtpFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.rgMoneda = new DevExpress.XtraEditors.RadioGroup();
            this.chkSaldoAntesCierre = new DevExpress.XtraEditors.CheckEdit();
            this.chkCalcularUtilidad = new DevExpress.XtraEditors.CheckEdit();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCostoHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCostoDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaldoAntesCierre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCalcularUtilidad.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(12, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(454, 26);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Imprime el balance General para un rango de cuentas y para un rango de centros de" +
    " costos, segun la contabilidad, moneda y totalizado por secciones.";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.slkupCentroCostoHasta);
            this.groupControl1.Controls.Add(this.slkupCentroCostoDesde);
            this.groupControl1.Location = new System.Drawing.Point(495, 70);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(475, 105);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Centros de Costos";
            this.groupControl1.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Hasta:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Desde:";
            // 
            // slkupCentroCostoHasta
            // 
            this.slkupCentroCostoHasta.Location = new System.Drawing.Point(56, 61);
            this.slkupCentroCostoHasta.Name = "slkupCentroCostoHasta";
            this.slkupCentroCostoHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupCentroCostoHasta.Properties.View = this.searchLookUpEdit2View;
            this.slkupCentroCostoHasta.Size = new System.Drawing.Size(402, 20);
            this.slkupCentroCostoHasta.TabIndex = 1;
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // slkupCentroCostoDesde
            // 
            this.slkupCentroCostoDesde.Location = new System.Drawing.Point(56, 34);
            this.slkupCentroCostoDesde.Name = "slkupCentroCostoDesde";
            this.slkupCentroCostoDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupCentroCostoDesde.Properties.View = this.searchLookUpEdit1View;
            this.slkupCentroCostoDesde.Size = new System.Drawing.Size(402, 20);
            this.slkupCentroCostoDesde.TabIndex = 0;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(37, 79);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Rango de Fechas:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.EditValue = null;
            this.dtpFechaInicial.Location = new System.Drawing.Point(141, 76);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaInicial.Size = new System.Drawing.Size(116, 20);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.EditValue = null;
            this.dtpFechaFinal.Location = new System.Drawing.Point(304, 76);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaFinal.Size = new System.Drawing.Size(116, 20);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.rgMoneda);
            this.groupControl2.Location = new System.Drawing.Point(37, 122);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(151, 100);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Moneda";
            // 
            // rgMoneda
            // 
            this.rgMoneda.Location = new System.Drawing.Point(13, 30);
            this.rgMoneda.Name = "rgMoneda";
            this.rgMoneda.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Local"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Dolar")});
            this.rgMoneda.Size = new System.Drawing.Size(100, 54);
            this.rgMoneda.TabIndex = 0;
            // 
            // chkSaldoAntesCierre
            // 
            this.chkSaldoAntesCierre.Location = new System.Drawing.Point(408, 133);
            this.chkSaldoAntesCierre.Name = "chkSaldoAntesCierre";
            this.chkSaldoAntesCierre.Properties.Caption = "Saldo antes de cierre";
            this.chkSaldoAntesCierre.Size = new System.Drawing.Size(137, 19);
            this.chkSaldoAntesCierre.TabIndex = 5;
            this.chkSaldoAntesCierre.Visible = false;
            // 
            // chkCalcularUtilidad
            // 
            this.chkCalcularUtilidad.Location = new System.Drawing.Point(408, 158);
            this.chkCalcularUtilidad.Name = "chkCalcularUtilidad";
            this.chkCalcularUtilidad.Properties.Caption = "Calcular Utilidad";
            this.chkCalcularUtilidad.Size = new System.Drawing.Size(137, 19);
            this.chkCalcularUtilidad.TabIndex = 5;
            this.chkCalcularUtilidad.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(154, 255);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(261, 255);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmBalanceGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 307);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chkCalcularUtilidad);
            this.Controls.Add(this.chkSaldoAntesCierre);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBalanceGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance General";
            this.Load += new System.EventHandler(this.frmBalanceGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCostoHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupCentroCostoDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaldoAntesCierre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCalcularUtilidad.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupCentroCostoHasta;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupCentroCostoDesde;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtpFechaInicial;
        private DevExpress.XtraEditors.DateEdit dtpFechaFinal;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.RadioGroup rgMoneda;
        private DevExpress.XtraEditors.CheckEdit chkSaldoAntesCierre;
        private DevExpress.XtraEditors.CheckEdit chkCalcularUtilidad;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}