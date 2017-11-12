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
            String getSQL = "SELECT  IDTipo ,IDSubtipo ,SubTipo ,Descr ,ReadOnlySys ,Activo   FROM dbo.cbSubTipoDocumento where (IDTipo=@IDTipo or @IDTipo=-1) and (IDSubTipo=@IDSubTipo or @IDSubtipo=-1)"  ;
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
                oAdaptador.SelectCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.SelectCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubtipo";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.InsertCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubtipo";
                oAdaptador.InsertCommand.Parameters.Add("@SubTipo", SqlDbType.NChar).SourceColumn = "SubTipo";
                oAdaptador.InsertCommand.Parameters.Add("@Descripcion", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@IDSubtipo", SqlDbType.Int).SourceColumn = "IDSubtipo";
                oAdaptador.UpdateCommand.Parameters.Add("@SubTipo", SqlDbType.NChar).SourceColumn = "SubTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@Descripcion", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                

                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@IDSubtipo", SqlDbType.Int).SourceColumn = "IDSubtipo";
                oAdaptador.DeleteCommand.Parameters.Add("@SubTipo", SqlDbType.NChar).SourceColumn = "SubTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@Descripcion", SqlDbType.NChar).SourceColumn = "Descr";
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

        public static DataSet GetData(int IDTipo,int IDSubTipo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTipo"].Value = IDTipo;
            oAdaptador.SelectCommand.Parameters["@IDSubTipo"].Value = IDSubTipo;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


        public static int GetNextConsecutivo(int IDTipo, int IDSubTipo)
        {
            int ID = 0;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cbNextConsecutivoSubTipoDocumento", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@IDTipo", SqlDbType.Int).Value = IDTipo;
                oCmd.Parameters.Add("@IDSubTipo", SqlDbType.Int).Value = IDSubTipo;
                oCmd.Parameters.Add("@NextConsecutivo", SqlDbType.Int);
                oCmd.Parameters["@NextConsecutivo"].Direction = ParameterDirection.Output;


                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@NextConsecutivo"].Value != DBNull.Value)
                    ID = (int)oCmd.Parameters["@NextConsecutivo"].Value;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return ID;

        }

    }
}
