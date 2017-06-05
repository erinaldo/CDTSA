using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{
    public static class TipoCambioDetalleDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDTipoCambio,Fecha,Monto FROM dbo.globalTipoCambioDetalle WHERE (IDTipoCambio=@IDTipoCambio OR @IDTipoCambio='*') AND (Fecha = @Fecha OR @Fecha IS NULL)";
            String InsertSQL = "[dbo].[globalUpdateTipoCambioDetalle]";
            String UpdateSQL = "[dbo].[globalUpdateTipoCambioDetalle]";
            String DeleteSQL = "[dbo].[globalUpdateTipoCambioDetalle]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.SelectCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.InsertCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.InsertCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.UpdateCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.UpdateCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.DeleteCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.DeleteCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";
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

        public static DataSet GetData(String IDTipoCambio,DateTime Fecha)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTipoCambio"].Value = IDTipoCambio;
            oAdaptador.SelectCommand.Parameters["@Fecha"].Value = Fecha;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }



    }

}
