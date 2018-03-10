using Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.DAC
{
    public static class clsGlobalTipoTransaccionDAC
    {
        public static DataSet Get(int IDTipoTran, String Descr, String Naturaleza, String Transaccion)
        {
            String strSQL = "dbo.invGetGlobalTransacciones";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDTipoTran", IDTipoTran));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.Parameters.Add(new SqlParameter("@Natrualeza", Naturaleza));
            oCmd.Parameters.Add(new SqlParameter("@Transaccion", Transaccion));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();
            oAdap.Fill(DS);
            DS.Tables[0].TableName = "Transacciones";
            return DS;
        }
    }
}
