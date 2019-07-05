using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Grid;
using CO.DAC;

namespace CO
{
    public partial class frmImportFromExcel : Form
    {
        public DataTable dtDetalleOrden = new DataTable();
        DataTable dtProductos = new DataTable();
        DataRow _currentRowDetalle ;
        public bool IsResult = false; 
        int IDProveedor;

        public frmImportFromExcel(int IDProveedor)
        {
            InitializeComponent();
            this.IDProveedor = IDProveedor;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    this.txtFileName.Text = filePath;

                    //Read the contents of the file into a stream
                    LoadData(filePath);
                    //var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }

        }

        private void LoadData(String Ruta)
        {

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@Ruta);

            Excel._Worksheet xlWorkSheet = xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            int Rows, Cols = 0;
            Rows = xlRange.Rows.Count;
            Cols = xlRange.Columns.Count;

            List<clsDetalleOrden> oLstDetalle = new List<clsDetalleOrden>();

            try
            {

                for (int i = 1; i <= Rows; i++)
                {
                    clsDetalleOrden oDetalle = new clsDetalleOrden();
                    for (int j = 1; j <= Cols; j++)
                    {
                        Object valor = xlRange.Cells[i, j].Value2;

                        if (i == 2)
                        {
                            //Validar Los datos
                            if (j == 1) //Codigo de Producto
                            {
                                if (valor.GetType() != typeof(double))
                                {
                                    MessageBox.Show("Error en codigo de producto, por favor verifique, el dato debe de ser numérico");
                                    return;
                                }
                                oDetalle.Codigo = Convert.ToInt32(valor);
                            }

                            if (j == 3)
                            {
                                if (valor.GetType() != typeof(double))
                                {
                                    MessageBox.Show("Error en Cantidad de producto, por favor verifique, el dato debe de ser numérico");
                                    return;
                                }
                                oDetalle.Cantidad = Convert.ToInt32(valor);
                            }

                            if (j == 4)
                            {
                                if (valor.GetType() != typeof(double))
                                {
                                    MessageBox.Show("Error en Precio de producto, por favor verifique, el dato debe de ser numérico");
                                    return;
                                }
                                oDetalle.Precio = Convert.ToDecimal(valor);
                            }

                            if (j == 5)
                            {
                                if (valor != null)
                                {
                                    if (valor.GetType() != typeof(double))
                                    {
                                        MessageBox.Show("Error en Impuesto de producto, por favor verifique, el dato debe de ser numérico");
                                        return;
                                    }
                                }
                                oDetalle.Impuesto = Convert.ToDecimal((valor == null) ? 0 : valor);
                            }

                            if (j == 6)
                            {
                                if (valor != null)
                                {
                                    if (valor.GetType() != typeof(double))
                                    {
                                        MessageBox.Show("Error en Descuento de producto, por favor verifique, el dato debe de ser numérico");
                                        return;
                                    }
                                }

                                oDetalle.Descuento = Convert.ToDecimal((valor == null) ? 0 : valor);
                            }

                            if (j == 7)
                            {
                                if (valor != null)
                                {
                                    if (valor.GetType() != typeof(double))
                                    {
                                        MessageBox.Show("Error en Porc Descuento de producto, por favor verifique, el dato debe de ser numérico");
                                        return;
                                    }
                                }
                                oDetalle.PorcDesc = Convert.ToDecimal((valor == null) ? 0 : valor);
                            }

                            if (j == 8)
                            {
                                oDetalle.Comentario = Convert.ToString((valor == null) ? "" : valor.ToString());
                            }
                        }


                    }
                    if (i > 1) oLstDetalle.Add(oDetalle);
                }

                this.dtDetalleOrden.Clear();

                foreach (clsDetalleOrden fila in oLstDetalle)
                {
                    DataRow nuevaFila = this.dtDetalleOrden.NewRow();
                    nuevaFila["IDProducto"] = fila.Codigo;
                    //nuevaFila["DescrProducto"] = "";
                    nuevaFila["Cantidad"] = fila.Cantidad;
                    nuevaFila["IsLoadFromSolicitud"] = 0;
                    nuevaFila["PrecioUnitario"] = fila.Precio;
                    nuevaFila["MontoDesc"] = fila.Descuento;
                    nuevaFila["PorcDesc"] = fila.PorcDesc;
                    nuevaFila["Comentario"] = fila.Comentario;
                    this.dtDetalleOrden.Rows.InsertAt(nuevaFila, 0);
                    //this.dtDetalleOrden.Rows.Add(fila);
                }

                ValidarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrienron los siguientes erorres por favor verifique", ex.Message);
            }
            finally
            {
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorkSheet);

