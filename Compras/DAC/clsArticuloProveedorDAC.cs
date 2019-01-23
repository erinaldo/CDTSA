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
    public static class clsArticuloProveedorDAC
    {
        
        public static long InsertUpdate(string Operacion,long IDProducto,int IDProveedor,int IDPaisManoFactura,
                                decimal LoteMinmoCompra,decimal PesoMinimoCompra, DateTime Fecha,String Usuario ,SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invUpdateArticuloProveedor";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());


            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            oCmd.Parameters.Add(new SqlParameter("@IDPaisManoFactura", IDPaisManoFactura));
            oCmd.Parameters.Add(new SqlParameter("@LoteMinCompra", LoteMinmoCompra));
            oCmd.Parameters.Add(new SqlParameter("@PesoMinimoCompra", PesoMinimoCompra));
            oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
            oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));

            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();
            
            return result;

        }


        public static DataSet Get(long IDProducto, int IDProveedor)
        {
            String strSQL = "dbo.invGetArticuloProveedor";
                                 
            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS,"Data");
            return DS;
        }

        
        public static DataSet GetProductosSinAsociar(int IDProveedor,int Clasif1,int Clasif2,int Clasif3, int Clasif4, int Clasif5, int Clasif6)
        {
            String strSQL = "dbo.invGetProductosSinAsociarProveedor";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            oCmd.Parameters.Add(new SqlParameter("@IDClasificacion1", Clasif1));
            oCmd.Parameters.Add(new SqlParameter("@IDClasificacion2", Clasif2));
            oCmd.Parameters.Add(new SqlParameter("@IDClasificacion3", Clasif3));
            oCmd.Parameters.Add(new SqlParameter("@IDClasificacion4", Clasif4));
            oCmd.Parameters.Add(new SqlParameter("@IDClasificacion5", Clasif5));
            oCmd.Parameters.Add(new SqlParameter("@IDClasificacion6", Clasif6));
            

            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
