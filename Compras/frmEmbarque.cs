using CO.DAC;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
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

namespace CO
{
    public partial class frmEmbarque : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public long IDOrdenCompra,IDEmbarque;
        DateTime  FechaEmbarque, Fecha;
        int IDEstado, IDProveedor,IDBodega;
        String OrdenCompra,Embarque;
        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        DataTable dtDetalleOrden = new DataTable();
        DataTable dtDetalleEmbarque = new DataTable();
        DataTable dtEmbarque = new DataTable();
        DataTable dtProductos = new DataTable();
        DataTable dtLotes = new DataTable();
        DataTable dtOrdenCompra = new DataTable();
        double TipoCambio;

        private string Accion = "Add";

        public frmEmbarque(long IDOrdenCompra)
        {
            InitializeComponent();
            this.Accion = "Add";
            this.IDOrdenCompra = IDOrdenCompra;            
            InicializarNuevoElement();
        }


        public frmEmbarque(long IDOrdenCompra,long IDEmbarque, String Accion)
        {
            InitializeComponent();
            
            this.IDOrdenCompra = IDOrdenCompra;
            this.IDEmbarque = IDEmbarque;
            this.Accion = Accion;
        }                                


        public long ID_Embarque {
            get { return this.IDEmbarque; }
            set { this.IDEmbarque = value; }
        }


        
        private void InicializarNuevoElement()
        {
            
            this.txtOrdenCompra.Text = "--";
            this.txtEmbarque.Text = "--";
            this.dtpFecha.EditValue = DateTime.Now;
            this.dtpFechaEmbarque.EditValue = DateTime.Now;
            this.txtProveedor.Text = "";
            this.dtDetalleEmbarque = new DataTable();
            this.dtDetalleOrden = new DataTable();
        }

