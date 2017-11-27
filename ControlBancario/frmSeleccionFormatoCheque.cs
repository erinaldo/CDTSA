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

namespace ControlBancario
{
    public partial class frmSeleccionFormatoCheque : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtFormatos = new DataTable();
        public int IDFormato { get; set; }
        public frmSeleccionFormatoCheque(DataTable dtFormatos)
        {
            InitializeComponent();
            this.dtFormatos = dtFormatos;
        }

        private void frmSeleccionFormatoCheque_Load(object sender, EventArgs e)
        {
            this.slkupReportes.Properties.DataSource = dtFormatos;

            slkupReportes.Properties.DisplayMember = "FormatoCheque";

            slkupReportes.Properties.ValueMember = "IDFormato";
 

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            String sMensaje = "";
            if (this.slkupReportes.EditValue == null || this.slkupReportes.EditValue.ToString() == "") {
                sMensaje = sMensaje + " • Por favor seleccione el formato del reporte.";
            }
            if (sMensaje !=""){
                MessageBox.Show("Han ocurrido los siguientes errores: " + sMensaje);
                return;
            }
             
            this.IDFormato =  Convert.ToInt32(this.slkupReportes.EditValue);
            this.Close();
        }
    }
}