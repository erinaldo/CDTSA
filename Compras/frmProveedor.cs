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
    public partial class frmProveedor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtProveedor;
        private DataSet _dsProveedor;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Proveedor";
        private bool isEdition = false;
        private String Accion = "";
        private long IDProveedor;
        private int IDNit,IDImpuesto,IDCategoria,IDPais,IDMoneda,IDCondicionPago,IDTipoContribuyente; 
        private DateTime FechaIngreso;
        private string NombreProveedor,Alias,Contacto,Telefono,email,Direccion;
        private decimal Descuento, InteresMora;
        private bool Inactivo, MultiMoneda, PagosCongelados,isLocal;
        


        public frmProveedor(String pAccion, long pIDProveedor =-1 )
        {
            InitializeComponent();
            this.Accion = pAccion;
            if (pIDProveedor != -1) {
                this.IDProveedor = pIDProveedor;
            }
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
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
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;

            //this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private void HabilitarControles(bool Activo)
        {
            this.txtNombreProveedor.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.dtpFechaIngreso.ReadOnly = !Activo;
            this.txtAlias.ReadOnly = !Activo;
            this.txtContacto.ReadOnly = !Activo;
            this.slkupNIT.ReadOnly = !Activo;
            this.txtTelefono.ReadOnly = !Activo;
            this.slkupImpuesto.ReadOnly = !Activo;
            this.slkupMoneda.ReadOnly = !Activo;
            this.slkupCategoria.ReadOnly = !Activo;
            this.chkMultimoneda.ReadOnly = !Activo;
            this.chkPagosCongelados.ReadOnly = !Activo;
            this.rdgOrigen.ReadOnly = !Activo;
            this.rgpTipoContribuyente.ReadOnly = !Activo;
            this.slkupPais.ReadOnly = !Activo;
            this.slkupCondicionPago.ReadOnly = !Activo;
            this.txtDescuento.ReadOnly = !Activo;
            this.txtInteresMora.ReadOnly = !Activo;
            this.txtEmail.ReadOnly = !Activo;
            this.txtDireccion.ReadOnly = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;

        }

        private void ClearControls()
        {
            this.txtNombreProveedor.EditValue = null;
            this.chkActivo.Checked = false;
            this.dtpFechaIngreso.EditValue = null;
            this.txtAlias.EditValue = null;
            this.txtContacto.EditValue = null;
            this.slkupNIT.EditValue = null;
            this.txtTelefono.EditValue = null;
            this.slkupImpuesto.EditValue = null;
            this.slkupMoneda.EditValue = null;
            this.slkupCategoria.EditValue = null;
            this.chkMultimoneda.Checked = false;
            this.chkPagosCongelados.Checked = false;
            this.rdgOrigen.EditValue = null;
            this.rgpTipoContribuyente.EditValue = null;
            this.slkupPais.EditValue = null;
            this.slkupCondicionPago.EditValue = null;
            this.txtDescuento.EditValue = null;
            this.txtInteresMora.EditValue = null;
            this.txtEmail.EditValue = null;
            this.txtDireccion.EditValue = null;
        }


        private void AddAction() {
            Accion = "Add";
            HabilitarControles(true);
            ClearControls();
            currentRow = null;
            this.btnAgregar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.txtNombreProveedor.Select();
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddAction();
            
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Accion = "Edit";
            HabilitarControles(true);
            this.btnAgregar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.txtNombreProveedor.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento

            if (this.txtNombreProveedor.Text == "")
                sMensaje = sMensaje + "     • Seleccione Nombre del Proveedor. \n\r";
            if (this.rdgOrigen.EditValue == null)
                sMensaje = sMensaje + "     • Seleccione el Origen del Proveedor. \n\r";
            if (this.dtpFechaIngreso.EditValue == null || this.dtpFechaIngreso.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione la fecha de ingreso del proveedor \n\r";
            if (this.slkupNIT.EditValue == null || this.slkupNIT.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione el Tipo de Contribuyente \n\r";
            if (this.slkupImpuesto.EditValue == null || this.slkupImpuesto.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione el Tipo de impuesto del proveedor \n\r";
            if (this.slkupCategoria.EditValue == null || this.slkupCategoria.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione la categoria del proveedor \n\r";
            if (this.slkupMoneda.EditValue == null || this.slkupMoneda.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione la moneda del proveedor \n\r";
            if (this.slkupCondicionPago.EditValue == null || this.slkupCondicionPago.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione la Condición de Pago del proveedor \n\r";
            if (this.txtDireccion.EditValue == null || this.txtDireccion.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione la Dirección del proveedor \n\r";

            if (sMensaje != "")
            {
                result = false;
                MessageBox.Show("Por favor revise los siguientes campos, puede que sean obligatorios: \n\r\n\r" + sMensaje);
            }
            return result;
        }

        private void ObtenerDatos() {
            this.IDProveedor = (this.txtIDProveedor.EditValue != null ) ? Convert.ToInt64(this.txtIDProveedor.EditValue) : -1 ;
            this.NombreProveedor = this.txtNombreProveedor.EditValue.ToString();
            this.IDNit = Convert.ToInt32(this.slkupNIT.EditValue);
            this.IDCategoria = Convert.ToInt32(this.slkupCategoria.EditValue);
            this.IDPais = Convert.ToInt32(this.slkupPais.EditValue);
            this.IDMoneda = Convert.ToInt32(this.slkupMoneda.EditValue);
            this.IDCondicionPago = Convert.ToInt32(this.slkupCondicionPago.EditValue);
            this.IDTipoContribuyente = Convert.ToInt32(this.rgpTipoContribuyente.SelectedIndex);
            this.IDImpuesto = Convert.ToInt32(this.slkupImpuesto.EditValue);
            this.FechaIngreso = Convert.ToDateTime(this.dtpFechaIngreso.EditValue);
            this.NombreProveedor = Convert.ToString(this.txtNombreProveedor.EditValue);
            this.Alias = (this.txtAlias.EditValue == null) ? "" : this.txtAlias.EditValue.ToString();
            this.Contacto = (this.txtContacto.EditValue == null )? "" : this.txtContacto.EditValue.ToString();
            this.Telefono = (this.txtTelefono.EditValue == null)? "" :  this.txtTelefono.EditValue.ToString();
            this.email = (this.txtEmail.EditValue == null) ? "" : this.txtEmail.EditValue.ToString();
            this.Direccion = (this.txtDireccion.EditValue == null) ? "" : this.txtDireccion.EditValue.ToString();
            this.Descuento = (this.txtDescuento.EditValue == null) ? 0 : Convert.ToDecimal(this.txtDescuento.EditValue);
            this.InteresMora = (this.txtInteresMora.EditValue == null) ? 0 : Convert.ToDecimal(this.txtInteresMora.EditValue);
            this.Inactivo = this.chkActivo.Checked;
            this.MultiMoneda = this.chkMultimoneda.Checked;
            this.PagosCongelados = this.chkPagosCongelados.Checked;
            this.isLocal =  (Convert.ToInt32(this.rdgOrigen.EditValue) == 1) ? true : false;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //ValidarDatos
                if (!ValidarDatos())
                    return;

                ConnectionManager.BeginTran();
                String Operacion = "";
                long IDProveedor = -1;
                if (Accion == "Add")
                {
                    Operacion = "I";
                }
                else
                {
                    Operacion = "U";
                    IDProveedor = Convert.ToInt64(this.txtIDProveedor.Text.Trim());
                }

                ObtenerDatos();
                DAC.clsProveedorDAC.UpdateProveedor(Operacion,
                    IDProveedor, NombreProveedor, IDNit, !Inactivo,
                    Alias, IDPais, IDMoneda,FechaIngreso, Contacto,
                   Telefono, IDImpuesto, IDCategoria, IDCondicionPago, Descuento,
                    InteresMora, email, Direccion,MultiMoneda,PagosCongelados,isLocal,IDTipoContribuyente, ConnectionManager.Tran);

                 ConnectionManager.CommitTran();

                 this.btnAgregar.Enabled = true;
                 this.btnEditar.Enabled = true;
                 this.btnEliminar.Enabled = true;
                 this.btnGuardar.Enabled = false;
                 this.btnCancelar.Enabled = false;

            }
            catch (Exception ex)
            {
                if (ConnectionManager.Tran != null) {
                    ConnectionManager.RollBackTran();
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = false;
            HabilitarControles(false);
            AplicarPrivilegios();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             

                if (MessageBox.Show("Esta seguro que desea eliminar el Proveedor", _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    try
                    {
                        ConnectionManager.BeginTran();
                        DAC.clsProveedorDAC.UpdateProveedor("D",(long)this.txtIDProveedor.EditValue,"",-1,false,"",-1,-1,DateTime.Now,"","",-1,-1,-1,0,0,"","",false,false,false,-1,ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
                    }
                            
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }

        private void CargarDatos() {
            DataTable dt = DAC.clsProveedorDAC.Get(this.IDProveedor, "*",-1).Tables[0];
           
            this.txtIDProveedor.EditValue = dt.Rows[0]["IDProveedor"].ToString();
            this.txtNombreProveedor.EditValue = dt.Rows[0]["Nombre"].ToString();
            this.dtpFechaIngreso.EditValue = Convert.ToDateTime(dt.Rows[0]["FechaIngreso"]);
            this.txtAlias.EditValue = dt.Rows[0]["Alias"].ToString();
            this.txtContacto.EditValue = dt.Rows[0]["Contacto"].ToString();
            this.slkupNIT.EditValue = Convert.ToInt32(dt.Rows[0]["IDRuc"]);
            this.txtTelefono.EditValue = dt.Rows[0]["Telefono"].ToString();
            this.slkupImpuesto.EditValue = Convert.ToInt32(dt.Rows[0]["IDImpuesto"]);
            this.slkupCategoria.EditValue = Convert.ToInt32(dt.Rows[0]["IDCategoria"]);
            this.chkActivo.EditValue = Convert.ToBoolean(dt.Rows[0]["Activo"]);
            this.chkMultimoneda.EditValue = Convert.ToBoolean(dt.Rows[0]["Multimoneda"]);
            this.chkPagosCongelados.EditValue = Convert.ToBoolean(dt.Rows[0]["PagosCongelados"]);
            this.rdgOrigen.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["IsLocal"])==true ? 0:1;
            this.rgpTipoContribuyente.SelectedIndex = Convert.ToInt32(dt.Rows[0]["TipoContribuyente"]);
            this.slkupPais.EditValue = Convert.ToInt32(dt.Rows[0]["IDPais"]);
            this.slkupMoneda.EditValue = Convert.ToInt32(dt.Rows[0]["IDMoneda"]);
            this.slkupCondicionPago.EditValue = Convert.ToInt32(dt.Rows[0]["IDCondicionPago"]);
            this.txtDescuento.EditValue = Convert.ToDecimal(dt.Rows[0]["PorcDesc"]);
            this.txtInteresMora.EditValue = Convert.ToDecimal(dt.Rows[0]["PorcInteresMora"]);
            this.txtEmail.EditValue = dt.Rows[0]["Email"].ToString();
            this.txtDireccion.EditValue = dt.Rows[0]["Direccion"].ToString();
            

        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.ConfigLookupEdit(this.slkupNIT, ControlBancario.DAC.RucDAC.GetData(-1).Tables[0],"RUC","IDRuc");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupNIT, "[{'ColumnCaption':'RUC','ColumnField':'IDRuc','width':30},{'ColumnCaption':'RUC','ColumnField':'RUC','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupImpuesto,DAC.clsGlobalImpuestoDAC.Get(-1).Tables[0], "Descr", "IDImpuesto");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupImpuesto, "[{'ColumnCaption':'IDImpuesto','ColumnField':'IDImpuesto','width':30},{'ColumnCaption':'Descr','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCategoria, DAC.clsCategoriaProveedorDAC.Get(-1,"*").Tables[0], "Descr", "IDCategoria");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCategoria, "[{'ColumnCaption':'IDCategoria','ColumnField':'IDCategoria','width':30},{'ColumnCaption':'Descr','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupPais, DAC.clsGlobalPaisDAC.Get(-1).Tables[0], "Descr", "IDPais");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupPais, "[{'ColumnCaption':'IDPais','ColumnField':'IDPais','width':30},{'ColumnCaption':'Descr','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupMoneda, ControlBancario.DAC.MonedaDAC.GetMoneda(-1).Tables[0], "Descr", "IDMoneda");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupMoneda, "[{'ColumnCaption':'IDMoneda','ColumnField':'IDMoneda','width':30},{'ColumnCaption':'Descr','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCondicionPago, DAC.clsCondicionPagoDAC.Get().Tables[0], "Descr", "IDCondicionPago");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCondicionPago, "[{'ColumnCaption':'IDCondicionPago','ColumnField':'IDCondicionPago','width':30},{'ColumnCaption':'Descr','ColumnField':'Descr','width':70}]");
                
                
                EnlazarEventos();

              //  PopulateGrid();
                CargarPrivilegios();

                if (Accion == "Add")
                {
                    AddAction();
                }
                else if (Accion == "Edit")
                {
                    CargarDatos();
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
