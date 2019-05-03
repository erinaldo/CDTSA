using Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO.DAC
{
    public static class clsUtilDAC
    {
        public static DataSet GetParametroCompra(String Parametro)
        {
            String strSQL = "dbo.invGetParametroCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Parametro", Parametro));
            
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
