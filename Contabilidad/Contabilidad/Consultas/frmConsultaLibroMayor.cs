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
    public partial class frmConsultaLibroMayor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable _dtCuenta = new DataTable();
        String sTipoMoneda = "L";
        
        DataTable dtDetallado = new DataTable();  


        public frmConsultaLibroMayor()
        {
            InitializeComponent();
            this.Load += frmConsultaLibroMayor_Load;
        }

        void frmConsultaLibroMayor_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime fechatemp = DateTime.Today;
                this.dtpFechaInicial.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                this.dtpFechaFinal.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);


                _dtCuenta = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, -1).Tables[0];

                this.chkComboCuenta.Properties.DataSource = _dtCuenta;
                this.chkComboCuenta.Properties.DisplayMember = "Descr";
                this.chkComboCuenta.Properties.ValueMember = "IDCuenta";
                this.chkComboCuenta.Properties.SeparatorChar = '|';
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstConsultaLibroMayor.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Consultas Libro Mayor"
            };


            this.gridView.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void btnMonedaDolar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "S";
            CargarDatosSegunMoneda(dtDetallado);
        }

        private void btnMonedaLocal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "L";
            CargarDatosSegunMoneda(dtDetallado);
        }

  

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String  sCuenta = (this.chkComboCuenta.EditValue == null) ? "" : this.chkComboCuenta.EditValue.ToString();
            bool bEsDeMayor = Convert.ToBoolean(this.chkCuentasMayor.EditValue);

            DataSet DS = new DataSet();
           // this.chkComboCuenta.EditValue;
            String[] lstCuenta = sCuenta.Split('|');
            DataTable dt = new DataTable();
            dt.Columns.Add("IDCuenta", typeof(int));
            if (sCuenta != "")
            {
                foreach (string ele in lstCuenta)
                {
                    dt.Rows.Add(Convert.ToUInt32(ele));
                }
            }

            DS = ConsultasDAC.ConsultaLibroMayor((bEsDeMayor) ? 1: 0 ,Convert.ToDateTime(this.dtpFechaInicial.EditValue), Convert.ToDateTime(this.dtpFechaFinal.EditValue),dt);
            dtDetallado = DS.Tables[0];



            this.gridView.Columns[5].FieldName = (sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar";
            this.gridView.Columns[6].FieldName =(sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar";
            this.gridView.Columns[4].FieldName = (sTipoMoneda == "L") ? "SaldoAnteriorLocal" : "SaldoAnteriorDolar";
            this.gridView.Columns[7].FieldName = (sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar";

           
            this.grid.DataSource = dtDetallado;
            this.gridView.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void CargarDatosSegunMoneda(DataTable dt)
        {
            this.gridView.Columns[5].FieldName = (sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar";
            this.gridView.Columns[6].FieldName = (sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar";
            this.gridView.Columns[4].FieldName = (sTipoMoneda == "L") ? "SaldoAnteriorLocal" : "SaldoAnteriorDolar";
            this.gridView.Columns[7].FieldName = (sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar";


        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}