using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public static class Acciones
    {
        public enum PrivilegiosGeneralesType
        {
            AccesoAlSistema = 1,
            ModificacionReportes =2,
            AdministracionSistema = 3,
            Contabilidad = 100,
            

            //Parametros que salen del modulo principal
            ParametrosGenerales = 4,
        }
        public enum PrivilegiosContableType
        {
            CatalogoCuentaContable = 101,
            AgregarCuentaContable = 102,
            EditarCuentaContable = 103,
            EliminarCuentaContable = 104,
            CatalogoCentroCosto = 105,
            AgregarCentroCosto = 106,
            EditarCentroCosto = 107,
            EliminarCentroCosto = 108,
            AsientodeDiario = 109,
            AgregarAsientodeDiario = 110,
            EditarAsientodeDiario = 111,
            EliminarAsientodeDiario = 112,
            MayorizarAsientodeDiario = 113,
            RegistrarTipoCambio=114,
            AnularAsientoMayorizado = 115,
            ParemtrosModuloContable = 116,
            PeriodosContables = 117,
            CerrarPeridoContable = 118,
            EstablecerPeridoTrabajo = 119,
            CrearEjerciciosContables = 120
        }

        
    }
}
