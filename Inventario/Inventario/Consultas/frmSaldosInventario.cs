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
        private DateTime Fecha, FechaInicial, FechaFinal;
        private int  IDLote, IDBodega;
        private long IDProducto;

        private DataTable DTProducto;
        private DataTable DTLote;
        private DataTable DTBodega;

        public frmSaldosInventario()
        {
            InitializeComponent();
        }

        private void frmSaldosInventario_Load(object sender, EventArgs e)
        {
            sProductos = sLotes = sBodegas = sClasif1 = sClasif2 = sClasif3 = sClasif4 = sClasif5 = sClasif6  = "*";
            bDetallaLote = true;
            Fecha = DateTime.Now;
            FechaInicial = DateTime.Now.AddMonths(-1);
            FechaFinal = DateTime.Now;
            this.dtpFecha.EditValue = Fecha;
            this.dtpFechaInicio.EditValue = FechaInicial;
            this.dtpFechaFinal.EditValue = FechaFinal;

            DTProducto = clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupProducto, DTProducto, "Descr", "IDProducto", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupProducto, "[{'ColumnCaption':'ID Producto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descr','ColumnField':'Descr','width':90}]");

            DTBodega = clsBodegaDAC.GetData(-1, "*", -1).Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupBodega, DTBodega, "Descr", "IDBodega", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodega, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            
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

        private bool ValidaDatos() { 
            String sMensaje ="";
            if (this.slkupProducto.EditValue == null || this.slkupProducto.EditValue.ToString() =="")
                sMensaje = " • Producto. \n\r";
            if (this.slkupBodega.EditValue == null || this.slkupBodega.EditValue.ToString() == "")
                sMensaje = " • Bodega \n\r";
            if (sMensaje!="")
            {
                MessageBox.Show("Por favor seleccione los siguientes campos: \n\r" + sMensaje); 
                return false;
            }else
                return true;

        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable DTExistencias  = new DataTable();

            Fecha = Convert.ToDateTime(this.dtpFecha.EditValue);
            FechaInicial = Convert.ToDateTime(this.dtpFechaInicio.EditValue);
            FechaFinal = Convert.ToDateTime(this.dtpFechaFinal.EditValue);

            if (this.cmbReporte.SelectedIndex == 0)
            {
                lytFechaCorte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.grRangoFecha.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                DTExistencias = clsExistenciaBodegaDAC.CorteInventario(Fecha, sBodegas, sProductos, sLotes, sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6, bDetallaLote).Tables[0];
            }
            else if (this.cmbReporte.SelectedIndex == 1 || this.cmbReporte.SelectedIndex == 2)
            {
                //Recoger los datos
                if (ValidaDatos())
                {
                    lytFechaCorte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.grRangoFecha.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    IDProducto = (long)this.slkupProducto.EditValue;
                    IDLote = (this.slkupLote.EditValue ==  null|| this.slkupLote.EditValue.ToString() == "") ? -1 : (int)this.slkupLote.EditValue;
                    IDBodega = (int)this.slkupBodega.EditValue;
                    if (this.cmbReporte.SelectedIndex == 1)
                    {
                        DTExistencias = clsExistenciaBodegaDAC.MovimientoInventario(FechaInicial, FechaFinal, IDBodega, IDProducto, IDLote).Tables[0];
                    }
                    else if (this.cmbReporte.SelectedIndex == 2)
                    {
                        DTExistencias = clsExistenciaBodegaDAC.KardexInventario(FechaInicial, FechaFinal, IDBodega, IDProducto, IDLote).Tables[0];
                    }
                }
                else
                    return;
            }
            //Limpiar las columnas
            this.gridView1.Columns.Clear();
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

        private void slkupProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupProducto.EditValue != null)
            {
                Util.Util.ConfigLookupEdit(this.slkupLote, clsLoteDAC.GetData(-1, Convert.ToInt32(slkupProducto.EditValue), "*", "*").Tables[0], "LoteProveedor", "IDLote", 350);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupLote, "[{'ColumnCaption':'IDLote','ColumnField':'IDLote','width':20},{'ColumnCaption':'Lote','ColumnField':'LoteProveedor','width':60},{'ColumnCaption':'F.V','ColumnField':'FechaVencimiento','width':20}]");

                this.slkupLote.Enabled = true;
            }
            else
            {
                this.slkupLote.Enabled = false;
            }
        }

        private void cmbReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbReporte.SelectedIndex == 0)
            {
                lytFechaCorte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.grRangoFecha.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else if (this.cmbReporte.SelectedIndex == 1 || this.cmbReporte.SelectedIndex == 2)
            {
                lytFechaCorte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.grRangoFecha.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

 
    
    }
}
