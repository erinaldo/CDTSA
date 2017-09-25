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
using Security;

namespace CG
{
    public partial class frmBalanceComprobacion : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dtCentroCosto;
        private DataTable _dtCuentaContable;
        private String sCuentasSelected = "";
        private String sCentrosSelected = "";

        public frmBalanceComprobacion()
        {
            InitializeComponent();
            this.Load += FrmBalanceComprobacion_Load;
        }

        private void FrmBalanceComprobacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                //Obtener los datos
                _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores
                _dtCuentaContable = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, -1).Tables[0];

                
                this.chkSoloCuentadeMayor.Checked = true;
                DateTime fechatemp = DateTime.Today;
                this.dtpFechaInicial.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                this.dtpFechaFinal.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);

                this.rgCuentasSinMovimientos.SelectedIndex = 1;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            MessageBox.Show(sCentrosSelected);
        }

        private void btnSelecctCuentasContables_Click(object sender, EventArgs e)
        {
            frmPopPupCuentaContable ofrmPopupCuenta = new frmPopPupCuentaContable();
            ofrmPopupCuenta.FormClosed += ofrmCuenta_FormClosed;
            ofrmPopupCuenta.sCuentasSelected = this.sCuentasSelected;
            ofrmPopupCuenta.Show();
        }

        void ofrmCuenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPopPupCuentaContable Cuenta = (frmPopPupCuentaContable)sender;
            sCuentasSelected = Cuenta.sCuentasSelected;
            MessageBox.Show(sCuentasSelected);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Obtener todas las variables
            int ConsolidadPorcuenta = 0;
            int IncluirAsientosDeDiario = 0;
            int SoloCuentasMayor =0;
            int CuentasSinMovimientos = 0;
            int Moneda = 0;

            if (this.chkConsilidarByCuenta.Checked == true)
                ConsolidadPorcuenta = 1;
            if (this.chkIncluirAsientosdeDiario.Checked == true)
                IncluirAsientosDeDiario = 1;
            if (this.chkSoloCuentadeMayor.Checked == true)
                SoloCuentasMayor = 1;
            CuentasSinMovimientos = this.rgCuentasSinMovimientos.SelectedIndex;
            Moneda = this.rgMonedas.SelectedIndex;
            String sUsuario =(UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
            //guarar los parametros de centros y Cuentas
            if (ReportesDAC.SetCuentaCentroReporte(sCuentasSelected, sCentrosSelected, 1, sUsuario)) { 
                //Mostrar el reporte
                    DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reporte/ReportesFinancieros/Plantilla/rptBalanceComrpobacion.repx", true);


                    // Obtain a parameter, and set its value.
                    report.Parameters["ConsolidadoByCuenta"].Value = ConsolidadPorcuenta;
                    report.Parameters["FechaInicial"].Value = Convert.ToDateTime(dtpFechaInicial.EditValue);
                    report.Parameters["FechaFinal"].Value = Convert.ToDateTime(dtpFechaFinal.EditValue);
                    report.Parameters["IDReporte"].Value = 1;
                    report.Parameters["IncluyeAsientoDeDiario"].Value = IncluirAsientosDeDiario;
                    report.Parameters["Moneda"].Value = Moneda;
                    report.Parameters["SoloCuentaMayor"].Value = SoloCuentasMayor;
                    report.Parameters["TipoCuentaMovimiento"].Value = CuentasSinMovimientos;
                    report.Parameters["Usuario"].Value = sUsuario;
                    // Show the report's print preview.
                    DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                    tool.ShowPreview();


            }

        }   

     
    }
}