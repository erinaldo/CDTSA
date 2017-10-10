using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CG
{


    public static class TipoAsientoDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT Tipo,Descr,Consecutivo,UltimoAsiento  FROM dbo.cntTipoAsiento WHERE Activo=1";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),

                };

             
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

        public static DataSet GetData()
        {
            DataSet DS = CreateDataSet();
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


        public static DataSet GetTipoAsientoByUsuario(String Usuario)
        {
            String strSQL = "SELECT  Tipo , Descr ,  Consecutivo , UltimoAsiento ,  Activo , ReadOnlySys  FROM dbo.cntTipoAsiento WHERE Tipo IN (SELECT Tipo  FROM TipoAsientoUsuario WHERE Usuario =@Usuario)";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
            oCmd.CommandType = CommandType.Text;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdap.Fill(DS.Tables["Data"]);
            return DS;
        }
    }
}
