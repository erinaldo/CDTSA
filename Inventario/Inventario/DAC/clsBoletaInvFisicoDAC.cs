using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CI.DAC
{
    public static class clsBoletaInvFisicoDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetBoletaInvFisico";
            String InsertSQL = "[dbo].[invUpdateBoletaInvFisico]";
            String UpdateSQL = "[dbo].[invUpdateBoletaInvFisico]";
            String DeleteSQL = "[dbo].[invUpdateBoletaInvFisico]";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    InsertCommand = new SqlCommand(InsertSQL, ConnectionManager.GetConnection()),
                    UpdateCommand = new SqlCommand(UpdateSQL, ConnectionManager.GetConnection()),
                    DeleteCommand = new SqlCommand(DeleteSQL, ConnectionManager.GetConnection())
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.SelectCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.SelectCommand.Parameters.Add("@IDProducto", SqlDbType.BigInt).SourceColumn = "IDProducto";
                oAdaptador.SelectCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.SelectCommand.Parameters.Add("@Validada", SqlDbType.Int).SourceColumn = "Validada";
                oAdaptador.SelectCommand.Parameters.Add("@Aplicada", SqlDbType.Int).SourceColumn = "Aplicada";
                oAdaptador.SelectCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.InsertCommand.Parameters.Add("@IDProducto", SqlDbType.BigInt).SourceColumn = "IDProducto";
                oAdaptador.InsertCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.InsertCommand.Parameters.Add("@Cantidad", SqlDbType.Decimal).SourceColumn = "Cantidad";
                oAdaptador.InsertCommand.Parameters.Add("@Validada", SqlDbType.Bit).SourceColumn = "Validada";
                oAdaptador.InsertCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).SourceColumn = "Usuario";
                oAdaptador.InsertCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";

                
                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.UpdateCommand.Parameters.Add("@IDProducto", SqlDbType.BigInt).SourceColumn = "IDProducto";
                oAdaptador.UpdateCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.UpdateCommand.Parameters.Add("@Cantidad", SqlDbType.Decimal).SourceColumn = "Cantidad";
                oAdaptador.UpdateCommand.Parameters.Add("@Validada", SqlDbType.Bit).SourceColumn = "Validada";
                oAdaptador.UpdateCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).SourceColumn = "Usuario";
                oAdaptador.UpdateCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.DeleteCommand.Parameters.Add("@IDProducto", SqlDbType.BigInt).SourceColumn = "IDProducto";
                oAdaptador.DeleteCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.DeleteCommand.Parameters.Add("@Cantidad", SqlDbType.Decimal).SourceColumn = "Cantidad";
                oAdaptador.DeleteCommand.Parameters.Add("@Validada", SqlDbType.Bit).SourceColumn = "Validada";
                oAdaptador.DeleteCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).SourceColumn = "Usuario";
                oAdaptador.DeleteCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                
                return oAdaptador;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static void SetTransactionToAdaptador(bool Activo)
        {
            oAdaptador.UpdateCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.DeleteCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.InsertCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
        }

        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData(int IDBodega, long IDProducto, int IdLote,int Validada,int Aplicada, DateTime Fecha)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDBodega"].Value = IDBodega;
            oAdaptador.SelectCommand.Parameters["@IDProducto"].Value = IDProducto;
            oAdaptador.SelectCommand.Parameters["@IDLote"].Value = IdLote;
            oAdaptador.SelectCommand.Parameters["@Validada"].Value = Validada;
            oAdaptador.SelectCommand.Parameters["@Aplicada"].Value = Validada;
            oAdaptador.SelectCommand.Parameters["@Fecha"].Value = Fecha;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

 
        public static long CreaDocumentoInv(int IDBodega,int IDPaquete,DateTime Fecha,
                                            bool ProductoNoInventarioSetCero, string Usuario, SqlTransaction tran)
        {
            long result = -1;
            String strSQL = "dbo.invCreaPaqueteInvFisico";

            SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDBodega", IDBodega));
            oCmd.Parameters.Add(new SqlParameter("@IDPaquete", IDPaquete));
            oCmd.Parameters.Add(new SqlParameter("@IDTransaccion", result));
            oCmd.Parameters["@IDTransaccion"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
            oCmd.Parameters.Add(new SqlParameter("@ProductoNoInvSetCero", ProductoNoInventarioSetCero));
            oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));

            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Transaction = tran;
            oCmd.ExecuteNonQuery();
            result = (long) oCmd.Parameters["@IDTransaccion"].Value;
            
            return result;

        }

        
    }
}
