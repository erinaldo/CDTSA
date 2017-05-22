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
    public partial class frmAsociarCentroCuenta : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dtCentro;
        private DataSet _dsCentro;
        private DataSet _dsCentroCuenta;
        private int _IDCuenta;
        
      
        
        public frmAsociarCentroCuenta(int IDCuenta)
        {
            InitializeComponent();
            _IDCuenta = IDCuenta;
            
        }

        private void frmAsociarCentroCuenta_Load(object sender, EventArgs e)
        {

            try
            {

                _dsCentroCuenta = CuentaCentroDAC.GetEmptyData();

                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.grid, "", this);

                PopulateGrid();
                this.btnAgregar.Click += BtnAgregar_Click;
                this.btnCancelar.Click += BtnCancelar_Click;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
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
                
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i] as DataRow;
                    // Change the field value.
                    DataRow currentRowCC =null;
                    //nuevo registro
                    currentRowCC = _dsCentroCuenta.Tables[0].NewRow();

                    currentRowCC["IDCuenta"] = _IDCuenta;
                    currentRowCC["IDCentro"] = Convert.ToInt32(row[0]);
                    _dsCentroCuenta.Tables[0].Rows.Add(currentRowCC);
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
                        currentRowCC = null;
                        MessageBox.Show(ex.Message);
                    }

                    PopulateGrid();
                }
            }
            finally
            {
                
            }

        }

        private void PopulateGrid()
        {
            _dsCentro = CuentaCentroDAC.GetCentroNotInCentroCuenta(_IDCuenta);
            _dtCentro = _dsCentro.Tables[0];
            this.grid.DataSource = _dtCentro;


        }
    }
}