using CO.DAC;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
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
            this.txtIDSolicitud.Text = "--";
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
            this.txtIDSolicitud.ReadOnly = true;
            this.btnExportar.Enabled = true;
            this.txtEstado.ReadOnly = true;

            if (Accion == "Add" || Accion == "Edit")
            {
                this.txtComentarios.ReadOnly = false;
                this.dtpFechaRequerida.ReadOnly = false;
                this.dtpFechaSolicitud.ReadOnly=false;
                
                this.btnImportar.Enabled = true;

                this.gridView1.OptionsBehavior.ReadOnly = false;
                this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                this.gridView1.OptionsBehavior.AllowDeleteRows =  DevExpress.Utils.DefaultBoolean.True;
            }
            else
            {
                this.txtComentarios.ReadOnly = true;
                this.dtpFechaRequerida.ReadOnly = true;
                this.dtpFechaSolicitud.ReadOnly=true;
                
                this.btnImportar.Enabled = false;
                this.gridView1.OptionsBehavior.ReadOnly = true;
                this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            }

            
        }

        private void UpdateControlsFromData(DataTable dt) { 
            DataRow cabecera =  dt.Rows[0];
            this.txtIDSolicitud.EditValue = cabecera["IDSolicitud"].ToString();
            this.dtpFechaSolicitud.EditValue = Convert.ToDateTime(cabecera["Fecha"]);
            this.dtpFechaRequerida.EditValue = Convert.ToDateTime(cabecera["FechaRequerida"]);
            this.txtEstado.EditValue = cabecera["DescrEstado"].ToString();
            this.txtEstado.Tag = cabecera["IDEstado"];
            this.txtEstado.ForeColor = cabecera["IDEstado"].ToString() =="0" ? Color.Black : (cabecera["IDEstado"].ToString() =="1" ? Color.Green :  cabecera["IDEstado"].ToString() =="2" ? Color.Red : Color.Purple);
            this.txtComentarios.Text = cabecera["Comentario"].ToString();
        }

        private void CargarSolicitud(int IDSolicitud) {
            DataTable dtSolicitud = DAC.clsSolicitudCompraDAC.GetByID(IDSolicitud).Tables[0];
            DataTable dtDetalle = DAC.clsDetalleSolicitudCompraDAC.Get(IDSolicitud).Tables[0];
            UpdateControlsFromData(dtSolicitud);
            this.dtgDetalleSolicitud.DataSource = dtDetalle;
            this.btnAprobar.Enabled = (Convert.ToInt32(this.txtEstado.Tag) == 0) ? true : false;
            
        }

        private void HabilitarComandosAccion() {
            IDEstado = Convert.ToInt32(this.txtEstado.Tag);
            if ( IDEstado == 0) {
                this.btnAprobar.Enabled = true;
                this.btnRechazar.Enabled = true;
                this.btnRevertir.Enabled =false;
                this.btnEliminarSolicitud.Enabled = (Accion == "View" && IDEstado == 0) ? true : false;
                this.btnEditarSolicitud.Enabled = (Accion == "View" && IDEstado == 0) ? true : false;
            }
            else if (IDEstado == 1 || IDEstado==2)
            {
                this.btnAprobar.Enabled = false;
                this.btnRechazar.Enabled = false;
                this.btnRevertir.Enabled = true;
                this.btnEliminarSolicitud.Enabled = false;
                this.btnEditarSolicitud.Enabled = false;
            }
            else {
                this.btnAprobar.Enabled = false;
                this.btnRechazar.Enabled = false;
                this.btnRevertir.Enabled = false;
                this.btnEliminarSolicitud.Enabled = false;
                this.btnEditarSolicitud.Enabled = false;
            }

        }

        private void LoadData()
        {
            try
            {
                HabilitarControles();
                HabilitarBotoneriaPrincipal();
                if (Accion == "Add")
                {
                    this.dtpFechaSolicitud.Focus();
                    dtDetalleSolicitud = DAC.clsDetalleSolicitudCompraDAC.Get(-1).Tables[0];
                    this.dtgDetalleSolicitud.DataSource = dtDetalleSolicitud;
                }
                else
                {
                    CargarSolicitud(this.IDSolicitud);
                }

                HabilitarComandosAccion();
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
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
            this.slkupIDProducto.PopulateViewColumns();
                        


                            
            //Util.Util.ConfigLookupEdit(this.slkupIDProducto, clsGlobalTipoTransaccionDAC.Get(-1, "*", "*", _dtPaquete.Rows[0]["Transaccion"].ToString()).Tables[0], "Descr", "IDTipoTran");
            //Util.Util.ConfigRepositoryLookupEditSetViewColumns(this.slkupIDProducto, "[{'ColumnCaption':'IDProducto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            this.slkupDescrProducto.DataSource = dtProductos;
            this.slkupDescrProducto.DisplayMember = "Descr";
            this.slkupDescrProducto.ValueMember = "IDProducto";
            this.slkupDescrProducto.NullText = " --- ---";
            this.slkupDescrProducto.EditValueChanged += slkup_EditValueChanged;
            this.slkupDescrProducto.Popup += slkup_Popup;
            


            //Util.Util.ConfigRepositoryLookupEditSetViewColumns(this.slkupDescrProducto, "[{'ColumnCaption':'IDProducto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            

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
            if (((DataTable)this.dtgDetalleSolicitud.DataSource).Rows.Count == 0)
                sMensaje = sMensaje = "   • Por favor agrege al menos un elemento al detalle de la solicitud";

            if (sMensaje != "") {
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
                    FechaRequerida = Convert.ToDateTime(this.dtpFechaRequerida.EditValue);
                    Fecha = Convert.ToDateTime(this.dtpFechaSolicitud.EditValue);
                    Comentarios = this.txtComentarios.Text.Trim();
                    DataTable dt = (DataTable)this.dtgDetalleSolicitud.DataSource;

                    ConnectionManager.BeginTran();
                    

                    if (Accion == "Add")
                    {
                        //Ingresar la cabecera de la solicitud
                        IDSolicitud = DAC.clsSolicitudCompraDAC.InsertUpdate("I", IDSolicitud, Fecha, FechaRequerida, 0, Comentarios, sUsuario,sUsuario,DateTime.Now, sUsuario, DateTime.Now, sUsuario, ConnectionManager.Tran);
                        this.txtIDSolicitud.Text = IDSolicitud.ToString();
                        foreach (DataRow row in dt.Rows)
                        {
                            DAC.clsDetalleSolicitudCompraDAC.InsertUpdate("I", IDSolicitud, (long)row["IDProducto"], (decimal)row["Cantidad"], row["Comentario"].ToString(), ConnectionManager.Tran);
                        }
                    }

                    if (Accion == "Edit")
                    {
                        DAC.clsSolicitudCompraDAC.InsertUpdate("U", IDSolicitud, Fecha, FechaRequerida, 0, Comentarios, sUsuario, sUsuario, DateTime.Now, sUsuario, DateTime.Now, sUsuario, ConnectionManager.Tran);
                        //Eliminamos el detalle y lo volvemos a insertar
                        DAC.clsDetalleSolicitudCompraDAC.InsertUpdate("D", IDSolicitud, -1, 0, "", ConnectionManager.Tran);
                        foreach (DataRow row in dt.Rows)
                        {
                            DAC.clsDetalleSolicitudCompraDAC.InsertUpdate("I", IDSolicitud, (long)row["IDProducto"], (decimal)row["Cantidad"], row["Comentario"].ToString(), ConnectionManager.Tran);
                        }
                    }

                    ConnectionManager.CommitTran();
                    this.Accion = "Edit";
                    HabilitarControles();
                    HabilitarBotoneriaPrincipal();
                    MessageBox.Show("La solicitud se ha guardado correctamente");
                    
                }
            } catch (Exception ex)
            {
                ConnectionManager.RollBackTran();
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
            try
            {
                if (MessageBox.Show("Esta seguro que desea eliminar la solicitud seleccionada ? ", "Listado de Solicitudes", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (IDSolicitud >-1)
                    {
                        ConnectionManager.BeginTran();
                        clsSolicitudCompraDAC.InsertUpdate("D", IDSolicitud, DateTime.Now, DateTime.Now, -1, "", "", "", DateTime.Now, "", DateTime.Now, "", ConnectionManager.Tran);
                        clsDetalleSolicitudCompraDAC.InsertUpdate("D", IDSolicitud, -1, 0, "", ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
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

       
      

        private void btnAprobar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Validar si se puede aprobar
            try
            {
                if (Convert.ToInt32(this.txtEstado.Tag) == 0)
                {
                    if (MessageBox.Show("Esta  seguro que desea aprobar la Solicitud de Compra ?", "Solicitud de Compra", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int Estado = 1;
                        FechaRequerida = Convert.ToDateTime(this.dtpFechaRequerida.EditValue);
                        Fecha = Convert.ToDateTime(this.dtpFechaSolicitud.EditValue);
                        Comentarios = this.txtComentarios.Text.Trim();
                        ConnectionManager.BeginTran();
                        DAC.clsSolicitudCompraDAC.InsertUpdate("U", IDSolicitud, Fecha, FechaRequerida, Estado, Comentarios, sUsuario, sUsuario, DateTime.Now, sUsuario, DateTime.Now, sUsuario, ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
                        this.txtEstado.Text = "APROBADO";
                        this.txtEstado.Tag = 1;
                        this.txtEstado.ForeColor = Color.Green;
                        this.Accion = "View";
                        HabilitarControles();
                        HabilitarBotoneriaPrincipal();
                        HabilitarComandosAccion();
                        MessageBox.Show("La solicitud se ha aprobado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("El estado actual de la solicitud no permite aprobarla");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores: " + ex.Message);
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
            report.Parameters["IDSolicitudCompra"].Value = Convert.ToInt32(this.txtIDSolicitud.Text.Trim());

            // Show the report's print preview.
            DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

            tool.ShowPreview();
        }

        private void btnRechazar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(this.txtEstado.Tag) == 0)
                {
                    if (MessageBox.Show("Esta  seguro que desea Rechazar la Solicitud de Compra ?", "Solicitud de Compra", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int Estado = 2;
                        FechaRequerida = Convert.ToDateTime(this.dtpFechaRequerida.EditValue);
                        Fecha = Convert.ToDateTime(this.dtpFechaSolicitud.EditValue);
                        Comentarios = this.txtComentarios.Text.Trim();
                        ConnectionManager.BeginTran();
                        DAC.clsSolicitudCompraDAC.InsertUpdate("U", IDSolicitud, Fecha, FechaRequerida, Estado, Comentarios, sUsuario, sUsuario, DateTime.Now, sUsuario, DateTime.Now, sUsuario, ConnectionManager.Tran);
                        ConnectionManager.CommitTran();
                        this.txtEstado.Text = "RECHAZADA";
                        this.txtEstado.Tag = 2;
                        this.txtEstado.ForeColor = Color.Red;
                        this.Accion = "View";
                        HabilitarControles();
                        HabilitarBotoneriaPrincipal();
                        HabilitarComandosAccion();
                        MessageBox.Show("La solicitud se ha rechazado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("El estado actual de la solicitud no permite aprobarla");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores : \n\r" + ex.Message);
            }
        }

        private void btnRevertir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Validar si la solicitud tiene ordenes asociadas
            DataTable dt = DAC.clsSolicitudCompraDAC.GetSolicitudCompra_OrdenCompra(IDSolicitud, -1, -1).Tables[0];
            if (dt.Rows.Count == 0)
            {
                int Estado = 0;
                FechaRequerida = Convert.ToDateTime(this.dtpFechaRequerida.EditValue);
                Fecha = Convert.ToDateTime(this.dtpFechaSolicitud.EditValue);
                Comentarios = this.txtComentarios.Text.Trim();
                DAC.clsSolicitudCompraDAC.InsertUpdate("U", IDSolicitud, Fecha, FechaRequerida, Estado, Comentarios, sUsuario, sUsuario, DateTime.Now, sUsuario, DateTime.Now, sUsuario, ConnectionManager.Tran);
                this.txtEstado.Text = "INICIALIZADA";
                this.txtEstado.Tag = 0;
                this.txtEstado.ForeColor = Color.Black;
                this.Accion = "Edit";
                HabilitarControles();
                HabilitarBotoneriaPrincipal();
                HabilitarComandosAccion();
                MessageBox.Show("La solicitud se ha revertido correctamente");
            }
            else {
                MessageBox.Show("La solicitud no puede ser revertida, posee ordenes de compra asociadas");
            }

        }

       

        
    }
}
                            