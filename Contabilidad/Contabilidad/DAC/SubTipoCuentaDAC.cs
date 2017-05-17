using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{
    public static class SubTipoCuentaDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDTipo,IDSubTipo,Descr,SubTipo,Activo,Naturaleza  FROM dbo.cntSubTipoCuenta WHERE (IDTipo=@IDTipo  OR @IDTipo=-1) AND (IDSubTipo =@IDSubTipo OR  @IDSubTipo=-1) ";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),

                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.SelectCommand.Parameters.Add("@IDSubTipo", SqlDbType.NChar).SourceColumn = "IDSubTipo";
                



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

        public static DataSet GetData(int IDTipo,int IDSubTipo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTipo"].Value = IDTipo;
            oAdaptador.SelectCommand.Parameters["@IDSubTipo"].Value = IDSubTipo;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }



    }
}
