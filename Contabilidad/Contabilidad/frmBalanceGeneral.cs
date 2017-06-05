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
    public partial class frmBalanceGeneral : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtCentroCosto;
        public frmBalanceGeneral()
        {
            InitializeComponent();
        }

        private void frmBalanceGeneral_Load(object sender, EventArgs e)
        {

            DateTime fechatemp = DateTime.Today;
            this.dtpFechaInicial.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            this.dtpFechaFinal.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);


            _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores

            Util.Util.ConfigLookupEdit(this.slkupCentroCostoDesde, _dtCentroCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCostoDesde, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
            this.chkTotalizarporSecciones.Checked = true;
            this.chkCalcularUtilidad.Checked = true;

        }
    }
}