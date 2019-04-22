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
    public static class clsCategoriaProveedorDAC
    {
        public static long InsertUpdate(string Operacion, long IDCategoria, String Descr, int Ctr_CXP, long Cta_CXP,
                            int Ctr_LetraCambio, long Cta_Letra_CXP, int Ctr_ProntoPago_CXP, long Cta_ProntoPago_CXP,
                            int Ctr_Comision_CXP, long Cta_Comision_CxP, int Ctr_Anticipos_CXP, long Cta_Anticipos_CXP ,
                            int Ctr_CierreDebitos_CXP, long Cta_CierreDebitos_CXP, int Ctr_Impuestos_CXP, long Cta_Impuestos_CXP                                                          
                               , SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.cppUpdateCategoriaPoveedor";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());


            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDCategoria", IDCategoria));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.Parameters.Add(new SqlParameter("@Ctr_CXP", Ctr_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Cta_CXP", Cta_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Ctr_LetraCambio", Ctr_LetraCambio));
            oCmd.Parameters.Add(new SqlParameter("@Cta_Letra_CXP", Cta_Letra_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Ctr_ProntoPago_CXP", Ctr_ProntoPago_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Cta_ProntoPago_CXP", Cta_ProntoPago_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Ctr_Comision_CXP", Ctr_Comision_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Cta_Comision_CxP", Cta_Comision_CxP));
            oCmd.Parameters.Add(new SqlParameter("@Ctr_Anticipos_CXP", Ctr_Anticipos_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Cta_Anticipos_CXP", Cta_Anticipos_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Ctr_CierreDebitos_CXP", Ctr_CierreDebitos_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Cta_CierreDebitos_CXP", Cta_CierreDebitos_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Ctr_Impuestos_CXP", Ctr_Impuestos_CXP));
            oCmd.Parameters.Add(new SqlParameter("@Cta_Impuestos_CXP", Cta_Impuestos_CXP));
            

            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();

            return result;

        }


        public static DataSet Get(int IDCategoria, String Descripcion)
        {
            String strSQL = "dbo.cppGetCategoriaProveedor";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDCategoria", IDCategoria));
            oCmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));

            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
