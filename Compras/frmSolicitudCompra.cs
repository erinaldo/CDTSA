using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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

    public partial class frmSolicitudCompra : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int IDSolicitud;
        DateTime Fecha, FechaRequerida;
        int IDEstado;
        String Comentarios;
        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        DataTable dtDetalleSolicitud = new DataTable();
        DataTable dtProductos = new DataTable();
        private string Accion = "Add";

        public frmSolicitudCompra(string pAccion)
        {
            InitializeComponent();
            this.Accion = "Add";
            
            InicializarNuevoElement();
        }

        public frmSolicitudCompra(int IDSolicitud,String Accion)
        {
            InitializeComponent();
            
            this.IDSolicitud = IDSolicitud;
            this.Accion = Accion;
        }

        private void InicializarNuevoElement()
        {
            this.txtIDSolicitud.Text = "XXX";
            this.dtpFechaSolicitud.EditValue = DateTime.Now;
            this.txtEstado.Text = "Inicial";
            this.txtEstado.Tag = 0;
            this.dtpFechaRequerida.EditValue = null;
            this.txtComentarios.Text = "";
            DataTable dtDetalleSolicitud = new DataTable();
        }

        private void HabilitarBotoneriaPrincipal() { 
            if (Accion=="Add" || Accion=="Edit"){
                this.btnAddSolicitud.Enabled = false;
                this.btnEditarSolicitud.Enabled = false;
                this.btnGuardarSolicitud.Enabled = true;
                this.btnCancelarSolicitud.Enabled = true;
                this.btnEliminarSolicitud.Enabled = false;
            }
            else if (Accion == "View") {
                this.btnAddSolicitud.Enabled = true;
                this.btnEditarSolicitud.Enabled = true;
                this.btnGuardarSolicitud.Enabled = false;
                this.btnCancelarSolicitud.Enabled = false;
                this.btnEliminarSolicitud.Enabled = true;
            }
            else if (Accion == "ReadOnly")
            {
                this.btnAddSolicitud.Enabled = true;
                this.btnEditarSolicitud.Enabled = false;
                this.btnGuardarSolicitud.Enabled = false;
                this.btnCancelarSolicitud.Enabled = false;
                this.btnEliminarSolicitud.Enabled = false;
            }
        }

        private void HabilitarControles() {
            this.txtIDSolicitud.Enabled = false;
            this.btnExportar.Enabled = true;
            this.txtEstado.Enabled = false;

            if (Accion == "Add" || Accion == "Edit")
            {
                this.dtgDetalleSolicitud.Enabled = true;
                this.txtComentarios.ReadOnly = false;
                this.dtpFechaRequerida.ReadOnly = false;
                this.dtpFechaSolicitud.ReadOnly=false;
                this.btnAgregar.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGuardar.Enabled = true;
                this.btnImportar.Enabled = true;

                this.gridView1.OptionsBehavior.ReadOnly = false;
                this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                this.gridView1.OptionsBehavior.AllowDeleteRows =  DevExpress.Utils.DefaultBoolean.True;
                this.gridView1.OptionsBehavior.ReadOnly = false;
            }
            else
            {
                this.dtgDetalleSolicitud.Enabled = false;
                this.txtComentarios.ReadOnly = true;
                this.dtpFechaRequerida.ReadOnly = true;
                this.dtpFechaSolicitud.ReadOnly=true;
                this.btnAgregar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.btnImportar.Enabled = false;
                this.gridView1.OptionsBehavior.ReadOnly = true;
                this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                this.gridView1.OptionsBehavior.ReadOnly = true;
            }

            
        }

        private void UpdateControlsFromData(DataTable dt) { 
            DataRow cabecera =  dt.Rows[0];
            this.txtIDSolicitud.EditValue = cabecera["IDSolicitud"].ToString();
            this.dtpFechaSolicitud.EditValue = Convert.ToDateTime(cabecera["Fecha"]);
            this.dtpFechaRequerida.EditValue = Convert.ToDateTime(cabecera["FechaRequerida"]);
            this.txtEstado.EditValue = cabecera["DescrEstado"].ToString();
            this.txtEstado.Tag = cabecera["IDEstado"];
            this.txtComentarios.Text = cabecera["Comentario"].ToString();
        }

        private void CargarSolicitud(int IDSolicitud) {
            DataTable dtSolicitud = DAC.clsSolicitudCompraDAC.GetByID(IDSolicitud).Tables[0];
            DataTable dtDetalle = DAC.clsOrdenCompraDetalleDAC.Get(IDSolicitud).Tables[0];
            UpdateControlsFromData(dtSolicitud);
            this.dtgDetalleSolicitud.DataSource = dtDetalle;
        }

        private void LoadData()
        {
            HabilitarControles();
            HabilitarBotoneriaPrincipal();
            if (Accion == "Add")
            {
                this.dtpFechaSolicitud.Focus();
                dtDetalleSolicitud = DAC.clsOrdenCompraDetalleDAC.Get(-1).Tables[0];
                this.dtgDetalleSolicitud.DataSource = dtDetalleSolicitud;
            }
            else
            {
                CargarSolicitud(this.IDSolicitud);
            }
        }

        private void frmSolicitudCompra_Load(object sender, EventArgs e)
        {
            this.gridView1.EditFormPrepared += gridView1_EditFormPrepared;
            this.gridView1.NewItemRowText = Util.Util.constNewItemTextGrid;
            //this.gridView1.ValidatingEditor += GridView1_ValidatingEditor;
            this.gridView1.ValidateRow += gridView1_ValidateRow;
            this.gridView1.InvalidRowException += gridView1_InvalidRowException;
            //this.gridView1.RowUpdated += gridView1_RowUpdated;
            //this.gridView1.ShownEditor += gridView1_ShownEditor;
            this.dtgDetalleSolicitud.ProcessGridKey += dtgDetalleSolicitud_ProcessGridKey;
            //this.gridView1.ValidatingEditor += gridView1_ValidatingEditor;
            
            

            this.gridView1.InitNewRow += gridView1_InitNewRow;
            //this.gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;

            Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, "Solicitud Compra", this);
            //slkupIDProducto

            dtProductos = CI.DAC.clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0];

            this.slkupIDProducto.DataSource = dtProductos;
            this.slkupIDProducto.DisplayMember = "IDProducto";
            this.slkupIDProducto.ValueMember = "IDProducto";
            this.slkupIDProducto.NullText = " --- ---";
            this.slkupIDProducto.EditValueChanged += slkup_EditValueChanged;
            this.slkupIDProducto.Popup += slkup_Popup;

            

            

            LoadData();
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

        private void slkup_EditValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DataView dataView = view.DataSource as DataView;
            System.Collections.IEnumerator en = dataView.GetEnumerator();

            en.Reset();

            string currentCode = e.Value.ToString();


            while (en.MoveNext())
            {
                DataRowView row = en.Current as DataRowView;
                object colValue = row["IDCentro"] + " " + row["IDCuenta"];
                if (colValue.ToString() == currentCode)
                {
                    e.ErrorText = "El elemento ya existe.";
                    e.Valid = false;
                    break;
                }
            }
        }

        void dtgDetalleSolicitud_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
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

        void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            try
            {
                if (view == null) return;
                //int count = (dtDetalleSolicitud.Rows.Count > 0) ? dtDetalleSolicitud.AsEnumerable().Max(a => a.Field<int>("Linea")) + 1 : 1;

                view.SetRowCellValue(e.RowHandle, view.Columns["IDSolicitud"], IDSolicitud);
                //view.SetRowCellValue(e.RowHandle, view.Columns["Linea"], count);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //try
            //{

            //    ColumnView view = sender as ColumnView;
            //    //if (e.Column.FieldName == "IDCentro")
            //    //{
            //    //    if (e.Value == null) return;
            //    //    DataView dt = new DataView();
            //    //    dt.Table = _dtCentros;
            //    //    dt.RowFilter = "IDCentro=" + e.Value.ToString();

            //    //    e.DisplayText = dt.ToTable().Rows[0]["Centro"].ToString() + "-" + dt.ToTable().Rows[0]["Descr"].ToString();
            //    //}
            //    //else if (e.Column.FieldName == "IDCuenta")
            //    //{
            //    //    if (e.Value == null) return;
            //    //    DataView dt = new DataView();
            //    //    dt.Table = _dtCuentas;
            //    //    dt.RowFilter = "IDCuenta=" + e.Value.ToString();

            //    //    e.DisplayText = dt.ToTable().Rows[0]["Cuenta"].ToString() + "-" + dt.ToTable().Rows[0]["Descr"].ToString();
            //    //}

            //    if (e.Column.FieldName == "Debito" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //    {
            //        if (e.Value == null || e.Value.ToString() == "") return;
            //        decimal Value = Convert.ToDecimal(e.Value);


            //        NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            //        nfi.CurrencySymbol = Util.Util.LocalSimbolCurrency;
            //        // Use the ToString method to format the value as currency ("c").
            //        e.DisplayText = ((decimal)e.Value).ToString("C" + Util.Util.DecimalLenght, nfi);


            //    }
            //    if (e.Column.FieldName == "Credito" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //    {
            //        if (e.Value == null || e.Value.ToString() == "") return;
            //        decimal Value = Convert.ToDecimal(e.Value);


            //        NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            //        nfi.CurrencySymbol = Util.Util.LocalSimbolCurrency;
            //        // Use the ToString method to format the value as currency ("c").
            //        e.DisplayText = ((decimal)e.Value).ToString("C" + Util.Util.DecimalLenght, nfi);


            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        void gridView1_ShownEditor(object sender, EventArgs e)
        {
            //ColumnView view = (ColumnView)sender;
            //if (view.FocusedColumn.FieldName == "IDCuenta")
            //{
            //    //LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
            //    SearchLookUpEdit editor = (SearchLookUpEdit)view.ActiveEditor;
            //    string idCentro = Convert.ToString(view.GetFocusedRowCellValue("IDCentro"));
            //    if (idCentro == "")
            //        idCentro = "0";

            //    editor.Properties.DataSource = CuentaContableDAC.GetCuentaByCentroCosto(Convert.ToInt32(idCentro)).Tables[0];
            //}
            //if (view.FocusedColumn.FieldName == "IDCentro")
            //{
            //    //LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
            //    SearchLookUpEdit editor = (SearchLookUpEdit)view.ActiveEditor;
            //    string IdCuenta = Convert.ToString(view.GetFocusedRowCellValue("IDCuenta"));
            //    if (IdCuenta == "")
            //        IdCuenta = "-1";

            //    editor.Properties.DataSource = CentroCostoDAC.GetCentroByCuenta(Convert.ToInt32(IdCuenta)).Tables[0];
            //}
        }

        void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //throw new NotImplementedException();
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
                GridColumn Cantidad = view.Columns["Cantidad"];
                
                object vIDProducto = (object)(view.GetRowCellValue(e.RowHandle, IDProducto));
                object vCantidad = (object)(view.GetRowCellValue(e.RowHandle, Cantidad));
                
            
                if (Convert.IsDBNull(vIDProducto))
                {
                    view.SetColumnError(IDProducto, "El campo no deberia ser vacio");
                    e.Valid = false;
                    return;
                }

                if (Convert.IsDBNull(vCantidad))
                {
                    view.SetColumnError(Cantidad, "El campo no deberia ser vacio");
                    e.Valid = false;
                    
                    return;
                }

            
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
            if (this.txtComentarios.Text == "")
                sMensaje = "   • Campo Comentarios \r\n";
            if (this.dtpFechaRequerida.Text == "")
                sMensaje = sMensaje +  "    • Fecha Requerida \n\r";
            if (this.dtpFechaSolicitud.Text == "")
                sMensaje = sMensaje + "   • Fecha Solicitud \n\r";

            if (sMensaje != "") {
                MessageBox.Show("Han ocurrido los siguientes errores por favor verifique los campos: \n\r");
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
                    FechaRequerida = Convert.ToDateTime(this.dtpFechaRequerida.EditValue);
                    Fecha = Convert.ToDateTime(this.dtpFechaSolicitud.EditValue);
                    Comentarios = this.txtComentarios.Text.Trim();
                    DataTable dt = (DataTable)this.dtgDetalleSolicitud.DataSource;

                    ConnectionManager.BeginTran();
                    if (Accion == "Add")
                    {
                        //Ingresar la cabecera de la solicitud
                        IDSolicitud = DAC.clsSolicitudCompraDAC.InsertUpdate("I", IDSolicitud, Fecha, FechaRequerida, 0, Comentarios, -1, sUsuario, null, DateTime.MinValue, sUsuario, DateTime.Now, sUsuario, DateTime.Now, sUsuario, null);

                        foreach (DataRow row in dt.Rows)
                        {
                            DAC.clsDetalleSolicitudCompraDAC.InsertUpdate("I", IDSolicitud, (long)row["IDProducto"], (decimal)row["Cantidad"], row["Comentario"].ToString(), ConnectionManager.Tran);
                        }
                    }

                    if (Accion == "Edit")
                    {
                        IDSolicitud = DAC.clsSolicitudCompraDAC.InsertUpdate("U", IDSolicitud, Fecha, FechaRequerida, 0, Comentarios, -1, sUsuario, null, DateTime.MinValue, sUsuario, DateTime.Now, sUsuario, DateTime.Now, sUsuario, null);
                        //Eliminamos el detalle y lo volvemos a insertar
                        DAC.clsDetalleSolicitudCompraDAC.InsertUpdate("D", IDSolicitud, -1, 0, "", ConnectionManager.Tran);
                        foreach (DataRow row in dt.Rows)
                        {
                            DAC.clsDetalleSolicitudCompraDAC.InsertUpdate("I", IDSolicitud, (long)row["IDProducto"], (decimal)row["Cantidad"], row["Comentario"].ToString(), ConnectionManager.Tran);
                        }
                    }
                }
            } catch (Exception ex)
            {
                 MessageBox.Show("Han ocurrido los siguiente errores: " + ex.Message);
            }

        }

        private void btnCancelarSolicitud_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Accion == "Add")
                this.Accion = "Add";
            else
                this.Accion = "View";
            LoadData();
        }

        private void btnEliminarSolicitud_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TODO: pendiente
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void frmSolicitudCompra_Load_1(object sender, EventArgs e)
        {

        }

        
    }
}
                            