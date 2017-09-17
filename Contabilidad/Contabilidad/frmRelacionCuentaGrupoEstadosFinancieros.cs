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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace CG
{
    public partial class frmRelacionCuentaGrupoEstadosFinancieros : DevExpress.XtraEditors.XtraForm
    {
        DataSet dsCuentaGrupo = new DataSet();
        DataRow _currentRow =null;

        public frmRelacionCuentaGrupoEstadosFinancieros()
        {
            InitializeComponent();
        }

        void InitTreeList(TreeList treeList)
        {
            treeList.OptionsDragAndDrop.DragNodesMode = DragNodesMode.Multiple;
            treeList.OptionsDragAndDrop.AcceptOuterNodes = true;
            treeList.BeforeDropNode += treeList_BeforeDropNode;
            treeList.BeforeDragNode += treeList_BeforeDragNode;
            //treeList.DragOver += treeList_DragOver;
            //treeList.DragDrop += treeList_DragDrop;
            //treeList.DragLeave += treeList_DragLeave;


            treeList.ExpandAll();
        }


        private void frmRelacionCuentaGrupoEstadosFinancieros_Load(object sender, EventArgs e)
        {
            try
            {
               
                InitTreeList(this.treeCuenta);
                InitTreeList(this.treeGrupoCuenta);
                treeCuenta.OptionsFilter.FilterMode = FilterMode.Extended;
                this.cmbGrupoEstadoFinanciero.SelectedIndex = 0;
                dsCuentaGrupo = Cuenta_GrupoEstadosFinancierosDAC.GetDataEmpty();
                _currentRow = dsCuentaGrupo.Tables[0].NewRow();
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        
        private String GetTipoGrupo()
        {
            String sTipo = "";
            if (this.cmbGrupoEstadoFinanciero.SelectedIndex > -1)
            {
                switch (this.cmbGrupoEstadoFinanciero.SelectedIndex)
                {
                    case 0:
                        sTipo = "BC";
                        break;
                    case 1:
                        sTipo = "ER";
                        break;
                    case 2:
                        sTipo = "BG";
                        break;
                }
                return sTipo;
            }
            else
                return "";
        }

   
        private void CargarCuentasContables()
        {
            DataTable dt = Cuenta_GrupoEstadosFinancierosDAC.GetCuentasDisponiblesGrupo(GetTipoGrupo());
            if (dt != null)
            {
                treeCuenta.BeginUpdate();
                this.treeCuenta.DataSource = dt;
                treeCuenta.EndUpdate();
                this.treeCuenta.ExpandAll();
            }
        }

        //private void CargarCuentasGruposEstadosFinancieros()
        //{
        //    DataTable dtCuentaGrupo = Cuenta_GrupoEstadosFinancierosDAC.GetCuentasGrupoEstadosFinancieros(GetTipoGrupo());
        //    DataTable dtGrupos = GrupoEstadosFinancierosDAC.GetData(-1, "*", "*", "*", "*", -1, 1, GetTipoGrupo()).Tables[0];
        //    this.treeGrupoCuenta.Nodes.Clear();
        //    if (dtCuentaGrupo != null) {
                
        //        foreach (DataRow Grupo in dtGrupos.Rows)
        //        {
        //            TreeListNode node = this.treeGrupoCuenta.Nodes.Add(Grupo["Grupo"].ToString(), Grupo["Descr"].ToString(),"",Grupo["IDGrupo"].ToString());
                    
        //            node.Tag = "Root";
        //            DataView dv = new DataView();
        //            dv =  dtCuentaGrupo.DefaultView;
        //            dv.RowFilter = string.Format("IDGrupo='{0}'", Grupo["IDGrupo"]);
        //            foreach (DataRow fila in dv.ToTable().Rows) {
        //                node.Nodes.Add(fila["Cuenta"].ToString(), fila["Descr"].ToString(),fila["IDCuenta"].ToString(),fila["IDGrupo"].ToString());
        //            }
        //        }

        //        this.treeGrupoCuenta.ExpandAll();
        //    }

        //}

        private void CargarCuentasGruposEstadosFinancieros()
        {
            DataTable dtCuentaGrupo = Cuenta_GrupoEstadosFinancierosDAC.GetCuentasGrupoEstadosFinancieros(GetTipoGrupo());
            DataTable dtGrupos = GrupoEstadosFinancierosDAC.GetData(-1, "*", "*", "*", "*", -1, 1, GetTipoGrupo()).Tables[0];
            this.treeGrupoCuenta.Nodes.Clear();
            if (dtGrupos != null)
            {
                TreeListNode nodoAnterior = null;

                foreach (DataRow Grupo in dtGrupos.Rows)
                {
                    TreeListNode node = null;
                    if (Grupo["IDGrupoAcumulador"].ToString() == "0")
                    {
                        //Rama principal
                        node = this.treeGrupoCuenta.Nodes.Add(Grupo["Grupo"].ToString(), Grupo["Descr"].ToString(), "", Grupo["IDGrupo"].ToString());
                    }
                    else { 
                        //Validar si el elemento anterior es papa
                        if (nodoAnterior.GetValue("IDGrupo").ToString() == Grupo["IDGrupoAcumulador"].ToString())
                        { 
                            //Agregar el elemento en el nodo padre
                            node = nodoAnterior.Nodes.Add(Grupo["Grupo"].ToString(), Grupo["Descr"].ToString(), "", Grupo["IDGrupo"].ToString());
                        } else {
                        //Buscar el nodo
                            TreeListNode fnode = treeGrupoCuenta.FindNodeByFieldValue("IDGrupo", Grupo["IDGrupoAcumulador"].ToString());
                            if (fnode!=null){
                                //node = fnode;
                                node = fnode.Nodes.Add(Grupo["Grupo"].ToString(), Grupo["Descr"].ToString(), "", Grupo["IDGrupo"].ToString());
                            }
                        }
                    }
                    if (!Convert.ToBoolean(Grupo["Acumulador"]))
                    {
                        node.Tag = "Root";
                        //Cargar las cuentas que tiene asociado el grupo
                        DataView dv = new DataView();
                        dv = dtCuentaGrupo.DefaultView;
                        dv.RowFilter = string.Format("IDGrupo='{0}'", Grupo["IDGrupo"]);
                        foreach (DataRow fila in dv.ToTable().Rows)
                        {
                            node.Nodes.Add(fila["Cuenta"].ToString(), fila["Descr"].ToString(), fila["IDCuenta"].ToString(), fila["IDGrupo"].ToString());
                        }
                    }
                    if (Convert.ToBoolean(Grupo["Acumulador"]) == true)
                    {
                        node.Tag="Padre";
                        nodoAnterior = node;
                    }
                }

                this.treeGrupoCuenta.ExpandAll();
            }

        }


        TreeListNode HasAsParent(TreeListNode node1, TreeListNode node2)
        {
            if (node1.Level > node2.Level)
                return node1.HasAsParent(node2) ? node1 : null;
            if (node1.Level < node2.Level)
                return node2.HasAsParent(node1) ? node2 : null;
            return null;
        }

        void treeList_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            String sNode = (e.Node.Tag == null) ? "" : e.Node.Tag.ToString();


            int i = 0, j = i + 1;
            List<TreeListNode> nonDragNodes = new List<TreeListNode>();
            while (i != e.Nodes.Count - 1)
            {
                TreeListNode nonDragNode = HasAsParent(e.Nodes[i], e.Nodes[j]);
                if (nonDragNode != null)
                    nonDragNodes.Add(nonDragNode);
                if (j == e.Nodes.Count - 1)
                {
                    i++;
                    j = i + 1;
                }
                else
                    j++;
            }
            if (nonDragNodes.Count == 0) return;
            foreach (TreeListNode node in nonDragNodes)
                e.Nodes.Remove(node);
        }

        void treeList_BeforeDropNode(object sender, BeforeDropNodeEventArgs e)
        {
            try
            {
                if (e.IsCopy) return;
                
                String sControl = e.DestinationNode.TreeList.Name ?? "";
                int IDGrupo = -1;
                String Valor = "";
                String Valor2 = "";
                int sCuenta = 0;
                if (sControl == "treeGrupoCuenta")
                {
                     Valor = (e.DestinationNode.Tag != null) ? e.DestinationNode.Tag.ToString() : "";
                     Valor2 = (e.SourceNode.GetValue("Tag") != null) ? e.SourceNode.GetValue("Tag").ToString() : "";
                     sCuenta = (e.SourceNode.GetValue("IDCuenta") != null && e.SourceNode.GetValue("IDCuenta").ToString()!="") ? Convert.ToInt32(e.SourceNode.GetValue("IDCuenta").ToString()) : 0;
                     IDGrupo = (e.DestinationNode.GetValue("IDGrupo") != null && e.DestinationNode.GetValue("IDGrupo").ToString()!="") ? Convert.ToInt32(e.DestinationNode.GetValue("IDGrupo").ToString()) : 0;
                }
                else {
                    
                    Valor2 = (e.SourceNode.Tag != null) ? (e.SourceNode.Tag.ToString()=="Padre") ? "Root": e.SourceNode.Tag.ToString() : "";
                    Valor = (e.DestinationNode.GetValue("Tag") != null) ? e.DestinationNode.GetValue("Tag").ToString() : "";
                    sCuenta = (e.SourceNode.GetValue("IDCuenta") != null && e.SourceNode.GetValue("IDCuenta").ToString() != "") ? Convert.ToInt32(e.SourceNode.GetValue("IDCuenta").ToString()) : 0;
                    IDGrupo = (e.SourceNode.ParentNode.GetValue("IDGrupo") != null && e.SourceNode.ParentNode.GetValue("IDGrupo").ToString()!="") ? Convert.ToInt32(e.SourceNode.ParentNode.GetValue("IDGrupo").ToString()) : 0;
                 
                }
                bool Cancel = (Valor2 == "Root" || Valor != "Root") ? true : false;

                //TreeListNodes nodes = e.DestinationNode == null ? ((TreeList)sender).Nodes : e.DestinationNode.Nodes;
            
                        e.Cancel = Cancel;

                        if (Cancel == false)
                        {
                            //Quitar esto de cuenta grupo
                            if (sControl == "treeGrupoCuenta")
                                Cuenta_GrupoEstadosFinancierosDAC.Insert(sCuenta, IDGrupo);
                            else
                            {
                                Cuenta_GrupoEstadosFinancierosDAC.Delete(sCuenta, IDGrupo);
                                
                                CargarCuentasContables();
                                
                                
                                //actualizar
                            }


                        }
                       
                      
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbGrupoEstadoFinanciero_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCuentasContables();
            CargarCuentasGruposEstadosFinancieros();
        }

        

     
    }
}