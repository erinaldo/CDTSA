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
using Security;
using CI.DAC;

namespace CI
{
    public partial class frmListadoProducto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public int _IDProducto;
        public String _Descripcion;
        public String _Alias;
        public String _CodigoBarra;
        public int _iEsControlado;
        public int _iEsMuestra;
        public int _iEsEtico;
        public int _iBajaPrecioDistribuidor;
        public int _iBajaPrecioProveedor;
        public int _iBonificaFactura;
        public int _TipoImpuesto;
        public int _iClasificacion1;
        public int _iClasificacion2;
        public int _iClasificacion3;
        public int _iClasificacion4;
        public int _iClasificacion5;
        public int _iClasificacion6;


        private String sSql = "";
        private String sWhereSql = "";
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        

        private DataSet _dsProducto;
        private DataTable _dtProducto;

        DataRow _currentRow = null;
        const String _tituloVentana = "Listado de Productos";
        

        public frmListadoProducto()
        {
            InitializeComponent();
            
        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, _sUsuario);
            DT = DS.Tables[0];
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarAsientodeDiario, DT))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarAsientodeDiario, DT))
                this.btnEditar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarAsientodeDiario, DT))
                this.btnEliminar.Enabled = false;

        }

        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += BtnAgregar_ItemClick;
            this.btnEditar.ItemClick += BtnEditar_ItemClick;
            this.btnEliminar.ItemClick += BtnEliminar_ItemClick;
            this.btnFiltro.ItemClick += BtnFiltro_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
        }



        private void frmListadoProducto_Load(object sender, EventArgs e)
        {
            try
            {


                //HabilitarControles(false);
                //Detallar los filtros globales para buscar los productos
                _IDProducto = -1;
                _Descripcion = "*";
                _Alias = "*";
                _CodigoBarra = "*";
                _iEsControlado = -1;
                _iEsEtico = -1;
                _iEsMuestra = -1;
                _iBajaPrecioDistribuidor = -1;
                _iBajaPrecioProveedor = -1;
                _iBonificaFactura = -1;
                _TipoImpuesto = -1;
                _iClasificacion1 = -1;
                _iClasificacion2 = -1;
                _iClasificacion3 = -1;
                _iClasificacion4 = -1;
                _iClasificacion5 = -1;
                _iClasificacion6 = -1;


                sSql = "SELECT IDProducto,Descr ,Alias ,Clasif1 ,Clasif2 ,Clasif3 ,Clasif4 ,Clasif5 ,Clasif6 ,CodigoBarra ,IDUnidad ,FactorEmpaque ,TipoImpuesto ," +
                        "EsMuestra ,EsControlado ,EsEtico ,BajaPrecioDistribuidor ,BajaPrecioProveedor ,PorcDescuentoAlzaProveedor ,BonificaFA ,BonificaCOPorCada ," +
                        "BonificaCOCantidad , Activo ,UserInsert ,UserUpdate  ,UpdateDate,CreateDate  FROM dbo.invProducto";
              

                this.gridView.FocusedRowChanged += GridView_FocusedRowChanged;
                this.gridView.DoubleClick += GridView_DoubleClick;
                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.gridControl1, _tituloVentana, this);

                EnlazarEventos();
                PopulateGrid();
                CargarPrivilegios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lsProductos.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Productos"
            };


            this.gridView.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }


        private void BtnFiltro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFiltroProducto ofrmFiltro = new frmFiltroProducto(_IDProducto,_Descripcion,_Alias,_CodigoBarra,_iEsControlado,_iEsMuestra,_iEsEtico,_iBajaPrecioDistribuidor,_iBajaPrecioProveedor,_iBonificaFactura,_TipoImpuesto,_iClasificacion1,_iClasificacion2,_iClasificacion3,_iClasificacion4,_iClasificacion5,_iClasificacion6);
            ofrmFiltro.FormClosed += OfrmFiltro_FormClosed;
            ofrmFiltro.ShowDialog();
        }

        private void OfrmFiltro_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFiltroProducto ofrmFiltro = (frmFiltroProducto)sender;
            //Obtener las variables de filtro

            _IDProducto = ofrmFiltro.IDProducto;
            _Descripcion = ofrmFiltro.Descripcion;
            _Alias = ofrmFiltro.Alias;
            _CodigoBarra = ofrmFiltro.CodigoBarra;
            _iEsControlado = ofrmFiltro.iEsControlado;
            _iEsEtico = ofrmFiltro.iEsEtico;
            _iEsMuestra = ofrmFiltro.iEsMuestra;
            _iBajaPrecioDistribuidor = ofrmFiltro.iBajaPrecioDistribuidor;
            _iBajaPrecioProveedor = ofrmFiltro.iBajaPrecioProveedor;
            _iBonificaFactura = ofrmFiltro.iBonificaFactura;
            _TipoImpuesto = ofrmFiltro.TipoImpuesto;
            _iClasificacion1 = ofrmFiltro.iClasificacion1;
            _iClasificacion2 = ofrmFiltro.iClasificacion2;
            _iClasificacion3 = ofrmFiltro.iClasificacion3;
            _iClasificacion4 = ofrmFiltro.iClasificacion4;
            _iClasificacion5 = ofrmFiltro.iClasificacion5;
            _iClasificacion6 = ofrmFiltro.iClasificacion6;
            sWhereSql = "";                
            ofrmFiltro.FormClosed -= OfrmFiltro_FormClosed;
            if (_IDProducto != -1)
                sWhereSql = string.Format(" IDProducto = {0} and ", _IDProducto);
            if (_Descripcion !="*")
                sWhereSql = string.Format("{0}  Descr LIKE '%{1}%' and ", sWhereSql, _Descripcion);
            if (_Alias != "*")
                sWhereSql = string.Format("{0}  Alias LIKE '%{1}%' and ", sWhereSql, _Alias);
            if (_CodigoBarra != "*")
                sWhereSql = string.Format("{0}  CodigoBarra LIKE '%{1}%' and ", sWhereSql, _CodigoBarra);
            if (_iEsControlado == 0)
                sWhereSql = string.Format("{0}  EsControlado= 0 and ", sWhereSql);
            if (_iEsEtico == 0)
                sWhereSql = string.Format("{0}  EsEtico= 0 and ", sWhereSql);
            if (_iEsMuestra == 0)
                sWhereSql = string.Format("{0}  EsMuestra= 0 and ", sWhereSql);
            if (_iBajaPrecioDistribuidor == 0)
                sWhereSql = string.Format("{0}  BajaPrecioDistribuidor= 0 and ", sWhereSql);
            if (_iBajaPrecioProveedor == 0)
                sWhereSql = string.Format("{0}  BajaPrecioProveedor = 0 and ", sWhereSql);
            if (_iBonificaFactura == 0)
                sWhereSql = string.Format("{0}  BonificaFA = 0 and ", sWhereSql);
            if (_TipoImpuesto != -1)
                sWhereSql = string.Format("{0}  TipoImpuesto = {1} and ", sWhereSql,_TipoImpuesto);
            if (_iClasificacion1 != -1)
                sWhereSql = string.Format("{0}  Clasif1 = {1} and ", sWhereSql, _iClasificacion1);
            if (_iClasificacion2 != -1)
                sWhereSql = string.Format("{0}  Clasif2 = {1} and ", sWhereSql, _iClasificacion2);
            if (_iClasificacion3 != -1)
                sWhereSql = string.Format("{0}  Clasif3 = {1} and ", sWhereSql, _iClasificacion3);
            if (_iClasificacion4 != -1)
                sWhereSql = string.Format("{0} Clasif4 = {1} and ", sWhereSql, _iClasificacion4);
            if (_iClasificacion5 != -1)
                sWhereSql = string.Format("{0}  Clasif5 = {1} and ", sWhereSql, _iClasificacion5);
            if (_iClasificacion6 != -1)
                sWhereSql = string.Format("{0}  Clasif6 = {1} and ", sWhereSql, _iClasificacion6);

            if (sWhereSql != "")
            {
                sWhereSql = " where " + sWhereSql;
                sWhereSql = sWhereSql.Substring(0, sWhereSql.Length - 4);
            }
            PopulateGrid();
        }


        private void BtnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRow != null)
            {
                
                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + _currentRow["IdProducto"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataSet _dsProductotmp = new DataSet();
                    DataTable _dtProductotmp = new DataTable();

                   
                  //Validar las dependendicas
                    //ToDo Validar dependencias de los prodcutos
                    _currentRow.Delete();
                    try
                    {

                        clsProductoDAC.oAdaptador.Update(_dsProducto, "Data");
                        _dsProducto.AcceptChanges();


                       // PopulateGrid();
                       // lblStatus.Text = "El elemento se ha eliminado";
                        //MessageBox.Show("El asiento se ha eliminado correctamente.");
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsProducto.RejectChanges();
                        MessageBox.Show("Han ocurrido errores al momento de eliminar el asiento por favor verifique" + ex.Message);
                    }

                    PopulateGrid();

                }

            }
        }


        private void PopulateGrid()
        {

            _dsProducto = clsProductoDAC.GetProductoDinamicConsult(sSql + sWhereSql);
            _dtProducto = _dsProducto.Tables[0];
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = _dtProducto;

        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            CargarProducto("View");
        }


        private void CargarProducto(String Accion)
        {
            if (_currentRow != null)
            {
                frmProducto ofrmProducto = new frmProducto   (Convert.ToInt32(_currentRow["IDProducto"]),Accion);
                ofrmProducto.FormClosed += OfrmAsiento_FormClosed;
                ofrmProducto.ShowDialog();

            }
        }


        private void BtnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarProducto("Edit");
        }

        private void OfrmAsiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProducto ofrmProducto = new frmProducto();
            ofrmProducto.FormClosed += OfrmAsiento_FormClosed;

            if (!ofrmProducto.IsDisposed)
                ofrmProducto.ShowDialog();

        }




        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (_currentRow != null && this.gridView.SelectedRowsCount == 1)
            {
                frmProducto ofrmProducto = new frmProducto(Convert.ToInt32(_currentRow["IDProducto"]),"View");
                ofrmProducto.FormClosed += ofrmProducto_FormClosed;
                ofrmProducto.ShowDialog();

            }
        }

        void ofrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();   
        }




        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                _currentRow = gridView.GetDataRow(index);
                //UpdateControlsFromCurrentRow(_currentRow);
            }
            else _currentRow = null;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

    
      
    }
}