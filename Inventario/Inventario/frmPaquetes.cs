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
    public partial class frmPaquetes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtPaquete;
        private DataSet _dsPaquete;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Paquetes";
        private bool isEdition = false;

        public frmPaquetes()
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
            String FileName = System.IO.Path.Combine(tempPath, "lstPaquetes.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Paquetes"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmPaquetes_Load(object sender, EventArgs e)
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
            
            Util.Util.ConfigLookupEdit(this.slkpConsecutivo, clsGlobalConsecutivosDAC.GetData(-1,"*",1).Tables[0], "Descr", "IDConsecutivo");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkpConsecutivo, "[{'ColumnCaption':'Consecutivo','ColumnField':'IDConsecutivo','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupTipoTransaccion, clsGlobalTipoTransaccionDAC.Get(-1, "*", "*", "*").Tables[0], "Descr", "IDTipoTran",300,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoTransaccion, "[{'ColumnCaption':'ID Transacción','ColumnField':'IDTipoTran','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':50},{'ColumnCaption':'Naturaleza','ColumnField':'Naturaleza','width':20}]");

        }

        private void PopulateGrid()
        {
            _dsPaquete = clsPaqueteDAC.GetData(-1, "*", "*", -1, -1, -1);

            _dtPaquete = _dsPaquete.Tables[0];
            this.gridControl.DataSource = null;
            this.gridControl.DataSource = _dtPaquete;

            PopulateData();

        }

        private void ClearControls()
        {
            this.txtPaquete.Text = "";
            this.txtDescripcion.Text = "";
            this.slkpConsecutivo.EditValue = null;
            this.slkupTipoTransaccion.EditValue = null;
            this.chkActivo.EditValue = true;
            
        }


        private void HabilitarControles(bool Activo)
        {
            this.txtDescripcion.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.txtDescripcion.ReadOnly = !Activo;
            this.txtPaquete.ReadOnly = !Activo;
            this.slkpConsecutivo.ReadOnly = !Activo;
            this.slkpConsecutivo.ReadOnly = !Activo;
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
            this.txtPaquete.Text = Row["PAQUETE"].ToString();
            this.txtDescripcion.Text = Row["Descr"].ToString();
            this.slkpConsecutivo.EditValue = Row["IDConsecutivo"].ToString();
            this.slkupTipoTransaccion.EditValue = Row["IDTipoTran"].ToString();
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
            if (this.txtPaquete.Text == "")
                sMensaje = sMensaje + "     • Paquete. \n\r";
            if (this.slkpConsecutivo.EditValue ==null)
                sMensaje = sMensaje + "     • Consecutivo \n\r";
            if (this.slkupTipoTransaccion.EditValue == null)
                sMensaje = sMensaje + "     • Tipo Transacción. \n\r";

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
                    currentRow["Paquete"] = this.txtPaquete.Text;
                    currentRow["IDConsecutivo"] = this.slkpConsecutivo.EditValue;
                    currentRow["IDTipoTran"] = this.slkupTipoTransaccion.EditValue;
                    currentRow["Activo"] = this.chkActivo.EditValue;

                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsPaquete.GetChanges(DataRowState.Modified);

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
                                    msg = msg + dr["Paquete"].ToString();
                                }
                            }
                        }

                        lblStatus.Caption = msg;
                    }

                    //Si no hay errores

                    if (okFlag)
                    {
                        clsPaqueteDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsPaquete.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsPaquete.RejectChanges();

                    }
                }
                else
                {
                    //nuevo registro
                    currentRow = _dtPaquete.NewRow();

                    currentRow["Descr"] = this.txtDescripcion.Text;
                    currentRow["Paquete"] = this.txtPaquete.Text;
                    currentRow["IDConsecutivo"] = this.slkpConsecutivo.EditValue;
                    currentRow["IDTipoTran"] = this.slkupTipoTransaccion.EditValue;
                    currentRow["Activo"] = this.chkActivo.EditValue;

                    _dtPaquete.Rows.Add(currentRow);
                    try
                    {
                        clsPaqueteDAC.oAdaptador.Update(_dsPaquete, "Data");
                        _dsPaquete.AcceptChanges();
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
                        _dsPaquete.RejectChanges();
                        currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _dsPaquete.RejectChanges();
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

                        clsGlobalConsecutivosDAC.oAdaptador.Update(_dsPaquete, "Data");
                        _dsPaquete.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsPaquete.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        

    }
}