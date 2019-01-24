using CO.DAC;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
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
    public partial class frmListadoArticuloProveedor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataSet _dsArticuloProveedor;
        private DataTable _dtSecurity, _dtArticuloProveedor,_dtProveedor;
        private int IDProveedor;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count>0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Articulos Proveedor";



        public frmListadoArticuloProveedor()
        {
            InitializeComponent();
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += frmConsecutivos_Load;
        }


        void frmConsecutivos_Load(object sender, EventArgs e)
        {
            try
            {
               
                HabilitarControles(false);

                _dtProveedor = CO.DAC.clsProveedorDAC.Get(-1).Tables[0];

                this.slkupProveedor.Properties.DataSource = _dtProveedor;
                this.slkupProveedor.Properties.DisplayMember = "Nombre";
                this.slkupProveedor.Properties.ValueMember = "IDProveedor";
                this.slkupProveedor.Properties.NullText = " --- ---";
                this.slkupProveedor.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupProveedor.Properties.Popup += slkup_Popup;
                this.slkupProveedor.Properties.PopulateViewColumns();

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.dtgpDetalle, _tituloVentana, this);

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
            this.btnRefrescar.Click += btnRefrescar_Click;
            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

    

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "Listado de Articulo Proveedor.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Artículo Proveedor "
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

                IDProveedor = (this.slkupProveedor.EditValue == null) ? -1 : Convert.ToInt32(this.slkupProveedor.EditValue);
                _dsArticuloProveedor = clsArticuloProveedorDAC.Get(-1,IDProveedor);

                _dtArticuloProveedor = _dsArticuloProveedor.Tables[0];
                this.dtgpDetalle.DataSource = null;
                this.dtgpDetalle.DataSource = _dtArticuloProveedor;

            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
            }
        }

        private void slkup_Popup(object sender, EventArgs e)
        {
            DevExpress.Utils.Win.IPopupControl popupControl = sender as DevExpress.Utils.Win.IPopupControl;
            DevExpress.XtraLayout.LayoutControl layoutControl = popupControl.PopupWindow.Controls[2].Controls[0] as LayoutControl;

            SimpleButton clearButton = ((DevExpress.XtraLayout.LayoutControlItem)layoutControl.Items.FindByName("lciClear")).Control as SimpleButton;
            SimpleButton findButton = ((DevExpress.XtraLayout.LayoutControlItem)layoutControl.Items.FindByName("lciButtonFind")).Control as SimpleButton;

            clearButton.Text = "Limpiar";
            findButton.Text = "Buscar";
        }

        private void slkup_EditValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void ClearControls()
        {
            this.slkupProveedor.EditValue = null;
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
            if (this.slkupProveedor.EditValue != null) {
                frmArticuloProveedor ofrmArticuloProveedor = new frmArticuloProveedor(Convert.ToInt32(this.slkupProveedor.EditValue), -1, "Add");
                ofrmArticuloProveedor.FormClosed += ofrmSolicitud_FormClosed;
                ofrmArticuloProveedor.ShowDialog();          
            }
        }

        void ofrmSolicitud_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadRelactionArticuloProveedor();
        }

        private void LoadRelactionArticuloProveedor() {
            if (currentRow != null)
            {
                //String Accion = (Convert.ToInt32(currentRow["IDEstado"]) == 0) ? "Edit" : "View";
                
                frmArticuloProveedor ofrmArticuloProveedor = new frmArticuloProveedor(Convert.ToInt32(currentRow["IDProveedor"]),Convert.ToInt64(currentRow["IDProducto"]),"Edit");
                ofrmArticuloProveedor.FormClosed += ofrmSolicitud_FormClosed;
                ofrmArticuloProveedor.ShowDialog();
            }
        }


        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta seguro que desea eliminar la relación del producto seleccionado del proveeor ? " ,"Listado de Articulo Proveedores", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes) {
                    if (currentRow != null)
                    {
                        ConnectionManager.BeginTran();
                        clsArticuloProveedorDAC.InsertUpdate("D", Convert.ToInt64(currentRow["IDProducto"]), Convert.ToInt32(currentRow["IDProveedor"]), -1, 0, 0,"", DateTime.Now, "", ConnectionManager.Tran);
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
            LoadRelactionArticuloProveedor();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.slkupProveedor.EditValue = null;
        }

  


    
    }
}
