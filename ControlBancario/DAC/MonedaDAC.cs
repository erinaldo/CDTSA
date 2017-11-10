using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace ControlBancario.DAC
{
    public static class MonedaDAC
    {
        public static DataSet GetMoneda(int IDMoneda)
        {

            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("SELECT IDMoneda,Moneda,Simbolo,Descr,Activo  FROM dbo.globalMoneda WHERE (IDMoneda=@IDMoneda OR @IDMoneda =-1)", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.Text;
                oCmd.Parameters.Add("@IDMoneda", SqlDbType.Int, 50).Value = IDMoneda;
                SqlDataAdapter oAdapatadorTmp = new SqlDataAdapter(oCmd);
                oAdapatadorTmp.Fill(DS, "Data");


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return DS;

        }
    }
}
