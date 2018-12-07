using Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras.DAC
{
    public static class OrdenCompraDAC
    {
       
        public static String Insert()
        {
            String sResult = "OK";
            String strSQL = "dbo.cntUpdateAsientoWithXML";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {
                oCmd.Parameters.Add("@Operacion", SqlDbType.NChar).Value = Operacion;
                oCmd.Parameters.Add("@XML", SqlDbType.Xml).Value = XML;
                oCmd.Parameters.Add("@Asiento", SqlDbType.NVarChar, 20).Value = Asiento;
                oCmd.Parameters["@Asiento"].Direction = ParameterDirection.InputOutput;
                oCmd.Parameters.Add("@Tipo", SqlDbType.NChar).Value = Tipo;
                oCmd.CommandType = CommandType.StoredProcedure;


                if (oCmd.Connection.State == ConnectionState.Closed)
                    oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                sResult = oCmd.Parameters["@Asiento"].Value.ToString();
                return sResult;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                if (oCmd.Connection.State == ConnectionState.Open)
                    oCmd.Connection.Close();
            }
        }

        public static DataSet GetCentroByCuenta(long IDCuenta)
        {
            String strSQL = "dbo.cntGetCentroCostoByCuentaContable";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDCuenta", IDCuenta));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS.Tables["Data"]);
            return DS;
        }

    }
}
