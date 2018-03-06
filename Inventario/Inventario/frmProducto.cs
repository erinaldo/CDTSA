using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Security;
using CI.DAC;


namespace CI
{
    public partial class frmProducto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtProducto;
        private DataSet _dsProducto;
        private DataTable _dtSecurity;
        
        private DataRow _currentRow;
        private String _tituloVentana = "Producto";


        private String Accion = "NEW";
        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";

        public frmProducto()
        {
            InitializeComponent();
            InicializaNuevoElemento();
        }

        private void InicializaNuevoElemento() {
             Accion = "New";
            _dsProducto = clsProductoDAC.GetDataEmpty();
            _dtProducto = _dsProducto.Tables[0];
            _currentRow = null;
            InicializarNuevoElemento();
        }

        public frmProducto(int Codigo, String Accion) {
            this.Accion = Accion;
            InitializeComponent();
            cargarProducto(Codigo);
        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, sUsuario);
            _dtSecurity = DS.Tables[0];

        }


        private void AplicarPrivilegios()
        {

            //if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarAsientodeDiario, _dtSecurity))
            //{
            //    if (_dsProducto.Tables[0].Rows.Count > 0 )
            //        this.btnEditar.Enabled = false;
            //    else
            //        this.btnEditar.Enabled = true;
            //}
            //else
            //    this.btnEditar.Enabled = false;

            //if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarAsientodeDiario, _dtSecurity))
            //{
            //    if (_dsProducto.Tables[0].Rows.Count > 0)
            //        this.btnEliminar.Enabled = false;
            //    else
            //        this.btnEliminar.Enabled = true;
            //}
            //else
            //    this.btnEliminar.Enabled = false;

        }


        private void InicializarNuevoElemento()
        {

            DataSet DS = new DataSet();
            //Cargar el tipo de cambio por defecto

            _currentRow = _dtProducto.NewRow();
            _currentRow["IDProducto"] = -1;
            _currentRow["Descr"] = "";
            _currentRow["Alias"] = "";
            _currentRow["Clasif1"] = -1;
            _currentRow["Clasif2"] = -1;
            _currentRow["Clasif3"] = -1;
            _currentRow["Clasif4"] = -1;
            _currentRow["Clasif5"] = -1;
            _currentRow["Clasif6"] = -1;
            _currentRow["CodigoBarra"] = "";
            _currentRow["IDUnidad"] = -1;
            _currentRow["FactorEmpaque"] = 0;
            _currentRow["TipoImpuesto"] = 0;
            _currentRow["EsMuestra"] = false;
            _currentRow["EsControlado"] = false;
            _currentRow["EsEtico"] = false;
            _currentRow["BajaPrecioDistribuidor"] = false;
            _currentRow["BajaPrecioProveedor"] = false;
            _currentRow["PorcDescuentoAlzaProveedor"] = 0;
            _currentRow["BonificaFA"] = false;
            _currentRow["BonificaCOPorCada"] = 0;
            _currentRow["BonificaCOCantidad"] = 0;
            _currentRow["Activo"] = true;
            _currentRow["UserInsert"] = sUsuario;
            _currentRow["UserUpdate"] = DateTime.Now;
            _currentRow["UpdateDate"] = DateTime.Now;


        }

        public void cargarProducto(int Codigo) {
            _dsProducto = clsProductoDAC.GetData(Codigo, "*", "*", -1, -1, -1, -1, -1, -1, "*",-1,-1,-1);
            _dtProducto = _dsProducto.Tables[0];
            _currentRow = _dtProducto.Rows[0];

        }


        public void UpdateControlsFromDataRow(DataRow row)
        {
            //_currentRow = _dtAsiento.NewRow();
            this.txtIDProducto.EditValue = _currentRow["IDProducto"].ToString();
            this.txtDescr.EditValue = _currentRow["Descr"].ToString();
            this.txtAlias.EditValue = _currentRow["Alias"].ToString();
            this.txtCodigoBarra.Text = _currentRow["CodigoBarra"].ToString(); 
            this.txtFactorEmpaque.EditValue = _currentRow["FactorEmpaque"].ToString();
            this.slkupUnidadMedida.EditValue = _currentRow["IDUnidad"];
            //this.dtpFecha.Text = Convert.ToDateTime(_currentRow["Fecha"]).ToShortDateString();
            this.slkupTipoImpuesto.EditValue = _currentRow["TipoImpuesto"].ToString();
            this.chkActivo.EditValue = _currentRow["Activo"];
            this.chkEsControlado.EditValue = _currentRow["EsControlado"];
            this.chkEsEtico.EditValue = _currentRow["EsEtico"];
            this.chkBajaPrecioDistribuidor.EditValue = _currentRow["BajaPrecioDistribuidor"].ToString();
            this.chkBajaPrecioProveedor.EditValue = _currentRow["BajaPrecioProveedor"].ToString();
            this.chkBonificaFactura.EditValue = _currentRow["BonificaFA"];

            this.txtBonificaCOCantidad.EditValue = _currentRow["BonificaCOPorCada"].ToString();
            this.txtBonificaCOPorCada.EditValue = _currentRow["BonificaCOCantidad"].ToString();
            this.txtPorcDescAlzaProveedor.EditValue = _currentRow["PorcDescuentoAlzaProveedor"].ToString();

            this.txtCostoPromDolar.EditValue = 0;
            this.txtCostoPromLocal.EditValue = 0;

            this.slkupClasif1.EditValue = _currentRow["Clasif1"];
            this.slkupClasif2.EditValue = _currentRow["Clasif2"];
            this.slkupClasif3.EditValue = _currentRow["Clasif3"];
            this.slkupClasif4.EditValue = _currentRow["Clasif4"];
            this.slkupClasif5.EditValue = _currentRow["Clasif5"];
            this.slkupClasif6.EditValue = _currentRow["Clasif6"];


            //Pagina de auditoria
            this.txtUsuarioCreacion.Text = _currentRow["UserInsert"].ToString();
            this.txtFechaCreacion.Text = _currentRow["CreateDate"].ToString();
            this.txtUsuarioModificacion.Text = _currentRow["UserUpdate"].ToString();
            this.txtFechaModificacion.Text = _currentRow["UpdateDate"].ToString();
            //Obtener los datos segun cabecera
            
        }



        private void HabilitarControles(bool Activo)
        {
            
            this.txtIDProducto.ReadOnly =true;
            this.txtDescr.ReadOnly = !Activo;
            this.txtAlias.ReadOnly = !Activo;
            this.txtCodigoBarra.ReadOnly = !Activo;
            this.txtFactorEmpaque.ReadOnly = !Activo;
            this.slkupUnidadMedida.ReadOnly = !Activo;
            //this.dtpFecha.Text = Convert.ToDateTime(_currentRow["Fecha"]).ToShortDateString();
            this.slkupTipoImpuesto.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.chkEsControlado.ReadOnly = !Activo;
            this.chkEsEtico.ReadOnly = !Activo;
            this.chkEsMuestra.ReadOnly = !Activo;
            this.chkBajaPrecioDistribuidor.ReadOnly = !Activo;
            this.chkBajaPrecioProveedor.ReadOnly = !Activo;
            this.chkBonificaFactura.ReadOnly = !Activo;

            this.txtBonificaCOCantidad.ReadOnly = !Activo;
            this.txtBonificaCOPorCada.ReadOnly = !Activo;
            this.txtPorcDescAlzaProveedor.ReadOnly = !Activo;

            this.txtCostoPromDolar.ReadOnly = !Activo;
            this.txtCostoPromLocal.ReadOnly = !Activo;

            this.slkupClasif1.ReadOnly = !Activo;
            this.slkupClasif2.ReadOnly = !Activo;
            this.slkupClasif3.ReadOnly = !Activo;
            this.slkupClasif4.ReadOnly = !Activo;
            this.slkupClasif5.ReadOnly = !Activo;
            this.slkupClasif6.ReadOnly = !Activo;


            //Pagina de auditoria

            if (Accion == "New")
            {
                this.btnEditar.Enabled = false;
                this.btnAgregar.Enabled = false;
                
            }
            else if (Accion == "View")
            {
                this.btnEditar.Enabled = true;
                this.btnAgregar.Enabled = true;

            }
            else if (Accion == "Edit") {
                this.btnAgregar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
                
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = !Activo;
        }


        private void EnlazarEventos()
        {
            //    this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            //this.btnImprimir.ItemClick += BtnImprimir_ItemClick;
            //this.btnCuadreTemporal.ItemClick += BtnCuadreTemporal_ItemClick;
        }

        void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentRow != null)
            {

                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + _currentRow["IdProducto"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataSet _dsProductotmp = new DataSet();
                    DataTable _dtProductotmp = new DataTable();


                    //Validar las dependendicas
                    //ToDo Validar dependencias de los prodcutos
                    _currentRow.Delete();
                    try
                    {

                        clsProductoDAC.oAdaptador.Update(_dsProducto, "Data");
                        _dsProducto.AcceptChanges();


                        // PopulateGrid();
                        //lblStatus.Text = "El elemento se ha eliminado";
                        //MessageBox.Show("El asiento se ha eliminado correctamente.");
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsProducto.RejectChanges();
                        MessageBox.Show("Han ocurrido errores al momento de eliminar el asiento por favor verifique" + ex.Message);
                    }

                    this.Close();

                }

            }
        }


        private bool ValidaDatos()
        {
            bool result = true;
            String sMensaje = "";

            if (this.txtDescr.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese la descripción del Producto. \n\r";
            if (this.slkupUnidadMedida.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese la unidad de Medida del Producto. \n\r";
            if (this.txtFactorEmpaque.Text == "")
                sMensaje = sMensaje + "     • Digite el Factor de Empaque del Producto. \n\r";
            if (this.slkupTipoImpuesto.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese el Tipo de Impuesto del Producto. \n\r";
            
         

            if (sMensaje != "")
            {
                MessageBox.Show("Estimado usuario, favor revise los siguientes errores: \n\r" + sMensaje);
                result = false;
            }
            return result;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GuardarAsiento();
        }


        private void GuardarAsiento()
        {
         
                if (!ValidaDatos()) return;

                //Validar si la fecha del asiento contable corresponde a una fecha valida
                

                //Obtener los datos


                //if (_currentRow != null)
                if (Accion != "New")
                {
                    Application.DoEvents();
                    _currentRow.BeginEdit();

                    //_dsProducto.Tables[0].Rows.Add(_currentRow);
                    _currentRow["IDProducto"] = this.txtIDProducto.Text.Trim();
                    _currentRow["Descr"] = this.txtDescr.Text.Trim();
                    _currentRow["Alias"] = this.txtAlias.Text.Trim();
                    _currentRow["Clasif1"] = (this.slkupClasif1.EditValue == null) ? 1 : Convert.ToInt32(this.slkupClasif1.EditValue);
                    _currentRow["Clasif2"] = (this.slkupClasif2.EditValue == null) ? 2 : Convert.ToInt32(this.slkupClasif2.EditValue);
                    _currentRow["Clasif3"] = (this.slkupClasif3.EditValue == null) ? 3 : Convert.ToInt32(this.slkupClasif3.EditValue);
                    _currentRow["Clasif4"] = (this.slkupClasif4.EditValue == null) ? 4 : Convert.ToInt32(this.slkupClasif4.EditValue);
                    _currentRow["Clasif5"] = (this.slkupClasif5.EditValue == null) ? 5 : Convert.ToInt32(this.slkupClasif5.EditValue);
                    _currentRow["Clasif6"] = (this.slkupClasif6.EditValue == null) ? 6: Convert.ToInt32(this.slkupClasif6.EditValue);
                    _currentRow["CodigoBarra"] = this.txtCodigoBarra.EditValue;
                    _currentRow["IDUnidad"] = this.slkupUnidadMedida.EditValue;
                    _currentRow["FactorEmpaque"] = this.txtFactorEmpaque.EditValue;
                    _currentRow["TipoImpuesto"] = this.slkupTipoImpuesto.EditValue;
                    _currentRow["EsMuestra"] = this.chkEsMuestra.EditValue;
                    _currentRow["EsControlado"] = this.chkEsControlado.EditValue;
                    _currentRow["EsEtico"] = this.chkEsEtico.EditValue;
                    _currentRow["BajaPrecioDistribuidor"] = this.chkBajaPrecioDistribuidor.EditValue;
                    _currentRow["BajaPrecioProveedor"] = this.chkBajaPrecioProveedor.EditValue;
                    _currentRow["PorcDescuentoAlzaProveedor"] = this.txtPorcDescAlzaProveedor.EditValue;
                    _currentRow["BonificaFA"] = this.chkBonificaFactura.EditValue;
                    _currentRow["BonificaCOPorCada"] = this.txtBonificaCOPorCada.EditValue;
                    _currentRow["BonificaCoCantidad"] = this.txtBonificaCOCantidad.EditValue;
                    _currentRow["Activo"] = this.chkActivo.EditValue;
                    _currentRow["UserInsert"] = sUsuario;
                    _currentRow["UserUpdate"] = sUsuario;
                    _currentRow["UpdateDate"] = DateTime.Now;
                    _currentRow.EndEdit();

                    DataSet _dsChanged = _dsProducto.GetChanges(DataRowState.Modified);

                    bool okFlag = true;
                    if (_dsChanged.HasErrors)
                    {
                        okFlag = false;
                        string msg = "Error en la fila con el tipo Id";

                        foreach (DataTable tb in _dsChanged.Tables)
                        {
                            if (tb.HasErrors)
                            {
                                DataRow[] errosRow = tb.GetErrors();

                                foreach (DataRow dr in errosRow)
                                {
                                    msg = msg + dr["IdProducto"].ToString();
                                }
                            }
                        }

                        lblStatus.Caption = msg;
                    }

                    //Si no hay errores

                    if (okFlag)
                    {
                        clsProductoDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + _currentRow["Descr"].ToString();
                        Application.DoEvents();

                        _dsProducto.AcceptChanges();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsProducto.RejectChanges();

                    }


                }
                else {

                    _currentRow = _dtProducto.NewRow();
                    //_currentRow["IDProducto"] = this.txtIDProducto.Text.Trim();
                    _currentRow["Descr"] = this.txtDescr.Text.Trim();
                    _currentRow["Alias"] = this.txtAlias.Text.Trim();
                    _currentRow["Clasif1"] = (this.slkupClasif1.EditValue == null) ? 1 : Convert.ToInt32(this.slkupClasif1.EditValue);
                    _currentRow["Clasif2"] = (this.slkupClasif2.EditValue == null) ? 2 : Convert.ToInt32(this.slkupClasif2.EditValue);
                    _currentRow["Clasif3"] = (this.slkupClasif3.EditValue == null) ? 3 : Convert.ToInt32(this.slkupClasif3.EditValue);
                    _currentRow["Clasif4"] = (this.slkupClasif4.EditValue == null) ? 4 : Convert.ToInt32(this.slkupClasif4.EditValue);
                    _currentRow["Clasif5"] = (this.slkupClasif5.EditValue == null) ? 5 : Convert.ToInt32(this.slkupClasif5.EditValue);
                    _currentRow["Clasif6"] = (this.slkupClasif6.EditValue == null) ? 6 : Convert.ToInt32(this.slkupClasif6.EditValue);
                    _currentRow["CodigoBarra"] = this.txtCodigoBarra.EditValue;
                    _currentRow["IDUnidad"] = this.slkupUnidadMedida.EditValue;
                    _currentRow["FactorEmpaque"] = this.txtFactorEmpaque.EditValue;
                    _currentRow["TipoImpuesto"] = this.slkupTipoImpuesto.EditValue;
                    _currentRow["EsMuestra"] = this.chkEsMuestra.EditValue;
                    _currentRow["EsControlado"] = this.chkEsControlado.EditValue;
                    _currentRow["EsEtico"] = this.chkEsEtico.EditValue;
                    _currentRow["BajaPrecioDistribuidor"] = this.chkBajaPrecioDistribuidor.EditValue;
                    _currentRow["BajaPrecioProveedor"] = this.chkBajaPrecioProveedor.EditValue;
                    _currentRow["PorcDescuentoAlzaProveedor"] = this.txtPorcDescAlzaProveedor.EditValue;
                    _currentRow["BonificaFA"] = this.chkBonificaFactura.EditValue;
                    _currentRow["BonificaCOPorCada"] = this.txtBonificaCOPorCada.EditValue;
                    _currentRow["BonificaCoCantidad"] = this.txtBonificaCOCantidad.EditValue;
                    _currentRow["Activo"] = this.chkActivo.EditValue;
                    _currentRow["UserInsert"] = sUsuario;
                    _currentRow["UserUpdate"] = sUsuario;
                    _currentRow["UpdateDate"] = DateTime.Now;

                    _dtProducto.Rows.Add(_currentRow);

                    try
                    {
                        clsProductoDAC.oAdaptador.Update(_dsProducto, "Data");
                        _dsProducto.AcceptChanges();

                        this.txtIDProducto.EditValue = clsProductoDAC.oAdaptador.InsertCommand.Parameters["@IDProducto"].Value.ToString();
                        lblStatus.Caption = "Se ha ingresado un nuevo registro";
                        Application.DoEvents();
                        
                        HabilitarControles(false);
                        AplicarPrivilegios();
                        
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsProducto.RejectChanges();
                        //_currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                
                }
              
        }


        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_currentRow == null)
            {
                return;
            }
           
                Accion = "Edit";
                HabilitarControles(true);
                AplicarPrivilegios();
                
            

        }


        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Accion == "Edit" )
            {
                HabilitarControles(false);
                AplicarPrivilegios();
                //CargarAsiento(_currentRow["Asiento"].ToString());
                UpdateControlsFromDataRow(_currentRow);
                Accion = "View";
                this.btnEditar.Enabled = true;
                this.btnAgregar.Enabled = true;
            }
            else
                this.Close();

        }


        private void ClearControls() {
            this.txtIDProducto.EditValue = "";
            this.txtDescr.EditValue = "";
            this.txtAlias.EditValue = "";
            this.txtCodigoBarra.EditValue = "";
            this.slkupUnidadMedida.EditValue = null;
            this.slkupTipoImpuesto.EditValue = null;
            this.txtFactorEmpaque.EditValue = "";
            this.chkActivo.EditValue = true;
            this.chkEsControlado.EditValue = false;
            this.chkEsMuestra.EditValue = false;
            this.chkEsEtico.EditValue = false;
            this.chkBajaPrecioDistribuidor.EditValue = false;
            this.chkBajaPrecioProveedor.EditValue = false;
            this.chkBonificaFactura.EditValue = false;

            this.txtBonificaCOCantidad.EditValue = "";
            this.txtBonificaCOPorCada.EditValue = "";
            this.txtPorcDescAlzaProveedor.EditValue = "";

            this.txtCostoPromLocal.EditValue = "";
            this.txtCostoPromDolar.EditValue = "";
            this.txtUltimoCostoDolar.EditValue = "";
            this.txtUltimoCostoLocal.EditValue = "";

            this.slkupClasif1.EditValue = null;
            this.slkupClasif2.EditValue = null;
            this.slkupClasif3.EditValue = null;
            this.slkupClasif4.EditValue = null;
            this.slkupClasif5.EditValue = null;
            this.slkupClasif6.EditValue = null;

            this.txtUsuarioCreacion.EditValue = "";
            this.txtFechaCreacion.EditValue = "";
            this.txtUsuarioModificacion.EditValue = "";
            this.txtFechaModificacion.EditValue = "";

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                
                HabilitarControles(false);
                
                CargarPrivilegios();
                EnlazarEventos();

                Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, _tituloVentana, this);

                //Configurar searchLookUp

                Util.Util.ConfigLookupEdit(this.slkupClasif1, clsClasificacionDAC.GetData(-1,1,"*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif1, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif2, clsClasificacionDAC.GetData(-1, 2, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif2, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif3, clsClasificacionDAC.GetData(-1, 3, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif3, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif4, clsClasificacionDAC.GetData(-1, 4, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif4, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif5, clsClasificacionDAC.GetData(-1, 5, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif5, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif6, clsClasificacionDAC.GetData(-1, 6, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif6, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                
                Util.Util.ConfigLookupEdit(this.slkupUnidadMedida, clsUnidadMedidaDAC.GetData(-1,"*").Tables[0], "Descr", "IDUnidad");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupUnidadMedida, "[{'ColumnCaption':'ID Unidad','ColumnField':'IDUnidad','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupTipoImpuesto, globalTipoImpuestoDAC.GetData(-1, "*").Tables[0], "Descr", "IDImpuesto");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoImpuesto, "[{'ColumnCaption':'ID Impuesto','ColumnField':'IDImpuesto','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");


                UpdateControlsFromDataRow(_currentRow);
                if (Accion == "New")
                {
                    HabilitarControles(true);
                    ClearControls();
                    this.tabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.ValidateChildren();
                } else if (Accion == "Edit"){
                     HabilitarControles(true);
                    AplicarPrivilegios();
                }
                else 
                {
                    Accion = "View";
                    HabilitarControles(false);
                    
                } 

                //if (_Estado == "PndtGuardar")
                //{
                //    btnEditar_ItemClick(this, null);
                //    this.btnCancelar.Enabled = false;
                //}
                AplicarPrivilegios();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_ItemClick(object sender, ItemClickEventArgs e)
        {
            InicializaNuevoElemento();
            HabilitarControles(true);
            ClearControls();
            this.tabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ValidateChildren();
        }
        
    }
}