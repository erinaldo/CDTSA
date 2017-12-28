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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace CG
{
    public partial class frmConsultaSaldoCuenta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable _dtCentroCosto = new DataTable();
        String sTipoMoneda = "L";
        DataTable dtConsolidado = new DataTable();
        DataTable dtDetallado = new DataTable();    

        public frmConsultaSaldoCuenta()
        {
            InitializeComponent();
            this.Load += FrmConsultaSaldoCuenta_Load;
        }

        private void FrmConsultaSaldoCuenta_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime fechatemp = DateTime.Today;

                this.dtDesde.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                if (fechatemp.Month + 1 < 13)
                { this.dtHasta.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1); }
                else
                { this.dtHasta.EditValue = new DateTime(Convert.ToInt32(fechatemp.Year) + 1, 1, 1).AddDays(-1); }



                _dtCentroCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0]; //No estamos tomando los acumuladores

                Util.Util.ConfigLookupEdit(this.slkupCentroCosto, _dtCentroCosto, "Descr", "IDCentro");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroCosto, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                this.slkupCentroCosto.Properties.ShowClearButton = true;
                this.slkupCentroCosto.Properties.PopupFormSize = new Size(400, 300);
                this.slkupCentroCosto.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores : " + ex.Message);
            }
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //Validar los datos
            
            int idCentro =  (this.slkupCentroCosto.EditValue== null) ? -1: Convert.ToInt32( this.slkupCentroCosto.EditValue);

            DataSet DS = new DataSet();
            
            DS = ConsultasDAC.GetSaldosByCentroCuenta(-1, idCentro, Convert.ToDateTime(this.dtDesde.EditValue), Convert.ToDateTime(this.dtHasta.EditValue));
            dtConsolidado = DS.Tables[0];
            dtDetallado = DS.Tables[1];

           

            //this.gridView1.Columns["Debitos"].FieldName = (sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar";
            //this.gridView1.Columns["Creditos"].FieldName =(sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar";
            //this.gridView1.Columns["SaldoInicial"].FieldName = (sTipoMoneda == "L") ? "SaldoAnteriorLocal" : "SaldoAnteriorDolar";
            //this.gridView1.Columns["SaldoLocal"].FieldName = (sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar";

            //if (dtConsolidado.Rows.Count > 0)
            //{
            //    this.txtSaldoInicial.Text = dtConsolidado.Rows[0][(sTipoMoneda=="L")? "SaldoAnteriorLocal" : "SaldoAnteriorDolar"].ToString();
            //    this.txtSaldoFinal.Text = dtConsolidado.Rows[0][(sTipoMoneda=="L")? "SaldoLocal":"SaldoDolar"].ToString();
            //    this.txtTotalCredito.Text = dtConsolidado.Rows[0][(sTipoMoneda=="L")? "CreditoLocal":"CreditoDolar"].ToString();
            //    this.txtTotalDebitos.Text = dtConsolidado.Rows[0][(sTipoMoneda=="L")? "DebitoLocal":"DebitoDolar"].ToString();
            //}
            this.grid.DataSource = dtDetallado;
            CargarDatosSegunMoneda(dtConsolidado);
        }

        private void CargarDatosSegunMoneda(DataTable dt) {
            Util.Util.SetFormatTextEdit(this.txtSaldoInicial, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
            Util.Util.SetFormatTextEdit(this.txtTotalCredito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
            Util.Util.SetFormatTextEdit(this.txtTotalDebitos, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
            Util.Util.SetFormatTextEdit(this.txtSaldoFinal, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");

            Util.Util.SetFormatTextEditGrid(this.txtGridSaldoInicial, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
            Util.Util.SetFormatTextEditGrid(this.txtGridCredito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
            Util.Util.SetFormatTextEditGrid(this.txtGridDebito, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");
            Util.Util.SetFormatTextEditGrid(this.txtGridSaldoFinal, (sTipoMoneda == "L") ? Util.Util.FormatType.MonedaLocal : Util.Util.FormatType.MonedaExtrangera, "");


            this.gridView1.Columns[5].FieldName = (sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar";
            this.gridView1.Columns[6].FieldName = (sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar";
            this.gridView1.Columns[4].FieldName = (sTipoMoneda == "L") ? "SaldoAnteriorLocal" : "SaldoAnteriorDolar";
            this.gridView1.Columns[7].FieldName = (sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar";
            this.gridView1.RefreshData();

            if (dt.Rows.Count > 0)
            {
                this.txtSaldoInicial.Text = dt.Rows[0][(sTipoMoneda == "L") ? "SaldoAnteriorLocal" : "SaldoAnteriorDolar"].ToString();
                this.txtSaldoFinal.Text = dt.Rows[0][(sTipoMoneda == "L") ? "SaldoLocal" : "SaldoDolar"].ToString();
                this.txtTotalCredito.Text = dt.Rows[0][(sTipoMoneda == "L") ? "CreditoLocal" : "CreditoDolar"].ToString();
                this.txtTotalDebitos.Text = dt.Rows[0][(sTipoMoneda == "L") ? "DebitoLocal" : "DebitoDolar"].ToString();
            }
        }

     

        private void btnMonedaLocal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "L";
            CargarDatosSegunMoneda(dtDetallado);
        }

        private void btnMonedaDolar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "D";
            CargarDatosSegunMoneda(dtDetallado);
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstSaldoCuentas.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Saldo Cuenta"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }




        private  void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                DataRow dr = view.GetDataRow(view.GetSelectedRows()[0]);
                frmConsultaAsiento frmConsultaAsiento = new frmConsultaAsiento(dr, Convert.ToDateTime(this.dtDesde.EditValue), Convert.ToDateTime(this.dtHasta.EditValue), Convert.ToDecimal(this.txtTasaCambio.Text));
                frmConsultaAsiento.ShowDialog();
                
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void dtHasta_EditValueChanged(object sender, EventArgs e)
        {
            CargarTipoCambio();  
        }

        private void CargarTipoCambio()
        {
            if (this.dtHasta.EditValue != null)
            {
                DateTime Fecha = Convert.ToDateTime(this.dtHasta.EditValue);
                if (Fecha.Month + 1 < 13)
                { Fecha = new DateTime(Fecha.Year, Fecha.Month + 1, 1).AddDays(-1); }
                else
                { Fecha = new DateTime(Convert.ToInt32(Fecha.Year) + 1, 1, 1).AddDays(-1); }

                double TipoCambio = TipoCambioDetalleDAC.GetLastTipoCambioFecha(Fecha);
                this.txtTasaCambio.Text = TipoCambio.ToString();
            }
        }
     
    }
}