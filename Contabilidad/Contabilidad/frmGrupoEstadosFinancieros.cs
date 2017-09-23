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
using DevExpress.XtraGrid.Views.Base;
using CG.DAC;


namespace CG
{
    public partial class frmGrupoEstadosFinancieros : DevExpress.XtraBars.Ribbon.RibbonForm
    {
  
        
        private DataTable _dtGrupo;
        private DataTable _lstGrupoAcumuladores;
        private DataSet _dsGrupo;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count>0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Grupos Estados Financieros";
        private bool isEdition = false;

        public frmGrupoEstadosFinancieros()
        {
            InitializeComponent();
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CargarTipoDeGrupo() {
            //Estado de resultado
            String stipo = "";
            if (this.cmbTipoGrupo.SelectedIndex == 0) { 
                stipo = "R";
            }
            else if (this.cmbTipoGrupo.SelectedIndex == 1) //Balance General
                stipo = "B";

            DataTable dt = GrupoDAC.GetGrupoByTipo(stipo).Tables[0];


            Util.Util.ConfigLookupEdit(this.slkpTipoDeGrupo, dt, "Descr", "IDGrupo");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkpTipoDeGrupo, "[{'ColumnCaption':'IDGrupo','ColumnField':'IDGrupo','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");
        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DS = UsuarioDAC.GetAccionModuloFromRole(0,_sUsuario );
            _dtSecurity = DS.Tables[0];

            AplicarPrivilegios();
        }

