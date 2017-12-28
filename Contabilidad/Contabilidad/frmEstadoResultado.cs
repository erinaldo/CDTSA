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
using CG.DAC;
using DevExpress.DataAccess.Sql;
using Security;
using DevExpress.DataAccess.ConnectionParameters;

namespace CG
{
    public partial class frmEstadoResultado : DevExpress.XtraEditors.XtraForm
    {
        String sCentrosSelected = "";
        String sUsuario = "";
        DataTable _dtCentroCosto = new DataTable();

        public frmEstadoResultado()
        {
            InitializeComponent();
            this.Load += FrmEstadoResultado_Load;
        }

        private void FrmEstadoResultado_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            //Obtener los datos
            sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
               

            DateTime fechatemp = DateTime.Today;
            this.dtFechaDesde.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            if (fechatemp.Month + 1 < 13)
            { this.dtFechaHasta.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1); }
            else
            { this.dtFechaHasta.EditValue = new DateTime(fechatemp.Year + 1, 1, 1).AddDays(-1); }

            //Obtener los datos Filtrados
            sCentrosSelected = GetCentroCostosFiltrados();
           
        }


        private String GetCentroCostosFiltrados()
        {
            String sCostos = "";
            DataSet DS = new DataSet();
            DS = ReportesDAC.GetCentroCostoGlobalReporte(1, sUsuario);
            foreach (DataRow ele in DS.Tables[0].Rows)
            {
                sCostos = string.Format("{0}{1},", sCostos, ele["IDCentro"]);
            }
            if (sCostos != "")
                sCostos = sCostos.Substring(0, sCostos.Length - 1);
            return sCostos;
        }


        private void btnSelectCentrosCostos_Click(object sender, EventArgs e)
        {
            frmPopPupCentroCosto ofrmCentro = new frmPopPupCentroCosto();
            ofrmCentro.FormClosed += ofrmCentro_FormClosed;
            ofrmCentro.sCostosSelected = this.sCentrosSelected;
            ofrmCentro.Show();
        }

        void ofrmCentro_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPopPupCentroCosto Centro = (frmPopPupCentroCosto)sender;
            sCentrosSelected = Centro.sCostosSelected;
            // MessageBox.Show(sCentrosSelected);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Obtener todas las variables
            int BaseReporte = 0;
            int Moneda = 1;

            BaseReporte = Convert.ToInt32(this.rgBaseReporte.EditValue);
            Moneda = Convert.ToInt32(this.rgMoneda.EditValue);
            

            //guarar los parametros de centros y Cuentas
            if (ReportesDAC.SetCuentaCentroReporte("", sCentrosSelected, 1, sUsuario))
            {
                //Mostrar el reporte
                DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reporte/ReportesFinancieros/Plantilla/rptEstadoResultado.repx", true);

                SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;



                SqlDataSource ds = report.DataSource as SqlDataSource;

                ds.ConnectionName = "sqlDataSource1";
                String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
                ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);


                // Obtain a parameter, and set its value.
                
                report.Parameters["FechaInicial"].Value = Convert.ToDateTime(this.dtFechaDesde.EditValue);
                report.Parameters["FechaFinal"].Value = Convert.ToDateTime(this.dtFechaHasta.EditValue);
                report.Parameters["Moneda"].Value = Moneda;
                report.Parameters["BaseReporte"].Value = BaseReporte;
                
                // Show the report's print preview.
                DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                tool.ShowPreview();


            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}