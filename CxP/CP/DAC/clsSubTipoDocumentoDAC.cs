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
    public static class clsSubTipoDocumentoDAC
    {
        public static DataSet Get(int IDSubTipo, String TipoDocumento, String IDClase, String Descr)
        {
            String strSQL = "dbo.cppGetSubTipoDocumento";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            oCmd.Parameters.Add(new SqlParameter("@IDSubTipo", IDSubTipo));
            oCmd.Parameters.Add(new SqlParameter("@TipoDocumento", TipoDocumento));
            oCmd.Parameters.Add(new SqlParameter("@IDClase", IDClase));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }


        public static long Update(String Operacion,int IDSubTipo, String TipoDocumento, String IDClase, String Descr, String Descripcion, int Consecutivo, bool DistribAutom ,
                    bool  EsRecuperacion,bool SubTipoGeneraAsiento,String NaturalezaCta,String CtaDebito,String CtaCredito,bool Especial, bool ContaCtaEnSubTipo, bool EsInteres, 
                bool EsDeslizamiento , SqlTransaction oTran)
        {
            long result = -1;
            String strSQL = "dbo.ccpUpdateSubTipoDocumento";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
         
            oCmd.Parameters.Add(new SqlParameter("@IDSubtipo", IDSubTipo));
            oCmd.Parameters.Add(new SqlParameter("@TipoDocumento", TipoDocumento));
            oCmd.Parameters.Add(new SqlParameter("@IDClase", IDClase));
            oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
            oCmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
            oCmd.Parameters.Add(new SqlParameter("@Consecutivo", Consecutivo));
            oCmd.Parameters.Add(new SqlParameter("@DistribAutom", DistribAutom));
            oCmd.Parameters.Add(new SqlParameter("@EsRecuperacion", EsRecuperacion));
            oCmd.Parameters.Add(new SqlParameter("@SubTipoGeneraAsiento", SubTipoGeneraAsiento));
            oCmd.Parameters.Add(new SqlParameter("@NaturalezaCta", NaturalezaCta));
            oCmd.Parameters.Add(new SqlParameter("@CtaDebito", CtaDebito));
            oCmd.Parameters.Add(new SqlParameter("@CtaCredito", CtaCredito));
            oCmd.Parameters.Add(new SqlParameter("@Especial", Especial));
            oCmd.Parameters.Add(new SqlParameter("@ContraCtaEnSubTipo", ContaCtaEnSubTipo));
            oCmd.Parameters.Add(new SqlParameter("@esInteres", EsInteres));
            oCmd.Parameters.Add(new SqlParameter("@esDeslizamiento", EsDeslizamiento));
            oCmd.Parameters.Add(new SqlParameter("@DistribAutom", DistribAutom));

            oCmd.CommandType = CommandType.StoredProcedure;

            oCmd.Transaction = oTran;
            result = oCmd.ExecuteNonQuery();

            oCmd.ExecuteNonQuery();

            return result;
        }
    }
}
