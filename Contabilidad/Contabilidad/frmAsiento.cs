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

namespace CG
{
    public partial class frmAsiento : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private DataTable _dtAsiento;
        private DataTable _dtDetalle;

        private DataSet _dsAsiento;
        private DataSet _dsDetalle;

        private DataTable _dtCuentas;
        private DataTable _dtCentros;

        private DataSet _dsEjercicioPeriodo;

        private DataRow _currentRow;
        private String Accion = "NEW";

        String sUsuario = "jespinoza";
        String _Asiento = "";
        String _ModuloFuente = "";
        String _tituloVentana = "Asiento";


        public frmAsiento()
        {
            InitializeComponent();
            InicializarControles();
            Accion = "New";
            //Obtener el Siguiente consecutivo de la solicitud"
            _dsAsiento = AsientoDAC.GetDataEmpty();
            _dtAsiento = _dsAsiento.Tables[0];
            _ModuloFuente = "CG";
            InicializarNuevoElemento();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frmAsiento(String Asiento)
        {
            InitializeComponent();
            InicializarControles();
            CargarAsiento(Asiento);
        }

        private void CargarAsiento(String Asiento)
        {

            _dsAsiento = AsientoDAC.GetDataByAsiento(Asiento);
            _dtAsiento = _dsAsiento.Tables[0];
            //_ModuloFuente = ModuloFuente;
            _currentRow = _dsAsiento.Tables[0].Rows[0];
            _Asiento = _currentRow["Asiento"].ToString();

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
            DS = TipoCambioDetalleDAC.GetData("TVEN", DateTime.Now);

            _currentRow = _dtAsiento.NewRow();
            _currentRow["IDEjercicio"] = _dsEjercicioPeriodo.Tables[0].Rows[0]["IDEjercicio"].ToString();
            _currentRow["Periodo"] = _dsEjercicioPeriodo.Tables[0].Rows[0]["Periodo"].ToString();
            _currentRow["TipoCambio"] = Convert.ToDecimal((DS.Tables[0].Rows.Count == 0) ? 0 : DS.Tables[0].Rows[0]["Monto"]);
            _currentRow["ModuloFuente"] = _ModuloFuente;
            _currentRow["FechaHora"] = DateTime.Now;
            _currentRow["Fecha"] = DateTime.Now;
            _currentRow["Tipo"] = "CG";
            _currentRow["Concepto"] = null;
            _currentRow["Mayorizado"] = false;
            _currentRow["Anulado"] = false;
            _currentRow["CuadreTemporal"] = false;
            

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
            this.txtTipoCambio.Text = Convert.ToDecimal(_currentRow["TipoCambio"]).ToString("N4");
            this.txtModuloFuente.EditValue = _currentRow["ModuloFuente"].ToString();
            this.dtpFecha.EditValue = Convert.ToDateTime(_currentRow["Fecha"]).ToShortDateString();
            this.txtFecha.EditValue = _currentRow["FechaHora"].ToString();
            this.slkupTipo.EditValue = "CG"; //_currentRow["Tipo"].ToString();
            this.txtConcepto.Text = _currentRow["Concepto"].ToString();
            this.txtEstado.Text = EstadoAsiento();
            //Obtener los datos segun cabecera
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            String sAsiento = (this.Accion == "New") ? "--------" : _Asiento;
            _dsDetalle = AsientoDetalleDAC.GetData(sAsiento, -1, -1);
            _dtDetalle = _dsDetalle.Tables[0];

            this.grid.DataSource = _dtDetalle;

        }

        private void ClearControls()
        {
            this.txtConcepto.Text = "";
        }


        private void HabilitarControles(bool Activo)
        {
            this.dtpFecha.ReadOnly = !Activo;
            this.txtTipoCambio.ReadOnly = !Activo;
            this.txtConcepto.ReadOnly = !Activo;
            this.txtFecha.ReadOnly = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
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
        }


        private void frmAsiento_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Accion=="New")
                //    CargarDatosPeriodoActivo();

