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
using Security;
using CI.DAC;
using DevExpress.XtraGrid.Views.Base;

namespace CI
{
    public partial class frmConsecutivos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
   

        private DataTable _dtConsecutivo;
        private DataSet _dsConsecutivos;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count>0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Consecutivos";
        private bool isEdition = false;


        public frmConsecutivos()
        {
            InitializeComponent();
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += frmConsecutivos_Load;
        }

        void frmConsecutivos_Load(object sender, EventArgs e)
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

        
        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DS = UsuarioDAC.GetAccionModuloFromRole(0,_sUsuario );
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
            String FileName = System.IO.Path.Combine(tempPath, "lstCconsecutivos.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Cconsecutivos"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

 

        
        private void PopulateGrid()
        {
            _dsConsecutivos = clsGlobalConsecutivosDAC.GetData(-1,"*",-1);

            _dtConsecutivo = _dsConsecutivos.Tables[0];
            this.gridControl.DataSource = null;
            this.gridControl.DataSource = _dtConsecutivo;


        }

        private void ClearControls()
        {
            this.txtDescripcion.Text = "";
            this.txtPRefijo.Text = "";
            this.txtConsecutivo.Text = "";
            this.txtDocumento.Text = "";
            this.chkActivo.EditValue = true;
        }

        private void HabilitarControles(bool Activo)
        {
            this.txtDescripcion.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.txtDescripcion.ReadOnly = !Activo;
            this.txtPRefijo.ReadOnly = !Activo; 
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
            this.txtConsecutivo.Text = Row["Consecutivo"].ToString();
            this.txtDescripcion.Text = Row["Descr"].ToString();
            this.txtDocumento.Text = Row["Documento"].ToString();
            this.txtPRefijo.Text = Row["Prefijo"].ToString();
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);
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
            this.txtConsecutivo.Text = "1";


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
           

            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
            this.txtDescripcion.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            
            if (this.txtDescripcion.Text == "")
                sMensaje = sMensaje + "     • Descripción del Consecutivo. \n\r";
            if (this.txtPRefijo.Text == "")
                sMensaje = sMensaje + "     • Prefijo. \n\r";
            if (this.txtPRefijo.Text.Trim().Length != 3)
                sMensaje = sMensaje + "     • La longitud del prefijo debe ser igual a 3";
            
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

                    currentRow["Descr"] = this.txtDescripcion.Text;
                    currentRow["Prefijo"] = this.txtPRefijo.Text;
                    currentRow["Consecutivo"] = this.txtConsecutivo.Text;
                    currentRow["Documento"] = this.txtDocumento.Text;
                    currentRow["Activo"] = this.chkActivo.EditValue;
                    
                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsConsecutivos.GetChanges(DataRowState.Modified);

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
                        clsGlobalConsecutivosDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsConsecutivos.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsConsecutivos.RejectChanges();

                    }
                }
                else
                {
                    //nuevo registro
                    currentRow = _dtConsecutivo.NewRow();

                    currentRow["Descr"] = this.txtDescripcion.Text;
                    currentRow["Prefijo"] = this.txtPRefijo.Text;
                    currentRow["Consecutivo"] = this.txtConsecutivo.Text;
                    currentRow["Documento"] = this.txtDocumento.Text;
                    currentRow["Activo"] = this.chkActivo.EditValue;
                    
                    _dtConsecutivo.Rows.Add(currentRow);
                    try
                    {
                        clsGlobalConsecutivosDAC.oAdaptador.Update(_dsConsecutivos, "Data");
                        _dsConsecutivos.AcceptChanges();
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
                        _dsConsecutivos.RejectChanges();
                        currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex) {
                _dsConsecutivos.RejectChanges();
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

                        clsGlobalConsecutivosDAC.oAdaptador.Update(_dsConsecutivos, "Data");
                        _dsConsecutivos.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsConsecutivos.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void txtPRefijo_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtPRefijo.Text.Trim() != "" && this.txtConsecutivo.Text.Trim() !="") {
                String sDocumento = this.txtPRefijo.Text.Trim() + this.txtConsecutivo.Text.Trim().PadLeft(8, '0');
                this.txtDocumento.Text = sDocumento;
            }
        }

     
        


      
    }
}