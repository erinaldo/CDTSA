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
    public partial class frmEstadoResultado : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtCentroCosto = new DataTable();
        public frmEstadoResultado()
        {
            InitializeComponent();
            this.Load += FrmEstadoResultado_Load;
        }

        private void FrmEstadoResultado_Load(object sender, EventArgs e)
        {
            //Obtener los datos
            _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores

            DateTime fechatemp = DateTime.Today;
            this.dtFechaDesde.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            this.dtFechaHasta.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);

            Util.Util.ConfigLookupEdit(this.slkupCentroCostoDesde, _dtCentroCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCostoDesde, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCentroCostoHasta, _dtCentroCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCostoHasta, "[{'ColumnCaption':'Cuenta','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");


        }
    }
}