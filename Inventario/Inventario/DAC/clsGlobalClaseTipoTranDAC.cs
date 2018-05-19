using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CI.DAC
{
    public class clsGlobalClaseTipoTranDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.GetGlobalClaseTipoTran";
            
            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.SelectCommand.Parameters.Add("@Transaccion", SqlDbType.NVarChar).SourceColumn = "Transaccion";
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                



                

                return oAdaptador;
            }
            catch (Exception)
            {
                throw;
            }
        }



        
        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData(String Transaccion, String Descr)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@Transaccion"].Value = Transaccion;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            


            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }
    }
}
