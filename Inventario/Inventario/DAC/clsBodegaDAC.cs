using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CI.DAC
{
    class clsBodegaDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetBodega";
            String InsertSQL = "[dbo].[invUpdateBodega]";
            String UpdateSQL = "[dbo].[invUpdateBodega]";
            String DeleteSQL = "[dbo].[invUpdateBodega]";

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
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.SelectCommand.Parameters.Add("@Activo", SqlDbType.Int).SourceColumn = "Activo";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Int).SourceColumn = "Activo";
                oAdaptador.InsertCommand.Parameters.Add("@PuedeFacturar", SqlDbType.Int).SourceColumn = "PuedeFacturar";
                oAdaptador.InsertCommand.Parameters.Add("@PuedePreFacturar", SqlDbType.Int).SourceColumn = "PuedePreFacturar";
                oAdaptador.InsertCommand.Parameters.Add("@IDPaqueteFactura", SqlDbType.Int).SourceColumn = "IDPaqueteFactura";
                oAdaptador.InsertCommand.Parameters.Add("@ConsecutivoPreFactura", SqlDbType.Int).SourceColumn = "ConsecutivoPreFactura";

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Int).SourceColumn = "Activo";
                oAdaptador.UpdateCommand.Parameters.Add("@PuedeFacturar", SqlDbType.Int).SourceColumn = "PuedeFacturar";
                oAdaptador.UpdateCommand.Parameters.Add("@PuedePreFacturar", SqlDbType.Int).SourceColumn = "PuedePreFacturar";
                oAdaptador.UpdateCommand.Parameters.Add("@IDPaqueteFactura", SqlDbType.Int).SourceColumn = "IDPaqueteFactura";
                oAdaptador.UpdateCommand.Parameters.Add("@ConsecutivoPreFactura", SqlDbType.Int).SourceColumn = "ConsecutivoPreFactura";

                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDBodega", SqlDbType.Int).SourceColumn = "IDBodega";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@Activo", SqlDbType.Int).SourceColumn = "Activo";
                oAdaptador.DeleteCommand.Parameters.Add("@PuedeFacturar", SqlDbType.Int).SourceColumn = "PuedeFacturar";
                oAdaptador.DeleteCommand.Parameters.Add("@PuedePreFacturar", SqlDbType.Int).SourceColumn = "PuedePreFacturar";
                oAdaptador.DeleteCommand.Parameters.Add("@IDPaqueteFactura", SqlDbType.Int).SourceColumn = "IDPaqueteFactura";
                oAdaptador.DeleteCommand.Parameters.Add("@ConsecutivoPreFactura", SqlDbType.Int).SourceColumn = "ConsecutivoPreFactura";

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

        public static DataSet GetData(int IDBodega, String Descr,int Activo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDBodega"].Value = IDBodega;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            oAdaptador.SelectCommand.Parameters["@Activo"].Value = Activo;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


    }

}