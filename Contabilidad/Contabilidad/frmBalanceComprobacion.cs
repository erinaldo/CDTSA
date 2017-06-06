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

                Util.Util.ConfigLookupEdit(this.slkupCentroCosto, _dtCentroCosto, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCosto, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentasDesde, _dtCuentaContable, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentasDesde, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentasHasta, _dtCuentaContable, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentasHasta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

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

        private void chkSoloCuentadeMayor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSoloCuentadeMayor.Checked == true)
            {
                this.chkDetalleMovimiento.Enabled = false;
                this.chkDetalleMovimiento.Checked = false;
            }
            else
            {
                this.chkDetalleMovimiento.Enabled = true;
                this.chkDetalleMovimiento.Checked = true;
            }
        }

        private void chkDetalleMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDetalleMovimiento.Checked == true)
            {
                this.chkSoloCuentadeMayor.Enabled = false;
                this.chkSoloCuentadeMayor.Checked = false;
            }
            else
            {
                this.chkSoloCuentadeMayor.Enabled = true;
                this.chkSoloCuentadeMayor.Checked = true;
            }
        }
    }
}