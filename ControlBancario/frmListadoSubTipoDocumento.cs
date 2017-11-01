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
using DevExpress.XtraGrid.Views.Base;

namespace ControlBancario
{
    public partial class frmListadoSubTipoDocumento : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private DataTable _dtSubTipoDocumento;
        private DataTable _lstTipoDocumento;
        private DataSet _dsSubTipoDocumento;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Tipos de SubTipo Documentos";
        private bool isEdition = false;

        
           public frmListadoSubTipoDocumento()
        {
            InitializeComponent();
               this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
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
            String FileName = System.IO.Path.Combine(tempPath, "lstListadoSubTipoDocumento.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado de Sub Tipo de Documento"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmListadoBanco_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridControl, _tituloVentana, this);

                EnlazarEventos();

                PopulateGrid();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void PopulateData()
        {
            _lstTipoDocumento = ControlBancario.DAC.TipoDocumentoDAC.GetData(-1).Tables["Data"];
            Util.Util.ConfigLookupEdit(this.slkupSubTipoDocumento, _lstTipoDocumento, "Descr", "IDTipo");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupSubTipoDocumento, "[{'ColumnCaption':'Tipo','ColumnField':'Tipo','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");


        }
 

        private void PopulateGrid()
        {
            _dsSubTipoDocumento =  BancoDAC.GetData(-1);

            _dtSubTipoDocumento = _dsSubTipoDocumento.Tables[0];
            this.gridControl.DataSource = null;
            this.gridControl.DataSource = _dtSubTipoDocumento;

            PopulateData();
           

        }


        private void ClearControls()
        {
            this.txtDescr.EditValue = "";
            this.chkActivo.EditValue = true;
            this.slkupSubTipoDocumento.EditValue =null;
            this.txtSubTipo.EditValue="";
            this.chkReadOnly.EditValue= null;
            this.txtConsecutivo.EditValue = "";
            
        }

        private void HabilitarControles(bool Activo)
        {
            //this.txtNivel1.ReadOnly = Activo;
            //this.txtNivel2.ReadOnly = Activo;
            //this.txtNivel3.ReadOnly = Activo;
            this.slkupSubTipoDocumento.ReadOnly = !Activo;
            this.txtSubTipo.ReadOnly = !Activo;
            this.chkReadOnly.ReadOnly = true;
            this.txtConsecutivo.ReadOnly = !Activo;
            this.txtDescr.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            

            this.gridControl.Enabled = !Activo;

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
            this.slkupSubTipoDocumento.EditValue = Row["IDSubTipo"].ToString();
            this.txtSubTipo.EditValue = Row["IDTipo"].ToString();
            this.txtDescr.Text = Row["Descr"].ToString();
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);
            this.chkReadOnly.EditValue = Convert.ToBoolean(Row["ReadOnlySys"]);
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);
            this.txtConsecutivo.EditValue = Row["Consecutivo"].ToString();
    
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
            
            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
            this.txtDescr.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (this.slkupSubTipoDocumento.EditValue == null || this.slkupSubTipoDocumento.EditValue == "")
                sMensaje = sMensaje + "     • SubTipoDocumento. \n\r";
            if (this.txtDescr.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Descripción. \n\r";
            if (this.txtConsecutivo.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Consecutivo. \n\r";
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

                currentRow["Descr"] = this.txtDescr.EditValue;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["IDTipo"] = this.slkupSubTipoDocumento.EditValue;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["Consecutivo"] = this.txtConsecutivo.EditValue;
                
                currentRow.EndEdit();

                DataSet _dsChanged = _dsSubTipoDocumento.GetChanges(DataRowState.Modified);

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
                                msg = msg + dr["IDTipo"].ToString();
                            }
                        }
                    }

                    lblStatus.Caption = msg;
                }

                //Si no hay errores

                if (okFlag)
                {
                    SubTipoDocumentoDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                    Application.DoEvents();
                    isEdition = false;
                    _dsSubTipoDocumento.AcceptChanges();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                }
                else
                {
                    _dsSubTipoDocumento.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                currentRow = _dtSubTipoDocumento.NewRow();

                currentRow["Descr"] = this.txtDescr.EditValue;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["IDTipo"] = this.slkupSubTipoDocumento.EditValue;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["Consecutivo"] = this.txtConsecutivo.EditValue;
                
                _dtSubTipoDocumento.Rows.Add(currentRow);
                try
                {
                    SubTipoDocumentoDAC.oAdaptador.Update(_dsSubTipoDocumento, "Data");
                    _dsSubTipoDocumento.AcceptChanges();
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
                    _dsSubTipoDocumento.RejectChanges();
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
                
                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + currentRow["Descr"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    currentRow.Delete();

                    try
                    {

                        SubTipoDocumentoDAC.oAdaptador.Update(_dsSubTipoDocumento, "Data");
                        _dsSubTipoDocumento.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsSubTipoDocumento.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

    }
}
