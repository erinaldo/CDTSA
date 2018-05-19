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
    public partial class frmLote : DevExpress.XtraBars.Ribbon.RibbonForm
    {
      


        private DataTable _dtLote;
        private DataSet _dsLote;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Lotes";
        private bool isEdition = false;

        public frmLote()
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
            String FileName = System.IO.Path.Combine(tempPath, "lstLotes.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado de Lotes"
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

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.dtgDetalle, _tituloVentana, this);

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
            
            Util.Util.ConfigLookupEdit(this.slkupProducto, clsProductoDAC.GetData(-1,"*","*",-1,-1,-1,-1,-1,-1,"*",-1,-1,-1).Tables[0], "Descr", "IDProducto");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupProducto, "[{'ColumnCaption':'IDProducto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            
        }

        private void PopulateGrid()
        {
            _dsLote = clsPaqueteDAC.GetData(-1, "*", "*", -1, "*", -1);

            _dtLote = _dsLote.Tables[0];
            this.dtgDetalle.DataSource = null;
            this.dtgDetalle.DataSource = _dtLote;

            PopulateData();

        }

        private void ClearControls()
        {
            this.txtLote.Text = "";
            this.txtLoteProveedor.Text = "";
            this.slkupProducto.EditValue = null;
            this.dtpFechaIngreso.EditValue = DateTime.Now;
            this.dtpFechaVence.EditValue = null;
            this.dtpFechaFabricacion.EditValue = null;
            
            
        }


        private void HabilitarControles(bool Activo)
        {
            this.txtLote.ReadOnly = !Activo;
            this.txtLoteProveedor.ReadOnly = !Activo;
            this.slkupProducto.ReadOnly = !Activo;
            this.dtpFechaFabricacion.ReadOnly = !Activo;
            this.dtpFechaIngreso.ReadOnly = !Activo;
            this.dtpFechaVence.ReadOnly = !Activo;
            this.dtgDetalle.Enabled = !Activo;
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
            this.txtLote.Text = Row["Lote"].ToString();
            this.txtLoteProveedor.Text = Row["LoteProveedor"].ToString();
            this.slkupProducto.EditValue = Row["IDProducto"].ToString();
            this.dtpFechaFabricacion.EditValue = Convert.ToDateTime( Row["FechaFabricacion"]);
            this.dtpFechaIngreso.EditValue = Convert.ToBoolean(Row["FechaIngreso"]);
            this.dtpFechaVence.EditValue = Convert.ToBoolean(Row["FechaVencimiento"]);
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


            this.txtLote.Focus();
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
            this.txtLote.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento

            if (this.txtLote.Text == "")
                sMensaje = sMensaje + "     • Lote del Producto. \n\r";
            if (this.txtLoteProveedor.Text == "")
                sMensaje = sMensaje + "     • Lote del Proveedor. \n\r";
            if (this.slkupProducto.EditValue ==null)
                sMensaje = sMensaje + "     • Articulo del Lote \n\r";
            if (this.dtpFechaFabricacion.EditValue == null)
                sMensaje = sMensaje + "     • Fecha de Fabricación. \n\r";
            if (this.dtpFechaIngreso.EditValue == null)
                sMensaje = sMensaje + "     • Fecha de Ingreso. \n\r";
            if (this.dtpFechaVence.EditValue == null)
                sMensaje = sMensaje + "     • Fecha de Vencimiento. \n\r";

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

                    currentRow["Lote"] = this.txtLote.Text;
                    currentRow["LoteProveedor"] = this.txtLoteProveedor.Text;
                    currentRow["IDArticulo"] = this.slkupProducto.EditValue;
                    currentRow["FechaFabricacion"] = this.dtpFechaFabricacion.EditValue;
                    currentRow["FechaIngreso"] = this.dtpFechaIngreso.EditValue;
                    currentRow["FechaVencimienot"] = this.dtpFechaVence.EditValue;

                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsLote.GetChanges(DataRowState.Modified);

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
                        clsLoteDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsLote.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsLote.RejectChanges();

                    }
                }
                else
                {
                    //nuevo registro
                    currentRow = _dtLote.NewRow();

                    currentRow["Lote"] = this.txtLote.Text;
                    currentRow["LoteProveedor"] = this.txtLoteProveedor.Text;
                    currentRow["IDArticulo"] = this.slkupProducto.EditValue;
                    currentRow["FechaFabricacion"] = this.dtpFechaFabricacion.EditValue;
                    currentRow["FechaIngreso"] = this.dtpFechaIngreso.EditValue;
                    currentRow["FechaVencimienot"] = this.dtpFechaVence.EditValue;

                    _dtLote.Rows.Add(currentRow);
                    try
                    {
                        clsLoteDAC.oAdaptador.Update(_dsLote, "Data");
                        _dsLote.AcceptChanges();
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
                        _dsLote.RejectChanges();
                        currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _dsLote.RejectChanges();
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

                        clsLoteDAC.oAdaptador.Update(_dsLote, "Data");
                        _dsLote.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsLote.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
