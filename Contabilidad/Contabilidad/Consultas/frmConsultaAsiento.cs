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
using CG.DAC;

namespace CG
{
    public partial class frmConsultaAsiento : DevExpress.XtraEditors.XtraForm
    {
        private DataRow drFila;
        DateTime FechaInicial, FechaFinal;
        Decimal TC = 0;
        String sTipoMoneda="L";
        DataTable dtDetallado = new DataTable();    

        public frmConsultaAsiento(DataRow Fila,DateTime FechaInicial ,DateTime FechaFinal,Decimal pTC)
        {
            InitializeComponent();
            drFila = Fila;
            this.FechaInicial = FechaInicial;
            this.FechaFinal = FechaFinal;
            this.TC = pTC;
        }

        private void  ShowData(){
            try
            {
                this.txtCentroCosto.Text = drFila["Centro"].ToString();
                this.txtDescrCentroCosto.Text = drFila["DescrCentroCosto"].ToString();
                this.txtCuentaContable.Text = drFila["Cuenta"].ToString();
                this.txtDescrCuentaContable.Text = drFila["DescrCuenta"].ToString();

                Util.Util.SetFormatTextEdit(this.txtSaldoInicial, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
                Util.Util.SetFormatTextEdit(this.txtTotalCredito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
                Util.Util.SetFormatTextEdit(this.txtTotalDebito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
                Util.Util.SetFormatTextEdit(this.txtSaldoFinal, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");

                this.txtSaldoInicial.Text = drFila[(sTipoMoneda == "L") ? "SaldoAnteriorLocal" : "SaldoAnteriorDolar"].ToString();
                this.txtTotalCredito.Text = drFila[(sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar"].ToString();
                this.txtTotalDebito.Text = drFila[(sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar"].ToString();
                this.txtSaldoFinal.Text = drFila[(sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar"].ToString();

                Util.Util.SetFormatTextEditGrid(this.txtGridCredito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
                Util.Util.SetFormatTextEditGrid(this.txtGridDebito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
                Util.Util.SetFormatTextEdit(this.txtTotalCredito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
                this.gridView1.Columns[8].FieldName = (sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar";
                this.gridView1.Columns[7].FieldName = (sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar";

                this.txtTC.Text = "$" + this.TC.ToString("N2");

                this.txtDel.Text = this.FechaInicial.ToShortDateString();
                this.txtAl.Text = this.FechaFinal.ToShortDateString();


                int idCentro = Convert.ToInt32(drFila["IDCentro"]);
                int idCuenta = Convert.ToInt32(drFila["IDCuenta"]);


                DataSet DS = new DataSet();

                DS = ConsultasDAC.GetMovimientosByCentroCuenta(idCuenta, idCentro, FechaInicial, FechaFinal);
                dtDetallado = DS.Tables[0];

                this.grid.DataSource = dtDetallado;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


  

        private void frmConsultaSaldoCuentaContable_Load(object sender, EventArgs e)
        {
            ShowData();
        }

         private void CargarDatosSegunMoneda(DataTable dt) {

             Util.Util.SetFormatTextEdit(this.txtSaldoInicial, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
             Util.Util.SetFormatTextEdit(this.txtTotalCredito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
             Util.Util.SetFormatTextEdit(this.txtTotalDebito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
             Util.Util.SetFormatTextEdit(this.txtSaldoFinal, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");

             Util.Util.SetFormatTextEditGrid(this.txtGridCredito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
             Util.Util.SetFormatTextEditGrid(this.txtGridDebito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
            //this.gridView1.Columns[3].FieldName = (sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar";
            this.gridView1.Columns[8].FieldName = (sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar";
            this.gridView1.Columns[7].FieldName = (sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar";
            //this.gridView1.Columns[5].FieldName = (sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar";
            //this.gridView1.RefreshData();

             this.txtSaldoInicial.Text = drFila[(sTipoMoneda == "L") ? "SaldoAnteriorLocal" : "SaldoAnteriorDolar"].ToString();
             this.txtTotalCredito.Text = drFila[(sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar"].ToString();
             this.txtTotalDebito.Text = drFila[(sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar"].ToString();
             this.txtSaldoFinal.Text = drFila[(sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar"].ToString();

        }

        private void btnMonedaDolar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "D";
            CargarDatosSegunMoneda(dtDetallado);
        }

        private void btnMonedaLocal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "L";
            CargarDatosSegunMoneda(dtDetallado);
        }

  
        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstDetalleMovimientoCentroCuenta.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Detalle Movimiento"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}