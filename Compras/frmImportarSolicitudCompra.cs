using DevExpress.XtraEditors;
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
    public partial class frmImportarSolicitudCompra : Form
    {
        private DataSet _dsSolicitudes;
        private DataTable _dtSecurity, _dtSolicitudes, _dtClasif1, _dtClasif2, _dtClasif3, _dtClasif4, _dtClasif5, _dtClasif6, _dtProductos;
        private int IDProveedor;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Importar Solicitudes de Compras";

        int IDSolicitudDesde, IDSolicitudHasta,IDClasif1,IDClasif2,IDClasif3,IDClasif4,IDClasif5,IDClasif6;
        long IDProducto;
        DateTime FechaSolicitudDesde, FechaSolicitudHasta, FechaRequeridaDesde, FechaRequeridaHasta;
        


        public frmImportarSolicitudCompra(int IDProveedor)
        {
            InitializeComponent();
            this.IDProveedor = IDProveedor;
        }


        private void EnlazarEventos()
        {
            this.btnImportar.Click += btnImportar_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            this.btnRefrescar.Click += btnRefrescar_Click;
        }

        void btnRefrescar_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }


        public DataTable GetSolicitudesSeleccionadas() {
            return _dtSolicitudes;
        }
 

        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnImportar_Click(object sender, EventArgs e)
        {
            this.DialogResult= System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        private void PopulateGrid()
        {

            try
            {
                IDSolicitudDesde = (this.txtIDSolicitudDesde.EditValue==null || this.txtIDSolicitudDesde.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.txtIDSolicitudDesde.EditValue);
                IDSolicitudHasta = (this.txtSolicitudHasta.EditValue == null || this.txtSolicitudHasta.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.txtSolicitudHasta.EditValue);
                FechaSolicitudDesde = (this.dtpFechaSolicitudDesde.EditValue==null || this.dtpFechaSolicitudDesde.EditValue.ToString() == "") ? Convert.ToDateTime("1981/08/21") : Convert.ToDateTime(this.dtpFechaSolicitudDesde.EditValue);
                FechaSolicitudHasta = (this.dtpFechaSolicitudHasta.EditValue==null || this.dtpFechaSolicitudHasta.EditValue.ToString() == "") ? DateTime.Now.AddYears(50) : Convert.ToDateTime(this.dtpFechaSolicitudHasta.EditValue);
                FechaRequeridaDesde = (this.dtpFechaRequeridaDesde.EditValue==null || this.dtpFechaRequeridaDesde.EditValue.ToString() == "") ? Convert.ToDateTime("1981/08/21") : Convert.ToDateTime(this.dtpFechaRequeridaDesde.EditValue);
                FechaRequeridaHasta = (this.dtpFechaRequeridaHasta.EditValue==null || this.dtpFechaRequeridaHasta.EditValue.ToString() == "") ? DateTime.Now.AddYears(50) : Convert.ToDateTime(this.dtpFechaRequeridaHasta.EditValue);
                IDClasif1 = (this.slkupClas1.EditValue == null || this.slkupClas1.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.slkupClas1.EditValue);
                IDClasif2 = (this.slkupClas2.EditValue == null || this.slkupClas2.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.slkupClas2.EditValue);
                IDClasif3 = (this.slkupClas3.EditValue == null || this.slkupClas3.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.slkupClas3.EditValue);
                IDClasif4 = (this.slkupClas4.EditValue == null || this.slkupClas4.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.slkupClas4.EditValue);
                IDClasif5 = (this.slkupClas5.EditValue == null || this.slkupClas5.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.slkupClas5.EditValue);
                IDClasif6 = (this.slkupClas6.EditValue == null || this.slkupClas6.EditValue.ToString() == "") ? -1 : Convert.ToInt32(this.slkupClas6.EditValue);
                IDProducto = (this.slkupProducto.EditValue == null || this.slkupProducto.EditValue.ToString() == "") ? -1 : Convert.ToInt64(this.slkupProducto.EditValue);


                _dtSolicitudes = CO.DAC.clsSolicitudCompraDAC.GetSolicitudCompraByProveedor(IDProveedor, IDSolicitudDesde, IDSolicitudHasta, FechaSolicitudDesde, FechaSolicitudHasta, FechaRequeridaDesde, FechaRequeridaHasta, IDClasif1, IDClasif2, IDClasif3, IDClasif4, IDClasif5, IDClasif6, IDProducto).Tables[0];
                this.dtgDetalle.DataSource = null;
                this.dtgDetalle.DataSource = _dtSolicitudes;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
            }
        }


        private void frmImportarSolicitudCompra_Load(object sender, EventArgs e)
        {
            try
            {

                _dtClasif1 = CI.DAC.clsClasificacionDAC.GetData(-1,1,"*").Tables[0];

                this.slkupClas1.Properties.DataSource = _dtClasif1;
                this.slkupClas1.Properties.DisplayMember = "Descr";
                this.slkupClas1.Properties.ValueMember = "IDClasificacion";
                this.slkupClas1.Properties.NullText = " --- ---";
                this.slkupClas1.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupClas1.Properties.Popup += slkup_Popup;
                this.slkupClas1.Properties.PopulateViewColumns();

                _dtClasif2 = CI.DAC.clsClasificacionDAC.GetData(-1, 2, "*").Tables[0];

                this.slkupClas2.Properties.DataSource = _dtClasif2;
                this.slkupClas2.Properties.DisplayMember = "Descr";
                this.slkupClas2.Properties.ValueMember = "IDClasificacion";
                this.slkupClas2.Properties.NullText = " --- ---";
                this.slkupClas2.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupClas2.Properties.Popup += slkup_Popup;
                this.slkupClas2.Properties.PopulateViewColumns();

                _dtClasif3 = CI.DAC.clsClasificacionDAC.GetData(-1, 3, "*").Tables[0];

                this.slkupClas3.Properties.DataSource = _dtClasif3;
                this.slkupClas3.Properties.DisplayMember = "Descr";
                this.slkupClas3.Properties.ValueMember = "IDClasificacion";
                this.slkupClas3.Properties.NullText = " --- ---";
                this.slkupClas3.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupClas3.Properties.Popup += slkup_Popup;
                this.slkupClas3.Properties.PopulateViewColumns();

                _dtClasif4 = CI.DAC.clsClasificacionDAC.GetData(-1, 4, "*").Tables[0];

                this.slkupClas4.Properties.DataSource = _dtClasif4;
                this.slkupClas4.Properties.DisplayMember = "Descr";
                this.slkupClas4.Properties.ValueMember = "IDClasificacion";
                this.slkupClas4.Properties.NullText = " --- ---";
                this.slkupClas4.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupClas4.Properties.Popup += slkup_Popup;
                this.slkupClas4.Properties.PopulateViewColumns();


                _dtClasif5 = CI.DAC.clsClasificacionDAC.GetData(-1, 5, "*").Tables[0];

                this.slkupClas5.Properties.DataSource = _dtClasif5;
                this.slkupClas5.Properties.DisplayMember = "Descr";
                this.slkupClas5.Properties.ValueMember = "IDClasificacion";
                this.slkupClas5.Properties.NullText = " --- ---";
                this.slkupClas5.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupClas5.Properties.Popup += slkup_Popup;
                this.slkupClas5.Properties.PopulateViewColumns();

                _dtClasif6 = CI.DAC.clsClasificacionDAC.GetData(-1, 6, "*").Tables[0];

                this.slkupClas6.Properties.DataSource = _dtClasif6;
                this.slkupClas6.Properties.DisplayMember = "Descr";
                this.slkupClas6.Properties.ValueMember = "IDClasificacion";
                this.slkupClas6.Properties.NullText = " --- ---";
                this.slkupClas6.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupClas6.Properties.Popup += slkup_Popup;
                this.slkupClas6.Properties.PopulateViewColumns();


                _dtProductos = CI.DAC.clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0];

                this.slkupProducto.Properties.DataSource = _dtProductos;
                this.slkupProducto.Properties.DisplayMember = "Descr";
                this.slkupProducto.Properties.ValueMember = "IDProducto";
                this.slkupProducto.Properties.NullText = " --- ---";
                this.slkupProducto.Properties.EditValueChanged += slkup_EditValueChanged;
                this.slkupProducto.Properties.Popup += slkup_Popup;
                this.slkupProducto.Properties.PopulateViewColumns();


                Util.Util.SetDefaultBehaviorControls(this.gridView1, true, this.dtgDetalle, _tituloVentana, this);
                EnlazarEventos();

                PopulateGrid();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridColumn CantOrdenada = view.Columns["CantOrdenada"];
                GridColumn CantPedida = view.Columns["Cantidad"];
    

                decimal vCantOrdenada = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, CantOrdenada));
                decimal vCantPedida = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, CantPedida));


                if (vCantOrdenada > vCantPedida) {
                    e.Valid = false;
                    view.SetColumnError(CantOrdenada, "La cantidad Pedida no puede se mayor a la cantidad ordenada");
                    return; 
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = (GridView)sender;
            if (view == null) return;
            if (e.Column.FieldName == "CantOrdenada")
            {
                view.ClearColumnErrors();
                decimal cellValue = (e.Value.ToString() == "") ? 0 : Convert.ToDecimal(e.Value);
                decimal CantPedida = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "Cantidad"));

                if (cellValue > CantPedida)
                    view.SetColumnError(e.Column, "La cantidad Pedida no puede se mayor a la cantidad ordenada");
                
                //view.SetRowCellValue(e.RowHandle, view.Columns["IDCentro"], _dtTemp.Rows[0]["IDCentro"].ToString());
            }
        }



        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            //e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
            XtraMessageBox.Show("Por favor ingrese un valor correcto", "Importar Solicitud", MessageBoxButtons.OK);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

   
    }
}
