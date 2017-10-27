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
using CG.TC;
using System.Xml;
using Newtonsoft.Json;


namespace CG
{
    public partial class frmSubirTipoCambio : DevExpress.XtraEditors.XtraForm
    {
        public frmSubirTipoCambio()
        {
            InitializeComponent();
        }

        private void frmSubirTipoCambio_Load(object sender, EventArgs e)
        {
            this.dtpFecha.EditValue = DateTime.Now; 
        }

        public DataTable GetTazaCambio(DateTime Fecha)
        {
            Tipo_Cambio_BCNSoapClient proxyTC = new Tipo_Cambio_BCNSoapClient();
            XmlElement oElement;
            XmlNodeList oNodeLista;
            DataTable dt = new DataTable();

            try
            {
                oElement = (XmlElement)proxyTC.RecuperaTC_Mes(Fecha.Year, Fecha.Month);
                oNodeLista = oElement.GetElementsByTagName("Tc");

                foreach (XmlNode node in oNodeLista.Item(0).ChildNodes)
                {
                    DataColumn col = new DataColumn(node.Name, System.Type.GetType("System.String"));
                    dt.Columns.Add(col);
                }


                for (int i = 0; i < oNodeLista.Count; i++)
                {
                    DataRow fila;
                    fila = dt.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (oNodeLista.Item(i).ChildNodes[j].InnerText != null)
                            fila[j] = oNodeLista.Item(i).ChildNodes[j].InnerText;
                        else
                            fila[j] = null;
                    }
                    dt.Rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El tipo de cambio para la fecha no esta disponible");
            }
            return dt;
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (this.dtpFecha.EditValue==null || this.dtpFecha.EditValue.ToString()==""){
                MessageBox.Show("Por favor seleccione la fecha");
                return;
            }
            String Json = JsonConvert.SerializeObject(GetTazaCambio(Convert.ToDateTime(this.dtpFecha.EditValue)));

            if (Json == "")
            {
                MessageBox.Show("No hay Tipos de Cambio Definidos para este mes, favor revisar...!");
                return;
            }

            if (TipoCambioDAC.SubirTipoCambio(Json) == true)
            {
                MessageBox.Show("Tipos de cambio actualizados.!");
            }

        }

     

     

    }
}