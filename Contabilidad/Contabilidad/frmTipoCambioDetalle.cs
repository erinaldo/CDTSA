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
    public partial class frmTipoCambioDetalle : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String IDTipoCambio;
        private String Descr;
        private DataTable _dtSecurity;
        private DataSet _dsTipoCambioDetalle;
        private DataTable _dtTipoCambioDetalle;
        DataRow currentRow;
        bool isEdition;

        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Detalle de Tipos de Cambio";
        public frmTipoCambioDetalle(String IDTipoCambio, String Descr)
        {
            InitializeComponent();

            this.IDTipoCambio = IDTipoCambio;
            this.Descr = Descr;
            this.Load += FrmTipoCambioDetalle_Load;
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
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarAsientodeDiario, _dtSecurity))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarCuentaContable, _dtSecurity))
                this.btnEditar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCuentaContable, _dtSecurity))
                this.btnEliminar.Enabled = false;
        }


        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstTiposdeCambioDetalle.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Tipos Cambio Detalle"
            };


            this.gridView.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }



        private void PopulateGrid()
        {
            DateTime FechaInicial = Convert.ToDateTime(this.dtpFechaInicial.EditValue);
            DateTime FechaFinal = Convert.ToDateTime(this.dtpFechaFinal.EditValue);

            _dsTipoCambioDetalle = TipoCambioDetalleDAC.GetDetalleTipoCambioByID("*", FechaInicial, FechaFinal);

            _dtTipoCambioDetalle = _dsTipoCambioDetalle.Tables[0];
            this.grid.DataSource = null;
            this.grid.DataSource = _dtTipoCambioDetalle;


        }

        private void ClearControls()
        {
            this.dtpFecha.Text = "";
            this.txtMonto.Text = "";
        }

        private void HabilitarControles(bool Activo)
        {
            this.txtMonto.ReadOnly = !Activo;
            this.txtIDTipoCambio.ReadOnly = !Activo;

            this.grid.Enabled = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;

        }

        private void UpdateControlsFromCurrentRow(DataRow Row)
        {
            this.dtpFecha.Text = Row["Fecha"].ToString();
            this.txtMonto.Text = Row["Monto"].ToString();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
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

        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.Click += BtnRefrescar_Click;
            this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void FrmTipoCambioDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                this.dtpFechaInicial.EditValue = DateTime.Now.AddMonths(-1);
                this.dtpFechaFinal.EditValue = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1));
                this.txtIDTipoCambio.Text = this.IDTipoCambio + " " + this.Descr;
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

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                isEdition = true;
                HabilitarControles(true);
                ClearControls();
                this.dtpFecha.EditValue= TipoCambioDetalleDAC.GetNetFechaByIDTipoCambio(this.IDTipoCambio);

                currentRow = null;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentRow == null && this.gridView.SelectedRowsCount>0)
            {
                lblStatus.Caption = "Por favor seleccione un elemento de la Lista";
                return;
            }
            else
                lblStatus.Caption = "";
            isEdition = true;
            HabilitarControles(true);
            this.dtpFecha.ReadOnly = true;
            //lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
        }


        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (this.dtpFecha.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Fecha del Tipo de Cambio  \n\r";
            if (this.txtMonto.Text == "")
                sMensaje = sMensaje + "     • El monto del Tipo de Cambio. \n\r";
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
                lblStatus.Caption = "Actualizando tipo de cambio para la fecha : " + currentRow["Fecha"].ToString();

                Application.DoEvents();
                currentRow.BeginEdit();

                currentRow["IDTipoCambio"] = this.IDTipoCambio;
                currentRow["Fecha"] = this.dtpFecha.EditValue;
                currentRow["Monto"] = this.txtMonto.Value;

                currentRow.EndEdit();

                DataSet _dsChanged = _dsTipoCambioDetalle.GetChanges(DataRowState.Modified);

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
                    TipoCambioDetalleDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado Tipo de cambio para la fecha " + currentRow["Fecha"].ToString();
                    Application.DoEvents();
                    isEdition = false;
                    _dsTipoCambioDetalle.AcceptChanges();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                    this.ribbonPageGroup1.ItemLinks[0].Focus();

                }
                else
                {
                    _dsTipoCambioDetalle.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                currentRow = _dtTipoCambioDetalle.NewRow();

                currentRow["IDTipoCambio"] = this.IDTipoCambio;
                currentRow["Fecha"] = this.dtpFecha.EditValue;
                currentRow["Monto"] = this.txtMonto.Value;
                _dtTipoCambioDetalle.Rows.Add(currentRow);
                try
                {
                    TipoCambioDetalleDAC.oAdaptador.Update(_dsTipoCambioDetalle, "Data");
                    _dsTipoCambioDetalle.AcceptChanges();
                    isEdition = false;
                    lblStatus.Caption = "Se ha ingresado un nuevo registro";
                    Application.DoEvents();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                    ColumnView view = this.gridView;
                    view.MoveLast();
                    this.ribbonPageGroup1.ItemLinks[0].Focus();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    _dsTipoCambioDetalle.RejectChanges();
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
                string msg = currentRow["Fecha"] + " eliminado..";

                if (MessageBox.Show("Esta seguro que desea eliminar el tipo de cambio para la fecha de  " + currentRow["Fecha"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {


                    currentRow.Delete();

                    try
                    {

                        TipoCambioDetalleDAC.oAdaptador.Update(_dsTipoCambioDetalle, "Data");
                        _dsTipoCambioDetalle.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsTipoCambioDetalle.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void txtMonto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ribbonPageGroup1.ItemLinks[2].Focus();
                
            }
        }
    }
}