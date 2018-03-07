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
    class clsPaqueteDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetPaquete";
            String InsertSQL = "[dbo].[invUpdatePaquete]";
            String UpdateSQL = "[dbo].[invUpdatePaquete]";
            String DeleteSQL = "[dbo].[invUpdatePaquete]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDPaquete", SqlDbType.Int).SourceColumn = "IDPaquete";
                oAdaptador.SelectCommand.Parameters.Add("@Paquete", SqlDbType.NChar).SourceColumn = "Paquete";
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.SelectCommand.Parameters.Add("@IDTipoTran", SqlDbType.Int).SourceColumn = "IDTipoTran";
                oAdaptador.SelectCommand.Parameters.Add("@IDconsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.SelectCommand.Parameters.Add("@Activo", SqlDbType.Int).SourceColumn = "Activo";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDPaquete", SqlDbType.Int).SourceColumn = "IDPaquete";
                oAdaptador.InsertCommand.Parameters.Add("@Paquete", SqlDbType.NVarChar).SourceColumn = "Paquete";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@IDConsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipoTran", SqlDbType.Int).SourceColumn = "IDTipoTran";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";



                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDPaquete", SqlDbType.Int).SourceColumn = "IDPaquete";
                oAdaptador.UpdateCommand.Parameters.Add("@Paquete", SqlDbType.NVarChar).SourceColumn = "Paquete";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@IDConsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipoTran", SqlDbType.Int).SourceColumn = "IDTipoTran";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDPaquete", SqlDbType.Int).SourceColumn = "IDPaquete";
                oAdaptador.DeleteCommand.Parameters.Add("@Paquete", SqlDbType.NVarChar).SourceColumn = "Paquete";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@IDConsecutivo", SqlDbType.Int).SourceColumn = "IDConsecutivo";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipoTran", SqlDbType.Int).SourceColumn = "IDTipoTran";
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

        public static DataSet GetData(int IDPaquete, String Paquete, String Descr, int IDConsecutivo, int IDTipoTran,int Activo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDPaquete"].Value = IDPaquete;
            oAdaptador.SelectCommand.Parameters["@Paquete"].Value = Paquete;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            oAdaptador.SelectCommand.Parameters["@IDConsecutivo"].Value = IDConsecutivo;
            oAdaptador.SelectCommand.Parameters["@IDTipoTran"].Value = IDTipoTran;
            oAdaptador.SelectCommand.Parameters["@Activo"].Value = Activo;
            

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }
    }
}
