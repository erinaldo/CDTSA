using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO.DAC
{
    public static class clsDetalleSolicitudCompraDAC
    {

        
        public static long InsertUpdate(string Operacion, int IDSolicitud, long IDProducto,decimal Cantidad,String Comentario, SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invUpdateSolicitudCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
            oCmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
            oCmd.Parameters.Add(new SqlParameter("@Comentario", Comentario));
            
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();
            
            return result;

        }
        
        public static DataSet Get(int IDSolicitud)
        {
            String strSQL = "dbo.invGetSolicitudCompraDetalle";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS.Tables["Data"]);
            return DS;
        }
    }
}
