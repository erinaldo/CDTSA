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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarUsuario())
            {
                //Validar privilegios del usuario
                DataSet DSUsuario = new DataSet();
                DataTable DT = new DataTable();
                DSUsuario = UsuarioDAC.GetAccionModuloFromRole(0, UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString());
                DT = DSUsuario.Tables[0];
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosType.AccesoAlSistema, DT))
                {
                    MainMenu.frmMain ofrmMain = new MainMenu.frmMain();
                    ofrmMain.Show();
                }
                else MessageBox.Show("Usted no tiene privilegios para acceder al modulo");
            }
            else {
                MessageBox.Show("Las credenciales utilizadas no son validas, por favor verifique");
            }
        }
    }
}