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
using DevExpress.XtraGrid.Views.Base;

namespace CG
{
    public partial class frmListadoTipoCambio : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataSet _dsTipoCambio;
        private DataTable _dtSecurity;
        private DataTable _dtTipoCambio;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Tipos de Cambio";
        private bool isEdition = false;

        public frmListadoTipoCambio()
        {
            InitializeComponent();
            this.Load += FrmListadoTipoCambio_Load;
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
            this.btnDetalleTipoCambio.ItemClick += BtnDetalleTipoCambio_ItemClick;
            this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private void BtnDetalleTipoCambio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Validar que exista un elemento selecionado.
            if (currentRow != null)
            {
                frmTipoCambioDetalle ofrmTipoDetalle = new frmTipoCambioDetalle(currentRow["IDTipoCambio"].ToString(), currentRow["Descr"].ToString());
                ofrmTipoDetalle.ShowDialog();
            }
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstTiposdeCambio.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Tipos Cambio"
            };


            this.gridView.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void FrmListadoTipoCambio_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.grid, _tituloVentana, this);

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
            
        }

        private void PopulateGrid()
        {
            _dsTipoCambio = TipoCambioDAC.GetData("*");

            _dtTipoCambio = _dsTipoCambio.Tables[0];
            this.grid.DataSource = null;
            this.grid.DataSource = _dtTipoCambio;
            //this.gridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
           // gridView.ClearSelection();
            //this.gridView.UnselectRow(0);

        }

        private void ClearControls()
        {
            this.txtDescr.Text = "";
            this.txtIDTipoCambio.Text = "";
        }

        private void HabilitarControles(bool Activo)
        {
            this.txtDescr.ReadOnly = !Activo;
            this.txtIDTipoCambio.ReadOnly = !Activo;
            
            this.grid.Enabled = !Activo;

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
            this.txtIDTipoCambio.Text = Row["IDTipoCambio"].ToString();
            this.txtDescr.Text = Row["Descr"].ToString();
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
            this.txtIDTipoCambio.ReadOnly = true;
            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (this.txtIDTipoCambio.Text == "")
                sMensaje = sMensaje + "     • ID TipoCambio  \n\r";
            if (this.txtDescr.Text == "")
                sMensaje = sMensaje + "     • Descripción del Tipo de Cambio. \n\r";
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

                currentRow["IDTipoCambio"] = this.txtIDTipoCambio.Text ;
                currentRow["Descr"] = this.txtDescr.Text;
                
                currentRow.EndEdit();

                DataSet _dsChanged = _dsTipoCambio.GetChanges(DataRowState.Modified);

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
                                msg = msg + dr["IDTipoCambio"].ToString();
                            }
                        }
                    }

                    lblStatus.Caption = msg;
                }

                //Si no hay errores

                if (okFlag)
                {
                    TipoCambioDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                    Application.DoEvents();
                    isEdition = false;
                    _dsTipoCambio.AcceptChanges();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                }
                else
                {
                    _dsTipoCambio.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                currentRow = _dtTipoCambio.NewRow();

                currentRow["IDTipoCambio"] = this.txtIDTipoCambio.Text;
                currentRow["Descr"] = this.txtDescr.Text;
                _dtTipoCambio.Rows.Add(currentRow);
                try
                {
                    TipoCambioDAC.oAdaptador.Update(_dsTipoCambio, "Data");
                    _dsTipoCambio.AcceptChanges();
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
                    _dsTipoCambio.RejectChanges();
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

                    if (TipoCambioDAC.ExisteTipoCambioInDetalle(currentRow["IDTipoCambio"].ToString())){
                        MessageBox.Show("El tipo de cambio que desea eliminar tiene detalle asociados por favor verifique");
                        return;
                    }

                    currentRow.Delete();

                    try
                    {

                        TipoCambioDAC.oAdaptador.Update(_dsTipoCambio, "Data");
                        _dsTipoCambio.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsTipoCambio.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


    }
}