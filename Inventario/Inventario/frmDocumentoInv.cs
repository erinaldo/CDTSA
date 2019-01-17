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
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;


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
        private String Error = "";
        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        private bool bCostoLocalActive = false;
        private bool bPrecioLocalActive = false;

        public frmDocumentoInv(int IdPaquete)
        {
            InitializeComponent();
            this.IDPaquete = IdPaquete;
            InicializaNuevoElemento();
            
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
            DataSet DS = new DataSet();
            String sTipoCambio = CG.ParametrosContabilidadDAC.GetTipoCambioModulo();
            DS = CG.TipoCambioDetalleDAC.GetData(sTipoCambio, DateTime.Now);

            TipoCambio = Convert.ToDecimal((DS.Tables[0].Rows.Count == 0) ? 0 : DS.Tables[0].Rows[0]["Monto"]);
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
            _currentRow["Asiento"] = "--";
            _currentRow["IDTraslado"] = -1;
            _currentRow["CreateDate"] = DateTime.Now;
            _currentRow["IDPaquete"] =Convert.ToInt32 (_dtPaquete.Rows[0]["IDPaquete"]);
            
        }


        public void cargarDocumento(long IDTransaccion) {
            try
            {
                _dsDocumentoInv = clsDocumentoInvCabecera.GetData(IDTransaccion);
                this.IDPaquete = Convert.ToInt32(_dsDocumentoInv.Tables[0].Rows[0]["IDPaquete"]);
                if (_dsDocumentoInv.Tables.Count > 0 && _dsDocumentoInv.Tables[0].Rows.Count > 0)
                {
                    _dtDocumentoInv = _dsDocumentoInv.Tables[0];
                    _currentRow = _dtDocumentoInv.Rows[0];
                }
                else {
                    this.Error = "  • El documento que quiere visualizar no existe en la base de datos";

                    return;
                }


                _dtPaquete = clsPaqueteDAC.GetData(this.IDPaquete, "*", "*", -1, "*", -1).Tables[0];
                _dsDetalle = clsDocumentoInvDetalle.GetData(IDTransaccion);
                _dtDetalle = _dsDetalle.Tables[0];
            }
            catch (Exception ex) {
                MessageBox.Show("Error:  \n\r"  + ex.Message);
            }


        }

        public void UpdateControlsFromDataRow(DataRow row)
        {
            //_currentRow = _dtAsiento.NewRow();
            this.txtDocumento.EditValue = _currentRow["Documento"].ToString();
            this.txtIDTransaccion.EditValue = (_currentRow["IDTransaccion"].ToString()=="-1") ? "--": _currentRow["IDTransaccion"].ToString();
            this.txtIDTraslado.EditValue = (_currentRow["IDTraslado"].ToString()=="-1") ? "--" : _currentRow["IDTraslado"].ToString();
            this.hlblAsiento.Text = _currentRow["Asiento"].ToString();
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
               this.slkupTransaccion.TabStop = Activo;
               this.slkupProducto.ReadOnly = !Activo;
               this.slkupProducto.TabStop = Activo;
               this.slkupLote.ReadOnly = !Activo;
               this.slkupLote.TabStop = Activo;
               this.slkupBodegaOrigen.ReadOnly = !Activo;
               this.slkupBodegaOrigen.TabStop = Activo;
               if (_dtPaquete.Rows[0]["Transaccion"].ToString() == "TR" && Activo)
               {
                   this.slkupBodegaDestino.ReadOnly = !Activo;
                   this.slkupBodegaDestino.TabStop = Activo;
                   
               }
               else
               {
                   this.slkupBodegaDestino.ReadOnly = true;
                   this.slkupBodegaDestino.TabStop = false;
                   
               }

               
              
               this.txtPrecioDolar.Enabled = false;
               this.txtPrecioDolar.TabStop = false;
               this.txtPrecioLocal.Enabled = false;
               this.txtPrecioLocal.TabStop = false;
               this.txtCostoDolar.Enabled = false;
               this.txtCostoDolar.TabStop = false;
               this.txtCostoLocal.Enabled = false;
               this.txtCostoLocal.TabStop = false;
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

               if (GetDataByDB) _dsDetalle = clsDocumentoInvDetalle.GetData(Convert.ToInt32(_currentRow["IDTransaccion"].ToString()));
               _dtDetalle = _dsDetalle.Tables[0];

               this.dtgDetalle.DataSource = _dtDetalle;
               
           }

           private void LimpiarCamposDetalle() {
               this.slkupTransaccion.EditValue = null;
               this.slkupProducto.EditValue = null;
               this.slkupLote.EditValue = null;
               this.slkupBodegaOrigen.EditValue = null;
               this.slkupBodegaDestino.EditValue = null;
               this.txtCantidad.EditValue = null;
               this.txtCostoDolar.EditValue = null;
               this.txtCostoLocal.EditValue = null;
               this.txtPrecioDolar.EditValue = null;
               this.txtPrecioLocal.EditValue=null;
           }


           private void HandlerMenu(String sOption) {

               DataRowView dr;
               switch (sOption)
               {
                   case "Agregar":

                       AccionDetalle = "Agregar";
                       HabilitarControlesDetalle(true);
                       this.slkupTransaccion.Focus();
                       break;
                   case "Editar":
                       AccionDetalle = "Editar";
                       HabilitarControlesDetalle(true);
                       if (this.gridViewDetalle.GetSelectedRows().Count() > 0)
                       {
                           DataRow row = this.gridViewDetalle.GetDataRow(0);
                           this.slkupTransaccion.EditValue = row["IDTipoTran"];
                           this.slkupProducto.EditValue = row["IDProducto"];
                           this.slkupLote.EditValue = row["IDLote"];
                           this.slkupTransaccion.ShowPopup();
                           this.slkupTransaccion.ClosePopup();

                           //    
                           this.slkupBodegaOrigen.EditValue = row["IDBodegaOrigen"];
                           this.txtCantidad.EditValue = row["Cantidad"];


                           if (slkupTransaccion.EditValue != null)
                           {
                               //dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                               dr = (DataRowView)slkupTransaccion.Properties.GetRowByKeyValue(this.slkupTransaccion.EditValue);
                               if (Convert.ToBoolean(dr["EsVenta"]))
                               {
                                   this.txtCostoDolar.Enabled = false;
                                   this.txtCostoLocal.Enabled = false;
                                   this.txtPrecioDolar.Enabled = true;
                                   this.txtPrecioLocal.Enabled = true;
                                   this.txtPrecioDolar.EditValue = row["PrecioUntDolar"];
                                   this.txtPrecioLocal.EditValue = row["PrecioUntLocal"];


                               }
                               else if ((Convert.ToBoolean(dr["EsAjuste"]) && Convert.ToInt32(dr["Factor"]) > 0) || Convert.ToBoolean(dr["EsCompra"]))
                               {
                                   this.txtCostoDolar.Enabled = true;
                                   this.txtCostoLocal.Enabled = true;
                                   this.txtPrecioDolar.Enabled = false;
                                   this.txtPrecioLocal.Enabled = false;
                                   this.txtCostoLocal.EditValue = row["CostoUntLocal"];
                                   this.txtCostoDolar.EditValue = row["CostoUntDolar"];
                               }
                               else if (Convert.ToBoolean(dr["EsTraslado"]))
                               {
                                   this.slkupBodegaDestino.EditValue = row["IDBodegaDestino"];
                                   this.txtCostoDolar.Enabled = false;
                                   this.txtCostoLocal.Enabled = false;
                                   this.txtPrecioDolar.Enabled = false;
                                   this.txtPrecioLocal.Enabled = false;
                               }
                               else
                               {
                                   this.txtCostoDolar.Enabled = false;
                                   this.txtCostoLocal.Enabled = false;
                                   this.txtPrecioDolar.Enabled = false;
                                   this.txtPrecioLocal.Enabled = false;
                               }
                           }
                       }
                       break;
                   case "Eliminar":
                       if (this.gridViewDetalle.GetSelectedRows().Count() > 0)
                       {
                           DataRow row = this.gridViewDetalle.GetDataRow(0);
                           _dsDetalle.Tables[0].Rows.Remove(row);
                       }
                       break;
                   case "Cancelar":
                       AccionDetalle = "View";
                       HabilitarControlesDetalle(false);
                       LimpiarCamposDetalle();
                       break;
                   case "Guardar":
                       String sEstado = "";
                       if (!ValidaDatosDetalle()) return;

                       //Traer la transaccion
                       DataTable dt = clsGlobalTipoTransaccionDAC.Get(Convert.ToInt32(this.slkupTransaccion.EditValue), "*", "*", "*").Tables[0];

                       //Validar Existencias si la transaccion lo require.
                       if (dt.Rows[0]["Naturaleza"].ToString() == "S")
                       {
                           DataSet dsExistencias = clsExistenciaBodegaDAC.GetExistenciasBodega(Convert.ToInt32(this.slkupBodegaOrigen.EditValue), Convert.ToInt32(this.slkupProducto.EditValue), Convert.ToInt32(this.slkupLote.EditValue));
                           if (dsExistencias.Tables.Count > 0 && dsExistencias.Tables[0].Rows.Count > 0)
                           {
                               decimal Existencia = Convert.ToDecimal(dsExistencias.Tables[0].Rows[0]["Existencia"]);
                               decimal Cantidad = Convert.ToDecimal(txtCantidad.Text.Trim());

                               if (Existencia < Cantidad)
                               {
                                   sEstado = "E";
                                   //Cambiar mostrar popup y agregar al inventari con una sena
                                   MessageBox.Show("Alerta: no hay suficiente inventario para satisfacer ");
                               }
                           }
                           else
                           {

                               sEstado = "E";
                               //Cambiar mostrar popup y agregar al inventari con una sena
                               MessageBox.Show("Alerta: no hay suficiente inventario para satisfacer ");
                           }
                       }

                       //Validar si la fecha del asiento contable corresponde a una fecha valida


                       //Obtener los datos


                       //if (_currentRow != null)
                       if (AccionDetalle != "Agregar")
                       {

                           Application.DoEvents();
                           _currentRowDetalle.BeginEdit();



                           //_dsProducto.Tables[0].Rows.Add(_currentRow);
                           _currentRowDetalle["IDTransaccion"] = -1;
                           _currentRowDetalle["Estado"] = sEstado;
                           //dr = (DataRowView)slkupProducto.Properties.View.GetRow(slkupProducto.Properties.GetIndexByKeyValue(slkupProducto.EditValue));
                           dr = (DataRowView)slkupProducto.Properties.GetRowByKeyValue(slkupProducto.EditValue);
                           _currentRowDetalle["IDProducto"] = Convert.ToInt32(this.slkupProducto.EditValue);
                           _currentRowDetalle["DescrProducto"] = dr["Descr"].ToString();
                           _currentRowDetalle["IDLote"] = Convert.ToInt32(this.slkupLote.EditValue);
                           //dr = (DataRowView)slkupLote.Properties.View.GetRow(slkupLote.Properties.GetIndexByKeyValue(slkupLote.EditValue));
                           dr = (DataRowView)slkupLote.Properties.GetRowByKeyValue(slkupLote.EditValue);
                           _currentRowDetalle["LoteInterno"] = dr["LoteInterno"].ToString();
                           _currentRowDetalle["IDTipoTran"] = Convert.ToInt32(this.slkupTransaccion.EditValue);
                           //dr = (DataRowView)slkupBodegaOrigen.Properties.View.GetRow(slkupBodegaOrigen.Properties.GetIndexByKeyValue(slkupBodegaOrigen.EditValue));
                           dr = (DataRowView)slkupBodegaOrigen.Properties.GetRowByKeyValue(slkupBodegaOrigen.EditValue);
                           _currentRowDetalle["IDBodegaOrigen"] = Convert.ToInt32(this.slkupBodegaOrigen.EditValue);
                           _currentRowDetalle["DescrBodegaOrigen"] = dr["Descr"].ToString();
                           //dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                           dr = (DataRowView)slkupTransaccion.Properties.GetRowByKeyValue(slkupTransaccion.EditValue);
                           if (dr["Transaccion"].ToString() == "TR")
                           {
                               //dr = (DataRowView)slkupBodegaDestino.Properties.View.GetRow(slkupBodegaDestino.Properties.GetIndexByKeyValue(slkupBodegaDestino.EditValue));
                               dr = (DataRowView)slkupBodegaDestino.Properties.GetRowByKeyValue(slkupBodegaDestino.EditValue);
                               _currentRowDetalle["IDBodegaDestino"] = Convert.ToInt32(this.slkupBodegaDestino.EditValue);
                               _currentRowDetalle["DescrBodegaDestino"] = dr["Descr"].ToString();
                           }

                           _currentRowDetalle["IDTraslado"] = _currentRow["IDTraslado"];
                           _currentRowDetalle["Cantidad"] = Convert.ToDecimal(this.txtCantidad.EditValue);
                           _currentRowDetalle["PrecioUntLocal"] = Convert.ToDecimal(this.txtPrecioLocal.EditValue);
                           _currentRowDetalle["PrecioUntDolar"] = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
                           _currentRowDetalle["CostoUntLocal"] = Convert.ToDecimal(this.txtCostoLocal.EditValue);
                           _currentRowDetalle["CostoUntDolar"] = Convert.ToDecimal(this.txtCostoDolar.EditValue);
                           //dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                           dr = (DataRowView)slkupTransaccion.Properties.GetRowByKeyValue(slkupTransaccion.EditValue);
                           _currentRowDetalle["Transaccion"] = dr["Transaccion"].ToString();
                           _currentRowDetalle["DescrTipoTran"] = dr["Descr"].ToString();
                           _currentRowDetalle["Factor"] = dr["Factor"].ToString();
                           _currentRowDetalle["Naturaleza"] = dr["Naturaleza"].ToString();
                           _currentRowDetalle["TipoCambio"] = TipoCambio;
                           _currentRowDetalle["Aplicado"] = 0;
                           _currentRow.EndEdit();

                         
                           AccionDetalle = "View";
                           AplicarPrivilegios();
                         

                       }
                       else
                       {



                           _currentRowDetalle = _dtDetalle.NewRow();
                           //_currentRow["IDProducto"] = this.txtIDProducto.Text.Trim();
                           _currentRowDetalle["IDTransaccion"] = -1;
                           _currentRowDetalle["Estado"] = sEstado;
                           //dr = (DataRowView)slkupProducto.Properties.View.GetRow(slkupProducto.Properties.GetIndexByKeyValue(slkupProducto.EditValue));
                           dr = (DataRowView)slkupProducto.Properties.GetRowByKeyValue(slkupProducto.EditValue);
                           _currentRowDetalle["IDProducto"] = Convert.ToInt32(this.slkupProducto.EditValue);
                           _currentRowDetalle["DescrProducto"] = dr["Descr"].ToString();
                           _currentRowDetalle["IDLote"] = Convert.ToInt32(this.slkupLote.EditValue);
                           //dr = (DataRowView)slkupLote.Properties.View.GetRow(slkupLote.Properties.GetIndexByKeyValue(slkupLote.EditValue));
                           dr = (DataRowView)slkupLote.Properties.GetRowByKeyValue(slkupLote.EditValue);
                           _currentRowDetalle["LoteInterno"] = dr["LoteInterno"].ToString();
                           _currentRowDetalle["IDTipoTran"] = Convert.ToInt32(this.slkupTransaccion.EditValue);
                           //dr = (DataRowView)slkupBodegaOrigen.Properties.View.GetRow(slkupBodegaOrigen.Properties.GetIndexByKeyValue(slkupBodegaOrigen.EditValue));
                           dr = (DataRowView)slkupBodegaOrigen.Properties.GetRowByKeyValue(slkupBodegaOrigen.EditValue);
                           _currentRowDetalle["IDBodegaOrigen"] = Convert.ToInt32(this.slkupBodegaOrigen.EditValue);
                           _currentRowDetalle["DescrBodegaOrigen"] = dr["Descr"].ToString();
                           //dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                           dr = (DataRowView)slkupTransaccion.Properties.GetRowByKeyValue(slkupTransaccion.EditValue);
                           if (dr["Transaccion"].ToString() == "TR")
                           {
                               //dr = (DataRowView)slkupBodegaDestino.Properties.View.GetRow(slkupBodegaDestino.Properties.GetIndexByKeyValue(slkupBodegaDestino.EditValue));
                               dr = (DataRowView)slkupBodegaDestino.Properties.GetRowByKeyValue(slkupBodegaDestino.EditValue);
                               _currentRowDetalle["IDBodegaDestino"] = Convert.ToInt32(this.slkupBodegaDestino.EditValue);
                               _currentRowDetalle["DescrBodegaDestino"] = dr["Descr"].ToString();
                           }
                           _currentRowDetalle["IDTraslado"] = Convert.ToInt32(_currentRow["IDTraslado"]);
                           _currentRowDetalle["Cantidad"] = Convert.ToDecimal(this.txtCantidad.EditValue);
                           _currentRowDetalle["PrecioUntLocal"] = Convert.ToDecimal(this.txtPrecioLocal.EditValue);
                           _currentRowDetalle["PrecioUntDolar"] = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
                           _currentRowDetalle["CostoUntLocal"] = Convert.ToDecimal(this.txtCostoLocal.EditValue);
                           _currentRowDetalle["CostoUntDolar"] = Convert.ToDecimal(this.txtCostoDolar.EditValue);
                           //dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                           dr = (DataRowView)slkupTransaccion.Properties.GetRowByKeyValue(slkupTransaccion.EditValue);
                           _currentRowDetalle["Transaccion"] = dr["Transaccion"].ToString();
                           _currentRowDetalle["DescrTipoTran"] = dr["Descr"].ToString();
                           _currentRowDetalle["Factor"] = dr["Factor"].ToString();
                           _currentRowDetalle["Naturaleza"] = dr["Naturaleza"].ToString();
                           _currentRowDetalle["TipoCambio"] = TipoCambio;
                           _currentRowDetalle["Aplicado"] = 0;

                           //Validar que el elemento no exista
                           DataView Dv = new DataView();
                           Dv.Table = ((DataView)gridViewDetalle.DataSource).ToTable();
                           Dv.RowFilter = string.Format("IDProducto={0} and IDLote ={1} and IDTipoTran = {2} and IDBodegaOrigen={3}", _currentRowDetalle["IDProducto"], _currentRowDetalle["IDLote"], _currentRowDetalle["IDTipoTran"], _currentRowDetalle["IDBodegaOrigen"]);

                           if (Dv.ToTable().Rows.Count > 0)
                           {
                               MessageBox.Show("El elemento que desea agregar ya existe en la lista, por favor verifique");
                               return;
                           }


                           _dtDetalle.Rows.Add(_currentRowDetalle);

                           try
                           {
                               
                               Application.DoEvents();


                               AccionDetalle = "View";
                               sEstado = "";
                               AplicarPrivilegios();
                               LimpiarCamposDetalle();

                           }
                           catch (System.Data.SqlClient.SqlException ex)
                           {
                               
                               MessageBox.Show("Ha ocurrido el siguiente error: \n\r" + ex.Message);
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

        private void LayoutDetalleDocumento_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            HandlerMenu(e.Button.Properties.Caption);
               
        }
        

        private bool ValidaDatosDetalle()
        {
            bool result = true;
            String sMensaje = "";
            if (this.slkupTransaccion.EditValue == null || this.slkupTransaccion.EditValue.ToString() == "")
                sMensaje = " •  Seleccione la Transacción\n\r";
            if (this.slkupProducto.EditValue == null || this.slkupProducto.EditValue.ToString() == "" )
                sMensaje = " • Seleccione el producto \n\r";
            if (this.txtCantidad.EditValue==null || this.txtCantidad.EditValue.ToString() == "" )
                sMensaje = " • Ingrese la cantidad\n\r";
            
            //DataRowView dr =  (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
            DataRowView dr = (DataRowView)slkupTransaccion.Properties.GetRowByKeyValue(slkupTransaccion.EditValue);
            if (Convert.ToBoolean(dr["EsVenta"])) {
               if  (this.txtPrecioDolar.EditValue ==null || this.txtPrecioLocal.EditValue.ToString()=="")
                   sMensaje = " • Ingrese el precio del producto \n\r";
            }
            else if (Convert.ToBoolean(dr["EsAjuste"]) || Convert.ToBoolean(dr["EsCompra"]))
            {
                if (this.txtCostoDolar.EditValue == null || this.txtCostoDolar.EditValue.ToString() == "")
                    sMensaje = " • Ingrese sel costo del producto \n\r";
            }
            else if (Convert.ToBoolean(dr["EsTraslado"])) { 
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
            if (Accion == "New" || Accion=="Edit")
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
                this.btnCancelDoc.Enabled = true;
                this.btnPrintDoc.Enabled = true;
            }
        }

        private void CargarLoad() {
            try
            {
                HabilitarControlesCabecera(false);
                CargarPrivilegios();
                AplicarPrivilegios();
                Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, _tituloVentana, this);
                DataTable stTemp;
                if (_dtPaquete.Rows[0]["Transaccion"].ToString() == "TR")
                {
                    stTemp = clsGlobalTipoTransaccionDAC.Get(-1, "*", "*", _dtPaquete.Rows[0]["Transaccion"].ToString()).Tables[0];
                    stTemp.Rows[1].Delete();
                    stTemp.Rows[0]["Descr"] = "Traslados";

                    Util.Util.ConfigLookupEdit(this.slkupTransaccion, stTemp, "Descr", "IDTipoTran");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupTransaccion, "[{'ColumnCaption':'TipoTran','ColumnField':'IDTipoTran','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                }
                else
                {
                    Util.Util.ConfigLookupEdit(this.slkupTransaccion, clsGlobalTipoTransaccionDAC.Get(-1, "*", "*", _dtPaquete.Rows[0]["Transaccion"].ToString()).Tables[0], "Descr", "IDTipoTran");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupTransaccion, "[{'ColumnCaption':'TipoTran','ColumnField':'IDTipoTran','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                }

                Util.Util.ConfigLookupEdit(this.slkupBodegaOrigen, clsBodegaDAC.GetData(-1, "*", -1).Tables[0], "Descr", "IDBodega");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodegaOrigen, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupBodegaDestino, clsBodegaDAC.GetData(-1, "*", -1).Tables[0], "Descr", "IDBodega");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodegaDestino, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupProducto, clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0], "Descr", "IDProducto",450);
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
                    HabilitarControlesDetalle(false);

                    this.ValidateChildren();
                    this.txtReferencia.Select();
                    
                }
                else if (Accion == "Edit")
                {

                    HabilitarControlesCabecera(true);
                    HabilitarControlesDetalle(false);

                    PopulateGrid(false);
                    AplicarPrivilegios();
                    this.txtReferencia.Focus();


                }
                else
                {

                    Accion = "View";

                    PopulateGrid(false);
                    HabilitarControlesCabecera(false);
                    HabilitarControlesDetalle(false);
                    LayoutDetalleDocumento.CustomHeaderButtons["Agregar"].Properties.Enabled = false;
                    LayoutDetalleDocumento.CustomHeaderButtons["Editar"].Properties.Enabled = false;
                    LayoutDetalleDocumento.CustomHeaderButtons["Eliminar"].Properties.Enabled = false;
                    LayoutDetalleDocumento.CustomHeaderButtons["Cancelar"].Properties.Enabled = false;
                    LayoutDetalleDocumento.CustomHeaderButtons["Guardar"].Properties.Enabled = false;

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDocumentoInv_Load(object sender, EventArgs e)
        {
            if (this.Error != "") {
                MessageBox.Show(this.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            CargarLoad();
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
                    //DataRowView dr = (DataRowView)slkupTransaccion.Properties.View.GetRow(slkupTransaccion.Properties.GetIndexByKeyValue(slkupTransaccion.EditValue));
                    DataRowView dr = (DataRowView)slkupTransaccion.Properties.GetRowByKeyValue(slkupTransaccion.EditValue);
                    if (Convert.ToBoolean(dr["EsVenta"]))
                    {
                        this.txtCostoDolar.Enabled = false;
                        this.txtCostoDolar.TabStop = false;
                        this.txtCostoLocal.Enabled = false;
                        this.txtCostoLocal.TabStop = false;
                        this.txtPrecioDolar.Enabled = true;
                        this.txtPrecioDolar.TabStop = true;
                        this.txtPrecioLocal.Enabled = true;
                        this.txtPrecioLocal.TabStop = true;
                    }
                    else if ((Convert.ToBoolean(dr["EsAjuste"]) && Convert.ToInt32(dr["Factor"])>0) || Convert.ToBoolean(dr["EsCompra"]))
                    {
                        this.txtCostoDolar.Enabled = true;
                        this.txtCostoDolar.TabStop = true;
                        this.txtCostoLocal.Enabled = true;
                        this.txtCostoLocal.TabStop = true;
                        this.txtPrecioDolar.Enabled = false;
                        this.txtPrecioDolar.TabStop = false;
                        this.txtPrecioLocal.Enabled = false;
                        this.txtPrecioLocal.TabStop = false;
                    }
                    else
                    {
                        this.txtCostoDolar.Enabled = false;
                        this.txtCostoDolar.TabStop = false;
                        this.txtCostoLocal.Enabled = false;
                        this.txtCostoLocal.TabStop = false;
                        this.txtPrecioDolar.Enabled = false;
                        this.txtPrecioDolar.TabStop = false;
                        this.txtPrecioLocal.Enabled = false;
                        this.txtPrecioLocal.TabStop = false;
                    }
                }
            }
        }

        private void slkupProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupProducto.EditValue != null)
            {
                Util.Util.ConfigLookupEdit(this.slkupLote, clsLoteDAC.GetData(-1, Convert.ToInt32(slkupProducto.EditValue), "*", "*").Tables[0], "LoteProveedor", "IDLote",350);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupLote, "[{'ColumnCaption':'IDLote','ColumnField':'IDLote','width':20},{'ColumnCaption':'Lote','ColumnField':'LoteProveedor','width':60},{'ColumnCaption':'F.V','ColumnField':'FechaVencimiento','width':20}]");
                
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
            //this.slkupTransaccion.EditValue = _currentRowDetalle["IDTipoTran"];
            //this.slkupProducto.EditValue = _currentRowDetalle["IDProducto"];
            //this.slkupLote.EditValue = _currentRowDetalle["IDLote"];
            //this.slkupBodegaOrigen.EditValue = _currentRowDetalle["IDBodegaOrigen"];
            //this.slkupBodegaDestino.EditValue = _currentRowDetalle["IDBodegaDestino"];
            //this.txtCantidad.EditValue = _currentRowDetalle["Cantidad"];
            //this.txtPrecioLocal.EditValue = _currentRowDetalle["PrecioUntLocal"];
            //this.txtPrecioDolar.EditValue = _currentRowDetalle["PrecioUntDolar"];
            //this.txtCostoLocal.EditValue = _currentRowDetalle["PrecioUntLocal"];
        }


        private void gridViewDetalle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

        private bool ValidasDatosCabecera() {
            bool result = true;
            String sMensaje = "";
            if (this.txtReferencia.Text.Trim() == "")
                sMensaje = sMensaje + " • Ingrese la referencia del documento\n\r";
            if (this.dtpFecha.EditValue.ToString() == "" || this.dtpFecha.EditValue == null)
                sMensaje = sMensaje + " • Seleccione la fecha del documento \n\r";
            if (_dtDetalle.Rows.Count == 0)
                sMensaje = sMensaje + " • Debe ingresar al menos una linea en el documento para poder aplicarlo \n\r";
            if (sMensaje !="") {
                MessageBox.Show("Estimado, usuario por favor verifique los siguientes campos: \n\r" + sMensaje);
                result = false;
            }
            return result;            
        }

        private bool ValidarDatosDetalle() {
            foreach (DataRow item in _dsDetalle.Tables[0].Rows) {
                if (item["Estado"].ToString() == "E")
                {
                    MessageBox.Show("El documento contiene productos con problemas de existencias, por favor verifique para poder guardar.");
                    return false;
                }
            }
            return true;
        }

        private void btnSaveDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("La acción que va realizar aplicará el documento al inventario \n\r Desea proseguir? ", "Aplicación del Documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            //Validar  los datos de Cabecera
            if (ValidasDatosCabecera() && ValidarDatosDetalle())
            { 
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

                ConnectionManager.BeginTran();
                clsDocumentoInvCabecera.SetTransactionToAdaptador(true);
                clsDocumentoInvDetalle.SetTransactionToAdaptador(true);

                if (_dsDocumentoInv.Tables[0].Rows.Count > 0)
                    _dsDocumentoInv.Tables[0].Rows.Clear();
                _dsDocumentoInv.Tables[0].Rows.Add(_currentRow);

               

                DataSet dsTemp = clsDocumentoInvDetalle.GetData(-1);
                try
                {
                    clsDocumentoInvCabecera.oAdaptador.Update(_dsDocumentoInv, "Data");
                    _dsDocumentoInv.AcceptChanges();

                    this.txtIDTransaccion.EditValue = _dsDocumentoInv.Tables[0].Rows[0]["IDTransaccion"];
                    this.txtDocumento.EditValue = _dsDocumentoInv.Tables[0].Rows[0]["Documento"];
                    DataTable dtTemp = dsTemp.Tables[0];



                    //Actualizar los datos
                    for (int i = 0; i < _dsDetalle.Tables[0].Rows.Count; i++)
                    {
                        _currentRowDetalle = dtTemp.NewRow();
                        if (_dtPaquete.Rows[0]["Transaccion"].ToString() == "TR")
                        {
                            _currentRowDetalle["IDTransaccion"] = _dsDocumentoInv.Tables[0].Rows[0]["IDTransaccion"];
                            _currentRowDetalle["IDProducto"] = _dsDetalle.Tables[0].Rows[i]["IDProducto"];
                            _currentRowDetalle["IDLote"] = _dsDetalle.Tables[0].Rows[i]["IDLote"];
                            _currentRowDetalle["IDTipoTran"] = 4;
                            _currentRowDetalle["IDBodegaOrigen"] = _dsDetalle.Tables[0].Rows[i]["IDBodegaOrigen"];
                            _currentRowDetalle["IDTraslado"] = _dsDetalle.Tables[0].Rows[i]["IDTraslado"];
                            _currentRowDetalle["Cantidad"] = _dsDetalle.Tables[0].Rows[i]["Cantidad"];
                            _currentRowDetalle["CostoUntDolar"] = _dsDetalle.Tables[0].Rows[i]["CostoUntDolar"];
                            _currentRowDetalle["CostoUntLocal"] = _dsDetalle.Tables[0].Rows[i]["CostoUntLocal"];
                            _currentRowDetalle["PrecioUntLocal"] = _dsDetalle.Tables[0].Rows[i]["PrecioUntLocal"];
                            _currentRowDetalle["PrecioUntDolar"] = _dsDetalle.Tables[0].Rows[i]["PrecioUntDolar"];
                            _currentRowDetalle["Transaccion"] = "TR";

                            _currentRowDetalle["TipoCambio"] = _dsDetalle.Tables[0].Rows[i]["TipoCambio"];
                            _currentRowDetalle["Aplicado"] = _dsDetalle.Tables[0].Rows[i]["Aplicado"];
                            dsTemp.Tables[0].Rows.Add(_currentRowDetalle);
                            _currentRowDetalle = dtTemp.NewRow();
                            _currentRowDetalle["IDTransaccion"] = _dsDocumentoInv.Tables[0].Rows[0]["IDTransaccion"];
                            _currentRowDetalle["IDProducto"] = _dsDetalle.Tables[0].Rows[i]["IDProducto"];
                            _currentRowDetalle["IDLote"] = _dsDetalle.Tables[0].Rows[i]["IDLote"];
                            _currentRowDetalle["IDTipoTran"] = 3;
                            _currentRowDetalle["IDBodegaOrigen"] = _dsDetalle.Tables[0].Rows[i]["IDBodegaDestino"];
                            _currentRowDetalle["IDTraslado"] = _dsDetalle.Tables[0].Rows[i]["IDTraslado"];

                            _currentRowDetalle["Cantidad"] = _dsDetalle.Tables[0].Rows[i]["Cantidad"];
                            _currentRowDetalle["CostoUntDolar"] = _dsDetalle.Tables[0].Rows[i]["CostoUntDolar"];
                            _currentRowDetalle["CostoUntLocal"] = _dsDetalle.Tables[0].Rows[i]["CostoUntLocal"];
                            _currentRowDetalle["PrecioUntLocal"] = _dsDetalle.Tables[0].Rows[i]["PrecioUntLocal"];
                            _currentRowDetalle["PrecioUntDolar"] = _dsDetalle.Tables[0].Rows[i]["PrecioUntDolar"];
                            _currentRowDetalle["Transaccion"] = "TR";

                            _currentRowDetalle["TipoCambio"] = _dsDetalle.Tables[0].Rows[i]["TipoCambio"];
                            _currentRowDetalle["Aplicado"] = _dsDetalle.Tables[0].Rows[i]["Aplicado"];

                        }
                        else
                        {
                            _currentRowDetalle["IDTransaccion"] = _dsDocumentoInv.Tables[0].Rows[0]["IDTransaccion"];
                            _currentRowDetalle["IDProducto"] = _dsDetalle.Tables[0].Rows[i]["IDProducto"];
                            _currentRowDetalle["IDLote"] = _dsDetalle.Tables[0].Rows[i]["IDLote"];
                            _currentRowDetalle["IDTipoTran"] = _dsDetalle.Tables[0].Rows[i]["IDTipoTran"];
                            _currentRowDetalle["IDBodegaOrigen"] = _dsDetalle.Tables[0].Rows[i]["IDBodegaOrigen"];
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

                        }
                        dsTemp.Tables[0].Rows.Add(_currentRowDetalle);

                    }

                    clsDocumentoInvDetalle.oAdaptador.Update(dsTemp, "Data");
                    dsTemp.AcceptChanges();

                    Application.DoEvents();

                    Accion = "View";
                    HabilitarControlesCabecera(false);
                    AplicarPrivilegios();
                    BotoneriaSuperior();

                    //Crear el asiento contable y aplicar el documento en inventario
                    long IDTransaccion = (long)_dsDocumentoInv.Tables[0].Rows[0]["IDTransaccion"];
                    bool result = clsDocumentoInvCabecera.AplicaInventario(IDTransaccion, ConnectionManager.Tran);
                    String Asiento = clsDocumentoInvCabecera.GeneraAsientoTransaccion(IDTransaccion, sUsuario, ConnectionManager.Tran);
                    this.hlblAsiento.Text = Asiento;
                    if (result && Asiento != null)
                        ConnectionManager.CommitTran();
                    else
                        throw new Exception("Ha ocurrido un error");

                    MessageBox.Show("El documento se ha guardado correctamente");
                    HabilitarControlesCabecera(false);
                    HabilitarControlesDetalle(false);
                }
               
                catch (Exception ex)
                {
                    _dsDocumentoInv.RejectChanges();
                    //_dsDetalle.RejectChanges();
                    dsTemp.RejectChanges();
                    this.btnSaveDoc.Enabled = true;
                    ConnectionManager.RollBackTran();
                    //_currentRow = null;
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void txtPrecioLocal_EditValueChanged(object sender, EventArgs e)
        {
            //convertir a Dolar
            if (bPrecioLocalActive)
            {
                Decimal Precio = Convert.ToDecimal(this.txtPrecioLocal.EditValue);
                this.txtPrecioDolar.EditValue = Precio / TipoCambio;
            }
            
        }

        private void txtPrecioDolar_EditValueChanged(object sender, EventArgs e)
        {
            //convertir a Dolar
            if (!bPrecioLocalActive)
            {
                Decimal Precio = Convert.ToDecimal(this.txtPrecioDolar.EditValue);
                this.txtPrecioLocal.EditValue = Precio * TipoCambio;
            }
            
        }

        private void btnAddDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InicializaNuevoElemento();
            CargarLoad();
           
        }

        private void btnPrintDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (Accion=="View")
            {
                DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptDocumentoInv.repx", true);


                SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

                SqlDataSource ds = report.DataSource as SqlDataSource;
                ds.ConnectionName = "DataSource";
                String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
                ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

                // Obtain a parameter, and set its value.
                report.Parameters["IDTransaccion"].Value = Convert.ToInt32(this.txtIDTransaccion.Text.Trim());

                // Show the report's print preview.
                DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                tool.ShowPreview();


            }
        }

        private void gridViewDetalle_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
            GridView view = sender as GridView;
            DataRow row1 = view.GetDataRow(e.RowHandle);
            if (!Convert.ToBoolean(row1["Aplicado"]))
            {
                if (e.RowHandle >= 0)
                {
                    String Estado = row1["Estado"].ToString();
                    String Naturaleza = row1["Naturaleza"].ToString();
                    if (Estado == "E" && Naturaleza=="S")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btnCancelDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.Close();
        }

        private void txtCostoDolar_Enter(object sender, EventArgs e)
        {
            this.bCostoLocalActive = false;
            
        }

        private void txtCostoDolar_EditValueChanged(object sender, EventArgs e)
        {
            if (!bCostoLocalActive)
            {
                Decimal Costo = Convert.ToDecimal(this.txtCostoDolar.EditValue);
                this.txtCostoLocal.EditValue = Costo * TipoCambio;
            }
        }

        private void txtCostoLocal_EditValueChanged(object sender, EventArgs e)
        {
            if (bCostoLocalActive)
            {
                Decimal Costo = Convert.ToDecimal(this.txtCostoLocal.EditValue);
                this.txtCostoDolar.EditValue = Costo / TipoCambio;
            }
        }

        private void txtCostoLocal_Enter(object sender, EventArgs e)
        {
            bCostoLocalActive = true;
        }

        private void txtPrecioLocal_Enter(object sender, EventArgs e)
        {
            bPrecioLocalActive = true;
        }

        private void txtPrecioDolar_Enter(object sender, EventArgs e)
        {
            bPrecioLocalActive = false;
        }

        private void hlblAsiento_Click(object sender, EventArgs e)
        {
            if (this.hlblAsiento.Text != "ND" && this.hlblAsiento.Text.Trim() !="--") {
                CG.frmAsiento frmAsiento = new CG.frmAsiento(this.hlblAsiento.Text.Trim());
                frmAsiento.Show();
            }
        }

        private void txtReferencia_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void txtReferencia_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                this.xtraTabControl1.SelectedTabPageIndex = 1;
            } 
        }

        private void frmDocumentoInv_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F1) {
                MessageBox.Show("Presione f1");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                HandlerMenu("Agregar");
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == Keys.F2)
            {
                if (this.gridViewDetalle.GetSelectedRows().Count() > 0)
                    HandlerMenu("Editar");
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == Keys.F4)
            {
                HandlerMenu("Eliminar");
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == Keys.F10)
            {
                HandlerMenu("Guardar");
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void slkupTransaccion_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            SearchLookUpEdit edito = (SearchLookUpEdit)sender;
            edito.ShowPopup();      
        }

        private void slkupcontrol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SearchLookUpEdit control = (SearchLookUpEdit)sender;
                control.ShowPopup();
            }
        }
    

    
    }
}
