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

namespace CI.Fisico
{
    public partial class frmBoleta : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private DataTable _dtBoleta;
        private DataSet _dsBoleta;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Boletas de Inventario";
        private bool isEdition = false;

        public frmBoleta()
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
                this.btnGuardar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCentroCosto, _dtSecurity))
                this.btnEliminar.Enabled = false;
        }

        private void EnlazarEventos()
        {
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnEliminar.Click += btnEliminar_Click;

            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
          
        }


        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstBoletas.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado de Boletas"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }


        private void ClearControls()
        {
            this.slkupProducto.EditValue = null;
            //this.slkupBodega.EditValue = null;
            this.slkupLote.EditValue = "";
            

        }

        private void HabilitarControles(bool Activo)
        {
            this.slkupLote.ReadOnly = !Activo;
            this.slkupBodega.ReadOnly = !Activo;
            this.txtCantidad.ReadOnly = !Activo;
            this.slkupProducto.ReadOnly = !Activo;
            
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
            this.btnExportar.Enabled = !Activo;
            this.btnRefrescar.Enabled = !Activo;

        }
        

        private void frmBoleta_Load(object sender, EventArgs e)
        {
            try
            {
                //HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.dtgGrid, _tituloVentana, this);

                EnlazarEventos();

                Util.Util.ConfigLookupEdit(this.slkupBodega, clsBodegaDAC.GetData(-1,"*",1).Tables[0], "Descr", "IDBodega");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodega, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupProducto, clsProductoDAC.GetData(-1,"*","*",-1,-1,-1,-1,-1,-1,"*",-1,-1,-1).Tables[0], "Descr", "IDProducto");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupProducto, "[{'ColumnCaption':'IDProducto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupLote, clsLoteDAC.GetData(-1,-1,"*","*").Tables[0], "LoteProveedor", "IDLote");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupLote, "[{'ColumnCaption':'IDLote','ColumnField':'IDLote','width':30},{'ColumnCaption':'Lote Proveedor','ColumnField':'LoteProveedor','width':70}]");

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
            _dsBoleta = clsBoletaInvFisicoDAC.GetData(-1, -1,-1,Convert.ToDateTime("19810821"));

            _dtBoleta = _dsBoleta.Tables[0];
            this.dtgGrid.DataSource = null;
            this.dtgGrid.DataSource = _dtBoleta;
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
            this.slkupProducto.EditValue = Row["IDProducto"].ToString();
            this.slkupBodega.EditValue = Row["IDBodega"].ToString();
            this.slkupLote.EditValue = Row["IDLote"].ToString();
            
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


            this.slkupProducto.Focus();
        }


        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento

            if (this.slkupProducto.EditValue== null || this.slkupProducto.EditValue == "")
                sMensaje = sMensaje + "     • Producto. \n\r";
            if (this.slkupBodega.EditValue == null || this.slkupBodega.EditValue == "")
                sMensaje = sMensaje + "     • Bodega. \n\r";
            if (this.slkupLote.EditValue == null || this.slkupLote.EditValue == "")
                sMensaje = sMensaje + "     • Lote. \n\r";
            if (this.dtpFecha.EditValue == null || this.dtpFecha.EditValue == "")
                sMensaje = sMensaje + "     • Fecha. \n\r";
            if (this.txtCantidad.Text.Trim() == "")
                sMensaje = sMensaje + "     • Cantidad. \n\r";

            
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
                    lblStatus.Caption = "Actualizando : " + currentRow["IDProd"].ToString();

                    Application.DoEvents();
                    currentRow.BeginEdit();

                    currentRow["IDBodega"] = (this.slkupBodega.EditValue == null ? DBNull.Value : this.slkupBodega.EditValue);
                    currentRow["IDProduto"] = (this.slkupProducto.EditValue == null ? DBNull.Value : this.slkupProducto.EditValue);
                    currentRow["IDLote"] = (this.slkupLote.EditValue == null ? DBNull.Value : this.slkupLote.EditValue);
                    currentRow["Cantidad"] = this.txtCantidad.EditValue;
                    currentRow["Usuario"] = _sUsuario;
                    currentRow["Fecha"] = this.dtpFecha.EditValue;

                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsBoleta.GetChanges(DataRowState.Modified);

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
                        clsBodegaDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsBoleta.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsBoleta.RejectChanges();

                    }
                }
                else
                {
                    //nuevo registro
                    currentRow = _dtBoleta.NewRow();

                    currentRow["IDBodega"] = (this.slkupBodega.EditValue == null ? DBNull.Value : this.slkupBodega.EditValue);
                    currentRow["IDProduto"] = (this.slkupProducto.EditValue == null ? DBNull.Value : this.slkupProducto.EditValue);
                    currentRow["IDLote"] = (this.slkupLote.EditValue == null ? DBNull.Value : this.slkupLote.EditValue);
                    currentRow["Cantidad"] = this.txtCantidad.EditValue;
                    currentRow["Usuario"] = _sUsuario;
                    currentRow["Fecha"] = this.dtpFecha.EditValue;

                    _dtBoleta.Rows.Add(currentRow);
                    try
                    {
                        clsBodegaDAC.oAdaptador.Update(_dsBoleta, "Data");
                        _dsBoleta.AcceptChanges();
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
                        _dsBoleta.RejectChanges();
                        currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _dsBoleta.RejectChanges();
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

        private void slkupProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupProducto.EditValue != null)
            {
                Util.Util.ConfigLookupEdit(this.slkupLote, clsLoteDAC.GetData(-1, Convert.ToInt32(slkupProducto.EditValue), "*", "*").Tables[0], "LoteProveedor", "IDLote", 350);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupLote, "[{'ColumnCaption':'IDLote','ColumnField':'IDLote','width':20},{'ColumnCaption':'Lote','ColumnField':'LoteProveedor','width':60},{'ColumnCaption':'F.V','ColumnField':'FechaVencimiento','width':20}]");

                DataRowView dr = (DataRowView)slkupProducto.Properties.View.GetRow(slkupProducto.Properties.GetIndexByKeyValue(slkupProducto.EditValue));
                this.txtDescrProducto.Text = dr["Descr"].ToString();
                this.slkupLote.Enabled = true;
            }
            else
            {
                this.slkupLote.Enabled = false;
                this.txtDescrProducto.Text = "";
            }
        }

        private void slkupLote_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupLote.EditValue != null)
            {
                DataRowView dr = (DataRowView)slkupLote.Properties.View.GetRow(slkupLote.Properties.GetIndexByKeyValue(slkupLote.EditValue));
                this.txtLote.Text = dr["LoteProveedor"].ToString();
                this.txtFechaVence.Text = Convert.ToDateTime(dr["FechaVencimiento"]).ToShortDateString();
            }
            else
            {
                this.txtLote.Text = "";
                this.txtFechaVence.Text = "";
            }
        }
    }
}