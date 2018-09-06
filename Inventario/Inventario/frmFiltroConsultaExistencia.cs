using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CI.DAC;
using DevExpress.XtraEditors.Controls;

namespace CI
{
    public partial class frmFiltroConsultaExistencia : Form
    {
        public DataTable DTProducto = new DataTable();
        public DataTable DTLote = new DataTable();
        public DataTable DTBodega = new DataTable();
        public DataTable DTClasif1 = new DataTable();
        public DataTable DTClasif2 = new DataTable();
        public DataTable DTClasif3 = new DataTable();
        public DataTable DTClasif4 = new DataTable();
        public DataTable DTClasif5 = new DataTable();
        public DataTable DTClasif6 = new DataTable();
       
        public frmFiltroConsultaExistencia()
        {
            InitializeComponent();
        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmFiltroConsultaExistencia_Load(object sender, EventArgs e)
        {

            DTProducto = clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0];
            this.chkBoxProducto.Properties.DataSource = DTProducto;
            this.chkBoxProducto.Properties.DisplayMember = "Descr";
            this.chkBoxProducto.Properties.ValueMember = "IDProducto";
            this.chkBoxProducto.Properties.IncrementalSearch = true;

            DTLote = clsLoteDAC.GetData(-1,-1,"*","*").Tables[0];
            this.chkBoxLote.Properties.DataSource = DTLote;
            this.chkBoxLote.Properties.DisplayMember = "LoteProveedor";
            this.chkBoxLote.Properties.ValueMember = "IDLote";
            this.chkBoxLote.Properties.IncrementalSearch = true;

            DTBodega = clsBodegaDAC.GetData(-1,"*",-1).Tables[0];
            this.chkBoxBodega.Properties.DataSource = DTBodega;
            this.chkBoxBodega.Properties.DisplayMember = "Descr";
            this.chkBoxBodega.Properties.ValueMember = "IDBodega";
            this.chkBoxBodega.Properties.IncrementalSearch = true;

            DTClasif1 = clsClasificacionDAC.GetData(-1,1,"*").Tables[0];
            this.chkBoxClasif1.Properties.DataSource = DTClasif1;
            this.chkBoxClasif1.Properties.DisplayMember = "Descr";
            this.chkBoxClasif1.Properties.ValueMember = "IDClasificacion";
            this.chkBoxClasif1.Properties.IncrementalSearch = true;

            DTClasif2 = clsClasificacionDAC.GetData(-1, 2, "*").Tables[0];
            this.chkBoxClasif2.Properties.DataSource = DTClasif2;
            this.chkBoxClasif2.Properties.DisplayMember = "Descr";
            this.chkBoxClasif2.Properties.ValueMember = "IDClasificacion";
            this.chkBoxClasif2.Properties.IncrementalSearch = true;

            DTClasif3 = clsClasificacionDAC.GetData(-1, 3, "*").Tables[0];
            this.chkBoxClasif3.Properties.DataSource = DTClasif3;
            this.chkBoxClasif3.Properties.DisplayMember = "Descr";
            this.chkBoxClasif3.Properties.ValueMember = "IDClasificacion";
            this.chkBoxClasif3.Properties.IncrementalSearch = true;

            DTClasif4 = clsClasificacionDAC.GetData(-1, 4, "*").Tables[0];
            this.chkBoxClasif4.Properties.DataSource = DTClasif4;
            this.chkBoxClasif4.Properties.DisplayMember = "Descr";
            this.chkBoxClasif4.Properties.ValueMember = "IDClasificacion";
            this.chkBoxClasif4.Properties.IncrementalSearch = true;

            DTClasif5 = clsClasificacionDAC.GetData(-1, 5, "*").Tables[0];
            this.chkBoxClasif5.Properties.DataSource = DTClasif5;
            this.chkBoxClasif5.Properties.DisplayMember = "Descr";
            this.chkBoxClasif5.Properties.ValueMember = "IDClasificacion";
            this.chkBoxClasif5.Properties.IncrementalSearch = true;

            DTClasif6 = clsClasificacionDAC.GetData(-1, 6, "*").Tables[0];
            this.chkBoxClasif6.Properties.DataSource = DTClasif6;
            this.chkBoxClasif6.Properties.DisplayMember = "Descr";
            this.chkBoxClasif6.Properties.ValueMember = "IDClasificacion";
            this.chkBoxClasif6.Properties.IncrementalSearch = true;

           
        }

      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            object lista =  this.chkBoxProducto.Properties.GetCheckedItems();
            object s = this.chkBoxProducto.Properties.Items.GetCheckedValues();
            
            
                        

        }



        private void chkAllClasificacion1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion1.Checked == true)
                this.chkBoxClasif1.Enabled = false;
            else
                this.chkBoxClasif1.Enabled = true;
        }

        private void chkAllProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllProducto.Checked == true)
                this.chkBoxProducto.Enabled = false;
            else
                this.chkBoxProducto.Enabled = true;
        }

        private void chkAllLote_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllLote.Checked == true)
                this.chkBoxLote.Enabled = false;
            else
                this.chkBoxLote.Enabled = true;
        }

        private void chkAllBodega_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllBodega.Checked == true)
                this.chkBoxBodega.Enabled = false;
            else
                this.chkBoxBodega.Enabled = true;
        }

        private void chkAllClasificacion2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion2.Checked == true)
                this.chkBoxClasif2.Enabled = false;
            else
                this.chkBoxClasif2.Enabled = true;
        }

        private void chkAllClasificacion3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion3.Checked == true)
                this.chkBoxClasif3.Enabled = false;
            else
                this.chkBoxClasif3.Enabled = true;
        }

        private void chkAllClasificacion4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion4.Checked == true)
                this.chkBoxClasif4.Enabled = false;
            else
                this.chkBoxClasif4.Enabled = true;
        }

        private void chkAllClasif5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasif5.Checked == true)
                this.chkBoxClasif5.Enabled = false;
            else
                this.chkBoxClasif5.Enabled = true;
        }

        private void chkAllClasif6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasif6.Checked == true)
                this.chkBoxClasif6.Enabled = false;
            else
                this.chkBoxClasif6.Enabled = true;
        }

      
    }
}
