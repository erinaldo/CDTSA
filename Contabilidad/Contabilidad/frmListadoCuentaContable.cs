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
            this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
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

                PopulateGrid();

               
                Util.Util.ConfigLookupEdit(this.slkupTipo, _dtTipo, "Descr", "IDTipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipo, "[{'ColumnCaption':'IDTipo','ColumnField':'IDTipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                

                EnlazarEventos();
                this.slkupSubTipo.Enabled = false;
                this.slkupGrupo.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
       
        private void PopulateGrid()
        {
            _dsCuenta = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*","*", -1, -1, -1, -1, -1, -1);

            _dtCuenta = _dsCuenta.Tables[0];
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
            this.slkupTipo.ReadOnly = !Activo;
            this.slkupSubTipo.ReadOnly = !Activo;
            //this.txtNivel1.ReadOnly = !Activo;
            this.txtNivel2.ReadOnly = !Activo;
            this.txtNivel3.ReadOnly = !Activo;
            this.txtNivel4.ReadOnly = !Activo;
            this.txtNivel5.ReadOnly = !Activo;
            this.chkComplementaria.ReadOnly = !Activo;
            this.chkEsMayor.ReadOnly = !Activo;
            this.chkActiva.ReadOnly = !Activo;
            this.chkAceptaDatos.ReadOnly = !Activo;
            this.chkUsaCentroCosto.ReadOnly = !Activo;
            this.txtDescripcion.ReadOnly = !Activo;
            this.slkupCuentaMayor.ReadOnly = !Activo;
            this.slkupCuentaAnterior.ReadOnly = !Activo;

           
            this.dtg.Enabled = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;

        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridView.GetDataRow(index);
                UpdateControlsFromCurrentRow(currentRow);
            }
        }

        private void UpdateControlsFromCurrentRow(DataRow Row)
        {
    
            this.slkupGrupo.EditValue = Row["IDGrupo"].ToString();
            this.slkupTipo.EditValue = Row["IDTipo"].ToString();
            this.slkupSubTipo.EditValue = Row["IDSubtipo"].ToString();
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



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }




        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = true;
            HabilitarControles(true);
            ClearControls();
            currentRow = null;
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
            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
        }

        private void SlkupCuentaAnterior_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isEdition)
                    return;
                if (this.slkupCuentaAnterior.EditValue != null && this.slkupCuentaAnterior.EditValue.ToString() != "")
                {
                    DataView dv = new DataView();
                    dv.Table = _dtCuenta;
                    dv.RowFilter = "IDCuenta='" + this.slkupCuentaAnterior.EditValue.ToString() + "' ";

                    DataTable dt = dv.ToTable();
                    bool EsMayor = Convert.ToBoolean((this.chkEsMayor.EditValue == null) ? false : this.chkEsMayor.EditValue);
                    if (!EsMayor)
                    {
                        int i = -1;
                        if (dt.Rows[0]["Nivel5"].ToString() != "0")
                        {
                            i = Convert.ToInt32(dt.Rows[0]["Nivel5"]);
                            i++;
                            this.txtNivel5.Text = i.ToString();
                            this.txtNivel4.Text = dt.Rows[0]["Nivel4"].ToString();
                            this.txtNivel3.Text = dt.Rows[0]["Nivel3"].ToString();
                            this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
                        }
                        else if (dt.Rows[0]["Nivel4"].ToString() != "0")
                        {
                            i = Convert.ToInt32(dt.Rows[0]["Nivel4"]);
                            i++;
                            this.txtNivel5.Text = "0";
                            this.txtNivel4.Text = i.ToString();
                            this.txtNivel3.Text = dt.Rows[0]["Nivel3"].ToString();
                            this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
                        }
                        else if (dt.Rows[0]["Nivel3"].ToString() != "0")
                        {
                            i = Convert.ToInt32(dt.Rows[0]["Nivel3"]);
                            i++;
                            this.txtNivel5.Text = "0";
                            this.txtNivel4.Text = "0";
                            this.txtNivel3.Text = i.ToString();
                            this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
                        }
                        else if (dt.Rows[0]["Nivel2"].ToString() != "0")
                        {
                            i = Convert.ToInt32(dt.Rows[0]["Nivel2"]);
                            i++;
                            this.txtNivel5.Text = "0";
                            this.txtNivel4.Text = "0";
                            this.txtNivel3.Text = "0";
                            this.txtNivel2.Text = i.ToString();
                        }

                    }
                    else
                    {
                        int i = -1;
                        if (dt.Rows[0]["Nivel5"].ToString() != "0")
                        {
                            i = Convert.ToInt32(dt.Rows[0]["Nivel4"]);
                            i++;
                            this.txtNivel4.Text = i.ToString();
                            this.txtNivel3.Text = dt.Rows[0]["Nivel3"].ToString();
                            this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();

                        }
                        else if (dt.Rows[0]["Nivel4"].ToString() != "0")
                        {
                            i = Convert.ToInt32(dt.Rows[0]["Nivel3"]);
                            i++;
                            this.txtNivel3.Text = i.ToString();
                            this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();

                        }
                        else if (dt.Rows[0]["Nivel3"].ToString() != "0")
                        {
                            i = Convert.ToInt32(dt.Rows[0]["Nivel2"]);
                            i++;
                            this.txtNivel2.Text = i.ToString();
                        }

                    }
                    //this.txtNivel2.Text = dt.Rows[0]["Nivel1"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (_dtCuenta.Rows.Count > 1)
                if (this.slkupCuentaAnterior.EditValue == null)
                    sMensaje = sMensaje + "     • Cuenta Anterior. \n\r";
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
                sMensaje = sMensaje + "     • Debe seleccionar si la cuenta es Mayor o Acepta Datos";
            if (Convert.ToBoolean(this.chkEsMayor.EditValue) == false)
                if (this.slkupCuentaMayor.EditValue == null)
                    sMensaje = sMensaje + "     • Cuenta de Mayor. \n\r";
            
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

            if (currentRow != null)
            {
                
                lblStatus.Caption = "Actualizando : " + currentRow["Descr"].ToString();

                Application.DoEvents();
                currentRow.BeginEdit();

                //currentRow["IDCuenta"] = (this.txtNivel1.Text == "") ? "0" : this.txtNivel1.Text;
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
                currentRow["AceptaDatos"] = (this.chkAceptaDatos.EditValue==null) ?false:this.chkAceptaDatos.EditValue;
                currentRow["Activa"] = (this.chkActiva.EditValue==null) ? false: this.chkActiva.EditValue;
                currentRow["IDCuentaAnterior"] = (this.slkupCuentaAnterior.EditValue== null) ? 0:  this.slkupCuentaAnterior.EditValue;
                currentRow["IDCuentaMayor"] = (this.slkupCuentaMayor.EditValue== null)? 0 : this.slkupCuentaMayor.EditValue;
                currentRow["UsaCentroCosto"] = (this.chkUsaCentroCosto.EditValue==null) ? false : this.chkUsaCentroCosto.EditValue;
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
                    HabilitarControles(false);
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
                try
                {
                    CuentaContableDAC.oAdaptador.Update(_dsCuenta, "Data");
                    _dsCuenta.AcceptChanges();
                    isEdition = false;
                    lblStatus.Caption = "Se ha ingresado un nuevo registro";
                    Application.DoEvents();
                    PopulateGrid();
                   

                    ClearControls();
                    HabilitarControles(false);
                    ColumnView view = this.gridView;
                    view.MoveLast();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                   //isEdition = false;
                    _dsCuenta.RejectChanges();
                    currentRow = null;
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = false;
            HabilitarControles(false);
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
                    currentRow.Delete();

                    try
                    {

                        CentroCostoDAC.oAdaptador.Update(_dsCuenta, "Data");
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
            if (this.chkEsMayor.EditValue == null)
                return;
            if ((bool)this.chkEsMayor.EditValue == true)
            {
                this.chkAceptaDatos.Enabled = false;
                this.chkAceptaDatos.EditValue = false;
            }
            else
            {
                this.chkAceptaDatos.Enabled = true;
                this.chkAceptaDatos.EditValue = true;
            }
        }

        private void chkAceptaDatos_CheckStateChanged(object sender, EventArgs e)
        {
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

        private void slkupTipo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.slkupTipo.EditValue != null && this.slkupTipo.EditValue.ToString() != "")
                {
                    DataView dv = new DataView();
                    dv.Table = _dtSubTipo;
                    dv.RowFilter = "IDTipo='" + this.slkupTipo.EditValue.ToString() + "'";
                    Util.Util.ConfigLookupEdit(this.slkupSubTipo, dv.ToTable(), "Descr", "IDSubTipo");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupSubTipo, "[{'ColumnCaption':'IDSubTipo','ColumnField':'IDSubTipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                    this.slkupSubTipo.EditValue = null;
                    this.slkupGrupo.EditValue = null;
                    this.slkupCuentaAnterior.EditValue = null;
                    this.slkupCuentaMayor.EditValue = null;
                    this.slkupSubTipo.Enabled =true;
                    this.slkupGrupo.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void slkupSubTipo_EditValueChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (this.slkupSubTipo.EditValue != null && this.slkupSubTipo.EditValue.ToString() != "")
                {
                    DataView dv = new DataView();
                    dv.Table = _dtGrupo;
                    dv.RowFilter = "IDTipo='" + this.slkupTipo.EditValue.ToString() + "' and IDSubTipo='" + this.slkupSubTipo.EditValue.ToString() + "'";
                    Util.Util.ConfigLookupEdit(this.slkupGrupo, dv.ToTable(), "Descr", "IDSubTipo");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupGrupo, "[{'ColumnCaption':'IDSubTipo','ColumnField':'IDSubTipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                    this.slkupGrupo.EditValue = null;
                    this.slkupCuentaAnterior.EditValue = null;
                    this.slkupCuentaMayor.EditValue = null;
                    this.slkupGrupo.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    dv.RowFilter = "IDGrupo='" + this.slkupGrupo.EditValue.ToString() +"' and IDTipo='" + this.slkupTipo.EditValue.ToString() + "' and IDSubTipo='" + this.slkupSubTipo.EditValue.ToString() + "'";

                    DataTable dt = dv.ToTable();

                    this.txtNivel1.Text = dt.Rows[0]["Nivel1"].ToString();

                    DataView dvCuentaAnt = new DataView();
                    dvCuentaAnt.Table = _dtCuenta;
                    dvCuentaAnt.RowFilter = "Nivel1 = " + dt.Rows[0]["Nivel1"].ToString();

                    Util.Util.ConfigLookupEdit(this.slkupCuentaAnterior, dvCuentaAnt.ToTable(), "Descr", "IDCuenta");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaAnterior, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                    DataView dvCuentaMayor = new DataView();
                    dvCuentaMayor.Table = _dtCuenta;
                    dvCuentaMayor.RowFilter = "EsMayor=1 and Nivel1= " + dt.Rows[0]["Nivel1"].ToString();

                    Util.Util.ConfigLookupEdit(this.slkupCuentaMayor, dvCuentaMayor.ToTable(), "Descr", "IDCuenta");
                    Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaMayor, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}