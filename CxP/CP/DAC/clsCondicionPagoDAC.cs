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
    public static class clsCondicionPagoDAC
    {
         public static DataSet Get(int IDCondicionPago, String Descr)
        {
            String strSQL = "dbo.cppGetClaseDocumento";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDCondicionPago", IDCondicionPago));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }


        public static long Update(String Operacion,int IDCondicionPago,String Descr, int Dias, decimal DescuentoContado, bool PagosParciales, bool Activo , SqlTransaction oTran)
        {
            long result = -1;
            String strSQL = "dbo.ccpUpdateClaseDocumento";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));

            oCmd.Parameters.Add(new SqlParameter("@TipoDocumento", IDCondicionPago));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.Parameters.Add(new SqlParameter("@Dias", Dias));
            oCmd.Parameters.Add(new SqlParameter("@DescuentoContado", DescuentoContado));
            oCmd.Parameters.Add(new SqlParameter("@PagosParciales", PagosParciales));
            oCmd.Parameters.Add(new SqlParameter("@Activo", Activo));
            
            oCmd.CommandType = CommandType.StoredProcedure;

            oCmd.Transaction = oTran;
            result = oCmd.ExecuteNonQuery();
           
            oCmd.ExecuteNonQuery();

            return result;
        }
            
    }
    }
}
