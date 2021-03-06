﻿using Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO.DAC
{
    public static class clsOrdenCompraDetalleDAC
    {
        public static long InsertUpdate(string Operacion,long IDOrdenCompra,long IDProducto,decimal Cantidad,decimal CantidadAceptada,
                        decimal CantidadRechazada,decimal PrecioUnitario,decimal Impuesto,decimal PorcDesc,decimal MontoDesc,
                        int IDEstado,String Comentario,SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invUpdateOrdenCompraDetalle";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Operacion", Operacion));
            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
            oCmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
            oCmd.Parameters.Add(new SqlParameter("@CantidadAceptada", CantidadAceptada));
            oCmd.Parameters.Add(new SqlParameter("@CantidadRechazada", CantidadRechazada));
            oCmd.Parameters.Add(new SqlParameter("@PrecioUnitario", PrecioUnitario));
            oCmd.Parameters.Add(new SqlParameter("@Impuesto", Impuesto));
            oCmd.Parameters.Add(new SqlParameter("@PorcDesc", PorcDesc));
            oCmd.Parameters.Add(new SqlParameter("@MontoDesc",MontoDesc));
            oCmd.Parameters.Add(new SqlParameter("@Estado", IDEstado));
            oCmd.Parameters.Add(new SqlParameter("@Comentario", Comentario));
            

            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            result = oCmd.ExecuteNonQuery();
            
            return result;

        }


        public static bool UpdateCantidadRecibida(long IDOrdenCompra, long IDProducto, decimal Cantidad, SqlTransaction tran)
        {
            bool result = false ;
            String strSQL = "dbo.invUpdateCantRecibidaOrdenCompra";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));
            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
            oCmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));


            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            oCmd.ExecuteNonQuery();
            result = true;
            return result;

        }


        public static DataSet Get(long IDOrdenCompra)
        {
            String strSQL = "dbo.invGetOrdenCompraDetalle";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDOrdenCompra", IDOrdenCompra));

            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS,"Data");
            return DS;
        }


        public static DataSet GetEmptyImportExcel()
        {
            String strSQL = "dbo.invGetOrdenCompraDetalleEmptyExcel";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());


            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();

            oAdap.Fill(DS, "Data");
            return DS;
        }
    }
}
