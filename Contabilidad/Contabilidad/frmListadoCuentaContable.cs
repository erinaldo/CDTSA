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
using DevExpress.XtraGrid.Views.Base;
using Security;


namespace CG
{
    public partial class frmListadoCuentaContable : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtCuenta;
        //private DataTable _lstCentroAcumuladores;
        private DataSet _dsCuenta;

        private DataTable _dtTipo;
        private DataTable _dtSubTipo;
        private DataTable _dtGrupo;
        private DataTable _dtSecurity;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        private bool isEdition = false;

        DataRow currentRow;
        const String _tituloVentana = "Listado de Cuentas Contables";


        public frmListadoCuentaContable()
        {
            InitializeComponent();
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;

        }



        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnAsociarCentroCosto.ItemClick += BtnAsociarCentroCosto_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstCuentasContables.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado de Cuentas Contables"
            };


            this.gridView.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
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
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarCuentaContable, _dtSecurity))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarCuentaContable, _dtSecurity))
                this.btnEditar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCuentaContable, _dtSecurity))
                this.btnEliminar.Enabled = false;
        }


        private void BtnAsociarCentroCosto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentRow != null)
            {
                if (Convert.ToBoolean(currentRow["UsaCentroCosto"]))
                {
                    frmCentroACuenta ofrmCentroCuenta = new frmCentroACuenta(currentRow);
                    ofrmCentroCuenta.ShowDialog();
                }
            }
        }

        private void PopulateDataSearchLookup()
        {
            Util.Util.ConfigLookupEdit(this.slkupCuentaAnterior, _dtCuenta, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaAnterior, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            DataView dvCuentaMayor = new DataView();
            dvCuentaMayor.Table = _dtCuenta;
            dvCuentaMayor.RowFilter = "EsMayor=1";

            Util.Util.ConfigLookupEdit(this.slkupCuentaMayor, dvCuentaMayor.ToTable(), "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaMayor, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
        }

        private void frmListadoCuentaContable_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);
                _dtTipo = TipoCuentaDAC.GetData().Tables["Data"];
                _dtSubTipo = SubTipoCuentaDAC.GetData(-1, -1).Tables["Data"];
                _dtGrupo = GrupoDAC.GetData(-1, -1, -1).Tables["Data"];

                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.dtg, _tituloVentana, this);

                EnlazarEventos();

                PopulateGrid();

                Util.Util.ConfigLookupEdit(this.slkupGrupo, _dtGrupo, "Descr", "IDGrupo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupGrupo, "[{'ColumnCaption':'IDGrupo','ColumnField':'IDGrupo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupTipo, _dtTipo, "Descr", "IDTipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipo, "[{'ColumnCaption':'IDTipo','ColumnField':'IDTipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupSubTipo, _dtSubTipo, "Descr", "IDSubTipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupSubTipo, "[{'ColumnCaption':'IDSubTipo','ColumnField':'IDSubTipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                this.slkupSubTipo.ReadOnly = true;
                this.slkupTipo.ReadOnly = true;
                this.slkupCuentaAnterior.ReadOnly = true;
                this.txtNivel2.ReadOnly = true;
                this.txtNivel3.ReadOnly = true;
                this.txtNivel4.ReadOnly = true;
                this.txtNivel5.ReadOnly = true;

                CargarPrivilegios();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void PopulateGrid()
        {
            _dsCuenta = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, -1, -1, -1, -1);

            _dtCuenta = _dsCuenta.Tables[0];
            this.dtg.DataSource = null;
            this.dtg.DataSource = _dtCuenta;
            this.gridView.SelectRow(-1);

            PopulateDataSearchLookup();



        }

        private void ClearControls()
        {
            this.slkupGrupo.EditValue = null;
            this.slkupTipo.EditValue = null;
            this.slkupSubTipo.EditValue = null;
            this.txtNivel1.Text = "";
            this.txtNivel2.Text = "";
            this.txtNivel3.Text = "";
            this.txtNivel4.Text = "";
            this.txtNivel5.Text = "";
            this.chkComplementaria.EditValue = null;
            this.chkEsMayor.EditValue = null;
            this.chkActiva.EditValue = true;
            this.chkAceptaDatos.EditValue = null;
            this.chkUsaCentroCosto.EditValue = null;
            this.txtCuenta.Text = "";
            this.txtDescripcion.Text = "";
            this.slkupCuentaMayor.EditValue = null;
            this.slkupCuentaAnterior.EditValue = null;

        }

        private void HabilitarControles(bool Activo)
        {
            this.slkupGrupo.ReadOnly = !Activo;

            this.chkComplementaria.ReadOnly = !Activo;
            this.chkEsMayor.ReadOnly = !Activo;
            this.chkActiva.ReadOnly = !Activo;
            this.chkAceptaDatos.ReadOnly = !Activo;
            this.chkUsaCentroCosto.ReadOnly = !Activo;
            this.txtDescripcion.ReadOnly = !Activo;
            this.slkupCuentaMayor.ReadOnly = !Activo;

            this.dtg.Enabled = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;

            //Habilitar los check por que se excluyen
            this.chkEsMayor.Enabled = true;
            this.chkAceptaDatos.Enabled = true;

        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridView.GetDataRow(index);
                UpdateControlsFromCurrentRow(currentRow);
                HabilitarBotones(currentRow);
            }
        }

        private void HabilitarBotones(DataRow currentRow)
        {
            if (currentRow != null)
            {
                if (Convert.ToBoolean(currentRow["UsaCentroCosto"]))
                    this.btnAsociarCentroCosto.Enabled = true;
                else
                    this.btnAsociarCentroCosto.Enabled = false;
            }
        }

        private void UpdateControlsFromCurrentRow(DataRow Row)
        {

            if (Row != null)
            {
                this.slkupTipo.EditValue = Row["IDTipo"].ToString();
                this.slkupSubTipo.EditValue = Row["IDSubtipo"].ToString();
                this.slkupGrupo.EditValue = Row["IDGrupo"].ToString();
                this.txtNivel1.Text = Row["Nivel1"].ToString();
                this.txtNivel2.Text = Row["Nivel2"].ToString();
                this.txtNivel3.Text = Row["Nivel3"].ToString();
                this.txtNivel4.Text = Row["Nivel4"].ToString();
                this.txtNivel5.Text = Row["Nivel5"].ToString();
                this.chkComplementaria.EditValue = Convert.ToBoolean(Row["Complementaria"]);
                this.chkEsMayor.EditValue = Convert.ToBoolean(Row["EsMayor"]);
                this.chkActiva.EditValue = Convert.ToBoolean(Row["Activa"]);
                this.chkAceptaDatos.EditValue = Convert.ToBoolean(Row["AceptaDatos"]);
                this.chkUsaCentroCosto.EditValue = Convert.ToBoolean(Row["UsaCentroCosto"]);
                this.txtCuenta.Text = Row["Cuenta"].ToString();
                this.txtDescripcion.Text = Row["Descr"].ToString();
                this.slkupCuentaMayor.EditValue = Row["IDCuentaMayor"].ToString();
                this.slkupCuentaAnterior.EditValue = Row["IDCuentaAnterior"].ToString();
            }
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }






        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = true;
            ClearControls();
            HabilitarControles(true);
            currentRow = null;
            this.slkupGrupo.Focus();
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentRow == null)
            {
                lblStatus.Caption = "Por favor seleccione un elemento de la Lista";
                return;
            }
            else
                lblStatus.Caption = "";
            isEdition = true;

            HabilitarControles(true);
            //Inactivar Controles que no se editan
            this.slkupGrupo.ReadOnly = true;
            this.slkupCuentaMayor.ReadOnly = true;

            if (CuentaContableDAC.GetCountCuentaByNivel(currentRow["Nivel1"].ToString(), currentRow["Nivel2"].ToString(), currentRow["Nivel3"].ToString(), currentRow["Nivel4"].ToString(), currentRow["Nivel5"].ToString()) > 1)
            {
                this.chkAceptaDatos.ReadOnly = true;
                this.chkEsMayor.ReadOnly = true;
                this.chkActiva.ReadOnly = true;
            }
            else
            {
                this.chkAceptaDatos.ReadOnly = false;
                this.chkEsMayor.ReadOnly = false;
                this.chkActiva.ReadOnly = false;
            }

            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
        }


        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";

            if (this.slkupTipo.EditValue == null)
                sMensaje = sMensaje + "     • Tipo de Cuenta. \n\r";
            if (this.slkupSubTipo.EditValue == null)
                sMensaje = sMensaje + "     • Sub Tipo de Cuenta. \n\r";
            if (this.slkupGrupo.EditValue == null)
                sMensaje = sMensaje + "     • Grupo de Cuenta. \n\r";
            if (this.txtNivel1.Text == "")
                sMensaje = sMensaje + "     • Nivel 1. \n\r";
            if (this.txtDescripcion.Text == "")
                sMensaje = sMensaje + "     • Descripción de la Cuenta. \n\r";
            if (this.chkAceptaDatos.EditValue == null && this.chkEsMayor.EditValue == null)
                sMensaje = sMensaje + "     • Debe seleccionar si la cuenta es de Mayor o Acepta Datos. \n\r";

            
            if (this.slkupCuentaMayor.EditValue == null)
            {
                //Validar que la cuenta de mayor no este ingresadas
                if (CuentaContableDAC.ExisteCuentaPrimerNivel(Convert.ToInt32(this.txtNivel1.Text)))

                    sMensaje = sMensaje + "     • Por favor seleccione la cuenta de mayor.";


            }
            if (sMensaje != "")
            {
                result = false;
                MessageBox.Show("Por favor revise los siguientes campos, puede que sean obligatorios: \n\r\n\r" + sMensaje);
            }
            return result;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidarDatos())
                return;
            try
            {

                if (currentRow != null)
                {

                    lblStatus.Caption = "Actualizando : " + currentRow["Descr"].ToString();

                    Application.DoEvents();
                    currentRow.BeginEdit();


                    currentRow["IDGrupo"] = this.slkupGrupo.EditValue;
                    currentRow["IDTipo"] = this.slkupTipo.EditValue;
                    currentRow["IDSubTipo"] = this.slkupSubTipo.EditValue;
                    currentRow["Nivel1"] = (this.txtNivel1.Text == "") ? "0" : this.txtNivel1.Text;
                    currentRow["Nivel2"] = (this.txtNivel2.Text == "") ? "0" : this.txtNivel2.Text;
                    currentRow["Nivel3"] = (this.txtNivel3.Text == "") ? "0" : this.txtNivel3.Text;
                    currentRow["Nivel4"] = (this.txtNivel4.Text == "") ? "0" : this.txtNivel4.Text;
                    currentRow["Nivel5"] = (this.txtNivel5.Text == "") ? "0" : this.txtNivel5.Text;
                    currentRow["Descr"] = this.txtDescripcion.Text;
                    currentRow["EsMayor"] = (this.chkEsMayor.EditValue == null) ? false : this.chkEsMayor.EditValue;
                    currentRow["AceptaDatos"] = (this.chkAceptaDatos.EditValue == null) ? false : this.chkAceptaDatos.EditValue;
                    currentRow["Activa"] = (this.chkActiva.EditValue == null) ? false : this.chkActiva.EditValue;
                    currentRow["IDCuentaAnterior"] = (this.slkupCuentaAnterior.EditValue == null) ? 0 : this.slkupCuentaAnterior.EditValue;
                    currentRow["IDCuentaMayor"] = (this.slkupCuentaMayor.EditValue == null) ? 0 : this.slkupCuentaMayor.EditValue;
                    currentRow["UsaCentroCosto"] = (this.chkUsaCentroCosto.EditValue == null) ? false : this.chkUsaCentroCosto.EditValue;
                    currentRow["Complementaria"] = (this.chkComplementaria.EditValue == null) ? false : this.chkComplementaria.EditValue;
                    currentRow["IDSeccion"] = 0;



                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsCuenta.GetChanges(DataRowState.Modified);

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
                                    msg = msg + dr["Centro"].ToString();
                                }
                            }
                        }

                        lblStatus.Caption = msg;
                    }

                    //Si no hay errores

                    if (okFlag)
                    {
                        CuentaContableDAC.oAdaptador.Update(_dsChanged, "Data");
                        isEdition = false;
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();

                        _dsCuenta.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsCuenta.RejectChanges();
                    }
                }
                else
                {

                    //nuevo registro
                    currentRow = _dtCuenta.NewRow();

                    currentRow["IDGrupo"] = this.slkupGrupo.EditValue;
                    currentRow["IDTipo"] = this.slkupTipo.EditValue;
                    currentRow["IDSubTipo"] = this.slkupSubTipo.EditValue;
                    currentRow["Nivel1"] = (this.txtNivel1.Text == "") ? "0" : this.txtNivel1.Text;
                    currentRow["Nivel2"] = (this.txtNivel2.Text == "") ? "0" : this.txtNivel2.Text;
                    currentRow["Nivel3"] = (this.txtNivel3.Text == "") ? "0" : this.txtNivel3.Text;
                    currentRow["Nivel4"] = (this.txtNivel4.Text == "") ? "0" : this.txtNivel4.Text;
                    currentRow["Nivel5"] = (this.txtNivel5.Text == "") ? "0" : this.txtNivel5.Text;
                    currentRow["Descr"] = this.txtDescripcion.Text;
                    currentRow["EsMayor"] = (this.chkEsMayor.EditValue == null) ? false : this.chkEsMayor.EditValue;
                    currentRow["AceptaDatos"] = (this.chkAceptaDatos.EditValue == null) ? false : this.chkAceptaDatos.EditValue;
                    currentRow["Activa"] = (this.chkActiva.EditValue == null) ? false : this.chkActiva.EditValue;
                    currentRow["IDCuentaAnterior"] = (this.slkupCuentaAnterior.EditValue == null) ? 0 : this.slkupCuentaAnterior.EditValue;
                    currentRow["IDCuentaMayor"] = (this.slkupCuentaMayor.EditValue == null) ? 0 : this.slkupCuentaMayor.EditValue;
                    currentRow["UsaCentroCosto"] = (this.chkUsaCentroCosto.EditValue == null) ? false : this.chkUsaCentroCosto.EditValue;
                    currentRow["Complementaria"] = (this.chkComplementaria.EditValue == null) ? false : this.chkComplementaria.EditValue;
                    currentRow["IDSeccion"] = 0;


                    _dtCuenta.Rows.Add(currentRow);
                    //_dsCuenta.Tables[0].Rows.Add(currentRow);
                   
                        CuentaContableDAC.oAdaptador.Update(_dsCuenta, "Data");
                        _dsCuenta.AcceptChanges();
                        isEdition = false;
                        lblStatus.Caption = "Se ha ingresado un nuevo registro";
                        Application.DoEvents();
                        PopulateGrid();


                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                        ColumnView view = this.gridView;
                        view.MoveLast();
                   
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //isEdition = false;
                _dsCuenta.RejectChanges();
                currentRow = null;
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = false;
            HabilitarControles(false);
            AplicarPrivilegios();
            SetCurrentRow();
            lblStatus.Caption = "";
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentRow != null)
            {
                string msg = currentRow["Descr"] + " eliminado..";

                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + currentRow["Descr"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Verificar si la cuenta a eliminar es de mayor
                    if (Convert.ToBoolean(currentRow["EsMayor"]))
                    {
                        //Validar si tiene hijos
                        if (CuentaContableDAC.GetCountCuentaByNivel(currentRow["Nivel1"].ToString(), currentRow["Nivel2"].ToString(), currentRow["Nivel3"].ToString(), currentRow["Nivel4"].ToString(), currentRow["Nivel5"].ToString()) > 1)
                        {
                            MessageBox.Show("La cuenta que desea eliminar es una cuenta de Mayor y tiene Sub Cuentas, por favor elimine las SubCuentas antes de proseguir");
                            return;
                        }
                    }

                    currentRow.Delete();

                    try
                    {

                        CuentaContableDAC.oAdaptador.Update(_dsCuenta, "Data");
                        _dsCuenta.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsCuenta.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void chkEsMayor_CheckStateChanged(object sender, EventArgs e)
        {
            if (!isEdition)
                return;
            if (this.chkEsMayor.EditValue == null)
                return;
            if ((bool)this.chkEsMayor.EditValue == true)
            {
                this.chkAceptaDatos.Enabled = false;
                this.chkAceptaDatos.EditValue = false;
                this.chkUsaCentroCosto.Enabled = false;
            }
            else
            {
                this.chkAceptaDatos.Enabled = true;
                this.chkAceptaDatos.EditValue = true;
                this.chkUsaCentroCosto.Enabled = true;
            }
        }

        private void chkAceptaDatos_CheckStateChanged(object sender, EventArgs e)
        {
            if (!isEdition)
                return;
            if (this.chkAceptaDatos.EditValue == null)
                return;
            if ((bool)this.chkAceptaDatos.EditValue == true)
            {
                this.chkEsMayor.Enabled = false;
                this.chkEsMayor.EditValue = false;
            }
            else
            {
                this.chkEsMayor.Enabled = true;
                this.chkEsMayor.EditValue = true;
            }
        }





        private void slkupGrupo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isEdition)
                    return;
                if (this.slkupGrupo.EditValue != null && this.slkupGrupo.EditValue.ToString() != "")
                {

                    DataView dv = new DataView();
                    dv.Table = _dtGrupo;
                    dv.RowFilter = string.Format("IDGrupo='{0}'", this.slkupGrupo.EditValue);

                    DataTable dt = dv.ToTable();
                    if (dt.Rows.Count == 0)
                        return;
                    //Llenar tipo y sub Tipo
                    this.slkupTipo.EditValue = dt.Rows[0]["IDTipo"].ToString();
                    this.slkupSubTipo.EditValue = dt.Rows[0]["IDSubTipo"].ToString();

                    //Validar si el tipo seleccionado ya tiene el elemento del primer nivel
                    if (CuentaContableDAC.ExisteCuentaPrimerNivel(Convert.ToInt32(dt.Rows[0]["Nivel1"].ToString())))
                        this.txtDescripcion.Text = "";
                    else
                        this.txtDescripcion.Text = dt.Rows[0]["Descr"].ToString();

                    this.txtNivel1.Text = dt.Rows[0]["Nivel1"].ToString();
                    this.chkComplementaria.Enabled = Convert.ToBoolean(dt.Rows[0]["UsaComplementaria"]);
                    this.chkComplementaria.EditValue = null;


                    DataView dvCuentaAnt = new DataView() { Table = _dtCuenta, RowFilter = "Nivel1 = " + dt.Rows[0]["Nivel1"].ToString() };

                    Util.Util.ConfigLookupEdit(this.slkupCuentaAnterior, dvCuentaAnt.ToTable(), "Descr", "IDCuenta");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaAnterior, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                    DataView dvCuentaMayor = new DataView() { Table = _dtCuenta, RowFilter = "EsMayor=1 and Nivel1= " + dt.Rows[0]["Nivel1"].ToString() };

                    Util.Util.ConfigLookupEdit(this.slkupCuentaMayor, dvCuentaMayor.ToTable(), "Descr", "IDCuenta");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaMayor, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void slkupCuentaMayor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {


                if (!isEdition)
                    return;
                if (this.slkupCuentaMayor.EditValue != null && this.slkupCuentaMayor.EditValue.ToString() != "")
                {

                    DataView dv = new DataView();
                    dv.Table = _dtCuenta;
                    dv.RowFilter = string.Format("IDCuenta='{0}' ", this.slkupCuentaMayor.EditValue);
                    DataTable dt = dv.ToTable();
                    if (dt.Rows.Count == 0)
                        return;
                    bool EsMayor = Convert.ToBoolean((this.chkEsMayor.EditValue == null) ? false : this.chkEsMayor.EditValue);
                    //if (!EsMayor)
                    //{


                    if (dt.Rows[0]["Nivel4"].ToString() != "0")
                    {
                        int iProximoConsecutivo = CuentaContableDAC.GetNextConsecutivoFinal(Convert.ToInt32(dt.Rows[0]["Nivel1"]), Convert.ToInt32(dt.Rows[0]["Nivel2"]), Convert.ToInt32(dt.Rows[0]["Nivel3"]), Convert.ToInt32(dt.Rows[0]["Nivel4"]), -1);

                        // iProximoConsecutivo++;

                        this.txtNivel5.Text = iProximoConsecutivo.ToString();
                        this.txtNivel4.Text = dt.Rows[0]["Nivel4"].ToString();
                        this.txtNivel3.Text = dt.Rows[0]["Nivel3"].ToString();
                        this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
                    }
                    else if (dt.Rows[0]["Nivel3"].ToString() != "0")
                    {
                        int iProximoConsecutivo = CuentaContableDAC.GetNextConsecutivoFinal(Convert.ToInt32(dt.Rows[0]["Nivel1"]), Convert.ToInt32(dt.Rows[0]["Nivel2"]), Convert.ToInt32(dt.Rows[0]["Nivel3"]), -1, 0);
                        // iProximoConsecutivo++;

                        this.txtNivel5.Text = "0";
                        this.txtNivel4.Text = iProximoConsecutivo.ToString();
                        this.txtNivel3.Text = dt.Rows[0]["Nivel3"].ToString();
                        this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
                    }
                    else if (dt.Rows[0]["Nivel2"].ToString() != "0")
                    {
                        int iProximoConsecutivo = CuentaContableDAC.GetNextConsecutivoFinal(Convert.ToInt32(dt.Rows[0]["Nivel1"]), Convert.ToInt32(dt.Rows[0]["Nivel2"]), -1, 0, 0);

                        // iProximoConsecutivo++;

                        this.txtNivel5.Text = "0";
                        this.txtNivel4.Text = "0";
                        this.txtNivel3.Text = iProximoConsecutivo.ToString();
                        this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
                    }
                    else if (dt.Rows[0]["Nivel1"].ToString() != "0")
                    {
                        int iProximoConsecutivo = CuentaContableDAC.GetNextConsecutivoFinal(Convert.ToInt32(dt.Rows[0]["Nivel1"]), -1, 0, 0, 0);
                        // iProximoConsecutivo++;

                        this.txtNivel5.Text = "0";
                        this.txtNivel4.Text = "0";
                        this.txtNivel3.Text = "0";
                        this.txtNivel2.Text = iProximoConsecutivo.ToString();
                        this.txtNivel1.Text = dt.Rows[0]["Nivel1"].ToString();
                    }


                    this.txtDescripcion.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}