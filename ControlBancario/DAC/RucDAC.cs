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
    public static class RucDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT  IDRuc ,r.IDTipoRuc,T.Descr ,RUC ,Nombre ,Alias ,C.IDCuenta,C.Cuenta,C.Descr,R.Activo  FROM dbo.cbRUC r " +
                            "INNER JOIN dbo.cbTipoRUC T ON r.IDTipoRuc=T.IDTipoRuc  " +
                            "INNER JOIN dbo.cntCuenta C ON r.IDCuenta=C.IDCuenta " +
                            "WHERE (IDRuc =@IDRuc OR @IDRuc=-1)";
            String InsertSQL = "[dbo].[cbUpdateRuc]";
            String UpdateSQL = "[dbo].[cbUpdateRUC]";
            String DeleteSQL = "[dbo].[cbUpdateRUC]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDRuc", SqlDbType.Int).SourceColumn = "IDRuc";




                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDRuc", SqlDbType.Int).SourceColumn = "IDRuc";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipoRuc", SqlDbType.Int).SourceColumn = "IDTipoRuc";
                oAdaptador.InsertCommand.Parameters.Add("@RUC", SqlDbType.NChar).SourceColumn = "RUC";
                oAdaptador.InsertCommand.Parameters.Add("@Nombre", SqlDbType.NVarChar).SourceColumn = "Nombre";
                oAdaptador.InsertCommand.Parameters.Add("@Alias", SqlDbType.NVarChar).SourceColumn = "Alias";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDRuc", SqlDbType.Int).SourceColumn = "IDRuc";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipoRuc", SqlDbType.Int).SourceColumn = "IDTipoRuc";
                oAdaptador.UpdateCommand.Parameters.Add("@RUC", SqlDbType.NChar).SourceColumn = "RUC";
                oAdaptador.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.NVarChar).SourceColumn = "Nombre";
                oAdaptador.UpdateCommand.Parameters.Add("@Alias", SqlDbType.NVarChar).SourceColumn = "Alias";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";



                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDRuc", SqlDbType.Int).SourceColumn = "IDRuc";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipoRuc", SqlDbType.Int).SourceColumn = "IDTipoRuc";
                oAdaptador.DeleteCommand.Parameters.Add("@RUC", SqlDbType.NChar).SourceColumn = "RUC";
                oAdaptador.DeleteCommand.Parameters.Add("@Nombre", SqlDbType.NVarChar).SourceColumn = "Nombre";
                oAdaptador.DeleteCommand.Parameters.Add("@Alias", SqlDbType.NVarChar).SourceColumn = "Alias";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
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

        public static DataSet GetData(int IDRuc)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDRuc"].Value = IDRuc;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }
    }
}
