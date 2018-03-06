using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CI.DAC
{
    public static class clsUnidadMedidaDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDUnidad,Descr,Activo  FROM dbo.invUnidadMedida WHERE (IDUnidad=@IDUnidad  OR @IDUnidad =-1) AND (Descr= @Descr or @Descr = '*'  OR Descr LIKE '%' + @Descr + '%')";
            String InsertSQL = "[dbo].[invUpdateUnidadMedida]";
            String UpdateSQL = "[dbo].[invUpdateUnidadMedida]";
            String DeleteSQL = "[dbo].[invUpdateUnidadMedida]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDUnidad", SqlDbType.Int).SourceColumn = "IDUnidad";
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDUnidad", SqlDbType.Int).SourceColumn = "IDUnidad";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDUnidad", SqlDbType.Int).SourceColumn = "IDUnidad";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDUnidad", SqlDbType.Int).SourceColumn = "IDUnidad";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
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

        public static DataSet GetData(int IDUnidad, String Descr)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDUnidad"].Value = IDUnidad;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


    }
}
