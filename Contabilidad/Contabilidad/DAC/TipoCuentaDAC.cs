using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{

    public static class TipoCuentaDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDTipo,Descr,Tipo,Activo  FROM dbo.cntTipoCuenta";
            
            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    
                }

               
                return oAdaptador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        
        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData()
        {
            DataSet DS = CreateDataSet();
        
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

    

        public static Task<DataSet> GetDataAsync(String CodSucursal, String NumSolicitud)
        {
            return Task.Factory.StartNew<DataSet>(() => {
                DataSet DS = CreateDataSet();
                oAdaptador.SelectCommand.Parameters["@CodSucursal"].Value = CodSucursal;
                oAdaptador.SelectCommand.Parameters["@NumSolicitud"].Value = NumSolicitud;
                oAdaptador.Fill(DS.Tables["Data"]);
                return DS;
            });


        }
    }
}
