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
    public static class clsOrdenCompraDAC {
    
        public static long InsertUpdate(string Operacion,long IDOrdenCompra,ref String OrdenCompra,DateTime Fecha,DateTime FechaRequerida,DateTime FechaEmision,DateTime FechaRequeridaEmbarque,DateTime FechaCotizacion,
                        int IDEstado, int IDBodega,int IDProveedor,int IDMoneda, int IDCondicionPago,Decimal Descuento, Decimal Flete,Decimal Seguro, Decimal Documentacion, Decimal Anticipos,
                        int  IDEmbarque , int IDDocumentoCP,Decimal TipoCambio, string Usuario,string UsuarioEmbarque,DateTime FechaCreaEmbarque,
                        String UsuarioAprobacion,DateTime FechaAprobacion,DateTime createdDate,String createdBy, DateTime recordDate, String updatedBy, SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invUpdateOrdenCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@OrdenCompra", OrdenCompra));
            oCmd.Parameters["@IDOrdenCompra"].Direction= ParameterDirection.InputOutput;
            oCmd.Parameters["@OrdenCompra"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters["@Ordencompra"].Size = 20;
            oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
               oCmd.Parameters.Add(new SqlParameter("@FechaRequerida", FechaRequerida));
               oCmd.Parameters.Add(new SqlParameter("@FechaEmision", FechaEmision));
               oCmd.Parameters.Add(new SqlParameter("@FechaRequeridaEmbarque", FechaRequeridaEmbarque));
               oCmd.Parameters.Add(new SqlParameter("@FechaCotizacion", FechaCotizacion));
               oCmd.Parameters.Add(new SqlParameter("@IDEstado", IDEstado));
               oCmd.Parameters.Add(new SqlParameter("@IDBodega", IDBodega));
               oCmd.Parameters.Add(new SqlParameter("@IDProveedor",IDProveedor));
               oCmd.Parameters.Add(new SqlParameter("@IDMoneda", IDMoneda));
               oCmd.Parameters.Add(new SqlParameter("@IDCondicionPago", IDCondicionPago));
               oCmd.Parameters.Add(new SqlParameter("@Descuento", Descuento));
               oCmd.Parameters.Add(new SqlParameter("@Flete", Flete));
               oCmd.Parameters.Add(new SqlParameter("@Seguro", Seguro));
               oCmd.Parameters.Add(new SqlParameter("@Documentacion", Documentacion));
            oCmd.Parameters.Add(new SqlParameter("@Anticipos", Anticipos));
            //oCmd.Parameters.Add(new SqlParameter("@IDTipoProrrateo", IDTipoProrrateo));
            oCmd.Parameters.Add(new SqlParameter("@IDEmbarque", IDEmbarque));
            oCmd.Parameters.Add(new SqlParameter("@IDDocumentoCP", IDDocumentoCP));
            oCmd.Parameters.Add(new SqlParameter("@TipoCambio", TipoCambio));
            oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
            oCmd.Parameters.Add(new SqlParameter("@UsuarioEmbarque", UsuarioEmbarque));
            oCmd.Parameters.Add(new SqlParameter("@FechaCreaEmbarque", FechaCreaEmbarque));
            oCmd.Parameters.Add(new SqlParameter("@UsuarioAprobacion", UsuarioAprobacion));
            oCmd.Parameters.Add(new SqlParameter("@FechaAprobacion", FechaAprobacion));
            oCmd.Parameters.Add(new SqlParameter("@CreateDate", createdDate));
            oCmd.Parameters.Add(new SqlParameter("@CreatedBy", createdBy));
            oCmd.Parameters.Add(new SqlParameter("@RecordDate", recordDate));
            oCmd.Parameters.Add(new SqlParameter("@UpdatedBy", updatedBy));
            


            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();
           if (Operacion =="I")                       
           {
                OrdenCompra = oCmd.Parameters["@OrdenCompra"].Value.ToString();
                result = (long) oCmd.Parameters["@IDOrdenCompra"].Value;
           }

            
            return result;

        }


        public static DataSet Get(int IDOrdenCompra, DateTime FechaInicial, DateTime FechaFinal,String Proveedor, String Estado,DateTime FechaRequeridaInicial, DateTime FechaRequeridaFinal )
        {
            String strSQL = "dbo.invGetOrdenCompra";
                                 
            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.Parameters.Add(new SqlParameter("@Proveedor", Proveedor));
            oCmd.Parameters.Add(new SqlParameter("@Estado", Estado));
            oCmd.Parameters.Add(new SqlParameter("@FechaRequeridaInicial", FechaRequeridaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaRequeridaFinal", FechaRequeridaFinal));
            
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS,"Data");
            return DS;
        }


        public static DataSet GetByID(long IDOrdenCompra)
        {
            String strSQL = "dbo.invGetOrdenCompraByID";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            

            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
