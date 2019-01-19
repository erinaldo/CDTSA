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
    public static class clsCondicionPagoDAC
    {
        public static DataSet Get()
        {
            String strSQL = "SELECT  IDCondicionPago ,Descr ,Dias ,DescuentoContado ,PagosParciales ,Activo  FROM dbo.cppCondicionPago WHERE Activo=1";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.CommandType = CommandType.Text;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
