using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Util;
namespace CG
{
    public static class CentroCostoDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT A.IDCentro,A.Nivel1,A.Nivel2,A.Nivel3,A.Centro,A.Descr,A.IDCentroAnterior,A.Acumulador,A.IDCentroAcumulador,B.Descr DescrCentroAcumulador,A.ReadOnlySys,A.Activo  FROM dbo.cntCentroCosto  A LEFT  JOIN dbo.cntCentroCosto B ON A.IDCentroAcumulador=B.IDCentro WHERE (A.IDCentro=@IDCentro OR @IDCentro=-1) AND (A.Nivel1=@Nivel1 OR @Nivel1='*') AND (A.Nivel2=@Nivel2 OR @Nivel2='*') AND (A.Nivel3=@Nivel3 OR @Nivel3='*') AND (A.Descr = @Descr OR @Descr='*')  AND (A.Acumulador=@Acumulador OR @Acumulador =-1) order by Cast(A.Nivel1 as int), Cast(A.Nivel2 as int), cast(A.Nivel3 as int)";
            String InsertSQL = "[dbo].[cntUpdateCentroCosto]";
            String UpdateSQL = "[dbo].[cntUpdateCentroCosto]";
            String DeleteSQL = "[dbo].[cntUpdateCentroCosto]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.SelectCommand.Parameters.Add("@Acumulador", SqlDbType.Int).SourceColumn = "Acumulador";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@IDCentroAnterior", SqlDbType.Int).SourceColumn = "IDCentroAnterior";
                oAdaptador.InsertCommand.Parameters.Add("@Acumulador", SqlDbType.Bit).SourceColumn = "Acumulador";
                oAdaptador.InsertCommand.Parameters.Add("@IDCentroAcumulador", SqlDbType.Int).SourceColumn = "IDCentroAcumulador";


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCentroAnterior", SqlDbType.Int).SourceColumn = "IDCentroAnterior";
                oAdaptador.UpdateCommand.Parameters.Add("@Acumulador", SqlDbType.Bit).SourceColumn = "Acumulador";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCentroAcumulador", SqlDbType.Int).SourceColumn = "IDCentroAcumulador";




                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCentroAnterior", SqlDbType.Int).SourceColumn = "IDCentroAnterior";
                oAdaptador.DeleteCommand.Parameters.Add("@Acumulador", SqlDbType.Bit).SourceColumn = "Acumulador";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCentroAcumulador", SqlDbType.Int).SourceColumn = "IDCentroAcumulador";


                return oAdaptador;
            }catch (Exception)
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

        public static DataSet GetData(int IDCentro, String Nivel1,String Nivel2,String Nivel3,String Descr, int Acumulador)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCentro"].Value = IDCentro;
            oAdaptador.SelectCommand.Parameters["@Nivel1"].Value = Nivel1;
            oAdaptador.SelectCommand.Parameters["@Nivel2"].Value = Nivel2;
            oAdaptador.SelectCommand.Parameters["@Nivel3"].Value = Nivel3;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            oAdaptador.SelectCommand.Parameters["@Acumulador"].Value = Acumulador;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

     
        public static Task<DataSet> GetDataAsync(String CodSucursal, String NumSolicitud)
        {
            return Task.Factory.StartNew<DataSet>(() => {
                DataSet DS = CreateDataSet();
                oAdaptador.SelectCommand.Parameters["@CodSucursal"].Value = CodSucursal;
                oAdaptador.SelectCommand.Parameters["@NumSolicitud"].Value = NumSolicitud;
                oAdaptador.Fill(DS.Tables["Data"]);
                return DS;
            });


        }


        public static int GetNextConsecutivo(int Nivel1, int Nivel2, int Nivel3)
        {
            int ID = 0;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntGetNextConsecutivoCentroCosto", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@Nivel1", SqlDbType.Int).Value = Nivel1;
                oCmd.Parameters.Add("@Nivel2", SqlDbType.Int).Value = Nivel2;
                oCmd.Parameters.Add("@Nivel3", SqlDbType.Int).Value = Nivel3;
                oCmd.Parameters.Add("@Resultado", SqlDbType.BigInt).Direction = ParameterDirection.ReturnValue;


                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@Resultado"].Value != DBNull.Value)
                    ID = (int)oCmd.Parameters["@Resultado"].Value;

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
