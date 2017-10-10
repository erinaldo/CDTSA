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

namespace CG
{
    public partial class frmCerrarPeriodo : DevExpress.XtraEditors.XtraForm
    {
        public frmCerrarPeriodo()
        {
            InitializeComponent();
        }

        private void frmCerrarPeriodo_Load(object sender, EventArgs e)
        {
            DataTable dtPeriodo = PeriodoContableDAC.GetPeriodoContableACerrar();
            this.txtEjercicio.Text = dtPeriodo.Rows[0]["IDEjercicio"].ToString();
            this.txtPeriodo.Text = dtPeriodo.Rows[0]["Periodo"].ToString();
            this.txtFecha.Text = dtPeriodo.Rows[0]["FechaFinal"].ToString();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desar cerrar el periodo contable " + txtPeriodo.Text.Trim(), "Cierre de Mes", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) { 
                //correr el proceso de cierre
                try
                {
                    PeriodoContableDAC.CierraPeriodoContable(Convert.ToInt32(this.txtEjercicio.Text.Trim()), this.txtPeriodo.Text.Trim());
                    MessageBox.Show("El periodo ha sido cerrado satisfactoriamente");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}