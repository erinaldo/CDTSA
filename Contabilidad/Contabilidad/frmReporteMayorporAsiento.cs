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
    public partial class frmReporteMayorporAsiento : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtCentro = new DataTable();
        DataTable _dtCuenta = new DataTable();
        DataTable _dtTipoAsiento = new DataTable();

        public frmReporteMayorporAsiento()
        {
            InitializeComponent();
            this.Load += FrmReporteMayorporAsiento_Load;
        }

        private void FrmReporteMayorporAsiento_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                //Obtener los datos
                _dtCentro = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores
                _dtCuenta = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, -1).Tables[0];
                _dtTipoAsiento = TipoAsientoDAC.GetData().Tables[0];

                Util.Util.ConfigLookupEdit(this.slkupCentroDesde, _dtCentro, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroDesde, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCentroHasta, _dtCentro, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroHasta, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");


                Util.Util.ConfigLookupEdit(this.slkupCuentaDesde, _dtCuenta, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaDesde, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentaHasta, _dtCuenta, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaHasta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupTipoAsiento, _dtTipoAsiento, "Descr", "Tipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoAsiento, "[{'ColumnCaption':'Tipo','ColumnField':'Tipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");


                DateTime fechatemp = DateTime.Today;
                this.dtpFechaDesde.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                this.dtpFechaHasta.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);


             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}