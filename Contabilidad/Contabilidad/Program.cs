using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new frmListadoAsientoDiario());
            //Application.Run(new frmAsiento("CG0000000016"));
            //Application.Run(new frmListadoTipoCambio());
            Application.Run(new frmListadoCuentaContable());
        }
    }
}