        private void HabilitarBotoneriaPrincipal() { 
            
            if (Accion=="Add" || Accion=="Edit"){
                this.btnEditar.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnEliminar.Enabled = false;
               
            }
            else if (Accion == "View") {
                this.btnEditar.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnEliminar.Enabled = true;
            }
            else if (Accion == "ReadOnly")
            {
                this.btnEditar.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void HabilitarControles() {
            this.txtOrdenCompra.ReadOnly = true;
            this.txtEmbarque.ReadOnly = true;
            this.txtProveedor.ReadOnly = true;
            

            if (Accion == "Add" || Accion == "Edit")
            {
                
                this.dtpFecha.ReadOnly = false;
                this.dtpFechaEmbarque.ReadOnly = false;
                
                
                this.gridView1.OptionsBehavior.ReadOnly = false;
                this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                this.gridView1.OptionsBehavior.AllowDeleteRows =  DevExpress.Utils.DefaultBoolean.True;

                this.gridView2.OptionsBehavior.ReadOnly = false;
                this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            }
            else
            {
                this.dtpFecha.ReadOnly = true;
                this.dtpFechaEmbarque.ReadOnly = true;
                

                this.gridView1.OptionsBehavior.ReadOnly = true;
                this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;

                this.gridView2.OptionsBehavior.ReadOnly = true;
                this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            }

            
        }

        private void UpdateControlsFromData(DataTable dt) { 
            DataRow cabecera =  dt.Rows[0];
            this.IDOrdenCompra = Convert.ToInt32(cabecera["IDOrdenCompra"]);
            this.txtOrdenCompra.EditValue = cabecera["OrdenCompra"].ToString();
            this.txtOrdenCompra.Tag = this.IDOrdenCompra;
            OrdenCompra = cabecera["OrdenCompra"].ToString();
            this.txtEmbarque.EditValue = cabecera["Embarque"].ToString();
            this.txtEmbarque.Tag = cabecera["IDEmbarque"].ToString();
            this.dtpFecha.EditValue = Convert.ToDateTime(cabecera["Fecha"]);
            this.dtpFechaEmbarque.EditValue = Convert.ToDateTime(cabecera["FechaEmbarque"]);
            this.linkAsiento.Text = cabecera["Asiento"].ToString();
            this.txtBodega.Text = cabecera["DescrBodega"].ToString();
            this.txtBodega.Tag = cabecera["IDBodega"].ToString();
            this.txtProveedor.Text = cabecera["NombreProveedor"].ToString();
            this.txtProveedor.Tag = cabecera["IDProveedor"].ToString();
            if (this.linkAsiento.Text != "")
            {
                this.btnAplicar.Enabled = false;
            }
            else
                this.btnAplicar.Enabled = true;
        }

        private void CargarEmbarque(long IDOrdenCompra,long IDEmbarque) {
            dtDetalleOrden = DAC.clsOrdenCompraDetalleDAC.Get(IDOrdenCompra).Tables[0];                                                              
            this.dtDetalleEmbarque = DAC.clsEmbarqueDetalleDAC.Get(IDEmbarque).Tables[0];
            this.dtEmbarque = DAC.clsEmbarqueDAC.GetByID(IDEmbarque, IDOrdenCompra).Tables[0];
            
            
            UpdateControlsFromData(dtEmbarque);

            if (IDEmbarque == -1)
            {
                this.dtDetalleEmbarque.Clear();
                foreach (DataRow row in dtDetalleOrden.Rows)
                {
                    DataRow fila = this.dtDetalleEmbarque.NewRow();
                    fila["IDEmbarque"] = 0;
                    fila["IDProducto"] = row["IDProducto"];
                    fila["DescrProducto"] = row["DescrProducto"];
                    //fila["Cantidad"] = row["Cantidad"];
                    this.dtDetalleEmbarque.Rows.Add(fila);

                }
                dtDetalleEmbarque.AcceptChanges();
                this.dtgLineasEmbarque.DataSource = dtDetalleEmbarque;
            }
            else
                this.dtgLineasEmbarque.DataSource = dtDetalleEmbarque;
                                                               
            this.dtgLineasOrden.DataSource = dtDetalleOrden;
        }
                                                                                
        private void LoadData()
        {
            try
            {

                TipoCambio = CG.TipoCambioDetalleDAC.GetLastTipoCambioFecha(DateTime.Now);
                HabilitarControles();
                HabilitarBotoneriaPrincipal();
                if (Accion == "Add")
                {
                    
                    this.dtpFecha.Focus();
                    IDEmbarque = -1;
                    CargarEmbarque(IDOrdenCompra, IDEmbarque);

                 
                  
                    this.dtgLineasOrden.DataSource = dtDetalleOrden;
                    this.dtgLineasEmbarque.DataSource =dtDetalleEmbarque;
                }
                else
                {
                    CargarEmbarque(this.IDOrdenCompra,this.IDEmbarque);
                }    
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        private void frmEmbarque_Load(object sender, EventArgs e)
        {
            try
            {
               
                //this.gridView2.EditFormPrepared += gridView1_EditFormPrepared;
                //this.gridView2.NewItemRowText = Util.Util.constNewItemTextGrid;
                ////this.gridView1.ValidatingEditor += GridView1_ValidatingEditor;
                //this.gridView2.ValidateRow += gridView1_ValidateRow;
                //this.gridView2.InvalidRowException += gridView1_InvalidRowException;
                //this.gridView2.RowUpdated += gridView1_RowUpdated;
                ////this.gridView1.ShownEditor += gridView1_ShownEditor;
                ////this.dtgDetalle.ProcessGridKey += dtgDetalleSolicitud_ProcessGridKey;
                ////this.gridView1.ValidatingEditor += gridView1_ValidatingEditor;



                //this.gridView2.InitNewRow += gridView1_InitNewRow;
                ////this.gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;

                ////Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, "Embarque", this);
                ////Util.Util.SetDefaultBehaviorControls(this.gridView2, true, null, "Embarque", this);
                ////slkupIDProducto

                //Validar que el consecutivo de Solicitud de Compra este asociado 
                String Consec = clsUtilDAC.GetParametroCompra("IDConsecEmbarque").Tables[0].Rows[0][0].ToString();
                if (Consec == null || Consec.Trim() == "")
                {
                    MessageBox.Show("Por favor establezca el consecutivo a utilizar en la Orden de Compra");
                    this.Close();
                }

                dtProductos = CI.DAC.clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0];
                dtLotes = CI.DAC.clsLoteDAC.GetData(-1, -1, "*", "*").Tables[0];

                this.slkupIDProducto.DataSource = dtProductos;
                this.slkupIDProducto.DisplayMember = "IDProducto";
                this.slkupIDProducto.ValueMember = "IDProducto";
                this.slkupIDProducto.NullText = " --- ---";
                this.slkupIDProducto.EditValueChanged += slkup_EditValueProductoChanged;
                this.slkupIDProducto.Popup += slkup_Popup;
                //this.slkupIDProducto.PopulateViewColumns();
            

                
                this.slkupLote.DisplayMember = "LoteProveedor";
                this.slkupLote.ValueMember = "IDLote";
                this.slkupLote.NullText = " --- ---";
                this.slkupLote.DataSource = dtLotes;
                this.slkupLote.BeforePopup += slkupLote_BeforePopup;
                this.slkupLote.EditValueChanged += slkup_EditValueChanged;
                this.slkupLote.Popup += slkup_Popup;


                this.slkupDescrProducto.DataSource = dtProductos;
                this.slkupDescrProducto.DisplayMember = "Descr";
                this.slkupDescrProducto.ValueMember = "IDProducto";
                this.slkupDescrProducto.NullText = " --- ---";
                this.slkupDescrProducto.EditValueChanged += slkup_EditValueProductoChanged;
                this.slkupDescrProducto.Popup += slkup_Popup;


                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores: " + ex.Message);
            }

        }

        void slkupLote_BeforePopup(object sender, EventArgs e)
        {
            MessageBox.Show("Se muestra antes de asociar el lote");
        }

   

        private void slkup_Popup(object sender, EventArgs e)
        {
            DevExpress.Utils.Win.IPopupControl popupControl = sender as DevExpress.Utils.Win.IPopupControl;
            DevExpress.XtraLayout.LayoutControl layoutControl = popupControl.PopupWindow.Controls[2].Controls[0] as LayoutControl;
            
            SimpleButton clearButton = ((DevExpress.XtraLayout.LayoutControlItem)layoutControl.Items.FindByName("lciClear")).Control as SimpleButton;
            SimpleButton findButton = ((DevExpress.XtraLayout.LayoutControlItem)layoutControl.Items.FindByName("lciButtonFind")).Control as SimpleButton;

            clearButton.Text = "Limpiar";
            findButton.Text = "Buscar";
        }

        private void slkup_EditValueProductoChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }


        private void slkup_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            DataRowView dr = (DataRowView)editor.GetSelectedDataRow();

            this.gridView2.PostEditor();
            Fecha = Convert.ToDateTime(dr["FechaVencimiento"]);
            this.gridView2.SetFocusedRowCellValue("FechaVencimiento", Fecha);

            SendKeys.Send("{TAB}");
        }


        void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (this.gridView1.FocusedRowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            //    return;

            //DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DataView dataView = view.DataSource as DataView;
            //System.Collections.IEnumerator en = dataView.GetEnumerator();

            //en.Reset();

            //string currentCode = e.Value.ToString();


            //while (en.MoveNext())
            //{
            //    DataRowView row = en.Current as DataRowView;
            //    object colValue = row["IDCentro"] + " " + row["IDCuenta"];
            //    if (colValue.ToString() == currentCode)
            //    {
            //        e.ErrorText = "El elemento ya existe.";
            //        e.Valid = false;
            //        break;
            //    }
            //}
        }

        void dtgDetalleSolicitud_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el elemento seleccionado?", "Embarque", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    view.DeleteSelectedRows();
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
        }