                xlWorkBook.Close();
                Marshal.ReleaseComObject(xlWorkBook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private void ValidarDatos() {
            foreach (DataRow fila in dtDetalleOrden.Rows) { 
                //Validar si el producto esta asociado 
                long IDProducto = Convert.ToInt64(fila["IDProducto"]);

                DataTable dt = clsArticuloProveedorDAC.Get(IDProducto, IDProveedor).Tables[0];

                if (dt.Rows.Count == 0)
                {
                    ////mostrar el mensaje de asocicion
                    //frmArticuloProveedor ofrmArticuloProveedor = new frmArticuloProveedor(IDProveedor, IDProducto, "Add", true);
                    //ofrmArticuloProveedor.ShowDialog();
                    fila["Status"] = 1;
                    fila["DescrStatus"] = "Tiene que asociar el producto";
                }
                else {
                    fila["Status"] = 0;
                    fila["DescrStatus"] = "";
                }

                this.dtgDetalle.DataSource = null;
                this.dtgDetalle.DataSource = dtDetalleOrden;
            }
        }



        private void fmrImportFromExcel_Load(object sender, EventArgs e)
        {
            dtDetalleOrden = DAC.clsOrdenCompraDetalleDAC.GetEmptyImportExcel().Tables[0];
                     

            this.dtgDetalle.DataSource = dtDetalleOrden;
            dtProductos = CI.DAC.clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0];

            this.slkupIDProducto.DataSource = dtProductos;
            this.slkupIDProducto.DisplayMember = "IDProducto";
            this.slkupIDProducto.ValueMember = "IDProducto";
            this.slkupIDProducto.NullText = " --- ---";
            
            this.slkupIDProducto.PopulateViewColumns();

            this.slkupDescrProducto.DataSource = dtProductos;
            this.slkupDescrProducto.DisplayMember = "Descr";
            this.slkupDescrProducto.ValueMember = "IDProducto";
            this.slkupDescrProducto.NullText = " --- ---";
            

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                //string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Status"]);
                //if (status == "1")
                //{
                //    e.Appearance.BackColor = Color.IndianRed;
                //}
                //else
                //{
                //    e.Appearance.BackColor = Color.White;
                //}

                var fld = e.Column.FieldName;
                if (fld == ("Status"))
                {
                    Brush circleBrush = null;
                    Rectangle r = e.Bounds;
                    r.Width = 16;
                    r.Height = 16;             

                    int cell_state = (int)View.GetRowCellValue(e.RowHandle, View.Columns[fld]);
                    if (cell_state == 0)
                        circleBrush = new SolidBrush(Color.Green);
                    else if (cell_state == 1)
                        circleBrush = new SolidBrush(Color.Red);
                    e.Graphics.FillEllipse(circleBrush, r);
                    e.Appearance.DrawString(e.Cache, "", r);
                    e.Handled = true;
                }
            }
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {

           if (this.gridView1.GetSelectedRows() != null ) {

                long IDProducto =  Convert.ToInt64(_currentRowDetalle["IDProducto"]);
                frmArticuloProveedor ofrmArticuloProveedor = new frmArticuloProveedor(IDProveedor, IDProducto, "Add", true);
                ofrmArticuloProveedor.ShowDialog();
                ValidarDatos();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }


        private void SetCurrentRow()
        {
            int index = (int)this.gridView1.FocusedRowHandle;
            if (index > -1)
            {
                _currentRowDetalle = gridView1.GetDataRow(index);
              
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.gridView1.RowCount ==0) {
                MessageBox.Show("Por favor seleccione el archivo a importar");
                return;
            }
            IsResult = true;         
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }

    public class clsDetalleOrden
    {
        public int Codigo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public decimal PorcDesc { get; set; }
        public String Comentario { get; set; }

        public clsDetalleOrden()
        {
            Codigo = 0;
            Cantidad = 0;
            Precio = 0.0m;
            Impuesto = 0.0m;
            Descuento = 0.0m;
            PorcDesc = 0.0m;
            Comentario = "";
        }
    }
}
