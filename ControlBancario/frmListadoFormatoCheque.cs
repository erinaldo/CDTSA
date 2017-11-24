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
using System.IO;
using Security;
using ControlBancario.DAC;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UserDesigner;

namespace ControlBancario
{
    public partial class frmListadoFormatoCheque : DevExpress.XtraEditors.XtraForm
    {
     
        private DataTable _dtFormatos;
        private DataSet _dsFormatos;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Formatos de Cheques";
        private bool isEdition = false;
        private int IdCuentaBanco;

        XRDesignMdiController mdiController;

        public frmListadoFormatoCheque(int pIdCuentaBanco)
        {
            InitializeComponent();
            this.IdCuentaBanco = pIdCuentaBanco;
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
                this.btnModificar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCentroCosto, _dtSecurity))
                this.btnEliminar.Enabled = false;
        }


        private void EnlazarEventos()
        {

            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }


        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = true;
            HabilitarControles(true);
            ClearControls();
            currentRow = null;
            this.txtDescripcion.Focus();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //ValidarDatos
            if (!ValidarDatos())
                return;

            if (currentRow != null)
            {
                lblStatus.Caption = "Actualizando : " + currentRow["FormatoCheque"].ToString();

                Application.DoEvents();
                currentRow.BeginEdit();

                currentRow["IDCuentaBanco"] = IdCuentaBanco;
                currentRow["FormatoCheque"] = this.txtDescripcion.EditValue;
                currentRow["Activo"] = this.chkActivo.EditValue;

                currentRow.EndEdit();

                DataSet _dsChanged = _dsFormatos.GetChanges(DataRowState.Modified);

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
                                msg = msg + dr["FormatoCheque"].ToString();
                            }
                        }
                    }

                    lblStatus.Caption = msg;
                }

                //Si no hay errores

                if (okFlag)
                {
                    CuentaFormatoChequeDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado " + currentRow["FormatoCheque"].ToString();
                    Application.DoEvents();
                    isEdition = false;
                    _dsFormatos.AcceptChanges();
                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                }
                else
                {
                    _dsFormatos.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                currentRow = _dtFormatos.NewRow();
                currentRow["IDFormato"] = -1;
                currentRow["IDCuentaBanco"] = IdCuentaBanco;
                currentRow["FormatoCheque"] = this.txtDescripcion.Text;
                currentRow["Activo"] = this.chkActivo.EditValue;

                _dtFormatos.Rows.Add(currentRow);
                try
                {
                    CuentaFormatoChequeDAC.oAdaptador.Update(_dsFormatos, "Data");
                    _dsFormatos.AcceptChanges();
                    isEdition = false;
                    lblStatus.Caption = "Se ha ingresado un nuevo registro";
                    Application.DoEvents();

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", "rptChequeBase.repx");
                    System.IO.File.Copy(path, Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", string.Format("Formato-{0}.repx", currentRow["IDFormato"])), true);

                    PopulateGrid();
                    SetCurrentRow();
                    HabilitarControles(false);
                    AplicarPrivilegios();
                    ColumnView view = this.gridView1;
                    view.MoveLast();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    _dsFormatos.RejectChanges();
                    currentRow = null;
                    MessageBox.Show(ex.Message);
                }
            }



        }

        private void frmListadoFormatoCheque_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.gridControl1, _tituloVentana, this);

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
            _dsFormatos = CuentaFormatoChequeDAC.GetData(IdCuentaBanco, -1);

            _dtFormatos = _dsFormatos.Tables[0];
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = _dtFormatos;



        }


        private void ClearControls()
        {
            this.txtDescripcion.EditValue = "";
            this.chkActivo.EditValue = true;

        }

        private void HabilitarControles(bool Activo)
        {
            this.txtDescripcion.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;


            this.gridControl1.Enabled = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnModificar.Enabled = !Activo;
            this.btnModificarFormato.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;

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
            this.txtDescripcion.Text = Row["FormatoCheque"].ToString();
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            lblStatus.Caption = "Editando el registro : " + currentRow["FormatoCheque"].ToString();
            this.txtDescripcion.Focus();
        }


        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (this.txtDescripcion.Text == "")
                sMensaje = sMensaje + "     • Descripción. \n\r";

            if (sMensaje != "")
            {
                result = false;
                MessageBox.Show("Por favor revise los siguientes campos, puede que sean obligatorios: \n\r\n\r" + sMensaje);
            }
            return result;
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentRow != null)
            {
                string msg = currentRow["FormatoCheque"] + " eliminado..";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", string.Format("Formato-{0}.repx", currentRow["IDFormato"]));
                String sNameFile = path.ToString();
                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + currentRow["FormatoCheque"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    currentRow.Delete();

                    try
                    {

                        CuentaFormatoChequeDAC.oAdaptador.Update(_dsFormatos, "Data");
                        _dsFormatos.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;

                        System.IO.File.Delete(sNameFile);

                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsFormatos.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
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

        private void btnModificarFormato_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport report = new XtraReport();
            String path = Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", string.Format("Formato-{0}.repx", currentRow["IDFormato"])).ToString();
            report.LoadLayout(path);
            //DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques");

                        
            ReportDesignTool designTool = new ReportDesignTool(report);
            IDesignForm desingForm = designTool.DesignRibbonForm;
            mdiController = desingForm.DesignMdiController;
            //mdiController.SetCommandVisibility(ReportCommand.SaveFileAs, CommandVisibility.None);
            //mdiController.SetCommandVisibility(ReportCommand.SaveFile, CommandVisibility.None);
            mdiController.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
            mdiController.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
            mdiController.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
            mdiController.SetCommandVisibility(ReportCommand.OpenRemoteReport, CommandVisibility.None);
            mdiController.SetCommandVisibility(ReportCommand.OpenSubreport, CommandVisibility.None);

            
            designTool.DesignRibbonForm.DesignMdiController.DesignPanelLoaded+= new DesignerLoadedEventHandler(DesignMdiController_DesignPanelLoaded);
            
            designTool.ShowRibbonDesigner();



        }

        void DesignMdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
        //    XtraReport report = (sender as XRDesignPanel).Report;
            
        //    (sender as XRDesignPanel).SaveReport(Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", string.Format("Formato-{0}.repx", currentRow["IDFormato"])).ToString());
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel, Path.Combine(Directory.GetCurrentDirectory(), "FormatosCheques", string.Format("Formato-{0}.repx", currentRow["IDFormato"])).ToString()));
        }

        public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
        {
            XRDesignPanel panel;
            String Ruta;


            public SaveCommandHandler(XRDesignPanel panel,String Ruta)
            {
                this.panel = panel;
                this.Ruta = Ruta;
               
            }

            public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
            object[] args)
            {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
            ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                    command == ReportCommand.SaveFileAs || command == ReportCommand.SaveAll);
                return !useNextHandler;
            }

            void Save()
            {
                // Write your custom saving here.
                // ...

                // For instance:
                panel.Report.SaveLayout(Ruta);

                // Prevent the "Report has been changed" dialog from being shown.
                panel.ReportState = ReportState.Saved;
            }
        }

    }


  
}