        void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            try
            {
                if (view == null) return;
                DataRow fila = view.GetDataRow(e.RowHandle);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridColumn IDProducto = view.Columns["IDProducto"];
                
                object vIDProducto = (object)(view.GetRowCellValue(e.RowHandle, IDProducto));
                
               // Validacion de Productos Unicos en la lista

                if (e.Row == null) return;
                //Get the value of the first column
                int iIDProducto = (view.GetRowCellValue(e.RowHandle, IDProducto) != null) ? Convert.ToInt32(view.GetRowCellValue(e.RowHandle, IDProducto)) : -1;
                //Validity criterion

                DataView Dv = new DataView();
                Dv.Table = ((DataView)view.DataSource).ToTable();
                Dv.RowFilter = string.Format("IdProducto={0}", iIDProducto);

                if (Dv.ToTable().Rows.Count > 1)
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(IDProducto, "El producto debe ser unico en la lista");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void gridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            Control ctrl = Util.Util.FindControl(e.Panel, "Update");
            if (ctrl != null)
                ctrl.Text = "Actualizar";
            ctrl = Util.Util.FindControl(e.Panel, "Cancel");

            if (ctrl != null)
                ctrl.Text = "Cancelar";
        }



        private void gridView2_ShownEditor(object sender, EventArgs e)
        {
            ColumnView view = (ColumnView)sender;

            if (view.FocusedColumn.FieldName == "IDLote" && view.ActiveEditor is SearchLookUpEdit && view.FocusedRowHandle >= 0)
            {
                SearchLookUpEdit edit = (SearchLookUpEdit)view.ActiveEditor;
                long IDProducto = (long)view.GetFocusedRowCellValue("IDProducto");
             
                edit.Properties.DataSource = CI.DAC.clsLoteDAC.GetData(-1, IDProducto, "*", "*").Tables[0];
            }
        }


