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
    public partial class frmListadoProveedores : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataSet _dsProveedores;
        private DataTable _dtSecurity, dtCategoriaProveedor,dtProveedor;
        private String NombreProveedor;
        private int IDProveedor;


        DataRow _currentRow;

        String _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        
        public frmListadoProveedores()
        {
            InitializeComponent();
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmListadoProveedores_Load(object sender, EventArgs e)
        {
            try
            {

                dtCategoriaProveedor = clsCategoriaProveedorDAC.Get(-1,"*").Tables[0];
                Util.Util.ConfigLookupEdit(this.slkupCategoriaProveedor, dtCategoriaProveedor, "Descr", "IDCategoria", 350);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCategoriaProveedor, "[{'ColumnCaption':'IDCategoria','ColumnField':'IDCategoria','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
                this.slkupCategoriaProveedor.Properties.View.OptionsSelection.MultiSelect = true;
                this.slkupCategoriaProveedor.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.dtgListadoProveedores, "Listado de proveedores", this);

                EnlazarEventos();

                PopulateGrid();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateGrid()
        {

            try
            {
                
                IDProveedor = this.txtIDProveedor.Text == "" ? -1 : Convert.ToInt32(this.txtIDProveedor.Text);
                NombreProveedor = this.txtNombreProveedor.Text == "" ? "*" : this.txtNombreProveedor.Text.Trim();

                
                _dsProveedores = clsProveedorDAC.Get(IDProveedor,NombreProveedor,-1);

                dtProveedor = _dsProveedores.Tables[0];
                this.dtgListadoProveedores.DataSource = null;
                this.dtgListadoProveedores.DataSource = dtProveedor;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
            }
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
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "Listado de Proveedores.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Proveedores "
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
            if (_currentRow != null)
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el Proveedor", "Listado de Proveedores", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    try
                    {
                        ConnectionManager.BeginTran();
                        DAC.clsProveedorDAC.UpdateProveedor("D", Convert.ToInt64(_currentRow["IDProveedor"]), "", "", false, "", -1, -1, DateTime.Now, "", "", -1, -1, 0, 0, "", "", false, false, false, ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
                        PopulateGrid();
                    }

                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadProveedor();
        }


        private void LoadProveedor()
        {
            if (_currentRow != null)
            {
                //String Accion = (Convert.ToInt32(currentRow["IDEstadoOrden"]) == 0) ? "Edit" : "View";
                String Accion = "View";
                //frmProveedor ofmProveedor = new frmProveedor(Convert.ToInt32(currentRow["IDOrdenCompra"]), Accion);
                //ofmProveedor.FormClosed +=ofmProveedor_FormClosed;
                //ofmProveedor.ShowDialog();
            }
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProveedor ofrmProveedor = new frmProveedor("Add");
            ofrmProveedor.FormClosed += ofrmProveedor_FormClosed;
            ofrmProveedor.Show();
        }

        void ofrmProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
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
                _currentRow = gridView1.GetDataRow(index);

            }
        }

        private void btnEditar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRow != null) {
                frmProveedor ofrmProveedor = new frmProveedor("Edit", Convert.ToInt64(_currentRow["IDProveedor"]));
                ofrmProveedor.FormClosed+=ofrmProveedor_FormClosed;
                ofrmProveedor.ShowDialog();
            }
        }

        private void dtgListadoProveedores_DoubleClick(object sender, EventArgs e)
        {
            if (_currentRow != null)
            {
                frmProveedor ofrmProveedor = new frmProveedor("Edit", Convert.ToInt64(_currentRow["IDProveedor"]));
                ofrmProveedor.FormClosed += ofrmProveedor_FormClosed;
                ofrmProveedor.ShowDialog();
            }
        }


    }
}
