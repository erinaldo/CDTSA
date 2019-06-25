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
using CO.DAC;

namespace CO
{
    public partial class frmListadoEmbarque : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        private DataTable _dtSecurity, _dtEmbarque;
        private DateTime FechaInicial, FechaFinal;
        private String sOrdenCompra, sEmbarque;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Ordenes de Compra";

        
        public frmListadoEmbarque()
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
           
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCentroCosto, _dtSecurity))
                this.btnEliminar.Enabled = false;
        }

        private void HabilitarControles(bool Activo)
        {
           
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
            this.btnExportar.Enabled = !Activo;
            this.btnRefrescar.Enabled = !Activo;

        }


        private void PopulateGrid()
        {

            try
            {
                FechaInicial = (this.dtpFechaInicial.EditValue == null) ? Convert.ToDateTime("1981/10/21") : Convert.ToDateTime(this.dtpFechaInicial.EditValue);
                FechaFinal = (this.dtpFechaInicial.EditValue == null) ? DateTime.Now.AddYears(10) : Convert.ToDateTime(this.dtpFechaFinal.EditValue);
                
                sOrdenCompra = this.txtOrdenCompra.Text ;
                sEmbarque = this.txtEmbarque.Text;

                _dtEmbarque = clsEmbarqueDAC.Get(-1, FechaInicial, FechaFinal,-1,-1,sOrdenCompra,sEmbarque,-1).Tables[0];

                this.dtgEmbarques.DataSource = null;
                this.dtgEmbarques.DataSource = _dtEmbarque;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
            }
        }

        private void EnlazarEventos()
        {
           
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
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

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "Listado de Embarques.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Embarques"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }


     

    
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el embarque seleccionada ? ", "Listado de Embarques", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (currentRow != null)
                    {
                        ConnectionManager.BeginTran();
                        string s = "";
                        clsEmbarqueDAC.InsertUpdate("D", Convert.ToInt64(currentRow["IDEmbarque"]),ref s ,DateTime.Now,DateTime.Now,"",-1,-1,-1,-1,0,"",DateTime.Now,"",DateTime.Now,"", ConnectionManager.Tran);
                        clsDetalleSolicitudCompraDAC.InsertUpdate("D", Convert.ToInt32(currentRow["IDSolicitud"]), -1, 0, "", ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
                    }
                    PopulateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
                ConnectionManager.RollBackTran();
            }
        }
        private void LoadEmbarque()
        {
            if (currentRow != null)
            {
                
                String Accion = "View";
                frmEmbarque frmEmbarque = new frmEmbarque(Convert.ToInt64(currentRow["IDOrdenCompra"]), Convert.ToInt64(currentRow["IDEmbarque"]), Accion);
                frmEmbarque.FormClosed += ofrmOrden_FormClosed;
                frmEmbarque.ShowDialog();
            }
        }

        void ofrmOrden_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void frmListadoEmbarque_Load(object sender, EventArgs e)
        {
            try
            {
                FechaInicial = DateTime.Now.AddMonths(-1);
                FechaFinal = DateTime.Now;

                
                this.dtpFechaInicial.EditValue = FechaInicial;
                this.dtpFechaFinal.EditValue = FechaFinal;
                

                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.dtgEmbarques, _tituloVentana, this);

                EnlazarEventos();

                PopulateGrid();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgEmbarques_DoubleClick(object sender, EventArgs e)
        {
            LoadEmbarque();
        }

        
    }
}
