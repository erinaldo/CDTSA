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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace CG
{
    public partial class frmPopPupCuentaContable : DevExpress.XtraEditors.XtraForm
    {

        DataTable _dtCuentas = new DataTable();
        private List<int> selectedRows = new List<int>();
        public String sCuentasSelected = "";

        public frmPopPupCuentaContable()
        {
            InitializeComponent();
            this.gridView1.ColumnFilterChanged += gridView1_ColumnFilterChanged;
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

        private void RestoreSelection(GridView view)
        {
            BeginInvoke(new Action(() =>
            {
                int i = 0;
                while (i < selectedRows.Count)
                {
                    view.SelectRow(view.GetRowHandle(selectedRows[i]));
                    i += 1;
                }
            }));
        }

        void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            RestoreSelection(sender as GridView);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gridView1.SelectAll();

        }

        private void btnLimpiarSeleccion_Click(object sender, EventArgs e)
        {
            this.gridView1.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckElements()
        {
            String[] Lista = sCuentasSelected.Split(',');

            for (int i = 0; i <= Lista.Count(); i++)
            {
                int rowHandle = gridView1.LocateByValue("IDCuenta", Lista[i]);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    gridView1.SelectRow(rowHandle);

            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Guardar las cuentas contables
            sCuentasSelected = "";
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
                sCuentasSelected = string.Format("{0}{1},", sCuentasSelected, row["IDCuenta"]);
            }
            if (sCuentasSelected != "")
                sCuentasSelected = sCuentasSelected.Substring(0, sCuentasSelected.Length - 1);
            this.Close();
        }

        private void popupCuentaContable_Load(object sender, EventArgs e)
        {
            _dtCuentas = CuentaContableDAC.GetData(-1,-1,-1,"*","*","*","*","*","*",-1,-1,-1,1,-1,-1).Tables[0];
            // _dtCuentasConstante = _dtCuentas.Clone();

            this.gridCuentas.DataSource = _dtCuentas;

            if (sCuentasSelected != "")
            {
                CheckElements();
            }

           
        }
    }
}