        private void AplicarPrivilegios()
        {
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarGrupoEstadosFinancieros, _dtSecurity))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarGrupoEstadosFinancieros, _dtSecurity))
                this.btnEditar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarGrupoEstadosFinancieros, _dtSecurity))
                this.btnEliminar.Enabled = false;
        }


        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
            this.slkupGrupoAcumulador.EditValueChanged += slkupGrupoAcumulador_EditValueChanged;  
        }

        void slkupGrupoAcumulador_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isEdition)
                    return;
                if (this.slkupGrupoAcumulador.EditValue != null && this.slkupGrupoAcumulador.EditValue.ToString() != "")
                {
                    DataView dv = new DataView();
                    dv.Table = _dtGrupo;
                    dv.RowFilter = string.Format("IDGrupo='{0}' ", this.slkupGrupoAcumulador.EditValue);
                    DataTable dt = dv.ToTable();

                    bool EsAcumulador = Convert.ToBoolean((this.chkAcumulador.EditValue == null) ? false : this.chkAcumulador.EditValue);

                    if (dt.Rows[0]["Nivel2"].ToString() != "0")
                    {
                        int iProximoConsecutivo = GrupoEstadosFinancierosDAC.GetNextConsecutivo(Convert.ToInt32(dt.Rows[0]["Nivel1"]), Convert.ToInt32(dt.Rows[0]["Nivel2"]), -1,GetTipoGrupo());

                        //iProximoConsecutivo++;

                        this.txtNivel3.Text = iProximoConsecutivo.ToString();
                        this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
                        this.txtNivel1.Text = dt.Rows[0]["Nivel1"].ToString();
                    }
                    else if (dt.Rows[0]["Nivel1"].ToString() != "0")
                    {
                        int iProximoConsecutivo = GrupoEstadosFinancierosDAC.GetNextConsecutivo(Convert.ToInt32(dt.Rows[0]["Nivel1"]), -1, 0,GetTipoGrupo());
                        //iProximoConsecutivo++;

                        this.txtNivel3.Text = "0";
                        this.txtNivel2.Text = iProximoConsecutivo.ToString();
                        this.txtNivel1.Text = dt.Rows[0]["Nivel1"].ToString();
                    }

                    //Inactivar  los acumuladores
                    if (this.txtNivel3.Text != "0")
                        this.chkAcumulador.Enabled = false;
                    else
                        this.chkAcumulador.Enabled = true;
                
                    this.slkpTipoDeGrupo.EditValue = dt.Rows[0]["IDGrupoCuenta"];
                    if (this.cmbTipoGrupo.SelectedIndex==0)
                        this.slkpTipoDeGrupo.Enabled = true;
                    else
                        this.slkpTipoDeGrupo.Enabled = false;
                    this.txtDescripcion.Text = "";
                    this.txtDescripcion.Focus();

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstGruposEstadosFinancieros.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Grupos de Estado Financieros"
            };


            this.gridView.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmListadoCentroCosto_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.dtg, _tituloVentana, this);

               

                EnlazarEventos();

                this.cmbTipoGrupo.SelectedIndex = 0;
                //PopulateGrid();
                CargarTipoDeGrupo();
                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String GetTipoGrupo() {
            String sTipo  ="";
            if (this.cmbTipoGrupo.SelectedIndex > -1) {
                switch (this.cmbTipoGrupo.SelectedIndex) { 
                    case 0:
                        sTipo = "ER";
                        break;
                    case 1:
                        sTipo = "BG";
                        break;
                }
                return sTipo;
            }
            else
                return "";
        }

        private void PopulateData()
        {
            String sTipo = GetTipoGrupo();
            _lstGrupoAcumuladores = GrupoEstadosFinancierosDAC.GetData(-1, "*", "*", "*", "*",1,-1,sTipo).Tables["Data"];
            Util.Util.ConfigLookupEdit(this.slkupGrupoAcumulador, _lstGrupoAcumuladores, "Descr", "IDGrupo");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupGrupoAcumulador, "[{'ColumnCaption':'Grupo','ColumnField':'Grupo','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            
        }

        private void PopulateGrid()
        {
            CargarTipoDeGrupo();
            String sTipo = GetTipoGrupo();
            _dsGrupo = GrupoEstadosFinancierosDAC.GetData(-1, "*", "*", "*", "*",-1, -1,sTipo);

            _dtGrupo = _dsGrupo.Tables[0];
            this.dtg.DataSource = null;
            this.dtg.DataSource = _dtGrupo;

            PopulateData();

        }

        private void ClearControls()
        {
            this.txtNivel1.Text = "";
            this.txtNivel2.Text = "";
            this.txtNivel3.Text = "";
            this.txtCentro.Text = "";
            this.txtDescripcion.Text = "";
            this.chkActivo.EditValue = true;
            this.chkAcumulador.EditValue = false;
            this.slkpTipoDeGrupo.EditValue = null;
            this.slkupGrupoAcumulador.EditValue = null;

            if (this._lstGrupoAcumuladores.Rows.Count < 1)
            {
                this.txtNivel1.Text = "1";
                this.txtNivel2.Text = "0";
                this.txtNivel3.Text = "0";
            }

        }

        private void HabilitarControles(bool Activo)
        {
            //this.txtNivel1.ReadOnly = Activo;
            //this.txtNivel2.ReadOnly = Activo;
            //this.txtNivel3.ReadOnly = Activo;
            this.txtDescripcion.ReadOnly = !Activo;
            this.cmbTipoGrupo.ReadOnly = Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.chkAcumulador.ReadOnly = !Activo;
            
            
            this.slkupGrupoAcumulador.ReadOnly = !Activo;

            this.dtg.Enabled = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
            this.slkpTipoDeGrupo.Enabled = false;

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
            this.txtNivel1.Text = Row["Nivel1"].ToString();
            this.txtNivel2.Text = Row["Nivel2"].ToString();
            this.txtNivel3.Text = Row["Nivel3"].ToString();
            this.txtCentro.Text = Row["Grupo"].ToString();
            this.txtDescripcion.Text = Row["Descr"].ToString();
           
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);
            this.chkAcumulador.EditValue = Convert.ToBoolean(Row["Acumulador"]);
            this.slkupGrupoAcumulador.EditValue = Row["IDGrupoAcumulador"].ToString();
            this.slkpTipoDeGrupo.EditValue = Row["IDGrupoCuenta"].ToString();
            

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

            //Agregar  los consecutivos

            int iProximoConsecutivo = GrupoEstadosFinancierosDAC.GetNextConsecutivo(-1, 0, 0,GetTipoGrupo());
            //iProximoConsecutivo++;

            this.txtNivel3.Text = "0";
            this.txtNivel2.Text = "0";
            this.txtNivel1.Text = iProximoConsecutivo.ToString();

            this.slkpTipoDeGrupo.Enabled = true;
            
            this.chkAcumulador.Enabled = true;
            this.txtDescripcion.Focus();
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

            this.slkupGrupoAcumulador.ReadOnly = true;
            this.chkAcumulador.Enabled = false;
            this.slkpTipoDeGrupo.Enabled = false;

            //Validar si tiene hijos
            if ( this.txtNivel3.Text=="" || this.txtNivel3.Text=="0")
            {
                bool TieneHijo = DAC.GrupoEstadosFinancierosDAC.GrupoTieneHijos(Convert.ToInt32(currentRow["IDGrupo"]), GetTipoGrupo());
                if (TieneHijo)
                {
                    this.slkpTipoDeGrupo.Enabled = false;
                    this.chkAcumulador.Enabled = false;
                    //this.slkupGrupoAcumulador.ReadOnly = true;
                }
                else
                {
                    this.slkpTipoDeGrupo.Enabled = true;
                    this.chkAcumulador.Enabled = true;
                    //this.slkupGrupoAcumulador.ReadOnly = false;
                }
            }

            

            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
            this.txtDescripcion.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (this.txtNivel1.Text == "")
                sMensaje = sMensaje + "     • Nivel 1. \n\r";
            if (this.txtDescripcion.Text == "")
                sMensaje = sMensaje + "     • Descripción del Grupo. \n\r";
            if (this.txtNivel1.Text != "0" && this.txtNivel2.Text == "0" && this.txtNivel3.Text == "0") { 
                if (this.slkpTipoDeGrupo.EditValue==null)
                    sMensaje = sMensaje + "     • Seleccione el grupo al que pertenece el elemento. \n\r";
            }
            //if (Convert.ToBoolean(this.chkAcumulador.EditValue) == true)
            //    if (this.slkupCentroAcumulador.EditValue == null)
            //        sMensaje = sMensaje + "     • Centro Acumulador. \n\r";
            if (sMensaje != "")
            {
                result = false;
                MessageBox.Show("Por favor revise los siguientes campos, puede que sean obligatorios: \n\r\n\r" + sMensaje);
            }
            return result;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ValidarDatos
            if (!ValidarDatos())
                return;

            if (currentRow != null)
            {
                lblStatus.Caption = "Actualizando : " + currentRow["Descr"].ToString();

                Application.DoEvents();
                currentRow.BeginEdit();

                currentRow["Nivel1"] = (this.txtNivel1.Text == "") ? "0" : this.txtNivel1.Text;
                currentRow["Nivel2"] = (this.txtNivel2.Text == "") ? "0" : this.txtNivel2.Text;
                currentRow["Nivel3"] = (this.txtNivel3.Text == "") ? "0" : this.txtNivel3.Text;
                currentRow["Grupo"] = this.txtCentro.Text;
                currentRow["Descr"] = this.txtDescripcion.Text;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["Acumulador"] = this.chkAcumulador.EditValue;
                currentRow["Tipo"] = GetTipoGrupo();
                currentRow["IDGrupoAcumulador"] = (this.slkupGrupoAcumulador.EditValue!=null)?this.slkupGrupoAcumulador.EditValue:0;
                currentRow["IDGrupoCuenta"] = this.slkpTipoDeGrupo.EditValue;

                currentRow.EndEdit();

                DataSet _dsChanged = _dsGrupo.GetChanges(DataRowState.Modified);

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
                                msg = msg + dr["Grupo"].ToString();
                            }
                        }
                    }

                    lblStatus.Caption = msg;
                }

                //Si no hay errores

                if (okFlag)
                {
                    GrupoEstadosFinancierosDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                    Application.DoEvents();
                    isEdition = false;
                    _dsGrupo.AcceptChanges();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                }
                else
                {
                    _dsGrupo.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                currentRow = _dtGrupo.NewRow();

                currentRow["Nivel1"] = (this.txtNivel1.Text == "") ? "0" : this.txtNivel1.Text;
                currentRow["Nivel2"] = (this.txtNivel2.Text == "") ? "0" : this.txtNivel2.Text;
                currentRow["Nivel3"] = (this.txtNivel3.Text == "") ? "0" : this.txtNivel3.Text;
                currentRow["Grupo"] = this.txtCentro.Text;
                currentRow["Descr"] = this.txtDescripcion.Text;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["Tipo"] = GetTipoGrupo();
                currentRow["Acumulador"] = this.chkAcumulador.EditValue;
                currentRow["IDGrupoAcumulador"] = (this.slkupGrupoAcumulador.EditValue == null) ? 0 : this.slkupGrupoAcumulador.EditValue;
                currentRow["IDGrupoCuenta"] = this.slkpTipoDeGrupo.EditValue;

                _dtGrupo.Rows.Add(currentRow);
                try
                {
                    GrupoEstadosFinancierosDAC.oAdaptador.Update(_dsGrupo, "Data");
                    _dsGrupo.AcceptChanges();
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
                catch (System.Data.SqlClient.SqlException ex)
                {
                    _dsGrupo.RejectChanges();
                    currentRow = null;
                    MessageBox.Show(ex.Message);
                }
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

                //Validar que no se el id 0

                if (currentRow["IDGrupo"].ToString() == "0") {
                    MessageBox.Show("El elemento que desea eliminar es propio del sistema");
                    return;
                }
                
                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + currentRow["Descr"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    currentRow.Delete();

                    try
                    {

                        GrupoEstadosFinancierosDAC.oAdaptador.Update(_dsGrupo, "Data");
                        _dsGrupo.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsGrupo.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void chkAcumulador_CheckStateChanged(object sender, EventArgs e)
        {
            if ((bool)this.chkAcumulador.EditValue == true)
            {
                //this.slkupCentroAcumulador.Enabled = false;
                if (this.slkupGrupoAcumulador.EditValue == null || this.slkupGrupoAcumulador.EditValue.ToString() == "")
                {
                    DataView dv = new DataView();
                    dv.Table = _dtGrupo;
                    dv.RowFilter = string.Format("IDGrupo='{0}' ", 0);
                    DataTable dt = dv.ToTable();

                    bool EsAcumulador = Convert.ToBoolean((this.chkAcumulador.EditValue == null) ? false : this.chkAcumulador.EditValue);


                    int iProximoConsecutivo = GrupoEstadosFinancierosDAC.GetNextConsecutivo(-1, 0, 0,GetTipoGrupo());
                    //iProximoConsecutivo++;

                    this.txtNivel3.Text = "0";
                    this.txtNivel2.Text = "0";
                    this.txtNivel1.Text = iProximoConsecutivo.ToString();



                    //this.txtDescripcion.Text = "";

                }
            }
            //else
            //{
            //    this.slkupCentroAcumulador.Enabled = true;
              
            //}
        }

        //private void slkupCentroAnterior_EditValueChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (!isEdition)
        //            return;

        //        if (this.slkupCentroAnterior.EditValue != null && this.slkupCentroAnterior.EditValue.ToString() != "")
        //        {
        //            DataView dv = new DataView();
        //            dv.Table = _dtCentro;
        //            dv.RowFilter = "IDCentro='" + this.slkupCentroAnterior.EditValue.ToString() + "'";
        //            this.txtNivel1.Text = dv[0].Row["Nivel1"].ToString();

        //            DataTable dt = dv.ToTable();
        //            int i = -1;
        //            if (dt.Rows[0]["Nivel3"].ToString() != "0")
        //            {
        //                i = Convert.ToInt32(dt.Rows[0]["Nivel3"]);
        //                i++;
        //                this.txtNivel3.Text = i.ToString();
        //                this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();


        //            }
        //            else if (dt.Rows[0]["Nivel2"].ToString() != "0")
        //            {
        //                i = Convert.ToInt32(dt.Rows[0]["Nivel2"]);
        //                i++;
        //                this.txtNivel2.Text = i.ToString();
        //                this.txtNivel3.Text = "0";
        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        //private void slkupCentroAcumulador_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!isEdition)
        //            return;
        //        if (this.slkupGrupoAcumulador.EditValue != null && this.slkupGrupoAcumulador.EditValue.ToString() != "")
        //        {
        //            DataView dv = new DataView();
        //            dv.Table = _dtGrupo;
        //            dv.RowFilter = string.Format("IDGrupo='{0}' ", this.slkupGrupoAcumulador.EditValue);
        //            DataTable dt = dv.ToTable();

        //            bool EsAcumulador = Convert.ToBoolean((this.chkAcumulador.EditValue == null) ? false : this.chkAcumulador.EditValue);
                    
        //           if (dt.Rows[0]["Nivel2"].ToString() != "0")
        //            {
        //                int iProximoConsecutivo = GrupoEstadosFinancierosDAC.GetNextConsecutivo(Convert.ToInt32(dt.Rows[0]["Nivel1"]), Convert.ToInt32(dt.Rows[0]["Nivel2"]), -1);
                        
        //                //iProximoConsecutivo++;

        //                this.txtNivel3.Text = iProximoConsecutivo.ToString();
        //                this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();
        //                this.txtNivel1.Text = dt.Rows[0]["Nivel1"].ToString();
        //            }
        //            else if (dt.Rows[0]["Nivel1"].ToString() != "0")
        //            {
        //                int iProximoConsecutivo = GrupoEstadosFinancierosDAC.GetNextConsecutivo(Convert.ToInt32(dt.Rows[0]["Nivel1"]), -1, 0);
        //                //iProximoConsecutivo++;

        //                this.txtNivel3.Text = "0";
        //                this.txtNivel2.Text = iProximoConsecutivo.ToString();
        //                this.txtNivel1.Text = dt.Rows[0]["Nivel1"].ToString();
        //            }

        //           //Inactivar  los acumuladores
        //           if (this.txtNivel3.Text != "0")
        //               this.chkAcumulador.Enabled = false;
        //           else
        //               this.chkAcumulador.Enabled = true;

        //            this.txtDescripcion.Text = "";
        //            this.txtDescripcion.Focus();
                
        //        }
        //    } catch (Exception ex)
        //    {
        //    }
        //}

        private void cmbTipoGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

  
      
       
    }
}
