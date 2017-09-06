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
    public static class ConsultasDAC
    {
        public static DataSet GetSaldosByCentroCuenta(int IdCuenta,int IDCentro,DateTime FechaInicial, DateTime FechaFinal)
        {
            String strSQL = "dbo.cntConsultaSaldosByCentroCuenta";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IdCuentaContable", IdCuenta));
            oCmd.Parameters.Add(new SqlParameter("@IdCentroCosto", IDCentro));
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();
            oAdap.Fill(DS);
            DS.Tables[0].TableName = "Consolidado";
            DS.Tables[1].TableName = "Detalle";
            return DS;
        }

    }
}
