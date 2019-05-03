using CO.DAC;
using DevExpress.XtraEditors;
using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CO
{
    public partial class frmListdoSolicitudCompra : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        private DataSet _dsCompras;
        private DataTable _dtSecurity, _dtCompras;
        private DateTime FechaInicial, FechaFinal;
        private int IDSolicitud,IDEstado;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count>0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Solicitudes de Compra";
        


        public frmListdoSolicitudCompra()
        {
            InitializeComponent();
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += frmConsecutivos_Load;
        }

        private void CargarEstadoSolicitud() {
            DataTable dt = clsEstadoSolicitudCompraDAC.Get().Tables[0];
            int indice = 0; 
            this.cmbEstado.Properties.Items.Add("TODOS").ToString();            

            foreach (DataRow row in dt.Rows) {
                indice =this.cmbEstado.Properties.Items.Add(row["Descr"].ToString());
                
            }

        }

        

        void frmConsecutivos_Load(object sender, EventArgs e)
        {
            try
            {
                FechaInicial = DateTime.Now.AddMonths(-1);
                FechaFinal = DateTime.Now;

                this.dtpFechaInicial.EditValue = FechaInicial;
                this.dtpFechaFinal.EditValue = FechaFinal;
                CargarEstadoSolicitud();

                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridControl1, _tituloVentana, this);

                EnlazarEventos();

                PopulateGrid();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DS = UsuarioDAC.GetAccionModuloFromRole(0,_sUsuario );
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
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "Listado de Solicitudes de Compras.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Solicitudes de Compras "
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

 

        
        private void PopulateGrid()
        {

            try
            {
                FechaInicial = Convert.ToDateTime(this.dtpFechaInicial.EditValue);
                FechaFinal = Convert.ToDateTime(this.dtpFechaFinal.EditValue);
                IDSolicitud = this.txtIDSolicitud.Text == "" ? -1 : Convert.ToInt32(this.txtIDSolicitud.Text);
                IDEstado = this.cmbEstado.SelectedIndex == 0 ? -1 : Convert.ToInt32(this.cmbEstado.SelectedItem) - 1;



                _dsCompras = clsSolicitudCompraDAC.Get(IDSolicitud, FechaInicial, FechaFinal, -1);

                _dtCompras = _dsCompras.Tables[0];
                this.gridControl1.DataSource = null;
                this.gridControl1.DataSource = _dtCompras;

            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
            }
        }

        private void ClearControls()
        {
            this.txtIDSolicitud.Text = "";
            FechaInicial = DateTime.Now.AddMonths(-1);
            FechaFinal = DateTime.Now;

            this.dtpFechaInicial.EditValue = FechaInicial;
            this.dtpFechaFinal.EditValue = FechaFinal;

            this.cmbEstado.SelectedIndex = 0;
        }

        private void HabilitarControles(bool Activo)
        {
            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
            this.btnExportar.Enabled = !Activo;
            this.btnRefrescar.Enabled = !Activo;

        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridView1.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridView1.GetDataRow(index);
               
            }
        }




        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSolicitudCompra ofrmSolicitud = new frmSolicitudCompra("New");
            ofrmSolicitud.FormClosed += ofrmSolicitud_FormClosed;
            ofrmSolicitud.ShowDialog();
        }

        void ofrmSolicitud_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadSolicitud();
        }

        private void LoadSolicitud() {
            if (currentRow != null)
            {
                String Accion = (Convert.ToInt32(currentRow["IDEstado"]) == 0) ? "Edit" : "View";

                frmSolicitudCompra ofrmSolicitud = new frmSolicitudCompra(Convert.ToInt32(currentRow["IDSolicitud"]), Accion);
                ofrmSolicitud.FormClosed +=ofrmSolicitud_FormClosed;
                ofrmSolicitud.ShowDialog();
            }
        }


        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta seguro que desea eliminar la solicitud seleccionada ? " ,"Listado de Solicitudes", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes) {
                    if (currentRow != null)
                    {
                        ConnectionManager.BeginTran();
                        clsSolicitudCompraDAC.InsertUpdate("D", Convert.ToInt32(currentRow["IDSolicitud"]),"", DateTime.Now, DateTime.Now, -1, "", "", "", DateTime.Now, "", DateTime.Now, "",  ConnectionManager.Tran);
                        clsDetalleSolicitudCompraDAC.InsertUpdate("D", Convert.ToInt32(currentRow["IDSolicitud"]), -1, 0, "", ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
                    }
                    PopulateGrid();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r"+ ex.Message);
                ConnectionManager.RollBackTran();
            }
        }

        private void btnRefres_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            LoadSolicitud();
        }
    
    }
}
