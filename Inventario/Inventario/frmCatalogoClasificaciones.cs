using CI.DAC;
using DevExpress.XtraGrid.Views.Base;
using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CI
{
    public partial class frmCatalogoClasificaciones : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtClasificaciones;
        private DataSet _dsClasificaciones;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Clasficaciones";
        private bool isEdition = false;

        public frmCatalogoClasificaciones()
        {
            InitializeComponent();
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Carga de Privilegios
        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, _sUsuario);
            _dtSecurity = DS.Tables[0];

            AplicarPrivilegios();
        }


        private void AplicarPrivilegios()
        {
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarCentroCosto, _dtSecurity))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarCentroCosto, _dtSecurity))
                this.btnEditar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCentroCosto, _dtSecurity))
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
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstClasificaciones.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado de Clasificaciones"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }



        private void frmCatalogoClasificaciones_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridClasificaciones, _tituloVentana, this);

                PopulateGrid();
                EnlazarEventos();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateData()
        {
                     //Cargar Grupo
            Util.Util.ConfigLookupEdit(this.slkupGrupo, clsGrupoClasificacionDAC.GetData(-1,"*").Tables[0], "Descr", "IDGrupo");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupGrupo, "[{'ColumnCaption':'IDGrupo','ColumnField':'IDGrupo','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");


        }

        private void PopulateGrid()
        {
            _dsClasificaciones = clsClasificacionDAC.GetData(-1,-1,"*");

            _dtClasificaciones = _dsClasificaciones.Tables[0];
            this.gridClasificaciones.DataSource = null;
            this.gridClasificaciones.DataSource = _dtClasificaciones;

            PopulateData();

        }

        private void ClearControls()
        {
            this.txtDescr.Text = "";
            this.chkActivo.Checked = true;
            this.slkupGrupo.EditValue = null;
        }


        private void HabilitarControles(bool Activo)
        {
            this.txtDescr.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.slkupGrupo.ReadOnly = !Activo;
            this.gridClasificaciones.Enabled = !Activo;
            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
            this.btnExportar.Enabled = !Activo;
            this.btnRefrescar.Enabled = !Activo;
        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridView1.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridView1.GetDataRow(index);
                UpdateControlsFromCurrentRow(currentRow);
            }
        }

        private void UpdateControlsFromCurrentRow(DataRow Row)
        {
            this.txtDescr.Text = Row["Descr"].ToString();
            this.chkActivo.Checked = Convert.ToBoolean( Row["Activo"]);
            this.slkupGrupo.EditValue = Row["IDGrupo"].ToString();
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


            this.txtDescr.Focus();
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


            //lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
            this.txtDescr.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento

            if (this.txtDescr.Text == "")
                sMensaje = sMensaje + "     • Descripción de la Clasificacion. \n\r";
            if (this.slkupGrupo.EditValue ==  null || this.slkupGrupo.EditValue.ToString()=="")
                sMensaje = sMensaje + "     • Grupo al que pertenece la Clasificación. \n\r";
            if (sMensaje != "")
            {
                result = false;
                MessageBox.Show("Por favor revise los siguientes campos, puede que sean obligatorios: \n\r\n\r" + sMensaje);
            }
            return result;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //ValidarDatos
                if (!ValidarDatos())
                    return;

                if (currentRow != null)
                {
                    lblStatus.Caption = "Actualizando : " + currentRow["Descr"].ToString();

                    Application.DoEvents();
                    currentRow.BeginEdit();

                    currentRow["Descr"] = this.txtDescr.Text;
                    currentRow["IDGrupo"] = this.slkupGrupo.EditValue;
                    currentRow["Activo"] = this.chkActivo.EditValue;
                    
                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsClasificaciones.GetChanges(DataRowState.Modified);

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
                        clsClasificacionDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsClasificaciones.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                        
                    }
                    else
                    {
                        _dsClasificaciones.RejectChanges();

                    }
                }
                else
                {
                    //nuevo registro
                    currentRow = _dtClasificaciones.NewRow();

                    currentRow["Descr"] = this.txtDescr.Text;
                    currentRow["IDGrupo"] = this.slkupGrupo.EditValue;
                    currentRow["Activo"] = this.chkActivo.EditValue;

                    _dtClasificaciones.Rows.Add(currentRow);
                    try
                    {
                        clsClasificacionDAC.oAdaptador.Update(_dsClasificaciones, "Data");
                        _dsClasificaciones.AcceptChanges();
                        isEdition = false;
                        lblStatus.Caption = "Se ha ingresado un nuevo registro";
                        Application.DoEvents();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                        ColumnView view = this.gridView1;
                        view.MoveLast();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsClasificaciones.RejectChanges();
                        currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _dsClasificaciones.RejectChanges();
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
                    currentRow.Delete();

                    try
                    {

                        clsClasificacionDAC.oAdaptador.Update(_dsClasificaciones, "Data");
                        _dsClasificaciones.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsClasificaciones.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGrupoClasificaciones ofrmGrupo = new frmGrupoClasificaciones();
            ofrmGrupo.ShowDialog();
        }

        

    }
}
