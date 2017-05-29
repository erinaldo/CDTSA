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
    public partial class frmListadoAsientoDiario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DateTime _FechaInicial;
        DateTime _FechaFinal;
        String _TipoAsiento;
        int _Mayorizado;
        int _Anulado;
        int _CuadreTemporal;
        String _ModuloFuente;
        
        public frmListadoAsientoDiario()
        {
            InitializeComponent();
            this.Load += FrmListadoAsientoDiario_Load;
        }

        private void FrmListadoAsientoDiario_Load(object sender, EventArgs e)
        {
            try
            {
                //HabilitarControles(false);
                _FechaInicial = DateTime.Now.AddDays(-15);
                _FechaFinal = DateTime.Now;

                _TipoAsiento = "CG";
                _ModuloFuente = "CG";
                _Mayorizado = 0;
                _Anulado = 0;
                _CuadreTemporal = 0;

                this.gridView.FocusedRowChanged += GridView_FocusedRowChanged;

                //PopulateGrid();
                EnlazarEventos();
                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.grid, _tituloVentana, this);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataSet _dsAsiento;
        private DataTable _dtAsiento;
        

        DataRow _currentRow;
        const String _tituloVentana = "Listado de Asientos";

        

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                _currentRow = gridView.GetDataRow(index);
                //UpdateControlsFromCurrentRow(_currentRow);
            }
        }

        //private void UpdateControlsFromCurrentRow(object currentRow)
        //{
        //    if (((bool)_currentRow["PeriodoTrabajo"]) == true)
        //    {
        //        this.btnAbrirPeriodo.Enabled = false;
        //        this.btnCerrarPeriodo.Enabled = false;
        //    }
        //    if (Convert.ToBoolean(_currentRow["Cerrado"]) == true)
        //    {
        //        this.btnCerrarPeriodo.Enabled = false;
        //        this.btnAbrirPeriodo.Enabled = false;
        //    }
        //    //if (Convert.ToBoolean(_currentRow[""]))

        //}

        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += BtnAgregar_ItemClick;
            this.btnEditar.ItemClick += BtnEditar_ItemClick;
            this.btnEliminar.ItemClick += BtnEliminar_ItemClick;
            this.btnFiltro.ItemClick += BtnFiltro_ItemClick;
        }

        private void BtnFiltro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmParametrosFiltroAsiento ofrmFiltro = new frmParametrosFiltroAsiento(_FechaInicial, _FechaFinal, _ModuloFuente, _TipoAsiento, (_Mayorizado == 1) ? true : false, (_Anulado == 1) ? true:false,(_CuadreTemporal==1) ? true:false);
            ofrmFiltro.FormClosed += OfrmFiltro_FormClosed;
            ofrmFiltro.ShowDialog();
        }

        private void OfrmFiltro_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParametrosFiltroAsiento ofrmFiltro = (frmParametrosFiltroAsiento)sender;
            //Obtener las variables de filtro
            _FechaInicial = ofrmFiltro.FechaInicial;
            _FechaFinal = ofrmFiltro.FechaFinal;
            _Mayorizado = Convert.ToInt32(ofrmFiltro.Mayorizado);
            _Anulado = Convert.ToInt32(ofrmFiltro.Anulado);
            _CuadreTemporal = Convert.ToInt32(ofrmFiltro.CuadreTemporal);
            _TipoAsiento = ofrmFiltro.TipoAsiento;
            _ModuloFuente = ofrmFiltro.ModuloFuente;
            ofrmFiltro.FormClosed -= OfrmFiltro_FormClosed;

            PopulateGrid();
        }

        private void BtnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

     
        private void BtnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         if (_currentRow != null)
            {
                frmAsiento ofrmAsiento = new frmAsiento(_currentRow["Asiento"].ToString());
                ofrmAsiento.FormClosed += OfrmAsiento_FormClosed;
                ofrmAsiento.ShowDialog();

            }
        }

        private void OfrmAsiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAsiento ofrmAsiento = new frmAsiento();
            ofrmAsiento.FormClosed += OfrmAsiento_FormClosed;
            ofrmAsiento.ShowDialog();

        }




        private void PopulateGrid()
        {
            _dsAsiento = AsientoDAC.GetDataByCriterio(_FechaInicial,_FechaFinal,_TipoAsiento,_Mayorizado,_Anulado,_ModuloFuente,_CuadreTemporal);
            _dtAsiento = _dsAsiento.Tables[0];
            this.grid.DataSource = _dtAsiento;
        }



        private void SetCurrentRow()
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                _currentRow = gridView.GetDataRow(index);
                //UpdateControlsFromCurrentRow(_currentRow);
            }
        }




        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

      
    }
}