        private void dtgDetalle_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete && Accion != "View" && Accion != "ReadOnly")
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el elemento seleccionado?", "Asiento de Diario", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    view.DeleteSelectedRows();
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //GridView view = (GridView)sender;
            //if (view == null) return;
            //if (e.Column.FieldName == "IDLote")
            //{
                
            //    view.SetRowCellValue(e.RowHandle, view.Columns[4], e.Value);
            //    //long IDProducto = Convert.ToInt64(view.GetRowCellValue(e.RowHandle, view.Columns[0]));

            //    //dtLotes= CI.DAC.clsLoteDAC.GetData(-1,IDProducto,"*","*").Tables[0];
            //    //this.slkupLote.DataSource = dtLotes;
            //    //this.slkupLote.DisplayMember = "IDLote";
            //    //this.slkupLote.ValueMember = "LoteProveedor";
            //    //this.slkupLote.NullText = " --- ---";
            //    //this.slkupLote.EditValueChanged += slkup_EditValueChanged;
            //    //this.slkupLote.Popup += slkup_Popup;
            //    //this.slkupLote.PopulateViewColumns();

            //    //DataTable dt = clsArticuloProveedorDAC.Get(IDProducto, IDProveedor).Tables[0];

            //    //validar si el producto 
            //}
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName == "PorcDesc")
            //{
            //    bEditMontoDesc = false;
            //    bEditPorcDesc = true;
            //}
        }

        private void btnAddSolicitud_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Accion = "Add";
            InicializarNuevoElement();
            LoadData();
        }

        private void btnEditarSolicitud_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Accion = "Edit";
            HabilitarControles();
            HabilitarBotoneriaPrincipal();
        }

        private bool ValidarDatos() { 
            String sMensaje = "";
            bool Resultado = true;
            if (this.dtpFecha.EditValue.ToString() == "" || this.dtpFecha.EditValue == null)
                sMensaje = "   • Fecha \r\n";
            if (this.dtpFechaEmbarque.EditValue == null || this.dtpFechaEmbarque.EditValue.ToString() == "")
                sMensaje = "   • Fecha Embarque \r\n";
            
            if (((DataTable)this.dtgLineasEmbarque.DataSource).Rows.Count == 0)
                sMensaje = sMensaje = "   • Por favor agrege al menos un elemento al detalle del embarque \r\n";
            foreach (DataRow fila in ((DataTable)this.dtgLineasEmbarque.DataSource).Rows)
            {
                if (fila.RowState != DataRowState.Deleted)
                {
                    if (fila["Cantidad"] == DBNull.Value || Convert.ToDecimal(fila["Cantidad"]) == 0)
                        sMensaje = "  • El producto " + fila["DescrProducto"].ToString() + " debe de tener la cantidad recibida\r\n";
                    
                }
            }
            if (sMensaje != "")
            {
                MessageBox.Show("Han ocurrido los siguientes errores por favor verifique los campos: \n\r " + sMensaje);
                Resultado = false;
            }
            return Resultado;
        }

        private void btnGuardarSolicitud_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    Fecha = Convert.ToDateTime(this.dtpFecha.EditValue);
                    FechaEmbarque = Convert.ToDateTime(this.dtpFechaEmbarque.EditValue);
                    IDProveedor = Convert.ToInt32(this.txtProveedor.Tag);
                    //IDOrdenCompra = Convert.ToInt64(this.txtOrdenCompra.Tag);
                    Embarque = this.txtEmbarque.EditValue.ToString().Trim();
                    IDBodega = Convert.ToInt32(this.txtBodega.Tag);                 
                    
                    DataTable dt = (DataTable)this.dtgLineasEmbarque.DataSource;

                    ConnectionManager.BeginTran();
                    

                    if (Accion == "Add")
                    {
                        OrdenCompra = "--";
                        
                        //Ingresar la cabecera de la solicitud
                        IDEmbarque = DAC.clsEmbarqueDAC.InsertUpdate("I", IDEmbarque,ref Embarque,Fecha,FechaEmbarque,null,IDBodega,IDProveedor,IDOrdenCompra,-1,Convert.ToDecimal(TipoCambio), sUsuario, DateTime.Now,sUsuario,DateTime.Now,sUsuario, ConnectionManager.Tran);
                        this.txtEmbarque.Tag = IDEmbarque;
                        this.txtEmbarque.Text = Embarque;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                DAC.clsEmbarqueDetalleDAC.InsertUpdate("I", IDEmbarque, (long)row["IDProducto"], (int)row["IDLote"], (decimal)row["Cantidad"], 0, 0, "", ConnectionManager.Tran);
                                DAC.clsOrdenCompraDetalleDAC.UpdateCantidadRecibida(IDOrdenCompra, (long)row["IDProducto"], (decimal)row["Cantidad"],ConnectionManager.Tran);
                            }
                        }

                    }

                     if (Accion == "Edit")
                    {
                        IDEmbarque = DAC.clsEmbarqueDAC.InsertUpdate("U", IDEmbarque,ref Embarque, Fecha, FechaEmbarque, null, IDBodega, IDProveedor, IDOrdenCompra, -1, 0, sUsuario, DateTime.Now, sUsuario, DateTime.Now, sUsuario, ConnectionManager.Tran);
                        
                         //Eliminamos el detalle y lo volvemos a insertar
                        DAC.clsEmbarqueDetalleDAC.InsertUpdate("D", IDEmbarque,-1,-1,0,0,0,"", ConnectionManager.Tran);
                        DAC.clsOrdenCompraDetalleDAC.UpdateCantidadRecibida(IDOrdenCompra, -1,0, ConnectionManager.Tran);
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                DAC.clsEmbarqueDetalleDAC.InsertUpdate("I", IDEmbarque, (long)row["IDProducto"], (int)row["IDLote"], (decimal)row["Cantidad"], 0, 0, "", ConnectionManager.Tran);
                            }
                        }

                        
                    }

                    ConnectionManager.CommitTran();
                    this.Accion = "Edit";
                    HabilitarControles();
                    HabilitarBotoneriaPrincipal();
                    MessageBox.Show("La Orden de Compra se ha guardado correctamente");
                    
                }
            } catch (Exception ex)
            {
                ConnectionManager.RollBackTran();
                 MessageBox.Show("Han ocurrido los siguiente errores: " + ex.Message);
            }

        }

        private void btnCancelarSolicitud_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
           // LoadData();
        }

        private void btnEliminarSolicitud_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta seguro que desea eliminar la Orden de Compra seleccionada ? ", "Listado de Ordenes de Compra", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (IDOrdenCompra >-1)
                    {
                        ConnectionManager.BeginTran();

                        DAC.clsEmbarqueDAC.InsertUpdate("D", IDEmbarque, ref Embarque ,DateTime.Now, DateTime.Now,"",-1,-1,-1,-1,0,"",DateTime.Now,"",DateTime.Now,"", ConnectionManager.Tran);                            
                        DAC.clsEmbarqueDetalleDAC.InsertUpdate("D",IDEmbarque,-1,-1,0,0,0,"", ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
                        MessageBox.Show("El embarque ha sido eliminado correctamente");
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
                ConnectionManager.RollBackTran();
            }
        }


        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptSolicitudCompra.repx", true);


            SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

            SqlDataSource ds = report.DataSource as SqlDataSource;
            ds.ConnectionName = "DataSource";
            String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
            ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

            // Obtain a parameter, and set its value.
            report.Parameters["IDOrdenCompra"].Value = this.IDOrdenCompra;

            // Show the report's print preview.
            DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

            tool.ShowPreview();
        }

        private void btnAplicar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                long IDTan = -1;
                String Asiento = "";
                ConnectionManager.BeginTran();
                DAC.clsEmbarqueDAC.CrearPaqueteInventario("CO", Convert.ToInt64(this.txtEmbarque.Tag), sUsuario, ref IDTan, ConnectionManager.Tran);
                DAC.clsEmbarqueDAC.GeneraAsientoContable("CO", Convert.ToInt64(this.txtEmbarque.Tag), sUsuario, ref Asiento, ConnectionManager.Tran);
                ConnectionManager.CommitTran();
                MessageBox.Show("El documento se ha aplicado correctamente ");
                this.linkAsiento.Text = Asiento;
                this.btnAplicar.Enabled = false;
            }
            catch (Exception Ex) {
                MessageBox.Show("Han ocurrido los siguientes errores : " + Ex.Message);
            }
        }

        private void linkAsiento_Click(object sender, EventArgs e)
        {
            CG.frmAsiento ofrmAsiento = new CG.frmAsiento(this.linkAsiento.Text);
            ofrmAsiento.ShowDialog();
        }

       

    }
}