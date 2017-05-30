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
    public partial class frmConsultaSaldoCuenta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable _dtCentroCosto = new DataTable();
        public frmConsultaSaldoCuenta()
        {
            InitializeComponent();
            this.Load += FrmConsultaSaldoCuenta_Load;
        }

        private void FrmConsultaSaldoCuenta_Load(object sender, EventArgs e)
        {
            DateTime fechatemp = DateTime.Today;
            this.dtDesde.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            this.dtHasta.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);

            _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores

            Util.Util.ConfigLookupEdit(this.slkupCentroCosto, _dtCentroCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCosto, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
        }
    }
}