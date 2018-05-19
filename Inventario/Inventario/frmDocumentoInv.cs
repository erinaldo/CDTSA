using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
using Security; 
using CI.DAC;

namespace CI
{
    public partial class frmDocumentoInv : Form
    {
        private DataTable _dtDocumentoInv;
        private DataTable _dtDetalle;
        private DataTable _dtPaquete;

        private DataSet _dsDocumentoInv;
        private DataSet _dsDetalle;
        
        private DataTable _dtSecurity;

        private DataRow _currentRow;
        private DataRow _currentRowDetalle;
        private String _tituloVentana = "Documento de Inventario";

        private String Accion = "NEW";
        private int IDPaquete = -1;
        private String AccionDetalle = "";
        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";


        public frmDocumentoInv(int IdPaquete)
        {
            InitializeComponent();
            InicializaNuevoElemento();
            this.IDPaquete = IdPaquete;
        }

         private void InicializaNuevoElemento() {
             Accion = "New";
            _dsDocumentoInv = clsDocumentoInvCabecera.GetDataEmpty();
            _dsDetalle = clsDocumentoInvDetalle.GetDataEmpty();
            _dtPaquete = clsPaqueteDAC.GetData(this.IDPaquete, "*", "*", -1, "*", -1).Tables[0];
            _dtDocumentoInv = _dsDocumentoInv.Tables[0];
            _dtDetalle = _dsDetalle.Tables[0];
            
            _currentRow = null;
            _currentRowDetalle = null;
            InicializarNuevoElemento();
        }

         public frmDocumentoInv(int IDTransaccion, String Accion)
         {
            this.Accion = Accion;
            InitializeComponent();
            cargarDocumento(IDTransaccion);
        }

