using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{
    
    public static class TipoCambioDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDTipoCambio,Descr  FROM dbo.globalTipoCambio WHERE (IDTipoCambio=@IDTipoCambio OR @IDTipoCambio='*')";
            String InsertSQL = "[dbo].[globalUpdateTipoCambio]";
            String UpdateSQL = "[dbo].[globalUpdateTipoCambio]";
            String DeleteSQL = "[dbo].[globalUpdateTipoCambio]";

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
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";



                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";

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

        public static DataSet GetData(String IDTipoCambio)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTipoCambio"].Value = IDTipoCambio;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


        
    }
}
