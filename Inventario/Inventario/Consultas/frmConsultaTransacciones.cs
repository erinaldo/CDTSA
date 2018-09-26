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

namespace CI
{
    public partial class frmConsultaTransacciones : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String sProductos = "";
        private String sLotes = "";
        private String sBodegas = "";
        private String sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6, sAplicacion,sReferencia,sTransaccion,sPaquete;
        private bool bDetallaLote;
        private DateTime FechaInicial, FechaFinal;


        public frmConsultaTransacciones()
        {
            InitializeComponent();
        }

        private void frmConsultaTransacciones_Load(object sender, EventArgs e)
        {
            sProductos = sLotes = sBodegas = sClasif1 = sClasif2 = sClasif3 = sClasif4 = sClasif5 = sClasif6 =sAplicacion=sReferencia=sTransaccion=sPaquete = "*";
            bDetallaLote = true;
            FechaFinal = DateTime.Now;
            FechaInicial = DateTime.Now.AddMonths(-1);
        }

        private void btnFiltrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFiltroConsultaExistencia ofrmFiltro = new frmFiltroConsultaExistencia("Transacciones", sProductos, sLotes, sBodegas, sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6,sPaquete,sTransaccion,sReferencia,sAplicacion,FechaInicial,FechaFinal, bDetallaLote);
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
                this.FechaInicial = ofrm.GetFechaInicial();
                this.FechaFinal = ofrm.GetFechaFinal();
                this.sAplicacion = ofrm.GetAplicacion();
                this.sReferencia = ofrm.GetReferencia();
                this.sTransaccion = ofrm.getLstFiltro("Transaccion");
                this.sPaquete = ofrm.getLstFiltro("Paquete");
                this.bDetallaLote = ofrm.DetallaLote;

            }
            
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            DataTable DTExistencias = clsDocumentoInvCabecera.GetTransaccionesInventarioByCriterio(sBodegas, sProductos, sLotes, sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6,sTransaccion,sPaquete,sAplicacion,sReferencia,FechaInicial,FechaFinal).Tables[0];
            this.dtgDetalleTransacciones.DataSource = DTExistencias;
            this.dtgDetalleTransacciones.Refresh();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "Transacciones.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Transacciones"
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
