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
    public partial class frmConsultaSaldoCentro : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable _dtCuenta = new DataTable();
        public frmConsultaSaldoCentro()
        {
            InitializeComponent();
            this.Load += FrmConsultaSaldoCentro_Load;
        }

        private void FrmConsultaSaldoCentro_Load(object sender, EventArgs e)
        {
            DateTime fechatemp = DateTime.Today;
            this.dtpFechaInicial.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            this.dtpFechaFinal.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);


            _dtCuenta = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, -1).Tables[0];
           
            Util.Util.ConfigLookupEdit(this.slkupCuenta, _dtCuenta, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuenta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

        }
    }
}