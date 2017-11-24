using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace ControlBancario.DAC
{
    public static class CuentaFormatoChequeDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT  IDFormato ,IDCuentaBanco ,FormatoCheque  ,Activo FROM dbo.cbCuentaFormatoCheque WHERE (IDCuentaBanco=@IDCuentaBanco or @IDCuentaBanco=-1) and (IDFormato=@IDFormato or @IDFormato=-1)";

            String InsertSQL = "[dbo].[cbUpdateCuentaFormatoCheque]";
            String UpdateSQL = "[dbo].[cbUpdateCuentaFormatoCheque]";
            String DeleteSQL = "[dbo].[cbUpdateCuentaFormatoCheque]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.SelectCommand.Parameters.Add("@IDFormato", SqlDbType.Int).SourceColumn = "IDFormato";




                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.InsertCommand.Parameters.Add("@IDFormato", SqlDbType.Int).SourceColumn = "IDFormato";
                oAdaptador.InsertCommand.Parameters["@IDFormato"].Direction = ParameterDirection.InputOutput;          
                oAdaptador.InsertCommand.Parameters.Add("@FormatoCheque", SqlDbType.NChar).SourceColumn = "FormatoCheque";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.UpdateCommand.Parameters.Add("@IDFormato", SqlDbType.Int).SourceColumn = "IDFormato";
                oAdaptador.UpdateCommand.Parameters.Add("@FormatoCheque", SqlDbType.NChar).SourceColumn = "FormatoCheque";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.DeleteCommand.Parameters.Add("@IDFormato", SqlDbType.Int).SourceColumn = "IDFormato";
                oAdaptador.DeleteCommand.Parameters.Add("@FormatoCheque", SqlDbType.NChar).SourceColumn = "FormatoCheque";
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

        public static DataSet GetData(int IDCuentaBanco, int IDFormato)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCuentaBanco"].Value = IDCuentaBanco;
            oAdaptador.SelectCommand.Parameters["@IDFormato"].Value = IDFormato;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

    }
}
