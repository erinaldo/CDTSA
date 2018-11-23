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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;

namespace CI.Fisico
{
    public partial class frmBoleta : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private DataTable _dtBoleta;
        private DataSet _dsBoleta;
        private DataTable _dtSecurity;

        List<DataRowView> SelectedValidate = new List<DataRowView>();
       

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Boletas de Inventario";
        private bool isEdition = false;
        private int Validada = -1;

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
            if (currentRow != null)
            {
                string msg = currentRow["IDProducto"] + " eliminado..";


                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + currentRow["IDProducto"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    currentRow.Delete();

                    try
                    {

                        clsBoletaInvFisicoDAC.oAdaptador.Update(_dsBoleta, "Data");
                        _dsBoleta.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsBoleta.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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
            this.txtCantidad.EditValue = 0;
            this.txtLote.Text = "";
            this.txtFechaVence.Text = "";
            //this.slkupBodega.EditValue = null;
            this.slkupLote.EditValue = null;
            

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

                this.dtpFecha.EditValue = DateTime.Now;

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
            _dsBoleta = clsBoletaInvFisicoDAC.GetData(-1, -1, -1, Validada, Convert.ToDateTime("1981/08/21"));

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
                //
            }
        }


        private void UpdateControlsFromCurrentRow(DataRow Row)
        {
            this.slkupBodega.EditValue = Row["IDBodega"].ToString();
            this.slkupProducto.EditValue = Row["IDProducto"].ToString();
            this.slkupLote.EditValue = Row["IDLote"].ToString();
            this.dtpFecha.EditValue = currentRow["Fecha"];
            this.txtCantidad.EditValue = currentRow["Cantidad"];

            searchLookUpEdit2View.GridControl.ForceInitialize();
            searchLookUpEdit2View.GridControl.BindingContext = new BindingContext();

            searchLookUpEdit3View.GridControl.ForceInitialize();
            searchLookUpEdit3View.GridControl.BindingContext = new BindingContext();
            
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = true;
            
            


            this.slkupProducto.Focus();
        }


        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento

            if (this.slkupProducto.EditValue== null || this.slkupProducto.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Producto. \n\r";
            if (this.slkupBodega.EditValue == null || this.slkupBodega.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Bodega. \n\r";
            if (this.slkupLote.EditValue == null || this.slkupLote.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Lote. \n\r";
            if (this.dtpFecha.EditValue == null || this.dtpFecha.EditValue.ToString() == "")
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


        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = false;
            
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
                
                //DataRowView dr = (DataRowView)slkupProducto.Properties.View.GetRow(slkupProducto.Properties.GetIndexByKeyValue(slkupProducto.EditValue));
                DataRowView dr = (DataRowView)slkupProducto.Properties.GetRowByKeyValue(this.slkupProducto.EditValue);
                this.txtDescrProducto.Text = dr["Descr"].ToString();
                this.slkupLote.Enabled = true;
                this.slkupLote.Focus();
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
                //DataRowView dr = (DataRowView)slkupLote.Properties.View.GetRow(slkupLote.Properties.GetIndexByKeyValue(slkupLote.EditValue));
                DataRowView dr = (DataRowView)slkupLote.Properties.GetRowByKeyValue(slkupLote.EditValue);
                this.txtLote.Text = dr["LoteProveedor"].ToString();
                this.txtFechaVence.Text = Convert.ToDateTime(dr["FechaVencimiento"]).ToShortDateString();
                this.txtCantidad.Focus();
            }
            else
            {
                this.txtLote.Text = "";
                this.txtFechaVence.Text = "";
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //ValidarDatos
                if (!ValidarDatos())
                    return;

                if (currentRow != null && isEdition)
                {
                    lblStatus.Caption = "Actualizando : " + currentRow["IDProducto"].ToString();

                    Application.DoEvents();
                    currentRow.BeginEdit();

                    currentRow["IDBodega"] = (this.slkupBodega.EditValue == null ? DBNull.Value : this.slkupBodega.EditValue);
                    currentRow["IDProducto"] = (this.slkupProducto.EditValue == null ? DBNull.Value : this.slkupProducto.EditValue);
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
                        clsBoletaInvFisicoDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["IDProducto"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsBoleta.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                       
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
                    currentRow["IDProducto"] = (this.slkupProducto.EditValue == null ? DBNull.Value : this.slkupProducto.EditValue);
                    currentRow["IDLote"] = (this.slkupLote.EditValue == null ? DBNull.Value : this.slkupLote.EditValue);
                    currentRow["Cantidad"] = this.txtCantidad.EditValue;
                    currentRow["Validada"] = false;
                    currentRow["Usuario"] = _sUsuario;
                    currentRow["Fecha"] = this.dtpFecha.EditValue;

                    _dtBoleta.Rows.Add(currentRow);
                    try
                    {
                        clsBoletaInvFisicoDAC.oAdaptador.Update(_dsBoleta, "Data");
                        _dsBoleta.AcceptChanges();
                        isEdition = false;
                        lblStatus.Caption = "Se ha ingresado un nuevo registro";
                        Application.DoEvents();
                        PopulateGrid();
                        SetCurrentRow();
                       
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


                ClearControls();
                currentRow = null;
                this.btnEditar.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.slkupProducto.Focus();
            }
            catch (Exception ex)
            {
                _dsBoleta.RejectChanges();
                currentRow = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (currentRow != null) {
                isEdition = true;
                UpdateControlsFromCurrentRow(currentRow);
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnGuardar.Enabled = true;
            }
        }

        private void btnCancelDet_Click(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnCancelar.Enabled = false;
            this.btnGuardar.Enabled = true;
        }

        private void slkup_Properties_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            SearchLookUpEdit edito = (SearchLookUpEdit)sender;
            edito.ShowPopup();  
        }

        private void slkup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchLookUpEdit control = (SearchLookUpEdit)sender;
                control.ShowPopup();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnGuardar.Focus();
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            if (e.Column.FieldName.ToUpper() == "VALIDADA")
            {
                // TODO: conwes 2016-04-25
                // Räkna om moms
                DataRow DR = (DataRow)this.gridView1.GetDataRow(e.RowHandle);
                // LevFaktRad shRow = (LevFaktRad)e.;
                // e.RepositoryItem = RULF_AvgiftRow_Combobox_DCT[shRow.ProduktGUID];
                if ((bool)DR["Validada"] == true) { 
                
                }
               
            }
        }


        private void setItemSelected()
        {
           
               
               // List<int> selection = new List<int>();
                //foreach (DataRowView val in SelectedValidate)
                //{
                    for (int i = 0; i < this.gridView1.RowCount; i++)
                    {
                        DataRowView ele = (DataRowView)gridView1.GetRow(i);
                        if (Convert.ToBoolean(((ele["Validada"]== DBNull.Value) ? false :ele["Validada"]) )==true)
                        {
                         
                            gridView1.SelectRow(i);
                        }
                    }
               // }
               
        }

        private void togleValidacionBoleta_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.togleValidacionBoleta.Checked == true )
            {
                this.gridView1.OptionsSelection.MultiSelect = true;
                this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                this.togleAplicacion.Enabled = false;
                this.btnAplicar.Enabled = false;
                this.btnValidar.Enabled = true;
                setItemSelected();
                //Cargar todas aquellas boletas que esten validadas

            }
            else {
                this.gridView1.OptionsSelection.MultiSelect = false;
                this.togleAplicacion.Enabled = true;
                this.btnAplicar.Enabled = false;
                this.btnValidar.Enabled = false;
                this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            }
        }

        private void togleAplicacion_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.togleAplicacion.Checked == true &&  this.togleValidacionBoleta.Checked==false)
            {
                //this.gridView1.OptionsSelection.MultiSelect = true;
                //this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                this.togleValidacionBoleta.Enabled = false;
                this.btnAplicar.Enabled = true;
                this.btnValidar.Enabled = false;
                //Cargar Boletas Aprobadas
                Validada = 1;
                PopulateGrid();
            }
            else
            {
                //this.gridView1.OptionsSelection.MultiSelect = false;
                this.togleValidacionBoleta.Enabled = true;
                this.btnAplicar.Enabled = false;
                this.btnValidar.Enabled = false;
                Validada = -1;
                PopulateGrid();
                //this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            }
        }


        private void btnValidar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            try
            {
                if (MessageBox.Show("Las lineas marcadas, se cambiaran a estado Validada", "Validación de Boletas", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    for (int i = 0; i < this.gridView1.RowCount; i++)
                    {
                        DataRowView ele = (DataRowView)gridView1.GetRow(i);
                       
                        ele.BeginEdit();                                                                                                          
                        if (SelectedValidate.Exists(a => a == ele))
                            ele["Validada"] = true;
                        else
                            ele["Validada"] = false;
                        ele.EndEdit();

                        DataSet _dsChanged = _dsBoleta.GetChanges(DataRowState.Modified);
                        clsBoletaInvFisicoDAC.oAdaptador.Update(_dsChanged, "Data");
                        _dsBoleta.AcceptChanges();
                    }
                    MessageBox.Show("Los datos se han actualizado correctamente!", "Validación de Boletas");
                    //recargar los datos.
                    PopulateGrid();
                    setItemSelected();
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores: " + ex.Message);
                _dsBoleta.RejectChanges();
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;                
            DataRowView Valor ;
            
            Valor = (DataRowView)view.GetRow(e.ControllerRow);
            if (Valor != null)
            {
                if (e.Action == CollectionChangeAction.Add)
                    SelectedValidate.Add(Valor);
                else if (e.Action == CollectionChangeAction.Remove)
                    SelectedValidate.Remove(Valor);
            }
            else {
                SelectedValidate.Clear();
                Int32[] selectedRowHandles = gridView1.GetSelectedRows();
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    int selectedRowHandle = selectedRowHandles[i];
                    if (selectedRowHandle >= 0)
                        SelectedValidate.Add((DataRowView)view.GetRow(selectedRowHandle));
                }
            }

          
        }

        private void btnImprimirBoletas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPrintBoletasInv ofrmPrint = new frmPrintBoletasInv();
            ofrmPrint.ShowDialog();
        }

        private void btnAplicar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Las Boletas marcadas seran aplicadas al inventario", "Aplicación del Inventario", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                 
            }
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {

        }
    }
}