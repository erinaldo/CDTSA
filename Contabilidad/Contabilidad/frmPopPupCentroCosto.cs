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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace CG
{
    public partial class frmPopPupCentroCosto : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtCentros = new DataTable();
        private List<int> selectedRows = new List<int>();
        public String sCostosSelected = "";

        public frmPopPupCentroCosto()
        {
            InitializeComponent();
            this.Load += frmPopPupCentroCosto_Load;
            this.gridView1.ColumnFilterChanged+=gridView1_ColumnFilterChanged;
            this.gridView1.MouseUp += gridView1_MouseUp;
            this.gridView1.MouseDown += gridView1_MouseDown;
        }

        void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            if (hi.Column.FieldName == "DX$CheckboxSelectorColumn")
            {
                if (!hi.InRow)
                {
                    bool allSelected = view.DataController.Selection.Count == view.DataRowCount;
                    if (!allSelected)
                    {
                        for (int i = 0; i <= view.RowCount - 1; i++)
                        {
                            int sourceHandle = view.GetDataSourceRowIndex(i);
                            if (!selectedRows.Contains(sourceHandle))
                            {
                                selectedRows.Add(sourceHandle);
                            }
                        }
                    }
                    else
                    {
                        selectedRows.Clear();
                    }
                }
                else
                {
                    int sourceHandle = view.GetDataSourceRowIndex(hi.RowHandle);
                    if (!selectedRows.Contains(sourceHandle))
                    {
                        selectedRows.Add(sourceHandle);
                    }
                    else
                    {
                        selectedRows.Remove(sourceHandle);
                    }
                }
            }
            RestoreSelection(view);

        }

        void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            RestoreSelection(view);
        }

        void frmPopPupCentroCosto_Load(object sender, EventArgs e)
        {
            _dtCentros = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", -1).Tables[0];
            // _dtCuentasConstante = _dtCuentas.Clone();

            this.gridCentroCosto.DataSource = _dtCentros;
            if (sCostosSelected != "") {
                CheckElements();
            }

        }
        private void RestoreSelection(GridView view)
        {
            int i = 0;
            try
            {
                BeginInvoke(new Action(() =>
                {
                   // int i = 0;
                    while (i < selectedRows.Count)
                    {
                        view.SelectRow(view.GetRowHandle(selectedRows[i]));
                        i += 1;
                    }
                }));
            }catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Debug: {0}{1}  {2} {3}{4} {5}", i, ex.Data, ex.InnerException, ex.Message, ex.Source, ex));
                }
        }

        
        void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            RestoreSelection(sender as GridView);
        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClearSeleccion_Click(object sender, EventArgs e)
        {
            this.gridView1.ClearSelection();
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            this.gridView1.SelectAll();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckElements() {
            String[] Lista = sCostosSelected.Split(',');

            for (int i=0 ;i<=Lista.Count();i++)
            {
                int rowHandle = gridView1.LocateByValue("IDCentro", Lista[i]);
                if(rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.SelectRow(rowHandle);
                 
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Guardar los elementos seleccionados en la base de datos.
            sCostosSelected = "";
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
                sCostosSelected = string.Format("{0}{1},", sCostosSelected, row["IDCentro"]);
            }
            if (sCostosSelected!="")
                sCostosSelected = sCostosSelected.Substring(0, sCostosSelected.Length - 1);

            this.Close();
        }
    }
}