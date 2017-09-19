using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;

namespace CG
{
    public partial class frmBalanceGeneral : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtCentroCosto;
        public frmBalanceGeneral()
        {
            InitializeComponent();
        }

        private void frmBalanceGeneral_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            DateTime fechatemp = DateTime.Today;
            this.dtpFechaInicial.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            this.dtpFechaFinal.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);


            _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores

            Util.Util.ConfigLookupEdit(this.slkupCentroCostoDesde, _dtCentroCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCostoDesde, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
            //this.chkTotalizarporSecciones.Checked = true;
            this.chkCalcularUtilidad.Checked = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Mostrar el reporte de Balance General
                String sMensaje = "";
                if (this.dtpFechaInicial.EditValue == null)
                    sMensaje = "  •Seleccione la fecha Inicial del Reporte \n\r ";
                if (this.dtpFechaFinal.EditValue == null)
                    sMensaje = "  •Seleccione la fecha final del Reporte \n\r ";
                if (sMensaje != "")
                {
                    MessageBox.Show("Han ocurrido los siguientes errores: \n\r " + sMensaje);
                    return;
                }




                DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reporte/ReportesFinancieros/Plantilla/rptBalanceGeneral.repx", true);
                //Reporte.Asiento.rptAsiento report = new Reporte.Asiento.rptAsiento();
                
                SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;
                
               

                SqlDataSource ds = report.DataSource as SqlDataSource;

                ds.ConnectionName = "sqlDataSource1";
                String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
                ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.Windows);



                // Obtain a parameter, and set its value.
                report.Parameters["PFechaInicial"].Value = Convert.ToDateTime(this.dtpFechaInicial.EditValue);
                report.Parameters["PFechaFinal"].Value = Convert.ToDateTime(this.dtpFechaFinal.EditValue);
                report.Parameters["Moneda"].Value = (this.rgMoneda.SelectedIndex == 0) ? "L" : "D";

                // Show the report's print preview.
                DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                tool.ShowPreview();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

   

        
    }
}