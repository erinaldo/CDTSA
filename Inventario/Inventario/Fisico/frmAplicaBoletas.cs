using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Security;
using CI.DAC;

namespace CI.Fisico
{
    public partial class frmAplicaBoletas : Form
    {
        int IDBodega;
        long IDTransaccion;
        DateTime Fecha;
        int IDPaquete;
        bool bProductoNoInventariadoSetCero;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";

        public frmAplicaBoletas(int IDBodega, long IDTransaccion)
        {
            InitializeComponent();
            this.IDBodega = IDBodega;
            this.IDPaquete = 11;
            this.IDTransaccion = IDTransaccion;
        }

        private void frmAplicaBoletas_Load(object sender, EventArgs e)
        {
            this.dtpFecha.EditValue = DateTime.Now;
            this.btnAplicar.Click += btnAplicar_Click;
        }

        void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                bProductoNoInventariadoSetCero = Convert.ToBoolean(this.chlProductosNoInventarioSetCero.EditValue);
                Fecha = Convert.ToDateTime(this.dtpFecha.EditValue);

                //Crear el Paquete de Inventario Fiscal 
                ConnectionManager.BeginTran();
                IDTransaccion = clsBoletaInvFisicoDAC.CreaDocumentoInv(IDBodega, IDPaquete, Fecha, bProductoNoInventariadoSetCero, _sUsuario, ConnectionManager.Tran);
                //Aplicacion del Documento
                clsDocumentoInvCabecera.AplicaInventario(IDTransaccion, ConnectionManager.Tran);
                //Creacion del Asiento contable
                clsDocumentoInvCabecera.GeneraAsientoTransaccion(IDTransaccion, _sUsuario, ConnectionManager.Tran);
                ConnectionManager.CommitTran();

                MessageBox.Show("El inventario se ha aplicado correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores:" + ex.Message);
                ConnectionManager.RollBackTran();
            }

        }

  
    }
}
