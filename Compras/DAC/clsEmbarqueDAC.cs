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
    public static class clsEmbarqueDAC
    {
        public static long InsertUpdate(string Operacion, long IDEmbarque, ref String Embarque, DateTime Fecha, DateTime FechaEmbarque,
              String Asiento, int IDBodega, int IDProveedor, long IDOrdenCompra, int IDDocumentoCP, decimal TipoCambio, String Usuario,
              DateTime CreateDate, String CreatedBy, DateTime RecordDate, String UpdateBy, SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invUpdateEmbaque";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDEmbarque", IDEmbarque));
            oCmd.Parameters["@IDEmbarque"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters["@IDEmbarque"].Size = 20;
            oCmd.Parameters.Add(new SqlParameter("@Embarque", Embarque));
            oCmd.Parameters["@Embarque"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters["@Embarque"].Size = 20;
            oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
            oCmd.Parameters.Add(new SqlParameter("@FechaEmbarque", FechaEmbarque));
            oCmd.Parameters.Add(new SqlParameter("@Asiento", ""));
            oCmd.Parameters.Add(new SqlParameter("@IDBodega", IDBodega));
            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@IDDocumentoCP", IDDocumentoCP));
            oCmd.Parameters.Add(new SqlParameter("@TipoCambio", TipoCambio));
            oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
            oCmd.Parameters.Add(new SqlParameter("@CreateDate", CreateDate));
            oCmd.Parameters.Add(new SqlParameter("@CreatedBy", CreatedBy));
            oCmd.Parameters.Add(new SqlParameter("@RecordDate", RecordDate));
            oCmd.Parameters.Add(new SqlParameter("@UpdateBy", UpdateBy));


            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();
            if (Operacion == "I")
            {
                result = (long)oCmd.Parameters["@IDEmbarque"].Value;
                Embarque = oCmd.Parameters["@Embarque"].Value.ToString();
            }


            return result;

        }

        public static DataSet Get(int IDEmbarque, DateTime FechaInicial, DateTime FechaFinal, int IDProveedor,
                                int IDSolicitud, string OrdenCompra, int IDDocumentoCP)
        {
            String strSQL = "dbo.invGetEmbarque";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDEmbarque", IDEmbarque));
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            oCmd.Parameters.Add(new SqlParameter("@IDSolicitud", IDSolicitud));
            oCmd.Parameters.Add(new SqlParameter("@OrdenCompra", OrdenCompra));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }


        public static DataSet GetByID(long IDEmbarque, long IDOrdenCompra)
        {
            String strSQL = "dbo.invGetEmbarqueByID";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDEmbarque", IDEmbarque));
            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
