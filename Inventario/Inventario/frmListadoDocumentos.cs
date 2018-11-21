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
    public partial class frmListadoDocumentos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataSet _dsProducto;
        private DataTable _dtProducto;

        DataRow _currentRow = null;
        const String _tituloVentana = "Listado de Documentos";

        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += BtnAgregar_ItemClick;
            this.btnEditar.ItemClick += BtnEditar_ItemClick;
            this.btnEliminar.ItemClick += BtnEliminar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstDocumentos.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Documentos"
            };


            this.gridView.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        
        private void BtnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Validar que el paquete no este aplicado

        }

        private void BtnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarElementoSeleccionado();
        }

        private void BtnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //validar que el paquete este seleccionado
            if (this.slkupPaquete.EditValue != null) {
                int IDPaquete = (int)this.slkupPaquete.EditValue;
                frmDocumentoInv ofrmDocumento = new frmDocumentoInv(IDPaquete);
                ofrmDocumento.ShowDialog();
            }
        }



        public frmListadoDocumentos()
        {
            InitializeComponent();
        }

        private void frmListadoDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridView.FocusedRowChanged += gridView_FocusedRowChanged;
                this.gridView.DoubleClick += gridView_DoubleClick;
                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.gridListadoDocumento, _tituloVentana, this);

                EnlazarEventos();

                //Cargar los paquetes
                Util.Util.ConfigLookupEdit(this.slkupPaquete, clsPaqueteDAC.GetData(-1,"*","*",-1,"*",-1).Tables[0], "Descr", "IDPaquete");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupPaquete, "[{'ColumnCaption':'IDPaquete','ColumnField':'IDPaquete','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                this.dtpFechaInicial.EditValue = DateTime.Now.AddMonths(-1);
                this.dtpFechaFinal.EditValue = DateTime.Now;

                PopulateGrid();
               // CargarPrivilegios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateGrid()
        {
            //if (this.slkupPaquete.EditValue != null)
            //{

                DateTime fechaInicial = (this.dtpFechaInicial.EditValue == null) ? Convert.ToDateTime("2009/01/01")  : (DateTime)this.dtpFechaInicial.EditValue;

                DateTime fechaFinal = (this.dtpFechaFinal.EditValue==null) ? DateTime.Now: (DateTime) this.dtpFechaFinal.EditValue;
                int IdPaquete =(this.slkupPaquete.EditValue == null)? -1: (int)this.slkupPaquete.EditValue;

                _dsProducto = clsDocumentoInvCabecera.GetDataByCriterio(fechaInicial, fechaFinal,"*", "*", "*", IdPaquete, -1, -1, "*");
                _dtProducto = _dsProducto.Tables[0];
                this.gridListadoDocumento.DataSource = null;
                this.gridListadoDocumento.DataSource = _dtProducto;
            //}
        }

        private void CargarElementoSeleccionado() {
            if (_currentRow != null)
            {
                String Accion ="";
                Accion = (Convert.ToBoolean(_currentRow["Aplicado"])==false) ? "Edit" : "View"; 
                frmDocumentoInv ofrmDocumento = new frmDocumentoInv(Convert.ToInt32 (_currentRow["IDTransaccion"]),Accion);
                // ofrmDocumento.MdiParent = this;
                ofrmDocumento.WindowState = FormWindowState.Normal;
                //ShowPagesRibbonMan(false);
                ofrmDocumento.Show();
            }
        }

        void gridView_DoubleClick(object sender, EventArgs e)
        {
            CargarElementoSeleccionado();
        }

        void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                _currentRow = gridView.GetDataRow(index);
                //UpdateControlsFromCurrentRow(_currentRow);
            }
            else _currentRow = null;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefrescar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

  

      
    }
}
