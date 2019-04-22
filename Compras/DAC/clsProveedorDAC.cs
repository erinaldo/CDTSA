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
    public static class clsProveedorDAC
    {
        public static DataSet Get(long IDProveedor,String Nombre,int IDCategoria)
        {
            String strSQL = "dbo.cppGetProveedor";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            oCmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
            oCmd.Parameters.Add(new SqlParameter("@IDCategoria", IDCategoria));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
        

        public static long UpdateProveedor(String Operacion, long IDProveedor,String Nombre,int IDRuc,bool Activo,String Alias,int IDPais,int IDMoneda,
            DateTime FechaIngreso,String Contacto,String Telefono,int IDImpuesto,int IDCategoria,int IDCondicionPago,decimal PorcDescuento,decimal PorcInteresMora, 
            string Email,string Direccion, bool Multimoneda, bool PagosCongelados, bool IsLocal, int TipoContribuyente, SqlTransaction    oTran ){
            long result = -1;
            String strSQL = "dbo.invUpdateProveedor";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDProveedor", IDProveedor));
            oCmd.Parameters["@IDProveedor"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
            oCmd.Parameters.Add(new SqlParameter("@IDRuc", IDRuc));
            oCmd.Parameters.Add(new SqlParameter("@Activo", Activo));
            oCmd.Parameters.Add(new SqlParameter("@Alias", Alias));
            oCmd.Parameters.Add(new SqlParameter("@IDPais", IDPais));
            oCmd.Parameters.Add(new SqlParameter("@IDMoneda", IDMoneda));
            oCmd.Parameters.Add(new SqlParameter("@FechaIngreso", FechaIngreso));
            oCmd.Parameters.Add(new SqlParameter("@Contacto", Contacto));
            oCmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
            oCmd.Parameters.Add(new SqlParameter("@IDImpuesto", IDImpuesto));
            oCmd.Parameters.Add(new SqlParameter("@IDCategoria", IDCategoria));
            oCmd.Parameters.Add(new SqlParameter("@IDCondicionPago", IDCondicionPago));
            oCmd.Parameters.Add(new SqlParameter("@PorcDescuento", PorcDescuento));
            oCmd.Parameters.Add(new SqlParameter("@PorcInteresMora", PorcInteresMora));
            oCmd.Parameters.Add(new SqlParameter("@Email", Email));
            oCmd.Parameters.Add(new SqlParameter("@Direccion", Direccion));
            oCmd.Parameters.Add(new SqlParameter("@MultiMoneda", Multimoneda));
            oCmd.Parameters.Add(new SqlParameter("@PagosCongelados", PagosCongelados));
            oCmd.Parameters.Add(new SqlParameter("@IsLocal", IsLocal));
            oCmd.Parameters.Add(new SqlParameter("@TipoContribuyente", TipoContribuyente));
            oCmd.CommandType = CommandType.StoredProcedure;

            oCmd.Transaction = oTran;
            result = oCmd.ExecuteNonQuery();
            if (Operacion == "I")
            {
                result = (long)oCmd.Parameters["@IDProveedor"].Value;
            }
            oCmd.ExecuteNonQuery();

            return result; 
        }
            
    }
}
