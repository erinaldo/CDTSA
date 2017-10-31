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
    public static class SubTipoDocumentoDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT  IDTipo ,IDSubtipo ,SubTipo ,Descr ,ReadOnlySys ,Activo ,Consecutivo  FROM dbo.cbSubTipoDocumento where IDTipo=@IDTipo and IDSubTipo=@IDSubTipo";
            String InsertSQL = "[dbo].[cbUpdateSubTipoDocumento]";
            String UpdateSQL = "[dbo].[cbUpdateSubTipoDocumento]";
            String DeleteSQL = "[dbo].[cbUpdateSubTipoDocumento]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";




                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.InsertCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.InsertCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).SourceColumn = "Consecutivo";
                


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.UpdateCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).SourceColumn = "Consecutivo";



                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.DeleteCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).SourceColumn = "Consecutivo";


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

        public static DataSet GetData(int IDTipo,int IDSubTipo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTipo"].Value = IDTipo;
            oAdaptador.SelectCommand.Parameters["@IDSubTipo"].Value = IDSubTipo;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

    }
}
