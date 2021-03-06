﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CI.DAC
{
    class clsExistenciaBodegaDAC
    {
         public static DataSet GetExistenciasBodega(int IDBodega, int IDProducto, int  IDLote)
        {
            String strSQL = "dbo.invGetExistenciaBodega";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDBodega", IDBodega));
            oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
            oCmd.Parameters.Add(new SqlParameter("@IDLote", IDLote));
            
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = new DataSet();
            oAdap.Fill(DS);
            DS.Tables[0].TableName = "Existencias";
            return DS;
        }


         public static DataSet GetExistenciaBodegaByClasificacion(String Bodega, String Producto, String Lote, String Clasif1, String Clasif2, String Clasif3, String Clasif4, String Clasif5, String Clasif6,bool DetallaLote)
         {
             String strSQL = "dbo.invGetExistenciaBodegabyClasificacion";

             SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

             oCmd.Parameters.Add(new SqlParameter("@Bodega", Bodega));
             oCmd.Parameters.Add(new SqlParameter("@Lote", Lote));
             oCmd.Parameters.Add(new SqlParameter("@Producto", Producto));
             oCmd.Parameters.Add(new SqlParameter("@Clasif1", Clasif1));
             oCmd.Parameters.Add(new SqlParameter("@Clasif2", Clasif2));
             oCmd.Parameters.Add(new SqlParameter("@Clasif3", Clasif3));
             oCmd.Parameters.Add(new SqlParameter("@Clasif4", Clasif4));
             oCmd.Parameters.Add(new SqlParameter("@Clasif5", Clasif5));
             oCmd.Parameters.Add(new SqlParameter("@Clasif6", Clasif6));
             oCmd.Parameters.Add(new SqlParameter("@DetallaLote", DetallaLote));
             

             oCmd.CommandType = CommandType.StoredProcedure;

             SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
             DataSet DS = new DataSet();
             oAdap.Fill(DS);
             DS.Tables[0].TableName = "Existencias";
             return DS;
         }

         public static DataSet CorteInventario(DateTime Fecha, String Bodega, String Producto, String Lote, 
                                                String Clasif1, String Clasif2, String Clasif3, String Clasif4, 
                                                String Clasif5, String Clasif6, bool DetallaLote)
         {
             String strSQL = "dbo.invGetCorteInventario";

             SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

             oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
             oCmd.Parameters.Add(new SqlParameter("@Bodega", Bodega));
             oCmd.Parameters.Add(new SqlParameter("@Lote", Lote));
             oCmd.Parameters.Add(new SqlParameter("@Producto", Producto));
             oCmd.Parameters.Add(new SqlParameter("@Clasif1", Clasif1));
             oCmd.Parameters.Add(new SqlParameter("@Clasif2", Clasif2));
             oCmd.Parameters.Add(new SqlParameter("@Clasif3", Clasif3));
             oCmd.Parameters.Add(new SqlParameter("@Clasif4", Clasif4));
             oCmd.Parameters.Add(new SqlParameter("@Clasif5", Clasif5));
             oCmd.Parameters.Add(new SqlParameter("@Clasif6", Clasif6));
             oCmd.Parameters.Add(new SqlParameter("@DetallaLote", DetallaLote));


             oCmd.CommandType = CommandType.StoredProcedure;

             SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
             DataSet DS = new DataSet();
             oAdap.Fill(DS);
             DS.Tables[0].TableName = "Corte";
             return DS;
         }

         public static DataSet KardexInventario(DateTime FechaInicio,DateTime FechaFin, int IDBodega, long IDProducto, int IDLote)
         {
             String strSQL = "dbo.invGetKardex";

             SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

             oCmd.Parameters.Add(new SqlParameter("@FechaInicio", FechaInicio));
             oCmd.Parameters.Add(new SqlParameter("@FechaFin", FechaFin));
             oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
             oCmd.Parameters.Add(new SqlParameter("@IDLote", IDLote));
             oCmd.Parameters.Add(new SqlParameter("@IDBodega", IDBodega));
             

             oCmd.CommandType = CommandType.StoredProcedure;

             SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
             DataSet DS = new DataSet();
             oAdap.Fill(DS);
             DS.Tables[0].TableName = "Corte";
             return DS;
         }

                        
         public static DataSet MovimientoInventario(DateTime FechaInicio, DateTime FechaFin, int IDBodega, long IDProducto, int IDLote)
         {
             String strSQL = "dbo.invKardexConsolidado";

             SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

             oCmd.Parameters.Add(new SqlParameter("@FechaInicio", FechaInicio));
             oCmd.Parameters.Add(new SqlParameter("@FechaFin", FechaFin));
             oCmd.Parameters.Add(new SqlParameter("@IDProducto", IDProducto));
             oCmd.Parameters.Add(new SqlParameter("@IDLote", IDLote));
             oCmd.Parameters.Add(new SqlParameter("@IDBodega", IDBodega));


             oCmd.CommandType = CommandType.StoredProcedure;

             SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
             DataSet DS = new DataSet();
             oAdap.Fill(DS);
             DS.Tables[0].TableName = "Corte";
             return DS;
         }
         
    }
}
