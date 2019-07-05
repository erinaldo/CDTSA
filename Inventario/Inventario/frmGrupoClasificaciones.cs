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

namespace CI
{
    public partial class frmGrupoClasificaciones : Form
    {
        DataSet _dsGrupos = new DataSet();
        DataTable dtGrupos = new DataTable();

        public frmGrupoClasificaciones()
        {
            InitializeComponent();
        }

        private void frmGrupoClasificaciones_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargar los Grupos
                _dsGrupos = clsGrupoClasificacionDAC.GetData(-1, "*");
                dtGrupos = _dsGrupos.Tables[0];

                this.txtDescrC1.Text = dtGrupos.Rows[0]["Descr"].ToString();
                this.chkActivoC1.Checked = Convert.ToBoolean(dtGrupos.Rows[0]["Activo"]);

                this.txtDescrC2.Text = dtGrupos.Rows[1]["Descr"].ToString();
                this.chkActivoC2.Checked = Convert.ToBoolean(dtGrupos.Rows[1]["Activo"]);

                this.txtDescrC3.Text = dtGrupos.Rows[2]["Descr"].ToString();
                this.chkActivoC3.Checked = Convert.ToBoolean(dtGrupos.Rows[2]["Activo"]);

                this.txtDescrC4.Text = dtGrupos.Rows[3]["Descr"].ToString();
                this.chkActivoC4.Checked = Convert.ToBoolean(dtGrupos.Rows[3]["Activo"]);

                this.txtDescrC5.Text = dtGrupos.Rows[4]["Descr"].ToString();
                this.chkActivoC5.Checked = Convert.ToBoolean(dtGrupos.Rows[4]["Activo"]);

                this.txtDescrC6.Text = dtGrupos.Rows[5]["Descr"].ToString();
                this.chkActivoC6.Checked = Convert.ToBoolean(dtGrupos.Rows[5]["Activo"]);
            }
            catch (Exception ex) {
                MessageBox.Show("Han ocurrido los siguientes errores");
            }
        }


        private bool Validar() {
            bool result = true;
            string sMensaje =  "";
            if (this.txtDescrC1.EditValue.ToString() == "") sMensaje = " • Descripción de clasificacion 1";
            if (this.txtDescrC2.EditValue.ToString() == "") sMensaje = " • Descripción de clasificacion 2";
            if (this.txtDescrC3.EditValue.ToString() == "") sMensaje = " • Descripción de clasificacion 3";
            if (this.txtDescrC4.EditValue.ToString() == "") sMensaje = " • Descripción de clasificacion 4";
            if (this.txtDescrC5.EditValue.ToString() == "") sMensaje = " • Descripción de clasificacion 5";
            if (this.txtDescrC6.EditValue.ToString() == "") sMensaje = " • Descripción de clasificacion 6";

            if (sMensaje != "") {
                result = false;
                MessageBox.Show("Por favor verique los siguientes campos: \n\r" + sMensaje);
            }
            return result;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validar los datos
            if (Validar()) {
                if (Guardar(dtGrupos.Rows[0], this.txtDescrC1.Text, Convert.ToBoolean(this.chkActivoC1.EditValue)) &&
                    Guardar(dtGrupos.Rows[1], this.txtDescrC2.Text, Convert.ToBoolean(this.chkActivoC2.EditValue)) &&
                    Guardar(dtGrupos.Rows[2], this.txtDescrC3.Text, Convert.ToBoolean(this.chkActivoC3.EditValue)) &&
                    Guardar(dtGrupos.Rows[3], this.txtDescrC4.Text, Convert.ToBoolean(this.chkActivoC4.EditValue)) &&
                    Guardar(dtGrupos.Rows[4], this.txtDescrC5.Text, Convert.ToBoolean(this.chkActivoC5.EditValue)) &&
                    Guardar(dtGrupos.Rows[5], this.txtDescrC6.Text, Convert.ToBoolean(this.chkActivoC6.EditValue)))
                {
                    MessageBox.Show("Los datos se han actualizados");
                    this.Close();
                }
                else {
                    MessageBox.Show("Ha ocurrido un error");
                }

            }
        }


        private bool Guardar(DataRow currentRow, String Descr,bool Activo)
        {
            bool Result = false;

            Application.DoEvents();
            currentRow.BeginEdit();

            currentRow["Descr"] = Descr;
            currentRow["Activo"] = Activo;
            
            currentRow.EndEdit();

            DataSet _dsChanged = _dsGrupos.GetChanges(DataRowState.Modified);

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
                            msg = msg + dr["Descr"].ToString();
                        }
                    }
                }

                
            }

            //Si no hay errores

            if (okFlag)
            {
                clsGrupoClasificacionDAC.oAdaptador.Update(_dsChanged, "Data");
                
                Application.DoEvents();

                _dsGrupos.AcceptChanges();
                Result = true;
            }
            else
            {
                _dsGrupos.RejectChanges();
                Result = false;
            }

            return Result;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
