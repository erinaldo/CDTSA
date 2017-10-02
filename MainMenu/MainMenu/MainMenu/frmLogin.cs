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
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace CDTSA
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           Thread.Sleep(1500); 
           if (SplashScreenManager.Default != null) {
               splash ofrm = new splash();
               Form frm = (Form)ofrm;
	            if (frm != null) {
		            if (SplashScreenManager.FormInPendingState) {
			            SplashScreenManager.CloseForm();
		            } else {
			            SplashScreenManager.CloseForm(false, 100, frm);
		            }
	            } else {
		            SplashScreenManager.CloseForm();
	            }
            }
        
        }

        private bool ValidarUsuario() {
            DataSet DS = new DataSet();
            DS= UsuarioDAC.ValidaUsuario(this.txtUsuario.EditValue.ToString(), this.txtPass.EditValue.ToString());
            if (DS.Tables[0].Rows.Count > 0)
            {
                UsuarioDAC.SetDataSetUsuario(DS);
                return true;
            }
            else return false;
        }

        private bool ValidarDatos() { 
            String sMensaje = "";
            if (this.cmbCompania.SelectedIndex == -1)
                sMensaje = sMensaje + "  •   Seleccione la compañia./n/r";
            if (this.txtUsuario.Text == "")
                sMensaje = sMensaje + " •  Ingrese el usuario./n/r";
            if (this.txtPass.Text == "")
                sMensaje = sMensaje + " •   Ingrese la Contraseña./n/r";
            if (sMensaje != ""){
                MessageBox.Show("Por favor verifique los siguiente datos: /n/r" + sMensaje);
                return false;
            }else
                return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que ingresen los datos
                if (!ValidarDatos())
                    return;

                if (ValidarUsuario())
                {
                    //Validar privilegios del usuario
                    DataSet DSUsuario = new DataSet();
                    DataTable DT = new DataTable();
                    DSUsuario = UsuarioDAC.GetAccionModuloFromRole(0, UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString());
                    DT = DSUsuario.Tables[0];
                    if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosGeneralesType.AccesoAlSistema, DT))
                    {
                        this.Hide();
                        MainMenu.frmMain ofrmMain = new MainMenu.frmMain();
                        ofrmMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene privilegios para acceder al módulo");
                        this.txtUsuario.Focus();
                    };
                }
                else
                {
                    MessageBox.Show("Las credenciales utilizadas no son validas, por favor verifique");
                    this.txtUsuario.Focus();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores: \n\r" + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtPass.Focus();
            }
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnAceptar.Focus();
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            this.txtUsuario.SelectAll();
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            this.txtPass.SelectAll();
        }

        private void cmbCompania_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCompania.SelectedIndex > -1)
            {
                Security.Esquema.Compania = this.cmbCompania.SelectedItem.ToString();
            }
        }
    }
}