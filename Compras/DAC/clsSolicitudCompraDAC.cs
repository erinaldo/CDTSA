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
    public class resultInsert {
         public int IDSolicitud {get;set;}
         public String Consecutivo { get; set; }
    }

    public static class clsSolicitudCompraDAC
    {
      
       public static resultInsert InsertUpdate(string Operacion,int IDSolicitud,string Consecutivo,DateTime Fecha,DateTime FechaRequerida,int IDEstado, String Comentario,
                                        String UsuarioSolicitud, string Usuario,DateTime createdDate,String createdBy, DateTime recordDate, String updatedBy, SqlTransaction tran)
        {
            resultInsert result = new resultInsert();
            String strSQL = "dbo.invUpdateSolicitudCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.Parameters["@IDSolicitud"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters.Add(new SqlParameter("@Consecutivo", Consecutivo));
            oCmd.Parameters["@Consecutivo"].Size = 20;
            oCmd.Parameters["@Consecutivo"].SqlDbType = SqlDbType.Char;
            oCmd.Parameters["@Consecutivo"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
           oCmd.Parameters.Add(new SqlParameter("@FechaRequerida", FechaRequerida));
           oCmd.Parameters.Add(new SqlParameter("@IDEstado", IDEstado));
           oCmd.Parameters.Add(new SqlParameter("@Comentario", Comentario));
           oCmd.Parameters.Add(new SqlParameter("@UsuarioSolicitud", UsuarioSolicitud));
           oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
           oCmd.Parameters.Add(new SqlParameter("@CreatedDate", createdDate));
           oCmd.Parameters.Add(new SqlParameter("@CreatedBy", createdBy));
           oCmd.Parameters.Add(new SqlParameter("@RecordDate", recordDate));
           oCmd.Parameters.Add(new SqlParameter("@UpdateBy", updatedBy));

            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            oCmd.ExecuteNonQuery();
            if (Operacion == "I")
            {
                result = new resultInsert()
                {
                    IDSolicitud = (int)oCmd.Parameters["@IDSolicitud"].Value,
                    Consecutivo = (String)oCmd.Parameters["@Consecutivo"].Value
                };
            }

            
            return result;

        }


        public static DataSet Get(int IDSolicitud, DateTime FechaInicial, DateTime FechaFinal, int IDEstado)
        {
            String strSQL = "dbo.invGetSolicitudCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.Parameters.Add(new SqlParameter("@IDEstado", IDEstado));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS,"Data");
            return DS;
        }

        
        public static DataSet GetByID(int IDSolicitud)
        {
            String strSQL = "dbo.invGetSolicitudCompraByID";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();
            

            oAdap.Fill(DS,"Data");
            return DS;
        }


        public static DataSet GetSolicitudCompra_OrdenCompra(int IDSolicitud, int IDOrdenCompra, long IDProducto)
        {
            String strSQL = "dbo.invGetSolicitudCompra_OrdenCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
            
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }

        public static DataSet GetSolicitudCompraByProveedor(int IDProveedor, int IDSolicitudDesde,int IDSolicitudHasta,
                        DateTime FechaSolicitudDesde,DateTime FechaSolicitudHasta,DateTime FechaRequeridaDesde,
                        DateTime FechaRequeridaHasta,int IDClas1,int IDClas2,int IDClas3,int IDClas4, int IDClas5, int IDClas6,long IDProducto)
        {
            String strSQL = "dbo.invGetSolicitudesByProveedor";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            oCmd.Parameters.Add(new SqlParameter("@IDSolicitudDesde", IDSolicitudDesde));
            oCmd.Parameters.Add(new SqlParameter("@IDSolicitudHasta", IDSolicitudHasta));
            oCmd.Parameters.Add(new SqlParameter("@FechaSolicitudDesde", FechaSolicitudDesde));
            oCmd.Parameters.Add(new SqlParameter("@FechaSolicitudHasta", FechaSolicitudHasta));
            oCmd.Parameters.Add(new SqlParameter("@FechaRequeridaDesde", FechaRequeridaDesde));
            oCmd.Parameters.Add(new SqlParameter("@FechaRequeridaHasta", FechaRequeridaHasta));
            oCmd.Parameters.Add(new SqlParameter("@IDClasif1", IDClas1));
            oCmd.Parameters.Add(new SqlParameter("@IDClasif2", IDClas2));
            oCmd.Parameters.Add(new SqlParameter("@IDClasif3", IDClas3));
            oCmd.Parameters.Add(new SqlParameter("@IDClasif4", IDClas4));
            oCmd.Parameters.Add(new SqlParameter("@IDClasif5", IDClas5));
            oCmd.Parameters.Add(new SqlParameter("@IDClasif6", IDClas6));
            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));

            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }


    }
}