           private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, sUsuario);
            _dtSecurity = DS.Tables[0];

        }
        
        
        private void InicializarNuevoElemento()
        {

            DataSet DS = new DataSet();
            //Cargar el tipo de cambio por defecto

            _currentRow = _dtDocumentoInv.NewRow();
            _currentRow["IDTransaccion"] = -1;
            _currentRow["ModuloOrigen"] = "CI";
            _currentRow["Fecha"] = DateTime.Now;
            _currentRow["Usuario"] = sUsuario;
            _currentRow["Referencia"] = "";
            _currentRow["Documento"] ="-- --";
            _currentRow["Aplicado"] = false;
            _currentRow["EsTraslado"] =false;
            _currentRow["IDTraslado"] = -1;
            _currentRow["CreateDate"] = DateTime.Now;
            _currentRow["IDPaquete"] =Convert.ToInt32 (_dtPaquete.Rows[0]["IDPaquete"]);
            
        }


        public void cargarDocumento(int IDTransaccion) {
            _dsDocumentoInv = clsDocumentoInvCabecera.GetData(IDTransaccion);
            _dtDocumentoInv = _dsDocumentoInv.Tables[0];
            _currentRow = _dtDocumentoInv.Rows[0];

            _dtPaquete = clsPaqueteDAC.GetData(this.IDPaquete, "*", "*", -1, "*", -1).Tables[0];
            _dsDetalle = clsDocumentoInvDetalle.GetData(IDTransaccion);
            _dtDetalle = _dsDetalle.Tables[0];


        }

           public void UpdateControlsFromDataRow(DataRow row)
        {
            //_currentRow = _dtAsiento.NewRow();
            this.txtDocumento.EditValue = _currentRow["Documento"].ToString();
            this.txtIDTraslado.EditValue = _currentRow["IDTraslado"].ToString();
            this.txtReferencia.EditValue = _currentRow["Referencia"].ToString();
            this.dtpFecha.EditValue = (DateTime)_currentRow["Fecha"];
            this.dtpFechaCreacion.EditValue = (DateTime)_currentRow["CreateDate"];
            this.txtModuloOrigen.EditValue = _currentRow["ModuloOrigen"].ToString();
            this.txtUsuario.EditValue =  _currentRow["Usuario"].ToString();
            this.txtPaquete.Text = string.Format("{0} - {1}", _dtPaquete.Rows[0]["Paquete"], _dtPaquete.Rows[0]["Descr"]); 

            //TODO Actualizar los Costos
            this.txtPrecioDolar.EditValue = 0;
            this.txtPrecioLocal.EditValue = 0;
            this.txtCostoDolar.EditValue = 0;
            this.txtCostoLocal.EditValue = 0;


            this.dtgDetalle.DataSource = _dtDetalle;
          
            
        }


           private void HabilitarControlesCabecera(bool Activo)
           {
               this.txtReferencia.ReadOnly = !Activo;
               this.dtpFecha.ReadOnly = !Activo;   
           }


           private void HabilitarControlesDetalle(bool Activo)
           {
               this.slkupTransaccion.ReadOnly = !Activo;
               this.slkupProducto.ReadOnly = !Activo;
               this.slkupBodegaOrigen.ReadOnly = !Activo;
               if (_dtPaquete.Rows[0]["Paquete"] == "TR")
                   this.slkupBodegaDestino.Enabled = true;
               else
                   this.slkupBodegaDestino.Enabled = false;
               this.txtPrecioDolar.Enabled = false;
               this.txtPrecioLocal.Enabled = false;
               this.txtCostoDolar.Enabled = false;
               this.txtCostoLocal.Enabled = false;
               this.txtCantidad.ReadOnly = !Activo;
               if (AccionDetalle == "Agregar" || AccionDetalle =="Editar")
               {
                   LayoutDetalleDocumento.CustomHeaderButtons["Agregar"].Properties.Enabled = false;
                   LayoutDetalleDocumento.CustomHeaderButtons["Editar"].Properties.Enabled = false;
                   LayoutDetalleDocumento.CustomHeaderButtons["Eliminar"].Properties.Enabled = false;
                   LayoutDetalleDocumento.CustomHeaderButtons["Cancelar"].Properties.Enabled = true;
                   LayoutDetalleDocumento.CustomHeaderButtons["Guardar"].Properties.Enabled = true;
               }
               if (AccionDetalle == "View")
               {
                   LayoutDetalleDocumento.CustomHeaderButtons["Agregar"].Properties.Enabled = true;
                   LayoutDetalleDocumento.CustomHeaderButtons["Editar"].Properties.Enabled = true;
                   LayoutDetalleDocumento.CustomHeaderButtons["Eliminar"].Properties.Enabled = true;
                   LayoutDetalleDocumento.CustomHeaderButtons["Cancelar"].Properties.Enabled = false;
                   LayoutDetalleDocumento.CustomHeaderButtons["Guardar"].Properties.Enabled = false;
               }
               
           }


           private bool ValidaDatos()
           {
               bool result = true;
               String sMensaje = "";

               if (this.txtReferencia.EditValue == null)
                   sMensaje = sMensaje + "     • Ingrese la Referencia del documento. \n\r";
               if (this.dtpFecha.EditValue == null)
                   sMensaje = sMensaje + "     • Seleccione la fecha del documento. \n\r";
               if (((DataTable)this.dtgDetalle.DataSource).Rows.Count ==0)
                   sMensaje = sMensaje + "     • El documento no tienen detalle. \n\r";
               


               if (sMensaje != "")
               {
                   MessageBox.Show("Estimado usuario, favor revise los siguientes errores: \n\r" + sMensaje);
                   result = false;
               }
               return result;
           }


        private void LayoutDetalleDocumento_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption) { 
                case "Agregar":
                    _currentRowDetalle = _dtDetalle.NewRow();
                    _currentRowDetalle["IDTransaccion"] = -1;
                    _currentRowDetalle["IDProducto"] =-1;
                    _currentRowDetalle["IDLote"] = -1;
                    _currentRowDetalle["IDTipoTran"] = -1;
                    _currentRowDetalle["IDBodega"] = -1;
                    _currentRowDetalle["IDTraslado"] = -1;
                    _currentRowDetalle["Cantidad"] = 0;
                    _currentRowDetalle["PrecioUntLocal"] = 0;
                    _currentRowDetalle["PrecioUntDolar"] = 0;
                    _currentRowDetalle["CostoUntLocal"] = 0;
                    _currentRowDetalle["CostoUntDolar"] = 0;
                    _currentRowDetalle["Transaccion"] = "";
                    _currentRowDetalle["TipoCambio"] = 0;
                    _currentRowDetalle["Aplicado"] = 0;
                    AccionDetalle = "Agregar";
                    HabilitarControlesDetalle(true);
                    break;
                case "Editar":
                    AccionDetalle = "Editar";
                    HabilitarControlesDetalle(true);
                    break;
                case "Eliminar":
                    break;
                case "Cancelar":
                    AccionDetalle = "View";
                    HabilitarControlesDetalle(false);
                    break;
                case "Guardar":
                    if (!ValidaDatosDetalle()) return;

                    //Validar si la fecha del asiento contable corresponde a una fecha valida
                

                    //Obtener los datos


                    //if (_currentRow != null)
                    if (Accion != "New")
                    {
                        Application.DoEvents();
                        _currentRow.BeginEdit();

                        

                        //_dsProducto.Tables[0].Rows.Add(_currentRow);
                        _currentRowDetalle["IDTransaccion"] = -1;
                        _currentRowDetalle["IDProducto"] = Convert.ToInt32(this.slkupProducto.EditValue);
                        _currentRowDetalle["IDLote"] = Convert.ToInt32(this.slkupLote.EditValue);
                        _currentRowDetalle["IDTipoTran"] = Convert.ToInt32(this.slkupTransaccion.EditValue);
                        _currentRowDetalle["IDBodega"] = Convert.ToInt32(this.slkupBodegaOrigen.EditValue);
                        _currentRowDetalle["IDTraslado"] = Convert.ToInt32(this.txtIDTraslado.EditValue);
                        _currentRowDetalle["Cantidad"] = Convert.ToDecimal(this.txtCantidad.EditValue);
                        _currentRowDetalle["PrecioUntLocal"] = Convert.ToDecimal(this.txtPrecioLocal.EditValue);
                        _currentRowDetalle["PrecioUntDolar"] = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
                        _currentRowDetalle["CostoUntLocal"] = Convert.ToDecimal(this.txtCostoLocal.EditValue);
                        _currentRowDetalle["CostoUntDolar"] = Convert.ToDecimal(this.txtCostoDolar.EditValue);
                        _currentRowDetalle["Transaccion"] = Convert.ToDecimal(this.txtIDTransaccion.EditValue);
                        _currentRowDetalle["TipoCambio"] = 0;
                        _currentRowDetalle["Aplicado"] = 0;
                        _currentRow.EndEdit();

                        DataSet _dsChanged = _dsDocumentoInv.GetChanges(DataRowState.Modified);

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
                                        msg = msg + dr["IdDocumento"].ToString();
                                    }
                                }
                            }

                            //lblStatus.Caption = msg;
                        }

                        //Si no hay errores

                        if (okFlag)
                        {
                            clsDocumentoInvCabecera.oAdaptador.Update(_dsChanged, "Data");
                            //lblStatus.Caption = "Actualizado " + _currentRow["Descr"].ToString();
                            Application.DoEvents();

                            _dsDocumentoInv.AcceptChanges();
                            HabilitarControlesCabecera(false);
                            Accion = "View";
                            AplicarPrivilegios();
                        }
                        else
                        {
                            _dsDocumentoInv.RejectChanges();

                        }


                    }
                    else {

                        _currentRow = _dtDocumentoInv.NewRow();
                        //_currentRow["IDProducto"] = this.txtIDProducto.Text.Trim();
                        _currentRowDetalle["IDTransaccion"] = -1;
                        _currentRowDetalle["IDProducto"] = Convert.ToInt32(this.slkupProducto.EditValue);
                        _currentRowDetalle["IDLote"] = Convert.ToInt32(this.slkupLote.EditValue);
                        _currentRowDetalle["IDTipoTran"] = Convert.ToInt32(this.slkupTransaccion.EditValue);
                        _currentRowDetalle["IDBodega"] = Convert.ToInt32(this.slkupBodegaOrigen.EditValue);
                        _currentRowDetalle["IDTraslado"] = Convert.ToInt32(this.txtIDTraslado.EditValue);
                        _currentRowDetalle["Cantidad"] = Convert.ToDecimal(this.txtCantidad.EditValue);
                        _currentRowDetalle["PrecioUntLocal"] = Convert.ToDecimal(this.txtPrecioLocal.EditValue);
                        _currentRowDetalle["PrecioUntDolar"] = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
                        _currentRowDetalle["CostoUntLocal"] = Convert.ToDecimal(this.txtCostoLocal.EditValue);
                        _currentRowDetalle["CostoUntDolar"] = Convert.ToDecimal(this.txtCostoDolar.EditValue);
                        _currentRowDetalle["Transaccion"] = Convert.ToDecimal(this.txtIDTransaccion.EditValue);
                        _currentRowDetalle["TipoCambio"] = 0;
                        _currentRowDetalle["Aplicado"] = 0;

                        _dtDocumentoInv.Rows.Add(_currentRow);

                        try
                        {
                            clsDocumentoInvCabecera.oAdaptador.Update(_dsDocumentoInv, "Data");
                            _dsDocumentoInv.AcceptChanges();

                            //this.txt.EditValue = clsProductoDAC.oAdaptador.InsertCommand.Parameters["@IDProducto"].Value.ToString();
                            //lblStatus.Caption = "Se ha ingresado un nuevo registro";
                            Application.DoEvents();
                        
                            HabilitarControlesCabecera(false);
                            Accion = "View";
                            AplicarPrivilegios();
                        
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            _dsDocumentoInv.RejectChanges();
                            //_currentRow = null;
                            MessageBox.Show(ex.Message);
                        }
                
                    }
                    AccionDetalle = "View";
                    HabilitarControlesDetalle(false);
                    break;
            }
               
        }

        private bool ValidaDatosDetalle()
        {
            bool result = true;
            String sMensaje = "";
            if (this.slkupTransaccion.EditValue.ToString() == "" || this.slkupTransaccion.EditValue == null)
                sMensaje = " • Por favor seleccion la Transacción\n\r";
            if (this.slkupProducto.EditValue.ToString() == "" || this.slkupProducto.EditValue == null)
                sMensaje = " • Por favor seleccion el producto \n\r";
            if (this.txtCantidad.EditValue.ToString() == "" )
                sMensaje = " • Por favor ingrese la cantidad\n\r";
            
            DataRowView dr =  (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
            if (Convert.ToBoolean(dr["EsVenta"])) {
               if  (this.txtPrecioDolar.EditValue.ToString() == "" || this.txtPrecioLocal.EditValue.ToString()=="")
                   sMensaje = " • Ingrese el precio del producto \n\r";
            }
            else if (Convert.ToBoolean(dr["EsAjuste"]) || Convert.ToBoolean(dr["EsCompra"]))
            {
                if (this.txtCostoDolar.EditValue.ToString() == "" || this.txtCostoLocal.EditValue.ToString() == "")
                    sMensaje = " • Ingrese sel costo del producto \n\r";
            }

            if (sMensaje != "") {
                MessageBox.Show("Estimado usuario, favor revise los siguientes errores: \n\r" + sMensaje);
                result = false;
            }
            return result;
        }

        private void ClearControlsCabecera()
        {
            this.txtReferencia.EditValue = "";
            this.dtpFecha.EditValue = "";
            
        }

        private void frmDocumentoInv_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControlesCabecera(false);
                CargarPrivilegios();
                Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, _tituloVentana, this);


                Util.Util.ConfigLookupEdit(this.slkupTransaccion, clsGlobalTipoTransaccionDAC.Get(-1, "*", "*", _dtPaquete.Rows[0]["Transaccion"].ToString()).Tables[0], "Descr", "IDTipoTran");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTransaccion, "[{'ColumnCaption':'TipoTran','ColumnField':'IDTipoTran','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupBodegaOrigen, clsBodegaDAC.GetData(-1,"*",-1).Tables[0], "Descr", "IDBodega");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodegaOrigen, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupBodegaDestino, clsBodegaDAC.GetData(-1, "*", -1).Tables[0], "Descr", "IDBodega");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodegaDestino, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupLote, clsBodegaDAC.GetData(-1, "*", -1).Tables[0], "Descr", "IDBodega");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupLote, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupProducto, clsProductoDAC.GetData(-1, "*","*", -1,-1,-1,-1,-1,-1,"*",-1,-1,-1).Tables[0], "Descr", "IDProducto");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupProducto, "[{'ColumnCaption':'IdProducto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.SetFormatTextEdit(txtCantidad, Util.Util.FormatType.Numerico);
                Util.Util.SetFormatTextEdit(txtCostoDolar, Util.Util.FormatType.MonedaExtrangera);
                Util.Util.SetFormatTextEdit(txtCostoLocal, Util.Util.FormatType.MonedaLocal);
                Util.Util.SetFormatTextEdit(txtPrecioDolar, Util.Util.FormatType.MonedaExtrangera);
                Util.Util.SetFormatTextEdit(txtPrecioLocal, Util.Util.FormatType.MonedaLocal);

                UpdateControlsFromDataRow(_currentRow);

                if (Accion == "New")
                {
                    //Cargar  datos del Paquete

                    HabilitarControlesCabecera(true);
                    
                    this.ValidateChildren();
                    this.txtReferencia.Focus();
                }
                else if (Accion == "Edit")
                {
                    
                    HabilitarControlesCabecera(true);
                    AplicarPrivilegios();
                    this.txtReferencia.Focus();
                }
                else
                {
                    
                    Accion = "View";
                    HabilitarControlesCabecera(false);

                }

                //if (_Estado == "PndtGuardar")
                //{
                //    btnEditar_ItemClick(this, null);
                //    this.btnCancelar.Enabled = false;
                //}
                AplicarPrivilegios();
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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

        private void slkupTransaccion_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView dr =  (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
            if (Convert.ToBoolean(dr["EsVenta"])) {
                this.txtCostoDolar.Enabled = false;
                this.txtCostoLocal.Enabled = false;
                this.txtPrecioDolar.Enabled = true;
                this.txtPrecioLocal.Enabled = true;
            }
            else if (Convert.ToBoolean(dr["EsAjuste"]) || Convert.ToBoolean(dr["EsCompra"]))
            {
                this.txtCostoDolar.Enabled = true;
                this.txtCostoLocal.Enabled = true;
                this.txtPrecioDolar.Enabled = false;
                this.txtPrecioLocal.Enabled = false;
            }

        }
   
    }
}
