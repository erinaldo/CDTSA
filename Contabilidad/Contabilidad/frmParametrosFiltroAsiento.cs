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
    public partial class frmParametrosFiltroAsiento : DevExpress.XtraEditors.XtraForm
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public String ModuloFuente { get; set; }
        public String TipoAsiento { get; set; }
        public bool Mayorizado { get; set; }
        public bool Anulado { get; set; }
        public bool CuadreTemporal { get; set; }

        public frmParametrosFiltroAsiento()
        {
            InitializeComponent();
            this.Load += FrmParametrosFiltroAsiento_Load;
        }

        private void FrmParametrosFiltroAsiento_Load(object sender, EventArgs e)
        {
            //Inicializar Fechas
            this.dtpDesde.EditValue = DateTime.Now.AddDays(-15);
            this.dtpHasta.EditValue = DateTime.Now;

            CargarTipoAsiento();

        }

        private void CargarTipoAsiento()
        {
            this.lstchkTipoAsiento.DataSource = TipoAsientoDAC.GetData().Tables[0];
            this.lstchkTipoAsiento.ValueMember = "Tipo";
            this.lstchkTipoAsiento.DisplayMember = "Descr";
        }

        private void CargarModuloFuente()
        {
            
        }

        private void chkMayorizado_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.chkMayorizado.EditValue) == true)
            {
                this.chkCuadreTemporal.EditValue = false;
                this.chkCuadreTemporal.Enabled = false;
            }
            else
            {
                this.chkCuadreTemporal.EditValue = false;
                this.chkCuadreTemporal.Enabled = true;
            }
        }


        private void ObtenerFiltro()
        {
            this.FechaInicial = (DateTime)this.dtpDesde.EditValue;
            this.FechaFinal = (DateTime)this.dtpHasta.EditValue;

            this.Anulado = (bool)this.chkAnulado.EditValue;
            this.CuadreTemporal = (bool)this.chkCuadreTemporal.EditValue;
            this.Mayorizado = (bool)this.chkMayorizado.EditValue;

            String sTiposAsiento = "";
            String sCaracterConcatenacion = "∞";
            //Tratar los tipos de Asiento
            foreach (System.Data.DataRowView item in this.lstchkTipoAsiento.CheckedItems)
            {
                sTiposAsiento += (item["Tipo"].ToString() + sCaracterConcatenacion);
            }

            if (sTiposAsiento.Length > 0)
                sTiposAsiento = sTiposAsiento.Substring(0, sTiposAsiento.Length - 1);

            this.TipoAsiento = sTiposAsiento;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ObtenerFiltro();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}