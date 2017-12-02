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
    public partial class frmReporteDelMayor : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dtCentroCosto;
        private DataTable _dtCuentaContable;
        public frmReporteDelMayor()
        {
            InitializeComponent();
            this.Load += FrmReporteDelMayor_Load;
        }

        private void FrmReporteDelMayor_Load(object sender, EventArgs e)
        {
            try
            {

                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                //Obtener los datos
                _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores
                _dtCuentaContable = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*","*", "*", -1, -1, -1, 1, -1, -1).Tables[0];

                Util.Util.ConfigLookupEdit(this.slkupCentoCostoDesde, _dtCentroCosto, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentoCostoDesde, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCentroCostoHasta, _dtCentroCosto, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCostoHasta, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            
                Util.Util.ConfigLookupEdit(this.slkupCuentaContableDesde, _dtCuentaContable, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaContableDesde, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentaContableHasta, _dtCuentaContable, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaContableHasta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                
                this.rbTotalesDiarios.Checked = true;
                this.rgImprimirCuentas.SelectedIndex = 0;
                this.rgCuentasSinMovimientos.SelectedIndex = 0;
                this.chkActivo.Checked = true;
                this.chkPasivo.Checked = true;
                this.chkGasto.Checked = true;
                this.chkIngreso.Checked = true;
                this.chkOrden.Checked = true;
                this.chkPatrimonio.Checked = true;

                DateTime fechatemp = DateTime.Today;
                this.dtpFechaDesde.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                if (fechatemp.Month + 1 < 13)
                { this.dtpFechaHasta.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1); }
                else
                { this.dtpFechaHasta.EditValue = new DateTime(fechatemp.Year + 1, 1, 1).AddDays(-1); }

                this.rgCuentasSinMovimientos.SelectedIndex = 1;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}