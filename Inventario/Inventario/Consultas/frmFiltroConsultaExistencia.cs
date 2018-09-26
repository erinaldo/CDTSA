using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CI.DAC;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace CI
{
    public partial class frmFiltroConsultaExistencia : Form
    {
        DataTable DTProducto = new DataTable();
        DataTable DTLote = new DataTable();
        DataTable DTBodega = new DataTable();
        DataTable DTClasif1 = new DataTable();
        DataTable DTClasif2 = new DataTable();
        DataTable DTClasif3 = new DataTable();
        DataTable DTClasif4 = new DataTable();
        DataTable DTClasif5 = new DataTable();
        DataTable DTClasif6 = new DataTable();
        DataTable DTPaquete = new DataTable();
        DataTable DTTransaccion = new DataTable();

        List<object> valuesProducto = new List<object>();
        List<object> valuesLote = new List<object>();
        List<object> valuesBodega = new List<object>();
        List<object> valuesClasif1 = new List<object>();
        List<object> valuesClasif2 = new List<object>();
        List<object> valuesClasif3 = new List<object>();
        List<object> valuesClasif4 = new List<object>();
        List<object> valuesClasif5 = new List<object>();
        List<object> valuesClasif6 = new List<object>();
        List<object> valuesPaquete = new List<object>();
        List<object> valuesTransaccion = new List<object>();

        string sProducto, sOrigen, sLote, sBodega, sClasif1, sClasif2, sClasif3, sClasif4, sClasif5, sClasif6, sPaquete, sTransaccion, sReferencia, sAplicacion;
        DateTime FechaInicial, FechaFinal;
        public bool DetallaLote = true;


        public frmFiltroConsultaExistencia(string sOrigen, string sProducto, string sLote, string sBodega, string sClasif1, string sClasif2, string sClasif3, string sClasif4, string sClasif5, string sClasif6, String sPaquete, String sTransaccion, String sReferencia, String sAplicacion, DateTime FI, DateTime FF, bool DetallaLote)
        {
            InitializeComponent();
            this.sProducto = sProducto;
            this.sLote = sLote;
            this.sBodega = sBodega;
            this.sClasif1 = sClasif1;
            this.sClasif2 = sClasif2;
            this.sClasif3 = sClasif3;
            this.sClasif4 = sClasif4;
            this.sClasif5 = sClasif5;
            this.sClasif6 = sClasif6;
            this.sPaquete = sPaquete;
            this.sTransaccion = sTransaccion;
            this.sReferencia = sReferencia;
            this.sAplicacion = sAplicacion;
            this.FechaInicial = FI;
            this.FechaFinal = FF;
            this.DetallaLote = DetallaLote;
            this.sOrigen = sOrigen;
        }


        private void frmFiltroConsultaExistencia_Load(object sender, EventArgs e)
        {

            DTProducto = clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", -1, -1, -1).Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxProducto, DTProducto, "Descr", "IDProducto", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxProducto, "[{'ColumnCaption':'ID Producto','ColumnField':'IDProducto','width':30},{'ColumnCaption':'Descr','ColumnField':'Descr','width':90}]");
            /*this.chkBoxProducto.Properties.DataSource = DTProducto;
            this.chkBoxProducto.Properties.DisplayMember = "Descr";
            this.chkBoxProducto.Properties.ValueMember = "IDProducto";*/
            this.chkBoxProducto.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxProducto.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            DTLote = clsLoteDAC.GetData(-1, -1, "*", "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxLote, DTLote, "LoteProveedor", "IDLote", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxLote, "[{'ColumnCaption':'IDLote','ColumnField':'IDLote','width':20},{'ColumnCaption':'Lote Proveedor','ColumnField':'LoteProveedor','width':90}]");
            this.chkBoxLote.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxLote.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

            DTBodega = clsBodegaDAC.GetData(-1, "*", -1).Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxBodega, DTBodega, "Descr", "IDBodega", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxBodega, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.chkBoxBodega.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxBodega.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            DTClasif1 = clsClasificacionDAC.GetData(-1, 1, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxClasif1, DTClasif1, "Descr", "IDClasificacion", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxClasif1, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
            this.chkBoxClasif1.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxClasif1.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            DTClasif2 = clsClasificacionDAC.GetData(-1, 2, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxClasif2, DTClasif2, "Descr", "IDClasificacion", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxClasif2, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
            this.chkBoxClasif2.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxClasif2.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;



            DTClasif3 = clsClasificacionDAC.GetData(-1, 3, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxClasif3, DTClasif3, "Descr", "IDClasificacion", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxClasif3, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
            this.chkBoxClasif3.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxClasif3.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            DTClasif4 = clsClasificacionDAC.GetData(-1, 4, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxClasif4, DTClasif4, "Descr", "IDClasificacion", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxClasif4, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
            this.chkBoxClasif4.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxClasif4.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;



            DTClasif5 = clsClasificacionDAC.GetData(-1, 5, "*").Tables[0];
            this.chkBoxClasif5.Properties.DataSource = DTClasif5;
            Util.Util.ConfigLookupEdit(this.chkBoxClasif5, DTClasif5, "Descr", "IDClasificacion", 250);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxClasif5, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
            this.chkBoxClasif5.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxClasif5.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;



            DTClasif6 = clsClasificacionDAC.GetData(-1, 6, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.chkBoxClasif6, DTClasif6, "Descr", "IDClasificacion", 250);
            Util.Util.ConfigLookupEditSetViewColumns(this.chkBoxClasif6, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
            this.chkBoxClasif6.Properties.View.OptionsSelection.MultiSelect = true;
            this.chkBoxClasif6.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

            DTTransaccion = clsGlobalTipoTransaccionDAC.Get(-1,"*", "*","*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupTransaccion, DTTransaccion, "Descr", "IDTipoTran", 250);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTransaccion, "[{'ColumnCaption':'Transaccion','ColumnField':'Transaccion','width':10},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");

            DTPaquete = clsPaqueteDAC.GetData(-1, "*", "*", -1, "*", 1).Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupPaquete, DTPaquete, "Descr", "IDPaquete", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupPaquete, "[{'ColumnCaption':'Paquete','ColumnField':'PAQUETE','width':10},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");



            if (sOrigen == "Existencia")
            {
                this.Height = 430;
                this.groupBoxDocumento.Visible = false;
                this.btnAceptar.Location = new Point(105, 355);
                this.btnCancelar.Location = new Point(230, 355);
            }
            else
            {
                this.Height = 581;
            }

            setItemSelected(sProducto, this.chkBoxProducto);
            setItemSelected(sLote, this.chkBoxLote);
            setItemSelected(sBodega, this.chkBoxBodega);
            setItemSelected(sClasif1, this.chkBoxClasif1);
            setItemSelected(sClasif2, this.chkBoxClasif2);
            setItemSelected(sClasif3, this.chkBoxClasif3);
            setItemSelected(sClasif4, this.chkBoxClasif4);
            setItemSelected(sClasif5, this.chkBoxClasif5);
            setItemSelected(sClasif6, this.chkBoxClasif6);
            setItemSelected(sTransaccion, this.slkupTransaccion);
            setItemSelected(sPaquete, this.slkupPaquete);

            this.txtAplicacion.EditValue = (sAplicacion == "*") ? "" : sAplicacion;
            this.txtReferencia.EditValue = (sReferencia == "*") ? "" : sReferencia;
            this.dtpFechaInicial.EditValue = FechaInicial;
            this.dtpFechaFinal.EditValue = FechaFinal;


        }


        private void HabilitarControles(string Nombre, bool Enable)
        {
            if (Nombre == "chkBoxProducto")
            {
                this.chkBoxProducto.Enabled = Enable;
                this.chkAllProducto.Checked = !Enable;
            }
            else if (Nombre == "chkBoxLote")
            {
                this.chkBoxLote.Enabled = Enable;
                this.chkAllLote.Checked = !Enable;
            }
            else if (Nombre == "chkBoxBodega")
            {
                this.chkBoxBodega.Enabled = Enable;
                this.chkAllBodega.Checked = !Enable;
            }
            else if (Nombre == "chkBoxClasif1")
            {
                this.chkBoxClasif1.Enabled = Enable;
                this.chkAllClasificacion1.Checked = !Enable;
            }
            else if (Nombre == "chkBoxClasif1")
            {
                this.chkBoxClasif1.Enabled = Enable;
                this.chkAllClasificacion1.Checked = !Enable;
            }
            else if (Nombre == "chkBoxClasif2")
            {
                this.chkBoxClasif2.Enabled = Enable;
                this.chkAllClasificacion2.Checked = !Enable;
            }
            else if (Nombre == "chkBoxClasif3")
            {
                this.chkBoxClasif3.Enabled = Enable;
                this.chkAllClasificacion3.Checked = !Enable;
            }
            else if (Nombre == "chkBoxClasif4")
            {
                this.chkBoxClasif4.Enabled = Enable;
                this.chkAllClasificacion4.Checked = !Enable;
            }
            else if (Nombre == "chkBoxClasif5")
            {
                this.chkBoxClasif5.Enabled = Enable;
                this.chkAllClasif5.Checked = !Enable;
            }
            else if (Nombre == "chkBoxClasif6")
            {
                this.chkBoxClasif6.Enabled = Enable;
                this.chkAllClasif6.Checked = !Enable;
            }


        }



        private List<int> GetSelection(string[] values, string fieldName, GridView view)
        {
            List<int> selection = new List<int>();
            foreach (string val in values)
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, fieldName).ToString() == val)
                        selection.Add(i);
                }
            }
            return selection;
        }


        private String GetFieldFind(string Nombre)
        {
            if (Nombre == "chkBoxProducto")
                return "IDProducto";
            else if (Nombre == "chkBoxLote")
                return "IDLote";
            else if (Nombre == "chkBoxBodega")
                return "IDBodega";
            else if (Nombre == "chkBoxClasif1" || Nombre == "chkBoxClasif2" || Nombre == "chkBoxClasif3" || Nombre == "chkBoxClasif4" || Nombre == "chkBoxClasif5" || Nombre == "chkBoxClasif6")
                return "IDClasificacion";
            else if (Nombre == "slkupTransaccion")
                return "IDTipoTran";
            else if (Nombre == "slkupPaquete")
                return "IDPaquete";
            else
                return "";

        }

        private void setItemSelected(string sLst, SearchLookUpEdit crt)
        {
            if (sLst != "*")
            {
                HabilitarControles(crt.Name, true);
                String[] valores = sLst.Split(',');
                crt.ShowPopup();
                crt.ClosePopup();
                GridView view = crt.Properties.View;

                List<int> selection = GetSelection(valores, GetFieldFind(crt.Name), view);
                foreach (int rowHandle in selection)
                {
                    view.SelectRow(rowHandle);
                }

            }
        }



        private void chkAllClasificacion1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion1.Checked == true)
                this.chkBoxClasif1.Enabled = false;
            else
                this.chkBoxClasif1.Enabled = true;
        }

        private void chkAllProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllProducto.Checked == true)
                this.chkBoxProducto.Enabled = false;
            else
                this.chkBoxProducto.Enabled = true;
        }

        private void chkAllLote_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllLote.Checked == true)
                this.chkBoxLote.Enabled = false;
            else
                this.chkBoxLote.Enabled = true;
        }

        private void chkAllBodega_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllBodega.Checked == true)
                this.chkBoxBodega.Enabled = false;
            else
                this.chkBoxBodega.Enabled = true;
        }

        private void chkAllClasificacion2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion2.Checked == true)
                this.chkBoxClasif2.Enabled = false;
            else
                this.chkBoxClasif2.Enabled = true;
        }

        private void chkAllClasificacion3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion3.Checked == true)
                this.chkBoxClasif3.Enabled = false;
            else
                this.chkBoxClasif3.Enabled = true;
        }

        private void chkAllClasificacion4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasificacion4.Checked == true)
                this.chkBoxClasif4.Enabled = false;
            else
                this.chkBoxClasif4.Enabled = true;
        }

        private void chkAllClasif5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasif5.Checked == true)
                this.chkBoxClasif5.Enabled = false;
            else
                this.chkBoxClasif5.Enabled = true;
        }

        private void chkAllClasif6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllClasif6.Checked == true)
                this.chkBoxClasif6.Enabled = false;
            else
                this.chkBoxClasif6.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DetallaLote = this.chkDetallaLote.Checked;
            this.Close();
        }

        public String getLstFiltro(string sCampo)
        {
            String Result = "";
            switch (sCampo)
            {
                case "Producto":
                    if (this.chkAllProducto.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesProducto);
                    break;
                case "Lote":
                    if (this.chkAllLote.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesLote);
                    break;
                case "Bodega":
                    if (this.chkAllBodega.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesBodega);
                    break;
                case "Clasif1":
                    if (this.chkAllClasificacion1.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesClasif1);
                    break;
                case "Clasif2":
                    if (this.chkAllClasificacion2.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesClasif2);
                    break;
                case "Clasif3":
                    if (this.chkAllClasificacion3.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesClasif3);
                    break;
                case "Clasif4":
                    if (this.chkAllClasificacion4.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesClasif4);
                    break;
                case "Clasif5":
                    if (this.chkAllClasif5.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesClasif5);
                    break;
                case "Clasif6":
                    if (this.chkAllClasif6.Checked == true)
                        Result = "*";
                    else
                        Result = String.Join(",", valuesClasif6);
                    break;
                case "Paquete":
                    Result = String.Join(",", valuesPaquete);
                    if (Result == "")
                        Result = "*";
                  
                    break;
                case "Transaccion":

                    Result = String.Join(",", valuesTransaccion);
                    if (Result == "")
                        Result = "*";

                    break;

            }

            return Result;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Producto
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDProducto");
            if (e.Action == CollectionChangeAction.Add)
                valuesProducto.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesProducto.Remove(Valor);

        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Lote
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDLote");
            if (e.Action == CollectionChangeAction.Add)
                valuesLote.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesLote.Remove(Valor);
        }

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Bodega
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDBodega");
            if (e.Action == CollectionChangeAction.Add)
                valuesBodega.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesBodega.Remove(Valor);
        }

        private void gridView4_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Clasif1
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDClasificacion");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesClasif1.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesClasif1.Remove(Valor);
        }

        private void gridView5_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Clasif2
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDClasificacion");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesClasif2.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesClasif2.Remove(Valor);
        }

        public DateTime GetFechaInicial()
        {
            return (DateTime)this.dtpFechaInicial.EditValue;
        }

        public DateTime GetFechaFinal()
        {
            return (DateTime)this.dtpFechaFinal.EditValue;
        }

        public String GetAplicacion()
        {
            return (this.txtAplicacion.Text.Trim() == "") ? "*" : this.txtAplicacion.Text.Trim();
        }

        public String GetReferencia()
        {
            return (this.txtReferencia.Text.Trim() == "") ? "*" : this.txtReferencia.Text.Trim();
        }

        private void gridView6_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Clasif3
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDClasificacion");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesClasif3.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesClasif3.Remove(Valor);
        }

        private void gridView7_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Clasif4
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDClasificacion");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesClasif4.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesClasif4.Remove(Valor);
        }

        private void gridView8_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Clasif5
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDClasificacion");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesClasif5.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesClasif5.Remove(Valor);
        }

        private void gridView9_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Clasif6
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDClasificacion");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesClasif6.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesClasif6.Remove(Valor);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void gridView10_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Transaccion
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDTipoTran");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesTransaccion.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesTransaccion.Remove(Valor);
        }

        private void gridView11_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Paquete
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDPaquete");
            if (e.Action == CollectionChangeAction.Add)
                this.valuesPaquete.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesPaquete.Remove(Valor);
        }





    }
}
