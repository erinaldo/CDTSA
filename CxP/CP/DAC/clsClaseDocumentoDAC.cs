using Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DAC
{
    public static class clsClaseDocumentoDAC
    {
        public static DataSet Get(String TipoDocumento, String IDClase, String Descr)
        {
            String strSQL = "dbo.cppGetClaseDocumento";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@TipoDocumento", TipoDocumento));
            oCmd.Parameters.Add(new SqlParameter("@IDClase", IDClase));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }


        public static long UpdateProveedor(String Operacion, String TipoDocumento, String IDClase, String Descr, int Orden, bool Activo,bool DistribAutom, SqlTransaction oTran)
        {
            long result = -1;
            String strSQL = "dbo.ccpUpdateClaseDocumento";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", TipoDocumento));
            oCmd.Parameters.Add(new SqlParameter("@IDClase", IDClase));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.Parameters.Add(new SqlParameter("@Activo", Activo));
            oCmd.Parameters.Add(new SqlParameter("@Orden", Orden));
            oCmd.Parameters.Add(new SqlParameter("@DistribAutom", DistribAutom));
            
            oCmd.CommandType = CommandType.StoredProcedure;

            oCmd.Transaction = oTran;
            result = oCmd.ExecuteNonQuery();
           
            oCmd.ExecuteNonQuery();

            return result;
        }
            
    }
}
