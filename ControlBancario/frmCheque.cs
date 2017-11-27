using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Security;
using ControlBancario.DAC;
using System.IO;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;

namespace ControlBancario
{
    public partial class frmCheque : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataRow _currentRow;
        private String Accion = "NEW";

        private DataTable _dtSecurity;
        private DataSet _dsCheque;
        private DataTable _dtCheque;
        

        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        String _Asiento = "";

        public frmCheque()
        {
            InitializeComponent();
            Accion = "New";
            //Obtener el Siguiente consecutivo de la solicitud"

            _dsCheque = MovimientosDAC.GetDataEmpty();
            _dtCheque = _dsCheque.Tables[0];
            InicializarNuevoElemento();
            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, sUsuario);
            _dtSecurity = DS.Tables[0];

        }


        public frmCheque(int pIDCuentaBanco, int pIDTipo, int pIDSubTipo,int IdRuc, String pNumero)
        {
            InitializeComponent();

            CargarCheque(pIDCuentaBanco, pIDTipo, pIDSubTipo,IdRuc, pNumero);


        }




        private void AplicarPrivilegios()
        {

            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarAsientodeDiario, _dtSecurity))

                this.btnEditar.Enabled = true;
            else
                this.btnEditar.Enabled = false;

            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarAsientodeDiario, _dtSecurity))
                this.btnEliminar.Enabled = true;
            else
                this.btnEliminar.Enabled = false;





        }


        private void CargarCheque(int IDCuentaBanco, int IDTipo, int IDSubTipo, int iDRuc,String Numero)
        {

            _dsCheque = MovimientosDAC.GetData(IDCuentaBanco, IDTipo, IDSubTipo,iDRuc, Numero);
            _dtCheque = _dsCheque.Tables[0];
            //_ModuloFuente = ModuloFuente;
            _currentRow = _dsCheque.Tables[0].Rows[0];

            _Asiento = _currentRow["Asiento"].ToString();
            

        }

        private void InicializarNuevoElemento()
        {
 
            //Cargar el tipo de cambio por defecto

            _currentRow = _dtCheque.NewRow();
            _currentRow["IDCuentaBanco"] = Convert.ToInt32(this.slkupCuentaBancaria.EditValue);
            _currentRow["Fecha"] = DateTime.Now;
            _currentRow["IDTipo"] = 1;//DBNull.Value;
            _currentRow["IDSubTipo"] = 1;//DBNull.Value;
            _currentRow["Numero"] = 0;
            _currentRow["Pagadero_a"] = "";
            _currentRow["Monto"] = "0";
            _currentRow["IDRuc"] = DBNull.Value;
            _currentRow["Usuario"] = sUsuario;
            _currentRow["Referencia"] = "";
            _currentRow["ConceptoContable"] = "";


        }





        private String EstadoAsiento()
        {
            String sEstado = "";
            if (Convert.ToBoolean(_currentRow["Mayorizado"]))
                sEstado = "Mayorizado";
            else if (Convert.ToBoolean(_currentRow["Anulado"]))
                sEstado = "Anulado";
            else if (Convert.ToBoolean(_currentRow["CuadreTemporal"]))
                sEstado = "Cuadre Temporal";
            else
                sEstado = "Editando..";
            return sEstado;
        }




        public void UpdateControlsFromDataRow(DataRow row)
        {

            this.slkupCuentaBancaria.EditValue = _currentRow["IDCuentaBanco"];
            this.dtpFecha.EditValue = _currentRow["Fecha"];
            this.slkupTipo.EditValue = _currentRow["IDTipo"].ToString();
            this.slkupSubTipo.EditValue = _currentRow["IDSubTipo"].ToString();
            this.txtNumero.EditValue = _currentRow["Numero"].ToString();
            this.txtMonto.EditValue = _currentRow["Monto"].ToString();
            this.txtAsiento.EditValue = _currentRow["Asiento"].ToString();
            this.txtAsientoAnulacion.Text = _currentRow["AsientoAnulacion"].ToString();
            this.txtConcepto.EditValue = _currentRow["ConceptoContable"].ToString();
            this.txtReferencia.Text = _currentRow["Referencia"].ToString();
            this.slkupRuc.EditValue =_currentRow["IDRuc"].ToString();
            this.txtPagaderoA.Text = _currentRow["Pagadero_a"].ToString();
            this.txtUsuario.EditValue = _currentRow["Usuario"].ToString();
            this.txtUsuarioAnulacion.EditValue = _currentRow["UsuarioAnulacion"].ToString();
            this.txtFechaAnulacion.EditValue = _currentRow["FechaAnulacion"].ToString();
            this.txtUsuarioAprobacion.EditValue = _currentRow["UsuarioAprobacion"].ToString();
            this.txtFechaAprobacion.EditValue = _currentRow["FechaAprobacion"].ToString();
            this.txtUsuarioImpresion.EditValue = _currentRow["UsuarioImpresion"].ToString();
            this.txtFechaImpresion.EditValue = _currentRow["FechaImpresion"].ToString();
            this.txtImpreso.Text = (Convert.ToBoolean((_currentRow["Impreso"].ToString() == "") ? 0 : _currentRow["Impreso"]) == true) ? "Impreso" : "";
        }


        private void ClearControls()
        {
            this.txtConcepto.Text = "";
        }


        private void HabilitarControles(bool Activo, bool Mayorizado)
        {

            this.txtConcepto.ReadOnly = !(Activo);
            this.txtReferencia.ReadOnly = !Activo;
            this.slkupTipo.ReadOnly = !Activo;
            this.slkupSubTipo.ReadOnly = !Activo;
            this.slkupRuc.ReadOnly = !Activo;
            this.txtPagaderoA.ReadOnly = !(Activo);
            this.txtMonto.ReadOnly = !(Activo);
            this.txtReferencia.ReadOnly = !(Activo);
            this.txtConcepto.ReadOnly = !(Activo);
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = (Mayorizado == true) ? false : Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
        }

        private void EnlazarEventos()
        {
            //    this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            //    this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            //this.btnImprimir.ItemClick += BtnImprimir_ItemClick;

            //this.btnAnular.ItemClick += BtnAnular_ItemClick;
            //this.btnCuadreTemporal.ItemClick += BtnCuadreTemporal_ItemClick;

        }


        private void BtnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (_dsCheque.Tables[0].Rows.Count > 0)
            //{
            //    if (Convert.ToBoolean(_dsCheque.Tables[0].Rows[0]["Mayorizado"]) == true)
            //    {
            //        int IdEjercicio = (int)_dsCheque.Tables[0].Rows[0]["IDEjercicio"];//(int)_dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"];
            //        String Periodo = _dsCheque.Tables[0].Rows[0]["Periodo"].ToString();//_dsEjercicioPeriodo.Tables[0].Rows[0]["Periodo"].ToString();
            //        String sAsientoAmulacion = "";
            //        bool bExito = false;
            //        sAsientoAmulacion = AsientoDAC.Revertir(IdEjercicio, Periodo, _Asiento, sUsuario);

            //        if (sAsientoAmulacion != "")
            //        {
            //            MessageBox.Show("El asiento contable, se ha revertido con exito");
            //            //Mostrar el asiento anulado. (como poner la referencia de anulacion en el primero asiento)
            //            this.Close();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ha ocurrido un error tratando de revertir el asiento..");
            //        }
            //    }
            //}
        }



     





        private void frmDocumento_Load(object sender, EventArgs e)
        {
            try
            {


                HabilitarControles(false, false);

                CargarPrivilegios();
                EnlazarEventos();


                Util.Util.ConfigLookupEdit(this.slkupRuc, RucDAC.GetData(-1).Tables["Data"], "Nombre", "IDRuc");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupRuc, "[{'ColumnCaption':'Ruc','ColumnField':'RUC','width':30},{'ColumnCaption':'Nombre','ColumnField':'Nombre','width':30},{'ColumnCaption':'Alias','ColumnField':'Alias','width':70}]");


                Util.Util.ConfigLookupEdit(this.slkupTipo, TipoDocumentoDAC.GetData(-1).Tables["Data"], "Descr", "IDTipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipo, "[{'ColumnCaption':'Tipo','ColumnField':'Tipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentaBancaria, CuentaBancariaDAC.GetData(-1, -1).Tables["Data"], "Descr", "IDCuentaBanco");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaBancaria, "[{'ColumnCaption':'Codigo','ColumnField':'Codigo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                
                UpdateControlsFromDataRow(_currentRow);

                this.txtNumero.EditValue = CuentaBancariaDAC.NextConsecutivoCheque(Convert.ToInt32(this.slkupCuentaBancaria.EditValue));

                if (Accion == "New")
                {
                    HabilitarControles(true, false);
                    ClearControls();
                    this.tabDocumento.Visible = false;
                    this.ValidateChildren();
                    this.slkupTipo.Enabled = false;
                    this.btnAprobar.Enabled = false;
                    this.btnImprimir.Enabled = false;

                }
                else
                {
                    Accion = "Edit";
                    
                    if (_currentRow["Asiento"].ToString() != ""){
                        this.btnImprimir.Enabled = true;
                        this.btnAprobar.Enabled = false;
                        this.btnAnular.Enabled = true;
                    }
                    else {
                        this.btnImprimir.Enabled = false;
                        this.btnAprobar.Enabled = true;
                        this.btnAnular.Enabled = false;
                    }
                    HabilitarControles(true, false);
                    this.slkupCuentaBancaria.ReadOnly = true;
                    this.txtNumero.ReadOnly = true;

                }
                AplicarPrivilegios();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_currentRow == null || _currentRow["Asiento"].ToString()!="")
            {
                return;
            }
            if (Convert.ToBoolean(_currentRow["Mayorizado"]) == false && Convert.ToBoolean(_currentRow["Anulado"]) == false)
            {
                Accion = "Edit";
                HabilitarControles(true, false);
                AplicarPrivilegios();
            }

        }


        private bool ValidaDatos()
        {
            bool result = true;
            String sMensaje = "";

            if (this.slkupCuentaBancaria.EditValue == null || this.slkupCuentaBancaria.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Seleccione la cuenta bancaria. \n\r";
            if (this.dtpFecha.EditValue == null || this.dtpFecha.EditValue.ToString()=="")
                sMensaje = sMensaje + "     • Ingrese la fecha del Cheque. \n\r";
            if (this.slkupTipo.EditValue == null || this.slkupTipo.EditValue.ToString() =="")
                sMensaje = sMensaje + "     • Ingrese el tipo de Documento. \n\r";
            if (this.slkupSubTipo.EditValue == null || this.slkupSubTipo.EditValue.ToString()=="") 
                sMensaje = sMensaje + "     • Ingrese el Sub Tipo de Documento. \n\r";
            if (this.txtMonto.EditValue == null || this.txtMonto.EditValue.ToString()=="" || this.txtMonto.EditValue.ToString()=="0.00")
                sMensaje = sMensaje + "     • Ingrese el monto del cheque. \n\r";
            if (this.txtReferencia.EditValue == null || this.txtReferencia.EditValue.ToString()=="")
                sMensaje = sMensaje + "     • Ingrese la Referencia del cheque. \n\r";
            if (this.txtConcepto.EditValue == null || this.txtConcepto.EditValue.ToString()=="")
                sMensaje = sMensaje + "     • Digite el concepto del Asiento. \n\r";
             
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


            //Validar Datos 
            if (!ValidaDatos()) return;

            if (Accion != "New")
            {
                if (_currentRow != null)
                {
                    Application.DoEvents();
                    _currentRow.BeginEdit();
                    //Obtener los datos
                    //if (_dsCheque.Tables[0].Rows.Count > 0)
                    //    _dsCheque.Tables[0].Rows.Clear();
                    //_dsCheque.Tables[0].Rows.Add(_currentRow);
                    _currentRow["IDCuentaBanco"] = this.slkupCuentaBancaria.EditValue.ToString();
                    _currentRow["Fecha"] = this.dtpFecha.EditValue;
                    _currentRow["IDTipo"] = this.slkupTipo.EditValue;
                    _currentRow["IDRuc"] = this.slkupRuc.EditValue;
                    _currentRow["IDSubTipo"] = this.slkupSubTipo.EditValue;
                    _currentRow["Numero"] = this.txtNumero.EditValue;
                    _currentRow["Pagadero_a"] = this.txtPagaderoA.EditValue;
                    _currentRow["Monto"] = this.txtMonto.EditValue;
                    _currentRow["ConceptoContable"] = this.txtConcepto.EditValue;
                    _currentRow["Referencia"] = this.txtReferencia.EditValue;
                    _currentRow["Usuario"] = this.txtUsuario.EditValue;


                    _currentRow.EndEdit();

                    DataSet _dsChanged = _dsCheque.GetChanges(DataRowState.Modified);

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
                                    msg = msg + dr["Descr"].ToString();
                                }
                            }
                        }

                        lblStatus.Caption = msg;
                    }

                    //Si no hay errores

                    if (okFlag)
                    {
                        MovimientosDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + _currentRow["Descr"].ToString();
                        Application.DoEvents();
                        // isEdition = false;
                        _dsCheque.AcceptChanges();


                        HabilitarControles(false, true);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsCheque.RejectChanges();

                    }
                }
            }
            else
            {
                //nuevo registro
               // _currentRow = _dtCheque.NewRow();

                _currentRow["IDCuentaBanco"] = this.slkupCuentaBancaria.EditValue.ToString();
                _currentRow["Fecha"] = this.dtpFecha.EditValue;
                _currentRow["IDRuc"] = this.slkupRuc.EditValue;
                _currentRow["IDTipo"] = this.slkupTipo.EditValue;
                _currentRow["IDSubTipo"] = this.slkupSubTipo.EditValue;
                _currentRow["Numero"] = this.txtNumero.EditValue;
                _currentRow["Pagadero_a"] = this.txtPagaderoA.EditValue;
                _currentRow["Monto"] = this.txtMonto.EditValue;
                _currentRow["ConceptoContable"] = this.txtConcepto.EditValue;
                _currentRow["Referencia"] = this.txtReferencia.EditValue;
                _currentRow["Usuario"] = this.txtUsuario.EditValue;
                _dtCheque.Rows.Add(_currentRow);
                try
                {
                    MovimientosDAC.oAdaptador.Update(_dsCheque, "Data");
                    _dsCheque.AcceptChanges();

                    lblStatus.Caption = "Se ha ingresado un nuevo registro";
                    Application.DoEvents();
                    HabilitarControles(false,true);
                    this.btnAprobar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    AplicarPrivilegios();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    _dsCheque.RejectChanges();
                    //_currentRow = null;
                    MessageBox.Show(ex.Message);
                }

                //    String xml = "";
            }


        }


        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Accion == "Edit")
            {
                HabilitarControles(false, true);
                AplicarPrivilegios();
                //CargarAsiento(_currentRow["Asiento"].ToString());
                UpdateControlsFromDataRow(_currentRow);

            }
            else
                this.Close();

        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRow != null)
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el asiento de diario? ", "Asiento de Diario", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    // AsientoDAC.InsertUpdateAsiento("D", "", _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());
                }
            }
        }


        private void btnMayorizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Vlidar si el documento esta guardado si no lo esta realizar el save
            if (_dsCheque.Tables[0].Rows.Count > 0)
            {
                //Validar el Periodo contable
                DateTime Fecha = Convert.ToDateTime(this.dtpFecha.EditValue);
                try
                {
                    //if (Fecha == null || PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha))
                    //PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Han ocurrido los siguientes errores: \r\n" + ex.Message);
                    return;
                }

                GuardarAsiento();

                //Validar situaciones comunes al momento de mayorizar
                if (Convert.ToBoolean(_dsCheque.Tables[0].Rows[0]["Mayorizado"]) == false)
                {
                    //Validar situaciones comunes al momento de mayorizar

                    int IdEjercicio = (int)_dsCheque.Tables[0].Rows[0]["IDEjercicio"];// (int)_dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"];
                    String Periodo = _dsCheque.Tables[0].Rows[0]["Periodo"].ToString();
                    bool bExito = false;
                    // bExito = AsientoDAC.Mayorizar(IdEjercicio, Periodo, _Asiento, sUsuario);

                    if (bExito)
                    {
                        MessageBox.Show("El asiento contable, se ha mayorizado con exito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error tratando de mayorizar el asiento..");
                    }
                }
            }
        }

        private void slkupTipo_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupTipo.EditValue != null && this.slkupTipo.EditValue.ToString() != "")
            {
                int iIDTipo = Convert.ToInt32(this.slkupTipo.EditValue);
                Util.Util.ConfigLookupEdit(this.slkupSubTipo, SubTipoDocumentoDAC.GetData(iIDTipo, -1).Tables["Data"], "Descr", "IDTipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupSubTipo, "[{'ColumnCaption':'Tipo','ColumnField':'SubTipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                this.slkupSubTipo.Enabled = true;


            }
            else
            {
                this.slkupSubTipo.Enabled = false;
            }

        }

        private void slkupSubTipo_EditValueChanged(object sender, EventArgs e)
        {
            //if (this.slkupSubTipo.EditValue != null && this.slkupSubTipo.EditValue.ToString() != "")
            //{
            //    //Obtener el consecutivo
            //    this.txtNumero.EditValue = CuentaBancariaDAC.NextConsecutivoCheque(Convert.ToInt32(this.slkupCuentaBancaria.EditValue));
            //}
        }

        private void slkupCuentaBancaria_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupCuentaBancaria.EditValue.ToString() != "" || this.slkupCuentaBancaria.EditValue != null)
            {
                this.tabDocumento.TabPages[0].PageEnabled = true;
                this.tabDocumento.TabPages[1].PageEnabled = true;
                this.txtNumero.EditValue = CuentaBancariaDAC.NextConsecutivoCheque(Convert.ToInt32(this.slkupCuentaBancaria.EditValue));
            }
            else {
                this.tabDocumento.TabPages[0].PageEnabled = false;
                this.tabDocumento.TabPages[1].PageEnabled = false;
            }


        }

        private void btnImprimir_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String path ="";
            if (_currentRow["Asiento"].ToString()!="")
            {
                //Obtener el listado de formatos
                DataSet dsFormatos =  CuentaFormatoChequeDAC.GetData(Convert.ToInt32(_currentRow["IDCuentaBanco"]),-1);
                if (dsFormatos.Tables.Count > 0) {
                    if (dsFormatos.Tables[0].Rows.Count > 0) {
                        DataTable tmpTable = new DataTable();
                        DataView dv = new DataView(dsFormatos.Tables[0]);
                        dv.RowFilter = "Activo=1";
                        tmpTable = dv.ToTable();
                        if (tmpTable.Rows.Count == 1)
                        {
                            //cargar el formato por defecto 
                            path = Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", string.Format("Formato-{0}.repx", tmpTable.Rows[0]["IDFormato"].ToString())).ToString();
                            DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile(path, true);


                            SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

                            SqlDataSource ds = report.DataSource as SqlDataSource;
                            ds.ConnectionName = "sqlDataSource1";
                            String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
                            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
                            ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

                            // Obtain a parameter, and set its value.
                            report.Parameters["Numero"].Value = Convert.ToInt32(_currentRow["Numero"]);
                            report.Parameters["IDCuentaBanco"].Value = Convert.ToInt32(_currentRow["IDCuentaBanco"]); 
                            report.Parameters["IDTipo"].Value = Convert.ToInt32(_currentRow["IDTipo"]); 
                            report.Parameters["IDSubTipo"].Value = Convert.ToInt32(_currentRow["IDSubTipo"]); 

                            // Show the report's print preview.
                            DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report); 
                            tool.ShowPreview();
                            SetChequeImpreso();
                        }
                        else { 
                            //Seleccionar de la lista de formatos
                            frmSeleccionFormatoCheque ofrmListarFormatos = new frmSeleccionFormatoCheque(tmpTable);
                            ofrmListarFormatos.FormClosed +=ofrmListarFormatos_FormClosed;
                             ofrmListarFormatos.ShowDialog();
                        }
                    }
                }


                

            }
        }

        private void SetChequeImpreso() { 
            DAC.MovimientosDAC.SetChequeImpreso(Convert.ToInt32(_currentRow["Numero"]),
                                            Convert.ToInt32(_currentRow["IDCuentaBanco"]),
                                            Convert.ToInt32(_currentRow["IDTipo"]),
                                            Convert.ToInt32(_currentRow["IDSubTipo"]),
                                            sUsuario);
            CargarReloadData();
        }

        void ofrmListarFormatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSeleccionFormatoCheque ofrm = (frmSeleccionFormatoCheque)sender;
            String path  = Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", string.Format("Formato-{0}.repx", ofrm.IDFormato)).ToString();
            DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile(path, true);


            SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

            SqlDataSource ds = report.DataSource as SqlDataSource;
            ds.ConnectionName = "sqlDataSource1";
            String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
            ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

            // Obtain a parameter, and set its value.
            report.Parameters["Numero"].Value = Convert.ToInt32(_currentRow["Numero"]);
            report.Parameters["IDCuentaBanco"].Value = Convert.ToInt32(_currentRow["IDCuentaBanco"]); ;
            report.Parameters["IDTipo"].Value = Convert.ToInt32(_currentRow["IDTipo"]); ;
            report.Parameters["IDSubTipo"].Value = Convert.ToInt32(_currentRow["IDSubTipo"]); ;

            // Show the report's print preview.
            DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

            tool.ShowPreview();
            SetChequeImpreso();
        }

        private void btnAprobar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRow["Asiento"].ToString() == "" || _currentRow["Asiento"] == null) {
                try
                {
                    //Security.ConnectionManager.BeginTran();
                    String Asiento = MovimientosDAC.GenerarAsientoContable(Convert.ToInt32(_currentRow["Numero"]), Convert.ToInt32(_currentRow["IDCuentaBanco"]), Convert.ToInt32(_currentRow["IDTipo"]), Convert.ToInt32(_currentRow["IDSubTipo"]), sUsuario);
                    if (Asiento == "") {
                        MessageBox.Show("Ha ocurrido un error tratando de generar el asiento contable del cheque");
                        return;
                    }
                    CG.frmAsiento ofrmAsiento = new CG.frmAsiento(Asiento,"PndtGuardar",true);
                    ofrmAsiento.FormClosed += ofrmAsiento_FormClosed;
                    ofrmAsiento.ShowDialog();
                    //Security.ConnectionManager.CommitTran();
                }
                catch (Exception ex) {
                    MessageBox.Show("Han ocurrido los siguientes errores, tratando de generar el asiento contable \n\r\n\r\n\r\n\r\n\r\n\r\n\r" + ex.Message);
                   // Security.ConnectionManager.RollBackTran();
                }
            }
        }

        private void CargarReloadData() {
            CargarCheque(Convert.ToInt32(_currentRow["IDCuentaBanco"]),
                           Convert.ToInt32(_currentRow["IDTipo"]),
                           Convert.ToInt32(_currentRow["IDSubTipo"]),
                           Convert.ToInt32(_currentRow["IDRuc"]),
                           _currentRow["Numero"].ToString());
            UpdateControlsFromDataRow(_currentRow);
            if (_currentRow["Asiento"].ToString() != "")
            {
                this.btnImprimir.Enabled = true;
                this.btnAprobar.Enabled = false;
                this.btnAnular.Enabled = true;
            }
            else
            {
                this.btnImprimir.Enabled = false;
                this.btnAprobar.Enabled = true;
                this.btnAnular.Enabled = false;
            }
        }

        void ofrmAsiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarReloadData();
        }

        private void btnAnular_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Preguntar por restricciones de anulacion

            if (_currentRow["Asiento"].ToString() != "") {
                MovimientosDAC.RevierteAsientoContable(Convert.ToInt32(_currentRow["Numero"]), Convert.ToInt32(_currentRow["IDCuentaBanco"]), Convert.ToInt32(_currentRow["IDTipo"]), Convert.ToInt32(_currentRow["IDSubTipo"]), sUsuario);
                MessageBox.Show("El cheque y su transaccion contable se ha anulado");
            }
        }

        private void slkupRuc_EditValueChanged(object sender, EventArgs e)
        {
            if (Accion == "New")
            {
                //this.txtPagaderoA.EditValue = this.slkupRuc;
                DevExpress.XtraGrid.Views.Grid.GridView view = slkupRuc.Properties.View;
                int rowHandle = view.FocusedRowHandle;
                // or other field name
                String value = (view.GetRowCellValue(rowHandle, "Nombre") == null) ? "" : view.GetRowCellValue(rowHandle, "Nombre").ToString();
                if (value != "")
                {
                    this.txtPagaderoA.EditValue = value;
                    this.txtPagaderoA.Focus();
                }

            }
        }




    }
}
