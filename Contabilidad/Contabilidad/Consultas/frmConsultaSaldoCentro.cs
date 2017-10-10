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
    public partial class frmConsultaSaldoCentro : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable _dtCuenta = new DataTable();
        String sTipoMoneda = "L";
        DataTable dtConsolidado = new DataTable();
        DataTable dtDetallado = new DataTable();  

        public frmConsultaSaldoCentro()
        {
            InitializeComponent();
            this.Load += FrmConsultaSaldoCentro_Load;
        }

        private void FrmConsultaSaldoCentro_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime fechatemp = DateTime.Today;
                this.dtpFechaInicial.EditValue = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                this.dtpFechaFinal.EditValue = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);


                _dtCuenta = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, -1).Tables[0];

                Util.Util.ConfigLookupEdit(this.slkupCuenta, _dtCuenta, "Descr", "IDCuenta");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuenta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                this.slkupCuenta.Properties.ShowClearButton = true;
                this.slkupCuenta.Properties.PopupFormSize = new Size(400, 300);
                this.slkupCuenta.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int idCuenta = (this.slkupCuenta.EditValue == null) ? -1 : Convert.ToInt32(this.slkupCuenta.EditValue);

            DataSet DS = new DataSet();
            
            DS = ConsultasDAC.GetSaldosByCentroCuenta(idCuenta, -1, Convert.ToDateTime(this.dtpFechaInicial.EditValue), Convert.ToDateTime(this.dtpFechaFinal.EditValue));
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
            this.gridView1.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void CargarDatosSegunMoneda(DataTable dt)
        {
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

        private void btnMonedaLoca_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "L";
            CargarDatosSegunMoneda(dtDetallado);
        }

        private void bntMonedaDolar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sTipoMoneda = "D";
            CargarDatosSegunMoneda(dtDetallado);
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstSaldoCentro.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Saldo Centro Costo"
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

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView1.SelectedRowsCount > 0) {
                DataRow dr = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                frmConsultaAsiento frmConsultaAsiento = new frmConsultaAsiento(dr, Convert.ToDateTime(this.dtpFechaInicial.EditValue), Convert.ToDateTime(this.dtpFechaFinal.EditValue),Convert.ToDecimal(this.txtTipoCambio.Text));
                frmConsultaAsiento.ShowDialog();
            }
        }

    private  void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                DataRow dr = view.GetDataRow(view.GetSelectedRows()[0]);
                frmConsultaAsiento frmConsultaAsiento = new frmConsultaAsiento(dr, Convert.ToDateTime(this.dtpFechaInicial.EditValue), Convert.ToDateTime(this.dtpFechaFinal.EditValue),Convert.ToDecimal(this.txtTipoCambio.Text));
                frmConsultaAsiento.ShowDialog();
                
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }



        private void dtpFechaFinal_EditValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFechaInicial.EditValue != null)
            {
                DateTime Fecha = Convert.ToDateTime(this.dtpFechaFinal.EditValue);
                Fecha = new DateTime(Fecha.Year, Fecha.Month + 1, 1).AddDays(-1);
                double TipoCambio = TipoCambioDetalleDAC.GetLastTipoCambioFecha(Fecha);
                this.txtTipoCambio.Text = TipoCambio.ToString();
            }
        }
    
    }
}