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
using Security;

namespace CI
{
    public partial class frmPaquetes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtPaquete;
        private DataSet _dsPaquete;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Paquetes";
        private bool isEdition = false;

        public frmPaquetes()
        {
            InitializeComponent();
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, _sUsuario);
            _dtSecurity = DS.Tables[0];

            AplicarPrivilegios();
        }


        private void AplicarPrivilegios()
        {
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarCentroCosto, _dtSecurity))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarCentroCosto, _dtSecurity))
                this.btnEditar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCentroCosto, _dtSecurity))
                this.btnEliminar.Enabled = false;
        }


        private void EnlazarEventos()
        {
            //this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            //this.btnEditar.ItemClick += btnEditar_ItemClick;
            //this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            //this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            //this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            //this.btnExportar.ItemClick += BtnExportar_ItemClick;
            //this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            //this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstPaquetes.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Paquetes"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmPaquetes_Load(object sender, EventArgs e)
        {
            try
            {
               // HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridControl, _tituloVentana, this);

                EnlazarEventos();

                PopulateGrid();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateData()
        {
            //_lstCentroAcumuladores = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 1).Tables["Data"];
            //Util.Util.ConfigLookupEdit(this.slkupCentroAcumulador, _lstCentroAcumuladores, "Descr", "IDCentro");
            //Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroAcumulador, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");


        }

        private void PopulateGrid()
        {
            //_dsCentro = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", -1);

            //_dtCentro = _dsCentro.Tables[0];
            //this.dtg.DataSource = null;
            //this.dtg.DataSource = _dtCentro;

            PopulateData();

        }

        private void ClearControls()
        {
            //this.txtNivel1.Text = "";
            //this.txtNivel2.Text = "";
            //this.txtNivel3.Text = "";
            //this.txtCentro.Text = "";
            //this.txtDescripcion.Text = "";
            //this.chkActivo.EditValue = true;
            //this.chkAcumulador.EditValue = false;

            //this.slkupCentroAcumulador.EditValue = null;

            //if (this._lstCentroAcumuladores.Rows.Count < 1)
            //{
            //    this.txtNivel1.Text = "1";
            //    this.txtNivel2.Text = "0";
            //    this.txtNivel3.Text = "0";
            //}

        }




    }
}