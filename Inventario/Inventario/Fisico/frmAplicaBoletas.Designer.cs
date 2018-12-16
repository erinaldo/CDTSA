namespace CI.Fisico
{
    partial class frmAplicaBoletas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAplicaBoletas));
            this.dtpFecha = new DevExpress.XtraEditors.DateEdit();
            this.chlProductosNoInventarioSetCero = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlProductosNoInventarioSetCero.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.EditValue = null;
            this.dtpFecha.Location = new System.Drawing.Point(74, 100);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFecha.Size = new System.Drawing.Size(119, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // chlProductosNoInventarioSetCero
            // 
            this.chlProductosNoInventarioSetCero.Location = new System.Drawing.Point(29, 145);
            this.chlProductosNoInventarioSetCero.Name = "chlProductosNoInventarioSetCero";
            this.chlProductosNoInventarioSetCero.Properties.Caption = "Los productos no inventariados, establecerlos a cero";
            this.chlProductosNoInventarioSetCero.Size = new System.Drawing.Size(278, 19);
            this.chlProductosNoInventarioSetCero.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha:";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(246, 88);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(89, 43);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Aplicar";

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aplicación de Bolestas de Inventario";
            // 
            // frmAplicaBoletas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 209);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chlProductosNoInventarioSetCero);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmAplicaBoletas";
            this.Text = "Aplicación de Boletas de Inventario";
            this.Load += new System.EventHandler(this.frmAplicaBoletas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlProductosNoInventarioSetCero.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtpFecha;
        private DevExpress.XtraEditors.CheckEdit chlProductosNoInventarioSetCero;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private System.Windows.Forms.Label label2;
    }
}