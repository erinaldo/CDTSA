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
    public static class clsParametrosDAC
    {
        public static long InsertUpdate(int? IDConsecSolicitud,int? IDConsecOrdenCompra, int? IDConsecEmbarque,
                        int? IDConsecDevolucion, int CantLineasOrdenCompra, int? IDBodegaDefault, string IDTipoCambio, 
                        int CantDecimalesPrecio, int CantDecimalesCantidad, String IDTipoAsientoContable, int? IDPaquete,
                        long? CtaTransitoLocal, long? CtrTransitoLocal, long? CtaTransitoExterior, 
                        long? CtrTransitoExterior, bool AplicaAutomaticamenteAsiento, bool CanEditASiento, 
                        bool CanViewAsiento , SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invUpdateParametrosCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());


            oCmd.Parameters.Add(new SqlParameter("@IDConsecSolicitud", (IDConsecSolicitud == null ? DBNull.Value : (Object) IDConsecSolicitud)));
            oCmd.Parameters.Add(new SqlParameter("@IDConsecOrdeCompra", IDConsecOrdenCompra==null ? DBNull.Value : (Object) IDConsecOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@IDConsecEmbarque", IDConsecEmbarque==null ? DBNull.Value : (Object)IDConsecEmbarque));
            oCmd.Parameters.Add(new SqlParameter("@IDConsecDevolucion", IDConsecDevolucion==null ? DBNull.Value : (Object)IDConsecDevolucion));
            oCmd.Parameters.Add(new SqlParameter("@CantLineasOrdenCompra",  CantLineasOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@IDBodegaDefault", IDBodegaDefault==null? DBNull.Value : (Object) IDBodegaDefault));
            oCmd.Parameters.Add(new SqlParameter("@IDTipoCambio", IDTipoCambio ==null ? DBNull.Value : (Object) IDTipoCambio));
            oCmd.Parameters.Add(new SqlParameter("@CantDecimalesPrecio", CantDecimalesPrecio));
            oCmd.Parameters.Add(new SqlParameter("@CantDecimalesCantidad", CantDecimalesCantidad));
            oCmd.Parameters.Add(new SqlParameter("@IDTipoAsientoContable", IDTipoAsientoContable == null ? DBNull.Value : (Object)IDTipoAsientoContable));
            oCmd.Parameters.Add(new SqlParameter("@IDPaquete", IDPaquete==null ? DBNull.Value : (Object) IDPaquete));
            oCmd.Parameters.Add(new SqlParameter("@CtaTransitoLocal", CtaTransitoLocal ==-1 ? DBNull.Value : (Object) CtaTransitoLocal));
            oCmd.Parameters.Add(new SqlParameter("@CtrTransitoLocal", CtrTransitoLocal==-1 ? DBNull.Value : (Object) CtrTransitoLocal));
            oCmd.Parameters.Add(new SqlParameter("@CtaTransitoExterior", CtaTransitoExterior == -1 ? DBNull.Value : (Object) CtaTransitoExterior));
            oCmd.Parameters.Add(new SqlParameter("@CtrTransitoExterior", CtrTransitoExterior == -1 ? DBNull.Value : (Object) CtrTransitoExterior));
            oCmd.Parameters.Add(new SqlParameter("@AplicaAutomaticamenteAsiento", AplicaAutomaticamenteAsiento));
            oCmd.Parameters.Add(new SqlParameter("@CanEditAsiento", CanViewAsiento));
            oCmd.Parameters.Add(new SqlParameter("@CanViewAsiento", CanViewAsiento));

            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();

            return result;

        }

        public static DataSet Get()
        {
            String strSQL = "dbo.invGetParametrosCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
