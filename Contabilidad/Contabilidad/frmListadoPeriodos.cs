using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public partial class frmListadoPeriodos : Form
    {

        private DataSet _dsPeriodo;
        private DataTable _dtPeriodo;
        private DataTable _dtEjericio;

        DataRow _currentRow;
        const String _tituloVentana = "Listado de Periodos";

        public frmListadoPeriodos()
        {
            InitializeComponent();
        }

        private void frmListadoPeriodos_Load(object sender, EventArgs e)
        {
            try
            {
                //HabilitarControles(false);
                _dtEjericio = EjercicioDAC.GetData(-1).Tables[0];
                this.gridView.FocusedRowChanged += GridView_FocusedRowChanged;
                Util.Util.ConfigLookupEdit(this.slkupEjercicio, _dtEjericio, "Descr", "IDEjercicio");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupEjercicio, "[{'ColumnCaption':'ID','ColumnField':'IDEjercicio','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

                if (_dtEjericio.Rows.Count>0)
                    this.slkupEjercicio.EditValue = _dtEjericio.Rows[_dtEjericio.Rows.Count-1]["IDEjercicio"];
                 
                EnlazarEventos();
                Util.Util.SetDefaultBehaviorControls(this.gridView,true, this.grid, _tituloVentana, this);

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                _currentRow = gridView.GetDataRow(index);
                UpdateControlsFromCurrentRow(_currentRow);
            }
        }

        private void UpdateControlsFromCurrentRow(object currentRow)
        {
            //if (((bool)_currentRow["PeriodoTrabajo"]) == true)
            //{
            //    this.btnAbrirPeriodo.Enabled = false;
                
            //}
            if (Convert.ToBoolean(_currentRow["Cerrado"]) == true)
            {
                this.btnCerrarPeriodo.Enabled = false;
                this.btnSetPeriodoTrabajo.Enabled = false;
            }
            else
            {
                
                this.btnCerrarPeriodo.Enabled = true;
                this.btnSetPeriodoTrabajo.Enabled = true;
                if (Convert.ToBoolean(_currentRow["PeriodoTrabajo"]) == true)
                    this.btnSetPeriodoTrabajo.Caption = "Quitar Periodo de Trabajo";
                else
                    this.btnSetPeriodoTrabajo.Caption = "Establecer Periodo de Trabajo";
                this.btnSetPeriodoTrabajo.Enabled = true;
            }
            //if (Convert.ToBoolean(_currentRow[""]))

        }

        private void EnlazarEventos()
        {
            this.btnSetPeriodoTrabajo.ItemClick += btnSetPeriodoTrabajo_ItemClick;
            this.btnCerrarPeriodo.ItemClick += BtnCerrarPeriodo_ItemClick;
            this.btnSalir.ItemClick += BtnSalir_ItemClick;

        }

        void btnSetPeriodoTrabajo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView.SelectedRowsCount > 0)
            {

                String sPeriodo = _currentRow["Periodo"].ToString();
                int IdEjercicio = (int)_currentRow["IdEjercicio"];
                if (PeriodoContableDAC.SetPeriodoTrabajoActivo(IdEjercicio, sPeriodo))
                {
                    _dsPeriodo = PeriodoContableDAC.GetData((int)this.slkupEjercicio.EditValue, "*");
                    PopulateGrid();
                }
            }
        }

        private void BtnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
            this.Close();
        }

        private void BtnCerrarPeriodo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.gridView.SelectedRowsCount > 0)
                {

                    String sPeriodo = _currentRow["Periodo"].ToString();
                    int IdEjercicio = (int)_currentRow["IdEjercicio"];
                    if (PeriodoContableDAC.CierraPeriodoContable(IdEjercicio, sPeriodo))
                    {
                        _dsPeriodo = PeriodoContableDAC.GetData((int)this.slkupEjercicio.EditValue, "*");
                        PopulateGrid();
                        MessageBox.Show("El periodo contable se ha cerrado con éxito");
                    }
                }
            }
            catch (Exception )
            {

            }
        }

     


        private void PopulateGrid()
        {
            _dtPeriodo = _dsPeriodo.Tables[0];
            this.grid.DataSource = null;
            this.grid.DataSource = _dtPeriodo;
        }



        private void SetCurrentRow()
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                _currentRow = gridView.GetDataRow(index);
                UpdateControlsFromCurrentRow(_currentRow);
            }
        }




        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }

        private void slkupEjercicio_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
          
                if (this.slkupEjercicio.EditValue != null && this.slkupEjercicio.EditValue.ToString() != "")
                {
                    _dsPeriodo = PeriodoContableDAC.GetData((int)this.slkupEjercicio.EditValue, "*");
                    PopulateGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
