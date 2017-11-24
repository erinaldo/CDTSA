using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Security;
using ControlBancario.DAC;
using DevExpress.XtraGrid.Views.Base;


namespace ControlBancario
{
    public partial class frmRUC : DevExpress.XtraBars.Ribbon.RibbonForm
    {
   

        private DataTable _dtNIT;
        
        private DataSet _dsNIT;
        private DataTable _dtCuentaContable;
        private DataTable _dtTipoNit;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de NIT";
        private bool isEdition = false;


        public frmRUC()
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
            String FileName = System.IO.Path.Combine(tempPath, "lstListadoDeNIT.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado de NIT"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmNIT_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);
                _dtCuentaContable = CG.CuentaContableDAC.GetData(-1, -1, -1,"*","*","*","*","*","*","*",-1,-1,-1,-1,-1,-1).Tables["Data"];
                _dtTipoNit = DAC.TipoRucDAC.GetTipoRuc(-1).Tables[0];

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridRuc, _tituloVentana, this);

                
                Util.Util.ConfigLookupEdit(this.slkupTipoRuc, _dtTipoNit, "Descr", "IDTipoRuc");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoRuc, "[{'ColumnCaption':'Tipo','ColumnField':'IDTipoRuc','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                EnlazarEventos();

                PopulateGrid();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


 

        private void PopulateGrid()
        {
            _dsNIT = RucDAC.GetData(-1);

            _dtNIT = _dsNIT.Tables[0];
            this.gridRuc.DataSource = null;
            this.gridRuc.DataSource = _dtNIT;

           

        }


        private void ClearControls()
        {
            this.txtRuc.EditValue = "";
            this.txtNombre.EditValue = "";
            this.txtAlias.EditValue = "";
            this.chkActivo.EditValue = true;
            this.slkupTipoRuc.EditValue = DBNull.Value;
        }

        private void HabilitarControles(bool Activo)
        {
            this.txtRuc.ReadOnly = !Activo;
            this.txtAlias.ReadOnly = !Activo;
            this.txtNombre.ReadOnly = !Activo;
            this.slkupTipoRuc.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            

            this.gridRuc.Enabled = !Activo;

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
            this.txtRuc.EditValue = Row["RUC"].ToString();
            this.txtNombre.EditValue = Row["Nombre"].ToString();
            this.txtAlias.EditValue = Row["Alias"].ToString();
            this.slkupTipoRuc.EditValue = Convert.ToInt32(Row["IDTipoRuc"]);
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
            this.txtRuc.Focus();
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
            this.txtRuc.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (this.txtRuc.Text == "")
                sMensaje = sMensaje + "     • RUC. \n\r";
            if (this.txtNombre.Text == "")
                sMensaje = sMensaje + "     • Nombre. \n\r";
            if (this.txtAlias.Text == "")
                sMensaje = sMensaje + "     • Alias. \n\r";
            if (this.slkupTipoRuc.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Tipo Ruc. \n\r";
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

                currentRow["RUC"] = this.txtRuc.EditValue;
                currentRow["Nombre"] = this.txtNombre.EditValue; 
                currentRow["Alias"] = this.txtAlias.EditValue;
                currentRow["IDTipoRuc"] = this.slkupTipoRuc.EditValue;
                currentRow["Activo"] = this.chkActivo.EditValue;
                
                currentRow.EndEdit();

                DataSet _dsChanged = _dsNIT.GetChanges(DataRowState.Modified);

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
                                msg = msg + dr["IDRuc"].ToString();
                            }
                        }
                    }

                    lblStatus.Caption = msg;
                }

                //Si no hay errores

                if (okFlag)
                {
                    RucDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado " + currentRow["Nombre"].ToString();
                    Application.DoEvents();
                    isEdition = false;
                    _dsNIT.AcceptChanges();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                }
                else
                {
                    _dsNIT.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                currentRow = _dtNIT.NewRow();

                currentRow["RUC"] = this.txtRuc.EditValue;
                currentRow["Nombre"] = this.txtNombre.EditValue;
                currentRow["Alias"] = this.txtAlias.EditValue;
                currentRow["IDTipoRuc"] = this.slkupTipoRuc.EditValue;
                currentRow["Activo"] = this.chkActivo.EditValue;

                _dtNIT.Rows.Add(currentRow);
                try
                {
                    RucDAC.oAdaptador.Update(_dsNIT, "Data");
                    _dsNIT.AcceptChanges();
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
                    _dsNIT.RejectChanges();
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

                        BancoDAC.oAdaptador.Update(_dsNIT, "Data");
                        _dsNIT.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsNIT.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

    
   
      
    }
}
