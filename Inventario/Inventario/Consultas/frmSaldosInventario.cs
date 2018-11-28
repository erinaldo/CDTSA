using CI.DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CI.Consultas
{
    public partial class frmSaldosInventario : Form
    {
       
        private String sProductos = "";
        private String sLotes = "";
        private String sBodegas = "";
        private String sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6;
        private bool bDetallaLote;
        private DateTime Fecha;


        public frmSaldosInventario()
        {
            InitializeComponent();
        }

        private void frmSaldosInventario_Load(object sender, EventArgs e)
        {
            sProductos = sLotes = sBodegas = sClasif1 = sClasif2 = sClasif3 = sClasif4 = sClasif5 = sClasif6  = "*";
            bDetallaLote = true;
            Fecha = DateTime.Now;
            this.dtpFecha.EditValue = Fecha;
        }

        private void btnFiltrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFiltroConsultaExistencia ofrmFiltro = new frmFiltroConsultaExistencia("SaldosInventario", sProductos, sLotes, sBodegas, sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6,"*","*","*","*",Fecha,Fecha, bDetallaLote);
               ofrmFiltro.FormClosed += ofrmFiltro_FormClosed;
            ofrmFiltro.ShowDialog();
        }

        void ofrmFiltro_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFiltroConsultaExistencia ofrm = (frmFiltroConsultaExistencia)sender;
            if (ofrm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.sProductos = ofrm.getLstFiltro("Producto");
                this.sLotes = ofrm.getLstFiltro("Lote");
                this.sBodegas = ofrm.getLstFiltro("Bodega");
                this.sClasif1 = ofrm.getLstFiltro("Clasif1");
                this.sClasif2 = ofrm.getLstFiltro("Clasif2");
                this.sClasif3 = ofrm.getLstFiltro("Clasif3");
                this.sClasif4 = ofrm.getLstFiltro("Clasif4");
                this.sClasif5 = ofrm.getLstFiltro("Clasif5");
                this.sClasif6 = ofrm.getLstFiltro("Clasif6");
     
                this.bDetallaLote = ofrm.DetallaLote;

            }
            
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Fecha = Convert.ToDateTime(this.dtpFecha.EditValue);
            DataTable DTExistencias = clsExistenciaBodegaDAC.CorteInventario(Fecha,sBodegas, sProductos, sLotes, sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6,bDetallaLote).Tables[0];
            this.dtgSaldos.DataSource = DTExistencias;
            this.dtgSaldos.Refresh();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "SaldosInventario.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Saldos"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

 
    
    }
}
