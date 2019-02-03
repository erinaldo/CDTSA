using DevExpress.XtraEditors;
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
    public partial class frmArticuloProveedor : Form
    {
        int IDProveedor;
        long IDArticulo;

        int IDPaisManoFactura;
        decimal LoteMinCompra,PesoMinCompra;
        String Notas;

        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        DataTable dtProductos = new DataTable();
        DataTable dtPais = new DataTable();
        bool NotClosing = false;
        
        private string Accion = "Add";

       

      
       
        public frmArticuloProveedor()
        {
            InitializeComponent();
            this.Accion = "Add";
            
            InicializarNuevoElement();
        }

        public frmArticuloProveedor(int IDProveedor,long IDArticulo, String Accion,bool NotClosing =false)
        {
            InitializeComponent();
            
            this.IDProveedor = IDProveedor;
            this.IDArticulo = IDArticulo;
            this.Accion = Accion;
            this.NotClosing = NotClosing;
        }


        private void InicializarNuevoElement()
        {
            this.slkupProducto.EditValue = null;
            this.slkupPaisManofactura.EditValue = null;
            this.txtLoteMinimoCompra.EditValue = null;
            this.txtNotas.EditValue = "";
            this.txtPesoMinimoCompra.EditValue = null;
            
        }

        private void HabilitarBotoneriaPrincipal() { 
            
            if (Accion=="Add" || Accion=="Edit"){
                this.btnAceptar.Enabled = true;

            }
            else if (Accion == "View" || Accion == "ReadOnly")
            {
                this.btnAceptar.Enabled = false;
            }
            
        }

        private void HabilitarControles() {
            this.slkupProducto.ReadOnly = (Accion == "Add")? false:true;
            
            if (Accion == "Add" || Accion == "Edit")
            {
                this.slkupPaisManofactura.ReadOnly = false;
                this.txtLoteMinimoCompra.ReadOnly = false;
                this.txtPesoMinimoCompra.ReadOnly=false;
                this.txtNotas.ReadOnly = false;
                
            }
            else
            {
                this.slkupPaisManofactura.ReadOnly = true;
                this.txtLoteMinimoCompra.ReadOnly = true;
                this.txtPesoMinimoCompra.ReadOnly = true;
                this.txtNotas.ReadOnly = true;
            }

            
        }

        private void UpdateControlsFromData(DataTable dt) {
            DataRow dtProductos = dt.Rows[0];
            this.slkupProducto.EditValue = Convert.ToInt64(dtProductos["IDProducto"]);
            this.slkupPaisManofactura.EditValue = Convert.ToInt32(dtProductos["IDPaisManofactura"]);
            this.txtLoteMinimoCompra.EditValue = Convert.ToDecimal(dtProductos["LoteMinCompra"]);
            this.txtPesoMinimoCompra.EditValue = Convert.ToDecimal(dtProductos["PesoMinimoCompra"]);
            this.txtNotas.EditValue = dtProductos["Notas"].ToString(); ;
            
        }

        private void CargarProducto() {
            DataTable dtSolicitud = DAC.clsArticuloProveedorDAC.Get(IDArticulo,IDProveedor).Tables[0];
            UpdateControlsFromData(dtSolicitud);
            
        }

      
        private void LoadData()
        {
            try
            {
                HabilitarControles();
                HabilitarBotoneriaPrincipal();
                if (this.NotClosing)
                    this.btnCancelar.Enabled = false;
                if (Accion == "Add")
                {
                    this.slkupPaisManofactura.Focus();
                    if (this.IDArticulo != -1 && this.IDArticulo.ToString() != "") {
                        this.slkupProducto.EditValue = this.IDArticulo;
                    }
                }
                else                              
                {
                    CargarProducto();
                }

                
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmArticuloProveedor_Load(object sender, EventArgs e)
        {
            if (Accion=="Edit" || Accion=="View")             
                dtProductos = CI.DAC.clsProductoDAC.GetProductoByID(this.IDArticulo,"*").Tables[0];
            else
                dtProductos = CO.DAC.clsArticuloProveedorDAC.GetProductosSinAsociar(this.IDProveedor, -1, -1, -1, -1, -1, -1).Tables[0];

            this.slkupProducto.Properties.DataSource = dtProductos;
            this.slkupProducto.Properties.DisplayMember = "Descr";
            this.slkupProducto.Properties.ValueMember = "IDProducto";
            this.slkupProducto.Properties.NullText = " --- ---";
            this.slkupProducto.Properties.EditValueChanged += slkup_EditValueChanged;
            this.slkupProducto.Properties.Popup += slkup_Popup;
            this.slkupProducto.Properties.PopulateViewColumns();

            dtPais = CO.DAC.clsGlobalPaisDAC.Get(-1).Tables[0];
            this.slkupPaisManofactura.Properties.DataSource = dtPais;
            this.slkupPaisManofactura.Properties.DisplayMember = "Descr";
            this.slkupPaisManofactura.Properties.ValueMember = "IDPais";
            this.slkupPaisManofactura.Properties.NullText = " --- ---";
            this.slkupPaisManofactura.Properties.EditValueChanged += slkup_EditValueChanged;
            this.slkupPaisManofactura.Properties.Popup += slkup_Popup;
            this.slkupPaisManofactura.Properties.PopulateViewColumns();


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

      
        private bool ValidarDatos() { 
            String sMensaje = "";
            bool Resultado = true;
            if (this.slkupProducto.EditValue.ToString() == "")
                sMensaje = "   • Producto \r\n";
            if (this.slkupPaisManofactura.EditValue.ToString() == "")
                sMensaje = sMensaje +  "    • Pais de Manofactura \n\r";
            if (this.txtLoteMinimoCompra.Text == "")
                sMensaje = sMensaje + "   • Lote Mínimo de Compra \n\r";
            if (this.txtPesoMinimoCompra.Text == "")
                sMensaje = sMensaje + "   • Peso Mínimo de Compra \n\r";
            if (this.txtNotas.Text == "")
                sMensaje = sMensaje + "   • Notas de Compra \n\r";
            
            if (sMensaje != "") {
                MessageBox.Show("Han ocurrido los siguientes errores por favor verifique los campos: \n\r " + sMensaje);
                Resultado = false;
            }
            return Resultado;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    IDArticulo = Convert.ToInt32(this.slkupProducto.EditValue);
                    IDPaisManoFactura = Convert.ToInt32(this.slkupPaisManofactura.EditValue);
                    LoteMinCompra = Convert.ToDecimal(this.txtLoteMinimoCompra.EditValue);
                    PesoMinCompra = Convert.ToDecimal(this.txtPesoMinimoCompra.EditValue);
                    Notas = this.txtNotas.EditValue.ToString();

                    ConnectionManager.BeginTran();

                    if (Accion == "Add")
                    {
                        //Ingresar la cabecera de la solicitud
                        DAC.clsArticuloProveedorDAC.InsertUpdate("I", IDArticulo, IDProveedor, IDPaisManoFactura, LoteMinCompra, PesoMinCompra,Notas, DateTime.Now, sUsuario, ConnectionManager.Tran);
                    }

                    if (Accion == "Edit")
                    {
                        DAC.clsArticuloProveedorDAC.InsertUpdate("U", IDArticulo, IDProveedor, IDPaisManoFactura, LoteMinCompra, PesoMinCompra,Notas, DateTime.Now, sUsuario, ConnectionManager.Tran);
                    }

                    ConnectionManager.CommitTran();
                    this.Accion = "Edit";
                    HabilitarControles();
                    HabilitarBotoneriaPrincipal();
                    MessageBox.Show("El producto se ha asociado correctamente al proveedor");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                ConnectionManager.RollBackTran();
                MessageBox.Show("Han ocurrido los siguiente errores: " + ex.Message);
            }

        }

        private void frmArticuloProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.NotClosing &&  this.DialogResult!= System.Windows.Forms.DialogResult.OK) {
                e.Cancel = true;
            } 
        }

        

        
    }
}
                            