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
    public static class clsGlobalPaisDAC
    {
        public static DataSet Get(long IDPais)
        {
            String strSQL = "dbo.invGetGlobalPais";
            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            oCmd.Parameters.Add(new SqlParameter("@IDPais", IDPais));
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();
            oAdap.Fill(DS,"Data");
            return DS;
        }

    }
}
