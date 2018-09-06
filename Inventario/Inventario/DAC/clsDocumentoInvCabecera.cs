using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Security;
using System.Text;
using System.Threading.Tasks;

namespace CI.DAC
{
    public class clsDocumentoInvCabecera
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetTransaccionCabecera";
            String InsertSQL = "[dbo].[invUpdateDocumentoInv]";
            String UpdateSQL = "[dbo].[invUpdateDocumentoInv]";
            String DeleteSQL = "[dbo].[invUpdateDocumentoInv]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                oAdaptador.InsertCommand.Parameters["@IDTransaccion"].Direction = ParameterDirection.InputOutput;
                oAdaptador.InsertCommand.Parameters.Add("@ModuloOrigen", SqlDbType.NVarChar).SourceColumn = "ModuloOrigen";
                oAdaptador.InsertCommand.Parameters.Add("@IDPaquete", SqlDbType.Int).SourceColumn = "IDPaquete";
                oAdaptador.InsertCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).SourceColumn = "Fecha";
                oAdaptador.InsertCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).SourceColumn = "Usuario";
                oAdaptador.InsertCommand.Parameters.Add("@Referencia", SqlDbType.NVarChar).SourceColumn = "Referencia";
                oAdaptador.InsertCommand.Parameters.Add("@Documento", SqlDbType.NVarChar,250).SourceColumn = "Documento";
                oAdaptador.InsertCommand.Parameters["@Documento"].Direction = ParameterDirection.InputOutput;
                oAdaptador.InsertCommand.Parameters.Add("@Aplicado", SqlDbType.Bit).SourceColumn = "Aplicado";
                oAdaptador.InsertCommand.Parameters.Add("@EsTraslado", SqlDbType.Bit).SourceColumn = "EsTraslado";
                oAdaptador.InsertCommand.Parameters.Add("@IDTraslado", SqlDbType.Int).SourceColumn = "IDTraslado";



                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                oAdaptador.UpdateCommand.Parameters.Add("@ModuloOrigen", SqlDbType.NVarChar).SourceColumn = "ModuloOrigen";
                oAdaptador.UpdateCommand.Parameters.Add("@IDPaquete", SqlDbType.Int).SourceColumn = "IDPaquete";
                oAdaptador.UpdateCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).SourceColumn = "Fecha";
                oAdaptador.UpdateCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).SourceColumn = "Usuario";
                oAdaptador.UpdateCommand.Parameters.Add("@Referencia", SqlDbType.NVarChar).SourceColumn = "Referencia";
                oAdaptador.UpdateCommand.Parameters.Add("@Documento", SqlDbType.NVarChar).SourceColumn = "Documento";
                oAdaptador.UpdateCommand.Parameters.Add("@Aplicado", SqlDbType.Bit).SourceColumn = "Aplicado";
                oAdaptador.UpdateCommand.Parameters.Add("@EsTraslado", SqlDbType.Bit).SourceColumn = "EsTraslado";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTraslado", SqlDbType.Int).SourceColumn = "IDTraslado";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTransaccion", SqlDbType.Int).SourceColumn = "IDTransaccion";
                oAdaptador.DeleteCommand.Parameters.Add("@ModuloOrigen", SqlDbType.NVarChar).SourceColumn = "ModuloOrigen";
                oAdaptador.DeleteCommand.Parameters.Add("@IDPaquete", SqlDbType.Int).SourceColumn = "IDPaquete";
                oAdaptador.DeleteCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).SourceColumn = "Fecha";
                oAdaptador.DeleteCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).SourceColumn = "Usuario";
                oAdaptador.DeleteCommand.Parameters.Add("@Referencia", SqlDbType.NVarChar).SourceColumn = "Referencia";
                oAdaptador.DeleteCommand.Parameters.Add("@Documento", SqlDbType.NVarChar).SourceColumn = "Documento";
                oAdaptador.DeleteCommand.Parameters.Add("@Aplicado", SqlDbType.Bit).SourceColumn = "Aplicado";
                oAdaptador.DeleteCommand.Parameters.Add("@EsTraslado", SqlDbType.Bit).SourceColumn = "EsTraslado";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTraslado", SqlDbType.Int).SourceColumn = "IDTraslado";


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

        public static DataSet GetData(long IDTransaccion)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTransaccion"].Value = IDTransaccion;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        
        public static DataSet GetDataEmpty()
        {
            String strSQL = "SELECT  IDTransaccion ,IDPaquete,ModuloOrigen ,Fecha ,Usuario , Referencia ,Documento ,Aplicado ,UniqueValue ,EsTraslado , IDTraslado , CreateDate  FROM dbo.invTransaccion WHERE 1=2";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static DataSet GetDataByCriterio(DateTime FechaInicial, DateTime FechaFinal, String Referencia, String  Documento, int IDPaquete,int EsTralado, int  IDTraslado,String Usuario)
        {
            String strSQL = "dbo.invGetTransaccionCabeceraByCriterio";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@FechaInicio", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.Parameters.Add(new SqlParameter("@Documento", Documento));
            oCmd.Parameters.Add(new SqlParameter("@Referencia", Referencia));
            oCmd.Parameters.Add(new SqlParameter("@IDPaquete", IDPaquete));
            oCmd.Parameters.Add(new SqlParameter("@EsTraslado", EsTralado));
            oCmd.Parameters.Add(new SqlParameter("@IDTraslado", IDTraslado));
            oCmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdap.Fill(DS.Tables["Data"]);
            return DS;
        }

    }
}
