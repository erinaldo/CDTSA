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
using Util;
using System.Collections;

namespace ControlBancario
{
    public partial class frmListadoDocumentosBancarios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DateTime _FechaInicial;
        DateTime _FechaFinal;

        public frmListadoDocumentosBancarios()
        {
            InitializeComponent();
        }
        private DataSet _dsDocumentos;
        private DataTable _dtDocumentos;


        DataRow _currentRow = null;
        const String _tituloVentana = "Listado de Documentos Bancarios";
        String _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, _sUsuario);
            DT = DS.Tables[0];
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarAsientodeDiario, DT))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarAsientodeDiario, DT))
                this.btnAnular.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarAsientodeDiario, DT))
                this.btnAnular.Enabled = false;

        }

        private void frmListadoDocumentosBancarios_Load(object sender, EventArgs e)
        {
            try
            {


                //HabilitarControles(false);
                _FechaInicial = DateTime.Now.AddDays(-15);
                _FechaFinal = DateTime.Now;

              
                this.gridView1.FocusedRowChanged += GridView_FocusedRowChanged;
                this.gridView1.DoubleClick += GridView_DoubleClick;
                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridDocumentos, _tituloVentana, this);

                EnlazarEventos();
                PopulateGrid();
                CargarPrivilegios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (_currentRow != null && this.gridView1.SelectedRowsCount == 1)
            {
                //frmAsiento ofrmAsiento = new frmAsiento(_currentRow["Asiento"].ToString());
                //ofrmAsiento.FormClosed += OfrmAsiento_FormClosed;
                //ofrmAsiento.ShowDialog();

            }
        }




        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = (int)this.gridView1.FocusedRowHandle;
            if (index > -1)
            {
                _currentRow = gridView1.GetDataRow(index);
                //UpdateControlsFromCurrentRow(_currentRow);
            }
            else _currentRow = null;
        }


        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += BtnAgregar_ItemClick;
            this.btnAnular.ItemClick += BtnEliminar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstDocumentosBancarios.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Documentos Bancarios"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        //private void BtnFiltro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    frmParametrosFiltroAsiento ofrmFiltro = new frmParametrosFiltroAsiento(_FechaInicial, _FechaFinal, _ModuloFuente, _TipoAsiento, (_Mayorizado == 1) ? true : false, (_Anulado == 1) ? true : false, (_CuadreTemporal == 1) ? true : false);
        //    ofrmFiltro.FormClosed += OfrmFiltro_FormClosed;
        //    ofrmFiltro.ShowDialog();
        //}

        //private void OfrmFiltro_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    frmParametrosFiltroAsiento ofrmFiltro = (frmParametrosFiltroAsiento)sender;
        //    //Obtener las variables de filtro
        //    _FechaInicial = ofrmFiltro.FechaInicial;
        //    _FechaFinal = ofrmFiltro.FechaFinal;
        //    _Mayorizado = (Convert.ToInt32(ofrmFiltro.Mayorizado) == 0) ? -1 : Convert.ToInt32(ofrmFiltro.Mayorizado);
        //    _Anulado = (Convert.ToInt32(ofrmFiltro.Anulado) == 0) ? -1 : Convert.ToInt32(ofrmFiltro.Anulado);
        //    _CuadreTemporal = Convert.ToInt32(ofrmFiltro.CuadreTemporal);
        //    _TipoAsiento = ofrmFiltro.TipoAsiento;
        //    _ModuloFuente = ofrmFiltro.ModuloFuente;
        //    ofrmFiltro.FormClosed -= OfrmFiltro_FormClosed;

        //    PopulateGrid();
        //}

        private void BtnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRow != null)
            {
                //string msg = _currentRow["Asiento"] + " eliminado..";
                //if (Convert.ToBoolean(_currentRow["Mayorizado"]) == true)
                //{
                //    lblStatus.Caption = "No puede eliminar asientos que se encuentran mayorizados";
                //    return;
                //}

                //if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + _currentRow["Asiento"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    DataSet _dsAsientotmp = new DataSet();
                //    DataSet _dsDetalle = new DataSet();
                //    DataTable _dtAsientotmp = new DataTable();
                //    DataTable _dtDetalle = new DataTable();

                //    String sAsiento = _currentRow["Asiento"].ToString();

                //    _dsAsientotmp = AsientoDAC.GetDataByAsiento(sAsiento);
                //    _dtDocumentos = _dsDocumentos.Tables[0];

                //    _dsDetalle = AsientoDetalleDAC.GetData(sAsiento, -1, -1);
                //    _dtDetalle = _dsDetalle.Tables[0];


                //    try
                //    {

                //        String xml = "";

                //        _dsAsientotmp.Tables[0].TableName = "Asiento";

                //        DataTable dt = new DataTable();
                //        dt = _dtDetalle.Clone();
                //        dt.TableName = "Detalle";
                //        if (_dsAsientotmp.Tables["Detalle"] != null)
                //            _dsAsientotmp.Tables.Remove(_dsAsientotmp.Tables["Detalle"]);
                //        foreach (DataRow dr in _dsDetalle.Tables[0].Rows)
                //        {
                //            dt.Rows.Add(dr.ItemArray);
                //        }
                //        _dsAsientotmp.Tables.Add(dt);

                //        DataRelation rel = new DataRelation("CabeceraDetalle", _dsAsientotmp.Tables[0].Columns["Asiento"], _dsAsientotmp.Tables[1].Columns["Asiento"], true);
                //        _dsAsientotmp.DataSetName = "Root";
                //        xml = _dsAsientotmp.GetXml(); //ToStringAsXml(_dsAsiento);


                //        AsientoDAC.InsertUpdateAsiento("D", xml, _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());

                //        MessageBox.Show("El asiento se ha eliminado correctamente.");
                //    }
                //    catch (System.Data.SqlClient.SqlException ex)
                //    {
                //        //_dsAsiento.RejectChanges();
                //        //_dsDetalle.RejectChanges();
                //        MessageBox.Show("Han ocurrido errores al momento de eliminar el asiento por favor verifique" + ex.Message);
                //    }

                //    PopulateGrid();

                //}

            }
        }


        private void BtnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRow != null)
            {
                //frmAsiento ofrmAsiento = new frmAsiento(_currentRow["Asiento"].ToString());
                //ofrmAsiento.FormClosed += OfrmAsiento_FormClosed;
                //ofrmAsiento.ShowDialog();

            }
        }

        private void OfrmAsiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmAsiento ofrmAsiento = new frmAsiento();
            //ofrmAsiento.FormClosed += OfrmAsiento_FormClosed;

            //if (!ofrmAsiento.IsDisposed)
            //    ofrmAsiento.ShowDialog();

        }




        private void PopulateGrid()
        {
            //_dsDocumentos = DAC..GetDataByCriterio(_FechaInicial, _FechaFinal, _TipoAsiento, _Mayorizado, _Anulado, _ModuloFuente, _CuadreTemporal, _sUsuario);
            //_dtDocumentos = _dsDocumentos.Tables[0];
            //this.gridDocumentos.DataSource = null;
            //this.gridDocumentos.DataSource = _dtDocumentos;


        }

        private void btnMayorizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////Validar que al menos un elemento se encuentre seleccionado
            //ArrayList rows = new ArrayList();
            //for (int i = 0; i < this.gridView1.SelectedRowsCount; i++)
            //{
            //    if (gridView1.GetSelectedRows()[i] >= 0)
            //        rows.Add(gridView1.GetDataRow(gridView1.GetSelectedRows()[i]));
            //}

            //if (rows.Count == 0)
            //{
            //    MessageBox.Show("Por favor chequee los elementos que desea mayorizar");
            //    return;
            //}

            //try
            //{

            //    for (int i = 0; i < rows.Count; i++)
            //    {
            //        DataRow row = rows[i] as DataRow;
            //        // Change the field value.


            //        DateTime Fecha = Convert.ToDateTime(row["Fecha"]);
            //        try
            //        {
            //            //if (Fecha == null || PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha))
            //            PeriodoContableDAC.ValidaFechaInPeriodoContable(Fecha);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Han ocurrido los siguientes errores: \r\n" + ex.Message);
            //            return;
            //        }

            //        if (Convert.ToBoolean(row["Mayorizado"]) == false)
            //        {
            //            //Validar situaciones comunes al momento de mayorizar
            //            String NumAsiento = row["Asiento"].ToString();
            //            int IdEjercicio = (int)row["IDEjercicio"];// (int)_dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"];
            //            String Periodo = row["Periodo"].ToString();
            //            bool bExito = false;
            //            bExito = AsientoDAC.Mayorizar(IdEjercicio, Periodo, NumAsiento, sUsuario);

            //            if (!bExito)
            //            {
            //                MessageBox.Show("Ha ocurrido un error tratando de mayorizar el asiento..");
            //                return;
            //            }
            //        }

            //    }
            //    MessageBox.Show("El asiento contable, se ha mayorizado con exito");

            //    PopulateGrid();
            //}
            //finally
            //{

            //}


        }
    }
}
