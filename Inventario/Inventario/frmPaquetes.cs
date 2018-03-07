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

namespace CI
{
    public partial class frmPaquetes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtPaquete;
        private DataSet _dsPaquete;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Paquetes";
        private bool isEdition = false;

        public frmPaquetes()
        {
            InitializeComponent();
        }
    }
}