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
    public static class clsGlobalConsecutivosDAC
    {
        public static DataSet Get(int IDConsecutivo, String Prefijo)
        {
            String strSQL = "dbo.globalGetConsecutivos";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDConsecutivo", IDConsecutivo));
            oCmd.Parameters.Add(new SqlParameter("@Prefijo", Prefijo));

            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
