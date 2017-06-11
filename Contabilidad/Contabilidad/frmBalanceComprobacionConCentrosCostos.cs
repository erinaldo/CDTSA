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
    public partial class frmBalanceComprobacionConCentrosCostos : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtCentroCosto;
        DataTable _dtCuentaContable;
        public frmBalanceComprobacionConCentrosCostos()
        {
            InitializeComponent();
            this.Load += FrmBalanceComprobacionConCentrosCostos_Load;
        }

        private void FrmBalanceComprobacionConCentrosCostos_Load(object sender, EventArgs e)
        {
            try{
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                DateTime fechatemp = DateTime.Today;
                this.dtpFechaInicial.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                this.dtpFechaFinal.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);


                _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores
                _dtCuentaContable = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, -1).Tables[0];

                Util.Util.ConfigLookupEdit(this.slkpCentroCostoDesde, _dtCentroCosto, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkpCentroCostoDesde, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                Util.Util.ConfigLookupEdit(this.slkupCentroCostoHasta, _dtCentroCosto, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCostoHasta, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentaContableDesde, _dtCuentaContable, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaContableDesde, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentaContableHasta, _dtCuentaContable, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaContableHasta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                this.dgMoneda.SelectedIndex = 0;
                this.dgCentroSinMovimiento.SelectedIndex = 1;
                this.rgCuentasSinMovimiento.SelectedIndex = 1;
                this.chkSolodeMayor.Checked = true;
                this.chkDetallarCuentasqueAceptenmovimietos.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}