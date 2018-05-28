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
        private Decimal TipoCambio;
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

            DataSet DS = new DataSet();
            String sTipoCambio = CG.ParametrosContabilidadDAC.GetTipoCambioModulo();
            DS = CG.TipoCambioDetalleDAC.GetData(sTipoCambio, DateTime.Now);

            TipoCambio = Convert.ToDecimal((DS.Tables[0].Rows.Count == 0) ? 0 : DS.Tables[0].Rows[0]["Monto"]);
            
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
               this.slkupLote.ReadOnly = !Activo;
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



           private void PopulateGrid(bool GetDataByDB)
           {

               if (GetDataByDB) _dsDetalle = clsDocumentoInvDetalle.GetData((int)_currentRow["IDTransaccion"]);
               _dtDetalle = _dsDetalle.Tables[0];

               this.dtgDetalle.DataSource = _dtDetalle;
               
           }

           private void LimpiarCamposDetalle() {
               this.slkupTransaccion.EditValue = null;
               this.slkupProducto.EditValue = null;
               this.slkupLote.EditValue = null;
               this.slkupBodegaOrigen.EditValue = null;
               this.txtCantidad.EditValue = null;
               this.txtCostoDolar.EditValue = null;
               this.txtCostoLocal.EditValue = null;
               this.txtPrecioDolar.EditValue = null;
               this.txtPrecioLocal.EditValue=null;
           }

        private void LayoutDetalleDocumento_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            DataRowView dr;
            switch (e.Button.Properties.Caption) { 
                case "Agregar":
                    
                    AccionDetalle = "Agregar";
                    HabilitarControlesDetalle(true);
                    break;
                case "Editar":
                    AccionDetalle = "Editar";
                    HabilitarControlesDetalle(true);
                    if (slkupTransaccion.EditValue != null)
                    {
                       dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                        if (Convert.ToBoolean(dr["EsVenta"]))
                        {
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
                    break;
                case "Eliminar":
                    break;
                case "Cancelar":
                    AccionDetalle = "View";
                    HabilitarControlesDetalle(false);
                    LimpiarCamposDetalle();
                    break;
                case "Guardar":
                    if (!ValidaDatosDetalle()) return;

                    //Validar si la fecha del asiento contable corresponde a una fecha valida
                

                    //Obtener los datos
                  

                    //if (_currentRow != null)
                    if (AccionDetalle != "Agregar")
                    {

                        Application.DoEvents();
                        _currentRowDetalle.BeginEdit();

                        
                        
                        //_dsProducto.Tables[0].Rows.Add(_currentRow);
                        _currentRowDetalle["IDTransaccion"] = -1;
                        dr = (DataRowView)slkupProducto.Properties.View.GetRow(slkupProducto.Properties.GetIndexByKeyValue(slkupProducto.EditValue));
                        _currentRowDetalle["IDProducto"] = Convert.ToInt32(this.slkupProducto.EditValue);
                        _currentRowDetalle["DescrProducto"] = dr["Descr"].ToString();
                        _currentRowDetalle["IDLote"] = Convert.ToInt32(this.slkupLote.EditValue);
                        dr = (DataRowView)slkupLote.Properties.View.GetRow(slkupLote.Properties.GetIndexByKeyValue(slkupLote.EditValue));
                        _currentRowDetalle["LoteInterno"] = dr["LoteInterno"].ToString();
                        _currentRowDetalle["IDTipoTran"] = Convert.ToInt32(this.slkupTransaccion.EditValue);
                        dr = (DataRowView)slkupBodegaOrigen.Properties.View.GetRow(slkupBodegaOrigen.Properties.GetIndexByKeyValue(slkupBodegaOrigen.EditValue));
                        _currentRowDetalle["IDBodegaOrigen"] = Convert.ToInt32(this.slkupBodegaOrigen.EditValue);
                        _currentRowDetalle["DescrBodegaOrigen"] = dr["Descr"].ToString();
                        dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                        if (dr["Transaccion"].ToString() == "TR")
                        {
                            dr = (DataRowView)slkupBodegaDestino.Properties.View.GetRow(slkupBodegaDestino.Properties.GetIndexByKeyValue(slkupBodegaDestino.EditValue));
                            _currentRowDetalle["IDBodegaDestino"] = Convert.ToInt32(this.slkupBodegaDestino.EditValue);
                            _currentRowDetalle["DescrBodegaDestino"] = dr["Descr"].ToString();
                        }
                        
                        _currentRowDetalle["IDTraslado"] = Convert.ToInt32(this.txtIDTraslado.EditValue);
                        _currentRowDetalle["Cantidad"] = Convert.ToDecimal(this.txtCantidad.EditValue);
                        _currentRowDetalle["PrecioUntLocal"] = Convert.ToDecimal(this.txtPrecioLocal.EditValue);
                        _currentRowDetalle["PrecioUntDolar"] = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
                        _currentRowDetalle["CostoUntLocal"] = Convert.ToDecimal(this.txtCostoLocal.EditValue);
                        _currentRowDetalle["CostoUntDolar"] = Convert.ToDecimal(this.txtCostoDolar.EditValue);
                        dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                        _currentRowDetalle["Transaccion"] = dr["Transaccion"].ToString();
                        _currentRowDetalle["DescrTipoTran"] = dr["Descr"].ToString();
                        _currentRowDetalle["Factor"] = dr["Factor"].ToString();
                        _currentRowDetalle["Naturaleza"] = dr["Naturaleza"].ToString();
                        _currentRowDetalle["TipoCambio"] = 0;
                        _currentRowDetalle["Aplicado"] = 0;
                        _currentRow.EndEdit();

                        //DataSet _dsChanged = _dsDocumentoInv.GetChanges(DataRowState.Modified);

                        //bool okFlag = true;
                        //if (_dsChanged.HasErrors)
                        //{
                        //    okFlag = false;
                        //    string msg = "Error en la fila con el tipo Id";

                        //    foreach (DataTable tb in _dsChanged.Tables)
                        //    {
                        //        if (tb.HasErrors)
                        //        {
                        //            DataRow[] errosRow = tb.GetErrors();

                        //            foreach (DataRow dr in errosRow)
                        //            {
                        //                msg = msg + dr["IdDocumento"].ToString();
                        //            }
                        //        }
                        //    }

                        //    //lblStatus.Caption = msg;
                        //}

                        ////Si no hay errores

                        //if (okFlag)
                        //{
                            //clsDocumentoInvCabecera.oAdaptador.Update(_dsChanged, "Data");
                            //lblStatus.Caption = "Actualizado " + _currentRow["Descr"].ToString();
                            //Application.DoEvents();

                            //_dsDocumentoInv.AcceptChanges();
                          
                            AccionDetalle = "View";
                            AplicarPrivilegios();
                        //}
                        //else
                        //{
                        //    _dsDocumentoInv.RejectChanges();

                        //}


                    }
                    else {

                        

                        _currentRowDetalle = _dtDetalle.NewRow();
                        //_currentRow["IDProducto"] = this.txtIDProducto.Text.Trim();
                        _currentRowDetalle["IDTransaccion"] = -1;
                        dr = (DataRowView)slkupProducto.Properties.View.GetRow(slkupProducto.Properties.GetIndexByKeyValue(slkupProducto.EditValue));
                        _currentRowDetalle["IDProducto"] = Convert.ToInt32(this.slkupProducto.EditValue);
                        _currentRowDetalle["DescrProducto"] = dr["Descr"].ToString();
                        _currentRowDetalle["IDLote"] = Convert.ToInt32(this.slkupLote.EditValue);
                        dr = (DataRowView)slkupLote.Properties.View.GetRow(slkupLote.Properties.GetIndexByKeyValue(slkupLote.EditValue));
                        _currentRowDetalle["LoteInterno"] = dr["LoteInterno"].ToString();
                        _currentRowDetalle["IDTipoTran"] = Convert.ToInt32(this.slkupTransaccion.EditValue);
                        dr = (DataRowView)slkupBodegaOrigen.Properties.View.GetRow(slkupBodegaOrigen.Properties.GetIndexByKeyValue(slkupBodegaOrigen.EditValue));
                        _currentRowDetalle["IDBodegaOrigen"] = Convert.ToInt32(this.slkupBodegaOrigen.EditValue);
                        _currentRowDetalle["DescrBodegaOrigen"] = dr["Descr"].ToString();
                        dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                        if (dr["Transaccion"].ToString() =="TR")
                        {
                            dr = (DataRowView)slkupBodegaDestino.Properties.View.GetRow(slkupBodegaDestino.Properties.GetIndexByKeyValue(slkupBodegaDestino.EditValue));
                            _currentRowDetalle["IDBodegaDestino"] = Convert.ToInt32(this.slkupBodegaDestino.EditValue);
                            _currentRowDetalle["DescrBodegaDestino"] = dr["Descr"].ToString();
                        }
                        _currentRowDetalle["IDTraslado"] = Convert.ToInt32(this.txtIDTraslado.EditValue);
                        _currentRowDetalle["Cantidad"] = Convert.ToDecimal(this.txtCantidad.EditValue);
                        _currentRowDetalle["PrecioUntLocal"] = Convert.ToDecimal(this.txtPrecioLocal.EditValue);
                        _currentRowDetalle["PrecioUntDolar"] = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
                        _currentRowDetalle["CostoUntLocal"] = Convert.ToDecimal(this.txtCostoLocal.EditValue);
                        _currentRowDetalle["CostoUntDolar"] = Convert.ToDecimal(this.txtCostoDolar.EditValue);
                        dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                        _currentRowDetalle["Transaccion"] = dr["Transaccion"].ToString();
                        _currentRowDetalle["DescrTipoTran"] = dr["Descr"].ToString();
                        _currentRowDetalle["Factor"] = dr["Factor"].ToString();
                        _currentRowDetalle["Naturaleza"] = dr["Naturaleza"].ToString();
                        _currentRowDetalle["TipoCambio"] = 0;
                        _currentRowDetalle["Aplicado"] = 0;

                        //Validar que el elemento no exista
                        DataView Dv = new DataView();
                        Dv.Table = ((DataView)gridViewDetalle.DataSource).ToTable();
                        Dv.RowFilter = string.Format("IDProducto={0} and IDLote ={1} and IDTipoTran = {2}", _currentRowDetalle["IDProducto"], _currentRowDetalle["IDLote"], _currentRowDetalle["IDTipoTran"]);

                        if (Dv.ToTable().Rows.Count > 0)
                        {
                            MessageBox.Show("El elemento que desea agregar ya existe en la lista, por favor verifique");
                            return;
                        }


                        _dtDetalle.Rows.Add(_currentRowDetalle);

                        try
                        {
                            //clsDocumentoInvCabecera.oAdaptador.Update(_dsDocumentoInv, "Data");
                            //_dsDocumentoInv.AcceptChanges();

                            //this.txt.EditValue = clsProductoDAC.oAdaptador.InsertCommand.Parameters["@IDProducto"].Value.ToString();
                            //lblStatus.Caption = "Se ha ingresado un nuevo registro";
                            Application.DoEvents();
                        
                          
                            AccionDetalle = "View";
                            AplicarPrivilegios();
                            LimpiarCamposDetalle();
                        
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            //_dsDocumentoInv.RejectChanges();
                            //_currentRow = null;
                            MessageBox.Show(ex.Message);
                        }
                
                    }
                    AccionDetalle = "View";
                    PopulateGrid(false);                    
                    HabilitarControlesDetalle(false);
                    this.gridViewDetalle.ClearSelection();
                      this.gridViewDetalle.FocusedRowHandle = -1;
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
               if  (this.txtPrecioDolar.EditValue ==null || this.txtPrecioLocal.EditValue.ToString()=="")
                   sMensaje = " • Ingrese el precio del producto \n\r";
            }
            else if (Convert.ToBoolean(dr["EsAjuste"]) || Convert.ToBoolean(dr["EsCompra"]))
            {
                if (this.txtCostoDolar.EditValue == null|| this.txtCostoLocal.EditValue.ToString() == "")
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

        private void BotoneriaSuperior() {
            if (Accion == "New")
            {
                this.btnAddDoc.Enabled = false;
                this.btnCancelDoc.Enabled = true;
                this.btnSaveDoc.Enabled = true;
                this.btnPrintDoc.Enabled = false;
            }
            else
            {
                this.btnAddDoc.Enabled = true;
                this.btnSaveDoc.Enabled = false;
                this.btnCancelDoc.Enabled = false;
                this.btnPrintDoc.Enabled = true;
            }
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
   
                Util.Util.ConfigLookupEdit(this.slkupProducto, clsProductoDAC.GetData(-1, "*","*", -1,-1,-1,-1,-1,-1,"*",-1,-1,-1).Tables[0], "Descr", "IDProducto");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupProducto, "[{'ColumnCaption':'IdProducto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.SetFormatTextEdit(txtCantidad, Util.Util.FormatType.Numerico);
                Util.Util.SetFormatTextEdit(txtCostoDolar, Util.Util.FormatType.MonedaExtrangera);
                Util.Util.SetFormatTextEdit(txtCostoLocal, Util.Util.FormatType.MonedaLocal);
                Util.Util.SetFormatTextEdit(txtPrecioDolar, Util.Util.FormatType.MonedaExtrangera);
                Util.Util.SetFormatTextEdit(txtPrecioLocal, Util.Util.FormatType.MonedaLocal);
                BotoneriaSuperior();
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
                    
                    PopulateGrid(true);
                    AplicarPrivilegios();
                    this.txtReferencia.Focus();
                }
                else
                {
                    
                    Accion = "View";
                    PopulateGrid(true);
                    HabilitarControlesCabecera(false);

                }

                HabilitarControlesDetalle(false);                    
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
            if (AccionDetalle == "Agregar")
            {
                if (slkupTransaccion.EditValue != null)
                {
                    DataRowView dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                    if (Convert.ToBoolean(dr["EsVenta"]))
                    {
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

        private void slkupProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupProducto.EditValue != null)
            {
                Util.Util.ConfigLookupEdit(this.slkupLote, clsLoteDAC.GetData(-1, Convert.ToInt32(slkupProducto.EditValue), "*", "*").Tables[0], "LoteInterno", "IDLote");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupLote, "[{'ColumnCaption':'IDLote','ColumnField':'IdLote','width':30},{'ColumnCaption':'Lote','ColumnField':'LoteInterno','width':70}]");
                this.slkupLote.Enabled = true;
            }
            else {
                this.slkupLote.Enabled = false;
            }
        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridViewDetalle.FocusedRowHandle;
            if (index > -1)
            {
                _currentRowDetalle = gridViewDetalle.GetDataRow(index);
                UpdateControlsFromCurrentRow(_currentRowDetalle);
            }
        }

        private void UpdateControlsFromCurrentRow(DataRow _currentRowDetalle)
        {
            this.slkupTransaccion.EditValue = _currentRowDetalle["IDTipoTran"];
            this.slkupProducto.EditValue = _currentRowDetalle["IDProducto"];
            this.slkupLote.EditValue = _currentRowDetalle["IDLote"];
            this.slkupBodegaOrigen.EditValue = _currentRowDetalle["IDBodegaOrigen"];
            this.slkupBodegaDestino.EditValue = _currentRowDetalle["IDBodegaDestino"];
            this.txtCantidad.EditValue = _currentRowDetalle["Cantidad"];
            this.txtPrecioLocal.EditValue = _currentRowDetalle["PrecioUntLocal"];
            this.txtPrecioDolar.EditValue = _currentRowDetalle["PrecioUntDolar"];
            this.txtCostoLocal.EditValue = _currentRowDetalle["PrecioUntLocal"];
        }


        private void gridViewDetalle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

        private bool ValidasDatosCabecera() {
            bool result = true;
            String sMensaje = "";
            if (this.txtReferencia.Text.Trim() == "")
                sMensaje = sMensaje + " • Por favor ingrese la referencia del documento\n\r";
            if (this.dtpFecha.EditValue.ToString() == "" || this.dtpFecha.EditValue == null)
                sMensaje = sMensaje + " • Por favor seleccione la fecha del documento \n\r";
            if (_dtDetalle.Rows.Count == 0)
                sMensaje = sMensaje + " • Debe ingresar al menos una linea en el documento para poder aplicarlo \n\r";
            if (sMensaje !="") {
                MessageBox.Show("Estimado, usuario por favor verifique los siguientes campos: \n\r" + sMensaje);
                result = false;
            }
            return result;            
        }

        private void btnSaveDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Validar  los datos de Cabecera
            if (ValidasDatosCabecera()) { 
                //Proceder a guardar los datos de cabecera.
                _currentRow = _dtDocumentoInv.NewRow();
                _currentRow["IDTransaccion"] = -1;
                _currentRow["ModuloOrigen"] = this.txtModuloOrigen.EditValue.ToString() ;
                _currentRow["IDPaquete"] = this.IDPaquete;
                _currentRow["Fecha"] = this.dtpFecha.EditValue;
                _currentRow["Usuario"]= sUsuario;
                _currentRow["Referencia"] =this.txtReferencia.Text.Trim();
                _currentRow["Documento"] = this.txtDocumento.Text.Trim();
                _currentRow["Aplicado"] = true;
                _currentRow["UniqueValue"] = Guid.NewGuid();
                _currentRow["EsTraslado"] = false; //Cambiar
                _currentRow["IDTraslado"] = "-1"; //Cambiar
                _currentRow["CreateDate"] = DateTime.Now;

                _dsDocumentoInv.Tables[0].Rows.Add(_currentRow);

                ConnectionManager.BeginTran();
                clsDocumentoInvCabecera.SetTransactionToAdaptador(true);
                clsDocumentoInvDetalle.SetTransactionToAdaptador(true);

                DataSet dsTemp = clsDocumentoInvDetalle.GetData(-1);
                try
                {
                    clsDocumentoInvCabecera.oAdaptador.Update(_dsDocumentoInv, "Data");
                    _dsDocumentoInv.AcceptChanges();

                    this.txtIDTransaccion.EditValue = _dsDocumentoInv.Tables[0].Rows[0]["IDTransaccion"];
                    this.txtDocumento.EditValue = _dsDocumentoInv.Tables[0].Rows[0]["Documento"];
                    DataTable dtTemp = dsTemp.Tables[0];

                    

                    //Actualizar los datos
                    for (int i = 0; i < _dsDetalle.Tables[0].Rows.Count; i++) {
                        _currentRowDetalle =  dtTemp.NewRow();
                        _currentRowDetalle["IDTransaccion"] = _dsDocumentoInv.Tables[0].Rows[0]["IDTransaccion"];
                        _currentRowDetalle["IDProducto"] = _dsDetalle.Tables[0].Rows[i]["IDProducto"];
                        _currentRowDetalle["IDLote"] = _dsDetalle.Tables[0].Rows[i]["IDLote"];
                        _currentRowDetalle["IDTipoTran"] = _dsDetalle.Tables[0].Rows[i]["IDTipoTran"];
                        _currentRowDetalle["IDBodega"] = _dsDetalle.Tables[0].Rows[i]["IDBodegaOrigen"];
                        _currentRowDetalle["IDTraslado"] = _dsDetalle.Tables[0].Rows[i]["IDTraslado"];
                        _currentRowDetalle["Naturaleza"] = _dsDetalle.Tables[0].Rows[i]["Naturaleza"];
                        _currentRowDetalle["Factor"] = _dsDetalle.Tables[0].Rows[i]["Factor"];
                        _currentRowDetalle["Cantidad"] = _dsDetalle.Tables[0].Rows[i]["Cantidad"];
                        _currentRowDetalle["CostoUntDolar"] = _dsDetalle.Tables[0].Rows[i]["CostoUntDolar"];
                        _currentRowDetalle["CostoUntLocal"] = _dsDetalle.Tables[0].Rows[i]["CostoUntLocal"];
                        _currentRowDetalle["PrecioUntLocal"] = _dsDetalle.Tables[0].Rows[i]["PrecioUntLocal"];
                        _currentRowDetalle["PrecioUntDolar"] = _dsDetalle.Tables[0].Rows[i]["PrecioUntDolar"];
                        _currentRowDetalle["Transaccion"] = _dsDetalle.Tables[0].Rows[i]["Transaccion"];
                        _currentRowDetalle["Factor"] = _dsDetalle.Tables[0].Rows[i]["Factor"];
                        _currentRowDetalle["Naturaleza"] = _dsDetalle.Tables[0].Rows[i]["Naturaleza"];
                        _currentRowDetalle["TipoCambio"] = _dsDetalle.Tables[0].Rows[i]["TipoCambio"];
                        _currentRowDetalle["Aplicado"] = _dsDetalle.Tables[0].Rows[i]["Aplicado"];
                        dsTemp.Tables[0].Rows.Add(_currentRowDetalle);

                    }

                    clsDocumentoInvDetalle.oAdaptador.Update(dsTemp, "Data");
                    dsTemp.AcceptChanges();
                   
                    Application.DoEvents();

                    Accion = "View";
                    HabilitarControlesCabecera(false);
                    AplicarPrivilegios();
                    BotoneriaSuperior();

                    ConnectionManager.CommitTran();

                    MessageBox.Show("El documento se ha guardado correctamente");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    _dsDocumentoInv.RejectChanges();
                    dsTemp.RejectChanges();
                    ConnectionManager.RollBackTran();
                    //_currentRow = null;
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void txtPrecioLocal_EditValueChanged(object sender, EventArgs e)
        {
            //convertir a Dolar
            Decimal Precio =Convert.ToDecimal( this.txtPrecioLocal.EditValue);
            this.txtPrecioDolar.EditValue = Precio / TipoCambio;
            
        }

        private void txtPrecioDolar_EditValueChanged(object sender, EventArgs e)
        {
            //convertir a Dolar
            Decimal Precio = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
            this.txtPrecioLocal.EditValue = Precio * TipoCambio;
        }

        private void btnAddDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InicializaNuevoElemento();
           
        }

    
    }
}
