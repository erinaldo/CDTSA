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
using System.Collections;

namespace CG
{
    public partial class frmCentroACuenta : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dtCentroCuenta;
        private DataSet _dsCentroCuenta;
        DataRow currentRow;
        const String _tituloVentana = "Listado de Centros de Costos Asociados a una Cuenta";
        private DataRow _drCuenta;
        private bool isEdition = false;

        public frmCentroACuenta(DataRow drCuenta)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _drCuenta = drCuenta;
        }

        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            
            
            this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
            this.gridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.TextAndVisual;
            
            this.gridView.OptionsFind.SearchInPreview = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }


        private void frmAsociarCentroACuenta_Load(object sender, EventArgs e)
        {
            try
            {
               
                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.grid, _tituloVentana, this);

                PopulateGrid();

                EnlazarEventos();

                UpdateControlsFromCurrentRow(_drCuenta);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void PopulateGrid()
        {
            _dsCentroCuenta = CuentaCentroDAC.GetData(-1,Convert.ToInt32(_drCuenta["IDCuenta"]));
            _dtCentroCuenta = _dsCentroCuenta.Tables[0];
            this.grid.DataSource = _dtCentroCuenta;
        }


        private void UpdateControlsFromCurrentRow(DataRow currentRow)
        {
            if (currentRow != null)
            {
                this.txtCuenta.Text = currentRow["Cuenta"].ToString();
                this.txtDescripcion.Text = currentRow["Descr"].ToString();
            }
        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridView.GetDataRow(index);
               
            }
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAsociarCentroCuenta ofrmAsociar = new frmAsociarCentroCuenta(Convert.ToInt32(_drCuenta["IDCuenta"]));
            ofrmAsociar.FormClosed += OfrmAsociar_FormClosed;
            ofrmAsociar.ShowDialog();
        }

        private void OfrmAsociar_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //Recorrer los elemento y agregarlos
            ArrayList rows = new ArrayList();
            for (int i = 0; i < this.gridView.SelectedRowsCount; i++)
            {
                if (gridView.GetSelectedRows()[i] >= 0)
                    rows.Add(gridView.GetDataRow(gridView.GetSelectedRows()[i]));
            }
            try
            {
                if (MessageBox.Show("Esta seguro que desea eliminar los elementos seleccionados ? ", "Eliminar Elementos", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i] as DataRow;
                    // Change the field value.
                  
                    row.Delete();
                    try
                    {
                        
                            CuentaCentroDAC.oAdaptador.Update(_dsCentroCuenta, "Data");
                            _dsCentroCuenta.AcceptChanges();
                            //isEdition = false;

                            Application.DoEvents();
                       
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsCentroCuenta.RejectChanges();
                        
                        MessageBox.Show(ex.Message);
                    }

                    
                }
            }
            finally
            {

            }

            PopulateGrid();


        }


    }
}