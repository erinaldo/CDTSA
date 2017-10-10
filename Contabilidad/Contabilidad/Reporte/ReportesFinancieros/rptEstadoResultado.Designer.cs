namespace CG.Reporte.ReportesFinancieros
{
    partial class rptEstadoResultado
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptEstadoResultado));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.BOLDACUMULADOR = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.FechaFinal = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.FechaInicial = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Moneda = new DevExpress.XtraReports.Parameters.Parameter();
            this.UtilidadNeta = new DevExpress.XtraReports.UI.CalculatedField();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.SaldoPositivo = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.CostoVenta = new DevExpress.XtraReports.UI.CalculatedField();
            this.Ingresos = new DevExpress.XtraReports.UI.CalculatedField();
            this.UtilidadBruta = new DevExpress.XtraReports.UI.CalculatedField();
            this.GastoAdministrativos = new DevExpress.XtraReports.UI.CalculatedField();
            this.GastosVenta = new DevExpress.XtraReports.UI.CalculatedField();
            this.UtilidadOperativa = new DevExpress.XtraReports.UI.CalculatedField();
            this.ImpuestoSobreRenta = new DevExpress.XtraReports.UI.CalculatedField();
            this.BaseReporte = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.Visible = false;
            // 
            // BOLDACUMULADOR
            // 
            this.BOLDACUMULADOR.Condition = "[Acumulador]=1";
            // 
            // 
            // 
            this.BOLDACUMULADOR.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOLDACUMULADOR.Name = "BOLDACUMULADOR";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 22.91667F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "StringConexion";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "cntrpEstadoResultado";
            queryParameter1.Name = "@FechaInicial";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.FechaInicial]", typeof(System.DateTime));
            queryParameter2.Name = "@FechaFinal";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.FechaFinal]", typeof(System.DateTime));
            queryParameter3.Name = "@Moneda";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.Moneda]", typeof(string));
            queryParameter4.Name = "@BaseReporte";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.BaseReporte]", typeof(int));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.StoredProcName = "cntrpEstadoResultado";
            customSqlQuery1.Name = "DatosGenerales";
            customSqlQuery1.Sql = "Select Nombre,Telefono,Logo  from globalCompania\r\n";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.pageFooterBand1.HeightF = 29F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(6F, 6F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StyleName = "PageInfo";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Format = "Page {0} of {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(331F, 6F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrPictureBox1,
            this.xrLabel20});
            this.reportHeaderBand1.HeightF = 157.25F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrLabel11
            // 
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(302.0833F, 74.95833F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(45.83333F, 23F);
            this.xrLabel11.Text = "Hasta:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(178.375F, 74.95833F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(45.83333F, 23F);
            this.xrLabel4.Text = "Desde:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.FechaFinal, "Text", "")});
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(224.2083F, 74.95833F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(73.95833F, 23F);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // FechaFinal
            // 
            this.FechaFinal.Description = "FechaFinal";
            this.FechaFinal.Name = "FechaFinal";
            this.FechaFinal.Type = typeof(System.DateTime);
            this.FechaFinal.ValueInfo = "09/19/2017 19:14:04";
            this.FechaFinal.Visible = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.FechaInicial, "Text", "")});
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(347.9167F, 74.95833F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // FechaInicial
            // 
            this.FechaInicial.Name = "FechaInicial";
            this.FechaInicial.Type = typeof(System.DateTime);
            this.FechaInicial.ValueInfo = "07/19/2017 19:13:00";
            this.FechaInicial.Visible = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DatosGenerales.Nombre")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(6.00001F, 6.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(638F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "DatosGenerales.Logo")});
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.00001F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(136.375F, 117.2916F);
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(6.00001F, 36.20834F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(638F, 23.625F);
            this.xrLabel20.StyleName = "Title";
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Estado de Resultado";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Maroon;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Maroon;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // Moneda
            // 
            this.Moneda.Name = "Moneda";
            this.Moneda.ValueInfo = "L";
            this.Moneda.Visible = false;
            // 
            // UtilidadNeta
            // 
            this.UtilidadNeta.Expression = "[UtilidadOperativa]-Iif(IsNull([ImpuestoSobreRenta]),0,[ImpuestoSobreRenta])";
            this.UtilidadNeta.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.UtilidadNeta.Name = "UtilidadNeta";
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // SaldoPositivo
            // 
            this.SaldoPositivo.DataMember = "cntrpEstadoResultado";
            this.SaldoPositivo.Expression = "abs([Saldo])";
            this.SaldoPositivo.Name = "SaldoPositivo";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5});
            this.GroupHeader1.HeightF = 296.875F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(36.37498F, 268.6667F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(159.375F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "UTILIDAD NETA";
            // 
            // xrLabel22
            // 
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(36.37498F, 235.25F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(159.375F, 23F);
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Impuesto sobre la Renta";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(36.37498F, 201.9583F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(159.375F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "UTILIDAD OPERATIVA";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(36.37498F, 167.5417F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(137.5F, 23F);
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Gasto de Ventas";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(36.37498F, 124.9583F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(137.5F, 23F);
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Gastos Administrativos";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(36.37498F, 85.37499F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(123.9583F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "UTILIDAD BRUTA";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(36.37498F, 46.45834F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Costo de Venta";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(36.37502F, 10.00001F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Ingresos";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UtilidadNeta")});
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(219F, 268.6667F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            xrSummary1.IgnoreNullValues = true;
            this.xrLabel13.Summary = xrSummary1;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ImpuestoSobreRenta", "{0:n2}")});
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(219F, 235.25F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel12.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UtilidadOperativa")});
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(219F, 201.9583F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "GastosVenta")});
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(219F, 167.5417F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "GastoAdministrativos")});
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(219F, 124.9583F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel8.Text = "xrLabel8";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UtilidadBruta")});
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(219F, 85.37499F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel7.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Ingresos")});
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(219F, 10.00001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel6.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CostoVenta")});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(219F, 46.45834F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.Text = "xrLabel5";
            // 
            // CostoVenta
            // 
            this.CostoVenta.Expression = "[cntrpEstadoResultado][[DescrTipo] == \'COSTOS\' and [Acumulador]=0].Sum([Saldo])";
            this.CostoVenta.Name = "CostoVenta";
            // 
            // Ingresos
            // 
            this.Ingresos.Expression = "[cntrpEstadoResultado][[DescrTipo] == \'INGRESOS\'  And [Acumulador]=0].Sum([Saldo]" +
    ")";
            this.Ingresos.Name = "Ingresos";
            // 
            // UtilidadBruta
            // 
            this.UtilidadBruta.Expression = "[Ingresos]-[CostoVenta]";
            this.UtilidadBruta.Name = "UtilidadBruta";
            // 
            // GastoAdministrativos
            // 
            this.GastoAdministrativos.Expression = "[cntrpEstadoResultado][[DescrTipo] == \'GASTOS\'  And [Acumulador]=0 And [Grupo]==\'" +
    "ER02-01-00\'].Sum([Saldo])";
            this.GastoAdministrativos.Name = "GastoAdministrativos";
            // 
            // GastosVenta
            // 
            this.GastosVenta.Expression = "[cntrpEstadoResultado][[DescrTipo] == \'GASTOS\'  And [Acumulador]=0 And [Grupo]==\'" +
    "ER02-02-00\'].Sum([Saldo])";
            this.GastosVenta.Name = "GastosVenta";
            // 
            // UtilidadOperativa
            // 
            this.UtilidadOperativa.Expression = "[UtilidadBruta]-[GastoAdministrativos]-[GastosVenta]";
            this.UtilidadOperativa.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.UtilidadOperativa.Name = "UtilidadOperativa";
            // 
            // ImpuestoSobreRenta
            // 
            this.ImpuestoSobreRenta.Expression = "[cntrpEstadoResultado][[DescrTipo] == \'GASTOS\'  And [Acumulador]=0 And [Grupo]==\'" +
    "ER03-00-00\'].Sum([Saldo])";
            this.ImpuestoSobreRenta.Name = "ImpuestoSobreRenta";
            // 
            // BaseReporte
            // 
            this.BaseReporte.Description = "BaseReporte";
            this.BaseReporte.Name = "BaseReporte";
            this.BaseReporte.Type = typeof(int);
            this.BaseReporte.ValueInfo = "1";
            this.BaseReporte.Visible = false;
            // 
            // rptEstadoResultado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.GroupFooter1,
            this.GroupHeader1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.UtilidadNeta,
            this.SaldoPositivo,
            this.CostoVenta,
            this.Ingresos,
            this.UtilidadBruta,
            this.GastoAdministrativos,
            this.GastosVenta,
            this.UtilidadOperativa,
            this.ImpuestoSobreRenta});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "cntrpEstadoResultado";
            this.DataSource = this.sqlDataSource1;
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.BOLDACUMULADOR,
            this.formattingRule1});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 23, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FechaInicial,
            this.FechaFinal,
            this.Moneda,
            this.BaseReporte});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.PageFooterBand pageFooterBand1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.ReportHeaderBand reportHeaderBand1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.XtraReports.Parameters.Parameter FechaInicial;
        private DevExpress.XtraReports.Parameters.Parameter FechaFinal;
        private DevExpress.XtraReports.Parameters.Parameter Moneda;
        private DevExpress.XtraReports.UI.FormattingRule BOLDACUMULADOR;
        private DevExpress.XtraReports.UI.CalculatedField UtilidadNeta;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule1;
        private DevExpress.XtraReports.UI.CalculatedField SaldoPositivo;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.CalculatedField CostoVenta;
        private DevExpress.XtraReports.UI.CalculatedField Ingresos;
        private DevExpress.XtraReports.UI.CalculatedField UtilidadBruta;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.CalculatedField GastoAdministrativos;
        private DevExpress.XtraReports.UI.CalculatedField GastosVenta;
        private DevExpress.XtraReports.UI.CalculatedField UtilidadOperativa;
        private DevExpress.XtraReports.UI.CalculatedField ImpuestoSobreRenta;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.Parameters.Parameter BaseReporte;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
    }
}
