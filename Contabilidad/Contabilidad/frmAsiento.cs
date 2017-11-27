using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Util;
using DevExpress.XtraGrid;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.IO;
using System.Xml.Serialization;
using Security;
using DevExpress.XtraGrid.Views.Base;
using System.Globalization;
using DevExpress.XtraLayout;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;

namespace CG
{
    public partial class frmAsiento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public List<clsColumnGrid> lstColumnas = new List<clsColumnGrid>();

        private DataTable _dtAsiento;
        private DataTable _dtDetalle;

        private DataSet _dsAsiento;
        private DataSet _dsDetalle;

        private DataTable _dtCuentas;
        private DataTable _dtCentros;

        private DataTable _dtSecurity;

        private DataSet _dsEjercicioPeriodo;

        private DataRow _currentRow;
        private String Accion = "NEW";
        private bool _ShowLessColumns = false;
        private bool _DonCloseCuadre = false;
        private String _Estado = "";

        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        String _Asiento = "";
        String _ModuloFuente = "";
        String _tituloVentana = "Asiento";
        double _TipoCambio = 0;


        public frmAsiento()
        {
            InitializeComponent();
            InicializarControles();
            Accion = "New";
            //Obtener el Siguiente consecutivo de la solicitud"
            _dsAsiento = AsientoDAC.GetDataEmpty();
            _dtAsiento = _dsAsiento.Tables[0];
            if (ValidarEjerciosPeriodoTrabajo())
            {
                _ModuloFuente = "CG";
                InicializarNuevoElemento();
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
                this.Dispose(true);
        }

        private bool ValidarEjerciosPeriodoTrabajo()
        {
            bool result = false;
            DataSet ds = new DataSet();
            ds = EjercicioDAC.ValidaEjercicioPeriodoTrabajo(DateTime.Now);
            String sMensaje = ds.Tables[0].Rows[0]["msg"].ToString();
            if (sMensaje != "OK")
            {
                MessageBox.Show(sMensaje);
            }
            else
                result = true;

            return result;
        }

        public frmAsiento(String Asiento)
        {
            InitializeComponent();
            InicializarControles();
            CargarAsiento(Asiento);
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

            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarAsientodeDiario, _dtSecurity))
            {
                if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
                    this.btnEditar.Enabled = false;
                else
                    this.btnEditar.Enabled = true;
            }
            else
                this.btnEditar.Enabled = false;

            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarAsientodeDiario, _dtSecurity))
            {
                if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
                    this.btnEliminar.Enabled = false;
                else
                    this.btnEliminar.Enabled = true;
            }
            else
                this.btnEliminar.Enabled = false;



            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.MayorizarAsientodeDiario, _dtSecurity))
            {
                if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
                    this.btnMayorizar.Enabled = false;
                else
                    this.btnMayorizar.Enabled = true;
            }
            else
                this.btnMayorizar.Enabled = false;

            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AnularAsientoMayorizado, _dtSecurity))
            {
                if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
                    this.btnAnular.Enabled = true;
                else
                    this.btnAnular.Enabled = false;
            }
            else
                this.btnAnular.Enabled = false;

        }

        private void CargarAsiento(String Asiento)
        {

            _dsAsiento = AsientoDAC.GetDataByAsiento(Asiento);
            _dtAsiento = _dsAsiento.Tables[0];
            //_ModuloFuente = ModuloFuente;
            _currentRow = _dsAsiento.Tables[0].Rows[0];
            _Asiento = _currentRow["Asiento"].ToString();
            _TipoCambio =(_currentRow["TipoCambio"].ToString() != "")? Convert.ToDouble(_currentRow["TipoCambio"]):0.0;

        }

        public  frmAsiento(String Asiento, String Estado, bool DontCloseCuadre)
        {
            InitializeComponent();
            InicializarControles();

            this._DonCloseCuadre = DontCloseCuadre;
            this._Estado = Estado;
            _dsAsiento = AsientoDAC.GetDataByAsiento(Asiento);
            _dtAsiento = _dsAsiento.Tables[0];
            //_ModuloFuente = ModuloFuente;
            _currentRow = _dsAsiento.Tables[0].Rows[0];
            _Asiento = _currentRow["Asiento"].ToString();
            _TipoCambio = (_currentRow["TipoCambio"].ToString() != "") ? Convert.ToDouble(_currentRow["TipoCambio"]) : 0.0;
            
        }

        public frmAsiento(DataSet ds, DataRow dr)
        {
            // Accion = "Edit";
            InitializeComponent();
            InicializarControles();
            _dsAsiento = ds;
            _dtAsiento = ds.Tables[0];
            //_ModuloFuente = ModuloFuente;
            _currentRow = dr;
            _TipoCambio = Convert.ToDouble(_currentRow["TipoCambio"]);
        }

        private void InicializarControles()
        {
            //gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }



        private void InicializarNuevoElemento()
        {
            _dsEjercicioPeriodo = EjercicioDAC.GetEjercicioActivo();
            DataSet DS = new DataSet();
            //Cargar el tipo de cambio por defecto
            String sTipoCambio = ParametrosContabilidadDAC.GetTipoCambioModulo();
            DS = TipoCambioDetalleDAC.GetData(sTipoCambio, DateTime.Now);

            _currentRow = _dtAsiento.NewRow();
            _currentRow["IDEjercicio"] = _dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"].ToString();
            _currentRow["Periodo"] = _dsEjercicioPeriodo.Tables[0].Rows[0]["Periodo"].ToString();
            _currentRow["TipoCambio"] = Convert.ToDecimal((DS.Tables[0].Rows.Count == 0) ? 0 : DS.Tables[0].Rows[0]["Monto"]);
            _currentRow["ModuloFuente"] = _ModuloFuente;
            _currentRow["FechaHora"] = DateTime.Now;
            _currentRow["Fecha"] = DateTime.Now;
            _currentRow["Tipo"] = "CG";
            _currentRow["Concepto"] = "";
            _currentRow["Mayorizado"] = false;
            _currentRow["Anulado"] = false;
            _currentRow["CuadreTemporal"] = false;
            _currentRow["MayorizadoBy"] = "";
            _currentRow["MayorizadoDate"] = DBNull.Value;


        }

        private void CargarParametrosMonedas()
        {
            DataSet DS = ParametrosContabilidadDAC.GetMonedasFuncionales();
            Util.Util.DecimalLenght = Convert.ToInt32(DS.Tables[0].Rows[0]["CantDigitosDecimales"]);
            Util.Util.LocalSimbolCurrency = DS.Tables[0].Rows[0]["SimboloMonedaFuncional"].ToString();
            Util.Util.ForeingSimbolCurrency = DS.Tables[0].Rows[0]["SimboloMonedaExtrangera"].ToString();
        }


        private void CargarSimbolosMoneda()
        {

            if (Util.Util.LocalSimbolCurrency == null)
            {
                CargarParametrosMonedas();
            }

            Util.Util.SetFormatTextEdit(this.txtCreditoLocal, Util.Util.FormatType.MonedaLocal);
            Util.Util.SetFormatTextEdit(this.txtDebitoLocal, Util.Util.FormatType.MonedaLocal);
            Util.Util.SetFormatTextEdit(this.txtDiferencia, Util.Util.FormatType.MonedaLocal);


            Util.Util.SetFormatTextEdit(this.txtDebitoDolar, Util.Util.FormatType.MonedaExtrangera);
            Util.Util.SetFormatTextEdit(this.txtCreditoDolar, Util.Util.FormatType.MonedaExtrangera);
            Util.Util.SetFormatTextEdit(this.txtDirenciaDolar, Util.Util.FormatType.MonedaExtrangera);

            Util.Util.SetFormatTextEditGrid(this.txtDebitoGrid, Util.Util.FormatType.MonedaLocal);
            Util.Util.SetFormatTextEditGrid(this.txtCreditoGrid, Util.Util.FormatType.MonedaLocal);
            //this.gridView1.Columns["asdfs"].DisplayFormat = 
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
            //_currentRow = _dtAsiento.NewRow();
            this.txtAsiento.EditValue = _currentRow["Asiento"].ToString();
            this.txtEjercicio.EditValue = _currentRow["IDEjercicio"].ToString();
            this.txtPeriodo.EditValue = _currentRow["Periodo"].ToString();
            this.txtTipoCambio.Text = (_currentRow["TipoCambio"].ToString()!="") ? Convert.ToDecimal(_currentRow["TipoCambio"]).ToString("N" + Util.Util.DecimalLenght): "0.00";
            this.txtModuloFuente.EditValue = _currentRow["ModuloFuente"].ToString();
            this.dtpFecha.EditValue = Convert.ToDateTime(_currentRow["Fecha"]);
            //this.dtpFecha.Text = Convert.ToDateTime(_currentRow["Fecha"]).ToShortDateString();
            this.txtFecha.EditValue = _currentRow["FechaHora"].ToString();
            this.slkupTipo.EditValue = _currentRow["Tipo"].ToString();
            this.txtConcepto.Text = _currentRow["Concepto"].ToString();
            //Pagina de auditoria
            this.txtCreadoPor.Text = _currentRow["Createdby"].ToString();
            this.txtFechaCreacion.Text = _currentRow["CreateDate"].ToString();
            this.txtMayorizadoPor.Text = _currentRow["Mayorizadoby"].ToString();
            this.txtFechaMayorizado.Text = _currentRow["MayorizadoDate"].ToString();
            this.txtFechaAnulacion.Text = _currentRow["AnuladoDate"].ToString();
            this.txtAnuladoPor.Text = _currentRow["Anuladoby"].ToString();
            this.txtEstado.Text = EstadoAsiento();
            if (Convert.ToBoolean(_currentRow["Anulado"]) == true)
                this.lblAnuladod.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                this.lblAnuladod.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //Obtener los datos segun cabecera
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            String sAsiento = (this.Accion == "New") ? "--------" : _Asiento;
            _dsDetalle = AsientoDetalleDAC.GetData(sAsiento, -1, -1);
            _dtDetalle = _dsDetalle.Tables[0];

            this.grid.DataSource = _dtDetalle;
            CalcularFooterAsiento();
        }

        private void ClearControls()
        {
            this.txtConcepto.Text = "";
        }


        private void HabilitarControles(bool Activo, bool Mayorizado)
        {
            this.dtpFecha.Enabled = (Mayorizado == true) ? false : (Activo);
            this.txtTipoCambio.ReadOnly = true;
            this.txtConcepto.ReadOnly = (Mayorizado == true) ? true : !(Activo);
            this.txtFecha.ReadOnly = !Activo;
            this.slkupTipo.ReadOnly = (Mayorizado == true) ? true : !(Activo);
            this.gridView1.OptionsBehavior.ReadOnly = !Activo;
            this.gridView1.OptionsBehavior.AllowAddRows = (Activo) ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = (Activo) ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.ReadOnly = (Mayorizado == true) ? true : !(Activo);
            this.btnCuadreTemporal.Enabled = (Mayorizado == true) ? false : (Activo);
            this.grid.UseEmbeddedNavigator = Activo;
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
            this.btnImprimir.ItemClick += BtnImprimir_ItemClick;
            this.btnColumnas.ItemClick += BtnColumnas_ItemClick;
            this.btnAnular.ItemClick += BtnAnular_ItemClick;
            //this.btnCuadreTemporal.ItemClick += BtnCuadreTemporal_ItemClick;
            this.btnShowLessColumns.ItemClick += BtnShowLessColumns_ItemClick;
        }

        private void BtnCuadreTemporal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.RowCount > 0)
            {
                if (Convert.ToBoolean(_currentRow["Mayorizado"]) == false)
                {
                    bool bExito = false;
                    DataView dvDebito = new DataView();
                    dvDebito.Table = _dsDetalle.Tables[0];
                    dvDebito.RowFilter = "Debito is not null";
                    DataTable dtDebito = dvDebito.ToTable();

                    DataView dvCredito = new DataView();
                    dvCredito.Table = _dsDetalle.Tables[0];
                    dvCredito.RowFilter = "Credito is not null";
                    DataTable dtCredito = dvCredito.ToTable();


                    Double Debito = (dtDebito.Rows.Count == 0) ? 0 : Convert.ToDouble(dtDebito.Compute("SUM(Debito)", ""));
                    Double Creditos = (dtCredito.Rows.Count == 0) ? 0 : Convert.ToDouble(dtCredito.Compute("SUM(Credito)", ""));
                    //bExito = AsientoDAC.CuadreTemporal(_Asiento);

                    Double Diferencia = Debito - Creditos;
                    if (Diferencia != 0 ) {
                        if (Debito < Creditos)
                            _dsDetalle.Tables[0].Rows[_dtDetalle.Rows.Count-1]["Debito"] = Convert.ToDouble(_dsAsiento.Tables[0].Rows[_dtDetalle.Rows.Count-1]["Debito"]) + Diferencia;
                        else
                            _dsDetalle.Tables[0].Rows[_dtDetalle.Rows.Count-1]["Creditos"] = Convert.ToDouble(_dsAsiento.Tables[0].Rows[_dtDetalle.Rows.Count-1]["Creditos"]) + Diferencia;
                    }
                    _currentRow["CuadreTemporal"] = 1;

                    GuardarAsiento();

                    if (bExito)
                    {
                        MessageBox.Show("Se ha cuadrado temporalmente el asiento contable.");
                        //Mostrar el asiento anulado. (como poner la referencia de anulacion en el primero asiento)
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error tratando de cuadrar el asiento..");
                    }
                }
            }
        }

        private void BtnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_dsAsiento.Tables[0].Rows.Count>0){
                if (Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
                {
                    int IdEjercicio = (int)_dsAsiento.Tables[0].Rows[0]["IDEjercicio"];//(int)_dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"];
                    String Periodo = _dsAsiento.Tables[0].Rows[0]["Periodo"].ToString();//_dsEjercicioPeriodo.Tables[0].Rows[0]["Periodo"].ToString();
                    String sAsientoAmulacion = "";
                    bool bExito = false;
                    sAsientoAmulacion = AsientoDAC.Revertir(IdEjercicio, Periodo, _Asiento, sUsuario);

                    if (sAsientoAmulacion != "")
                    {
                        MessageBox.Show("El asiento contable, se ha revertido con exito");
                        //Mostrar el asiento anulado. (como poner la referencia de anulacion en el primero asiento)
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error tratando de revertir el asiento..");
                    }
                }
            }
        }

        private void BtnShowLessColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_ShowLessColumns)
                {
                    //this.btnShowLessColumns.LargeGlyph = null;
                    this.btnShowLessColumns.LargeGlyph = imgCollection.Images[1];//DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/clear_32x32.png");
                    this.btnShowLessColumns.Glyph = imgCollection.Images[1]; //DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/clear_32x32.png");
                    this.btnShowLessColumns.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
                    //Mostrar Detalle
                    this.btnShowLessColumns.Caption = "Ocultar Detalle";
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCentro").Visible = true;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCuentaContable").Visible = true;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Referencia").Visible = true;

                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Linea").VisibleIndex = 0;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "CentroCosto").VisibleIndex = 1;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCentro").VisibleIndex = 2;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "CuentaContable").VisibleIndex = 4;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCuentaContable").VisibleIndex = 5;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Debito").VisibleIndex = 6;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Creditos").VisibleIndex = 7;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Documento").VisibleIndex = 8;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Referencia").VisibleIndex = 9;

                    CargarColumnas();

                }
                else
                {
                    this.btnShowLessColumns.LargeGlyph = imgCollection.Images[0]; //DevExpress.Images.ImageResourceCache.Default.GetImage("images/Spreadsheet/showdetail_32x32.png");
                    this.btnShowLessColumns.Glyph = imgCollection.Images[0];//DevExpress.Images.ImageResourceCache.Default.GetImage("images/Spreadsheet/showdetail_32x32.png");
                    this.btnShowLessColumns.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
                    this.btnShowLessColumns.Caption = "Mostrar Detalle";
                    //Ocultar Detalle
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCentro").Visible = false;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCuentaContable").Visible = false;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Referencia").Visible = false;

                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Linea").VisibleIndex = 0;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "CentroCosto").VisibleIndex = 1;
                    //this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCentro").VisibleIndex = 2;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "CuentaContable").VisibleIndex = 4;
                    //this.gridView1.Columns.FirstOrDefault(a => a.Name == "DescrCuentaContable").VisibleIndex = 5;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Debito").VisibleIndex = 6;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Creditos").VisibleIndex = 7;
                    //this.gridView1.Columns.FirstOrDefault(a => a.Name == "Documento").VisibleIndex = 8;
                    this.gridView1.Columns.FirstOrDefault(a => a.Name == "Referencia").VisibleIndex = 9;
                    CargarColumnas();

                }
                this.btnShowLessColumns.Refresh();
                _ShowLessColumns = !_ShowLessColumns;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnColumnas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmShowHideColumns ofrmLista = new frmShowHideColumns(lstColumnas);
            ofrmLista.FormClosed += OfrmLista_FormClosed;
            ofrmLista.ShowDialog();
        }

        private void OfrmLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmShowHideColumns ofrm = (frmShowHideColumns)sender;
            this.lstColumnas = ofrm.GetLista();
            foreach (GridColumn oCol in this.gridView1.Columns)
            {
                oCol.Visible = (lstColumnas.FirstOrDefault(a => a.Name == oCol.Name).Visible);
            }
        }

        private void BtnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridView1.PostEditor();
            if (_Asiento != null && _Asiento != "")
            {
                DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reporte/Asiento/Plantillas/rptAsiento.repx", true);


                SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

                SqlDataSource ds = report.DataSource as SqlDataSource;
                ds.ConnectionName = "sqlDataSource1";
                String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
                ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

                // Obtain a parameter, and set its value.
                report.Parameters["Asiento"].Value = _Asiento;

                // Show the report's print preview.
                DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                tool.ShowPreview();


            }
        }

        private void ActivateEditGrid(bool Activate)
        {
            this.gridView1.OptionsBehavior.AllowAddRows = (Activate) ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = (Activate) ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.NewItemRowPosition = (Activate) ? NewItemRowPosition.Bottom : NewItemRowPosition.None;



        }

        private void CargarColumnas()
        {
            lstColumnas.Clear();
            foreach (GridColumn oCol in this.gridView1.Columns)
            {
                clsColumnGrid oColumna = new clsColumnGrid()
                {
                    Caption = oCol.Caption,
                    Name = oCol.Name,
                    Visible = oCol.Visible
                };

                lstColumnas.Add(oColumna);
            }

        }



        private void frmAsiento_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosPeriodoActivo();

                HabilitarControles(false, false);
                CargarSimbolosMoneda();
                CargarPrivilegios();
                EnlazarEventos();

                this.gridView1.EditFormPrepared += GridView1_EditFormPrepared;
                this.gridView1.NewItemRowText = Util.Util.constNewItemTextGrid;
                //this.gridView1.ValidatingEditor += GridView1_ValidatingEditor;
                this.gridView1.ValidateRow += GridView1_ValidateRow;
                this.gridView1.InvalidRowException += GridView1_InvalidRowException;
                this.gridView1.RowUpdated += GridView1_RowUpdated;
                this.gridView1.ShownEditor += gridView1_ShownEditor;

                this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
                this.gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;

                Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, _tituloVentana, this);

                //        //Configurar searchLookUp
                //_dtCentros = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0];
                _dtCentros = CentroCostoDAC.GetCentroByCuenta(-1).Tables[0];
                //_dtCentrosConstante = _dtCentros.Clone();
                this.slkupCentroCostoGrid.DataSource = _dtCentros;
                this.slkupCentroCostoGrid.DisplayMember = "Centro";
                this.slkupCentroCostoGrid.ValueMember = "IDCentro";
                this.slkupCentroCostoGrid.NullText = " --- ---";
                this.slkupCentroCostoGrid.EditValueChanged += slkupCuentaContableGrid_EditValueChanged;
                this.slkupCentroCostoGrid.Popup += slkupGrid_Popup;

                // this.slkupCentroCostoGrid.EditValueChanged += SlkupCentroCostoGrid_EditValueChanged;

                //_dtCuentas = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, 1, 1, -1, -1).Tables[0];
                _dtCuentas = CuentaContableDAC.GetCuentaByCentroCosto(0).Tables[0];
                // _dtCuentasConstante = _dtCuentas.Clone();
                this.slkupCuentaContableGrid.DataSource = _dtCuentas;
                this.slkupCuentaContableGrid.DisplayMember = "Cuenta";
                this.slkupCuentaContableGrid.ValueMember = "IDCuenta";
                this.slkupCuentaContableGrid.NullText = " --- ---";
                this.slkupCuentaContableGrid.EditValueChanged += slkupCuentaContableGrid_EditValueChanged;
                this.slkupCuentaContableGrid.Popup += slkupGrid_Popup;



                CargarColumnas();
                Util.Util.ConfigLookupEdit(this.slkupTipo, TipoAsientoDAC.GetTipoAsientoByUsuario(sUsuario).Tables["Data"], "Descr", "Tipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipo, "[{'ColumnCaption':'Tipo','ColumnField':'Tipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                grid.ProcessGridKey += Grid_ProcessGridKey;
                UpdateControlsFromDataRow(_currentRow);
                if (Accion == "New")
                {
                    HabilitarControles(true, false);

                    ClearControls();
                    this.TabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.ValidateChildren();
                }
                else
                {
                    Accion = "Edit";
                    bool bMayorizado = Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]);
                    HabilitarControles(true, bMayorizado);
                    ActivateEditGrid(false);
                }

                if (_Estado == "PndtGuardar")
                {
                    btnEditar_ItemClick(this, null);
                    this.btnCancelar.Enabled = false;
                }
                AplicarPrivilegios();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void gridView1_ShownEditor(object sender, EventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            if (view.FocusedColumn.FieldName == "IDCuenta")
            {
                //LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                SearchLookUpEdit editor = (SearchLookUpEdit)view.ActiveEditor;
                string idCentro = Convert.ToString(view.GetFocusedRowCellValue("IDCentro"));
                if (idCentro == "")
                    idCentro = "0";

                editor.Properties.DataSource = CuentaContableDAC.GetCuentaByCentroCosto(Convert.ToInt32(idCentro)).Tables[0];
            }
            if (view.FocusedColumn.FieldName == "IDCentro")
            {
                //LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                SearchLookUpEdit editor = (SearchLookUpEdit)view.ActiveEditor;
                string IdCuenta = Convert.ToString(view.GetFocusedRowCellValue("IDCuenta"));
                if (IdCuenta == "")
                    IdCuenta = "-1";

                editor.Properties.DataSource = CentroCostoDAC.GetCentroByCuenta(Convert.ToInt32(IdCuenta)).Tables[0];
            }
        }






        void slkupGrid_Popup(object sender, EventArgs e)
        {
            DevExpress.Utils.Win.IPopupControl popupControl = sender as DevExpress.Utils.Win.IPopupControl;
            DevExpress.XtraLayout.LayoutControl layoutControl = popupControl.PopupWindow.Controls[2].Controls[0] as LayoutControl;
            SimpleButton clearButton = ((DevExpress.XtraLayout.LayoutControlItem)layoutControl.Items.FindByName("lciClear")).Control as SimpleButton;
            SimpleButton findButton = ((DevExpress.XtraLayout.LayoutControlItem)layoutControl.Items.FindByName("lciButtonFind")).Control as SimpleButton;

            clearButton.Text = "Limpiar";
            findButton.Text = "Buscar";
        }

        void slkupCuentaContableGrid_EditValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }




        private void CalcularFooterAsiento()
        {
            //Actualizar los totales
            DataView dvDebito = new DataView();
            dvDebito.Table = _dsDetalle.Tables[0];
            dvDebito.RowFilter = "Debito is not null";
            DataTable dtDebito = dvDebito.ToTable();

            DataView dvCredito = new DataView();
            dvCredito.Table = _dsDetalle.Tables[0];
            dvCredito.RowFilter = "Credito is not null";
            DataTable dtCredito = dvCredito.ToTable();

            double dDebito = (dtDebito.Rows.Count == 0) ? 0 : Convert.ToDouble(dtDebito.Compute("SUM(Debito)", ""));
            double dCredito = (dtCredito.Rows.Count == 0) ? 0 : Convert.ToDouble(dtCredito.Compute("SUM(Credito)", ""));

            this.txtDebitoLocal.EditValue = dDebito.ToString("N" + Util.Util.DecimalLenght);
            this.txtCreditoLocal.EditValue = dCredito.ToString("N" + Util.Util.DecimalLenght);
            this.txtDiferencia.EditValue = (dDebito - dCredito).ToString("N" + Util.Util.DecimalLenght);
            //Dolar
            this.txtDebitoDolar.EditValue = (_TipoCambio == 0) ? (0).ToString("N" + Util.Util.DecimalLenght) : (dDebito / _TipoCambio).ToString("N" + Util.Util.DecimalLenght);
            this.txtCreditoDolar.EditValue = (_TipoCambio == 0) ? (0).ToString("N" + Util.Util.DecimalLenght) : (dCredito / _TipoCambio).ToString("N" + Util.Util.DecimalLenght);
            this.txtDirenciaDolar.EditValue = (_TipoCambio == 0) ? (0).ToString("N" + Util.Util.DecimalLenght) : ((dDebito / _TipoCambio) - (dCredito / _TipoCambio)).ToString("N" + Util.Util.DecimalLenght);

            if ((dDebito - dCredito) != 0)
            {
                //En rojo las casillas
                this.txtDiferencia.ForeColor = Color.Red;
                this.txtDirenciaDolar.ForeColor = Color.Red;
            }
            else
            {
                this.txtDiferencia.ForeColor = Color.Black;
                this.txtDirenciaDolar.ForeColor = Color.Black;
            }
        }

        private void GridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            CalcularFooterAsiento();
        }

        private void GridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn CentroCol = view.Columns["IDCentro"];
            GridColumn CuentaCol = view.Columns["IDCuenta"];
            GridColumn DebitoCol = view.Columns["Debito"];
            GridColumn CreditoCol = view.Columns["Credito"];

            object vCentro = (object)(view.GetRowCellValue(e.RowHandle, CentroCol));
            object vCuenta = (object)(view.GetRowCellValue(e.RowHandle, CuentaCol));
            object vDebito = (object)(view.GetRowCellValue(e.RowHandle, DebitoCol));
            object vCredito = (object)(view.GetRowCellValue(e.RowHandle, CreditoCol));
            if (Convert.IsDBNull(vCentro))
            {
                e.Valid = false;
                view.SetColumnError(CentroCol, "El campo no deberia ser vacio");
                return;
            }

            if (Convert.IsDBNull(vCuenta))
            {
                e.Valid = false;
                view.SetColumnError(CuentaCol, "El campo no deberia ser vacio");
                return;
            }

            if (Convert.IsDBNull(vDebito) && Convert.IsDBNull(vCredito))
            {
                if (Convert.IsDBNull(vDebito))
                {
                    e.Valid = false;
                    view.SetColumnError(DebitoCol, "El campo no deberia ser vacio");
                    return;
                }
                if (Convert.IsDBNull(vCredito))
                {
                    e.Valid = false;
                    view.SetColumnError(CreditoCol, "El campo no deberia ser vacio");
                    return;
                }
            }

            if (e.Row == null) return;
            //Get the value of the first column
            int iCentro = (view.GetRowCellValue(e.RowHandle, CentroCol) != null) ? (int)view.GetRowCellValue(e.RowHandle, CentroCol) : -1;
            //Get the value of the second column
            int iCuenta = (view.GetRowCellValue(e.RowHandle, CuentaCol) != null) ? (int)view.GetRowCellValue(e.RowHandle, CuentaCol) : -1;
            //Validity criterion

            DataView Dv = new DataView();
            Dv.Table = ((DataView)view.DataSource).ToTable();
            Dv.RowFilter = string.Format("IDCuenta={0} and IDCentro ={1}", iCuenta, iCentro);

            if (Dv.ToTable().Rows.Count > 1)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                view.SetColumnError(CentroCol, "El centro de costo con la cuenta contable debe de ser únicos");
                view.SetColumnError(CuentaCol, "La cuenta contable con el centro de costo deben de ser únicos");
            }

        }




        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {

                ColumnView view = sender as ColumnView;
                //if (e.Column.FieldName == "IDCentro")
                //{
                //    if (e.Value == null) return;
                //    DataView dt = new DataView();
                //    dt.Table = _dtCentros;
                //    dt.RowFilter = "IDCentro=" + e.Value.ToString();

                //    e.DisplayText = dt.ToTable().Rows[0]["Centro"].ToString() + "-" + dt.ToTable().Rows[0]["Descr"].ToString();
                //}
                //else if (e.Column.FieldName == "IDCuenta")
                //{
                //    if (e.Value == null) return;
                //    DataView dt = new DataView();
                //    dt.Table = _dtCuentas;
                //    dt.RowFilter = "IDCuenta=" + e.Value.ToString();

                //    e.DisplayText = dt.ToTable().Rows[0]["Cuenta"].ToString() + "-" + dt.ToTable().Rows[0]["Descr"].ToString();
                //}

                if (e.Column.FieldName == "Debito" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    if (e.Value == null || e.Value.ToString() == "") return;
                    decimal Value = Convert.ToDecimal(e.Value);


                    NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
                    nfi.CurrencySymbol = Util.Util.LocalSimbolCurrency;
                    // Use the ToString method to format the value as currency ("c").
                    e.DisplayText = ((decimal)e.Value).ToString("C" + Util.Util.DecimalLenght, nfi);


                }
                if (e.Column.FieldName == "Credito" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    if (e.Value == null || e.Value.ToString() == "") return;
                    decimal Value = Convert.ToDecimal(e.Value);


                    NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
                    nfi.CurrencySymbol = Util.Util.LocalSimbolCurrency;
                    // Use the ToString method to format the value as currency ("c").
                    e.DisplayText = ((decimal)e.Value).ToString("C" + Util.Util.DecimalLenght, nfi);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Grid_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el elemento seleccionado?", "Asiento de Diario", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    view.DeleteSelectedRows();
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
        }

        private void GridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DataView dataView = view.DataSource as DataView;
            System.Collections.IEnumerator en = dataView.GetEnumerator();

            en.Reset();

            string currentCode = e.Value.ToString();


            while (en.MoveNext())
            {
                DataRowView row = en.Current as DataRowView;
                object colValue = row["IDCentro"] + " " + row["IDCuenta"];
                if (colValue.ToString() == currentCode)
                {
                    e.ErrorText = "El elemento ya existe.";
                    e.Valid = false;
                    break;
                }
            }
        }

        private void GridView1_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            Control ctrl = Util.Util.FindControl(e.Panel, "Update");
            if (ctrl != null)
                ctrl.Text = "Actualizar";
            ctrl = Util.Util.FindControl(e.Panel, "Cancel");
            if (ctrl != null)
                ctrl.Text = "Cancelar";
        }

        private void CargarDatosPeriodoActivo()
        {
            _dsEjercicioPeriodo = EjercicioDAC.GetEjercicioActivo();
            this.txtEjercicio.Text = _dsEjercicioPeriodo.Tables[0].Rows[0]["DescrEjercicio"].ToString();
            this.txtPeriodo.Text = _dsEjercicioPeriodo.Tables[0].Rows[0]["DescrPeriodo"].ToString();
            DataSet DS = new DataSet();
            DS = TipoCambioDetalleDAC.GetData("TVEN", DateTime.Now);
            double TipoCambio = (DS.Tables[0].Rows.Count > 0) ? Convert.ToDouble(DS.Tables[0].Rows[0]["Monto"]) : 0;
            this.txtTipoCambio.Text = TipoCambio.ToString();
            _TipoCambio = TipoCambio;
        }




        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            try
            {
                if (view == null) return;
                int count = (_dtDetalle.Rows.Count > 0) ? _dtDetalle.AsEnumerable().Max(a => a.Field<int>("Linea")) + 1 : 1;

                view.SetRowCellValue(e.RowHandle, view.Columns["Asiento"], _currentRow["Asiento"]);
                view.SetRowCellValue(e.RowHandle, view.Columns["Linea"], count);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            GridView view = (GridView)sender;
            if (view == null) return;
            if (e.Column.FieldName == "IDCentro")
            {
                string cellValue = (e.Value.ToString() == "") ? "-1" : e.Value.ToString();
                DataView dt = new DataView();
                dt.Table = _dtCentros;
                dt.RowFilter = "IDCentro=" + cellValue;
                if (dt.ToTable().Rows.Count > 0)
                    view.SetRowCellValue(e.RowHandle, view.Columns["DescrCentro"], dt.ToTable().Rows[0]["Descr"].ToString());
                else
                    view.SetRowCellValue(e.RowHandle, view.Columns["DescrCentro"], "");
                //cellValue = (cellValue == "-1") ? "0" : cellValue;
                //_dtCuentas = CuentaContableDAC.GetCuentaByCentroCosto(Convert.ToInt32(cellValue)).Tables[0];
                //this.slkupCuentaContableGrid.DataSource = _dtCuentas;
            }
            if (e.Column.FieldName == "IDCuenta")
            {
                string cellValue = (e.Value.ToString() == "") ? "-1" : e.Value.ToString();
                DataView dt = new DataView();
                dt.Table = _dtCuentas;
                dt.RowFilter = "IDCuenta=" + cellValue;
                if (dt.ToTable().Rows.Count > 0)
                    view.SetRowCellValue(e.RowHandle, view.Columns["DescrCuenta"], dt.ToTable().Rows[0]["Descr"].ToString());
                else
                    view.SetRowCellValue(e.RowHandle, view.Columns["DescrCuenta"], "");

                DataTable _dtTemp = CentroCostoDAC.GetCentroByCuenta(Convert.ToInt32(cellValue)).Tables[0];
                //this.slkupCentroCostoGrid.DataSource = _dtCentros;
                if (_dtTemp.Rows.Count == 1)
                {
                    view.SetRowCellValue(e.RowHandle, view.Columns["IDCentro"], _dtTemp.Rows[0]["IDCentro"].ToString());
                }
            }

        }




        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_currentRow == null)
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

            if (this.dtpFecha.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese la fecha del asiento. \n\r";
            if (this.slkupTipo.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese el tipo de Asiento. \n\r";
            if (this.txtConcepto.Text == "")
                sMensaje = sMensaje + "     • Digite el concepto del Asiento. \n\r";
            if (_dsDetalle.Tables[0].Rows.Count == 0)
                sMensaje = sMensaje + "     • El asiento no tiene detalle en sus lineas. \n\r";
            if (_dsDetalle.Tables[0].Rows.Count == 1)
                sMensaje = sMensaje + "     • El asiento debe de contener al menos dos lineas en su detalle. \n\r";

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
            try
            {
                this.gridView1.PostEditor();

                //this.gridView1.PostEditor();
                //Validar Datos 
                if (!ValidaDatos()) return;

                //Validar si la fecha del asiento contable corresponde a una fecha valida
                DateTime Fecha = Convert.ToDateTime(this.dtpFecha.EditValue);
                try
                {
                    //if (Fecha == null || PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha))
                    PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Han ocurrido los siguientes errores: \r\n" + ex.Message);
                    return;
                }


                //Obtener los datos
                if (_dsAsiento.Tables[0].Rows.Count > 0)
                    _dsAsiento.Tables[0].Rows.Clear();
                _dsAsiento.Tables[0].Rows.Add(_currentRow);
                _currentRow["IDEjercicio"] = this.txtEjercicio.Text.Trim();
                _currentRow["Periodo"] = this.txtPeriodo.Text.Trim();
                _currentRow["Asiento"] = this.txtAsiento.Text.Trim() != "" ? this.txtAsiento.Text.Trim() : "---";
                _currentRow["Tipo"] = this.slkupTipo.EditValue;
                _currentRow["Fecha"] = this.dtpFecha.EditValue;
                _currentRow["FechaHora"] = DateTime.Now;
                _currentRow["Createdby"] = sUsuario;
                _currentRow["CreateDate"] = DateTime.Now;
                // _currentRow["ModuloFuente"] = this.txtModuloFuente.Text.Trim();
                //no incluir:
                //mayorizado
                //mayorizadoDate
                _currentRow["Mayorizadoby"] = "";
                _currentRow["MayorizadoDate"] = DBNull.Value;
                _currentRow["Concepto"] = this.txtConcepto.Text.Trim();
                _currentRow["Mayorizado"] = false;
                _currentRow["Anulado"] = false;
                _currentRow["TipoCambio"] = this.txtTipoCambio.Text.Trim();
                _currentRow["ModuloFuente"] = this.txtModuloFuente.Text.Trim(); ;
                _currentRow["CuadreTemporal"] = false;


                String xml = "";

                _dsAsiento.Tables[0].TableName = "Asiento";

                DataTable dt = new DataTable();
                dt = _dtDetalle.Clone();
                dt.TableName = "Detalle";
                if (_dsAsiento.Tables["Detalle"] != null)
                    _dsAsiento.Tables.Remove(_dsAsiento.Tables["Detalle"]);
                foreach (DataRow dr in _dsDetalle.Tables[0].Rows)
                {

                    dt.Rows.Add(dr.ItemArray);
                }
                _dsAsiento.Tables.Add(dt);

                DataRelation rel = new DataRelation("CabeceraDetalle", _dsAsiento.Tables[0].Columns["Asiento"], _dsAsiento.Tables[1].Columns["Asiento"], true);
                _dsAsiento.DataSetName = "Root";
                xml = _dsAsiento.GetXml(); //ToStringAsXml(_dsAsiento);


                if (Accion == "Edit")
                {
                    _Asiento = AsientoDAC.InsertUpdateAsiento("U", xml, _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());

                }
                else if (Accion == "New")
                {
                    _Asiento = AsientoDAC.InsertUpdateAsiento("I", xml, _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());

                }
                Accion = "Edit";
                CargarAsiento(_Asiento);
                UpdateControlsFromDataRow(_currentRow);
                AplicarPrivilegios();

                _Estado = "stateOk";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //_dsAsiento.RejectChanges();
                //_dsDetalle.RejectChanges();
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Accion == "Edit")
            {
                HabilitarControles(false, true);
                AplicarPrivilegios();
                CargarAsiento(_currentRow["Asiento"].ToString());
                UpdateControlsFromDataRow(_currentRow);
                CalcularFooterAsiento();
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

                    AsientoDAC.InsertUpdateAsiento("D", "", _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());
                }
            }
        }

        private void grid_FocusedViewChanged(object sender, ViewFocusEventArgs e)
        {
            if (e.PreviousView != null)
            {

                e.PreviousView.CloseEditor();

                (e.PreviousView as DevExpress.XtraGrid.Views.Base.ColumnView).UpdateCurrentRow();

            }
        }

        private void btnMayorizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Vlidar si el documento esta guardado si no lo esta realizar el save
            if (_dsAsiento.Tables[0].Rows.Count > 0)
            {
                //Validar el Periodo contable
                DateTime Fecha = Convert.ToDateTime(this.dtpFecha.EditValue);
                try
                {
                    //if (Fecha == null || PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha))
                    PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Han ocurrido los siguientes errores: \r\n" + ex.Message);
                    return;
                }

                GuardarAsiento();

                //Validar situaciones comunes al momento de mayorizar
                if (Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == false)
                {
                    //Validar situaciones comunes al momento de mayorizar

                    int IdEjercicio = (int)_dsAsiento.Tables[0].Rows[0]["IDEjercicio"];// (int)_dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"];
                    String Periodo = _dsAsiento.Tables[0].Rows[0]["Periodo"].ToString();
                    bool bExito = false;
                    bExito = AsientoDAC.Mayorizar(IdEjercicio, Periodo, _Asiento, sUsuario);

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



        private void dtpFecha_Validated(object sender, EventArgs e)
        {

        }

        private void dtpFecha_Validating(object sender, CancelEventArgs e)
        {
            //Tomar el periodo

            DateTime Fecha = Convert.ToDateTime(((DateEdit)sender).EditValue);
            try
            {
                if (Fecha == null || PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha))
                    e.Cancel = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores: \r\n" + ex.Message);
                e.Cancel = true;
            }
        }

        private void dtpFecha_EditValueChanged(object sender, EventArgs e)
        {
            //Tomar el periodo y 
            if (this.dtpFecha.EditValue != null)
            {
                _dsEjercicioPeriodo = PeriodoContableDAC.GetPeriodoContableByFecha(Convert.ToDateTime(this.dtpFecha.EditValue));
                _currentRow["IDEjercicio"] = _dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"].ToString();
                _currentRow["Periodo"] = _dsEjercicioPeriodo.Tables[0].Rows[0]["Periodo"].ToString();
                _currentRow["TipoCambio"] = (_dsEjercicioPeriodo.Tables[0].Rows[0]["TipoCambio"].ToString() == "") ? 0 : Convert.ToDecimal(_dsEjercicioPeriodo.Tables[0].Rows[0]["TipoCambio"]);
                this.txtEjercicio.Text = _currentRow["IDEjercicio"].ToString();
                this.txtPeriodo.Text = _currentRow["Periodo"].ToString();
                this.txtTipoCambio.Text = Convert.ToDecimal(_currentRow["TipoCambio"]).ToString("N" + Util.Util.DecimalLenght);
            }
        }

        private void grid_Leave(object sender, EventArgs e)
        {
            this.gridView1.PostEditor();
        }

        private void frmAsiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_DonCloseCuadre == true) {
                if (Convert.ToDecimal(this.txtDiferencia.EditValue) != 0 && _Estado!="stateOk")
                {
                    MessageBox.Show("Cuadre el asiento de diario y por favor guardelo");
                    e.Cancel = true;
                }
            }
        }

     
    }
}