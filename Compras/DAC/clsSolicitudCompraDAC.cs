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
    public static class clsSolicitudCompraDAC
    {
       public static long InsertUpdate(string Operacion,int IDSolicitud,DateTime Fecha,DateTime FechaRequerida,int IDEstado, String Comentario,int IDOrdenCompra,
                                        String UsuarioSolicitud,String UsuarioCreaOC,DateTime FechaCreaOC, string Usuario,DateTime createdDate,String createdBy, DateTime recordDate, String updatedBy, SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invUpdateSolicitudCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.Parameters["@IDSolicitud"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
           oCmd.Parameters.Add(new SqlParameter("@FechaRequerida", FechaRequerida));
           oCmd.Parameters.Add(new SqlParameter("@IDEstado", IDEstado));
           oCmd.Parameters.Add(new SqlParameter("@Comentario", Comentario));
           oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
           oCmd.Parameters.Add(new SqlParameter("@UsuarioSolicitud", UsuarioSolicitud));
           oCmd.Parameters.Add(new SqlParameter("@UsuarioCreaOC",UsuarioCreaOC));
           oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
           oCmd.Parameters.Add(new SqlParameter("@CreatedDate", createdDate));
           oCmd.Parameters.Add(new SqlParameter("@CreatedBy", createdBy));
           oCmd.Parameters.Add(new SqlParameter("@RecordDate", recordDate));
           oCmd.Parameters.Add(new SqlParameter("@UpdateBy", updatedBy));

            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();
           if (Operacion =="I")
                result = (long) oCmd.Parameters["@IDSolicitud"].Value;

            
            return result;

        }


        public static DataSet Get(int IDSolicitud, DateTime FechaInicial, DateTime FechaFinal, int IDEstado, ,int IDOrdenCompra)
        {
            String strSQL = "dbo.invGetSolicitudCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.Parameters.Add(new SqlParameter("@IDEstado", IDEstado));
            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS.Tables["Data"]);
            return DS;
        }

    }
}
