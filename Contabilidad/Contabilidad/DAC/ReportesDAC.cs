using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CG.DAC
{
    
    public static class ReportesDAC
    {
           public static bool SetCuentaCentroReporte(String sCuentas,String sCentros,int IDReporte,String Usuario)
        {
            String strSQL = "dbo.globalSetCuentaCentroReporte";
            bool Result = false;
            
            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {
                

                oCmd.Parameters.Add(new SqlParameter("@StrCuentas", sCuentas));
                oCmd.Parameters.Add(new SqlParameter("@StrCentros", sCentros));
                oCmd.Parameters.Add(new SqlParameter("@IDReporte", IDReporte));
                oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
                
                
                
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();

                Result = true;
                
            }catch (Exception )
            {
                throw;
            }
            finally
            {
                if (oCmd.Connection.State == ConnectionState.Open)
                    oCmd.Connection.Close();
            }
            return Result;
        }

    }
}
