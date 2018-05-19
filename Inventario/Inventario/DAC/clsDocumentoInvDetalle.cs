using Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;



namespace CI.DAC
{
    public class clsDocumentoInvDetalle
    {
           public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetTransaccionInvDetalle";
            String InsertSQL = "[dbo].[invUpdateDocumentoInvDetalle]";
            String UpdateSQL = "[dbo].[invUpdateDocumentoInvDetalle]";
            String DeleteSQL = "[dbo].[invUpdateDocumentoInvDetalle]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                oAdaptador.InsertCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.InsertCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipoTran", SqlDbType.Int).SourceColumn = "IDTipoTran";
                oAdaptador.InsertCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.InsertCommand.Parameters.Add("@IDTraslado", SqlDbType.Int).SourceColumn = "IDTraslado";
                oAdaptador.InsertCommand.Parameters.Add("@Cantidad", SqlDbType.Decimal).SourceColumn = "Cantidad";
                oAdaptador.InsertCommand.Parameters.Add("@PrecioUnitarioLocal", SqlDbType.Decimal).SourceColumn = "PrecioUnitarioLocal";
                oAdaptador.InsertCommand.Parameters.Add("@PrecioUnitarioDolar", SqlDbType.Decimal).SourceColumn = "PrecioUnitarioDolar";
                oAdaptador.InsertCommand.Parameters.Add("@Transaccion", SqlDbType.NVarChar).SourceColumn = "Transaccion";
                oAdaptador.InsertCommand.Parameters.Add("@TipoCambio", SqlDbType.Decimal).SourceColumn = "TipoCambio";
                oAdaptador.InsertCommand.Parameters.Add("@Aplicado", SqlDbType.Bit).SourceColumn = "Aplicado";



                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                oAdaptador.UpdateCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.UpdateCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipoTran", SqlDbType.Int).SourceColumn = "IDTipoTran";
                oAdaptador.UpdateCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTraslado", SqlDbType.Int).SourceColumn = "IDTraslado";
                oAdaptador.UpdateCommand.Parameters.Add("@Cantidad", SqlDbType.Decimal).SourceColumn = "Cantidad";
                oAdaptador.UpdateCommand.Parameters.Add("@PrecioUnitarioLocal", SqlDbType.Decimal).SourceColumn = "PrecioUnitarioLocal";
                oAdaptador.UpdateCommand.Parameters.Add("@PrecioUnitarioDolar", SqlDbType.Decimal).SourceColumn = "PrecioUnitarioDolar";
                oAdaptador.UpdateCommand.Parameters.Add("@Transaccion", SqlDbType.NVarChar).SourceColumn = "Transaccion";
                oAdaptador.UpdateCommand.Parameters.Add("@TipoCambio", SqlDbType.Decimal).SourceColumn = "TipoCambio";
                oAdaptador.UpdateCommand.Parameters.Add("@Aplicado", SqlDbType.Bit).SourceColumn = "Aplicado";

                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                oAdaptador.DeleteCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.DeleteCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipoTran", SqlDbType.Int).SourceColumn = "IDTipoTran";
                oAdaptador.DeleteCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTraslado", SqlDbType.Int).SourceColumn = "IDTraslado";
                oAdaptador.DeleteCommand.Parameters.Add("@Cantidad", SqlDbType.Decimal).SourceColumn = "Cantidad";
                oAdaptador.DeleteCommand.Parameters.Add("@PrecioUnitarioLocal", SqlDbType.Decimal).SourceColumn = "PrecioUnitarioLocal";
                oAdaptador.DeleteCommand.Parameters.Add("@PrecioUnitarioDolar", SqlDbType.Decimal).SourceColumn = "PrecioUnitarioDolar";
                oAdaptador.DeleteCommand.Parameters.Add("@Transaccion", SqlDbType.NVarChar).SourceColumn = "Transaccion";
                oAdaptador.DeleteCommand.Parameters.Add("@TipoCambio", SqlDbType.Decimal).SourceColumn = "TipoCambio";
                oAdaptador.DeleteCommand.Parameters.Add("@Aplicado", SqlDbType.Bit).SourceColumn = "Aplicado";


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

        public static DataSet GetData(int IDTransaccion)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTransaccion"].Value = IDTransaccion;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static DataSet GetDataEmpty()
        {
            String strSQL = "SELECT  *  FROM dbo.invTransaccionLinea WHERE 1=2";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        
    }
   
}
