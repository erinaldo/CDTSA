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

                this.rbLocal.Checked = true;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}