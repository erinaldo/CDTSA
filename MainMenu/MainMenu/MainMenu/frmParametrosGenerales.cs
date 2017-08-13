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
using System.Drawing.Drawing2D;
using CG;
using CDTSA.DAC;

namespace CDTSA
{
    public partial class frmParametrosGenerales : DevExpress.XtraEditors.XtraForm
    {
        DataSet _dsParametros = new DataSet();
        DataTable _dtParametros = new DataTable();
        
        DataRow _CurrentRow = null;

        public frmParametrosGenerales()
        {
            InitializeComponent();
            this.Load += frmParametrosGenerales_Load;
            AsignarEventos();
        }

        private void AsignarEventos()
        {
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnSalir.Click += btnSalir_Click;
        }


        public static byte[] ImageToByte(Image img)
        {
            img = resizeImage(img, new Size(125, 125));
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
     

        private void ObtenerDatos()
        {
            
            _CurrentRow["Nombre"] = this.txtNombre.EditValue;
            _CurrentRow["Direccion"] = this.txtDireccion.EditValue;
            _CurrentRow["Telefono"] = this.txtTelefono.EditValue;
            _CurrentRow["Logo"] = (this.picLogo.Image!= null)? ImageToByte( this.picLogo.Image):null;
            _CurrentRow["UsaCentroCosto"] = this.chkUsaCentroCosto.EditValue;
            _CurrentRow["SimboloMonedaFuncional"] = this.txtMoneda.EditValue;
            _CurrentRow["SimboloMonedaExtrangera"] = this.txtMonedaExtrangera.EditValue;
            _CurrentRow["TipoCambio"] = this.slkupTipoCambio.EditValue;
        }

        void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_CurrentRow != null)
            {
                Application.DoEvents();
                _CurrentRow.BeginEdit();
                ObtenerDatos();
                _CurrentRow.EndEdit();


                DataSet _dsChanged = _dsParametros.GetChanges(DataRowState.Modified);

                bool okFlag = true;
                if (_dsChanged.HasErrors)
                {
                    okFlag = false;
                    string msg = "Error en la fila con el tipo Id";

                    foreach (DataTable tb in _dsChanged.Tables)
                    {
                        if (tb.HasErrors)
                        {
                            DataRow[] errosRow = tb.GetErrors();

                            foreach (DataRow dr in errosRow)
                            {
                                msg = msg + dr["Nombre"].ToString();
                            }
                        }
                    }


                }

                //Si no hay errores

                if (okFlag)
                {
                    DAC.ParametrosGeneralesDAC.oAdaptador.Update(_dsChanged, "Data");
                    // lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                    Application.DoEvents();
                    // isEdition = false;
                    _dsParametros.AcceptChanges();
                    // PopulateGrid();
                    //HabilitarControles(false);
                }
                else
                {
                    _dsParametros.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                _CurrentRow = _dtParametros.NewRow();
                ObtenerDatos();
                _dtParametros.Rows.Add(_CurrentRow);
                try
                {
                    ParametrosGeneralesDAC.oAdaptador.Update(_dsParametros, "Data");
                    _dsParametros.AcceptChanges();
                    
                    Application.DoEvents();
                    
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    _dsParametros.RejectChanges();
                    _CurrentRow = null;
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        private void CargarParametros()
        {
            try
            {
                _dsParametros = DAC.ParametrosGeneralesDAC.GetData();
                _dtParametros = _dsParametros.Tables[0];
                if (_dsParametros.Tables[0].Rows.Count > 0)
                {
                    _CurrentRow = _dsParametros.Tables[0].Rows[0];
                    this.chkUsaCentroCosto.EditValue = Convert.ToBoolean(_CurrentRow["UsaCentroCosto"]);
                    this.txtNombre.EditValue = _CurrentRow["Nombre"].ToString();
                    this.txtDireccion.EditValue = _CurrentRow["Direccion"].ToString();
                    this.txtTelefono.EditValue = _CurrentRow["Telefono"].ToString();
                    this.txtMoneda.EditValue = _CurrentRow["SimboloMonedaFuncional"].ToString();
                    this.txtMonedaExtrangera.EditValue = _CurrentRow["SimboloMonedaExtrangera"].ToString();
                    this.picLogo.EditValue = _CurrentRow["Logo"];
                    this.slkupTipoCambio.EditValue = _CurrentRow["TipoCambio"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void frmParametrosGenerales_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            CargarParametros();

            Util.Util.ConfigLookupEdit(this.slkupTipoCambio, CG.TipoCambioDAC.GetData("*").Tables["Data"], "Descr", "IDTipoCambio");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoCambio, "[{'ColumnCaption':'Tipo','ColumnField':'IDTipoCambio','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
            //configurar los searchlokup
            
            
        }

     
    }
}