using Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.DAC
{
    public static class clsGlobalConsecutivosDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetGlobalConsecutivo";
            String InsertSQL = "[dbo].[invUpdateGlobalConsecutivos]";
            String UpdateSQL = "[dbo].[invUpdateGlobalConsecutivos]";
            String DeleteSQL = "[dbo].[invUpdateGlobalConsecutivos]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDConsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.SelectCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDConsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@Prefijo", SqlDbType.NChar).SourceColumn = "Prefijo";
                oAdaptador.InsertCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).SourceColumn = "Consecutivo";
                oAdaptador.InsertCommand.Parameters.Add("@Documento", SqlDbType.NVarChar).SourceColumn = "Documento";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";



                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDConsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@Prefijo", SqlDbType.NChar).SourceColumn = "Prefijo";
                oAdaptador.UpdateCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).SourceColumn = "Consecutivo";
                oAdaptador.UpdateCommand.Parameters.Add("@Documento", SqlDbType.NVarChar).SourceColumn = "Documento";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDConsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@Prefijo", SqlDbType.NChar).SourceColumn = "Prefijo";
                oAdaptador.DeleteCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).SourceColumn = "Consecutivo";
                oAdaptador.DeleteCommand.Parameters.Add("@Documento", SqlDbType.NVarChar).SourceColumn = "Documento";
                oAdaptador.DeleteCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";


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

        public static DataSet GetData(int IDConsecutivo, String Descr, int Activo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDConsecutivo"].Value = IDConsecutivo;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            oAdaptador.SelectCommand.Parameters["@Activo"].Value = Activo;


            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }
    }
}
