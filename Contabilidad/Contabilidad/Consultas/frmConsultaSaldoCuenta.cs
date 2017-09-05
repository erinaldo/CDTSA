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

            _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*",-1).Tables[0]; //No estamos tomando los acumuladores

            Util.Util.ConfigLookupEdit(this.slkupCentroCosto, _dtCentroCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCosto, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //Validar los datos
            
            int idCentro =  (this.slkupCentroCosto.EditValue== null) ? -1: Convert.ToInt32( this.slkupCentroCosto.EditValue);

            DataSet DS = new DataSet();
            DataTable dtConsolidado = new DataTable();
            DataTable dtDetallado = new DataTable();
            DS = ConsultasDAC.GetSaldosByCentroCuenta(-1, idCentro, Convert.ToDateTime(this.dtDesde.EditValue), Convert.ToDateTime(this.dtHasta.EditValue));
            dtConsolidado = DS.Tables[0];
            dtDetallado = DS.Tables[1];

            if (dtConsolidado.Rows.Count > 0)
            {
                this.txtSaldoInicial.Text = dtConsolidado.Rows[0]["SaldoAnterior"].ToString();
                this.txtSaldoFinal.Text = dtConsolidado.Rows[0]["Saldo"].ToString();
                this.txtTotalCredito.Text = dtConsolidado.Rows[0]["Credito"].ToString();
                this.txtTotalDebitos.Text = dtConsolidado.Rows[0]["Debito"].ToString();
            }
            this.grid.DataSource = dtDetallado;
        }
    }
}