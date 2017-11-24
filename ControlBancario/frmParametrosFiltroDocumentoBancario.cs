using ControlBancario.DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControlBancario
{
    public partial class frmParametrosFiltroDocumentoBancario : Form
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Anulado { get; set; }
        public int IdTipo { get; set; }
        public int IdSubTipo { get; set; }
        public int IdRuc { get; set; }
        public String NombreRuc { get; set; }
        public String AliasRuc { get; set; }
        public String PagaderaA { get; set; }
        public String Referencia { get; set; }
        public String ConceptoContable { get; set; }


        public frmParametrosFiltroDocumentoBancario()
        {
            InitializeComponent();
            this.Load += frmParametrosFiltroDocumentoBancario_Load;
        }

        public  frmParametrosFiltroDocumentoBancario(DateTime FechaInicial, DateTime FechaFinal, int Anulado, int IdTipo, int IDSubTipo, int IdRuc, String NombreRuc, String AliasRuc, String PagaderoA, String Referencia, String ConceptoContable)
        {
            InitializeComponent();
            this.FechaInicial = FechaInicial;
            this.FechaFinal = FechaFinal;
            this.Anulado = Anulado;
            this.IdSubTipo= IDSubTipo;
            this.IdTipo =IdTipo;
            this.IdRuc = IdRuc;
            this.NombreRuc = NombreRuc;
            this.AliasRuc = AliasRuc;
            this.PagaderaA = PagaderoA;
            this.Referencia = Referencia;
            this.ConceptoContable = ConceptoContable;
            this.Load += frmParametrosFiltroDocumentoBancario_Load;
            
            
        }
        void frmParametrosFiltroDocumentoBancario_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                //Inicializar Fechas
                this.dtpFechaInicial.EditValue = DateTime.Now.AddDays(-15);
                this.dtpFechaFinal.EditValue = DateTime.Now;

                CargarCatalogos();

                ActualizarEstados();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCatalogos()
        {
            this.slkupTipoDocumento.Properties.DataSource = TipoDocumentoDAC.GetData(-1).Tables[0];
            this.slkupTipoDocumento.Properties.ValueMember = "IDTipo";
            this.slkupTipoDocumento.Properties.DisplayMember = "Descr";

            this.slkSubTipoDocumento.Properties.DataSource =SubTipoDocumentoDAC.GetData(-1,-1).Tables[0];
            this.slkSubTipoDocumento.Properties.ValueMember = "IDTipo";
            this.slkSubTipoDocumento.Properties.DisplayMember = "Descr";

            this.slkupRuc.Properties.DataSource = RucDAC.GetData(-1).Tables[0];
            this.slkupRuc.Properties.ValueMember = "IDRuc";
            this.slkupRuc.Properties.DisplayMember = "Descr";
        }


        private void ActualizarEstados()
        {
            this.dtpFechaInicial.EditValue = this.FechaInicial;
            this.dtpFechaFinal.EditValue = this.FechaFinal;
            this.chkAnulado.EditValue = this.Anulado;
            this.slkupTipoDocumento.EditValue = this.IdTipo;
            this.slkSubTipoDocumento.EditValue = this.IdSubTipo;
            this.slkupRuc.EditValue = this.IdRuc;
            this.txtNombreRuc.EditValue = this.NombreRuc;
            this.txtAliasRuc.EditValue = this.AliasRuc;
            this.txtPagaderoA.EditValue = this.PagaderaA;
            this.txtReferencia.EditValue = this.Referencia;
            this.txtConceptoContable.EditValue = this.ConceptoContable;
            
        }


        private void ObtenerFiltro()
        {
            this.FechaInicial = (DateTime)this.dtpFechaInicial.EditValue;
            this.FechaFinal = (DateTime)this.dtpFechaFinal.EditValue;

            this.Anulado = Convert.ToInt32(this.chkAnulado.EditValue);
            this.IdTipo = Convert.ToInt32((this.slkupTipoDocumento.EditValue)==null? -1 :this.slkupTipoDocumento.EditValue);
            this.IdSubTipo = Convert.ToInt32((this.slkSubTipoDocumento.EditValue == null) ? -1 : this.slkSubTipoDocumento.EditValue);
            this.IdRuc = Convert.ToInt32((this.slkupRuc.EditValue == null) ? -1 : this.slkupRuc.EditValue);
            this.NombreRuc = this.txtNombreRuc.EditValue.ToString();
            this.AliasRuc = this.txtAliasRuc.EditValue.ToString();
            this.PagaderaA = this.txtPagaderoA.EditValue.ToString();
            this.Referencia = this.txtReferencia.EditValue.ToString();
            this.ConceptoContable = this.txtConceptoContable.EditValue.ToString();

            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ObtenerFiltro();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
