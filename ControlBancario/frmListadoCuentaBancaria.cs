using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Security;
using ControlBancario.DAC;
using DevExpress.XtraGrid.Views.Base;
using CG.DAC;

namespace ControlBancario
{
    public partial class frmListadoCuentaBancaria : DevExpress.XtraBars.Ribbon.RibbonForm
    {




        private DataTable _dtCuenta;
        private DataTable _dtBanco;
        private DataTable _dtTipo;
        private DataTable _dtMoneda;
        private DataSet _dsCuenta;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Cuentas Bancarias";
        


        public frmListadoCuentaBancaria()
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
            String FileName = System.IO.Path.Combine(tempPath, "lstListadoCuentaBancaria.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado de Cuenta Bancaria"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmListadoCuentaBancaria_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);
                
                _dtTipo = TipoCuentaDAC.GetData(-1).Tables["Data"];
                _dtBanco = BancoDAC.GetData(-1).Tables["Data"];
                _dtCuenta = CG.CuentaContableDAC.GetData(-1,-1, -1,"*","*","*","*","*","*","*",-1,-1,-1,1,-1,-1).Tables["Data"];
                _dtMoneda = MonedaDAC.GetMoneda(-1).Tables[0];
                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridCuenta, _tituloVentana, this);

                Util.Util.ConfigLookupEdit(this.slkupBanco, _dtBanco, "Descr", "IDBanco");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupBanco, "[{'ColumnCaption':'Codigo','ColumnField':'Codigo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupTipo, _dtTipo, "Descr", "IDTipo");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipo, "[{'ColumnCaption':'Codigo','ColumnField':'IDTipo','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentaContable, _dtCuenta, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaContable, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupMoneda, _dtMoneda, "Descr", "IDMoneda");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupMoneda, "[{'ColumnCaption':'Moneda','ColumnField':'IDMoneda','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

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
            _dsCuenta = CuentaBancariaDAC.GetData(-1, -1);

            _dtCuenta = _dsCuenta.Tables[0];
            this.gridCuenta.DataSource = null;
            this.gridCuenta.DataSource = _dtCuenta;



        }


        private void ClearControls()
        {
            //Pendiente
            this.txtCodigo.EditValue = "";
            this.txtDescr.EditValue = "";
            this.slkupBanco.EditValue = DBNull.Value;
            this.slkupMoneda.EditValue = DBNull.Value;
            this.slkupTipo.EditValue = DBNull.Value;
            this.slkupCuentaContable.EditValue = DBNull.Value;
            this.chkActivo.EditValue = true;
            this.txtLimite.EditValue = DBNull.Value;



        }

        private void HabilitarControles(bool Activo)
        {
            this.txtDescr.ReadOnly = !Activo;
            this.slkupBanco.ReadOnly = !Activo;
            this.slkupCuentaContable.ReadOnly = !Activo;
            this.slkupMoneda.ReadOnly = !Activo;
            this.slkupTipo.ReadOnly = !Activo;
            this.txtLimite.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.txtCodigo.ReadOnly = !Activo;

            this.gridCuenta.Enabled = !Activo;

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
            //Pendiente
            this.txtCodigo.Text = Row["Codigo"].ToString();
            this.txtDescr.Text = Row["Descr"].ToString();
            this.slkupBanco.EditValue = Convert.ToInt32(Row["IDBanco"]);
            this.slkupCuentaContable.EditValue = Convert.ToInt32(Row["IDCuenta"]);
            this.slkupMoneda.EditValue = Convert.ToInt32(Row["IDMoneda"]);
            this.slkupTipo.EditValue = Convert.ToInt32(Row["IDTipo"]);
            this.txtLimite.EditValue = Convert.ToDecimal(Row["Limite"]);
            this.txtSaldoBancos.EditValue = Convert.ToDecimal(Row["SaldoBanco"]);
            this.txtSaldoLibros.EditValue = Convert.ToDecimal(Row["SaldoLibro"]);
            this.txtUltDeposito.EditValue = Convert.ToDecimal(Row["UltDeposito"]);
            this.txtUltimoCheque.EditValue = Convert.ToDecimal(Row["UltCheque"]);
            this.txtUltTransferencia.EditValue = Convert.ToDecimal(Row["UltTransferencia"]);
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activa"]);
            this.dtFechaCreacion.EditValue = Convert.ToDateTime(Row["FechaCreacion"]);


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }


        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            HabilitarControles(true);
            ClearControls();
            currentRow = null;
            this.txtCodigo.Focus();
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

            
            HabilitarControles(true);

            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
            this.txtCodigo.Focus();
        }

        private bool ValidarDatos()
        {
            //Pendiente
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (this.txtCodigo.Text == "")
                sMensaje = sMensaje + "     • Código. \n\r";
            if (this.txtDescr.Text == "")
                sMensaje = sMensaje + "     • Descripción. \n\r";
            if (this.slkupBanco.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Banco \n\r";
            if (this.slkupCuentaContable.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Cuenta Contable \n\r";
            if (this.slkupMoneda.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Moneda \n\r";
            if (this.slkupTipo.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Tipo Cuenta \n\r";
            if (this.txtLimite.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Límite de la Cuenta \n\r";
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
            //Pendiente
            //ValidarDatos
            if (!ValidarDatos())
                return;

            if (currentRow != null)
            {
                lblStatus.Caption = "Actualizando : " + currentRow["Descr"].ToString();

                Application.DoEvents();
                currentRow.BeginEdit();
                
                currentRow["Descr"] = this.txtDescr.EditValue;
                currentRow["Codigo"] = this.txtCodigo.EditValue;
                currentRow["IDBanco"] = this.slkupBanco.EditValue;
                currentRow["IDMoneda"] = this.slkupMoneda.EditValue;
                currentRow["FechaCreacion"] = this.dtFechaCreacion.EditValue;
                currentRow["IDTipo"] = this.slkupTipo.EditValue;
                currentRow["Limite"] = this.txtLimite.EditValue;
                currentRow["IDCuenta"] = this.slkupCuentaContable.EditValue;
                currentRow["Activa"] = this.chkActivo.EditValue;

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
                                msg = msg + dr["IDCuentaBanco"].ToString();
                            }
                        }
                    }

                    lblStatus.Caption = msg;
                }

                //Si no hay errores

                if (okFlag)
                {
                    CuentaBancariaDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                    Application.DoEvents();
                    
                    _dsCuenta.AcceptChanges();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
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


                currentRow["Descr"] = this.txtDescr.EditValue;
                currentRow["Codigo"] = this.txtCodigo.EditValue;
                currentRow["IDBanco"] = this.slkupBanco.EditValue;
                currentRow["IDMoneda"] = this.slkupMoneda.EditValue;
                currentRow["FechaCreacion"] = this.dtFechaCreacion.EditValue;
                currentRow["IDTipo"] = this.slkupTipo.EditValue;
                currentRow["Limite"] = this.txtLimite.EditValue;
                currentRow["IDCuenta"] = this.slkupCuentaContable.EditValue;
                currentRow["Activa"] = this.chkActivo.EditValue;

                _dtCuenta.Rows.Add(currentRow);
                try
                {
                    CuentaBancariaDAC.oAdaptador.Update(_dsCuenta, "Data");
                    _dsCuenta.AcceptChanges();
                    
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
                    _dsCuenta.RejectChanges();
                    currentRow = null;
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
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

                        CuentaBancariaDAC.oAdaptador.Update(_dsCuenta, "Data");
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

    

    }
       

}
