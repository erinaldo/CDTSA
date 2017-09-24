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

namespace CG
{
    public partial class frmCreaEjercicio : DevExpress.XtraEditors.XtraForm
    {
        public frmCreaEjercicio()
        {
            InitializeComponent();
            this.btnGenerar.Click += BtnGenerar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            string sMensaje = "";
            if (Convert.ToBoolean(this.ckEsInicioOperaciones.EditValue) == true)
            {
                if (this.dtMesInicio.EditValue == null)
                {
                    sMensaje = sMensaje + "     • Por favor seleccione el mes de inicio de operaiones. \n\r";
                }
            }

            if (this.dtFechaInicio.EditValue == null)
                sMensaje = sMensaje + "     • Por favor seleccione la fecha de Inicio del Periodo. \n\r";
            if (sMensaje != "")
            {
                MessageBox.Show("Por favor revise los siguientes campos: \n\r" + sMensaje);
                result = false;
            }
            return result;
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            DateTime FechaInicio;
            int MesInicioOperaciones = 0;
            bool InicioOperaciones = false;
            try
            {
                //Validar Datos 
                if (ValidarDatos())
                {
                    if (Convert.ToBoolean(this.ckEsInicioOperaciones.EditValue) == true)
                    {
                        MesInicioOperaciones = Convert.ToDateTime(this.dtMesInicio.EditValue).Month;
                        InicioOperaciones = true;
                    }
                    FechaInicio = Convert.ToDateTime(this.dtFechaInicio.EditValue);
                    EjercicioDAC.CreaEjercicio(FechaInicio, InicioOperaciones, MesInicioOperaciones);
                    MessageBox.Show("Se ha creado el ejercicio...");
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Han ocurrido los siguientes errores, " + ex.Message);
            }
        }

        private void frmCreaEjercicio_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Validar si ya existen periodos

            int IDEjercicio = EjercicioDAC.GetNextConsecutivo();
            if (IDEjercicio == -1)
            {
                //Primera vez que se ejecuta el procedimiento
                this.dtFechaInicio.EditValue = DateTime.Now;
                this.dtMesInicio.EditValue = DateTime.Now;
                this.ckEsInicioOperaciones.EditValue = true;
            }
            else
            {
                this.dtFechaInicio.EditValue = Convert.ToDateTime(DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month + "/" + ++IDEjercicio);
                this.ckEsInicioOperaciones.Enabled = false;
                this.ckEsInicioOperaciones.EditValue = false;
                this.dtMesInicio.Enabled = false;
                this.dtMesInicio.EditValue = null;
            }
        }

    }
}