                HabilitarControles(false);

                //        //SetDefaultBehaviorControls();
                Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, _tituloVentana, this);
                EnlazarEventos();

                this.gridView1.EditFormPrepared += GridView1_EditFormPrepared;
                this.gridView1.NewItemRowText = Util.Util.constNewItemTextGrid;
                //this.gridView1.ValidatingEditor += GridView1_ValidatingEditor;
                this.gridView1.ValidateRow += GridView1_ValidateRow;
                this.gridView1.InvalidRowException += GridView1_InvalidRowException;

                this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
                //this.gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
                //        //Configurar searchLookUp
                _dtCentros = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0];
                this.slkupCentroCostoGrid.DataSource = _dtCentros;
                this.slkupCentroCostoGrid.DisplayMember = "Centro";
                this.slkupCentroCostoGrid.ValueMember = "IDCentro";
                this.slkupCentroCostoGrid.NullText = " --- ---";
                // this.slkupCentroCostoGrid.EditValueChanged += SlkupCentroCostoGrid_EditValueChanged;

                _dtCuentas = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, 1, 1, -1, -1).Tables[0];
                this.slkupCuentaContableGrid.DataSource = _dtCuentas;
                this.slkupCuentaContableGrid.DisplayMember = "Cuenta";
                this.slkupCuentaContableGrid.ValueMember = "IDCuenta";
                this.slkupCuentaContableGrid.NullText = " --- ---";


                Util.Util.ConfigLookupEdit(this.slkupTipo, TipoAsientoDAC.GetData().Tables["Data"], "Descr", "Tipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipo, "[{'ColumnCaption':'Tipo','ColumnField':'Tipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                grid.ProcessGridKey += Grid_ProcessGridKey;
                UpdateControlsFromDataRow(_currentRow);
                if (Accion == "New")
                {
                    HabilitarControles(true);
                    ClearControls();
                    this.TabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                //else if (Convert.ToBoolean(_currentRow["Mayorizado"]) || Convert.ToBoolean(_currentRow["Anulado"]))
                //{
                //    Accion = "View";
                //    this.TabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //}
                //else
                //{
                //    Accion = "Edit";
                //    this.TabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            //Get the value of the first column
            int iCentro = (int)view.GetRowCellValue(e.RowHandle, CentroCol);
            //Get the value of the second column
            int iCuenta = (int)view.GetRowCellValue(e.RowHandle, CuentaCol);
            //Validity criterion

            DataView Dv = new DataView();
            Dv.Table = ((DataView)view.DataSource).ToTable();
            Dv.RowFilter = "IDCuenta=" + iCuenta.ToString() + " and IDCentro =" + iCentro.ToString();

            if (Dv.ToTable().Rows.Count > 1)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                view.SetColumnError(CentroCol, "The value must be greater than Units On Order");
                view.SetColumnError(CuentaCol, "The value must be less than Units In Stock");
            }

        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDCentro")
            {
                if (e.Value == null) return;
                DataView dt = new DataView();
                dt.Table = _dtCentros;
                dt.RowFilter = "IDCentro=" + e.Value.ToString();

                e.DisplayText = dt.ToTable().Rows[0]["Centro"].ToString() + "-" + dt.ToTable().Rows[0]["Descr"].ToString();
            }
            else if (e.Column.FieldName == "IDCuenta")
            {
                if (e.Value == null) return;
                DataView dt = new DataView();
                dt.Table = _dtCuentas;
                dt.RowFilter = "IDCuenta=" + e.Value.ToString();

                e.DisplayText = dt.ToTable().Rows[0]["Cuenta"].ToString() + "-" + dt.ToTable().Rows[0]["Descr"].ToString();
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
            this.txtTipoCambio.Text = DS.Tables[0].Rows[0]["Monto"].ToString();
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
                string cellValue = e.Value.ToString();
                DataView dt = new DataView();
                dt.Table = _dtCentros;
                dt.RowFilter = "IDCentro=" + cellValue;

                view.SetRowCellValue(e.RowHandle, view.Columns["DescrCentro"], dt.ToTable().Rows[0]["Descr"].ToString());
            }
            if (e.Column.FieldName == "IDCuenta")
            {
                string cellValue = e.Value.ToString();
                DataView dt = new DataView();
                dt.Table = _dtCuentas;
                dt.RowFilter = "IDCuenta=" + cellValue;

                view.SetRowCellValue(e.RowHandle, view.Columns["DescrCuenta"], dt.ToTable().Rows[0]["Descr"].ToString());
            }
        }




        //private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    HabilitarControles(true);
        //    ClearControls();
        //    Accion = "New";
        //    InicializarNuevoElemento();
        //    UpdateControlsFromDataRow(_currentRow);

        //}

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (_currentRow == null)
            {
                return;
            }
            if (Convert.ToBoolean(_currentRow["Mayorizado"])==false && Convert.ToBoolean(_currentRow["Anulado"])==false)
            {
                Accion = "Edit";
                HabilitarControles(true);
            }
           
        }


        private bool ValidaDatos()
        {
            bool result = true;
            String sMensaje = "";

            if (this.dtpFecha.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese la fecha del asiento \n\r";
            if (this.slkupTipo.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese el tipo de Asiento \n\r";
            if (this.txtConcepto.Text == "")
                sMensaje = sMensaje + "     • Digite el concepto del Asiento \n\r";
            if (_dsDetalle.Tables[0].Rows.Count == 0)
                sMensaje = sMensaje + "     • El asiento no tiene detalle en sus lineas \n\r";
            if (sMensaje != "")
            {
                MessageBox.Show("Estimado usuario, favor revise los siguientes errores: \n\r" + sMensaje);
                result = false;
            }
            return result;
        }



        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Validar Datos 
                if (!ValidaDatos()) return;

                //Obtener los datos

                _currentRow["IDEjercicio"] = this.txtEjercicio.Text.Trim();
                _currentRow["Periodo"] = this.txtPeriodo.Text.Trim();
                _currentRow["Asiento"] = "---";
                _currentRow["Tipo"] = this.slkupTipo.EditValue;
                _currentRow["Fecha"] = this.dtpFecha.EditValue;
                _currentRow["FechaHora"] = DateTime.Now;
                _currentRow["Createdby"] = "jespinoza";
                _currentRow["CreateDate"] = DateTime.Now;
                //no incluir:
                //mayorizado
                //mayorizadoDate
                _currentRow["Concepto"] = this.txtConcepto.Text.Trim();
                _currentRow["Mayorizado"] = false;
                _currentRow["Anulado"] = false;
                _currentRow["TipoCambio"] = this.txtTipoCambio.Text.Trim();
                _currentRow["ModuloFuente"] = _ModuloFuente;
                _currentRow["CuadreTemporal"] = false;


                String xml = "";
                if (_dsAsiento.Tables[0].Rows.Count > 0)
                    _dsAsiento.Tables[0].Rows.Clear();
                _dsAsiento.Tables[0].Rows.Add(_currentRow);
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
                    _Asiento= AsientoDAC.InsertUpdateAsiento("U", xml, _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());
                  
                }
                else if (Accion == "New")
                {
                   _Asiento = AsientoDAC.InsertUpdateAsiento("I", xml, _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());
                  
                }
                Accion = "Edit";
                CargarAsiento(_Asiento);
                UpdateControlsFromDataRow(_currentRow);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
               
                MessageBox.Show(ex.Message);
            }

        }



        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (Accion == "Edit")
            {
                HabilitarControles(false);
                CargarAsiento(_currentRow["Asiento"].ToString());
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

                    AsientoDAC.InsertUpdateAsiento("D", "", _currentRow["Asiento"].ToString(), _currentRow["Tipo"].ToString());
                }
            }
        }



    }
}