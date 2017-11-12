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
    public static class TipoRucDAC
    {
        public static DataSet GetTipoRuc(int IDTipoRuc)
        {

            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("SELECT IDTipoRuc,Descr  FROM dbo.cbTipoRUC WHERE Activo=1 and (IDTipoRuc=@IDTipoRuc OR @IDTipoRuc =-1)", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.Text;
                oCmd.Parameters.Add("@IDTipoRuc", SqlDbType.Int, 50).Value = IDTipoRuc;
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
