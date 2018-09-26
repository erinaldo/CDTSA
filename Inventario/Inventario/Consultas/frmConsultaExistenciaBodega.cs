using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CI.DAC;

namespace CI
{
    public partial class frmConsultaExistenciaBodega : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String sProductos = "";
        private String sLotes = "";
        private String sBodegas = "";
        private String sClasif1,sClasif2, sClasif3, sClasif4, sClasif5, sClasif6;
        private bool bDetallaLote;

        public frmConsultaExistenciaBodega()
        {
            InitializeComponent();
        }

        private void frmConsultaExistenciaBodega_Load(object sender, EventArgs e)
        {
            sProductos = sLotes = sBodegas = sClasif1 = sClasif2 = sClasif3 = sClasif4 = sClasif5 = sClasif6 = "*";
            bDetallaLote = true;
        }

        private void btnFiltrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFiltroConsultaExistencia ofrmFiltro = new frmFiltroConsultaExistencia("Existencia",sProductos,sLotes,sBodegas,sClasif1,sClasif2,sClasif3,sClasif4,sClasif5,sClasif6,"","","","",DateTime.Now,DateTime.Now,bDetallaLote);
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
            if (!bDetallaLote)
            {
                this.gridViewConsultaExistencia.Columns[4].Visible = false;
                this.gridViewConsultaExistencia.Columns[5].Visible = false;
                this.gridViewConsultaExistencia.Columns[6].Visible = false;
                this.gridViewConsultaExistencia.Columns[7].Visible = false;
                this.gridViewConsultaExistencia.Columns[8].Visible = false;

            }
            else {
                this.gridViewConsultaExistencia.Columns[4].Visible = true;
                this.gridViewConsultaExistencia.Columns[5].Visible = true;
                this.gridViewConsultaExistencia.Columns[6].Visible = true;
                this.gridViewConsultaExistencia.Columns[7].Visible = true;
                this.gridViewConsultaExistencia.Columns[8].Visible = true;
            }
            DataTable DTExistencias =  clsExistenciaBodegaDAC.GetExistenciaBodegaByClasificacion(sBodegas, sProductos, sLotes, sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6,bDetallaLote).Tables[0];
            this.dtgConsultaExistencia.DataSource = DTExistencias;
            this.dtgConsultaExistencia.Refresh();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "Existencias.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Existencias"
            };


            this.gridViewConsultaExistencia.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";           
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }
    }
}
